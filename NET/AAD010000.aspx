<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010000.aspx.vb" Inherits="NET.AAD010000" %>
<%@ MasterType VirtualPath="~/MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<!--begin::Post-->
<div class="content flex-row-fluid" id="kt_content">
	<!--begin::breadcrumb bar-->
	<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">
							<a href="DSB010000" class="text-white text-hover-primary">Apps</a>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Accounts Administration</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Account Transaction</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Dashboard</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::breadcrumb bar-->
	<!--begin::content-->
    <!--begin::Row-->
	<div class="row g-6 g-xl-9 mb-6 mb-xl-9">
		<div class="d-flex flex-column flex-xl-row gap-7 gap-lg-10">
			<!--begin::New Users-->
			<div id="div01NewUsers" runat="server" class="card card-flush py-4 flex-row-fluid overflow-hidden">
				<!--begin::Background-->
				<div class="position-absolute top-0 end-0 opacity-10 pe-none text-end">
					<img src="assets/media/custom/users.png" class="w-200px" alt=""/>
				</div>
				<!--end::Background-->
				<!--begin::Card header-->
				<div class="card-header">
					<div class="card-title">
						<h2>New Users</h2>
					</div>
				</div>
				<!--end::Card header-->
				<!--begin::Card body-->
				<div class="card-body pt-0">
					<!--begin::Row-->
					<div class="row p-0 mb-5 px-9">
						<!--begin::Col-->
						<div class="col">
							<div class="border border-dashed border-gray-300 text-center min-w-125px rounded pt-4 pb-2 my-3">
								<span class="fs-4 fw-bold text-success d-block">New Users</span>
								<span id="span01NewUsers" runat="server"  class="fs-2hx fw-bolder text-gray-900" data-kt-countup="true" data-kt-countup-value="0">0</span>
							</div>
						</div>
						<!--end::Col-->
					</div>
					<!--end::Row-->
				</div>
				<!--end::Card body-->
			</div>
			<!--end::New Users-->
			<!--begin::Total Users-->
			<div id="div01TotalUsers" runat="server" class="card card-flush py-4 flex-row-fluid overflow-hidden">
				<!--begin::Background-->
				<div class="position-absolute top-0 end-0 opacity-10 pe-none text-end">
					<img src="assets/media/custom/users.png" class="w-200px" alt="" />
				</div>
				<!--end::Background-->
				<!--begin::Card header-->
				<div class="card-header">
					<div class="card-title">
						<h2>Total Users</h2>
					</div>
				</div>
				<!--end::Card header-->
				<!--begin::Card body-->
				<div class="card-body pt-0">
					<!--begin::Row-->
					<div class="row p-0 mb-5 px-9">
						<!--begin::Col-->
						<div class="col">
							<div class="border border-dashed border-gray-300 text-center min-w-125px rounded pt-4 pb-2 my-3">
								<span class="fs-4 fw-bold text-success d-block">Total Users</span>
								<span id="span01TotalUsers" runat="server" class="fs-2hx fw-bolder text-gray-900" data-kt-countup="true" data-kt-countup-value="36899">0</span>
							</div>
						</div>
						<!--end::Col-->
					</div>
					<!--end::Row-->
				</div>
				<!--end::Card body-->
			</div>
			<!--end::Total Users-->
		</div>
	</div>
	<!--begin::Total Users Chart-->
	<div class="row g-6 g-xl-9">
		<div id="div01UsersChart" runat="server" class="col-xl-12">
			<div class="card card-xl-stretch mb-3">
				<!--begin::Header-->
				<div class="card-header border-0 pt-5">
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder fs-3 mb-1">Users Per Project</span>
						<span class="text-muted mt-1 fw-bold fs-7"><asp:Label ID="lbl01Date" runat="server"></asp:Label></span>
					</h3>
				</div>
				<!--end::Header-->
				<!--begin::Body-->
				<div class="card-body py-3">
					<!--begin::Chart-->
					<div id="CIISTotalUsers_column_chart" style="height: 300px;"></div>
					<!--end::Chart-->
				</div>
				<!--begin::Body-->
			</div>
		</div>
	</div>
	<!--begin::Total Users Chart-->
	<!--begin::Menu-->
	<asp:UpdatePanel ID="upnlMenu" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
		<ContentTemplate>
			<div class="col-xl-12">
				<div class="card card-xl-stretch mb-3">
					<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Row-->
						<div class="row mb-6">
							<!--begin::Col-->
							<div class="col-lg-4">
								<asp:LinkButton ID="lbtnAAD010500" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
									<div class="card-body d-flex align-items">
										<span class="svg-icon fs-1">
											<img src="assets/media/svg/Custom/remittance.svg" class="me-4 w-30px" alt="" />
										</span>
										<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
											Remittance Slip
										</span>
									</div>
								</asp:LinkButton>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-lg-4">
								<asp:LinkButton ID="lbtnAAD010400" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
									<span id="spanMenuPDCIsNotEmpty" runat="server" class="position-absolute top-0 start-100 translate-middle badge badge-circle badge-primary" visible="false">!</span>
									<div class="card-body d-flex align-items">
										<span class="svg-icon fs-1">
											<img src="assets/media/svg/Custom/pdc.svg" class="me-4 w-30px" alt="" />
										</span>
										<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
											Post Dated Checks
										</span>
									</div>
								</asp:LinkButton>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-lg-4">
								<asp:LinkButton ID="lbtnAAD010300" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
									<div class="card-body d-flex align-items">
										<span class="svg-icon fs-1">
											<img src="assets/media/svg/Custom/inquiry.svg" class="me-4 w-30px" alt="" />
										</span>
										<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
											Request and Inquiry
										</span>
									</div>
								</asp:LinkButton>
							</div>
							<!--end::Col-->
						</div>
						<!--end::Row-->
						<!--begin::Row-->
						<div class="row mb-6">
							<!--begin::Col-->
							<div class="col-lg-4">
								<asp:LinkButton ID="lbtnAAD010600" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
									<div class="card-body d-flex align-items">
										<span class="svg-icon fs-1">
											<img src="assets/media/svg/Custom/requirements.svg" class="me-4 w-30px" alt="" />
										</span>
										<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
											Requirements
										</span>
									</div>
								</asp:LinkButton>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-lg-4">
								<asp:LinkButton ID="lbtnAAD010100" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
									<div class="card-body d-flex align-items">
										<span class="svg-icon fs-1">
											<img src="assets/media/svg/Custom/documentary.svg" class="me-4 w-30px" alt="" />
										</span>
										<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
											Documentary
										</span>
									</div>
								</asp:LinkButton>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-lg-4">
								<asp:LinkButton ID="lbtnAAD010200" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
									<div class="card-body d-flex align-items">
										<span class="svg-icon fs-1">
											<img src="assets/media/svg/Custom/downloadables.svg" class="me-4 w-30px" alt="" />
										</span>
										<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
											Downloadable Templates
										</span>
									</div>
								</asp:LinkButton>
							</div>
							<!--end::Col-->
						</div>
						<!--end::Row-->
					</div>
					<!--end::Card body-->
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--end::Menu-->
	<!--begin::Remittance Slip-->
	<asp:UpdatePanel ID="upnlRequestSummary" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
		<ContentTemplate>
		<div class="col-md-6 col-lg-3 col-xl-6">
			<!--begin::Card-->
			<div class="card h-100">
				<!--begin::Header-->
				<div class="card-header border-0 pt-5">
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder text-dark">Remittance Slip</span>
						<span class="text-muted mt-1 fw-bold fs-7"><asp:Label ID="lbl01RSDate" runat="server"></asp:Label></span>
					</h3>
					<!--begin::Action-->
					<div class="mb-1">
						<asp:LinkButton ID="RSViewDetails" runat="server" class="btn btn-sm btn-success">View Details</asp:LinkButton>
					</div>
					<!--end::Action-->
				</div>
				<!--end::Header-->
				<!--begin::Card body-->
				<div class="card-body d-flex justify-content-center text-center flex-column p-8">
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/pending.svg" class="me-4 w-30px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl01RSPendingTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Pending</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div01RSPendingProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl01RSPendingPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-2">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/approved.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl01RSApprovedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Approved</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div01RSApprovedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl01RSApprovedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					 <!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/declined.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl01RSDeclinedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Declined</span>
								<!--end::Text-->
								<!--begin::Description-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div01RSDeclinedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl01RSDeclinedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
				</div>
				<!--end::Card body-->
			</div>
			<!--end::Card-->
		</div>
		<!--end::Remittance Slip-->
		<!--begin::PDC-->
		<div class="col-md-6 col-lg-4 col-xl-6">
			<!--begin::Card-->
			<div class="card h-100">
				<!--begin::Header-->
				<div class="card-header border-0 pt-5">
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder text-dark">Post Dated Checks</span>
						<span class="text-muted mt-1 fw-bold fs-7"><asp:Label ID="lbl02PDCDate" runat="server"></asp:Label></span>
					</h3>
					<!--begin::Tabs-->
					<ul class="nav nav-stretch nav-pills nav-pills-custom d-flex mt-4">
						<!--begin::Nav item-->
						<li class="nav-item p-0 ms-0">
							<asp:LinkButton ID="lbtnPDCVerified" runat="server" class="nav-link btn btn-color-gray-400 flex-center px-3 position-relative me-5">
								<span class="position-absolute top-0 start-100 translate-middle  badge badge-circle badge-primary"><asp:Label ID="lblPDCForApprovalTotal" runat="server"></asp:Label></span>	
							<%--<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#kt_timeline_widget_4_tab_day">--%>
								<!--begin::Title-->
								<i class="las la-list-alt fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="For Approval"></i>
								<!--end::Title-->
								<!--begin::Bullet-->
								<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
								<!--end::Bullet-->
							<%--</a>--%>
							</asp:LinkButton>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item p-0 ms-0">
							<asp:LinkButton ID="lbtnPDCForVerification" runat="server" class="nav-link btn btn-color-gray-400 flex-center px-3 position-relative me-5">
								<span class="position-absolute top-0 start-100 translate-middle  badge badge-circle badge-success"><asp:Label ID="lblPDCForVerificationTotal" runat="server"></asp:Label></span>	
							<%--<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#kt_timeline_widget_4_tab_week">--%>
								<!--begin::Title-->
								<i class="las la-list fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="For Verification"></i>
								<!--end::Title-->
								<!--begin::Bullet-->
								<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
								<!--end::Bullet-->
							<%--</a>--%>
							</asp:LinkButton>
						</li>
						<!--end::Nav item-->
					</ul>
					<!--end::Tabs-->
					<!--begin::Action-->
					<%--<div class="mb-1">
						<asp:LinkButton ID="lbtnPDCViewDetails" runat="server" class="btn btn-sm btn-success">View Details</asp:LinkButton>
					</div>--%>
					<!--end::Action-->
				</div>
				<!--end::Header-->
				<!--begin::Card body-->
				<div class="card-body d-flex justify-content-center text-center flex-column p-8">
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/pending.svg" class="me-4 w-30px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl02PDCPendingTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Pending</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div02PDCPendingProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl02PDCPendingPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-2">
							<!--begin::Logo-->
							<div class="position-relative me-5">
								<img src="assets/media/svg/Custom/approved.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl02PDCApprovedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Approved</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div02PDCApprovedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl02PDCApprovedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					 <!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-5">
								<img src="assets/media/svg/Custom/declined.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl02PDCDeclinedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Declined</span>
								<!--end::Text-->
								<!--begin::Description-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div02PDCDeclinedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl02PDCDeclinedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
				</div>
				<!--end::Card body-->
			</div>
			<!--end::Card-->
		</div>
		<!--end::PDC-->
		<!--begin::Requirements-->
		<div class="col-md-6 col-lg-4 col-xl-6">
			<!--begin::Card-->
			<div class="card h-100">
				<!--begin::Header-->
				<div class="card-header border-0 pt-5">
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder text-dark">Requirements</span>
						<span class="text-muted mt-1 fw-bold fs-7"><asp:Label ID="lbl03REQDate" runat="server"></asp:Label></span>
					</h3>
					<!--begin::Action-->
					<!--begin::Tabs-->
					<!--end::Tabs-->
					<div class="mb-1">
						<asp:LinkButton ID="lbtnREQViewDetails" runat="server" class="btn btn-sm btn-success">View Details</asp:LinkButton>
					</div>
					<!--end::Action-->
				</div>
				<!--end::Header-->
				<!--begin::Card body-->
				<div class="card-body d-flex justify-content-center text-center flex-column p-8">
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/pending.svg" class="me-4 w-30px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl03REQPendingTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Pending</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div03REQPendingProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl03REQPendingPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-2">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/approved.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl03REQApprovedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Approved</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div03REQApprovedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl03REQApprovedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					 <!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/declined.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl03REQDeclinedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Declined</span>
								<!--end::Text-->
								<!--begin::Description-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div03REQDeclinedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl03REQDeclinedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
				</div>
				<!--end::Card body-->
			</div>
			<!--end::Card-->
		</div>
		<!--end::Requirements-->
		<!--begin::Request and Inquiry-->
		<div class="col-md-6 col-lg-4 col-xl-6">
			<!--begin::Card-->
			<div class="card h-100">
				<!--begin::Header-->
				<div class="card-header border-0 pt-5">
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder text-dark">Request and Inquiry</span>
						<span class="text-muted mt-1 fw-bold fs-7"><asp:Label ID="lbl04INQDate" runat="server"></asp:Label></span>
					</h3>
					<!--begin::Action-->
					<div class="mb-1">
						<asp:LinkButton ID="lbtnINQViewDetails" runat="server" class="btn btn-sm btn-success">View Details</asp:LinkButton>
					</div>
					<!--end::Action-->
				</div>
				<!--end::Header-->
				<!--begin::Card body-->
				<div class="card-body d-flex justify-content-center text-center flex-column p-8">
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/pending.svg" class="me-4 w-30px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl04INQPendingTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Pending</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div04INQPendingProgress" runat="server" class="progress-bar bg-square" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl04INQPendingPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-2">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/approved.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl04INQApprovedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Approved</span>
								<!--end::Text-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div04INQApprovedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl04INQApprovedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					 <!--end::Item-->
					<!--begin::Separator-->
					<div class="separator separator-dashed my-3"></div>
					<!--end::Separator-->
					<!--begin::Item-->
					<div class="d-flex flex-stack">
						<!--begin::Wrapper-->
						<div class="d-flex align-items-center me-3">
							<!--begin::Logo-->
							<div class="position-relative me-8">
								<img src="assets/media/svg/Custom/declined.svg" class="me-4 w-35px" alt="" />
								<span class="position-absolute top-0 start-0 translate-middle badge badge-square badge-success"><asp:Label ID="lbl04INQDeclinedTotal" runat="server"></asp:Label></span>
							</div>
							<!--end::Logo-->
							<!--begin::Section-->
							<div class="flex-grow-1">
								<!--begin::Text-->
								<span class="text-gray-800 fs-5 fw-bolder lh-0">Declined</span>
								<!--end::Text-->
								<!--begin::Description-->
							</div>
							<!--end::Section-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 mw-400px">
							<!--begin::Progress-->
							<div class="progress h-9px w-100 me-2 bg-light-primary">
								<div id="div04INQDeclinedProgress" runat="server" class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span class="text-gray-400 fw-bold"><asp:Label ID="lbl04INQDeclinedPercentage" runat="server"></asp:Label></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
					</div>
					<!--end::Item-->
				</div>
				<!--end::Card body-->
			</div>
			<!--end::Card-->
		</div>
		<!--end::Requirements-->
			</ContentTemplate>
	</asp:UpdatePanel>
	<!--end::Row-->
