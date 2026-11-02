
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        fn01Load();
        fn02Load();
    });
};

//load

var table01Record;
var table02Record;
function fn01Load() {

    let activeQtyEdit = null;
    function parseQty(value) {

        if (value === null || value === undefined || value === "") {
            return 0;
        }

        return parseFloat(String(value).replace(/,/g, "")) || 0;
    }


    table01Record = new Tabulator("#table01Record", {

        layout: "fitColumns",

        groupBy: function (data) {
            return `${data.ID} - ${data.Item}`;
        },

        columns: [

            {
                title: "ID",
                field: "ID",
                width: 200,
                tooltip: true
            },

            {
                title: "Category",
                field: "Category",
                width: 230,
                tooltip: true
            },

            {
                title: "Estimate",
                field: "Estimate",
                width: 300,
                tooltip: true
            },

            {
                title: "Est. No.",
                field: "EstNo",
                width: 180,
                tooltip: true
            },

            {
                title: "Project",
                field: "Project",
                width: 180,
                tooltip: true
            },

            {
                title: "Item",
                field: "Item",
                width: 300,
                tooltip: true
            },

            {
                title: "Unit",
                field: "Unit",
                width: 100,
                tooltip: true
            },

            {
                title: "EstCode",
                field: "EstCode",
                width: 100,
                tooltip: true,
                visible: false
            },

            {
                title: "EstItemNo",
                field: "EstItemNo",
                width: 100,
                tooltip: true,
                visible: false
            },

            {
                title: "PRCode",
                field: "PRCode",
                width: 100,
                tooltip: true,
                visible: false
            },

            {
                title: "Cost",
                field: "Cost",
                width: 100,
                tooltip: true,
                visible: false
            },
            {
                title: "Qty",
                field: "Qty",
                width: 130,
                frozen: true,
                hozAlign: "right",

                formatter: "money",

                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    precision: 2
                },

                cellClick: function (e, cell) {

                    if (activeQtyEdit && activeQtyEdit.cell !== cell) {

                        const oldEdit = activeQtyEdit;

                        if (oldEdit.input) {
                            oldEdit.input.value = oldEdit.currentValue;
                        }

                        oldEdit.cell.setValue(oldEdit.currentValue);

                        activeQtyEdit = null;
                    }
                    const cellEl = cell.getElement();

                    if (cellEl.querySelector("input")) {
                        return;
                    }
                    const rowData = cell.getRow().getData();

                    if (parseQty(rowData.Release) > 0) {
                        return;
                    }
                    const maxQty = parseQty(rowData.QtyOrig);



                    const currentValue =
                        rowData.Qty !== null &&
                            rowData.Qty !== undefined &&
                            rowData.Qty !== ""
                            ? parseQty(rowData.Qty)
                            : maxQty;

                    cellEl.innerHTML = "";


                    const input = document.createElement("input");

                    input.type = "number";
                    input.step = "0.01";
                    input.min = "0";
                    input.value = currentValue;

                    input.style.width = "100%";
                    input.style.boxSizing = "border-box";


                    cellEl.appendChild(input);

                    activeQtyEdit = {
                        cell: cell,
                        input: input,
                        currentValue: currentValue,
                        maxQty: maxQty
                    };


                    input.focus();
                    input.select();
                    function cancelEdit() {
                        if (
                            activeQtyEdit &&
                            activeQtyEdit.cell === cell
                        ) {

                            cell.setValue(currentValue);

                            activeQtyEdit = null;
                        }
                    }

                    function commitEdit() {
                        if (!activeQtyEdit || activeQtyEdit.cell !== cell) {
                            return;
                        }
                        const newValue = parseQty(input.value);
                        const estCode = rowData.EstCode;
                        const estItemNo = rowData.EstItemNo;
                        const PRCode = rowData.PRCode;
                        if (newValue > maxQty) {
                            Swal.fire({
                                text: `Quantity cannot exceed ${maxQty.toLocaleString(undefined, {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                })}`,
                                icon: "warning"
                            }).then(() => {
                                input.focus();
                                input.select();
                            });
                            return;
                        }
                        if (newValue < 0) {
                            Swal.fire({
                                text: "Quantity cannot be negative.",
                                icon: "warning"
                            }).then(() => {
                                input.focus();
                                input.select();
                            });
                            return;
                        }
                        if (newValue === currentValue) {
                            cell.setValue(currentValue);
                            activeQtyEdit = null;
                            return;
                        }
                        Swal.fire({
                            text: "Save record?", 
                            icon: "question",
                            iconColor: "#0095e8",
                            buttonsStyling: false,
                            showCancelButton: true,
                            confirmButtonText: "Yes",
                            cancelButtonText: "Cancel",
                            focusConfirm: true,
                            customClass: {
                                confirmButton: "btn btn-sm btn-info min-w-100px",
                                cancelButton: "btn btn-sm btn-light-danger min-w-100px"
                            }
                        }).then((res) => {
                            if (res.isConfirmed) {
                                cell.setValue(newValue);
                                fnSaveQty(cell, PRCode, newValue, estCode, estItemNo);
                            } else {
                                cell.setValue(currentValue);
                            }
                            activeQtyEdit = null;
                        });
                    };
                    function fnSaveQty(cell, PRCode, newValue, estCode, estItemNo) {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/ACC/ACC030200HND.ashx",
                            data: {
                                pFunction: "Save-Quantity-01",
                                pPRno: PRCode,
                                pNewValue: newValue,
                                pEstCode: estCode,
                                pEstItemNo: estItemNo
                            },
                            success: function (response) {
                                fn01Load();
                                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            },
                            error: function (xhr, status, err) {
                                console.error("Load Failed:", err);
                                console.error("XHR:", xhr);
                            }
                        });
                    }

                    input.addEventListener("keydown", function (ev) {
                        if (ev.key === "Enter") {

                            ev.preventDefault();
                            ev.stopPropagation();

                            commitEdit();

                            return;
                        }
                        if (ev.key === "Escape") {

                            ev.preventDefault();
                            ev.stopPropagation();

                            cancelEdit();

                            return;
                        }
                    });
                    document.addEventListener("click", function (e) {
                        if (!activeQtyEdit) {
                            return;
                        }

                        const cellEl = activeQtyEdit.cell.getElement();

                        if (!cellEl.contains(e.target)) {
                            activeQtyEdit.cell.setValue(activeQtyEdit.currentValue);
                            activeQtyEdit = null;
                        }
                    });
                }
            },
            {
                title: "Release",
                field: "Release",
                width: 130,
                hozAlign: "right",
                formatter: "money",
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    precision: 2
                }
            },
            {
                title: `<span style="color: #000000 !important; opacity: 1 !important;"><i class="las la-bars fs-2x" style="color: #000000 !important;"></i></span>`,
                field: "ForRelease",
                width: 130,
                hozAlign: "center",
                headerHozAlign: "center",
                download: false,
                headerSort: false,
                headerSortElement: false,
                formatter: function (cell) {    
                    const value = parseFloat(String(cell.getRow().getData().Release || "0").replace(/,/g, "")) || 0;
                    const disabled = value > 0 ? "disabled" : "";
                    const grayscale = value > 0 ? "style='filter: grayscale(100%); opacity: 0.6;'" : "";

                    return `<button type="button" class="btn btn-sm btn-info" ${disabled} ${grayscale}>Release</button>`;
                },
                cellClick: function (e, cell) {
                    const rowData = cell.getRow().getData();
                    const release = parseFloat(String(rowData.Release || "0").replace(/,/g, "")) || 0;

                    if (release > 0) {
                        return;
                    }

                    const Qty = rowData.Qty;
                    const Cost = rowData.Cost;
                    const EstCode = rowData.EstCode;
                    const EstItemNo = rowData.EstItemNo;

                    Swal.fire({
                        text: "Release this record?",
                        icon: "question",
                        iconColor: "#0095e8",
                        buttonsStyling: false,
                        showCancelButton: true,
                        confirmButtonText: "Yes",
                        cancelButtonText: "Cancel",
                        focusConfirm: true,
                        customClass: {
                            confirmButton: "btn btn-sm btn-info min-w-100px",
                            cancelButton: "btn btn-sm btn-light-danger min-w-100px"
                        }
                    }).then((res) => {
                        if (res.isConfirmed) {
                            fnSaveRelease(); 
                        }
                    });
                   function fnSaveRelease() {
                       $.ajax({
                           type: "POST",
                           url: "Assets/Handler/ACC/ACC030200HND.ashx",
                           dataType: "json",
                           data: {
                               pFunction: "Save-Release-01",
                               pQty: Qty,
                               pCost: Cost,
                               pEstCode: EstCode,
                               pEstItemNo: EstItemNo
                           },
                           success: function (response) {
                               fn01Load();
                               fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                           },
                           error: function (xhr, status, err) {
                               console.error("Load Failed:", err);
                               console.error("Response Text:", xhr.responseText);
                               console.error("XHR:", xhr);
                           }
                       });
                    }
                }
            }

        ]

    });


    // Load data
    $.ajax({
        type: "POST",
        url: "Assets/Handler/ACC/ACC030200HND.ashx",
        data: {
            "pFormCode": "ACC030200",
            "pType": "Get - PR - (House Construction)"
        },
        success: function (response) {
            response.forEach(function (row) {
                row.QtyOrig = row.Qty;
            });
            // Load into Tabulator
            table01Record.setData(response);
        },
        error: function (xhr, status, err) {
            console.error("Load Failed:", err);
            console.error("XHR:", xhr);
        }
    });

    $("#tbx01Find").on("keyup", function () {
        table01Record.setFilter(function (data) {
            const search = this.value.toLowerCase();

            return Object.values(data).some(function (value) {
                return String(value ?? "").toLowerCase().includes(search);
            });
        }.bind(this));
    });

}
function fn02Load() {

    let activeQtyEdit = null;
    function parseQty(value) {

        if (value === null || value === undefined || value === "") {
            return 0;
        }

        return parseFloat(String(value).replace(/,/g, "")) || 0;
    }


    table02Record = new Tabulator("#table02Record", {

        layout: "fitColumns",

        //groupBy: function (data) {
        //    return `${data.ID} - ${data.Item}`;
        //},

        columns: [

            {
                title: "ID",
                field: "ID",
                width: 200,
                tooltip: true
            },

            {
                title: "Category",
                field: "Category",
                width: 230,
                tooltip: true
            },

            {
                title: "Estimate",
                field: "Estimate",
                width: 300,
                tooltip: true
            },

            {
                title: "Est. No.",
                field: "EstNo",
                width: 180,
                tooltip: true
            },

            {
                title: "Project",
                field: "Project",
                width: 180,
                tooltip: true
            },

            {
                title: "Item",
                field: "Item",
                width: 300,
                tooltip: true
            },

            {
                title: "Unit",
                field: "Unit",
                width: 100,
                tooltip: true
            },

            {
                title: "EstCode",
                field: "EstCode",
                width: 100,
                tooltip: true,
                visible: false
            },

            {
                title: "EstItemNo",
                field: "EstItemNo",
                width: 100,
                tooltip: true,
                visible: false
            },

            {
                title: "PRCode",
                field: "PRCode",
                width: 100,
                tooltip: true,
                visible: false
            },

            {
                title: "Cost",
                field: "Cost",
                width: 100,
                tooltip: true,
                visible: false
            },
            {
                title: "Qty",
                field: "Qty",
                width: 130,
                frozen: true,
                hozAlign: "right",

                formatter: "money",

                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    precision: 2
                },

                cellClick: function (e, cell) {

                    if (activeQtyEdit && activeQtyEdit.cell !== cell) {

                        const oldEdit = activeQtyEdit;

                        if (oldEdit.input) {
                            oldEdit.input.value = oldEdit.currentValue;
                        }

                        oldEdit.cell.setValue(oldEdit.currentValue);

                        activeQtyEdit = null;
                    }
                    const cellEl = cell.getElement();

                    if (cellEl.querySelector("input")) {
                        return;
                    }
                    const rowData = cell.getRow().getData();

                    if (parseQty(rowData.Release) > 0) {
                        return;
                    }
                    const maxQty = parseQty(rowData.QtyOrig);



                    const currentValue =
                        rowData.Qty !== null &&
                            rowData.Qty !== undefined &&
                            rowData.Qty !== ""
                            ? parseQty(rowData.Qty)
                            : maxQty;

                    cellEl.innerHTML = "";


                    const input = document.createElement("input");

                    input.type = "number";
                    input.step = "0.01";
                    input.min = "0";
                    input.value = currentValue;

                    input.style.width = "100%";
                    input.style.boxSizing = "border-box";


                    cellEl.appendChild(input);

                    activeQtyEdit = {
                        cell: cell,
                        input: input,
                        currentValue: currentValue,
                        maxQty: maxQty
                    };


                    input.focus();
                    input.select();
                    function cancelEdit() {
                        if (
                            activeQtyEdit &&
                            activeQtyEdit.cell === cell
                        ) {

                            cell.setValue(currentValue);

                            activeQtyEdit = null;
                        }
                    }

                    function commitEdit() {
                        if (!activeQtyEdit || activeQtyEdit.cell !== cell) {
                            return;
                        }
                        const newValue = parseQty(input.value);
                        const estCode = rowData.EstCode;
                        const estItemNo = rowData.EstItemNo;
                        const PRCode = rowData.PRCode;
                        if (newValue > maxQty) {
                            Swal.fire({
                                text: `Quantity cannot exceed ${maxQty.toLocaleString(undefined, {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                })}`,
                                icon: "warning"
                            }).then(() => {
                                input.focus();
                                input.select();
                            });
                            return;
                        }
                        if (newValue < 0) {
                            Swal.fire({
                                text: "Quantity cannot be negative.",
                                icon: "warning"
                            }).then(() => {
                                input.focus();
                                input.select();
                            });
                            return;
                        }
                        if (newValue === currentValue) {
                            cell.setValue(currentValue);
                            activeQtyEdit = null;
                            return;
                        }
                        Swal.fire({
                            text: "Save record?", 
                            icon: "question",
                            iconColor: "#0095e8",
                            buttonsStyling: false,
                            showCancelButton: true,
                            confirmButtonText: "Yes",
                            cancelButtonText: "Cancel",
                            focusConfirm: true,
                            customClass: {
                                confirmButton: "btn btn-sm btn-info min-w-100px",
                                cancelButton: "btn btn-sm btn-light-danger min-w-100px"
                            }
                        }).then((res) => {
                            if (res.isConfirmed) {
                                cell.setValue(newValue);
                                fnSaveQty(cell, PRCode, newValue, estCode, estItemNo);
                            } else {
                                cell.setValue(currentValue);
                            }
                            activeQtyEdit = null;
                        });
                    };
                    function fnSaveQty(cell, PRCode, newValue, estCode, estItemNo) {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/ACC/ACC030200HND.ashx",
                            data: {
                                pFunction: "Save-Quantity-02",
                                pPRno: PRCode,
                                pNewValue: newValue,
                                pEstCode: estCode,
                                pEstItemNo: estItemNo
                            },
                            success: function (response) {
                                fn02Load();
                                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            },
                            error: function (xhr, status, err) {
                                console.error("Load Failed:", err);
                                console.error("XHR:", xhr);
                            }
                        });
                    }

                    input.addEventListener("keydown", function (ev) {
                        if (ev.key === "Enter") {

                            ev.preventDefault();
                            ev.stopPropagation();

                            commitEdit();

                            return;
                        }
                        if (ev.key === "Escape") {

                            ev.preventDefault();
                            ev.stopPropagation();

                            cancelEdit();

                            return;
                        }
                    });
                    document.addEventListener("click", function (e) {
                        if (!activeQtyEdit) {
                            return;
                        }

                        const cellEl = activeQtyEdit.cell.getElement();

                        if (!cellEl.contains(e.target)) {
                            activeQtyEdit.cell.setValue(activeQtyEdit.currentValue);
                            activeQtyEdit = null;
                        }
                    });
                }
            },
            {
                title: "Release",
                field: "Release",
                width: 130,
                hozAlign: "right",
                formatter: "money",
                formatterParams: {
                    decimal: ".",
                    thousand: ",",
                    precision: 2
                }
            },
            {
                title: `<span style="color: #000000 !important; opacity: 1 !important;"><i class="las la-bars fs-2x" style="color: #000000 !important;"></i></span>`,
                field: "ForRelease",
                width: 130,
                hozAlign: "center",
                headerHozAlign: "center",
                download: false,
                headerSort: false,
                headerSortElement: false,
                formatter: function (cell) {    
                    const value = parseFloat(String(cell.getRow().getData().Release || "0").replace(/,/g, "")) || 0;
                    const disabled = value > 0 ? "disabled" : "";
                    const grayscale = value > 0 ? "style='filter: grayscale(100%); opacity: 0.6;'" : "";

                    return `<button type="button" class="btn btn-sm btn-info" ${disabled} ${grayscale}>Release</button>`;
                },
                cellClick: function (e, cell) {
                    const rowData = cell.getRow().getData();
                    const release = parseFloat(String(rowData.Release || "0").replace(/,/g, "")) || 0;

                    if (release > 0) {
                        return;
                    }

                    const Qty = rowData.Qty;
                    const Cost = rowData.Cost;
                    const EstCode = rowData.EstCode;
                    const EstItemNo = rowData.EstItemNo;

                    Swal.fire({
                        text: "Release this record?",
                        icon: "question",
                        iconColor: "#0095e8",
                        buttonsStyling: false,
                        showCancelButton: true,
                        confirmButtonText: "Yes",
                        cancelButtonText: "Cancel",
                        focusConfirm: true,
                        customClass: {
                            confirmButton: "btn btn-sm btn-info min-w-100px",
                            cancelButton: "btn btn-sm btn-light-danger min-w-100px"
                        }
                    }).then((res) => {
                        if (res.isConfirmed) {
                            fnSaveRelease(); 
                        }
                    });
                   function fnSaveRelease() {
                       $.ajax({
                           type: "POST",
                           url: "Assets/Handler/ACC/ACC030200HND.ashx",
                           dataType: "json",
                           data: {
                               pFunction: "Save-Release-02",
                               pQty: Qty,
                               pCost: Cost,
                               pEstCode: EstCode,
                               pEstItemNo: EstItemNo
                           },
                           success: function (response) {
                               fn02Load();
                               fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                           },
                           error: function (xhr, status, err) {
                               console.error("Load Failed:", err);
                               console.error("Response Text:", xhr.responseText);
                               console.error("XHR:", xhr);
                           }
                       });
                    }
                }
            }

        ]

    });


    // Load data
    $.ajax({
        type: "POST",
        url: "Assets/Handler/ACC/ACC030200HND.ashx",
        data: {
            "pFormCode": "ACC030200",
            "pType": "Get - PR - (Others)"
        },
        success: function (response) {
            response.forEach(function (row) {
                row.QtyOrig = row.Qty;
            });
            // Load into Tabulator
            table02Record.setData(response);
        },
        error: function (xhr, status, err) {
            console.error("Load Failed:", err);
            console.error("XHR:", xhr);
        }
    });

    $("#tbx02Find").on("keyup", function () {
        table02Record.setFilter(function (data) {
            const search = this.value.toLowerCase();

            return Object.values(data).some(function (value) {
                return String(value ?? "").toLowerCase().includes(search);
            });
        }.bind(this));
    });

}

