<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC050000.aspx.vb" Inherits="NET.ACC050000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">PR Status</li>
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
						<img src="Assets/media/svg/apps/ACC050000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">PR Status</span>
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
							    <th class="min-w-100px mw-100px fw-bold">PR No.</th>
								<th class="min-w-250px w-100 fw-bold border-end">Title</th>
								<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
								<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
								<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
								<th class="min-w-100px mw-100px fw-bold border-end">Form Status</th>
								<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
								<th class="min-w-100px mw-100px fw-bold border-end">PO Status</th>
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
        
		<!--begin::Modal View record-->
		<div id="mdl02View" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Order - View record</h5>
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
			            <!--begin::Card body-->
			            <div class="card-toolbar mb-2">
                            <div class="d-flex justify-content-end me-3">
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
						            <input id="tbx02Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
					            </div>
					            <!--end::Search-->
                            </div>
			            </div>
			            <div class="card-body pt-0 mt-0">
				            <!--begin::Files-->
                            <div class="table-loading" style="min-height:62.3vh;">
                                <div id="div02Loader" class="table-loading-message">
                                    Loading...
                                </div>
									<table id="table02Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>
											<tr class="fw-bold fs-7 text-gray-800">
                                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-100px mw-100px fw-bold border-end">PO No.</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Qty.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">UOM</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Cost</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Total</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Commodity</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Strategy</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Remarks</th>
												<th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Qty.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">UOM</th>
											</tr>
										</thead>
										<tbody>
						
										</tbody>
									</table>
                            </div>
                        </div>
			            <!--end::Card body-->
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
		<!--begin::Modal Add record-->
        
		<!--begin::Modal View record-->
		<div id="mdl03View" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Item Receiving - View record</h5>
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
			            <!--begin::Card body-->
			            <div class="card-toolbar mb-2">
                            <div class="d-flex justify-content-end me-3">
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
						            <input id="tbx03Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
					            </div>
					            <!--end::Search-->
                            </div>
			            </div>
			            <div class="card-body pt-0 mt-0">
				            <!--begin::Files-->
                            <div class="table-loading" style="min-height:62.3vh;">
                                <div id="div03Loader" class="table-loading-message">
                                    Loading...
                                </div>
									<table id="table03Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>
											<tr class="fw-bold fs-7 text-gray-800">
                                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-125px mw-125px fw-bold border-end">IR No.</th>
												<th class="min-w-125px mw-125px fw-bold border-end">PR No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-150px w-30 fw-bold border-end">PO No. / WT No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-150px w-70 fw-bold border-end">SI / DR No.</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Type</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-150px w-70 fw-bold border-end">Qty.</th>
												<th class="min-w-150px w-50 fw-bold border-end">UOM</th>
												<th class="min-w-150px w-50 fw-bold border-end">Cost</th>
												<th class="min-w-150px w-70 fw-bold border-end">Total</th>
												<th class="min-w-250px w-100 fw-bold border-end">Remarks</th>
											</tr>
										</thead>
										<tbody>
						
										</tbody>
									</table>
                            </div>
                        </div>
			            <!--end::Card body-->
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
		<!--begin::Modal Add record-->
        
    </div>
    <script type="text/javascript">

        //general
        function fn01Load() {
            fnAccess('ACC050000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDACC.ashx",
                    data: {
                        'pFormCode': 'ACC050000',
                        'pType': 'Get Record'
                    },
                    success: function (response) {
                        document.getElementById("div01Loader").style.display = "";

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
                                { data: 'ID' },
                                { data: 'Title' },
                                { data: 'Type' },
                                { data: 'DateCreated' },
                                { data: 'DateExpected' },
                                { data: 'FormStatus' },
                                { data: 'RequestedBy' },
                                { data: 'POStatus' }],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0, orderable: false
                                },
                                {
                                    targets: 2, className: 'tbody-nowrap-auto'
                                }
                            ],
                            initComplete: function () {
                                this.api().cells().every(function () {
                                    var cell = this.node();
                                    $(cell).attr('title', $(cell).text());
                                });
                            },
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });
                        //search

                        //export
                        const documentTitle = 'PR Status';
                        var buttons = new $.fn.dataTable.Buttons(table01Record, {
                            buttons: [
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle,
                                    exportOptions: {
                                        columns: [1, 2, 3, 4, 5, 6, 7, 8]
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
                    },
                });

            };
        };
        function fn01Toggle(button) {
            // Find the closest wrapper and toggle the child menu
            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            // Hide all other open toggle menus first
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) menu.classList.add('d-none');
            });

            // Toggle the clicked one
            if (toggleMenu) {
                toggleMenu.classList.toggle('d-none');
            }
        };
        function fn01View(pID) {
            window.open(pID, "_blank");
        };
        function fn02View(pID) {
            $.ajax({
                type: "POST",
                url: "HNDACC.ashx",
                data: {
                    'pFormCode': 'ACC050000',
                    'pType': 'PO Record',
                    'pID': pID
                },
                success: function (response) {
                    try {
                        //display loader
                        document.getElementById("div02Loader").style.display = "";
                        //display loader

                        //$('#table0102Particular').DataTable().destroy();
                        if ($.fn.DataTable.isDataTable('#table02Record')) {
                            $('#table02Record').DataTable().clear().destroy();
                        }

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table02Record = $("#table02Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: false,
                            bInfo: false,
                            scrollCollapse: true,
                            paging: false,
                            lengthChange: false,
                            select: true,
                            data: response,
                            rowCallback: function (row, data, index) {
                                if (index % 2 === 0) {
                                    $(row).css('background-color', '#f0f9ff');
                                } else {
                                    $(row).css('background-color', '#ffffff');
                                }
                            },
                            columns: [
                                { data: 'Action' },
                                { data: 'PONo' },
                                { data: 'ItemName' },
                                { data: 'Qty' },
                                { data: 'UMName' },
                                { data: 'Cost' },
                                { data: 'Total' },
                                { data: 'Classification' },
                                { data: 'Commodity' },
                                { data: 'Remarks' },
                                { data: 'PRNo' },
                                { data: 'PRSeqNo' },
                                { data: 'PRItem' },
                                { data: 'PRQty' },
                                { data: 'PRUnit' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false
                                },
                                {
                                    targets: [3, 5, 6, 13],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                },
                                {
                                    targets: [2, 7, 8, 9, 12],
                                    className: 'tbody-nowrap-auto'
                                }
                            ],
                            initComplete: function () {
                                this.api().cells().every(function () {
                                    var cell = this.node();
                                    $(cell).attr('title', $(cell).text());
                                });
                            },
                            ordering: false
                        });
                        //datatable

                        //search
                        $('#tbx02Find').on('keyup', function () {
                            table02Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div02Loader").style.display = "none";
                        //hide loader

                        $("#mdl02View").modal("show");

                    } catch (err) {
                        console.error('Error initializing DataTable:', err);
                    };
                },
            });
        };
        function fn02ViewPO(pID) {
            window.open("SCM060100-DTL-" + pID, "_blank");
        };
        function fn03View(pID) {
            $.ajax({
                type: "POST",
                url: "HNDACC.ashx",
                data: {
                    'pFormCode': 'ACC050000',
                    'pType': 'IR Record',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div03Loader").style.display = "";
                    //display loader

                    $('#table03Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table03Record = $("#table03Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        rowCallback: function (row, data, index) {
                            if (index % 2 === 0) {
                                $(row).css('background-color', '#f0f9ff');
                            } else {
                                $(row).css('background-color', '#ffffff');
                            }
                        },
                        columns: [
                            { data: 'Action' },
                            { data: 'IRNo' },
                            { data: 'PRNo' },
                            { data: 'PRSeqNo' },
                            { data: 'PONo' },
                            { data: 'POSeqNo' },
                            { data: 'SIDRNo' },
                            { data: 'Type' },
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMInit' },
                            { data: 'Cost' },
                            { data: 'Total' },
                            { data: 'Remarks' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false
                            },
                            {
                                targets: [9, 11, 12],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [8, 13],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        },
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx03Find').on('keyup', function () {
                        table03Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div03Loader").style.display = "none";
                    //hide loader

                    $("#mdl03View").modal("show");
                },
            });
        };
        function fn03ViewIR(pID) {
            window.open("SCM070100-DTL-" + pID, "_blank");
        };
        //general

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
