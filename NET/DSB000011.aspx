<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000011.aspx.vb" Inherits="NET.DSB000011" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Project</li>
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

		<!--begin::Navbar-->
		<asp:UpdatePanel ID="upnlNavBar" runat="server" UpdateMode="Conditional" class="card mb-6 mb-xl-9">
		<ContentTemplate>
			<div class="card-body pt-9 pb-0">
				<!--begin::Details-->
				<div class="d-flex flex-wrap flex-sm-nowrap mb-6">
					<!--begin::Image-->
					<div class="d-flex flex-center flex-shrink-0 bg-light rounded w-100px h-100px w-lg-150px h-lg-150px me-7 mb-4">
						<img id="imgProject" runat="server" class="mw-125px mw-lg-125px" src="Assets/media/svg/brand-logos/volicity-9.svg" alt="image" />
					</div>
					<!--end::Image-->
					<!--begin::Wrapper-->
					<div class="flex-grow-1">
						<!--begin::Head-->
						<div class="d-flex justify-content-between align-items-start flex-wrap mb-2">
							<!--begin::Details-->
							<div class="d-flex flex-column">
								<!--begin::Status-->
								<div class="d-flex align-items-center mb-1">
									<asp:Label ID="lblProjName" runat="server" class="text-gray-800 fs-2 fw-bolder me-3" Text=""></asp:Label>
								</div>
								<!--end::Status-->
								<!--begin::Description-->
								<div class="d-flex flex-wrap fw-bold mb-4 fs-5 text-gray-400"><asp:Label ID="lblAddress" runat="server"></asp:Label></div>
								<!--end::Description-->
							</div>
							<!--end::Details-->
						</div>
						<!--end::Head-->
						<!--begin::Info-->
						<div class="d-flex flex-wrap justify-content-start">
							<!--begin::Stats-->
							<div class="d-flex flex-wrap">
								<!--begin::Stat-->
								<div class="border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-6 mb-3">
									<!--begin::Number-->
									<div class="d-flex align-items-center">
										<div class="fs-4 fw-bolder"><asp:Label ID="lblLaunchDate" runat="server"></asp:Label></div>
									</div>
									<!--end::Number-->
									<!--begin::Label-->
									<div class="fw-bold fs-6 text-gray-400">Launch Date</div>
									<!--end::Label-->
								</div>
								<!--end::Stat-->
								<!--begin::Stat-->
								<div class="border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-6 mb-3">
									<!--begin::Number-->
									<div class="d-flex align-items-center">
										<!--begin::Svg Icon | path: icons/duotune/arrows/arr065.svg-->
										<span class="svg-icon svg-icon-3 svg-icon-danger me-2">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="11" y="18" width="13" height="2" rx="1" transform="rotate(-90 11 18)" fill="currentColor" />
												<path d="M11.4343 15.4343L7.25 11.25C6.83579 10.8358 6.16421 10.8358 5.75 11.25C5.33579 11.6642 5.33579 12.3358 5.75 12.75L11.2929 18.2929C11.6834 18.6834 12.3166 18.6834 12.7071 18.2929L18.25 12.75C18.6642 12.3358 18.6642 11.6642 18.25 11.25C17.8358 10.8358 17.1642 10.8358 16.75 11.25L12.5657 15.4343C12.2533 15.7467 11.7467 15.7467 11.4343 15.4343Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
										<div id="divTotal" runat="server" class="fs-4 fw-bolder" data-kt-countup="true" >0</div>
									</div>
									<!--end::Number-->
									<!--begin::Label-->
									<div class="fw-bold fs-6 text-gray-400">Open Tasks</div>
									<!--end::Label-->
								</div>
								<!--end::Stat-->
							</div>
							<!--end::Stats-->
							<!--begin::Users-->
							<div id="divPE" runat="server" class="symbol-group symbol-hover mb-3">
								
							</div>
							<!--end::Users-->
						</div>
						<!--end::Info-->
					</div>
					<!--end::Wrapper-->
				</div>
				<!--end::Details-->
				<div class="separator"></div>
				<!--begin::Nav-->
				<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
					<!--begin::Nav item-->
					<li class="nav-item">
						<a id="aOverview" runat="server" class="nav-link text-active-primary py-5 me-6 active">Overview</a>
					</li>
					<!--end::Nav item-->
					<!--begin::Nav item-->
					<li class="nav-item">
						<a id="aMap" runat="server" class="nav-link text-active-primary py-5 me-6">Map</a>
					</li>
					<!--end::Nav item-->
				</ul>
				<!--end::Nav-->
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Navbar-->

		<!--begin::Row-->
		<div class="row g-5 mb-5">
			<!--begin::Col-->
			<div class="col-lg-6">
				<!--begin::Card-->
				<div class="card h-100 card-flush mb-5">
                    <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Current Construction</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARStatus('All')"><asp:Label ID="lblActiveTask" runat="server" Text="0 Units"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
					<!--begin::Card body-->
					<div class="card-body p-0 pl-5">
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap">
                            <!--begin::Chart-->
							<div class="d-flex flex-center h-300px w-300px mb-5">
                                <div id="pie_chart" ></div>
							</div>
							<!--end::Chart-->
                            <!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-warning me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARStatus('On-time')">On-time</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieOntime" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-danger me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARStatus('Delayed')">Delayed</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieDelayed" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-info me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARStatus('Not yet started')">Not yet started</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblPieNotYetStarted" runat="server" Text="0"></asp:Label></div>
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
			<!--end::Col-->
			<!--begin::Col-->
			<div class="col-lg-6">
				<!--begin::Graph-->
				<div class="card card-flush h-lg-100 mb-5">
					<!--begin::Card header-->
					<div class="card-header">
						<!--begin::Card title-->
						<h3 class="card-title flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Assigned Project Engineer</span>
							<!--begin::Labels-->
							<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold">
                                <!--begin::Label-->
						        <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARStatus('On-time')">
							        <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-warning"></span></span>On-time
						        </a>
						        <!--end::Label-->
                                <!--begin::Label-->
						        <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARStatus('Delayed')">
							        <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-danger"></span></span>Delayed
						        </a>
						        <!--end::Label-->
                                <!--begin::Label-->
						        <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARStatus('Not yet started')">
							        <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-info"></span></span>Not yet started
						        </a>
						        <!--end::Label-->
                                <!--begin::Label-->
						        <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARStatus('All')">
							        <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-primary"></span></span>All
						        </a>
						        <!--end::Label-->
							</div>
							<!--end::Labels-->
						</h3>
						<!--end::Card title-->
					</div>
					<!--end::Card header-->
					<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Chart-->
						<div id="bar_chart" class="card-rounded-bottom" style="height: 260px"></div>
						<!--end::Chart-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Graph-->
			</div>
			<!--end::Col-->
		</div>
		<!--end::Row-->

        <!--begin::Card-->
		<div class="card card-flush">
			<!--begin::Card body-->
			<div class="card-body">
				<!--begin::toolbar-->
				<div class="d-flex flex-stack align-items-center me-5">
					<!--begin::Search-->
					<div class="d-flex align-items-center position-relative my-1">
						<span class="svg-icon svg-icon-2 position-absolute left-20">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor"/>
								<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor"/>
							</svg>
						</span>
						<input id="tbxSearch01" type="text" class="form-control form-control-solid w-250px ps-15" placeholder="Search Record"/>	
					</div>
					<!--end::Search-->
                    <!--begin::Export buttons-->
                    <div id="divExportButton" class="d-none">
                    </div>
                    <!--end::Export buttons-->
                    <!--begin::Export dropdown-->
                    <button type="button" class="btn btn-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
                        Export
                    </button>
                    <!--begin::Menu-->
                    <div id="divDatatableExportMenu01" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-200px py-4" data-kt-menu="true">
                        <div class="menu-item px-3">
                            <a href="#" class="menu-link px-3" data-kt-export="copy">Copy to clipboard</a>
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
                    <!--end::Export dropdown-->
   
				</div>
				<!--end::toolbar-->
				<!--begin::Files-->
				<asp:GridView ID="gvWAR01" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<%# Eval("Bullet") %>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="WO#">
						<ItemTemplate>
							<%# Eval("HWCode") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Territory">
						<ItemTemplate>
							<%# Eval("Territory") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Project">
						<ItemTemplate>
							<%# Eval("Project") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Unit">
						<ItemTemplate>
                            <%# Eval("ModelName") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Status">
						<ItemTemplate>
                            <%# Eval("Status") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Contractor">
						<ItemTemplate>
                            <%# Eval("vendor") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Batch">
						<ItemTemplate>
                            <%# Eval("BatchNo") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Accomplisment">
						<ItemTemplate>
                            <%# Eval("POCRate") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="As of">
						<ItemTemplate>
                            <%# Eval("POCDate") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-75px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Remarks">
						<ItemTemplate>
                            <%# Eval("Remarks") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px"/>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="PE">
						<ItemTemplate>
                            <%# Eval("PE") %>
						</ItemTemplate>
						<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px"/>
					</asp:TemplateField>
				</Columns>
				</asp:GridView>
				<!--end::Files-->
			</div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->

		<!--begin::Modal WAR-->
		<div id="mdlWAR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Weekly Accomplishment Report</h5>
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
					<div class="modal-body">
						<!--begin::toolbar-->
						<div class="d-flex flex-stack align-items-center me-5">
							<!--begin::Search-->
							<div class="d-flex align-items-center position-relative w-md-400px me-md-2">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-2 position-absolute ms-4">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
							</div>
							<!--end::Search-->
                            <!--begin::Export buttons-->
                            <div id="kt_datatable_example_buttons" class="d-none">
                            </div>
                            <!--end::Export buttons-->
                            <!--begin::Export dropdown-->
                           <button type="button" class="btn btn-sm btn-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
                                Export
                           </button>
                           <!--begin::Menu-->
                           <div id="kt_datatable_example_export_menu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-200px py-4" data-kt-menu="true">
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="copy">Copy to clipboard</a>
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
                           <!--end::Export dropdown-->
   
						</div>
						<!--end::toolbar-->
						<!--begin::gridview-->
						<div class="table-responsive overflow-hidden min-h-350px">
							<table id="gvWAR" class="table table-no-border table-row-bordered table-hover align-middle">
								<thead>
                                    <tr>
									    <th>
										
									    </th>
									    <th class="fw-bold fs-6 text-dark min-w-100px">
										    WO#
									    </th>
									    <th class="fw-bold fs-6 text-dark min-w-100px">
										    Territory
									    </th>
									    <th class="fw-bold fs-6 text-dark min-w-150px">
										    Project
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-200px">
										    Unit
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-150px">
										    Status
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-300px">
										    Contractor
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-100px">
										    Batch
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-100px">
										    Accomplisment
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-75px">
										    As of
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-300px">
										    Remarks
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-150px">
										    PE
									    </th>
								    </tr>
								</thead>
                                <tbody>
                                    
                                </tbody>
							</table>
						</div>
						<!--end::gridview-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal WAR-->

	</div>
	<!--end::Post-->
		
	<script type="text/javascript">

		//form variable
		var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
        var ltrlPieOntime = <asp:Literal ID="ltrlPieOntime" runat="server" />;
		var ltrlPieNotYetStarted = <asp:Literal ID="ltrlPieNotYetStarted" runat="server" />;
        var ltrlPieDelayed = <asp:Literal ID="ltrlPieDelayed" runat="server" />;
        var ltrlBarOngoing = '<asp:Literal ID="ltrlBarOngoing" runat="server" />';
        var ltrlBarNotYetStarted = '<asp:Literal ID="ltrlBarNotYetStarted" runat="server" />';
		var ltrlBarDelayed = '<asp:Literal ID="ltrlBarDelayed" runat="server" />';
        var ltrlBarAssigned = '<asp:Literal ID="ltrlBarAssigned" runat="server" />';
        var ltrlBarCategories = '<asp:Literal ID="ltrlBarCategories" runat="server" />';
		//form variable

        //view war
        function ViewWARStatus(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000011',
                    'Type': 'View WAR (Status)',
                    'Project': ltrlID,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Status: " + textStatus); alert("Error: " + errorThrown);
                } 
            });
		}
        function ViewWARStatusPE(Status, PE) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000011',
                    'Type': 'View WAR (Status - PE)',
					'Project': ltrlID,
                    'Status': Status,
                    'PE': PE
                },
                success: function (response) {
                    DisplayWAR(response);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Status: " + textStatus); alert("Error: " + errorThrown);
                } 
            });
        }
        function DisplayWAR(response) {
            //datatable
            var gvWAR = $("#gvWAR").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
				scrollY: '300px',
                scrollX: true,
                fixedColumns: { left: 2 },
                select: true,
                data: response,
                columns: [
                    { data: 'Bullet' },
                    { data: 'HWCode' },
                    { data: 'Territory' },
                    { data: 'Project' },
                    { data: 'ModelName' },
                    { data: 'Status' },
                    { data: 'vendor' },
                    { data: 'BatchNo' },
                    { data: 'POCRate' },
                    { data: 'POCDate' },
                    { data: 'Remarks' },
                    { data: 'PE' }]
            });
            //datatable
            //search
            $('#tbxSearchWAR').on('keyup', function () {
                gvWAR.search(this.value).draw();
            });
            //search
            //export
            const documentTitle = 'Weekly Accomplishment Report';
            var buttons = new $.fn.dataTable.Buttons(gvWAR, {
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
            }).container().appendTo($('#kt_datatable_example_buttons'));
            // Hook dropdown menu click event to datatable export buttons
            const exportButtons = document.querySelectorAll('#kt_datatable_example_export_menu [data-kt-export]');
            exportButtons.forEach(exportButton => {
                exportButton.addEventListener('click', e => {
                    e.preventDefault();

                    // Get clicked export value
                    const exportValue = e.target.getAttribute('data-kt-export');
                    const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                    // Trigger click event on hidden datatable export buttons
                    target.click();
                    console.log(target);
                });
            });
            //export
            $('#mdlWAR').modal('show');
        }
		//view war

		//form load
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                document.getElementById('pie_chart').innerHTML = "";
                var element = document.getElementById('pie_chart');
                if (!element) {
                    return;
                }

                var options = {
                    series: [ltrlPieOntime, ltrlPieDelayed, ltrlPieNotYetStarted],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARPEStatus(Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['On-time', 'Delayed', 'Not yet started'],
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
            jQuery(function ($) {
                var element = document.getElementById('bar_chart');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
				var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                const ArrayOngValueData = ltrlBarOngoing.split(",");
                const ArrayNysValueData = ltrlBarNotYetStarted.split(",");
				const ArrayDelValueData = ltrlBarDelayed.split(",");
                const ArrayAssValueData = ltrlBarAssigned.split(",");
                const ArrayCatValueData = ltrlBarCategories.split(",");
	
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'On-time',
                        data: ArrayOngValueData
                    }, {
                        name: 'Delayed',
                        data: ArrayDelValueData
                    }, {
                        name: 'Not Yet Started',
                        data: ArrayNysValueData
                    }, {
                        name: 'Total',
                        data: ArrayAssValueData
					}],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
						},
						events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Category = config.w.globals.seriesNames[config.seriesIndex];
                                var PE = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewWARStatusPE(Category, PE);
                            },
                        },
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
                        categories: ArrayCatValueData,
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
                    colors: ['#ffc700', '#f1416c', '#009ef7', '#279852'],
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
                //datatable
                var tblWAR = $("#ContentPlaceHolder1_gvWAR01").DataTable({
                    scrollY: "300px",
                    scrollX: true,
                    scrollCollapse: true,
                    bLengthChange: true,
                    lengthMenu: [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
                    bSort: false,
                    bDestroy: true,
                    fixedColumns: {
                        left: 2
                    },
                    select: true,
                });
                //datatable
                //search
                $('#tbxSearch01').on('keyup', function () {
                    tblWAR.search(this.value).draw();
                });
                //search
                //export
                const documentTitle = 'Weekly Accomplishment Report';
                var buttons = new $.fn.dataTable.Buttons(tblWAR, {
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
                }).container().appendTo($('#divExportButton'));
                // Hook dropdown menu click event to datatable export buttons
                const exportButtons = document.querySelectorAll('#divDatatableExportMenu01 [data-kt-export]');
                exportButtons.forEach(exportButton => {
                    exportButton.addEventListener('click', e => {
                        e.preventDefault();

                        // Get clicked export value
                        const exportValue = e.target.getAttribute('data-kt-export');
                        const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                        // Trigger click event on hidden datatable export buttons
                        target.click();
                        console.log(target);
                    });
                });
                    //export
            });
		}
		//form load
    </script>

</asp:Content>
