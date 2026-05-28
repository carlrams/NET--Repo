<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000012.aspx.vb" Inherits="NET.DSB000012" MaintainScrollPositionOnPostback = "true" %>
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
		<asp:UpdatePanel ID="upnlNavBar" runat="server" UpdateMode="Conditional" class="card mb-5">
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
						<a id="aOverview" runat="server" class="nav-link text-active-primary py-5 me-6">Overview</a>
					</li>
					<!--end::Nav item-->
					<!--begin::Nav item-->
					<li class="nav-item">
						<a id="aMap" runat="server" class="nav-link text-active-primary py-5 me-6 active">Map</a>
					</li>
					<!--end::Nav item-->
				</ul>
				<!--end::Nav-->
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Navbar-->

		<div class="row g-5">
			<!--begin::Content-->
			<asp:UpdatePanel ID="upnlContent" runat="server" UpdateMode="Conditional" class="col-lg-9">
			<ContentTemplate>
				<div class="card h-md-100">
					<div class="card-body pb-5">
						<div class="canvascontainer">
							<div class="mapcontainer">
								<div class="map border-radius-047rem"></div>
							</div>
						</div>
					</div>
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::Content-->
			<!--begin::Sidebar-->
			<asp:UpdatePanel ID="upnlMenu" runat="server" UpdateMode="Conditional" class="col-lg-3">
			<ContentTemplate>
				<!--begin::Sticky aside-->
				<div class="card h-100 card-flush" data-kt-sticky="false" data-kt-sticky-name="inbox-aside-sticky" data-kt-sticky-offset="{default: false, xl: '0px'}" data-kt-sticky-width="{lg: '275px'}" data-kt-sticky-left="auto" data-kt-sticky-top="150px" data-kt-sticky-animation="false" data-kt-sticky-zindex="95">
					<!--begin::Aside content-->
					<div class="card-body">
						<div class="card-title fs-5 fw-bolder">legend</div>
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap mb-5">
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#83E2E9"></div>
									<div class="text-gray-400">Newly Endorsed</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsNewlyEndorsed" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#619FFC"></div>
									<div class="text-gray-400">For Budget</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsForCosting" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#A777C9"></div>
									<div class="text-gray-400">For Budget</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsForBudget" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#ED7DB1"></div>
									<div class="text-gray-400">For Award</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsForAward" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#6991A7"></div>
									<div class="text-gray-400">Awarded</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsAwarded" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#F8C22D"></div>
									<div class="text-gray-400">On-Going</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsOnGoing" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#43BF57"></div>
									<div class="text-gray-400">Completed</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsCompleted" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#ADD43C"></div>
									<div class="text-gray-400">On-Hold</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsOnHold" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet w-15px h-15px me-3" style="background-color:#F2451C"></div>
									<div class="text-gray-400">Cancelled</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblStsCancelled" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
							</div>
						</div>
						<!--end::Wrapper-->
						<div class="card-title fs-5 fw-bolder">Information</div>
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap mb-5">
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="text-gray-400">Project : <span id="spnProject" class="ms-auto fw-bolder text-gray-700">-</span></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="text-gray-400">Unit : <span id="spnUnit" class="ms-auto fw-bolder text-gray-700">-</span></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="text-gray-400">Contractor : <span id="spnContractor" class="ms-auto fw-bolder text-gray-700">-</span></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="text-gray-400">Progress : <span id="spnProgress" class="ms-auto fw-bolder text-gray-700">-</span></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="text-gray-400">Status : <span id="spnStatus" class="ms-auto fw-bolder text-gray-700">-</span></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="text-gray-400">PE : <span id="spnPE" class="ms-auto fw-bolder text-gray-700">-</span></div>
								</div>
								<!--end::Label-->
							</div>
							
						</div>
						<!--end::Wrapper-->
					</div>
					<!--end::Aside content-->
				</div>
				<!--end::Sticky aside-->
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::Sidebar-->
		</div>

	</div>
	<!--end::Post-->
		
	<script type="text/javascript">
		var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
    </script>

</asp:Content>
