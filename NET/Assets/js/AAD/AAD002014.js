//form
var FormCodeHdr = 'AAD002000'
var FormCodeDtl = 'AAD002014'
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
        fn0102LoadSetup(document.getElementById("hdn02ID").value);
    });
};
//master

//page

function fn02Load(pID) {
    fn01Access(FormCodeHdr, 'View', function (response) {
        if (response[0].oReturn == "1") {
            LoadHeader(pID);
            LoadBody(pID);
            LoadSellerName(pID);
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
            url: "Assets/Handler/AAD/AAD002014HND.ashx",
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
                        { data: 'Realty' },
                        { data: 'Group' },
                        { data: 'Type' },
                        { data: 'Seller' },
                        { data: 'LOComm' },
                        { data: 'HLComm' },
                        { data: 'WT' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, className: 'tbody-nowrap-auto' },
                        { targets: 2, className: 'tbody-nowrap-auto' },
                        { targets: 3, className: 'tbody-nowrap-auto' },
                        { targets: 4, className: 'tbody-nowrap-auto' },
                        { targets: 5, orderable: false },
                        { targets: 6, orderable: false }],
                    order: []
                });
                $('#tbx02Find').on('keyup', function () { tbl02Record.search(this.value).draw(); });
            },
        });
    };
    function LoadSellerName(pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002014HND.ashx",
            data: {
                'pFunction': 'Get-Info-04',
                'pID': pID,
            },
            success: function (response) {
                document.getElementById("lbl02SellerName").innerText = response[0].SellerName || "-";
            },
        });
    };


};

//page

//record
let realtyOptions = [];
let groupOptions = [];
let sellerOptions = [];
// Load all dropdown data once
function loadDropdownData() {
    return $.when(
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002014HND.ashx",    
            data: { pFunction: 'Get-Record-03-List', pTblName: 'mstr_Realty', pPlaceHolder: 'Select Realty' },
            dataType: "json"
        }),
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002014HND.ashx",
            data: { pFunction: 'Get-Record-03-List', pTblName: 'mstr_SellerGroup', pPlaceHolder: 'Select Group' },
            dataType: "json"
        }),
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002014HND.ashx",
            data: { pFunction: 'Get-Record-03-List', pTblName: 'mstr_Sellers', pPlaceHolder: 'Select Seller' },
            dataType: "json"
        })
    ).done(function (realty, group, seller) {
        // $.when resolves each response as [data, status, xhr]
        realtyOptions = realty[0];
        groupOptions = group[0];
        sellerOptions = seller[0];
    });
}
// helper function
function resetDataTable(tableId) {
    let $table = $(tableId);

    // make sure the table exists in DOM
    if ($table.length) {
        // only destroy if it's already a DataTable
        if ($.fn.DataTable.isDataTable($table)) {
            $table.DataTable().clear().destroy();
            $table.empty(); // 🔑 also clear headers/rows to avoid duplication
        }
    }
}