</div>
<!--end::Post-->

<!--begin::Modal User Total-->
<div id="mdlUsers" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
	    <div class="modal-content">
		    <div class="modal-header">
			    <h5 class="modal-title"><asp:Label ID="lbl01Users" runat="server"></asp:Label></h5>
			    <!--begin::Close-->
			    <div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
				    <span class="svg-icon svg-icon-1">
					    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
						    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
						    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
					    </svg>
				    </span>
			    </div>
			    <!--end::Close-->
		    </div>
		    <div class="modal-body">
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
					    <input id="tbxSearchUsers" type="text" class="form-control form-control-solid w-250px ps-15" placeholder="Search Record"/>	
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
							 <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
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
			    <div class="table-responsive">
				    <table id="gvUsers" class="table table-no-border table-row-bordered table-hover">
					    <thead>
							<tr>
								<th class="fw-bold fs-6 text-dark min-w-150px">
									Account No.
								</th>
								<th class="fw-bold fs-6 text-dark min-w-500px">
									Name
								</th>
								<th class="fw-bold fs-6 text-dark min-w-250px">
									Project
								</th>
								<th class="fw-bold fs-6 text-dark min-w-250px">
									Date Created
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
<!--begin::Modal User Total-->

<!--begin::Modal User Total-->
<div id="mdlPDCMenu" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
	    <div class="modal-content">
		    <div class="modal-header">
			    <h5 class="modal-title"></h5>
			    <!--begin::Close-->
			    <div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
				    <span class="svg-icon svg-icon-1">
					    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
						    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
						    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
					    </svg>
				    </span>
			    </div>
			    <!--end::Close-->
		    </div>
		    <div class="modal-body">
			    <!--begin::Row-->
				<div class="row mb-6">
					<!--begin::Col-->
					<div class="col-lg-4 mb-5">
						<asp:LinkButton ID="lbtnMenuPDCForVerification" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
							<span class="position-absolute top-0 start-100 translate-middle  badge badge-circle badge-primary"><asp:Label ID="lblMenuPDCForVerificationTotal" runat="server"></asp:Label></span>
							<div class="card-body d-flex align-items">
								<span class="svg-icon fs-1">
									<img src="assets/media/svg/Custom/verification.svg" class="me-4 w-30px" alt="" />
								</span>
								<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
									PDC (For Verification)
								</span>
							</div>
						</asp:LinkButton>
					</div>
					<!--end::Col-->
					<!--begin::Col-->
					<div class="col-lg-4 mb-5">
						<asp:LinkButton ID="lbtnMenuPDCForApproval" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
							<span class="position-absolute top-0 start-100 translate-middle  badge badge-circle badge-primary"><asp:Label ID="lblMenuPDCForApprovalTotal" runat="server"></asp:Label></span>
							<div class="card-body d-flex align-items">
								<span class="svg-icon fs-1">
									<img src="assets/media/svg/Custom/approval.svg" class="me-4 w-30px" alt="" />
								</span>
								<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
									PDC (For Approval)
								</span>
							</div>
						</asp:LinkButton>
					</div>
					<!--end::Col-->
					<!--begin::Col-->
					<div class="col-lg-4 mb-5">
						<asp:LinkButton ID="lbtnMenuPDCMonitoring" runat="server" class="card hover-elevate-up shadow-sm parent-hover">
							<div class="card-body d-flex align-items">
								<span class="svg-icon fs-1">
									<img src="assets/media/svg/Custom/monitoring.svg" class="me-4 w-30px" alt="" />
								</span>
								<span class="ms-3 text-gray-700 parent-hover-primary fs-6 fw-bold">
									Monitoring
								</span>
							</div>
						</asp:LinkButton>
					</div>
					<!--end::Col-->
				</div>
				<!--end::Row-->
         
		    </div>
	    </div>
    </div>
