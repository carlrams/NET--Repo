<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000014.aspx.vb" Inherits="NET.DSB000014" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--begin::Post-->
	<div class="content flex-row-fluid" id="kt_content">
		
		<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
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
						<li class="breadcrumb-item text-white">House Construction</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Batch</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Details</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::piechart-->
		<div class="row g-5 mb-5">
			<div class="col-lg-6">
				<!--begin::Card-->
				<div class="card h-100">
					<!--begin::Card body-->
					<div class="card-body p-9">
						<!--begin::Heading-->
						<div class="fs-2hx fw-bolder">Construction</div>
						<!--end::Heading-->
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap">
							<!--begin::Chart-->
							<div class="d-flex flex-center me-9 mb-5">
								<canvas id="pie_chart"></canvas>
							</div>
							<!--end::Chart-->
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#83E2E9"></div>
									<div class="text-gray-400">Newly Endorsed</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieNewlyEndorsed" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#619FFC"></div>
									<div class="text-gray-400">For Costing</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieForCosting" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#A777C9"></div>
									<div class="text-gray-400">For Budget</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieForBudget" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#ED7DB1"></div>
									<div class="text-gray-400">For Award</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieForAward" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#6991A7"></div>
									<div class="text-gray-400">Awarded</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieAwarded" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#F8C22D"></div>
									<div class="text-gray-400">On-Going</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieOngoing" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#43BF57"></div>
									<div class="text-gray-400">Completed</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieCompleted" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#ADD43C"></div>
									<div class="text-gray-400">On-Hold</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieOnhold" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#F2451C"></div>
									<div class="text-gray-400">Cancelled</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieCancelled" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
						</div>
						<!--end::Wrapper-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Card-->
			</div>
			<div class="col-lg-6">
				<!--begin::Card-->
				<div class="card h-100">
					<!--begin::Body-->
					<div class="card-body">
						<!--begin::Heading-->
						<div class="fs-2hx fw-bolder">Project by Stage</div>
						<!--end::Heading-->
						<div id="bar_chart_horizontal" style="height:300px"></div>
					</div>
					<!--end: Card Body-->
				</div>
				<!--end::Card-->
			</div>
		</div>
		<!--end::piechart-->

        <!--begin::piechart-->
		<div class="row g-5 mb-5">
			<div class="col-lg-6">
				<!--begin::Card-->
				<div class="card h-100">
					<!--begin::Body-->
					<div class="card-body">
						<!--begin::Heading-->
						<div class="fs-2hx fw-bolder">House Model Type</div>
						<!--end::Heading-->
						<div id="bar_chart_vertical1" style="height:300px"></div>
					</div>
					<!--end: Card Body-->
				</div>
				<!--end::Card-->
			</div>
			<div class="col-lg-6">
				<!--begin::Card-->
				<div class="card h-100">
					<!--begin::Body-->
					<div class="card-body">
						<!--begin::Heading-->
						<div class="fs-2hx fw-bolder">Contractor</div>
						<!--end::Heading-->
						<div id="bar_chart_vertical2" style="height:300px"></div>
					</div>
					<!--end: Card Body-->
				</div>
				<!--end::Card-->
			</div>
		</div>
		<!--end::piechart-->

	</div>
	<!--end::Post-->
	
	<script type="text/javascript">

        //form variable
        var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
		var ltrlPieNewlyEndorsed = '<asp:Literal ID="ltrlPieNewlyEndorsed" runat="server" />';
        var ltrlPieForCosting = '<asp:Literal ID="ltrlPieForCosting" runat="server" />';
        var ltrlPieForBudget = '<asp:Literal ID="ltrlPieForBudget" runat="server" />';
        var ltrlPieForAward = '<asp:Literal ID="ltrlPieForAward" runat="server" />';
        var ltrlPieAwarded = '<asp:Literal ID="ltrlPieAwarded" runat="server" />';
        var ltrlPieOnGoing = '<asp:Literal ID="ltrlPieOnGoing" runat="server" />';
        var ltrlPieCompleted = '<asp:Literal ID="ltrlPieCompleted" runat="server" />';
        var ltrlPieOnHold = '<asp:Literal ID="ltrlPieOnHold" runat="server" />';
        var ltrlPieCancelled = '<asp:Literal ID="ltrlPieCancelled" runat="server" />';

        var ltrlBarHTarPermits = '<asp:Literal ID="ltrlBarHTarPermits" runat="server" />';
        var ltrlBarHTarPAD = '<asp:Literal ID="ltrlBarHTarPAD" runat="server" />';
        var ltrlBarHTarCost = '<asp:Literal ID="ltrlBarHTarCost" runat="server" />';
        var ltrlBarHTarSCMD = '<asp:Literal ID="ltrlBarHTarSCMD" runat="server" />';
        var ltrlBarHTarCOD = '<asp:Literal ID="ltrlBarHTarCOD" runat="server" />';
        var ltrlBarHTarPMD = '<asp:Literal ID="ltrlBarHTarPMD" runat="server" />';
        var ltrlBarHActPermits = '<asp:Literal ID="ltrlBarHActPermits" runat="server" />';
        var ltrlBarHActPAD = '<asp:Literal ID="ltrlBarHActPAD" runat="server" />';
        var ltrlBarHActCost = '<asp:Literal ID="ltrlBarHActCost" runat="server" />';
        var ltrlBarHActSCMD = '<asp:Literal ID="ltrlBarHActSCMD" runat="server" />';
        var ltrlBarHActCOD = '<asp:Literal ID="ltrlBarHActCOD" runat="server" />';
        var ltrlBarHActPMD = '<asp:Literal ID="ltrlBarHActPMD" runat="server" />';
        var ltrlBarV1ValueCategory = '<asp:Literal ID="ltrlBarV1ValueCategory" runat="server" />';
        var ltrlBarV1ValueData = '<asp:Literal ID="ltrlBarV1ValueData" runat="server" />';
        var ltrlBarV2ValueCategory = '<asp:Literal ID="ltrlBarV2ValueCategory" runat="server" />';
        var ltrlBarV2ValueData = '<asp:Literal ID="ltrlBarV2ValueData" runat="server" />';
        //form variable

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                // init chart
                var element = document.getElementById("pie_chart");
                if (!element) {
                    return;
                }
                var config = {
                    type: 'doughnut',
                    data: {
                        datasets: [{
                            data: [ltrlPieNewlyEndorsed, ltrlPieForCosting, ltrlPieForBudget, ltrlPieForAward, ltrlPieAwarded, ltrlPieOnGoing, ltrlPieCompleted, ltrlPieOnHold, ltrlPieCancelled],
                            backgroundColor: ['#83E2E9', '#619FFC', '#A777C9', '#ED7DB1', '#6991A7', '#F8C22D', '#43BF57', '#ADD43C', '#F2451C']
                        }],
                        labels: ['Newly Endorsed', 'for Costing', 'for Budget', 'for Award', 'Awarded', 'On-going', 'Completed', 'On-hold', 'Cancelled']
                    },
                    options: {
                        chart: {
                            fontFamily: 'inherit'
                        },
                        cutout: '75%',
                        cutoutPercentage: 65,
                        responsive: true,
                        maintainAspectRatio: false,
                        title: {
                            display: false
                        },
                        animation: {
                            animateScale: true,
                            animateRotate: true
                        },
                        tooltips: {
                            enabled: true,
                            intersect: false,
                            mode: 'nearest',
                            bodySpacing: 5,
                            yPadding: 10,
                            xPadding: 10,
                            caretPadding: 0,
                            displayColors: false,
                            backgroundColor: '#20D489',
                            titleFontColor: '#ffffff',
                            cornerRadius: 4,
                            footerSpacing: 0,
                            titleSpacing: 0
                        },
                        plugins: {
                            legend: {
                                display: false
                            }
                        }
                    }
                };
                var ctx = element.getContext('2d');
                var myDoughnut = new Chart(ctx, config);
			});
            jQuery(function ($) {
                var element = document.getElementById('bar_chart_horizontal');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Target',
                        data: [ltrlBarHTarPermits, ltrlBarHTarPAD, ltrlBarHTarCost, ltrlBarHTarSCMD, ltrlBarHTarCOD, ltrlBarHTarPMD]
                    }, {
                        name: 'Actual',
                        data: [ltrlBarHActPermits, ltrlBarHActPAD, ltrlBarHActCost, ltrlBarHActSCMD, ltrlBarHActCOD, ltrlBarHActPMD]
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
                            horizontal: true,
                            columnWidth: ['30%'],
                            endingShape: 'rounded'
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ['Permits', 'PAD', 'COST', 'SCMD', 'COD', 'PMD'],
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
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
                        },
                        y: {
                            formatter: function (val) {
                                return val + ' units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
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
                chart.render();
            });
            jQuery(function ($) {
                var element = document.getElementById('bar_chart_vertical1');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');
                const ArrayBarV1ValueCategory = ltrlBarV1ValueCategory.split(",");
                const ArrayBarV1ValueData = ltrlBarV1ValueData.split(",");
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'Unit',
                        data: ArrayBarV1ValueData
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
                            columnWidth: ['30%'],
                            endingShape: 'rounded'
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ArrayBarV1ValueCategory,
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
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
                        },
                        y: {
                            formatter: function (val) {
                                return + val + ' Units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    title: {
                        text: 'Monthly Inflation in Argentina, 2002',
                        floating: true,
                        offsetY: 330,
                        align: 'center',
                        style: {
                            color: '#444'
                        }
                    }
                };
                var chart = new ApexCharts(element, options);
                chart.render();
            });
            jQuery(function ($) {
                var element = document.getElementById('bar_chart_vertical2');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');
                const ArrayBarV2ValueCategory = ltrlBarV2ValueCategory.split(",");
                const ArrayBarV2ValueData = ltrlBarV2ValueData.split(",");
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'Unit',
                        data: ArrayBarV2ValueData
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
                            columnWidth: ['30%'],
                            endingShape: 'rounded'
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ArrayBarV2ValueCategory,
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
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
                        },
                        y: {
                            formatter: function (val) {
                                return + val + ' Units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    title: {
                        text: 'Monthly Inflation in Argentina, 2002',
                        floating: true,
                        offsetY: 330,
                        align: 'center',
                        style: {
                            color: '#444'
                        }
                    }
                };
                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
    </script>

</asp:Content>
