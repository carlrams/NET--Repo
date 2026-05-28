var FormCode = 'AAD002000'

//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        fn01Plugins();
        fn02Load();
    });
};
//master

//page
function fn02Load() {
    fn01Access(FormCode, 'View', function (response) {
        
        if (response[0].oReturn == "1") {
            Load();
        } else {
            location.replace("MNU000022");
        };
    });
    function Load() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002000HND.ashx",
            data: {
                'pFunction': 'Get-Record-02',
                'pAcctNo': document.getElementById("hdn0201AcctNo").value,
                'pAcctName': document.getElementById("hdn0201AcctName").value,
                'pDOEFrom': document.getElementById("hdn0201DOEFrom").value,
                'pDOETo': document.getElementById("hdn0201DOETo").value,
                'pSubd': document.getElementById("hdn0201Subd").value,
                'pPhase': document.getElementById("hdn0201Phase").value,
                'pBlock': document.getElementById("hdn0201Block").value,
                'pLot': document.getElementById("hdn0201Lot").value,
                'pPaid': document.getElementById("hdn0201Paid").checked,
                'pCancelled': document.getElementById("hdn0201Cancelled").checked,
                'pTransferred': document.getElementById("hdn0201Transferred").checked,
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
                        { data: 'AcctNo' },
                        { data: 'AcctName' },
                        { data: 'Project' },
                        { data: 'DOE' },
                        { data: 'Paid' },
                        { data: 'Cancelled' },
                        { data: 'Transferred' },
                        { data: 'Blank' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, className: 'tbody-nowrap-auto' },
                        { targets: 2, className: 'tbody-nowrap-auto' },
                        { targets: 3, className: 'tbody-nowrap-auto' },
                        { targets: 4, className: 'tbody-nowrap-auto' },
                        { targets: 5, orderable: false },
                        { targets: 6, orderable: false },
                        { targets: 7, orderable: false },
                        { targets: 8, orderable: false }],
                    order: [[2, 'asc']],

                });
                $('#tbx02Find').on('keyup', function () { tbl02Record.search(this.value).draw(); });
            },
        });
    };
};
function fn02Redraw(Action, ID) {
    if (Action == "Add" || Action == "Edit") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002000HND.ashx",
            data: {
                'pFunction': 'Redraw-02',
                'pID': ID
            },
            success: function (response) {
                if (Action == "Add") {
                    var gv01 = $('#tbl02Record').DataTable();
                    gv01.rows().deselect();
                    var row01 = gv01.row.add(
                        {
                            Action: response[0].Action,
                            AcctNo: response[0].AcctNo,
                            AcctName: response[0].AcctName,
                            Project: response[0].Project,
                            DOE: response[0].DOE,
                            Paid: response[0].Paid,
                            Cancelled: response[0].Cancelled,
                            Transferred: response[0].Transferred,
                            Blank: response[0].Blank
                        }).draw(false).select();
                    $(row01.node()).attr('id', response[0].rowId);
                    let new01 = gv01.row('#' + response[0].rowId);
                    let index01 = new01.index();
                    var rowNode = gv01.row(index01).node();
                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                } else if (Action == "Edit") {
                    var gv01 = $('#tbl02Record').DataTable();
                    gv01.rows().deselect();
                    let row01 = gv01.row('#' + response[0].rowId);
                    let index01 = row01.index();
                    gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                    gv01.cell({ row: index01, column: 1 }).data(response[0].AcctNo).draw(false);
                    gv01.cell({ row: index01, column: 2 }).data(response[0].AcctName).draw(false);
                    gv01.cell({ row: index01, column: 3 }).data(response[0].Project).draw(false);
                    gv01.cell({ row: index01, column: 4 }).data(response[0].DOE).draw(false);
                    gv01.cell({ row: index01, column: 5 }).data(response[0].Paid).draw(false);
                    gv01.cell({ row: index01, column: 6 }).data(response[0].Cancelled).draw(false);
                    gv01.cell({ row: index01, column: 7 }).data(response[0].Transferred).draw(false);
                    gv01.cell({ row: index01, column: 8 }).data(response[0].Blank).draw(false);
                    row01.select();
                    var rowNode = gv01.row(index01).node();
                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                };
            },
        });
    } else {
        var gv01 = $('#tbl02Record').DataTable();
        gv01.row('#rowID02' + ID).remove().draw(false);
    };
};
function fn02Filter() {
    document.getElementById("tbx0201AcctNo").value = document.getElementById("hdn0201AcctNo").value;
    document.getElementById("tbx0201AcctName").value = document.getElementById("hdn0201AcctName").value;
    document.getElementById("tbx0201Subd").value = document.getElementById("hdn0201Subd").value;
    document.getElementById("tbx0201Phase").value = document.getElementById("hdn0201Phase").value;
    document.getElementById("tbx0201Block").value = document.getElementById("hdn0201Block").value;
    document.getElementById("tbx0201Lot").value = document.getElementById("hdn0201Lot").value;
    document.getElementById("tbx0201DOEFrom").value = document.getElementById("hdn0201DOEFrom").value;
    document.getElementById("tbx0201DOETo").value = document.getElementById("hdn0201DOETo").value;
    document.getElementById("cbx0201Paid").checked = document.getElementById("hdn0201Paid").checked;
    document.getElementById("cbx0201Cancelled").checked = document.getElementById("hdn0201Cancelled").checked;
    document.getElementById("cbx0201Transferred").checked = document.getElementById("hdn0201Transferred").checked;
    $('#mdl0201Filter').modal('show');
};
function fn02Refresh() {
    fn02Load();
};
function fn02View(pMode, pID) {
    document.getElementById("hdn03Mode").value = pMode;
    document.getElementById("hdn03ID").value = pID;
    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
};
//page

