<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="PDD090100.aspx.vb" Inherits="NET.PDD090100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
		<!--begin::breadcrumb bar-->
		<div class="toolbar py-5">
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Merge Lots</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<!--end::breadcrumb bar-->
		
		<!--begin::title-->
		<div class="card card-flush">
			<!--begin::title-->
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/PDD090000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn0101Title">-</span></h2>
						<div class="text-muted fw-bolder">
							<span id="spn0101Status">-</span>
						</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--begin::title-->
			<div class="card-body pt-3 pb-0">
				<div class="d-flex flex-stack">
					<!--begin::Navs-->
					<div class="d-flex overflow-auto">
						<ul id="ul0101Nav" class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
							<!--begin::Nav item-->
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary active" title="Overview" data-bs-toggle="tab" href="#tab0101Overview"><i class="las la-file-alt fs-3x"></i></a>
							</li>
							<!--end::Nav item-->
						</ul>
					</div>
					<!--begin::Navs-->
				</div>
			</div>
			<!--begin::Content-->
			<div class="card" >
				<div class="tab-content" >
					<div class="tab-pane fade show active" id="tab0101Overview">
						<!--begin::Menu Content-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Overview</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex flex-wrap">
									<button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0101Add();return false;"><i class="las la-plus fs-2"></i></button>
								</div>
                                <div class="card-toolbar">
                                    <div class="d-flex flex-stack">
                                        <!--begin::Search-->
                                        <div class="position-relative me-2">
                                            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                                </svg>
                                            </span>
                                            <!--end::Svg Icon-->
                                            <input id="tbx0101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
                            </div>
                            <!--end::Card header-->
							<!--begin::Files-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0101Record" class="table-loading-message">
										Loading...
									</div>
									<table id="table0101Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					                    <thead>
						                    <tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-100px mw-100px fw-bold border-end">Phase</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Block</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Lot</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Lots</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Acct. No</th>
												<th class="min-w-250px w-100 fw-bold border-end">Acct. Name</th>
						                    </tr>
					                    </thead>
										<tbody>
						
										</tbody>
									</table>
								</div>
							</div>
							<!--end::Files-->
						</div>
						<!--end::particular-->
						</div>
						<!--end::Menu Content-->

						<!--begin::attachment-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Attachment</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
                                <div class="d-flex align-items-center">
				                    <button id="btn0201Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="return false;"><i class="las la-upload fs-2"></i></button>
                                </div>
                                <div class="card-toolbar">
                                    <div class="d-flex flex-stack">
                                        <!--begin::Search-->
                                        <div class="position-relative me-2">
                                            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                                </svg>
                                            </span>
                                            <!--end::Svg Icon-->
                                            <input id="tbx0201FindAttachment" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div class="card-body table-loading table-responsive">
								<div id="div0201LoaderAttachment" class="table-loading-message">
									Loading...
								</div>
								<table id="table0201Attachment" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
									<thead>
										<tr class="fw-bold fs-7 text-gray-800">
											<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
											<th class="min-w-60px mw-60px fw-bold border-end">Type</th>
											<th class="min-w-200px w-100 fw-bold">Name</th>
											<th class="min-w-200px mw-200px fw-bold">By</th>
											<th class="min-w-200px mw-200px fw-bold">Date</th>
										</tr>
									</thead>
									<tbody>

									</tbody>
								</table>
							</div>
							<!--end::Dtl-->
						</div>
						<!--begin::attachment-->
                        
						<!--begin::notes-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Notes</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex align-items-center">
									<button id="btn0301Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0301Add();return false;"><i class="las la-comment fs-2"></i></button>
                                </div>
                                <div class="card-toolbar">
                                    <div class="d-flex flex-stack">
                                        <!--begin::Search-->
                                        <div class="position-relative me-2">
				                            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
				                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
					                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
						                            <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
						                            <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
					                            </svg>
				                            </span>
				                            <!--end::Svg Icon-->
				                            <input id="tbx0301FindNotes" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0301LoaderNotes" class="table-loading-message">
										Loading...
									</div>
									<table id="table0301Notes" class="table gy-2 gs-2 w-100 align-middle">
										<thead style="display:none">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-100px w-100">Notes</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
								</div>
							</div>
							<!--end::Dtl-->
						</div>
						<!--end::notes-->

					</div>
			</div>
		</div>
		<!--end::title-->
        
		<!--begin::Modal Add record -->
		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-600px modal-dialog-scrollable">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Merge Lots  - Add Lots</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <!--begin::Search-->
                                <div class="position-relative me-1">
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
				                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
					                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
					                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
				                        </svg>
                                    </span>
                                    <!--end::Svg Icon-->
                                    <input id="tbx0102Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
                                </div>
                            </div>
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
                        <!--begin::Files-->
                        <div class="table-loading">
                            <div id="div0102Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0102Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Phase</th>
										<th class="min-w-100px mw-100px fw-bold border-end">Block</th>
										<th class="min-w-100px mw-100px fw-bold border-end">Lot</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Add record -->
		<div id="mdl0103Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-600px modal-dialog-scrollable">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Merge Lots  - Edit Lots</h5>
                        <div class="d-flex align-items-center">
                            <button id="btn0104Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0104Add(this);return false;">
						        <span class="indicator-label">
							        <i class="las la-plus fs-2"></i>
						        </span>
						        <span class="indicator-progress">
							        <span class="spinner-border spinner-border-sm align-middle"></span>
						        </span>
                            </button>
                            <div class="d-flex flex-stack">
                                <!--begin::Search-->
                                <div class="position-relative me-1">
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
				                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
					                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
					                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
				                        </svg>
                                    </span>
                                    <!--end::Svg Icon-->
                                    <input id="tbx0103Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
                                </div>
                            </div>
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
                        <div class="row g-2">
						    <div class="col-sm-12 col-md-12 col-lg-6">
							    <div class="input-group input-group-sm mb-2">
								    <span class="input-group-text min-w-150px">Primary Lot</span>
								    <input id="tbx0103Phase" type="text" class="form-control " maxlength="13" Placeholder="Phase" readonly="readonly" />
							    </div>
						    </div>
						    <div class="col-sm-12 col-md-12 col-lg-3">
							    <div class="input-group input-group-sm mb-2">
								    <input id="tbx0103Block" type="text" class="form-control " maxlength="13" Placeholder="Block" readonly="readonly" />
							    </div>
						    </div>
						    <div class="col-sm-12 col-md-12 col-lg-3">
							    <div class="input-group input-group-sm mb-2">
								    <input id="tbx0103Lot" type="text" class="form-control " maxlength="13" Placeholder="Lot" readonly="readonly" />
							    </div>
						    </div>
                        </div>
                        <div class="table-loading">
                            <div id="div0103Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0103Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Phase</th>
										<th class="min-w-100px mw-100px fw-bold border-end">Block</th>
										<th class="min-w-100px mw-100px fw-bold border-end">Lot</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Add record -->
		<div id="mdl0104Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-600px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Merge Lots  - Add Lots</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <!--begin::Search-->
                                <div class="position-relative me-1">
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
				                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
					                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
					                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
				                        </svg>
                                    </span>
                                    <!--end::Svg Icon-->
                                    <input id="tbx0104Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
                                </div>
                            </div>
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
                        <!--begin::Files-->
                        <div class="table-loading">
                            <div id="div0104Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0104Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Phase</th>
										<th class="min-w-100px mw-100px fw-bold border-end">Block</th>
										<th class="min-w-100px mw-100px fw-bold border-end">Lot</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Upload-->
		<div id="mdl0202Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
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
					<div class="modal-body">
						<!--begin::Dropzone-->
						<div class="dropzone mb-5" id="DropZone">
							<!--begin::Message-->
							<div class="dz-message needsclick">
								<!--begin::Icon-->
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<!--end::Icon-->
								<!--begin::Info-->
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
								<!--end::Info-->
							</div>
						</div>
						<!--end::Dropzone-->
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0202Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Upload-->
	
		<!--begin::Modal Comment-->
		<div id="mdl0302Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Notes - Add Note</h5>
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
					<div class="modal-body">
						<textarea id="tbx0302Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" Placeholder="Notes"></textarea>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0302Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0302Add_Ok(this);return false;">
                            <span class="indicator-label">
                                Add Note
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Comment-->

    </div>
	
	<!--param-->
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnLotCode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<!--param-->
	
    <!-- script related to this page -->
    <script type="text/javascript">

        //variable
        var FileCount = 0;
        let checkedBoxStates = {};
        //variable

        //general
        function fn01Load() {
            fnAccess('PDD090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    location.replace("MNU000022");
                };
            });
        };
        function fn01DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0101Refresh").classList.remove("btn-view");
                document.getElementById("btn0101Add").classList.remove("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = pValue;
                }
            } else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Add").classList.add("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = pValue;
                }
            }
            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Add").disabled = pValue;
        };
        function fn01Toggle(button) {
            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            // Hide all other toggle menus
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) menu.classList.add('d-none');
            });

            // Toggle current menu
            if (toggleMenu) {
                const isVisible = !toggleMenu.classList.contains('d-none');
                toggleMenu.classList.toggle('d-none');

                // If now visible, add outside click listener
                if (!isVisible) {
                    const outsideClickListener = function (event) {
                        if (!wrapper.contains(event.target)) {
                            toggleMenu.classList.add('d-none');
                            document.removeEventListener('click', outsideClickListener);
                        }
                    };
                    setTimeout(() => {
                        // Allow this click to finish before listening
                        document.addEventListener('click', outsideClickListener);
                    }, 0);
                }
            }
        };
        //general

        //overview
        function fn0101LoadOverview(pMode, pID) { 
            if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Get Info - Dtl',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101Status").innerText = response[0].Status;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        fn01DisableButtons(false);
                        //toolbar

                        //load table
                        fn0101LoadTblDtl(pID);
                        //load table

                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Get Info - Dtl',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101Status").innerText = response[0].Status;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        fn01DisableButtons(true);
                        document.getElementById("btn0101Edit").classList.add("btn-edit");
                        document.getElementById("btn0101Edit").disabled = false;
                        document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                        document.getElementById("btn0101Delete").classList.remove("d-none");
                        document.getElementById("i0101Edit").classList.add("la-save");
                        //toolbar

                        //load table
                        fn0101LoadTblUpd(pID);
                        //load table

                        //content
                        document.getElementById("lbl0101UpdatedByName").innerText = response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = response[0].UpdatedDate;
                        //content
                    },
                });
            }
        };
        function fn0101Redraw(pMode, pID, pLotCode, pPhase, pBlock, pLot) {
            //update list
            if (pMode == "Add" || pMode == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Redraw',
                        'pID': pID,
                        'pLotCode': pLotCode,
                        'pPhase': pPhase,
                        'pBlock': pBlock,
                        'pLot': pLot,
                    },
                    success: function (response) {
                        if (pMode == "Add") {
                            //add row
                            var gv01 = $('#table0101Record').DataTable();
                            gv01.rows().deselect();
                            //last row
                            let lastrowId = "";
                            response.forEach(item => {
                                var row01 = gv01.row.add({
                                    Action: item.Action,
                                    Phase: item.Phase,
                                    Block: item.Block,
                                    Lot: item.Lot,
                                    Lots: item.Lots,
                                    AcctNo: item.AcctNo,
                                    AcctName: item.AcctName
                                }).draw(false).select();
                                // Set ID for each row
                                $(row01.node()).attr('id', item.rowId);

                                // Keep track of the last row ID to scroll to it later
                                lastRowId = item.rowId;
                            });

                            // Scroll to the last added row
                            if (lastRowId !== '') {
                                let new01 = gv01.row('#' + lastRowId);
                                let index01 = new01.index();
                                var rowNode = gv01.row(index01).node();
                                rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            };
                        } else if (pMode == "Edit") {
                            //edit row
                            var gv01 = $('#table0101Record').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].Phase).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Block).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Lot).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Lots).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].AcctNo).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].AcctName).draw(false);
                            //edit row

                            //select and go to record
                            row01.select();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        };
                    },
                });
            } else {
                //assigned
                var gv01 = $('#table0101Record').DataTable();
                let pCode = pLotCode + '' + pID + '' + pPhase + '' + pBlock + '' + pLot;
                gv01.row('#rowID0102' + pCode).remove().draw(false);
            };
        };
        function fn0102Redraw(pMode, pLotCode, pPhase, pBlock, pLot) {
            //update list
            if (pMode == "Add" || pMode == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Redraw - Dtl',
                        'pLotCode': pLotCode,
                        'pPhase': pPhase,
                        'pBlock': pBlock,
                        'pLot': pLot,
                    },
                    success: function (response) {
                        if (pMode == "Add") {
                            //add row
                            var gv01 = $('#table0103Record').DataTable();
                            gv01.rows().deselect();
                            //last row
                            let lastrowId = "";
                            response.forEach(item => {
                                var row01 = gv01.row.add({
                                    Action: item.Action,
                                    Phase: item.Phase,
                                    Block: item.Block,
                                    Lot: item.Lot
                                }).draw(false).select();
                                // Set ID for each row
                                $(row01.node()).attr('id', item.rowId);

                                // Keep track of the last row ID to scroll to it later
                                lastRowId = item.rowId;
                            });

                            // Scroll to the last added row
                            if (lastRowId !== '') {
                                let new01 = gv01.row('#' + lastRowId);
                                let index01 = new01.index();
                                var rowNode = gv01.row(index01).node();
                                rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            };
                        } else if (pMode == "Edit") {
                            //edit row
                            var gv01 = $('#table0103Record').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].Phase).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Block).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Lot).draw(false);
                            //edit row

                            //select and go to record
                            row01.select();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        };
                    },
                });
            } else {
                //assigned
                var gv01 = $('#table0103Record').DataTable();
                let pCode = pLotCode + '' + pPhase + '' + pBlock + '' + pLot;
                gv01.row('#rowID0104' + pCode).remove().draw(false);
            };
        };
        //function
        async function fn0102Add_Ok(Btn) {
            //access
            fnAccess('PDD090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn0102Add_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0102Add_Ok_Await(Btn) {
                // Get all checked items from our state object instead of DOM
                let checkboxData = Object.values(checkedBoxStates);
                let ModelCodeSrs = "";

                // Build ModelCodeSrs from stored state
                checkboxData.forEach(item => {
                    if (item.status === 1) {
                        if (ModelCodeSrs === "") {
                            ModelCodeSrs = `${item.modelcode}©${item.status}`;
                        } else {
                            ModelCodeSrs += `®${item.modelcode}©${item.status}`;
                        }
                    }
                });

                // Check if at least one item is selected
                if (checkboxData.length > 0) {
                    const projcode = checkboxData[0].projcode;
                    Add_Question(Btn, projcode, ModelCodeSrs);
                } else {
                    fnAlertOnly('Please select a house model!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                }

                // Rest of your functions remain the same...
                function Add_Question(Btn, projcode, ModelCodeSrs) {
                    Swal.fire({
                        text: 'Add/Modify selected model house(s)?',
                        icon: 'question',
                        iconColor: '#0095e8',
                        buttonsStyling: false,
                        showCancelButton: true,
                        confirmButtonText: "Yes",
                        cancelButtonText: 'Cancel',
                        customClass: {
                            confirmButton: 'btn btn-sm btn-info min-w-100px',
                            cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                        }
                    }).then((result) => {
                        if (result.isConfirmed) {
                            Validate_Add(document.getElementById('ContentPlaceHolder1_hdnID').value, Btn, projcode, ModelCodeSrs);
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                }
                //validate add
                function Validate_Add(ID, Btn, projcode, ModelCodeSrs) {
                    fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Add_Ok(Btn, projcode, ModelCodeSrs);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            checkedBoxStates = {};
                            selectAllcbx0102.checked = false;
                            fn01UpdateColumn(ID);
                            $('#mdl0102Add').modal('hide');
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');

                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                        };
                    });
                };

                function Add_Ok(Btn, projcode, ModelCodeSrs) {
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD090100',
                            'pType': 'Add House Model',
                            'pProjCode': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pModelCodeSrs': ModelCodeSrs,
                        },
                        success: async function (response) {
                            // Clear the checked states after successful save
                            checkedBoxStates = {};
                            selectAllcbx0102.checked = false;

                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');

                            await fn01UpdateColumn(document.getElementById("ContentPlaceHolder1_hdnID").value);

                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                            $('#mdl0102Add').modal('hide');
                        },
                    });
                }
            }
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('PDD090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                //load add model
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Get Data - Add',
                        'pProjCode': document.getElementById('ContentPlaceHolder1_hdnID').value
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div0102Loader").style.display = 'none';
                        //display loader

                        $('#table0102Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //datatable
                        var table0102Record = $("#table0102Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: false,
                            bInfo: false,
                            scrollCollapse: true,
                            paging: false,
                            lengthChange: false,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'Phase' },
                                { data: 'Block' },
                                { data: 'Lot' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false
                                }
                            ],
                            ordering: false
                        });
                        //datatable

                        //search
                        $('#tbx0102Find').on('keyup', function () {
                            table0102Record.search(this.value).draw();
                        });
                        //search

                        //show add modal
                        $('#mdl0102Add').modal('show');
                        //show add modal

                    }
                });
            //load add model
            };
        };

        //datatable structure
        function fn0101LoadTblDtl(pID) {
            $.ajax({
                type: "POST",
                url: "HNDPDD.ashx",
                data: {
                    'pFormCode': 'PDD090100',
                    'pType': 'Get Data',
                    'pProjCode': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0101Record").style.display = 'none';

                    //display loader
                    $('#table0101Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0101Record = $("#table0101Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Phase' },
                            { data: 'Block' },
                            { data: 'Lot' },
                            { data: 'Lots' },
                            { data: 'AcctNo' },
                            { data: 'AcctName' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false
                            },
                            {
                                targets: [6],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx0101Find').on('keyup', function () {
                        table0101Record.search(this.value).draw();
                    });
                    //search
                }
            });
        }
        function fn010201Add(pLotCode, pPhase, pBlock, pLot) {
            //access
            fnAccess('PDD090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Question();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add question
            function Add_Question() {
                Swal.fire({
                    text: 'Add record?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Add_Ok();
                    };
                });
                //add
                function Add_Ok() {
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD090100',
                            'pType': 'Add Record',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pLotCode': pLotCode,
                            'pPhase': pPhase,
                            'pBlock': pBlock,
                            'pLot': pLot
                        },
                        success: function (response) {
                            //alert
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            //load
                            fn0101Redraw("Add", document.getElementById("ContentPlaceHolder1_hdnID").value, pLotCode, pPhase, pBlock, pLot);
                            //modal
                            $("#mdl0102Add").modal("hide");
                        },
                    });
                };

            };
        };
        function fn010201Delete(pLotCode, pID, pPhase, pBlock, pLot) {
            //access
            fnAccess('PDD090000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    var pTblCode = pID + ' ' + pPhase + ' ' + pBlock + ' ' + pLot;
                    Validate(pTblCode);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(pTblCode) {
                fnValidateRecord('mstr_PackagedLots', pTblCode, '', 'Delete(Hdr)', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(pTblCode);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
            //delete question
            function Delete_Question(pTblCode) {
                Swal.fire({
                    text: 'Remove record?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Validate_Delete(pTblCode);
                    }
                });
                //validate
                function Validate_Delete(pTblCode) {
                    fnValidateRecord('mstr_PackagedLots', pTblCode, '', 'Delete', function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Ok(pTblCode);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            fn0101Redraw("Edit", document.getElementById("ContentPlaceHolder1_hdnID").value, pLotCode, pPhase, pBlock, pLot);
                            fn01LoadOverview(document.getElementById("hdnMode").value, document.getElementById("hdnID").value);
                        };
                    });
                };
                function Delete_Ok(pTblCode) {
                    fnDelete('PDD090000', 'mstr_PackagedLots(Hdr)', pTblCode, function (response) {
                        //alert
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        //load
                        fn0101Redraw("Delete", document.getElementById("ContentPlaceHolder1_hdnID").value, pLotCode, pPhase, pBlock, pLot);
                    });
                };
            };
        };
        function fn010201Edit(pLotCode, pID, pPhase, pBlock, pLot) {
            //access
            fnAccess('PDD090000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('mstr_PackagedLots', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(pLotCode);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //add
            function Edit(pLotCode) {
                //load add model
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Get Data - Edit',
                        'pLotCode': pLotCode
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div0103Loader").style.display = 'none';
                        //display loader

                        $('#table0103Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //datatable
                        var table0103Record = $("#table0103Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: false,
                            bInfo: false,
                            scrollCollapse: true,
                            paging: false,
                            lengthChange: false,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'Phase' },
                                { data: 'Block' },
                                { data: 'Lot' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false
                                }
                            ],
                            ordering: false
                        });
                        //datatable

                        //search
                        $('#tbx0103Find').on('keyup', function () {
                            table0103Record.search(this.value).draw();
                        });
                        //search

                        //bind
                        document.getElementById("tbx0103Phase").value = response[0].PhaseNo;
                        document.getElementById("tbx0103Block").value = response[0].BlockNo;
                        document.getElementById("tbx0103Lot").value = response[0].LotNo;
                        document.getElementById("ContentPlaceHolder1_hdnLotCode").value = pLotCode;
                        //bind

                        //show add modal
                        $('#mdl0103Edit').modal('show');
                        //show add modal

                    }
                });
                //load add model
            };
        };
        function fn010301Edit(pLotCode, pID, pPhase, pBlock, pLot) {
            //access
            fnAccess('PDD090000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Edit_Question();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add question
            function Edit_Question() {
                Swal.fire({
                    text: 'Save record?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Edit_Ok();
                    };
                });
                //add
                function Edit_Ok() {
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD090100',
                            'pType': 'Edit Record',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pLotCode': pLotCode,
                            'pPhase': pPhase,
                            'pBlock': pBlock,
                            'pLot': pLot
                        },
                        success: function (response) {
                            //alert
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            //load
                            fn0101Redraw("Add", document.getElementById("ContentPlaceHolder1_hdnID").value, pLotCode, pPhase, pBlock, pLot);
                            //modal
                            $("#mdl0102Add").modal("hide");
                        },
                    });
                };

            };
        };
        function fn010301Delete(pLotCode, pID, pPhase, pBlock, pLot) {
            //access
            fnAccess('PDD090000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Delete_Question(pLotCode);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //delete question
            function Delete_Question(pLotCode) {
                Swal.fire({
                    text: 'Remove record?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Delete_Ok(pLotCode);
                    }
                });
                //delete
                function Delete_Ok(pLotCode) {
                    fnDelete('PDD090000', 'mstr_PackagedLots(Dtl)', pLotCode, function (response) {
                        //alert
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        //load
                        RedrawHdr(document.getElementById("ContentPlaceHolder1_hdnID").value);
                        Redraw(document.getElementById("ContentPlaceHolder1_hdnLotCode").value);
                    });
                };
                function Redraw(pLotCode) {
                    //load add model
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD090100',
                            'pType': 'Get Data - Edit',
                            'pLotCode': pLotCode
                        },
                        success: function (response) {
                            //display loader
                            document.getElementById("div0103Loader").style.display = 'none';
                            //display loader

                            $('#table0103Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //datatable
                            var table0103Record = $("#table0103Record").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: false,
                                bInfo: false,
                                scrollCollapse: true,
                                paging: false,
                                lengthChange: false,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'Phase' },
                                    { data: 'Block' },
                                    { data: 'Lot' }
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0],
                                        orderable: false
                                    }
                                ],
                                ordering: false
                            });
                            //datatable

                            //search
                            $('#tbx0103Find').on('keyup', function () {
                                table0103Record.search(this.value).draw();
                            });
                            //search

                            //bind
                            document.getElementById("tbx0103Phase").value = response[0].PhaseNo;
                            document.getElementById("tbx0103Block").value = response[0].BlockNo;
                            document.getElementById("tbx0103Lot").value = response[0].LotNo;
                            document.getElementById("ContentPlaceHolder1_hdnLotCode").value = pLotCode;
                            //bind

                            //show add modal
                            $('#mdl0103Edit').modal('show');
                            //show add modal

                        }
                    });
                    //load add model
                };
                function RedrawHdr(pID) {
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD090100',
                            'pType': 'Get Data',
                            'pProjCode': pID
                        },
                        success: function (response) {
                            //display loader
                            document.getElementById("div0101Record").style.display = 'none';

                            //display loader
                            $('#table0101Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table0101Record = $("#table0101Record").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: false,
                                bInfo: false,
                                scrollCollapse: true,
                                paging: false,
                                lengthChange: false,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'Phase' },
                                    { data: 'Block' },
                                    { data: 'Lot' },
                                    { data: 'Lots' },
                                    { data: 'AcctNo' },
                                    { data: 'AcctName' }
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0],
                                        orderable: false
                                    },
                                    {
                                        targets: [6],
                                        className: 'tbody-nowrap-auto'
                                    }
                                ],
                                ordering: false
                            });
                            //datatable

                            //search
                            $('#tbx0101Find').on('keyup', function () {
                                table0101Record.search(this.value).draw();
                            });
                            //search
                        }
                    });
                };
            };
        };
        function fn0104Add(Btn) {
            //access
            fnAccess('PDD090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    // Enable button
                    Btn.disabled = false;
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                // Disable button to avoid multiple click
                Btn.disabled = true;
                // Show loading indication
                Btn.setAttribute('data-kt-indicator', 'on');
                //load add model
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD090100',
                        'pType': 'Get Data - Add (Dtl)',
                        'pProjCode': document.getElementById('ContentPlaceHolder1_hdnID').value
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div0104Loader").style.display = 'none';
                        //display loader

                        $('#table0104Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //datatable
                        var table0104Record = $("#table0104Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: false,
                            bInfo: false,
                            scrollCollapse: true,
                            paging: false,
                            lengthChange: false,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'Phase' },
                                { data: 'Block' },
                                { data: 'Lot' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false
                                }
                            ],
                            ordering: false
                        });
                        //datatable

                        //search
                        $('#tbx0104Find').on('keyup', function () {
                            table0104Record.search(this.value).draw();
                        });
                        //search

                        //show add modal
                        $('#mdl0104Add').modal('show');
                        //show add modal

                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        // Enable button
                        Btn.disabled = false;
                    }
                });
                //load add model
            };
        };
        function fn010401Add(pLotCode, pPhase, pBlock, pLot) {
            //access
            fnAccess('PDD090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Question();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add question
            function Add_Question() {
                Swal.fire({
                    text: 'Add record?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Add_Ok();
                    };
                });
                //add
                function Add_Ok() {
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD090100',
                            'pType': 'Add Record (Dtl)',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pCode': document.getElementById("ContentPlaceHolder1_hdnLotCode").value,
                            'pMtr_Phase': document.getElementById("tbx0103Phase").value,
                            'pMtr_Block': document.getElementById("tbx0103Block").value,
                            'pMtr_Lot': document.getElementById("tbx0103Lot").value,
                            'pLotCode': pLotCode,
                            'pPhase': pPhase,
                            'pBlock': pBlock,
                            'pLot': pLot
                        },
                        success: function (response) {
                            //alert
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            //load
                            fn0101Redraw("Edit", document.getElementById("ContentPlaceHolder1_hdnID").value, document.getElementById("ContentPlaceHolder1_hdnLotCode").value, document.getElementById("tbx0103Phase").value, document.getElementById("tbx0103Block").value, document.getElementById("tbx0103Lot").value);
                            fn0102Redraw("Add", pLotCode, pPhase, pBlock, pLot);
                            //modal
                            $("#mdl0104Add").modal("hide");
                        },
                    });
                };

            };
        };
        //datatable structure

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'PDD090000',
                    'pType': 'Upload - Get Record',
                    'pID': pID,
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0201LoaderAttachment").style.display = "";
                    //display loader

                    $('#table0201Attachment').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0201Attachment = $("#table0201Attachment").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Type' },
                            { data: 'Attachment' },
                            { data: 'UploadedBy' },
                            { data: 'UploadedDate' }],
                        columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                        order: [[2, 'asc']],
                    });
                    //datatable

                    //search
                    $('#tbx0201FindAttachment').on('keyup', function () {
                        table0201Attachment.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0201LoaderAttachment").style.display = "none";
                    //hide loader

                    //action button
                    if (pMode == "ADD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    } else if (pMode == "DTL") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.add("btn-active-light");
                            btn.disabled = false;
                        }
                    } else if (pMode == "UPD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    }
                    //action button

                },
            });
        };
        function fn0201Download(pFormCode, pID, pFileName) {
            //if exisit
            fnIfExist('calmardblive.dbo.mstr_PackagedLots', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Download();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //download
            function Download() {
                $.ajax({
                    type: "POST",
                    url: "HNDGEN.ashx",
                    data: {
                        'pFormCode': pFormCode,
                        'pType': 'Upload - Download',
                        'pID': pID,
                        'pFileName': pFileName,
                    },
                    success: function (response) {
                        window.open('MNU020200?View=' + response[0].View);
                    },
                });
            };
        };
        function fn0201Delete(pFormCode, pID, pFileName) {
            //if exisit
            fnIfExist('calmardbLive.dbo.mstr_PackagedLots', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('PDD090000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Question(pFormCode, pID, pFileName);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //delete question
            function Delete_Question(pFormCode, pID, pFileName) {
                Swal.fire({
                    text: 'Remove attachment?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Delete_Ok(pFormCode, pID, pFileName);
                    }
                });
            };
            function Delete_Ok(pFormCode, pID, pFileName) {
                $.ajax({
                    type: "POST",
                    url: "HNDGEN.ashx",
                    data: {
                        'pFormCode': pFormCode,
                        'pType': 'Upload - Delete',
                        'pID': pID,
                        'pFileName': pFileName,
                    },
                    success: function (response) {
                        fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
                    },
                });
            };
        };
        //attachment

        //notes
        function fn0301LoadNotes(pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'PDD090000',
                    'pType': 'Notes - Get Record',
                    'pID': pID,
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0301LoaderNotes").style.display = "";
                    //display loader

                    $('#table0301Notes').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0301Notes = $("#table0301Notes").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        data: response,
                        columns: [
                            { data: 'Notes' }],
                        columnDefs: [{ targets: 0, orderable: false }],
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx0301FindNotes').on('keyup', function () {
                        table0301Notes.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0301LoaderNotes").style.display = "none";
                    //hide loader

                },
            });
        };
        function fn0301Add() {
            //if exisit
            fnIfExist('calmardbLive.dbo.mstr_PackagedLots', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //add
            function Add() {
                document.getElementById("tbx0302Note").value = "";
                document.getElementById("hdnMention").value = "";
                $('#mdl0302Notes').modal('show');
            };
        };
        function fn0302Add_Ok(Btn) {
            //if exisit
            fnIfExist('calmardbLive.dbo.mstr_PackagedLots', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //add
            async function Add_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn0302Add_Ok_Await(Btn);
            }
        };
        function fn0302Add_Ok_Await(Btn) {
            // process
            return new Promise(resolve => {
                //Validate
                if (document.getElementById("tbx0302Note").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Add_Ok_Await();
                }
                //add
                function Add_Ok_Await() {
                    // Do Billing
                    $.ajax({
                        type: "POST",
                        url: "HNDGEN.ashx",
                        data: {
                            'pFormCode': 'PDD090000',
                            'pType': 'Notes - Add',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pNotes': document.getElementById("tbx0302Note").value,
                            'pMention': document.getElementById("hdnMention").value,
                        },
                        success: function (response) {
                            //message
                            fnAlertOnly('Note successfully added.', 'success', 'btn btn-success');
                            document.getElementById("tbx0302Note").value = "";
                            document.getElementById("hdnMention").value = "";
                            fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        },
                    });
                };
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                //resolve
                resolve();
            });
        };
        //notes

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //metion                jq.fn.atwho.debug = true;
                var chatHub = jq.connection.chatHub;
                jq.connection.hub.start().done(function () {
                    loadFunction()
                }).fail(function (error) {
                    console.error("SignalR connection failed: " + error)
                });
                function loadFunction() {
                    chatHub.server.getEmployeeData().then(function (data) {
                        initAtWho(data);
                    }).catch(function (error) {
                        console.error("Error fetching data from SignalR:", error)
                    });
                    function initAtWho(data) {
                        var at_config = {
                            at: "@",
                            data: data,
                            insertTpl: '${fname}',
                            displayTpl: "<li><div class='d-flex align-items-center'><div class='symbol symbol-30px overflow-hidden me-3'><div class='symbol-label'> <img src='Assets/media/avatars/${empPic}' class='w-100' alt='' />  </div></div><div class='d-flex flex-column '><span class='text-weight-500 text-gray-800 '>${name}</span><span class='text-weight-500'>${email}</span></div></div></li>",
                            limit: 200,
                            callbacks: {
                                beforeInsert: function (value, jqli, e) {
                                    var selectedUserData = jqli.data('item-data');
                                    mentionUser.push({
                                        name: selectedUserData.fname,
                                        empCode: selectedUserData.empCode
                                    })
                                    var emp_no = mentionUser.map(function (employee) {
                                        return employee.empCode
                                    });
                                    initialMention = emp_no;
                                    $('#hdnMention').val(initialMention.join(','));
                                    return '@' + value;
                                },
                            }
                        }
                        $inputor = jq('.mention').atwho(at_config);
                        $inputor.caret('pos', 47);
                        $inputor.focus().atwho('run');
                        // for removing mention
                        $inputor.on('keydown', function (e) {
                            if (e.keyCode === 8) {
                                handleBackspace();
                            }
                        })
                        function handleBackspace() {
                            var inputValue = $inputor.val();
                            var cursorPosition = $inputor.caret('pos');
                            var mentionStart = inputValue.lastIndexOf('@', cursorPosition - 1);

                            if (mentionStart !== -1) {
                                // Extract mention text to be removed
                                var mentionText = inputValue.substring(mentionStart, cursorPosition);

                                // Find and remove mention from mentionUser array
                                mentionUser = mentionUser.filter(function (user) {
                                    return `@${user.name}` !== mentionText;
                                });

                                var emp_no = mentionUser.map(function (employee) {
                                    return employee.empCode
                                });

                                initialMention = emp_no;
                            }
                        }
                    };
                };                //metion

                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

                //upload
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "HNDGEN.ashx?pFormCode=PDD090000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0202Upload').modal('hide');
                        //load attachment
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                myDropzone.on("addedfile", function (file) {
                    FileCount = FileCount + 1;
                });
                myDropzone.on("removedfile", function (file) {
                    FileCount = FileCount - 1;
                });
                $('#btn0201Add').on('click', function (e) {
                    //access
                    fnAccess('PDD090000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Add();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    function Add() {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl0202Upload').modal('show');
                    };
                });
                $('#btn0202Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('PDD090100', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
                    function Validate() {
                        if (FileCount > 0) {
                            btn0202Add_Ok();
                        } else {
                            fnAlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
                        }
                    }
                    //upload
                    async function btn0202Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0202Add_Ok_Await(Btn);
                    }
                    async function btn0202Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=PDD090000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //upload

                //add record - uploadrecord
                var myDropzone = new Dropzone("#DropZoneUploadRecord", {
                    url: "HNDPDD.ashx?pType=Upload-HLA",
                    autoProcessQueue: false,
                    parallelUploads: 1,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 1,
                    acceptedFiles: ".xlsx,.xls,.XLSX,.XLS",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0203Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0203Upload').modal('hide');
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                        fnAlertOnly('There was an issue uploading your file. Please try again.', 'danger', 'btn btn-danger');
                    }
                });
                myDropzone.on("addedfile", function () { FileCount++; });
                myDropzone.on("removedfile", function () { FileCount--; });
                $('#a0103UploadRecord').on('click', function (e) {
                    //access
                    fnAccess('PDD090000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
                    function Validate(ID) {
                        fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Add();
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    };
                    function Add() {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl0203Upload').modal('show');
                    };
                });
                $('#btn0203Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('PDD090000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate_AddOk(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate add
                    function Validate_AddOk(ID) {
                        fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Validate();
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                var Btn = document.getElementById('btn0203Add_Ok');
                                Btn.disabled = false;
                                Btn.removeAttribute('data-kt-indicator');

                                $('#mdl0203Upload').modal('hide');

                                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                            };
                        });
                    };
                    //validate empty attachment
                    function Validate() {
                        if (FileCount > 0) {
                            btn0203Add_Ok();
                        } else {
                            fnAlertOnly('Attach an excel file to proceed!', 'error', 'btn btn-danger');
                        }
                    };
                    //upload
                    async function btn0203Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0203Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0203Add_Ok_Await(Btn);
                    }
                    async function btn0203Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone.options.url = "HNDPDD.ashx?pType=Upload-HLA";
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //add record - uploadrecord

            });
            jQuery(function ($) {
                fn01Load();
            });
        };
        //load page

    </script>
    <!-- script related to this page -->

</asp:Content>
