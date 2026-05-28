<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="MNU000007.aspx.vb" Inherits="NET.MNU000007" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Task</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item"><a href="FRM010000" class="text-white">Form</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white"><span id="spnTotal" runat="server">You have 253 tasks</span></li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<!--begin::content-->
		<div class="row g-5 mb-5">
			<!--begin::Sidebar-->
			<asp:UpdatePanel ID="upnlMenu" runat="server" UpdateMode="Conditional" class="col-lg-3">
			<ContentTemplate>
				<!--begin::Sticky aside-->
				<div class="card h-100 card-flush">
					<!--begin::Aside content-->
					<div class="card-body">
						<!--begin::Button-->
						<button type="button" class="btn btn-primary text-uppercase w-100 mb-10" data-bs-toggle="modal" data-bs-target="#mdlNewForm">
							Create New Form
						</button>
						<!--end::Button-->
						<!--begin::Menu-->
						<div class="menu menu-dark menu-column menu-rounded menu-state-bg menu-state-title-primary menu-state-icon-primary menu-state-bullet-primary menu-state-badge-primary mb-10">
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000006" class="menu-link ">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 svg-icon-dark me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" fill-rule="evenodd" clip-rule="evenodd" d="M2 4.63158C2 3.1782 3.1782 2 4.63158 2H13.47C14.0155 2 14.278 2.66919 13.8778 3.04006L12.4556 4.35821C11.9009 4.87228 11.1726 5.15789 10.4163 5.15789H7.1579C6.05333 5.15789 5.15789 6.05333 5.15789 7.1579V16.8421C5.15789 17.9467 6.05333 18.8421 7.1579 18.8421H16.8421C17.9467 18.8421 18.8421 17.9467 18.8421 16.8421V13.7518C18.8421 12.927 19.1817 12.1387 19.7809 11.572L20.9878 10.4308C21.3703 10.0691 22 10.3403 22 10.8668V19.3684C22 20.8218 20.8218 22 19.3684 22H4.63158C3.1782 22 2 20.8218 2 19.3684V4.63158Z" fill="currentColor"/>
												<path d="M10.9256 11.1882C10.5351 10.7977 10.5351 10.1645 10.9256 9.77397L18.0669 2.6327C18.8479 1.85165 20.1143 1.85165 20.8953 2.6327L21.3665 3.10391C22.1476 3.88496 22.1476 5.15129 21.3665 5.93234L14.2252 13.0736C13.8347 13.4641 13.2016 13.4641 12.811 13.0736L10.9256 11.1882Z" fill="currentColor"/>
												<path d="M8.82343 12.0064L8.08852 14.3348C7.8655 15.0414 8.46151 15.7366 9.19388 15.6242L11.8974 15.2092C12.4642 15.1222 12.6916 14.4278 12.2861 14.0223L9.98595 11.7221C9.61452 11.3507 8.98154 11.5055 8.82343 12.0064Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Open Task</span>
									<asp:Label ID="lblCntTask" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Inbox-->
								<a href="MNU000007" class="menu-link active">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/communication/com010.svg-->
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.3" x="2" y="2" width="20" height="20" rx="5" fill="currentColor"/>
												<path d="M10.4343 12.4343L8.75 10.75C8.33579 10.3358 7.66421 10.3358 7.25 10.75C6.83579 11.1642 6.83579 11.8358 7.25 12.25L10.2929 15.2929C10.6834 15.6834 11.3166 15.6834 11.7071 15.2929L17.25 9.75C17.6642 9.33579 17.6642 8.66421 17.25 8.25C16.8358 7.83579 16.1642 7.83579 15.75 8.25L11.5657 12.4343C11.2533 12.7467 10.7467 12.7467 10.4343 12.4343Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">For Approval</span>
									<asp:Label ID="lblCntApproval" runat="server" class="badge badge-light-success">0</asp:Label>
								</a>
								<!--end::Inbox-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000009" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 svg-icon-dark me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.3" x="2" y="2" width="20" height="20" rx="10" fill="currentColor"/>
												<path d="M11.276 13.654C11.276 13.2713 11.3367 12.9447 11.458 12.674C11.5887 12.394 11.738 12.1653 11.906 11.988C12.0833 11.8107 12.3167 11.61 12.606 11.386C12.942 11.1247 13.1893 10.896 13.348 10.7C13.5067 10.4947 13.586 10.2427 13.586 9.944C13.586 9.636 13.4833 9.356 13.278 9.104C13.082 8.84267 12.69 8.712 12.102 8.712C11.486 8.712 11.066 8.866 10.842 9.174C10.6273 9.482 10.52 9.82267 10.52 10.196L10.534 10.574H8.826C8.78867 10.3967 8.77 10.2333 8.77 10.084C8.77 9.552 8.90067 9.07133 9.162 8.642C9.42333 8.20333 9.81067 7.858 10.324 7.606C10.8467 7.354 11.4813 7.228 12.228 7.228C13.1987 7.228 13.9687 7.44733 14.538 7.886C15.1073 8.31533 15.392 8.92667 15.392 9.72C15.392 10.168 15.322 10.5507 15.182 10.868C15.042 11.1853 14.874 11.442 14.678 11.638C14.482 11.834 14.2253 12.0533 13.908 12.296C13.544 12.576 13.2733 12.8233 13.096 13.038C12.928 13.2527 12.844 13.528 12.844 13.864V14.326H11.276V13.654ZM11.192 15.222H12.928V17H11.192V15.222Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Clarification</span>
									<asp:Label ID="lblCntClarification" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000008" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 svg-icon-dark me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M6.28548 15.0861C7.34369 13.1814 9.35142 12 11.5304 12H12.4696C14.6486 12 16.6563 13.1814 17.7145 15.0861L19.3493 18.0287C20.0899 19.3618 19.1259 21 17.601 21H6.39903C4.87406 21 3.91012 19.3618 4.65071 18.0287L6.28548 15.0861Z" fill="currentColor"/>
												<rect opacity="0.3" x="8" y="3" width="8" height="8" rx="4" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Endorsed</span>
									<asp:Label ID="lblCntEndorsed" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000010" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 svg-icon-dark me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M12 22C13.6569 22 15 20.6569 15 19C15 17.3431 13.6569 16 12 16C10.3431 16 9 17.3431 9 19C9 20.6569 10.3431 22 12 22Z" fill="currentColor"/>
												<path d="M19 15V18C19 18.6 18.6 19 18 19H6C5.4 19 5 18.6 5 18V15C6.1 15 7 14.1 7 13V10C7 7.6 8.7 5.6 11 5.1V3C11 2.4 11.4 2 12 2C12.6 2 13 2.4 13 3V5.1C15.3 5.6 17 7.6 17 10V13C17 14.1 17.9 15 19 15ZM11 10C11 9.4 11.4 9 12 9C12.6 9 13 8.6 13 8C13 7.4 12.6 7 12 7C10.3 7 9 8.3 9 10C9 10.6 9.4 11 10 11C10.6 11 11 10.6 11 10Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Subscribed</span>
									<asp:Label ID="lblCntSubscriber" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000011" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 svg-icon-dark me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM16 13.5L12.5 13V10C12.5 9.4 12.6 9.5 12 9.5C11.4 9.5 11.5 9.4 11.5 10L11 13L8 13.5C7.4 13.5 7 13.4 7 14C7 14.6 7.4 14.5 8 14.5H11V18C11 18.6 11.4 19 12 19C12.6 19 12.5 18.6 12.5 18V14.5L16 14C16.6 14 17 14.6 17 14C17 13.4 16.6 13.5 16 13.5Z" fill="currentColor"/>
												<rect x="11" y="19" width="10" height="2" rx="1" transform="rotate(-90 11 19)" fill="currentColor"/>
												<rect x="7" y="13" width="10" height="2" rx="1" fill="currentColor"/>
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">My Request</span>
									<asp:Label ID="lblCntRequest" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
						</div>
						<!--end::Menu-->
					</div>
					<!--end::Aside content-->
				</div>
				<!--end::Sticky aside-->
				<asp:Button ID="lbtnSUBS" runat="server" Text="Button" OnClick="lbtnSUBS_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnSUBM" runat="server" Text="Button" OnClick="lbtnSUBM_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnRPT" runat="server" Text="Button" OnClick="lbtnRPT_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnSTSSUpd" runat="server" Text="Button" OnClick="lbtnSTSSUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnSTSMUpd" runat="server" Text="Button" OnClick="lbtnSTSMUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnUPLSUpd" runat="server" Text="Button" OnClick="lbtnUPLSUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnUPLMUpd" runat="server" Text="Button" OnClick="lbtnUPLMUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnNTESUpd" runat="server" Text="Button" OnClick="lbtnNTESUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnNTEMUpd" runat="server" Text="Button" OnClick="lbtnNTEMUpd_Click" ClientIDMode="Static" style="display:none;"/>
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::Sidebar-->
			<!--begin::Content-->
			<asp:UpdatePanel ID="upnlContent" runat="server" UpdateMode="Conditional" class="col-lg-9">
			<ContentTemplate>
				<div class="card h-100 card-flush">
					<!--begin::Card body-->
					<div class="card-body">
						 <!--begin::toolbar-->
						<div class="d-flex align-items-center flex-wrap gap-1">
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
							<!--begin::Settings-->
							<div>
								<a id="aSUBM" type="button" class="btn btn-sm btn-icon btn-light btn-active-light-primary" style="display:none" data-bs-toggle="tooltip" data-bs-placement="top" title="Subscribed" onclick='lbtnSUBM(this);'>
									<span class="indicator-label">
										<!--begin::Svg Icon | path: icons/duotune/general/gen052.svg-->
										<span class="svg-icon svg-icon-2 m-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M12 22C13.6569 22 15 20.6569 15 19C15 17.3431 13.6569 16 12 16C10.3431 16 9 17.3431 9 19C9 20.6569 10.3431 22 12 22Z" fill="currentColor"/>
												<path d="M19 15V18C19 18.6 18.6 19 18 19H6C5.4 19 5 18.6 5 18V15C6.1 15 7 14.1 7 13V10C7 7.6 8.7 5.6 11 5.1V3C11 2.4 11.4 2 12 2C12.6 2 13 2.4 13 3V5.1C15.3 5.6 17 7.6 17 10V13C17 14.1 17.9 15 19 15ZM11 10C11 9.4 11.4 9 12 9C12.6 9 13 8.6 13 8C13 7.4 12.6 7 12 7C10.3 7 9 8.3 9 10C9 10.6 9.4 11 10 11C10.6 11 11 10.6 11 10Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</a>
								<a id="aSTSMUpd" class="btn btn-sm btn-icon btn-light btn-active-light-primary" style="display:none" data-bs-toggle="tooltip" data-bs-placement="top" title="Change Status" onclick="lbtnSTSMUpd(this);">
									<span class="indicator-label">
										<!--begin::Svg Icon | path: icons/duotune/general/gen052.svg-->
										<span class="svg-icon svg-icon-2 m-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M6 22H4V3C4 2.4 4.4 2 5 2C5.6 2 6 2.4 6 3V22Z" fill="currentColor"/>
												<path d="M18 14H4V4H18C18.8 4 19.2 4.9 18.7 5.5L16 9L18.8 12.5C19.3 13.1 18.8 14 18 14Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</a>
								<a id="aUPLMUpd" class="btn btn-sm btn-icon btn-light btn-active-light-primary" style="display:none" data-bs-toggle="tooltip" data-bs-placement="top" title="Upload File" onclick="lbtnUPLMUpd(this);">
									<span class="indicator-label">
										<!--begin::Svg Icon | path: icons/duotune/general/gen052.svg-->
										<span class="svg-icon svg-icon-2 m-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M4.425 20.525C2.525 18.625 2.525 15.525 4.425 13.525L14.825 3.125C16.325 1.625 18.825 1.625 20.425 3.125C20.825 3.525 20.825 4.12502 20.425 4.52502C20.025 4.92502 19.425 4.92502 19.025 4.52502C18.225 3.72502 17.025 3.72502 16.225 4.52502L5.82499 14.925C4.62499 16.125 4.62499 17.925 5.82499 19.125C7.02499 20.325 8.82501 20.325 10.025 19.125L18.425 10.725C18.825 10.325 19.425 10.325 19.825 10.725C20.225 11.125 20.225 11.725 19.825 12.125L11.425 20.525C9.525 22.425 6.425 22.425 4.425 20.525Z" fill="currentColor"/>
												<path d="M9.32499 15.625C8.12499 14.425 8.12499 12.625 9.32499 11.425L14.225 6.52498C14.625 6.12498 15.225 6.12498 15.625 6.52498C16.025 6.92498 16.025 7.525 15.625 7.925L10.725 12.8249C10.325 13.2249 10.325 13.8249 10.725 14.2249C11.125 14.6249 11.725 14.6249 12.125 14.2249L19.125 7.22493C19.525 6.82493 19.725 6.425 19.725 5.925C19.725 5.325 19.525 4.825 19.125 4.425C18.725 4.025 18.725 3.42498 19.125 3.02498C19.525 2.62498 20.125 2.62498 20.525 3.02498C21.325 3.82498 21.725 4.825 21.725 5.925C21.725 6.925 21.325 7.82498 20.525 8.52498L13.525 15.525C12.325 16.725 10.525 16.725 9.32499 15.625Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</a>
								<a id="aNTEMUpd" class="btn btn-sm btn-icon btn-light btn-active-light-primary" style="display:none" data-bs-toggle="tooltip" data-bs-placement="top" title="Add Notes" onclick="lbtnNTEMUpd(this);">
									<span class="indicator-label">
										<!--begin::Svg Icon | path: icons/duotune/general/gen052.svg-->
										<span class="svg-icon svg-icon-2 m-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M2 4V16C2 16.6 2.4 17 3 17H13L16.6 20.6C17.1 21.1 18 20.8 18 20V17H21C21.6 17 22 16.6 22 16V4C22 3.4 21.6 3 21 3H3C2.4 3 2 3.4 2 4Z" fill="currentColor"/>
												<path d="M18 9H6C5.4 9 5 8.6 5 8C5 7.4 5.4 7 6 7H18C18.6 7 19 7.4 19 8C19 8.6 18.6 9 18 9ZM16 12C16 11.4 15.6 11 15 11H6C5.4 11 5 11.4 5 12C5 12.6 5.4 13 6 13H15C15.6 13 16 12.6 16 12Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</a>
							</div>
							<!--end::Settings-->
						</div>
						<!--end::toolbar-->
						<!--begin::list-->
						<asp:GridView ID="gvTask" runat="server" class="table table-no-border table-row-bordered table-hover align-middle tscroll w-100" AutoGenerateColumns="False" onscroll="scrollPos();" ShowHeaderWhenEmpty="true" >
							<Columns>
								<asp:TemplateField HeaderText="">
									<ItemTemplate>
										<span class='<%# Eval("Bullet") %>'></span>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-5px min-w-5px" />
									<ItemStyle CssClass="mw-5px min-w-5px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="">
									<HeaderTemplate>
										<div class="form-check form-check-sm form-check-custom form-check-solid">
											<input class="form-check-input checkBoxAllClass progre " type="checkbox" value="1" css="" />
										</div>
									</HeaderTemplate>
									<ItemTemplate>
										<div class="form-check form-check-sm form-check-custom form-check-solid">
											<input class="form-check-input checkBoxClass" id="RowCheckbox" runat="server" type="checkbox" value="1" />
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-30px min-w-30px" />
									<ItemStyle CssClass="mw-30px min-w-30px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="For Approval">
									<ItemTemplate>
										<div class="overlay overflow-hidden">
											<div class="overlay-wrapper">
												<a href='<%# Eval("Link") %>' class="d-flex align-items-center">
													<div class="symbol symbol-30px overflow-hidden me-3">
														<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
													</div>
													<div class="d-flex flex-column text-truncate ">
														<span class="text-dark fw-bolder fs-6"> <%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
												</a>
											</div>
											<div class="overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end">
												<div class="d-flex justify-content-end flex-shrink-0">
													<a href="#" class="btn btn-sm btn-icon btn-light btn-active-light-primary me-4" title="Action" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
														<!--begin::Svg Icon | path: icons/duotune/arrows/arr072.svg-->
														<span class="svg-icon svg-icon-1 m-0">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<path d="M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z" fill="currentColor"/>
																<path opacity="0.3" d="M21 14H3C2.4 14 2 13.6 2 13V11C2 10.4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z" fill="currentColor"/>
															</svg>
														</span>
														<!--end::Svg Icon-->
													</a>
													<!--begin::Menu-->
													<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-200px py-4" data-kt-menu="true">
														<!--begin::Menu item-->
														<div class="menu-item px-3">
															<a class="menu-link px-3" onclick="<%# Eval("lbtnSUBS") %>">Subscribed</a>
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3" <%# Eval("DisplayRPT") %>>
															<a class="menu-link px-3" onclick="<%# Eval("lbtnRPT") %>">Print Preview</a>
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3">
															<a class="menu-link px-3" onclick="<%# Eval("lbtnSTSSUpd") %>">Change Status</a>
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3">
															<a class="menu-link px-3" onclick="<%# Eval("lbtnUPLSUpd") %>">Upload File</a>
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3">
															<a class="menu-link px-3" onclick="<%# Eval("lbtnNTESUpd") %>">Add Note</a>
														</div>
														<!--end::Menu item-->
													</div>
													<!--end::Menu-->
												</div>
											</div>
										</div>
										<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="w-100" />
									<ItemStyle CssClass="w-100" />
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
						<!--end::list-->
					</div>
					<!--end::Card body-->
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::Content-->
		</div>
		<!--begin::content-->

		<!--begin::Modal New Form-->
		<div id="mdlNewForm" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen p-9" role="document">
				<div class="modal-content modal-rounded">
					<div class="modal-header">
						<h5 class="modal-title">Create new form</h5>
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
					<div class="modal-body scroll h-500px">
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>General</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000001-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Work Order</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Business Tech. Department</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000002-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000002.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Business Tech. Support</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Human Resources</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000003-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000003.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Change Off</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000004-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000004.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Change Shift</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000005-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000005.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Leave of Absence</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000006-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000006.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Out of Office Work</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000007-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000007.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Undertime</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000008-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000008.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Training Request</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Project Development</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000027-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">TCT Clearance</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Investment and Land Acquisition</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000026-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000026.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Rawland Documents Turn-over</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Sales</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000028-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000028.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Lot Clearance</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000029-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000029.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Sales Request Advice</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Accounts Administration</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000030-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000030.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Account Activity Advice</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000031-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000031.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Cash Remittance Verification Slip</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000032-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Transfer of Title Routing Slip</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Customer Service</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000011-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000011.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Customer Request</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000013-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Occupancy Clearance</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000012-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000012.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Service Request</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000014-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000014.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Transaction Log</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Construction Division</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000019-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000019.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Request For Approval</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000020-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000020.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Request For Information</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000021-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000021.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Site Instruction</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Property Management</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000022-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000022.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Construction Clearance</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000023-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000023.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Electrical Service Connection</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000024-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000024.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Request for RFO Keys</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000025-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000025.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Water Service Connection</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Supply Chain Management</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000009-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Contract Order</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000010-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Purchase Request</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<h3 class="card-title fw-bolder text-dark w-100 mb-5"><span>Finance</span></h3>
						<div class="row">
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000018-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000018.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Capital Expenditure Request</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000015-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Cash Advance</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000033-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000033.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Contract Billing</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000017-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000017.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Payment Request</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
							<!--begin::Col-->
							<div class="col-md-3 col-lg-2 col-xl-2">
								<a href="FRM000016-ADD-0000000000000" class="d-flex align-items-center w-100 mb-5">
									<div class="symbol symbol-45px me-5">
										<img src="Assets/media/svg/apps/FRM000016.svg" alt="" />
									</div>
									<div class="d-flex justify-content-start flex-column">
										<span class="text-dark fw-bolder fs-6">Petty Cash</span>
										<span class="text-muted fw-bold text-muted d-block fs-7">New</span>
									</div>
								</a>
							</div>
							<!--end::Col-->
						</div>
						<!--end::Details-->
					</div>
				</div>
			</div>
		</div>
		<!--end::Modal New Form-->

		<!--begin::Modal Subscribe-->
		<asp:UpdatePanel ID="mdlSUB" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Subscribed</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabSUBInput">Inputs</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tabSUBItem">Items</a>
								</li>
							</ul>
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
					</div>
					<div class="modal-body">
						<div class="tab-content">
							<div class="tab-pane fade show active" style="max-height:200px;min-height:200px" id="tabSUBInput" role="tabpanel">
								<p>Subscribe?</p>
							</div>
							<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin; max-height:200px;min-height:200px" id="tabSUBItem" role="tabpanel">
								<asp:GridView ID="gvSUBSelected" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="symbol symbol-30px overflow-hidden me-3">
														<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
													</div>
													<div class="d-flex flex-column ">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
												</div>
												<asp:Label ID="lblFormCode" runat="server" Text='<%# Eval("FormCode") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
											</ItemTemplate>
											<ItemStyle CssClass="w-100" />
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtnSUBOk" runat="server" class="btn btn-primary">Subscribe</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Subscribe-->

		<!--begin::Modal Status-->
		<asp:UpdatePanel ID="mdlSTS" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Change Status</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabSTSInput">Inputs</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tabSTSItem">Items</a>
								</li>
							</ul>
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
					</div>
					<div class="modal-body">
						<div class="tab-content">
							<div class="tab-pane fade show active" id="tabSTSInput" role="tabpanel">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Change status to</span>
									<asp:DropDownList ID="ddlSTSStatus" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlSTS" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddlSTSStatus(this);">
										<asp:ListItem Value="">Select a status</asp:ListItem>
										<asp:ListItem Value="Approved">Approved</asp:ListItem>
										<asp:ListItem Value="Declined">Declined</asp:ListItem>
										<asp:ListItem Value="Clarify">Clarify</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div id="divSTSClarifyTo" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
									<span class="input-group-text min-w-150px required">Clarify to</span>
									<asp:DropDownList ID="ddlSTSClarifyTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlSTS" class="form-select form-select-sm form-select-border min-h-35px">
										<asp:ListItem Value="">Select a user</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div class="input-group input-group-sm">
									<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
									<asp:TextBox ID="tbxSTSNote" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
								</div>
							</div>
							<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin; max-height:283px;min-height:283px" id="tabSTSItem" role="tabpanel">
								<asp:GridView ID="gvSTSSelected" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="symbol symbol-30px overflow-hidden me-3">
														<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
													</div>
													<div class="d-flex flex-column ">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
												</div>
												<asp:Label ID="lblFormCode" runat="server" Text='<%# Eval("FormCode") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
											</ItemTemplate>
											<ItemStyle CssClass="w-100" />
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtnSTSUpdOk" runat="server" class="btn btn-primary">Save changes</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Status-->

		<!--begin::Modal Upload-->
		<asp:UpdatePanel ID="mdlUPL" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Upload File</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabUPLInput">Inputs</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tabUPLItem">Items</a>
								</li>
							</ul>
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
					</div>
					<div class="modal-body">
						<div class="tab-content">
							<div class="tab-pane fade show active" style="min-height:181px" id="tabUPLInput" role="tab panel">
								<!--begin::Dropzone-->
								<div class="dropzone" id="DropZone">
									<!--begin::Message-->
									<div class="dz-message needsclick">
										<!--begin::Icon-->
										<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
										<!--end::Icon-->
										<!--begin::Info-->
										<div class="ms-4">
											<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
											<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
										</div>
										<!--end::Info-->
									</div>
								</div>
								<!--end::Dropzone-->
							</div>
							<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin; max-height:181px;min-height:181px" id="tabUPLItem" role="tabpanel">
								<input id="lblUPLIDsrs" runat="server" type="text" style="display:none" />
								<asp:GridView ID="gvUPLSelected" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="symbol symbol-30px overflow-hidden me-3">
														<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
													</div>
													<div class="d-flex flex-column">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
												</div>
												<asp:Label ID="lblFormCode" runat="server" Text='<%# Eval("FormCode") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
											</ItemTemplate>
											<ItemStyle CssClass="w-100" />
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button id="lbtnUPLUpdOk" type="button" class="btn btn-primary">Upload</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Upload-->
		
		<!--begin::Modal Comment-->
		<asp:UpdatePanel ID="mdlNTE" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Note</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabNTEInput">Inputs</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tabNTEItem">Items</a>
								</li>
							</ul>
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
					</div>
					<div class="modal-body">
						<div class="tab-content">
							<div class="tab-pane fade show active" id="tabNTEInput" role="tabpanel">
								<div class="input-group input-group-sm">
									<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
									<asp:TextBox ID="tbxNTENote" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
								</div>
							</div>
							<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin;max-height:200px;min-height:200px;" id="tabNTEItem" role="tabpanel">
								<asp:GridView ID="gvNTESelected" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="symbol symbol-30px overflow-hidden me-3">
														<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
													</div>
													<div class="d-flex flex-column">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
												</div>
												<asp:Label ID="lblFormCode" runat="server" Text='<%# Eval("FormCode") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
											</ItemTemplate>
											<ItemStyle CssClass="w-100" />
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtnNTEUpdOk" runat="server" class="btn btn-primary">Add</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->
		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfFormCode" runat="server" />
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hrRPT" runat="server" />
		<asp:HiddenField ID="hfMention" runat="server" />
		<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Post-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">
        //function related to this page only
		function lbtnSUBS(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnSUBS.ClientID %>");
            clickButton.click();
        }
        function lbtnSUBM(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnSUBM.ClientID %>");
            clickButton.click();
			// Disable button to avoid multiple click
            Btn.disabled = true;
            // Show loading indication
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                // Enable button
				Btn.disabled = false;
            }, 3000);
		};
		function lbtnRPT(FormCode, ID,RPT) {
            var hfFormCode = document.getElementById("ContentPlaceHolder1_hfFormCode");
            hfFormCode.value = FormCode;
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
			hfID.value = ID;
            var hrRPT = document.getElementById("ContentPlaceHolder1_hrRPT");
            hrRPT.value = RPT;
            var clickButton = document.getElementById("<%= lbtnRPT.ClientID %>");
            clickButton.click();
        }
		function lbtnSTSSUpd(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnSTSSUpd.ClientID %>");
            clickButton.click();
        }
		function lbtnSTSMUpd(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnSTSMUpd.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click 
            Btn.disabled = true;
            // Show loading indication
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function ddlSTSStatus(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;
            var divSTSClarifyTo = document.getElementById("ContentPlaceHolder1_divSTSClarifyTo");
            divSTSClarifyTo.style.display = "none";
            if (selectValue == "Clarify") {
                divSTSClarifyTo.style.display = "";
            }
        }
        function lbtnUPLSUpd(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnUPLSUpd.ClientID %>");
            clickButton.click();
		}
        function lbtnUPLMUpd(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnUPLMUpd.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click 
            Btn.disabled = true;
            // Show loading indication
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function lbtnNTESUpd(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnNTESUpd.ClientID %>");
            clickButton.click();
        }
        function lbtnNTEMUpd(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnNTEMUpd.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click 
            Btn.disabled = true;
            // Show loading indication
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                // Enable button
                Btn.disabled = false;
			}, 3000);
		};
		//function related to this page only

		//table search
        var $rows = $('#ContentPlaceHolder1_gvTask tbody tr');
        $('#tbxFind').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
            $rows.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();
		});
		//table search

		//tbody scroll
        var $table = $('table.tscroll'),$bodyCells = $table.find('tbody tr:first').children(),colWidth;
		$(window).resize(function () {
			colWidth = $bodyCells.map(function () {
				return $(this).width();
			}).get();
			$table.find('thead tr').children().each(function (i, v) {
				$(v).width(colWidth[i]);
			});
		});
		function scrollPos() {
			var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");
            hfScrollPosition.value = document.querySelector('#ContentPlaceHolder1_gvTask > tbody').scrollTop;
		}
		//tbody scroll

		//checkbox
		$('.checkBoxAllClass').click(function () {
            var aSUBM = document.getElementById("aSUBM");
            var aSTSMUpd = document.getElementById("aSTSMUpd");
            var aUPLMUpd = document.getElementById("aUPLMUpd");
			var aNTEMUpd = document.getElementById("aNTEMUpd");

            if ($(this).is(":checked")) {
                //get tr which is visible ..add checked to that checkboxes
                $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                aSUBM.style.display = "";
				aSTSMUpd.style.display = "";
                aUPLMUpd.style.display = "";
                aNTEMUpd.style.display = "";
            } else {
                //remove checked
                $(".checkBoxClass").prop('checked', false);
                aSUBM.style.display = "none";
				aSTSMUpd.style.display = "none";
                aUPLMUpd.style.display = "none";
                aNTEMUpd.style.display = "none";
			}
        })
        $(".checkBoxClass").change(function () {
            var aSUBM = document.getElementById("aSUBM");
			var aSTSMUpd = document.getElementById("aSTSMUpd");
            var aUPLMUpd = document.getElementById("aUPLMUpd");
            var aNTEMUpd = document.getElementById("aNTEMUpd");
			if (!$(this).prop("checked")) {
				$(".checkBoxAllClass").prop("checked", false);
			}
			if ($('.checkBoxClass:checked').length > 0) {
                aSUBM.style.display = "";
                aSTSMUpd.style.display = "";
                aUPLMUpd.style.display = "";
                aNTEMUpd.style.display = "";
			} else {
                aSUBM.style.display = "none";
                aSTSMUpd.style.display = "none";
                aUPLMUpd.style.display = "none";
                aNTEMUpd.style.display = "none";
			}
		});
        //checkbox

        //numeric formating
        function FormatNumeric(ID) {
            var NumVal = document.getElementById(ID);
            var Val = parseFloat(NumVal.value);
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
            if (Num == "NaN") {
                Num = "0.00";
            }
            NumVal.value = Num;
        }
        //numeric formating

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
            jQuery(function ($) {
                //form variable
                var lblUPLIDsrs = document.getElementById("ContentPlaceHolder1_lblUPLIDsrs");
				var lblUPLIDsrs = document.getElementById("ContentPlaceHolder1_lblUPLIDsrs");
                //form variable
				//scroll position				document.querySelector('#ContentPlaceHolder1_gvTask > tbody').setAttribute("onscroll", "scrollPos()");				var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");				document.querySelector('#ContentPlaceHolder1_gvTask > tbody').scrollTop = hfScrollPosition.value;				//scroll position                //metion                jq.fn.atwho.debug = true;
                var chatHub = jq.connection.chatHub;
                jq.connection.hub.start().done(function () {
                    // mention load
                    loadFunction()
                    //// mention save
                    //jq('.lbtn05AddNote').click(function () {
                    //    // Call the Send method on the hub.
                    //    chatHub.server.send(ltrlFormCode, ltrlID, ltrlFormCode, initialMention.join(','), ltrlCreatedBy);
                    //    // clear
                    //    initialMention = [];
                    //    mentionUser = [];
                    //})
                }).fail(function (error) {
                    console.error("SignalR connection failed: " + error)
                });
                function loadFunction() {
                    chatHub.server.getEmployeeData().then(function (data) {
                        initAtWho(data);
                    }).catch(function (error) {
                        console.error("Error fetching data from SignalR:", error)
                    });
                    function initAtWho(data) {
                        var at_config = {
                            at: "@",
                            data: data,
                            insertTpl: '${fname}',
                            displayTpl: "<li><div class='d-flex align-items-center'><div class='symbol symbol-30px overflow-hidden me-3'><div class='symbol-label'> <img src='Assets/media/avatars/${empPic}' class='w-100' alt='' />  </div></div><div class='d-flex flex-column '><span class='text-weight-500 text-gray-800 '>${name}</span><span class='text-weight-500'>${email}</span></div></div></li>",
                            limit: 200,
                            callbacks: {
                                beforeInsert: function (value, jqli, e) {
                                    var selectedUserData = jqli.data('item-data');
                                    mentionUser.push({
                                        name: selectedUserData.fname,
                                        empCode: selectedUserData.empCode
                                    })
                                    var emp_no = mentionUser.map(function (employee) {
                                        return employee.empCode
                                    });
                                    initialMention = emp_no;
                                    $('#<%=hfMention.ClientID %>').val(initialMention.join(','));
                                    return '@' + value;
                                },
                            }
                        }
                        $inputor = jq('.mention').atwho(at_config);
                        $inputor.caret('pos', 47);
                        $inputor.focus().atwho('run');
                        // for removing mention
                        $inputor.on('keydown', function (e) {
                            if (e.keyCode === 8) {
                                handleBackspace();
                            }
                        })
                        function handleBackspace() {
                            var inputValue = $inputor.val();
                            var cursorPosition = $inputor.caret('pos');
                            var mentionStart = inputValue.lastIndexOf('@', cursorPosition - 1);

                            if (mentionStart !== -1) {
                                // Extract mention text to be removed
                                var mentionText = inputValue.substring(mentionStart, cursorPosition);

                                // Find and remove mention from mentionUser array
                                mentionUser = mentionUser.filter(function (user) {
                                    return `@${user.name}` !== mentionText;
                                });

                                var emp_no = mentionUser.map(function (employee) {
                                    return employee.empCode
                                });

                                initialMention = emp_no;
                            }
                        }
                    };
                };                //metion

                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

                //tooltip
                $('[data-bs-toggle="tooltip"]').tooltip();
                //tooltip

                //menu
                KTMenu.createInstances();
                //menu

                //upload
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "HND000004.ashx?FormCode=FRM000001&IDSrs=" + lblUPLIDsrs.value,
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        var imgName = response;
                        file.previewElement.classList.add("dz-success");
                        console.log("Successfully uploaded :" + imgName);
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                $('#lbtnUPLUpdOk').on('click', function (e) {
                    myDropzone.processQueue();
                });
                //upload
            });
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
