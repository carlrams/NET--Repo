<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000002.aspx.vb" Inherits="NET.DSB000002" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Project Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Overview</li>
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

		<!--begin::row-->
		<div class="row gx-5 gy-5">
		    <!--end::Col-->
             <!--begin::Col-->
			<div class=" col-sm-12 col-md-6 col-lg-3">
				<!--begin::Card widget 4-->
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header pt-5">
						<!--begin::Title-->
						<div class="card-title d-flex flex-column">
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<div class="symbol symbol-45px me-5">
									<img src="Assets/media/svg/Custom/LandDevelopment01.svg" alt="" />
								</div>
								<div class="d-flex justify-content-start flex-column">
									<span class="fs-2 fw-bolder text-dark">23</span>
									<span class="fs-6 fw-bold text-muted">Land Development</span>
								</div>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Title-->
					</div>
					<!--end::Header-->
                    <!--begin::Body-->
                    <div class="card-body">
                        <!--begin::Chart-->
					    <div class="d-flex flex-center">
						    <div id="landdevelopment_pie_chart" style="height: 200px; width:200px; position:relative;top:0px"></div>
					    </div>
					    <!--end::Chart-->
                        <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-warning me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Quezon</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-danger me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Laguna</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-info me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Batangas</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
                    </div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 4-->
			</div>
			<!--end::Col-->
            <!--begin::Col-->
			<div class=" col-sm-12 col-md-6 col-lg-3">
				<!--begin::Card widget 4-->
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header pt-5">
						<!--begin::Title-->
						<div class="card-title d-flex flex-column">
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<div class="symbol symbol-45px me-5">
									<img src="Assets/media/svg/Custom/Amenities01.svg" alt="" />
								</div>
								<div class="d-flex justify-content-start flex-column">
									<span class="fs-2 fw-bolder text-dark">23</span>
									<span class="fs-6 fw-bold text-muted">Amenities</span>
								</div>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<!--begin::Body-->
                    <div class="card-body">
                        <!--begin::Chart-->
					    <div class="d-flex flex-center">
						    <div id="amenities_pie_chart" style="height: 200px; width:200px; position:relative;top:0px"></div>
					    </div>
					    <!--end::Chart-->
                        <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-warning me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Quezon</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-danger me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Laguna</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-info me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Batangas</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
                    </div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 4-->
			</div>
			<!--end::Col-->
            <!--begin::Col-->
			<div class=" col-sm-12 col-md-6 col-lg-3">
				<!--begin::Card widget 4-->
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header pt-5">
						<!--begin::Title-->
						<div class="card-title d-flex flex-column">
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<div class="symbol symbol-45px me-5">
									<img src="Assets/media/svg/Custom/House01.svg" alt="" />
								</div>
								<div class="d-flex justify-content-start flex-column">
									<span class="fs-2 fw-bolder text-dark">475</span>
									<span class="fs-6 fw-bold text-muted">House</span>
								</div>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<!--begin::Body-->
                    <div class="card-body">
                        <!--begin::Chart-->
					    <div class="d-flex flex-center">
						    <div id="house_pie_chart" style="height: 200px; width:200px; position:relative;top:0px"></div>
					    </div>
					    <!--end::Chart-->
                        <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-warning me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Quezon</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-danger me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Laguna</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-info me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Batangas</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
                    </div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 4-->
			</div>
			<!--end::Col-->
            <!--begin::Col-->
			<div class=" col-sm-12 col-md-6 col-lg-3">
				<!--begin::Card widget 4-->
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header pt-5">
						<!--begin::Title-->
						<div class="card-title d-flex flex-column">
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<div class="symbol symbol-45px me-5">
									<img src="Assets/media/svg/Custom/Other01.svg" alt="" />
								</div>
								<div class="d-flex justify-content-start flex-column">
									<span class="fs-2 fw-bolder text-dark">172</span>
									<span class="fs-6 fw-bold text-muted">Other Project</span>
								</div>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<!--begin::Body-->
                    <div class="card-body">
                        <!--begin::Chart-->
					    <div class="d-flex flex-center">
						    <div id="other_pie_chart" style="height: 200px; width:200px; position:relative;top:0px"></div>
					    </div>
					    <!--end::Chart-->
                        <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-warning me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Quezon</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-danger me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Laguna</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						 <!--begin::Item-->
						<div class="d-flex flex-stack">
	                        <!--begin::Label-->
							<div class="d-flex fs-6 fw-bold align-items-center ">
								<div class="bullet bg-info me-3"></div>
                                <div class="text-gray-700 fw-bold fs-6 me-2">Batangas</div>
							</div>
							<!--end::Label-->
							<!--begin::Statistics-->
							<div class="d-flex align-items-senter">
								<!--begin::Number-->
								<span class="text-gray-700 fw-bold">2</span>
								<!--end::Number-->
							</div>
							<!--end::Statistics-->
						</div>
						<!--end::Item-->
                    </div>
					<!--end::Body-->
				</div>
				<!--end::Card widget 4-->
			</div>
			<!--end::Col-->
		</div>
		<!--end::row-->

	</div>
	<!--end::Post-->
	
	<script type="text/javascript">

        //loan data
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
			//land development
			jQuery(function ($) {
                document.getElementById('landdevelopment_pie_chart').innerHTML = "";
                var element = document.getElementById('landdevelopment_pie_chart');
                if (!element) {
                    return;
                }
				var options = {
                    series: [2, 3, 4],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Laguna', Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['Quezon', 'Laguna', 'Batangas'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],
                    grid: {
                        padding: {
                            top: -2,
                            left: -5
                        }
                    },
                };

                var chart = new ApexCharts(element, options);
                chart.render();
			});
			//land development

			//amenities
            jQuery(function ($) {
                document.getElementById('amenities_pie_chart').innerHTML = "";
                var element = document.getElementById('amenities_pie_chart');
                if (!element) {
                    return;
                }
                var options = {
                    series: [2, 3, 4],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Laguna', Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['Quezon', 'Laguna', 'Batangas'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],
                    grid: {
                        padding: {
                            top: -2,
                            left: -5
                        }
                    },
                };

                var chart = new ApexCharts(element, options);
                chart.render();
			});
			//amenities

            //house
            jQuery(function ($) {
                document.getElementById('house_pie_chart').innerHTML = "";
                var element = document.getElementById('house_pie_chart');
                if (!element) {
                    return;
                }
                var options = {
                    series: [2, 3, 4],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Laguna', Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['Quezon', 'Laguna', 'Batangas'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],
                    grid: {
                        padding: {
                            top: -2,
                            left: -5
                        }
                    },
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
			//house

            //house
            jQuery(function ($) {
                document.getElementById('other_pie_chart').innerHTML = "";
                var element = document.getElementById('other_pie_chart');
                if (!element) {
                    return;
                }
                var options = {
                    series: [2, 3, 4],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Laguna', Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['Quezon', 'Laguna', 'Batangas'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],
                    grid: {
                        padding: {
                            top: -2,
                            left: -5
                        }
                    },
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
			//house
        }
        //loan data

    </script>

</asp:Content>
