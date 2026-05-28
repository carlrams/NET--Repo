<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB010000.aspx.vb" Inherits="NET.DSB010000" MaintainScrollPositionOnPostback = "true"%>
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
						<li class="breadcrumb-item text-white">Home</li>
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

		<div class="row g-5 mb-5">
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3 ml-auto">
				<div class="card">
					<div class="card-body">
						<div class="d-flex flex-stack mb-5">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/FRM.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-gray-900 fw-boldest fs-5">Form</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblCntFRM" runat="server" CssClass="badge badge-light badge-square badge-lg me-3" Text="0"></asp:Label>
							</div>
						</div>
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap mb-5">
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pl-10 pr-10">
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_FRM_Summary('Endorsed By')">
                                    <div class="text-gray-400">Endorsement</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_FRM_Endorsement" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_FRM_Summary('Approved By')">
                                    <div class="text-gray-400">Approval</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_FRM_Approval" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_FRM_Summary('Implementer')">
                                    <div class="text-gray-400">Implementation</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_FRM_Implementation" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_FRM_Summary('Clarification')">
                                    <div class="text-gray-400">Clarification</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_FRM_Clarification" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_FRM_Summary('Creator')">
                                    <div class="text-gray-400">For Cancellation</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_FRM_ForCancellation" runat="server" Text="0"></asp:Label></div>
								</a>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
						</div>
						<!--end::Wrapper-->
						<div class="m-0 d-flex flex-column-fluid flex-center">
							<a href='FRM010000' class="btn btn-sm btn-success w-100px me-2">View More</a>
							<a class="btn btn-sm btn-success pointer w-100px" data-bs-toggle="modal" data-bs-target="#mdlFRM" title="Create Form">Create</a>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3 mr-auto">
				<div class="card">
					<div class="card-body">
						<div class="d-flex flex-stack mb-5">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/WRK010000.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-gray-900 fw-boldest fs-5">Work Order</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblCntWO" runat="server" CssClass="badge badge-light badge-square badge-lg me-3" Text="0"></asp:Label>
							</div>
						</div>

						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap mb-5">
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pl-10 pr-10">
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_WO_Summary('Assigned')">
                                    <div class="text-gray-400">Assigned</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_WO_Assigned" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_WO_Summary('Accepted')">
                                    <div class="text-gray-400">Accepted</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_WO_Accepted" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_WO_Summary('Completed')">
                                    <div class="text-gray-400">Completed</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_WO_Completed" runat="server" Text="0"></asp:Label></div>
								</a>
								<a class="d-flex fs-6 fw-bold align-items-center mb-3 pointer" onclick="View_WO_Summary('Clarification')">
                                    <div class="text-gray-400">Clarification</div>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblCnt_WO_Clarify" runat="server" Text="0"></asp:Label></div>
								</a>
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
                                    <div class="text-gray-400">&nbsp;</div>

								</div>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
						</div>
						<!--end::Wrapper-->
						<div class="m-0 d-flex flex-column-fluid flex-center">
							<a href='WRK010000' class="btn btn-sm btn-success w-100px me-2">View More</a>
							<a href='FRM000001-ADD-0000000000000' class="btn btn-sm btn-success pointer w-100px">Create</a>
						</div>
					</div>
				</div>
			</div>
		</div>

		<div class="row g-5 mb-5">
			<div class="col-12">
				<div class="separator separator-content mb-5 mt-5"><span class="badge badge-secondary badge-lg fs-5"><li class="las la-edit"></li> MODULE&nbsp&nbsp</span></div>
			</div>
		</div>

		<div class="row g-5 mb-5">
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/PDD.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Project Development</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlPDD_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntPDD" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlPDD_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlPDD_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/ENG.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Engineering</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlENG_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntENG" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdENG_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlENG_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/SLS.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Sales</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlSLS_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntSLS" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlSLS_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlSLS_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/AAD.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Accounts Administration</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlAAD_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntAAD" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdAAD_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlAAD_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/FIN.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Finance</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlFIN_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntFIN" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlFIN_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlFIN_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/SCM.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Supply Chain Management</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlSCM_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntSCM" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlSCM_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlSCM_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/SCM.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Human Resources Administration</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlHRA_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntHRA" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlHRA_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlHRA_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/CSD.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Customer Service</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlCSD_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntCSD" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlCSD_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlCSD_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3 ml-auto">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/AUD.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Internal Audit</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlAUD_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntAUD" runat="server" CssClass="badge badge-light badge-square badge-lg" Text="0"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlAUD_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlAUD_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/AMD.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Asset</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlAMD_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntAMD" runat="server"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlAMD_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlAMD_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-12 col-sm-6 col-m-3 col-l-3 col-xl-3 mr-auto">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body p-0">
						<div class="px-9 pt-7 card-rounded h-175px w-100 bg-primary">
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px me-3">
									<img src="Assets/media/svg/apps/BTD.svg" alt="" />
								</div>
								<div class="me-5">
									<span class="text-white fw-boldest fs-5">Business Technology</span>
								</div>
							</div>
						</div>
						<div class="bg-body shadow-sm card-rounded mx-9 mb-7 px-6 py-9 position-relative z-index-1" style="margin-top: -100px">
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlBTD_DE">Data Entry</a>
									</div>
									<div class="d-flex align-items-center">
										<asp:Label ID="lblCntBTD" runat="server"></asp:Label>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center mb-3">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M3 2H10C10.6 2 11 2.4 11 3V10C11 10.6 10.6 11 10 11H3C2.4 11 2 10.6 2 10V3C2 2.4 2.4 2 3 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 2H21C21.6 2 22 2.4 22 3V10C22 10.6 21.6 11 21 11H14C13.4 11 13 10.6 13 10V3C13 2.4 13.4 2 14 2Z" fill="currentColor"/>
												<path opacity="0.3" d="M3 13H10C10.6 13 11 13.4 11 14V21C11 21.6 10.6 22 10 22H3C2.4 22 2 21.6 2 21V14C2 13.4 2.4 13 3 13Z" fill="currentColor"/>
												<path opacity="0.3" d="M14 13H21C21.6 13 22 13.4 22 14V21C22 21.6 21.6 22 21 22H14C13.4 22 13 21.6 13 21V14C13 13.4 13.4 13 14 13Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer" data-bs-toggle="modal" data-bs-target="#mdlBTD_PR">Parameter</a>
									</div>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<div class="symbol symbol-30px w-20px me-5">
									<span class="symbol-label bg-lighten">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14V4H6V20H18V8H20V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
									</span>
								</div>
								<div class="d-flex align-items-center flex-wrap w-100">
									<div class="mb-1 pe-3 flex-grow-1">
										<a class="fs-5 text-gray-800 text-hover-primary fw-bolder pointer"  data-bs-toggle="modal" data-bs-target="#mdlBTD_RT">Report</a>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

		<div id="mdlFRM_Summary" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title"><span id="lblFRMTitle"></span></h5>
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
						<!--begin::Files-->
						<div class="table-responsive border rounded h-100">
							<table id="gvFRM_Summary" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
									</tr>
								</thead>
								<tbody id="tbodyFRM_Summary">
									
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>
		
		<div id="mdlWO_Summary" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title"><span id="lblWOTitle"></span></h5>
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
						<!--begin::Files-->
						<div class="table-responsive border rounded h-100">
							<table id="gvWO_Summary" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
									</tr>
								</thead>
								<tbody id="tbodyWO_Summary">
							
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>

		<!--begin::Modal New Form-->
		<div id="mdlFRM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_GEN()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/GEN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">General</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_PDD()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Project Development</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_ENG()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Engineering</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_SLS()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_AAD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AAD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_FIN()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/FIN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Finance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_SCM()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/SCM.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Supply Chain Management</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_HRA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/HRA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Human Resources Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_CSD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_BTD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/BTD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech.</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_ILA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/ILA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Investment and Land Acquisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_AUD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AUD.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Internal Audit</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_AMD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AMD.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Asset</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form-->

		<!--begin::Modal New Form > GEN-->
		<div id="mdlFRM_GEN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > General</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000001-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000037-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order (Contract)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > GEN-->

		<!--begin::Modal New Form > PDD-->
		<div id="mdlFRM_PDD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Project Development</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000027-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000043-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000043.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Holding Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > PDD-->
		
		<!--begin::Modal New Form > ENG-->
		<div id="mdlFRM_ENG" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Engineering</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000019-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000019.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Approval</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000020-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000020.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Information</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000021-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000021.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Site Instruction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000036-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000036.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Survey Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000038-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000038.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Notice of Delay</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000039-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000039.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Non Conformance Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000022-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000022.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Construction Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000023-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000023.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electrical Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000024-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000024.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request for RFO Keys</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000013-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Occupancy Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000025-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000025.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > ENG-->
		
		<!--begin::Modal New Form > SLS-->
		<div id="mdlFRM_SLS" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Sales</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000028-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000028.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000029-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000029.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Request Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > SLS-->
		
		<!--begin::Modal New Form > AAD-->
		<div id="mdlFRM_AAD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Accounts Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000030-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000030.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Activity Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000031-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000031.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Cash Remittance Verification Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000032-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transfer of Title Routing Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000042-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000042.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT-HDMF DOA Annotation Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > AAD-->
		
		<!--begin::Modal New Form > FIN-->
		<div id="mdlFRM_FIN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Finance</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000018-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000018.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Capital Expenditure Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000015-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000033-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000033.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Billing</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000017-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000017.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payment Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000016-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000016.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Petty Cash</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > FIN-->
		
		<!--begin::Modal New Form > SCM-->
		<div id="mdlFRM_SCM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Supply Chain Management</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000009-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000010-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Purchase Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > SCM-->
		
		<!--begin::Modal New Form > HRA-->
		<div id="mdlFRM_HRA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Human Resources Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000003-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000003.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Off</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000004-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000004.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Shift</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000005-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000005.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Leave of Absence</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000006-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000006.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Out of Office Work</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000007-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000007.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Undertime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000008-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000008.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000034-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000034.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Job Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000035-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000035.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Conference Room Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000040-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000040.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Personnel Requisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000046-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000046.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Human Resource HelpDesk</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > HRA-->
		
		<!--begin::Modal New Form > CSD-->
		<div id="mdlFRM_CSD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Customer Service</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000011-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000011.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000012-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000012.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Service Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000014-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000014.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transaction Log</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > CSD-->
		
		<!--begin::Modal New Form > BTD-->
		<div id="mdlFRM_BTD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Business Tech.</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000002-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000002.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech. Support</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > BTD-->
		
		<!--begin::Modal New Form > ILA-->
		<div id="mdlFRM_ILA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Investment and Land Acquisition</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000026-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000026.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Rawland Documents Turn-over</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > ILA-->

		<!--begin::Modal New Form > AUD-->
		<div id="mdlFRM_AUD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Internal Audit</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000044-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000044.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Document Creation/Change Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000045-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000045.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Documented Information Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000047-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000047.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Audit Document Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000048-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000048.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Audit Recommendation Implementation Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > AUD-->

		<!--begin::Modal New Form > AMD-->
		<div id="mdlFRM_AMD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Asset</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000049-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000049.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Gate Pass</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > AMD-->

		<!--begin::Modal PDD > DE-->
		<div id="mdlPDD_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Project Development > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="PDD_DE_PDD010000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Permit</div>
											<asp:Label ID="lblCntPDD_PDD010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD010000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD010001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Projects</div>
											<asp:Label ID="lblCntPDD_PDD010001" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD030000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House Models</div>
											<asp:Label ID="lblCntPDD_PDD030000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD040000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Promo Discount & Others</div>
											<asp:Label ID="lblCntPDD_PDD040000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD050000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House Assignment</div>
											<asp:Label ID="lblCntPDD_PDD050000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD060000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Pricing</div>
											<asp:Label ID="lblCntPDD_PDD060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD070000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD070000_PriorityList.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Priority List Batch Upload</div>
											<asp:Label ID="lblCntPDD_PDD070000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD080000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD080000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Inventory</div>
											<asp:Label ID="lblCntPDD_PDD080000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD090000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD090000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Merge Lot</div>
											<asp:Label ID="lblCntPDD_PDD090000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal PDD > DE-->
		
		<!--begin::Modal PDD > DE > PDD010000-->
		<div id="mdlPDD_DE_PDD010000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Project Development > Data Entry > Permit</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD010100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Building Permit</div>
											<asp:Label ID="lblCntPDD_PDD010100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD010200" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Inspection</div>
											<asp:Label ID="lblCntPDD_PDD010200" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD010300" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">COO / CEI</div>
											<asp:Label ID="lblCntPDD_PDD010300" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal PDD > DE > PDD010000-->

		<!--begin::Modal PDD > PR-->
		<div id="mdlPDD_PR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Project Development > Parameter</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDD100000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD100000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Type</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal PDD > PR-->

		<!--begin::Modal PDD > RT-->
		<div id="mdlPDD_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Project Development > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Land Inventory</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRTView?FormCode=PDDRT0002" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Overall Inventory Status</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRTView?FormCode=PDDRT0003" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Hold Units Breakdown</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRTView?FormCode=PDDRT0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Overall Open</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0005" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Actual Sale</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0006" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Total Gross Sale</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0007" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Gross Sale (per Year)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">H&L Gross Sale Breakdown</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0009" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">LO Gross Sale Breakdown</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Gross Sale (per Project)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0011" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">PDD Promos</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0012" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Price List</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0013" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Price List (per Unit)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="aPDDRT0014" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Reserved Sale</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0015" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cancellation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0016" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Summary of Promo Discount</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PDDRT0017" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Tracking of Cancelled Units</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal PDD > RT-->

		<!--begin::Modal ENG > DE-->
		<div id="mdlENG_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="ENG_DE_ENG020000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Planning and Design</div>
											<asp:Label ID="lblCntENG_ENG020000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="ENG_DE_ENG030000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cost Estimate</div>
											<asp:Label ID="lblCntENG_ENG030000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="ENG_DE_ENG050000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Survey</div>
											<asp:Label ID="lblCntENG_ENG050000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="ENG_DE_ENG010100()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Project Management</div>
											<asp:Label ID="lblCntENG_ENG010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="ENG_DE_ENG040000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Property Management</div>
											<asp:Label ID="lblCntENG_ENG040000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE-->
		
		<!--begin::Modal ENG > DE > ENG010100-->
		<div id="mdlENG_DE_ENG010100" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Data Entry > Project Mangement</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Land Development (New)</div>
											<asp:Label ID="lblCntENG_ENG010100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010200" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Land Development (Repair)</div>
											<asp:Label ID="lblCntENG_ENG010200" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010300" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Amenities (New)</div>
											<asp:Label ID="lblCntENG_ENG010300" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010400" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Amenities (Repair)</div>
											<asp:Label ID="lblCntENG_ENG010400" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010500" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House (New)</div>
											<asp:Label ID="lblCntENG_ENG010500" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010600" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House (Repair)</div>
											<asp:Label ID="lblCntENG_ENG010600" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG010700" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Other Projects</div>
											<asp:Label ID="lblCntENG_ENG010700" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">POC Batch Upload</div>
											<asp:Label ID="lblCntENG_ENG060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE > ENG010100-->

		<!--begin::Modal ENG > DE > ENG020000-->
		<div id="mdlENG_DE_ENG020000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Data Entry > Planning and Design</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG020100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Construction Drawings</div>
											<asp:Label ID="lblCntENG_ENG020100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG020200" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Permit Plans</div>
											<asp:Label ID="lblCntENG_ENG020200" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE > ENG020000-->

		<!--begin::Modal ENG > DE > ENG030000-->
		<div id="mdlENG_DE_ENG030000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Data Entry > Cost Estimate</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG030100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House</div>
											<asp:Label ID="lblCntENG_ENG030100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE > ENG030000-->

		<!--begin::Modal ENG > DE > ENG040000-->
		<div id="mdlENG_DE_ENG040000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Data Entry > Property Management</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG040100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Temporary Facility</div>
											<asp:Label ID="lblCntENG_ENG040100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG040200" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Extension of Facilities</div>
											<asp:Label ID="lblCntENG_ENG040200" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG040300" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Punchlist / COC</div>
											<asp:Label ID="lblCntENG_ENG040300" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Connection Inquiry</div>
											<asp:Label ID="lblCntPMD_PMD010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD020000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electricity Billing and Reading</div>
											<asp:Label ID="lblCntPMD_PMD020000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD030000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Billing and Reading</div>
											<asp:Label ID="lblCntPMD_PMD030000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD040000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">VMD Billing and Reading</div>
											<asp:Label ID="lblCntPMD_PMD040000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD050000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">VMD(LO) Billing and Reading</div>
											<asp:Label ID="lblCntPMD_PMD050000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">RFO Monitoring</div>
											<asp:Label ID="lblCntPMD_PMD060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD070000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PMD070000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Setup</div>
											<asp:Label ID="lblCntPMD_PMD070000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE > ENG040000-->
		
		<!--begin::Modal ENG > DE > ENG050000-->
		<div id="mdlENG_DE_ENG050000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Data Entry > Survey</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG050100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TOPO</div>
											<asp:Label ID="lblCntENG_ENG050100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENG050200" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Relocation</div>
											<asp:Label ID="lblCntENG_ENG050200" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE > ENG050000-->

		<!--begin::Modal ENG > RT-->
		<div id="mdlENG_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Engineering > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRTView?FormCode=ENGRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">OSM Material Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0002" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Batch Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0003" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">COD Form Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Billing Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0005" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Daily Collection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0006" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SRF CRF CCF Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0007" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">OC ESC WSC Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">AAA Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRTView?FormCode=ENGRT0009" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">RFO Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="ENGRT0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">BOQ Request Balance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD080000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electricity Billing and Reading</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD090000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Billing and Reading</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD100000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">VMD Billing and Reading</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="PMD110000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">VMD(LO) Billing and Reading</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal ENG > DE-->
		
		<!--begin::Modal SLS > DE-->
		<div id="mdlSLS_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Sales > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller Masterlist</div>
											<asp:Label ID="lblCntSLS_SLS010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS020000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller Management</div>
											<asp:Label ID="lblCntSLS_SLS020000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS030000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Reservation Monitoring</div>
											<asp:Label ID="lblCntSLS_SLS030000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS040000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Inventory</div>
											<asp:Label ID="lblCntSLS_SLS040000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS050000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Monitoring</div>
											<asp:Label ID="lblCntSLS_SLS050000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller's Ranking</div>
											<asp:Label ID="lblCntSLS_SLS060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS140000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS140000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller Entry</div>
											<asp:Label ID="lblCntSLS_SLS140000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS150000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS150000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Kaliwaan</div>
											<asp:Label ID="lblCntSLS_SLS150000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS190000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS190000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller Registration</div>
											<asp:Label ID="lblCntSLS_SLS190000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal SLS > DE-->

		<!--begin::Modal SLS > PR-->
		<div id="mdlSLS_PR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Sales > Parameter</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS160000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS160000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Realty</div>
											<asp:Label ID="lblCntSLS_SLS160000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS170000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS170000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller Group</div>
											<asp:Label ID="lblCntSLS_SLS170000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLS180000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS180000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Seller Type</div>
											<asp:Label ID="lblCntSLS_SLS180000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal SLS > PR-->

		<!--begin::Modal SLS > RT-->
		<div id="mdlSLS_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Customer Service > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SLSRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Price List</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>				
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal SLS > RT-->

		<!--begin::Modal AAD > DE-->
		<div id="mdlAAD_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Accounts Administration > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AAD010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AAD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Transaction</div>
											<asp:Label ID="lblCntAAD_AAD010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AAD040000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AAD040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Processing Fee</div>
											<asp:Label ID="lblCntAAD_AAD040000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AAD050000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AAD050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Commission Advice</div>
											<asp:Label ID="lblCntAAD_AAD050000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AAD060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AAD060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Buyer's Profile</div>
											<asp:Label ID="lblCntAAD_AAD060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AAD002000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AAD002000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Inquiry</div>
											<asp:Label ID="lblCntAAD_AAD002000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal AAD > DE-->

		<!--begin::Modal AAD > RT-->
		<div id="mdlAAD_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Accounts Administration > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Booked Sales</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0002" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts for Commission</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0003" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Commission Receivable</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Daily Collection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0007" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Land Inventory</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Aging</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0009" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Reservation Status</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Commission</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0011" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Overriding Comm. (Old)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0012" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Overriding Comm. (New)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0013" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Incentive</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0014" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Quarter Branch Incentive</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRTView?FormCode=AADRT0015" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts Under DP Stage</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0016" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Full DP</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0017" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Full Payment Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0018" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Expired Account</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0019" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cancellation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0020" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Bounced Check</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0021" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">RS for TCT</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0022" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Tracking of Cancelled Units</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0023" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Loan Management Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0025" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Reservation Sales Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0026" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Price List</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRTView?FormCode=AADRT0027" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Agent List</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0028" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Overdue Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0029" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">In-House Seller Incentives</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0030" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">1st DP Status</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0031" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CIBI Endorsement</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0032" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SRA</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0034" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CTS Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0035" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CTS Financing</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0036" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Credit Investigation (CI)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0037" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House Status</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRTView?FormCode=AADRT0038" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Remittance Verification</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AADRT0039" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Aging Loans</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal AAD > RT-->
		
		<!--begin::Modal FIN > DE-->
		<div id="mdlFIN_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Finance > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Billing</div>
											<asp:Label ID="lblCntFIN_FIN010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN020000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Replenishment</div>
											<asp:Label ID="lblCntFIN_FIN020000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FIN_DE_FIN030000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Budget Approval</div>
											<asp:Label ID="lblCntFIN_FIN030000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN040000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Journal Entry</div>
											<asp:Label ID="lblCntFIN_FIN040000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN050000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">A/P Voucher</div>
											<asp:Label ID="lblCntFIN_FIN050000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">A/P Payment</div>
											<asp:Label ID="lblCntFIN_FIN060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN080000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN080000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payment Order</div>
											<asp:Label ID="lblCntFIN_FIN080000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN110000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN110001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cashiering Journal</div>
											<asp:Label ID="lblCntFIN_FIN110000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN120000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN120000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Budget</div>
											<asp:Label ID="lblCntFIN_FIN120000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN140000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN140001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">For Release Check</div>
											<asp:Label ID="lblCntFIN_FIN140000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN150000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN150000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Unclear Check</div>
											<asp:Label ID="lblCntFIN_FIN150000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN160000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN160000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Journal</div>
											<asp:Label ID="lblCntFIN_FIN160000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN070000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN070000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Liquidation</div>
											<asp:Label ID="lblCntFIN_FIN070000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN130000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN130000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Management (Deposit)</div>
											<asp:Label ID="lblCntFIN_FIN130000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN130001" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN130000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Management (Remittance)</div>
											<asp:Label ID="lblCntFIN_FIN130001" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN100000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN100000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">PDC/ADA Inventory (Submitted)</div>
											<asp:Label ID="lblCntFIN_FIN100000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN100001" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN100000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">PDC/ADA Inventory (Change Check Status)</div>
											<asp:Label ID="lblCntFIN_FIN100001" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN100002" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN100000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">PDC/ADA Inventory (Change Warehouse)</div>
											<asp:Label ID="lblCntFIN_FIN100002" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN170000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN170000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cost Estimate</div>
											<asp:Label ID="lblCntFIN_FIN170000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN090000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN090000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cashiering (Receipting)</div>
											<asp:Label ID="lblCntFIN_FIN090000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal FIN > DE-->
		
		<!--begin::Modal FIN > DE > FIN030000-->
		<div id="mdlFIN_DE_FIN030000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Finance > Data Entry > Budget Approval</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FIN030100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FIN030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House</div>
											<asp:Label ID="lblCntFIN_FIN030100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal FIN > DE > FIN030000-->
		
		<!--begin::Modal FIN > RT-->
		<div id="mdlFIN_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Finance > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">GL Balance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0021" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">GL Detail</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SL Balance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0019" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SL Detail</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0006" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Trial Balance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0023" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">GL Financial</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0018" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Schedule of Released Checks</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0016" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">A/P Aging Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Schedule Of Creditable Input Tax</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0005" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Schedule of Withholding Tax - Expanded</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0015" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance Aging</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0013" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Income Recognition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0014" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Land Inventory</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRT0009" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Capital Expenditure Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FINRTView?FormCode=FINRT0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance for Liquidation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal FIN > RT-->

		<!--begin::Modal SCM > DE-->
		<div id="mdlSCM_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Supply Chain Management > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM040000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Item Receiving<br>(For Site Warehouseman)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM050000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Stock Issuance<br>(For Site Warehouseman)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM020000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contractor Registration</div>
											<asp:Label ID="lblCntSCM_SCM020000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM010100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Management</div>
											<asp:Label ID="lblCntSCM_SCM010000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="SCM_DE_SCM030000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Awarding</div>
											<asp:Label ID="lblCntSCM_SCM030000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Purchase Order</div>
											<asp:Label ID="lblCntSCM_SCM060000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM070000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM070000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Item Receiving</div>
											<asp:Label ID="lblCntSCM_SCM070000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM080000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM080000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Stock Issuance</div>
											<asp:Label ID="lblCntSCM_SCM080000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM090000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM090000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Warehouse Transfer</div>
											<asp:Label ID="lblCntSCM_SCM090000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM100000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM100000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Item Convertion</div>
											<asp:Label ID="lblCntSCM_SCM100000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM110000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM110000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Awarding</div>
											<asp:Label ID="lblCntSCM_SCM110000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM120000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM120000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Cancellation</div>
											<asp:Label ID="lblCntSCM_SCM120000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM130000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM130000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Item Masterlist</div>
											<asp:Label ID="lblCntSCM_SCM130000" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal SCM > DE-->
		
		<!--begin::Modal SCM > DE > SCM030000-->
		<div id="mdlSCM_DE_SCM030000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Supply Chain Management > Data Entry > Contract Awarding</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCM030100" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SCM030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">House</div>
											<asp:Label ID="lblCntSCM_SCM030100" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-circle badge-light" Text="0"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal SCM > DE > SCM030000-->
		
		<!--begin::Modal SCM > RT-->
		<div id="mdlSCM_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Supply Chain Management > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Warehouse Transfer</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0002" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Warehouse Cancelled</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0003" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cycle</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">PR Under OSM</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0005" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">For Deliver</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0006" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">PO Notes</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0007" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">COF Approval Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Warehouse Inventory</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Procurement</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0011" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Warehouse Issuance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="SCMRT0012" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Warehouse Receiving</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal SCM > RT-->

		<!--begin::Modal HRA > DE-->
		<div id="mdlHRA_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Human Resources Administration > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA040000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA040000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employee Masterlist</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA050000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA050000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Schedule</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA060000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA060000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Leave Credit</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA070000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA070000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Salary</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA080000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA080000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Attendance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA090000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA090000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Deduction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA100000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA100000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payroll</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA120000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA120000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA130000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA130000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employee PL / ML / BL</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal HRA > DE-->
		
		<!--begin::Modal HRA > PR-->
		<div id="mdlHRA_PR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Human Resources Administration > Parameter</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Shift</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA020000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Holiday</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA030000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payroll Period</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRA110000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/HRA110000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training List</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal HRA > PR-->

		<!--begin::Modal HRA > RT-->
		<div id="mdlHRA_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Human Resources Administration > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">UT Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0002" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">LV Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0003" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">OT Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TA Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0005" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">OB Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0006" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CO Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0007" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CS Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRARTView?FormCode=HRART0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employee Contact Information</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0009" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Conference Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Override Schedule</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0011" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Override Earnings</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0012" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Daily Time Record - Detailed</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>		
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0013" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Daily Time Record - Summary</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0014" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees w/ Undertime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0015" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees w/ Late</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0016" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees w/ Leave</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>		
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0017" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees Leave Summary</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0018" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Perfect Attendance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0019" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees Working Days</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0020" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employee Payroll</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>		
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0021" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payroll w/ Deminimis</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0022" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Schedule of Overtime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0023" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Total Deduction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0024" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SSS Contribution</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>		
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0025" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">HDMF Contribution</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0026" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Philhealth Contribution</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0027" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Total Contribution</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0028" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Net Pay</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>		
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0029" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employee Training List</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0030" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SL Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0031" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">VL Forms</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0032" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Tardiness</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>	
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0033" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">FTI & FTO</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0034" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Birthday</div>
										</a>	
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0035" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees’ Forms Under Superior</div>
										</a>	
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="HRART0036" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Employees’ DTR Under Superior</div>
										</a>	
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>							
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal HRA > RT-->

		<!--begin::Modal CSD > DE-->
		<div id="mdlCSD_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Customer Service > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="CSD_DE_CSD010000()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Queueing</div>
											<asp:Label ID="lblCntCSD_CSD010000" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal CSD > DE-->

		<!--begin::Modal CSD > DE > CSD010000-->
		<div id="mdlCSD_DE_CSD010000" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" style="z-index:1056">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Customer Service > Data Entry > Queueing</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSD010100" class="text-gray-800 d-flex flex-column" target="_blank">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service 1</div>
											<asp:Label ID="lblCntCSD_CSD010100" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSD010200" class="text-gray-800 d-flex flex-column" target="_blank">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service 2</div>
											<asp:Label ID="lblCntCSD_CSD010200" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSD010300" class="text-gray-800 d-flex flex-column" target="_blank">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service 3</div>
											<asp:Label ID="lblCntCSD_CSD010300" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSD010400" class="text-gray-800 d-flex flex-column" target="_blank">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service 4</div>
											<asp:Label ID="lblCntCSD_CSD010400" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSD010500" class="text-gray-800 d-flex flex-column" target="_blank">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Courtesy Lane</div>
											<asp:Label ID="lblCntCSD_CSD010500" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSD010600" class="text-gray-800 d-flex flex-column" target="_blank">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/CSD010600.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Supervisor</div>
											<asp:Label ID="lblCntCSD_CSD010600" runat="server"></asp:Label>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal CSD > DE > CSD010000-->

		<!--begin::Modal CSD > RT-->
		<div id="mdlCSD_RT" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Customer Service > Report</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0001" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Approval Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0002" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CSD Outbound Call</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0003" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CSD Mancom</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0004" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CSD Queueing Detail</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0005" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CSD Queueing Transaction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0006" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CSD Queueing Walk-ins</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0007" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CSD Queueing Individual</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0008" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">CRF SRF Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0009" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">AAA Monitoring</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0010" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">SRF Repair</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRTView?FormCode=CSDRT0011" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Forms with Escalation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0012" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">BTD Mancom</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRT0013" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Active Customers</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="CSDRTView?FormCode=CSDRT0014" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/RPT.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Client Contact Numbers</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Report</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal CSD > RT-->

		<!--begin::Modal AUD > DE-->
		<div id="mdlAUD_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Internal Audit > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AUD010100" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AUD010100.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Quality Management System</div>										
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal AUD > DE-->

		<!--begin::Modal AMD > DE-->
		<div id="mdlAMD_DE" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Asset > Data Entry</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AMD020000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AMD020000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Fixed Asset</div>										
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AMD030000" class="text-gray-800 d-flex flex-column pointer">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AMD030000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Fixed Asset Issuance</div>										
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal AMD > DE-->

		<!--begin::Modal AMD > PR-->
		<div id="mdlAMD_PR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Asset > Parameter</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="AMD010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/AMD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Fixed Asset Type</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal AMD > PR-->

		<!--begin::Modal BTD > PR-->
		<div id="mdlBTD_PR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Business Technology > Parameter</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="BTD010000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/BTD010000.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Form Approver</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Module</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal BTD > PR-->

		<asp:HiddenField ID="hfEventID" runat="server" />
		<asp:UpdatePanel ID="upnlHidden" runat="server" UpdateMode="Conditional"> 
		<ContentTemplate>
			<asp:HiddenField ID="hfEvent" runat="server" />
		</ContentTemplate>
		</asp:UpdatePanel>

	</div>
	<!--end::Post-->

	<!-- scripts related to this page -->
    <script type="text/javascript">

		//form summary
        function FRMUpdate(ID) {
            //update counter
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB010000',
                    'Type': 'Form Counter'
                },
				success: function (response) {
                    var lblCntFRM = document.getElementById("ContentPlaceHolder1_lblCntFRM");
                    var lblCnt_FRM_Endorsement = document.getElementById("ContentPlaceHolder1_lblCnt_FRM_Endorsement");
                    var lblCnt_FRM_Approval = document.getElementById("ContentPlaceHolder1_lblCnt_FRM_Approval");
                    var lblCnt_FRM_Implementation = document.getElementById("ContentPlaceHolder1_lblCnt_FRM_Implementation");
                    var lblCnt_FRM_Clarification = document.getElementById("ContentPlaceHolder1_lblCnt_FRM_Clarification");
                    var lblCnt_FRM_ForCancellation = document.getElementById("ContentPlaceHolder1_lblCnt_FRM_ForCancellation");
                    lblCntFRM.innerText = response[0].Total;
					lblCnt_FRM_Endorsement.innerText = response[0].Endorse;
                    lblCnt_FRM_Approval.innerText = response[0].Approve;
                    lblCnt_FRM_Implementation.innerText = response[0].Implement;
                    lblCnt_FRM_Clarification.innerText = response[0].Clarify;
                    lblCnt_FRM_ForCancellation.innerText = response[0].ForCancel;
                },
            });
            //update list
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB010000',
                    'Type': 'Form Update',
                    'ID': ID
                },
                success: function (response) {
                    if (response[0].Action == "Update") {
                        if (document.getElementById("trFRM_Summary" + ID) != null) {
                            //assigned
                            var gv01 = $('#gvFRM_Summary').DataTable();
                            let row01 = gv01.row('#trFRM_Summary' + ID);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].col00).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].col01).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].col02).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].col03).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].col04).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].col05).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].col06).draw(false);
                         } else {
                            var gv01 = $('#gvFRM_Summary').DataTable();
                            var row01Data = [response[0].col00, response[0].col01, response[0].col02, response[0].col03, response[0].col04, response[0].col05, response[0].col06];
                            var row01ID = 'trFRM_Summary' + ID;
                            var row01 = gv01.row.add(row01Data).draw();
                            $(row01.node()).attr('id', row01ID);
                        }
                    } else {
                        //assigned
                        var gv01 = $('#gvFRM_Summary').DataTable();
                        gv01.row('#trFRM_Summary' + ID).remove().draw(false);
                    }
                },
            });
        }
        function View_FRM_Summary(Status) {
            var lblFRMTitle = document.getElementById("lblFRMTitle");
            if (Status == "Endorsed By") {
                lblFRMTitle.innerHTML = "Endorsement";
            } else if (Status == "Approved By") {
                lblFRMTitle.innerHTML = "Approval";
            } else if (Status == "Implementer") {
                lblFRMTitle.innerHTML = "Implementation";
            } else if (Status == "Clarification") {
                lblFRMTitle.innerHTML = "Clarification";
            } else if (Status == "Creator") {
                lblFRMTitle.innerHTML = "For Cancellation";
            };

            //initial load
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB010000',
                    'Type': 'Form Summary',
                    'Status': Status
                },
                success: function (response) {
                    $('#gvFRM_Summary').DataTable().destroy();
                    $('#gvFRM_Summary tbody').empty();
                    var tbodyFRM_Summary = document.getElementById("tbodyFRM_Summary");
                    tbodyFRM_Summary.innerHTML = response;
                    Display()
                },
            });
			function Display() {
                //disable column type detection
                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });
                //disable column type detection

                //sort date by yyyy/mm/dd
                $.fn.dataTable.moment('MM/DD/YYYY');
                //sort date by yyyy/mm/dd

                //datatable
                var gvFRM_Summary = $("#gvFRM_Summary").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollX: true,
                    paging: false,
                    lengthChange: false,
                    fixedColumns: { left: 1 },
                    select: false,
                    columnDefs: [{ targets: 1, className: 'tbody-nowrap-auto' }, { targets: 6, className: 'tbody-nowrap-150px' }],
                    orderCellsTop: true
                });
                //datatable

                $('#mdlFRM_Summary').modal('show');
            }
            //initial load
        };
		//form summary

        //work order summary
        function WRKUpdate(ID) {
            //update counter
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB010000',
                    'Type': 'Work Order Counter'
                },
				success: function (response) {
                    var lblCntWO = document.getElementById("ContentPlaceHolder1_lblCntWO");
                    var lblCnt_WO_Assigned = document.getElementById("ContentPlaceHolder1_lblCnt_WO_Assigned");
                    var lblCnt_WO_Accepted = document.getElementById("ContentPlaceHolder1_lblCnt_WO_Accepted");
                    var lblCnt_WO_Completed = document.getElementById("ContentPlaceHolder1_lblCnt_WO_Completed");
                    var lblCnt_WO_Clarify = document.getElementById("ContentPlaceHolder1_lblCnt_WO_Clarify");
                    lblCntWO.innerText = response[0].Total;
					lblCnt_WO_Assigned.innerText = response[0].Assigned;
                    lblCnt_WO_Accepted.innerText = response[0].Accepted;
                    lblCnt_WO_Completed.innerText = response[0].Completed;
                    lblCnt_WO_Clarify.innerText = response[0].Clarify;
                },
            });
            //update list
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB010000',
                    'Type': 'Work Order Update',
                    'ID': ID
                },
                success: function (response) {
                    if (response[0].Action == "Update") {
                        if (document.getElementById("trWO_Summary" + ID) != null) {
                            //assigned
                            var gv01 = $('#gvWO_Summary').DataTable();
                            let row01 = gv01.row('#trWO_Summary' + ID);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].col00).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].col01).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].col02).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].col03).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].col04).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].col05).draw(false);
                        } else {
                            var gv01 = $('#gvWO_Summary').DataTable();
                            var row01Data = [response[0].col00, response[0].col01, response[0].col02, response[0].col03, response[0].col04, response[0].col05];
                            var row01ID = 'trWO_Summary' + ID;
                            var row01 = gv01.row.add(row01Data).draw();
                            $(row01.node()).attr('id', row01ID);
                        }
                    } else {
                        //assigned
                        var gv01 = $('#gvWO_Summary').DataTable();
                        gv01.row('#trWO_Summary' + ID).remove().draw(false);
                    }
                },
            });
        }
        function View_WO_Summary(Status) {
            var lblWOTitle = document.getElementById("lblWOTitle");
            lblWOTitle.innerHTML = Status;

            //initial load
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB010000',
                    'Type': 'Work Order Summary',
                    'Status': Status
                },
                success: function (response) {
                    $('#gvWO_Summary').DataTable().destroy();
                    $('#gvWO_Summary tbody').empty();
                    var tbodyWO_Summary = document.getElementById("tbodyWO_Summary");
                    tbodyWO_Summary.innerHTML = response;
                    Display()
                },
            });
            function Display() {
                //disable column type detection
                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });
                //disable column type detection

                //sort date by yyyy/mm/dd
                $.fn.dataTable.moment('MM/DD/YYYY');
                //sort date by yyyy/mm/dd

                //datatable
                var gvWO_Summary = $("#gvWO_Summary").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollX: true,
                    paging: false,
                    lengthChange: false,
                    fixedColumns: { left: 1 },
                    select: false,
                    columnDefs: [{ targets: 1, className: 'tbody-nowrap-auto' }, { targets: 5, className: 'tbody-nowrap-150px' }],
                    orderCellsTop: true
                });
                //datatable

                $('#mdlWO_Summary').modal('show');
            }
            //initial load
        };
		//work order summary

		//module
		function FRM_GEN(){
			 $('#mdlFRM_GEN').modal('show');
		}
		function FRM_PDD(){
			 $('#mdlFRM_PDD').modal('show');
		}
		function FRM_ENG(){
			 $('#mdlFRM_ENG').modal('show');
		}
        function FRM_SLS() {
            $('#mdlFRM_SLS').modal('show');
		}
        function FRM_AAD() {
            $('#mdlFRM_AAD').modal('show');
		}
        function FRM_FIN() {
            $('#mdlFRM_FIN').modal('show');
		}
        function FRM_SCM() {
            $('#mdlFRM_SCM').modal('show');
		}
        function FRM_HRA() {
            $('#mdlFRM_HRA').modal('show');
		}
        function FRM_CSD() {
            $('#mdlFRM_CSD').modal('show');
		}
        function CSD_DE_CSD010000() {
            $('#mdlCSD_DE_CSD010000').modal('show');
        }
        function FRM_BTD() {
            $('#mdlFRM_BTD').modal('show');
		}
        function FRM_ILA() {
            $('#mdlFRM_ILA').modal('show');
		}
        function FRM_AUD() {
            $('#mdlFRM_AUD').modal('show');
		}
        function FRM_AMD() {
            $('#mdlFRM_AMD').modal('show');
		}
        function PDD_DE_PDD010000() {
            $('#mdlPDD_DE_PDD010000').modal('show');
		}
        function ENG_DE_ENG010100() {
            $('#mdlENG_DE_ENG010100').modal('show');
		}
        function ENG_DE_ENG020000() {
            $('#mdlENG_DE_ENG020000').modal('show');
		}
        function ENG_DE_ENG030000() {
            $('#mdlENG_DE_ENG030000').modal('show');
		}
        function ENG_DE_ENG040000() {
            $('#mdlENG_DE_ENG040000').modal('show');
		}
        function ENG_DE_ENG050000() {
            $('#mdlENG_DE_ENG050000').modal('show');
		}
        function FIN_DE_FIN030000() {
            $('#mdlFIN_DE_FIN030000').modal('show');
		}
        function SCM_DE_SCM030000() {
            $('#mdlSCM_DE_SCM030000').modal('show');
        }
		//module

        //fixed column header alignment
        $(document).ready(function () {
            $('#mdlFRM_Summary').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
			});
            $('#mdlWO_Summary').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection
            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
			//sort date by yyyy/mm/dd
		});
		//fixed column header alignment

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
			//general
			jQuery(function ($) {

                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

                //date
                $('[data-kt-repeater="timepicker"]').flatpickr({
                    enableTime: true,
                    noCalendar: true,
                    dateFormat: "h:i K"
                });
                //date

                // Format options
                var optionFormat = function (item) {
                    if (!item.id) {
                        return item.text;
                    }

                    var span = document.createElement('span');
                    var imgUrl = item.element.getAttribute('data-kt-select2-user');
                    var template = '';

                    template += '<img src="' + imgUrl + '" class="rounded-circle h-20px me-2" alt="image"/>';
                    template += item.text;

                    span.innerHTML = template;

                    return $(span);
                }

			});
			//general
        }
		//load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
