<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM060000.aspx.vb" Inherits="NET.SCM060000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Purchase Order</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<!--end::breadcrumb bar-->
		
		<!--begin::Card-->
        <div id="card01Content" class="card mb-5">
			<div class="card-header card-header-stretch border-bottom border-gray-200">
				<div class="d-flex align-items-center">
					<div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Purchase Order</span>
						</h3>
					</div>
				</div>
			</div>
            <div class="border-bottom border-gray-200 px-4 py-3 mb-2">
                <div class="d-flex flex-stack align-items-center">
                    <div class="d-flex align-items-center ms-5">
                        <div class="d-flex flex-stack">
                            <div id="div01ExportButton" class="d-none"></div>
                            <button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options">
                               <i class="las la-filter fs-3"></i>
                            </button>
                            <div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-2" data-kt-menu="true">
				                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn01Filter();return false;">Filter</a>
                                    <a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn01Export(); return false;">Export as Excel</a>
                                </div>
                            </div>
							<span class="bullet h-30px w-2px bg-secondary m-1"></span>
							<a href="#" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn01Add(); return false;"><i class="las la-plus fs-2"></i></a>
                        </div>
                    </div>
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
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="gridApi.setGridOption('quickFilterText', document.getElementById('tbx01Find').value);" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
			<!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                <div id="table01Record" style="height: 150vh;"></div>
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->
        
		<!--begin::Modal Filter-->
		<div id="mdl01Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Order - Filter record</h5>
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
                        <select id="ddl01Vendor" data-kt-repeater="select2" data-dropdown-parent="#mdl01Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Vendor</option>
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
						<h5 class="modal-title">Purchase Order - Cancel Record</h5>
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
					    <div class="input-group input-group-sm">
                            <textarea id="tbx0201Reason" class="form-control border border-danger" placeholder="Reason" rows="4"></textarea>
                            <input id="hf0201pID" runat="server" type="hidden" value="" />
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
        
		<!--begin::Modal Tools -->
		<div id="mdl03Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
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
                        <input id="hf03ID" runat="server" type="hidden" value="" />
					</div>
					<div class="modal-body scroll">
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-3 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Find Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Price)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Find</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Price</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">Update</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Purchaser)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-3 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS05();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(CP > PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS06();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(CP > SR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS07();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO > CP)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS08();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO > CCC)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-3 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS09();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO > SR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS10();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cancel Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS11();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cancel Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS12();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Re-Open</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-4 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS13();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Re-Printing</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-4 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS14();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Online Tagging</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Monitoring)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">PR</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT05();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">PO</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT06();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT07();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(CP)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT08();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Price</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">History</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT09();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">PO Movement</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">History</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT10();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Pending</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">PR</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT11();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Receiving</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">History</div>
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
		<!--begin::Modal Tools -->
        
		<!--begin::Modal Search record-->
		<div id="mdl010102YRFilter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Filter record</h5>
                        <div class="d-flex align-items-center">
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
                        <div class="row">
						    <div class="col-sm-12 col-md-12 col-lg-6">
							    <div class="input-group input-group-sm mb-2 border border-danger">
								    <input id="tbx010102PrevYR" type="text" onkeypress="return fnEnterKeyNumber(event,this.id);" maxlength="4" class="form-control" Placeholder="Previous Year" />
							    </div>
						    </div>
						    <div class="col-sm-12 col-md-12 col-lg-6">
							    <div class="input-group input-group-sm mb-2 border border-danger">
								    <input id="tbx010102CurrYR" type="text" onkeypress="return fnEnterKeyNumber(event,this.id);" maxlength="4" class="form-control" Placeholder="Current Year" />
							    </div>
						    </div>
                        </div>
					</div>
                    <div class="modal-footer">
                        <button id="btn010102Filter" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn010102Filter_Ok(this); return false;">
                            <span class="indicator-label">
                                Submit
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl010102Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Search record</h5>
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
                                    <input id="tbx010102FindTools" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010102FindTools').value);" />
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
                        <div id="table010102Record" style="width: 100%; height: 100%;"></div>
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
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl010103Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Search record</h5>
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
                                    <input id="tbx010103FindTools" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010103FindTools').value);" />
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
                        <div id="table010103Record" style="width: 100%; height: 100%;"></div>
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
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl010103Trxn" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered  mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">PR Transaction</h5>
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
                                    <input id="tbx010103FindTrxn" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010103TrxnLoader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010103Trxn" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-75px mw-75px fw-bold border-end">Type</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Date</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Post"><i class='las la-check-circle fs-3'></i></span></th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Cancel"><i class='las la-times-circle fs-3'></i></span></th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Prepared By</th>
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
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl010104Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Price Update</h5>
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
                                    <input id="tbx010104Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010104Find').value);" />
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
					    <div class="input-group input-group-sm mb-2 p-1 border border-danger">
						    <select id="ddl010104Vendor" data-kt-repeater="select2" data-dropdown-parent="#mdl010104Tools" class="form-select form-select-sm form-select-border" onchange="ddl010104Vendor_onchange(this);">
							    <option value="">Vendor</option>
						    </select>
					    </div>
                        <div id="table010104Record" style="width: 100%; height: 100%;"></div>
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
		<!--begin::Modal Search record-->
        		
		<!--begin::Modal Search record-->
		<div id="mdl010104Item" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-600px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Update Record</h5>
                        <div class="d-flex align-items-center">
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
						<div class="input-group input-group-sm mb-2 border border-danger">
							<span class="input-group-text min-w-150px">Item</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx010104Item" type="text" class="form-control form-control-sm border-0 m-0" readonly placeholder="Item" />
                                <input id="hf010104Vendor" runat="server" type="hidden" value="" />
                                <input id="hf010104ItemCode" runat="server" type="hidden" value="" />
                                <input id="hf010104OrigItemCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn010104Item(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
						    <input id="tbx010104UOM" type="text" class="form-control" Placeholder="UOM" maxlength="20" readonly />
                            <input id="hf010104UOMCode" runat="server" type="hidden" value="" />
					    </div>
					    <div class="input-group input-group-sm mb-2 border border-danger">
						    <span class="input-group-text min-w-150px">Price</span>
						    <input id="tbx010104Price" type="text" class="form-control" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumber(this);" Placeholder="Price" maxlength="21" />
					    </div>
					    <div class="input-group input-group-sm border border-danger">
						    <span class="input-group-text min-w-150px">Date</span>
						    <input id="tbx010104Date" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
                            <input id="hf010104OrigDate" runat="server" type="hidden" value="" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010104_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        		
		<!--begin::Modal Search record-->
		<div id="mdl010104FindItem" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Search Record</h5>
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
                                    <input id="tbx010104FindItem" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010104FindItem').value);" />
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
                        <div id="table010104FindItem" style="width: 100%; height: 100%;"></div>
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
		<!--begin::Modal Search record-->
        		
        <!--begin::Modal Search record-->
		<div id="mdl010105Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (Purchaser)</h5>
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
                                    <input id="tbx010105Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010105Find').value);" />
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
                        <div id="table010105Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010105_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        		
        <!--begin::Modal Search record-->
		<div id="mdl010106Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (CP > PO)</h5>
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
                                    <input id="tbx010106Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010106Find').value);" />
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
                        <div id="table010106Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010106_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010107Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (CP > SR)</h5>
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
                                    <input id="tbx010107Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010107Find').value);" />
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
                        <div id="table010107Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010107_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010108Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (PO > CP)</h5>
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
                                    <input id="tbx010108Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010108Find').value);" />
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
                        <div id="table010108Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010108_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010109Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (PO > CCC)</h5>
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
                                    <input id="tbx010109Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010109Find').value);" />
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
                        <div id="table010109Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010109_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010110Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (PO > SR)</h5>
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
                                    <input id="tbx010110Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010110Find').value);" />
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
                        <div id="table010110Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010110_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010111Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Cancel Item (PR)</h5>
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
                                    <input id="tbx010111Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010111Find').value);" />
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
                        <div id="table010111Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010111_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010112Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Cancel Item (PO)</h5>
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
                                    <input id="tbx010112Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010112Find').value);" />
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
                        <div id="table010112Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010112_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010113Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-500px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Re-Open (PO)</h5>
                        <div class="d-flex align-items-center">
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
					    <div class="input-group input-group-sm border border-danger">
                            <textarea id="tbx010113Reason" class="form-control border border-danger" placeholder="Reason" rows="4"></textarea>
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010113_Ok(this); return false;">
                             <span class="indicator-label">Re-Open PO</span>
                             <span class='indicator-progress'>Processing</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010114Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-500px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Re-Open (PO)</h5>
                        <div class="d-flex align-items-center">
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
					    <div class="input-group input-group-sm border border-danger">
                            <textarea id="tbx010114PersonalRemarks" class="form-control border border-danger" placeholder="Remarks" rows="4"></textarea>
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010114_Ok(this); return false;">
                             <span class="indicator-label">Re-Print PO</span>
                             <span class='indicator-progress'>Processing</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010115Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Online PO Monitoring</h5>
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
                                    <input id="tbx010115Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010115Find').value);" />
                                </div>
                                <div id="div010115ExportButton" class="d-none"></div>
                                <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                                   <i class="las la-bars fs-3"></i>
                                    <!--end::Svg Icon-->
                                </button>
                                <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
				                    <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn010115Filter();return false;">Filter</a>
                                        <a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn010115Export(); return false;">Export as Excel</a>
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
                        <div id="table010115Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->

		<!--begin::Modal Filter-->
		<div id="mdl010115Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Order - Filter record</h5>
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
					    <div class="row g-2">
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115PONoFrom" type="text" class="form-control" Placeholder="PO No. From" maxlength="13" />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115PONoTo" type="text" class="form-control" Placeholder="PO No. To" maxlength="13" />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115DateFrom" type="text" class="form-control" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115DateTo" type="text" class="form-control" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
                                </div>
                            </div>
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn010115Filter_Ok(this);return false;">
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
        
	</div>
    <!--content-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
    <script type="text/javascript">

        //variable
        let gridApi;
        let grid010104Record;
        let grid010105Record;
        //variable

        //format numeric

        function formatNumber(value) {
            return new Intl.NumberFormat('en-US', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }).format(value);
        };
        function fnEnterKeyNumber(event, inputId) {
            const key = event.key;
            // Allow only the following keys: numbers (0-9), decimal point, backspace, delete, arrow keys
            if (
                (key >= '0' && key <= '9') ||    // Allow 0-9
                key === '.' ||                   // Allow decimal point
                key === 'Backspace' ||           // Allow backspace
                key === 'ArrowLeft' ||           // Allow left arrow key
                key === 'ArrowRight' ||          // Allow right arrow key
                key === 'ArrowUp' ||             // Allow up arrow key
                key === 'ArrowDown' ||           // Allow down arrow key
                key === 'Delete'                 // Allow delete key
            ) {
                return true; // Allow the key press
            };
            // Prevent any other keys (including letters and special characters)
            event.preventDefault();
            return false;
        };
        function fnFormatNumber(input) {
            var num = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(num);
        };
        //format numeric

        //general
        function fn01Load() {
            fnAccess('SCM060000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060000',
                        'Type': 'Purchase Order - Get Record',
                        'pPosted': 0,
                        'pVendor': ''
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table01Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            onRowDoubleClicked: params => {
                                window.open(
                                    `SCM060100-DTL-${params.data.Code}`,
                                    '_blank'
                                );
                            },
                            suppressCellFocus: true,
                            suppressVerticalScroll: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    lockPosition: true,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "Code",
                                    field: "Code",
                                    lockPosition: true,
                                    width: 150,
                                    tooltipField: "Code",
                                    cellRenderer: params => {
                                        const link = document.createElement('a');
                                        link.href = "javascript:void(0)";
                                        link.innerText = params.value;
                                        link.onclick = function () {
                                            window.open(
                                                `SCM060100-DTL-${params.value}`,
                                                '_blank'
                                            );
                                        };
                                        return link;
                                    }
                                },
                                {
                                    headerName: "Lock",
                                    field: "Lock",
                                    sortable: false,
                                    resizable: false,
                                    lockPosition: true,
                                    width: 65,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "Post",
                                    field: "Post",
                                    sortable: false,
                                    resizable: false,
                                    lockPosition: true,
                                    width: 65,
                                    cellRenderer: params => params.value,
                                },
                                {
                                    headerName: "Rvrs",
                                    field: "Rvrs",
                                    sortable: false,
                                    resizable: false,
                                    lockPosition: true,
                                    width: 65,
                                    cellRenderer: params => params.value,
                                },
                                {
                                    headerName: "PONo",
                                    field: "PONo",
                                    width: 150,
                                    tooltipField: "PONo"
                                },
                                {
                                    headerName: "PODate",
                                    field: "PODate",
                                    width: 120,
                                    tooltipField: "PODate"
                                },
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    width: 120,
                                    tooltipField: "Status"
                                },
                                {
                                    headerName: "Vendor",
                                    field: "Vendor",
                                    tooltipField: "Vendor",
                                    width: 350
                                },
                                {
                                    headerName: "Dlvr. Mode",
                                    field: "DlvrMode",
                                    width: 150,
                                    tooltipField: "DlvrMode"
                                },
                                {
                                    headerName: "Dlvr. To",
                                    field: "DlvrTo",
                                    tooltipField: "DlvrTo",
                                    width: 320
                                },
                                {
                                    headerName: "Prepared By",
                                    field: "PreparedBy",
                                    width: 150,
                                    tooltipField: "PreparedBy"
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            onBodyScroll: function (event) {
                                document.querySelectorAll('.toggle-menu').forEach(menu => {
                                    menu.classList.add('d-none');
                                    const parent = toggleMenuMap.get(menu);
                                    if (parent) parent.appendChild(menu);
                                    toggleMenuMap.delete(menu);
                                });

                                // Remove AG Grid highlight
                                if (gridApi) gridApi.deselectAll();
                            }
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);
                    },
                });

                //filter
                document.getElementById("cbx01Posted").checked = false;
                ddl01Vendor('');
                $('#ddl01Vendor').val('').trigger('change');
                //filter
            };
        };
        function fn01Redraw(Action, ID) {
            if (Action === "Add" || Action === "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060000',
                        'Type': 'Purchase Order - Get Record : Redraw',
                        'pID': ID
                    },
                    success: function (response) {
                        const record = response[0];

                        if (!record) return;

                        if (Action === "Add") {
                            // Add new record at the top
                            const result = gridApi.applyTransaction({ add: [record], addIndex: 0 });

                            // Highlight and select
                            const node = result.add[0];
                            gridApi.flashCells({ rowNodes: [node] });
                            node.setSelected(true);
                            gridApi.ensureNodeVisible(node, 'top');

                        } else if (Action === "Edit") {
                            // Update existing record and temporarily move to top
                            let targetNode = null;

                            gridApi.forEachNode(node => {
                                if (node.data.Code === record.Code) {
                                    node.setData(record);
                                    targetNode = node;
                                }
                            });

                            if (targetNode) {
                                // Move it to top temporarily
                                const currentData = [];
                                gridApi.forEachNodeAfterFilter(node => currentData.push(node.data));

                                // Remove + re-add to top
                                gridApi.applyTransaction({ remove: [targetNode.data] });
                                gridApi.applyTransaction({ add: [record], addIndex: 0 });

                                const topNode = gridApi.getDisplayedRowAtIndex(0);
                                gridApi.flashCells({ rowNodes: [topNode] });
                                topNode.setSelected(true);
                                gridApi.ensureNodeVisible(topNode, 'top');

                            }
                        }
                    }
                });
            } else {
                // Remove record
                gridApi.forEachNode(function (node) {
                    if (node.data.Code === ID || node.data.ID === ID) {
                        gridApi.applyTransaction({ remove: [node.data] });
                    }
                });
            };
        };
        function fn0103Redraw(Action, pItemCode, pVendor, pDate) {
            if (!grid010104Record) return;

            if (Action === "Add" || Action === "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Update Item Price : Redraw',
                        'pItemCode': pItemCode,
                        'pVendor': pVendor,
                        'pDate': pDate
                    },
                    success: function (response) {
                        const record = response[0];
                        if (!record) return;

                        const newRecord = { ...record }; // shallow clone

                        if (Action === "Add" || Action === "Edit") {
                            // Remove old row if exists (for Edit)
                            grid010104Record.forEachNode(function (node) {
                                if (node.data.ItemCode === pItemCode &&
                                    node.data.Vendor === pVendor &&
                                    node.data.Date === pDate) {
                                    grid010104Record.applyTransaction({ remove: [node.data] });
                                }
                            });

                            // Add new/updated record at top
                            const result = grid010104Record.applyTransaction({
                                add: [newRecord],
                                addIndex: 0
                            });

                            const node = result.add[0];
                            if (node) {
                                grid010104Record.flashCells({ rowNodes: [node] });
                                node.setSelected(true);
                                grid010104Record.ensureNodeVisible(node, 'top');
                            }
                        }
                    }
                });
            } else if (Action === "Delete") {
                // Remove record
                grid010104Record.forEachNode(function (node) {
                    if (node.data.ItemCode === pItemCode &&
                        node.data.Vendor === pVendor &&
                        node.data.Date === pDate) {
                        grid010104Record.applyTransaction({ remove: [node.data] });
                    }
                });
            }
        };

        // Store the original parent nodes safely (DOM reference, not string)
        const toggleMenuMap = new WeakMap();
        function fn01Toggle(button, event) {
            if (event) {
                event.preventDefault();
                event.stopPropagation();
            }

            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            const rowElement = button.closest('.ag-row');
            if (rowElement) {
                const rowIndex = parseInt(rowElement.getAttribute('row-index'), 10);
                const rowNode = gridApi.getDisplayedRowAtIndex(rowIndex);
                if (rowNode) {
                    gridApi.deselectAll(); 
                    rowNode.setSelected(true);
                }
            }

            // Hide any other open menus first
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) {
                    menu.classList.add('d-none');
                    const parent = toggleMenuMap.get(menu);
                    if (parent) parent.appendChild(menu);
                    toggleMenuMap.delete(menu);
                }
            });

            if (toggleMenu) {
                const isVisible = !toggleMenu.classList.contains('d-none');
                toggleMenu.classList.toggle('d-none');

                if (!isVisible) {
                    // Move to body
                    toggleMenuMap.set(toggleMenu, wrapper);
                    document.body.appendChild(toggleMenu);

                    const rect = button.getBoundingClientRect();
                    const offsetX = 40; // horizontal offset
                    toggleMenu.style.position = 'absolute';
                    toggleMenu.style.left = `${rect.left + window.scrollX + offsetX}px`;
                    toggleMenu.style.top = `${rect.top + window.scrollY + (rect.height / 2) - (toggleMenu.offsetHeight / 2)}px`;
                    toggleMenu.style.zIndex = '9999';

                    // Close when clicking outside
                    const outsideClickListener = (ev) => {
                        if (!toggleMenu.contains(ev.target) && ev.target !== button) {
                            toggleMenu.classList.add('d-none');
                            const parent = toggleMenuMap.get(toggleMenu);
                            if (parent) parent.appendChild(toggleMenu);
                            toggleMenuMap.delete(toggleMenu);

                            // Remove highlight when menu closes
                            gridApi.clearFocusedCell();
                            document.removeEventListener('click', outsideClickListener);
                        }
                    };

                    setTimeout(() => document.addEventListener('click', outsideClickListener), 0);
                } else {
                    const parent = toggleMenuMap.get(toggleMenu);
                    if (parent) parent.appendChild(toggleMenu);
                    toggleMenuMap.delete(toggleMenu);
                }
            }
        }
        function fn02Toggle(button, event) {
            if (event) {
                event.preventDefault();
                event.stopPropagation();
            }

            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            const rowElement = button.closest('.ag-row');
            if (rowElement) {
                const rowIndex = parseInt(rowElement.getAttribute('row-index'), 10);
                const rowNode = gridApi.getDisplayedRowAtIndex(rowIndex);
                if (rowNode) {
                    gridApi.deselectAll();
                    rowNode.setSelected(true);
                }
            }

            // Hide any other open menus first
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) {
                    menu.classList.add('d-none');
                    const parent = toggleMenuMap.get(menu);
                    if (parent) parent.appendChild(menu);
                    toggleMenuMap.delete(menu);
                }
            });

            if (toggleMenu) {
                const isVisible = !toggleMenu.classList.contains('d-none');
                toggleMenu.classList.toggle('d-none');

                if (!isVisible) {
                    // Move to body
                    toggleMenuMap.set(toggleMenu, wrapper);
                    document.body.appendChild(toggleMenu);

                    const rect = button.getBoundingClientRect();
                    const offsetX = 40; // horizontal offset
                    toggleMenu.style.position = 'absolute';
                    toggleMenu.style.left = `${rect.left + window.scrollX + offsetX}px`;
                    toggleMenu.style.top = `${rect.top + window.scrollY + (rect.height / 2) - (toggleMenu.offsetHeight / 2)}px`;
                    toggleMenu.style.zIndex = '9999';

                    // Close when clicking outside
                    const outsideClickListener = (ev) => {
                        if (!toggleMenu.contains(ev.target) && ev.target !== button) {
                            toggleMenu.classList.add('d-none');
                            const parent = toggleMenuMap.get(toggleMenu);
                            if (parent) parent.appendChild(toggleMenu);
                            toggleMenuMap.delete(toggleMenu);

                            // Remove highlight when menu closes
                            gridApi.clearFocusedCell();
                            document.removeEventListener('click', outsideClickListener);
                        }
                    };

                    setTimeout(() => document.addEventListener('click', outsideClickListener), 0);
                } else {
                    const parent = toggleMenuMap.get(toggleMenu);
                    if (parent) parent.appendChild(toggleMenu);
                    toggleMenuMap.delete(toggleMenu);
                }
            }
        }
        //resize
        window.addEventListener('resize', () => {
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                menu.classList.add('d-none');
                const parent = toggleMenuMap.get(menu);
                if (parent) parent.appendChild(menu);
                toggleMenuMap.delete(menu);
            });
            // Remove AG Grid highlight
            if (gridApi) gridApi.deselectAll();
        });
        //scroll
        window.addEventListener('scroll', () => {
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                menu.classList.add('d-none');
                const parent = toggleMenuMap.get(menu);
                if (parent) parent.appendChild(menu);
                toggleMenuMap.delete(menu);
            });

            // Remove AG Grid highlight
            if (gridApi) gridApi.deselectAll();
        });
        //disable
        function fn01DisableToggle() {
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                menu.classList.add('d-none');
                const parent = toggleMenuMap.get(menu);
                if (parent) parent.appendChild(menu);
                toggleMenuMap.delete(menu);
            });

            // Remove AG Grid highlight
            if (gridApi) gridApi.deselectAll();
        };
        function ddl01Vendor(ID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM070100',
                    'Type': 'Get Record',
                    'pTblName': 'Mstr_Vendor',
                    'pPlaceHolder': 'Vendor',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl01Vendor").html(s);
                    $('#ddl01Vendor').val(ID).trigger('change');
                },
            });
        };
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
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060000',
                            'Type': 'Purchase Order - Get Record',
                            'pPosted': document.getElementById("cbx01Posted").checked,
                            'pVendor': document.getElementById("ddl01Vendor").options[document.getElementById("ddl01Vendor").selectedIndex].value,
                        },
                        success: function (response) {

                            let gridDiv = document.querySelector('#table01Record');
                            let gridOptions;

                            // Destroy old grid if exists
                            gridDiv.innerHTML = "";

                            gridOptions = {
                                onRowDoubleClicked: params => {
                                    window.open(
                                        `SCM060100-DTL-${params.data.Code}`,
                                        '_blank'
                                    );
                                },
                                suppressCellFocus: true,
                                suppressVerticalScroll: true,
                                enableCellTextSelection: true,
                                rowSelection: 'single',
                                //popupParent: document.body,
                                loading: false,
                                columnDefs: [
                                    {
                                        headerName: "Action",
                                        field: "Action",
                                        sortable: false,
                                        resizable: false,
                                        lockPosition: true,
                                        width: 75,
                                        cellRenderer: params => params.value
                                    },
                                    {
                                        headerName: "Code",
                                        field: "Code",
                                        lockPosition: true,
                                        width: 150,
                                        tooltipField: "Code",
                                        cellRenderer: params => {
                                            const link = document.createElement('a');
                                            link.href = "javascript:void(0)";
                                            link.innerText = params.value;
                                            link.onclick = function () {
                                                window.open(
                                                    `SCM060100-DTL-${params.value}`,
                                                    '_blank'
                                                );
                                            };
                                            return link;
                                        }
                                    },
                                    {
                                        headerName: "Lock",
                                        field: "Lock",
                                        sortable: false,
                                        resizable: false,
                                        lockPosition: true,
                                        width: 65,
                                        cellRenderer: params => params.value
                                    },
                                    {
                                        headerName: "Post",
                                        field: "Post",
                                        sortable: false,
                                        resizable: false,
                                        lockPosition: true,
                                        width: 65,
                                        cellRenderer: params => params.value,
                                    },
                                    {
                                        headerName: "Rvrs",
                                        field: "Rvrs",
                                        sortable: false,
                                        resizable: false,
                                        lockPosition: true,
                                        width: 65,
                                        cellRenderer: params => params.value,
                                    },
                                    {
                                        headerName: "PONo",
                                        field: "PONo",
                                        width: 150,
                                        tooltipField: "PONo"
                                    },
                                    {
                                        headerName: "PODate",
                                        field: "PODate",
                                        width: 120,
                                        tooltipField: "PODate"
                                    },
                                    {
                                        headerName: "Status",
                                        field: "Status",
                                        width: 120,
                                        tooltipField: "Status"
                                    },
                                    {
                                        headerName: "Vendor",
                                        field: "Vendor",
                                        tooltipField: "Vendor",
                                        width: 350
                                    },
                                    {
                                        headerName: "Dlvr. Mode",
                                        field: "DlvrMode",
                                        width: 150,
                                        tooltipField: "DlvrMode"
                                    },
                                    {
                                        headerName: "Dlvr. To",
                                        field: "DlvrTo",
                                        tooltipField: "DlvrTo",
                                        width: 320
                                    },
                                    {
                                        headerName: "Prepared By",
                                        field: "PreparedBy",
                                        width: 150,
                                        tooltipField: "PreparedBy"
                                    },
                                ],
                                rowData: response,
                                pagination: false,
                                onBodyScroll: function (event) {
                                    document.querySelectorAll('.toggle-menu').forEach(menu => {
                                        menu.classList.add('d-none');
                                        const parent = toggleMenuMap.get(menu);
                                        if (parent) parent.appendChild(menu);
                                        toggleMenuMap.delete(menu);
                                    });

                                    // Remove AG Grid highlight
                                    if (gridApi) gridApi.deselectAll();
                                }
                            };

                            gridApi = agGrid.createGrid(gridDiv, gridOptions);

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            document.getElementById("cbx01Posted").checked = false;
                            ddl01Vendor('');
                            $('#ddl01Vendor').val('').trigger('change');
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

        //export
        function fn01Export() {
            if (gridApi) {
                gridApi.exportDataAsCsv({
                    fileName: 'Purhase Order.csv',
                    columnKeys: ['Code', 'PONo', 'PODate', 'Status', 'Vendor', 'DlvrMode', 'DlvrTo', 'PreparedBy']
                });
            }
        };
        //export

        //add
        function fn01Add() {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add_Ok() {
                window.open('SCM060100-ADD-000000000000');
            };
        };
        //add

        //delete
        function fn03Delete(ID) {
            //access
            fnAccess('SCM060000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Delete_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Delete record?</span>',
                    icon: 'question',
                    html: `<input id="tbx03Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx03Password");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                        fnValidatePassword(document.getElementById("tbx03Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //delete ok
            function Delete_Ok(ID) {
                fnDelete('SCM060000', 'Trxn_POHdr', ID, function (response) {
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Redraw("Delete", ID);
                });
            };
        };
        //delete

        //edit
        function fn04Edit(ID) {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Edit_Ok(ID) {
                window.open('SCM060100-UPD-' + ID);
            };
        };
        //edit

        //lock
        function fn05Lock(ID) {
            //access
            fnAccess('SCM060000', 'Lock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else if (response[0].oReturn == "0") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //lock question
            function Lock_Question(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Lock Validation (Header)',
                        'pID': ID
                    },
                    success: function (response) {
                        if (response[0].Vendor == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].Warehouse == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].PODate == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].DlvrSched == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].PmtMode == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].Terms == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].VAT == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else if (response[0].EWT == "") {
                            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        } else {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM060100',
                                    'Type': 'Purchase Order - Lock Status'
                                },
                                success: function (response) {
                                    if (response[0].oLock == "1") {
                                        Swal.fire({
                                            title: '<span class="fs-6 fw-normal text-gray-700">Lock record w. Canvass?</span>',
                                            icon: 'question',
                                            html: `<input id="tbx0101LockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                                            iconColor: '#009ef7',
                                            buttonsStyling: false,
                                            showCancelButton: true,
                                            showDenyButton: true,
                                            confirmButtonText: "Yes",
                                            denyButtonText: "No",
                                            cancelButtonText: 'Cancel',
                                            customClass: {
                                                confirmButton: 'btn btn-sm btn-info min-w-100px',
                                                denyButton: 'btn btn-sm btn-warning min-w-100px',
                                                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                                            }
                                        }).then((result) => {
                                            if (result.isConfirmed) {
                                                fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                                                    if (response[0].oReturn == "") {
                                                        fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                                                            if (response[0].oReturn == "") {
                                                                Lock_Ok(ID, true);
                                                            } else {
                                                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                            };
                                                        });
                                                    } else {
                                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                    };
                                                });
                                            } else if (result.isDenied) {
                                                fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                                                    if (response[0].oReturn == "") {
                                                        fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                                                            if (response[0].oReturn == "") {
                                                                Lock_Ok(ID, false);
                                                            } else {
                                                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                            };
                                                        });
                                                    } else {
                                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                    };
                                                });
                                            };
                                        });
                                    } else {
                                        Swal.fire({
                                            title: '<span class="fs-6 fw-normal text-gray-700">Set status for Locking?</span>',
                                            icon: 'question',
                                            html: `<input id="tbx0101LockStatusPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                                            didOpen: () => {
                                                const input = document.getElementById("tbx0101LockStatusPassword");
                                                input.focus();
                                                input.addEventListener("keydown", function (e) {
                                                    if (e.key === "Enter") {
                                                        Swal.clickConfirm();
                                                    };
                                                });
                                            },
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
                                                fnValidatePassword(document.getElementById("tbx0101LockStatusPassword").value, function (response) {
                                                    if (response[0].oReturn == "") {
                                                        fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                                                            if (response[0].oReturn == "") {
                                                                Lock_Status(ID);
                                                            } else {
                                                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                            };
                                                        });
                                                    } else {
                                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                    };
                                                });
                                            }
                                        });
                                    };
                                }
                            });
                        }
                    }
                });
            };
            //lock ok
            function Lock_Ok(ID, Mode) {
                if (Mode) {
                    fnLock('Lock', 'Trxn_POHdr(wCanvass)', ID, function (response) {
                        fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                    });
                } else {
                    fnLock('Lock', 'Trxn_POHdr', ID, function (response) {
                        fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                    });
                };
            }
            //lock status
            function Lock_Status(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Lock Change Status',
                        'pID': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                    }
                });
            };
        };
        //lock

        //unlock
        function fn06Unlock(ID) {
            //access
            fnAccess('SCM060000', 'Unlock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Unlock', function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //unlock question
            function Unlock_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Unlock record?</span>',
                    icon: 'question',
                    html: `<input id="tbx06Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx06Password");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                        fnValidatePassword(document.getElementById("tbx06Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Unlock_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'Trxn_POHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                });
            }
        };
        //unlock

        //post
        function fn07Post(ID) {
            //access
            fnAccess('SCM060000', 'Post', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Post', function (response) {
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
                    html: `<input id="tbx07Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx07Password");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                        fnValidatePassword(document.getElementById("tbx07Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Post_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function Post_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'Type': "Post",
                        'pRecType': "Purchase Order",
                        'pTblCode': ID,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully posted.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                    },
                });
            }
        };
        //post

        //rvrs
        function fn08Rvrs(ID) {
            //access
            fnAccess('SCM060000', 'Unpost', function (response) {
                if (response[0].oReturn == "1") {
                    wAccess_Cancel(ID);
                } else {
                    woAccess_Cancel(ID);
                };
            });
            //with access - validate
            function wAccess_Cancel(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        wCancel_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function wCancel_Ok(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Cancel record?</span>',
                    icon: 'question',
                    html: `<input id="tbx08Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx08Password");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                        fnValidatePassword(document.getElementById("tbx08Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Direct_Cancel(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    };
                });
            };
            function Direct_Cancel(ID) { 
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Direct Cancel Record',
                        'pID': ID
                    },
                    success: function (response) {
                        //cancel
                        fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                        //modal
                        $('#mdl02Cancel').modal('hide');
                    },
                });
            };

            //without access - validate
            function woAccess_Cancel(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        woCancel_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function woCancel_Ok(ID) {
                document.getElementById("ContentPlaceHolder1_hf0201pID").value = ID;
                document.getElementById("tbx0201Reason").value = "";
                $('#mdl02Cancel').modal('show');
            };
        };
        function fn0201Cancel_Ok(Btn) {
            //if exists
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf0201pID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Cancel_Ok();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            async function Cancel_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn0201Cancel_Ok_Await(Btn);
            }
            function fn0201Cancel_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx0201Reason").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        //Modal
                        $('#mdl02Cancel').modal('hide');
                        //Cancel question
                        Cancel_Question();
                    }
                    function Cancel_Question() {
                        Swal.fire({
                            title: '<span class="fs-6 fw-normal text-gray-700">Set status for Cancellation?</span>',
                            icon: 'question',
                            html: `<input id="tbx08Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                            didOpen: () => {
                                const input = document.getElementById("tbx08Password");
                                input.focus();
                                input.addEventListener("keydown", function (e) {
                                    if (e.key === "Enter") {
                                        Swal.clickConfirm();
                                    };
                                });
                            },
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
                                fnValidatePassword(document.getElementById("tbx08Password").value, function (response) {
                                    if (response[0].oReturn == "") {
                                        Add_Cancel_Await();
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        //Modal
                                        $('#mdl02Cancel').modal('show');
                                    };
                                });
                            } else {
                                $('#mdl02Cancel').modal('show');
                            }
                        });
                    };
                    //add
                    function Add_Cancel_Await() {
                        // Do Cancellation
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Cancel Record (PO)',
                                'pID': document.getElementById('ContentPlaceHolder1_hf0201pID').value,
                                'pRemarks': document.getElementById("tbx0201Reason").value
                            },
                            success: function (response) {
                                //cancel
                                fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                                fn01Redraw("Edit", document.getElementById('ContentPlaceHolder1_hf0201pID').value);
                                document.getElementById("ContentPlaceHolder1_hf0201pID").value = "";
                                document.getElementById("tbx0201Reason").value = "";
                                //modal
                                $('#mdl02Cancel').modal('hide');
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
        };
        //rvrs

        //tools
        function fn09Tools(ID) {
            document.getElementById("ContentPlaceHolder1_hf03ID").value = ID;
            //modal
            $("#mdl03Tools").modal("show");
        };

        function fn010101_SCM03TLS01() {
            $('#mdl010102YRFilter').modal('show');
        };
        function fn010102Filter_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            if (document.getElementById("tbx010102PrevYR").value == "") {
                fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } else if (document.getElementById("tbx010102CurrYR").value == "") {
                fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } else if (document.getElementById("tbx010102PrevYR").value > document.getElementById("tbx010102CurrYR").value) {
                fnAlertOnly('Incorrect Format!', 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } else {
                Filter_Ok();
            };
            //function
            async function Filter_Ok() {
                await Filter_Ok_Await(Btn);
            };
            async function Filter_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Get Item Price',
                            'pPrevYR': document.getElementById("tbx010102PrevYR").value,
                            'pCurrYR': document.getElementById("tbx010102CurrYR").value,
                        },
                        success: function (response) {

                            let gridDiv = document.querySelector('#table010102Record');
                            let gridOptions;

                            // Destroy old grid if exists
                            gridDiv.innerHTML = "";

                            gridOptions = {
                                suppressCellFocus: true,
                                suppressVerticalScroll: true,
                                enableCellTextSelection: true,
                                rowSelection: 'single',
                                //popupParent: document.body,
                                loading: false,
                                columnDefs: [
                                    {
                                        headerName: "Code",
                                        field: "ItemCode",
                                        width: 150,
                                        tooltipField: "ItemCode"
                                    },
                                    {
                                        headerName: "Lock",
                                        field: "Lock",
                                        resizable: false,
                                        width: 65,
                                        cellRenderer: params => params.value
                                    },
                                    {
                                        headerName: "Item",
                                        field: "ItemName",
                                        tooltipField: "ItemName",
                                        flex: 1
                                    },
                                    {
                                        headerName: "UOM",
                                        field: "UMName",
                                        width: 75,
                                        tooltipField: "UMName"
                                    },
                                    {
                                        headerName: "Cost",
                                        field: "Cost",
                                        width: 150,
                                        tooltipField: "Cost",
                                        cellClass: "text-end",
                                        valueFormatter: params => {
                                            if (params.value == null || params.value === "") return "";
                                            return Number(params.value).toLocaleString("en-US", {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            });
                                        },
                                    },
                                    {
                                        headerName: "Canvass",
                                        field: "Canvass",
                                        width: 150,
                                        tooltipField: "Canvass",
                                        cellClass: "text-end",
                                        valueFormatter: params => {
                                            if (params.value == null || params.value === "") return "";
                                            return Number(params.value).toLocaleString("en-US", {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            });
                                        },
                                    },
                                    {
                                        headerName: "Date Encoded",
                                        field: "UpdatedDate",
                                        width: 150,
                                        tooltipField: "UpdatedDate"
                                    },
                                    {
                                        headerName: "Vendor",
                                        field: "Vendor",
                                        flex: 1,
                                        tooltipField: "Vendor"
                                    },
                                ],
                                rowData: response,
                                pagination: false,
                                paginationPageSize: 25
                            };
                            gridApi = agGrid.createGrid(gridDiv, gridOptions);
                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            $('#mdl010102YRFilter').modal('hide');
                            $('#mdl010102Tools').modal('show');
                            document.getElementById("tbx010102PrevYR").value = "";
                            document.getElementById("tbx010102CurrYR").value = "";
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
        }
        function fn010101_SCM03TLS02() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Purchase Order - Find PR',
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
                    let gridDiv = document.querySelector('#table010103Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";


                    gridOptions = {
                        suppressCellFocus: true,
                        enableCellTextSelection: true,
                        rowSelection: 'single',
                        //popupParent: document.body,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action",
                                field: "Action",
                                sortable: false,
                                resizable: false,
                                width: 75,
                                cellRenderer: params => params.value
                            },
                            {
                                headerName: "PR No.",
                                field: "PRNo",
                                width: 150,
                                tooltipField: "PRNo"
                            },
                            {
                                headerName: "Date Required",
                                field: "DateRequired",
                                width: 120,
                                tooltipField: "DateRequired"
                            },
                            {
                                headerName: "Purchase Type",
                                field: "PurchaseType",
                                width: 150,
                                tooltipField: "PurchaseType"
                            },
                            {
                                headerName: "Project",
                                field: "Project",
                                width: 150,
                                tooltipField: "Project"
                            },
                            {
                                headerName: "Remarks",
                                field: "Remarks",
                                tooltipField: "Remarks",
                                flex: 1
                            },
                            {
                                headerName: "Requestor",
                                field: "Requestor",
                                flex: 1,
                                tooltipField: "Requestor"
                            }
                        ],
                        rowData: response,
                        pagination: false,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                    //close 
                    Swal.close();
                    //modal
                    $('#mdl010103Tools').modal('show');
                },
            });
        };
        function fn010103View(pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Purchase Order - PR Trxn',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010103TrxnLoader").style.display = "";
                    //display loader

                    $('#table010103Trxn').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010103Trxn = $("#table010103Trxn").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        paging: false,
                        lengthChange: true,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Type' },
                            { data: 'No' },
                            { data: 'Date' },
                            { data: 'Post' },
                            { data: 'Rvrs' },
                            { data: 'PreparedBy' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0, 1, 2, 3, 4, 5, 6], orderable: false
                            },
                            {
                                targets: 6, className: 'tbody-nowrap-auto'
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
                    $('#tbx010103FindTrxn').on('keyup', function () {
                        table010103Trxn.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010103TrxnLoader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl010103Trxn').modal('show');
                },
            });
        };
        function fn010103ViewTrxn(pID, pCode, pType) {
            //access
            fnAccess('SCM060000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Preview Report',
                            'pID': pID,
                            'pCode': pCode,
                            'pType': pType
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        }
        function fn010101_SCM03TLS03() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    ddl010104Vendor('');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function ddl010104Vendor(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Vendor',
                        'pPlaceHolder': 'Vendor',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl010104Vendor").html(s);
                        $('#ddl010104Vendor').val(ID).trigger('change');
                        //reset
                        document.getElementById("table010104Record").innerHTML = "";
                        //modal
                        $("#mdl010104Tools").modal("show");
                    },
                });
            };
        };
        function ddl010104Vendor_onchange(ddl010104Vendor) {
            if (ddl010104Vendor.options[ddl010104Vendor.selectedIndex].value != "") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Price Update',
                        'pVendor': ddl010104Vendor.options[ddl010104Vendor.selectedIndex].value
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010104Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "ItemName",
                                    field: "ItemName",
                                    flex: 1,
                                    tooltipField: "ItemName"
                                },
                                {
                                    headerName: "UOM",
                                    field: "UMName",
                                    width: 75,
                                    tooltipField: "UMName"
                                },
                                {
                                    headerName: "Price",
                                    field: "Price",
                                    width: 150,
                                    tooltipField: "Price",
                                    cellClass: "text-end",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                },
                                {
                                    headerName: "Project",
                                    field: "Project",
                                    width: 150,
                                    tooltipField: "Project"
                                },
                                {
                                    headerName: "Date",
                                    field: "Date",
                                    tooltipField: "Date",
                                    width: 120
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25,
                            onBodyScroll: function (event) {
                                document.querySelectorAll('.toggle-menu').forEach(menu => {
                                    menu.classList.add('d-none');
                                    const parent = toggleMenuMap.get(menu);
                                    if (parent) parent.appendChild(menu);
                                    toggleMenuMap.delete(menu);
                                });

                                // Remove AG Grid highlight
                                if (gridApi) gridApi.deselectAll();
                            }
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        if (!grid010104Record) {
                            grid010104Record = gridApi;
                        };

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                        //close 
                        Swal.close();
                    },
                });
            };
        };
        function fn010104Edit(pItemCode, pVendor) {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(pItemCode, pVendor);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(pItemCode, pVendor) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Item Record',
                        'pItemCode': pItemCode,
                        'pVendor': pVendor
                    },
                    success: function (response) {
                        document.getElementById("tbx010104Item").value = response[0].ItemName;
                        document.getElementById("ContentPlaceHolder1_hf010104Vendor").value = pVendor;
                        document.getElementById("ContentPlaceHolder1_hf010104OrigItemCode").value = pItemCode;
                        document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010104UOM").value = response[0].UMName;
                        document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010104Price").value = formatNumber(response[0].Price);
                        document.getElementById("tbx010104Date").value = response[0].Date;
                        document.getElementById("ContentPlaceHolder1_hf010104OrigDate").value = response[0].Date;

                        $("#mdl010104Item").modal("show");
                    },
                });
            };
        };
        function fn010104Item() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    LoadMaterial();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function LoadMaterial() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Find Item',
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
                        let gridDiv = document.querySelector('#table010104FindItem');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";


                        gridOptions = {
                            suppressCellFocus: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "Item Code",
                                    field: "ItemCode",
                                    width: 150,
                                    tooltipField: "ItemCode"
                                },
                                {
                                    headerName: "Lock",
                                    field: "Lock",
                                    resizable: false,
                                    orderable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "ItemName",
                                    field: "ItemName",
                                    flex: 1,
                                    tooltipField: "ItemName"
                                },
                                {
                                    headerName: "UOM",
                                    field: "UMName",
                                    width: 150,
                                    tooltipField: "UMName"
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                        //close 
                        Swal.close();
                        //modal
                        $('#mdl010104FindItem').modal('show');
                    },
                });
            };
        };
        function fn010104ViewItem(pItemName, pItemCode, pUMCode, pUMName, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemName, pItemCode, pUMName, pUMCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemName, pItemCode, pUMName, pUMCode) {
                document.getElementById("tbx010104Item").value = pItemName;
                document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value = pItemCode;
                document.getElementById("tbx010104UOM").value = pUMName;
                document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value = pUMCode;

                //modal
                $("#mdl010104FindItem").modal("hide");
            };
        };
        function fn010104_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
            function Validate() {
                //Validate
                if (document.getElementById("tbx010104Item").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                } else if (document.getElementById("tbx010104Price").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                } else if (document.getElementById("tbx010104Date").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                } else {
                    Upd_Item_Question();
                };
            };
            function Upd_Item_Question() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Update Item Price',
                        'pVendor': document.getElementById("ContentPlaceHolder1_hf010104Vendor").value,
                        'pItemCode': document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value,
                        'pOrigItemCode': document.getElementById("ContentPlaceHolder1_hf010104OrigItemCode").value,
                        'pUOMCode': document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value,
                        'pPrice': document.getElementById("tbx010104Price").value,
                        'pDate': document.getElementById("tbx010104Date").value,
                        'pOrigDate': document.getElementById("ContentPlaceHolder1_hf010104OrigDate").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        fn0103Redraw("Edit", document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value, document.getElementById("ContentPlaceHolder1_hf010104Vendor").value, document.getElementById("tbx010104Date").value);
                        document.getElementById("tbx010104Item").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104Vendor").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104OrigItemCode").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value = "";
                        document.getElementById("tbx010104UOM").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value = "";
                        document.getElementById("tbx010104Price").value = "0.00";
                        document.getElementById("tbx010104Date").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104OrigDate").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //modal
                        $("#mdl010104Item").modal("hide");
                    }
                });
            };
        };
        function fn010104Delete(pItemCode, pVendor, pDate) {
            //access
            fnAccess('SCM060000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Del_Item_Question(pItemCode, pVendor, pDate);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Del_Item_Question(pItemCode, pVendor, pDate) {
                Swal.fire({
                    text: 'Delete record?',
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
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Delete Item Price',
                                'pItemCode': pItemCode,
                                'pVendor': pVendor,
                                'pDate': pDate
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                                //Load010104Tbl(pVendor);

                                fn0103Redraw("Delete", pItemCode, pVendor, pDate);
                                //modal
                                //$("#mdl010104Tools").modal("hide");
                            }
                        });
                    }
                });
            };
            function Load010104Tbl(pVendor) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Price Update',
                        'pVendor': pVendor
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010104Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "ItemName",
                                    field: "ItemName",
                                    flex: 1,
                                    tooltipField: "ItemName"
                                },
                                {
                                    headerName: "UOM",
                                    field: "UMName",
                                    width: 75,
                                    tooltipField: "UMName"
                                },
                                {
                                    headerName: "Price",
                                    field: "Price",
                                    width: 150,
                                    tooltipField: "Price",
                                    cellClass: "text-end",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                },
                                {
                                    headerName: "Project",
                                    field: "Project",
                                    width: 150,
                                    tooltipField: "Project"
                                },
                                {
                                    headerName: "Date",
                                    field: "Date",
                                    tooltipField: "Date",
                                    width: 120
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25,
                            onBodyScroll: function (event) {
                                document.querySelectorAll('.toggle-menu').forEach(menu => {
                                    menu.classList.add('d-none');
                                    const parent = toggleMenuMap.get(menu);
                                    if (parent) parent.appendChild(menu);
                                    toggleMenuMap.delete(menu);
                                });
                            }
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        if (!grid010104Record) {
                            grid010104Record = gridApi;
                        };

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                        //close 
                        Swal.close();
                    },
                });
            }
        };
        function fn010101_SCM03TLS04() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate() {
                let purchaserList = [];
                //purchaser
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Purchaser (Employee)'
                    },
                    success: function (responsePurchaser) {
                        purchaserList = responsePurchaser;
                        let purchaserDescList = purchaserList.map(x => x.Desc);
                        //list
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Transfer Item (Purchaser)'
                            },
                            success: function (response) {
                                let gridDiv = document.querySelector('#table010105Record');
                                let gridOptions;

                                // Destroy old grid if exists
                                gridDiv.innerHTML = "";

                                gridOptions = {
                                    suppressCellFocus: true,
                                    enableCellTextSelection: true,
                                    rowSelection: 'single',
                                    //popupParent: document.body,
                                    loading: false,
                                    columnDefs: [
                                        {
                                            headerName: "PR No.",
                                            field: "PRNo",
                                            tooltipField: "PRNo"
                                        },
                                        {
                                            headerName: "No.",
                                            field: "SeqNo",
                                            width: 75,
                                            tooltipField: "SeqNo"
                                        },
                                        {
                                            headerName: "Item",
                                            field: "Item",
                                            flex: 1,
                                            tooltipField: "Item"
                                        },
                                        {
                                            headerName: "Qty.",
                                            field: "ForPOBalance",
                                            width: 150,
                                            tooltipField: "ForPOBalance",
                                            cellClass: "text-end",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                        },
                                        {
                                            headerName: "UOM",
                                            field: "Unit",
                                            width: 75,
                                            tooltipField: "Unit"
                                        },
                                        {
                                            headerName: "Purchaser",
                                            field: "Purchaser",
                                            editable: true,
                                            cellEditor: 'agSelectCellEditor',
                                            cellEditorParams: {
                                                values: purchaserDescList
                                            },
                                            valueFormatter: (params) => params.value || "Select Purchaser",
                                            onCellValueChanged: function (params) {
                                                const match = purchaserList.find(x => x.Desc === params.newValue);
                                                if (match) {
                                                    params.data.Purchaser = match.Desc;
                                                    params.data.PurchaserCode = match.Code;
                                                }
                                            }
                                        },
                                        {
                                            headerName: "Purchaser Code",
                                            field: "PurchaserCode",
                                            hide: true
                                        }
                                    ],
                                    rowData: response,
                                    pagination: false,
                                    paginationPageSize: 25,
                                    onBodyScroll: function (event) {
                                        document.querySelectorAll('.toggle-menu').forEach(menu => {
                                            menu.classList.add('d-none');
                                            const parent = toggleMenuMap.get(menu);
                                            if (parent) parent.appendChild(menu);
                                            toggleMenuMap.delete(menu);
                                        });
                                    }
                                };
                                gridApi = agGrid.createGrid(gridDiv, gridOptions);

                                if (!grid010105Record) {
                                    grid010105Record = gridApi;
                                };

                                //modal
                                $("#mdl010105Tools").modal("show");
                            },
                        });
                    }
                });
            };
        };
        function fn010105_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
            function Validate() {
                if (!grid010105Record) return;
                let allRows = [];
                grid010105Record.forEachNode(node => {
                    if (node.data.PurchaserCode && node.data.PurchaserCode.trim() !== "") {
                        allRows.push(node.data);
                    }
                });
                //array
                let ItemSrs = allRows
                    .map(row => row.PRNo + "©" + row.SeqNo + "©" + row.PurchaserCode)
                    .join("®");
                //validation
                if (allRows.length === 0) {
                    fnAlertOnly('Please select a Purchaser!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
                //result
                if (ItemSrs != "") Upd_Item_Purchaser(ItemSrs);

            };
            function Upd_Item_Purchaser(ItemSrs) {
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
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Update Item Purchaser',
                                'pItemSrs': ItemSrs
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                                //modal
                                $("#mdl010105Tools").modal("hide");
                            }
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
        };
        function fn010101_SCM03TLS05() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (CP > PO)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010106Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Cash Purchase",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForCP",
                                            tooltipField: "ForCP",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForCPBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForCPBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForCPBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010106Tools").modal("show");
                    },
                });
            };
        };
        function fn010106_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0106Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0106Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForCPBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to PO, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx06Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx06Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx06Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CPtoPO_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CPtoPO_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (CP > PO)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010106Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS05();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS06() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (CP > SR)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010107Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Cash Purchase",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForCP",
                                            tooltipField: "ForCP",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForCPBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForCPBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForCPBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010107Tools").modal("show");
                    },
                });
            };
        };
        function fn010107_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0107Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0107Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForCPBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to SR, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx07Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx07Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx07Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CPtoSR_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CPtoSR_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (CP > SR)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010107Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS06();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS07() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (PO > CP)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010108Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010108Tools").modal("show");
                    },
                });
            };
        };
        function fn010108_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0108Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0108Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForPOBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to CP, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx08Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx08Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx08Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    POtoCP_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function POtoCP_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (PO > CP)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010108Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS07();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS08() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (PO > CCC)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010109Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010109Tools").modal("show");
                    },
                });
            };
        };
        function fn010109_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0109Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0109Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForPOBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to CCC, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx09Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx09Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx09Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    POtoCCC_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function POtoCCC_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (PO > CCC)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010109Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS08();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS09() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (PO > CCC)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010110Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010110Tools").modal("show");
                    },
                });
            };
        };
        function fn010110_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0110Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0110Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForPOBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to SR, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx10Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx10Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx10Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    POtoSR_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function POtoSR_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (PO > SR)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010110Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS09();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS10() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Cancel Item (PR)'
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010111Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Cancel",
                                            field: "Cancel",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Cancel", maxQty);
                                                    return false;
                                                }

                                                params.data.Cancel = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                                {
                                    headerName: "Reason",
                                    field: "Reason",
                                    sortable: false,
                                    editable: true,
                                    width: 250
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010111Tools").modal("show");
                    },
                });
            };
        };
        function fn010111_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0111Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0111Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Cancel: (row.Cancel !== undefined && row.Cancel !== null && row.Cancel !== "")
                            ? parseFloat(row.Cancel)
                            : parseFloat(row.ForPOBalance) || 0,
                        Reason: (row.Reason !== undefined && row.Reason !== null && row.Reason !== "")
                            ? row.Reason
                            : "",
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Cancel}©${i.Reason}`
                ).join('®');

                Cancel_Question(ItemSrs, Btn);
                function Cancel_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be cancelled, cancel Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx11Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx11Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx11Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CancelPR_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CancelPR_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Cancel Item (PR)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010110Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS10();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS11() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        Load_Record(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //load record
            function Load_Record(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Cancel PO Item',
                        'pID': ID
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010112Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "No.",
                                    field: "POSeqNo",
                                    tooltipField: "POSeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "ItemName",
                                    tooltipField: "ItemName",
                                    flex: 1
                                },
                                {
                                    headerName: "Qty.",
                                    field: "Qty",
                                    tooltipField: "Qty",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    cellClass: "text-end",
                                    width: 100
                                },
                                {
                                    headerName: "Cancel",
                                    field: "Cancel",
                                    valueFormatter: params => {
                                        let value = parseFloat(params.value);
                                        if (isNaN(value)) {
                                            value = parseFloat(params.data.QtyBal) || 0;
                                        }
                                        return value.toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    valueSetter: (params) => {
                                        let newValue = parseFloat(params.newValue);
                                        if (isNaN(newValue)) newValue = 0;

                                        let maxQty = parseFloat(params.data.QtyBal);
                                        if (isNaN(maxQty)) maxQty = 0;

                                        if (newValue > maxQty) {
                                            params.node.setDataValue("Cancel", maxQty);
                                            return false;
                                        }

                                        params.data.Cancel = newValue;
                                        return true;
                                    },
                                    editable: true,
                                    cellClass: "text-end fw-bolder",
                                    width: 100
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010112Tools").modal("show");
                    },
                });
            };
        };
        function fn010112_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access(Btn);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access(Btn) {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Btn.disabled = true;
                        Btn.setAttribute('data-kt-indicator', 'on');
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value, Btn);
                    } else {
                        Swal.close();
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        fn0112Add_Ok_Await(ID, Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
            function fn0112Add_Ok_Await(ID, Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRCode: ID,
                        POSeqNo: row.POSeqNo,
                        Cancel: (row.Cancel !== undefined && row.Cancel !== null && row.Cancel !== "")
                            ? parseFloat(row.Cancel)
                            : parseFloat(row.QtyBal) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRCode}©${i.POSeqNo}©${i.Cancel}`
                ).join('®');

                Cancel_Question(ItemSrs, Btn);
                function Cancel_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be cancelled, cancel Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx12Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx12Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx12Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CancelPO_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CancelPO_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Cancel PO Item',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010112Tools").modal("hide");
                            //trigger
                            
                            fn010101_SCM03TLS11();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS12() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Open', function (response) {
                    if (response[0].oReturn == "") {
                        Load_Modal(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //modal
            function Load_Modal(ID) {
                document.getElementById("tbx010113Reason").value = "";
                $("#mdl010113Tools").modal("show");
            };
        };
        function fn010113_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access(Btn);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access(Btn) {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Btn.disabled = true;
                        Btn.setAttribute('data-kt-indicator', 'on');
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value, Btn);
                    } else {
                        Swal.close();
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Open', function (response) {
                    if (response[0].oReturn == "") {
                        fn010113Add_Ok_Await(ID, Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            }
            function fn010113Add_Ok_Await(ID, Btn) {
                if (document.getElementById("tbx010113Reason").value == "") {
                    fnAlertOnly("Some fields are missing!", 'warning', 'btn btn-warning');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                } else {
                    //swal
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Re-Open Record?</span>',
                        icon: 'question',
                        html: `<input id="tbx13Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx13Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx13Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    ReOpenPO_Ok(ID, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                };
                function ReOpenPO_Ok(ID, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Re-Open PO',
                            'pID': ID,
                            'pRemarks': document.getElementById("tbx010113Reason").value
                        },
                        success: function (response) {
                            fnAlertOnly('Request for re-open successfully updated.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            document.getElementById("tbx010113Reason").value = "";
                            $("#mdl010101Tools").modal("hide");
                            $("#mdl010113Tools").modal("hide");
                            //trigger
                            
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS13() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Printing', function (response) {
                    if (response[0].oReturn == "") {
                        Load_Modal(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //modal
            function Load_Modal(ID) {
                document.getElementById("tbx010114PersonalRemarks").value = "";
                $("#mdl010114Tools").modal("show");
            };
        };
        function fn010114_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access(Btn);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access(Btn) {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Btn.disabled = true;
                        Btn.setAttribute('data-kt-indicator', 'on');
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value, Btn);
                    } else {
                        Swal.close();
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Printing', function (response) {
                    if (response[0].oReturn == "") {
                        fn010114Add_Ok_Await(ID, Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            }
            function fn010114Add_Ok_Await(ID, Btn) {
                if (document.getElementById("tbx010114PersonalRemarks").value == "") {
                    fnAlertOnly("Some fields are missing!", 'warning', 'btn btn-warning');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                } else {
                    //swal
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Re-Print Record?</span>',
                        icon: 'question',
                        html: `<input id="tbx14Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx14Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
                            });
                        },
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
                            fnValidatePassword(document.getElementById("tbx14Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    RePrintPO_Ok(ID, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                };
                function RePrintPO_Ok(ID, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Re-Print PO',
                            'pID': ID,
                            'pRemarks': document.getElementById("tbx010114PersonalRemarks").value
                        },
                        success: function (response) {
                            fnAlertOnly('Request for re-printing successfully updated.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            document.getElementById("tbx010113Reason").value = "";
                            $("#mdl010101Tools").modal("hide");
                            $("#mdl010114Tools").modal("hide");
                            //trigger
                            
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS14() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Online Tagging',
                        'pPONoFrom': '',
                        'pPONoTo': '',
                        'pPODateFrom': '',
                        'pPODateTo': ''
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010115Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "PO No.",
                                    field: "PONo",
                                    tooltipField: "PONo",
                                    width: 150
                                },
                                {
                                    headerName: "PO Date",
                                    field: "PODate",
                                    width: 150,
                                    tooltipField: "PODate"
                                },
                                {
                                    headerName: "Vendor",
                                    field: "Vendor",
                                    tooltipField: "Vendor",
                                    flex: 1
                                },
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    tooltipField: "Status",
                                    width: 75
                                },
                                {
                                    headerName: "Online Ref. No.",
                                    field: "OnlineReferenceNo",
                                    sortable: false,
                                    editable: true,
                                    width: 250
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010115Tools").modal("show");
                    },
                });
            };
        };
        function fn010115Filter() {
            document.getElementById("tbx010115PONoFrom").value = "";
            document.getElementById("tbx010115PONoTo").value = "";
            document.getElementById("tbx010115DateFrom").value = "";
            document.getElementById("tbx010115DateTo").value = "";
            $("#mdl010115Filter").modal("show");
        };
        function fn010115Filter_Ok(Btn) {
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
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Online Tagging',
                            'pPONoFrom': document.getElementById("tbx010115PONoFrom").value,
                            'pPONoTo': document.getElementById("tbx010115PONoTo").value,
                            'pPODateFrom': document.getElementById("tbx010115DateFrom").value,
                            'pPODateTo': document.getElementById("tbx010115DateTo").value
                        },
                        success: function (response) {
                            let gridDiv = document.querySelector('#table010115Record');
                            let gridOptions;

                            // Destroy old grid if exists
                            gridDiv.innerHTML = "";

                            gridOptions = {
                                suppressCellFocus: true,
                                loading: false,
                                rowSelection: 'multiple',
                                suppressRowClickSelection: true,
                                columnDefs: [
                                    {
                                        headerName: "PO No.",
                                        field: "PONo",
                                        tooltipField: "PONo",
                                        width: 150
                                    },
                                    {
                                        headerName: "PO Date",
                                        field: "PODate",
                                        width: 150,
                                        tooltipField: "PODate"
                                    },
                                    {
                                        headerName: "Vendor",
                                        field: "Vendor",
                                        tooltipField: "Vendor",
                                        flex: 1
                                    },
                                    {
                                        headerName: "Status",
                                        field: "Status",
                                        tooltipField: "Status",
                                        width: 150
                                    },
                                    {
                                        headerName: "Online Ref. No.",
                                        field: "OnlineReferenceNo",
                                        sortable: false,
                                        editable: true,
                                        width: 250
                                    },
                                ],
                                rowData: response,
                                pagination: false,
                                paginationPageSize: 25
                            };
                            gridApi = agGrid.createGrid(gridDiv, gridOptions);

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            //clear
                            document.getElementById("tbx010115PONoFrom").value = "";
                            document.getElementById("tbx010115PONoTo").value = "";
                            document.getElementById("tbx010115DateFrom").value = "";
                            document.getElementById("tbx010115DateTo").value = "";

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            $("#mdl010115Filter").modal("hide");
                        },
                    });
                });
            };
        };
        function fn010115Export() {
            if (gridApi) {
                gridApi.exportDataAsCsv({
                    fileName: 'Purhase Order - Online Monitoring.csv',
                    columnKeys: ['PONo', 'PODate', 'Vendor', 'Status', 'OnlineReferenceNo']
                });
            }
        }
        function fn010101_SCM03RPT04() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById("ContentPlaceHolder1_hf03ID").value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PR Printout',
                        'pID': ID
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT05() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById("ContentPlaceHolder1_hf03ID").value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PO Printout',
                        'pID': ID
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                            fn01Redraw("Edit", ID);
                            //trigger
                            
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT06() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - For (PO)'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT07() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - For (CP)'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT08() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Price History'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT09() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PO Movement',
                        'pID': document.getElementById("ContentPlaceHolder1_hf03ID").value
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT10() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Pending PR'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT11() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Receiving History',
                        'pID': document.getElementById("ContentPlaceHolder1_hf03ID").value
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn0101Open() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Open', function (response) {
                    if (response[0].oReturn == "") {
                        ReOpen_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function ReOpen_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Re-Open record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101ReOpenPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx0101ReOpenPassword");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                        fnValidatePassword(document.getElementById("tbx0101ReOpenPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Open', function (response) {
                                    if (response[0].oReturn == "") {
                                        ReOpen_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function ReOpen_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM060100",
                        'Type': "Purchase Order - Re-Open Record",
                        'pID': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                    },
                });
            }
        };
        function fn0101RePrint() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hf03ID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hf03ID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Print', function (response) {
                    if (response[0].oReturn == "") {
                        RePrint_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function RePrint_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Re-Print record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101RePrintPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx0101RePrintPassword");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                        fnValidatePassword(document.getElementById("tbx0101RePrintPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Print', function (response) {
                                    if (response[0].oReturn == "") {
                                        RePrint_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function RePrint_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM060100",
                        'Type': "Purchase Order - Re-Print Record",
                        'pID': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                        
                    },
                });
            }
        };
        //tools

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
                fn01Load();
            });
        }
        //load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
