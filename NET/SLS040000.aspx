<%@ Page Title="Lot Inventory Masterlist" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS040000.aspx.vb" Inherits="NET.SLS040000" MaintainScrollPositionOnPostback = "true"  %>
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
					<h1 class="d-flex text-white my-1 fs-3">Sales Admin</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Lot Inventory Masterlist</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Open Lots Checklist</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Toolbar-->
				<div class="d-flex flex-wrap flex-stack">
					<!--begin::Controls-->
					<div class="d-flex flex-wrap my-1">
						<!--begin::Tab nav-->
						<ul class="nav nav-pills me-5">
							<li class="nav-item m-0">
								<a href="SLS010000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Agent Masterlist">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/agent-masterlist.svg" alt="agent-masterlist" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS020000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Seller Management">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/seller-management.svg" alt="seller-management" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS030000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Reservation Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/reservation-monitoring.svg" alt="reservation-monitoring" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS040000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Lot Inventory Masterlist">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/lot-inventory-masterlist.svg" alt="lot-inventory-masterlist" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS050000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Sales Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sales-monitoring1.svg" alt="sales-monitoring" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="SLS060000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Seller's Ranking" >
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sellers-ranking.svg" alt="sellers-ranking" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
						</ul>
						<!--end::Tab nav-->
					</div>
					<!--end::Controls-->
				</div>
				<!--end::Toolbar-->
			</div>
			<!--begin::Container-->
			
			<asp:Button ID="btnProjTOL" runat="server" Text="Button" OnClick="btnProjTOL_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnProjReinstatement" runat="server" Text="Button" OnClick="btnProjReinstatement_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnProjTL" runat="server" Text="Button" OnClick="btnProjTL_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnProjTechnical" runat="server" Text="Button" OnClick="btnProjTechnical_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<%-- begin::Lot Inventory Masterlist --%>
		<asp:UpdatePanel ID="mdlInventoryDtl" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
		<ContentTemplate>
			<div class="col-lg-12">
				<div class="card card-flush h-lg-100">
					<div class="card-header" style="border-bottom: 1px solid #EFF2F5;">
						<div class="d-flex align-items-center">
							<%-- begin::header img --%>
							<div class="symbol me-5">
								<img id="img1" runat="server" class="mw-125px mw-lg-125px" src="assets/media/svg/apps/lot-inventory-masterlist.svg" alt="project-image" />
							</div>
							<%-- end::header img --%>
                            <%-- begin::title --%>
							<div class="d-flex flex-column">
								<span id="spnMstr" runat="server" class="card-label fs-4 fw-bolder d-none">Admin's Masterlist</span>
								<span id="spnTOL" runat="server" class="card-label fs-4 fw-bolder d-none">Hold: For TOL</span>
								<span id="spnReinstatement" runat="server" class="card-label fs-4 fw-bolder d-none">Hold: For Reinstatement</span>
								<span id="spnTL" runat="server" class="card-label fs-4 fw-bolder d-none">Hold: For TL</span>
								<span id="spnTechnical" runat="server" class="card-label fs-4 fw-bolder d-none">Hold: Technical</span>
								<span id="spnInv" runat="server" class="card-label fs-4 fw-bolder d-none">Seller's Inventory</span>
							 <span class="text-muted fw-bold fs-7">Admin | Lot Checklist</span> 
							</div>
                            <%-- end::title --%>
						</div>
						<div class="d-flex align-items-center position-relative my-1">
							<div id="ddlProjectsMasterlist" runat="server" class="">
								<div class="card-toolbar flex-row-fluid justify-content-end">
									<div class="d-flex align-items-center">
										<div class="d-flex flex-column w-200px me-3">
											<asp:DropDownList ID="ddlProjMstr" runat="server" onchange="UpdateGVMstr();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
											</asp:DropDownList>
										</div>
									</div>
								</div>
							</div>
							<div id="ddlProjectsInventory" runat="server" class="d-none">
								<div class="card-toolbar flex-row-fluid justify-content-end">
									<div class="d-flex align-items-center">
										<div class="d-flex flex-column w-200px me-3">
											<asp:DropDownList ID="ddlProjInv" runat="server" onchange="UpdateGVInv();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
											</asp:DropDownList>
										</div>
									</div>
								</div>
							</div>
                        <%-- end:: settings --%>
						<%-- begin::Edit Nav --%>
							<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
								<!--begin::Nav item-->
								<li onclick="toggleMstr();" class="nav-item">
									<a href="#aMasterlist" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary active">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Masterlist">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-folder-check" viewBox="0 0 16 16">
											  <path d="m.5 3 .04.87a2 2 0 0 0-.342 1.311l.637 7A2 2 0 0 0 2.826 14H9v-1H2.826a1 1 0 0 1-.995-.91l-.637-7A1 1 0 0 1 2.19 4h11.62a1 1 0 0 1 .996 1.09L14.54 8h1.005l.256-2.819A2 2 0 0 0 13.81 3H9.828a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 6.172 1H2.5a2 2 0 0 0-2 2m5.672-1a1 1 0 0 1 .707.293L7.586 3H2.19q-.362.002-.683.12L1.5 2.98a1 1 0 0 1 1-.98z"/>
											  <path d="M15.854 10.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.707 0l-1.5-1.5a.5.5 0 0 1 .707-.708l1.146 1.147 2.646-2.647a.5.5 0 0 1 .708 0"/>
											</svg>
										</div>
									<asp:Label ID="lblMasterlistCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label></a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li onclick="toggleTOL();" class="nav-item">
									<a href="#aTOL" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="TOL">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-geo" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M8 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6M4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999zm2.493 8.574a.5.5 0 0 1-.411.575c-.712.118-1.28.295-1.655.493a1.3 1.3 0 0 0-.37.265.3.3 0 0 0-.057.09V14l.002.008.016.033a.6.6 0 0 0 .145.15c.165.13.435.27.813.395.751.25 1.82.414 3.024.414s2.273-.163 3.024-.414c.378-.126.648-.265.813-.395a.6.6 0 0 0 .146-.15l.015-.033L12 14v-.004a.3.3 0 0 0-.057-.09 1.3 1.3 0 0 0-.37-.264c-.376-.198-.943-.375-1.655-.493a.5.5 0 1 1 .164-.986c.77.127 1.452.328 1.957.594C12.5 13 13 13.4 13 14c0 .426-.26.752-.544.977-.29.228-.68.413-1.116.558-.878.293-2.059.465-3.34.465s-2.462-.172-3.34-.465c-.436-.145-.826-.33-1.116-.558C3.26 14.752 3 14.426 3 14c0-.599.5-1 .961-1.243.505-.266 1.187-.467 1.957-.594a.5.5 0 0 1 .575.411"/>
											</svg>
										</div>
									<asp:Label ID="lblTOLCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label></a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li onclick="toggleReinstatement();" class="nav-item">
									<a href="#aReinstatement" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Reinstatement">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-wallet-fill" viewBox="0 0 16 16">
											  <path d="M1.5 2A1.5 1.5 0 0 0 0 3.5v2h6a.5.5 0 0 1 .5.5c0 .253.08.644.306.958.207.288.557.542 1.194.542s.987-.254 1.194-.542C9.42 6.644 9.5 6.253 9.5 6a.5.5 0 0 1 .5-.5h6v-2A1.5 1.5 0 0 0 14.5 2z"/>
											  <path d="M16 6.5h-5.551a2.7 2.7 0 0 1-.443 1.042C9.613 8.088 8.963 8.5 8 8.5s-1.613-.412-2.006-.958A2.7 2.7 0 0 1 5.551 6.5H0v6A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5z"/>
											</svg>
										</div>
									<asp:Label ID="lblReinstatementCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label></a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li onclick="toggleTL();" class="nav-item">
									<a href="#aTL" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="TL">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-wallet" viewBox="0 0 16 16">
												<path d="M0 3a2 2 0 0 1 2-2h13.5a.5.5 0 0 1 0 1H15v2a1 1 0 0 1 1 1v8.5a1.5 1.5 0 0 1-1.5 1.5h-12A2.5 2.5 0 0 1 0 12.5zm1 1.732V12.5A1.5 1.5 0 0 0 2.5 14h12a.5.5 0 0 0 .5-.5V5H2a2 2 0 0 1-1-.268M1 3a1 1 0 0 0 1 1h12V2H2a1 1 0 0 0-1 1"/>
											</svg>
										</div>
									<asp:Label ID="lblTLCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label></a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li onclick="toggleTechnical();" class="nav-item">
									<a href="#aTechnical" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Technical">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-gear" viewBox="0 0 16 16">
											  <path d="M8 4.754a3.246 3.246 0 1 0 0 6.492 3.246 3.246 0 0 0 0-6.492M5.754 8a2.246 2.246 0 1 1 4.492 0 2.246 2.246 0 0 1-4.492 0"/>
											  <path d="M9.796 1.343c-.527-1.79-3.065-1.79-3.592 0l-.094.319a.873.873 0 0 1-1.255.52l-.292-.16c-1.64-.892-3.433.902-2.54 2.541l.159.292a.873.873 0 0 1-.52 1.255l-.319.094c-1.79.527-1.79 3.065 0 3.592l.319.094a.873.873 0 0 1 .52 1.255l-.16.292c-.892 1.64.901 3.434 2.541 2.54l.292-.159a.873.873 0 0 1 1.255.52l.094.319c.527 1.79 3.065 1.79 3.592 0l.094-.319a.873.873 0 0 1 1.255-.52l.292.16c1.64.893 3.434-.902 2.54-2.541l-.159-.292a.873.873 0 0 1 .52-1.255l.319-.094c1.79-.527 1.79-3.065 0-3.592l-.319-.094a.873.873 0 0 1-.52-1.255l.16-.292c.893-1.64-.902-3.433-2.541-2.54l-.292.159a.873.873 0 0 1-1.255-.52zm-2.633.283c.246-.835 1.428-.835 1.674 0l.094.319a1.873 1.873 0 0 0 2.693 1.115l.291-.16c.764-.415 1.6.42 1.184 1.185l-.159.292a1.873 1.873 0 0 0 1.116 2.692l.318.094c.835.246.835 1.428 0 1.674l-.319.094a1.873 1.873 0 0 0-1.115 2.693l.16.291c.415.764-.42 1.6-1.185 1.184l-.291-.159a1.873 1.873 0 0 0-2.693 1.116l-.094.318c-.246.835-1.428.835-1.674 0l-.094-.319a1.873 1.873 0 0 0-2.692-1.115l-.292.16c-.764.415-1.6-.42-1.184-1.185l.159-.291A1.873 1.873 0 0 0 1.945 8.93l-.319-.094c-.835-.246-.835-1.428 0-1.674l.319-.094A1.873 1.873 0 0 0 3.06 4.377l-.16-.292c-.415-.764.42-1.6 1.185-1.184l.292.159a1.873 1.873 0 0 0 2.692-1.115z"/>
											</svg>
										</div>
									<asp:Label ID="lblTechnicalCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label></a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li onclick="toggleInv();" class="nav-item">
									<a href="#aSLInventory" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Seller's Inventory">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-bag-plus-fill" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M10.5 3.5a2.5 2.5 0 0 0-5 0V4h5zm1 0V4H15v10a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V4h3.5v-.5a3.5 3.5 0 1 1 7 0M8.5 8a.5.5 0 0 0-1 0v1.5H6a.5.5 0 0 0 0 1h1.5V12a.5.5 0 0 0 1 0v-1.5H10a.5.5 0 0 0 0-1H8.5z"/>
											</svg>
										</div>
									<asp:Label ID="lblInventoryCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label></a>
								</li>
								<!--end::Nav item-->
							</ul>
						<%-- end::Edit Nav --%>
						</div>
					</div>
					<div class="card-body py-3">
						<div class="tab-content">
							<div class="tab-pane fade show active" id="aMasterlist">
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin:: search --%>
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxSearchProject" type="text" class="form-control form-control-solid w-200px ps-12" placeholder="Search Record" />
								<%-- end:: search --%>
                                <%-- begin::lot options --%>
								<div class="ms-1">
									<button id="btnTOL" runat="server" style="display:none;" class="btn btn-sm btn-icon btn-success align-self-center m-1" onclick="ProjTOL(this);">
										<span class="indicator-label">
											<div data-bs-toggle="tooltip" data-bs-placement="top" title="For TOL">
												<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo" viewBox="0 0 16 16">
												  <path fill-rule="evenodd" d="M8 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6M4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999zm2.493 8.574a.5.5 0 0 1-.411.575c-.712.118-1.28.295-1.655.493a1.3 1.3 0 0 0-.37.265.3.3 0 0 0-.057.09V14l.002.008.016.033a.6.6 0 0 0 .145.15c.165.13.435.27.813.395.751.25 1.82.414 3.024.414s2.273-.163 3.024-.414c.378-.126.648-.265.813-.395a.6.6 0 0 0 .146-.15l.015-.033L12 14v-.004a.3.3 0 0 0-.057-.09 1.3 1.3 0 0 0-.37-.264c-.376-.198-.943-.375-1.655-.493a.5.5 0 1 1 .164-.986c.77.127 1.452.328 1.957.594C12.5 13 13 13.4 13 14c0 .426-.26.752-.544.977-.29.228-.68.413-1.116.558-.878.293-2.059.465-3.34.465s-2.462-.172-3.34-.465c-.436-.145-.826-.33-1.116-.558C3.26 14.752 3 14.426 3 14c0-.599.5-1 .961-1.243.505-.266 1.187-.467 1.957-.594a.5.5 0 0 1 .575.411"/>
												</svg>
											</div>
										</span>
										<span class="indicator-progress">
											<span class="spinner-border spinner-border-sm align-middle"></span>
										</span>
									</button>

									<button id="btnReinstatement" runat="server" style="display:none;" class="btn btn-sm btn-icon btn-success align-self-center m-1" onclick="ProjReinstatement(this);">
										<span class="indicator-label">
											<div data-bs-toggle="tooltip" data-bs-placement="top" title="For Reinstatement">
												<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-wallet-fill" viewBox="0 0 16 16">
												  <path d="M1.5 2A1.5 1.5 0 0 0 0 3.5v2h6a.5.5 0 0 1 .5.5c0 .253.08.644.306.958.207.288.557.542 1.194.542s.987-.254 1.194-.542C9.42 6.644 9.5 6.253 9.5 6a.5.5 0 0 1 .5-.5h6v-2A1.5 1.5 0 0 0 14.5 2z"/>
												  <path d="M16 6.5h-5.551a2.7 2.7 0 0 1-.443 1.042C9.613 8.088 8.963 8.5 8 8.5s-1.613-.412-2.006-.958A2.7 2.7 0 0 1 5.551 6.5H0v6A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5z"/>
												</svg>
											</div>
										</span>
										<span class="indicator-progress">
											<span class="spinner-border spinner-border-sm align-middle"></span>
										</span>
									</button>

									<button id="btnTL" runat="server" style="display:none;" class="btn btn-sm btn-icon btn-success align-self-center m-1" onclick="ProjTL(this);">
										<span class="indicator-label">
											<div data-bs-toggle="tooltip" data-bs-placement="top" title="For TL">
												<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-wallet" viewBox="0 0 16 16">
												  <path d="M0 3a2 2 0 0 1 2-2h13.5a.5.5 0 0 1 0 1H15v2a1 1 0 0 1 1 1v8.5a1.5 1.5 0 0 1-1.5 1.5h-12A2.5 2.5 0 0 1 0 12.5zm1 1.732V12.5A1.5 1.5 0 0 0 2.5 14h12a.5.5 0 0 0 .5-.5V5H2a2 2 0 0 1-1-.268M1 3a1 1 0 0 0 1 1h12V2H2a1 1 0 0 0-1 1"/>
												</svg>
											</div>
										</span>
										<span class="indicator-progress">
											<span class="spinner-border spinner-border-sm align-middle"></span>
										</span>
									</button>

									<button id="btnnTechnical" runat="server" style="display:none;" class="btn btn-sm btn-icon btn-success align-self-center m-1" onclick="ProjTechnical(this);">
										<span class="indicator-label">
											<div data-bs-toggle="tooltip" data-bs-placement="top" title="For Technical">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="For Technical">
											<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-gear" viewBox="0 0 16 16">
											  <path d="M8 4.754a3.246 3.246 0 1 0 0 6.492 3.246 3.246 0 0 0 0-6.492M5.754 8a2.246 2.246 0 1 1 4.492 0 2.246 2.246 0 0 1-4.492 0"/>
											  <path d="M9.796 1.343c-.527-1.79-3.065-1.79-3.592 0l-.094.319a.873.873 0 0 1-1.255.52l-.292-.16c-1.64-.892-3.433.902-2.54 2.541l.159.292a.873.873 0 0 1-.52 1.255l-.319.094c-1.79.527-1.79 3.065 0 3.592l.319.094a.873.873 0 0 1 .52 1.255l-.16.292c-.892 1.64.901 3.434 2.541 2.54l.292-.159a.873.873 0 0 1 1.255.52l.094.319c.527 1.79 3.065 1.79 3.592 0l.094-.319a.873.873 0 0 1 1.255-.52l.292.16c1.64.893 3.434-.902 2.54-2.541l-.159-.292a.873.873 0 0 1 .52-1.255l.319-.094c1.79-.527 1.79-3.065 0-3.592l-.319-.094a.873.873 0 0 1-.52-1.255l.16-.292c.893-1.64-.902-3.433-2.541-2.54l-.292.159a.873.873 0 0 1-1.255-.52zm-2.633.283c.246-.835 1.428-.835 1.674 0l.094.319a1.873 1.873 0 0 0 2.693 1.115l.291-.16c.764-.415 1.6.42 1.184 1.185l-.159.292a1.873 1.873 0 0 0 1.116 2.692l.318.094c.835.246.835 1.428 0 1.674l-.319.094a1.873 1.873 0 0 0-1.115 2.693l.16.291c.415.764-.42 1.6-1.185 1.184l-.291-.159a1.873 1.873 0 0 0-2.693 1.116l-.094.318c-.246.835-1.428.835-1.674 0l-.094-.319a1.873 1.873 0 0 0-2.692-1.115l-.292.16c-.764.415-1.6-.42-1.184-1.185l.159-.291A1.873 1.873 0 0 0 1.945 8.93l-.319-.094c-.835-.246-.835-1.428 0-1.674l.319-.094A1.873 1.873 0 0 0 3.06 4.377l-.16-.292c-.415-.764.42-1.6 1.185-1.184l.292.159a1.873 1.873 0 0 0 2.692-1.115z"/>
											</svg>
											</div>
										</span>
										<span class="indicator-progress">
											<span class="spinner-border spinner-border-sm align-middle"></span>
										</span>
									</button>

									<asp:LinkButton ID="lbtnAddtoInventory" runat="server" CssClass="btn btn-sm btn-icon btn-success align-self-center m-1" style="display:none;"
										OnClientClick="confirmAddtoInventory(event); return false;">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Add to Inventory">
											<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-bag-plus-fill" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M10.5 3.5a2.5 2.5 0 0 0-5 0V4h5zm1 0V4H15v10a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V4h3.5v-.5a3.5 3.5 0 1 1 7 0M8.5 8a.5.5 0 0 0-1 0v1.5H6a.5.5 0 0 0 0 1h1.5V12a.5.5 0 0 0 1 0v-1.5H10a.5.5 0 0 0 0-1H8.5z"/>
											</svg>
										</div>
									</asp:LinkButton>
								</div>
                                <%-- end::lot options --%>
								</div>
								<!--begin::Gridview-->
								<asp:UpdatePanel ID="upnlMstrList" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
								<ContentTemplate>
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<asp:GridView ID="gvAllProject" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
										<Columns>
											<asp:TemplateField HeaderText="Project">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbAllProject" class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
													</div>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:UpdatePanel ID="upnlCheckbox" runat="server" UpdateMode="Conditional" >
													<ContentTemplate>
														<div class="form-check form-check-sm form-check-custom form-check-solid">
															<input id="MstrCheckbox" class="form-check-input checkBoxClass" runat="server" type="checkbox" value="1" />
														</div>
													</ContentTemplate>
													</asp:UpdatePanel>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-40px min-w-40px" />
												<ItemStyle CssClass="mw-40px min-w-40px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Subdivision">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
																</div>
																<span onclick="ViewHistory(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("LotCode") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Project") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Category") %> | <%# Eval("LotType") %> </span>
																</span>
															</div>
														</div>
														<%--<div class="overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end">
															<div class="d-flex justify-content-end flex-shrink-0">
																<a href="#" class="btn btn-sm btn-icon btn-light btn-active-light-primary me-4" title="Action" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
																	<!--begin::Svg Icon | path: icons/duotune/arrows/arr072.svg-->
																	<span class="svg-icon svg-icon-1 m-0">
																		<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																			<path d="M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z" fill="currentColor"/>
																			<path opacity="0.3" d="M21 14H3C2.4 14 2 13.6 2 13V11C2 10.4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z" fill="currentColor"/>
																		</svg>
																	</span>
																	<!--end::Svg Icon-->
																</a>
															</div>
														</div>--%>
													</div>
													<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-250px" />
											<ItemStyle CssClass="mw-5px min-w-250px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Category">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlStatus1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblStatus1" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("HouseStatus") %>'></asp:Label>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
													<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-400px" />
												<ItemStyle CssClass="mw-5px min-w-400px" />
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
									</div>
								</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Gridview-->
							</div>
							<div class="tab-pane fade show" id="aTOL">
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin:: search --%>
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxSearchTOL" type="text" class="form-control form-control-solid w-200px ps-12" placeholder="Search Record" />
								<%-- end:: search --%>
                                <%-- begin::options --%>
								<div class="ms-1">
									<asp:LinkButton ID="lbtnUnhold" runat="server" CssClass="btn btn-sm btn-icon btn-success align-self-center m-1" style="display:none;"
										OnClientClick="confirmUnhold(event); return false;">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Unhold">
											<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2z"/>
											  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466"/>
											</svg>
										</div>
									</asp:LinkButton>
								</div>
                                <%-- end::options --%>

								</div>
								<!--begin::Gridview-->
								<asp:UpdatePanel ID="upnlTOLList" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
								<ContentTemplate>
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<asp:GridView ID="gvTOL" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
										<Columns>
											<asp:TemplateField HeaderText="Project">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbTOL" class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
													</div>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:UpdatePanel ID="upnlCheckbox" runat="server" UpdateMode="Conditional" >
													<ContentTemplate>
														<div class="form-check form-check-sm form-check-custom form-check-solid">
															<input id="TOLCheckbox" class="form-check-input checkBoxClass" runat="server" type="checkbox" value="1" />
														</div>
													</ContentTemplate>
													</asp:UpdatePanel>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-40px min-w-40px" />
												<ItemStyle CssClass="mw-40px min-w-40px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Subdivision">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
																</div>
																<span onclick="ViewHistory(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("LotCode") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Project") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Category") %> | <%# Eval("LotType") %> </span>
																</span>
															</div>
														</div>
													</div>
													<asp:Label ID="lblTOLLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-250px" />
											<ItemStyle CssClass="mw-5px min-w-250px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Category">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlStatus2" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("HouseStatus") %>'></asp:Label>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Details">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Title") %>'>
																	</asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Remarks") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("RemarksDate") %></span>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-400px" />
												<ItemStyle CssClass="mw-5px min-w-400px" />
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
									</div>
								</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Gridview-->
							</div>
							<div class="tab-pane fade show" id="aReinstatement">
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin:: search --%>
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxSearchReinstatement" type="text" class="form-control form-control-solid w-200px ps-12" placeholder="Search Record" />
								<%-- end:: search --%>
                                <%-- begin::options --%>
								<div class="ms-1">
									<asp:LinkButton ID="lbtnUnholdReinstatement" runat="server" CssClass="btn btn-sm btn-icon btn-success align-self-center m-1" style="display:none;"
										OnClientClick="confirmUnholdReinstatement(event); return false;">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Unhold">
											<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2z"/>
											  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466"/>
											</svg>
										</div>
									</asp:LinkButton>
								</div>
                                <%-- end::options --%>

								</div>
								<!--begin::Gridview-->
								<asp:UpdatePanel ID="upnlReinstatementList" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
								<ContentTemplate>
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<asp:GridView ID="gvReinstatement" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
										<Columns>
											<asp:TemplateField HeaderText="Project">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbReinstatement" class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
													</div>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:UpdatePanel ID="upnlCheckbox" runat="server" UpdateMode="Conditional" >
													<ContentTemplate>
														<div class="form-check form-check-sm form-check-custom form-check-solid">
															<input id="ReinstatementCheckbox" class="form-check-input checkBoxClass" runat="server" type="checkbox" value="1" />
														</div>
													</ContentTemplate>
													</asp:UpdatePanel>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-40px min-w-40px" />
												<ItemStyle CssClass="mw-40px min-w-40px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Subdivision">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
																</div>
																<span onclick="ViewHistory(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("LotCode") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Project") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Category") %> | <%# Eval("LotType") %> </span>
																</span>
															</div>
														</div>
													</div>
													<asp:Label ID="lblReinstatementLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-250px" />
											<ItemStyle CssClass="mw-5px min-w-250px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Category">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlStatus2" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("HouseStatus") %>'></asp:Label>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Details">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Title") %>'>
																	</asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Remarks") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("RemarksDate") %></span>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-400px" />
												<ItemStyle CssClass="mw-5px min-w-400px" />
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
									</div>
								</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Gridview-->
							</div>
							<div class="tab-pane fade show" id="aTL">
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin:: search --%>
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxSearchTL" type="text" class="form-control form-control-solid w-200px ps-12" placeholder="Search Record" />
								<%-- end:: search --%>
                                <%-- begin::options --%>
								<div class="ms-1">
									<asp:LinkButton ID="lbtnUnholdTL" runat="server" CssClass="btn btn-sm btn-icon btn-success align-self-center m-1" style="display:none;"
										OnClientClick="confirmUnholdTL(event); return false;">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Unhold">
											<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2z"/>
											  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466"/>
											</svg>
										</div>
									</asp:LinkButton>
								</div>
                                <%-- end::options --%>

								</div>
								<!--begin::Gridview-->
								<asp:UpdatePanel ID="upnlTLList" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
								<ContentTemplate>
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<asp:GridView ID="gvTL" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
										<Columns>
											<asp:TemplateField HeaderText="Project">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbTL" class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
													</div>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:UpdatePanel ID="upnlCheckbox" runat="server" UpdateMode="Conditional" >
													<ContentTemplate>
														<div class="form-check form-check-sm form-check-custom form-check-solid">
															<input id="TLCheckbox" class="form-check-input checkBoxClass" runat="server" type="checkbox" value="1" />
														</div>
													</ContentTemplate>
													</asp:UpdatePanel>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-40px min-w-40px" />
												<ItemStyle CssClass="mw-40px min-w-40px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Subdivision">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
																</div>
																<span onclick="ViewHistory(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("LotCode") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Project") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Category") %> | <%# Eval("LotType") %> </span>
																</span>
															</div>
														</div>
													</div>
													<asp:Label ID="lblTLLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-250px" />
											<ItemStyle CssClass="mw-5px min-w-250px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Category">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlStatus2" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("HouseStatus") %>'></asp:Label>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Details">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Title") %>'>
																	</asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Remarks") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("RemarksDate") %></span>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-400px" />
												<ItemStyle CssClass="mw-5px min-w-400px" />
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
									</div>
								</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Gridview-->
							</div>
							<div class="tab-pane fade show" id="aTechnical">
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin:: search --%>
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxSearchTechnical" type="text" class="form-control form-control-solid w-200px ps-12" placeholder="Search Record" />
								<%-- end:: search --%>
                                <%-- begin::options --%>
								<div class="ms-1">
									<asp:LinkButton ID="lbtnUnholdTechnical" runat="server" CssClass="btn btn-sm btn-icon btn-success align-self-center m-1" style="display:none;"
										OnClientClick="confirmUnholdTechnical(event); return false;">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Unhold">
											<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2z"/>
											  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466"/>
											</svg>
										</div>
									</asp:LinkButton>
								</div>
                                <%-- end::options --%>

								</div>
								<!--begin::Gridview-->
								<asp:UpdatePanel ID="upnlTechnicalList" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
								<ContentTemplate>
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<asp:GridView ID="gvTechnical" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
										<Columns>
											<asp:TemplateField HeaderText="Project">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbTechnical" class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
													</div>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:UpdatePanel ID="upnlCheckbox" runat="server" UpdateMode="Conditional" >
													<ContentTemplate>
														<div class="form-check form-check-sm form-check-custom form-check-solid">
															<input id="TechnicalCheckbox" class="form-check-input checkBoxClass" runat="server" type="checkbox" value="1" />
														</div>
													</ContentTemplate>
													</asp:UpdatePanel>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-40px min-w-40px" />
												<ItemStyle CssClass="mw-40px min-w-40px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Subdivision">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
																</div>
																<span onclick="ViewHistory(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("LotCode") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Project") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Category") %> | <%# Eval("LotType") %> </span>
																</span>
															</div>
														</div>
													</div>
													<asp:Label ID="lblTechnicalLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-250px" />
											<ItemStyle CssClass="mw-5px min-w-250px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Category">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlStatus2" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("HouseStatus") %>'></asp:Label>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Details">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Title") %>'>
																	</asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Remarks") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("RemarksDate") %></span>
																	<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-400px" />
												<ItemStyle CssClass="mw-5px min-w-400px" />
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
									</div>
								</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Gridview-->
							</div>
							<div class="tab-pane fade show" id="aSLInventory">
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin:: search --%>
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxSearchInventory" type="text" class="form-control form-control-solid w-200px ps-12 " placeholder="Search Record" />
								<%-- end:: search --%>
                                <%-- begin::options --%>
								<div class="ms-1">
									<asp:LinkButton ID="lbtnReturntoMasterlist" runat="server" CssClass="btn btn-sm btn-icon btn-success align-self-center m-1 d-none" style="display:none"
										OnClientClick="confirmReturntoMasterlist(event); return false;">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Return to Masterlist">
											<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-x-lg" viewBox="0 0 16 16">
												<path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8z"/>
											</svg>
										</div>
									</asp:LinkButton>
								</div>
                                <%-- end::options --%>
								</div>
							<!--begin::Gridview-->
							<asp:UpdatePanel ID="upnlInvList" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
							<ContentTemplate>
								<div style="overflow-x:auto; scrollbar-width: thin;">
								<asp:GridView ID="gvProjList" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
								<Columns>
									<asp:TemplateField HeaderText="Project">
										<HeaderTemplate>
											<div class="form-check form-check-sm form-check-custom form-check-solid">
												<input id="cbProjList" class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
											</div>
										</HeaderTemplate>
										<ItemTemplate>
											<asp:UpdatePanel ID="upnlCheckbox1" runat="server" UpdateMode="Conditional" >
											<ContentTemplate>
												<div class="form-check form-check-sm form-check-custom form-check-solid">
													<input id="InvCheckbox" class="form-check-input checkBoxClass" runat="server" type="checkbox" value="1" />
												</div>
											</ContentTemplate>
											</asp:UpdatePanel>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-40px min-w-40px" />
										<ItemStyle CssClass="mw-40px min-w-40px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Subdivision">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<div class="symbol symbol-30px overflow-hidden me-3"> 
															<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
														</div>
														<span onclick="ViewHistory(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("LotCode") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
															<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Project") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Category") %> | <%# Eval("LotType") %> </span>
														</span>
													</div>
												</div>
												<%--<div class="overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end">
													<div class="d-flex justify-content-end flex-shrink-0">
														<a href="#" class="btn btn-sm btn-icon btn-light btn-active-light-primary me-4" title="Action" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
															<!--begin::Svg Icon | path: icons/duotune/arrows/arr072.svg-->
															<span class="svg-icon svg-icon-1 m-0">
																<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																	<path d="M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z" fill="currentColor"/>
																	<path opacity="0.3" d="M21 14H3C2.4 14 2 13.6 2 13V11C2 10.4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z" fill="currentColor"/>
																</svg>
															</span>
															<!--end::Svg Icon-->
														</a>
													</div>
												</div>--%>
												<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-250px" />
										<ItemStyle CssClass="mw-5px min-w-250px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Category">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<asp:UpdatePanel ID="upnlStatus" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
														<ContentTemplate>
															<asp:Label ID="lblStatus" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("HouseStatus") %>'></asp:Label>
														</ContentTemplate>
														</asp:UpdatePanel>
													</div>
												</div>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-400px" />
										<ItemStyle CssClass="mw-5px min-w-400px" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							</ContentTemplate>
							</asp:UpdatePanel>
							<!--end::Gridview-->
							</div>
						</div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<%-- end::Lot Inventory Masterlist --%>

		<!--begin::modals-->
        <%-- begin::TOL modal --%>
			<asp:UpdatePanel ID="mdlTOLProj" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Add Note</h5>
							<div class="d-flex align-items-center flex-wrap gap-1">
								<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
									<li class="nav-item">
										<a class="nav-link active" data-bs-toggle="tab" href="#aTOLInputs">Inputs</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" data-bs-toggle="tab" href="#aTOLItems">Items</a>
									</li>
								</ul>
								<!--begin::Close-->
								<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
									<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
											<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</div>
								<!--end::Close-->
							</div>
						</div>
						<div class="modal-body">
							<div class="tab-content">
								<div class="tab-pane fade show active" id="aTOLInputs" role="tabpanel">
									<div class="input-group input-group-sm">
										<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
										<asp:TextBox ID="tbxTOLRemarks" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
									</div>
								</div>
								<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin;max-height:200px;min-height:200px;" id="aTOLItems" role="tabpanel">
									<asp:GridView ID="gvTOLProj" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="False" >
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<div class="d-flex align-items-center">
														<div class="symbol symbol-30px overflow-hidden me-3">
															<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
														</div>
														<div class="d-flex flex-column">
															<span class="text-dark fw-bolder fs-6"><%# Eval("Project") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("Category") %> <%# Eval("LotType") %> <%# Eval("HouseStatus") %></span>
														</div>
													</div>
													<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
												<ItemStyle CssClass="w-100" />
											</asp:TemplateField>
										</Columns>
									</asp:GridView>
								</div>
							</div>
						</div>
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtnTOL" runat="server" OnClientClick="confirmTOL(event); return false;" CssClass="btn btn-primary">For TOL</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
        <%-- end::TOL modal --%>

        <%-- begin::reinstatement modal --%>
			<asp:UpdatePanel ID="mdlReinstatementProj" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Add Note</h5>
							<div class="d-flex align-items-center flex-wrap gap-1">
								<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
									<li class="nav-item">
										<a class="nav-link active" data-bs-toggle="tab" href="#aReinstatementInputs">Inputs</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" data-bs-toggle="tab" href="#aReinstatementItems">Items</a>
									</li>
								</ul>
								<!--begin::Close-->
								<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
									<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
											<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</div>
								<!--end::Close-->
							</div>
						</div>
						<div class="modal-body">
							<div class="tab-content">
								<div class="tab-pane fade show active" id="aReinstatementInputs" role="tabpanel">
									<div class="input-group input-group-sm">
										<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
										<asp:TextBox ID="tbxReinstatementRemarks" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
									</div>
								</div>
								<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin;max-height:200px;min-height:200px;" id="aReinstatementItems" role="tabpanel">
									<asp:GridView ID="gvReinstatementProj" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="False" >
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<div class="d-flex align-items-center">
														<div class="symbol symbol-30px overflow-hidden me-3">
															<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
														</div>
														<div class="d-flex flex-column">
															<span class="text-dark fw-bolder fs-6"><%# Eval("Project") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("Category") %> <%# Eval("LotType") %> <%# Eval("HouseStatus") %></span>
														</div>
													</div>
													<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
												<ItemStyle CssClass="w-100" />
											</asp:TemplateField>
										</Columns>
									</asp:GridView>
								</div>
							</div>
						</div>
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtnReinstatement" runat="server" OnClientClick="confirmReinstatement(event); return false;" CssClass="btn btn-primary">For Reinstatement</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
        <%-- end::reinstatement modal --%>

        <%-- begin::TL modal --%>
			<asp:UpdatePanel ID="mdlTLProj" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Add Note</h5>
							<div class="d-flex align-items-center flex-wrap gap-1">
								<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
									<li class="nav-item">
										<a class="nav-link active" data-bs-toggle="tab" href="#aTLInputs">Inputs</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" data-bs-toggle="tab" href="#aTLItems">Items</a>
									</li>
								</ul>
								<!--begin::Close-->
								<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
									<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
											<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</div>
								<!--end::Close-->
							</div>
						</div>
						<div class="modal-body">
							<div class="tab-content">
								<div class="tab-pane fade show active" id="aTLInputs" role="tabpanel">
									<div class="input-group input-group-sm">
										<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
										<asp:TextBox ID="tbxTLRemarks" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
									</div>
								</div>
								<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin;max-height:200px;min-height:200px;" id="aTLItems" role="tabpanel">
									<asp:GridView ID="gvTLProj" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" ShowHeader="false">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<div class="d-flex align-items-center">
														<div class="symbol symbol-30px overflow-hidden me-3">
															<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
														</div>
														<div class="d-flex flex-column">
															<span class="text-dark fw-bolder fs-6"><%# Eval("Project") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("Category") %> <%# Eval("LotType") %> <%# Eval("HouseStatus") %></span>
														</div>
													</div>
													<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
												<ItemStyle CssClass="w-100" />
											</asp:TemplateField>
										</Columns>
									</asp:GridView>
								</div>
							</div>
						</div>
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtnTL" runat="server" OnClientClick="confirmTL(event); return false;" CssClass="btn btn-primary">For TL</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
        <%-- end::TL modal --%>

        <%-- begin::TL modal --%>
			<asp:UpdatePanel ID="mdlTechnicalProj" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Add Note</h5>
							<div class="d-flex align-items-center flex-wrap gap-1">
								<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
									<li class="nav-item">
										<a class="nav-link active" data-bs-toggle="tab" href="#aTechnicalInputs">Inputs</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" data-bs-toggle="tab" href="#aTechnicalItems">Items</a>
									</li>
								</ul>
								<!--begin::Close-->
								<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
									<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
											<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</div>
								<!--end::Close-->
							</div>
						</div>
						<div class="modal-body">
							<div class="tab-content">
								<div class="tab-pane fade show active" id="aTechnicalInputs" role="tabpanel">
									<div class="input-group input-group-sm">
										<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
										<asp:TextBox ID="tbxTechnicalRemarks" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
									</div>
								</div>
								<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin;max-height:200px;min-height:200px;" id="aTechnicalItems" role="tabpanel">
									<asp:GridView ID="gvTechnicalProj" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" ShowHeader="false">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<div class="d-flex align-items-center">
														<div class="symbol symbol-30px overflow-hidden me-3">
															<img src="Assets/media/svg/project/<%# Eval("ProjImage") %>.svg" alt="project-image" >
														</div>
														<div class="d-flex flex-column">
															<span class="text-dark fw-bolder fs-6"><%# Eval("Project") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("Category") %> <%# Eval("LotType") %> <%# Eval("HouseStatus") %></span>
														</div>
													</div>
													<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>
												</ItemTemplate>
												<ItemStyle CssClass="w-100" />
											</asp:TemplateField>
										</Columns>
									</asp:GridView>
								</div>
							</div>
						</div>
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtnTechnical" runat="server" OnClientClick="confirmTechnical(event); return false;" CssClass="btn btn-primary">For Technical</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
        <%-- end::TL modal --%>

        <%-- begin::TL modal --%>
			<div id="mdlLotHistory" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Lot History</h5>
							<div class="d-flex align-items-center flex-wrap gap-1">
								<!--begin::Close-->
								<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
									<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
											<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</div>
								<!--end::Close-->
							</div>
						</div>
						<div class="modal-body">
							<div style="overflow-x:auto; scrollbar-width: thin;">
								<div class="table-responsive overflow-hidden min-h-300px" >
								<!--begin::Table-->
									<table id="gvLotHistory" class="table table-row-dashed tscroll table-row-gray-300 table-hover align-middle">
										<!--begin::Table head-->
										<thead>
											<tr>
												<th class="text-dark fw-bold fs-5 min-w-200px">Description</th>
												<th class="text-dark fw-bold fs-5 min-w-350px">Remarks</th>
												<th class="text-dark fw-bold fs-5 min-w-150px">Author</th>
												<th class="text-dark fw-bold fs-5 min-w-150px">Date & Time</th>
											</tr>
										</thead>
										<!--end::Table head-->
										<!--begin::Table body-->
										<tbody>

										</tbody>
										<!--end::Table body-->
									</table>
								<!--end::Table-->
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
        <%-- end::TL modal --%>
		<!--begin::modals-->

		<%-- begin:: hiddenfield variables --%>
		<asp:HiddenField ID="hfLotCode" runat="server" />
		<%-- end:: hiddenfield variables --%>

    </div>
    <!--end::Post-->

	<script type="text/javascript">
		window.onload = function () {
			toggleMstr();
		};
        //link button
        function toggleMstr() {
			$('#<%= spnMstr.ClientID %>').removeClass('d-none');
			$('#<%= spnTOL.ClientID %>').addClass('d-none');
			$('#<%= spnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= spnTL.ClientID %>').addClass('d-none');
			$('#<%= spnTechnical.ClientID %>').addClass('d-none');
			$('#<%= spnInv.ClientID %>').addClass('d-none'); 
			$('#<%= ddlProjectsMasterlist.ClientID %>').removeClass('d-none');
			$('#<%= ddlProjectsInventory.ClientID %>').addClass('d-none');
			$('#<%= lbtnTOL.ClientID %>').removeClass('d-none');
			$('#<%= btnReinstatement.ClientID %>').removeClass('d-none');
			$('#<%= btnTL.ClientID %>').removeClass('d-none');
			$('#<%= btnnTechnical.ClientID %>').removeClass('d-none');
			$('#<%= lbtnTechnical.ClientID %>').removeClass('d-none');
			$('#<%= lbtnUnhold.ClientID %>').removeClass('d-none');
			$('#<%= lbtnReturntoMasterlist.ClientID %>').addClass('d-none');
			//masterlist
			$('#cbAllProject').click(function () {
				var TOL = document.getElementById("ContentPlaceHolder1_lbtnTOL");
				var Reinstatement = document.getElementById("ContentPlaceHolder1_btnReinstatement");
                var TL = document.getElementById("ContentPlaceHolder1_btnTL");
				var Technical = document.getElementById("ContentPlaceHolder1_btnnTechnical");
				var Remarks = document.getElementById("ContentPlaceHolder1_btnTOL");
                var AddToInventory = document.getElementById("ContentPlaceHolder1_lbtnAddtoInventory");

				if ($(this).is(":checked")) {
					//get tr which is visible ..add checked to that checkboxes
					$('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
					AddToInventory.style.display = "";
					TOL.style.display = "";
					Reinstatement.style.display = "";
					TL.style.display = "";
					Technical.style.display = "";
					Remarks.style.display = "";
				} else {
					//remove checked
					$(".checkBoxClass").prop('checked', false);
                    AddToInventory.style.display = "none";
                    TOL.style.display = "none";
                    Reinstatement.style.display = "none";
                    TL.style.display = "none";
                    Technical.style.display = "none";
                    Remarks.style.display = "none";
				}
			})
            $(".checkBoxClass").change(function () {
                var TOL = document.getElementById("ContentPlaceHolder1_lbtnTOL");
                var Reinstatement = document.getElementById("ContentPlaceHolder1_btnReinstatement");
                var TL = document.getElementById("ContentPlaceHolder1_btnTL");
                var Technical = document.getElementById("ContentPlaceHolder1_btnnTechnical");
                var Remarks = document.getElementById("ContentPlaceHolder1_btnTOL");
                var AddToInventory = document.getElementById("ContentPlaceHolder1_lbtnAddtoInventory");
				if (!$(this).prop("checked")) {
                    $("#ContentPlaceHolder1_MstrCheckbox.checkBoxAllClass").prop("checked", false);
				}
                if ($('.checkBoxClass:checked').length > 0) {
                    AddToInventory.style.display = "";
                    TOL.style.display = "";
                    Reinstatement.style.display = "";
					TL.style.display = "";
					Technical.style.display = "";
					Remarks.style.display = "";
				} else {
                    AddToInventory.style.display = "none";
                    TOL.style.display = "none";
                    Reinstatement.style.display = "none";
                    TL.style.display = "none";
                    Technical.style.display = "none";
                    Remarks.style.display = "none";
				}
			});
		}
        function toggleTOL() {
            $('#<%= spnMstr.ClientID %>').addClass('d-none');
            $('#<%= spnTOL.ClientID %>').removeClass('d-none');
            $('#<%= spnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= spnTL.ClientID %>').addClass('d-none');
			$('#<%= spnTechnical.ClientID %>').addClass('d-none');
            $('#<%= spnInv.ClientID %>').addClass('d-none'); 
            $('#<%= ddlProjectsMasterlist.ClientID %>').addClass('d-none');
            $('#<%= ddlProjectsInventory.ClientID %>').addClass('d-none');
            $('#<%= lbtnTOL.ClientID %>').addClass('d-none');
			$('#<%= btnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= btnTL.ClientID %>').addClass('d-none');
			$('#<%= lbtnUnhold.ClientID %>').removeClass('d-none');
            $('#<%= lbtnReturntoMasterlist.ClientID %>').addClass('d-none');
			//masterlist
            $('#cbTOL').click(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnhold");

				if ($(this).is(":checked")) {
					//get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    Unhold.style.display = "";
				} else {
					//remove checked
					$(".checkBoxClass").prop('checked', false);
                    Unhold.style.display = "none";
				}
			})
            $(".checkBoxClass").change(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnhold");
				if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
				}
                if ($('.checkBoxClass:checked').length > 0) {
                    Unhold.style.display = "";
				} else {
                    Unhold.style.display = "none";
				}
			});
		}
        function toggleReinstatement() {
            $('#<%= spnMstr.ClientID %>').addClass('d-none');
            $('#<%= spnTOL.ClientID %>').addClass('d-none');
            $('#<%= spnReinstatement.ClientID %>').removeClass('d-none');
			$('#<%= spnTL.ClientID %>').addClass('d-none');
			$('#<%= spnTechnical.ClientID %>').addClass('d-none');
            $('#<%= spnInv.ClientID %>').addClass('d-none'); 
            $('#<%= ddlProjectsMasterlist.ClientID %>').addClass('d-none');
            $('#<%= ddlProjectsInventory.ClientID %>').addClass('d-none');
            $('#<%= lbtnTOL.ClientID %>').addClass('d-none');
			$('#<%= btnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= btnTL.ClientID %>').addClass('d-none');
			$('#<%= lbtnUnholdReinstatement.ClientID %>').removeClass('d-none');
            $('#<%= lbtnReturntoMasterlist.ClientID %>').addClass('d-none');
			//masterlist
            $('#cbReinstatement').click(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnholdReinstatement");

				if ($(this).is(":checked")) {
					//get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    Unhold.style.display = "";
				} else {
					//remove checked
					$(".checkBoxClass").prop('checked', false);
                    Unhold.style.display = "none";
				}
			})
            $(".checkBoxClass").change(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnholdReinstatement");
				if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
				}
                if ($('.checkBoxClass:checked').length > 0) {
                    Unhold.style.display = "";
				} else {
                    Unhold.style.display = "none";
				}
			});
		}
        function toggleTL() {
            $('#<%= spnMstr.ClientID %>').addClass('d-none');
            $('#<%= spnTOL.ClientID %>').addClass('d-none');
            $('#<%= spnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= spnTL.ClientID %>').removeClass('d-none');
			$('#<%= spnTechnical.ClientID %>').addClass('d-none');
            $('#<%= spnInv.ClientID %>').addClass('d-none'); 
            $('#<%= ddlProjectsMasterlist.ClientID %>').addClass('d-none');
            $('#<%= ddlProjectsInventory.ClientID %>').addClass('d-none');
            $('#<%= lbtnTOL.ClientID %>').addClass('d-none');
			$('#<%= btnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= btnTL.ClientID %>').addClass('d-none');
			$('#<%= lbtnUnholdReinstatement.ClientID %>').removeClass('d-none');
            $('#<%= lbtnReturntoMasterlist.ClientID %>').addClass('d-none');
			//masterlist
            $('#cbTL').click(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnholdTL");

				if ($(this).is(":checked")) {
					//get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    Unhold.style.display = "";
				} else {
					//remove checked
					$(".checkBoxClass").prop('checked', false);
                    Unhold.style.display = "none";
				}
			})
            $(".checkBoxClass").change(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnholdTL");
				if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
				}
                if ($('.checkBoxClass:checked').length > 0) {
                    Unhold.style.display = "";
				} else {
                    Unhold.style.display = "none";
				}
			});
		}
        function toggleTechnical() {
            $('#<%= spnMstr.ClientID %>').addClass('d-none');
            $('#<%= spnTOL.ClientID %>').addClass('d-none');
            $('#<%= spnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= spnTL.ClientID %>').addClass('d-none');
			$('#<%= spnTechnical.ClientID %>').removeClass('d-none');
            $('#<%= spnInv.ClientID %>').addClass('d-none'); 
            $('#<%= ddlProjectsMasterlist.ClientID %>').addClass('d-none');
            $('#<%= ddlProjectsInventory.ClientID %>').addClass('d-none');
            $('#<%= lbtnTOL.ClientID %>').addClass('d-none');
			$('#<%= btnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= btnTL.ClientID %>').addClass('d-none');
			$('#<%= lbtnUnholdReinstatement.ClientID %>').removeClass('d-none');
            $('#<%= lbtnReturntoMasterlist.ClientID %>').addClass('d-none');
			//masterlist
            $('#cbTechnical').click(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnholdTechnical");

				if ($(this).is(":checked")) {
					//get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    Unhold.style.display = "";
				} else {
					//remove checked
					$(".checkBoxClass").prop('checked', false);
                    Unhold.style.display = "none";
				}
			})
            $(".checkBoxClass").change(function () {
                var Unhold = document.getElementById("ContentPlaceHolder1_lbtnUnholdTechnical");
				if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
				}
                if ($('.checkBoxClass:checked').length > 0) {
                    Unhold.style.display = "";
				} else {
                    Unhold.style.display = "none";
				}
			});
		}
        function toggleInv() {
            $('#<%= spnMstr.ClientID %>').addClass('d-none');
            $('#<%= spnTOL.ClientID %>').addClass('d-none');
            $('#<%= spnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= spnTL.ClientID %>').addClass('d-none');
			$('#<%= spnTechnical.ClientID %>').addClass('d-none');
            $('#<%= spnInv.ClientID %>').removeClass('d-none'); 
            $('#<%= ddlProjectsMasterlist.ClientID %>').addClass('d-none');
            $('#<%= ddlProjectsInventory.ClientID %>').removeClass('d-none');
            $('#<%= lbtnTOL.ClientID %>').removeClass('d-none');
			$('#<%= btnReinstatement.ClientID %>').addClass('d-none');
			$('#<%= btnTL.ClientID %>').addClass('d-none');
			$('#<%= lbtnUnhold.ClientID %>').removeClass('d-none');
            $('#<%= lbtnReturntoMasterlist.ClientID %>').removeClass('d-none');
            //seller's inventory
            $('#cbProjList').click(function () {
                var ReturntoMasterlist = document.getElementById("ContentPlaceHolder1_lbtnReturntoMasterlist");
                if ($(this).is(":checked")) {
                    //get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    ReturntoMasterlist.style.display = "";
                    $('#<%= lbtnReturntoMasterlist.ClientID %>').removeClass('d-none');
                } else {
                    //remove checked
                    $(".checkBoxClass").prop('checked', false);
                    ReturntoMasterlist.style.display = "none";
                }
            })
            $(".checkBoxClass").change(function () {
                var ReturntoMasterlist = document.getElementById("ContentPlaceHolder1_lbtnReturntoMasterlist");
                if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
                }
                if ($('.checkBoxClass:checked').length > 0) {
                    ReturntoMasterlist.style.display = "";
                    $('#<%= lbtnReturntoMasterlist.ClientID %>').removeClass('d-none');
                } else {
                    ReturntoMasterlist.style.display = "none";
                }
            });
		}

        //remarks
        function ProjTOL(Proj) {
            var btn = document.getElementById("<%= btnProjTOL.ClientID %>");
			btn.click();
            Proj.disabled = true;
            Proj.setAttribute('data-kt-indicator', 'on');
            setTimeout(function () {
                Proj.removeAttribute('data-kt-indicator');
                Proj.disabled = false;
            }, 3000);
		}
        function ProjReinstatement(Proj) {
            var btn = document.getElementById("<%= btnProjReinstatement.ClientID %>");
			btn.click();
            Proj.disabled = true;
            Proj.setAttribute('data-kt-indicator', 'on');
            setTimeout(function () {
                Proj.removeAttribute('data-kt-indicator');
                Proj.disabled = false;
            }, 3000);
        }
        function ProjTL(Proj) {
            var btn = document.getElementById("<%= btnProjTL.ClientID %>");
            btn.click();
            Proj.disabled = true;
            Proj.setAttribute('data-kt-indicator', 'on');
            setTimeout(function () {
                Proj.removeAttribute('data-kt-indicator');
                Proj.disabled = false;
            }, 3000);
        }
        function ProjTechnical(Proj) {
            var btn = document.getElementById("<%= btnProjTechnical.ClientID %>");
            btn.click();
            Proj.disabled = true;
            Proj.setAttribute('data-kt-indicator', 'on');
            setTimeout(function () {
                Proj.removeAttribute('data-kt-indicator');
                Proj.disabled = false;
            }, 3000);
        }

        //gridview onchange
        function UpdateGVMstr() {
            var MstrProj = $('#<%= ddlProjMstr.ClientID %>').val()
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS040000',
                    'Type': 'View Masterlist (Project)',
                    'Project': MstrProj
                },
				success: function (response) {
                    __doPostBack('<%= upnlMstrList.ClientID %>', '');
                },
                error: function (error) {
					// Handle error
                    console.log("Error:", error);
                }
            });
        }
		function UpdateGVInv() {
            var InvProj = $('#<%= ddlProjInv.ClientID %>').val()
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS040000',
                    'Type': 'View Sellers Inventory (Project)',
                    'Project': InvProj
                },
				success: function (response) {
                    __doPostBack('<%= upnlInvList.ClientID %>', '');
                },
                error: function (error) {
					// Handle error
                    console.log("Error:", error);
                }
            });
        }
        //function UpdateGVMstr(response) {
        //    //datatable
        //    var gvAllProject = $("#gvAllProject").DataTable({
        //        bFilter: true,
        //        bSort: false,
        //        bPaginate: false,
        //        bDestroy: true,
        //        bInfo: false,
        //        scrollCollapse: true,
        //        bLengthChange: true,
        //        lengthMenu: [[5, 10, 20, 30, 40, 50, -1], [5, 10, 20, 30, 40, 50, "All"]],
        //        scrollY: '250px',
        //        scrollX: true,
        //        fixedColumns: { left: 1 },
        //        select: true,
        //        data: response,
        //        columns: [
        //            { data: 'ProjImage' },
        //            { data: 'Project' },
        //            { data: 'Category' },
        //            { data: 'LotType' },
        //            { data: 'LotCode' },
        //            { data: 'HouseStatus' }]
        //    });
        //    //datatable
        //    //search
        //    //$('#tbxSearchSeller').on('keyup', function () {
        //    //    gvDisplayGroupSales.search(this.value).draw();
        //    //});
        //}

        //approve seller 
        function confirmAddtoInventory(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be added to the inventory',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully added to inventory!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnAddtoInventory.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmTOL(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be added to TOL',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully added to TOL!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnTOL.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmReinstatement(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be added to reinstatement',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully added to Reinstatement!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnReinstatement.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmTL(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be added to TL',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully added to Reinstatement!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnTL.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmTechnical(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be added to the technical',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully added to Technical!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnTechnical.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmUnhold(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be taken off hold as TOL',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully returned to masterlist!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnUnhold.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmUnholdReinstatement(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be taken off hold as reinstatement',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully returned to masterlist!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnUnholdReinstatement.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmUnholdTL(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be taken off hold as TL',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully returned to masterlist!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnUnholdTL.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmUnholdTechnical(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be taken off hold as technical',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully returned to masterlist!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleMstr();
                        __doPostBack('<%= lbtnUnholdTechnical.UniqueID %>', '');
                    });
                } else {
                }
            });
        } 
        function confirmReturntoMasterlist(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'The following project(s) will be reverted to the masterlist',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Project successfully reverted!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        toggleInv();
                        __doPostBack('<%= lbtnReturntoMasterlist.UniqueID %>', '');
                    });
                } else {
                }
            });
        }

        //view lot history - modal 
        function ViewHistory(LotCode) {
			LotCode = LotCode.getAttribute("data-value");
			console.log(LotCode)
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS040000',
                    'Type': 'View History (LotCode)',
                    'LotCode': LotCode
                },
                success: function (response) {
                    console.log(response);
					DisplayLotHistory(response);
                },
            });
        }
        function DisplayLotHistory(response) {
            //datatable
            var gvLotHistory = $("#gvLotHistory").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
                bLengthChange: true,
                lengthMenu: [[5, 10, 20, 30, 40, 50, -1], [5, 10, 20, 30, 40, 50, "All"]],
                scrollY: '300px',
                scrollX: true,
                select: true,
                data: response,
                columns: [
                    { data: 'Desc', class: "min-w-200px" },
                    { data: 'Remarks', class: "min-w-350px" },
                    { data: 'Employee', class: "min-w-150px" },
                    { data: 'DateTime', class: "min-w-150px" }]
            });
            //datatable
            // Show the modal
            $('#mdlLotHistory').modal('show');
        }

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $gvAllProject = $('#ContentPlaceHolder1_gvAllProject tbody tr');
            $('#tbxSearchProject').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvAllProject.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvTOL = $('#ContentPlaceHolder1_gvTOL tbody tr');
            $('#tbxSearchTOL').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvTOL.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvReinstatement = $('#ContentPlaceHolder1_gvReinstatement tbody tr');
            $('#tbxSearchReinstatement').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvTOL.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvTL = $('#ContentPlaceHolder1_gvTL tbody tr');
            $('#tbxSearchTL').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvTOL.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvTechnical = $('#ContentPlaceHolder1_gvTechnical tbody tr');
            $('#tbxSearchTechnical').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvTOL.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvProjList = $('#ContentPlaceHolder1_gvProjList tbody tr');
            $('#tbxSearchInventory').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvProjList.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
        }
        //table search

        //tbody scroll
        var $table = $('table.tscroll'), $bodyCells = $table.find('tbody tr:first').children(), colWidth;
        $(window).resize(function () {
            colWidth = $bodyCells.map(function () {
                return $(this).width();
            }).get();
            $table.find('thead tr').children().each(function (i, v) {
                $(v).width(colWidth[i]);
            });
        });
        //tbody scroll

		//checkbox
		//checkbox


        //page load script ------------------------------------------------------------------------------------------------------------------------
        function pageLoad(sender, args) { InitializeSettings(); }
		function InitializeSettings() {

			//combobox
			$('[data-kt-repeater="select2"]').select2();
			//combobox
		}
    </script>

</asp:Content>
