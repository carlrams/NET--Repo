//form
var FormCodeHdr = 'AAD002000'
var FormCodeDtl = 'AAD002017'
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
            url: "Assets/Handler/AAD/AAD002017HND.ashx",
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
                        { data: 'Rcvd' },
                        { data: 'Type' },
                        { data: 'ReqDesc' },
                        { data: 'DocNo' },
                        { data: 'DocDate' },
                        { data: 'ExpDate' },
                        { data: 'ReceivedBy' },
                        { data: 'ReceivedDate' },
                        { data: 'Remarks' },
                        { data: 'Code', visible: false }
                    ],
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
                    order: []
                });
                $('#tbx02Find').on('keyup', function () { tbl02Record.search(this.value).draw(); });
            },
        });
    };


};

//page

//record
//edit
var originalTbodyClone = null;
var originalTableData = null;    
function formatDateToMMDDYYYY(val) {
    if (!val && val !== 0) return "";
    val = String(val).trim();
    if (/^\d{2}\/\d{2}\/\d{4}$/.test(val)) return val;       
    if (/^\d{4}-\d{2}-\d{2}$/.test(val)) {                   
        let [y, m, d] = val.split("-");
        return `${m}/${d}/${y}`;
    }
    if (val.includes("/")) {
        let p = val.split("/");
        if (p.length === 3) {
            let mm = p[0].padStart(2, "0"), dd = p[1].padStart(2, "0"), yyyy = p[2];
            if (yyyy.length === 2) yyyy = "20" + yyyy;
            return `${mm}/${dd}/${yyyy}`;
        }
    }
    let dt = new Date(val);
    if (!isNaN(dt)) {
        let mm = String(dt.getMonth() + 1).padStart(2, "0"),
            dd = String(dt.getDate()).padStart(2, "0"),
            yyyy = dt.getFullYear();
        return `${mm}/${dd}/${yyyy}`;
    }
    return "";
}
function makeRowEditable(row, editableColumns) {
    let cells = row.querySelectorAll("td");

    cells.forEach((cell, index) => {
        if (!editableColumns.includes(index)) return;

        if (cell.querySelector("input, select")) return;

        if (!cell.hasAttribute("data-original-value")) {
            let existing = cell.querySelector("input, select");
            let orig = existing ? (existing.value || existing.textContent || "").toString().trim() : cell.innerText.trim();
            cell.setAttribute("data-original-value", orig);
        }

        let existingSelect = cell.querySelector("select");
        let currentValue = existingSelect ? (existingSelect.value || existingSelect.options[existingSelect.selectedIndex]?.text || "") : cell.innerText.trim();

        cell.innerHTML = "";

        if (index === 1) {
            let select = document.createElement("select");
            select.className = "input-lineTest";
            select.setAttribute("data-kt-repeater", "select2"); 
            select.style.width = "100%";

            let placeholder = document.createElement("option");
            placeholder.value = "";
            placeholder.text = "Select Type";
            placeholder.disabled = false;  
            placeholder.selected = (currentValue === "" || currentValue === null);
            select.appendChild(placeholder);

            let options = ["Standard", "OFW", "Bank", "Locally Employed", "HDMF/Pag-Ibig", "In-House", "Others"];
            options.forEach(opt => {
                let option = document.createElement("option");
                option.value = opt;
                option.text = opt;
                if (opt === currentValue) option.selected = true;
                select.appendChild(option);
            });

            cell.appendChild(select);

        } else if ([4, 5, 7].includes(index)) {
            let input = document.createElement("input");
            input.type = "text";
            input.className = "input-lineTest";
            input.dataset.ktRepeater = "datepicker";
            input.style.width = "90px";
            input.style.height = "18px";
            input.style.padding = 0;
            input.style.margin = 0;
            input.readOnly = true;

            input.addEventListener('keydown', function (e) {
                if (e.key === 'Backspace' || e.key === 'Delete') {
                    e.preventDefault();
                    input.value = '';
                    if (input._flatpickr) input._flatpickr.clear();
                }
            });

            input.value = formatDateToMMDDYYYY(currentValue);
            cell.appendChild(input);

        } else {
            if (existingSelect) {
                existingSelect.disabled = false;
                cell.appendChild(existingSelect);
            } else {
                let input = document.createElement("input");
                input.type = "text";
                input.className = "input-lineTest";
                input.style.width = "100%";
                input.style.height = "15px";
                input.value = currentValue;

                if (index === 3) input.maxLength = 20;
                if (index === 6) input.maxLength = 13;
                if (index === 8) input.maxLength = 1000;

                cell.appendChild(input);
            }
        }
    });
    $(row).find('[data-kt-repeater="datepicker"]').flatpickr({
        dateFormat: "m/d/Y",
        allowInput: true,
        onOpen: function (selectedDates, dateStr, instance) {
            if (!instance.input.value) instance.setDate(new Date());
        }
    });
    $(row).find('[data-kt-repeater="select2"]').select2({
        width: 'resolve'
    });
    $(row).find('.select2-container .select2-selection--single').css({
        'height': '23px',
        'min-height': '23px',
        'line-height': '23px'
    });
}
function restoreRowOriginal(row, editableColumns) {
    let cells = row.querySelectorAll("td");
    cells.forEach((cell, index) => {
        if (!editableColumns.includes(index)) return;

        let input = cell.querySelector("input");
        if (input && input._flatpickr) {
            input._flatpickr.destroy();
        }

        let orig = cell.getAttribute("data-original-value");
        if (orig === null || orig === undefined) {
            return;
        }
        cell.textContent = orig;
    });
}
function makeTableEditable() {
    fnAccess(FormCodeDtl, 'Save', function (response) {
        if (response[0].oReturn != "1") {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            return;
        }
        captureOriginalTableState();
        let editableColumns = [1, 2, 3, 4, 5, 6, 7, 8];
        let tbody = document.getElementById("gv01FormBody");
        if (!tbody) return;

        let rows = Array.from(tbody.querySelectorAll("tr"));
        let hasValidRows = rows.some(row => {
            const cells = row.querySelectorAll("td");
            return !(cells.length === 1 && (cells[0].classList.contains("dt-empty") || cells[0].colSpan > 1));
        });

        if (!hasValidRows) {
            fnAlertOnly('No row to edit!', 'error', 'btn btn-danger');
            return;
        }

        if (!originalTbodyClone) originalTbodyClone = tbody.cloneNode(true);

        rows.forEach(row => makeRowEditable(row, editableColumns));
        rows.forEach(row => {
            let checkbox = row.querySelector("td input[type='checkbox']");
            if (checkbox) {
                checkbox.style.pointerEvents = "auto"; 
            }
        });
        document.getElementById("editTableBtn").style.display = "none";
        document.getElementById("AddTableBtn").style.display = "none";
        document.getElementById("DeleteTableBtn").style.display = "none";
        document.getElementById("saveTableBtn").style.display = "inline-flex";
        document.getElementById("cancelTableBtn").style.display = "inline-flex";
    });
}
function addNewRow() {
    fnAccess(FormCodeDtl, 'Delete', function (response) {
        if (response[0].oReturn != "1") {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            return;
        }

        if (!$.fn.dataTable.isDataTable('#tbl02Record')) {
            fnAlertOnly('Table is not initialized', 'error', 'btn btn-danger');
            return;
        }

        let table = $('#tbl02Record').DataTable();

        captureOriginalTableState();

        if ($('#tbl02Record tbody tr[data-new-row="true"]').length > 0) {
            fnAlertOnly('A new row is already added!', 'warning', 'btn btn-warning');
            return;
        }
        $('#tbl02Record thead th').removeClass('text-end').addClass('text-start');
        let newRowData = {
            Rcvd: "",
            Type: "",
            ReqDesc: "",
            DocNo: "",
            DocDate: "",
            ExpDate: "",
            ReceivedBy: "",
            ReceivedDate: "",
            Remarks: "",
            Code: ""
        };

        let dtRowNode = table.row.add(newRowData).draw(false).node();
        $(dtRowNode).attr("data-new-row", "true");

        let td0 = $(dtRowNode).find("td").eq(0);
        td0.html(
            "<div class='form-check form-check-sm form-check-custom form-check-solid' " +
            "style='display:flex;justify-content:center;align-items:center;padding-right:3px;margin-right:3px;'>" +
            "<input type='checkbox' class='form-check-input checkBoxAllClass chkSelect row-checkbox' />" +
            "</div>"
        );

        let editableColumns = [1, 2, 3, 4, 5, 6, 7, 8];
        $('#tbl02Record tbody tr').each(function () {
            makeRowEditable(this, editableColumns);
        });

        document.getElementById("editTableBtn").style.display = "none";
        document.getElementById("AddTableBtn").style.display = "none";
        document.getElementById("DeleteTableBtn").style.display = "none";
        document.getElementById("saveTableBtn").style.display = "inline-flex";
        document.getElementById("cancelTableBtn").style.display = "inline-flex";
    });
}
function captureOriginalTableState() {
    if (originalTableData === null) {
        if ($.fn.dataTable.isDataTable('#tbl02Record')) {
            originalTableData = $('#tbl02Record').DataTable().rows().data().toArray();
        } else {
            let rows = [];
            $('#tbl02Record tbody tr').each(function () {
                let cols = $(this).find('td');
                rows.push({
                    Rcvd: cols.eq(0).html() || "",
                    Type: cols.eq(1).text().trim() || "",
                    ReqDesc: cols.eq(2).text().trim() || "",
                    DocNo: cols.eq(3).text().trim() || "",
                    DocDate: cols.eq(4).text().trim() || "",
                    ExpDate: cols.eq(5).text().trim() || "",
                    ReceivedBy: cols.eq(6).text().trim() || "",
                    ReceivedDate: cols.eq(7).text().trim() || "",
                    Remarks: cols.eq(8).text().trim() || "",
                    Code: ""
                });
            });
            originalTableData = rows;
        }
    }

    if (originalTbodyClone === null) {
        let tb = document.getElementById("gv01FormBody");
        if (tb) originalTbodyClone = tb.cloneNode(true);
    }
}
function initTbl02RecordWithData(data) {

    if ($.fn.dataTable.isDataTable('#tbl02Record')) {
        $('#tbl02Record').DataTable().clear().destroy();
    }

    DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
    DataTable.datetime('MM/DD/YYYY');

    var tbl = $("#tbl02Record").DataTable({
        processing: true,
        bFilter: true,
        bPaginate: true,
        bInfo: true,
        paging: true,
        lengthChange: false,
        pageLength: 50,
        select: true,
        data: data || [],
        columns: [
            { data: 'Rcvd' },
            { data: 'Type' },
            { data: 'ReqDesc' },
            { data: 'DocNo' },
            { data: 'DocDate' },
            { data: 'ExpDate' },
            { data: 'ReceivedBy' },
            { data: 'ReceivedDate' },
            { data: 'Remarks' },
            { data: 'Code', visible: false }
        ],
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
            { targets: 8, orderable: false }
        ],
        order: []
    });

    $('#tbx02Find').off('keyup').on('keyup', function () {
        tbl.search(this.value).draw();
    });

    return tbl;
}
function CancelTableChanges() {
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
        if (!result.isConfirmed) return;

        if ($.fn.dataTable.isDataTable('#tbl02Record')) {
            $('#tbl02Record').DataTable().clear().destroy();
        }

        if (originalTbodyClone) {
            let tbody = document.getElementById("gv01FormBody");
            tbody.parentNode.replaceChild(originalTbodyClone.cloneNode(true), tbody);

            let pID = document.getElementById("hdn02ID").value;
            $.ajax({
                type: "POST",
                url: "Assets/Handler/AAD/AAD002017HND.ashx",
                data: { 'pFunction': 'Get-Record-02', 'pID': pID },
                success: function (data) {
                    // ✅ rebuild DataTable
                    if ($.fn.dataTable.isDataTable('#tbl02Record')) {
                        $('#tbl02Record').DataTable().clear().destroy();
                    }

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
                        data: data,
                        columns: [
                            { data: 'Rcvd' },
                            { data: 'Type' },
                            { data: 'ReqDesc' },
                            { data: 'DocNo' },
                            { data: 'DocDate' },
                            { data: 'ExpDate' },
                            { data: 'ReceivedBy' },
                            { data: 'ReceivedDate' },
                            { data: 'Remarks' },
                            { data: 'Code', visible: false }
                        ],
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
                            { targets: 8, orderable: false }
                        ],
                        order: []
                    });

                    $('#tbx02Find').on('keyup', function () {
                        tbl02Record.search(this.value).draw();
                    });

                    // ✅ Update originalTableData after reload
                    originalTableData = data;
                    originalTbodyClone = null;
                    document.getElementById("editTableBtn").style.display = "inline-flex";
                    document.getElementById("AddTableBtn").style.display = "inline-flex";
                    document.getElementById("DeleteTableBtn").style.display = "inline-flex";
                    document.getElementById("saveTableBtn").style.display = "none";
                    document.getElementById("cancelTableBtn").style.display = "none";
                },
                error: function () {
                    initTbl02RecordWithData([]);
                    originalTableData = [];
                    originalTbodyClone = null;
                }
            });
        } else {
            // Fallback: if nothing was cloned yet, pull from DB
            let pID = document.getElementById("hdn02ID").value;
            $.ajax({
                type: "POST",
                url: "Assets/Handler/AAD/AAD002017HND.ashx",
                data: { 'pFunction': 'Get-Record-02', 'pID': pID },
                success: function (response) {
                    initTbl02RecordWithData(response);
                    document.getElementById("editTableBtn").style.display = "inline-flex";
                    document.getElementById("AddTableBtn").style.display = "inline-flex";
                    document.getElementById("DeleteTableBtn").style.display = "inline-flex";
                    document.getElementById("saveTableBtn").style.display = "none";
                    document.getElementById("cancelTableBtn").style.display = "none";
                },
                error: function () {
                    initTbl02RecordWithData([]);
                }
            });
        }

    });
}

