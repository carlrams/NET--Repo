<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC060000.aspx.vb" Inherits="NET.ACC060000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Warehouse Monitoring</li>
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
						<img src="Assets/media/svg/apps/ACC060000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Warehouse Monitoring</span>
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
							    <th class="min-w-200px mw-200px fw-bold">Warehouse</th>
                                <th class="min-w-200px mw-200px fw-bold">Classification</th>
							    <th class="min-w-150px w-100 fw-bold">Item</th>
							    <th class="min-w-75px w-100 fw-bold">Qty</th>
							    <th class="min-w-75px w-100 fw-bold">Unit</th>
							    <th class="min-w-150px w-100 fw-bold">Cost</th>
							    <th class="min-w-150px w-100 fw-bold">Total</th>
						    </tr>
					    </thead>
					    <tbody>
							
					    </tbody>
                        <tfoot>
						    <tr>
                                <th></th>
							    <th></th>
                                <th class="text-dark fw-bolder">Total</th>
							    <th class="text-dark fw-bolder text-end"></th>
							    <th></th>
							    <th class="text-dark fw-bolder text-end"></th>
							    <th class="text-dark fw-bolder text-end"></th>
						    </tr>
                        </tfoot>
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
						<h5 class="modal-title">Warehouse Monitoring - Filter record</h5>
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
						<div class="input-group input-group-sm danger p-1 mb-2">
							<select id="ddl01Warehouse" data-kt-repeater="select2" data-dropdown-parent="#mdl01Filter" class="form-select form-select-sm form-select-border ">
								<option value="">Warehouse</option>
							</select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx01Item" type="text" class="form-control form-control-sm border-0 m-0" readonly placeholder="Item" />
								<input id="hf01ItemCode" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn01Item(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<input id="tbx01Date" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
						</div>
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
        
		<!--begin::Modal Search record-->
		<div id="mdl01Item" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Item - Search record</h5>
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
                                    <input id="tbx01FindItem" type="text" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div01LoaderItem" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01RecordItem" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Item Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">Lock</th>
                                        <th class="min-w-250px w-100 fw-bold border-end">Item</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
    </div>
	
    <script type="text/javascript">
		//general
		function fn01Load() {
            fnAccess('ACC060000', 'View', function (response) {
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
                        'pFormCode': 'ACC060000',
                        'pType': 'Get Record',
                        'pItem': '',
                        'pDate': '',
                        'pWarehouse': ''
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
                                { data: 'WhseName' },
                                { data: 'ClassName' },
                                { data: 'ItemName' },
                                { data: 'Qty' },
                                { data: 'UMName' },
                                { data: 'Cost' },
                                { data: 'Total' }],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [3, 5, 6],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                },
                                {
                                    targets: [0 ,1 ,2], className: 'tbody-nowrap-auto'
                                }
                            ],
                            footerCallback: function (row, data, start, end, display) {
                                var api = this.api();

                                function sumColumn(colIndex) {
                                    return api.column(colIndex, { search: 'applied' }).data().reduce(function (a, b) {
                                        return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                                    }, 0);
                                }

                                var qtyTotal = sumColumn(3);
                                var costTotal = sumColumn(5);
                                var overallTotal = sumColumn(6);

                                $(api.column(3).footer()).html(qtyTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));
                                $(api.column(5).footer()).html(costTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));
                                $(api.column(6).footer()).html(overallTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));
                            },
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
                        const documentTitle = 'Warehouse Monitoring';
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

                //filter
                document.getElementById("tbx01Item").value = "";
                document.getElementById("hf01ItemCode").value = "";
                document.getElementById("tbx01Date").value = "";
                ddl01Warehouse('');
                //filter
            };
        };
		//general

        //filter
        function fn01Filter() {
            ddl01Warehouse('');
            $('#mdl01Filter').modal('show');
        };
        function ddl01Warehouse(ID) {
            $.ajax({
                type: "POST",
                url: "HNDACC.ashx",
                data: {
                    'pType': 'Dropdown',
                    'pTblName': 'Mstr_Warehouse',
                    'pPlaceHolder': 'Warehouse',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl01Warehouse").html(s);
                    $('#ddl01Warehouse').val(ID).trigger('change');
                },
            });
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
                        url: "HNDACC.ashx",
                        data: {
                            'pFormCode': 'ACC060000',
                            'pType': 'Get Record',
                            'pItem': document.getElementById("hf01ItemCode").value,
                            'pDate': document.getElementById("tbx01Date").value,
                            'pWarehouse': document.getElementById("ddl01Warehouse").options[document.getElementById("ddl01Warehouse").selectedIndex].value
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
                                    { data: 'WhseName' },
                                    { data: 'ClassName' },
                                    { data: 'ItemName' },
                                    { data: 'Qty' },
                                    { data: 'UMName' },
                                    { data: 'Cost' },
                                    { data: 'Total' }],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [3, 5, 6],
                                        className: 'dt-body-right',
                                        render: $.fn.dataTable.render.number(',', '.', 2)
                                    },
                                    {
                                        targets: [0, 1, 2], className: 'tbody-nowrap-auto'
                                    }
                                ],
                                footerCallback: function (row, data, start, end, display) {
                                    var api = this.api();

                                    function sumColumn(colIndex) {
                                        return api.column(colIndex, { search: 'applied' }).data().reduce(function (a, b) {
                                            return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                                        }, 0);
                                    }

                                    var qtyTotal = sumColumn(3);
                                    var costTotal = sumColumn(5);
                                    var overallTotal = sumColumn(6);

                                    $(api.column(3).footer()).html(qtyTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));
                                    $(api.column(5).footer()).html(costTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));
                                    $(api.column(6).footer()).html(overallTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));
                                },
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
                            const documentTitle = 'Warehouse Monitoring';
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

                            //filter
                            document.getElementById("tbx01Item").value = "";
                            document.getElementById("hf01ItemCode").value = "";
                            document.getElementById("tbx01Date").value = "";
                            ddl01Warehouse('');
                            //filter

                            $("#mdl01Filter").modal("hide");
                        },
                    });
                });
            };
        };
        function fn01Item() {
            if (document.getElementById("ddl01Warehouse").options[document.getElementById("ddl01Warehouse").selectedIndex].value == "") {
                fnAlertOnly('Please select a warehouse!', 'error', 'btn btn-danger');
            } else {
                //item
                $.ajax({
                    type: "POST",
                    url: "HNDACC.ashx",
                    data: {
                        'pFormCode': 'ACC060000',
                        'pType': 'Get Record : Item',
                        'pWarehouse': document.getElementById("ddl01Warehouse").options[document.getElementById("ddl01Warehouse").selectedIndex].value
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div01LoaderItem").style.display = "";
                        //display loader

                        $('#table01RecordItem').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table01RecordItem = $("#table01RecordItem").DataTable({
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
                                { data: 'ItemCode' },
                                { data: 'Lock' },
                                { data: 'ItemName' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0, orderable: false
                                },
                                {
                                    targets: 3, className: 'tbody-nowrap-auto'
                                }
                            ],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01FindItem').on('keyup', function () {
                            table01RecordItem.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01LoaderItem").style.display = "none";
                        //hide loader

                        //modal
                        $('#mdl01Item').modal('show');
                    },
                });
            };
        };
        function fn01GetItem(pItem, pID, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItem, pID);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            function Item(pItem, pID) {
                document.getElementById("tbx01Item").value = pItem;
                document.getElementById("hf01ItemCode").value = pID;
                $("#mdl01Item").modal("hide");
            };
        };
        //filter

        //view
        function fn01View(ID, SeqNo) {
            fn01View_Ok();
            //function
            async function fn01View_Ok() {
                await fn01View_Ok_Await();
            };
            async function fn01View_Ok_Await(){
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDACC.ashx",
                        data: {
                            'pFormCode': 'ACC040000',
                            'pType': 'Get Info',
                            'pID': ID,
                            'pSeqNo': SeqNo
                        },
                        success: function (response) {
                            //display loader
                            document.getElementById("div0101Loader").style.display = "";
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
                                bPaginate: true,
                                bInfo: false,
                                paging: true,
                                lengthChange: true,
                                pageLength: 25,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'ItemName' },
                                    { data: 'Qty' },
                                    { data: 'UMName' },
                                    { data: 'Remarks' },
                                    { data: 'PRNo' },
                                    { data: 'PRSeqNo' },
                                    { data: 'PRItem' },
                                    { data: 'PRQty' },
                                    { data: 'PRUnit' },
                                    { data: 'Status' }],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: 0, orderable: false
                                    },
                                    {
                                        targets: [1, 4, 7], className: 'tbody-nowrap-auto'
                                    }
                                ],
                                order: [[2, 'asc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx0101Find').on('keyup', function () {
                                table0101Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div0101Loader").style.display = "none";
                            //hide loader

                            //condition
                            if (response.length > 10) {
                                fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                            };
                            //condition

                            //resolve
                            resolve();
                        },
                    });
                });
            };

            //modal
            $('#mdl01View').modal('show');
        };
        //view

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

                fn01Load();
            });
        }
        //load page
    </script>

</asp:Content>
