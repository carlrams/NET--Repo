<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="PMD060000.aspx.vb" Inherits="NET.PMD060000" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    
    <!--begin::Post-->
    <div class="content flex-row-fluid" id="kt_content">

                <div>
    <style>
        .dtfc-fixed-left {
            z-index: 1 !important; /* Lower the stacking order */
            position: relative; /* Ensures proper stacking */
        } 
        .swal-popup {
            width: 450px !important;
            height: 250px !important; 

            font-family: Arial, sans-serif;
            padding: 0 !important; /* Remove padding */
 
        }

        .swal-html-container {
            width: 100% !important;
            padding: 0px !important;

        }

        .separator {
            width: 100% !important;
            height: 2px;
            display: block;
            margin: 0;
        }


        /* Header styling */
        .swal-header {
            font-size: 20px;
            font-weight: bold;
            color: #333;
            padding-bottom: 35px;
            text-align: start;
        }

        /* Body styling */
        .swal-body {
            font-size: 14px;
            color: #555;
            text-align: center;
            display: flex;
            align-items: center;
            padding: 25px 0px 35px 0px; 
        }

          
        /* Confirm (Ok) button */
        .swal-confirm-btn {
            background-color: #218838 !important; /* Dark Green */
            color: white !important;
            border-radius: 6px;
            padding: 8px 16px; 
            font-size: 14px;
            border: none;
        }

        /* Cancel button */
        .swal-cancel-btn {
            background-color: #f8f9fa !important; 
            color: #6c757d !important; 
            border-radius: 6px;
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            opacity: 0.7; 
        }
.pagination .active > a,
.pagination .active > span {
    background-color: #008c44 !important;
    border-color: #008c44 !important;
    color: white !important;
}




    </style>