function fn0102LoadSetup(pID) {
    // Load dropdowns first, then proceed
    loadDropdownData().done(function () {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002014HND.ashx",
            data: {
                pFunction: 'Get-Info-03',
                pID: pID,
            },
            success: function (response) {
                document.getElementById("div0102LoaderSetup").style.display = "";

                resetDataTable("#table0102Setup");

                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });

                $.fn.dataTable.moment('MM/DD/YYYY');

                var table0102Setup = $("#table0102Setup").DataTable({
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
                        { data: 'Type' },
                        {
                            data: 'RealtyCode',
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    let rowID = meta.row;
                                    let selectId = `ddlRealty_${rowID}`;
                                    let options = realtyOptions.map(item =>
                                        `<option value="${item.ID}" ${String(item.ID) === String(row.RealtyCode) ? 'selected' : ''}>${item.Name}</option>`
                                    ).join('');
                                    return `
                                        <select id="${selectId}" data-dropdown-parent="#table0102Setup" data-kt-repeater="select2" 
                                                class="form-select form-select-sm form-select-border">
                                            ${options}
                                        </select>`;
                                }
                                return data;
                            }
                        },
                        {
                            data: 'GroupCode',
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    let rowID = meta.row;
                                    let selectId = `ddlGroup_${rowID}`;
                                    let options = groupOptions.map(item =>
                                        `<option value="${item.ID}" ${String(item.ID) === String(row.GroupCode) ? 'selected' : ''}>${item.Name}</option>`
                                    ).join('');
                                    return `
                                        <select id="${selectId}" data-dropdown-parent="#table0102Setup" data-kt-repeater="select2" 
                                                class="form-select form-select-sm form-select-border">
                                                                ${options}
                                        </select>`;
                                }
                                return data;
                            }
                        },
                        {
                            data: 'SellerCode',
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    let rowID = meta.row;
                                    let selectId = `ddlSeller_${rowID}`;
                                    let options = sellerOptions.map(item =>
                                        `<option value="${item.ID}" ${item.ID === row.SellerCode ? 'selected' : ''}>${item.Name}</option>`
                                    ).join('');
                                    return `
                                        <select id="${selectId}" data-dropdown-parent="#table0102Setup" data-kt-repeater="select2" 
                                                class="form-select form-select-sm form-select-border">
                                                            ${options}
                                        </select>`;
                                }
                                return data;
                            }
                        },
                        {
                            data: 'LOComm',
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    let inputId = `commRate_${meta.row}`;
                                    let value = isNaN(parseFloat(data)) ? '0.00' : parseFloat(data).toFixed(2);
                                    return `
                                        <input id="${inputId}" type="text" step="0.01" class="form-control form-control-sm"
                                               value="${value}" onkeypress="return fnEnterKey(event, this)" onblur="fnFormatNumeric(this)"/>
                                    `;
                                }
                                return data;
                            }
                        },
                        {
                            data: 'HLComm',
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    let inputId = `hlCommRate_${meta.row}`;
                                    let value = isNaN(parseFloat(data)) ? '0.00' : parseFloat(data).toFixed(2);
                                    return `
                                        <input id="${inputId}" type="text" step="0.01" class="form-control form-control-sm"
                                               value="${value}" onkeypress="return fnEnterKey(event, this)" onblur="fnFormatNumeric(this)" />
                                    `;
                                }
                                return data;
                            }
                        },
                        { data: 'TypeCode', visible: false }
                    ],
                    drawCallback: function () {
                        $('[data-kt-repeater="select2"]').each(function () {
                            if (!$(this).hasClass("select2-hidden-accessible")) {
                                $(this).select2({ width: '100%' });
                            }
                        });
                    },
                    columnDefs: [
                        { targets: [0, 1, 2, 3], orderable: false }
                    ],
                    ordering: false
                });

                document.getElementById("div0102LoaderSetup").style.display = "none";
            }
        });
    });
}
function fn0102Setup() {
    //if exisit
    fnIfExist('calmardbLive.dbo.ICR_Buyers', 'AcctNo', document.getElementById("hdn02ID").value, function (response) {
        if (response[0].oReturn == "1") {
            Access();
        } else {
            window.location.replace("MNU040100");
        };
    });
    //access
    function Access() {
        fnAccess(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                $('#mdl0102Setup').modal('show');
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    };
}
function saveSellerSetup() {
    document.getElementById("btn0102Setup").disabled = true;
    setTimeout(function () {
        document.getElementById("btn0102Setup").disabled = false;
    }, 3000);
    var str = window.location.href;
    var url = new URL(str);
    let AcctNo = url.searchParams.get("pID");
    const table = $('#table0102Setup').DataTable();
    const rowCount = table.rows().count();

    let payload = [];

    for (let i = 0; i < rowCount; i++) {
        let realtyCode = $(`#ddlRealty_${i}`).val();
        let groupCode = $(`#ddlGroup_${i}`).val();
        let sellerCode = $(`#ddlSeller_${i}`).val();

        let commRate = parseFloat($(`#commRate_${i}`).val()) || 0;
        let hlCommRate = parseFloat($(`#hlCommRate_${i}`).val()) || 0;

        // Define mapping
        let type = (table.cell(i, 0).data() || "").toString().trim().toUpperCase();
        console.log("Row", i, "type raw:", table.cell(i, 0).data());
        const typeMap = {
            "SR": 1,
            "SM": 2,
            "SD": 3,
            "GSM": 4,
            "JR. SD": 6,
            "BROKER": 7
        };
        // Get code, or 0 if not found
        let typeCode = typeMap[type] || 0;
        let level = i + 1;

        // Check if row has any value
        let hasValue = sellerCode || groupCode || realtyCode || commRate || hlCommRate || typeCode !== 0;

        if (hasValue) {
            // If one of them is missing → show alert and skip this row
            if (!sellerCode || !groupCode || !realtyCode || typeCode === 0) {
                continue; // 🔹 skip this row, but keep processing the rest
            }

            // ✅ All required fields are present → push
            payload.push({
                SellerCode: sellerCode,
                TypeCode: typeCode,
                GroupCode: groupCode,
                RealtyCode: realtyCode,
                CommRate: commRate,
                HLCommRate: hlCommRate,
                Level: level
            });
        }

        // else → row is completely empty → skip silently
    }

    if (payload.length === 0) {
        fnAlertOnly('No seller setup data to save.', 'error', 'btn btn-danger');
        return;
    }

    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002014HND.ashx",
        data: {
            pFunction: 'Update-Record-04',
            pID: AcctNo,
            pPayload: JSON.stringify(payload)
        },
        dataType: "json", // 🔹 force JSON
        success: function (res) {
            if (res.status === "Success") {
                fnAlertOnly('Record successfully added.', 'success', 'btn btn-success');
                $('#mdl0102Setup').modal('hide');
                fn02Load(AcctNo)
            } else {
                console.error(res);
                fnAlertOnly('Failed to save setup: ' + res.message, 'error', 'btn btn-danger');
            }
        },
        error: function (xhr, status, error) {
            console.error("Error saving setup:", error);
            fnAlertOnly('Error occurred while saving setup.', 'error', 'btn btn-danger');
        }
    });

}

//record
