//variable
var FileCount = 0;
//variable

//general
function fn01Load() {
    fnAccess('SCM230000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            location.replace("MNU000022");
        };
    });

    //Page title
    if (document.getElementById('ContentPlaceHolder1_hdnID').value === '000000000000') {
        document.title = "Unit of Measure Masterlist - Add New";
    } else {
        document.title = "Unit of Measure Masterlist - " + document.getElementById('ContentPlaceHolder1_hdnID').value;
    }
};
function fn01DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn0101Find").classList.remove("btn-view");
        document.getElementById("btn0101Refresh").classList.remove("btn-view");
        document.getElementById("btn0101Add").classList.remove("btn-add");
        document.getElementById("btn0101Delete").classList.remove("btn-delete");
        document.getElementById("btn0101Edit").classList.remove("btn-edit");
        document.getElementById("btn0101Lock").classList.remove("btn-lock");
        document.getElementById("btn0101Unlock").classList.remove("btn-lock");
        document.getElementById("btn0201Add").classList.remove("btn-add");
        document.getElementById("btn0301Add").classList.remove("btn-add");
        const button = document.querySelectorAll('.action-button');
        for (const btn of button) {
            btn.classList.remove("btn-active-light");
            btn.disabled = pValue;
        }
    } else {
        document.getElementById("btn0101Find").classList.add("btn-view");
        document.getElementById("btn0101Refresh").classList.add("btn-view");
        document.getElementById("btn0101Add").classList.add("btn-add");
        document.getElementById("btn0101Delete").classList.add("btn-delete");
        document.getElementById("btn0101Edit").classList.add("btn-edit");
        document.getElementById("btn0101Lock").classList.add("btn-lock");
        document.getElementById("btn0101Unlock").classList.add("btn-lock");
        document.getElementById("btn0201Add").classList.add("btn-add");
        document.getElementById("btn0301Add").classList.add("btn-add");
        const button = document.querySelectorAll('.action-button');
        for (const btn of button) {
            btn.classList.add("btn-active-light");
            btn.disabled = pValue;
        }
    }
    document.getElementById("btn0101Find").disabled = pValue;
    document.getElementById("btn0101Refresh").disabled = pValue;
    document.getElementById("btn0101Add").disabled = pValue;
    document.getElementById("btn0101Delete").disabled = pValue;
    document.getElementById("btn0101Edit").disabled = pValue;
    document.getElementById("btn0101Lock").disabled = pValue;
    document.getElementById("btn0101Unlock").disabled = pValue;
    document.getElementById("btn0201Add").disabled = pValue;
    document.getElementById("btn0301Add").disabled = pValue;
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
//general

