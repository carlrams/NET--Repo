<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM080000.aspx.vb" Inherits="NET.SCM080000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Stock Issuance</li>
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
						<img src="Assets/media/svg/apps/SCM080000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Stock Issuance</span>
						</h3>
					</div>
					<!--end::Title-->
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
                                <a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn01Filter();return false;">Filter</a>
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
                    <table id="table01Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					    <thead>
						    <tr class="fw-bold fs-7 text-gray-800">
							    <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                <th class="min-w-75px mw-75px fw-bold border-end">Trxn. No.</th>
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Posted"><i class='las la-check-circle fs-3'></i></span></th>
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Reversed"><i class='las la-times-circle fs-3'></i></span></th>
                                <th class="min-w-75px mw-75px fw-bold border-end">SI No.</th>
                                <th class="min-w-75px mw-75px fw-bold border-end">SI Date</th>
                                <th class="min-w-75px mw-75px fw-bold border-end">GP No.</th>
								<th class="min-w-150px w-50 fw-bold border-end">Requested By</th>
                                <th class="min-w-200px w-100 fw-bold border-end">Warehouse</th>
                                <th class="min-w-150px w-50 fw-bold border-end">Prepared By</th>
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
						<h5 class="modal-title">Fixed Asset - Filter record</h5>
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
                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
				            <input id="cbx01Posted" class="form-check-input" type="checkbox" value=""/>
				            <label class="form-check-label" for="cbx01Posted">
					            Posted
				            </label>
                         </div>
                        <select id="ddl01Warehouse" data-kt-repeater="select2" data-dropdown-parent="#mdl01Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Warehouse</option>
                        </select>
					</div>
                    <!--begin::Actions-->
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
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Filter-->
        
		<!--begin::Modal Cancel-->
		<div id="mdl02Cancel" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Stock Issuance - Cancel Record</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Date</span>
							<input id="tbx0201ReasonDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
                            <input id="hf0201pID" runat="server" type="hidden" value="" />
						</div>
					    <div class="input-group input-group-sm">
						    <span class="input-group-text min-w-150px required">Reason</span>
						    <input id="tbx0201Reason" type="text" class="form-control" maxlength="500" Placeholder="Reason" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0201Cancel_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0201Cancel_Ok(this); return false;">
                            <span class="indicator-label">
                                Save
                            </span>
                            <span class="indicator-progress">
                                Saving
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
		<!--begin::Modal Cancel-->

    </div>
	 <script src="Assets/js/SCM/SCM080000.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
