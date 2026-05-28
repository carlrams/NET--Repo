<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC040000.aspx.vb" Inherits="NET.ACC040000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">PR Monitoring</li>
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
						<img src="Assets/media/svg/apps/ACC040000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">PR Monitoring</span>
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
							    <th class="min-w-100px mw-100px fw-bold">PR No.</th>
							    <th class="min-w-100px mw-100px fw-bold">Date Required</th>
							    <th class="min-w-50px mw-50px fw-bold">No.</th>
							    <th class="min-w-150px w-100 fw-bold">Item</th>
							    <th class="min-w-75px w-100 fw-bold">Qty</th>
							    <th class="min-w-75px w-100 fw-bold">Unit</th>
							    <th class="min-w-150px w-100 fw-bold">Status</th>
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
		<div id="mdl01View" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">PR Monitoring - View record</h5>
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
						            <input id="tbx0101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
					            </div>
					            <!--end::Search-->
                            </div>
			            </div>
			            <div class="card-body pt-0 mt-0">
				            <!--begin::Files-->
                            <div class="table-loading" style="min-height:62.3vh;">
                                <div id="div0101Loader" class="table-loading-message">
                                    Loading...
                                </div>
                                <table id="table0101Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					                <thead>
                                        <tr class="fw-bold fs-7 text-gray-800">
                                            <th colspan="5" class="w-100 align-middle border-bottom border-end fw-bold">SI Items</th> 
                                            <th colspan="6" class="w-100 align-middle border-bottom border-end fw-bold">PR Reference</th> 
                                        </tr>
						                <tr class="fw-bold fs-7 text-gray-800">
							                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
							                <th class="min-w-150px w-100 fw-bold">Item</th>
							                <th class="min-w-75px w-100 fw-bold">Qty.</th>
							                <th class="min-w-75px w-100 fw-bold">Unit</th>
							                <th class="min-w-150px w-100 fw-bold border-end">Remarks</th>
							                <th class="min-w-150px w-100 fw-bold">PR No.</th>
							                <th class="min-w-50px mw-50px fw-bold">PR #</th>
							                <th class="min-w-150px w-100 fw-bold">PR Item</th>
							                <th class="min-w-75px w-100 fw-bold">Qty.</th>
							                <th class="min-w-75px w-100 fw-bold">Unit</th>
							                <th class="min-w-75px w-100 fw-bold">Status</th>
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
        
    </div>

    <script type="text/javascript">
		//general
		function fn01Load() {
            fnAccess('ACC040000', 'View', function (response) {
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
                        'pFormCode': 'ACC040000',
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
                                { data: 'PRNo' },
                                { data: 'DateRequired' },
                                { data: 'SeqNo' },
                                { data: 'ItemName' },
                                { data: 'Qty' },
                                { data: 'Unit' },
                                { data: 'Status' }],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0, orderable: false
                                },
                                {
                                    targets: 4, className: 'tbody-nowrap-auto'
                                }
                            ],
                            order: [[2, 'desc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });
                        //search

                        //export
                        const documentTitle = 'PR Monitoring';
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
                document.getElementById("cbx01Posted").checked = false;
                //filter
            };
        };
        function fn01Redraw(Action, SICode, ID, SeqNo) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDACC.ashx",
                    data: {
                        'pFormCode': 'ACC040000',
                        'pType': 'Get Record - Redraw',
                        'pSICode': SICode,
                        'pID': ID,
                        'pSeqNo': SeqNo
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add(
                                {
                                    Action: response[0].Action,
                                    PRNo: response[0].PRNo,
                                    DateRequired: response[0].DateRequired,
                                    SeqNo: response[0].SeqNo,
                                    ItemName: response[0].ItemName,
                                    Qty: response[0].Qty,
                                    Unit: response[0].Unit,
                                    Status: response[0].Status
                                }
                            ).draw(false).select();
                            $(row01.node()).attr('id', response[0].rowId);
                            //add row

                            //select and go to record
                            let new01 = gv01.row('#' + response[0].rowId);
                            let index01 = new01.index();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        } else if (Action == "Edit") {
                            //update row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].PRNo).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].DateRequired).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].SeqNo).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].ItemName).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].Qty).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].Unit).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].Status).draw(false);
                            //update row

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
                let pCode = ID + '' + SeqNo;
                gv01.row('#rowID01' + pCode).remove().draw(false);
            };
        };
        function fn0101Redraw(Action, SICode, ID, SeqNo) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDACC.ashx",
                    data: {
                        'pFormCode': 'ACC040000',
                        'pType': 'Get Info - Redraw',
                        'pSICode': SICode,
                        'pID': ID,
                        'pSeqNo': SeqNo,
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv0101 = $('#table0101Record').DataTable();
                            gv0101.rows().deselect();
                            var row0101 = gv0101.row.add(
                                {
                                    Action: response[0].Action,
                                    ItemName: response[0].ItemName,
                                    Qty: response[0].Qty,
                                    UMName: response[0].UMName,
                                    Remarks: response[0].Remarks,
                                    PRNo: response[0].PRNo,
                                    PRSeqNo: response[0].PRSeqNo,
                                    PRItem: response[0].PRItem,
                                    PRQty: response[0].PRQty,
                                    PRUnit: response[0].PRUnit,
                                    Status: response[0].Status
                                }
                            ).draw(false).select();
                            $(row0101.node()).attr('id', response[0].rowId);
                            //add row

                            //select and go to record
                            let new0101 = gv0101.row('#' + response[0].rowId);
                            let index0101 = new0101.index();
                            var rowNode = gv0101.row(index0101).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        } else if (Action == "Edit") {
                            //update row
                            var gv0101 = $('#table0101Record').DataTable();
                            gv0101.rows().deselect();
                            let row0101 = gv0101.row('#' + response[0].rowId);
                            let index0101 = row0101.index();
                            gv0101.cell({ row: index0101, column: 0 }).data(response[0].Action).draw(false);
                            gv0101.cell({ row: index0101, column: 1 }).data(response[0].ItemName).draw(false);
                            gv0101.cell({ row: index0101, column: 2 }).data(response[0].Qty).draw(false);
                            gv0101.cell({ row: index0101, column: 3 }).data(response[0].UMName).draw(false);
                            gv0101.cell({ row: index0101, column: 4 }).data(response[0].Remarks).draw(false);
                            gv0101.cell({ row: index0101, column: 5 }).data(response[0].PRNo).draw(false);
                            gv0101.cell({ row: index0101, column: 6 }).data(response[0].PRSeqNo).draw(false);
                            gv0101.cell({ row: index0101, column: 7 }).data(response[0].PRItem).draw(false);
                            gv0101.cell({ row: index0101, column: 8 }).data(response[0].PRQty).draw(false);
                            gv0101.cell({ row: index0101, column: 9 }).data(response[0].PRUnit).draw(false);
                            gv0101.cell({ row: index0101, column: 10 }).data(response[0].Status).draw(false);
                            //update row

                            //select and go to record
                            row0101.select();
                            var rowNode = gv0101.row(index0101).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        };
                    },
                });
            } else {
                //assigned
                var gv01 = $('#table0101Record').DataTable();
                gv01.row('#rowID0101' + SICode + SeqNo).remove().draw(false);
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
                        url: "HNDACC.ashx",
                        data: {
                            'pFormCode': 'ACC040000',
                            'pType': 'Get Record - HDR',
                            'pPosted': document.getElementById("cbx01Posted").checked,
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
                                    { data: 'PRNo' },
                                    { data: 'DateRequired' },
                                    { data: 'SeqNo' },
                                    { data: 'ItemName' },
                                    { data: 'Qty' },
                                    { data: 'Unit' },
                                    { data: 'Status' }],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: 0, orderable: false
                                    },
                                    {
                                        targets: 4, className: 'tbody-nowrap-auto'
                                    }
                                ],
                                order: [[2, 'desc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx01Find').on('keyup', function () {
                                table01Record.search(this.value).draw();
                            });
                            //search

                            //export
                            const documentTitle = 'PR Monitoring';
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

        //received
        function fn0101Received(SICode, ID, SeqNo) {
            //access
            fnAccess('ACC040000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Received_Question(SICode, ID, SeqNo);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //received question
            function Received_Question(SICode, ID, SeqNo) {
                Swal.fire({
                    title:'<span class="fs-6 fw-normal text-gray-700">Mark item as received?</span>',
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
                        Received_Ok_Wait(SICode, ID, SeqNo);
                    }
                });
            };
            function Received_Ok_Wait(SICode, ID, SeqNo) {
                // Update Record
                $.ajax({
                    type: "POST",
                    url: "HNDACC.ashx",
                    data: {
                        'pFormCode': 'ACC040000',
                        'pType': 'Edit Record Info',
                        'pSICode': SICode,
                        'pID': ID,
                        'pSeqNo': SeqNo,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        //HDR
                        fn01Redraw("Edit", response[0].oSICode, response[0].oID, response[0].oSeqNo);
                        //DTL
                        fn0101Redraw("Edit", response[0].oSICode, response[0].oID, response[0].oSeqNo);
                    },
                });
            };
        };
        //received

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