</div>
        <!--begin::breadcrumb bar-->
        <asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
            <ContentTemplate>
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
                            <li class="breadcrumb-item text-white opacity-75">Property Management</li>
                            <!--end::Item-->
                            <!--begin::Item-->
                            <li class="breadcrumb-item">
                                <span class="bullet bg-white opacity-75 w-5px h-2px"></span>
                            </li>
                            <!--end::Item-->
                            <!--begin::Item-->
                            <li class="breadcrumb-item text-white opacity-75">Data Entry</li>
                            <li class="breadcrumb-item">
                                <span class="bullet bg-white opacity-75 w-5px h-2px"></span>
                            </li>
                            <!--end::Item-->
                            <!--begin::Item-->
                            <li class="breadcrumb-item text-white opacity-75">RFO Monitoring</li>
                            <!--end::Item-->
                            <asp:Label ID="lblID" runat="server" ClientIDMode="Static" style="display:none">-</asp:Label>
                            <asp:HiddenField ID="lbl01ID" runat="server"/>
                            <asp:HiddenField ID="Empcode" runat="server" ClientIDMode="Static" />
                        </ul>
                        <!--end::Breadcrumb-->
                    </div>
                    <!--end::Page title-->
                </div>
                <!--begin::Container-->
            </ContentTemplate>
        </asp:UpdatePanel>

        <!--end::title-->
        <!--end::Card header-->
        <!--begin::Card body-->
        <div id="card01Form" class="card mb-5">
            <!--begin::Card body-->
            <div class="card-header border-0">
                <div class="d-flex align-items-center">
                    <!--begin::Icon-->
                    <div class="symbol symbol-35px me-2">
                        <img src="Assets/media/svg/apps/survey.svg" alt="" />
                    </div>
                    <!--end::Icon-->
                    <!--begin::Title-->
                    <div class="d-flex flex-column">
                        <h3 class="card-title align-items-start flex-column">
                            <span class="card-label fw-bolder text-dark">RFO Monitoring</span>
                        </h3>
                    </div>
                    <!--end::Title-->
                </div>
                <div class="card-toolbar">
                    <div class="d-flex flex-stack">
                        <!--begin::Search-->
                        <div class="position-relative me-2">
                            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                </svg>
                            </span>
                            <!--end::Svg Icon-->
                            <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
                        </div>
                        <!--end::Search-->
                        <!--begin::Export buttons-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <!--end::Export buttons-->
                        <!--Filter-->
                        <!--Filter-->
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                            <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                            <i class="las la-bars fs-3"></i>
                            <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="btn01Filter()">Filter</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="csv">Export as CSV</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="pdf">Export as PDF</a>
                            </div>
                        </div>
                        <!--end::Menu-->
                    </div>
                </div>
            </div>
            <div class="card-header">
                <div class="d-flex table-responsive pt-0 mt-0">
                    <asp:LinkButton ID="lbtn01Refresh" runat="server" ToolTip="Refresh record" class="btn btn-sm btn-icon btn-info align-self-center m-1" OnClientClick=""><i class="las la-redo-alt fs-2"></i></asp:LinkButton>
                    <button type="button" runat="server" id="editTableBtn" class="btn btn-sm btn-icon btn-warning align-self-center m-1"
                        style="width: 35px; height: 35px; display: inline-flex; align-items: center; justify-content: center;"
                        onclick="makeTableEditable();">
                        <i class="las la-pencil-alt fs-2"></i>
                    </button>
                    <button type="button" runat="server" id="cancelTableBtn" class="btn btn-sm btn-icon btn-danger align-self-center m-1"
                        style="width: 35px; height: 35px; display: none; align-items: center; justify-content: center;"
                        onclick="CancelTableChanges();">
                        <i class="las la-trash fs-2"></i>
                    </button>
                    <button type="button" runat="server" id="saveTableBtn" class="btn btn-sm btn-icon btn-warning align-self-center m-1"
                        style="width: 35px; height: 35px; display: none; align-items: center; justify-content: center;"
                        onclick="saveTableChanges();">
                        <i class="las la-save fs-2"></i>
                    </button>
                </div>
            </div> 

            <div class="card-body pt-0 mt-0">
                <!--begin::Files-->
                <div class="table-responsive border rounded h-100">
                    <table id="gv01Form" class="table table-row-bordered gy-2 gs-2 w-100 h-100">
                        <thead>
                            <tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
                                <th class="fw-bold border-end">Code</th>
                                <th class="fw-bold border-end">Subd</th>
                                <th class="fw-bold border-end">Phase</th>
                                <th class="fw-bold border-end">Block</th>
                                <th class="fw-bold border-end">Lot</th>
                                <th class="fw-bold border-end">Area</th>
                                <th class="fw-bold border-end">Status</th>
                                <th class="fw-bold border-end">DOE</th>
                                <th class="fw-bold border-end">Model House</th>
                                <th class="fw-bold border-end">Batch No.</th>
                                <th class="fw-bold border-end">Com. Date</th>
                                <th class="fw-bold border-end">TO to PMD</th>
                                <th class="fw-bold border-end">TO Date</th>
                                <th class="fw-bold border-end">Owner</th>
                                <th class="fw-bold border-end">Keys</th>
                                <th class="fw-bold border-end">PMD Status</th>
                            </tr>
                            <tr id="tr01Filter" class="fw-bold fs-7 text-gray-800" style="display: none;">
                                <td class="border-end">
                                    <input id="tbx01Find00" type="text" class="border-0 p-0 min-w-10px w-8 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find01" type="text" class="border-0 p-0 min-w-10px w-2 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find02" type="text" class="border-0 p-0 min-w-10px w-2 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find03" type="text" class="border-0 p-0 min-w-10px w-2 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find04" type="text" class="border-0 p-0 min-w-10px w-2 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find05" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find06" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find07" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find08" type="text" class="border-0 p-0 min-w-10px w-10 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find09" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find10" type="text" class="border-0 p-0 min-w-10px w-9 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find11" type="text" class="border-0 p-0 min-w-10px w-9 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find12" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find13" type="text" class="border-0 p-0 min-w-10px w-14 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find14" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                <td class="border-end">
                                    <input id="tbx01Find15" type="text" class="border-0 p-0 min-w-10px w-6 mw-50px" style="outline: none" value="" /></td>
                                </tr>
                        </thead>
                        <tbody>
                            <%For Each dr As Data.DataRow In Me.FormDataSet.Tables(0).Rows%>
                            <tr>
                                <%For Each dc As Data.DataColumn In Me.FormDataSet.Tables(0).Columns%>
                                <td>
                                    <%=dr(dc.ColumnName)%>
                                </td>
                                <% Next%>
                            </tr>
                            <% Next%>
                        </tbody>
                    </table>
                </div>
                <!--end::Files-->
            </div>
            <!--end::Card body-->
        </div>

    </div>
           
