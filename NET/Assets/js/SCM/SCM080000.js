

    //general
    function fn01Load() {
        fnAccess('SCM080000', 'View', function (response) {
            if (response[0].oReturn == "1") {
                Load();
            } else {
                location.replace("MNU000022");
            };
        });
    function Load() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM080000HND.ashx",
            data: {
                'FormCode': 'SCM080000',
                'Type': 'Stock Issuance - Get Record',
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
                        { data: 'SINo' },
                        { data: 'SIDate' },
                        { data: 'GPNo' },
                        { data: 'RequestedBy' },
                        { data: 'WhseName' },
                        { data: 'PreparedBy' }
                    ],
                    rowId: 'rowId',
                    columnDefs: [
                        {
                            targets: [0, 1, 2, 3, 4], orderable: false
                        },
                        {
                            targets: [8, 9], className: 'tbody-nowrap-auto'
                        }
                    ],
                    order: [[6, 'desc']],
                    orderCellsTop: true,
                });
                //datatable

                //search
                $('#tbx01Find').on('keyup', function () {
                    table01Record.search(this.value).draw();
                });
                //search

                //export
                const documentTitle = 'Stock Issuance';
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
            url: "Assets/Handler/SCM/SCM080000HND.ashx",
            data: {
                'FormCode': 'SCM080000',
                'Type': 'Stock Issuance - Get Record : Redraw',
                'pID': ID
            },
            success: function (response) {
                if (Action == "Add") {
                    //add row
                    var gv01 = $('#table01Record').DataTable();
                    gv01.rows().deselect();
                    var row01 = gv01.row.add({
                        Action: response[0].Action,
                        Code: response[0].Code,
                        Lock: response[0].Lock,
                        Post: response[0].Post,
                        Rvrs: response[0].Rvrs,
                        SINo: response[0].SINo,
                        SIDate: response[0].SIDate,
                        GPNo: response[0].GPNo,
                        RequestedBy: response[0].RequestedBy,
                        WhseName: response[0].WhseName,
                        PreparedBy: response[0].PreparedBy
                    }).draw(false).select();
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
                    gv01.cell({ row: index01, column: 5 }).data(response[0].SINo).draw(false);
                    gv01.cell({ row: index01, column: 6 }).data(response[0].SIDate).draw(false);
                    gv01.cell({ row: index01, column: 7 }).data(response[0].GPNo).draw(false);
                    gv01.cell({ row: index01, column: 8 }).data(response[0].RequestedBy).draw(false);
                    gv01.cell({ row: index01, column: 9 }).data(response[0].WhseName).draw(false);
                    gv01.cell({ row: index01, column: 10 }).data(response[0].PreparedBy).draw(false);
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
    function ddl01Warehouse() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM080000HND.ashx",
            data: {
                'FormCode': 'SCM080000',
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
                $('#ddl01Warehouse').val('').trigger('change');
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
            url: "Assets/Handler/SCM/SCM080000HND.ashx",
            data: {
                'FormCode': 'SCM080000',
                'Type': 'Stock Issuance - Get Record',
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
                        { data: 'SINo' },
                        { data: 'SIDate' },
                        { data: 'GPNo' },
                        { data: 'RequestedBy' },
                        { data: 'WhseName' },
                        { data: 'PreparedBy' },
                    ],
                    rowId: 'rowId',
                    columnDefs: [
                        {
                            targets: [0, 1, 2, 3, 4], orderable: false
                        },
                        {
                            targets: [8, 9], className: 'tbody-nowrap-auto'
                        }
                    ],
                    order: [[6, 'desc']],
                    orderCellsTop: true,
                });
                //datatable

                //search
                $('#tbx01Find').on('keyup', function () {
                    table01Record.search(this.value).draw();
                });
                //search

                //export
                const documentTitle = 'Stock Issuance';
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
        fnAccess('SCM080000', 'Add', function (response) {
            if (response[0].oReturn == "1") {
                Add_Ok();
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    function Add_Ok() {
        window.open('SCM080100-ADD-000000000000');
            };
        };
    //add

    //delete
    function fn03Delete(ID) {
        //access
        fnAccess('SCM080000', 'Delete', function (response) {
            if (response[0].oReturn == "1") {
                Validate(ID);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    function Validate(ID) {
        fnValidateRecord('Trxn_SIHdr', ID, '', 'Delete', function (response) {
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
        fnDelete('SCM080000', 'Trxn_SIHdr', ID, function (response) {
            fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
            fn01Redraw("Delete", ID);
        });
            }
        };
    //delete

    //edit
    function fn04Edit(ID) {
        //access
        fnAccess('SCM080000', 'Save', function (response) {
            if (response[0].oReturn == "1") {
                Validate(ID);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    function Validate(ID) {
        fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
            if (response[0].oReturn == "") {
                Edit_Ok(ID);
            } else {
                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
            };
        });
            };
    function Edit_Ok(ID) {
        window.open('SCM080100-UPD-' + ID);
            };
        };
    //edit

    //lock
    function fn05Lock(ID) {
        //access
        fnAccess('SCM080000', 'Lock', function (response) {
            if (response[0].oReturn == "1") {
                Validate(ID);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    function Validate(ID) {
            fnValidateRecord('Trxn_SIHdr', ID, '', 'Lock', function (response) {
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
        fnLock('Lock', 'Trxn_SIHdr', ID, function (response) {
            fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
            fn01Redraw("Edit", ID);
        });
        }
    };
    //lock

    //unlock
    function fn06Unlock(ID) {
        //access
        fnAccess('SCM080000', 'Unlock', function (response) {
            if (response[0].oReturn == "1") {
                Validate(ID);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    //validate
    function Validate(ID) {
        fnValidateRecord('Trxn_SIHdr', ID, '', 'Unlock', function (response) {
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
        fnLock('Unlock', 'Trxn_SIHdr', ID, function (response) {
            fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
            fn01Redraw("Edit", ID);
        });
            }
        };
    //unlock

    //post
    function fn07Post(ID) {
        //access
        fnAccess('SCM080000', 'Post', function (response) {
            if (response[0].oReturn == "1") {
                Validate(ID);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    //validate
    function Validate(ID) {
        fnValidateRecord('Trxn_SIHdr', ID, '', 'Post', function (response) {
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
            url: "Assets/Handler/SCM/SCM080000HND.ashx",
            data: {
                'Type': "Post",
                'pRecType': "SI",
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

    //rvrs
    function fn08Rvrs(ID) {
        //access
        fnAccess('SCM080000', 'Unpost', function (response) {
            if (response[0].oReturn == "1") {
                Validate(ID);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    //validate
    function Validate(ID) {
        fnValidateRecord('Trxn_SIHdr', ID, '', 'Reverse', function (response) {
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
        fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hf0201pID').value, function (response) {
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
            url: "Assets/Handler/SCM/SCM080000HND.ashx",
            data: {
                'FormCode': 'SCM080100',
                'Type': 'Stock Issuance - Cancel Record',
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
    //rvrs

    //load page
    function pageLoad(sender, args) {InitialiseSettings(); }
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
