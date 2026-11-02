//page
function fn01Load() {
    //Access
    fnAccess('SCM230000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            Load();
            Header();
        } else {
            location.replace("MNU000022");
        };
    });
    //Load
    function Load() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM230000HND.ashx",
            data: {
                'pFormCode': 'SCM230000',
                'pType': 'Get - Record',
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
                        { data: 'Lock' },
                        { data: 'Description' }
                    ],
                    rowId: 'rowId',
                    columnDefs: [
                        {
                            targets: [0, 1], orderable: false
                        },
                        {
                            targets: [2], className: 'tbody-nowrap-auto'
                        }
                    ],
                    //order: [[2, 'asc']],
                    orderCellsTop: true,
                });
                //datatable

                //search
                $('#tbx01Find').on('keyup', function () {
                    table01Record.search(this.value).draw();
                });
                //search

                //export
                const documentTitle = 'Unit of Measure Masterlist';
                var buttons = new $.fn.dataTable.Buttons(table01Record, {
                    buttons: [
                        {
                            extend: 'excelHtml5',
                            title: documentTitle,
                            exportOptions: {
                                columns: [1, 2]
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
    function Header() {
        document.title = "Unit of Measure Masterlist";
    };
};
function fn01Redraw(Action, ID) {
    //update list
    if (Action == "Add" || Action == "Edit") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM230000HND.ashx",
            data: {
                'pFormCode': 'SCM230000',
                'pType': 'Get - Record : Redraw',
                'pID': ID
            },
            dataType: "json",
            success: function (response) {
                if (Action == "Add") {
                    //add row
                    var gv01 = $('#table01Record').DataTable();
                    gv01.rows().deselect();
                    var row01 = gv01.row.add(
                        {
                            Action: response[0].Action,
                            Lock: response[0].Lock,
                            Description: response[0].Description
                        }
                    ).draw(false).select();
                    gv01.page('last').draw(false);
                    $(row01.node()).attr('id', response[0].rowId);
                    //add row

                    //select and go to record
                    let new01 = gv01.row('#' + response[0].rowId);
                    let index01 = new01.index();
                    var rowNode = gv01.row(index01).node();
                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                } else if (Action == "Edit") {
                    //edit row
                    var gv01 = $('#table01Record').DataTable();
                    gv01.rows().deselect();
                    let row01 = gv01.row('#' + response[0].rowId);
                    let index01 = row01.index();
                    gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                    gv01.cell({ row: index01, column: 1 }).data(response[0].Lock).draw(false);
                    gv01.cell({ row: index01, column: 2 }).data(response[0].Description).draw(false);
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
    // Find the closest wrapper and toggle the child menu
    const wrapper = button.closest('.action-toggle-wrapper');
    const toggleMenu = wrapper.querySelector('.toggle-menu');

    // Hide all other open toggle menus first
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
//page

//add
function fn01Add() {
    //access
    fnAccess('SCM230000', 'Add', function (response) {
        if (response[0].oReturn == "1") {
            Add_Ok();
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    function Add_Ok() {
        window.open('SCM230100-ADD-000000000000');
    };
};
//add

//delete
function fn03Delete(ID) {
    //access
    fnAccess('SCM230000', 'Delete', function (response) {
        if (response[0].oReturn == "1") {
            Validate(ID);
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    function Validate(ID) {
        fnValidateRecord('Mstr_UOM', ID, '', 'Delete', function (response) {
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
        fnDelete('SCM230000', 'Mstr_UOM', ID, function (response) {
            fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
            fn01Redraw("Delete", ID);
        });
    }
};
//delete

//edit
function fn04Edit(ID) {
    //access
    fnAccess('SCM230000', 'Save', function (response) {
        if (response[0].oReturn == "1") {
            Validate(ID);
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    function Validate(ID) {
        fnValidateRecord('Mstr_UOM', ID, '', 'Save', function (response) {
            if (response[0].oReturn == "") {
                Edit_Ok(ID);
            } else {
                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
            };
        });
    };
    function Edit_Ok(ID) {
        window.open('SCM230100-UPD-' + ID);
    };
};
//edit

//lock
function fn05Lock(ID) {
    //access
    fnAccess('SCM230000', 'Lock', function (response) {
        if (response[0].oReturn == "1") {
            Validate(ID);
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    function Validate(ID) {
        fnValidateRecord('Mstr_UOM', ID, '', 'Lock', function (response) {
            if (response[0].oReturn == "") {
                Lock_Question(ID);
            } else {
                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
            };
        });
    };
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
    function Lock_Ok(ID) {
        fnLock('Lock', 'Mstr_UOM', ID, function (response) {
            fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
            fn01Redraw("Edit", ID);
        });
    };
};
//lock

//unlock
function fn06Unlock(ID) {
    //access
    fnAccess('SCM230000', 'Unlock', function (response) {
        if (response[0].oReturn == "1") {
            Validate(ID);
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    fnAccess('SCM230000', 'Unlock', function (response) {
        if (response[0].oReturn == "1") {
            Validate(ID);
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    //validate
    function Validate(ID) {
        fnValidateRecord('Mstr_UOM', ID, '', 'Unlock', function (response) {
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
        fnLock('Unlock', 'Mstr_UOM', ID, function (response) {
            fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
            fn01Redraw("Edit", ID);
        });
    }
};
//unlock

//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        fn01Load();
    });
};
//master