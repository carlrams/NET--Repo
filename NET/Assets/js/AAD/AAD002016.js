//form
var FormCodeHdr = 'AAD002000'
var FormCodeDtl = 'AAD002016'
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
            url: "Assets/Handler/AAD/AAD002016HND.ashx",
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
var originalTbodyClone = originalTbodyClone || null;
function formatDateToMMDDYYYY(val) {
    if (!val && val !== 0) return "";
    val = String(val).trim();
    if (/^\d{2}\/\d{2}\/\d{4}$/.test(val)) return val;        // mm/dd/yyyy
    if (/^\d{4}-\d{2}-\d{2}$/.test(val)) {                   // yyyy-mm-dd -> mm/dd/yyyy
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
    // fallback: parse via Date
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

        // Don't re-create inputs if already editable
        if (cell.querySelector("input, select")) {
            return;
        }

        // Save original value once (use value of existing input/select if present)
        if (!cell.hasAttribute("data-original-value")) {
            let existing = cell.querySelector("input, select");
            let orig = existing ? (existing.value || existing.textContent || "").toString().trim() : cell.innerText.trim();
            cell.setAttribute("data-original-value", orig);
        }

        // Preserve existing select (if the cell originally had a select control)
        let existingSelect = cell.querySelector("select");
        let currentValue = existingSelect ? (existingSelect.value || existingSelect.options[existingSelect.selectedIndex]?.text || "") : cell.innerText.trim();

        // Clear and create input/select depending on column
        cell.innerHTML = "";

        if ([4, 5, 7].includes(index)) {
            // date -> flatpickr text input (date format m/d/Y)
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
            // text input
            if (existingSelect) {
                // if original was select --> re-attach it (enable)
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

    // init flatpickr only for new date inputs inside this row
    $(row).find('[data-kt-repeater="datepicker"]').flatpickr({
        dateFormat: "m/d/Y",
        allowInput: true,
        onOpen: function (selectedDates, dateStr, instance) {
            if (!instance.input.value) instance.setDate(new Date());
        }
    });
}
function restoreRowOriginal(row, editableColumns) {
    let cells = row.querySelectorAll("td");
    cells.forEach((cell, index) => {
        if (!editableColumns.includes(index)) return;

        // If we used flatpickr, destroy it
        let input = cell.querySelector("input");
        if (input && input._flatpickr) {
            input._flatpickr.destroy();
        }

        let orig = cell.getAttribute("data-original-value");
        if (orig === null || orig === undefined) {
            // nothing stored -> leave as-is
            return;
        }
        // restore as text content (keeps display consistent with original text)
        cell.textContent = orig;
    });
}
function makeTableEditable() {
    fnAccess(FormCodeDtl, 'Save', function (response) {
        if (response[0].oReturn != "1") {   
            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            return;
        }

        let editableColumns = [3, 4, 5, 6, 7, 8]; // columns that can become editable
        let tbody = document.getElementById("gv01FormBody");
        if (!tbody) return;

        let rows = Array.from(tbody.querySelectorAll("tr"));
        let hasValidRows = false;

        rows.forEach(row => {
            const cells = row.querySelectorAll("td");
            if (cells.length === 1 && (cells[0].classList.contains("dt-empty") || cells[0].colSpan > 1)) return;
            if (cells.length > 0) hasValidRows = true;
        });

        if (!hasValidRows) {
            fnAlertOnly('No row to edit!', 'error', 'btn btn-danger');
            return;
        }

        // keep a clone to allow full cancel/restore if needed
        if (!originalTbodyClone) originalTbodyClone = tbody.cloneNode(true);

        // Store original values for all editable cells once (so we can restore when unchecked)
        rows.forEach(row => {
            let cells = row.querySelectorAll("td");
            cells.forEach((cell, index) => {
                if (!editableColumns.includes(index)) return;
                if (!cell.hasAttribute("data-original-value")) {
                    let existing = cell.querySelector("input, select");
                    let orig = existing ? (existing.value || existing.textContent || "").toString().trim() : cell.innerText.trim();
                    cell.setAttribute("data-original-value", orig);
                }
            });
        });

        // enable checkboxes and attach change handlers
        rows.forEach(row => {
            let cells = row.querySelectorAll("td");
            if (!cells || cells.length === 0) return;

            let cbCell = cells[0];
            let checkbox = cbCell.querySelector("input[type='checkbox']");
            if (!checkbox) return;

            // enable the checkbox (in case it was pointer-events:none or disabled)
            checkbox.style.pointerEvents = "auto";
            checkbox.disabled = false;

            // if it's already checked at the moment user clicked Edit -> make row editable immediately
            if (checkbox.checked) {
                makeRowEditable(row, editableColumns);
            }

            // attach change listener once
            if (!checkbox._rowChangeBound) {
                checkbox.addEventListener("change", function () {
                    if (checkbox.checked) {
                        makeRowEditable(row, editableColumns);
                    } else {
                        restoreRowOriginal(row, editableColumns);
                    }
                });
                checkbox._rowChangeBound = true;
            }
        });

        // toggle buttons
        document.getElementById("editTableBtn").style.display = "none";
        document.getElementById("saveTableBtn").style.display = "inline-flex";
        document.getElementById("cancelTableBtn").style.display = "inline-flex";
    });
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
        if (originalTbodyClone) {
            // 🧨 Destroy DataTable
            if ($.fn.dataTable.isDataTable('#table01Record')) {
                $('#table01Record').DataTable().destroy();
            }

            const tbody = document.getElementById("gv01FormBody");
            const newClone = originalTbodyClone.cloneNode(true);
            tbody.parentNode.replaceChild(newClone, tbody);
            newClone.id = "gv01FormBody";

            $(document).ready(function () {
                // Check if the table has any rows other than the No data available row
                let pID = document.getElementById("hdn02ID").value
                if ($("#tbl02Record tbody tr").length > 0 && $("#tbl02Record tbody tr td[colspan]").length === 0) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/AAD/AAD002016HND.ashx",
                        data: {
                            'pFunction': 'Get-Record-02',
                            'pID': pID,
                        },
                        success: function (response) {
                            console.log(response)
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
                                    { data: 'Code', visible: false }],
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

                } else {
                    // If no rows are present, destroy DataTable instance if already initialized
                    if ($.fn.dataTable.isDataTable('#tbl02Record')) {
                        $('#tbl02Record').DataTable().clear().destroy();
                    }
                }
            });
            // Restore buttons
            document.getElementById("editTableBtn").style.display = "inline-flex";
            document.getElementById("saveTableBtn").style.display = "none";
            document.getElementById("cancelTableBtn").style.display = "none";
        }
    });
}
function confirmSaveTableChanges() {
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
            saveTableChanges(); // ✅ Execute save only if confirmed
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
    let pAcctNo = document.getElementById("hdn02ID").value
    // Loop through all visible rows in the DOM
    $('#tbl02Record tbody tr').each(function () {
        let $row = $(this);
        let dtRow = table.row(this); // DataTables row API
        let rowData = dtRow.data();  // Full row data including hidden POCode

        let code = stripHtml(rowData.Code);

        let isChecked = $row.find('td:eq(0) input[type="checkbox"]').is(':checked') ? 1 : 0;
        // Collect inputs
        let col3 = $row.find('td:eq(3) input').val()?.trim() || ""; 
        let col4 = $row.find('td:eq(4) input').val()?.trim() || "";  
        let col5 = $row.find('td:eq(5) input').val()?.trim() || "";  
        let col6 = $row.find('td:eq(6) input').val()?.trim() || "";   
        let col7 = $row.find('td:eq(7) input').val()?.trim() || "";  
        let col8 = $row.find('td:eq(8) input').val()?.trim() || ""; 

        // Convert date values from yyyy-mm-dd back to mm/dd/yyyy for saving/display
        function formatDate(value) {
            if (value && value.includes("-")) { // yyyy-mm-dd
                let [yyyy, mm, dd] = value.split("-");
                return `${mm}/${dd}/${yyyy}`;
            }
            return value;
        }

        DocumentList.push({
            code: code,
            checked: isChecked,
            col3: col3,
            col4: formatDate(col4),
            col5: formatDate(col5),
            col6: col6,
            col7: formatDate(col7),
            col8: col8
        });
    });
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002016HND.ashx",
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
        $(document).ready(function () {
            // Check if the table has any rows other than the No data available row
            let pID = document.getElementById("hdn02ID").value
            if ($("#tbl02Record tbody tr").length > 0 && $("#tbl02Record tbody tr td[colspan]").length === 0) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/AAD/AAD002016HND.ashx",
                    data: {
                        'pFunction': 'Get-Record-02',
                        'pID': pID,
                    },
                    success: function (response) {
                        console.log(response)
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
                                { data: 'Code', visible: false }],
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

            } else {
                // If no rows are present, destroy DataTable instance if already initialized
                if ($.fn.dataTable.isDataTable('#tbl02Record')) {
                    $('#tbl02Record').DataTable().clear().destroy();
                }
            }
        });

        document.getElementById("editTableBtn").style.display = "inline-flex";
        document.getElementById("saveTableBtn").style.display = "none";
        document.getElementById("cancelTableBtn").style.display = "none";

        let tbody = document.getElementById("gv01FormBody");

        // 🧠 Re-store clone after save, since data has changed
        originalTbodyClone = tbody.cloneNode(true);
    }
}
//edit
//record
