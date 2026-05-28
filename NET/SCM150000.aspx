<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM150000.aspx.vb" Inherits="NET.SCM150000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Credit Terms Masterlist</li>
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
							<span class="card-label fw-bolder text-dark">Credit Terms</span>
						</h3>
					</div>
				</div>
			</div>
            <div class="border-bottom border-gray-200 px-4 py-3 mb-2">
                <div class="d-flex flex-stack align-items-center">
                    <!-- Left side: Buttons + Select (separate divs) -->
                    <div class="d-flex align-items-center ms-5">
                        <div class="d-flex flex-stack">
                            <div id="div01ExportButton" class="d-none"></div>
                            <button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Options">
                                <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                               <i class="las la-filter fs-3"></i>
                                <!--end::Svg Icon-->
                            </button>
                            <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-2" data-kt-menu="true">
				                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn01Export(); return false;">Export as Excel</a>
                                </div>
                            </div>
                            
							<span class="bullet h-30px w-2px bg-secondary m-1"></span>
							<a href="#" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn01Add(); return false;"><i class="las la-plus fs-2"></i></a>
                        </div>
                    </div>

                    <!-- Right side: Search -->
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
                <div id="table01Record" style="height: 100vh;"></div>
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->
        
    </div>
	
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
    <script type="text/javascript">

        //variable
        let gridApi;
        //variable

        //general
        function fn01Load() {
            fnAccess('SCM150000', 'View', function (response) {
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
                        'FormCode': 'SCM150000',
                        'Type': 'Get Record - Credit Terms Masterlist'
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table01Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            onRowDoubleClicked: params => {
                                window.open(
                                    `SCM150100-DTL-${params.data.Code}`,
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
                                                `SCM150100-DTL-${params.value}`,
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
                                    headerName: "Credit Terms",
                                    field: "Description",
                                    tooltipField: "Description",
                                    flex: 1,
                                    minWidth: 350
                                }
                            ],
                            rowData: response,
                            pagination: true,
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
                    },
                });
            };
        };
        function fn01Redraw(Action, ID) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM150000',
                        'Type': 'Get Record - Credit Terms Masterlist : Redraw',
                        'pID': ID
                    },
                    dataType: "json",
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

        //export
        function fn01Export() {
            if (gridApi) {
                gridApi.exportDataAsCsv({
                    fileName: 'Credit Terms Masterlist.csv',
                    columnKeys: ['Code', 'Description']
                });
            }
        };
        //export

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
        //general

        //add
        function fn01Add() {
            //access
            fnAccess('SCM150000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    //toggle
                    fn01DisableToggle();
                };
            });
            function Add_Ok() {
                window.open('SCM150100-ADD-0000000000000');
            };
        };
        //add

        //delete
        function fn03Delete(ID) {
            //access
            fnAccess('SCM150000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    //toggle
                    fn01DisableToggle();
                };
            });
            function Validate(ID) {
                fnValidateRecord('Mstr_CreditTerms', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        //toggle
                        fn01DisableToggle();
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
                fnDelete('SCM150000', 'Mstr_CreditTerms', ID, function (response) {
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Redraw("Delete", ID);
                    //toggle
                    fn01DisableToggle();
                });
            }
        };
        //delete

        //edit
        function fn04Edit(ID) {
            //access
            fnAccess('SCM150000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    //toggle
                    fn01DisableToggle();
                };
            });
            function Validate(ID) {
                fnValidateRecord('Mstr_CreditTerms', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        //toggle
                        fn01DisableToggle();
                    };
                });
            };
            function Edit_Ok(ID) {
                window.open('SCM150100-UPD-' + ID);
            };
        };
        //edit

        //lock
        function fn05Lock(ID) {
            //access
            fnAccess('SCM150000', 'Lock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    //toggle
                    fn01DisableToggle();
                };
            });
            function Validate(ID) {
                fnValidateRecord('Mstr_CreditTerms', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        //toggle
                        fn01DisableToggle();
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
                                //toggle
                                fn01DisableToggle();
                            };
                        });
                    }
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'Mstr_CreditTerms', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                    //toggle
                    fn01DisableToggle();
                });
            }
        };
        //lock

        //unlock
        function fn06Unlock(ID) {
            //access
            fnAccess('SCM150000', 'Unlock', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(ID);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    //toggle
                    fn01DisableToggle();
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Mstr_CreditTerms', ID, '', 'Unlock', function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        //toggle
                        fn01DisableToggle();
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
                                //toggle
                                fn01DisableToggle();
                            };
                        });
                    }
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'Mstr_CreditTerms', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    fn01Redraw("Edit", ID);
                    //toggle
                    fn01DisableToggle();
                });
            }
        };
        //unlock

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
