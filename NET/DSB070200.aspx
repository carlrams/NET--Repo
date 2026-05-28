<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB070200.aspx.vb" Inherits="NET.DSB070200" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    
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
						<li class="breadcrumb-item text-white">Business Tech. Support</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Status</li>
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

		<div class="card card-flush mb-5">
			<!--begin::Header-->
			<div class="card-header">
				<!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Overall</span>
					<asp:Label ID="lbl01Total" runat="server" class="text-muted fw-bold fs-6" Text="Total Accepted Ticket"></asp:Label>
				</h3>
				<!--end::Title-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
			<div class="card-body pt-0 pb-0" >
				<div class="row g-5">
					<div class="col-lg-3">
						<!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
								<div class="symbol symbol-30px me-4">
									<div class="symbol-label fs-2 fw-bold text-white pointer" style="background-color:#7239EA"><a onclick="ViewOverview('Total');">N</a></div>
								</div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">New</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl01New" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
						<!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
								<div class="symbol symbol-30px me-4">
									<div class="symbol-label fs-2 fw-bold bg-info text-inverse-info pointer"><a onclick="ViewOverview('Total');">G</a></div>
								</div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">On-Going</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl01Ongoing" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
						<!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
								<div class="symbol symbol-30px me-4">
									<div class="symbol-label fs-2 fw-bold bg-warning text-inverse-warning pointer"><a onclick="ViewOverview('Total');">H</a></div>
								</div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">On-Hold</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl01Onhold" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
						<!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
								<div class="symbol symbol-30px me-4">
									<div class="symbol-label fs-2 fw-bold bg-danger text-inverse-danger pointer"><a onclick="ViewOverview('Total');">N</a></div>
								</div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Not Started</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl01Notstarted" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
						<!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-10">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
								<div class="symbol symbol-30px me-4">
									<div class="symbol-label fs-2 fw-bold bg-success text-inverse-success pointer"><a onclick="ViewOverview('Total');">C</a></div>
								</div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Complete</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl01Complete" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
					</div>
					<div class="col-lg-9">
						<div id="div01Total" style="height:270px"></div>
					</div>
				</div>
						
			</div>
			<!--end::Body-->
		</div>
		
        <div class="row g-5 mb-5">
            <div class="col-lg-6">
                <div class="card card-flush h-100">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Ticket</span>
                            <span class="text-muted fw-bold fs-6"">Per Department</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body pt-0 pb-0" >
                        <div class="row g-5">
                            <div class="col-lg-6 pb-7">
                                <div style="overflow-x:auto; scrollbar-width: thin;height:293px">
                                    <asp:GridView ID="gv02Department" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					                <Columns>
						                <asp:TemplateField HeaderText="Open Task">
							                <ItemTemplate>
								               <div class="d-flex align-items-center pl-3">
											        <div class="d-flex flex-column me-3">
												       <span class="bullet h-15px w-15px" style='<%# Eval("Background") %>'></span>
											        </div>
											        <div class="d-flex flex-column w-100">
												        <span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("DepName") %></span>
											        </div>
                                                   <div class="d-flex flex-column min-w-100px me-3">
												        <%# Eval("Total") %>
											        </div>
										        </div>
							                </ItemTemplate>
						                </asp:TemplateField>
					                </Columns>
				                </asp:GridView>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <!--begin::Chart-->
					            <div class="d-flex flex-center align-items-center mr-auto ml-auto mt-auto mb-auto">
						            <div id="div02Department" style="height: 270px; width:270px;"></div>
					            </div>
					            <!--end::Chart-->
                            </div>
                        </div>
						
			        </div>
			        <!--end::Body-->
		        </div>
            </div>
            <div class="col-lg-6">
                <div class="card card-flush h-100">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Ticket</span>
                            <span class="text-muted fw-bold fs-6"">Per Priority</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body pt-0 pb-0" >
                        <div class="row g-5">
                            <div class="col-lg-4 pb-7">
                                <!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<div class="symbol symbol-30px me-4">
											<div class="symbol-label fs-2 fw-bold text-white pointer" style="background-color:#b65edf"><a onclick="ViewOverview('Total');">1</a></div>
										</div>
      									<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Critical</a>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl03Critical" runat="server"></asp:Label></a></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<div class="symbol symbol-30px me-4">
											<div class="symbol-label fs-2 fw-bold text-inverse-info pointer" style="background-color:#da5da8"><a onclick="ViewOverview('Total');">2</a></div>
										</div>
      									<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">High</a>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl03High" runat="server"></asp:Label></a></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<div class="symbol symbol-30px me-4">
											<div class="symbol-label fs-2 fw-bold text-inverse-warning pointer" style="background-color:#e15e5a"><a onclick="ViewOverview('Total');">3</a></div>
										</div>
      									<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Medium</a>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl03Medium" runat="server"></asp:Label></a></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-2">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<div class="symbol symbol-30px me-4">
											<div class="symbol-label fs-2 fw-bold text-inverse-danger pointer" style="background-color:#dd8433"><a onclick="ViewOverview('Total');">4</a></div>
										</div>
      									<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Low</a>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl03Low" runat="server"></asp:Label></a></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<div class="symbol symbol-30px me-4">
											<div class="symbol-label fs-2 fw-bold text-inverse-success pointer" style="background-color:#e3cd09"><a onclick="ViewOverview('Total');">5</a></div>
										</div>
      									<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Lowest</a>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl03Lowest" runat="server"></asp:Label></a></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
                            </div>
                            <div class="col-lg-8">
                                <!--begin::Chart-->
						           <div id="div03Priority" style="height: 270px;"></div>
					            <!--end::Chart-->
                            </div>
                        </div>
						
			        </div>
			        <!--end::Body-->
		        </div>
            </div>
        </div>
                
		<div class="card card-flush mb-5">
			<!--begin::Header-->
			<div class="card-header">
                <!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Ticket</span>
                    <span class="text-muted fw-bold fs-6"">Per Implementer (Status)</span>
				</h3>
				<!--end::Title-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
			<div class="card-body pt-0 pb-0" >
                <div class="row g-5">
                    <div class="col-lg-3 pb-7">
                        <div style="overflow-x:auto; scrollbar-width: thin;height:293px">
                            <asp:GridView ID="gv04ImplementerStatus" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					        <Columns>
						        <asp:TemplateField HeaderText="Open Task">
							        <ItemTemplate>
								        <div class="d-flex align-items-center pl-3">
											<div class="d-flex flex-column w-100">
												<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Name") %></span>
											</div>
                                            <div class="d-flex flex-column min-w-100px me-3">
												<%# Eval("Total") %>
											</div>
										</div>
							        </ItemTemplate>
						        </asp:TemplateField>
					        </Columns>
				        </asp:GridView>
                        </div>
                    </div>
                    <div class="col-lg-9">
                        <!--begin::Chart-->
						<div id="div04ImplementerStatus" style="height: 270px;"></div>
					    <!--end::Chart-->
                    </div>
                </div>
						
			</div>
			<!--end::Body-->
		</div>
			    
		<div class="card card-flush mb-5">
			<!--begin::Header-->
			<div class="card-header">
                <!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Ticket</span>
                    <span class="text-muted fw-bold fs-6"">Per Implementer (Priority)</span>
				</h3>
				<!--end::Title-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
			<div class="card-body pt-0 pb-0" >
                <div class="row g-5">
                    <div class="col-lg-3 pb-7">
                        <div style="overflow-x:auto; scrollbar-width: thin;height:293px">
                            <asp:GridView ID="gv05ImplementerPriority" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					        <Columns>
						        <asp:TemplateField HeaderText="Open Task">
							        <ItemTemplate>
								        <div class="d-flex align-items-center pl-3">
											<div class="d-flex flex-column w-100">
												<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Name") %></span>
											</div>
                                            <div class="d-flex flex-column min-w-100px me-3">
												<%# Eval("Total") %>
											</div>
										</div>
							        </ItemTemplate>
						        </asp:TemplateField>
					        </Columns>
				        </asp:GridView>
                        </div>
                    </div>
                    <div class="col-lg-9">
                        <!--begin::Chart-->
						<div id="div05ImplementerPriority" style="height: 270px;"></div>
					    <!--end::Chart-->
                    </div>
                </div>
						
			</div>
			<!--end::Body-->
		</div>
					
	</div>
    	
	<!-- scripts related to this page -->
    <script type="text/javascript">

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {

            //Total 
            var ltrl01New = '<asp:Literal ID="ltrl01New" runat="server" />';
            var ltrl01Ongoing = '<asp:Literal ID="ltrl01Ongoing" runat="server" />';
            var ltrl01Onhold = '<asp:Literal ID="ltrl01Onhold" runat="server" />';
            var ltrl01Notstarted = '<asp:Literal ID="ltrl01Notstarted" runat="server" />';
            var ltrl01Complete = '<asp:Literal ID="ltrl01Complete" runat="server" />';
            jQuery(function ($) {
                document.getElementById('div01Total').innerHTML = "";
                var element = document.getElementById('div01Total');
                var height = parseInt(KTUtil.css(element, 'height'));
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                const Array01New = ltrl01New.split(",");
                const Array01Ongoing = ltrl01Ongoing.split(",");
                const Array01Onhold = ltrl01Onhold.split(",");
                const Array01Notstarted = ltrl01Notstarted.split(",");
                const Array01Complete = ltrl01Complete.split(",");

                var options = {
                    series: [{
                        name: 'New',
                        data: Array01New
                    }, {
                        name: 'On-Going',
                        data: Array01Ongoing
                    }, {
                        name: 'On-Hold',
                        data: Array01Onhold
                    }, {
                        name: 'Not Started',
                        data: Array01Notstarted
                    }, {
                        name: 'Complete',
                        data: Array01Complete
                    }],
                    chart: {
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var monthVal;
                                if (Month == "<" + yearnow) {
                                    monthVal = yearnow;
                                } else if (Month == "Jan") {
                                    monthVal = 1;
                                } else if (Month == "Feb") {
                                    monthVal = 2;
                                } else if (Month == "Mar") {
                                    monthVal = 3;
                                } else if (Month == "Apr") {
                                    monthVal = 4;
                                } else if (Month == "May") {
                                    monthVal = 5;
                                } else if (Month == "Jun") {
                                    monthVal = 6;
                                } else if (Month == "Jul") {
                                    monthVal = 7;
                                } else if (Month == "Aug") {
                                    monthVal = 8;
                                } else if (Month == "Sep") {
                                    monthVal = 9;
                                } else if (Month == "Oct") {
                                    monthVal = 10;
                                } else if (Month == "Nov") {
                                    monthVal = 11;
                                } else if (Month == "Dec") {
                                    monthVal = 12;
                                } else {
                                    monthVal = 0;
                                }
                                ViewFormsTotal(monthVal, Status);
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '90%',
                            endingShape: 'rounded'
                        },
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
                        categories: ['IT','SD'],
                    },
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + " Tickets"
                            }
                        }
                    },
                    colors: ['#7239ea', '#009ef7', '#ffc700', '#f1416c', '#279852'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    height: "270px"
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            //Total

            //Department
            var ltrl02Code = '<asp:Literal ID="ltrl02Code" runat="server" />';
            var ltrl02Value = '<asp:Literal ID="ltrl02Value" runat="server" />';
            var ltrl02Color = '<asp:Literal ID="ltrl02Color" runat="server" />';
            var ltrl02Name = '<asp:Literal ID="ltrl02Name" runat="server" />';
            jQuery(function ($) {
                document.getElementById('div02Department').innerHTML = "";
                var element = document.getElementById('div02Department');
                const Array02Code = ltrl02Code.split(",");
                const Array02Value = ltrl02Value.split(",");
                const Array02Color = ltrl02Color.split(",");
                const Array02Name = ltrl02Name.split(",");
                const newArray02Value = Array02Value.map(Number);
                if (!element) {
                    return;
                }
                var options = {
                    series: newArray02Value,
                    chart: {
                        type: 'donut', events:
                        {
                            dataPointSelection: function (event, chartContext, config) {
                                const currPos = config.dataPointIndex;
                                const Status = config.w.config.labels[config.dataPointIndex];
                                //ViewWARDivisionStatus('Laguna', Status)
                                $.ajax({
                                    type: "POST",
                                    url: "HND000003.ashx",
                                    data: {
                                        'FormCode': 'DSB030000',
                                        'Type': 'Aging Form Per Department',
                                        'DeptCode': Array02Code[currPos]
                                    },
                                    success: function (response) {
                                        Display_Aging(response);
                                    },
                                });
                            }
                        },
                    },
                    plotOptions:
                    {
                        pie:
                        {
                            donut:
                            {
                                size: '0%',
                                labels:
                                {
                                    value:
                                    {
                                        fontSize: '10px'
                                    }
                                }
                            }
                        }
                    },
                    labels: Array02Name,
                    legend: {
                        show: false,
                    },
                    colors: Array02Color,
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
			//Department

            //Priority
            var ltrl03Critical = '<asp:Literal ID="ltrl03Critical" runat="server" />';
            var ltrl03High = '<asp:Literal ID="ltrl03High" runat="server" />';
            var ltrl03Medium = '<asp:Literal ID="ltrl03Medium" runat="server" />';
            var ltrl03Low = '<asp:Literal ID="ltrl03Low" runat="server" />';
            var ltrl03Lowest = '<asp:Literal ID="ltrl03Lowest" runat="server" />';
            jQuery(function ($) {
                document.getElementById('div03Priority').innerHTML = "";
                var element = document.getElementById('div03Priority');
                var height = parseInt(KTUtil.css(element, 'height'));
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                const Array03Critical = ltrl03Critical.split(",");
                const Array03High = ltrl03High.split(",");
                const Array03Medium = ltrl03Medium.split(",");
                const Array03Low = ltrl03Low.split(",");
                const Array03Lowest = ltrl03Lowest.split(",");

                var options = {
                    series: [{
                        name: 'Critical',
                        data: Array03Critical
                    }, {
                        name: 'High',
                        data: Array03High
                    }, {
                        name: 'Medium',
                        data: Array03Medium
                    }, {
                        name: 'Low',
                        data: Array03Low
                    }, {
                        name: 'Lowest',
                        data: Array03Lowest
                    }],
                    chart: {
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var monthVal;
                                if (Month == "<" + yearnow) {
                                    monthVal = yearnow;
                                } else if (Month == "Jan") {
                                    monthVal = 1;
                                } else if (Month == "Feb") {
                                    monthVal = 2;
                                } else if (Month == "Mar") {
                                    monthVal = 3;
                                } else if (Month == "Apr") {
                                    monthVal = 4;
                                } else if (Month == "May") {
                                    monthVal = 5;
                                } else if (Month == "Jun") {
                                    monthVal = 6;
                                } else if (Month == "Jul") {
                                    monthVal = 7;
                                } else if (Month == "Aug") {
                                    monthVal = 8;
                                } else if (Month == "Sep") {
                                    monthVal = 9;
                                } else if (Month == "Oct") {
                                    monthVal = 10;
                                } else if (Month == "Nov") {
                                    monthVal = 11;
                                } else if (Month == "Dec") {
                                    monthVal = 12;
                                } else {
                                    monthVal = 0;
                                }
                                ViewFormsTotal(monthVal, Status);
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '90%',
                            endingShape: 'rounded'
                        },
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
                        categories: ['Critical', 'High', 'Medium', 'Low', 'Lowest'],
                    },
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + " Tickets"
                            }
                        }
                    },
                    colors: ['#b65edf', '#da5da8', '#e15e5a', '#dd8433', '#e3cd09'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    height: "270px"
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
			//Priority

            //Implementer - Status 
            var ltrl04Name = '<asp:Literal ID="ltrl04Name" runat="server" />';
            var ltrl04Ongoing = '<asp:Literal ID="ltrl04Ongoing" runat="server" />';
            var ltrl04Onhold = '<asp:Literal ID="ltrl04Onhold" runat="server" />';
            var ltrl04Notstarted = '<asp:Literal ID="ltrl04Notstarted" runat="server" />';
            var ltrl04Complete = '<asp:Literal ID="ltrl04Complete" runat="server" />';
            jQuery(function ($) {
                document.getElementById('div04ImplementerStatus').innerHTML = "";
                var element = document.getElementById('div04ImplementerStatus');
                var height = parseInt(KTUtil.css(element, 'height'));
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                const Array04Name = ltrl04Name.split(",");
                const Array04Ongoing = ltrl04Ongoing.split(",");
                const Array04Onhold = ltrl04Onhold.split(",");
                const Array04Notstarted = ltrl04Notstarted.split(",");
                const Array04Complete = ltrl04Complete.split(",");

                var options = {
                    series: [{
                        name: 'On-Going',
                        data: Array04Ongoing
                    }, {
                        name: 'On-Hold',
                        data: Array04Onhold
                    }, {
                        name: 'Not Started',
                        data: Array04Notstarted
                    }, {
                        name: 'Complete',
                        data: Array04Complete
                    }],
                    chart: {
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var monthVal;
                                if (Month == "<" + yearnow) {
                                    monthVal = yearnow;
                                } else if (Month == "Jan") {
                                    monthVal = 1;
                                } else if (Month == "Feb") {
                                    monthVal = 2;
                                } else if (Month == "Mar") {
                                    monthVal = 3;
                                } else if (Month == "Apr") {
                                    monthVal = 4;
                                } else if (Month == "May") {
                                    monthVal = 5;
                                } else if (Month == "Jun") {
                                    monthVal = 6;
                                } else if (Month == "Jul") {
                                    monthVal = 7;
                                } else if (Month == "Aug") {
                                    monthVal = 8;
                                } else if (Month == "Sep") {
                                    monthVal = 9;
                                } else if (Month == "Oct") {
                                    monthVal = 10;
                                } else if (Month == "Nov") {
                                    monthVal = 11;
                                } else if (Month == "Dec") {
                                    monthVal = 12;
                                } else {
                                    monthVal = 0;
                                }
                                ViewFormsTotal(monthVal, Status);
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '90%',
                            endingShape: 'rounded'
                        },
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
                        categories: Array04Name,
                    },
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + " Tickets"
                            }
                        }
                    },
                    colors: ['#009ef7', '#ffc700', '#f1416c', '#279852'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    height: "270px"
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            //Implementer - Status

            //Implementer - Priority 
            var ltrl05Name = '<asp:Literal ID="ltrl05Name" runat="server" />';
            var ltrl05Critical = '<asp:Literal ID="ltrl05Critical" runat="server" />';
            var ltrl05High = '<asp:Literal ID="ltrl05High" runat="server" />';
            var ltrl05Medium = '<asp:Literal ID="ltrl05Medium" runat="server" />';
            var ltrl05Low = '<asp:Literal ID="ltrl05Low" runat="server" />';
            var ltrl05Lowest = '<asp:Literal ID="ltrl05Lowest" runat="server" />';
            jQuery(function ($) {
                document.getElementById('div05ImplementerPriority').innerHTML = "";
                var element = document.getElementById('div05ImplementerPriority');
                var height = parseInt(KTUtil.css(element, 'height'));
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                const Array05Name = ltrl05Name.split(",");
                const Array05Critical = ltrl05Critical.split(",");
                const Array05High = ltrl05High.split(",");
                const Array05Medium = ltrl05Medium.split(",");
                const Array05Low = ltrl05Low.split(",");
                const Array05Lowest = ltrl05Lowest.split(",");

                var options = {
                    series: [{
                        name: 'Critical',
                        data: Array05Critical
                    }, {
                        name: 'High',
                        data: Array05High
                    }, {
                        name: 'Medium',
                        data: Array05Medium
                    }, {
                        name: 'Low',
                        data: Array05Low
                    }, {
                        name: 'Lowest',
                        data: Array05Lowest
                    }],
                    chart: {
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var monthVal;
                                if (Month == "<" + yearnow) {
                                    monthVal = yearnow;
                                } else if (Month == "Jan") {
                                    monthVal = 1;
                                } else if (Month == "Feb") {
                                    monthVal = 2;
                                } else if (Month == "Mar") {
                                    monthVal = 3;
                                } else if (Month == "Apr") {
                                    monthVal = 4;
                                } else if (Month == "May") {
                                    monthVal = 5;
                                } else if (Month == "Jun") {
                                    monthVal = 6;
                                } else if (Month == "Jul") {
                                    monthVal = 7;
                                } else if (Month == "Aug") {
                                    monthVal = 8;
                                } else if (Month == "Sep") {
                                    monthVal = 9;
                                } else if (Month == "Oct") {
                                    monthVal = 10;
                                } else if (Month == "Nov") {
                                    monthVal = 11;
                                } else if (Month == "Dec") {
                                    monthVal = 12;
                                } else {
                                    monthVal = 0;
                                }
                                ViewFormsTotal(monthVal, Status);
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '90%',
                            endingShape: 'rounded'
                        },
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
                        categories: Array05Name,
                    },
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + " Tickets"
                            }
                        }
                    },
                    colors: ['#b65edf', '#da5da8', '#e15e5a', '#dd8433', '#e3cd09'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    height: "270px"
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            //Implementer - Priority

        }
        //load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
