<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AMD010000.aspx.vb" Inherits="NET.AMD010000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Fixed Asset Type</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" onclick="fn02Add();return false;">Add New</a>
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
						<img src="Assets/media/svg/apps/AMD010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Fixed Asset Type</span>
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
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
							    <th class="min-w-150px w-100 fw-bold">Description</th>
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
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Fixed Asset Type - View record</h5>
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
                        <div class="input-group input-group-sm">
                            <span class="input-group-text min-w-150px">Description</span>
                            <input id="tbx01Description" type="text" class="form-control" Placeholder="Description" maxlength="60" readonly />
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Add record-->
		<div id="mdl02Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Fixed Asset Type - Add record</h5>
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
                        <div class="input-group input-group-sm">
                            <span class="input-group-text min-w-150px required">Description</span>
                            <input id="tbx02Description" type="text" class="form-control" Placeholder="Description" maxlength="60" />
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn02Add_Ok(this);return false;" title="Filter record">
                            <span class="indicator-label">
				                Add
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
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Edit record-->
		<div id="mdl04Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Fixed Asset Type - Edit record</h5>
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
                        <input id="hdn04ID" type="hidden" />
                        <div class="input-group input-group-sm">
                            <span class="input-group-text min-w-150px required">Description</span>
                            <input id="tbx04Description" type="text" class="form-control" Placeholder="Description" maxlength="60" />
                        </div>
					</div>
                     <!--begin::Actions-->
                     <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn04Edit_Ok(this);return false;">
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
		<!--begin::Modal Edit record-->

    </div>
    <!--content-->

	<!-- scripts related to this page -->
    <script type="text/javascript">

        //general
        function fn01Load() {
            document.getElementById("div01Loader").style.display = "";
            fnAccess('AMD010000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD010000',
                        'pType': 'Get Record'
                    },
                    success: function (response) {
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
                                { data: 'Lock' },
                                { data: 'Description' }],
                            rowId: 'rowId',
                            columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }],
                            order: [[2, 'asc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });
                        //search

                        //export
                        const documentTitle = 'Fixed Asset Type';
                        var buttons = new $.fn.dataTable.Buttons(table01Record, {
                            buttons: [
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle,
                                    exportOptions: {
                                        columns: [3]
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
        function fn01Redraw(Action, ID) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD010000',
                        'pType': 'Redraw',
                        'pID': ID
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add({ Action: response[0].Action, Lock: response[0].Lock, Description: response[0].Description }).draw(false).select();
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
                            gv01.cell({ row: index01, column: 1 }).data(response[0].Lock).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Description).draw(false);
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
                gv01.row('#rowID01' + ID).remove().draw(false);
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

        //view
        function fn01View(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAMD.ashx",
                data: {
                    'pFormCode': 'AMD010000',
                    'pType': 'Get Info',
                    'pID': ID
                },
                success: function (response) {
                    document.getElementById("tbx01Description").value = response[0].Description;
                    $('#mdl01View').modal('show');
                },
            });
        };
        //view

        //add
        function fn02Add() {
            //validate access
            fnAccess('AMD010000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                document.getElementById("tbx02Description").value = "";
                $('#mdl02Add').modal('show');
            }
        };
        function fn02Add_Ok(Btn) {
            //validate access
            fnAccess('AMD010000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            async function Add_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn02Add_Ok_Await(Btn);
                // Disable the clicked button to avoid multiple clicks
            }
        }
        async function fn02Add_Ok_Await(Btn) {
            // process
            return new Promise(resolve => {
                //Validate
                if (document.getElementById("tbx02Description").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Add_Ok_Question();
                }
                //qeustion
                function Add_Ok_Question() {
                    Swal.fire({
                        text: 'Save record?',
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
                            Add_Ok_Await();
                        }
                    });
                };
                //add
                function Add_Ok_Await() {
                    // Do Billing
                    $.ajax({
                        type: "POST",
                        url: "HNDAMD.ashx",
                        data: {
                            'pFormCode': 'AMD010000',
                            'pType': 'Add Record',
                            'pDescription': document.getElementById("tbx02Description").value,
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            document.getElementById("tbx02Description").value = '';
                            fn01Redraw("Add", response[0].oID);
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
        }
        //add

        //delete
        function fn03Delete(ID) {
            //access
            fnAccess('AMD010000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Mstr_FAType', ID, '', 'Delete', function (response) {
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
                        Delete_Ok(ID);
                    }
                });
            };
            //delete ok
            function Delete_Ok(ID) {
                fnDelete('AMD010000', 'Mstr_FAType', ID, function (response) {
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Redraw("Delete", ID);
                });
            }
        };
        //delete

        //edit
        function fn04Edit(ID) {
            //access
            fnAccess('AMD010000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Mstr_FAType', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Edit(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD010000',
                        'pType': 'Get Info',
                        'pID': ID
                    },
                    success: function (response) {
                        document.getElementById("hdn04ID").value = ID;
                        document.getElementById("tbx04Description").value = response[0].Description;
                        $('#mdl04Edit').modal('show');
                    },
                });
            }
        };
        function fn04Edit_Ok(Btn) {
            //access
            fnAccess('AMD010000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Edit_Ok();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            async function Edit_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn04Edit_Ok_Await(Btn);
            }
        }
        async function fn04Edit_Ok_Await(Btn) {
            // process
            return new Promise(resolve => {
                //Validate
                if (document.getElementById("tbx04Description").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Edit_Ok_Question();
                }
                //Edit question
                function Edit_Ok_Question() {
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
                            Edit_Ok_Await();
                        }
                    });
                };
                //edit ok
                function Edit_Ok_Await() {
                    // Do Billing
                    $.ajax({
                        type: "POST",
                        url: "HNDAMD.ashx",
                        data: {
                            'pFormCode': 'AMD010000',
                            'pType': 'Edit Record',
                            'pID': document.getElementById("hdn04ID").value,
                            'pDescription': document.getElementById("tbx04Description").value,
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            fn01Redraw("Edit", document.getElementById("hdn04ID").value);
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
        }
        //edit

        //lock
        function fn05Lock(ID) {
            //access
            fnAccess('AMD010000', 'Lock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Mstr_FAType', ID, '', 'Lock', function (response) {
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
                    html:`<input id="tbx05Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
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
                fnLock('Lock', 'Mstr_FAType', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                });
            }
        };
        //lock

        //unlock
        function fn06Unlock(ID) {
            //access
            fnAccess('AMD010000', 'Unlock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Mstr_FAType', ID, '', 'Unlock', function (response) {
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
                    iconColor: '#009ef7',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    },
                    allowEscapeKey: false,
                }).then((result) => {
                    if (result.isConfirmed) {
                        fnValidatePassword(document.getElementById("tbx06Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Unlock_Ok(ID);
                            } else {
                                return false;
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'Mstr_FAType', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                });
            }
        };
        //unlock

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox
            });
            jQuery(function ($) {
                fn01Load();
            });
        }
        //load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
