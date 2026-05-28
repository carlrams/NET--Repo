//form
var FormCodeHdr = 'AAD002000'
var FormCodeDtl = 'AAD002002'
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
            url: "Assets/Handler/AAD/AAD002002HND.ashx",
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
                        { data: 'Lock' },
                        { data: 'Post' },
                        { data: 'Cancel' },
                        { data: 'PayDesc' },
                        { data: 'TotalAmount' },
                        { data: 'Coinciding' },
                        { data: 'InstallmentNo' },
                        { data: 'InstallmentAmount' },
                        { data: 'StartDate' },
                        { data: 'Blank' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, orderable: false },
                        { targets: 2, orderable: false },
                        { targets: 3, orderable: false },
                        { targets: 4, className: 'tbody-nowrap-auto' },
                        { targets: 5, className: 'dt-body-right', type: 'num' },
                        { targets: 6, orderable: false },
                        { targets: 7, className: 'dt-body-center', type: 'num' },
                        { targets: 8, className: 'dt-body-right', type: 'num' },
                        { targets: 9, className: 'dt-body-center' },
                        { targets: 10, orderable: false }],
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
            url: "Assets/handler/AAD/AAD002002HND.ashx",
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
                            Lock: response[0].Lock,
                            Post: response[0].Post,
                            Cancel: response[0].Cancel,
                            PayDesc: response[0].PayDesc,
                            TotalAmount: response[0].TotalAmount,
                            Coinciding: response[0].Coinciding,
                            InstallmentNo: response[0].InstallmentNo,
                            InstallmentAmount: response[0].InstallmentAmount,
                            StartDate: response[0].StartDate,
                            Blank: response[0].Blank
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
                    gv01.cell({ row: index01, column: 1 }).data(response[0].Lock).draw(false);
                    gv01.cell({ row: index01, column: 2 }).data(response[0].Post).draw(false);
                    gv01.cell({ row: index01, column: 3 }).data(response[0].Cancel).draw(false);
                    gv01.cell({ row: index01, column: 4 }).data(response[0].PayDesc).draw(false);
                    gv01.cell({ row: index01, column: 5 }).data(response[0].TotalAmount).draw(false);
                    gv01.cell({ row: index01, column: 6 }).data(response[0].Coinciding).draw(false);
                    gv01.cell({ row: index01, column: 7 }).data(response[0].InstallmentNo).draw(false);
                    gv01.cell({ row: index01, column: 8 }).data(response[0].InstallmentAmount).draw(false);
                    gv01.cell({ row: index01, column: 9 }).data(response[0].StartDate).draw(false);
                    gv01.cell({ row: index01, column: 10 }).data(response[0].Blank).draw(false);
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
    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
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
            Validate(pMode, pID);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    //validate
    function Validate(pMode, pID) {
        fn01ValidateRecord('trn_OCSummary', pID, '', 'Save', function (response) {
            if (response[0].oReturn == "") {
                Edit(pMode, pID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
    };
    //edit
    function Edit(pMode, pID) {
        document.getElementById("hdn03Mode").value = pMode;
        document.getElementById("hdn03ID").value = pID;
        fn03Edit();
        $('#mdl03View').modal('show');
    }
};
function fn02Lock(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Lock();
};
function fn02Unlock(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Unlock();
};
function fn02Post(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Post();
};
function fn02Cancel(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Cancel();
};
//page

//record
function fn03DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn03Refresh").classList.remove("btn-view");
        document.getElementById("btn03Add").classList.remove("btn-add");
        document.getElementById("btn03Delete").classList.remove("btn-delete");
        document.getElementById("btn03Edit").classList.remove("btn-edit");
        document.getElementById("btn03Lock").classList.remove("btn-lock");
        document.getElementById("btn03Unlock").classList.remove("btn-lock");
        document.getElementById("btn03Post").classList.remove("btn-post");
        document.getElementById("btn03Cancel").classList.remove("btn-cancel");
    } else {
        document.getElementById("btn03Refresh").classList.add("btn-view");
        document.getElementById("btn03Add").classList.add("btn-add");
        document.getElementById("btn03Delete").classList.add("btn-delete");
        document.getElementById("btn03Edit").classList.add("btn-edit");
        document.getElementById("btn03Lock").classList.add("btn-lock");
        document.getElementById("btn03Unlock").classList.add("btn-lock");
        document.getElementById("btn03Post").classList.add("btn-post");
        document.getElementById("btn03Cancel").classList.add("btn-cancel");
    }
    document.getElementById("btn03Refresh").disabled = pValue;
    document.getElementById("btn03Add").disabled = pValue;
    document.getElementById("btn03Delete").disabled = pValue;
    document.getElementById("btn03Edit").disabled = pValue;
    document.getElementById("btn03Lock").disabled = pValue;
    document.getElementById("btn03Unlock").disabled = pValue;
    document.getElementById("btn03Post").disabled = pValue;
    document.getElementById("btn03Cancel").disabled = pValue;
};
function ddl03PayType(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002002HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'mstr_PaymentType',
            'pPlaceHolder': 'Application'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl03PayType").html(s);
            $('#ddl03PayType').val(pID).trigger('change');
        },
    });
};
function cbx03Coinciding02_onchange(cbx03Coinciding02) {
    if (cbx03Coinciding02.checked == true) {
        if (document.getElementById("tbx03TotalAmount").value == "") { document.getElementById("tbx03TotalAmount").value = 0 };
        fn01FormatNumeric(document.getElementById("tbx03TotalAmount"));
        document.getElementById("spn03InstallmentNo").classList.remove('required');
        document.getElementById("tbx03InstallmentNo").readOnly = true;
        document.getElementById("tbx03InstallmentNo").value = 0;        
        fn01FormatInteger(document.getElementById("tbx03InstallmentNo"));
        document.getElementById("spn03InstallmentAmount").classList.remove('required');
        document.getElementById("tbx03InstallmentAmount").value = 0;
        fn01FormatNumeric(document.getElementById("tbx03InstallmentAmount"));
        document.getElementById("spn03StartDate").classList.remove('required');
        document.getElementById("tbx03StartDate").disabled = true;
        fn01ClearTime('tbx03StartDate');
    } else {
        if (document.getElementById("tbx03TotalAmount").value == "") { document.getElementById("tbx03TotalAmount").value = 0 };
        fn01FormatNumeric(document.getElementById("tbx03TotalAmount"));
        document.getElementById("spn03InstallmentNo").classList.add('required');
        document.getElementById("tbx03InstallmentNo").readOnly = false;
        if (document.getElementById("tbx03InstallmentNo").value == "") { document.getElementById("tbx03InstallmentNo").value = 0 };
        fn01FormatInteger(document.getElementById("tbx03InstallmentNo"));
        document.getElementById("spn03InstallmentAmount").classList.add('required');
        if (document.getElementById("tbx03InstallmentAmount").value == "") { document.getElementById("tbx03InstallmentAmount").value = 0 };
        fn01FormatNumeric(document.getElementById("tbx03InstallmentAmount"));
        document.getElementById("spn03StartDate").classList.add('required');
        document.getElementById("tbx03StartDate").disabled = false;
    }

};
function tbx03TotalAmount_onblur(tbx03TotalAmount) {
    if (tbx03TotalAmount.value == '') { tbx03TotalAmount.value = 0 };
    fn01FormatNumeric(tbx03TotalAmount);
    if (document.getElementById("tbx03InstallmentNo").value == '') { document.getElementById("tbx03InstallmentNo").value = 0 };
    fn01FormatInteger(document.getElementById("tbx03InstallmentNo"));
    tbx03InstallmentAmount_onblur(tbx03TotalAmount.value.replace(',', ''), document.getElementById("tbx03InstallmentNo").value.replace(',', ''));
};
function tbx03InstallmentNo_onblur(tbx03InstallmentNo) {
    if (document.getElementById("tbx03TotalAmount").value == '') { document.getElementById("tbx03TotalAmount").value = 0 };
    fn01FormatNumeric(document.getElementById("tbx03TotalAmount"));
    if (tbx03InstallmentNo.value == '') { tbx03InstallmentNo.value = 0 };
    fn01FormatInteger(tbx03InstallmentNo);
    tbx03InstallmentAmount_onblur(tbx03TotalAmount.value.replace(',', ''), document.getElementById("tbx03InstallmentNo").value.replace(',', ''));
};
function tbx03InstallmentAmount_onblur(tbx03TotalAmount, tbx03InstallmentNo) {
    if (tbx03InstallmentNo == "0") {
        document.getElementById("tbx03InstallmentAmount").value = 0;
    } else {
        document.getElementById("tbx03InstallmentAmount").value = parseFloat(tbx03TotalAmount) / parseFloat(tbx03InstallmentNo);
    }
    fn01FormatNumeric(document.getElementById("tbx03InstallmentAmount"));
}
function fn03Load(pMode, pID) {
    if (pMode == "ADD") {
        //title
        document.getElementById("spn03Title").innerText = "New Record";
        document.getElementById("spn03Status").innerText = "New";
        if (document.getElementById("spn03Status").innerText == "New") {
            document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-new");
        } else if (document.getElementById("spn03Status").innerText == "Locked") {
            document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-locked");
        } else if (document.getElementById("spn03Status").innerText == "Unlocked") {
            document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
        } else if (document.getElementById("spn03Status").innerText == "Posted") {
            document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-posted");
        } else if (document.getElementById("spn03Status").innerText == "Cancelled") {
            document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
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
        document.getElementById("cbx03Lock").checked = false;
        document.getElementById("cbx03Post").checked = false;
        document.getElementById("cbx03Cancel").checked = false;
        //toolbar

        //content
        document.getElementById("cbx03Coinciding02").checked = false;
        cbx03Coinciding02_onchange(document.getElementById("cbx03Coinciding02"));
        document.getElementById("div03Detail").style.display = "none";
        document.getElementById("div03Update").style.display = "";
        ddl03PayType('');
        fn01ClearTime('tbx03StartDate');
        document.getElementById("tbx03Remarks").value = "";
        document.getElementById("lbl03UpdatedByName").innerText = "";
        document.getElementById("lbl03UpdatedDate").innerText = "";
        document.getElementById("lbl03LockedByName").innerText = "";
        document.getElementById("lbl03LockedDate").innerText = "";
        document.getElementById("lbl03PostedByName").innerText = ""
        document.getElementById("lbl03PostedDate").innerText = "";
        document.getElementById("lbl03CancelledByName").innerText = "";
        document.getElementById("lbl03CancelledDate").innerText = "";
        document.getElementById("lbl03CancelledRemarks").innerText = "";
        //content

        //attachment
        LoadOthers();
        //note

    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002002HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID,
            },
            success: function (response) {
                //title
                document.getElementById("spn03Title").innerText = response[0].Title;
                document.getElementById("spn03Status").innerText = response[0].RecordStatus;
                if (document.getElementById("spn03Status").innerText == "New") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn03Status").innerText == "Locked") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-locked");
                } else if (document.getElementById("spn03Status").innerText == "Unlocked") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                } else if (document.getElementById("spn03Status").innerText == "Posted") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-posted");
                } else if (document.getElementById("spn03Status").innerText == "Cancelled") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                };
                //title

                //toolbar
                document.getElementById("i03Edit").classList.add("la-pencil-alt");
                document.getElementById("i03Edit").classList.remove("la-save");
                fn03DisableButtons(false);
                document.getElementById("cbx03Lock").checked = response[0].Lock;
                document.getElementById("cbx03Post").checked = response[0].Post;
                document.getElementById("cbx03Cancel").checked = response[0].Cancel;
                //checkbox

                //content
                document.getElementById("div03Detail").style.display = "";
                document.getElementById("div03Update").style.display = "none";
                document.getElementById("lbl03PayDesc").innerText = response[0].PayDesc;
                document.getElementById("lbl03TotalAmount").innerText = response[0].TotalAmount;
                document.getElementById("lbl03InstallmentNo").innerText = response[0].InstallmentNo;
                document.getElementById("lbl03InstallmentAmount").innerText = response[0].InstallmentAmount;
                document.getElementById("cbx03Coinciding01").checked = response[0].Coinciding;
                document.getElementById("lbl03StartDate").innerText = response[0].StartDate;
                document.getElementById("lbl03Remarks").innerText = response[0].Remarks;
                document.getElementById("lbl03UpdatedByName").innerText = response[0].UpdatedByName;
                document.getElementById("lbl03UpdatedDate").innerText = response[0].UpdatedDate;
                document.getElementById("lbl03LockedByName").innerText = response[0].LockedByName;
                document.getElementById("lbl03LockedDate").innerText = response[0].LockedDate;
                document.getElementById("lbl03PostedByName").innerText = response[0].PostedByName;
                document.getElementById("lbl03PostedDate").innerText = response[0].PostedDate;
                document.getElementById("lbl03CancelledByName").innerText = response[0].CancelledByName;
                document.getElementById("lbl03CancelledDate").innerText = response[0].CancelledDate;
                document.getElementById("lbl03CancelledRemarks").innerText = response[0].CancelledRemarks;
                //content

                //attachment
                LoadOthers();
                //note

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002002HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID
            },
            success: function (response) {
                //title
                document.getElementById("spn03Title").innerText = response[0].Description;
                document.getElementById("spn03Status").innerText = response[0].RecordStatus;
                if (document.getElementById("spn03Status").innerText == "New") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn03Status").innerText == "Locked") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-locked");
                } else if (document.getElementById("spn03Status").innerText == "Unlocked") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                } else if (document.getElementById("spn03Status").innerText == "Posted") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-posted");
                } else if (document.getElementById("spn03Status").innerText == "Cancelled") {
                    document.getElementById("spn03Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
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
                document.getElementById("cbx03Lock").checked = response[0].Lock;
                document.getElementById("cbx03Post").checked = response[0].Post;
                document.getElementById("cbx03Cancel").checked = response[0].Cancel;
                //toolbar

                //content
                document.getElementById("div03Detail").style.display = "none";
                document.getElementById("div03Update").style.display = "";
                ddl03PayType(response[0].PayType);
                document.getElementById("tbx03TotalAmount").value = response[0].TotalAmount;
                document.getElementById("tbx03InstallmentNo").value = response[0].InstallmentNo;
                document.getElementById("tbx03InstallmentAmount").value = response[0].InstallmentAmount;
                document.getElementById("cbx03Coinciding02").checked = response[0].Coinciding;
                cbx03Coinciding02_onchange(document.getElementById("cbx03Coinciding02"));
                document.getElementById("tbx03StartDate").value = response[0].StartDate;
                document.getElementById("tbx03Remarks").innerText = response[0].Remarks;
                document.getElementById("lbl03UpdatedByName").innerText = response[0].UpdatedByName;
                document.getElementById("lbl03UpdatedDate").innerText = response[0].UpdatedDate;
                document.getElementById("lbl03LockedByName").innerText = response[0].LockedByName;
                document.getElementById("lbl03LockedDate").innerText = response[0].LockedDate;
                document.getElementById("lbl03PostedByName").innerText = response[0].PostedByName;
                document.getElementById("lbl03PostedDate").innerText = response[0].PostedDate;
                document.getElementById("lbl03CancelledByName").innerText = response[0].CancelledByName;
                document.getElementById("lbl03CancelledDate").innerText = response[0].CancelledDate;
                document.getElementById("lbl03CancelledRemarks").innerText = response[0].CancelledRemarks;
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
    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
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
        fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
    };
};
function fn03Delete() {
    if (document.getElementById('hdn03Mode').value == "ADD") {
        Cancel_Add_Question();
    } else if (document.getElementById('hdn03Mode').value == "DTL") {
        //access
        fn01Access(FormCodeDtl, 'Delete', function (response) {
            if (response[0].oReturn == "1") {
                Validate(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
        //validate
        function Validate(ID) {
            fn01ValidateRecord('trn_OCSummary', ID, '', 'Delete', function (response) {
                if (response[0].oReturn == "") {
                    Delete_Dtl_Question(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
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
                    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
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
            fn01Delete(FormCodeDtl, 'trn_OCSummary', ID, function (response) {
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
                    fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
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
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
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
                Validate(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
        //validate
        function Validate(ID) {
            fn01ValidateRecord('trn_OCSummary', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    Edit_Dtl_Ok_Await(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    } else if (document.getElementById('hdn03Mode').value == "UPD") {
        //access
        fn01Access(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                Validate(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
        //validate
        function Validate(ID) {
            fn01ValidateRecord('trn_OCSummary', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    ValidateFields(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("ddl03PayType").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx03TotalAmount").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (parseFloat(document.getElementById("tbx03TotalAmount").value.replace(',','')) <= 0) {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx03InstallmentNo").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("cbx03Coinciding02").checked == false && parseFloat(document.getElementById("tbx03InstallmentNo").value.replace(',', '')) <= 0) {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx03InstallmentAmount").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("cbx03Coinciding02").checked == false && parseFloat(document.getElementById("tbx03InstallmentAmount").value.replace(',', '')) <= 0) {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("cbx03Coinciding02").checked == false && document.getElementById("tbx03StartDate").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx03Remarks").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
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
                confirmButton: 'btn btn-sm btn-primary min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                if (document.getElementById('hdn03Mode').value == "ADD") {
                    Edit_Add_Ok_Await();
                } else if (document.getElementById('hdn03Mode').value == "DTL") {
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('hdn03Mode').value == "UPD") {
                    Edit_Upd_Ok_Await(ID);
                }
            }
        });
    };
    //do edit
    function Edit_Add_Ok_Await() {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/handler/AAD/AAD002002HND.ashx",
            data: {
                'pFunction': 'Add-Record-03',
                'pAcctNo': document.getElementById("hdn02ID").value,
                'pPayType': document.getElementById("ddl03PayType").value,
                'pTotalAmount': document.getElementById("tbx03TotalAmount").value,
                'pInstallmentNo': document.getElementById("tbx03InstallmentNo").value,
                'pInstallmentAmount': document.getElementById("tbx03InstallmentAmount").value,
                'pCoinciding': document.getElementById("cbx03Coinciding02").checked,
                'pStartDate': document.getElementById("tbx03StartDate").value,
                'pRemarks': document.getElementById("tbx03Remarks").value,
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                fn02Redraw("Add", response[0].oID);
                document.getElementById('hdn03Mode').value = "DTL"
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
            url: "Assets/handler/AAD/AAD002002HND.ashx",
            data: {
                'pFunction': 'Update-Record-03',
                'pID': ID,
                'pAcctNo': document.getElementById("hdn02ID").value,
                'pPayType': document.getElementById("ddl03PayType").value,
                'pTotalAmount': document.getElementById("tbx03TotalAmount").value,
                'pInstallmentNo': document.getElementById("tbx03InstallmentNo").value,
                'pInstallmentAmount': document.getElementById("tbx03InstallmentAmount").value,
                'pCoinciding': document.getElementById("cbx03Coinciding02").checked,
                'pStartDate': document.getElementById("tbx03StartDate").value,
                'pRemarks': document.getElementById("tbx03Remarks").value,
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                fn02Redraw("Edit", ID);
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
            },
        });
    };
};
function fn03Lock() {
    //access
    fn01Access(FormCodeDtl, 'Lock', function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('hdn03ID').value);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    //validate
    function Validate(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Lock', function (response) {
            if (response[0].oReturn == "") {
                Lock_Question(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
    };
    //lock question
    function Lock_Question(ID) {
        Swal.fire({
            title: '<span class="fs-6 fw-normal text-gray-700">Lock record?</span>',
            icon: 'question',
            html: `<input id="tbx03LockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
            iconColor: '#009ef7',
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
                fn01ValidatePassword(document.getElementById("tbx03LockPassword").value, function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Ok(ID);
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'warning');
                    };
                });
            }
        });
    };
    //lock ok
    function Lock_Ok(ID) {
        fn01Lock('Lock-Record-01', 'trn_OCSummary', ID, 1, function (response) {
            fn01AlertOnly('Record successfully locked.', 'success');
            fn02Redraw("Edit", ID);
            fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
        });
    }
};
function fn03Unlock() {
    //access
    fn01Access(FormCodeDtl, 'Unlock', function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('hdn03ID').value);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    //validate
    function Validate(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Unlock', function (response) {
            if (response[0].oReturn == "") {
                Unlock_Question(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
    };
    //unlock question
    function Unlock_Question(ID) {
        Swal.fire({
            title: '<span class="fs-6 fw-normal text-gray-700">Unlock record?</span>',
            icon: 'question',
            html: `<input id="tbx03UnlockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
            iconColor: '#009ef7',
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
                fn01ValidatePassword(document.getElementById("tbx03UnlockPassword").value, function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Ok(ID);
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'warning');
                    };
                });
            }
        });
    };
    //unlock ok
    function Unlock_Ok(ID) {
        fn01Lock('Lock-Record-01','trn_OCSummary', ID, 0, function (response) {
            fn01AlertOnly('Record successfully unlocked.', 'success');
            fn02Redraw("Edit", ID);
            fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
        });
    }
};
function fn03Post() {
    //access
    fn01Access(FormCodeDtl, 'Post', function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('hdn03ID').value);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    //validate
    function Validate(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Post', function (response) {
            if (response[0].oReturn == "") {
                Post_Question(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
    };
    //unlock question
    function Post_Question(ID) {
        Swal.fire({
            title: '<span class="fs-6 fw-normal text-gray-700">Post record?</span>',
            icon: 'question',
            html: `<input id="tbx03PostPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
            iconColor: '#009ef7',
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
                fn01ValidatePassword(document.getElementById("tbx03PostPassword").value, function (response) {
                    if (response[0].oReturn == "") {
                        Post_Ok(ID);
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'warning');
                    };
                });
            }
        });
    };
    //post ok
    function Post_Ok(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Post', function (response) {
            if (response[0].oReturn == "") {
                Post(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
        function Post(ID) {
            $.ajax({
                type: "POST",
                url: "Assets/handler/AAD/AAD002002HND.ashx",
                data: {
                    'pFunction': 'Post-Record-03',
                    'pID': ID
                },
                success: function (response) {
                    fn01AlertOnly('Record successfully posted.', 'success', 'btn btn-success');
                    fn02Redraw("Edit", ID);
                    fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
                },
            });
        }
    };
};
function fn03Cancel() {
    //access
    fn01Access(FormCodeDtl, 'Cancel', function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('hdn03ID').value);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    //validate
    function Validate(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Cancel', function (response) {
            if (response[0].oReturn == "") {
                Cancel(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
    };
    //cancel
    function Cancel() {
        document.getElementById("tbx0301CancelledRemarks").value = "";
        $('#mdl0301Cancel').modal('show');
    };
};
//record


//cancel
function fn0301Cancel() {
    //access
    fn01Access(FormCodeDtl, 'Cancel', function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('hdn03ID').value);
        } else {
            fn01AlertOnly('Access denied!', 'error');
        };
    });
    //validate
    function Validate(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Cancel', function (response) {
            if (response[0].oReturn == "") {
                ValidateFields(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
    };
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx0301CancelledRemarks").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else {
            Cancel_Question(ID);
        }
    }
    //question
    function Cancel_Question(ID) {
        Swal.fire({
            title: '<span class="fs-6 fw-normal text-gray-700">Cancel record?</span>',
            icon: 'question',
            html: `<input id="tbx0301CancelPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
            iconColor: '#009ef7',
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
                fn01ValidatePassword(document.getElementById("tbx0301CancelPassword").value, function (response) {
                    if (response[0].oReturn == "") {
                        Cancel_Ok(ID);
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'warning');
                    };
                });
            }
        });
    };
    //do edit
    function Cancel_Ok(ID) {
        fn01ValidateRecord('trn_OCSummary', ID, '', 'Cancel', function (response) {
            if (response[0].oReturn == "") {
                Cancel(ID);
            } else {
                fn01AlertOnly(response[0].oReturn, 'warning');
            };
        });
        function Cancel(ID) {
            // Do Billing
            $.ajax({
                type: "POST",
                url: "Assets/handler/AAD/AAD002002HND.ashx",
                data: {
                    'pFunction': 'Cancel-Record-03',
                    'pID': ID,
                    'pCancelledRemarks': document.getElementById("tbx0301CancelledRemarks").value,
                },
                success: function (response) {
                    fn01AlertOnly('Record successfully cancelled.', 'success');
                    fn02Redraw("Edit", ID);
                    document.getElementById('hdn03Mode').value = "DTL"
                    document.getElementById('hdn03ID').value = ID
                    document.getElementById('hdn03IDPrev').value = ID
                    fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
                    $('#mdl0301Cancel').modal('hide');
                },
            });
        }
    };
};
//cancel