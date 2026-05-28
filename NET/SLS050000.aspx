<%@ Page Title="Sales Monitoring" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS050000.aspx.vb" Inherits="NET.SLS050000" MaintainScrollPositionOnPostback = "true" %>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Sales Admin</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Sales Monitoring</li>
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
								<a href="SLS040000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Lot Inventory Masterlist">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/lot-inventory-masterlist.svg" alt="lot-inventory-masterlist" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS050000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Sales Monitoring">
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
		<!--end::breadcrumb bar-->

		<!--begin::Navbar-->
		<asp:UpdatePanel ID="upnlNavBar" runat="server" UpdateMode="Conditional" class="card mb-6 mb-xl-3">
		<ContentTemplate>
			<div class="col-lg-12">
				<div class="card card-flush h-lg-100">
					<div class="card-header">
						<div class="d-flex align-items-center">
							<%-- begin::header img --%>
							<div class="symbol me-5">
								<img id="imgProject" runat="server" class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sales-monitoring1.svg" alt="project-image" />
							</div>
							<%-- end::header img --%>
                            <%-- begin::title --%>
							<div class="d-flex flex-column">
								<span class="text-gray-800 fw-bolder fs-2 me-3">Sales Monitoring</span>
								<span class="text-muted fw-bold fs-7">Admin</span> 
							</div>
                            <%-- end::title --%>
						</div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Navbar-->

		<asp:UpdatePanel ID="upnlDashboard" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
		<ContentTemplate>
            <div>
			    <div class="row gy-3 g-sm-3">
					<%-- begin::total sales --%>
					<div class="col-lg-4">
						<div class="card card-flush h-lg-100" style="background-color: #6D1B00">
								<!--begin::Header-->
								<div class="card-header mt-3">
									<div class="card-title flex-column">
										<h3 class="mb-1 text-white">Sales 
											<span id="spnCurrentDate" class="mb-1 fw-bold text-gray-400"></span>
										</h3>
									</div>
									<!--end::Toolbar-->
								</div>
								<%-- end::Header --%>

								<!--begin::Body-->
								<div class="card-body pt-6">
									<div class="mb-2 mt-3">
										<!--begin::Statistics-->
										<span class="fs-1 fw-bold text-white me-1 mt-n1">₱</span>
										<span id="spReservationSales" runat="server" class="fs-2x fw-bolder text-white me-2 lh-1 ls-n2" data-kt-countup="true">0</span>
										<!--end::Statistics-->
										<!--begin::Description-->
										<%--<a class="text-gray-400 text-hover-white fw-bold fs-6 d-block pointer" data-bs-toggle="modal" data-bs-target="#kt_reservation_sales">Reservation Sales</a>--%>
										<a class="text-gray-400 text-hover-white fw-bold fs-6 d-block pointer">Reservation Sales</a>
										<!--end::Description-->
									</div>
									<div class="separator"></div>
									<div class="mb-2 mt-3">
										<!--begin::Statistics-->
										<span class="fs-1 fw-bold text-white me-1 mt-n1">₱</span>
										<span id="spBookedSales" runat="server" class="fs-2x fw-bolder text-white me-2 lh-1 ls-n2" data-kt-countup="true">0</span>
										<!--end::Statistics-->
										<!--begin::Description-->
										<%--<a class="text-gray-400 text-hover-white fw-bold fs-6 d-block pointer" data-bs-toggle="modal" data-bs-target="#kt_booked_sales">Booked Sales</a>--%>
										<a class="text-gray-400 text-hover-white fw-bold fs-6 d-block pointer">Booked Sales</a>
										<!--end::Description-->
									</div>
								</div>
								<%-- end::body --%>
							<!--begin::Chart-->
							<%--<div class="kt_total_sales_linechart min-h-auto" data-kt-chart-color="#6D1B00"  style="height: 150px"></div>--%>
							<!--end::Chart-->
						</div>
					</div>
					<%-- end::total sales --%>
			
					<%-- begin::total monthly sales (ytd)--%>
					<div class="col-lg-8">
						<!--begin::Summary-->
						<div class="card card-flush h-lg-100">
							<!--begin::Card header-->
							<div class="card-header mt-6">
								<!--begin::Card title-->
								<div class="card-title flex-column">
									<h3 class="mb-1">Monthly Sales</h3>
									<div class="fs-6 fw-bold text-gray-400">Data for monthly sales
										<span id="spnYrSls" class="fs-6 fw-bold text-gray-400"></span>
									</div>
								</div>
								<!--end::Card title-->
								<!--begin::Card toolbar-->
								<%--<div class="card-toolbar flex-row-fluid justify-content-end">
									<div class="d-flex align-items-center">
										<div class="d-flex flex-column w-100px me-3">
											<input type="text" id="inpFrom" data-kt-repeater="datepicker" class="form-control form-control-sm flatpickr-input" value="01/01/2024"/>
										</div>
										<div class="d-flex flex-column w-100px me-3">
											<input type="text" id="inpTo" data-kt-repeater="datepicker" class="form-control form-control-sm flatpickr-input" value="09/30/2024"/>
										</div>
										<div class="d-flex flex-column w-100px me-3">
											<input type="submit" id="inpFilter" class="btn btn-sm btn-primary" value="Filter"/>
										</div>
									</div>
								</div>--%>
								<!--end::Card toolbar-->
							</div>
							<!--end::Card header-->
		
							<!--begin::Info-->
							<%--<div class="d-flex align-items-center px-9">
								<!--begin::Item-->
								<div class="d-flex align-items-center me-5">
									<a class="d-flex fw-bold align-items-center" data-bs-target="#kt_jan_sales_modal" data-bs-toggle="modal" style="cursor:pointer;">
										<!--begin::Bullet-->
										<div class="bullet w-8px h-3px rounded-2 bg-primary me-2"></div>
										<!--end::Bullet-->
										<!--begin::Label-->
										<span class="fw-bold fs-6 text-gray-600">Jan</span>
										<!--end::Label-->
									</a>
								</div>
								<!--end::Item-->

								<!--begin::Item-->
								<div class="d-flex align-items-center me-5">
									<!--begin::Bullet-->
									<a class="d-flex fw-bold align-items-center" data-bs-target="#kt_feb_sales_modal" data-bs-toggle="modal" style="cursor:pointer;">
										<div class="bullet w-8px h-3px rounded-2 bg-primary me-2"></div>
										<!--end::Bullet-->
										<!--begin::Label-->
										<span class="fw-bold fs-6 text-gray-600">Feb</span>
										<!--end::Label-->
									</a>
								</div>
								<!--end::Item-->

								<!--begin::Item-->
								<div class="d-flex align-items-center me-5">
									<!--begin::Bullet-->
									<a class="d-flex fw-bold align-items-center" data-bs-target="#kt_mar_sales_modal" data-bs-toggle="modal" style="cursor:pointer;">
										<div class="bullet w-8px h-3px rounded-2 bg-primary me-2"></div>
										<!--end::Bullet-->
										<!--begin::Label-->
										<span class="fw-bold fs-6 text-gray-600">Mar</span>
										<!--end::Label-->
									</a>
								</div>
								<!--end::Item-->

								<!--begin::Item-->
								<div class="d-flex align-items-center me-5">
									<!--begin::Bullet-->
									<a class="d-flex fw-bold align-items-center" data-bs-target="#kt_apr_sales_modal" data-bs-toggle="modal" style="cursor:pointer;">
										<div class="bullet w-8px h-3px rounded-2 bg-primary me-2"></div>
										<!--end::Bullet-->
										<!--begin::Label-->
										<span class="fw-bold fs-6 text-gray-600">Apr</span>
										<!--end::Label-->
									</a>
								</div>
								<!--end::Item-->

								<!--begin::Item-->
								<div class="d-flex align-items-center me-5">
									<!--begin::Bullet-->
									<a class="d-flex fw-bold align-items-center" data-bs-target="#kt_jun_sales_modal" data-bs-toggle="modal" style="cursor:pointer;">
										<div class="bullet w-8px h-3px rounded-2 bg-primary me-2"></div>
										<!--end::Bullet-->
										<!--begin::Label-->
										<span class="fw-bold fs-6 text-gray-600">May</span>
										<!--end::Label-->
									</a>
								</div>
								<!--end::Item-->

								<!--begin::Item-->
								<div class="d-flex align-items-center me-5">
									<!--begin::Bullet-->
									<a class="d-flex fw-bold align-items-center" data-bs-target="#kt_jun_sales_modal" data-bs-toggle="modal" style="cursor:pointer;">
										<div class="bullet w-8px h-3px rounded-2 bg-primary me-2"></div>
										<!--end::Bullet-->
										<!--begin::Label-->
										<span class="fw-bold fs-6 text-gray-600">Jun</span>
										<!--end::Label-->
									</a>
								</div>
								<!--end::Item-->
							</div>--%>
							<!--ed::Info-->
			
							<!--begin::Card body-->
							<div class="card-body pt-0 pb-0 px-5">
								<!--begin::Chart-->
								<div id="kt_monthly_sales_linechart" style="height: 260px"></div>
								<%--<div id="kt_monthly_sales_dropdown" style="height: 260px"></div>--%>
								<!--end::Chart-->
							</div>
							<!--end::Card body-->
						</div>
						<!--end::Summary-->
					</div>
					<%-- end::total monthly sales (ytd) --%>

					<%-- begin::reserved and booked sales --%>
					<div class="col-lg-12">
						<div class="card card-flush h-lg-100">
								<!--begin::Header-->
								<div class="card-header mt-3">
									<h3 class="card-title align-items-start flex-column">
										<span id="spnRsvSls" runat="server" class="card-label fs-4 fw-bolder mb-1">Reservation Sales</span>
										<span id="spnBkSls" runat="server" class="card-label fs-4 fw-bolder mb-1 d-none">Booked Sales</span>
									</h3>
										<div class="d-flex align-items-center position-relative my-1">
										<%-- begin:: Search --%>
										<div id="divSearchRsvSls" class="d-flex align-items-center position-relative my-1 d-none">
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-1 position-absolute ms-4">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon-->
											<input id="tbxSearchRsvSls" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
										</div>
										<%-- end:: Search --%>
										<%-- begin::Edit Nav --%>
											<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
												<!--begin::Nav item-->
												<li id="liRsvSls" onclick="toggleRsvSls(); return false;" class="nav-item mt-2 ml-5">
													<a href="#aRsvSls" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6 active">
														<div data-bs-toggle="tooltip" data-bs-placement="top" title="Reservation Sales">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-house-gear-fill" viewBox="0 0 16 16">
															  <path d="M7.293 1.5a1 1 0 0 1 1.414 0L11 3.793V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v3.293l2.354 2.353a.5.5 0 0 1-.708.708L8 2.207 1.354 8.854a.5.5 0 1 1-.708-.708z"/>
															  <path d="M11.07 9.047a1.5 1.5 0 0 0-1.742.26l-.02.021a1.5 1.5 0 0 0-.261 1.742 1.5 1.5 0 0 0 0 2.86 1.5 1.5 0 0 0-.12 1.07H3.5A1.5 1.5 0 0 1 2 13.5V9.293l6-6 4.724 4.724a1.5 1.5 0 0 0-1.654 1.03"/>
															  <path d="m13.158 9.608-.043-.148c-.181-.613-1.049-.613-1.23 0l-.043.148a.64.64 0 0 1-.921.382l-.136-.074c-.561-.306-1.175.308-.87.869l.075.136a.64.64 0 0 1-.382.92l-.148.045c-.613.18-.613 1.048 0 1.229l.148.043a.64.64 0 0 1 .382.921l-.074.136c-.306.561.308 1.175.869.87l.136-.075a.64.64 0 0 1 .92.382l.045.149c.18.612 1.048.612 1.229 0l.043-.15a.64.64 0 0 1 .921-.38l.136.074c.561.305 1.175-.309.87-.87l-.075-.136a.64.64 0 0 1 .382-.92l.149-.044c.612-.181.612-1.049 0-1.23l-.15-.043a.64.64 0 0 1-.38-.921l.074-.136c.305-.561-.309-1.175-.87-.87l-.136.075a.64.64 0 0 1-.92-.382ZM12.5 14a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3"/>
															</svg>
														</div>
													<%--<asp:Label ID="lblMasterlistCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label>--%>
													</a>
												</li>
												<!--end::Nav item-->
												<!--begin::Nav item-->
												<li id="liBkSls" onclick="toggleBkSls(); return false;" class="nav-item mt-2">
													<a href="#aBkSls" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6">
														<div data-bs-toggle="tooltip" data-bs-placement="top" title="Booked Sales">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-houses-fill" viewBox="0 0 16 16">
																<path d="M7.207 1a1 1 0 0 0-1.414 0L.146 6.646a.5.5 0 0 0 .708.708L1 7.207V12.5A1.5 1.5 0 0 0 2.5 14h.55a2.5 2.5 0 0 1-.05-.5V9.415a1.5 1.5 0 0 1-.56-2.475l5.353-5.354z"/>
																<path d="M8.793 2a1 1 0 0 1 1.414 0L12 3.793V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v3.293l1.854 1.853a.5.5 0 0 1-.708.708L15 8.207V13.5a1.5 1.5 0 0 1-1.5 1.5h-8A1.5 1.5 0 0 1 4 13.5V8.207l-.146.147a.5.5 0 1 1-.708-.708z"/>
															</svg>
														</div>
													</a>
												</li>
												<!--end::Nav item-->
											</ul>
										<%-- end::Edit Nav --%>
										</div>
								</div>
								<%-- end::Header --%>

								<!--begin::Body-->
								<div class="card-body pt-0 pb-0">
									<div class="tab-content">
										<div class="tab-pane fade show active" id="aRsvSls">
											<div class="d-flex align-items-center position-relative my-1">
												<%-- begin:: search --%>
													<span class="svg-icon svg-icon-1 position-absolute ms-4">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<!--end::Svg Icon-->
													<input id="tbxSearchReserved" type="text" class="form-control form-control-solid w-250px ps-12 " placeholder="Search Record" />
												<%-- end:: search --%>
											</div>
											<!--begin::Gridview-->
											<div style="overflow-x:auto; scrollbar-width: thin;">
												<asp:GridView ID="gvRsvSales" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" >
												<Columns>
													<asp:TemplateField HeaderText="Sellers">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img alt="" src="<%# Eval("SlrImg") %>" />
																</div>
																<span onclick="ViewRsvDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-150px w-100 pointer" >
																<%--<span style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" class="d-flex flex-column min-w-150px w-100 pointer" >--%>
																	<span class="text-dark text-hover-primary fw-bolder fs-6 nowrap-auto"><%# Eval("Seller") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Group") %></span>
																</span>
															</div>
														</ItemTemplate>
														<HeaderStyle CssClass="mw-5px min-w-200px" />
														<ItemStyle CssClass="mw-5px min-w-200px" />
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Buyer">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlBuyer" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<span style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" class="d-flex flex-column min-w-250px w-100" >
																		<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Buyer") %></span>
																		<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Project") %> | <%# Eval("Unit") %> </span>
																	</span>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</ItemTemplate>
														<HeaderStyle CssClass="mw-5px min-w-350px" />
														<ItemStyle CssClass="mw-5px min-w-350px" />
													</asp:TemplateField>
													<asp:TemplateField HeaderText="TCP">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlTCP" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblTCP" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TCP") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</ItemTemplate>
														<HeaderStyle CssClass="mw-5px min-w-200px" />
														<ItemStyle CssClass="mw-5px min-w-200px" />
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Reservation Date">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlRsvDate" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblRsvDate" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("RsvDate") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</ItemTemplate>
													<HeaderStyle CssClass="mw-5px min-w-175px" />
													<ItemStyle CssClass="mw-5px min-w-175px" />
													</asp:TemplateField>
												</Columns>
												</asp:GridView>
											</div>
											<!--end::Gridview-->
										</div>
										<div class="tab-pane fade show" id="aBkSls">
											<div class="d-flex align-items-center position-relative my-1">
												<%-- begin:: search --%>
													<span class="svg-icon svg-icon-1 position-absolute ms-4">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<!--end::Svg Icon-->
													<input id="tbxSearchBooked" type="text" class="form-control form-control-solid w-250px ps-12 " placeholder="Search Record" />
												<%-- end:: search --%>
											</div>
											<!--begin::Gridview-->
											<div style="overflow-x:auto; scrollbar-width: thin;">
												<asp:GridView ID="gvBkSales" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" >
												<Columns>
													<asp:TemplateField HeaderText="Sellers">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<div class="symbol symbol-30px overflow-hidden me-3"> 
																	<img alt="" src="<%# Eval("SlrImg") %>" />
																</div>
																<span onclick="ViewBkDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-150px w-100 pointer" >
																<%--<span style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" class="d-flex flex-column min-w-150px w-100 pointer" >--%>
																	<span class="text-dark text-hover-primary fw-bolder fs-6 nowrap-auto"><%# Eval("Seller") %></span>
																	<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Group") %></span>
																</span>
															</div>
														</ItemTemplate>
														<HeaderStyle CssClass="mw-5px min-w-200px" />
														<ItemStyle CssClass="mw-5px min-w-200px" />
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Buyer">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlBuyer" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<span style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" class="d-flex flex-column min-w-250px w-100" >
																		<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Buyer") %></span>
																		<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Project") %> | <%# Eval("Unit") %> </span>
																	</span>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</ItemTemplate>
														<HeaderStyle CssClass="mw-5px min-w-350px" />
														<ItemStyle CssClass="mw-5px min-w-350px" />
													</asp:TemplateField>
													<asp:TemplateField HeaderText="TCP">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlTCP1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblTCP1" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TCP") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</ItemTemplate>
														<HeaderStyle CssClass="mw-5px min-w-200px" />
														<ItemStyle CssClass="mw-5px min-w-200px" />
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Booked Date">
														<ItemTemplate>
															<div class="d-flex align-items-center w-100">
																<asp:UpdatePanel ID="upnlBkDate" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
																<ContentTemplate>
																	<asp:Label ID="lblBkDate" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("BkDate") %>'></asp:Label>
																</ContentTemplate>
																</asp:UpdatePanel>
															</div>
														</ItemTemplate>
													<HeaderStyle CssClass="mw-5px min-w-175px" />
													<ItemStyle CssClass="mw-5px min-w-175px" />
													</asp:TemplateField>
												</Columns>
												</asp:GridView>
											</div>
											<!--end::Gridview-->
										</div>
									</div>
								</div>
								<%-- end::body --%>
						</div>
					</div>
					<%-- end::reserved and booked sales --%>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>

		<%-- begin::reserved detail modal --%>
		<div id="mdlRsvDetail" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Reservation Detail</h5>
						<div class="d-flex align-items-center position-relative my-1">
							<!--begin::Close-->
							<div id="btnClose" class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
						<div class="card-body py-3">
							<div class="row mb-3">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Seller</span>
									<asp:TextBox ID="tbxSeller" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Buyer</span>
									<asp:TextBox ID="tbxBuyer" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Project | Unit</span>
									<asp:TextBox ID="tbxProject" runat="server" class="form-control" readonly="true">-</asp:TextBox>
									<asp:TextBox ID="tbxUnit" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">TCP</span>
									<asp:TextBox ID="tbxTCP" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Reservation Date</span>
									<asp:TextBox ID="tbxRsvDate" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Financing Scheme</span>
									<asp:TextBox ID="tbxFinancingScheme" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:TextBox ID="tbxStatus" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
								<span class="input-group-text input-group-text-top min-w-150px">Payment Term</span>
									<asp:TextBox ID="tbxPmtTerm" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" readonly="true">-</asp:TextBox>
								</div>
						</div>
					</div>
				</div>
				</div>
			</div>
		</div>
		<%-- end::reserved detail modal --%>

		<%-- begin::booked detail modal --%>
		<div id="mdlBkDetail" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Booked Detail</h5>
						<div class="d-flex align-items-center position-relative my-1">
							<!--begin::Close-->
							<div id="btnClose2" class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
						<div class="card-body py-3">
							<div class="row mb-3">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Seller</span>
									<asp:TextBox ID="tbxSeller1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Buyer</span>
									<asp:TextBox ID="tbxBuyer1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Project | Unit</span>
									<asp:TextBox ID="tbxProject1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
									<asp:TextBox ID="tbxUnit1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">TCP</span>
									<asp:TextBox ID="tbxTCP1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Booked Date</span>
									<asp:TextBox ID="tbxBkDate" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Financing Scheme</span>
									<asp:TextBox ID="tbxFinancingScheme1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:TextBox ID="tbxStatus1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
								<span class="input-group-text input-group-text-top min-w-150px">Payment Term</span>
									<asp:TextBox ID="tbxPmtTerm1" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" readonly="true">-</asp:TextBox>
								</div>
						</div>
					</div>
				</div>
				</div>
			</div>
		</div>
		<%-- end::booked detail modal --%>


    </div>
	<%-- end::Post --%>

    <%-- scripts related to this page --%>
	<script type="text/javascript">
        //for line chart monthly sales
        var ltrlLineMonthlyReserved = '<asp:Literal ID="ltrlLineMonthlyReserved" runat="server" />';
        var ltrlLineMonthlyBooked = '<asp:Literal ID="ltrlLineMonthlyBooked" runat="server" />';
		var ltrlLineMonthlyName = '<asp:Literal ID="ltrlLineMonthlyName" runat="server" />';

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $gvReserved = $('#ContentPlaceHolder1_gvRsvSales tbody tr');
            $('#tbxSearchReserved').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvReserved.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvBooked = $('#ContentPlaceHolder1_gvBkSales tbody tr');
            $('#tbxSearchBooked').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvBooked.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
        }
        //table search

        //link button
        function toggleRsvSls() {
            $('#<%= spnRsvSls.ClientID %>').removeClass('d-none');
			$('#<%= spnBkSls.ClientID %>').addClass('d-none'); 
		}
        function toggleBkSls() {
			$('#<%= spnRsvSls.ClientID %>').addClass('d-none');
			$('#<%= spnBkSls.ClientID %>').removeClass('d-none');
		}

        //view reservation detail - modal 
        function ViewRsvDetail(Project) {
			Project = Project.getAttribute("data-value");
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS050000',
                    'Type': 'View Reservation Detail (Project)',
                    'Project': Project
                },
				success: function (response) {
                    var tbxSeller = document.getElementById("ContentPlaceHolder1_tbxSeller");
                    var tbxBuyer = document.getElementById("ContentPlaceHolder1_tbxBuyer");
                    var tbxProject = document.getElementById("ContentPlaceHolder1_tbxProject");
                    var tbxUnit = document.getElementById("ContentPlaceHolder1_tbxUnit");
                    var tbxTCP = document.getElementById("ContentPlaceHolder1_tbxTCP");
                    var tbxRsvDate = document.getElementById("ContentPlaceHolder1_tbxRsvDate");
                    var tbxFinancingScheme = document.getElementById("ContentPlaceHolder1_tbxFinancingScheme");
                    var tbxStatus = document.getElementById("ContentPlaceHolder1_tbxStatus");
                    var tbxPmtTerm = document.getElementById("ContentPlaceHolder1_tbxPmtTerm");

                    tbxSeller.value = response[0].Seller;
                    tbxBuyer.value = response[0].Buyer;
					tbxProject.value = response[0].Project;
                    tbxUnit.value = response[0].Unit;
                    tbxTCP.value = response[0].TCP;
                    tbxRsvDate.value = response[0].RsvDate;
                    tbxFinancingScheme.value = response[0].FinancingScheme;
                    tbxStatus.value = response[0].Status;
                    tbxPmtTerm.value = response[0].PmtTerm;
                    $('#mdlRsvDetail').modal('show');
                },
            });
        }

        //view booked detail - modal 
        function ViewBkDetail(Project) {
			Project = Project.getAttribute("data-value");
			console.log(Project)
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS050000',
                    'Type': 'View Booked Detail (Project)',
                    'Project': Project
                },
				success: function (response) {
					console.log(response)
                    var tbxSeller1 = document.getElementById("ContentPlaceHolder1_tbxSeller1");
                    var tbxBuyer1 = document.getElementById("ContentPlaceHolder1_tbxBuyer1");
                    var tbxProject1 = document.getElementById("ContentPlaceHolder1_tbxProject1");
                    var tbxUnit1 = document.getElementById("ContentPlaceHolder1_tbxUnit1");
                    var tbxTCP1 = document.getElementById("ContentPlaceHolder1_tbxTCP1");
                    var tbxBkDate = document.getElementById("ContentPlaceHolder1_tbxBkDate");
                    var tbxFinancingScheme1 = document.getElementById("ContentPlaceHolder1_tbxFinancingScheme1");
                    var tbxStatus1 = document.getElementById("ContentPlaceHolder1_tbxStatus1");
                    var tbxPmtTerm1 = document.getElementById("ContentPlaceHolder1_tbxPmtTerm1");

                    tbxSeller1.value = response[0].Seller1;
                    tbxBuyer1.value = response[0].Buyer1;
					tbxProject1.value = response[0].Project1;
                    tbxUnit1.value = response[0].Unit1;
                    tbxTCP1.value = response[0].TCP1;
                    tbxBkDate.value = response[0].BkDate;
                    tbxFinancingScheme1.value = response[0].FinancingScheme1;
                    tbxStatus1.value = response[0].Status1;
                    tbxPmtTerm1.value = response[0].PmtTerm1;
                    $('#mdlBkDetail').modal('show');
                },
            });
        }

        //page load script ------------------------------------------------------------------------------------------------------------------------
        function pageLoad(sender, args) { InitializeSettings(); }
		function InitializeSettings() {
			//declare const
			const currentDate = new Date();
			const currentYear = new Date().getFullYear();	
			const currentMonthIndex = currentDate.getMonth();
			const monthNames = [
				'January', 'February', 'March', 'April', 'May', 'June',
				'July', 'August', 'September', 'October', 'November', 'December'
			];
			const currentMonthName = monthNames[currentMonthIndex];

			//sales - current year
			const dateString = `- As of ${currentMonthName} ${currentYear}`;
			document.getElementById('spnCurrentDate').innerHTML = `<span>${dateString}</span>`;

			const slsDate = ` for the year ${currentYear}`;
			document.getElementById('spnYrSls').innerHTML = `<span>${slsDate}</span>`;

            //combobox
            $('[data-kt-repeater="select2"]').select2();
            //combobox

            //date
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y"
            });
            //date

            //monthly sales line-chart ----------------------------------------------------------------------------------------------
            jQuery(function ($) {
                var element = document.getElementById("kt_monthly_sales_linechart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var lightColor = KTUtil.getCssVariableValue('--bs-light-primary');

                const ArrayValueReserved = ltrlLineMonthlyReserved.split(",")
                const ArrayValueBooked = ltrlLineMonthlyBooked.split(",")
                const ArrayValueLabel = ltrlLineMonthlyName.split(",")

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Reserved Sales',
                        data: ArrayValueReserved
                    }, {
                        name: 'Booked Sales',
                        data: ArrayValueBooked
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'area',
                        height: 260,
                        toolbar: {
                            show: false
                        }
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 1
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [baseColor]
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
                        },
                        crosshairs: {
                            position: 'front',
                            stroke: {
                                color: baseColor,
                                width: 1,
                                dashArray: 3
                            }
                        },
                        tooltip: {
                            enabled: true,
                            formatter: undefined,
                            offsetY: 0,
                            style: {
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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }); //+ " thousands"
                            },
                        }
                    },
                    colors: ['#5cb85c', '#d9534f'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    markers: {
                        strokeColor: baseColor,
                        strokeWidth: 3
                    }
                };


                var chart = new ApexCharts(element, options);
                chart.render();
            });
		}

    </script>

</asp:Content>
