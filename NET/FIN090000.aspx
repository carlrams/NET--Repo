<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FIN090000.aspx.vb" Inherits="NET.FIN090000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!--content-->
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
						<li class="breadcrumb-item text-white">Cashiering (Receipting)</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" onclick="fn01Add();return false;">Add New</a>
					<!--end::Button-->
				</div>
				<!--end::Actions-->
			</div>
			<!--begin::Container-->
		</div>
		<!--end::breadcrumb bar-->
		
		<!--begin::Card-->
        <div id="card01Content" class="card mb-5">
			<!--begin::Beader-->
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/FIN090000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Cashiering (Receipting)</span>
						</h3>
					</div>
					<!--end::Title-->
				</div>
			    <div class="card-toolbar">
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
						    <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
					    </div>
					    <!--end::Search-->
                        <!--option-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                            <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                           <i class="las la-bars fs-3"></i>
                            <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="fn01Filter();return false;">Filter</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="fn01Tools();return false;">Tools</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                            </div>
                        </div>
                        <!--option-->
                        <!--end::Menu-->
                    </div>
			    </div>
            </div>
		    <!--end::Header-->
			<!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                <div class="table-loading" style="min-height:62.3vh;">
                    <div id="div01Loader" class="table-loading-message">
                        Loading...
                    </div>
                    <table id="table01Record" class="table border rounded table-row-bordered  gy-2 gs-2 w-100 align-middle">
					    <thead>
						    <tr class="fw-bold fs-7 text-gray-800">
							    <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Post"><i class='las la-check-circle fs-3'></i></span></th>
							    <th class="min-w-150px mw-150px fw-bold border-end nowrap-auto"><span title="OR No.">OR No.</span></th>
                                <th class="min-w-100px mw-100px fw-bold border-end nowrap-auto"><span title="OR Date">OR Date</span></th>
                                <th class="min-w-150px w-50 fw-bold border-end">Payee</th>
                                <th class="min-w-150px w-50 fw-bold border-end">Particulars</th>
                                <th class="min-w-150px mw-150px fw-bold">Amount</th>
						    </tr>
					    </thead>
					    <tbody>
							
					    </tbody>
				    </table>
				    <!--end::Files-->
                </div>
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->
        
		<!--begin::Modal Filter-->
		<div id="mdl01Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Cashiering (Receipting) - Filter record</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-warning" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
                        <select id="ddl01Branch" data-kt-repeater="select2" data-dropdown-parent="#mdl01Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Select Branch</option>
                            <option value="All">All</option>
                            <option value="Main Office">Main Office</option>
                            <option value="SM Lucena">SM Lucena</option>
                            <option value="Batangas">Batangas</option>
                            <option value="Laguna">Laguna</option>
                            <option value="Sonrisa">Sonrisa</option>
                        </select>
                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
				            <input id="cbx01Post" class="form-check-input" type="checkbox" value=""/>
				            <label class="form-check-label" for="cbx01Post">
					            Posted
				            </label>
                         </div>
                        <div class="row gx-2 mb-2">
                            <div class="col-6">
                                <input id="tbx01ORFrom" type="text" class="form-control form-control-sm" placeholder="OR No. From" value="" />
                            </div>
                            <div class="col-6">
                                <input id="tbx01ORTo" type="text" class="form-control form-control-sm" placeholder="OR No. To" value="" />
                            </div>
                        </div>
                        <div class="row gx-2 gy-2 mb-2">
                            <div class="col-6">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
                                    <input id="tbx01DateFrom" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly Placeholder="Date From" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx01DateFrom');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
						    </div>
						    <div class="col-6">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
                                    <input id="tbx01DateTo" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly Placeholder="Date To" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx01DateTo');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
						    </div>
                        </div>
					</div>

                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn01Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Processing
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Filter-->

		<!--begin::Modal Filter-->
		<div id="mdl01FilterAdd" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index: 1060;">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Cashiering (Receipting) - Add record filter</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-warning" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
                        <select id="ddl01BranchAdd" data-kt-repeater="select2" data-dropdown-parent="#mdl01FilterAdd" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Select Branch</option>
                            <option value="All">All</option>
                            <option value="Main Office">Main Office</option>
                            <option value="SM Lucena">SM Lucena</option>
                            <option value="Batangas">Batangas</option>
                            <option value="Laguna">Laguna</option>
                            <option value="Sonrisa">Sonrisa</option>
                        </select>        
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn01FilterAdd_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Processing
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Filter-->

		<!--begin::Modal Tools-->
		<div id="mdl01Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Tools</h5>
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
					<div class="modal-body scroll">
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Payment Order (PDC)</div>
							            </a>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Payment Order (Remittance)</div>
							            </a>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">OR Settings</div>
							            </a>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">OR Reversal</div>
							            </a>
						            </div>
					            </div>
				            </div>
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Tools-->

		<!--begin::Modal Add record-->
		<div id="mdl01Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - Add record</h5>
                        <!--begin::Close-->
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
                    <!--begin::Card header-->
                    <div class="card-header">
                        <div class="d-flex align-items-center">
                            <button id="btn01Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn01Add();return false;"><i class="las la-redo-alt fs-2"></i></button>
							<button id="btn01Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn01Delete();return false;"><i class="las la-trash fs-2"></i></button>
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
                                    <input id="tbx01ModalFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                </div>
                                <!--end::Search-->
                                <!--option-->
                                <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                                   <i class="las la-bars fs-3"></i>
                                    <!--end::Svg Icon-->
                                </button>
                                <div id="div01Filter" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
                                    <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" onclick="fn01FilterAdd();return false;">Filter</a>
                                    </div>
                                </div>
                                <!--option-->
                            </div>
                        </div>
                    </div>
                    <!--end::Card header-->
					<div class="modal-body">
                        <!--begin::Files-->
                        <div class="table-loading">
                            <div id="div01ModalLoader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01Add" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-20px mw-20px fw-bold border-end" style="padding-left:15px"><span title="Select">Select</i></span></th>
						                <th class="min-w-100px mw-100px fw-bold border-end">Transaction No.</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end" style="padding-left:15px"><span title="Transaction Date">Transaction Date</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Payor</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Amount</th>
                                        <th class="min-w-30px mw-30px fw-bold">Action</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer d-flex flex-nowrap justify-content-between align-items-center overflow-auto">
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px flex-shrink-0" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                        <div class="d-flex gap-3 mx-auto flex-shrink-1">
                            <div class="form-check">
                                <input id="rb01SalesInvoice" class="form-check-input" type="radio" name="options" value="SalesInvoice">
                                <label class="form-check-label" for="rb01SalesInvoice">Sales Invoice</label>
                            </div>
                            <div class="form-check">
                                <input id="rb01RegularOR" class="form-check-input" type="radio" name="options" value="RegularOR">
                                <label class="form-check-label" for="rb01RegularOR">Regular OR</label>
                            </div>
                            <div class="form-check">
                                <input id="rb01SmallOR" class="form-check-input" type="radio" name="options" value="SmallOR">
                                <label class="form-check-label" for="rb01SmallOR">Small OR</label>
                            </div>
                        </div>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->

        <!--begin::Modal PDC record-->
		<div id="mdl0102PDC" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - Payment Order (PDC/ADA)</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <!-- Search -->
                                <div class="position-relative flex-grow-1 me-2">
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
                                                transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                            <path
                                                d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
                                                fill="currentColor" />
                                        </svg>
                                    </span>
                                    <input id="tbx0102Find" type="text"
                                        data-kt-inbox-listing-filter="search"
                                        class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12"
                                        placeholder="Search" />
                                </div>

                                <!-- Bars button -->
                                <div>
                                    <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                                        <i class="las la-bars fs-3"></i>
                                    </button>
                                    <div id="div0102ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
                                        <div class="menu-item px-3">
                                            <a href="#" class="menu-link px-3" onclick="fn0102Filter();return false;">Filter</a>
                                        </div>
                                    </div>
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
                        <div class="table-loading">
                            <div id="div0102Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0102Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Acct. No.</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Acct. Name</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Drawee Bank</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Type</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check No.</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check Date</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check Amt.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Depository Bank</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Application</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0102Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal PDC record-->

		<!--begin::Modal Filter-->
		<div id="mdl0102Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Cashiering (Receipting) Payment Order (PDC/ADA) - Filter record</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-warning" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
                        <div class="row gx-2 gy-2 mb-2">
                            <div class="col-12">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
                                    <input id="tbx0102Date" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly Placeholder="Date" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0102Date');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
						    </div>
                        </div>
					</div>

                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0102Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Processing
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Filter-->

		<!--begin::Modal Remittance record-->
		<div id="mdl0103Remittance" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - Payment Order (Remittance)</h5>
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
                        <div class="table-loading">
                            <div id="div0103Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0103Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
						                <th class="min-w-150px mw-150px fw-bold border-end">Reference</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Bank</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Date</th>
                                        <th class="min-w-150px mw-100px fw-bold border-end">Amount</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Class</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Payor</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Payor Name</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Application</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Status</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0103Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Remittance record-->
        
        <!--begin::Modal OR record-->
        <div id="mdl0104OR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
		        <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - OR Settings</h5>
					</div>
                    <div class="card-header">
                        <div class="d-flex flex-wrap">
                            <button id="btn0104Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0104Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
                            <span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
                            <button id="btn0104Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0104Delete();return false;"><i class="las la-trash fs-2"></i></button>
                            <button id="btn0104Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0104Edit();return false;"><i id="i0104Edit" class="las la-pencil-alt fs-2"></i></button>
                        </div>
                    </div>
			        <div class="modal-body">
                        <div id="div0104Detail">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">User</span>
                                <span id="lbl0104User" type="text" class="form-control" Placeholder="User"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Branch</span>
                                <span id="lbl0104Branch" type="text" class="form-control" Placeholder="Branch"></span>
                            </div>
                            <div class="row g-2">
                                <div class="col-sm-12 col-md-12 col-lg-9"> 
                                    <div class="input-group input-group-sm mb-2">
                                        <span class="input-group-text min-w-150px">OR No.</span>
                                        <span id="lbl0104ORNo" type="text" class="form-control" Placeholder="OR No."></span>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-3"> 
                                    <div class="input-group input-group-sm mb-2">
                                        <span id="lbl0104Location" type="text" class="form-control" Placeholder="Location"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Small OR No.</span>
                                <span id="lbl0104SmallORNo" type="text" class="form-control" Placeholder="Small OR No."></span>
                            </div>
                        </div>
                        <div id="div0104Update" style="display:none">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">User</span>
                                <input id="tbx0104User" type="text" class="form-control" Placeholder="User" readonly />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Branch</span>
                                <input id="tbx0104Branch" type="text" class="form-control" Placeholder="Branch" readonly />
                            </div>
                            <div class="row g-2">
                                <div class="col-sm-12 col-md-12 col-lg-9">
                                    <div class="input-group input-group-sm mb-2">
                                        <span class="input-group-text min-w-150px required">OR No.</span>
                                        <input id="tbx0104ORNo" type="text" class="form-control" Placeholder="OR No." maxlength="500" />
                                    </div>
                                 </div>
                                <div class="col-sm-12 col-md-12 col-lg-3">
                                    <div class="input-group input-group-sm mb-2">
                                        <input id="tbx0104Location" type="text" class="form-control" Placeholder="Location" readonly />
                                    </div>
                                 </div>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Small OR No.</span>
                                <input id="tbx0104SmallORNo" type="text" class="form-control" Placeholder="Small OR No." maxlength="500" />
                            </div>
                        </div>
			        </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
                    <!--end::Actions-->
		        </div>
	        </div>
        </div>
        <!--begin::Modal OR record-->
        
		<!--begin::Modal OR Reversal record-->
		<div id="mdl0105Reversal" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog  modal-dialog-centered mw-1000px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - OR Reversal</h5>
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
                                    <input id="tbx0105Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                        <div class="table-loading">
                            <div id="div0105Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0105Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">OR No.</th>
                                        <th class="min-w-200px mw-150px fw-bold border-end">OR Date</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Payee</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Amount</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text min-w-150px">Reason</span>
                            <input id="tbx0105Reason" type="text" class="form-control" Placeholder="Reason" maxlength="500" />
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0105Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal OR Reversal record-->
        
    </div>
    <!--content-->
	
    <input id="IsPostBack01" type="hidden" value="false" />
    <input id="hdnBranchCode" type="hidden" value="false" />
    <input id="hdnORMode" runat="server" type="hidden" value="" />
	
	<!-- scripts related to this page -->
    <script type="text/javascript">

        //general
        function fn01Load() {
            fnAccess('FIN090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090000',
                        'pType': 'Get Branch',
                    },
                    success: function (response) {
                        document.getElementById("hdnBranchCode").value = response[0].BranchCode;
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Get Record - HDR',
                                'pBranch': response[0].BranchName,
                                'pPost': 0,
                                'pDocNoFrom': '',
                                'pDocNoTo': '',
                                'pDocDateFrom': '',
                                'pDocDateTo': '',
                                'pAuditUser': '',
                            },
                            success: function (response) {
                                //display loader
                                document.getElementById("div01Loader").style.display = "";
                                //display loader

                                $('#table01Record').DataTable().destroy();

                                //disable column type detection
                                DataTable.types().forEach(type => {
                                    DataTable.type(type, 'detect', () => false);
                                });
                                //disable column type detection

                                //sort date by yyyy/mm/dd
                                $.fn.dataTable.moment('MM/DD/YYYY');
                                //sort date by yyyy/mm/dd

                                //datatable
                                var table01Record = $("#table01Record").DataTable({
                                    processing: true,
                                    bFilter: true,
                                    bPaginate: true,
                                    bInfo: false,
                                    paging: true,
                                    lengthChange: true,
                                    pageLength: 25,
                                    select: true,
                                    data: response,
                                    columns: [
                                        { data: 'Action' },
                                        { data: 'Posted' },
                                        { data: 'DocNo' },
                                        { data: 'DocDate' },
                                        { data: 'Payee' },
                                        { data: 'Particulars' },
                                        { data: 'DocAmount' }],
                                    rowId: 'rowId',
                                    columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }, { targets: 5, className: 'tbody-nowrap-auto' }, { targets: 6, className: 'tbody-nowrap-auto' }],
                                    order: [[4, 'asc']],
                                    orderCellsTop: true,
                                });
                                //datatable

                                //search
                                $('#tbx01Find').on('keyup', function () {
                                    table01Record.search(this.value).draw();
                                });
                                //search

                                //export
                                const documentTitle = 'Cashiering (Receipting)';
                                var buttons = new $.fn.dataTable.Buttons(table01Record, {
                                    buttons: [
                                        {
                                            extend: 'excelHtml5',
                                            title: documentTitle,
                                            exportOptions: {
                                                columns: [2, 3, 4, 5, 6]
                                            }
                                        }
                                    ]
                                }).container().appendTo($('#div01ExportButton'));
                                // Hook dropdown menu click event to datatable export buttons
                                const exportButtons = document.querySelectorAll('[data-kt-export]');
                                exportButtons.forEach(exportButton => {
                                    exportButton.addEventListener('click', e => {
                                        e.preventDefault();

                                        // Get clicked export value
                                        const exportValue = e.target.getAttribute('data-kt-export');
                                        const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                                        // Trigger click event on hidden datatable export buttons
                                        target.click();
                                    });
                                });
                                //export

                                //stop loading
                                document.getElementById("IsPostBack01").value = "true";
                                //stop loading

                                //hide loader
                                document.getElementById("div01Loader").style.display = "none";
                                //hide loader
                            },
                        });
                    },
                });
                //filter
                $('#ddl01Branch').val('').trigger('change');
                document.getElementById("cbx01Post").checked = false;
                document.getElementById("tbx01ORFrom").value = "";
                document.getElementById("tbx01ORTo").value = "";
                document.getElementById("tbx01DateFrom").value = "";
                document.getElementById("tbx01DateTo").value = "";
                //filter
            };
        };
        function fn01Redraw(Action, ID) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090000',
                        'pType': 'Redraw - Hdr',
                        'pID': ID
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add({ Action: response[0].Action, Posted: response[0].Posted, DocNo: response[0].DocNo, DocDate: response[0].DocDate, Payee: response[0].Payee, Particulars: response[0].Particulars, DocAmount: response[0].DocAmount }).draw(false).select();
                            $(row01.node()).attr('id', response[0].rowId);
                            gv01.row({ selected: true }).scrollTo(false);

                            let new01 = gv01.row('#' + response[0].rowId);
                            let index01 = new01.index();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        } else if (Action == "Edit") {
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].Posted).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].DocNo).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].DocDate).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Payee).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].Particulars).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].DocAmount).draw(false);

                            row01.select();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        };
                    },
                });
            } else {
                //assigned
                var gv01 = $('#table01Record').DataTable();
                gv01.row('#rowID01' + ID).remove().draw(false);
            };
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
        }
        //general

        //filter
        function fn01Filter() {
            $('#mdl01Filter').modal('show');
        };
        function fn01Filter_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            Filter_Ok();
            //function
            async function Filter_Ok() {
                await Filter_Ok_Await(Btn);
            };
            async function Filter_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090000',
                            'pType': 'Get Record - HDR',
                            'pBranch': document.getElementById("ddl01Branch").options[document.getElementById("ddl01Branch").selectedIndex].value,
                            'pPost': document.getElementById("cbx01Post").checked,
                            'pDocNoFrom': document.getElementById("tbx01ORFrom").value,
                            'pDocNoTo': document.getElementById("tbx01ORTo").value,
                            'pDocDateFrom': document.getElementById("tbx01DateFrom").value,
                            'pDocDateTo': document.getElementById("tbx01DateTo").value,
                            'pAuditUser': '',
                        },
                        success: function (response) {
                            //display loader
                            document.getElementById("div01Loader").style.display = "";
                            //display loader

                            $('#table01Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table01Record = $("#table01Record").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: true,
                                bInfo: false,
                                paging: true,
                                lengthChange: true,
                                pageLength: 25,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'Posted' },
                                    { data: 'DocNo' },
                                    { data: 'DocDate' },
                                    { data: 'Payee' },
                                    { data: 'Particulars' },
                                    { data: 'DocAmount' }],
                                rowId: 'rowId',
                                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }, { targets: 5, className: 'tbody-nowrap-auto' }, { targets: 6, className: 'tbody-nowrap-auto' }],
                                order: [[4, 'asc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx01Find').on('keyup', function () {
                                table01Record.search(this.value).draw();
                            });
                            //search

                            //export
                            const documentTitle = 'Cashiering (Receipting)';
                            var buttons = new $.fn.dataTable.Buttons(table01Record, {
                                buttons: [
                                    {
                                        extend: 'excelHtml5',
                                        title: documentTitle,
                                        exportOptions: {
                                            columns: [2, 3, 4, 5, 6]
                                        }
                                    }
                                ]
                            }).container().appendTo($('#div01ExportButton'));
                            // Hook dropdown menu click event to datatable export buttons
                            const exportButtons = document.querySelectorAll('#div01ExportMenu [data-kt-export]');
                            exportButtons.forEach(exportButton => {
                                exportButton.addEventListener('click', e => {
                                    e.preventDefault();

                                    // Get clicked export value
                                    const exportValue = e.target.getAttribute('data-kt-export');
                                    const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                                    // Trigger click event on hidden datatable export buttons
                                    target.click();
                                });
                            });
                            //export

                            //hide loader
                            document.getElementById("div01Loader").style.display = "none";
                            //hide loader

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //resolve
                            resolve();
                        },
                    });
                });
            };
        };
        //filter

        //tools
        function fn01Tools() {
            $('#mdl01Tools').modal('show');
        }
        // PDC
        function fn0101_FIN09RPT01() {
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Payment Order',
                    },
                    beforeSend: function () {
                        // Show Swal loader
                        Swal.fire({
                            title: 'Loading...',
                            text: 'Please wait while data is being processed.',
                            allowOutsideClick: false,
                            didOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    success: function (response) {
                        //hide loader
                        document.getElementById("div0102Loader").style.display = "";
                        //hide loader

                        $('#table0102Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table0102Record = $("#table0102Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'AcctNo', },
                                { data: 'AcctName' },
                                { data: 'DraweeBankCodeName' },
                                { data: 'Type' },
                                { data: 'CheckNo' },
                                { data: 'CheckDate' },
                                { data: 'CheckAmt' },
                                { data: 'DepositoryBankCodeName' },
                                { data: 'Application' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false,
                                }
                                ,
                                {
                                    targets: [2, 3, 9],
                                    className: 'tbody-nowrap-auto'
                                },
                                {
                                    targets: [7],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                }
                            ],
                            orderCellsTop: true,
                            initComplete: function () {
                                this.api().cells().every(function () {
                                    var cell = this.node();
                                    $(cell).attr('title', $(cell).text());
                                });
                            }
                        });
                        //datatable

                        //search
                        $('#tbx0102Find').on('keyup', function () {
                            table0102Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div0102Loader").style.display = "none";
                        //hide loader

                        // close Swal loader when everything is done
                        Swal.close();
                    }
                });
                //modal
                $('#mdl0102PDC').modal('show');
            };
        };
        function fn0102Filter() {
            document.getElementById("tbx0102Date").value = '';
            $('#mdl0102Filter').modal('show');
        };
        function fn0102Filter_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            Filter_Ok();
            //function
            async function Filter_Ok() {
                await Filter_Ok_Await(Btn);
            };
            async function Filter_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090100',
                            'pType': 'Cashiering Tools - Payment Order',
                            'pDate': document.getElementById("tbx0102Date").value
                        },
                        beforeSend: function () {
                            // Show Swal loader
                            Swal.fire({
                                title: 'Loading...',
                                text: 'Please wait while data is being processed.',
                                allowOutsideClick: false,
                                didOpen: () => {
                                    Swal.showLoading();
                                }
                            });
                        },
                        success: function (response) {

                            //hide loader
                            document.getElementById("div0102Loader").style.display = "";
                            //hide loader

                            $('#table0102Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table0102Record = $("#table0102Record").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: true,
                                bInfo: false,
                                paging: true,
                                lengthChange: true,
                                pageLength: 25,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'AcctNo', },
                                    { data: 'AcctName' },
                                    { data: 'DraweeBankCodeName' },
                                    { data: 'Type' },
                                    { data: 'CheckNo' },
                                    { data: 'CheckDate' },
                                    { data: 'CheckAmt' },
                                    { data: 'DepositoryBankCodeName' },
                                    { data: 'Application' }
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0],
                                        orderable: false,
                                    }
                                    ,
                                    {
                                        targets: [2, 3, 9],
                                        className: 'tbody-nowrap-auto'
                                    },
                                    {
                                        targets: [7],
                                        className: 'dt-body-right',
                                        render: $.fn.dataTable.render.number(',', '.', 2)
                                    }
                                ],
                                orderCellsTop: true,
                                initComplete: function () {
                                    this.api().cells().every(function () {
                                        var cell = this.node();
                                        $(cell).attr('title', $(cell).text());
                                    });
                                }
                            });
                            //datatable

                            //search
                            $('#tbx0102Find').on('keyup', function () {
                                table0102Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div0102Loader").style.display = "none";
                            //hide loader

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //resolve
                            resolve();
                            // close Swal loader when everything is done
                            Swal.close();
                        }
                    });
                });
            };
        };
        function fn0102Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
            //access
            fnAccess('FIN090000', 'Save', function (response) {
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
                var table0102Record = $('#table0102Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table0102Record.$('.row-checkbox', { page: 'all' });

                // Check if atleast one
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        AcctNo: checkBox.getAttribute('data-kt-code'),
                        CheckNo: checkBox.getAttribute('data-kt-no')
                    }));
                if (checkedValues.length > 0) {
                    // Array
                    let ItemList = [];

                    // Loop
                    checkedValues.forEach(item => {

                        // Push
                        ItemList.push({
                            AcctNo: item.AcctNo,
                            CheckNo: item.CheckNo
                        });
                    });

                    let CheckSrs = ItemList.map(i =>
                        `${i.AcctNo}©${i.CheckNo}`
                    ).join('®');
                    PDC_Question(CheckSrs, Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
                function PDC_Question(CheckSrs, Btn) {
                    Swal.close(); // close loader before confirmation
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Current record/changes will be saved?</span>',
                        icon: 'question',
                        iconColor: '#009ef7',
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
                            // Show loader again while saving
                            Swal.fire({
                                title: 'Saving...',
                                html: 'Please wait',
                                allowOutsideClick: false,
                                allowEscapeKey: false,
                                didOpen: () => Swal.showLoading()
                            });
                            // Add Ok
                            $.ajax({
                                type: "POST",
                                url: "HNDAAD.ashx",
                                data: {
                                    'pFormCode': 'FIN090100',
                                    'pType': 'Cashiering Tools - New PDC Payment',
                                    'pCheckSrs': CheckSrs,
                                },
                                success: async function (response) {
                                    Swal.close();
                                    //alert
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    //load
                                    // Destroy the DataTable before reloading
                                    if ($.fn.DataTable.isDataTable('#table0102Record')) {
                                        var table = $('#table0102Record').DataTable();
                                        table.clear().destroy();
                                    }
                                    $('#table0102Record tbody').empty();
                                    $("#mdl0102PDC").modal("hide");
                                    if (window.opener && typeof window.opener.fn01Add === 'function') {
                                        window.opener.fn01Add();
                                    }
                                    // Disable the clicked button to avoid multiple clicks
                                    Btn.disabled = false;
                                    // Hide loading indication
                                    Btn.removeAttribute('data-kt-indicator');
                                },
                            });
                        } else {
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                };
            };
        };
        // PDC
        // Remittance
        function fn0101_FIN09RPT02() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Remittance'
                    },
                    beforeSend: function () {
                        // Show Swal loader
                        Swal.fire({
                            title: 'Loading...',
                            text: 'Please wait while data is being processed.',
                            allowOutsideClick: false,
                            didOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    success: function (response) {
                        //hide loader
                        document.getElementById("div0103Loader").style.display = "";
                        //hide loader

                        $('#table0103Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table0103Record = $("#table0103Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            rowId: 'rowId',
                            columns: [
                                { data: 'RmtCode' },
                                { data: 'BankName' },
                                { data: 'Date' },
                                { data: 'Amount' },

                                // CLASS DROPDOWN
                                {
                                    data: 'Class',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let selectId = `class_${meta.row}`;
                                            let dropdown = `
                                                    <select id="class_${rowId}" prm0103Class="${rowId}" data-dropdown-parent="#mdl0103Remittance" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ddl-class" style="width:100%">
                                                        <option value="">Select Class</option>
                                                    </select>`;


                                            return dropdown;
                                        }
                                        return data;
                                    },
                                    createdCell: function (cell, cellData, rowData, rowIndex, colIndex) {
                                        let rowId = rowData.rowId;
                                        let dropdown = $(cell).find('[prm0103Class="' + rowId + '"]');

                                        // Fetch data asynchronously
                                        $.ajax({
                                            type: 'GET',
                                            url: 'HNDAAD.ashx',
                                            data: {
                                                'pFormCode': 'FIN090100',
                                                'pType': 'Remittance Class'
                                            },
                                            success: function (response) {
                                                let options = response.map(item => `<option value="${item.Code}">${item.Description}</option>`).join('');
                                                dropdown.html(`<option value="">Select Class</option>` + options);

                                                dropdown.select2();
                                            },
                                            error: function () {
                                                dropdown.html('<option>Error loading options</option>');
                                            }
                                        });
                                    }
                                },

                                // PAYOR (hidden, will be updated by PayorName)
                                {
                                    data: 'Payor',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;

                                            let textbox = `
                                                    <input prm0103Payor="${rowId}" type="text" class="w-100 outline-none border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" readonly />
                                                `;
                                            return textbox || "";
                                        }
                                        return data;
                                    }
                                },

                                // PAYORNAME DROPDOWN
                                {
                                    data: 'PayorName',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let selectId = `payor_${meta.row}`;
                                            let dropdown = `
                                                    <select id="payor_${rowId}" prm0103PayorName="${rowId}" data-dropdown-parent="#mdl0103Remittance" data-kt-repeater="select2"  class="form-select form-select-sm form-select-border ddl-payorname" style="width:100%">
                                                        <option value="">Select Payor</option>
                                                    </select>`;
                                            return dropdown;
                                        }
                                        return data;
                                    }
                                },

                                // APPLICATION DROPDOWN
                                {
                                    data: 'Application',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let selectId = `app_${meta.row}`;
                                            let dropdown = `
                                                        <select id="application_${rowId}" prm0103Application="${rowId}" data-dropdown-parent="#mdl0103Remittance" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ddl-application" style="width:100%">
                                                            <option value="">Select Application</option>
                                                        </select>`;
                                            return dropdown;
                                        }
                                        return data;
                                    }
                                },

                                { data: 'Status' }
                            ],

                            columnDefs: [
                                {
                                    targets: [3],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                }
                            ],

                            drawCallback: function () {
                                // initialize select2
                                $('[data-kt-repeater="select2"]').select2({
                                    width: '100%'
                                });

                                // Class
                                $("#table0103Record").on("change", ".ddl-class", function () {
                                    let classVal = $(this).val();
                                    let rowId = $(this).attr("prm0103Class");
                                    let ddlPayor = $(`[prm0103PayorName=${rowId}]`);
                                    ddlPayor.html(`<option>Select Class</option>`);

                                    $.ajax({
                                        type: 'GET',
                                        url: 'HNDAAD.ashx',
                                        data: {
                                            'pFormCode': 'FIN090100',
                                            'pType': 'Remittance Payor',
                                            'pClass': classVal
                                        },
                                        success: function (response) {
                                            let options = response.map(item =>
                                                `<option value="${item.Code}" data-payor="${item.Code}">${item.Description}</option>`
                                            ).join('');
                                            ddlPayor.html(`<option value="">Select Payor</option>` + options);
                                        },
                                        error: function () {
                                            ddlPayor.html('<option>Error loading options</option>');
                                        }
                                    });
                                });

                                // Payor
                                $("#table0103Record").on("change", ".ddl-payorname", function () {
                                    let payorVal = $(this).val();
                                    let rowId = $(this).data("rowId");
                                    let tr = $(this).closest("tr");
                                    let tbxPayor = tr.find("[prm0103Payor]");
                                    tbxPayor.val(payorVal);
                                });

                                // Application
                                $("#table0103Record").on("change", ".ddl-class, .ddl-payorname", function () {
                                    let tr = $(this).closest("tr");
                                    let classVal = tr.find(".ddl-class").val();
                                    let payorVal = tr.find(".ddl-payorname").val();
                                    let ddlApplication = tr.find("[prm0103Application]");

                                    if (classVal && payorVal) {
                                        ddlApplication.html(`<option>Select Application</option>`);

                                        $.ajax({
                                            type: 'GET',
                                            url: 'HNDAAD.ashx',
                                            data: {
                                                'pFormCode': 'FIN090100',
                                                'pType': 'Remittance - Application'
                                            },
                                            success: function (response) {
                                                let options = response.map(item =>
                                                    `<option value="${item.Code}">${item.Description}</option>`
                                                ).join('');
                                                ddlApplication.html(`<option value="">Select Application</option>` + options);
                                            },
                                            error: function () {
                                                ddlApplication.html('<option>Error loading options</option>');
                                            }
                                        });
                                    } else {
                                        let tbxPayor = tr.find("[prm0103Payor]");
                                        tbxPayor.val('');
                                        // reset if one is missing
                                        ddlApplication.html('<option value="">Select Application</option>');
                                    }
                                });
                            },
                            initComplete: function () {
                                this.api().cells().every(function () {
                                    var cell = this.node();
                                    $(cell).attr('title', $(cell).text());
                                });
                            }
                        });
                        //datatable

                        //search
                        $('#tbx0103Find').on('keyup', function () {
                            table0103Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div0103Loader").style.display = "none";
                        //hide loader

                        // close Swal loader when everything is done
                        Swal.close();
                    }
                });
                //modal
                $('#mdl0103Remittance').modal('show');
            };
        };
        function fn0103Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
            //access
            fnAccess('FIN090000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn0103dd_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            async function fn0103dd_Ok_Await(Btn) {
                let table0103Record = $('#table0103Record').DataTable();
                var allRows = [];
                let cntr = 0;
                let hasError = false;

                table0103Record.rows().every(function () {
                    let rowData = this.data();
                    let tr = $(this.node());

                    let RmtCode = rowData.RmtCode || "";
                    let ClassCode = tr.find(".ddl-class").val() || "";
                    let AcctNo = tr.find("[prm0103Payor]").val() || "";
                    let AcctName = tr.find(".ddl-payorname option:selected").text() || "";
                    let PmtType = tr.find(".ddl-application").val() || "";

                    // Only proceed if all required fields are filled
                    if (RmtCode && ClassCode && AcctName && PmtType) {
                        allRows.push({
                            rowData: rowData,
                            tr: tr,
                            RmtCode: RmtCode,
                            ClassCode: ClassCode,
                            AcctNo: AcctNo,
                            AcctName: AcctName,
                            PmtType: PmtType
                        });
                    }
                });

                if (allRows.length === 0) {
                    fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                } else {
                    Add_Question();
                }

                async function Add_Question() {
                    const result = await Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Current record/changes will be saved?</span>',
                        icon: 'question',
                        iconColor: '#009ef7',
                        buttonsStyling: false,
                        showCancelButton: true,
                        confirmButtonText: "Yes",
                        cancelButtonText: 'Cancel',
                        customClass: {
                            confirmButton: 'btn btn-sm btn-info min-w-100px',
                            cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                        }
                    });

                    if (result.isConfirmed) {
                        for (let row of allRows) {
                            try {
                                await $.ajax({
                                    type: "POST",
                                    url: "HNDAAD.ashx",
                                    data: {
                                        pFormCode: "FIN090100",
                                        pType: "Cashiering Tools - Add Remittance",
                                        pRmtCode: row.RmtCode,
                                        pClassCode: row.ClassCode,
                                        pAcctNo: row.AcctNo,
                                        pAcctName: row.AcctName,
                                        pPmtType: row.PmtType
                                    }
                                });
                                row.rowData.Status = "Success";
                                table0103Record.row(row.tr).data(row.rowData).invalidate();

                                cntr++;
                            } catch (err) {
                                hasError = true;
                            }
                        }

                        // Final message after loop
                        if (cntr === 0) {
                            fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                            //Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        } else if (!hasError) {
                            fnAlertOnly('Record successfully saved!', 'success', 'btn btn-success');
                            $("#mdl0103Remittance").modal("hide");
                            //Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                }
            };
        };
        // Remittance
        // OR
        function fn0101_FIN09RPT03() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    OR();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function OR() {
                document.getElementById("ContentPlaceHolder1_hdnORMode").value = "DTL";
                fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value)
            };
        };
        function fn0104Refresh() {
            document.getElementById("ContentPlaceHolder1_hdnORMode").value = "DTL";
            fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value)
        };
        function fn0104Edit() {
            if (document.getElementById("ContentPlaceHolder1_hdnORMode").value == "DTL") {
                //access
                fnAccess('FIN090000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Edit_Dtl_Ok_Await("UPD");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
                //validate
                function Edit_Dtl_Ok_Await(pMode) {
                    document.getElementById("ContentPlaceHolder1_hdnORMode").value = pMode;
                    fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value);
                };
            } else if (document.getElementById("ContentPlaceHolder1_hdnORMode").value == "UPD") {
                //access
                fnAccess('FIN090000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields();
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
                function ValidateFields() {
                    if (document.getElementById("tbx0104ORNo").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0104SmallORNo").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Upd_Question();
                    }
                };
                //question
                function Upd_Question() {
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
                            if (document.getElementById('ContentPlaceHolder1_hdnORMode').value == "DTL") {
                                Edit_Dtl_Ok_Await();
                            } else if (document.getElementById('ContentPlaceHolder1_hdnORMode').value == "UPD") {
                                Validate_Upd();
                            }
                        }
                    });
                };
                //validate
                function Validate_Upd() {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090100',
                            'pType': 'Cashiering Tools - Update OR/SOR',
                            'pORNo': document.getElementById("tbx0104ORNo").value,
                            'pSORNo': document.getElementById("tbx0104SmallORNo").value
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            document.getElementById('ContentPlaceHolder1_hdnORMode').value = "DTL";
                            fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value);
                        }
                    });
                };
            };
        };
        function fn0104Delete() {
            if (document.getElementById("ContentPlaceHolder1_hdnORMode").value == "UPD") {
                Cancel_Upd_Question();
            };
            function Cancel_Upd_Question() {
                Swal.fire({
                    text: 'Cancel changes?',
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
                        document.getElementById('ContentPlaceHolder1_hdnORMode').value = "DTL"
                        fn0104LoadOR(document.getElementById('ContentPlaceHolder1_hdnORMode').value);
                    }
                });
            };
        };
        function fn0104LoadOR(pMode) {
            if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Get OR Settings',
                    },
                    success: function (response) {
                        fn04DisableButtons(false);
                        document.getElementById("i0104Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0104Edit").classList.remove("la-save");

                        document.getElementById("div0104Detail").style.display = "";
                        document.getElementById("div0104Update").style.display = "none";
                        document.getElementById("lbl0104User").innerText = response[0].User;
                        document.getElementById("lbl0104Branch").innerText = response[0].Branch;
                        document.getElementById("lbl0104ORNo").innerText = response[0].ORNo;
                        document.getElementById("lbl0104Location").innerText = response[0].Location;
                        document.getElementById("lbl0104SmallORNo").innerText = response[0].SORNo;
                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Get OR Settings',
                    },
                    success: function (response) {
                        fn04DisableButtons(true);
                        document.getElementById("btn0104Delete").classList.add("btn-delete");
                        document.getElementById("btn0104Delete").disabled = false;
                        document.getElementById("btn0104Edit").classList.add("btn-edit");
                        document.getElementById("btn0104Edit").disabled = false;
                        document.getElementById("i0104Edit").classList.remove("la-pencil-alt");
                        document.getElementById("i0104Edit").classList.add("la-save");

                        document.getElementById("div0104Detail").style.display = "none";
                        document.getElementById("div0104Update").style.display = "";
                        document.getElementById("tbx0104User").value = response[0].User;
                        document.getElementById("tbx0104Branch").value = response[0].Branch;
                        document.getElementById("tbx0104ORNo").value = response[0].ORNo;
                        document.getElementById("tbx0104Location").value = response[0].Location;
                        document.getElementById("tbx0104SmallORNo").value = response[0].SORNo;
                    },
                });
            }

            // modal
            $("#mdl01Tools").modal("hide");
            $("#mdl0104OR").modal("show");
        };
        function fn04DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0104Refresh").classList.remove("btn-view");
                document.getElementById("btn0104Delete").classList.remove("btn-delete");
                document.getElementById("btn0104Delete").classList.remove("d-none");
                document.getElementById("btn0104Edit").classList.remove("btn-edit");
            } else {
                document.getElementById("btn0104Refresh").classList.add("btn-view");
                document.getElementById("btn0104Delete").classList.add("btn-delete");
                document.getElementById("btn0104Delete").classList.add("d-none");
                document.getElementById("btn0104Edit").classList.add("btn-edit");
            }
            document.getElementById("btn0104Refresh").disabled = pValue;
            document.getElementById("btn0104Delete").disabled = pValue;
            document.getElementById("btn0104Edit").disabled = pValue;
        };
        // OR
        // OR Reversal
        function fn0101_FIN09RPT04() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                var table = $('#table0105Record').DataTable();
                if (table) {
                    table.clear().draw();
                };

                $('#mdl01Tools').modal('hide');
                $('#mdl0105Reversal').modal('show');
            };
        };
        var input_DocNo = document.getElementById("tbx0105Find");
        input_DocNo.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                FindORReversal(input_DocNo.value);
            }
        });
        function FindORReversal(Find) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'pFormCode': 'FIN090100',
                    'pType': 'Cashiering Tools - OR Reversal',
                    'pDocNo': Find
                },
                beforeSend: function () {
                    // Show Swal loader
                    Swal.fire({
                        title: 'Loading...',
                        text: 'Please wait while data is being processed.',
                        allowOutsideClick: false,
                        didOpen: () => {
                            Swal.showLoading();
                        }
                    });
                },
                success: function (response) {
                    //hide loader
                    document.getElementById("div0105Loader").style.display = "";
                    //hide loader

                    // Destroy old table safely if exists
                    if ($.fn.DataTable.isDataTable('#table0105Record')) {
                        $('#table0105Record').DataTable().clear().destroy();
                    };

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0105Record = $("#table0105Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'DocNo', },
                            { data: 'DocDate' },
                            { data: 'Payee' },
                            { data: 'DocAmount' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false,
                            }
                            ,
                            {
                                targets: [2],
                                className: 'tbody-nowrap-auto'
                            },
                            {
                                targets: [4],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            }
                        ],
                        orderCellsTop: true,
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        }
                    });
                    //datatable

                    //search
                    $('#tbx0105Find').on('keyup', function () {
                        table0105Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0105Loader").style.display = "none";
                    //hide loader

                    // close Swal loader when everything is done
                    Swal.close();
                }
            });
        };
        function fn0105Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
            //access
            fnAccess('FIN090000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn0105Add_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0105Add_Ok_Await(Btn) {
                var table0105Record = $('#table0105Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table0105Record.$('.row-checkbox', { page: 'all' });

                // Check if atleast one
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        AcctNo: checkBox.getAttribute('data-kt-no'),
                        DocNo: checkBox.getAttribute('data-kt-doc'),
                        DocDate: checkBox.getAttribute('data-kt-date')
                    }));
                if (checkedValues.length > 0) {
                    // Array
                    let ItemList = [];

                    // Loop
                    checkedValues.forEach(item => {
                        Swal.close(); // close loader before confirmation
                        Swal.fire({
                            title: '<span class="fs-6 fw-normal text-gray-700">Reverse current record?</span>',
                            icon: 'question',
                            iconColor: '#009ef7',
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
                                checkedValues.forEach(item => {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090100',
                                            'pType': 'Cashiering Tools - Reverse OR Record',
                                            'pDocNo': item.DocNo,
                                            'pDocDate': item.DocDate,
                                            'pAcctNo': item.AcctNo,
                                            'pReason': document.getElementById("tbx0105Reason").value
                                        },
                                        success: function (response) {
                                            //nothing
                                        }
                                    });
                                });
                                //alert
                                fnAlertOnly('Record successfully reversed.', 'success', 'btn btn-success');
                                //load
                                // Destroy the DataTable before reloading
                                var table = $('#table0105Record').DataTable();
                                table.clear().destroy();
                                $('#table0105Record tbody').empty();
                                document.getElementById("tbx0105Find").value = "";
                                document.getElementById("tbx0105Reason").value = "";
                                $("#mdl0105Reversal").modal("hide");
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            }
                        });
                    });

                } else {
                    Swal.close();
                    fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            };
        };
        // OR Reversal
        //tools

        //add
        function fn01FilterAdd() {
            $('#mdl01FilterAdd').modal('show');
        };
        function fn01FilterAdd_Ok(Btn) {
            if (document.getElementById("ddl01BranchAdd").options[document.getElementById("ddl01BranchAdd").selectedIndex].value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                FilterAdd_Ok();
                //function
                async function FilterAdd_Ok() {
                    await FilterAdd_Ok_Await(Btn);
                };
            }
            async function FilterAdd_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090000',
                            'pType': 'Get Record Add',
                            'pBranch': document.getElementById("ddl01BranchAdd").options[document.getElementById("ddl01BranchAdd").selectedIndex].value,
                        },
                        success: function (response) {
                            //hide loader
                            document.getElementById("div01ModalLoader").style.display = "";
                            //hide loader

                            $('#table01Add').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table01Add = $("#table01Add").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: true,
                                bInfo: false,
                                paging: true,
                                lengthChange: true,
                                pageLength: 25,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'CheckBox' },
                                    { data: 'TrxnNo' },
                                    { data: 'TrxnDate' },
                                    { data: 'PayorName' },
                                    { data: 'TotalAmount' },
                                    { data: 'Action' }],
                                rowId: 'rowId',
                                columnDefs: [{ targets: 0, className: 'tbody-nowrap-auto', orderable: false }, { targets: 1, className: 'tbody-nowrap-auto' }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto dt-body-right' }, { targets: 5, className: 'tbody-nowrap-auto', orderable: false }],
                                order: [[3, 'asc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx01ModalFind').on('keyup', function () {
                                table01Add.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div01ModalLoader").style.display = "none";
                            //hide loader

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //resolve
                            resolve();
                        },
                    });
                });
            };
        };
        function fn01Add() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add_Ok() {
                $('#ddl01BranchAdd').val('').trigger('change');
                document.getElementById("rb01SalesInvoice").checked = false;
                document.getElementById("rb01RegularOR").checked = false;
                document.getElementById("rb01SmallOR").checked = false;
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090000',
                        'pType': 'Get Record Add',
                        'pBranch': 'All',
                    },
                    success: function (response) {
                        //hide loader
                        document.getElementById("div01ModalLoader").style.display = "";
                        //hide loader

                        $('#table01Add').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table01Add = $("#table01Add").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'CheckBox' },
                                { data: 'TrxnNo' },
                                { data: 'TrxnDate' },
                                { data: 'PayorName' },
                                { data: 'TotalAmount' },
                                { data: 'Action' }],
                            rowId: 'rowId',
                            columnDefs: [{ targets: 0, className: 'tbody-nowrap-auto', orderable: false }, { targets: 1, className: 'tbody-nowrap-auto' }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto dt-body-right' }, { targets: 5, className: 'tbody-nowrap-auto', orderable: false }],
                            order: [[3, 'asc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01ModalFind').on('keyup', function () {
                            table01Add.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01ModalLoader").style.display = "none";
                        //hide loader
                    },
                });
                $('#mdl01Add').modal('show');
            };
        };
        async function fn01Add_Ok(TrxnNo) {
            //if exisit
            fnIfExist('calmardblive.dbo.ICR_Assessment', 'TransactionNumber', TrxnNo, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        fn01Add_Ok_Await();
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            }
            function fn01Add_Ok_Await() {
                if (document.getElementById("rb01SalesInvoice").checked == false && document.getElementById("rb01RegularOR").checked == false && document.getElementById("rb01SmallOR").checked == false) {
                    fnAlertOnly('Please select OR Type!', 'error', 'btn btn-danger');
                } else {
                    Add_Question();
                }
            };
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
                        //if exisit
                        fnIfExist('calmardblive.dbo.ICR_Assessment', 'TransactionNumber', TrxnNo, function (response) {
                            if (response[0].oReturn == "1") {
                                Access();
                            } else {
                                window.location.replace("MNU040100");
                            };
                        });
                        //access
                        function Access() {
                            fnAccess('FIN090000', 'Add', function (response) {
                                if (response[0].oReturn == "1") {
                                    let isRegularReceipt = document.getElementById("rb01SalesInvoice").checked ? 2 : document.getElementById("rb01RegularOR").checked ? 1 : 0;

                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Add Record',
                                            'pIsRegularOR': isRegularReceipt,
                                            'pBranch': document.getElementById("hdnBranchCode").value,
                                            'pTrxnNo': TrxnNo,
                                        },
                                        success: function (response) {
                                            if (response[0].oReturn != "") {
                                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                            } else {
                                                fnAlertOnly('Record successfully added.', 'success', 'btn btn-success');
                                                fn01Add();
                                                fn01Load();
                                            };
                                        },
                                    });
                                } else {
                                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                };
                            });
                        }
                    }
                });
            };
        };
        function fn01Delete() {
            checkedTrxnos = [];
            $("input[type='checkbox'][data-trxno]:checked").each(function () {
                checkedTrxnos.push($(this).attr("data-trxno"));
            });

            if (checkedTrxnos.length == 0) {
                fnAlertOnly('There are no record(s) selected!', 'error', 'btn btn-danger');
            } else {
                Swal.fire({
                    text: 'Remove record(s)?',
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
                        trxnoList = checkedTrxnos.join(",");
                        fnDelete('FIN090000', 'ICR_Assessment', trxnoList, function (response) {
                            fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                            fn01Add();
                        });
                    }
                });
            }
        };
        //add

        //delete
        function fn03Delete(ID) {
            //if exisit
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', ID, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            function Access() {
                //access
                fnAccess('FIN090000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(ID);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            }
            //validate
            function Validate(ID) {
                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //delete question
            function Delete_Question(ID) {
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
                        //if exisit
                        fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', ID, function (response) {
                            if (response[0].oReturn == "1") {
                                Access();
                            } else {
                                window.location.replace("MNU040100");
                            };
                        });
                        function Access() {
                            //access
                            fnAccess('FIN090000', 'Delete', function (response) {
                                if (response[0].oReturn == "1") {
                                    Validate(ID);
                                } else {
                                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                };
                            });
                        }
                        //validate
                        function Validate(ID) {
                            fnValidateRecord('ICR_PaymentHeader', ID, '', 'Delete', function (response) {
                                if (response[0].oReturn == "") {
                                    Delete_Ok(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        };
                    }
                });
            };
            //delete ok
            function Delete_Ok(ID) {
                fnDelete('FIN090000', 'ICR_PaymentHeader', ID, function (response) {
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Redraw("Delete", ID);
                });
            }
        };
        //delete

        //edit
        function fn04Edit(ID, Date, AcctNo) {
            //if exisit
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', ID, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN090000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(ID);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            }
            //validate
            function Validate(ID) {
                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Edit_Ok(ID) {
                window.open('FIN090100-UPD-' + ID + '-' + Date + '-' + AcctNo);
            };
        };
        //edit

        //post
        function fn05Post(ID) {
            //if exisit
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', ID, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN090000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(ID);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Post', function (response) {
                    if (response[0].oReturn == "") {
                        Post_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function Post_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Post record?</span>',
                    icon: 'question',
                    html: `<input id="tbx05Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx05Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                //if exisit
                                fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', ID, function (response) {
                                    if (response[0].oReturn == "1") {
                                        Access();
                                    } else {
                                        window.location.replace("MNU040100");
                                    };
                                });
                                //access
                                function Access() {
                                    fnAccess('FIN090000', 'Post', function (response) {
                                        if (response[0].oReturn == "1") {
                                            Validate(ID);
                                        } else {
                                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                        };
                                    });
                                };
                                //validate
                                function Validate(ID) {
                                    fnValidateRecord('ICR_PaymentHeader', ID, '', 'Post', function (response) {
                                        if (response[0].oReturn == "") {
                                            Post_Ok(ID);
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                };
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function Post_Ok(ID) {
                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Post', function (response) {
                    if (response[0].oReturn == "") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Post Record',
                                'pDocNo': ID,
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully posted.', 'success', 'btn btn-success');
                                fn01Redraw("Edit", ID);
                                //$.ajax({
                                //    type: "POST",
                                //    url: "HNDAAD.ashx",
                                //    data: {
                                //        'pFormCode': 'FIN090000',
                                //        'pType': 'Generate CI',
                                //        'pID': ID,
                                //    },
                                //    success: function (response) {
                                //        if (response.status === "success") {
                                //            window.open(response.viewUrl, '_blank');
                                //        } else {
                                //            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                //        }
                                //    }
                                //});
                            },
                        });
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
        };
        //post

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date
            });
            jQuery(function ($) {
                if (document.getElementById("IsPostBack01").value == "false") {
                    fn01Load();
                }
            });
        }
        //load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