function exportAllToExcel01() {

    Swal.fire({
        text: "Export record?",
        icon: "question",
        iconColor: "#0095e8",
        buttonsStyling: false,
        showCancelButton: true,
        confirmButtonText: "Yes",
        cancelButtonText: "Cancel",
        focusConfirm: true,
        customClass: {
            confirmButton: "btn btn-sm btn-info min-w-100px",
            cancelButton: "btn btn-sm btn-light-danger min-w-100px"
        }
    }).then((res) => {
        if (res.isConfirmed) {
            table01Record.download("xlsx", "House_Construction.xlsx", {
                sheetName: "House Construction"
            });
        }
    });

}

function exportAllToExcel02() {

    Swal.fire({
        text: "Export record?",
        icon: "question",
        iconColor: "#0095e8",
        buttonsStyling: false,
        showCancelButton: true,
        confirmButtonText: "Yes",
        cancelButtonText: "Cancel",
        focusConfirm: true,
        customClass: {
            confirmButton: "btn btn-sm btn-info min-w-100px",
            cancelButton: "btn btn-sm btn-light-danger min-w-100px"
        }
    }).then((res) => {
        if (res.isConfirmed) {
            table02Record.download("xlsx", "Others.xlsx", {
                sheetName: "Others"
            });
        }
    });

}
//load