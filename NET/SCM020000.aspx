<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM020000.aspx.vb" Inherits="NET.SCM020000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<style type="text/css">
	/* Hide border left */
     div.dataTables_scrollBody {
        border-left: 0px solid #ddd !important
     }
	</style>

    <div class="content flex-row-fluid" id="kt_content">

        <!--begin::breadcrumb bar-->
		<div class="toolbar py-5">
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Account</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Supply Chain Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Contracts Admin</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<!--begin::breadcrumb bar-->
		
		<!--begin::Row-->
		<div class="row gy-5 g-xl-10">
			<div class="col-xl-12">
				<div class="row d-flex justify-content-center g-lg-5 g-xl-10">
					<div class="col-md-4 col-xl-3 mb-md-5 mb-xl-10 pointer" onclick="fn01Verification();">
                        <div class="card overflow-hidden h-md-100 mb-5 mb-xl-10">
							<div class='card-body d-flex justify-content-between flex-column px-0 pb-0'>
								<div class='mb-4 px-9'>
									<div class='d-flex align-items-center mb-2'>
										<span id="spn01VerificationTotal" class='fs-2hx fw-bolder text-gray-800 me-2 lh-1 ls-n2'>0</span>
									</div>
									<span class='fs-6 fw-bold text-gray-400'>For Verification</span>
								</div>
								<div class='card-body d-flex flex-column justify-content-end pe-0'>
									<span class='fs-6 fw-boldest text-gray-800 d-block mb-2'>Verification</span>
									<div id="div01Verification" class='symbol-group symbol-hover flex-nowrap'>
										<div class='symbol symbol-35px symbol-circle' data-bs-toggle='tooltip' title=''>
											<span class='symbol-label bg-gray text-inverse-warning fw-bolder'></span>
										</div>
									</div>
								</div>
							</div>
                        </div>
					</div>
					<div class="col-md-4 col-xl-3 mb-md-5 mb-xl-10 pointer" onclick="fn01Resubmission();">
                        <div class="card overflow-hidden h-md-100 mb-5 mb-xl-10">
							<div class='card-body d-flex justify-content-between flex-column px-0 pb-0'>
								<div class='mb-4 px-9'>
									<div class='d-flex align-items-center mb-2'>
										<span id="spn01ResubmissionTotal" class='fs-2hx fw-bolder text-gray-800 me-2 lh-1 ls-n2'>0</span>
									</div>
									<span class='fs-6 fw-bold text-gray-400'>For Resubmission</span>
								</div>
								<div class='card-body d-flex flex-column justify-content-end pe-0'>
									<span class='fs-6 fw-boldest text-gray-800 d-block mb-2'>Resubmission</span>
									<div id="div01Resubmission" class='symbol-group symbol-hover flex-nowrap'>
										<div class='symbol symbol-35px symbol-circle' data-bs-toggle='tooltip' title=''>
											<span class='symbol-label bg-gray text-inverse-warning fw-bolder'></span>
										</div>
									</div>
								</div>
							</div>
                        </div>
					</div>
					<div class="col-md-4 col-xl-3 mb-md-5 mb-xl-10 pointer" onclick="fn01Approved();">
                        <div class="card overflow-hidden h-md-100 mb-5 mb-xl-10">
							<div class='card-body d-flex justify-content-between flex-column px-0 pb-0'>
								<div class='mb-4 px-9'>
									<div class='d-flex align-items-center mb-2'>
										<span id="spn01ApprovedTotal" class='fs-2hx fw-bolder text-gray-800 me-2 lh-1 ls-n2'>0</span>
									</div>
									<span class='fs-6 fw-bold text-gray-400'>Approved</span>
								</div>
								<div class='card-body d-flex flex-column justify-content-end pe-0'>
									<span class='fs-6 fw-boldest text-gray-800 d-block mb-2'>Approved</span>
									<div id="div01Approved" class='symbol-group symbol-hover flex-nowrap'>
										<div class='symbol symbol-35px symbol-circle' data-bs-toggle='tooltip' title=''>
											<span class='symbol-label bg-gray text-inverse-warning fw-bolder'></span>
										</div>
									</div>
								</div>
							</div>
                        </div>
					</div>
					<div class="col-md-4 col-xl-3 mb-md-5 mb-xl-10 pointer" onclick="fn01Declined();">
                        <div class="card overflow-hidden h-md-100 mb-5 mb-xl-10">
							<div class='card-body d-flex justify-content-between flex-column px-0 pb-0'>
								<div class='mb-4 px-9'>
									<div class='d-flex align-items-center mb-2'>
										<span id="spn01CancelledTotal" class='fs-2hx fw-bolder text-gray-800 me-2 lh-1 ls-n2'>0</span>
									</div>
									<span class='fs-6 fw-bold text-gray-400'>Declined</span>
								</div>
								<div class='card-body d-flex flex-column justify-content-end pe-0'>
									<span class='fs-6 fw-boldest text-gray-800 d-block mb-2'>Declined</span>
									<div id="div01Cancelled" class='symbol-group symbol-hover flex-nowrap'>
										<div class='symbol symbol-35px symbol-circle' data-bs-toggle='tooltip' title=''>
											<span class='symbol-label bg-gray text-inverse-warning fw-bolder'></span>
										</div>
									</div>
								</div>
							</div>
                        </div>
					</div>
				</div>
			</div>
			<!--end::Col-->
		</div>
		<!--end::Row-->
		
		<!--begin::Row-->
		<div class="row gy-5 g-xl-10 mb-10">
			<!--begin::Col-->
			<div class="col">
				<!--begin::Chart widget 10-->
				<div class="card card-flush h-xxl-100">
					<!--begin::Body-->
					<div class="card-body d-flex flex-column justify-content-between pb-5 px-0">
						<!--begin::Chart-->
						<div id="kt_card_accounts" class="min-h-auto" style="height: 350px;"></div>
						<!--end::Chart-->
					</div>
					<!--end: Card Body-->
				</div>
				<!--end::Chart widget 10-->
			</div>
			<!--end::Col-->
		</div>
		<!--end::Row-->
        
		<!--begin::Row-->
		<div class="row h-xxl-50">
			<!--begin::Col-->
			<div class="col">
                <div class="d-flex justify-content-end mb-2">
				    <div class="d-flex align-items-center">
					    <!--begin::Search-->
					    <div class="position-relative">
						    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
						    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
							    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="#42ba96" />
								    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="#42ba96" />
							    </svg>
						    </span>
						    <!--end::Svg Icon-->
                            <input id="tbx02Find" type="text" data-kt-inbox-listing-filter="search" class="form-control border border-success form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="gridApi02.setGridOption('quickFilterText', document.getElementById('tbx02Find').value);" />
					    </div>
					    <!--end::Search-->
				    </div>
                </div>
                <div id="table02Record" style="height: 100vh;"></div>
			</div>
			<!--end::Col-->
		</div>
		<!--end::Row-->

		<!--begin::Modal Status-->
		<div id="mdl01Users" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Users</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Close-->
					</div>
					<div class="modal-body min-h-80px mh-80px overflow-hidden">
						<!--begin::toolbar-->
						<div class="d-flex align-items-center">
							<!--begin::Search-->
							<div class="position-relative">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="gridApi.setGridOption('quickFilterText', document.getElementById('tbx01Find').value);" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
                    <div class="modal-body p-0">
                        <div id="table01Record" style="height: 100vh;"></div>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Status-->

	</div>
	
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
    <script type="text/javascript">

		//variable
        let gridApi;
        let gridApi02;
		//variable

		//general
        function fn01Load() {
            fnAccess('SCM020000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    Header();
                    Body();
                    Footer();
                } else {
                    location.replace("MNU000022");
                };
            });
			function Header() {
				// For Approval
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contracts Admin (For Approval)'
                    },
                    success: function (response) {
                        document.getElementById("spn01ApprovalTotal").innerText = response[0].Total;
                        response.forEach(row => {
                            if (row.Approval != "") {
                                document.getElementById("div01Approval").innerHTML = row.Approval;
                            };
                        });
                    },
				});

				// For Verification
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contracts Admin (For Verification)'
                    },
					success: function (response) {
                        document.getElementById("spn01VerificationTotal").innerText = response[0].Total;
                        response.forEach(row => {
                            if (row.Verification != "") {
                                document.getElementById("div01Verification").innerHTML = row.Verification;
                            };
                        });
                    },
				});

                // For Resubmission
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contracts Admin (For Resubmission)'
                    },
					success: function (response) {
                        document.getElementById("spn01ResubmissionTotal").innerText = response[0].Total;
                        response.forEach(row => {
                            if (row.Resubmission != "") {
                                document.getElementById("div01Resubmission").innerHTML = row.Resubmission;
                            };
                        });
                    },
				});

                // Approved
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contracts Admin (Approved)'
                    },
                    success: function (response) {
                        document.getElementById("spn01ApprovedTotal").innerText = response[0].Total;
                        response.forEach(row => {
                            if (row.Approved != "") {
                                document.getElementById("div01Approved").innerHTML = row.Approved;
                            };
                        });
                    },
                });

                // Cancelled
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contracts Admin (Cancelled)'
                    },
                    success: function (response) {
                        document.getElementById("spn01CancelledTotal").innerText = response[0].Total;
                        response.forEach(row => {
                            if (row.Cancelled != "") {
                                document.getElementById("div01Cancelled").innerHTML = row.Cancelled;
                            };
                        });
                    },
                });
            };
            function Body() {
                // Chart
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contracts Admin (Chart)'
                    },
                    success: function (response) {
                        var options = {
                            series: [{
                                name: 'Users',
                                data: response[0].Users.split(",")
                            }],
                            chart: {
                                height: 350,
                                type: 'bar',
                                events: {
                                    dataPointSelection: function (event, chartContext, config) {
                                        var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                        const abbrMonth = {
                                            Jan: "1", Feb: "2", Mar: "3", Apr: "4", May: "5", Jun: "6",
                                            Jul: "7", Aug: "8", Sep: "9", Oct: "10", Nov: "11", Dec: "12"
                                        };
                                        var Num = abbrMonth[Month];
                                        $.ajax({
                                            type: "POST",
                                            url: "SCM000011.ashx",
                                            data: {
                                                'FormCode': 'SCM020000',
                                                'Type': 'User details (Contrator)',
                                                'Num': Num
                                            },
                                            success: function (response) {
                                                let gridDiv = document.querySelector('#table01Record');
                                                let gridOptions;

                                                // Destroy old grid if exists
                                                gridDiv.innerHTML = "";

                                                gridOptions = {
                                                    suppressCellFocus: true,
                                                    suppressVerticalScroll: true,
                                                    enableCellTextSelection: true,
                                                    rowSelection: 'single',
                                                    //popupParent: document.body,
                                                    loading: false,
                                                    columnDefs: [
                                                        {
                                                            headerName: "Action",
                                                            field: "Action",
                                                            sortable: false,
                                                            resizable: false,
                                                            lockPosition: true,
                                                            width: 75,
                                                            cellRenderer: params => params.value
                                                        },
                                                        {
                                                            headerName: "Code",
                                                            field: "Code",
                                                            lockPosition: true,
                                                            width: 150,
                                                            tooltipField: "Code",
                                                            cellRenderer: params => {
                                                                const Status = params.data.AcctProgress;
                                                                const link = document.createElement('a');
                                                                link.href = "javascript:void(0)";
                                                                link.innerText = params.value;
                                                                if (Status == "For Approval" || Status == "For Verification") {
                                                                    link.onclick = function () {
                                                                        window.open(
                                                                            `SCM020100-DTL-${params.value}`,
                                                                            '_blank'
                                                                        );
                                                                    };
                                                                } else if (Status == "For Resubmission") {
                                                                    link.onclick = function () {
                                                                        window.open(
                                                                            `SCM020200-DTL-${params.value}`,
                                                                            '_blank'
                                                                        );
                                                                    };
                                                                } else if (Status == "Approved") {
                                                                    link.onclick = function () {
                                                                        window.open(
                                                                            `SCM020300-DTL-${params.value}`,
                                                                            '_blank'
                                                                        );
                                                                    };
                                                                } else if (Status == "Declined") {
                                                                    link.onclick = function () {
                                                                        window.open(
                                                                            `SCM020400-DTL-${params.value}`,
                                                                            '_blank'
                                                                        );
                                                                    };
                                                                };
                                                                return link;
                                                            }
                                                        },
                                                        {
                                                            headerName: "Contractor",
                                                            field: "Contractor",
                                                            flex: 1,
                                                            tooltipField: "Contractor"
                                                        },
                                                        {
                                                            headerName: "Email",
                                                            field: "Email",
                                                            tooltipField: "Email",
                                                            width: 350
                                                        },
                                                        {
                                                            headerName: "Address",
                                                            field: "Address",
                                                            tooltipField: "Address",
                                                            width: 320
                                                        },
                                                        {
                                                            headerName: "Status",
                                                            field: "AcctProgress",
                                                            width: 150,
                                                            tooltipField: "AcctProgress"
                                                        },
                                                        {
                                                            headerName: "Date Created",
                                                            field: "CreatedDate",
                                                            width: 150,
                                                            tooltipField: "CreatedDate"
                                                        },
                                                        {
                                                            headerName: "Type",
                                                            field: "Type",
                                                            width: 75,
                                                            tooltipField: "Type"
                                                        }
                                                    ],
                                                    rowData: response,
                                                    pagination: true,
                                                    paginationPageSize: 25
                                                };
                                                gridApi = agGrid.createGrid(gridDiv, gridOptions);

                                                //modal
                                                $("#mdl01Users").modal("show");
                                            },
                                        });
                                    },
                                },
                            },
                            plotOptions: {
                                bar: {
                                    borderRadius: 10,
                                    dataLabels: {
                                        position: 'top', // top, center, bottom
                                    },
                                }
                            },
                            dataLabels: {
                                enabled: true,
                                formatter: function (val) {
                                    return val;
                                },
                                offsetY: -20,
                                style: {
                                    fontSize: '12px',
                                    colors: ["#304758"]
                                }
                            },

                            xaxis: {
                                categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                                position: 'top',
                                axisBorder: {
                                    show: false
                                },
                                axisTicks: {
                                    show: false
                                },
                                crosshairs: {
                                    fill: {
                                        type: 'gradient',
                                        gradient: {
                                            colorFrom: '#D8E3F0',
                                            colorTo: '#BED1E6',
                                            stops: [0, 100],
                                            opacityFrom: 0.4,
                                            opacityTo: 0.5,
                                        }
                                    }
                                },
                                tooltip: {
                                    enabled: true,
                                }
                            },
                            yaxis: {
                                axisBorder: {
                                    show: false
                                },
                                axisTicks: {
                                    show: false,
                                },
                                labels: {
                                    show: false,
                                    formatter: function (val) {
                                        return val;
                                    }
                                }

                            },
                            title: {
                                text: 'Total Users Per Month',
                                floating: true,
                                offsetY: 330,
                                align: 'center',
                                style: {
                                    color: '#444'
                                }
                            }
                        };

                        var chart = new ApexCharts(document.querySelector("#kt_card_accounts"), options);
                        chart.render();
                    },
                });
            };
            function Footer() {
                $.ajax({
                    type: "POST",
                    url: "SCM000011.ashx",
                    data: {
                        'FormCode': 'SCM020000',
                        'Type': 'Get Record - Contractor'
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table02Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            suppressVerticalScroll: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    lockPosition: true,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "Code",
                                    field: "Code",
                                    lockPosition: true,
                                    width: 150,
                                    tooltipField: "Code",
                                    cellRenderer: params => {
                                        const Status = params.data.AcctProgress;
                                        const link = document.createElement('a');
                                        link.href = "javascript:void(0)";
                                        link.innerText = params.value;
                                        if (Status == "For Approval" || Status == "For Verification") {
                                            link.onclick = function () {
                                                window.open(
                                                    `SCM020100-DTL-${params.value}`,
                                                    '_blank'
                                                );
                                            };
                                        } else if (Status == "For Resubmission") {
                                            link.onclick = function () {
                                                window.open(
                                                    `SCM020200-DTL-${params.value}`,
                                                    '_blank'
                                                );
                                            };
                                        } else if (Status == "Approved") {
                                            link.onclick = function () {
                                                window.open(
                                                    `SCM020300-DTL-${params.value}`,
                                                    '_blank'
                                                );
                                            };
                                        } else if (Status == "Declined") {
                                            link.onclick = function () {
                                                window.open(
                                                    `SCM020400-DTL-${params.value}`,
                                                    '_blank'
                                                );
                                            };
                                        };
                                        return link;
                                    }
                                },
                                {
                                    headerName: "Contractor",
                                    field: "Contractor",
                                    flex: 1,
                                    tooltipField: "Contractor"
                                },
                                {
                                    headerName: "Email",
                                    field: "Email",
                                    tooltipField: "Email",
                                    width: 250
                                },
                                {
                                    headerName: "Address",
                                    field: "Address",
                                    tooltipField: "Address",
                                    width: 250
                                },
                                {
                                    headerName: "Status",
                                    field: "AcctProgress",
                                    width: 150,
                                    tooltipField: "AcctProgress"
                                },
                                {
                                    headerName: "Date Created",
                                    field: "CreatedDate",
                                    width: 150,
                                    tooltipField: "CreatedDate"
                                },
                                {
                                    headerName: "Type",
                                    field: "Type",
                                    width: 75,
                                    tooltipField: "Type"
                                }
                            ],
                            rowData: response,
                            pagination: true,
                            paginationPageSize: 25
                        };
                        gridApi02 = agGrid.createGrid(gridDiv, gridOptions);
                    },
                });
            };
		};
		//general

        //button
        function fn01Verification() {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'FormCode': 'SCM020000',
                    'Type': 'For Verification (Contractor)'
                },
                success: function (response) {
                    let gridDiv = document.querySelector('#table01Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";

                    gridOptions = {
                        suppressCellFocus: true,
                        suppressVerticalScroll: true,
                        enableCellTextSelection: true,
                        rowSelection: 'single',
                        //popupParent: document.body,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action",
                                field: "Action",
                                sortable: false,
                                resizable: false,
                                lockPosition: true,
                                width: 75,
                                cellRenderer: params => params.value
                            },
                            {
                                headerName: "Code",
                                field: "Code",
                                lockPosition: true,
                                width: 150,
                                tooltipField: "Code",
                                cellRenderer: params => {
                                    const link = document.createElement('a');
                                    link.href = "javascript:void(0)";
                                    link.innerText = params.value;
                                    link.onclick = function () {
                                        window.open(
                                            `SCM020100-DTL-${params.value}`,
                                            '_blank'
                                        );
                                    };
                                    return link;
                                }
                            },
                            {
                                headerName: "Contractor",
                                field: "Contractor",
                                flex: 1,
                                tooltipField: "Contractor"
                            },
                            {
                                headerName: "Email",
                                field: "Email",
                                tooltipField: "Email",
                                width: 350
                            },
                            {
                                headerName: "Address",
                                field: "Address",
                                tooltipField: "Address",
                                width: 320
                            },
                            {
                                headerName: "Status",
                                field: "AcctProgress",
                                width: 150,
                                tooltipField: "AcctProgress"
                            },
                            {
                                headerName: "Date Created",
                                field: "CreatedDate",
                                width: 150,
                                tooltipField: "CreatedDate"
                            },
                            {
                                headerName: "Type",
                                field: "Type",
                                width: 75,
                                tooltipField: "Type"
                            }
                        ],
                        rowData: response,
                        pagination: true,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    //modal
                    $("#mdl01Users").modal("show");
                },
            });
        };
        function fn01Resubmission() {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'FormCode': 'SCM020000',
                    'Type': 'For Resubmission (Contractor)'
                },
                success: function (response) {
                    let gridDiv = document.querySelector('#table01Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";

                    gridOptions = {
                        suppressCellFocus: true,
                        suppressVerticalScroll: true,
                        enableCellTextSelection: true,
                        rowSelection: 'single',
                        //popupParent: document.body,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action",
                                field: "Action",
                                sortable: false,
                                resizable: false,
                                lockPosition: true,
                                width: 75,
                                cellRenderer: params => params.value
                            },
                            {
                                headerName: "Code",
                                field: "Code",
                                lockPosition: true,
                                width: 150,
                                tooltipField: "Code",
                                cellRenderer: params => {
                                    const link = document.createElement('a');
                                    link.href = "javascript:void(0)";
                                    link.innerText = params.value;
                                    link.onclick = function () {
                                        window.open(
                                            `SCM020200-DTL-${params.value}`,
                                            '_blank'
                                        );
                                    };
                                    return link;
                                }
                            },
                            {
                                headerName: "Contractor",
                                field: "Contractor",
                                flex: 1,
                                tooltipField: "Contractor"
                            },
                            {
                                headerName: "Email",
                                field: "Email",
                                tooltipField: "Email",
                                width: 350
                            },
                            {
                                headerName: "Address",
                                field: "Address",
                                tooltipField: "Address",
                                width: 320
                            },
                            {
                                headerName: "Status",
                                field: "AcctProgress",
                                width: 150,
                                tooltipField: "AcctProgress"
                            },
                            {
                                headerName: "Date Created",
                                field: "CreatedDate",
                                width: 150,
                                tooltipField: "CreatedDate"
                            },
                            {
                                headerName: "Type",
                                field: "Type",
                                width: 75,
                                tooltipField: "Type"
                            }
                        ],
                        rowData: response,
                        pagination: true,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    //modal
                    $("#mdl01Users").modal("show");
                },
            });
        };
        function fn01Approved() {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'FormCode': 'SCM020000',
                    'Type': 'For Approved (Contractor)'
                },
                success: function (response) {
                    let gridDiv = document.querySelector('#table01Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";

                    gridOptions = {
                        suppressCellFocus: true,
                        suppressVerticalScroll: true,
                        enableCellTextSelection: true,
                        rowSelection: 'single',
                        //popupParent: document.body,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action",
                                field: "Action",
                                sortable: false,
                                resizable: false,
                                lockPosition: true,
                                width: 75,
                                cellRenderer: params => params.value
                            },
                            {
                                headerName: "Code",
                                field: "Code",
                                lockPosition: true,
                                width: 150,
                                tooltipField: "Code",
                                cellRenderer: params => {
                                    const link = document.createElement('a');
                                    link.href = "javascript:void(0)";
                                    link.innerText = params.value;
                                    link.onclick = function () {
                                        window.open(
                                            `SCM020300-DTL-${params.value}`,
                                            '_blank'
                                        );
                                    };
                                    return link;
                                }
                            },
                            {
                                headerName: "Contractor",
                                field: "Contractor",
                                flex: 1,
                                tooltipField: "Contractor"
                            },
                            {
                                headerName: "Email",
                                field: "Email",
                                tooltipField: "Email",
                                width: 350
                            },
                            {
                                headerName: "Address",
                                field: "Address",
                                tooltipField: "Address",
                                width: 320
                            },
                            {
                                headerName: "Status",
                                field: "AcctProgress",
                                width: 150,
                                tooltipField: "AcctProgress"
                            },
                            {
                                headerName: "Date Created",
                                field: "CreatedDate",
                                width: 150,
                                tooltipField: "CreatedDate"
                            },
                            {
                                headerName: "Type",
                                field: "Type",
                                width: 75,
                                tooltipField: "Type"
                            }
                        ],
                        rowData: response,
                        pagination: true,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    //modal
                    $("#mdl01Users").modal("show");
                },
            });
        };
        function fn01Declined() {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'FormCode': 'SCM020000',
                    'Type': 'For Declined (Contractors)'
                },
                success: function (response) {
                    let gridDiv = document.querySelector('#table01Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";

                    gridOptions = {
                        suppressCellFocus: true,
                        suppressVerticalScroll: true,
                        enableCellTextSelection: true,
                        rowSelection: 'single',
                        //popupParent: document.body,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action",
                                field: "Action",
                                sortable: false,
                                resizable: false,
                                lockPosition: true,
                                width: 75,
                                cellRenderer: params => params.value
                            },
                            {
                                headerName: "Code",
                                field: "Code",
                                lockPosition: true,
                                width: 150,
                                tooltipField: "Code",
                                cellRenderer: params => {
                                    const link = document.createElement('a');
                                    link.href = "javascript:void(0)";
                                    link.innerText = params.value;
                                    link.onclick = function () {
                                        window.open(
                                            `SCM020200-DTL-${params.value}`,
                                            '_blank'
                                        );
                                    };
                                    return link;
                                }
                            },
                            {
                                headerName: "Contractor",
                                field: "Contractor",
                                flex: 1,
                                tooltipField: "Contractor"
                            },
                            {
                                headerName: "Email",
                                field: "Email",
                                tooltipField: "Email",
                                width: 350
                            },
                            {
                                headerName: "Address",
                                field: "Address",
                                tooltipField: "Address",
                                width: 320
                            },
                            {
                                headerName: "Status",
                                field: "AcctProgress",
                                width: 150,
                                tooltipField: "AcctProgress"
                            },
                            {
                                headerName: "Date Created",
                                field: "CreatedDate",
                                width: 150,
                                tooltipField: "CreatedDate"
                            },
                            {
                                headerName: "Type",
                                field: "Type",
                                width: 75,
                                tooltipField: "Type"
                            }
                        ],
                        rowData: response,
                        pagination: true,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    //modal
                    $("#mdl01Users").modal("show");
                },
            });
        };
        //button

        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {
				fn01Load();
			});
        }
    </script>

</asp:Content>