</div>
<!--begin::Modal User Total-->

<!--scripts related to this page -->
<script type="text/javascript">      

	//variables
    var ltrlTotalUsers = '<asp:Literal ID="ltrlTotalUsers" runat="server" />';
	//variables

	//get user per project
    function ViewUsers(Project) {

        var lbl01Users = $("#ContentPlaceHolder1_lbl01Users");
        lbl01Users.text("Users");

        $.ajax({
            type: "POST",
            url: "/HND000005.ashx",
            data: {
                'FormCode': 'AAD010000',
                'Type': 'UserPerProject',
                'Project': Project
            },
            success: function (response) {
                DisplayUsers(response);
            },
        });
    }
    //get user per project

	function DisplayUsers(response) {

        //datatable
        var gvUsers = $("#gvUsers").DataTable({

            scrollY: false,
            scrollX: true,
            scrollCollapse: true,
            bLengthChange: true,
            lengthMenu: [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
            bSort: false,
            bDestroy: true,
            data: response,
            columns: [
				{ data: 'Acct' },
                { data: 'Name' },
                { data: 'Project' },
                { data: 'Date' }]
        });
        //datatable

        //search
        $('#tbxSearchUsers').on('keyup', function () {
            gvUsers.search(this.value).draw();
        });
        //search

        //export
        const documentTitle = 'User Per Project';
        var buttons = new $.fn.dataTable.Buttons(gvUsers, {
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
        $('#mdlUsers').modal('show');
    }
	//view forms total

    //chart
    jQuery(function ($) {
        var element = document.getElementById('CIISTotalUsers_column_chart');
        var height = parseInt(KTUtil.css(element, 'height'));
        var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
        var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
        var baseColor = KTUtil.getCssVariableValue('--bs-primary');
        var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

        const ArrayTotalUsers = ltrlTotalUsers.split(",");

		console.log(ArrayTotalUsers);

        var options = {
            series: [{
                name: 'Total',
				data: ArrayTotalUsers
            }],
            chart: {
                type: 'bar',
                height: 350,
                toolbar: {
                    show: false
                },
                events: {
                    dataPointSelection: function (event, chartContext, config) {
                        const categories = config.w.config.xaxis.categories;
                        const Project = categories[config.dataPointIndex];
                        ViewUsers(Project);
                    }
                }
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: '40%',
					endingShape: 'rounded',
					dataLabels: {
                        position: 'top',
                    },
                },
            },
            dataLabels: {
				enabled: true,
                offsetY: -25,
                style: {
                    fontSize: '12px',
                    colors: ["#304758"]
                }

            },
            stroke: {
                show: true,
                width: 2,
                colors: ['transparent']
            },
            xaxis: {
                categories: ['BW', 'CBH', 'CH', 'CHD', 'CHN', 'CASA', 'CG', 'CM', 'COH', 'IL', 'LCR', 'LRT', 'LM', 'NCE', 'NEV', 'PS', 'PV', 'PREA', 'PRIS', 'PROP', 'SLH', 'SON', 'SOR', 'SBW', 'TML', 'TV'],
            },
            yaxis: {
                title: {
                    text: 'Total Users Per Project'
                }
            },
            fill: {
                opacity: 1
            },
            tooltip: {
                y: {
                    formatter: function (val) {
                        return val + " Users"
                    }
                }
            },
            colors: ['#279852'],
            grid: {
                borderColor: borderColor,
                strokeDashArray: 4,
                yaxis: {
                    lines: {
                        show: true
                    }
                }
            },
        };

        var chart = new ApexCharts(element, options);
        chart.render();
	})
    //chart

</script>
<!-- scripts related to this page -->

</asp:Content>