<!--end::Card
		<!--begin::content-->


		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfFormCode" runat="server" />
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
		<!--begin::hidden variable-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">
        function makeTableEditable() {
            let table = document.getElementById("gv01Form");
            let rows = table.querySelectorAll("tbody tr");

            rows.forEach(row => {
                let cells = row.querySelectorAll("td");

                cells.forEach((cell, index) => {
                    if ([11, 12, 14, 15].includes(index)) {
                        if (!cell.querySelector("input")) {
                            let text = cell.innerText.trim();

                            if (!cell.hasAttribute("data-original-value")) {
                                cell.setAttribute("data-original-value", text);
                            }

                            let input = document.createElement("input");

                            if (index === 11 || index === 12) {
                                input.type = "text";
                                input.dataset.ktRepeater = "datepicker";
                                input.style.width = "80px";
                                input.style.height = "18px";
                                input.style.padding = 0;
                                input.style.margin = 0;

                                let formattedDate = formatDateToMMDDYYYY(text);
                                input.value = formattedDate;
                            } else if (index === 14) {
                                input.type = "text";
                                input.value = text;
                                input.style.textAlign = "left";
                                input.style.width = "50px";
                                input.style.height = "18px";
                                input.style.padding = 0;
                                input.style.margin = 0;
                            } else if (index === 15) {
                                input.type = "text";
                                input.value = text;
                                input.style.textAlign = "left";
                                input.style.width = "65px";
                                input.style.height = "18px";
                                input.style.padding = 0;
                                input.style.margin = 0;
                            }

                            input.className = "table-input";

                            cell.innerHTML = "";
                            cell.appendChild(input);
                        }
                    }
                });
            });

            // ✅ Store multiple editable pages
            let tableInstance = $('#gv01Form').DataTable();
            let currentPage = tableInstance.page.info().page;

            let storedPages = JSON.parse(localStorage.getItem('editablePages')) || []; // Get stored pages array

            if (!storedPages.includes(currentPage)) {
                storedPages.push(currentPage); // Add new page only if not already stored
            }

            localStorage.setItem('editablePages', JSON.stringify(storedPages)); // Save updated pages array

            // Toggle buttons
            document.getElementById("<%= editTableBtn.ClientID %>").style.display = "none";
            document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "inline-flex";
            document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "inline-flex";

            // ✅ Initialize Flatpickr on inputs with [data-kt-repeater="datepicker"]
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y",
                allowInput: true,
                onOpen: function (selectedDates, dateStr, instance) {
                    if (!instance.input.value) {
                        instance.setDate(new Date());
                    }
                }
            });

            // ✅ Initialize Metronic menu if available
            if (typeof KTMenu !== "undefined") {
                KTMenu.createInstances();
            }
        }



        function formatDateToMMDDYYYY(dateStr) {
            if (!dateStr) return ""; // Return empty if no value

            // Check if date is already in MM/DD/YYYY format
            let mmddyyyyPattern = /^\d{2}\/\d{2}\/\d{4}$/;
            if (mmddyyyyPattern.test(dateStr)) {
                return dateStr; // ✅ Already correct, return as-is
            }

            // Check if date is in YYYY-MM-DD format (common for database storage)
            let yyyymmddPattern = /^\d{4}-\d{2}-\d{2}$/;
            if (yyyymmddPattern.test(dateStr)) {
                let [year, month, day] = dateStr.split("-");
                return `${month}/${day}/${year}`; // ✅ Convert to MM/DD/YYYY
            }

            // Check if date is in DD/MM/YYYY format and convert it
            let ddmmyyyyPattern = /^\d{2}\/\d{2}\/\d{4}$/;
            if (ddmmyyyyPattern.test(dateStr)) {
                let [day, month, year] = dateStr.split("/");
                return `${month}/${day}/${year}`; // ✅ Convert to MM/DD/YYYY
            }

            return dateStr; // If no known format matches, return as is
        }



        function CancelTableChanges() {
            Swal.fire({
                html: `
<div class="swal-header">Message</div>
<div class="separator"></div>
<div class="swal-body">Cancel record?</div>
<div class="separator"></div>
`,
                icon: null,
                showCancelButton: true,
                cancelButtonText: "Cancel",
                confirmButtonText: "Ok",
                buttonsStyling: false,
                reverseButtons: true,
                customClass: {
                    popup: "swal-popup",
                    confirmButton: "swal-confirm-btn",
                    cancelButton: "swal-cancel-btn",
                    htmlContainer: "swal-html-content"
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    let rows = document.querySelectorAll("#gv01Form tbody tr");

                    rows.forEach(row => {
                        let cells = row.querySelectorAll("td");

                        cells.forEach((cell, index) => {
                            let input = cell.querySelector("input");

                            if (input && [11, 12, 14, 15].includes(index)) {
                                // Restore previous value stored in `data-original-value`
                                let originalValue = cell.getAttribute("data-original-value") || "";

                                // ✅ Ensure MM/dd/yyyy format for columns 11 and 12
                                if (index === 11 || index === 12) {
                                    originalValue = formatDateToMMDDYYYY(originalValue);
                                }

                                // Remove input and restore original text
                                cell.innerHTML = originalValue;
                            }
                        });
                    });

                    // ✅ Remove the current page from stored editable pages
                    let table = $('#gv01Form').DataTable();
                    let currentPage = table.page.info().page;
                    let storedPages = JSON.parse(localStorage.getItem('editablePages')) || [];

                    // Remove the current page from the stored pages list
                    storedPages = storedPages.filter(page => page !== currentPage);

                    // Update localStorage
                    localStorage.setItem('editablePages', JSON.stringify(storedPages));

                    // ✅ Restore the table to its original (non-editable) state
                    resetTableState();
                }
            });
        }


        // ✅ Function to Reset the Table State
        function resetTableState() {
            let rows = document.querySelectorAll("#gv01Form tbody tr");

            rows.forEach(row => {
                let cells = row.querySelectorAll("td");

                cells.forEach((cell, index) => {
                    let input = cell.querySelector("input");

                    if (input && [11, 12, 14, 15].includes(index)) {
                        let originalValue = cell.getAttribute("data-original-value") || "";
                        if (index === 11 || index === 12) {
                            originalValue = formatDateToMMDDYYYY(originalValue);
                        }
                        cell.innerHTML = originalValue; // Remove input field
                    }
                });
            });
            // ✅ Toggle buttons after canceling edit mode
            document.getElementById("<%= editTableBtn.ClientID %>").style.display = "inline-flex";
    document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "none";
    document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "none";
}


        function saveTableChanges() {
            Swal.fire({
                html: `
<div class="swal-header">Message</div>
<div class="separator"></div>
<div class="swal-body">Save record?</div>
<div class="separator"></div>
`,
                icon: null,
                showCancelButton: true,
                cancelButtonText: "Cancel",
                confirmButtonText: "Ok",
                buttonsStyling: false,
                reverseButtons: true,
                customClass: {
                    popup: "swal-popup",
                    confirmButton: "swal-confirm-btn",
                    cancelButton: "swal-cancel-btn",
                    htmlContainer: "swal-html-content"
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    let table = document.getElementById("gv01Form");
                    let rows = table.querySelectorAll("tbody tr");
                    let updatedData = [];

                    rows.forEach(row => {
                        let lotCode = row.getAttribute("data-id") || row.cells[0]?.innerText.trim();

                        let getValue = (cellIndex) => {
                            let cell = row.cells[cellIndex];
                            let input = cell?.querySelector("input");
                            let rawValue = input ? input.value.trim() : cell.innerText.trim();
                            return rawValue || "";
                        };

                        let TOtoPMD = getValue(11);
                        let TurnOverDate = getValue(12);
                        let Keys = getValue(14);
                        let PMDStatus = getValue(15);

                        if (lotCode !== "N/A") {
                            updatedData.push({
                                LotCode: lotCode,
                                TOtoPMD: TOtoPMD,
                                TurnOverDate: TurnOverDate,
                                Keys: Keys,
                                PMDStatus: PMDStatus
                            });
                        }
                    });

                    if (updatedData.length === 0) {
                        Swal.fire("No changes detected!", "Please modify some values before saving.", "info");
                        return;
                    }

                    $.ajax({
                        type: "POST",
                        url: "PMD060000.aspx/UpdateRFOMonitor",
                        data: JSON.stringify({ updatedData: updatedData }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            let data = response.d;
                            Swal.fire({
                                text: "Record saved successfully!",
                                icon: data.status === "success" ? "success" : "error",
                                buttonsStyling: false,
                                confirmButtonText: "Ok, got it!",
                                customClass: {
                                    confirmButton: data.status === "success" ? "btn btn-primary" : "btn btn-danger"
                                }
                            });

                            rows.forEach(row => {
                                [11, 12, 14, 15].forEach(index => {
                                    let cell = row.cells[index];
                                    let input = cell?.querySelector("input");
                                    if (input) {
                                        cell.innerHTML = input.value;
                                    }
                                });
                            });

                            // ✅ Get current page from DataTable
                            let page = $('#gv01Form').DataTable().page.info().page;

                            // ✅ Retrieve stored pages and remove only the current one
                            let storedPages = JSON.parse(localStorage.getItem('editablePages')) || [];
                            storedPages = storedPages.filter(p => p !== page);
                            localStorage.setItem('editablePages', JSON.stringify(storedPages));

                            // Toggle buttons
                            document.getElementById("<%= editTableBtn.ClientID %>").style.display = "inline-flex";
                    document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "none";
                    document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "none";
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", xhr.responseText);
                    Swal.fire({
                        text: "An error occurred: " + xhr.responseText,
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: { confirmButton: "btn btn-danger" }
                    });
                }
            });
        }
    });
        }





        function btn01Filter() {
            var tr01Header = document.getElementById("tr01Header");
            var tr01Filter = document.getElementById("tr01Filter");

            if (window.getComputedStyle(tr01Filter).display === "none") {


                tr01Header.style.display = "none";
                tr01Filter.style.display = "table-row";
            } else {
                tr01Header.style.display = "table-row";
                tr01Filter.style.display = "none";
            }

        }

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                var isPostBack = <%= IsPostBack.ToString().ToLower() %>; if (!isPostBack) {
                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var gv01Form = $("#gv01Form").DataTable({
                        order: [],
                        scrollX: true, 
                        scrollY: "515px",
                        scrollCollapse: true,
                        bPaginate: true,
                        bDestroy: true,
                        bInfo: true,
                        paging: true,
                        select: false,
                        fixedColumns: {
                            left: 5
                        },
                        "pageLength": 15,
                        "lengthMenu": [[15, 50, 75, 100], [15, 50, 75, 100]],
                        columnDefs: [
                            { width: '8%', targets: 0 },
                            { width: '2%', targets: 1 },
                            { width: '2%', targets: 2 },
                            { width: '2%', targets: 3 },
                            { width: '2%', targets: 4 },
                            { width: '6%', targets: 5 },
                            { width: '6%', targets: 6 },
                            { width: '6%', targets: 7 },
                            { width: '10%', targets: 8 },
                            { width: '6%', targets: 9 },
                            { width: '9%', targets: 10 },
                            { width: '9%', targets: 11 },
                            { width: '6%', targets: 12 },
                            { width: '14%', targets: 13 },
                            { width: '6%', targets: 14 },
                            { width: '6%', targets: 15 }
                        ],
                        autoWidth: false,
                        orderCellsTop: true,

                    });
                    //datatable
                    $('[data-kt-repeater="datepicker"]').flatpickr({
                        dateFormat: "m/d/Y"
                    });

                    var previousPage = 0; // Store previous page index

                    gv01Form.on('page.dt', function () {
                        let table = gv01Form;
                        let currentPage = table.page.info().page;
                        let storedPages = JSON.parse(localStorage.getItem('editablePages')) || []; // Get stored pages

                        if (storedPages.length > 0) {
                            if (storedPages.includes(currentPage)) {

                                // Run this when the user returns to an editable page
                                document.getElementById("<%= editTableBtn.ClientID %>").style.display = "none";
                                document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "inline-flex";
                                document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "inline-flex";
                            } else {

                            // Run this when the user leaves any editable page
                            document.getElementById("<%= editTableBtn.ClientID %>").style.display = "inline-flex";
                            document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "none";
                             document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "none";
                             }
                        }
                    });







                    //search
                    $('#tbx01Find').on('keyup', function () {
                        gv01Form.search(this.value).draw();
                    });
                    //search

                    //filter
                    $('#tbx01Find00').on('keyup', function () {
                        gv01Form.columns(0).search(this.value).draw();
                    });
                    $('#tbx01Find01').on('keyup', function () {
                        gv01Form.columns(1).search(this.value).draw();
                    });
                    $('#tbx01Find02').on('keyup', function () {
                        gv01Form.columns(2).search(this.value).draw();
                    });
                    $('#tbx01Find03').on('keyup', function () {
                        gv01Form.columns(3).search(this.value).draw();
                    });
                    $('#tbx01Find04').on('keyup', function () {
                        gv01Form.columns(4).search(this.value).draw();
                    });
                    $('#tbx01Find05').on('keyup', function () {
                        gv01Form.columns(5).search(this.value).draw();
                    });
                    $('#tbx01Find06').on('keyup', function () {
                        gv01Form.columns(6).search(this.value).draw();
                    });
                    $('#tbx01Find07').on('keyup', function () {
                        gv01Form.columns(7).search(this.value).draw();
                    });
                    $('#tbx01Find08').on('keyup', function () {
                        gv01Form.columns(8).search(this.value).draw();
                    });
                    $('#tbx01Find09').on('keyup', function () {
                        gv01Form.columns(9).search(this.value).draw();
                    });
                    $('#tbx01Find10').on('keyup', function () {
                        gv01Form.columns(10).search(this.value).draw();
                    });
                    $('#tbx01Find11').on('keyup', function () {
                        gv01Form.columns(11).search(this.value).draw();
                    });
                    $('#tbx01Find12').on('keyup', function () {
                        gv01Form.columns(12).search(this.value).draw();
                    });
                    $('#tbx01Find13').on('keyup', function () {
                        gv01Form.columns(13).search(this.value).draw();
                    });
                    $('#tbx01Find14').on('keyup', function () {
                        gv01Form.columns(14).search(this.value).draw();
                    });
                    $('#tbx01Find15').on('keyup', function () {
                        gv01Form.columns(15).search(this.value).draw();
                    });
                    //filter

                    //export
                    const documentTitle = 'Assigned Forms';
                    var buttons = new $.fn.dataTable.Buttons(gv01Form, {
                        buttons: [
                            {
                                extend: 'copyHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'excelHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'csvHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'pdfHtml5',
                                title: documentTitle
                            }
                        ]
                    }).container().appendTo($('#div01ExportButton'));
                    // Hook dropdown menu click event to datatable export buttons
                    const exportButtons = document.querySelectorAll('#div01ExportMenu [data-kt-export]');
                    exportButtons.forEach(exportButton => {
                        exportButton.addEventListener('click', e => {
                            e.preventDefault();

                            // Get clicked export value
                            const exportValue = e.target.getAttribute('data-kt-export');
                            const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                            // Trigger click event on hidden datatable export buttons
                            target.click();
                        });
                    });
                    //export
                }
            });
        }

    </script>
	<!-- scripts related to this page -->

</asp:Content>
