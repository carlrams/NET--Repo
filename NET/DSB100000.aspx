<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB100000.aspx.vb" Inherits="NET.DSB100000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Supply Chain Management</li>
						<!--end::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<li class="breadcrumb-item text-white">Warehouse Monitoring</li>
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		
		<div class="row gy-5 g-xl-10">
			<!--begin::Col-->
			<div class="col-sm-6 col-xl-2 mb-xl-10">
				<!--begin::Card widget 2-->
				<div class="card h-lg-100">
					<!--begin::Body-->
					<div class="card-body d-flex justify-content-between align-items-start flex-column">
						<!--begin::Icon-->
						<div class="m-0">
							<!--begin::Svg Icon | path: icons/duotune/maps/map004.svg-->
							<span class="svg-icon svg-icon-2hx svg-icon-gray-600">
								<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
								<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
									<rect x="0" y="0" width="24" height="24"/>
									<path d="M3.95709826,8.41510662 L11.47855,3.81866389 C11.7986624,3.62303967 12.2013376,3.62303967 12.52145,3.81866389 L20.0429,8.41510557 C20.6374094,8.77841684 21,9.42493654 21,10.1216692 L21,19.0000642 C21,20.1046337 20.1045695,21.0000642 19,21.0000642 L4.99998155,21.0000673 C3.89541205,21.0000673 2.99998155,20.1046368 2.99998155,19.0000673 L2.99999828,10.1216672 C2.99999935,9.42493561 3.36258984,8.77841732 3.95709826,8.41510662 Z M10,13 C9.44771525,13 9,13.4477153 9,14 L9,17 C9,17.5522847 9.44771525,18 10,18 L14,18 C14.5522847,18 15,17.5522847 15,17 L15,14 C15,13.4477153 14.5522847,13 14,13 L10,13 Z" fill="currentColor"/>
								</g>
							</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Icon-->
						<!--begin::Section-->
						<div class="d-flex flex-column my-7">
							<!--begin::Number-->
							<span class="fw-bold fs-3x text-gray-800 lh-1 ls-n2">33</span>
							<!--end::Number-->
							<!--begin::Follower-->
							<div class="m-0">
								<span class="fw-bold fs-6 text-gray-400">Warehouse</span>
							</div>
							<!--end::Follower-->
						</div>
						<!--end::Section-->
						<!--begin::Badge-->
						<span class="badge badge-success fs-base">2.1%</span>
						<!--end::Badge-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 2-->
			</div>
			<!--end::Col-->
			<!--begin::Col-->
			<div class="col-sm-6 col-xl-2 mb-xl-10">
				<!--begin::Card widget 2-->
				<div class="card h-lg-100">
					<!--begin::Body-->
					<div class="card-body d-flex justify-content-between align-items-start flex-column">
						<!--begin::Icon-->
						<div class="m-0">
							<!--begin::Svg Icon | path: icons/duotune/graphs/gra001.svg-->
							<span class="svg-icon svg-icon-2hx svg-icon-gray-600">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path opacity="0.3" d="M14 3V21H10V3C10 2.4 10.4 2 11 2H13C13.6 2 14 2.4 14 3ZM7 14H5C4.4 14 4 14.4 4 15V21H8V15C8 14.4 7.6 14 7 14Z" fill="currentColor" />
									<path d="M21 20H20V8C20 7.4 19.6 7 19 7H17C16.4 7 16 7.4 16 8V20H3C2.4 20 2 20.4 2 21C2 21.6 2.4 22 3 22H21C21.6 22 22 21.6 22 21C22 20.4 21.6 20 21 20Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Icon-->
						<!--begin::Section-->
						<div class="d-flex flex-column my-7">
							<!--begin::Number-->
							<span class="fw-bold fs-3x text-gray-800 lh-1 ls-n2">27,5M</span>
							<!--end::Number-->
							<!--begin::Follower-->
							<div class="m-0">
								<span class="fw-bold fs-6 text-gray-400">Stock Qty</span>
							</div>
							<!--end::Follower-->
						</div>
						<!--end::Section-->
						<!--begin::Badge-->
						<span class="badge badge-success fs-base">2.1%</span>
						<!--end::Badge-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 2-->
			</div>
			<!--end::Col-->
			<!--begin::Col-->
			<div class="col-sm-6 col-xl-2 mb-xl-10">
				<!--begin::Card widget 2-->
				<div class="card h-lg-100">
					<!--begin::Body-->
					<div class="card-body d-flex justify-content-between align-items-start flex-column">
						<!--begin::Icon-->
						<div class="m-0">
							<!--begin::Svg Icon | path: icons/duotune/abstract/abs048.svg-->
							<span class="svg-icon svg-icon-2hx svg-icon-gray-600">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path opacity="0.3" d="M12 22C17.5228 22 22 17.5228 22 12C22 6.47715 17.5228 2 12 2C6.47715 2 2 6.47715 2 12C2 17.5228 6.47715 22 12 22Z" fill="currentColor" />
									<path d="M8.70001 6C8.10001 5.7 7.39999 5.40001 6.79999 5.10001C7.79999 4.00001 8.90001 3 10.1 2.2C10.7 2.1 11.4 2 12 2C12.7 2 13.3 2.1 13.9 2.2C12 3.2 10.2 4.5 8.70001 6ZM12 8.39999C13.9 6.59999 16.2 5.30001 18.7 4.60001C18.1 4.00001 17.4 3.6 16.7 3.2C14.4 4.1 12.2 5.40001 10.5 7.10001C11 7.50001 11.5 7.89999 12 8.39999ZM7 20C7 20.2 7 20.4 7 20.6C6.2 20.1 5.49999 19.6 4.89999 19C4.59999 18 4.00001 17.2 3.20001 16.6C2.80001 15.8 2.49999 15 2.29999 14.1C4.99999 14.7 7 17.1 7 20ZM10.6 9.89999C8.70001 8.09999 6.39999 6.9 3.79999 6.3C3.39999 6.9 2.99999 7.5 2.79999 8.2C5.39999 8.6 7.7 9.80001 9.5 11.6C9.8 10.9 10.2 10.4 10.6 9.89999ZM2.20001 10.1C2.10001 10.7 2 11.4 2 12C2 12 2 12 2 12.1C4.3 12.4 6.40001 13.7 7.60001 15.6C7.80001 14.8 8.09999 14.1 8.39999 13.4C6.89999 11.6 4.70001 10.4 2.20001 10.1ZM11 20C11 14 15.4 9.00001 21.2 8.10001C20.9 7.40001 20.6 6.8 20.2 6.2C13.8 7.5 9 13.1 9 19.9C9 20.4 9.00001 21 9.10001 21.5C9.80001 21.7 10.5 21.8 11.2 21.9C11.1 21.3 11 20.7 11 20ZM19.1 19C19.4 18 20 17.2 20.8 16.6C21.2 15.8 21.5 15 21.7 14.1C19 14.7 16.9 17.1 16.9 20C16.9 20.2 16.9 20.4 16.9 20.6C17.8 20.2 18.5 19.6 19.1 19ZM15 20C15 15.9 18.1 12.6 22 12.1C22 12.1 22 12.1 22 12C22 11.3 21.9 10.7 21.8 10.1C16.8 10.7 13 14.9 13 20C13 20.7 13.1 21.3 13.2 21.9C13.9 21.8 14.5 21.7 15.2 21.5C15.1 21 15 20.5 15 20Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Icon-->
						<!--begin::Section-->
						<div class="d-flex flex-column my-7">
							<!--begin::Number-->
							<span class="fw-bold fs-3x text-gray-800 lh-1 ls-n2">149M</span>
							<!--end::Number-->
							<!--begin::Follower-->
							<div class="m-0">
								<span class="fw-bold fs-6 text-gray-400">Stock Value</span>
							</div>
							<!--end::Follower-->
						</div>
						<!--end::Section-->
						<!--begin::Badge-->
						<span class="badge badge-danger fs-base">0.47%</span>
						<!--end::Badge-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 2-->
			</div>
			<!--end::Col-->
			<!--begin::Col-->
			<div class="col-sm-6 col-xl-2 mb-xl-10">
				<!--begin::Card widget 2-->
				<div class="card h-lg-100">
					<!--begin::Body-->
					<div class="card-body d-flex justify-content-between align-items-start flex-column">
						<!--begin::Icon-->
						<div class="m-0">
							<!--begin::Svg Icon | path: icons/duotune/maps/map002.svg-->
							<span class="svg-icon svg-icon-2hx svg-icon-gray-600">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path d="M8.7 4.19995L4 6.30005V18.8999L8.7 16.8V19L3.1 21.5C2.6 21.7 2 21.4 2 20.8V6C2 5.4 2.3 4.89995 2.9 4.69995L8.7 2.09998V4.19995Z" fill="currentColor" />
									<path d="M15.3 19.8L20 17.6999V5.09992L15.3 7.19989V4.99994L20.9 2.49994C21.4 2.29994 22 2.59989 22 3.19989V17.9999C22 18.5999 21.7 19.1 21.1 19.3L15.3 21.8998V19.8Z" fill="currentColor" />
									<path opacity="0.3" d="M15.3 7.19995L20 5.09998V17.7L15.3 19.8V7.19995Z" fill="currentColor" />
									<path opacity="0.3" d="M8.70001 4.19995V2L15.4 5V7.19995L8.70001 4.19995ZM8.70001 16.8V19L15.4 22V19.8L8.70001 16.8Z" fill="currentColor" />
									<path opacity="0.3" d="M8.7 16.8L4 18.8999V6.30005L8.7 4.19995V16.8Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Icon-->
						<!--begin::Section-->
						<div class="d-flex flex-column my-7">
							<!--begin::Number-->
							<span class="fw-bold fs-3x text-gray-800 lh-1 ls-n2">89M</span>
							<!--end::Number-->
							<!--begin::Follower-->
							<div class="m-0">
								<span class="fw-bold fs-6 text-gray-400">Avg. Stock Qty</span>
							</div>
							<!--end::Follower-->
						</div>
						<!--end::Section-->
						<!--begin::Badge-->
						<span class="badge badge-success fs-base">2.1%</span>
						<!--end::Badge-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 2-->
			</div>
			<!--end::Col-->
			<!--begin::Col-->
			<div class="col-sm-6 col-xl-2 mb-5 mb-xl-10">
				<!--begin::Card widget 2-->
				<div class="card h-lg-100">
					<!--begin::Body-->
					<div class="card-body d-flex justify-content-between align-items-start flex-column">
						<!--begin::Icon-->
						<div class="m-0">
							<!--begin::Svg Icon | path: icons/duotune/abstract/abs037.svg-->
							<span class="svg-icon svg-icon-2hx svg-icon-gray-600">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path opacity="0.3" d="M2.10001 10C3.00001 5.6 6.69998 2.3 11.2 2L8.79999 4.39999L11.1 7C9.60001 7.3 8.30001 8.19999 7.60001 9.59999L4.5 12.4L2.10001 10ZM19.3 11.5L16.4 14C15.7 15.5 14.4 16.6 12.7 16.9L15 19.5L12.6 21.9C17.1 21.6 20.8 18.2 21.7 13.9L19.3 11.5Z" fill="currentColor" />
									<path d="M13.8 2.09998C18.2 2.99998 21.5 6.69998 21.8 11.2L19.4 8.79997L16.8 11C16.5 9.39998 15.5 8.09998 14 7.39998L11.4 4.39998L13.8 2.09998ZM12.3 19.4L9.69998 16.4C8.29998 15.7 7.3 14.4 7 12.8L4.39999 15.1L2 12.7C2.3 17.2 5.7 20.9 10 21.8L12.3 19.4Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Icon-->
						<!--begin::Section-->
						<div class="d-flex flex-column my-7">
							<!--begin::Number-->
							<span class="fw-bold fs-3x text-gray-800 lh-1 ls-n2">72.4%</span>
							<!--end::Number-->
							<!--begin::Follower-->
							<div class="m-0">
								<span class="fw-bold fs-6 text-gray-400">Avg. Stock Value</span>
							</div>
							<!--end::Follower-->
						</div>
						<!--end::Section-->
						<!--begin::Badge-->
						<span class="badge badge-danger fs-base">0.647%</span>
						<!--end::Badge-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 2-->
			</div>
			<!--end::Col-->
			<!--begin::Col-->
			<div class="col-sm-6 col-xl-2 mb-5 mb-xl-10">
				<!--begin::Card widget 2-->
				<div class="card h-lg-100">
					<!--begin::Body-->
					<div class="card-body d-flex justify-content-between align-items-start flex-column">
						<!--begin::Icon-->
						<div class="m-0">
							<!--begin::Svg Icon | path: icons/duotune/abstract/abs027.svg-->
							<span class="svg-icon svg-icon-2hx svg-icon-gray-600">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path opacity="0.3" d="M21.25 18.525L13.05 21.825C12.35 22.125 11.65 22.125 10.95 21.825L2.75 18.525C1.75 18.125 1.75 16.725 2.75 16.325L4.04999 15.825L10.25 18.325C10.85 18.525 11.45 18.625 12.05 18.625C12.65 18.625 13.25 18.525 13.85 18.325L20.05 15.825L21.35 16.325C22.35 16.725 22.35 18.125 21.25 18.525ZM13.05 16.425L21.25 13.125C22.25 12.725 22.25 11.325 21.25 10.925L13.05 7.62502C12.35 7.32502 11.65 7.32502 10.95 7.62502L2.75 10.925C1.75 11.325 1.75 12.725 2.75 13.125L10.95 16.425C11.65 16.725 12.45 16.725 13.05 16.425Z" fill="currentColor" />
									<path d="M11.05 11.025L2.84998 7.725C1.84998 7.325 1.84998 5.925 2.84998 5.525L11.05 2.225C11.75 1.925 12.45 1.925 13.15 2.225L21.35 5.525C22.35 5.925 22.35 7.325 21.35 7.725L13.05 11.025C12.45 11.325 11.65 11.325 11.05 11.025Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Icon-->
						<!--begin::Section-->
						<div class="d-flex flex-column my-7">
							<!--begin::Number-->
							<span class="fw-bold fs-3x text-gray-800 lh-1 ls-n2">106M</span>
							<!--end::Number-->
							<!--begin::Follower-->
							<div class="m-0">
								<span class="fw-bold fs-6 text-gray-400">Saving</span>
							</div>
							<!--end::Follower-->
						</div>
						<!--end::Section-->
						<!--begin::Badge-->
						<span class="badge badge-success fs-base">2.1%</span>
						<!--end::Badge-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 2-->
			</div>
			<!--end::Col-->
		</div>

		<div class="row gx-5 gx-xl-10">
			<!--begin::Col-->
			<div class="col-xl-12 mb-5 mb-xl-10">
				<!--begin::Chart widget 32-->
				<div class="card card-flush h-xl-100">
					<!--begin::Header-->
					<div class="card-header pt-7 mb-3">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-gray-800">Warehouse</span>
							<span class="text-gray-400 mt-1 fw-bold fs-6">Monitoring</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<!--begin::Body-->
					<div class="card-body d-flex flex-column justify-content-between pb-5 px-0">
						<!--begin::Chart-->
						<div id="scm_warehouse_monitoring_chart" class="min-h-auto" style="height: 375px"></div>
						<!--end::Chart-->
					</div>
					<!--end: Card Body-->
				</div>
				<!--end::Chart widget 32-->
			</div>
			<!--end::Col-->
		</div>

    </div>

    <script type="text/javascript">

		function pageLoad(sender, args) { InitialiseSettings(); };
		function InitialiseSettings() {
			jQuery(function ($) {

                // Class definition
                var KTChartsWidget32 = function () {
                    // Private methods
                    var initChart = function (chartSelector, data, initByDefault) {
                        var element = document.querySelector(chartSelector);

                        if (!element) {
                            return;
                        }

                        var height = parseInt(KTUtil.css(element, 'height'));
                        var labelColor = KTUtil.getCssVariableValue('--bs-gray-900');

                        var borderColor = KTUtil.getCssVariableValue('--bs-border-dashed-color');

                        var options = {
                            series: [{
                                name: 'Qty',
                                data: data
                            }],
                            chart: {
                                fontFamily: 'inherit',
                                type: 'bar',
                                height: height,
                                toolbar: {
                                    show: false
                                }
                            },
                            plotOptions: {
                                bar: {
                                    horizontal: false,
                                    columnWidth: ['22%'],
                                    borderRadius: 5,
                                    dataLabels: {
                                        position: "top" // top, center, bottom
                                    },
                                    startingShape: 'flat'
                                },
                            },
                            legend: {
                                show: false
                            },
                            dataLabels: {
                                enabled: true,
                                offsetY: -28,
                                style: {
                                    fontSize: '13px',
                                    colors: ['labelColor']
                                }
                            },
                            stroke: {
                                show: true,
                                width: 2,
                                colors: ['transparent']
                            },
                            xaxis: {
                                categories: ['SONRISA WAREHOUSE', 'MAIN WAREHOUSE H.E.', 'OSM PROMESA ISABANG', 'MAIN WAREHOUSE C.M.', 'LRT WAREHOUSE', 'OSM PALM SPRING', 'OSM CITTA GRANDE'],
                                axisBorder: {
                                    show: false,
                                },
                                axisTicks: {
                                    show: false
                                },
                                labels: {
                                    style: {
                                        colors: KTUtil.getCssVariableValue('--bs-gray-500'),
                                        fontSize: '13px'
                                    }
                                },
                                crosshairs: {
                                    fill: {
                                        gradient: {
                                            opacityFrom: 0,
                                            opacityTo: 0
                                        }
                                    }
                                }
                            },
                            yaxis: {
                                labels: {
                                    style: {
                                        colors: KTUtil.getCssVariableValue('--bs-gray-500'),
                                        fontSize: '13px'
                                    }
                                }
                            },
                            fill: {
                                opacity: 1
                            },
                            states: {
                                normal: {
                                    filter: {
                                        type: 'none',
                                        value: 0
                                    }
                                },
                                hover: {
                                    filter: {
                                        type: 'none',
                                        value: 0
                                    }
                                },
                                active: {
                                    allowMultipleDataPointsSelection: false,
                                    filter: {
                                        type: 'none',
                                        value: 0
                                    }
                                }
                            },
                            tooltip: {
                                style: {
                                    fontSize: '12px'
                                }
                            },
                            colors: [KTUtil.getCssVariableValue('--bs-primary'), KTUtil.getCssVariableValue('--bs-light-primary')],
                            grid: {
                                borderColor: borderColor,
                                strokeDashArray: 4,
                                yaxis: {
                                    lines: {
                                        show: true
                                    }
                                }
                            }
                        };

                        var chart = new ApexCharts(element, options);

                        var init = false;

                        if (initByDefault === true) {
                            chart.render();
                            init = true;
                        }

                    }

                    // Public methods
                    return {
                        init: function () {
                            initChart('#scm_warehouse_monitoring_chart', [54, 42, 75, 110, 23, 87, 50], true);
                        }
                    }
                }();

                // Webpack support
                if (typeof module !== 'undefined') {
                    module.exports = KTChartsWidget32;
                }

                // On document ready
                KTUtil.onDOMContentLoaded(function () {
                    KTChartsWidget32.init();
                });
			});
		};
    </script>

</asp:Content>
