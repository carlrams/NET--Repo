//form
var FormCodeHdr = 'AAD002000'
var FormCodeDtl = 'AAD002013'
//form

//attachment
var FileCount = 0;
//attachment

//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        var str = window.location.href;
        var url = new URL(str);
        document.getElementById("hdn02ID").value = url.searchParams.get("pID");
        fn01Plugins();
        fn02Load(document.getElementById("hdn02ID").value);
    });
};
//master

//page
function fn02Load(pID) {
    fn01Access(FormCodeHdr, 'View', function (response) {
        if (response[0].oReturn == "1") {
            LoadHeader(pID);
            LoadBody(pID);
        } else {
            location.replace("MNU000022");
        };
    });
    function LoadHeader(pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Info-02',
                'pID': pID,
            },
            success: function (response) {
                //detail
                document.getElementById("lbl02AcctNo").innerText = response[0].AcctNo;
                document.getElementById("lbl02AcctName").innerText = response[0].AcctName;
                document.getElementById("lbl02Project").innerText = response[0].Project;
                document.getElementById("lbl02ModelName").innerText = response[0].ModelName;
                document.getElementById("lbl02Status").innerText = response[0].Status;
                document.getElementById("lbl02Balance").innerText = response[0].Balance;
                //detail
            },
        });
    };
    function LoadBody(pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002013HND.ashx",
            data: {
                'pFunction': 'Get-Record-02',
                'pID': pID,
            },
            success: function (response) {
                $('#tbl02Record').DataTable().destroy();
                DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
                DataTable.datetime('MM/DD/YYYY');
                var tbl02Record = $("#tbl02Record").DataTable({
                    processing: true,
                    bFilter: true,
                    bPaginate: true,
                    bInfo: true,
                    paging: true,
                    lengthChange: false,
                    pageLength: 50,
                    select: true,
                    data: response,
                    columns: [
                        { data: 'Action' },
                        { data: 'Reminder' },
                        { data: 'Type' },
                        { data: 'NoteDate' },
                        { data: 'Note' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, orderable: false },
                        { targets: 2, orderable: false },
                        { targets: 3, orderable: false, className: 'dt-body-left', type: 'date' },
                        { targets: 4, className: 'tbody-nowrap-auto' }],
                    order: [false],

                });
                $('#tbx02Find').on('keyup', function () { tbl02Record.search(this.value).draw(); });
            },
        });
    };
};
function fn02Redraw(Action, ID) {

    //update list
    if (Action == "Add" || Action == "Edit") {
        $.ajax({
            type: "POST",
            url: "Assets/handler/AAD/AAD002013HND.ashx",
            data: {
                'pFunction': 'Redraw-02',
                'pID': ID
            },
            success: function (response) {
                if (Action == "Add") {
                    //add row
                    var gv01 = $('#tbl02Record').DataTable();
                    gv01.rows().deselect();
                    var row01 = gv01.row.add(
                        {
                            Action: response[0].Action,
                            Reminder: response[0].Reminder,
                            Type: response[0].Type,
                            NoteDate: response[0].NoteDate,
                            Note: response[0].Note
                        }).draw(false).select();
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
                    var gv01 = $('#tbl02Record').DataTable();
                    gv01.rows().deselect();
                    let row01 = gv01.row('#' + response[0].rowId);
                    let index01 = row01.index();
                    gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                    gv01.cell({ row: index01, column: 1 }).data(response[0].Reminder).draw(false);
                    gv01.cell({ row: index01, column: 2 }).data(response[0].Type).draw(false);
                    gv01.cell({ row: index01, column: 3 }).data(response[0].NoteDate).draw(false);
                    gv01.cell({ row: index01, column: 4 }).data(response[0].Note).draw(false);
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
        var gv01 = $('#tbl02Record').DataTable();
        gv01.row('#rowID02' + ID).remove().draw(false);
    };
};
function fn02Refresh() {
    fn02Load(document.getElementById("hdn02ID").value);
};
function fn02Add() {
    //access
    fn01Access(FormCodeDtl, 'Add', function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    function Add() {
        document.getElementById("hdn03Mode").value = "ADD";
        document.getElementById("hdn03ID").value = document.getElementById("hdn02ID").value + '-0-0';
        fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
        $('#mdl03View').modal('show');
    };
};
function fn02View(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Load(pMode, pID);
};
function fn02Delete(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Delete();
};
function fn02Edit(pMode, pID) {
    //access
    fn01Access(FormCodeDtl, 'Save', function (response) {
        if (response[0].oReturn == "1") {
            Edit(pMode, pID);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    function Edit(pMode, pID) {
        fn03Load(pMode, pID)
        document.getElementById("hdn03Mode").value = pMode;
        document.getElementById("hdn03ID").value = pID;
        $('#mdl03View').modal('show');
    }
};
//page

//record
function fn03DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn03Refresh").classList.remove("btn-view");
        document.getElementById("btn03Add").classList.remove("btn-add");
        document.getElementById("btn03Delete").classList.remove("btn-delete");
        document.getElementById("btn03Edit").classList.remove("btn-edit");
    } else {
        document.getElementById("btn03Refresh").classList.add("btn-view");
        document.getElementById("btn03Add").classList.add("btn-add");
        document.getElementById("btn03Delete").classList.add("btn-delete");
        document.getElementById("btn03Edit").classList.add("btn-edit");
    }
    document.getElementById("btn03Refresh").disabled = pValue;
    document.getElementById("btn03Add").disabled = pValue;
    document.getElementById("btn03Delete").disabled = pValue;
    document.getElementById("btn03Edit").disabled = pValue;
};
function ddl03Type(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002013HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl03Type").html(s);
            $('#ddl03Type').val(pID).trigger('change');
        },
    });
};
function fn03Load(pMode, pID) {
    if (pMode == "ADD") {
        //title
        document.getElementById("spn03Title").innerText = "New Record";
        document.getElementById("spn03Status").innerText = "New";
        if (document.getElementById("spn03Status").innerText == "New") {
            document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-new");
        };
        //title

        //toolbar
        fn03DisableButtons(true);
        document.getElementById("btn03Delete").classList.add("btn-delete");
        document.getElementById("btn03Delete").disabled = false;
        document.getElementById("btn03Edit").classList.add("btn-edit");
        document.getElementById("btn03Edit").disabled = false;
        document.getElementById("i03Edit").classList.remove("la-pencil-alt");
        document.getElementById("i03Edit").classList.add("la-save");
        //toolbar

        //content
        document.getElementById("cbx03Reminder02").checked = false;
        document.getElementById("div03Detail").style.display = "none";
        document.getElementById("div03Update").style.display = "";
        ddl03Type('');
        fn01ClearTime('tbx03DateNote');
        document.getElementById("tbx03Notes").value = "";
        document.getElementById("lbl03UpdatedByName").innerText = "";
        document.getElementById("lbl03UpdatedDate").innerText = "";
        //content

        //attachment
        LoadOthers();
        //note

    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002013HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID
            },
            success: function (response) {
                //title
                document.getElementById("spn03Title").innerText = response[0].Title;
                document.getElementById("spn03Status").innerText = response[0].RecordStatus;
                if (document.getElementById("spn03Status").innerText == "New") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-new");
                };
                //title

                //toolbar
                document.getElementById("i03Edit").classList.add("la-pencil-alt");
                document.getElementById("i03Edit").classList.remove("la-save");
                fn03DisableButtons(false);
                //checkbox

                //content
                document.getElementById("div03Detail").style.display = "";
                document.getElementById("div03Update").style.display = "none";
                document.getElementById("lbl03Type").innerText = response[0].Type;
                document.getElementById("cbx03Reminder01").checked = response[0].Reminder;
                document.getElementById("lbl03DateNote").innerText = response[0].NotesDate;
                document.getElementById("lbl03Notes").innerText = response[0].Notes;
                document.getElementById("lbl03UpdatedByName").innerText = response[0].updated_by;
                document.getElementById("lbl03UpdatedDate").innerText = response[0].AuditDate;
                //content

                //attachment
                LoadOthers();
                //note

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002013HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID

            },
            success: function (response) {
                //title
                document.getElementById("spn03Title").innerText = response[0].Title;
                document.getElementById("spn03Status").innerText = response[0].RecordStatus;
                if (document.getElementById("spn03Status").innerText == "New") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-new");
                };
                //title

                //toolbar
                fn03DisableButtons(true);
                document.getElementById("btn03Delete").classList.add("btn-delete");
                document.getElementById("btn03Delete").disabled = false;
                document.getElementById("btn03Edit").classList.add("btn-edit");
                document.getElementById("btn03Edit").disabled = false;
                document.getElementById("i03Edit").classList.remove("la-pencil-alt");
                document.getElementById("i03Edit").classList.add("la-save");
                //toolbar

                //content
                document.getElementById("div03Detail").style.display = "none";
                document.getElementById("div03Update").style.display = "";
                ddl03Type(response[0].NotesType);
                document.getElementById("cbx03Reminder02").checked = response[0].Reminder;
                document.getElementById("tbx03DateNote").value = response[0].NotesDate;
                document.getElementById("tbx03Notes").value = response[0].Notes;
                document.getElementById("lbl03UpdatedByName").innerText = response[0].updated_by;
                document.getElementById("lbl03UpdatedDate").innerText = response[0].AuditDate;
                //content

                //attachment
                LoadOthers();
                //note
            },
        });
    }

    function LoadOthers() {
        if (pMode == "ADD") { document.getElementById("hdn03IDPrev").value = ""; };
        if (pMode == "DTL") { document.getElementById("hdn03IDPrev").value = pID; };
        if (pMode == "UPD") { document.getElementById("hdn03IDPrev").value = pID; };
    };
};
function fn03Refresh() {
    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value, document.getElementById("hdn03Trxno").value);
};
function fn03Add() {
    //access
    fn01Access(FormCodeDtl, 'Add', function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    function Add() {
        document.getElementById("hdn03Mode").value = "ADD";
        document.getElementById("hdn03ID").value = "000000000000";
        fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value, document.getElementById("hdn03Trxno").value);
    };
};
function fn03Delete() {
    if (document.getElementById('hdn03Mode').value == "ADD") {
        Cancel_Add_Question();
    } else if (document.getElementById('hdn03Mode').value == "DTL") {
        //access
        fn01Access(FormCodeDtl, 'Delete', function (response) {
            if (response[0].oReturn == "1") {
                Delete_Dtl_Question(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
        //validate
    } else if (document.getElementById('hdn03Mode').value == "UPD") {
        Cancel_Upd_Question(document.getElementById('hdn03ID').value);
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
                confirmButton: 'btn btn-sm btn-primary min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                if (document.getElementById('hdn03IDPrev').value == "") {
                    $('#mdl03View').modal('hide');
                } else {
                    document.getElementById('hdn03Mode').value = "DTL"
                    document.getElementById('hdn03ID').value = document.getElementById('hdn03IDPrev').value;
                    document.getElementById('hdn03IDPrev').value = document.getElementById('hdn03IDPrev').value;
                    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value, document.getElementById("hdn03Trxno").value);
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
                confirmButton: 'btn btn-sm btn-primary min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                Detele_Ok(ID);
            }
        });
        function Detele_Ok(ID) {
            fn01Delete(FormCodeDtl, 'ICR_AccountNotes', ID, function (response) {
                if (document.getElementById('hdn03IDPrev').value == "") {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn02Redraw("Delete", ID);
                    $('#mdl03View').modal('hide');
                } else if (document.getElementById('hdn03IDPrev').value == ID) {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn02Redraw("Delete", ID);
                    $('#mdl03View').modal('hide');
                } else if (document.getElementById('hdn03IDPrev').value != ID) {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn02Redraw("Delete", ID);
                    document.getElementById('hdn03Mode').value = "DTL"
                    document.getElementById('hdn03ID').value = document.getElementById('hdn03IDPrev').value
                    document.getElementById('hdn03IDPrev').value = document.getElementById('hdn03IDPrev').value
                    fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value, document.getElementById("hdn03Trxno").value);
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
                confirmButton: 'btn btn-sm btn-primary min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value, document.getElementById("hdn03Trxno").value);
            }
        });
    };
};
function fn03Edit() {
    //validate
    if (document.getElementById('hdn03Mode').value == "ADD") {
        //access
        fn01Access(FormCodeDtl, 'Add', function (response) {
            if (response[0].oReturn == "1") {
                ValidateFields("");
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
    } else if (document.getElementById('hdn03Mode').value == "DTL") {
        //access
        fn01Access(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                Edit_Dtl_Ok_Await(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
        //validate
    } else if (document.getElementById('hdn03Mode').value == "UPD") {
        //access
        fn01Access(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                ValidateFields(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
        //validate
    }

    //validate fields

    function ValidateFields(ID) {
        if (document.getElementById("ddl03Type").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx03DateNote").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx03Notes").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else {
            Edit_Question(ID);
        }
    }


    //question.
    async function Edit_Question(ID) {
        const result = await Swal.fire({
            text: 'Save record?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-primary min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        });

        if (result.isConfirmed) {
            const mode = document.getElementById('hdn03Mode').value;

            if (mode === "ADD") {
                await Edit_Add_Ok_Await(ID);  
            } else if (mode === "DTL") {
                await Edit_Dtl_Ok_Await(ID);
            } else if (mode === "UPD") {
                await Edit_Upd_Ok_Await(ID);   // wait until UPDATE finishes
            }
        }
    }
    function ValidateIfPushedMail(ID) {
        let notes = document.getElementById("tbx03Notes").value.trim();
        let ddl = document.getElementById("ddl03Type");
        let type = ddl.options[ddl.selectedIndex].text;

        if (notes.includes("PICKED-UP BY J&T (FOR BUYER'S SIGNATURE)") && type === "CTS") {
            SendCTS();
        } else {
            console.log("Condition NOT met, skipping SendCTS()");
        }
    }

    //do edit

    function Edit_Add_Ok_Await() {

        var str = window.location.href;
        var url = new URL(str);
        pAcctNo = url.searchParams.get("pID");
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/handler/AAD/AAD002013HND.ashx",
            data: {
                'pFunction': 'Add-Record-03',
                'pAcctNo': pAcctNo,
                'pPayType': document.getElementById("ddl03Type").value,
                'pCheck': document.getElementById("cbx03Reminder02").checked,
                'pNotesDate': document.getElementById("tbx03DateNote").value,
                'pNotes': document.getElementById("tbx03Notes").value,
            },
            success: function (response) {
                document.getElementById('hdn03Mode').value = "DTL"
                fn01AlertOnly('Record successfully saved.', 'success');
                ValidateIfPushedMail(); 
                fn02Redraw("Add", response[0].oID);
                document.getElementById('hdn03ID').value = response[0].oID
                document.getElementById('hdn03IDPrev').value = response[0].oID
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
            },
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('hdn03Mode').value = "UPD"
        document.getElementById('hdn03ID').value = ID
        document.getElementById('hdn03IDPrev').value = ID
        fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/handler/AAD/AAD002013HND.ashx",
            data: {
                'pFunction': 'Update-Record-03',
                'pID': ID,
                'pPayType': document.getElementById("ddl03Type").value,
                'pCheck': document.getElementById("cbx03Reminder02").checked,
                'pNotesDate': document.getElementById("tbx03DateNote").value,
                'pNotes': document.getElementById("tbx03Notes").value
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                fn02Redraw("Edit", ID);
                ValidateIfPushedMail(); 
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
            },
        });
    };
};

function SendCTS() {
    console.log("SendCTS triggered!");
    Swal.fire({
        text: 'Send push mail?',
        icon: 'question',
        iconColor: '#0095e8',
        buttonsStyling: false,
        showCancelButton: true,
        confirmButtonText: "Yes",
        cancelButtonText: 'Cancel',
        customClass: {
            confirmButton: 'btn btn-sm btn-primary min-w-100px',
            cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            console.log("Triggered")
            var str = window.location.href;
            var url = new URL(str);
            let pID = url.searchParams.get("pID");

            // Get record
            $.ajax({
                type: "POST",
                url: "Assets/handler/AAD/AAD002013HND.ashx",
                data: {
                    'pFunction': 'Getdata-Account',
                    'pID': pID
                },
                success: function (response) {
                    // fallback if empty
                    if (!response || response.length === 0) {
                        response = [{}];
                    }

                    let AcctName = response[0].AcctName || "";
                    let Project = response[0].Project || "";
                    let Address = response[0].Address || "";
                    let MainEmail = "namichanchan27@gmail.com";

                    // Get Co-buyers
                    $.ajax({
                        type: "POST",
                        url: "Assets/handler/AAD/AAD002013HND.ashx",
                        data: {
                            'pFunction': 'Getdata-Cobuyers-email',
                            'pID': pID
                        },
                        success: function (coBuyerResponse) {
                            let EmailCoBuyer = [];

                            if (coBuyerResponse && coBuyerResponse.length > 0) {
                                EmailCoBuyer = [
                                    { Email: "edmarrosos27@gmail.com" },
                                    { Email: "namichanchan27@gmail.com" }
                                ];
                                coBuyerResponse.forEach(e => {
                                    e.Email = (e.Email || "").trim();
                                });
                            }

                            // Get pushmail recipients
                            $.ajax({
                                type: "POST",
                                url: "Assets/handler/AAD/AAD002013HND.ashx",
                                data: {
                                    'pFunction': 'GetdataPushmail',
                                    'pID': pID
                                },
                                success: function (EmailResponse) {
                                    if (!EmailResponse || EmailResponse.length === 0) {
                                        EmailResponse = [];
                                    }

                                    var EmailTest = [
                                        { EmailType: "To", Email: "edmarrosos27@gmail.com" },
                                        { EmailType: "CC", Email: "brenda23.aquino23@calmarland.com" },
                                        { EmailType: "CC", Email: "namichanchan27@gmail.com" }

                                    ];
                                    EmailResponse.forEach(e => {
                                        e.Email = (e.Email || "").trim();
                                    });

                                    // Get seller
                                    $.ajax({
                                        type: "POST",
                                        url: "Assets/handler/AAD/AAD002013HND.ashx",
                                        data: {
                                            'pFunction': 'Getdata-Account-Seller',
                                            'pID': pID
                                        },
                                        success: function (SellerResponse) {
                                            if (!SellerResponse || SellerResponse.length === 0) {
                                                SellerResponse = [{}];
                                            }

                                            var SellerEmail = SellerResponse[0].EmailAddress || "";
                                            var SellerGrp = SellerResponse[0].SellerGrpDesc || "";
                                            var SellerEmailtest = "namichanchan27@gmail.com";

                                            // Send pushmail
                                            $.ajax({
                                                type: "POST",
                                                url: "Assets/handler/AAD/AAD002013HND.ashx",
                                                data: {
                                                    'pFunction': 'SendPushmail',
                                                    'AcctNo': pID,
                                                    'Project': Project,
                                                    'AcctName': AcctName,
                                                    'Address': Address,
                                                    'EmailCoBuyer': JSON.stringify(EmailCoBuyer),
                                                    'SellerEmail': SellerEmailtest,
                                                    'SellerGrp': SellerGrp,
                                                    'Email': JSON.stringify(EmailTest),
                                                    'MainEmail': MainEmail
                                                },
                                                success: function (response) {
                                                    fnAlertOnly('Email sent successfully.', 'success', 'btn btn-success');
                                                },
                                                error: function (xhr, status, error) {
                                                    console.log("Error sending pushmail: " + error);
                                                }
                                            });
                                        },
                                        error: function (xhr, status, error) {
                                            console.log("Error: " + error);
                                        }
                                    });
                                }
                            });
                        }
                    });
                }
            });
        }
    });
}



//record
