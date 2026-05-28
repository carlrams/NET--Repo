<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB280000.aspx.vb" Inherits="NET.DSB280000" MaintainScrollPositionOnPostback = "true" enableEventValidation="false"%>
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
	.text-info02 {
		color: #7239EA !important;
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
	[v-cloak] {
		display: none;
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
						<li class="breadcrumb-item text-white">Purchasing Dashboard</li>
					</ul>
				</div>
				<div class="d-flex align-items-center py-3 py-md-1">
					<button type="button" class="btn btn-sm btn-icon btn-secondary btn-active-light-secondary m-1" onclick="fn00Filter(); return false;" title="Filter">
						<i class="las la-filter fs-3"></i>
					</button>
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
		
        <div id="div01Parent" class="row g-5 g-xl-8">
			
			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Total PO's</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-info">
										<img src="assets/media/svg/apps/DSB280100.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01Posted" class="text-dark fw-bold fs-1">0</h1>
							<span id="spn01Title" class="text-muted fw-bold fs-7 flex-grow-1">as of </span>
                            <br />
							<span id="spn0102Title" class="text-info fw-bolder fst-italic fs-7 flex-grow-1">prev. Month</span>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Total Value</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-success">
										<img src="assets/media/svg/apps/DSB280200.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01TotalValue" class="text-dark fw-bold fs-1">0</h1>
							<span id="spn02Title" class="text-muted fw-bold fs-7 flex-grow-1">as of </span>
                            <br />
							<span id="spn0201Title" class="text-success fw-bold fs-7 fst-italic flex-grow-1">prev. Month</span>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-5 mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Posted</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-warning">
										<img src="assets/media/svg/apps/DSB280300.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01InProgress" class="text-dark fw-bold fs-1">0</h1>
							<span class="text-muted fw-bold fs-7 flex-grow-1">posted PO's w/o Fuel & Permits</span>
                            <br />
							<span id="spn0301Title" class="text-warning fw-bold fs-7 fst-italic flex-grow-1">prev. Month</span>
						</div>
					</div>
				</div>
			</div>

			<div class="col-xl-3">
				<div class="card card-xl-stretch mb-5 mb-xl-8">
					<div class="card-body d-flex flex-column pb-5 pb-lg-8">
						<div class="flex-grow-1">
							<div class="d-flex align-items-center pe-2 mb-5">
								<span class="text-muted fw-bold fs-5 flex-grow-1">Completed</span>
								<div class="symbol symbol-50px">
									<span class="symbol-label bg-info2">
										<img src="assets/media/svg/apps/DSB280400.svg" class="h-50 align-self-center" alt="" />
									</span>
								</div>
							</div>
							<h1 id="h01Completed" class="text-dark fw-bold fs-1">0</h1>
							<span class="text-muted fw-bold fs-7 flex-grow-1">delivered PO's</span>
                            <br />
							<span id="spn0401Title" class="text-info02 fw-bold fs-7 fst-italic flex-grow-1">prev. Month</span>
						</div>
					</div>
				</div>
			</div>

        </div>

        <div class="row g-5">
			<div id="div01Title" class="card-title fs-3 fw-bolder pt-1">Monthly Report</div>
			<div class="col-xl-6">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bold text-dark">Procurement Value</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Commodity</span>
						</h3>
					</div>
					<div class="card-body pt-5">
						<div id="kt_bar_graph_01" style="height: 350px"></div>
					</div>
				</div>
			</div>
			<div class="col-xl-6">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bold text-dark">Procurement Item</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Commodity</span>
						</h3>
					</div>
					<div class="card-body pt-5">
						<div id="kt_donut_graph_002" style="height: 350px"></div>
					</div>
				</div>
			</div>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bold text-dark">Suppliers Performance</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Evaluation</span>
						</h3>
					</div>
					<div class="card-body pt-5">
						<div id="kt_bar_graph_03" style="height: 350px"></div>
					</div>
				</div>
			</div>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Purchase Order</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Manage purchase transaction</span>
						</h3>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
							<div class="d-flex align-items-center ms-5">
								<div class="d-flex flex-stack">
									<div class="d-none"></div>
									<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options">
										<i class="las la-filter fs-3"></i>
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
						<div id="table01Record" style="height: 100vh; border: none;"></div>
					</div>
				</div>
			</div>
			<div id="div02Title" class="card-title fs-3 fw-bolder pt-1">Monthly Commodity</div>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Commodity</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Purchase per Commodity</span>
						</h3>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
							<div class="d-flex align-items-center ms-5">
								<div class="d-flex flex-stack">
									<div class="d-none"></div>
									<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" onclick="fn02Export(); return false;">
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
									<input id="tbx02Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid02Api.setGridOption('quickFilterText', document.getElementById('tbx02Find').value);" />
								</div>
							</div>
						</div>
					</div>
					<div class="card-body py-3">
						<div id="table02Record" style="height: 80vh; border: none;"></div>
					</div>
				</div>
			</div>
			<div id="div03Title" class="card-title fs-3 fw-bolder pt-1">Summary of Commodities</div>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Commodity</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Year-to-Date Purchase</span>
						</h3>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
							<div class="d-flex align-items-center ms-5">
								<div class="d-flex flex-stack">
									<div class="d-none"></div>
									<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" onclick="fn03Export(); return false;">
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
									<input id="tbx03Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid03Api.setGridOption('quickFilterText', document.getElementById('tbx03Find').value);" />
								</div>
							</div>
						</div>
					</div>
					<div class="card-body py-3">
						<div id="table03Record" style="height: 100vh; border: none;"></div>
					</div>
				</div>
			</div>
			<div id="div04Title" class="card-title fs-3 fw-bolder pt-1">Purchases from Manufacturer & Dealer</div>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Top Manufacturer & Dealer</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Year-to-Date Purchase</span>
						</h3>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
							<div class="d-flex align-items-center ms-5">
								<div class="d-flex flex-stack">
									<div class="d-none"></div>
									<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" onclick="fn04Export(); return false;">
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
						<div id="table04Record" style="height: 100vh; border: none;"></div>
					</div>
				</div>
			</div>
			<div id="div05Title" class="card-title fs-3 fw-bolder pt-1">Purchase Order</div>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-xl-8 border border-gray-300">
					<div class="card-header pt-5">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Overall Item</span>
							<span class="text-gray-400 pt-2 fw-bold fs-7">Year-to-Date Purchase</span>
						</h3>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
							<div class="d-flex align-items-center ms-5">
								<div class="d-flex flex-stack">
									<div class="d-none"></div>
									<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" onclick="fn05Export(); return false;">
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
									<input id="tbx05Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid05Api.setGridOption('quickFilterText', document.getElementById('tbx05Find').value);" />
								</div>
							</div>
						</div>
					</div>
					<div class="card-body py-3">
						<div id="table05Record" style="height: 100vh; border: none;"></div>
					</div>
				</div>
			</div>
        </div>
		
		<div id="mdl00Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Order - Filter record</h5>
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
                        <select id="ddl00Month" data-kt-repeater="select2" data-dropdown-parent="#mdl00Filter" class="form-select form-select-sm min-h-38px mb-2 border border-danger">
                            <option value="">Select Month</option>
                        </select>
                        <select id="ddl00Year" data-kt-repeater="select2" data-dropdown-parent="#mdl00Filter" class="form-select form-select-sm min-h-38px mb-2 border border-danger">
                            <option value="">Select Year</option>
                        </select>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn00Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
						<h5 class="modal-title">Purchase Order - Filter record</h5>
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
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
    </div>
	
	<script src="https://unpkg.com/vue@3/dist/vue.global.prod.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/apexcharts/3.52.0/apexcharts.min.js"></script>
	<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/countup.js@latest/dist/countUp.umd.js"></script>
    <script type="text/javascript" src="Assets/js/DSB/DSB280000.js"></script>
    <script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>
	
</asp:Content>
