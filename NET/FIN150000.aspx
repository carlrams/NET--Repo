<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FIN150000.aspx.vb" Inherits="NET.FIN150000" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!--content-->
    <div class="content flex-row-fluid" id="kt_content">
        <div>
            <style>
                .custom-file-input {
                    width: 300px;
                    padding: 8px;
                    border: 1px solid #ccc;
                    border-radius: 8px;
                    font-family: Arial, sans-serif;
                    font-size: 14px;
                    background-color: #f8f9fa;
                    cursor: pointer;
                    transition: all 0.3s ease;
                }

                .custom-file-input:hover {
                    border-color: #004d25;
                    background-color: lightgray;
                }
            </style>
        </div>
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
						<li class="breadcrumb-item text-white">Finance</li>
						<li class="breadcrumb-item text-white">-</li>
						<li class="breadcrumb-item text-white">Data Entry</li>
						<li class="breadcrumb-item text-white">-</li>
						<li class="breadcrumb-item text-white">Uncleared Check</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
<%--				<div class="d-flex align-items-center py-3 py-md-1">
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" onclick="fn01Add();return false;">Add New</a>
					<!--end::Button-->
				</div>--%>
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
						<img src="Assets/media/svg/apps/FIN150001.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Uncleared Check</span>
						</h3>
					</div>
					<!--end::Title-->
				</div>
			    <div class="card-toolbar">
                    <div class="d-flex flex-wrap align-items-center gap-2">
                        <!--begin::Search-->
                        <div class="position-relative">
                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
                                        transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                    <path
                                        d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
                                        fill="currentColor" />
                                </svg>
                            </span>
                            <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search"
                                class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10"
                                placeholder="Search" />
                        </div>
                        <!--end::Search-->

                        <!-- Hidden export placeholder -->
                        <div id="div01ExportButton" class="d-none"></div>

                        <!-- Action Buttons -->
                        <div class="d-flex gap-2">
                            <button type="button"
                                class="btn btn-sm btn-icon btn-success"
                                style="width: 32px; height: 32px;" title="Clear" onclick="fn01Clear(); return false;">
                                <i class="bi bi-send fs-3"></i>
                            </button>
                        </div>

                        <!-- Options dropdown -->
                        <div class="dropdown">
                            <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light"
                                data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                                <i class="las la-bars fs-3"></i>
                            </button>

                            <div id="div01ExportMenu"
                                class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-175px py-4"
                                data-kt-menu="true">
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" onclick="fn0102UploadExcel(); return false;">Clear Check - Upload</a>
                                </div>
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" onclick="fn0102RCheckView(); return false;">Cleared Check View</a>
                                </div>
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" onclick="fn0102PrintFRC(); return false;">Print</a>
                                </div>
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                                </div>
                            </div>
                        </div>
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
                                <th class="min-w-25px mw-25px fw-bold border-end no-border-top">
                                    <div class="form-check form-check-sm form-check-custom form-check-solid pl-2"
                                        style="background-color: white; padding-right: 2px; align-content: center; padding-left: 1px;">
                                        <input id="chk03Header" type="checkbox" class="form-check-input checkBoxAllClass progre" />
                                    </div>
                                </th>
                                <th class="min-w-125px mw-125px fw-bold border-end">CV No.</th>
                                <th class="min-w-75px mw-75px fw-bold border-end">Type</th>
                                <th class="min-w-250px mw-250px fw-bold border-end">Payee</th>
                                <th class="min-w-250px mw-250px fw-bold border-end">Bank</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Check No.</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Check Date</th>
                                <th class="min-w-100px mw-100px fw-bold">Amount</th>
						    </tr>
					    </thead>
					    <tbody id="gv01FormBody">
					    </tbody>
                          <tfoot>
                            <tr>
                              <th>Total:</th>
                              <th style="text-align:right"></th>
                              <th style="text-align:right"></th>
                              <th style="text-align:right"></th>
                              <th style="text-align:right"></th>
                              <th style="text-align:right"></th>
                              <th style="text-align:right"></th>
                              <th id="chkAmtTotal" style="text-align:right">0.00</th>
                            </tr>
                          </tfoot>
				    </table>
				    <!--end::Files-->
                </div>
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->


		<!--begin:: For Releasing-->
        <div id="mdl0101Clear" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Clear Record</h5>
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
                        <div class="row g-2 mb-2">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <div class="input-group input-group-sm">
                                    <span class="input-group-text min-w-150px required">Period</span>
                                    <input id="tbx01rvrsPeriod" type="text" class="form-control" onkeypress=" return isNumberKey(event)" maxlength="2"/>
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <div class="input-group input-group-sm">
                                    <span class="input-group-text min-w-150px required">Year</span>
                                    <input id="tbx01rvrsyear" type="text" class="form-control" onkeypress=" return isNumberKey(event)" maxlength="4" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                        <input type="hidden" id="hiddenCashJournalID" />
                        <button class="btn btn-sm btn-info fw-bolder min-w-100px m-1" onclick="fn01ClearOk(this);return false;">
                            <span class="indicator-label">Ok
                            </span>
                        </button>

                    </div>
                    <!--end::Actions-->
                </div>
            </div>
        </div>
		<!--begin:: For Releasing-->


		<!--begin:: Upload Excel-->
        <div id="mdl0102UploadExcel" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered mw-650px">
                <div class="modal-content shadow-lg">
                    <div class="modal-header">
                        <h5 class="modal-title">Clear Check - Upload</h5>
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
                        <input type="file" id="excelFileInput" accept=".xlsx" class="custom-file-input mb-2 w-600px" />
                        <input type="text" id="ExcelTextBoxX" readonly class="d-none mb-2" />
                        <div class="table-loading" style="height: 450px;">
                            <table id="table03Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
                                <thead>
                                    <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-200px mw-200px fw-bold border-end">CV No.</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Check No.</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Check Amt.</th>
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
                        <button type="button" class="btn btn-sm btn-danger min-w-100px" data-bs-dismiss="modal">Cancel</button>
                        <button class="btn btn-sm btn-info min-w-100px" onclick="fn0102UploadExcelSave(); return false;">Ok</button>
                    </div>
                    <!--end::Actions-->
                </div>
            </div>
        </div>
		<!--End:: Upload Excel-->

		<!--begin:: Release Check View Modal-->
        <div id="mdl0102RCheckView" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-fullscreen">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Cleared Check View</h5>
                        <!--begin::Close-->
                        <div class="d-flex flex-wrap align-items-center gap-2">
                         <div class="btn btn-sm btn-icon btn-secondary" title="Print" onclick="fn0102Print(); return false;">
                             <i class="las la-print fs-2"></i>
                        </div>

                        <div class="position-relative">
                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
                                        transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                    <path
                                        d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
                                        fill="currentColor" />
                                </svg>
                            </span>
                            <input id="tbx02Find" type="text" data-kt-inbox-listing-filter="search"
                                class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10"
                                placeholder="Search" />
                        </div>

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
                    </div>
                    <div class="modal-body">
                        <div class="table-loading" style="min-height: 62.3vh;">
                            <div id="div02Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table02Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
                                <thead>
                                    <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-100px mw-100px fw-bold border-end">CV No.</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Type</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Payee</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Bank</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check No.</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Check Date</th>
                                        <th class="min-w-75px mw-75px fw-bold ">Amount</th>
                                    </tr>
                                </thead>
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

        <div id="mdl0102Print" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered mw-650px">
                <div class="modal-content shadow-lg">
                    <div class="modal-header">
                        <h5 class="modal-title">Clear Check</h5>
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
                            <div class="col-6">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left: 1px">
                                    <input id="InpdatefromFRC" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly placeholder="Date From" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('InpdatefromFRC');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor" />
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor" />
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left: 1px">
                                    <input id="InpdatetoFRC" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly placeholder="Date To" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('InpdatetoFRC');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor" />
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor" />
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
                            </div>
                        </div>
                    </div>

                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-sm btn-danger min-w-100px" data-bs-dismiss="modal">Cancel</button>
                        <button id="btnPrintFRC" class="btn btn-sm btn-info min-w-100px" onclick="fn0102_FIN15RPT01(); return false;">Ok</button>
                    </div>
                    <!--end::Actions-->
                </div>
            </div>
        </div>

        <div id="mdl0102PrintFRC" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered mw-650px">
                <div class="modal-content shadow-lg">
                    <div class="modal-header">
                        <h5 class="modal-title">Uncleared Check</h5>
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
					<div class="col-12 mb-2">
						<div class="input-group input-group-sm">
							<span class="input-group-text min-w-150px">Bank</span>
							 <select id="ddl0102Branch" data-kt-repeater="select2" data-dropdown-parent="#mdl0102PrintFRC" class="form-select form-select-sm form-select-border min-h-38px" >
                             </select>
						</div>
					</div>
                    </div>

                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-sm btn-danger min-w-100px" data-bs-dismiss="modal">Cancel</button>
                        <button id="btnPrint" class="btn btn-sm btn-info min-w-100px" onclick="fn0102_FIN15RPT02(); return false;">Ok</button>
                    </div>
                    <!--end::Actions-->
                </div>
            </div>
        </div>
		<!--end:: Release Check View Modal-->
         



    </div>

    <!--content-->
	<!-- scripts related to this page -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <script type="text/javascript">
        //Date
        function initDateRangePicker(dateFromId, dateToId) {
            const dateFromInput = document.getElementById(dateFromId);
            const dateToInput = document.getElementById(dateToId);

            if (!dateFromInput || !dateToInput) return;

            // Destroy existing Flatpickr instances to avoid duplicates
            if (dateFromInput._flatpickr) dateFromInput._flatpickr.destroy();
            if (dateToInput._flatpickr) dateToInput._flatpickr.destroy();

            // Initialize Date To
            const dateToPicker = flatpickr(dateToInput, {
                dateFormat: 'm/d/Y'
            });

            // Initialize Date From with logic to restrict Date To
            flatpickr(dateFromInput, {
                dateFormat: 'm/d/Y',
                defaultDate: dateFromInput.value || null,
                onReady(selectedDates) {
                    if (selectedDates.length) {
                        dateToPicker.set('minDate', selectedDates[0]);
                    }
                },
                onChange(selectedDates) {
                    const minDate = selectedDates.length ? selectedDates[0] : null;
                    dateToPicker.set('minDate', minDate);

                    if (dateToPicker.selectedDates.length && dateToPicker.selectedDates[0] < minDate) {
                        dateToPicker.clear();
                    }
                }
            });
        }

        document.addEventListener('DOMContentLoaded', function () {
            const modalPO = document.getElementById('mdl0102Print');
            modalPO.addEventListener('shown.bs.modal', function () {
                initDateRangePicker('InpdatefromFRC', 'InpdatetoFRC');
            });

        });
        document.addEventListener("click", function (e) {
            if (e.target.closest("a[title='Clear']")) {
                // delay to let fnClearTime do its job first
                setTimeout(() => {
                    // always re-init both pickers you care about
                    initDateRangePicker("InpdatefromFRC", "InpdatetoFRC");
                }, 0);
            }
        });
        //Date

        //general
        //fnLoad
        function fn01Load() {
            fnAccess('FIN150000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDFIN.ashx",
                    data: {
                        'pFormCode': 'FIN150000',
                        'pType': 'Get Record - HDR',
                    },
                    success: function (response) {
                        document.getElementById("div01Loader").style.display = "";

                        $('#table01Record').DataTable().destroy();

                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });

                        $.fn.dataTable.moment('MM/DD/YYYY');

                        var table01Record = $("#table01Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: false,
                            bInfo: false,
                            paging: false,
                            scrollY: '600px',
                            pageLength: 25,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Check' },
                                { data: 'p_code' },
                                { data: 'crdtr_type' },
                                { data: 'Payee' },
                                { data: 'bank' },
                                { data: 'chk_no' },
                                { data: 'chk_date' },
                                { data: 'chk_amt' }
                            ],
                            columnDefs: [
                                { targets: 0, orderable: false },
                                { targets: 1, className: 'tbody-nowrap-auto' },
                                { targets: 2, className: 'tbody-nowrap-auto' },
                                { targets: 3, className: 'tbody-nowrap-auto' },
                                { targets: 4, className: 'tbody-nowrap-auto' },
                                { targets: 5, className: 'tbody-nowrap-auto' },
                                { targets: 6, className: 'tbody-nowrap-auto' },
                                { targets: 7, className: 'tbody-nowrap-auto dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2) }
                            ],
                            order: [[1, 'desc']],
                            orderCellsTop: true,
                            drawCallback: function () {
                                bindCheckboxListeners(this.api());
                            }
                        });

                        // Setup search box
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });

                        // Export buttons
                        const documentTitle = 'For Release Check';
                        var buttons = new $.fn.dataTable.Buttons(table01Record, {
                            buttons: [
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle,
                                    exportOptions: {
                                        columns: [1, 2, 3, 4, 5, 6, 7]
                                    }
                                }
                            ]
                        }).container().appendTo($('#div01ExportButton'));

                        const exportButtons = document.querySelectorAll('[data-kt-export]');
                        exportButtons.forEach(exportButton => {
                            exportButton.addEventListener('click', e => {
                                e.preventDefault();
                                const rowCount = table01Record.rows({ filter: 'applied' }).data().length;
                                if (rowCount > 5000) {
                                    fnAlertOnly('Too many rows. Please filter your data before exporting.', 'warning', 'btn btn-danger');
                                    return;
                                }
                                const exportValue = e.target.getAttribute('data-kt-export');
                                const target = document.querySelector('.dt-buttons .buttons-' + exportValue);
                                target.click();
                            });
                        });

                        setupHeaderCheckboxToggle(table01Record);
                        updateChkAmtTotal();

                        document.getElementById("div01Loader").style.display = "none";
                    }
                });
            }
        };
        var selectedIndexes = [];

        function setupHeaderCheckboxToggle(dataTable) {
            $('#chk03Header').off('change').on('change', function () {
                const isChecked = $(this).is(':checked');

                // Update all visible checkboxes
                dataTable.rows().nodes().to$().find('.row-checkbox').each(function () {
                    const index = parseInt($(this).data('row'));

                    $(this).prop('checked', isChecked);

                    if (!isNaN(index)) {
                        if (isChecked) {
                            if (!selectedIndexes.includes(index)) {
                                selectedIndexes.push(index);
                            }
                        } else {
                            selectedIndexes = selectedIndexes.filter(x => x !== index);
                        }
                    }
                });

                updateChkAmtTotal();
            });
        }
        function updateChkAmtTotal() {
            let total = 0;
            const table = $('#table01Record').DataTable();

            $('#table01Record tbody .row-checkbox:checked').each(function () {
                const $row = $(this).closest('tr');
                const rowData = table.row($row).data();
                if (rowData && rowData.chk_amt) {
                    total += parseFloat(rowData.chk_amt) || 0;
                }
            });

            $('#chkAmtTotal').text(total.toLocaleString('en-US', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }));
        }
        //fnLoad

        function fn01Redraw(Action, ID) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDFIN.ashx",
                    data: {
                        'pFormCode': 'FIN150000',
                        'pType': 'Redraw - Hdr',
                        'pID': ID
                    },
                    success: function (response) {

                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add({ Action: response[0].Action, CJCode: response[0].CJCode, Lock: response[0].Lock, Post: response[0].Post, Cancel: response[0].Cancel, Date: response[0].Date, Period: response[0].Period, Year: response[0].Year, RefNo: response[0].RefNo, RefDate: response[0].RefDate, Description: response[0].Description }).draw(false).select();
                            $(row01.node()).attr('id', response[0].rowId);
                            gv01.row({ selected: true }).scrollTo(false);
                            //add row

                            //select and go to record
                            let new01 = gv01.row('#' + response[0].rowId);
                            let index01 = new01.index();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        } else if (Action == "Edit") {

                            //edit row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();

                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].CJCode).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Lock).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Post).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Cancel).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].Date).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].Period).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].Year).draw(false);
                            gv01.cell({ row: index01, column: 8 }).data(response[0].RefNo).draw(false);
                            gv01.cell({ row: index01, column: 9 }).data(response[0].RefDate).draw(false);
                            gv01.cell({ row: index01, column: 10 }).data(response[0].Description).draw(false);
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
        function isNumberKey(evt, input) {
            var charCode = evt.which ? evt.which : evt.keyCode;
            var charTyped = String.fromCharCode(charCode);

            if (evt.ctrlKey || evt.metaKey || charCode < 32) return true;

            if (charTyped === '-') {
                return input.selectionStart === 0 && !input.value.includes('-');
            }

            if (charTyped === '.') {
                return !input.value.includes('.');
            }

            return charCode >= 48 && charCode <= 57;
        }
        //general

        //Releasing Check
        function stripHtml(html) {
            let div = document.createElement("div");
            div.innerHTML = html;
            return div.textContent || div.innerText || "";
        }
        function bindCheckboxListeners(dataTable) {
            dataTable.rows().nodes().to$().find('input[type="checkbox"]').each(function () {
                const index = parseInt($(this).data('row'));

                // Restore state
                if (selectedIndexes.includes(index)) {
                    $(this).prop('checked', true);
                }
                // Attach change listener
                $(this).off('change').on('change', function () {
                    if (!isNaN(index)) {
                        if (this.checked) {
                            if (!selectedIndexes.includes(index)) {
                                selectedIndexes.push(index);
                            }
                            updateChkAmtTotal()
                        } else {
                            selectedIndexes = selectedIndexes.filter(x => x !== index);
                        }
                    }
                });
            });
        }

        function getSelectedIndexes() {
            return selectedIndexes;
        }
        function buildAccountList(table, indexes) {
            return indexes.map(i => {
                const data = table.row(i).data();
                return { code: stripHtml(data.p_code) };
            });
        }
        function fn01Clear() {
            fnAccess('FIN150000', 'Post', function (response) {
                if (response[0].oReturn == "1") {
                    const indexes = getSelectedIndexes();
                    if (indexes.length === 0) {
                        fnAlertOnly('There are no record selected!', 'error', 'btn btn-danger');
                        return;
                    }

                    const table = $('#table01Record').DataTable();
                    const Accountlist = buildAccountList(table, indexes);

                    const now = new Date();
                    document.getElementById("tbx01rvrsPeriod").value = String(now.getMonth() + 1).padStart(2, '0');
                    document.getElementById("tbx01rvrsyear").value = now.getFullYear();
                    $('#mdl0101Clear').modal('show');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        }
        function fn01ClearOk() {
            fnAccess('FIN150000', 'Post', function (response) {
                if (response[0].oReturn == "1") {
                    const indexes = getSelectedIndexes();
                    const table = $('#table01Record').DataTable();
                    const Accountlist = buildAccountList(table, indexes);

                    const Period = document.getElementById("tbx01rvrsPeriod").value;
                    const Year = document.getElementById("tbx01rvrsyear").value;

                    const dateRelease = new Date(Year + '-' + Period + '-01');
                    const formattedDate = dateRelease.toISOString().slice(0, 10);

                    if (!Period || !Year) {
                        fnAlertOnly('Some field(s) is/are missing!', 'error', 'btn btn-danger');
                        return;
                    }

                    function validateAccountsSequentially(accountList, index = 0) {
                        if (index >= accountList.length) {
                            // All accounts passed, now validate the journal date
                            financeValidateRecord('pdx_period(date)', '', formattedDate, '', function (response) {
                                if (response[0].oReturn == "") {
                                    Swal.fire({
                                        title: '<span class="fs-6 fw-normal text-gray-700">Release record?</span>',
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
                                            $('#mdl0101Clear').modal('hide');
                                            $.ajax({
                                                type: "POST",
                                                url: "HNDFIN.ashx",
                                                data: {
                                                    'pFormCode': 'FIN150000',
                                                    'pType': 'Clear CV Number',
                                                    'Accountlist': JSON.stringify(Accountlist),
                                                    'Period': Period,
                                                    'Year': Year
                                                },
                                                success: function (response) {
                                                    fnAlertOnly('Record(s) successfully released.', 'success', 'btn btn-success');
                                                    selectedIndexes = [];
                                                    $('#table01Record tbody input[type="checkbox"]').prop("checked", false);
                                                    fn01Load();
                                                },
                                            });
                                            } else if (result.isDismissed) {
                                                btn.disabled = false;
                                            }
                                        });
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                }
                            });
                            return;
                        }

                        const account = accountList[index];

                        financeValidateRecord('fin_app_hdr', account.code, '', 'Unclear', function (response) {
                            if (response[0].oReturn == "") {
                                // Continue with next account
                                validateAccountsSequentially(accountList, index + 1);
                            } else {
                                fnAlertOnly('Journal Date should be equal and not less than the defined Journal Date!', 'warning', 'btn btn-warning');
                            }
                        });
                    }

                    // ✅ Start validation sequence here
                    validateAccountsSequentially(Accountlist);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
              });
        }
        //Releasing Check

        //Upload Excel
        function fn0102UploadExcel() {
            fnAccess('FIN150000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    document.getElementById("excelFileInput").value = "";
                    document.getElementById("ExcelTextBoxX").value = "";
                    $('#table03Record').DataTable().clear().draw();
                    $('#mdl0102UploadExcel').modal('show');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        }
        document.getElementById("excelFileInput").addEventListener("change", function (e) {
            const file = e.target.files[0];
            if (!file) return;

            document.getElementById("ExcelTextBoxX").value = file.name;

            const reader = new FileReader();
            reader.onload = function (e) {
                try {
                    const data = new Uint8Array(e.target.result);
                    const workbook = XLSX.read(data, { type: "array" });
                    const worksheet = workbook.Sheets[workbook.SheetNames[0]];

                    const tableData = [];
                    let rowIndex = 2;

                    while (rowIndex < 1000) {
                        const chkNo = worksheet["A" + rowIndex];
                        const chkAmtCell = worksheet["B" + rowIndex];
                        let chkAmt = chkAmtCell ? chkAmtCell.v.toString().replace(/[^0-9.-]/g, '') : '';

                        if (!chkNo || !chkNo.v) break;

                        // ❗ Skip rows where chkAmt is invalid (e.g., contains letters)
                        if (chkAmt === '' || isNaN(chkAmt)) {
                            rowIndex++;
                            continue; // skip to next row
                        }

                        tableData.push({
                            chk_no: chkNo.v.toString(),
                            chk_amt: chkAmt,
                            cv_no: ''
                        });


                        rowIndex++;
                    }

                    // Get CV_No from server based on chk_no & chk_amt
                    $.ajax({
                        type: "POST",
                        url: "HNDFIN.ashx",
                        data: {
                            pFormCode: 'FIN150000',
                            pType: 'GetCVNo',
                            UploadExcel: JSON.stringify(tableData)
                        },
                        success: function (response) {
                            try {
                                if (!response || response.length === 0) {
                                    fnAlertOnly('No record found.', 'warning', 'btn btn-warning');
                                    $('#table03Record').DataTable().clear().draw();
                                    return;
                                }

                                initDataTable(response);
                            } catch (err) {
                                fnAlertOnly('Invalid response from server.', 'warning', 'btn btn-warning');
                            }
                        },
                        error: function () {
                            alert("Error occurred while fetching data.");
                        }
                    });


                } catch (err) {
                    fnAlertOnly("Error: " + err.message, 'error', 'btn btn-danger');
                }
            };

            reader.readAsArrayBuffer(file);
        });

        function initDataTable(data) {
            $('#table03Record').DataTable({
                scrollY: '350px',
                scrollCollapse: true,
                fixedHeader: true,
                bDestroy: true,
                select: false,
                bInfo: false,
                bPaginate: false,
                paging: false,
                data: data,
                columns: [
                    { data: 'cv_no' },
                    { data: 'chk_no' },
                    { data: 'chk_amt' }
                ],
                columnDefs: [
                    { targets: '_all', className: 'tbody-nowrap-auto' },
                    { targets: 2, className: 'tbody-nowrap-auto dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2) }
                ],
                order: [[0, 'desc']]
            });
        }
        //Upload Excel



        //For Release Check View
        function fn0102RCheckView() {

            fnAccess('FIN150000', 'Print', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    return;
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDFIN.ashx",
                    data: {
                        'pFormCode': 'FIN150000',
                        'pType': 'Get Record - HDR - View',
                    },
                    success: function (response) {
                        document.getElementById("div02Loader").style.display = "";

                        $('#table02Record').DataTable().destroy();

                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });

                        $.fn.dataTable.moment('MM/DD/YYYY');

                        var table02Record = $("#table02Record").DataTable({
                            scrollY: '450px',
                            scrollCollapse: false,
                            fixedHeader: true,
                            bDestroy: true,
                            pageLength: 15,
                            lengthMenu: [[15, 50, 75, 100], [15, 50, 75, 100]],
                            select: false,
                            bInfo: false,
                            bPaginate: true,
                            paging: true,
                            data: response,
                            columns: [
                                { data: 'p_code' },
                                { data: 'crdtr_type' },
                                { data: 'Payee' },
                                { data: 'bank' },
                                { data: 'chk_no' },
                                { data: 'chk_date' },
                                { data: 'chk_amt' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                { targets: 0, className: 'tbody-nowrap-auto' },
                                { targets: 1, className: 'tbody-nowrap-auto' },
                                { targets: 2, className: 'tbody-nowrap-auto' },
                                { targets: 3, className: 'tbody-nowrap-auto' },
                                { targets: 4, className: 'tbody-nowrap-auto' },
                                { targets: 5, className: 'tbody-nowrap-auto' },
                                { targets: 6, className: 'tbody-nowrap-auto dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2) }
                            ],
                            order: [[1, 'desc']],
                            orderCellsTop: true,
                        });

                        // Setup search box
                        $('#tbx02Find').on('keyup', function () {
                            table02Record.search(this.value).draw();
                        });
                        document.getElementById("div02Loader").style.display = "none";
                    }
                });
                $('#mdl0102RCheckView').modal('show');
            }

        }
        function fn0102Print() {
            fnAccess('FIN150000', 'Print', function (response) {
                if (response[0].oReturn == "1") {
                    document.getElementById("InpdatefromFRC").value = "";
                    document.getElementById("InpdatetoFRC").value = "";
                    $('#mdl0102Print').modal('show');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        }
        function fn0102_FIN15RPT01() {
            const btn = document.getElementById("btnPrintFRC");
            btn.disabled = true; // Disable the button immediately

            fnAccess('FIN150000', 'Print', function (response) {
                if (response[0].oReturn == "1") {
                    const DateFrom = document.getElementById("InpdatefromFRC").value.trim();
                    const DateTo = document.getElementById("InpdatetoFRC").value.trim();

                    if (!DateFrom || !DateTo) {
                        fnAlertOnly('Some field(s) is/are missing', 'error', 'btn btn-danger');
                        btn.disabled = false;
                        return; // stop the function if empty
                    }
                    $.ajax({
                        type: "POST",
                        url: "HNDFIN.ashx",
                        data: {
                            'pFormCode': 'FIN150000',
                            'pType': 'Generate Release Check',
                            'DateFrom': DateFrom,
                            'DateTo': DateTo
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            }
                        },
                        complete: function () {
                            // Re-enable the button after the AJAX call finishes (success or error)
                            btn.disabled = false;
                        }
                    });

                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    btn.disabled = false; // Re-enable if access denied
                }
            });
        }
        // For Release Check Print
        function fn0102PrintFRC() {
            fnAccess('FIN150000', 'Print', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDFIN.ashx",
                        data: {
                            pFormCode: 'FIN00001',
                            pType: 'Getbank'
                        },
                        success: function (response) {
                            var branch = JSON.parse(response);
                            var ddl = $("#ddl0102Branch");

                            ddl.empty(); // Clear existing options

                            $.each(branch, function (i, item) {
                                ddl.append($('<option>', {
                                    value: item.Code,
                                    text: item.Name
                                }));
                            });

                            // Reset value after loading options
                            ddl.val("");
                        },

                        error: function (xhr, status, error) {
                            alert("Error fetching branch list: " + error);
                        }
                    });

                    $('#mdl0102PrintFRC').modal('show');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                }
            });
        }
        function fn0102_FIN15RPT02() {
            const btn = document.getElementById("btnPrint");
            btn.disabled = true;

            fnAccess('FIN150000', 'Print', function (response) {
                if (response[0].oReturn == "1") {
                    const Branch = $('#ddl0102Branch').val();

                    if (!Branch) {
                        fnAlertOnly('Some field(s) is/are missing', 'error', 'btn btn-danger');
                        btn.disabled = false;
                        return; // stop the function if empty
                    }
                    $.ajax({
                        type: "POST",
                        url: "HNDFIN.ashx",
                        data: {
                            'pFormCode': 'FIN150000',
                            'pType': 'Generate Cleared Check Per Branch',
                            'Branch': Branch
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            }
                        },
                        complete: function () {
                            // Re-enable the button after the AJAX call finishes (success or error)
                            btn.disabled = false;
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });

        }
        //For Release Check Print

        //Adjust Table
        $(document).ready(function () {
            function adjustTable(selector) {

                if ($(selector).length === 0) {
                    return;
                }

                //if (excludedTables.includes(selector)) {
                //    return;
                //}
                if (!$.fn.DataTable.isDataTable(selector)) {
                    $(selector).DataTable({
                        responsive: true,

                        destroy: true
                    });
                } else {
                    $(selector).DataTable().columns.adjust().draw(false);
                }
            }

            // Adjust DataTables when a modal is shown
            $('.modal').on('shown.bs.modal', function () {
                setTimeout(function () {
                    $($.fn.dataTable.tables(true)).each(function () {
                        adjustTable('#' + $(this).attr('id')); // Use the ID selector
                    });
                }, 300);
            });

            // Adjust DataTables when switching tabs inside a modal
            $('a[data-bs-toggle="tab"]').on('shown.bs.tab', function (e) {
                let targetTab = $(e.target).attr('href');
                $(targetTab).find('table').each(function () {
                    if ($(this).attr('id') == "ContentPlaceHolder1_gv02Files") {
                        return;
                    }
                    adjustTable('#' + $(this).attr('id'));
                });
            });
        });
        //Adjust Table

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
            });
            jQuery(function ($) {
                fn01Load();
            });
        }
        //load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
