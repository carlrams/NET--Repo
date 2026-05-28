<%@ Page Title="Reservation Monitoring" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS030000.aspx.vb" Inherits="NET.SLS030000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Reservation Monitoring</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Recent Reservations</li>
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
								<a href="SLS030000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Reservation Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/reservation-monitoring.svg" alt="reservation-monitoring" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS040000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Lot Inventory Masterlist">
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
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::Navbar-->
		<asp:UpdatePanel ID="upnlNavBar" runat="server" UpdateMode="Conditional" class="card mb-6 mb-xl-3">
		<ContentTemplate>
			<div class="col-lg-12">
				<div class="card card-flush h-lg-100">
					<div class="card-header">
						<div class="d-flex align-items-center">
							<%-- begin::header img --%>
							<div class="symbol me-5">
								<img id="img1" runat="server" class="mw-125px mw-lg-125px" src="assets/media/svg/apps/reservation-monitoring.svg" alt="project-image" />
							</div>
							<%-- end::header img --%>
                            <%-- begin::title --%>
							<div class="d-flex flex-column">
								<span class="text-gray-800 fw-bolder fs-2 me-3">Reservation Monitoring</span>
								<span class="text-muted fw-bold fs-7">Admin | Reservations</span> 
							</div>
                            <%-- end::title --%>
						</div>
						<div class="d-flex align-items-center position-relative my-1">
						<%-- begin::Edit Nav --%>
							<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aNewReservations" data-bs-toggle="tab" runat="server" class="ml-lg-5 nav-link text-active-primary active">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="New Reservations">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-house-fill" viewBox="0 0 16 16">
											  <path d="M8.707 1.5a1 1 0 0 0-1.414 0L.646 8.146a.5.5 0 0 0 .708.708L8 2.207l6.646 6.647a.5.5 0 0 0 .708-.708L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293z"/>
											  <path d="m8 3.293 6 6V13.5a1.5 1.5 0 0 1-1.5 1.5h-9A1.5 1.5 0 0 1 2 13.5V9.293z"/>
											</svg>
											<asp:Label ID="lblNewReservationsCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label>
										</div>
									</a>
								</li>	
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aApproved" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Approved Reservations">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-house-check-fill" viewBox="0 0 16 16">
												<path d="M8.707 1.5a1 1 0 0 0-1.414 0L.646 8.146a.5.5 0 0 0 .708.708L8 2.207l6.646 6.647a.5.5 0 0 0 .708-.708L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293z"/>
												<path d="m8 3.293 4.712 4.712A4.5 4.5 0 0 0 8.758 15H3.5A1.5 1.5 0 0 1 2 13.5V9.293z"/>
												<path d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7m1.679-4.493-1.335 2.226a.75.75 0 0 1-1.174.144l-.774-.773a.5.5 0 0 1 .708-.707l.547.547 1.17-1.951a.5.5 0 1 1 .858.514"/>
											</svg>
											<asp:Label ID="lblApprovedCount" runat="server" class="badge badge-secondary ms-1">0</asp:Label>
										</div>
									</a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aRejected" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Denied Reservations">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-house-x-fill" viewBox="0 0 16 16">
												<path d="M8.707 1.5a1 1 0 0 0-1.414 0L.646 8.146a.5.5 0 0 0 .708.708L8 2.207l6.646 6.647a.5.5 0 0 0 .708-.708L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293z"/>
												<path d="m8 3.293 4.712 4.712A4.5 4.5 0 0 0 8.758 15H3.5A1.5 1.5 0 0 1 2 13.5V9.293z"/>
												<path d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7m-.646-4.854.646.647.646-.646a.5.5 0 0 1 .708.707l-.647.646.647.646a.5.5 0 0 1-.708.708l-.646-.647-.646.647a.5.5 0 0 1-.708-.707l.647-.647-.647-.646a.5.5 0 0 1 .708-.707Z"/>
											</svg>
											<asp:Label ID="lblRejectedCount" runat="server" class="badge badge-secondary ms-1">0</asp:Label>
										</div>
									</a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aExpired" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Expired Reservations">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-house-exclamation-fill" viewBox="0 0 16 16">
											  <path d="M8.707 1.5a1 1 0 0 0-1.414 0L.646 8.146a.5.5 0 0 0 .708.708L8 2.207l6.646 6.647a.5.5 0 0 0 .708-.708L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293z"/>
											  <path d="m8 3.293 4.712 4.712A4.5 4.5 0 0 0 8.758 15H3.5A1.5 1.5 0 0 1 2 13.5V9.293z"/>
											  <path d="M16 12.5a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0m-3.5-2a.5.5 0 0 0-.5.5v1.5a.5.5 0 1 0 1 0V11a.5.5 0 0 0-.5-.5m0 4a.5.5 0 1 0 0-1 .5.5 0 0 0 0 1"/>
											</svg>
											<asp:Label ID="lblExpiredCount" runat="server" class="badge badge-secondary ms-1">0</asp:Label>
										</div>
									</a>
								</li>
								<!--end::Nav item-->
							</ul>
						<%-- end::Edit Nav --%>
						</div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Navbar-->

		<%-- begin::Reservation Monitoring --%>
		<asp:UpdatePanel ID="mdlSellerDtl" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
		<ContentTemplate>
			<div class="tab-content">
				<div class="tab-pane fade show active" id="aNewReservations">
					<div class="row gy-3 g-sm-3">
						<%-- begin::reservations per group --%>
						<div class="col-lg-6">
							<!--begin::Graph-->
							<div class="card card-flush h-lg-100">
								<!--begin::Card header-->
								<div class="card-header mt-6">
									<!--begin::Card title-->
									<div class="card-title flex-column">
										<h3 class="mb-1">Reservations per Group</h3>
										<div class="fs-6 fw-bold text-gray-400">Number of reservations per group</div>
									</div>
									<!--end::Card title-->
									<!--begin::Card toolbar-->
									<%--<div class="card-toolbar">
										<!--begin::Select-->
										<button data-bs-target="#kt_group_sales_modal" data-bs-toggle="modal" type="button" class="btn btn-sm btn-light">View All</button>
										<!--end::Select-->
									</div>--%>
									<!--end::Card toolbar-->
								</div>
								<!--end::Card header-->

								<!--begin::Card body-->
								<div class="card-body pt-5 pb-0 px-5">
									<!--begin::Chart-->
									<div id="kt_groupsales_barchart" class="card-rounded-bottom" style="height: 260px"></div>
									<!--end::Chart-->
								</div>
								<!--end::Card body-->
							</div>
							<!--end::Graph-->
						</div>
						<%-- end::reservations per group --%>

						<%-- begin::account status --%>
						<div class="col-lg-6">
							<!--begin::Summary-->
							<div class="card card-flush h-lg-100">
								<!--begin::Card header-->
								<div class="card-header mt-6">
									<!--begin::Card title-->
									<div class="card-title flex-column">
										<h3 class="mb-1">Reservation Status</h3>
										<div class="fs-6 fw-bold text-gray-400">Current status of reservations</div>
									</div>
									<!--end::Card title-->
									<!--begin::Card toolbar-->
									<div class="card-toolbar">
									</div>
									<!--end::Card toolbar-->
								</div>
								<!--end::Card header-->

								<!--begin::Card body-->
								<div class="card-body p-5">
									<!--begin::Wrapper-->
									<div class="d-flex flex-wrap">	
										<!--begin::Chart-->
										<div class="d-flex flex-center h-260px w-260px mb-5">
											<div id="kt_account_status_piechart"></div>
										</div>
										<!--end::Chart-->
										<!--begin::kt_account_status_piechart Labels-->
										<div class="d-flex flex-column justify-content-center flex-row-fluid pe-3 mb-1">
											<!--begin::Label-->
											<div class="d-flex fs-6 fw-bold align-items-center mb-3">
												<div class="bullet bg-info me-3"></div>
													<a class="text-gray-400 pointer" onclick="ViewAccountStatus('Pending')">Pending</a>
												<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPiePending" runat="server" Text="0"></asp:Label></div>
											</div>
											<!--end::Label-->
											<!--begin::Label-->
											<div class="d-flex fs-6 fw-bold align-items-center mb-3">
												<div class="bullet bg-primary me-3"></div>
													<a class="text-gray-400 pointer" onclick="ViewAccountStatus('Reserved')">Reserved</a>
												<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieReserved" runat="server" Text="0"></asp:Label></div>
											</div>
											<!--end::Label-->
											<!--begin::Label-->
											<div class="d-flex fs-6 fw-bold align-items-center mb-3">
												<div class="bullet bg-warning me-3"></div>
													<a class="text-gray-400 pointer" onclick="ViewAccountStatus('Approved')">Approved</a>
												<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieApproved" runat="server" Text="0"></asp:Label></div>
											</div>
											<!--end::Label-->
											<!--begin::Label-->
											<div class="d-flex fs-6 fw-bold align-items-center mb-3">
												<div class="bullet bg-danger me-3"></div>
													<a class="text-gray-400 pointer" onclick="ViewAccountStatus('Rejected')">Rejected</a>
												<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieRejected" runat="server" Text="0"></asp:Label></div>
											</div>
											<!--end::kt_account_status_piechart Label-->
										</div>
										<!--end::Labels-->
									</div>
									<!--end::Wrapper-->
								</div>
								<!--end::Card body-->
							</div>
							<!--end::Summary-->
						</div>
						<%-- end::account status --%>

						<%-- begin::gridview --%>
						<div class="col-lg-12">
							<div class="card card-flush h-lg-100">
								<div class="card-header border-0 pt-5">
									<h3 class="card-title align-items-start flex-column">
										<span class="card-label fs-4 fw-bolder mb-1">Recent Reservations</span>
										<!-- <span class="text-muted mt-1 fw-bold fs-7">Over 500 members</span> -->
									</h3>
									<div class="d-flex align-items-center position-relative my-1">
									<!--begin::Search-->
									<span class="svg-icon svg-icon-1 position-absolute ms-4">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<input id="tbxSearchRecent" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px mr-10 ps-14" placeholder="Search Record" />
									</div>
								</div>
								<div class="card-body py-3">
									<!--begin::Gridview-->
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<asp:GridView ID="gvNewReservations" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" >
										<Columns>
											<asp:TemplateField HeaderText="List">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img alt="" src="<%# Eval("SlrImg") %>" />
																</div>
																<span onclick="ViewRsvDetail(this)" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-200px w-100 pointer" >
																	<asp:Label ID="lblSeller" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("Seller") %>'></asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7">Seller</span>
																</span>
																<asp:UpdatePanel ID="upnlSeller" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-200px">
																<ContentTemplate>
																	<span class="d-flex flex-column" >
																		<span class="text-dark fw-bolder fs-6 nowrap-auto" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"> <%# Eval("Buyer") %> </span>
																		<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Project") %> | <%# Eval("Unit") %> | <%# Eval("HouseStatus") %> </span>
																	</span>
																</ContentTemplate>
																</asp:UpdatePanel>
																<asp:UpdatePanel ID="upnlTCP" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-150px">
																<ContentTemplate>
																	<asp:Label ID="lblTCP" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("TCP") %>'></asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7">TCP</span>
																</ContentTemplate>
																</asp:UpdatePanel>
																<asp:UpdatePanel ID="upnlReservationDate" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-200px">
																<ContentTemplate>
																	<asp:Label ID="lblReservationDate" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("ReservationDate") %>'></asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7">Reservation Date</span>
																</ContentTemplate>
																</asp:UpdatePanel>
																<asp:UpdatePanel ID="upnlExpiryDate" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-150px">
																<ContentTemplate>
																	<asp:Label ID="lblExpiryDate" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("ExpiryDate") %>'></asp:Label>
																	<span class="text-muted fw-bold text-muted d-block fs-7">Expiry Date</span>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
													<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
												</ItemTemplate>
												<HeaderStyle CssClass="w-100" />
												<ItemStyle CssClass="w-100" />
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
									</div>
									<!--end::Gridview-->
								</div>
							</div>
						</div>
						<%-- end::gridview --%>
					</div>
				</div>
				<div class="tab-pane fade" id="aApproved">
					<%-- begin::gridview --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fs-4 fw-bolder mb-1">List of Approved Reservations</span>
									<!-- <span class="text-muted mt-1 fw-bold fs-7">Over 500 members</span> -->
								</h3>
								<div class="d-flex align-items-center position-relative my-1">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-1 position-absolute ms-4">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxSearchApproved" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
								</div>
							</div>
							<div class="card-body py-3">
								<!--begin::Gridview-->
								<div style="overflow-x:auto; scrollbar-width: thin;">
									<asp:GridView ID="gvApproved" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
									<Columns>
										<asp:TemplateField HeaderText="List">
											<ItemTemplate>
												<div class="overlay overflow-hidden">
													<div class="overlay-wrapper">
														<div class="d-flex align-items-center w-100">
															<div class="symbol symbol-30px overflow-hidden me-3"> 
																<img alt="" src="<%# Eval("SlrImg") %>" />
															</div>
															<span onclick="ViewRsvDetail(this)" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-200px w-100 pointer" >
																<asp:Label ID="lblSeller" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("Seller") %>'></asp:Label>
																<span class="text-muted fw-bold text-muted d-block fs-7">Seller</span>
															</span>
															<asp:UpdatePanel ID="upnlSeller" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-200px">
															<ContentTemplate>
																<span class="d-flex flex-column" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"> <%# Eval("Buyer") %> </span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Project") %> | <%# Eval("Unit") %> | <%# Eval("HouseStatus") %> </span>
																</span>
															</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
												</div>
											</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-500px" />
												<ItemStyle CssClass="mw-5px min-w-500px" />
										</asp:TemplateField>
											<asp:TemplateField HeaderText="TCP">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlTCP1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblTCP1" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TCP") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Approver">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlApprover" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblApprover" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Approver") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Date Approved">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlApprovedDate" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblApprovedDate" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("ApprovedDate") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::Gridview-->
							</div>
						</div>
					</div>
					<%-- end::gridview --%>
				</div>
				<div class="tab-pane fade" id="aRejected">
					<%-- begin::gridview --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fs-4 fw-bolder mb-1">List of Rejected Reservations</span>
									<!-- <span class="text-muted mt-1 fw-bold fs-7">Over 500 members</span> -->
								</h3>
								<div class="d-flex align-items-center position-relative my-1">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-1 position-absolute ms-4">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxSearchRejected" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
								</div>
							</div>
							<div class="card-body py-3">
								<!--begin::Gridview-->
								<div style="overflow-x:auto; scrollbar-width: thin;">
									<asp:GridView ID="gvRejected" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
									<Columns>
										<asp:TemplateField HeaderText="List">
											<ItemTemplate>
												<div class="overlay overflow-hidden">
													<div class="overlay-wrapper">
														<div class="d-flex align-items-center w-100">
															<div class="symbol symbol-30px overflow-hidden me-3"> 
																<img alt="" src="<%# Eval("SlrImg") %>" />
															</div>
															<span onclick="ViewRsvDetail(this)" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-200px w-100 pointer" >
																<asp:Label ID="lblSeller" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("Seller") %>'></asp:Label>
																<span class="text-muted fw-bold text-muted d-block fs-7">Seller</span>
															</span>
															<asp:UpdatePanel ID="upnlSeller" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-200px">
															<ContentTemplate>
																<span class="d-flex flex-column" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"> <%# Eval("Buyer") %> </span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Project") %> | <%# Eval("Unit") %> | <%# Eval("HouseStatus") %> </span>
																</span>
															</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
												</div>
												<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
											</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-500px" />
												<ItemStyle CssClass="mw-5px min-w-500px" />
										</asp:TemplateField>
											<asp:TemplateField HeaderText="TCP">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlTCP2" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblTCP2" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TCP") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Rejected By">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlRejedtedBy" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblRejedtedBy" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("RejedtedBy") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Date Rejected">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlRejectedDate" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblRejectedDate" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("RejectedDate") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</div>
													</div>
												</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-200px" />
												<ItemStyle CssClass="mw-5px min-w-200px" />
											</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::Gridview-->
							</div>
						</div>
					</div>
					<%-- end::gridview --%>
				</div>
				<div class="tab-pane fade" id="aExpired">
					<%-- begin::gridview --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fs-4 fw-bolder mb-1">List of Expired Reservations</span>
									<!-- <span class="text-muted mt-1 fw-bold fs-7">Over 500 members</span> -->
								</h3>
								<div class="d-flex align-items-center position-relative my-1">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-1 position-absolute ms-4">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxSearchExpired" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
								</div>
							</div>
							<div class="card-body py-3">
								<!--begin::Gridview-->
								<div style="overflow-x:auto; scrollbar-width: thin;">
									<asp:GridView ID="gvExpired" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
									<Columns>
										<asp:TemplateField HeaderText="List">
											<ItemTemplate>
												<div class="overlay overflow-hidden">
													<div class="overlay-wrapper">
														<div class="d-flex align-items-center w-100">
															<div class="symbol symbol-30px overflow-hidden me-3"> 
																<img alt="" src="<%# Eval("SlrImg") %>" />
															</div>
															<span onclick="ViewRsvDetail(this)" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-200px w-100 pointer" >
																<asp:Label ID="lblSeller" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("Seller") %>'></asp:Label>
																<span class="text-muted fw-bold text-muted d-block fs-7">Seller</span>
															</span>
															<asp:UpdatePanel ID="upnlSeller" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-200px">
															<ContentTemplate>
																<span class="d-flex flex-column" >
																	<span class="text-dark fw-bolder fs-6 nowrap-auto" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"> <%# Eval("Buyer") %> </span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Project") %> | <%# Eval("Unit") %> | <%# Eval("HouseStatus") %> </span>
																</span>
															</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
												</div>
												<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
											</ItemTemplate>
												<HeaderStyle CssClass="mw-5px min-w-500px" />
												<ItemStyle CssClass="mw-5px min-w-500px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="TCP">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlTCP3" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblTCP3" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TCP") %>'></asp:Label>
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
											<asp:TemplateField HeaderText="Date Expired">
												<ItemTemplate>
													<div class="overlay overflow-hidden">
														<div class="overlay-wrapper">
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlDateExpired" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblDateExpired" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("ExpiryDate") %>'></asp:Label>
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
								<!--end::Gridview-->
							</div>
						</div>
					</div>
					<%-- end::gridview --%>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<%-- end::Reservation Monitoring --%>

        <%-- begin::Modals --%>
			<%-- begin::seller detail modal --%>
			<div id="kt_rsv_dtl_modal" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Reservation Detail</h5>
								<div class="d-flex align-items-center position-relative my-1">
								<%-- begin::Edit Nav --%>
									<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
										<!--begin::Nav item-->
										<li class="nav-item mt-2">
											<a href="#aOverview" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6 active">Overview</a>
										</li>
										<!--end::Nav item-->
										<!--begin::Nav item-->
										<li class="nav-item mt-2">
											<a href="#aPackagePrice" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6">Package Price</a>
										</li>
										<!--end::Nav item-->
										<!--begin::Nav item-->
										<li class="nav-item mt-2">
											<a href="#aOtherCharges" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6">Other Charges</a>
										</li>
										<!--end::Nav item-->
									</ul>
								<%-- end::Edit Nav --%>
								<!--begin::Close-->
								<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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

						<div class="modal-body scroll h-300px">
							<div class="card-body py-3">
								<div class="tab-content">
									<div class="tab-pane fade show active" id="aOverview">
										<div class="row mb-6">
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">ID</span>
												<asp:TextBox ID="tbxID" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Status</span>
												<asp:TextBox ID="tbxFormStatus" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Requested By</span>
												<asp:TextBox ID="tbxRequestedBy" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxType" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxGroup" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:HiddenField ID="hfLotCode" runat="server" />
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Form Type</span>
												<asp:TextBox ID="tbxFormType" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Reservation Date</span>
												<input id="tbxReservationDate" runat="server" type="text" readonly="" class="form-control" placeholder="Pick a date" />
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">Buyer</span>
												<input id="tbxAcctName" runat="server" type="text" class="form-control" readonly="" placeholder="Account Name" />
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Project</span>
												<asp:TextBox ID="tbxProjInit" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxPhase" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxBlock" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxLot" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2 flex-nowrap">
												<span class="input-group-text min-w-150px ">House Model</span>
												<asp:TextBox ID="tbxHouseModel" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Lot Type</span>
												<asp:TextBox ID="tbxLotType" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">House Status</span>
												<asp:TextBox ID="tbxHouseStatus" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Lot Area</span>
												<asp:TextBox ID="tbxLotArea" runat="server" class="form-control" ReadOnly="true">-</asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Floor Area</span>
												<asp:TextBox ID="tbxFloorArea" runat="server" class="form-control" ReadOnly="true">-</asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2 flex-nowrap">
												<span class="input-group-text min-w-150px ">Financing</span>
												<asp:TextBox ID="tbxFinancing" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>

										</div>
									</div>
									<div class="tab-pane fade show" id="aPackagePrice">
										<div class="row mb-6">
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Total Contract Price</span>
												<asp:TextBox ID="tbxTCP" runat="server" class="form-control" readonly="true">-</asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Less Fixed Disc.</span>
												<asp:TextBox ID="tbxfixedDisc" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">Less 1% Loyalty Disc.</span>
												<asp:TextBox ID="tbxLoyaltyDiscPercent" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxLoyaltyDisc" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Net of Promo Disc.</span>
												<asp:TextBox ID="tbxNetPromoDisc" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">Spot 10% DP Disc.</span>
												<asp:TextBox ID="tbxSpotDPDiscPercent" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxSpotDPDisc" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Net TCP</span>
												<asp:TextBox ID="tbxNetTCP" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">12% VAT (if any)</span>
												<asp:TextBox ID="tbxVATPercent" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxVAT" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Net Contract Price</span>
												<asp:TextBox ID="tbxNetContractPrice" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
								
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">A. Downpayment(1)</span>
												<asp:TextBox ID="tbxDownPaymentAPercent" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<asp:TextBox ID="tbxDownPaymentA" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">Payments Made</span>
												<asp:TextBox ID="tbxPaymentsMade" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">PR No.</span>
												<asp:TextBox ID="tbxPRNo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<span class="input-group-text min-w-150px">PR Date</span>
												<asp:TextBox ID="tbxPRDate" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">DP Balance</span>
												<asp:TextBox ID="tbxDPBalance" runat="server" class="form-control"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px ">Payable Within</span>
												<asp:TextBox ID="tbxPayableWithinA" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Monthly Equity</span>
												<asp:TextBox ID="tbxMonthlyEquityA" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
								
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Loanable Amount</span>
												<asp:TextBox ID="tbxLoanableAmt" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Loan Option</span>
												<asp:TextBox ID="tbxLoanableAmtOpt" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Interest Rate</span>
												<asp:TextBox ID="tbxInterestRate" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Term</span>
												<asp:TextBox ID="tbxTerm" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Est. Monthly Amort</span>
												<asp:TextBox ID="tbxEstMonthlyAmort" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>

											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Final Net TCP</span>
												<asp:TextBox ID="tbxFinalNetTCP" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>

										</div>
									</div>
									<div class="tab-pane fade show" id="aOtherCharges">
										<div class="row mb-6">
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">A. Bank Charges</span>
												<asp:TextBox ID="tbxBankCharges" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>

											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Move-in Charges</span>
												<asp:TextBox ID="tbxMoveInCharges" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Water Conn. Fee</span>
												<asp:TextBox ID="tbxWaterConnFee" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Electric Conn. Fee</span>
												<asp:TextBox ID="tbxElecConnFee" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Fire Insurance</span>
												<asp:TextBox ID="tbxFireInsurance" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">MRI</span>
												<asp:TextBox ID="tbxMortInsurance" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="card-title fs-5 fw-bolder">Village Maintenance Dues</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Promesa</span>
												<asp:TextBox ID="tbxPromesa" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
												<span class="input-group-text min-w-150px">CBH/IL/TV</span>
												<asp:TextBox ID="tbxCbhIlTv" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Total Other Charges</span>
												<asp:TextBox ID="tbxTotalOtherCharges" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
											</div>

										</div>
									</div>
								</div>
                                <%-- begin::Table --%>
									<div class="col-lg-12">
										<div class="card card-flush h-lg-100">
											<div class="card-header border-0 pt-5">
												<h3 class="card-title align-items-start flex-column">
													<span class="card-label fs-4 fw-bolder mb-1">Payment Schedule</span>
													<!-- <span class="text-muted mt-1 fw-bold fs-7">Over 500 members</span> -->
												</h3>
											</div>
											<div class="card-body py-3">
												<!--begin::Table-->
												<table id="gvPaymentSchedule" class="table table-row-dashed table-row-gray-300 table-hover align-middle gs-0 gy-4">
													<!--begin::Table head-->
													<thead>
														<tr>
															<th class="text-dark fw-bold fs-6 min-w-150px">Description</th>
															<th class="text-dark fw-bold fs-6 min-w-100px">Due Date</th>
															<th class="text-dark fw-bold fs-6 min-w-150px">DP Amount</th>
															<th class="text-dark fw-bold fs-6 min-w-100px">Bank Charges</th>	
															<th class="text-dark fw-bold fs-6 min-w-100px">Move-in Charges</th>
															<th class="text-dark fw-bold fs-6 min-w-100px">Total Amount Due</th>
														</tr>
													</thead>
													<!--end::Table head-->
													<!--begin::Table body-->
													<tbody id="tblPaymentSchedule" runat="server">

													</tbody>
													<!--end::Table body-->
												</table>
												<!--end::Table-->
											</div>
										</div>
									</div>
                                <%-- end::Table --%>
							</div>

						</div>
						<div class="card-body py-3">
							<%-- begin:: confirm --%>
							<div class="d-flex align-items-center py-3 py-md-1 gap-4">
								<asp:Linkbutton id="btnApprove" runat="server" OnClientClick="confirmReservation(event); return false;" class="btn btn-primary d-none">Approve</asp:Linkbutton>
								<asp:Linkbutton id="btnReject" runat="server" OnClientClick="confirmReject(event); return false;" class="btn btn-light-danger">Reject</asp:Linkbutton>
							</div>
							<%-- end:: confirm --%>
						</div>
					</div>
				</div>
			</div>
			<%-- end::seller detail modal --%>
        <%-- end::Modals --%>

    </div>
    <%-- end::Post --%>
	
	<script type="text/javascript">
        //for pie chart account status
        var ltrlPiePending = <asp:Literal ID="ltrlPiePending" runat="server" />;
        var ltrlPieReserved = <asp:Literal ID="ltrlPieReserved" runat="server" />;
        var ltrlPieApproved = <asp:Literal ID="ltrlPieApproved" runat="server" />;
        var ltrlPieRejected = <asp:Literal ID="ltrlPieRejected" runat="server" />;
        //for bar-chart group sales
        var ltrlBarGroupSalesData = '<asp:Literal ID="ltrlBarGroupSalesData" runat="server" />'
		var ltrlBarGroupSalesName = '<asp:Literal ID="ltrlBarGroupSalesName" runat="server" />'

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $gvNewReservations = $('#ContentPlaceHolder1_gvNewReservations tbody tr');
            $('#tbxSearchRecent').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvNewReservations.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvApproved = $('#ContentPlaceHolder1_gvApproved tbody tr');
            $('#tbxSearchApproved').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvApproved.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvRejected = $('#ContentPlaceHolder1_gvRejected tbody tr');
            $('#tbxSearchRejected').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvRejected.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvExpired = $('#ContentPlaceHolder1_gvExpired tbody tr');
            $('#tbxSearchExpired').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvExpired.show().filter(function () {
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
        function scrollPos() {
            var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");
            hfScrollPosition.value = document.querySelector('#ContentPlaceHolder1_gvNewReservations > tbody').scrollTop;
        }
        //tbody scroll

        //approve reservation
        function confirmReservation(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'Reservation will be approved',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Approve',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Approved successfully!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        __doPostBack('<%= btnApprove.UniqueID %>', '');
                        $('#kt_sellerdtl_modal').modal('hide');
                    });
                } else {
                    // If the user cancels, do nothing
                }
            });
		} 

        //reject reservation
        function confirmReject(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'This reservation will be rejected',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Reject',
                cancelButtonText: 'Cancel'

            }).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Reservation rejected!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        __doPostBack('<%= btnReject.UniqueID %>', '');
                        $('#kt_sellerdtl_modal').modal('hide');
                    });
                } else {
                    // If the user cancels, do nothing
                    Swal.fire(
                        'Cancelled',
                        'Carefully check the details',
                        'error'
                    );
                }
            });
        } 

        //view reservation details --------------------------------------------------------------------------------------------------
        function ViewRsvDetail(SLFCode) {
            SLFCode = SLFCode.getAttribute("data-value");
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS030000',
                    'Type': 'View Reservation Detail (SLFCode)',
                    'SLFCode': SLFCode
                },
				success: function (response) {
					document.getElementById('<%= hfLotCode.ClientID %>').value = hfLotCode;
                    var hfLotCode = document.getElementById("ContentPlaceHolder1_hfLotCode");
					var tbxID = document.getElementById("ContentPlaceHolder1_tbxID");
					var tbxFormStatus = document.getElementById("ContentPlaceHolder1_tbxFormStatus");
                    var tbxRequestedBy = document.getElementById("ContentPlaceHolder1_tbxRequestedBy");
                    var tbxFormType = document.getElementById("ContentPlaceHolder1_tbxFormType");
					var tbxType = document.getElementById("ContentPlaceHolder1_tbxType");
					var tbxGroup = document.getElementById("ContentPlaceHolder1_tbxGroup");
					var tbxReservationDate = document.getElementById("ContentPlaceHolder1_tbxReservationDate");
					var tbxAcctName = document.getElementById("ContentPlaceHolder1_tbxAcctName");
					var tbxProjInit = document.getElementById("ContentPlaceHolder1_tbxProjInit");
					var tbxPhase = document.getElementById("ContentPlaceHolder1_tbxPhase");
					var tbxBlock = document.getElementById("ContentPlaceHolder1_tbxBlock");
					var tbxLot = document.getElementById("ContentPlaceHolder1_tbxLot");
					var tbxHouseModel = document.getElementById("ContentPlaceHolder1_tbxHouseModel");
					var tbxLotType = document.getElementById("ContentPlaceHolder1_tbxLotType");
					var tbxHouseStatus = document.getElementById("ContentPlaceHolder1_tbxHouseStatus");
					var tbxLotArea = document.getElementById("ContentPlaceHolder1_tbxLotArea");
					var tbxFloorArea = document.getElementById("ContentPlaceHolder1_tbxFloorArea");
					var tbxFinancing = document.getElementById("ContentPlaceHolder1_tbxFinancing");
					var tbxTCP = document.getElementById("ContentPlaceHolder1_tbxTCP");
                    var tbxfixedDisc = document.getElementById("ContentPlaceHolder1_tbxfixedDisc");
					var tbxLoyaltyDiscPercent = document.getElementById("ContentPlaceHolder1_tbxLoyaltyDiscPercent");
					var tbxLoyaltyDisc = document.getElementById("ContentPlaceHolder1_tbxLoyaltyDisc");
					var tbxNetPromoDisc = document.getElementById("ContentPlaceHolder1_tbxNetPromoDisc");
					var tbxSpotDPDiscPercent = document.getElementById("ContentPlaceHolder1_tbxSpotDPDiscPercent");
					var tbxSpotDPDisc = document.getElementById("ContentPlaceHolder1_tbxSpotDPDisc");
					var tbxNetTCP = document.getElementById("ContentPlaceHolder1_tbxNetTCP");
					var tbxVATPercent = document.getElementById("ContentPlaceHolder1_tbxVATPercent");
					var tbxVAT = document.getElementById("ContentPlaceHolder1_tbxVAT");
					var tbxNetContractPrice = document.getElementById("ContentPlaceHolder1_tbxNetContractPrice");
					var tbxDownPaymentAPercent = document.getElementById("ContentPlaceHolder1_tbxDownPaymentAPercent");
					var tbxDownPaymentA = document.getElementById("ContentPlaceHolder1_tbxDownPaymentA");
					var tbxPaymentsMade = document.getElementById("ContentPlaceHolder1_tbxPaymentsMade");
					var tbxPRNo = document.getElementById("ContentPlaceHolder1_tbxPRNo");
					var tbxPRDate = document.getElementById("ContentPlaceHolder1_tbxPRDate");
					var tbxDPBalance = document.getElementById("ContentPlaceHolder1_tbxDPBalance");
					var tbxPayableWithinA = document.getElementById("ContentPlaceHolder1_tbxPayableWithinA");
					var tbxMonthlyEquityA = document.getElementById("ContentPlaceHolder1_tbxMonthlyEquityA");
                    var tbxLoanableAmtOpt = document.getElementById("ContentPlaceHolder1_tbxLoanableAmtOpt");
					var tbxLoanableAmt = document.getElementById("ContentPlaceHolder1_tbxLoanableAmt");
					var tbxInterestRate = document.getElementById("ContentPlaceHolder1_tbxInterestRate");
					var tbxTerm = document.getElementById("ContentPlaceHolder1_tbxTerm");
					var tbxEstMonthlyAmort = document.getElementById("ContentPlaceHolder1_tbxEstMonthlyAmort");
					var tbxFinalNetTCP = document.getElementById("ContentPlaceHolder1_tbxFinalNetTCP");
					var tbxBankCharges = document.getElementById("ContentPlaceHolder1_tbxBankCharges");
					var tbxMoveInCharges = document.getElementById("ContentPlaceHolder1_tbxMoveInCharges");
					var tbxWaterConnFee = document.getElementById("ContentPlaceHolder1_tbxWaterConnFee");
					var tbxElecConnFee = document.getElementById("ContentPlaceHolder1_tbxElecConnFee");
					var tbxFireInsurance = document.getElementById("ContentPlaceHolder1_tbxFireInsurance");
					var tbxMortInsurance = document.getElementById("ContentPlaceHolder1_tbxMortInsurance");
					var tbxPromesa = document.getElementById("ContentPlaceHolder1_tbxPromesa");
					var tbxCbhIlTv = document.getElementById("ContentPlaceHolder1_tbxCbhIlTv");
					var tbxTotalOtherCharges = document.getElementById("ContentPlaceHolder1_tbxTotalOtherCharges");

					hfLotCode.value = response.textBoxData[0].LotCode
					tbxID.value = response.textBoxData[0].ID
					tbxFormStatus.value = response.textBoxData[0].FormStatus
                    tbxRequestedBy.value = response.textBoxData[0].RequestedBy
                    tbxFormType.value = response.textBoxData[0].FormType
					tbxType.value = response.textBoxData[0].Type
					tbxGroup.value = response.textBoxData[0].Group
					tbxReservationDate.value = response.textBoxData[0].ReservationDate
					tbxAcctName.value = response.textBoxData[0].AcctName
					tbxProjInit.value = response.textBoxData[0].ProjInit
					tbxPhase.value = response.textBoxData[0].Phase
					tbxBlock.value = response.textBoxData[0].Block
					tbxLot.value = response.textBoxData[0].Lot
					tbxHouseModel.value = response.textBoxData[0].HouseModel
					tbxLotType.value = response.textBoxData[0].LotType
					tbxHouseStatus.value = response.textBoxData[0].HouseStatus
					tbxLotArea.value = response.textBoxData[0].LotArea
					tbxFloorArea.value = response.textBoxData[0].FloorArea
					tbxFinancing.value = response.textBoxData[0].Financing
					tbxTCP.value = response.textBoxData[0].TCP
					tbxfixedDisc.value = response.textBoxData[0].FixedDisc
					tbxLoyaltyDiscPercent.value = response.textBoxData[0].LoyaltyDiscPercent
					tbxLoyaltyDisc.value = response.textBoxData[0].LoyaltyDisc
					tbxNetPromoDisc.value = response.textBoxData[0].NetPromoDisc
					tbxSpotDPDiscPercent.value = response.textBoxData[0].SpotDPDiscPercent
					tbxSpotDPDisc.value = response.textBoxData[0].SpotDPDisc
					tbxNetTCP.value = response.textBoxData[0].NetTCP
					tbxVATPercent.value = response.textBoxData[0].VATPercent
					tbxVAT.value = response.textBoxData[0].VAT
					tbxNetContractPrice.value = response.textBoxData[0].NetContractPrice
					tbxDownPaymentAPercent.value = response.textBoxData[0].DownPaymentAPercent
					tbxDownPaymentA.value = response.textBoxData[0].DownPaymentA
					tbxPaymentsMade.value = response.textBoxData[0].PaymentsMade
					tbxPRNo.value = response.textBoxData[0].PRNo
					tbxPRDate.value = response.textBoxData[0].PRDate
					tbxDPBalance.value = response.textBoxData[0].DPBalance
					tbxPayableWithinA.value = response.textBoxData[0].PayableWithinA
					tbxMonthlyEquityA.value = response.textBoxData[0].MonthlyEquityA
                    tbxLoanableAmtOpt.value = response.textBoxData[0].LoanableAmtOpt
					tbxLoanableAmt.value = response.textBoxData[0].LoanableAmt
					tbxInterestRate.value = response.textBoxData[0].InterestRate
					tbxTerm.value = response.textBoxData[0].Term
					tbxEstMonthlyAmort.value = response.textBoxData[0].EstMonthlyAmort
					tbxFinalNetTCP.value = response.textBoxData[0].FinalNetTCP
					tbxBankCharges.value = response.textBoxData[0].BankCharges
					tbxMoveInCharges.value = response.textBoxData[0].MoveInCharges
					tbxWaterConnFee.value = response.textBoxData[0].WaterConnFee
					tbxElecConnFee.value = response.textBoxData[0].ElecConnFee
					tbxFireInsurance.value = response.textBoxData[0].FireInsurance
					tbxMortInsurance.value = response.textBoxData[0].MortInsurance
					tbxPromesa.value = response.textBoxData[0].Promesa
					tbxCbhIlTv.value = response.textBoxData[0].CbhIlTv
					tbxTotalOtherCharges.value = response.textBoxData[0].TotalOtherCharges

					//$('#gvPaymentSchedule').DataTable().clear().destroy();
                    $('#gvPaymentSchedule').DataTable({
                    	scrollY: "300px",
                    	scrollX: true,
                    	scrollCollapse: true,
                    	bLengthChange: true,
                    	lengthMenu: [[5, 10, 20, 30, 40, 50, -1], [5, 10, 20, 30, 40, 50, "All"]],
                    	pageLength: 5,
                        bSort: false,
						bDestroy: true
                    });

                    // Populate the DataTable with new rows
					if (response.dataTableData.length > 0) {
						var tblPaymentSchedule = '';
                        // Loop through each row in the dataTableData array
						response.dataTableData.forEach(function (row) {
						tblPaymentSchedule += '<tr>';
						tblPaymentSchedule += '<td><span class="fw - light d - block fs - 6">' + row.Description + '</span></td>';
						tblPaymentSchedule += '<td><span class="fw - light d - block fs - 6">' + row.DueDate + '</span></td>';
						tblPaymentSchedule += '<td><span class="fw - light d - block fs - 6">' + row.DPAmount + '</span></td>';
						tblPaymentSchedule += '<td><span class="fw - light d - block fs - 6">' + row.BankCharges + '</span></td>';
						tblPaymentSchedule += '<td><span class="fw - light d - block fs - 6">' + row.MoveInCharges + '</span></td>';
						tblPaymentSchedule += '<td><span class="fw - light d - block fs - 6">' + row.TotalAmountDue + '</span></td>';
						tblPaymentSchedule += '</tr>';
						});
					$('#gvPaymentSchedule').html(tblPaymentSchedule);
					//$('#gvPaymentSchedule').DataTable({
					//	scrollY: "300px",
					//	scrollX: true,
					//	scrollCollapse: true,
					//	bLengthChange: true,
					//	lengthMenu: [[5, 10, 20, 30, 40, 50, -1], [5, 10, 20, 30, 40, 50, "All"]],
					//	pageLength: 5,
					//	bSort: false
					//});
                    }
                    if (tbxFormStatus.value == 'Reserved') {
                        document.getElementById("ContentPlaceHolder1_btnApprove").classList.remove('d-none');
                        document.getElementById("ContentPlaceHolder1_btnReject").classList.remove('d-none');
                    } else {
                        document.getElementById("ContentPlaceHolder1_btnApprove").classList.add('d-none');
                        document.getElementById("ContentPlaceHolder1_btnReject").classList.add('d-none');
                    

                    }
                    $('#kt_rsv_dtl_modal').modal('show');
                }
            });
        }

        //form load
        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
            //reservations per group bar-chart ----------------------------------------------------------------------------------------------
            jQuery(function ($) {
                var element = document.getElementById("kt_groupsales_barchart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                const ArrayValueData = ltrlBarGroupSalesData.split(",")
                const ArrayValueLabel = ltrlBarGroupSalesName.split(",")

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Reserved',
                        data: ArrayValueData,
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Project = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                ViewGroupSales();
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['30%'],
                            borderRadius: 4
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ArrayValueLabel,

                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
                        }
                    },
                    fill: {
                        opacity: 1
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px'
                        },
                        y: {
                            formatter: function (val) {
                                return val + " units" //+ val + " ₱"
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });

            //account status - pie chart
            jQuery(function ($) {
                document.getElementById('kt_account_status_piechart').innerHTML = "";
                var element = document.getElementById('kt_account_status_piechart');
                if (!element) {
                    return;
                }

                var options = {
                    series: [ltrlPiePending, ltrlPieReserved, ltrlPieApproved, ltrlPieRejected],
                    chart: {
                        type: 'donut', height: 180,
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                const Status = config.w.config.labels[config.dataPointIndex];
                                ViewAccountStatus(Status)
                            }
                        },
                    },
                    plotOptions: { pie: { donut: { size: '55%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ["Pending", "Reserved", "Approved", "Rejected"],
                    legend: { show: false, },
                    colors: ['#0275d8', '#5cb85c', '#f0ad4e', '#d9534f'],
                    grid: {
                        padding: {
                            top: -2,
                            left: -5
                        }
                    },
                };

                var chart = new ApexCharts(element, options);
                chart.render();


            });
		}
    </script>

</asp:Content>
