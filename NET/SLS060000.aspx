<%@ Page Title="Seller's Ranking" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS060000.aspx.vb" Inherits="NET.SLS060000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Seller's Ranking</li>
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
								<a href="SLS050000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Sales Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sales-monitoring1.svg" alt="sales-monitoring" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="SLS060000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Seller's Ranking" >
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
								<img id="imgProject" runat="server" class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sellers-ranking.svg" alt="project-image" />
							</div>
							<%-- end::header img --%>
                            <%-- begin::title --%>
							<div class="d-flex flex-column">
								<span class="text-gray-800 fw-bolder fs-2 me-3">Seller's Ranking</span>
								<span class="text-muted fw-bold fs-7">Admin</span> 
							</div>
                            <%-- end::title --%>
						</div>
						<div class="d-flex align-items-center position-relative my-1">
						<%-- begin::Edit Nav --%>
							<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
								<li class="nav-item">
									<a href="#aStatistics" data-bs-toggle="tab" runat="server" class="ml-lg-1 nav-link text-active-primary active">
										<div data-bs-toggle="tooltip" data-bs-placement="top" title="Statistics">
											<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-bar-chart-fill" viewBox="0 0 16 16">
											  <path d="M1 11a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1zm5-4a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v7a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1zm5-5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1z"/>
											</svg>
										</div>
									</a>
								</li>	
								<!--end::Nav item-->
								<!--begin::Nav item-->
								<li class="nav-item">
									<a href="#aRanking" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary">
										<svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-diagram-3" viewBox="0 0 16 16">
                                          <path fill-rule="evenodd" d="M6 3.5A1.5 1.5 0 0 1 7.5 2h1A1.5 1.5 0 0 1 10 3.5v1A1.5 1.5 0 0 1 8.5 6v1H14a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-1 0V8h-5v.5a.5.5 0 0 1-1 0V8h-5v.5a.5.5 0 0 1-1 0v-1A.5.5 0 0 1 2 7h5.5V6A1.5 1.5 0 0 1 6 4.5zM8.5 5a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5zM0 11.5A1.5 1.5 0 0 1 1.5 10h1A1.5 1.5 0 0 1 4 11.5v1A1.5 1.5 0 0 1 2.5 14h-1A1.5 1.5 0 0 1 0 12.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5zm4.5.5A1.5 1.5 0 0 1 7.5 10h1a1.5 1.5 0 0 1 1.5 1.5v1A1.5 1.5 0 0 1 8.5 14h-1A1.5 1.5 0 0 1 6 12.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5zm4.5.5a1.5 1.5 0 0 1 1.5-1.5h1a1.5 1.5 0 0 1 1.5 1.5v1a1.5 1.5 0 0 1-1.5 1.5h-1a1.5 1.5 0 0 1-1.5-1.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5z"/>
                                        </svg>
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

		<asp:UpdatePanel ID="upnlDashboard" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
		<ContentTemplate>
            <div>
				<div class="tab-content">
				    <div class="tab-pane fade show active" id="aStatistics">
			            <div class="row gy-3 g-sm-3">
			                <%-- begin::group sales - reserved --%>
			                <div class="col-lg-6">
				                <!--begin::Graph-->
				                <div class="card card-flush h-lg-100">
					                <!--begin::Card header-->
					                <div class="card-header mt-3">
						                <!--begin::Card title-->
						                <div class="card-title flex-column">
							                <h3 id="h3RsvChart" runat="server" class="mb-1">Group Sales - Reserved</h3>
							                <h3 id="h3BkChart" runat="server" class="mb-1 d-none">Group Sales - Booked</h3>
							                <div class="fs-6 fw-bold text-gray-400">Sales of groups/channel</div>
						                </div>
						                <!--end::Card title-->
						                <!--begin::Card toolbar-->
						                <div class="card-toolbar">
							                <%-- begin::Edit Nav --%>
							                <ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
									                <!--begin::Nav item-->
									                <li id="liRsvChart" onclick="toggleRsvChart(); return false;" class="nav-item mt-2 ml-5">
										                <a href="#aRsvChart" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6 active">
											                <div data-bs-toggle="tooltip" data-bs-placement="top" title="Group Sales - Reservation">
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
									                <li id="liBkChart" onclick="toggleBkChart(); return false;" class="nav-item mt-2">
										                <a href="#aBkChart" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6">
											                <div data-bs-toggle="tooltip" data-bs-placement="top" title="Group Sales - Booked">
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
						                <!--end::Card toolbar-->
					                </div>
					                <!--end::Card header-->

					                <!--begin::Card body-->
					                <div class="card-body pt-0 pb-0 px-0">
						                <div class="tab-content">
							                <div class="tab-pane fade show active" id="aRsvChart">
								                <!--begin::Chart-->
								                <div id="kt_GSRsv_barchart" class="card-rounded-bottom" style="height: 260px"></div>
								                <!--end::Chart-->
							                </div>
							                <div class="tab-pane fade show" id="aBkChart">
								                <!--begin::Chart-->
								                <div id="kt_Bksv_barchart" class="card-rounded-bottom" style="height: 260px"></div>
								                <!--end::Chart-->
							                </div>
						                </div>
					                </div>
					                <!--end::Card body-->
				                </div>
				                <!--end::Graph-->
			                </div>
                            <%-- end::group sales - reserved --%>

			                <%-- begin::group sales monthly--%>
			                <div class="col-lg-6">
				                <div class="card card-flush h-lg-100">

					                <div class="card-header mt-3">
						                <div class="card-title flex-column">
							                <h3 class="mb-1">Group Sales - Monthly</h3>
						                </div>
						                <div class="card-toolbar flex-row-fluid justify-content-end">
							                <div class="d-flex align-items-center">
								                <div class="d-flex flex-column w-150px me-3">
							                        <asp:DropDownList ID="ddlMonths" runat="server" onchange="UpdateChart();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
							                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
					                </div>

					                <div class="card-body pt-0 pb-0 px-2">
						                <!--begin::Wrapper-->
						                <div id="kt_grp_monthly_sls_barchart" style="height: 260px;" class=""></div><div id="kt_grp_monthly_sls_barchart_ddl" style="height: 260px" class="d-none"></div>
						                <!--end::Wrapper-->
					                </div>
				                </div>
			                </div>
			                <%-- begin::group sales monthly--%>

			                <%-- begin::seller's rank --%>
			                <div class="col-lg-12">
				                <!--begin::Summary-->
				                <div class="card card-flush h-lg-100">
					                <!--begin::Header-->
					                <div class="card-header mt-3">
						                <h3 class="card-title align-items-start flex-column">
							                <span id="spnRsvRank" runat="server" class="card-label fs-4 fw-bolder mb-1">Ranking - Reservation</span>
							                <span id="spnBkRank" runat="server" class="card-label fs-4 fw-bolder mb-1 d-none">Ranking - Booked</span>
						                </h3>
							                <div class="d-flex align-items-center position-relative">
							                <%-- begin::Reserved Search --%>
							                <div id="RsvSearch" runat="server" class="">
								                <%-- begin:: search --%>
									                <span class="svg-icon svg-icon-1 position-absolute ms-4 mt-3">
										                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										                </svg>
									                </span>
									                <!--end::Svg Icon-->
									                <input id="tbxSearchReservedRank" type="text" class="form-control form-control-solid w-250px ps-12 " placeholder="Search Record" />
								                <%-- end:: search --%>
							                </div>
							                <%-- end::Reserved Search --%>
							                <%-- end::Booked Search --%>
							                <div id="BkSearch" runat="server" class="d-none">
								                <%-- begin:: search --%>
									                <span class="svg-icon svg-icon-1 position-absolute ms-4 mt-3">
										                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										                </svg>
									                </span>
									                <!--end::Svg Icon-->
									                <input id="tbxSearchBookedRank" type="text" class="form-control form-control-solid w-250px ps-12 " placeholder="Search Record" />
								                <%-- end:: search --%>
							                </div>
							                <%-- end::Booked Search --%>
							                <%-- begin::Edit Nav --%>
							                <ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
									                <!--begin::Nav item-->
									                <li id="liRsvSls" onclick="toggleRsvRank(); return false;" class="nav-item mt-2 ml-5">
										                <a href="#aRsvSls" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6 active">
											                <div data-bs-toggle="tooltip" data-bs-placement="top" title="Ranking - Reservation">
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
									                <li id="liBkSls" onclick="toggleBkRank(); return false;" class="nav-item mt-2">
										                <a href="#aBkSls" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6">
											                <div data-bs-toggle="tooltip" data-bs-placement="top" title="Ranking - Booked">
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
					                <!--end::Header-->

					                <!--begin::Body-->
					                <div class="card-body pt-0 pb-0">
						                <div class="tab-content">
							                <div class="tab-pane fade show active" id="aRsvSls">
								                <!--begin::Gridview-->
								                <div style="overflow-x:auto; scrollbar-width: thin;">
									                <asp:GridView ID="gvRsvRank" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" >
									                <Columns>
										                <asp:TemplateField HeaderText="">
											                <ItemTemplate>
												                <div class="d-flex align-items-center w-100">
													                <asp:UpdatePanel ID="upnlRank" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-30px">
													                <ContentTemplate>
														                <asp:Label ID="lblRank" runat="server" CssClass="text-dark fw-bolder fs-4" Text='<%# Eval("Rank") %>'></asp:Label>
													                </ContentTemplate>
													                </asp:UpdatePanel>
												                </div>
											                </ItemTemplate>
											                <HeaderStyle CssClass="mw-5px min-w-30px" />
											                <ItemStyle CssClass="mw-5px min-w-30px" />
										                </asp:TemplateField>
										                <asp:TemplateField HeaderText="Sellers">
											                <ItemTemplate>
												                <div class="d-flex align-items-center w-100">
													                <div class="symbol symbol-30px overflow-hidden me-3"> 
														                <img alt="" src="<%# Eval("SlrImg") %>" />
													                </div>
													                <span onclick="ViewRsvDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
														                <span class="text-dark text-hover-primary fw-bolder fs-6 nowrap-auto"><%# Eval("Seller") %></span>
														                <span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Group") %></span>
													                </span>
												                </div>
											                </ItemTemplate>
											                <HeaderStyle CssClass="mw-5px min-w-500px" />
											                <ItemStyle CssClass="mw-5px min-w-500px" />
										                </asp:TemplateField>
										                <asp:TemplateField HeaderText="Total Sales">
											                <ItemTemplate>
												                <div class="d-flex align-items-center w-100">
													                <asp:UpdatePanel ID="upnlTotalSales" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
													                <ContentTemplate>
														                <asp:Label ID="lblTotalSales" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TotalSales") %>'></asp:Label>
													                </ContentTemplate>
													                </asp:UpdatePanel>
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
							                <div class="tab-pane fade show" id="aBkSls">
								                <!--begin::Gridview-->
								                <div style="overflow-x:auto; scrollbar-width: thin;">
									                <asp:GridView ID="gvBkRank" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" >
									                <Columns>
										                <asp:TemplateField HeaderText="">
											                <ItemTemplate>
												                <div class="d-flex align-items-center w-100">
													                <asp:UpdatePanel ID="upnlRank1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-30px">
													                <ContentTemplate>
														                <asp:Label ID="lblRank1" runat="server" CssClass="text-dark fw-bolder fs-4" Text='<%# Eval("Rank") %>'></asp:Label>
													                </ContentTemplate>
													                </asp:UpdatePanel>
												                </div>
											                </ItemTemplate>
											                <HeaderStyle CssClass="mw-5px min-w-30px" />
											                <ItemStyle CssClass="mw-5px min-w-30px" />
										                </asp:TemplateField>
										                <asp:TemplateField HeaderText="Sellers">
											                <ItemTemplate>
												                <div class="d-flex align-items-center w-100">
													                <div class="symbol symbol-30px overflow-hidden me-3"> 
														                <img alt="" src="<%# Eval("SlrImg") %>" />
													                </div>
													                <span onclick="ViewRsvDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
														                <span class="text-dark text-hover-primary fw-bolder fs-6 nowrap-auto"><%# Eval("Seller") %></span>
														                <span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Group") %></span>
													                </span>
												                </div>
											                </ItemTemplate>
											                <HeaderStyle CssClass="mw-5px min-w-500px" />
											                <ItemStyle CssClass="mw-5px min-w-500px" />
										                </asp:TemplateField>
										                <asp:TemplateField HeaderText="Total Sales">
											                <ItemTemplate>
												                <div class="d-flex align-items-center w-100">
													                <asp:UpdatePanel ID="upnlTotalSales1" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
													                <ContentTemplate>
														                <asp:Label ID="lblTotalSales1" runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TotalSales") %>'></asp:Label>
													                </ContentTemplate>
													                </asp:UpdatePanel>
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
                                    <%-- end::body --%>

				                </div>
				                <!--end::Summary-->
			                </div>
			                <%-- end::seller's rank --%>
                        </div>
                    </div>
                    
					<div class="tab-pane fade show" id="aRanking">
					    <asp:UpdatePanel ID="upnlQueSales" runat="server" UpdateMode="Conditional" class="row gy-3 g-sm-3">
					    <ContentTemplate>
			                <%--<div class="col-lg-12">
				                <div class="card card-flush h-lg-100">
					                <!--begin::Card header retyrn-->
					                <div class="card-header mt-3">
						                <!--begin::Card title-->
						                <div class="card-title flex-column">
							                <h3 id="h3" runat="server" class="mb-1">Sales Group</h3>
							                <div class="fs-6 fw-bold text-gray-400">Ranking of sales group in Quezon</div>
						                </div>
						                <!--end::Card title-->
                                    </div>
									<!--end::Card header-->

					                <!--begin::Card body-->
					                <div class="card-body pt-0 pb-0 px-0">
								        <!--begin::Chart-->
								        <div id="GrpSls_Que_barchart" class="card-rounded-bottom" style="height: 260px"></div>
								        <!--end::Chart-->
					                </div>
					                <!--end::Card body-->
                                </div>
                            </div>--%>
                            <%-- begin::producers board que --%>
			                <div class="col-lg-12">
				                <div class="card card-flush h-lg-100">
					                <!--begin::header-->
					                <div class="card-header mt-3">
						                <!--begin::Card title-->
						                <div class="card-title flex-column">
							                <span class="mb-1 fs-3 fw-bolder">Calmar Land <span id="CLDCTerritory" class="fs-3 fw-bolder">All Territory</span></span>
							                <div class="fs-6 fw-bold text-gray-400">Top producers board</div>
						                </div>
						                <!--end::Card title-->
						                <div class="card-toolbar flex-row-fluid justify-content-end">
							                <div class="d-flex align-items-center">
								                <div class="d-flex flex-column w-150px me-3">
							                        <asp:DropDownList ID="ddlTerritory" runat="server" onchange="UpdateTerritory();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
										                <asp:ListItem Value="All Territory">Select all territory</asp:ListItem>
										                <asp:ListItem Value="Quezon">Quezon</asp:ListItem>
										                <asp:ListItem Value="Laguna">Laguna</asp:ListItem>
										                <asp:ListItem Value="Batangas">Batangas</asp:ListItem>
							                        </asp:DropDownList>
                                                </div>
								                <div class="d-flex flex-column w-150px me-3">
							                        <asp:DropDownList ID="ddlQueYear" runat="server" onchange="UpdateSLQueYear();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
							                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!--end::Header-->

					                <!--begin::Body-->
					                <div class="card-body pt-0 pb-0">
								        <!--begin::Gridview-->
							            <asp:UpdatePanel ID="upnlQueOverall" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
							            <ContentTemplate>
											<div style="overflow-x:auto; scrollbar-width: thin;">
									        <asp:GridView ID="gvSalesOverall" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found">
											<EmptyDataTemplate>
												<div style="text-align: center;" class="text-muted fst-italic">
													No records found.
												</div>
											</EmptyDataTemplate>
									        <Columns>
										        <asp:TemplateField HeaderText="Month">
											        <ItemTemplate>
												        <div class="d-flex align-items-center w-100">
													        <asp:UpdatePanel ID="upnlTotalSales" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
													        <ContentTemplate>
														        <asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("SLMonth") %>'></asp:Label>
													        </ContentTemplate>
													        </asp:UpdatePanel>
												        </div>
											        </ItemTemplate>
											        <HeaderStyle CssClass="mw-5px min-w-150px" />
											        <ItemStyle CssClass="mw-5px min-w-150px" />
										        </asp:TemplateField>
										        <asp:TemplateField HeaderText="Top Sales Group">
											        <ItemTemplate>
												        <div class="d-flex align-items-center w-100">
													        <div class="symbol symbol-30px overflow-hidden me-3"> 
														        <img alt="" src="<%# Eval("SlrImg") %>" />
													        </div>
													        <span onclick="ViewRsvDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
														        <span class="text-dark text-hover-primary fw-bolder fs-6 nowrap-auto"><%# Eval("SLGroup") %></span>
														        <span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("TotalSales") %></span>
													        </span>
												        </div>
											        </ItemTemplate>
											        <HeaderStyle CssClass="mw-5px min-w-300px" />
											        <ItemStyle CssClass="mw-5px min-w-300px" />
										        </asp:TemplateField>
										        <asp:TemplateField HeaderText="Top Sales Manager">
											        <ItemTemplate>
												        <div class="d-flex align-items-center w-100">
													        <asp:UpdatePanel ID="upnlTotalSales" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
													        <ContentTemplate>
														        <%--<asp:Label runat="server" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("TotalSales") %>'></asp:Label>--%>
													        </ContentTemplate>
													        </asp:UpdatePanel>
												        </div>
											        </ItemTemplate>
											        <HeaderStyle CssClass="mw-5px min-w-200px" />
											        <ItemStyle CssClass="mw-5px min-w-200px" />
										        </asp:TemplateField>
									        </Columns>
									        </asp:GridView>
								        </div>
										</ContentTemplate>
										</asp:UpdatePanel>
								        <!--end::Gridview-->
                                    </div>
                                    <!--end::Body-->
                                </div>
                            </div>
                            <%-- end::producers board que--%>

                            <%-- begin::sales ranking --%>
			                <div class="col-lg-12">
				                <div class="card card-flush h-lg-100">
					                <!--begin::header-->
					                <div class="card-header mt-3">
						                <!--begin::Card title-->
						                <div class="card-title flex-column">
							                <h3 class="mb-1">Sales Ranking
							                </h3>
							                <div class="fs-6 fw-bold text-gray-400">Sales ranking based on selected category</div>
						                </div>
						                <!--end::Card title-->
						                <div class="card-toolbar flex-row-fluid justify-content-end">
							                <div class="d-flex align-items-center">
								                <div class="d-flex flex-column w-150px me-3">
                                                    <asp:TextBox ID="tbxSLDateFrom" onchange="DateChange()" AutoPostBack="True" runat="server" data-kt-repeater="datepicker" class="form-control form-control-sm" placeholder="Date From"></asp:TextBox>
                                                </div>
                                            </div>
							                <div class="d-flex align-items-center">
								                <div class="d-flex flex-column w-150px me-3">
                                                    <asp:TextBox ID="tbxSLDateTo" onchange="DateChange()" AutoPostBack="True" runat="server" data-kt-repeater="datepicker" class="form-control form-control-sm" placeholder="Date From"></asp:TextBox>
                                                </div>
                                            </div>
							                <div class="d-flex align-items-center">
								                <div class="d-flex flex-column w-150px me-3">
							                        <asp:DropDownList ID="ddlSLNewType" runat="server" onchange="UpdateSLNewTypeGroup();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
							                        </asp:DropDownList>
                                                </div>
                                            </div>
							                <div class="d-flex align-items-center">
								                <div class="d-flex flex-column w-150px me-3">
							                        <asp:DropDownList ID="ddlSLNewGroup" runat="server" onchange="UpdateSLNewTypeGroup();" data-kt-repeater="select2" class="form-control form-control-sm flatpickr-input">
							                        </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!--end::Header-->

					                <!--begin::Body-->
					                <div class="card-body pt-0 pb-0">
								        <!--begin::Gridview-->
							            <asp:UpdatePanel ID="upnlSLTypeGroupRank" runat="server" UpdateMode="Conditional" class="row g-xxl-9">
							            <ContentTemplate>
								            <div id="divTypeGroupRank" runat="server" class="" style="overflow-x:auto; scrollbar-width: thin;">
									            <asp:GridView ID="gvNewSLTypeGroupRank" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle" AutoGenerateColumns="False" >
									            <Columns>
										            <asp:TemplateField HeaderText="Rank">
											            <ItemTemplate>
												            <div class="d-flex align-items-center w-100">
													            <asp:UpdatePanel ID="upnlRank" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-30px">
													            <ContentTemplate>
														            <asp:Label ID="lblRank4" runat="server" CssClass="text-dark fw-bolder fs-2x" Text='<%# Eval("Rank") %>'></asp:Label>
													            </ContentTemplate>
													            </asp:UpdatePanel>
												            </div>
											            </ItemTemplate>
											            <HeaderStyle CssClass="mw-5px min-w-50px" />
											            <ItemStyle CssClass="mw-5px min-w-50px" />
										            </asp:TemplateField>
										            <asp:TemplateField HeaderText="Sellers">
											            <ItemTemplate>
												            <div class="d-flex align-items-center w-100">
													            <div class="symbol symbol-30px overflow-hidden me-3"> 
														            <img alt="" src="<%# Eval("SlrImg") %>" />
													            </div>
													            <span onclick="ViewRsvDetail(this)" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
														            <span class="text-dark text-hover-primary fw-bolder fs-6 nowrap-auto"><%# Eval("Seller") %></span>
														            <span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("SLGroup") %> | <%# Eval("SLType") %></span>
													            </span>
												            </div>
											            </ItemTemplate>
											            <HeaderStyle CssClass="mw-5px min-w-250px" />
											            <ItemStyle CssClass="mw-5px min-w-250px" />
										            </asp:TemplateField>
										            <asp:TemplateField HeaderText="Total Sales">
											            <ItemTemplate>
												            <div class="d-flex align-items-center w-100">
														        <asp:Label ID="lblTotalSales4" runat="server" CssClass="text-primary fw-bold fs-6" Text='<%# Eval("TotalSales") %>'></asp:Label>
												            </div>
											            </ItemTemplate>
											            <HeaderStyle CssClass="mw-5px min-w-150px" />
											            <ItemStyle CssClass="mw-5px min-w-150px" />
										            </asp:TemplateField>
									            </Columns>
									            </asp:GridView>
								            </div>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
								        <!--end::Gridview-->
					                </div>
                                    <%-- end::body --%>
                                </div>
                            </div>
							<%-- end::sales ranking --%>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
		</ContentTemplate>
		</asp:UpdatePanel>

        <%-- begin::modals --%>
			<%-- begin::group sales reserved modal --%>
			<div id="mdlGrpSlsRsv" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
					<div class="modal-content modal-rounded">
						<div class="modal-header">
							<h5 class="modal-title">Group Sales - Reserved</h5>
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
										<input id="tbxSearchGrpSlsRsv" type="text" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
									</div>
									<%-- end::search --%>	
								</div>

								<!--begin::Table | Gridview-->
								<div class="card-body py-3">
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<div class="table-responsive overflow-hidden min-h-300px" >
										<!--begin::Table-->
											<table id="gvDisplayGrpSlsRsv" class="table table-row-dashed tscroll table-row-gray-300 table-hover align-middle">
												<!--begin::Table head-->
												<thead>
													<tr>
														<th class="text-dark fw-bold fs-5 min-w-250px">Seller</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Group</th>
														<th class="text-dark fw-bold fs-5 min-w-250px">Buyer</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Project</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Unit</th>
														<th class="text-dark fw-bold fs-5 min-w-150px">TCP</th>
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
			<%-- end::group sales reserved modal --%>

			<%-- begin::group sales booked modal --%>
			<div id="mdlGrpSlsBk" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
					<div class="modal-content modal-rounded">
						<div class="modal-header">
							<h5 class="modal-title">Group Sales - Booked</h5>
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
										<input id="tbxSearchGrpSlsBk" type="text" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
									</div>
									<%-- end::search --%>	
								</div>

								<!--begin::Table | Gridview-->
								<div class="card-body py-3">
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<div class="table-responsive overflow-hidden min-h-300px" >
										<!--begin::Table-->
											<table id="gvDisplayGrpSlsBk" class="table table-row-dashed tscroll table-row-gray-300 table-hover align-middle">
												<!--begin::Table head-->
												<thead>
													<tr>
														<th class="text-dark fw-bold fs-5 min-w-250px">Seller</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Group</th>
														<th class="text-dark fw-bold fs-5 min-w-250px">Buyer</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Project</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Unit</th>
														<th class="text-dark fw-bold fs-5 min-w-150px">TCP</th>
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
			<%-- end::group sales booked modal --%>
        <%-- end::modals --%>

	</div>
    <%-- end::Post --%>

	<script type="text/javascript">
        //for bar-chart group sales - reserved
        var ltrlBarGroupSalesDataRsv = '<asp:Literal ID="ltrlBarGroupSalesDataRsv" runat="server" />'
        var ltrlBarGroupSalesNameRsv = '<asp:Literal ID="ltrlBarGroupSalesNameRsv" runat="server" />'
        //for bar-chart group sales - booked
        var ltrlBarGroupSalesDataBk = '<asp:Literal ID="ltrlBarGroupSalesDataBk" runat="server" />'
        var ltrlBarGroupSalesNameBk = '<asp:Literal ID="ltrlBarGroupSalesNameBk" runat="server" />'
        //for bar-chart group sales - quezon
        var ltrlBarGroupSalesDataQue = '<asp:Literal ID="ltrlBarGroupSalesDataQue" runat="server" />'
        var ltrlBarGroupSalesNameQue = '<asp:Literal ID="ltrlBarGroupSalesNameQue" runat="server" />'
        //pie chart - account status
        var ltrlBarGrpSlsRsv = '<asp:Literal ID="ltrlBarGrpSlsRsv" runat="server" />'
        var ltrlBarGrpSlsBk = '<asp:Literal ID="ltrlBarGrpSlsBk" runat="server" />'
        var ltrlBarGrpCgy = '<asp:Literal ID="ltrlBarGrpCgy" runat="server" />'

        //sales territory onchange
        function UpdateTerritory() {
            var Territory = $('#<%= ddlTerritory.ClientID %>').val()
            var text = document.getElementById('CLDCTerritory')
            text.textContent = Territory;
            __doPostBack('<%= upnlQueSales.ClientID %>', '');
        }

        //sales date oninput
        function DateChange() {
            var DateFrom = document.getElementById('<%= tbxSLDateFrom.ClientID %>').value;
            var DateTo = document.getElementById('<%= tbxSLDateTo.ClientID %>').value;
            __doPostBack('<%= upnlSLTypeGroupRank.ClientID %>', '');
        }

        //sales year onchange
        function UpdateSLQueYear() {
            var SLType = $('#<%= ddlQueYear.ClientID %>').val()
            __doPostBack('<%= upnlQueOverall.ClientID %>', '');
        }

        //seller typegroup onchange
        function UpdateSLNewTypeGroup() {
            var SLNewType = $('#<%= ddlSLNewType.ClientID %>').val()
            var SLNewGroup = $('#<%= ddlSLNewGroup.ClientID %>').val()
            __doPostBack('<%= upnlSLTypeGroupRank.ClientID %>', '');
        }

        //chart onchange
        function UpdateChart() {
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS060000',
                    'Type': 'View Group Sales Chart (Month)',
                    'selectedMonth': $('#<%= ddlMonths.ClientID %>').val()
                },
                success: function (response) {
                    changeChart(response);
                },
                error: function (error) {
                    // Handle error
                    console.log("Error:", error);
                }
            });
        }
        //monthly sales per group - dropdown change
        function changeChart(response) {
            var x = [];
            var y = [];

            var Data = response.pop();
            var Group = Data.Group.split(",");
            var Rsrv = Data.ReservationSales.split(",");

            jQuery(function ($) {

                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-info');

                var options = {
                    series: [{
                        name: 'Sales',
                        data: Rsrv,
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        stacked: false,
                        height: 260,
                        toolbar: {
                            show: false
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            barHeight: ['40%'],
                            columnWidth: ['50%'],
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
                        categories: Group,
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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });
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

                document.querySelector("#kt_grp_monthly_sls_barchart_ddl").innerHTML = "";
                document.getElementById("kt_grp_monthly_sls_barchart").classList.add('d-none');
                document.getElementById("kt_grp_monthly_sls_barchart_ddl").classList.remove('d-none');
                var chart = new ApexCharts(document.querySelector("#kt_grp_monthly_sls_barchart_ddl"), options);
                chart.render();
            });
        }

        //link button
        function toggleRsvChart() {
            $('#<%= h3RsvChart.ClientID %>').removeClass('d-none');
            $('#<%= h3BkChart.ClientID %>').addClass('d-none');
		}
        function toggleBkChart() {
            $('#<%= h3RsvChart.ClientID %>').addClass('d-none');
            $('#<%= h3BkChart.ClientID %>').removeClass('d-none');
        }

        //View reserved sales per group - modal
        function ViewGroupSalesRsv(RsvGrp) {
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS060000',
                    'Type': 'View Group Sales (RsvGrp)',
                    'RsvGrp': RsvGrp
                },
                success: function (response) {
                    DisplayGroupSalesRsv(response)
                },
                error: function (error) {
                    // Handle error
                    console.log("Error:", error);
                }
            });
        }
        function DisplayGroupSalesRsv(response) {
            //datatable
            var gvDisplayGrpSlsRsv = $("#gvDisplayGrpSlsRsv").DataTable({
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
                    { data: 'Group', class: "min-w-100px" },
                    { data: 'Buyer', class: "min-w-250px" },
                    { data: 'Project', class: "min-w-100px" },
                    { data: 'Unit', class: "min-w-100px" },
                    { data: 'TCP', class: "min-w-150px" },
                    { data: 'Status', class: "min-w-100px" }]
            });
            //datatable
            //search
            $('#tbxSearchGrpSlsRsv').on('keyup', function () {
                gvDisplayGrpSlsRsv.search(this.value).draw();
            });
            // Show the modal
            $('#mdlGrpSlsRsv').modal('show');
        }

        //View booked sales per group - modal
        function ViewGroupSalesBk(BkGrp) {
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS060000',
                    'Type': 'View Group Sales (BkGrp)',
                    'BkGrp': BkGrp
                },
                success: function (response) {
                    DisplayGroupSalesBk(response)
                },
                error: function (error) {
                    // Handle error
                    console.log("Error:", error);
                }
            });
        }
        function DisplayGroupSalesBk(response) {
            //datatable
            var gvDisplayGrpSlsBk = $("#gvDisplayGrpSlsBk").DataTable({
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
                    { data: 'Group', class: "min-w-100px" },
                    { data: 'Buyer', class: "min-w-250px" },
                    { data: 'Project', class: "min-w-100px" },
                    { data: 'Unit', class: "min-w-100px" },
                    { data: 'TCP', class: "min-w-150px" },
                    { data: 'Status', class: "min-w-100px" }]
            });
            //datatable
            //search
            $('#tbxSearchGrpSlsBk').on('keyup', function () {
                gvDisplayGrpSlsBk.search(this.value).draw();
            });
            // Show the modal
            $('#mdlGrpSlsBk').modal('show');
        }   

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $gvRsvRank = $('#ContentPlaceHolder1_gvRsvRank tbody tr');
            $('#tbxSearchReservedRank').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvRsvRank.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            var $gvBkRank = $('#ContentPlaceHolder1_gvBkRank tbody tr');
            $('#tbxSearchBookedRank').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvBkRank.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
        }
        //table search

        //link button
        function toggleRsvRank() {
            $('#<%= RsvSearch.ClientID %>').removeClass('d-none');
            $('#<%= BkSearch.ClientID %>').addClass('d-none'); 
            $('#<%= spnRsvRank.ClientID %>').removeClass('d-none');
            $('#<%= spnBkRank.ClientID %>').addClass('d-none'); 
		}
        function toggleBkRank() {
            $('#<%= RsvSearch.ClientID %>').addClass('d-none');
            $('#<%= BkSearch.ClientID %>').removeClass('d-none'); 
			$('#<%= spnRsvRank.ClientID %>').addClass('d-none');
            $('#<%= spnBkRank.ClientID %>').removeClass('d-none');
		}

        //page load script ------------------------------------------------------------------------------------------------------------------------
        function pageLoad(sender, args) { InitializeSettings(); }
        function InitializeSettings() {

            //combobox
            $('[data-kt-repeater="select2"]').select2();
            //combobox

            //date
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y"
            });
            //date

            //group sales bar-chart reserved ----------------------------------------------------------------------------------------------
            jQuery(function ($) {
                var element = document.getElementById("kt_GSRsv_barchart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                const ArrayValueDataRsv = ltrlBarGroupSalesDataRsv.split(",")
                const ArrayValueLabelRsv = ltrlBarGroupSalesNameRsv.split(",")

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Sales',
                        data: ArrayValueDataRsv,
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
                                var RsvGrp = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewGroupSalesRsv(RsvGrp);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            columnWidth: ['50%'],
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
                        categories: ArrayValueLabelRsv,

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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });  //+ val + " ₱"
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

            //group sales bar-chart booked ----------------------------------------------------------------------------------------------
            jQuery(function ($) {
                var element = document.getElementById("kt_Bksv_barchart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                const ArrayValueDataBk = ltrlBarGroupSalesDataBk.split(",")
                const ArrayValueLabelBk = ltrlBarGroupSalesNameBk.split(",")

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Sales',
                        data: ArrayValueDataBk,
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
                                var BkGrp = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewGroupSalesBk(BkGrp);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            columnWidth: ['50%'],
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
                        categories: ArrayValueLabelBk,

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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });  //+ val + " ₱"
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

            //group sales bar-chart quez ----------------------------------------------------------------------------------------------
            jQuery(function ($) {
                var element = document.getElementById("GrpSls_Que_barchart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                const ArrayValueDataQue = ltrlBarGroupSalesDataQue.split(",")
                const ArrayValueLabelQue = ltrlBarGroupSalesNameQue.split(",")

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Sales',
                        data: ArrayValueDataQue,
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
                                var BkGrp = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewGroupSalesBk(BkGrp);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            columnWidth: ['50%'],
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
                        categories: ArrayValueLabelQue,

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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });  //+ val + " ₱"
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

            //monthly group sales - bar chart
            jQuery(function ($) {
                var element = document.getElementById("kt_grp_monthly_sls_barchart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-info');

                const ArrayValueGrpRsv = ltrlBarGrpSlsRsv.split(",")
               // const ArrayValueGrpBk = ltrlBarGrpSlsBk.split(",")
                const ArrayValueCgy = ltrlBarGrpCgy.split(",")

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Sales',
                        data: ArrayValueGrpRsv,
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        stacked: false,
                        height: 260,
                        toolbar: {
                            show: false
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: true,
                            barHeight: ['40%'],
                            columnWidth: ['50%'],
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
                        categories: ArrayValueCgy,
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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });
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

                window.chart = new ApexCharts(element, options);
                window.chart.render();
            });
        }

    </script>

</asp:Content>
