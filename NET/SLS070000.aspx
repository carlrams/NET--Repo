<%@ Page Title="Group Sales" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS070000.aspx.vb" Inherits="NET.SLS070000" MaintainScrollPositionOnPostback = "true" %>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Sales Admin</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Group Sales</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Toolbar-->
				<div class="d-flex flex-wrap flex-stack">
					<!--begin::Controls-->
					<div class="d-flex flex-wrap my-1">
						<!--begin::Tab nav-->
						<ul class="nav nav-pills me-5">
							<li class="nav-item m-0">
								<a href="SLS050000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Sales Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-clipboard2-data" viewBox="0 0 16 16">
										  <path d="M9.5 0a.5.5 0 0 1 .5.5.5.5 0 0 0 .5.5.5.5 0 0 1 .5.5V2a.5.5 0 0 1-.5.5h-5A.5.5 0 0 1 5 2v-.5a.5.5 0 0 1 .5-.5.5.5 0 0 0 .5-.5.5.5 0 0 1 .5-.5z"/>
										  <path d="M3 2.5a.5.5 0 0 1 .5-.5H4a.5.5 0 0 0 0-1h-.5A1.5 1.5 0 0 0 2 2.5v12A1.5 1.5 0 0 0 3.5 16h9a1.5 1.5 0 0 0 1.5-1.5v-12A1.5 1.5 0 0 0 12.5 1H12a.5.5 0 0 0 0 1h.5a.5.5 0 0 1 .5.5v12a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5z"/>
										  <path d="M10 7a1 1 0 1 1 2 0v5a1 1 0 1 1-2 0zm-6 4a1 1 0 1 1 2 0v1a1 1 0 1 1-2 0zm4-3a1 1 0 0 0-1 1v3a1 1 0 1 0 2 0V9a1 1 0 0 0-1-1"/>
										</svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="SLS060000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Seller's Ranking" >
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-diagram-3" viewBox="0 0 16 16">
										  <path fill-rule="evenodd" d="M6 3.5A1.5 1.5 0 0 1 7.5 2h1A1.5 1.5 0 0 1 10 3.5v1A1.5 1.5 0 0 1 8.5 6v1H14a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-1 0V8h-5v.5a.5.5 0 0 1-1 0V8h-5v.5a.5.5 0 0 1-1 0v-1A.5.5 0 0 1 2 7h5.5V6A1.5 1.5 0 0 1 6 4.5zM8.5 5a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5zM0 11.5A1.5 1.5 0 0 1 1.5 10h1A1.5 1.5 0 0 1 4 11.5v1A1.5 1.5 0 0 1 2.5 14h-1A1.5 1.5 0 0 1 0 12.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5zm4.5.5A1.5 1.5 0 0 1 7.5 10h1a1.5 1.5 0 0 1 1.5 1.5v1A1.5 1.5 0 0 1 8.5 14h-1A1.5 1.5 0 0 1 6 12.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5zm4.5.5a1.5 1.5 0 0 1 1.5-1.5h1a1.5 1.5 0 0 1 1.5 1.5v1a1.5 1.5 0 0 1-1.5 1.5h-1a1.5 1.5 0 0 1-1.5-1.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5z"/>
										</svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="SLS070000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Group Sales" >
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-people" viewBox="0 0 16 16">
										  <path d="M15 14s1 0 1-1-1-4-5-4-5 3-5 4 1 1 1 1zm-7.978-1L7 12.996c.001-.264.167-1.03.76-1.72C8.312 10.629 9.282 10 11 10c1.717 0 2.687.63 3.24 1.276.593.69.758 1.457.76 1.72l-.008.002-.014.002zM11 7a2 2 0 1 0 0-4 2 2 0 0 0 0 4m3-2a3 3 0 1 1-6 0 3 3 0 0 1 6 0M6.936 9.28a6 6 0 0 0-1.23-.247A7 7 0 0 0 5 9c-4 0-5 3-5 4q0 1 1 1h4.216A2.24 2.24 0 0 1 5 13c0-1.01.377-2.042 1.09-2.904.243-.294.526-.569.846-.816M4.92 10A5.5 5.5 0 0 0 4 13H1c0-.26.164-1.03.76-1.724.545-.636 1.492-1.256 3.16-1.275ZM1.5 5.5a3 3 0 1 1 6 0 3 3 0 0 1-6 0m3-2a2 2 0 1 0 0 4 2 2 0 0 0 0-4"/>
										</svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
						</ul>
						<!--end::Tab nav-->
					</div>
					<!--end::Controls-->
				</div>
				<!--end::Toolbar-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<asp:UpdatePanel ID="upnlDashboard" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
		<ContentTemplate>
			<%-- begin::group sales - reserved --%>
			<div class="col-lg-6">
				<!--begin::Graph-->
				<div class="card card-flush h-lg-100">
					<!--begin::Card header-->
					<div class="card-header mt-3">
						<!--begin::Card title-->
						<div class="card-title flex-column">
							<h3 id="h3RsvChart" runat="server" class="mb-1">Group Sales - Reserved</h3>
							<h3 id="h3BkChart" runat="server" class="mb-1 d-none">Group Sales - Booked</h3>
							<div class="fs-6 fw-bold text-gray-400">Sold units for the <asp:Label ID="lblAgentGroup" runat="server" Text=""></asp:Label> group</div>
						</div>
						<!--end::Card title-->
						<!--begin::Card toolbar-->
						<div class="card-toolbar">
							<%-- begin::Edit Nav --%>
							<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
									<!--begin::Nav item-->
									<li id="liRsvChart" onclick="toggleRsvChart(); return false;" class="nav-item mt-2 ml-5">
										<a href="#aRsvChart" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6 active">
											<div data-bs-toggle="tooltip" data-bs-placement="top" title="Group Sales - Reservation">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-house-gear-fill" viewBox="0 0 16 16">
													<path d="M7.293 1.5a1 1 0 0 1 1.414 0L11 3.793V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v3.293l2.354 2.353a.5.5 0 0 1-.708.708L8 2.207 1.354 8.854a.5.5 0 1 1-.708-.708z"/>
													<path d="M11.07 9.047a1.5 1.5 0 0 0-1.742.26l-.02.021a1.5 1.5 0 0 0-.261 1.742 1.5 1.5 0 0 0 0 2.86 1.5 1.5 0 0 0-.12 1.07H3.5A1.5 1.5 0 0 1 2 13.5V9.293l6-6 4.724 4.724a1.5 1.5 0 0 0-1.654 1.03"/>
													<path d="m13.158 9.608-.043-.148c-.181-.613-1.049-.613-1.23 0l-.043.148a.64.64 0 0 1-.921.382l-.136-.074c-.561-.306-1.175.308-.87.869l.075.136a.64.64 0 0 1-.382.92l-.148.045c-.613.18-.613 1.048 0 1.229l.148.043a.64.64 0 0 1 .382.921l-.074.136c-.306.561.308 1.175.869.87l.136-.075a.64.64 0 0 1 .92.382l.045.149c.18.612 1.048.612 1.229 0l.043-.15a.64.64 0 0 1 .921-.38l.136.074c.561.305 1.175-.309.87-.87l-.075-.136a.64.64 0 0 1 .382-.92l.149-.044c.612-.181.612-1.049 0-1.23l-.15-.043a.64.64 0 0 1-.38-.921l.074-.136c.305-.561-.309-1.175-.87-.87l-.136.075a.64.64 0 0 1-.92-.382ZM12.5 14a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3"/>
												</svg>
											</div>
										<%--<asp:Label ID="lblMasterlistCount" runat="server" class="ml-lg-5 badge badge-secondary ms-1">0</asp:Label>--%>
										</a>
									</li>
									<!--end::Nav item-->
									<!--begin::Nav item-->
									<li id="liBkChart" onclick="toggleBkChart(); return false;" class="nav-item mt-2">
										<a href="#aBkChart" data-bs-toggle="tab" runat="server" class="nav-link text-active-primary py-5 me-6">
											<div data-bs-toggle="tooltip" data-bs-placement="top" title="Group Sales - Booked">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-houses-fill" viewBox="0 0 16 16">
													<path d="M7.207 1a1 1 0 0 0-1.414 0L.146 6.646a.5.5 0 0 0 .708.708L1 7.207V12.5A1.5 1.5 0 0 0 2.5 14h.55a2.5 2.5 0 0 1-.05-.5V9.415a1.5 1.5 0 0 1-.56-2.475l5.353-5.354z"/>
													<path d="M8.793 2a1 1 0 0 1 1.414 0L12 3.793V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v3.293l1.854 1.853a.5.5 0 0 1-.708.708L15 8.207V13.5a1.5 1.5 0 0 1-1.5 1.5h-8A1.5 1.5 0 0 1 4 13.5V8.207l-.146.147a.5.5 0 1 1-.708-.708z"/>
												</svg>
											</div>
										</a>
									</li>
									<!--end::Nav item-->
								</ul>
							<%-- end::Edit Nav --%>
						</div>
						<!--end::Card toolbar-->
					</div>
					<!--end::Card header-->

					<!--begin::Card body-->
					<div class="card-body pt-0 pb-0 px-0">
						<div class="tab-content">
							<div class="tab-pane fade show active" id="aRsvChart">
								<!--begin::Chart-->
								<div id="kt_GSRsv_barchart" class="card-rounded-bottom" style="height: 260px"></div>
								<!--end::Chart-->
							</div>
							<div class="tab-pane fade show" id="aBkChart">
								<!--begin::Chart-->
								<div id="kt_Bksv_barchart" class="card-rounded-bottom" style="height: 260px"></div>
								<!--end::Chart-->
							</div>
						</div>
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Graph-->
			</div>
            <%-- end::group sales - reserved --%>
		</ContentTemplate>
		</asp:UpdatePanel>

        <%-- begin::modals --%>
			<%-- begin::group sales reserved modal --%>
			<div id="mdlGrpSlsRsv" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
					<div class="modal-content modal-rounded">
						<div class="modal-header">
							<h5 class="modal-title">Group Sales - Reserved</h5>
							<!--begin::Close-->
							<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
							<div class="card-toolbar">
								<div class="d-flex flex-stack flex-wrap gap-4">
									<%-- begin::search --%>
									<div class="d-flex align-items-center position-relative my-1">
										<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
										<span class="svg-icon svg-icon-1 position-absolute ms-4">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
										<input id="tbxSearchGrpSlsRsv" type="text" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
									</div>
									<%-- end::search --%>	
								</div>

								<!--begin::Table | Gridview-->
								<div class="card-body py-3">
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<div class="table-responsive overflow-hidden min-h-300px" >
										<!--begin::Table-->
											<table id="gvDisplayGrpSlsRsv" class="table table-row-dashed tscroll table-row-gray-300 table-hover align-middle">
												<!--begin::Table head-->
												<thead>
													<tr>
														<th class="text-dark fw-bold fs-5 min-w-250px">Seller</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Group</th>
														<th class="text-dark fw-bold fs-5 min-w-250px">Buyer</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Project</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Unit</th>
														<th class="text-dark fw-bold fs-5 min-w-150px">TCP</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Status</th>
													</tr>
												</thead>
												<!--end::Table head-->
												<!--begin::Table body-->
												<tbody>

												</tbody>
												<!--end::Table body-->
											</table>
										<!--end::Table-->
									</div>
									</div>
								</div>
								<!--end::Table | Gridview-->
							</div>
						</div>
					</div>
				</div>
			</div>
			<%-- end::group sales reserved modal --%>

			<%-- begin::group sales booked modal --%>
			<div id="mdlGrpSlsBk" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
					<div class="modal-content modal-rounded">
						<div class="modal-header">
							<h5 class="modal-title">Group Sales - Booked</h5>
							<!--begin::Close-->
							<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
							<div class="card-toolbar">
								<div class="d-flex flex-stack flex-wrap gap-4">
									<%-- begin::search --%>
									<div class="d-flex align-items-center position-relative my-1">
										<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
										<span class="svg-icon svg-icon-1 position-absolute ms-4">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
										<input id="tbxSearchGrpSlsBk" type="text" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
									</div>
									<%-- end::search --%>	
								</div>

								<!--begin::Table | Gridview-->
								<div class="card-body py-3">
									<div style="overflow-x:auto; scrollbar-width: thin;">
										<div class="table-responsive overflow-hidden min-h-300px" >
										<!--begin::Table-->
											<table id="gvDisplayGrpSlsBk" class="table table-row-dashed tscroll table-row-gray-300 table-hover align-middle">
												<!--begin::Table head-->
												<thead>
													<tr>
														<th class="text-dark fw-bold fs-5 min-w-250px">Seller</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Group</th>
														<th class="text-dark fw-bold fs-5 min-w-250px">Buyer</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Project</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Unit</th>
														<th class="text-dark fw-bold fs-5 min-w-150px">TCP</th>
														<th class="text-dark fw-bold fs-5 min-w-100px">Status</th>
													</tr>
												</thead>
												<!--end::Table head-->
												<!--begin::Table body-->
												<tbody>

												</tbody>
												<!--end::Table body-->
											</table>
										<!--end::Table-->
									</div>
									</div>
								</div>
								<!--end::Table | Gridview-->
							</div>
						</div>
					</div>
				</div>
			</div>
			<%-- end::group sales booked modal --%>
        <%-- end::modals --%>

    </div>
    <%-- end::Post --%>

	<script type="text/javascript">
        //for bar-chart group sales - reserved
        var ltrlBarGroupSalesDataRsv = '<asp:Literal ID="ltrlBarGroupSalesDataRsv" runat="server" />'
        var ltrlBarGroupSalesNameRsv = '<asp:Literal ID="ltrlBarGroupSalesNameRsv" runat="server" />'
        //for bar-chart group sales - booked
        var ltrlBarGroupSalesDataBk = '<asp:Literal ID="ltrlBarGroupSalesDataBk" runat="server" />'
        var ltrlBarGroupSalesNameBk = '<asp:Literal ID="ltrlBarGroupSalesNameBk" runat="server" />'

        //link button
        function toggleRsvChart() {
            $('#<%= h3RsvChart.ClientID %>').removeClass('d-none');
			$('#<%= h3BkChart.ClientID %>').addClass('d-none');
		}
        function toggleBkChart() {
            $('#<%= h3RsvChart.ClientID %>').addClass('d-none');
            $('#<%= h3BkChart.ClientID %>').removeClass('d-none');
        }

        //View reserved sales per group - modal
        function ViewGroupSalesRsv(RsvGrp) {
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS070000',
                    'Type': 'View Group Sales (RsvGrp)',
                    'RsvGrp': RsvGrp
                },
                success: function (response) {
                    DisplayGroupSalesRsv(response)
                },
                error: function (error) {
                    // Handle error
                    console.log("Error:", error);
                }
            });
        }
        function DisplayGroupSalesRsv(response) {
            //datatable
            var gvDisplayGrpSlsRsv = $("#gvDisplayGrpSlsRsv").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
                bLengthChange: true,
                lengthMenu: [[5, 10, 20, 30, 40, 50, -1], [5, 10, 20, 30, 40, 50, "All"]],
                scrollY: '300px',
                scrollX: true,
                select: true,
                data: response,
                columns: [
                    { data: 'Seller', class: "min-w-250px" },
                    { data: 'Group', class: "min-w-100px" },
                    { data: 'Buyer', class: "min-w-250px" },
                    { data: 'Project', class: "min-w-100px" },
                    { data: 'Unit', class: "min-w-100px" },
                    { data: 'TCP', class: "min-w-150px" },
                    { data: 'Status', class: "min-w-100px" }]
            });
            //datatable
            //search
            $('#tbxSearchGrpSlsRsv').on('keyup', function () {
                gvDisplayGrpSlsRsv.search(this.value).draw();
            });
            // Show the modal
            $('#mdlGrpSlsRsv').modal('show');
        }

        //View booked sales per group - modal
        function ViewGroupSalesBk(BkGrp) {
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS070000',
                    'Type': 'View Group Sales (BkGrp)',
                    'BkGrp': BkGrp
                },
                success: function (response) {
                    DisplayGroupSalesBk(response)
                },
                error: function (error) {
                    // Handle error
                    console.log("Error:", error);
                }
            });
        }
        function DisplayGroupSalesBk(response) {
            //datatable
            var gvDisplayGrpSlsBk = $("#gvDisplayGrpSlsBk").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
                bLengthChange: true,
                lengthMenu: [[5, 10, 20, 30, 40, 50, -1], [5, 10, 20, 30, 40, 50, "All"]],
                scrollY: '300px',
                scrollX: true,
                select: true,
                data: response,
                columns: [
                    { data: 'Seller', class: "min-w-250px" },
                    { data: 'Group', class: "min-w-100px" },
                    { data: 'Buyer', class: "min-w-250px" },
                    { data: 'Project', class: "min-w-100px" },
                    { data: 'Unit', class: "min-w-100px" },
                    { data: 'TCP', class: "min-w-150px" },
                    { data: 'Status', class: "min-w-100px" }]
            });
            //datatable
            //search
            $('#tbxSearchGrpSlsBk').on('keyup', function () {
                gvDisplayGrpSlsBk.search(this.value).draw();
            });
            // Show the modal
            $('#mdlGrpSlsBk').modal('show');
        }

        //page load script ------------------------------------------------------------------------------------------------------------------------
        function pageLoad(sender, args) { InitializeSettings(); }
		function InitializeSettings() {

			//group sales bar-chart reserved ----------------------------------------------------------------------------------------------
			jQuery(function ($) {
                var element = document.getElementById("kt_GSRsv_barchart");

				var height = parseInt(KTUtil.css(element, 'height'));
				var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
				var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
				var baseColor = KTUtil.getCssVariableValue('--bs-primary');
				var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

				const ArrayValueDataRsv = ltrlBarGroupSalesDataRsv.split(",")
                const ArrayValueLabelRsv = ltrlBarGroupSalesNameRsv.split(",")

				if (!element) {
					return;
				}

				var options = {
					series: [{
						name: 'Sales',
						data: ArrayValueDataRsv,
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
								var RsvGrp = config.w.config.xaxis.categories[config.dataPointIndex]; 
                                ViewGroupSalesRsv(RsvGrp);
							},
						},
					},
					plotOptions: {
						bar: {
							horizontal: true,
							columnWidth: ['50%'],
							borderRadius: 4
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
						categories: ArrayValueLabelRsv,

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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });  //+ val + " ₱"
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

			//group sales bar-chart booked ----------------------------------------------------------------------------------------------
			jQuery(function ($) {
                var element = document.getElementById("kt_Bksv_barchart");

				var height = parseInt(KTUtil.css(element, 'height'));
				var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
				var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
				var baseColor = KTUtil.getCssVariableValue('--bs-primary');
				var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

				const ArrayValueDataBk = ltrlBarGroupSalesDataBk.split(",")
				const ArrayValueLabelBk = ltrlBarGroupSalesNameBk.split(",")

				if (!element) {
					return;
				}

				var options = {
					series: [{
						name: 'Sales',
                        data: ArrayValueDataBk,
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
                                var BkGrp = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewGroupSalesBk(BkGrp);
							},
						},
					},
					plotOptions: {
						bar: {
							horizontal: true,
							columnWidth: ['50%'],
							borderRadius: 4
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
                        categories: ArrayValueLabelBk,

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
                                return "₱ " + val.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });  //+ val + " ₱"
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

		}

    </script>

</asp:Content>
