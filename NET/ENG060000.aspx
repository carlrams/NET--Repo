<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ENG060000.aspx.vb" Inherits="NET.ENG060000" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!--content-->
    <div class="content flex-row-fluid" id="kt_content">
        <div>
            <style>
                .custom-file-input {
                    width: 1300px;
                    padding: 2px;
                    height: 33px;
                    border: 1px solid #ccc;
                    border-radius: 8px;
                    font-family: Arial, sans-serif;
                    font-size: 14px;
                    background-color: #f8f9fa;
                    cursor: pointer;
                    transition: all 0.3s ease;
                }

                .custom-file-input:hover {
                    border-color: #004d25;
                    background-color: lightgray;
                }
            </style>
        </div>
		<!--begin::breadcrumb bar-->
		<div class="toolbar py-5">
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">ENG</li>
						<li class="breadcrumb-item text-white">-</li>
						<li class="breadcrumb-item text-white">Data Entry</li>
						<li class="breadcrumb-item text-white">-</li>
						<li class="breadcrumb-item text-white">Upload POC</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
				<!--end::Actions-->
			</div>
			<!--begin::Container-->
		</div>
		<!--end::breadcrumb bar-->
		
		<!--begin::Card-->
        <div id="card01Content" class="card mb-5">
			<!--begin::Beader-->
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/ENG060000_UploadPOC.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Upload POC</span>
						</h3>
					</div>
					<!--end::Title-->
				</div>
                
			    <div class="card-toolbar">
                    <div class="d-flex flex-wrap align-items-center gap-2">
                        <!--begin::Search-->
                        <div class="position-relative">
                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
                                        transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                    <path
                                        d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
                                        fill="currentColor" />
                                </svg>
                            </span>
                            <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search"
                                class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10"
                                placeholder="Search" />
                        </div>
                        <!--end::Search-->

                        <!-- Hidden export placeholder -->
    

                        <!-- Action Buttons -->
                        <div class="d-flex gap-2">
                            <button id="SaveButton" type="button"
                                class="btn btn-sm btn-icon btn-success"
                                style="width: 32px; height: 32px;" title="Save" onclick="fn01Save(); return false;">
                                <i class="las la-save fs-3"></i>
                            </button>
                        </div>

                        <!-- Options dropdown -->
                 
                    </div>

			    </div>
            </div>
		    <!--end::Header-->
			<!--begin::Card body-->
        
			<div class="card-body pt-0 mt-0">
                 <div class="row gx-2 gy-2">
                    <div class="row gx-2 gy-2 mb-2">
                        <div class="col-md-12">
                            <div class="input-group input-group-sm mb-2 w-100">
                                <button class="btn btn-secondary btn-sm w-150px" type="button" onclick="document.getElementById('excelFileInput').click();">
                                    Choose file
                                </button>
                                <input type="file" id="excelFileInput" accept=".xlsx" class="form-control d-none" />
                                <input type="text" id="ExcelTextBoxX" readonly class="form-control form-control-sm" placeholder="No file chosen..." />
                            </div>
                        </div>
                    </div>
                </div>
				<!--begin::Files-->
                <div class="table-loading" style="min-height:62.3vh;">
                    <div id="div01Loader" class="table-loading-message">
                        Loading...
                    </div>
                    <table id="table01Table" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					    <thead>
						    <tr class="fw-bold fs-7 text-gray-800">
                                <th class="min-w-150px fw-bold border-end">WO#</th>
                                <th class="min-w-75px fw-bold border-end">Subd</th>
                                <th class="min-w-75px fw-bold border-end">Phase</th>
                                <th class="min-w-75px text-start fw-bold border-end">Block</th>
                                <th class="min-w-75px fw-bold border-end">Lot</th>
                                <th class="min-w-75px text-start fw-bold border-end">%</th>
                                <th class="min-w-100px fw-bold border-end">Date</th>
                                <th class="min-w-200px fw-bold border-end">Status</th>
						    </tr>
					    </thead>
					    <tbody>
					    </tbody>
				    </table>
				    <!--end::Files-->
                </div>
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->



         



    </div>

    <!--content-->
	<!-- scripts related to this page -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <script type="text/javascript">


        //general
        //fnLoad
        function fn01Load() {
            fnAccess('ENG060000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Load();
                } else {
                    location.replace("MNU000022");
                };
            });
            function Load() {
                document.getElementById("excelFileInput").value = "";
                document.getElementById("ExcelTextBoxX").value = "";
                $('#table01Table').DataTable().clear().draw();
                //display loader
                document.getElementById("div01Loader").style.display = "none";
                //display loader
                initDataTable();
            }
        };
      
        //fnLoad


        //Upload ExcelFile
        document.getElementById("excelFileInput").addEventListener("change", function (e) {
            const file = e.target.files[0];
            if (!file) return;

            document.getElementById("ExcelTextBoxX").value = file.name;

            const reader = new FileReader();
            reader.onload = function (e) {
                try {
                    const data = new Uint8Array(e.target.result);
                    const workbook = XLSX.read(data, { type: "array" });
                    const worksheet = workbook.Sheets[workbook.SheetNames[0]];

                    // ✅ Expected headers
                    const expectedHeaders = ["WO#", "Subd.", "Phase", "Block", "Lot", "%", "Date"];
                    const actualHeaders = [
                        worksheet["A1"]?.v?.toString().trim() || "",
                        worksheet["B1"]?.v?.toString().trim() || "",
                        worksheet["C1"]?.v?.toString().trim() || "",
                        worksheet["D1"]?.v?.toString().trim() || "",
                        worksheet["E1"]?.v?.toString().trim() || "",
                        worksheet["F1"]?.v?.toString().trim() || "",
                        worksheet["G1"]?.v?.toString().trim() || ""
                    ];

                    for (let i = 0; i < expectedHeaders.length; i++) {
                        if (actualHeaders[i].toLowerCase() !== expectedHeaders[i].toLowerCase()) {
                            fnAlertOnly("Invalid file format!", "error", "btn btn-danger");
                            document.getElementById("excelFileInput").value = "";
                            document.getElementById("ExcelTextBoxX").value = "";
                            return;
                        }
                    }

                    const tableData = [];
                    let rowIndex = 2;

                    while (rowIndex < 1000) {
                        const WO = worksheet["A" + rowIndex]?.v || "";
                        const Subd = worksheet["B" + rowIndex]?.v || "";
                        const Phase = worksheet["C" + rowIndex]?.v || "";
                        const Block = worksheet["D" + rowIndex]?.v || "";
                        const Lot = worksheet["E" + rowIndex]?.v || "";
                        const Percentage = worksheet["F" + rowIndex]?.v || "";
                        const DateCell = worksheet["G" + rowIndex];

                        let DateValue = "";
                        if (DateCell) {
                            if (DateCell.t === "n") {
                                DateValue = excelDateToJSDate(DateCell.v).toISOString().split("T")[0];
                            } else {
                                DateValue = DateCell.v;
                            }
                        }

                        // Stop if empty row
                        if (!WO && !Subd && !Phase && !Block && !Lot && !Percentage && !DateValue) break;

                        tableData.push({
                            WO: WO.toString(),
                            Subd: Subd.toString(),
                            Phase: Phase.toString(),
                            Block: Block.toString(),
                            Lot: Lot.toString(),
                            Percentage: Number.isFinite(Number(Percentage))
                                ? Number(Percentage).toFixed(2)
                                : "",
                            Date: DateValue,
                            Status: "" // to be filled by backend
                        });

                        rowIndex++;
                    }

                    if (tableData.length === 0) {
                        fnAlertOnly("No valid rows found in the file.", "warning", "btn btn-warning");
                        document.getElementById("excelFileInput").value = "";
                        document.getElementById("ExcelTextBoxX").value = "";
                        return;
                    }

                    //display loader
                    document.getElementById("div01Loader").style.display = "";

                    // Send to backend
                    $.ajax({
                        type: "POST",
                        url: "HNDENG.ashx",
                        data: {
                            FormCode: "ENG060000",
                            Type: "GetValidation",
                            UploadExcel: JSON.stringify(tableData)
                        },
                        success: function (response) {
                            try {
                                if (!response || response.length === 0) {
                                    fnAlertOnly("No record found.", "warning", "btn btn-warning");
                                    document.getElementById("excelFileInput").value = "";
                                    document.getElementById("ExcelTextBoxX").value = "";
                                    $("#table01Table").DataTable().clear().draw();
                                    return;
                                }
                                initDataTable(response);
                            } catch (err) {
                                fnAlertOnly("Invalid response from server.", "warning", "btn btn-warning");
                            }
                        },
                        error: function () {
                            alert("Error occurred while fetching data.");
                        }
                    });

                } catch (err) {
                    fnAlertOnly("Error: " + err.message, 'error', 'btn btn-danger');
                } 
            };

            reader.readAsArrayBuffer(file);
        });
        function excelDateToJSDate(serial) {
            const utc_days = Math.floor(serial - 25569);
            const utc_value = utc_days * 86400;
            const date_info = new Date(utc_value * 1000);

            return new Date(
                date_info.getFullYear(),
                date_info.getMonth(),
                date_info.getDate()
            );
        }
        let table01Table; 
        function initDataTable(data) {
          table01Table = $('#table01Table').DataTable({
                scrollY: '600px',
                scrollCollapse: true,
                fixedHeader: true,
                bDestroy: true,
                select: false,
                bInfo: false,
                bPaginate: false,
                paging: false,
                data: data,
                columns: [
                    { data: 'WO' },
                    { data: 'Subd' },
                    { data: 'Phase' },
                    { data: 'Block' },
                    { data: 'Lot' },
                    { data: 'Percentage' },
                    { data: 'Date' },
                    { data: 'Status' }
                ],
                columnDefs: [
                    { targets: '_all', className: 'tbody-nowrap-auto text-start'}
                ],
              order: [[0, 'desc']],
                   rowCallback: function (row, data) {
                  if (data.Status && data.Status.toLowerCase() === "valid") {
                      $(row).css("background-color", "#d4edda");  // light green
                  } else if (data.Status && data.Status.toLowerCase() === "invalid") {
                      $(row).css("background-color", "#f8d7da");  // light red
                  }
              }
            });
            // Setup search box
            $('#tbx01Find').on('keyup', function () {
                table01Table.search(this.value).draw();
            });
            document.getElementById("excelFileInput").value = "";
            //display loader
            document.getElementById("div01Loader").style.display = "none";
            //display loader

        }
        //Upload Excel
        // Export buttons binding (runs once only)
        document.querySelectorAll('[data-kt-export]').forEach(exportButton => {
            exportButton.addEventListener('click', e => {
                e.preventDefault();

                // Always get the latest DataTable instance
                const rowCount = table01Table.rows({ filter: 'applied' }).data().length;

                if (rowCount === 0) {
                    fnAlertOnly('No rows found.', 'warning', 'btn btn-danger');
                    return;
                }
                if (rowCount > 5000) {
                    fnAlertOnly('Too many rows.', 'warning', 'btn btn-danger');
                    return;
                }

                const exportValue = e.target.getAttribute('data-kt-export');
                const target = document.querySelector('.dt-buttons .buttons-' + exportValue);
                if (target) target.click();
            });
        });

        function fn01Save() {
            document.getElementById("SaveButton").disabled = true;
   
            var UploadExcel = $('#table01Table').DataTable().rows().data().toArray();
            if (UploadExcel.length == 0) {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                document.getElementById("SaveButton").disabled = false;
                return;
            }
            // ✅ Check if any row has Status = "Invalid"
            var hasInvalid = UploadExcel.some(function (row) {
                return row.Status && row.Status.toString().toLowerCase() === "invalid";
   
            });
            if (hasInvalid) {
                fnAlertOnly('There are invalid rows!', 'error', 'btn btn-danger');
                document.getElementById("SaveButton").disabled = false;
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

                    
                    // Check if any field is empty

                    $.ajax({
                        type: "POST",
                        url: "HNDENG.ashx",
                        data: {
                            FormCode: 'ENG060000',
                            Type: 'SaveUploadPOC',
                            UploadExcel: JSON.stringify(UploadExcel)
                        },

                        success: function (response) {

                            fn01Load();
                            document.getElementById("SaveButton").disabled = false;
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');


                        },
                        error: function (xhr, status, error) {

                            fnAlertOnly('Invalid input', 'error', 'btn btn-danger');
                        }
                    });
                   
                } else if (result.isDismissed) {
                    document.getElementById("SaveButton").disabled = false;
                }
          
            });
          
        }

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
            });
            jQuery(function ($) {
                fn01Load();
            });
        }
        //load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
