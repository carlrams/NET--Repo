<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM070000.aspx.vb" Inherits="NET.SCM070000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Item Receiving</li>
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
						<img src="Assets/media/svg/apps/SCM070000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Item Receiving</span>
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
                                <th class="min-w-75px mw-75px fw-bold border-end">RR No.</th>
                                <th class="min-w-75px mw-75px fw-bold border-end">RR Date</th>
                                <th class="min-w-200px w-100 fw-bold border-end">Warehouse</th>
                                <th class="min-w-250px w-100 fw-bold border-end">Origin of Transaction</th>
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
						<h5 class="modal-title">Item Receiving - Cancel Record</h5>
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
						    <input id="tbx0201Reason" type="text" class="form-control " Placeholder="Reason" />
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

    <script type="text/javascript">

		//general
		function fn01Load() {
            fnAccess('SCM070000', 'View', function (response) {
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
                        'FormCode': 'SCM070000',
                        'Type': 'Item Receiving - Get Record',
                        'pPosted': 0,
                        'pWarehouse': '',
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
                                { data: 'Code' },
                                { data: 'Lock' },
                                { data: 'Post' },
                                { data: 'Rvrs' },
                                { data: 'RRNo' },
                                { data: 'RRDate' },
                                { data: 'WhseName' },
                                { data: 'VenName' },
                                { data: 'PreparedBy' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0, 1, 2, 3, 4], orderable: false
                                },
                                {
                                    targets: [7, 8, 9], className: 'tbody-nowrap-auto'
                                }
                            ],
                            order: [[6, 'asc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });
                        //search

                        //export
                        const documentTitle = 'Item Receiving';
                        var buttons = new $.fn.dataTable.Buttons(table01Record, {
                            buttons: [
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle,
                                    exportOptions: {
                                        columns: [1, 5, 6, 7, 8, 9]
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
                //filter
                document.getElementById("cbx01Posted").checked = false;
                ddl01Warehouse('');
                $('#ddl01Warehouse').val('').trigger('change');
                //filter
            };
        };
        function fn01Redraw(Action, ID) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070000',
                        'Type': 'Item Receiving - Get Record : Redraw',
                        'pID': ID
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add({ Action: response[0].Action, Code: response[0].Code, Lock: response[0].Lock, Post: response[0].Post, Rvrs: response[0].Rvrs, RRNo: response[0].RRNo, RRDate: response[0].RRDate, WhseName: response[0].WhseName, VenName: response[0].VenName, PreparedBy: response[0].PreparedBy }).draw(false).select();
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
                            gv01.cell({ row: index01, column: 1 }).data(response[0].Code).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Lock).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Post).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Rvrs).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].RRNo).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].RRDate).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].WhseName).draw(false);
                            gv01.cell({ row: index01, column: 8 }).data(response[0].VenName).draw(false);
                            gv01.cell({ row: index01, column: 9 }).data(response[0].PreparedBy).draw(false);
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
        };
        function ddl01Warehouse(ID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM070100',
                    'Type': 'Get Record',
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
                            'FormCode': 'SCM070000',
                            'Type': 'Item Receiving - Get Record',
                            'pPosted': document.getElementById("cbx01Posted").checked,
                            'pWarehouse': document.getElementById("ddl01Warehouse").options[document.getElementById("ddl01Warehouse").selectedIndex].value,
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
                                    { data: 'Code' },
                                    { data: 'Lock' },
                                    { data: 'Post' },
                                    { data: 'Rvrs' },
                                    { data: 'RRNo' },
                                    { data: 'RRDate' },
                                    { data: 'WhseName' },
                                    { data: 'VenName' },
                                    { data: 'PreparedBy' },
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0, 1, 2, 3, 4], orderable: false
                                    },
                                    {
                                        targets: [7, 8, 9], className: 'tbody-nowrap-auto'
                                    }
                                ],
                                order: [[6, 'asc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx01Find').on('keyup', function () {
                                table01Record.search(this.value).draw();
                            });
                            //search

                            //export
                            const documentTitle = 'Item Receiving';
                            var buttons = new $.fn.dataTable.Buttons(table01Record, {
                                buttons: [
                                    {
                                        extend: 'excelHtml5',
                                        title: documentTitle,
                                        exportOptions: {
                                            columns: [1, 5, 6, 7, 8, 9]
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

        //add
        function fn01Add() {
            //access
            fnAccess('SCM070000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add_Ok() {
                window.open('SCM070100-ADD-000000000000');
            };
        }; 
        //add

        //delete
        function fn03Delete(ID) {
            //access
            fnAccess('SCM070000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
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
                        Delete_Ok(ID);
                    }
                });
            };
            //delete ok
            function Delete_Ok(ID) {
                fnDelete('SCM070000', 'Trxn_IRHdr', ID, function (response) {
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Redraw("Delete", ID);
                });
            }
        };
        //delete

        //edit
        function fn04Edit(ID) {
            //access
            fnAccess('SCM070000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Edit_Ok(ID) {
                window.open('SCM070100-UPD-' + ID);
            };
        };
        //edit

        //lock
        function fn05Lock(ID) {
            //access
            fnAccess('SCM070000', 'Lock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //lock question
            function Lock_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Lock record?</span>',
                    icon: 'question',
                    html: `<input id="tbx05Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx05Password");
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
                        fnValidatePassword(document.getElementById("tbx05Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Lock_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'Trxn_IRHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                });
            }
        };
        //lock

        //unlock
        function fn06Unlock(ID) {
            //access
            fnAccess('SCM070000', 'Unlock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Unlock', function (response) {
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
                fnLock('Unlock', 'Trxn_IRHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                });
            }
        };
        //unlock

        //post
        function fn07Post(ID) {
            //access
            fnAccess('SCM070000', 'Post', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Post', function (response) {
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
                        'pRecType': "IR",
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

        //cancel
        function fn08Rvrs(ID) {
            //access
            fnAccess('SCM070000', 'Post', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        Cancel(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Cancel(ID) {
                document.getElementById("ContentPlaceHolder1_hf0201pID").value = ID;
                $('#mdl02Cancel').modal('show');
            };
        };
        function fn0201Cancel_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hf0201pID').value, function (response) {
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
                    if (document.getElementById("tbx0201ReasonDate").value == "" || document.getElementById("tbx0201Reason").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        //Modal
                        $('#mdl02Cancel').modal('hide');
                        //Cancel question
                        Cancel_Question();
                    }
                    function Cancel_Question() {
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
                                'FormCode': 'SCM070100',
                                'Type': 'Item Receiving - Cancel Record',
                                'pID': document.getElementById('ContentPlaceHolder1_hf0201pID').value,
                                'pReasonDate': document.getElementById("tbx0201ReasonDate").value,
                                'pReason': document.getElementById("tbx0201Reason").value
                            },
                            success: function (response) {
                                //cancel
                                fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                                fn01Redraw("Edit", document.getElementById('ContentPlaceHolder1_hf0201pID').value);
                                document.getElementById("ContentPlaceHolder1_hf0201pID").value = "";
                                document.getElementById("tbx0201ReasonDate").value = "";
                                document.getElementById("tbx0201Reason").value = "";
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
        //cancel

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

</asp:Content>
