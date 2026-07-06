<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM110000.aspx.vb" Inherits="NET.SCM110000"  MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Awarding</li>
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
			<!--begin::Beader-->
            
			<div class="card-header card-header-stretch border-bottom border-gray-200">
				<div class="d-flex align-items-center">
					<div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Awarding</span>
						</h3>
					</div>
				</div>
			</div>
            <div class="border-bottom border-gray-200 px-4 py-3 mb-2">
                <div class="d-flex flex-stack align-items-center">
                    <div class="d-flex align-items-center mr-5">
                        <!--option-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <button type="button" class="btn btn-sm btn-icon btn-info btn-active-info" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options" style="width: 32px; height: 32px; margin-left: 3px;">
                            <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                            <i class="las la-filter fs-3"></i>
                            <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
				            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="fn01Export(); return false;" data-kt-export="excel">Export as Excel</a>
                            </div>
                        </div>
						<span class="bullet h-30px w-2px bg-secondary m-1"></span>
                        <div class="d-flex gap-1">
                            <button type="button" id="btn01Cancel" class="btn btn-sm btn-icon btn-delete d-none" style="width: 32px; height: 32px;" onclick="fn01Cancel(); return false;" title="Cancel Record">
                                <i class="las la-trash fs-2"></i>
                            </button>
                            <button type="button" id="btn01Edit" class="btn btn-sm btn-icon btn-edit" style="width: 32px; height: 32px;" onclick="fn01Edit(); return false;" title="Edit Record">
                                <i id="i01Edit" class="las la-pencil-alt fs-2"></i>
                            </button>
                            <button type="button" id="btn01Save" class="btn btn-sm btn-icon btn-edit d-none" style="width: 32px; height: 32px;" onclick="fn01Save(); return false;" title="Edit Record">
                                <i id="i01Save" class="las la-pencil-alt fs-2"></i>
                            </button>
                            <button type="button" id="btn01Post" class="btn btn-sm btn-icon btn-post" style="width: 32px; height: 32px;" title="Post Record" onclick="fn01Post(); return false;">
                                <i class="las la-check-circle fs-3"></i>
                            </button>
                        </div>
                        <!--option-->
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
						        <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="mainGridApi.setGridOption('quickFilterText', document.getElementById('tbx01Find').value);" />
					        </div>
					        <!--end::Search-->
                    </div>
			        </div>
                </div>
            </div>
		    <!--end::Header-->
			<!--begin::Card body-->
			<div class="card-body">
                <div id="table01Record" style="height: 100vh;"></div>
				<!--end::Files-->
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->
        
		<!--begin::Modal Search record-->
		<div id="mdl0101BOQ" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-800px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate (BOQ) - Search record</h5>
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
                                    <input id="hf0101RowID" type="hidden" value="" />
                                    <input id="hf0101OldCECode" type="hidden" value="" />
                                    <input id="hf0101OldTitle" type="hidden" value="" />
                                    <input id="tbx0101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="gridApi.setGridOption('quickFilterText', document.getElementById('tbx0101Find').value);" />
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
                        <div id="table0101BOQ" style="height: 80vh;"></div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl0102Contractor" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-800px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Contractor - Search record</h5>
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
                                    <input id="hf0102RowID" type="hidden" value="" />
                                    <input id="hf0102OldCode" type="hidden" value="" />
                                    <input id="hf0102OldContractor" type="hidden" value="" />
                                    <input id="tbx0102Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="gridApi.setGridOption('quickFilterText', document.getElementById('tbx0102Find').value);" />
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
                        <div id="table0102Contractor" style="height: 80vh;"></div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
    </div>
	
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
    <script type="text/javascript">

        //AG Grid
        let mainGridApi = null;
        let gridApi = null;
        //AG Grid

        //numeric
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
        function fnFormatNumberNum(input) {
            var Num = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(Num);
        };
        //numeric

        //general
        function fn01Load() {
            fnAccess('SCM110000', 'View', function (response) {
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
                        'FormCode': 'SCM110000',
                        'Type': 'Awarding - Get Record'
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table01Record');
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
                                    headerName: "Form No.",
                                    field: "FormNo",
                                    tooltipField: "FormNo"
                                },
                                {
                                    headerName: "Category",
                                    field: "Category",
                                    tooltipField: "Category"
                                },
                                {
                                    headerName: "Project",
                                    field: "Project",
                                    tooltipField: "Project"
                                },
                                {
                                    headerName: "BOQ",
                                    field: "Title",
                                    tooltipField: "Title"
                                },
                                {
                                    headerName: "CECode",
                                    field: "CECode",
                                    tooltipField: "CECode",
                                    hide: true
                                },
                                {
                                    headerName: "Contractor",
                                    field: "Contractor",
                                    tooltipField: "Contractor"
                                },
                                {
                                    headerName: "ContractorID",
                                    field: "ContractorID",
                                    tooltipField: "ContractorID",
                                    hide: true
                                },
                                {
                                    headerName: "Category",
                                    field: "ConCategory",
                                    tooltipField: "ConCategory"
                                },
                                {
                                    headerName: "Type",
                                    field: "Type",
                                    width: 125,
                                    tooltipField: "Type"
                                },
                                {
                                    headerName: "No.",
                                    field: "No",
                                    width: 125,
                                    tooltipField: "No"
                                },
                                {
                                    headerName: "Price",
                                    field: "Price",
                                    tooltipField: "Price",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "VAT",
                                    field: "VAT",
                                    tooltipField: "VAT",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "EWT",
                                    field: "EWT",
                                    tooltipField: "EWT",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Downpayment",
                                    field: "Downpayment",
                                    tooltipField: "Downpayment",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Retention Fee",
                                    field: "RetentionFee",
                                    tooltipField: "RetentionFee",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Prior Start",
                                    field: "PriorStart",
                                    tooltipField: "PriorStart",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    width: 125,
                                    tooltipField: "Status"
                                },
                                {
                                    headerName: "Date Awarded",
                                    field: "DateAwarded",
                                    width: 125,
                                    tooltipField: "DateAwarded",
                                    valueFormatter: params => {
                                        if (!params.value) return '';
                                        const d = new Date(params.value);
                                        return [
                                            String(d.getMonth() + 1).padStart(2, '0'),
                                            String(d.getDate()).padStart(2, '0'),
                                            d.getFullYear()
                                        ].join('/');
                                    }
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
                        mainGridApi = agGrid.createGrid(gridDiv, gridOptions);
                    },
                });
            };
        };
        function fn0101LoadOverview(pMode) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM110000',
                    'Type': 'Awarding - Get Record'
                },
                success: function (response) {
                    let gridDiv = document.querySelector('#table01Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";

                    if (pMode == "DTL") {
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
                                    headerName: "Form No.",
                                    field: "FormNo",
                                    tooltipField: "FormNo"
                                },
                                {
                                    headerName: "Category",
                                    field: "Category",
                                    tooltipField: "Category"
                                },
                                {
                                    headerName: "Project",
                                    field: "Project",
                                    tooltipField: "Project"
                                },
                                {
                                    headerName: "BOQ",
                                    field: "Title",
                                    tooltipField: "Title"
                                },
                                {
                                    headerName: "CECode",
                                    field: "CECode",
                                    tooltipField: "CECode",
                                    hide: true
                                },
                                {
                                    headerName: "Contractor",
                                    field: "Contractor",
                                    tooltipField: "Contractor"
                                },
                                {
                                    headerName: "ContractorID",
                                    field: "ContractorID",
                                    tooltipField: "ContractorID",
                                    hide: true
                                },
                                {
                                    headerName: "Category",
                                    field: "ConCategory",
                                    tooltipField: "ConCategory"
                                },
                                {
                                    headerName: "Type",
                                    field: "Type",
                                    width: 125,
                                    tooltipField: "Type"
                                },
                                {
                                    headerName: "No.",
                                    field: "No",
                                    width: 125,
                                    tooltipField: "No"
                                },
                                {
                                    headerName: "Price",
                                    field: "Price",
                                    tooltipField: "Price",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "VAT",
                                    field: "VAT",
                                    tooltipField: "VAT",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "EWT",
                                    field: "EWT",
                                    tooltipField: "EWT",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Downpayment",
                                    field: "Downpayment",
                                    tooltipField: "Downpayment",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Retention Fee",
                                    field: "RetentionFee",
                                    tooltipField: "RetentionFee",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Prior Start",
                                    field: "PriorStart",
                                    tooltipField: "PriorStart",
                                    cellClass: "text-end",
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
                                },
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    width: 125,
                                    tooltipField: "Status"
                                },
                                {
                                    headerName: "Date Awarded",
                                    field: "DateAwarded",
                                    width: 125,
                                    tooltipField: "DateAwarded",
                                    valueFormatter: params => {
                                        if (!params.value) return '';
                                        const d = new Date(params.value);
                                        return [
                                            String(d.getMonth() + 1).padStart(2, '0'),
                                            String(d.getDate()).padStart(2, '0'),
                                            d.getFullYear()
                                        ].join('/');
                                    }
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };

                        mainGridApi = agGrid.createGrid(gridDiv, gridOptions);
                    } else if (pMode == "UPD") {

                        // Format Date
                        response.forEach(r => {
                            if (r.DateAwarded) {
                                r.DateAwarded = new Date(r.DateAwarded);
                            }
                        });

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            loading: false,

                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    width: 75,
                                    checkboxSelection: true,
                                    sortable: false,
                                    checkboxSelection: params => {
                                        return params.data && params.data.canSelect === true;
                                    }
                                },
                                { headerName: "Form No.", field: "FormNo" },
                                { headerName: "Category", field: "Category" },
                                { headerName: "Project", field: "Project" },
                                {
                                    headerName: "BOQ",
                                    field: "Title",
                                    editable: false,
                                    tooltipField: "Title",
                                    cellRenderer: function (params) {
                                        const value = params.value || 'Select BOQ';
                                        return `
                                                <span style="cursor:pointer; display:flex; justify-content: end;align-items:center; gap:6px; font-style: italic;">
                                                    <span>${value}</span>
                                                    <span class="ag-icon ag-icon-edit"></span>
                                                </span>
                                            `;
                                    },
                                    onCellDoubleClicked: function (params) {
                                        openBOQModal(params);
                                    }
                                },
                                {
                                    headerName: "CECode",
                                    field: "CECode",
                                    tooltipField: "CECode",
                                    hide: true
                                },
                                {
                                    headerName: "Contractor",
                                    field: "Contractor",
                                    editable: false,
                                    tooltipField: "Title",
                                    cellRenderer: function (params) {
                                        const value = params.value || 'Select Contractor';
                                        return `
                                                <span style="cursor:pointer; display:flex; justify-content: end;align-items:center; gap:6px; font-style: italic;">
                                                    <span>${value}</span>
                                                    <span class="ag-icon ag-icon-edit"></span>
                                                </span>
                                            `;
                                    },
                                    onCellDoubleClicked: function (params) {
                                        openContractorModal(params);
                                    }
                                },
                                {
                                    headerName: "ContractorID",
                                    field: "ContractorID",
                                    tooltipField: "ContractorID",
                                    hide: true
                                },
                                {
                                    headerName: "Category",
                                    field: "ConCategory",
                                    editable: true,
                                    cellEditor: 'agSelectCellEditor',
                                    cellEditorParams: {
                                        values: ['Job Order', 'Contract Agreement']
                                    }
                                },

                                {
                                    headerName: "Type",
                                    field: "Type",
                                    editable: true,
                                    cellEditor: 'agSelectCellEditor',
                                    cellEditorParams: {
                                        values: ['OSM', 'Package']
                                    }
                                },

                                { headerName: "No.", field: "No", editable: true },

                                {
                                    headerName: "Price",
                                    field: "Price",
                                    editable: true,
                                    cellClass: "text-end",
                                    valueFormatter: params =>
                                        Number(params.value || 0).toLocaleString('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        })
                                },

                                {
                                    headerName: "VAT",
                                    field: "VAT",
                                    editable: true,
                                    cellClass: "text-end",
                                    valueFormatter: params =>
                                        Number(params.value || 0).toLocaleString('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        })
                                },
                                {
                                    headerName: "EWT",
                                    field: "EWT",
                                    editable: true,
                                    cellClass: "text-end",
                                    valueFormatter: params =>
                                        Number(params.value || 0).toLocaleString('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        })
                                },
                                {
                                    headerName: "Downpayment",
                                    field: "Downpayment",
                                    editable: true,
                                    cellClass: "text-end",
                                    valueFormatter: params =>
                                        Number(params.value || 0).toLocaleString('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        })
                                },
                                {
                                    headerName: "Retention Fee",
                                    field: "RetentionFee",
                                    editable: true,
                                    cellClass: "text-end",
                                    valueFormatter: params =>
                                        Number(params.value || 0).toLocaleString('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        })
                                },
                                {
                                    headerName: "Prior Start",
                                    field: "PriorStart",
                                    editable: false,
                                    cellClass: "text-end",
                                    valueFormatter: params =>
                                        Number(params.value || 0).toLocaleString('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        })
                                },
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    editable: true,
                                    cellEditor: 'agSelectCellEditor',
                                    cellEditorParams: {
                                        values: ['For Award', 'Awarded', 'Cancelled']
                                    }
                                },
                                {
                                    headerName: "Date Awarded",
                                    field: "DateAwarded",
                                    editable: true,
                                    cellEditor: 'agDateCellEditor',
                                    valueFormatter: params => {
                                        if (!params.value) return '';
                                        const d = new Date(params.value);
                                        return [
                                            String(d.getMonth() + 1).padStart(2, '0'),
                                            String(d.getDate()).padStart(2, '0'),
                                            d.getFullYear()
                                        ].join('/');
                                    }
                                }

                            ],

                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };

                        mainGridApi = agGrid.createGrid(gridDiv, gridOptions);
                    }

                    // BOQ
                    function openBOQModal(params) {

                        // AG Grid
                        window.activeGridApi = mainGridApi;  
                        // AG Grid

                        //set
                        document.getElementById("hf0101RowID").value = params.node.id;
                        document.getElementById("hf0101OldCECode").value = params.data.BOQ;
                        document.getElementById("hf0101OldTitle").value = params.data.Title;
                        //set

                        let gridDiv = document.querySelector('#table0101BOQ');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                FormCode: 'SCM110000',
                                Type: 'Awarding - Get Estimate (BOQ)',
                            },
                            beforeSend: function () {
                                // Show modal
                                $('#mdl0101BOQ').modal('show');

                                // Show Swal loader
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while data is being processed.',
                                    allowOutsideClick: false,
                                    allowEscapeKey: false,
                                    allowEnterKey: false,
                                    didOpen: () => {
                                        Swal.showLoading();
                                    }
                                });
                            },
                            dataType: "json",
                            success: function (response) {

                                gridOptions = {
                                    suppressCellFocus: true,
                                    loading: false,
                                    columnDefs: [
                                        {
                                            headerName: "Action",
                                            field: "Action",
                                            width: 75,
                                            resizable: false,
                                            sortable: false,
                                            cellRenderer: params => params.value,
                                            cellClass: "mt-1"
                                        },
                                        {
                                            headerName: "Code",
                                            field: "Code",
                                            width: 150,
                                            tooltipField: "Code"
                                        },
                                        {
                                            headerName: "Lock",
                                            field: "Lock",
                                            width: 75,
                                            resizable: false,
                                            sortable: false,
                                            cellRenderer: params => params.value,
                                            cellClass: "mt-3"
                                        },
                                        {
                                            headerName: "Title",
                                            field: "Title",
                                            tooltipField: "Title",
                                            flex: 1
                                        }
                                    ],
                                    rowData: response,
                                    pagination: true,
                                    paginationPageSize: 25
                                };
                                gridApi = agGrid.createGrid(gridDiv, gridOptions);

                                // close Swal loader when everything is done
                                Swal.close();
                            }
                        });
                    };

                    // Contractor
                    function openContractorModal(params) {

                        // AG Grid
                        window.activeGridApi = mainGridApi;
                        // AG Grid

                        //set
                        document.getElementById("hf0102RowID").value = params.node.id;
                        document.getElementById("hf0102OldCode").value = params.data.ContractorID;
                        document.getElementById("hf0102OldContractor").value = params.data.Contractor;
                        //set

                        let gridDiv = document.querySelector('#table0102Contractor');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                FormCode: 'SCM110000',
                                Type: 'Awarding - Get Contractor',
                            },
                            beforeSend: function () {
                                // Show modal
                                $('#mdl0102Contractor').modal('show');

                                // Show Swal loader
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while data is being processed.',
                                    allowOutsideClick: false,
                                    allowEscapeKey: false,
                                    allowEnterKey: false,
                                    didOpen: () => {
                                        Swal.showLoading();
                                    }
                                });
                            },
                            dataType: "json",
                            success: function (response) {

                                gridOptions = {
                                    suppressCellFocus: true,
                                    loading: false,
                                    columnDefs: [
                                        {
                                            headerName: "Action",
                                            field: "Action",
                                            width: 75,
                                            resizable: false,
                                            sortable: false,
                                            cellRenderer: params => params.value,
                                            cellClass: "mt-1"
                                        },
                                        {
                                            headerName: "Code",
                                            field: "Code",
                                            width: 150,
                                            tooltipField: "Code"
                                        },
                                        {
                                            headerName: "Lock",
                                            field: "Lock",
                                            width: 75,
                                            resizable: false,
                                            sortable: false,
                                            cellRenderer: params => params.value,
                                            cellClass: "mt-3"
                                        },
                                        {
                                            headerName: "Vendor",
                                            field: "Vendor",
                                            tooltipField: "Vendor",
                                            flex: 1
                                        }
                                    ],
                                    rowData: response,
                                    pagination: true,
                                    paginationPageSize: 25
                                };
                                gridApi = agGrid.createGrid(gridDiv, gridOptions);

                                // close Swal loader when everything is done
                                Swal.close();
                            }
                        });
                    };
                },
            });
        };
        //general

        //action
        function fn01Edit() {
            fnAccess('SCM110000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    fn01DisableButtons(true);
                    document.getElementById("btn01Cancel").classList.add("btn-delete");
                    document.getElementById("btn01Cancel").disabled = false;
                    document.getElementById("btn01Edit").classList.add("d-none");
                    document.getElementById("btn01Save").classList.add("btn-edit");
                    document.getElementById("btn01Save").disabled = false;
                    document.getElementById("i01Save").classList.remove("la-pencil-alt");
                    document.getElementById("i01Save").classList.add("la-save");
                    fn0101LoadOverview("UPD");
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                }
            });
        };
        function fn01Save() {
            fnAccess('SCM110000', 'Save', async function (response) {
                if (response[0].oReturn !== "1") {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    return;
                }

                // Confirm save
                const result = await Swal.fire({
                    html: '<span class="fs-6 fw-normal text-gray-700">Current record/changes will be saved?</span>',
                    icon: 'question',
                    iconColor: '#0095e8',
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    buttonsStyling: false,
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                });

                if (!result.isConfirmed) return;

                // Show loading
                Swal.fire({
                    title: 'Processing...',
                    text: 'Please wait while we save the changes.',
                    icon: 'info',
                    showConfirmButton: false,
                    allowOutsideClick: false,
                    didOpen: () => Swal.showLoading()
                });

                const allRows = [];

                // Loop all rows (all pages)
                mainGridApi.forEachNode(node => {
                    const row = { ...node.data };

                    row.ContractorID = row.ContractorID || "";
                    row.ConCategory = row.ConCategory || "";
                    row.Type = row.Type || "";
                    row.No = row.No || "";
                    row.Price = Number(row.Price || 0);
                    row.VAT = Number(row.VAT || 0);
                    row.EWT = Number(row.EWT || 0);
                    row.Downpayment = Number(row.Downpayment || 0);
                    row.RetentionFee = Number(row.RetentionFee || 0);
                    row.Status = row.Status || "";
                    row.CECode = row.CECode || "";
                    row.FormNo = row.FormNo || "";
                    row.Category = row.Category || "";

                    // Date
                    if (row.DateAwarded instanceof Date) {
                        const d = row.DateAwarded;
                        row.DateAwarded = [
                            d.getFullYear(),
                            String(d.getMonth() + 1).padStart(2, '0'),
                            String(d.getDate()).padStart(2, '0')
                        ].join('-');
                    }
                    // Date

                    allRows.push(row);

                });

                // Save all rows sequentially
                for (let row of allRows) {
                    if (row.Category === "House Construction" && !row.FormNo.startsWith("009") && !row.FormNo.startsWith("COF") && !row.FormNo.startsWith("CRT")) {
                        await updateRecordHC(row);
                    } else {
                        await updateRecordOTH(row);
                    }
                }

                Swal.close();
                fnAlertOnly('Record successfully saved!', 'success', 'btn btn-danger');

                // Reset buttonstb
                fn01DisableButtons(false);
                document.getElementById("btn01Edit").classList.add("btn-edit");
                document.getElementById("btn01Edit").disabled = false;
                document.getElementById("i01Edit").classList.remove("la-save");
                document.getElementById("i01Edit").classList.add("la-pencil-alt");

                fn0101LoadOverview("DTL"); // Reload

                // Update Function
                async function updateRecordHC(row) {
                    return $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: 'SCM110000',
                            Type: 'Awarding - Update Record (House Construction)',
                            pID: row.Code,
                            pContractor: row.ContractorID,
                            pConCategory: row.ConCategory,
                            pConType: row.Type,
                            pConNo: row.No,
                            pConPrice: row.Price,
                            pVAT: row.VAT,
                            pEWT: row.EWT,
                            pDP: row.Downpayment,
                            pRF: row.RetentionFee,
                            pPriorStart: row.PriorStart,
                            pConStatus: row.Status,
                            pConDate: row.DateAwarded,
                            pCECode: row.CECode
                        }
                    });
                }
                async function updateRecordOTH(row) {
                    return $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: 'SCM110000',
                            Type: 'Awarding - Update Record (OTH)',
                            pID: row.Code,
                            pContractor: row.ContractorID,
                            pConCategory: row.ConCategory,
                            pConType: row.Type,
                            pConNo: row.No,
                            pConPrice: row.Price,
                            pVAT: row.VAT,
                            pEWT: row.EWT,
                            pDP: row.Downpayment,
                            pRF: row.RetentionFee,
                            pPriorStart: row.PriorStart,
                            pConStatus: row.Status,
                            pConDate: row.DateAwarded,
                            pCECode: row.CECode
                        }
                    });
                }
            });
        };
        function fn0101BOQ(pID, pTitle, pLock) {
            //validate
            if (pLock == 1) {
                BOQ(pID, pTitle);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            function BOQ(pID, pTitle) {
                if (pID != "" || pTitle != "") {
                    let rowID = $("#hf0101RowID").val();

                    // Find grid Row
                    let rowNode = window.activeGridApi.getRowNode(rowID);

                    // Update
                    rowNode.setDataValue("CECode", pID);
                    rowNode.setDataValue("Title", pTitle);

                    // Model
                    $("#mdl0101BOQ").modal("hide");
                }
            };
        };
        function fn0102Contractor(pID, pVendor, pLock) {
            //validate
            if (pLock == 1) {
                Contractor(pID, pVendor);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            function Contractor(pID, pVendor) {
                if (pID != "" || pVendor != "") {
                    let rowID = $("#hf0102RowID").val();

                    // Find grid Row
                    let rowNode = window.activeGridApi.getRowNode(rowID);

                    // Update
                    rowNode.setDataValue("ContractorID", pID);
                    rowNode.setDataValue("Contractor", pVendor);

                    // Model
                    $("#mdl0102Contractor").modal("hide");
                }
            };
        };
        function fn01Post() {
            fnAccess('SCM110000', 'Post', async function (response) {
                if (response[0].oReturn !== "1") {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    return;
                };
                
                const selectedRows = [];

                // Loop all rows (all pages)
                const checkRows = mainGridApi.getSelectedRows();
                checkRows.forEach(row => {
                    selectedRows.push({
                        FormNo: row.FormNo,
                        Category: row.Category,

                    })
                });

                // Validate selection before confirmation
                if (selectedRows.length === 0) {
                    fnAlertOnly('No records selected!', 'warning', 'btn btn-warning');
                    return;
                };

                // Confirm post
                const confirmResult = await Swal.fire({
                    html: '<span class="fs-6 fw-normal text-gray-700">Post selected record/s?</span>',
                    icon: 'question',
                    iconColor: '#0095e8',
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    buttonsStyling: false,
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                });

                if (!confirmResult.isConfirmed) return;

                // Ask for password
                const passwordResult = await Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Post record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101PostPassword" type="password" class="form-control form-control-sm" placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx0101PostPassword");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            }
                        });
                    },
                    iconColor: '#009ef7',
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    buttonsStyling: false,
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                });

                if (!passwordResult.isConfirmed) return;

                const password = document.getElementById("tbx0101PostPassword").value;

                // Validate password
                const isPasswordValid = await new Promise(resolve => {
                    fnValidatePassword(password, function (resp) {
                        if (resp[0].oReturn === "") resolve(true);
                        else {
                            fnAlertOnly(resp[0].oReturn, 'warning', 'btn btn-warning');
                            resolve(false);
                        }
                    });
                });

                if (!isPasswordValid) return;

                // Post selected rows sequentially
                for (let row of selectedRows) {
                    if (row.Category === "House Construction" && !row.FormNo.startsWith("009") && !row.FormNo.startsWith("COF") && !row.FormNo.startsWith("CRT")) {
                        await postRecordHC(row);
                    } else {
                        await postRecordOTH(row);
                    }
                }

                Swal.close();
                fnAlertOnly('Record/s successfully posted!', 'success', 'btn btn-danger');

                // Reload
                fn0101LoadOverview("DTL");

                // Post Function
                async function postRecordHC(row) {
                    return $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: 'SCM110000',
                            Type: 'Awarding - Post Record (House Construction)',
                            pFormNo: row.FormNo,
                            pCategory: row.Category
                        },
                        dataType: 'json'
                    });
                };
                async function postRecordOTH(row) {
                    return $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: 'SCM110000',
                            Type: 'Awarding - Post Record (OTH)',
                            pFormNo: row.FormNo,
                            pCategory: row.Category
                        },
                        dataType: 'json'
                    });
                };
            });
        };
        function fn01Cancel() {
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
                    fn01DisableButtons(false);
                    document.getElementById("btn01Edit").classList.add("btn-edit");
                    document.getElementById("btn01Edit").disabled = false;
                    document.getElementById("i01Edit").classList.remove("la-save");
                    document.getElementById("i01Edit").classList.add("la-pencil-alt");
                    fn0101LoadOverview("DTL");
                };
            });
        };
        function fn01DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn01Edit").classList.remove("btn-edit");
                document.getElementById("btn01Edit").classList.remove("d-none");
                document.getElementById("btn01Save").classList.remove("btn-edit");
                document.getElementById("btn01Save").classList.remove("d-none");
                document.getElementById("btn01Cancel").classList.remove("btn-delete");
                document.getElementById("btn01Cancel").classList.remove("d-none");
                document.getElementById("btn01Post").classList.remove("btn-post");
            } else {
                document.getElementById("btn01Edit").classList.add("btn-edit");
                document.getElementById("btn01Edit").classList.remove("d-none");
                document.getElementById("btn01Save").classList.add("btn-edit");
                document.getElementById("btn01Save").classList.add("d-none");
                document.getElementById("btn01Cancel").classList.add("btn-delete");
                document.getElementById("btn01Cancel").classList.add("d-none");
                document.getElementById("btn01Post").classList.add("btn-post");
            };
            document.getElementById("btn01Edit").disabled = pValue;
            document.getElementById("btn01Cancel").disabled = pValue;
            document.getElementById("btn01Post").disabled = pValue;
        };
        //action

        //export
        function fn01Export() {
            if (mainGridApi) {
                mainGridApi.exportDataAsCsv({
                    fileName: 'Awarding.csv',
                    columnKeys: ['FormNo', 'Category', 'Project', 'Title', 'Contractor', 'ConCategory', 'Type', 'No', 'Price', 'VAT', 'EWT', 'Downpayment', 'RetentionFee', 'PriorStart', 'Status', 'DateAwarded']
                });
            }
        };
        //export

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                fn01Load();
            });
        }
        //load page

    </script>

</asp:Content>
