<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM120000.aspx.vb" Inherits="NET.SCM120000"  MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Contract Cancellation</li>
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
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/SCM120000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Contract Cancellation</span>
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
                        <div class="d-flex gap-1">
                            <button type="button" id="btn01Refresh" class="btn btn-sm btn-icon btn-view" style="width: 32px; height: 32px;" title="Refresh Record" onclick="fn01Refresh(); return false;">
                                <i class="las la-redo-alt fs-2"></i>
                            </button>
                            <button type="button" id="btn01Cancel" class="btn btn-sm btn-icon btn-cancel" style="width: 32px; height: 32px;" title="Cancel Record" onclick="fn01Cancel(); return false;">
                                <i class="las la-times-circle fs-3"></i>
                            </button>
                        </div>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options" style="margin-left: 3px;">
                            <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                           <i class="las la-bars fs-3"></i>
                            <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
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
			<div class="card-body table-loading table-responsive" style="overflow-x: hidden;">
				<!--begin::Files-->
                <div id="div01Loader" class="table-loading-message">
                    Loading...
                </div>
                <table id="table01Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					<thead>
						<tr class="fw-bold fs-7 text-gray-800">
							<th class="min-w-50px mw-50px fw-bold"></th>
							<th class="min-w-150px mw-150px fw-bold">Form No.</th>
							<th class="min-w-250px mw-250px fw-bold">Category</th>
							<th class="min-w-150px mw-150px fw-bold">Project</th>
							<th class="min-w-250px mw-250px fw-bold">Remarks</th>
							<th class="min-w-250px w-100 fw-bold">Contractor</th>
							<th class="min-w-100px mw-100px fw-bold">Status</th>
							<th class="d-none"></th>
						</tr>
					</thead>
					<tbody>
							
					</tbody>
				</table>
				<!--end::Files-->
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->
        
    </div>
	
    <script type="text/javascript">

        //general
        function fn01Load() {
            fnAccess('SCM120000', 'View', function (response) {
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
                        'FormCode': 'SCM120000',
                        'Type': 'Cancellation - Get Record'
                    },
                    success: function (response) {

                        //display loader
                        document.getElementById("div01Loader").style.display = "";
                        //display loader

                        // Remove all rows
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
                            autoWidth: false,
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
                                {
                                    data: 'CheckBox',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let textbox = `
                                                           <div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'>
                                                                <input prm0101CheckBox="${rowId}" data-form-no="${row.Category}" data-code="${row.CRTCode}" class='form-check-input widget-9-check' type='checkbox'/>
                                                           </div>
                                                        `;
                                            return textbox || "";
                                        }
                                        return data;
                                    }
                                },
                                { data: 'FormNo' },
                                { data: 'Category' },
                                { data: 'Project' },
                                { data: 'Remarks' },
                                { data: 'Contractor' },
                                { data: 'Status' },
                                { data: 'CRTCode', visible: false }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false
                                },
                                {
                                    targets: [1, 2, 3, 4, 5],
                                    className: 'tbody-nowrap-auto'
                                },
                                {
                                    targets: [7],
                                    orderable: false,
                                    searchable: false
                                }
                            ],
                            //order: [[3, 'desc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01Loader").style.display = "none";
                        //hide loader
                        //export
                        const documentTitle = 'Contract Cancellation';
                        var buttons = new $.fn.dataTable.Buttons(table01Record, {
                            buttons: [
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle,
                                    exportOptions: {
                                        columns: [0, 1, 2, 3, 4, 5, 6]
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

                        //hide loader
                        document.getElementById("div01Loader").style.display = "none";
                        //hide loader
                    },
                });
            };
        };
        //general

        //action
        function fn01Refresh() {
            fn01Load();
        };
        function fn01Cancel() {
            fnAccess('SCM120000', 'Unpost', async function (response) {
                if (response[0].oReturn !== "1") {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    return;
                };

                const table = $('#table01Record').DataTable();
                const selectedRows = [];

                // Collect all checked rows across all pages
                table.rows().every(function () {
                    const rowData = this.data();
                    const rowNode = this.node();
                    const isChecked = $(rowNode).find('.widget-9-check').prop('checked');

                    if (isChecked) {
                        selectedRows.push(rowData);
                    }
                });

                // Validate selection before confirmation
                if (selectedRows.length === 0) {
                    fnAlertOnly('No records selected!', 'warning', 'btn btn-warning');
                    return;
                };

                // Confirm post
                const confirmResult = await Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Cancel selected record/s?</span>',
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
                    title: '<span class="fs-6 fw-normal text-gray-700">Cancel record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101CancelPassword" type="password" class="form-control form-control-sm" placeholder="Password" maxlength="20" />`,
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

                const password = document.getElementById("tbx0101CancelPassword").value;

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
                    await cancelRecord(row);
                };

                Swal.close();
                fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');

                //reload
                fn01Refresh();

                async function cancelRecord(row) {
                    return $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: 'SCM120000',
                            Type: 'Cancellation - Cancel Record',
                            pCategory: row.Category,
                            pCRTCode: row.CRTCode
                        },
                        dataType: 'json'
                    });
                };
            });
        };
        //action

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