//filter
function fn0201Filter_Ok(Btn) {
    Btn.disabled = true;
    Btn.setAttribute('data-kt-indicator', 'on');

    document.getElementById("hdn0201AcctNo").value = document.getElementById("tbx0201AcctNo").value;
    document.getElementById("hdn0201AcctName").value = document.getElementById("tbx0201AcctName").value;
    document.getElementById("hdn0201Subd").value = document.getElementById("tbx0201Subd").value;
    document.getElementById("hdn0201Phase").value = document.getElementById("tbx0201Phase").value;
    document.getElementById("hdn0201Block").value = document.getElementById("tbx0201Block").value;
    document.getElementById("hdn0201Lot").value = document.getElementById("tbx0201Lot").value;
    document.getElementById("hdn0201DOEFrom").value = document.getElementById("tbx0201DOEFrom").value;
    document.getElementById("hdn0201DOETo").value = document.getElementById("tbx0201DOETo").value;
    document.getElementById("hdn0201Paid").checked = document.getElementById("cbx0201Paid").checked;
    document.getElementById("hdn0201Cancelled").checked = document.getElementById("cbx0201Cancelled").checked;
    document.getElementById("hdn0201Transferred").checked = document.getElementById("cbx0201Transferred").checked;

    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002000HND.ashx",
        data: {
            'pFunction': 'Get-Record-02',
            'pAcctNo': document.getElementById("hdn0201AcctNo").value,
            'pAcctName': document.getElementById("hdn0201AcctName").value,
            'pSubd': document.getElementById("hdn0201Subd").value,
            'pPhase': document.getElementById("hdn0201Phase").value,
            'pBlock': document.getElementById("hdn0201Block").value,
            'pLot': document.getElementById("hdn0201Lot").value,
            'pDOEFrom': document.getElementById("hdn0201DOEFrom").value,
            'pDOETo': document.getElementById("hdn0201DOETo").value,
            'pPaid': document.getElementById("hdn0201Paid").checked,
            'pCancelled': document.getElementById("hdn0201Cancelled").checked,
            'pTransferred': document.getElementById("hdn0201Transferred").checked,
        },
        success: function (response) {
            $('#tbl02Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            DataTable.datetime('MM/DD/YYYY');
            var tbl02Record = $("#tbl02Record").DataTable({
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
                    { data: 'AcctNo' },
                    { data: 'AcctName' },
                    { data: 'Project' },
                    { data: 'DOE' },
                    { data: 'Paid' },
                    { data: 'Cancelled' },
                    { data: 'Transferred' },
                    { data: 'Blank' }],
                rowId: 'rowId',
                columnDefs: [
                    { targets: 0, orderable: false },
                    { targets: 1, className: 'tbody-nowrap-auto' },
                    { targets: 2, className: 'tbody-nowrap-auto' },
                    { targets: 3, className: 'tbody-nowrap-auto' },
                    { targets: 4, className: 'dt-body-left' },
                    { targets: 5, orderable: false },
                    { targets: 6, orderable: false },
                    { targets: 7, orderable: false },
                    { targets: 8, orderable: false }],
                order: [[2, 'asc']],

            });
            $('#tbx02Find').on('keyup', function () { tbl02Record.search(this.value).draw(); });
            fn01AlertOnly('Record successfully loaded.', 'success');
            Btn.disabled = false;
            Btn.removeAttribute('data-kt-indicator');
        },
    });
};
//filter