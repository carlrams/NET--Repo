
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        fn01Load();
    });
};

//load
function fn01Load() {
    var table01Record = new Tabulator("#table01Record", {
        layout: "fitColumns",
        groupBy: function (data) {
            return `${data.ID} - ${data.Item}`;
        },
        columns: [
            { title: "ID", field: "ID", width: 200, tooltip: true },
            { title: "Category", field: "Category", width: 230, tooltip: true },
            { title: "Estimate", field: "Estimate", width: 300, tooltip: true },
            { title: "Est. No.", field: "EstNo", width: 180, tooltip: true },
            { title: "Project", field: "Project", width: 180, tooltip: true },
            { title: "Item", field: "Item", width: 300, tooltip: true },
            { title: "Unit", field: "Unit", width: 100, tooltip: true },
            {
                title: "Qty",
                field: "Qty",
                width: 150,
                frozen: true,
                hozAlign: "right",
                formatter: "money",
                formatterParams: { decimal: ".", thousand: ",", precision: 2 },
                cellClick: function (e, cell) {
                    const rowData = cell.getRow().getData();
                    const maxQty = parseFloat(rowData.QtyOrig) || 0;
                    const currentValue = cell.getValue();

                    const cellEl = cell.getElement();
                    cellEl.innerHTML = ""; // clear formatted display temporarily

                    const input = document.createElement("input");
                    input.type = "number";
                    input.value = currentValue;
                    input.style.width = "100%";
                    cellEl.appendChild(input);
                    input.focus();
                    input.select();

                    function commitEdit() {
                        const newValue = parseFloat(input.value) || 0;

                        if (newValue > maxQty) {
                            cell.setValue(currentValue);
                            return;
                        }

                        if (newValue === currentValue) {
                            cell.setValue(currentValue); // no change, just re-render
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
                        }).then((res) => {
                            if (res.isConfirmed) {
                                cell.setValue(newValue); // commits + re-renders with money formatter
                                //fnSaveQty(cell, newValue);
                                console.log(newValue);
                            } else {
                                cell.setValue(currentValue); // reverted
                            }
                        });
                    }

                    input.addEventListener("keydown", function (ev) {
                        if (ev.key === "Enter") {
                            ev.preventDefault();
                            ev.stopPropagation(); // 
                            commitEdit();
                        } else if (ev.key === "Escape") {
                            cell.setValue(currentValue); // cancel, revert
                        }
                    });

                    input.addEventListener("blur", function () {
                        // optional: treat blur as cancel, or call commitEdit() if you want blur to also save
                        cell.setValue(currentValue);
                    });
                },
            },
        ]
    });
    $.ajax({
        type: "POST",
        url: "Assets/Handler/ACC/ACC030200HND.ashx",
        data: {
            'pFormCode': 'ACC030200',
            'pType': 'Get - PR - (House Construction)'
        },
        success: function (response) {
            response.forEach(row => {
                row.QtyOrig = row.Qty;
            });
            table01Record.setData(response);
        },
        error: function (xhr, status, err) {
            console.error("Load Failed");
        }
    });
};
//load