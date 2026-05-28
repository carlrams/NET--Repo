<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="PDD030000.aspx.vb" Inherits="NET.PDD030000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">House Models</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" onclick="fn0101Add();return false;">Add New</a>
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
						<img src="Assets/media/svg/apps/PDD030000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">House Models</span>
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
                                <th class="min-w-200px w-70 fw-bold border-end">Name</th>
							    <th class="min-w-300px mw-300px fw-bold border-end">Internal</th>
							    <th class="min-w-300px mw-300px fw-bold border-end">Marketing</th>
							    <th class="min-w-200px w-30 fw-bold border-end">Finish</th>
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
        <div id="mdl01View" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
		        <div class="modal-content">
			        <div class="modal-header">
				        <!--begin::Title-->
                        <div class="d-flex flex-column">
		                    <h2 class="mb-1"><span id="spn0101Title">-</span></h2>
		                    <div class="text-muted fw-bolder">
			                    <span id="spn0101ID">-</span>
			                    <span class="mx-3">|</span>
			                    <span id="spn0101Status">-</span>
		                    </div>
                        </div>
                        <!--end::Title-->
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
                    <div class="card-header">
                        <div class="d-flex">
                            <button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
                            <span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
                            <button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0101Add();return false;"><i class="las la-plus fs-2"></i></button>
                            <button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
                            <button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
                            <span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
                            <div class="form-check form-check-custom form-check-success form-check-solid form-check-lg m-1">
                                <input class="form-check-input" type="checkbox" value="" id="cbx0101Lock" onclick="return false;"/>
                            </div>
                            <button id="btn0101Lock" class="btn btn-sm btn-icon btn-lock align-self-center m-1" title="Lock" onclick="fn0101Lock();return false;"><i class="las la-lock fs-2"></i></button>
                            <button id="btn0101Unlock" class="btn btn-sm btn-icon btn-lock align-self-center m-1" title="Unlock" onclick="fn0101Unlock();return false;"><i class="las la-unlock fs-2"></i></button>
                        </div>
                    </div>
			        <div class="modal-body">
                        <div id="div0101Detail">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Name</span>
                                <span id="lbl0101Name" type="text" class="form-control" placeholder="Name"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Internal</span>
                                <span id="lbl0101Internal" type="text" class="form-control" placeholder="Internal"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Marketing</span>
                                <span id="lbl0101Marketing" type="text" class="form-control" placeholder="Marketing"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Finish</span>
                                <span id="lbl0101Finish" type="text" class="form-control" placeholder="Office Address"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Min. Lot Area</span>
                                <span id="lbl0101MinLotArea" type="text" class="form-control" placeholder="Min. Lot Area"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Lot Dimension</span>
                                <span id="lbl0101LotDimension" type="text" class="form-control" placeholder="Lot Dimension"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Type</span>
                                <span id="lbl0101Type" type="text" class="form-control" placeholder="Type"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Storey</span>
                                <span id="lbl0101Storey" type="text" class="form-control" placeholder="Storey"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Gross Floor Area</span>
                                <span id="lbl0101GrossFloorArea" type="text" class="form-control" placeholder="Gross Floor Area"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Net Floor Area</span>
                                <span id="lbl0101NetFloorArea" type="text" class="form-control" placeholder="Net Floor Area"></span>
                            </div>
                            <div class="card-title fs-5 fw-bolder ms-2">For Accounting</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">GL House</span>
                                    <span id="lbl0101GLHouse" class="form-control">-</span>
                                </div>
                        </div>
                        <div id="div0101Update" style="display:none">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Name</span>
                                <input id="tbx0101Name" type="text" class="form-control" placeholder="Name" maxlength="50" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Internal</span>
                                <input id="tbx0101Internal" type="text" class="form-control" placeholder="Internal" maxlength="60" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Marketing</span>
                                <input id="tbx0101Marketing" type="text" class="form-control" placeholder="Marketing" maxlength="60" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Finish</span>
                                <select id="ddl0101Finish" data-kt-repeater="select2" data-dropdown-parent="#mdl01View" class="form-select form-select-sm form-select-border min-h-38px" >
                                    <option value="">Finish</option>
                                    <option value="Basic">Basic</option>
                                    <option value="Complete">Complete</option>
                                    <option value="Bare">Bare</option>
                                    <option value="Premium">Premium</option>
                                </select>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Min. Lot Area</span>
                                <input id="tbx0101MinLotArea" type="text" class="form-control" placeholder="Min. Lot Area" maxlength="21" onkeypress="return fnEnterKey(event,this)" onblur="fnFormatNumeric(this)" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Lot Dimension</span>
                                <input id="tbx0101LotDimension" type="text" class="form-control" placeholder="Lot Dimension" maxlength="60" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Type</span>
                                <input id="tbx0101Type" type="text" class="form-control" placeholder="Type" maxlength="60" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Storey</span>
                                <input id="tbx0101Storey" type="text" class="form-control" placeholder="Storey" maxlength="60" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Gross Floor Area</span>
                                <input id="tbx0101GrossFloorArea" type="text" class="form-control" placeholder="Gross Floor Area" maxlength="21" onkeypress="return fnEnterKey(event,this)" onblur="fnFormatNumeric(this)" />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Net Floor Area</span>
                                <input id="tbx0101NetFloorArea" type="text" class="form-control" placeholder="Net Floor Area" maxlength="21" onkeypress="return fnEnterKey(event,this)" onblur="fnFormatNumeric(this)" />
                            </div>
                            <div class="card-title fs-5 fw-bolder ms-2">For Accounting</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px required">GL House</span>
                                    <select id="ddl0101GLHouse" data-kt-repeater="select2" data-dropdown-parent="#mdl01View" class="form-select form-select-sm form-select-border min-h-38px" >
                                        <option value="">GLHouse</option>
                                    </select>
                                </div>
                        </div>
                        <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Updated By</span>
                                <span id="lbl0101UpdatedByName" class="form-control">-</span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Date</span>
                                <span id="lbl0101UpdatedDate" class="form-control">-</span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Locked By</span>
                                <span id="lbl01LockedByName" class="form-control">-</span>
                            </div>
                            <div class="input-group input-group-sm">
                                <span class="input-group-text min-w-150px">Date</span>
                                <span id="lbl0101LockedDate" class="form-control">-</span>
                            </div>
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
    <!--content-->
    
	<!--param-->
	<input id="hdnPrevID" type="hidden" value="" />
    <input id="hdnID" type="hidden" value="" />
	<input id="hdnMode" type="hidden" value="" />
	<!--param-->

	<!-- scripts related to this page -->
    <script type="text/javascript">

        //general
        function fn01Load() {
            document.getElementById("div01Loader").style.display = "";
            fnAccess('PDD030000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD030000',
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
                                { data: 'Name' },
                                { data: 'Internal' },
                                { data: 'Marketing' },
                                { data: 'Finish' }],
                            rowId: 'rowId',
                            columnDefs: [
                                { targets: 0, orderable: false },
                                { targets: 1, orderable: false },
                                { targets: 2, className: 'tbody-nowrap-auto' },
                                { targets: 3, className: 'tbody-nowrap-auto' },
                                { targets: 4, className: 'tbody-nowrap-auto' },
                                { targets: 5, className: 'tbody-nowrap-auto' }],
                            order: [[2, 'asc']],
                            
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Record.search(this.value).draw();
                        });
                        //search

                        //export
                        const documentTitle = 'House Models';
                        var buttons = new $.fn.dataTable.Buttons(table01Record, {
                            buttons: [
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle,
                                    exportOptions: {
                                        columns: [1,2,3,4,5]
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
        function fn01Redraw(Action, ID) { //test1
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD030000',
                        'pType': 'Redraw',
                        'pID': ID
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add(
                                {
                                    Action: response[0].Action,
                                    Lock: response[0].Lock,
                                    Name: response[0].Name,
                                    Internal: response[0].Internal,
                                    Marketing: response[0].Marketing,
                                    Finish: response[0].Finish
                                }
                            ).draw(false).select();
                            $(row01.node()).attr('id', response[0].rowId);
                            //add row

                            //select and go to record
                            //let new01 = gv01.row('#' + response[0].rowId);
                            //let index01 = new01.index();
                            //var rowNode = gv01.row(index01).node();
                            //rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        //select and go to record
                        } else if (Action == "Edit") {
                            //update row
                            var gv01 = $('#table01Record').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].Lock).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Name).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Internal).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Marketing).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].Finish).draw(false);
                            //update row end here

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
        function fn01DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0101Refresh").classList.remove("btn-view");
                document.getElementById("btn0101Add").classList.remove("btn-add");
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Lock").classList.remove("btn-lock");
                document.getElementById("btn0101Unlock").classList.remove("btn-lock");
            } else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Add").classList.add("btn-add");
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Lock").classList.add("btn-lock");
                document.getElementById("btn0101Unlock").classList.add("btn-lock");
            }
            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Add").disabled = pValue;
            document.getElementById("btn0101Delete").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Lock").disabled = pValue;
            document.getElementById("btn0101Unlock").disabled = pValue;
        };
        function fn01Toggle(button) {
            // Find the closest wrapper and toggle the child menu
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
        //general

        //Action
        function fn01View(pMode, pID) {
            document.getElementById("hdnMode").value = pMode;
            document.getElementById("hdnID").value = pID;
            fn01LoadOverview(document.getElementById("hdnMode").value, document.getElementById("hdnID").value);
        };
        function fn01Delete(pMode, pID) {
            document.getElementById("hdnMode").value = pMode;
            document.getElementById("hdnID").value = pID;
            fn0101Delete();
        };
        function fn01Edit(pMode, pID) {
            //access
            fnAccess('PDD030000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(pMode, pID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(pMode, pID) {
                fnValidateRecord('mstr_HouseModels', pID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(pMode, pID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Edit(pMode, pID) {
                document.getElementById("hdnMode").value = pMode;
                document.getElementById("hdnID").value = pID;
                fn0101Edit();
                $('#mdl01View').modal('show');
            }
        };
        function fn01Lock(pMode, pID) {
            document.getElementById("hdnMode").value = pMode;
            document.getElementById("hdnID").value = pID;
            fn0101Lock();
        };
        function fn01Unlock(pMode, pID) {
            document.getElementById("hdnMode").value = pMode;
            document.getElementById("hdnID").value = pID;
            fn0101Unlock();
        };
        //Action

        //overview
        function fn01LoadOverview(pMode, pID) {

            if (pMode == "ADD") {
                //title
                document.getElementById("spn0101Title").innerText = "New Record";
                document.getElementById("spn0101ID").innerText = "000000000000";
                document.getElementById("spn0101Status").innerText = "New";
                if (document.getElementById("spn0101Status").innerText == "New") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                };
                //title

                //toolbar
                fn01DisableButtons(true);
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Delete").disabled = false;
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Edit").disabled = false;
                document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                document.getElementById("i0101Edit").classList.add("la-save");
                document.getElementById("cbx0101Lock").checked = false;
                //toolbar

                //content
                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";
                document.getElementById("tbx0101Name").value = "";
                document.getElementById("tbx0101Internal").value = "";
                document.getElementById("tbx0101Marketing").value = "";
                $('#ddl0101Finish').val("").trigger('change');
                document.getElementById("tbx0101MinLotArea").value = "";
                document.getElementById("tbx0101LotDimension").value = "";
                document.getElementById("tbx0101Type").value = "";
                document.getElementById("tbx0101Storey").value = "";
                document.getElementById("tbx0101GrossFloorArea").value = "";
                document.getElementById("tbx0101NetFloorArea").value = "";
                ddl0101GLHouse('');
                document.getElementById("lbl0101UpdatedByName").innerText = "";
                document.getElementById("lbl0101UpdatedDate").innerText = "";
                document.getElementById("lbl01LockedByName").innerText = "";
                document.getElementById("lbl0101LockedDate").innerText = "";
                //content

            } else if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD030000',
                        'pType': 'Get Info',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById('hdnPrevID').value = pID; //get previous ID
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101ID").innerText = response[0].ID;
                        document.getElementById("spn0101Status").innerText = response[0].Status;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.remove("la-save");
                        fn01DisableButtons(false);
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "";
                        document.getElementById("div0101Update").style.display = "none";
                        document.getElementById("lbl0101Name").innerText = response[0].Name;
                        document.getElementById("lbl0101Internal").innerText = response[0].Internal;
                        document.getElementById("lbl0101Marketing").innerText = response[0].Marketing;
                        document.getElementById("lbl0101Finish").innerText = response[0].Finish;
                        document.getElementById("lbl0101MinLotArea").innerText = response[0].MinLotArea;
                        document.getElementById("lbl0101LotDimension").innerText = response[0].LotDimension;
                        document.getElementById("lbl0101Type").innerText = response[0].Type;
                        document.getElementById("lbl0101Storey").innerText = response[0].Storey;
                        document.getElementById("lbl0101GrossFloorArea").innerText = response[0].GrossFloorArea;
                        document.getElementById("lbl0101NetFloorArea").innerText = response[0].NetFloorArea;
                        document.getElementById("lbl0101GLHouse").innerText = response[0].GLHouse;
                            //prepared by
                        document.getElementById("lbl0101GLHouse").innerText = response[0].GLHouse;
                        document.getElementById("lbl0101UpdatedByName").innerText = response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = response[0].UpdatedDate;
                        document.getElementById("lbl01LockedByName").innerText = response[0].LockedByName;
                        document.getElementById("lbl0101LockedDate").innerText = response[0].LockedDate;
                        //content

                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD030000',
                        'pType': 'Get Info - Last',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101ID").innerText = response[0].ID;
                        document.getElementById("spn0101Status").innerText = response[0].Status;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        fn01DisableButtons(true);
                        document.getElementById("btn0101Delete").classList.add("btn-delete");
                        document.getElementById("btn0101Delete").disabled = false;
                        document.getElementById("btn0101Edit").classList.add("btn-edit");
                        document.getElementById("btn0101Edit").disabled = false;
                        document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.add("la-save");
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "none";
                        document.getElementById("div0101Update").style.display = "";
                        document.getElementById("tbx0101Name").value = response[0].Name;
                        document.getElementById("tbx0101Internal").value = response[0].Internal;
                        document.getElementById("tbx0101Marketing").value = response[0].Marketing;
                        $('#ddl0101Finish').val(response[0].Finish).trigger('change');
                        document.getElementById("tbx0101MinLotArea").value = response[0].MinLotArea;
                        document.getElementById("tbx0101LotDimension").value = response[0].LotDimension;
                        document.getElementById("tbx0101Type").value = response[0].Type;
                        document.getElementById("tbx0101Storey").value = response[0].Storey;
                        document.getElementById("tbx0101GrossFloorArea").value = response[0].GrossFloorArea;
                        document.getElementById("tbx0101NetFloorArea").value = response[0].NetFloorArea;
                        ddl0101GLHouse(response[0].GLHouse);
                        document.getElementById("lbl0101UpdatedByName").innerText = response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = response[0].UpdatedDate;
                        document.getElementById("lbl01LockedByName").innerText = response[0].LockedByName;
                        document.getElementById("lbl0101LockedDate").innerText = response[0].LockedDate;
                        //content

                    },
                });
            }

        };
        function ddl0101GLHouse(ID) {
            $.ajax({
                type: "POST",
                url: "HNDPDD.ashx",
                data: {
                    'pFormCode': 'PDD030000',
                    'pType': 'Get GLHouse',
                    'pTblName': 'glhouse',
                    'pPlaceHolder': 'GLHouse',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101GLHouse").html(s);
                    $('#ddl0101GLHouse').val(ID).trigger('change');
                },
            });
        };
        function fn0101Refresh() {
            fn01LoadOverview(document.getElementById("hdnMode").value, document.getElementById("hdnID").value);
        };
        function fn0101Add() {
            //access
            fnAccess('PDD030000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add() {
                document.getElementById("hdnMode").value = "ADD";
                document.getElementById("hdnID").value = "000000000000";
                fn01LoadOverview(document.getElementById("hdnMode").value, document.getElementById("hdnID").value);
                $('#mdl01View').modal('show');
            };
        };
        function fn0101Delete() {
            if (document.getElementById('hdnMode').value == "ADD") {
                Cancel_Add_Question();
            } else if (document.getElementById('hdnMode').value == "DTL") {
                //if exist
                fnIfExist('calmardblive.dbo.mstr_HouseModels', 'ModelCode', document.getElementById('hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('PDD030000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('mstr_HouseModels', ID, '', 'Delete', function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Dtl_Question(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('hdnMode').value == "UPD") {
                Cancel_Upd_Question(document.getElementById('hdnID').value);
            }

            function Cancel_Add_Question() {
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
                        if (document.getElementById('hdnPrevID').value == "") {
                            $('#mdl01View').modal('hide');
                        } else {
                            document.getElementById('hdnMode').value = "DTL"
                            document.getElementById('hdnID').value = document.getElementById('hdnPrevID').value
                            document.getElementById('hdnPrevID').value = document.getElementById('hdnPrevID').value
                            fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                        }
                    }
                });
            };
            function Delete_Dtl_Question(ID) {
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
                        Validate_Delete(ID);
                    }
                });
                //validate
                function Validate_Delete(ID) {
                    fnValidateRecord('mstr_HouseModels', ID, '', 'Delete', function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Ok(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            fn01Redraw("Edit", ID);
                            fn01LoadOverview(document.getElementById("hdnMode").value, document.getElementById("hdnID").value);
                        };
                    });
                };
                function Delete_Ok(ID) {
                    fnDelete('PDD030000', 'mstr_HouseModels', ID, function (response) {
                        if (document.getElementById('hdnPrevID').value == "") {
                            fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                            fn01Redraw("Delete", ID);
                            $('#mdl01View').modal('hide');
                        } else if (document.getElementById('hdnPrevID').value == ID) {
                            fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                            fn01Redraw("Delete", ID);
                            $('#mdl01View').modal('hide');
                        } else if (document.getElementById('hdnPrevID').value != ID) {
                            fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                            fn01Redraw("Delete", ID);
                            $('#mdl01View').modal('hide');
                            document.getElementById('hdnMode').value = "DTL"
                            document.getElementById('hdnID').value = document.getElementById('hdnPrevID').value
                            document.getElementById('hdnPrevID').value = document.getElementById('hdnPrevID').value
                            fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                        }
                    });
                };
            };
            function Cancel_Upd_Question(ID) {
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
                        document.getElementById('hdnMode').value = "DTL"
                        document.getElementById('hdnID').value = ID
                        document.getElementById('hdnPrevID').value = ID
                        fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                    }
                });
            };
        };
        function fn0101Edit() {
            //validate
            if (document.getElementById('hdnMode').value == "ADD") {
                //access
                fnAccess('PDD030000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('hdnMode').value == "DTL") {
                //if exist
                fnIfExist('calmardblive.dbo.mstr_HouseModels', 'ModelCode', document.getElementById('hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('PDD030000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('mstr_HouseModels', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('hdnMode').value == "UPD") {
                //if exist
                fnIfExist('calmardblive.dbo.mstr_HouseModels', 'ModelCode', document.getElementById('hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('PDD030000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate_Update(document.getElementById('hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate_Update(ID) {
                    fnValidateRecord('mstr_HouseModels', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            ValidateFields(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            fn01Redraw("Edit", ID);
                            fn01LoadOverview("DTL", document.getElementById("hdnID").value);
                        };
                    });
                };
            }
            //validate fields
            function ValidateFields(ID) {
                if (document.getElementById("tbx0101Name").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Internal").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Marketing").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101Finish").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101MinLotArea").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101LotDimension").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Type").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Storey").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101GrossFloorArea").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101NetFloorArea").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101GLHouse").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Edit_Question(ID);
                }
            }
            //question
            function Edit_Question(ID) {
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
                        if (document.getElementById('hdnMode').value == "ADD") {
                            Edit_Add_Ok_Await();
                        } else if (document.getElementById('hdnMode').value == "DTL") {
                            Edit_Dtl_Ok_Await();
                        } else if (document.getElementById('hdnMode').value == "UPD") {
                            Validate_Edit(ID);
                        }
                    }
                });
            };
            //validate
            function Validate_Edit(ID) {
                fnValidateRecord('mstr_HouseModels', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_Upd_Ok_Await(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        fn01Redraw("Edit", ID);
                        document.getElementById('hdnMode').value = "DTL";
                        fn01LoadOverview("DTL", document.getElementById("hdnID").value);
                    };
                });
            };

            //do edit
            function Edit_Add_Ok_Await() {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD030000',
                        'pType': 'Add Record',
                        'pName': document.getElementById("tbx0101Name").value,
                        'pInternal': document.getElementById("tbx0101Internal").value,
                        'pMarketing': document.getElementById("tbx0101Marketing").value,
                        'pFinish': document.getElementById("ddl0101Finish").value,
                        'pMinLotArea': document.getElementById("tbx0101MinLotArea").value,
                        'pLotDimension': document.getElementById("tbx0101LotDimension").value,
                        'pMType': document.getElementById("tbx0101Type").value,
                        'pStorey': document.getElementById("tbx0101Storey").value,
                        'pGrossFloorArea': document.getElementById("tbx0101GrossFloorArea").value,
                        'pNetFloorArea': document.getElementById("tbx0101NetFloorArea").value,
                        'pGLHouse': document.getElementById("ddl0101GLHouse").options[document.getElementById("ddl0101GLHouse").selectedIndex].value,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        fn01Redraw("Add", response[0].oID);
                        document.getElementById('hdnMode').value = "DTL"
                        document.getElementById('hdnID').value = response[0].oID
                        document.getElementById('hdnPrevID').value = response[0].oID
                        fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                    },
                });
            };
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('hdnMode').value = "UPD"
                document.getElementById('hdnID').value = ID
                document.getElementById('hdnPrevID').value = ID
                fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD030000',
                        'pType': 'Edit Record',
                        'pID': ID,
                        'pName': document.getElementById("tbx0101Name").value,
                        'pGLHouse': document.getElementById("ddl0101GLHouse").options[document.getElementById("ddl0101GLHouse").selectedIndex].value,
                        'pInternal': document.getElementById("tbx0101Internal").value,
                        'pMarketing': document.getElementById("tbx0101Marketing").value,
                        'pFinish': document.getElementById("ddl0101Finish").value,
                        'pMinLotArea': document.getElementById("tbx0101MinLotArea").value,
                        'pLotDimension': document.getElementById("tbx0101LotDimension").value,
                        'pMType': document.getElementById("tbx0101Type").value,
                        'pStorey': document.getElementById("tbx0101Storey").value,
                        'pGrossFloorArea': document.getElementById("tbx0101GrossFloorArea").value,
                        'pNetFloorArea': document.getElementById("tbx0101NetFloorArea").value,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        fn01Redraw("Edit", ID);
                        document.getElementById('hdnMode').value = "DTL"
                        document.getElementById('hdnID').value = ID
                        document.getElementById('hdnPrevID').value = ID
                        fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                    },
                });
            };
        };
        function fn0101Lock() {
            //if exist
            fnIfExist('calmardblive.dbo.mstr_HouseModels', 'ModelCode', document.getElementById('hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('PDD030000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('mstr_HouseModels', ID, '', 'Lock', function (response) {
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
                    html: `<input id="tbx0101LockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
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
                        fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                Validate_Lock(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //validate
            function Validate_Lock(ID) {
                fnValidateRecord('mstr_HouseModels', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        fn01Redraw("Edit", ID);
                        fn01LoadOverview("DTL", document.getElementById("hdnID").value);
                    };
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'mstr_HouseModels', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                    fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exist
            fnIfExist('calmardblive.dbo.mstr_HouseModels', 'ModelCode', document.getElementById('hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('PDD030000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('mstr_HouseModels', ID, '', 'Unlock', function (response) {
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
                    html: `<input id="tbx0101UnlockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
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
                        fnValidatePassword(document.getElementById("tbx0101UnlockPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                Validate_Unlock(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //validate
            function Validate_Unlock(ID) {
                fnValidateRecord('mstr_HouseModels', ID, '', 'Unlock', function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        fn01Redraw("Edit", ID);
                        fn01LoadOverview("DTL", document.getElementById("hdnID").value);
                    };
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'mstr_HouseModels', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                    fn01LoadOverview(document.getElementById('hdnMode').value, document.getElementById('hdnID').value);
                });
            }
        };
        //overview

        //capitalize first letter
        function titleCase(str) {
            var splitStr = str.toLowerCase().split(' ');
            for (var i = 0; i < splitStr.length; i++) {
                // You do not need to check if i is larger than splitStr length, as your for does that for you
                // Assign it back to the array
                splitStr[i] = splitStr[i].charAt(0).toUpperCase() + splitStr[i].substring(1);
            }
            // Directly return the joined string
            return splitStr.join(' ');
        }

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

                //date
                $('[data-kt-repeater="timepicker"]').flatpickr({
                    enableTime: true,
                    noCalendar: true,
                    dateFormat: "h:i K"
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