//overview
function fn0101LoadOverview(pMode, pID) {
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
        document.getElementById("tbx0101Initial").value = "";
        document.getElementById("tbx0101UpdatedByName").value = "";
        document.getElementById("tbx0101UpdatedDate").value = "";
        document.getElementById("tbx0101LockedByName").value = "";
        document.getElementById("tbx0101LockedDate").value = "";
        //content
    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM230100HND.ashx",
            data: {
                'pFormCode': 'SCM230100',
                'pType': 'Get - Record',
                'pID': pID
            },
            success: function (response) {
                //title
                document.getElementById("spn0101Title").innerText = response[0].Name;
                document.getElementById("spn0101ID").innerText = response[0].ID;
                document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
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
                //checkbox

                //content
                document.getElementById("div0101Detail").style.display = "";
                document.getElementById("div0101Update").style.display = "none";
                document.getElementById("lbl0101Name").innerText = response[0].Name;
                document.getElementById("lbl0101Initial").innerText = response[0].Initial;
                document.getElementById("lbl0101UpdatedByName").innerText = (response[0].UpdatedByName == "" || response[0].UpdatedByName == null) ? "-" : response[0].UpdatedByName;
                document.getElementById("lbl0101UpdatedDate").innerText = (response[0].UpdatedDate == "" || response[0].UpdatedDate == null) ? "-" : response[0].UpdatedDate;
                document.getElementById("lbl0101LockedByName").innerText = (response[0].LockedByName == "" || response[0].LockedByName == null) ? "-" : response[0].LockedByName;
                document.getElementById("lbl0101LockedDate").innerText = (response[0].LockedDate == "" || response[0].LockedDate == null) ? "-" : response[0].LockedDate;
                //content

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM230100HND.ashx",
            data: {
                'pFormCode': 'SCM230100',
                'pType': 'Get - Record',
                'pID': pID
            },
            success: function (response) {
                //titlef
                document.getElementById("spn0101Title").innerText = response[0].Name;
                document.getElementById("spn0101ID").innerText = response[0].ID;
                document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
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
                document.getElementById("tbx0101Initial").value = response[0].Initial;
                document.getElementById("tbx0101UpdatedByName").value = (response[0].UpdatedByName == "" || response[0].UpdatedByName == null ? "-" : response[0].UpdatedByName);
                document.getElementById("tbx0101UpdatedDate").value = (response[0].UpdatedDate == "" || response[0].UpdatedDate == null) ? "-" : response[0].UpdatedDate;
                document.getElementById("tbx0101LockedByName").value = (response[0].LockedByName == "" || response[0].LockedByName == null) ? "-" : response[0].LockedByName;
                document.getElementById("tbx0101LockedDate").value = (response[0].LockedDate == "" || response[0].LockedDate == null) ? "-" : response[0].LockedDate;
                //content

            },
        });
    };
};
function fn0101Find() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/SCM/SCM230100HND.ashx",
        data: {
            'pFormCode': 'SCM230100',
            'pType': 'Find - Record',
        },
        success: function (response) {
            $('#table0101Find').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0101Find = $("#table0101Find").DataTable({
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
            $('#tbx0101Find').on('keyup', function () {
                table0101Find.search(this.value).draw();
            });
            //search

        }
    });

    $("#mdl0101Find").modal("show");
};
function fn0101Refresh() {
    fn01Load();
};
function fn0101Add() {
    //access
    fnAccess('SCM230000', 'Add', function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        };
    });
    function Add() {
        document.getElementById("ContentPlaceHolder1_hdnMode").value = "ADD";
        document.getElementById("ContentPlaceHolder1_hdnID").value = "000000000000";
        fn01Load();
    };
};
function fn0101Delete() {
    if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "ADD") {
        Cancel_Add_Question();
    } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "DTL") {
        //if exisit
        fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                Access();
            } else {
                window.location.replace("MNU040100");
            };
        });
        //access
        function Access() {
            //access
            fnAccess('SCM230000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //validate
        function Validate(ID) {
            fnValidateRecord('Mstr_UOM', ID, '', 'Delete', function (response) {
                if (response[0].oReturn == "") {
                    Delete_Dtl_Question(ID);
                } else {
                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                };
            });
        };
    } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "UPD") {
        Cancel_Upd_Question(document.getElementById('ContentPlaceHolder1_hdnID').value);
    };
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
                if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                    window.close();
                } else {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                    fn01Load();
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
                //if exisit
                fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        fnValidateRecord('Mstr_UOM', ID, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
            }
        });
        function Delete_Ok(ID) {
            fnDelete('SCM230000', 'Mstr_UOM', ID, function (response) {
                if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                    window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM130000");
                    window.close();
                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                    window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM130000");
                    window.close();
                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                    document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                    document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            };
        });
    };
};
function fn0101Edit() {
    //validate
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        //access
        fnAccess('SCM230000', 'Add', function (response) {
            if (response[0].oReturn == "1") {
                ValidateFields("");
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
        //if exisit
        fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                Access();
            } else {
                window.location.replace("MNU040100");
            };
        });
        //access
        function Access() {
            //access
            fnAccess('SCM230000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //validate
        function Validate(ID) {
            fnValidateRecord('Mstr_UOM', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    Edit_Dtl_Ok_Await(ID);
                } else {
                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                };
            });
        };
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
        //if exisit
        fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                Access();
            } else {
                window.location.replace("MNU040100");
            };
        });
        //access
        function Access() {
            //access
            fnAccess('SCM230000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //validate
        function Validate(ID) {
            fnValidateRecord('Mstr_UOM', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    ValidateFields(ID);
                } else {
                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                };
            });
        };
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx0101Name").value == "") {
            //Alert
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0101Initial").value == "") {
            //Alert
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
                if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                    Edit_Add_Ok_Await();
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                    //if exisit
                    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                        if (response[0].oReturn == "1") {
                            fnValidateRecord('Mstr_UOM', ID, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Edit_Upd_Ok_Await(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        } else {
                            window.location.replace("MNU040100");
                        };
                    });
                }
            }
        });
    };
    //do edit
    function Edit_Add_Ok_Await() {
        // Add
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM230100HND.ashx",
            data: {
                'pFormCode': 'SCM230100',
                'pType': 'Add - Record',
                'pName': document.getElementById("tbx0101Name").value,
                'pInitial': document.getElementById("tbx0101Initial").value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Add", response[0].oID);
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oID;
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            },
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD";
        document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Update
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM230100HND.ashx",
            data: {
                'pFormCode': 'SCM230100',
                'pType': 'Edit - Record',
                'pID': ID,
                'pName': document.getElementById("tbx0101Name").value,
                'pInitial': document.getElementById("tbx0101Initial").value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            },
        });
    };
};
function fn0101Lock() {
    //if exisit
    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Access();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //access
    function Access() {
        fnAccess('SCM230000', 'Lock', function (response) {
            if (response[0].oReturn == "1") {
                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    };
    //validate
    function Validate(ID) {
        fnValidateRecord('Mstr_UOM', ID, '', 'Lock', function (response) {
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
            didOpen: () => {
                const input = document.getElementById("tbx0101LockPassword");
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
                fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                    if (response[0].oReturn == "") {
                        fnValidateRecord('Mstr_UOM', ID, '', 'Lock', function (response) {
                            if (response[0].oReturn == "") {
                                Lock_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
        });
    };
    //lock ok
    function Lock_Ok(ID) {
        fnLock('Lock', 'Mstr_UOM', ID, function (response) {
            fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
            if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
        });
    };
};
function fn0101Unlock() {
    //if exists
    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Access();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //access
    function Access() {
        fnAccess('SCM230000', 'Unlock', function (response) {
            if (response[0].oReturn == "1") {
                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    };
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
            html: `<input id="tbx0101UnlockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
            didOpen: () => {
                const input = document.getElementById("tbx0101UnlockPassword");
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
                fnValidatePassword(document.getElementById("tbx0101UnlockPassword").value, function (response) {
                    if (response[0].oReturn == "") {
                        fnValidateRecord('Mstr_UOM', ID, '', 'Unlock', function (response) {
                            if (response[0].oReturn == "") {
                                Unlock_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
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
            if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
        });
    }
};
//overview

//attachment
function fn0201LoadAttachment(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'SCM230000',
            'pType': 'Upload - Get Record',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0201LoaderAttachment").style.display = "";
            //display loader

            $('#table0201Attachment').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0201Attachment = $("#table0201Attachment").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: true,
                data: response,
                columns: [
                    { data: 'Action' },
                    { data: 'Type' },
                    { data: 'Attachment' },
                    { data: 'UploadedBy' },
                    { data: 'UploadedDate' }],
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                order: [[2, 'asc']],
            });
            //datatable

            //search
            $('#tbx0201FindAttachment').on('keyup', function () {
                table0201Attachment.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0201LoaderAttachment").style.display = "none";
            //hide loader

            //action button
            if (pMode == "ADD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            } else if (pMode == "DTL") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = false;
                }
            } else if (pMode == "UPD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            }
            //action button

        },
    });
};
function fn0201Download(pFormCode, pID, pFileName) {
    //if exists
    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Download();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //download
    function Download() {
        $.ajax({
            type: "POST",
            url: "HNDGEN.ashx",
            data: {
                'pFormCode': pFormCode,
                'pType': 'Upload - Download',
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                window.open('MNU020200?View=' + response[0].View);
            },
        });
    };
};
function fn0201Delete(pFormCode, pID, pFileName) {
    //if exisit
    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Access();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //access
    function Access() {
        fnAccess('SCM230000', 'Delete', function (response) {
            if (response[0].oReturn == "1") {
                Delete_Question(pFormCode, pID, pFileName);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    };
    //delete question
    function Delete_Question(pFormCode, pID, pFileName) {
        Swal.fire({
            text: 'Remove attachment?',
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
                Delete_Ok(pFormCode, pID, pFileName);
            }
        });
    };
    function Delete_Ok(pFormCode, pID, pFileName) {
        $.ajax({
            type: "POST",
            url: "HNDGEN.ashx",
            data: {
                'pFormCode': pFormCode,
                'pType': 'Upload - Delete',
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
            },
        });
    };
};
//attachment

//notes
function fn0301LoadNotes(pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'SCM230000',
            'pType': 'Notes - Get Record',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0301LoaderNotes").style.display = "";
            //display loader

            $('#table0301Notes').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0301Notes = $("#table0301Notes").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                data: response,
                columns: [
                    { data: 'Notes' }],
                columnDefs: [{ targets: 0, orderable: false }],
                ordering: false
            });
            //datatable

            //search
            $('#tbx0301FindNotes').on('keyup', function () {
                table0301Notes.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0301LoaderNotes").style.display = "none";
            //hide loader

        },
    });
};
function fn0301Add() {
    //if exisit
    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //add
    function Add() {
        document.getElementById("tbx0302Note").value = "";
        document.getElementById("hdnMention").value = "";
        $('#mdl0302Notes').modal('show');
    };
};
function fn0302Add_Ok(Btn) {
    //if exisit
    fnIfExist('sys_um', 'u_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add_Ok();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //add
    async function Add_Ok() {
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = true;
        // Show loading indicator
        Btn.setAttribute('data-kt-indicator', 'on');
        // Simulate form submission
        await fn0302Add_Ok_Await(Btn);
    }
};
function fn0302Add_Ok_Await(Btn) {
    // process
    return new Promise(resolve => {
        //Validate
        if (document.getElementById("tbx0302Note").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else {
            Add_Ok_Await();
        }
        //add
        function Add_Ok_Await() {
            // Do Billing
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'SCM230000',
                    'pType': 'Notes - Add',
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pNotes': document.getElementById("tbx0302Note").value,
                    'pMention': document.getElementById("hdnMention").value,
                },
                success: function (response) {
                    //message
                    fnAlertOnly('Note successfully added.', 'success', 'btn btn-success');
                    document.getElementById("tbx0302Note").value = "";
                    document.getElementById("hdnMention").value = "";
                    fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
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
//notes

//@mention
var mentionUser = [];
var initialMention = [];
var jq = jQuery.noConflict();
//@mention

//load page
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {

        //metion
        jq.fn.atwho.debug = true;
        var chatHub = jq.connection.chatHub;
        jq.connection.hub.start().done(function () {
            loadFunction()
        }).fail(function (error) {
            console.error("SignalR connection failed: " + error)
        });
        function loadFunction() {
            chatHub.server.getEmployeeData().then(function (data) {
                initAtWho(data);
            }).catch(function (error) {
                console.error("Error fetching data from SignalR:", error)
            });
            function initAtWho(data) {
                var at_config = {
                    at: "@",
                    data: data,
                    insertTpl: '${fname}',
                    displayTpl: "<li><div class='d-flex align-items-center'><div class='symbol symbol-30px overflow-hidden me-3'><div class='symbol-label'> <img src='Assets/media/avatars/${empPic}' class='w-100' alt='' />  </div></div><div class='d-flex flex-column '><span class='text-weight-500 text-gray-800 '>${name}</span><span class='text-weight-500'>${email}</span></div></div></li>",
                    limit: 200,
                    callbacks: {
                        beforeInsert: function (value, jqli, e) {
                            var selectedUserData = jqli.data('item-data');
                            mentionUser.push({
                                name: selectedUserData.fname,
                                empCode: selectedUserData.empCode
                            })
                            var emp_no = mentionUser.map(function (employee) {
                                return employee.empCode
                            });
                            initialMention = emp_no;
                            $('#hdnMention').val(initialMention.join(','));
                            return '@' + value;
                        },
                    }
                }
                $inputor = jq('.mention').atwho(at_config);
                $inputor.caret('pos', 47);
                $inputor.focus().atwho('run');
                // for removing mention
                $inputor.on('keydown', function (e) {
                    if (e.keyCode === 8) {
                        handleBackspace();
                    }
                })
                function handleBackspace() {
                    var inputValue = $inputor.val();
                    var cursorPosition = $inputor.caret('pos');
                    var mentionStart = inputValue.lastIndexOf('@', cursorPosition - 1);

                    if (mentionStart !== -1) {
                        // Extract mention text to be removed
                        var mentionText = inputValue.substring(mentionStart, cursorPosition);

                        // Find and remove mention from mentionUser array
                        mentionUser = mentionUser.filter(function (user) {
                            return `@${user.name}` !== mentionText;
                        });

                        var emp_no = mentionUser.map(function (employee) {
                            return employee.empCode
                        });

                        initialMention = emp_no;
                    }
                }
            };
        };
        //metion

        //combobox
        $('[data-kt-repeater="select2"]').select2();
        //combobox

        //date
        $('[data-kt-repeater="datepicker"]').flatpickr({
            dateFormat: "m/d/Y"
        });
        //date

        //upload
        Dropzone.autoDiscover = false;
        var myDropzone = new Dropzone("#DropZone", {
            url: "HNDGEN.ashx?pFormCode=SCM230000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
            autoProcessQueue: false,
            //upload more than 2 files by Dropzone.js with button
            parallelUploads: 5,
            //File size
            maxFilesize: 10,
            //Number of files
            maxFiles: 5,
            acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
            addRemoveLinks: true,
            success: function (file, response) {
                file.previewElement.classList.add("dz-success");
                // Perform button
                var Btn = document.getElementById('btn0202Add_Ok');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                //hide modal
                $('#mdl0202Upload').modal('hide');
                //load attachment
                fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                //message
                fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
            },
            error: function (file, response) {
                file.previewElement.classList.add("dz-error");
            }
        });
        myDropzone.on("addedfile", function (file) {
            FileCount = FileCount + 1;
        });
        myDropzone.on("removedfile", function (file) {
            FileCount = FileCount - 1;
        });
        $('#btn0201Add').on('click', function (e) {
            //access
            fnAccess('SCM130000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add() {
                myDropzone.removeAllFiles();
                FileCount = 0;
                $('#mdl0202Upload').modal('show');
            };
        });
        $('#btn0202Add_Ok').on('click', function (e) {
            //access
            fnAccess('SCM130000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                if (FileCount > 0) {
                    btn0202Add_Ok();
                } else {
                    fnAlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
                }
            }
            //upload
            async function btn0202Add_Ok() {
                // Perform button
                var Btn = document.getElementById('btn0202Add_Ok');
                // Disable button to avoid multiple click
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await btn0202Add_Ok_Await(Btn);
            }
            async function btn0202Add_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM230000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
                    myDropzone.processQueue();
                    //resolve
                    resolve();
                });
            }
        });
        //upload

    });
    jQuery(function ($) {
        fn01Load();
    });
};
//load page
