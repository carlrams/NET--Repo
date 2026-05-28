<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB240000.aspx.vb" Inherits="NET.DSB240000" MaintainScrollPositionOnPostback = "true" enableEventValidation="false"%>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <style>
	.progress-bar {
		transition: width 0.8s ease-in-out;
	}
	.highlight-cell {
		background-color: #fff3cd;
		font-weight: bold;
	}
	.hide-zero .ag-cell-value {
		visibility: hidden;
	}
	.badge-light-info2 {
		color: #7239EA;
		background-color: #F8F5FF;
	}
	.bg-info2 {
		background-color: #7239EA !important;
		--bg-color: 0, 158, 247 !important;
	}
	.svg-icon.svg-icon-info2 {
    color: #7239EA;
	}
	.border-info2 {
	  border-color: #7239EA !important;
	}
	 .btn-check:checked + .btn.btn-active-secondary, .btn-check:active + .btn.btn-active-secondary, .btn.btn-active-secondary:focus:not(.btn-active), .btn.btn-active-secondary:hover:not(.btn-active), .btn.btn-active-secondary:active:not(.btn-active), .btn.btn-active-secondary.active, .btn.btn-active-secondary.show, .show > .btn.btn-active-secondary {
		color: #FFFFFF;
        border-color: #3F4254;
        background-color: #3F4254 !important;
 }

     .btn-check:checked + .btn.btn-active-secondary i,
     .btn-check:checked + .btn.btn-active-secondary .svg-icon, .btn-check:active + .btn.btn-active-secondary i,
     .btn-check:active + .btn.btn-active-secondary .svg-icon, .btn.btn-active-secondary:focus:not(.btn-active) i,
     .btn.btn-active-secondary:focus:not(.btn-active) .svg-icon, .btn.btn-active-secondary:hover:not(.btn-active) i,
     .btn.btn-active-secondary:hover:not(.btn-active) .svg-icon, .btn.btn-active-secondary:active:not(.btn-active) i,
     .btn.btn-active-secondary:active:not(.btn-active) .svg-icon, .btn.btn-active-secondary.active i,
     .btn.btn-active-secondary.active .svg-icon, .btn.btn-active-secondary.show i,
     .btn.btn-active-secondary.show .svg-icon, .show > .btn.btn-active-secondary i,
     .show > .btn.btn-active-secondary .svg-icon {
         color: #FFFFFF;
     }

     .btn-check:checked + .btn.btn-active-secondary.dropdown-toggle:after, .btn-check:active + .btn.btn-active-secondary.dropdown-toggle:after, .btn.btn-active-secondary:focus:not(.btn-active).dropdown-toggle:after, .btn.btn-active-secondary:hover:not(.btn-active).dropdown-toggle:after, .btn.btn-active-secondary:active:not(.btn-active).dropdown-toggle:after, .btn.btn-active-secondary.active.dropdown-toggle:after, .btn.btn-active-secondary.show.dropdown-toggle:after, .show > .btn.btn-active-secondary.dropdown-toggle:after {
         color: #FFFFFF;
     }
    </style>

    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Supply Chain Management</li>
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<li class="breadcrumb-item text-white">Warehouse Dashboard</li>
					</ul>
				</div>
				<div class="d-flex align-items-center py-3 py-md-1">
					<i class="las la-refresh fs-2"></i>
					<a href="#" class="btn btn-sm btn-info fw-bolder min-w-100px" onclick="fn01Refresh(); return false;">
						<span class="svg-icon svg-icon-primary svg-icon-1x">
							<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
								<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
									<rect x="0" y="0" width="24" height="24"/>
									<path d="M8.43296491,7.17429118 L9.40782327,7.85689436 C9.49616631,7.91875282 9.56214077,8.00751728 9.5959027,8.10994332 C9.68235021,8.37220548 9.53982427,8.65489052 9.27756211,8.74133803 L5.89079566,9.85769242 C5.84469033,9.87288977 5.79661753,9.8812917 5.74809064,9.88263369 C5.4720538,9.8902674 5.24209339,9.67268366 5.23445968,9.39664682 L5.13610134,5.83998177 C5.13313425,5.73269078 5.16477113,5.62729274 5.22633424,5.53937151 C5.384723,5.31316892 5.69649589,5.25819495 5.92269848,5.4165837 L6.72910242,5.98123382 C8.16546398,4.72182424 10.0239806,4 12,4 C16.418278,4 20,7.581722 20,12 C20,16.418278 16.418278,20 12,20 C7.581722,20 4,16.418278 4,12 L6,12 C6,15.3137085 8.6862915,18 12,18 C15.3137085,18 18,15.3137085 18,12 C18,8.6862915 15.3137085,6 12,6 C10.6885336,6 9.44767246,6.42282109 8.43296491,7.17429118 Z" fill="currentColor" fill-rule="nonzero"/>
								</g>
							</svg>
						</span>
						Refresh</a>
				</div>
			</div>
		</div>
		
		<div class="row g-5 g-xl-8">

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Posted Materials</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-success">
										<img src="assets/media/svg/apps/DSB240100.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01Delivered" class="text-dark fw-bold fs-1">0</h1>
							<span id="spn01Overall" class="text-muted fw-bold fs-7 flex-grow-1"></span>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Pending Requests</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-info">
										<img src="assets/media/svg/apps/DSB240200.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01Pending" class="text-dark fw-bold fs-1">0</h1>
							<span class="text-muted fw-bold fs-7 flex-grow-1">Awaiting section</span>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-5 mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Low Stock Items</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-warning">
										<img src="assets/media/svg/apps/DSB240300.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01LowStock" class="text-dark fw-bold fs-1">0</h1>
							<span class="text-muted fw-bold fs-7 flex-grow-1">Need attention</span>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-5 mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Total Stock Materials</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-info2">
										<img src="assets/media/svg/apps/DSB240400.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01TotalStock" class="text-dark fw-bold fs-1">0</h1>
							<span class="text-muted fw-bold fs-7 flex-grow-1">Across all warehouses</span>
						</div>
					</div>
				</div>
			</div>

		</div>
		
        <div class="tab-content">

            <div class="row g-5">
				<div class="card-title fs-3 fw-bolder pt-1">Issuance Report</div>
				<div class="col-xl-4">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Issuance Volume Over Time</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Consumables over time</span>
							</h3>
						</div>
						<div class="card-body pt-5">
							<div id="kt_volume_graph_001" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-4">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Issuance By Warehouse</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Posted record</span>
							</h3>
						</div>
						<div class="card-body pt-5">
							<div id="kt_stack_graph_002" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-4">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Quantity by Item (Top 10)</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Consumables record</span>
							</h3>
						</div>
						<div class="card-body pt-5">
							<div id="kt_bar_graph_003" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="card-title fs-3 fw-bolder pt-1">Movement Flow</div>
				<div class="col-xl-6">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Status Distribution</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Purchase request</span>
							</h3>
						</div>
						<div class="card-body pt-5">
							<div id="kt_donut_graph_004" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-6">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Total per Stage</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Purchase request</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" onclick="fn0001Filter();return false;">
											<i class="las la-filter fs-3"></i>
										</button>
									</div>
								</div>
							</div>
						</div>
						<div class="card-body pt-5">
							<div id="kt_bar_graph_005" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Purchase Request & Status Tracking</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">For P.O.</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
								<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<div class="d-none"></div>
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options">
											<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
											<i class="las la-filter fs-3"></i>
											<!--end::Svg Icon-->
										</button>
										<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-2" data-kt-menu="true">
											<div class="menu-item px-3">
												<a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn01Filter();return false;">Filter</a>
												<a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn01Export(); return false;">Export as Excel</a>
											</div>
										</div>
									</div>
								</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid01Api.setGridOption('quickFilterText', document.getElementById('tbx01Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table01Record" class="ag-theme-alpine" style="height: 500px; border: none;"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Purchase Request & Status Tracking</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">For S.R.</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
									<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<div id="div01ExportButton" class="d-none"></div>
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options">
											<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
											<i class="las la-filter fs-3"></i>
											<!--end::Svg Icon-->
										</button>
										<div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-2" data-kt-menu="true">
											<div class="menu-item px-3">
												<a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn02Filter();return false;">Filter</a>
												<a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn02Export(); return false;">Export as Excel</a>
											</div>
										</div>
									</div>
								</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx02Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid02Api.setGridOption('quickFilterText', document.getElementById('tbx02Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table02Record" style="height: 500px; border: none;"></div>
						</div>
					</div>
				</div>
				<div class="card-title fs-3 fw-bolder">Warehouse Inventory</div>
				<div class="col-xl-6">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Stock Comparison by Warehouse</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Available stock materials</span>
							</h3>
						</div>
						<div class="card-body pt-5">
							<div id="kt_bar_graph_006" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-6">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bold text-dark">Stock by Category</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Available per classification</span>
							</h3>
						</div>
						<div class="card-body pt-5">
							<div id="kt_donut_graph_007" style="height: 350px"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Inventory Stock per Warehouse</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Available stock materials</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx03Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid03Api.setGridOption('quickFilterText', document.getElementById('tbx03Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table03Record" class="ag-theme-quartz" style="height: 500px; border: none;"></div>
						</div>
					</div>
				</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Actual Issuance Usage</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Available stock materials</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
										
								<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<div class="d-none"></div>
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" title="Export as CSV" onclick="fn04Export(); return false;">
											<i class="las la-file-csv fs-3"></i>
										</button>
									</div>
								</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx04Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid04Api.setGridOption('quickFilterText', document.getElementById('tbx04Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table04Record" class="ag-theme-quartz" style="height: 500px; border: none;"></div>
						</div>
					</div>
				</div>
				<div class="card-title fs-3 fw-bolder">Incoming Stock</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Upcoming New Balances (Incoming Stock)</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">On-going purchase order</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
								<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<div class="d-none"></div>
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options">
											<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
											<i class="las la-filter fs-3"></i>
											<!--end::Svg Icon-->
										</button>
										<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-2" data-kt-menu="true">
											<div class="menu-item px-3">
												<a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn05Filter();return false;">Filter</a>
												<a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn05Export(); return false;">Export as Excel</a>
											</div>
										</div>
									</div>
								</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx05Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid05Api.setGridOption('quickFilterText', document.getElementById('tbx05Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table05Record" style="height: 150vh; border: none;"></div>
						</div>
					</div>
				</div>
				<div class="card-title fs-3 fw-bolder">Projected BOQ</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="svg-icon svg-icon-1 svg-icon-gray-500 me-1">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<path d="M19.0759 3H4.72777C3.95892 3 3.47768 3.83148 3.86067 4.49814L8.56967 12.6949C9.17923 13.7559 9.5 14.9582 9.5 16.1819V19.5072C9.5 20.2189 10.2223 20.7028 10.8805 20.432L13.8805 19.1977C14.2553 19.0435 14.5 18.6783 14.5 18.273V13.8372C14.5 12.8089 14.8171 11.8056 15.408 10.964L19.8943 4.57465C20.3596 3.912 19.8856 3 19.0759 3Z" fill="currentColor" />
									</svg>
                                    <span class="fs-6 text-dark">Filters</span>
								</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
									<div class="d-flex align-items-center ms-5">
										<div class="d-flex flex-stack">
											<button class="btn btn-sm btn-info fw-bolder min-w-100px m-1" onclick="fn06Filter_Ok(this);return false;">
												<span class="indicator-label">
													Filter
												</span>
												<span class="indicator-progress">
													Loading
												</span>
											</button>
											<button class="btn btn-sm btn-secondary fw-bolder min-w-100px m-1" onclick="fn06Clear_Ok(this);return false;">
												<span class="indicator-label">
													Clear
												</span>
												<span class="indicator-progress">
													Loading
												</span>
											</button>
										</div>
									</div>
								</div>
							</div>
						</div>
                        <div class="card-body">
                            <div class="row mb-2">
                                <div class="col-sm-12 col-md-12 col-lg-3 mb-2">
                                    <div id="div06Category" class="border border-radius-047rem border-danger">
										<select id="ddl06Category" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border-0" onchange="ddl06Category_onchange(this);">
											<option value="">Category</option>
										</select>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-3 mb-2">
                                    <div id="div06Estimate" class="border border-radius-047rem">
										<select id="ddl06Estimate" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border-0" onchange="ddl06Estimate_onchange(this);" disabled="disabled">
											<option value="">Estimate</option>
										</select>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-3 mb-2">
                                    <div id="div06Project" class="border border-radius-047rem">
										<select id="ddl06Project" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border-0" disabled="disabled">
											<option value="">Project</option>
										</select>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-3 mb-2">
                                    <div id="div06Warehouse" class="border border-radius-047rem">
										<select id="ddl06Warehouse" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border-0">
											<option value="">Warehouse</option>
										</select>
                                    </div>
                                </div>
                            </div>
                        </div>
					</div>
				</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Estimated New Balances (BOQ)</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">Posted BOQ</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
								<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<div class="d-none"></div>
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" title="Export" onclick="fn06Export(); return false;">
											<i class="las la-file-csv fs-3"></i>
										</button>
									</div>
								</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx06Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid06Api.setGridOption('quickFilterText', document.getElementById('tbx06Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table06Record" style="height: 100vh; border: none;"></div>
						</div>
					</div>
				</div>
				<div class="card-title fs-3 fw-bolder">Projected P.R</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="svg-icon svg-icon-1 svg-icon-gray-500 me-1">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<path d="M19.0759 3H4.72777C3.95892 3 3.47768 3.83148 3.86067 4.49814L8.56967 12.6949C9.17923 13.7559 9.5 14.9582 9.5 16.1819V19.5072C9.5 20.2189 10.2223 20.7028 10.8805 20.432L13.8805 19.1977C14.2553 19.0435 14.5 18.6783 14.5 18.273V13.8372C14.5 12.8089 14.8171 11.8056 15.408 10.964L19.8943 4.57465C20.3596 3.912 19.8856 3 19.0759 3Z" fill="currentColor" />
									</svg>
                                    <span class="fs-6 text-dark">Filters</span>
								</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
									<div class="d-flex align-items-center ms-5">
										<div class="d-flex flex-stack">
											<button class="btn btn-sm btn-info fw-bolder min-w-100px m-1" onclick="fn07Filter_Ok(this);return false;">
												<span class="indicator-label">
													Filter
												</span>
												<span class="indicator-progress">
													Loading
												</span>
											</button>
											<button class="btn btn-sm btn-secondary fw-bolder min-w-100px m-1" onclick="fn07Clear_Ok(this);return false;">
												<span class="indicator-label">
													Clear
												</span>
												<span class="indicator-progress">
													Loading
												</span>
											</button>
										</div>
									</div>
								</div>
							</div>
						</div>
                        <div class="card-body">
                            <div class="row mb-2">
                                <div class="col-sm-12 col-md-12 col-lg-4 mb-2">
                                    <div id="div07Category" class="border border-radius-047rem border-danger">
										<select id="ddl07Category" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border-0" onchange="ddl07Category_onchange(this);">
											<option value="">Category</option>
										</select>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-4 mb-2">
                                    <div id="div07Project" class="border border-radius-047rem">
										<select id="ddl07Project" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px" disabled="disabled">
											<option value="">Project</option>
										</select>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-4 mb-2">
                                    <div id="div07Warehouse" class="border border-radius-047rem">
										<select id="ddl07Warehouse" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border-0">
											<option value="">Warehouse</option>
										</select>
                                    </div>
                                </div>
                            </div>
                        </div>
					</div>
				</div>
				<div class="col-xl-12">
					<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
						<div class="card-header pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder fs-3 mb-1">Upcoming New Balances (PR)</span>
								<span class="text-gray-400 pt-2 fw-bold fs-7">On-going purchase request</span>
							</h3>
							<div class="card-toolbar">
								<div class="d-flex flex-stack">
								<div class="d-flex align-items-center ms-5">
									<div class="d-flex flex-stack">
										<div class="d-none"></div>
										<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" title="Export" onclick="fn07Export(); return false;">
											<i class="las la-file-csv fs-3"></i>
										</button>
									</div>
								</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
													transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path
													d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
													fill="currentColor" />
											</svg>
										</span>
										<input id="tbx07Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid07Api.setGridOption('quickFilterText', document.getElementById('tbx07Find').value);" />
									</div>
								</div>
							</div>
						</div>
						<div class="card-body py-3">
							<div id="table07Record" style="height: 100vh; border: none;"></div>
						</div>
					</div>
				</div>
            </div>

        </div>
		
		<div id="mdl0001Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Issuance - Filter record</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <input id="tbx0001DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                        <input id="tbx0001DateTo" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0001Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl01Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Issuance - Filter record</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <input id="tbx01DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                        <input id="tbx01DateTo" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn01Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl0102Record" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Request - Transaction</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0102Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid0101Api.setGridOption('quickFilterText', document.getElementById('tbx0102Find').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0102Record" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl02Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Issuance - Filter record</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <input id="tbx02DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                        <input id="tbx02DateTo" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn02Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl0201Record" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Request - Transaction</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0201Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid0201Api.setGridOption('quickFilterText', document.getElementById('tbx0201Find').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0201Record" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl0201Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Issuance - Filter record</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <select id="ddl0201Status" data-kt-repeater="select2" data-dropdown-parent="#mdl0201Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Status</option>
                            <option value="Delivered">Delivered</option>
                            <option value="Partial">Partial</option>
                            <option value="Pending">Pending</option>
                            <option value="For Approval">For Approval</option>
                        </select>
                        <select id="ddl0201FormStatus" data-kt-repeater="select2" data-dropdown-parent="#mdl0201Filter" class="form-select form-select-sm min-h-38px mb-2" onchange="ddl0201FormStatus_onchange(this);">
                            <option value="">Form Status</option>
                        </select>
                        <input id="tbx0201DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" placeholder="Date" data-kt-repeater="datepicker" maxlength="20" readonly />
                        <input id="tbx0201DateTo" type="text" class="form-control form-control-sm border border-danger mb-2" placeholder="Date" data-kt-repeater="datepicker" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0201Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		
		<div id="mdl03Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Issuance - Filter record</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <input id="tbx03DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                        <input id="tbx03DateTo" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0301Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl0301Record" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Request - Transaction</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0301Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid0301Api.setGridOption('quickFilterText', document.getElementById('tbx0301Find').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0301Record" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl05Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Issuance - Filter record</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <select id="ddl05Warehouse" data-kt-repeater="select2" data-dropdown-parent="#mdl05Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Warehouse</option>
                        </select>
                        <select id="ddl05Vendor" data-kt-repeater="select2" data-dropdown-parent="#mdl05Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Vendor</option>
                        </select>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn05Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

    </div>
	
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/apexcharts/3.52.0/apexcharts.min.js"></script>
	<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/countup.js@latest/dist/countUp.umd.js"></script>
    <script type="text/javascript" src="Assets/js/DSB/DSB240000.js"></script>
    <script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
