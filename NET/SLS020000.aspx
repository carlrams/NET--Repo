<%@ Page Title="Seller Management" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS020000.aspx.vb" Inherits="NET.SLS020000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Seller Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Seller's Status</li>
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
								<a href="SLS020000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Seller Management">
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
								<img id="imgProject" runat="server" class="mw-125px mw-lg-125px" src="assets/media/svg/apps/seller-management.svg" alt="project-image" />
							</div>
							<%-- end::header img --%>
                            <%-- begin::title --%>
							<div class="d-flex flex-column">
								<span class="text-gray-800 fw-bolder fs-2 me-3">Seller Management</span>
								<span class="text-muted fw-bold fs-7">Admin | Seller Monitoring</span> 
							</div>
                            <%-- end::title --%>
						</div>
						<div class="d-flex align-items-center position-relative my-1">
						<%-- begin::Edit Nav --%>
							<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
								<li class="nav-item">
									<a href="#aStatistics" data-bs-toggle="tab" runat="server" class="ml-lg-5 nav-link text-active-primary active">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Stats">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-bar-chart-fill" viewBox="0 0 16 16">
											  <path d="M1 11a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1zm5-4a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v7a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1zm5-5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1z"/>
											</svg>
										</div>
									</a>
								</li>	
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aApproval" data-bs-toggle="tab" runat="server" class="ml-lg-5 nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="For Approval">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-clipboard-fill" viewBox="0 0 16 16">
											  <path fill-rule="evenodd" d="M10 1.5a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h3a.5.5 0 0 0 .5-.5zm-5 0A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5v1A1.5 1.5 0 0 1 9.5 4h-3A1.5 1.5 0 0 1 5 2.5zm-2 0h1v1A2.5 2.5 0 0 0 6.5 5h3A2.5 2.5 0 0 0 12 2.5v-1h1a2 2 0 0 1 2 2V14a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V3.5a2 2 0 0 1 2-2"/>
											</svg>
											<asp:Label ID="lblApprovalCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label>
										</div>
									</a>
								</li>	
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aApproved" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Approved">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-clipboard-check-fill" viewBox="0 0 16 16">
											  <path d="M6.5 0A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0zm3 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5z"/>
											  <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1A2.5 2.5 0 0 1 9.5 5h-3A2.5 2.5 0 0 1 4 2.5zm6.854 7.354-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 0 1 .708-.708L7.5 10.793l2.646-2.647a.5.5 0 0 1 .708.708"/>
											</svg>
											<asp:Label ID="lblApprovedCount" runat="server" class="badge badge-secondary ms-1">0</asp:Label>
										</div>
									</a>
								</li>
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aDenied" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Denied">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-clipboard-x-fill" viewBox="0 0 16 16">
											  <path d="M6.5 0A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0zm3 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5z"/>
											  <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1A2.5 2.5 0 0 1 9.5 5h-3A2.5 2.5 0 0 1 4 2.5zm4 7.793 1.146-1.147a.5.5 0 1 1 .708.708L8.707 10l1.147 1.146a.5.5 0 0 1-.708.708L8 10.707l-1.146 1.147a.5.5 0 0 1-.708-.708L7.293 10 6.146 8.854a.5.5 0 1 1 .708-.708z"/>
											</svg>
											<asp:Label ID="lblRejectedCount" runat="server" class="badge badge-secondary ms-1">0</asp:Label>
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

		<%-- begin::Content --%>
		<asp:UpdatePanel ID="mdlSellerDtl" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
		<ContentTemplate>
            <%-- begin::Tabs --%>
			<div class="tab-content">
                <%-- begin::Statistics --%>
				<div class="tab-pane fade show active" id="aStatistics">
					<%-- begin::monitoring overview --%>
					<div class="col-xxl-12">
						<div class="card card-xxl-stretch mb-5 mb-xl-3">
							<!--begin::Header-->
							<div class="card-header card-header-stretch">
								<div class="card-title flex-column">
									<h3 class="mb-1">Monitoring Overview 
										<span id="spnCurrentDate" class="mb-1 fw-bold text-gray-400"></span>
									</h3>
								</div>
							</div>
							<%-- end::Header --%>

							<!--begin::Body-->
							<div class="card-body pt-0 pb-0 px-0">
								<!--begin::Row-->
								<div class="row p-0 mb-5 px-9">
									<!--begin::Col-->
									<div class="col">
										<div class="border border-dashed border-gray-300 text-center min-w-125px rounded pt-2 pb-2 my-3">
											<span class="fs-4 fw-bold text-info d-block">For Approval</span>
											<span id="spnForApproval" class="fs-2hx fw-bolder text-gray-800" runat="server" data-kt-countup="true">0</span>
										</div>
									</div>
									<!--end::Col-->
									<!--begin::Col-->
									<div class="col">
										<div class="border border-dashed border-gray-300 text-center min-w-125px rounded pt-2 pb-2 my-3">
											<span class="fs-4 fw-bold text-primary d-block">Approved</span>
											<span id="spnApproved" class="fs-2hx fw-bolder text-gray-800" runat="server" data-kt-countup="true">0</span>
										</div>
									</div>
									<!--end::Col-->
									<!--begin::Col-->
									<div class="col">
										<div class="border border-dashed border-gray-300 text-center min-w-125px rounded pt-2 pb-2 my-3">
											<span class="fs-4 fw-bold text-danger d-block">Rejected</span>
											<span id="spnRejected" class="fs-2hx fw-bolder text-gray-800" runat="server" data-kt-countup="true">0</span>
										</div>
									</div>
								</div>
								<!--end::Row-->
							</div>
							<%-- end::body --%>
						</div>
					</div>

					<div class="col-xxl-12">
						<div class="card card-xxl-stretch mb-5 mb-xl-3">
							<!--begin::Header-->
							<div class="card-header card-header-stretch">
								<div class="card-title flex-column">
									<h3 class="mb-1">Users Chart 
										<span id="spnCurrent" class="mb-1 fw-bold text-gray-400"></span>
									</h3>
								</div>
							</div>
							<%-- end::Header --%>

							<!--begin::Body-->
							<div class="card-body pt-6">
                                <%-- begin::Chart --%>
								<div class="card-body pt-5 pb-0 px-5">
									<!--begin::Chart-->
									<div id="kt_user_barchart" class="card-rounded-bottom" style="height: 260px"></div>
									<!--end::Chart-->
								</div>
                                <%-- end::Chart --%>
							</div>
							<%-- end::body --%>
						</div>
					</div>
					<%-- end::monitoring overview --%>
				</div>
                <%-- end::Statistics --%>

                <%-- begin::For Approval --%>
				<div class="tab-pane fade show" id="aApproval">
					<%-- begin::gridview --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fs-4 fw-bolder mb-1">Verify the following sellers</span>
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
								<input id="tbxSearchApproval" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
								</div>
							</div>
							<div class="card-body py-3">
								<!--begin::Gridview-->
								<div style="overflow-x:auto; scrollbar-width: thin;">
									<asp:GridView ID="gvApproval" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
								<Columns>
									<asp:TemplateField HeaderText="Sellers">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<span onclick="ViewDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
															<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Name") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Type") %> | <%# Eval("Group") %> | <%# Eval("Email") %> </span>
														</span>
													</div>
												</div>
											</div>
											<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-500px" />
										<ItemStyle CssClass="mw-5px min-w-500px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Status">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<asp:UpdatePanel ID="upnlStatus0" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
														<ContentTemplate>
															<asp:Label ID="lblStatus0" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Status") %>'></asp:Label>
															<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
														</ContentTemplate>
														</asp:UpdatePanel>
													</div>
												</div>
											</div>
											<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-300px" />
										<ItemStyle CssClass="mw-5px min-w-300px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Date Created">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<asp:UpdatePanel ID="upnlDateCreated" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
														<ContentTemplate>
															<asp:Label ID="lblDateCreated" runat="server" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("DateCreated") %>'></asp:Label>
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
                <%-- end::For Approval --%>

                <%-- begin::Approved --%>
				<div class="tab-pane fade" id="aApproved">
					<%-- begin::gridview --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fs-4 fw-bolder mb-1">List of Approved Sellers</span>
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
									<asp:TemplateField HeaderText="Sellers">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<span onclick="ViewRvtDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
															<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Name") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Type") %> | <%# Eval("Group") %> | <%# Eval("Email") %> </span>
														</span>
													</div>
												</div>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-500px" />
										<ItemStyle CssClass="mw-5px min-w-500px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Status">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<asp:UpdatePanel ID="upnlStatus1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
														<ContentTemplate>
															<asp:Label ID="lblStatus1" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Status") %>'></asp:Label>
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
										<HeaderStyle CssClass="mw-5px min-w-300px" />
										<ItemStyle CssClass="mw-5px min-w-300px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Date Approved">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<asp:UpdatePanel ID="upnlDateApproved" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
														<ContentTemplate>
															<asp:Label ID="lblDateApproved" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("DateApproved") %>'></asp:Label>
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
                <%-- end::Approved --%>

                <%-- begin::Denied --%>
				<div class="tab-pane fade" id="aDenied">
					<%-- begin::gridview --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fs-4 fw-bolder mb-1">List of Denied Sellers</span>
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
								<input id="tbxSearchDenied" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
								</div>
							</div>
							<div class="card-body py-3">
								<!--begin::Gridview-->
								<div style="overflow-x:auto; scrollbar-width: thin;">
									<asp:GridView ID="gvDenied" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
										<EmptyDataTemplate>
											<div style="text-align: center;" class="text-muted fst-italic">
												No records found.
											</div>
										</EmptyDataTemplate>
									<Columns>
										<asp:TemplateField HeaderText="Sellers">
											<ItemTemplate>
												<div class="overlay overflow-hidden">
													<div class="overlay-wrapper">
														<div class="d-flex align-items-center w-100">
															<span onclick="ViewRvtDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
																<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Name") %></span>
																<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Type") %> | <%# Eval("Group") %> | <%# Eval("Email") %> </span>
															</span>
														</div>
													</div>
												</div>
												<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
											</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-500px" />
											<ItemStyle CssClass="mw-5px min-w-500px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Status">
											<ItemTemplate>
												<div class="overlay overflow-hidden">
													<div class="overlay-wrapper">
														<div class="d-flex align-items-center w-100">
															<asp:UpdatePanel ID="upnlStatus2" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
															<ContentTemplate>
																<asp:Label ID="lblStatus2" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Status") %>'></asp:Label>
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
															<asp:UpdatePanel ID="upnlApprover1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
															<ContentTemplate>
																<asp:Label ID="lblApprover1" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Approver") %>'></asp:Label>
															</ContentTemplate>
															</asp:UpdatePanel>
														</div>
													</div>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="mw-5px min-w-300px" />
											<ItemStyle CssClass="mw-5px min-w-300px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Date Denied">
											<ItemTemplate>
												<div class="overlay overflow-hidden">
													<div class="overlay-wrapper">
														<div class="d-flex align-items-center w-100">
															<asp:UpdatePanel ID="upnlDateDenied" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
															<ContentTemplate>
																<asp:Label ID="lblDateDenied" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("DateDenied") %>'></asp:Label>
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
                <%-- end::Denied --%>
			</div>
            <%-- end::Tabs --%>

			<%-- begin::Modals --%>
				<%-- begin::seller detail modal --%>
				<div id="kt_sellerdtl_modal" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
					<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
						<div class="modal-content">
							<div class="modal-header">
								<h5 class="modal-title">Seller Details</h5>
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
							<div class="modal-body">
								<div class="card-body py-3">
									<%-- begin:: Input group --%>
									<div class="row mb-3">
										<div class="input-group input-group-sm mb-2" style="display:none;">
											<input id="tbxAgentCode" runat="server" type="text" class="form-control" readonly="" style="display:none;"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Profile">
												<img id="SlrImgApproval" alt="" src="" />
											</div>
											<input id="tbxFirstName" runat="server" type="text" class="form-control" readonly="" />
											<input id="tbxMiddleName" runat="server" type="text" class="form-control" readonly="" />
											<input id="tbxLastName" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Email">
												<img src="assets/media/svg/apps/email.svg" alt="" />
											</div>
											<input id="tbxEmail" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Type">
												<img src="assets/media/svg/apps/type.svg" alt="" />
											</div>
											<input id="tbxType" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Group">
												<img src="assets/media/svg/apps/group.svg" alt="" />
											</div>
											<input id="tbxGroup" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Status">
												<img src="assets/media/svg/apps/status.svg" alt="" />
											</div>
											<input id="tbxStatus" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Date Created">
												<img src="assets/media/svg/apps/datecreated.svg" alt="" />
											</div>
											<input id="tbxDateCreated" runat="server" type="text" class="form-control" readonly="" />
										</div>
									<%-- end:: Input group --%>
								</div>
				
									<%-- begin:: confirm --%>
									<div class="d-flex align-items-center py-3 py-md-1 gap-4">
										<asp:Linkbutton id="btnApprove" runat="server" OnClientClick="confirmApprove(event); return false;" class="btn btn-primary">Approve</asp:Linkbutton>
										<asp:Linkbutton id="btnReject" runat="server" OnClientClick="rejectSeller(event); return false;" class="btn btn-light-danger">Reject</asp:Linkbutton>
										<%--<a class="btn btn-primary" role="button">Approve</a>
										<a class="btn btn-light-danger" role="button">Reject</a>--%>
									</div>
									<%-- end:: confirm --%>
							</div>
						</div>
					</div>
				</div>
				</div>
				<%-- end::seller detail modal --%>

				<%-- begin::revert seller modal --%>
				<div id="kt_revert_seller_modal" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
					<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
						<div class="modal-content">
							<div class="modal-header">
								<h5 class="modal-title">Seller Details</h5>
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
							<div class="modal-body">
								<div class="card-body py-3">
									<%-- begin:: Input group --%>
									<div class="row mb-3">
										<div class="input-group input-group-sm mb-2" style="display:none;">
											<input id="tbxRvtAgentCode" runat="server" type="text" class="form-control" readonly="" style="display:none;"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Profile">
												<img id="SlrImgApproved" alt="" src="" />
											</div>
											<input id="tbxRvtFirstName" runat="server" type="text" class="form-control" readonly="" />
											<input id="tbxRvtMiddleName" runat="server" type="text" class="form-control" readonly="" />
											<input id="tbxRvtLastName" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Email">
												<img src="assets/media/svg/apps/email.svg" alt="" />
											</div>
											<input id="tbxRvtEmail" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Type">
												<img src="assets/media/svg/apps/type.svg" alt="" />
											</div>
											<input id="tbxRvtType" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Group">
												<img src="assets/media/svg/apps/group.svg" alt="" />
											</div>
											<input id="tbxRvtGroup" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Status">
												<img src="assets/media/svg/apps/status.svg" alt="" />
											</div>
											<input id="tbxRvtStatus" runat="server" type="text" class="form-control" readonly="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Date">
												<img src="assets/media/svg/apps/datecreated.svg" alt="" />
											</div>
											<input id="tbxRvtDateApproved" runat="server" type="text" class="form-control" readonly="" />
										</div>
									<%-- end:: Input group --%>
								</div>
				
									<%-- begin:: confirm --%>
									<div class="d-flex align-items-center py-3 py-md-1 gap-4">
										<asp:Linkbutton id="btnRevert" runat="server" OnClientClick="revertSeller(event); return false;" class="btn btn-danger">Revert</asp:Linkbutton>
									</div>
									<%-- end:: confirm --%>
							</div>
						</div>
					</div>
				</div>
				</div>
				<%-- end::revert seller modal --%>

				<%-- begin::account status modal --%>
				<div id="mdlUsers" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
					<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
						<div class="modal-content modal-rounded">
							<div class="modal-header">
								<h5 class="modal-title">List of Users</h5>
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
							<div class="modal-body">
								<div class="card-toolbar">
									<div class="d-flex flex-stack flex-wrap gap-4">
										<%-- begin::search --%>
										<div class="d-flex align-items-center position-relative my-1">
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-1 position-absolute ms-4">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon-->
											<input id="tbxSearchUsers" type="text" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
										</div>
										<%-- end::search --%>	
									</div>

									<!--begin::Table | Gridview-->
									<div class="card-body py-3">
										<div style="overflow-x:auto; scrollbar-width: thin;">
											<div class="table-responsive overflow-hidden min-h-300px" >
											<!--begin::Table-->
												<table id="gvDisplayUsers" class="table table-row-dashed tscroll table-row-gray-300 table-hover align-middle">
													<!--begin::Table head-->
													<thead>
														<tr>
															<th class="text-dark fw-bold fs-5 min-w-250px">Seller</th>
															<th class="text-dark fw-bold fs-5 min-w-100px">Type</th>
															<th class="text-dark fw-bold fs-5 min-w-100px">Group</th>
															<th class="text-dark fw-bold fs-5 min-w-200px">Email</th>
															<th class="text-dark fw-bold fs-5 min-w-100px">Status</th>
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
									<!--end::Table | Gridview-->
								</div>
							</div>
						</div>
					</div>
				</div>
				<%-- end::account status modal --%>
			<%-- end::Modals --%>

		</ContentTemplate>
		</asp:UpdatePanel>
		<%-- end::Content --%>

    </div>
	<%-- end::Post --%>

    <script type="text/javascript">

    //literals
    var ltrlBarUserData = '<asp:Literal ID="ltrlBarUserData" runat="server" />'
	var ltrlBarUserGroupName = '<asp:Literal ID="ltrlBarUserGroupName" runat="server" />'

    //table search
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        // re-bind your jQuery events here
        loadscript();
    });
    $(document).ready(loadscript);
    function loadscript() {
        var $gvApproval = $('#ContentPlaceHolder1_gvApproval tbody tr');
        $('#tbxSearchApproval').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
            $gvApproval.show().filter(function () {
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
        var $gvDenied = $('#ContentPlaceHolder1_gvDenied tbody tr');
		$('#tbxSearchDenied').keyup(function () {
			var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
            $gvDenied.show().filter(function () {
				var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
				return !~text.indexOf(val);
			}).hide();
        });
    }

	//approve seller 
	function confirmApprove(event) {
        event.preventDefault();
		Swal.fire({
			title: 'Are you sure?',
			text: 'This seller will be approved',
			icon: 'warning',
			showCancelButton: true,
			confirmButtonText: 'Confirm',
			cancelButtonText: 'Cancel'

			}).then((result) => {
				if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Seller successfully approved!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
					__doPostBack('<%= btnApprove.UniqueID %>', '');
						$('#kt_sellerdtl_modal').modal('hide');
                    });
			} else {
				// If the user cancels, do nothing
				Swal.fire(
					'Cancelled',
					'Please check the details',
					'error'
				);
			}
		});
	} 

	//reject seller 
	function rejectSeller(event) {
        event.preventDefault();
		Swal.fire({
			title: 'Are you sure?',
			text: 'This seller will be rejected',
			icon: 'warning',
			showCancelButton: true,
			confirmButtonText: 'Confirm',
			cancelButtonText: 'Cancel'

			}).then((result) => {
				if (result.isConfirmed) {
					// If the user confirms, submit the form
					__doPostBack('<%= btnReject.UniqueID %>', '');
                    $('#kt_sellerdtl_modal').modal('hide');
			} else {
				// If the user cancels, do nothing
				Swal.fire(
					'Cancelled',
					'Please carefully check the details.',
					'error'
				);
			}
		});
	} 

	//revert seller for approval
	function revertSeller(event) {
        event.preventDefault();
		Swal.fire({
			title: 'Are you sure?',
			text: 'This seller will be reverted for approval!',
			icon: 'warning',
			showCancelButton: true,
			confirmButtonText: 'Confirm',
			cancelButtonText: 'Cancel'

			}).then((result) => {
                if (result.isConfirmed) {
                    // Show success message before form submission
                    Swal.fire({
                        title: 'Success!',
                        text: 'Seller successfully reverted!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        __doPostBack('<%= btnRevert.UniqueID %>', '');
                        $('#kt_revert_seller_modal').modal('hide');
                    });
			} else {
				// If the user cancels, do nothing
				Swal.fire(
					'Cancelled',
					'Please carefully check the details.',
					'error'
				);
			}
		});
		} 

	//view users on chart
    function ViewUsers(SellerType) {
        $.ajax({
            type: "POST",
            url: "HND000006.ashx",
            data: {
                'FormCode': 'SLS020000',
                'Type': 'View Users (SellerType)',
                'SellerType': SellerType
            },
            success: function (response) {
                DisplayUsers(response)
            },
            error: function (error) {
                // Handle error
                console.log("Error:", error);
            }
        });
	}
    function DisplayUsers(response) {
        //datatable
        var gvDisplayUsers = $("#gvDisplayUsers").DataTable({
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
                { data: 'Seller', class: "min-w-250px" },
                { data: 'Type', class: "min-w-100px" },
                { data: 'Group', class: "min-w-100px" },
                { data: 'Email', class: "min-w-200px" },
                { data: 'Status', class: "min-w-100px" }]
        });
        //datatable
        //search
        $('#tbxSearchUsers').on('keyup', function () {
            gvDisplayUsers.search(this.value).draw();
        });
        // Show the modal
        $('#mdlUsers').modal('show');
    }

    //view seller detail for approval - modal 
	function ViewDetail(SellerCode) {
		SellerCode = SellerCode.getAttribute("data-value");
        $.ajax({
            type: "POST",
            url: "HND000006.ashx",
            data: {
                'FormCode': 'SLS020000',
                'Type': 'View Detail (SellerCode)',
				'SellerCode': SellerCode
            },
			success: function (response) {
				var tbxAgentCode = document.getElementById("ContentPlaceHolder1_tbxAgentCode")
                var tbxFirstName = document.getElementById("ContentPlaceHolder1_tbxFirstName");
                var tbxMiddleName = document.getElementById("ContentPlaceHolder1_tbxMiddleName");
                var tbxLastName = document.getElementById("ContentPlaceHolder1_tbxLastName");
                var tbxEmail = document.getElementById("ContentPlaceHolder1_tbxEmail");
                var tbxType = document.getElementById("ContentPlaceHolder1_tbxType");
                var tbxGroup = document.getElementById("ContentPlaceHolder1_tbxGroup");
                var tbxStatus = document.getElementById("ContentPlaceHolder1_tbxStatus");
                var tbxDateCreated = document.getElementById("ContentPlaceHolder1_tbxDateCreated");

				tbxAgentCode.value = response[0].AgentCode
                tbxFirstName.value = response[0].FirstName;
                tbxMiddleName.value = response[0].MiddleName;
                tbxLastName.value = response[0].LastName;
                tbxEmail.value = response[0].Email;
                tbxType.value = response[0].Type;
                tbxGroup.value = response[0].Group;
                tbxStatus.value = response[0].Status;
                tbxDateCreated.value = response[0].DateCreated;
                var SlrImg = response[0].SlrImg;
                document.getElementById("SlrImgApproval").src = SlrImg;
                $('#kt_sellerdtl_modal').modal('show');
            },
        });
    }

    //view seller detail revert - modal
	function ViewRvtDetail(SellerCode) {
		SellerCode = SellerCode.getAttribute("data-value");
        $.ajax({
            type: "POST",
            url: "HND000006.ashx",
            data: {
                'FormCode': 'SLS020000',
                'Type': 'View Detail Revert (SellerCode)',
				'SellerCode': SellerCode
            },
			success: function (response) {
                var tbxRvtAgentCode = document.getElementById("ContentPlaceHolder1_tbxRvtAgentCode")
                var tbxRvtFirstName = document.getElementById("ContentPlaceHolder1_tbxRvtFirstName");
                var tbxRvtMiddleName = document.getElementById("ContentPlaceHolder1_tbxRvtMiddleName");
                var tbxRvtLastName = document.getElementById("ContentPlaceHolder1_tbxRvtLastName");
                var tbxRvtEmail = document.getElementById("ContentPlaceHolder1_tbxRvtEmail");
                var tbxRvtType = document.getElementById("ContentPlaceHolder1_tbxRvtType");
                var tbxRvtGroup = document.getElementById("ContentPlaceHolder1_tbxRvtGroup");
                var tbxRvtStatus = document.getElementById("ContentPlaceHolder1_tbxRvtStatus");
                var tbxRvtDateApproved = document.getElementById("ContentPlaceHolder1_tbxRvtDateApproved");

                tbxRvtAgentCode.value = response[0].RvtAgentCode
                tbxRvtFirstName.value = response[0].RvtFirstName;
                tbxRvtMiddleName.value = response[0].RvtMiddleName;
                tbxRvtLastName.value = response[0].RvtLastName;
                tbxRvtEmail.value = response[0].RvtEmail;
                tbxRvtType.value = response[0].RvtType;
                tbxRvtGroup.value = response[0].RvtGroup;
                tbxRvtStatus.value = response[0].RvtStatus;
                tbxRvtDateApproved.value = response[0].RvtDateApproved;
                var SlrImg = response[0].SlrImg;
                document.getElementById("SlrImgApproved").src = SlrImg;
                $('#kt_revert_seller_modal').modal('show');
            },
        });
    }

    //form load
    function pageLoad(sender, args) { InitialiseSettings(); }
	function InitialiseSettings() {

        //user stats bar-chart 
        jQuery(function ($) {
            var element = document.getElementById("kt_user_barchart");

            var height = parseInt(KTUtil.css(element, 'height'));
            var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
            var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
            var baseColor = KTUtil.getCssVariableValue('--bs-info');
            var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

            const ArrayValueData = ltrlBarUserData.split(",")
            const ArrayValueLabel = ltrlBarUserGroupName.split(",")

            if (!element) {
                return;
            }

            var options = {
                series: [{
                    name: 'Users',
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
                            var SellerType = config.w.config.xaxis.categories[config.dataPointIndex];
							ViewUsers(SellerType);
                        },
                    },
                },
                plotOptions: {
                    bar: {
                        horizontal: false,
                        columnWidth: ['20%'],
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
                            return val + " Sellers" //+ val + " ₱"
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
	}

    </script>

</asp:Content>