function confirmSaveTableChanges() {
    let hasMissing = false;

    $('#tbl02Record tbody tr').each(function () {
        let $row = $(this);

        let col1 = $row.find("td:eq(1) select").val()?.trim() || "";
        let col2 = $row.find("td:eq(2) input").val()?.trim() || "";

        // If col1 or col2 is missing regardless of new or existing row
        if (!col1 || !col2) {
            fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
            hasMissing = true;
            return false; // break .each loop
        }
    });

    if (hasMissing) {
        return;
    }

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
            saveTableChanges();
        }
    });
}

function stripHtml(html) {
    let div = document.createElement("div");
    div.innerHTML = html;
    return div.textContent || div.innerText || "";
}
function saveTableChanges() {
    let table = $('#tbl02Record').DataTable();
    let DocumentList = [];
    let pAcctNo = document.getElementById("hdn02ID").value;

    $('#tbl02Record tbody tr').each(function () {
        let $row = $(this);
        let dtRow = table.row(this);
        let rowData = dtRow.data();

        let isNewRow = $row.attr("data-new-row") === "true";
        let code = isNewRow ? null : stripHtml(rowData.Code);
        let isChecked = $row.find('td:eq(0) input[type="checkbox"]').is(':checked') ? 1 : 0;

        let col1 = $row.find("td:eq(1) select").val()?.trim() || "";
        let col2 = $row.find('td:eq(2) input').val()?.trim() || "";
        let col3 = $row.find('td:eq(3) input').val()?.trim() || "";
        let col4 = $row.find('td:eq(4) input').val()?.trim() || "";
        let col5 = $row.find('td:eq(5) input').val()?.trim() || "";
        let col6 = $row.find('td:eq(6) input').val()?.trim() || "";
        let col7 = $row.find('td:eq(7) input').val()?.trim() || "";
        let col8 = $row.find('td:eq(8) input').val()?.trim() || "";

        function formatDate(value) {
            if (value && value.includes("-")) {
                let [yyyy, mm, dd] = value.split("-");
                return `${mm}/${dd}/${yyyy}`;
            }
            return value;
        }

        DocumentList.push({
            code: code,
            isNew: isNewRow,
            checked: isChecked,
            col1: col1,
            col2: col2,
            col3: col3,
            col4: formatDate(col4),
            col5: formatDate(col5),
            col6: col6,
            col7: col7,
            col8: col8
        });
    });

    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002017HND.ashx",
        data: {
            pFunction: 'Update-Record-02',
            pAcctNo: pAcctNo,
            pDocumentList: JSON.stringify(DocumentList)
        },
        success: function (response) {
            Display(response);
        }
    });

    function Display(response) {
        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');

        let pID = document.getElementById("hdn02ID").value;

        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002017HND.ashx",
            data: { 'pFunction': 'Get-Record-02', 'pID': pID },
            success: function (data) {
                // ✅ rebuild DataTable
                if ($.fn.dataTable.isDataTable('#tbl02Record')) {
                    $('#tbl02Record').DataTable().clear().destroy();
                }

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
                    data: data,
                    columns: [
                        { data: 'Rcvd' },
                        { data: 'Type' },
                        { data: 'ReqDesc' },
                        { data: 'DocNo' },
                        { data: 'DocDate' },
                        { data: 'ExpDate' },
                        { data: 'ReceivedBy' },
                        { data: 'ReceivedDate' },
                        { data: 'Remarks' },
                        { data: 'Code', visible: false }
                    ],
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
                        { targets: 8, orderable: false }
                    ],
                    order: []
                });

                $('#tbx02Find').on('keyup', function () {
                    tbl02Record.search(this.value).draw();
                });

                // ✅ Update originalTableData after reload
                originalTableData = data;
                originalTbodyClone = null;
            },
            error: function () {
                initTbl02RecordWithData([]);
                originalTableData = [];
                originalTbodyClone = null;
            }
        });

        // Reset buttons
        document.getElementById("editTableBtn").style.display = "inline-flex";
        document.getElementById("AddTableBtn").style.display = "inline-flex";
        document.getElementById("DeleteTableBtn").style.display = "inline-flex";
        document.getElementById("saveTableBtn").style.display = "none";
        document.getElementById("cancelTableBtn").style.display = "none";
    }
}

function DeleteRow() {
    fnAccess(FormCodeDtl, 'Delete', function (response) {
        if (response[0].oReturn != "1") {
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            return;
        }
        let table = $('#tbl02Record').DataTable();

        let selectedData = table.row({ selected: true }).data();

        if (!selectedData) {
            fnAlertOnly('Please select a row first!', 'warning', 'btn btn-warning');
        } else {
            let code = stripHtml(selectedData.Code);

            Swal.fire({
                text: 'Delete record?',
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
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/AAD/AAD002017HND.ashx",
                        data: {
                            pFunction: 'Delete-Record-02',
                            pCode: code
                        },
                        success: function (response) {
                            fnAlertOnly('Record deleted successfully.', 'success', 'btn btn-success');
                            table.row({ selected: true }).remove().draw(false);
                            let tbody = document.getElementById("gv01FormBody");
                            originalTbodyClone = tbody.cloneNode(true);
                        }
                    });
                }
            });
        }
    });

}
//edit
//record
