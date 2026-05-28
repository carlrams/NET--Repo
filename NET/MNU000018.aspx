<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="MNU000018.aspx.vb" Inherits="NET.MNU000018" MaintainScrollPositionOnPostback = "true" %>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
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
						<li class="breadcrumb-item text-white">Construction</li>
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
		<!--begin::breadcrumb bar-->

		<!--begin::content-->
        <div class="row g-5 mb-5">
			<asp:UpdatePanel ID="upnlMenu" runat="server" UpdateMode="Conditional" class="col-lg-3">
			<ContentTemplate>
				<!--begin::Card-->
				<div class="card h-100 card-flush">
					<!--begin::Card body-->
					<div class="card-body">
                        <!--begin::Button-->
						<button type="button" class="btn btn-primary text-uppercase w-100 mb-10" data-bs-toggle="modal" data-bs-target="#mdlANU">
							Add New Unit
						</button>
						<!--end::Button-->
						<!--begin::Menu-->
						<div class="menu menu-dark menu-column menu-rounded menu-state-bg menu-state-title-primary menu-state-icon-primary menu-state-bullet-primary menu-state-badge-primary mb-10">
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000017" class="menu-link">
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
								<!--begin::Marked-->
								<a href="MNU000018" class="menu-link active">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.3" x="2" y="2" width="20" height="20" rx="10" fill="currentColor"/>
												<rect x="11" y="14" width="7" height="2" rx="1" transform="rotate(-90 11 14)" fill="currentColor"/>
												<rect x="11" y="17" width="2" height="2" rx="1" transform="rotate(-90 11 17)" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">On-Hold</span>
									<asp:Label ID="lblCntOnHold" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000019" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.3" x="2" y="2" width="20" height="20" rx="5" fill="currentColor"/>
												<path d="M10.4343 12.4343L8.75 10.75C8.33579 10.3358 7.66421 10.3358 7.25 10.75C6.83579 11.1642 6.83579 11.8358 7.25 12.25L10.2929 15.2929C10.6834 15.6834 11.3166 15.6834 11.7071 15.2929L17.25 9.75C17.6642 9.33579 17.6642 8.66421 17.25 8.25C16.8358 7.83579 16.1642 7.83579 15.75 8.25L11.5657 12.4343C11.2533 12.7467 10.7467 12.7467 10.4343 12.4343Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Completed</span>
									<asp:Label ID="lblCntCompleted" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Marked-->
								<a href="MNU000020" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/abstract/abs024.svg-->
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.3" x="2" y="2" width="20" height="20" rx="10" fill="currentColor"/>
												<path d="M11.276 13.654C11.276 13.2713 11.3367 12.9447 11.458 12.674C11.5887 12.394 11.738 12.1653 11.906 11.988C12.0833 11.8107 12.3167 11.61 12.606 11.386C12.942 11.1247 13.1893 10.896 13.348 10.7C13.5067 10.4947 13.586 10.2427 13.586 9.944C13.586 9.636 13.4833 9.356 13.278 9.104C13.082 8.84267 12.69 8.712 12.102 8.712C11.486 8.712 11.066 8.866 10.842 9.174C10.6273 9.482 10.52 9.82267 10.52 10.196L10.534 10.574H8.826C8.78867 10.3967 8.77 10.2333 8.77 10.084C8.77 9.552 8.90067 9.07133 9.162 8.642C9.42333 8.20333 9.81067 7.858 10.324 7.606C10.8467 7.354 11.4813 7.228 12.228 7.228C13.1987 7.228 13.9687 7.44733 14.538 7.886C15.1073 8.31533 15.392 8.92667 15.392 9.72C15.392 10.168 15.322 10.5507 15.182 10.868C15.042 11.1853 14.874 11.442 14.678 11.638C14.482 11.834 14.2253 12.0533 13.908 12.296C13.544 12.576 13.2733 12.8233 13.096 13.038C12.928 13.2527 12.844 13.528 12.844 13.864V14.326H11.276V13.654ZM11.192 15.222H12.928V17H11.192V15.222Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Clarification</span>
									<asp:Label ID="lblCntClarify" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Marked-->
							</div>
							<!--end::Menu item-->
							<!--begin::Menu item-->
							<div class="menu-item mb-3">
								<!--begin::Inbox-->
								<a href="MNU000021" class="menu-link">
									<span class="menu-icon">
										<!--begin::Svg Icon | path: icons/duotune/communication/com010.svg-->
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M17 6H3C2.4 6 2 6.4 2 7V21C2 21.6 2.4 22 3 22H17C17.6 22 18 21.6 18 21V7C18 6.4 17.6 6 17 6Z" fill="currentColor"/>
												<path d="M17.8 4.79999L9.3 13.3C8.9 13.7 8.9 14.3 9.3 14.7C9.5 14.9 9.80001 15 10 15C10.2 15 10.5 14.9 10.7 14.7L19.2 6.20001L17.8 4.79999Z" fill="currentColor"/>
												<path opacity="0.3" d="M22 9.09998V3C22 2.4 21.6 2 21 2H14.9L22 9.09998Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="menu-title fw-bolder">Upcoming</span>
									<asp:Label ID="lblCntUpcoming" runat="server" class="badge badge-secondary">0</asp:Label>
								</a>
								<!--end::Inbox-->
							</div>
							<!--end::Menu item-->
						</div>
						<!--end::Menu-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Card-->
				<asp:Button ID="lbtnCONSUpd" runat="server" Text="Button"  OnClick="lbtnCONSUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnCONMUpd" runat="server" Text="Button"  OnClick="lbtnCONMUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnPRGSUpd" runat="server" Text="Button"  OnClick="lbtnPRGSUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnPRGMUpd" runat="server" Text="Button"  OnClick="lbtnPRGMUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnSTSSUpd" runat="server" Text="Button"  OnClick="lbtnSTSSUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnSTSMUpd" runat="server" Text="Button"  OnClick="lbtnSTSMUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnUPLSUpd" runat="server" Text="Button"  OnClick="lbtnUPLSUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnUPLMUpd" runat="server" Text="Button"  OnClick="lbtnUPLMUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnNTESUpd" runat="server" Text="Button"  OnClick="lbtnNTESUpd_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="lbtnNTEMUpd" runat="server" Text="Button"  OnClick="lbtnNTEMUpd_Click" ClientIDMode="Static" style="display:none;"/>
			</ContentTemplate>
			</asp:UpdatePanel>
			<asp:UpdatePanel ID="upnlContent" runat="server" UpdateMode="Conditional" class="col-lg-9">
			<ContentTemplate>
				<!--begin::bar chart-->
		        <div class="card h-100 card-flush">
			        <!--begin::Body-->
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
								<a id="aCONMUpd" class="btn btn-sm btn-icon btn-light btn-active-light-primary" style="display:none" data-bs-toggle="tooltip" data-bs-placement="top" title="Update Contract" onclick="lbtnCONMUpd(this);">
									<span class="indicator-label">
										<!--begin::Svg Icon | path: icons/duotune/general/gen052.svg-->
										<span class="svg-icon svg-icon-2 m-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M18 22C19.7 22 21 20.7 21 19C21 18.5 20.9 18.1 20.7 17.7L15.3 6.30005C15.1 5.90005 15 5.5 15 5C15 3.3 16.3 2 18 2H6C4.3 2 3 3.3 3 5C3 5.5 3.1 5.90005 3.3 6.30005L8.7 17.7C8.9 18.1 9 18.5 9 19C9 20.7 7.7 22 6 22H18Z" fill="currentColor"/>
												<path d="M18 2C19.7 2 21 3.3 21 5H9C9 3.3 7.7 2 6 2H18Z" fill="currentColor"/>
												<path d="M9 19C9 20.7 7.7 22 6 22C4.3 22 3 20.7 3 19H9Z" fill="currentColor"/>
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</a>
								<a id="aPRGMUpd" class="btn btn-sm btn-icon btn-light btn-active-light-primary" style="display:none" data-bs-toggle="tooltip" data-bs-placement="top" title="Input Progress" onclick="lbtnPRGMUpd(this);">
									<span class="indicator-label">
										<!--begin::Svg Icon | path: icons/duotune/general/gen052.svg-->
										<span class="svg-icon svg-icon-2 m-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M17.8 8.79999L13 13.6L9.7 10.3C9.3 9.89999 8.7 9.89999 8.3 10.3L2.3 16.3C1.9 16.7 1.9 17.3 2.3 17.7C2.5 17.9 2.7 18 3 18C3.3 18 3.5 17.9 3.7 17.7L9 12.4L12.3 15.7C12.7 16.1 13.3 16.1 13.7 15.7L19.2 10.2L17.8 8.79999Z" fill="currentColor"/>
												<path opacity="0.3" d="M22 13.1V7C22 6.4 21.6 6 21 6H14.9L22 13.1Z" fill="currentColor"/>
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
						<div style="overflow-x:auto; scrollbar-width: thin;">
							<asp:GridView ID="gvTask" runat="server" class="table table-no-border table-row-bordered table-hover align-middle tscroll" AutoGenerateColumns="False" onscroll="scrollPos();" ShowHeaderWhenEmpty="true" >
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
												<input class='<%# Eval("checkBoxClass") %>' name='<%# Eval("SubID") %>' id="RowCheckbox" runat="server" type="checkbox" value="1" />
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-30px min-w-30px" />
										<ItemStyle CssClass="mw-30px min-w-30px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="On-Hold">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<a href='<%# Eval("Link") %>' class="d-flex align-items-center">
														<div class="d-flex flex-column-fluid">
															<div class="symbol symbol-30px overflow-hidden me-3">
																<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
															</div>
															<div class="d-flex flex-column min-w-300px">
																<span class="text-dark fw-bolder fs-6 text-truncate"><%# Eval("Title") %></span>
																<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
															</div>
														</div>
														<asp:UpdatePanel ID="upnlProgress" UpdateMode="Conditional" runat="server">
														<ContentTemplate>
															<div id="divProgress" runat="server" class="d-flex w-150px min-w-150px me-4">
																<%# Eval("Progress") %>
															</div>
														</ContentTemplate>
														</asp:UpdatePanel>
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
															<div class="menu-item px-3" <%# Eval("DisplayContract") %>>
																<a class="menu-link px-3" onclick="<%# Eval("lbtnCONSUpd") %>">Update Contract</a>
															</div>
															<!--end::Menu item-->
															<!--begin::Menu item-->
															<div class="menu-item px-3" <%# Eval("DisplayProgress") %>>
																<a class="menu-link px-3" onclick="<%# Eval("lbtnPRGSUpd") %>">Update Progress</a>
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
											<asp:Label ID="lblSubID" runat="server" Text='<%# Eval("SubID") %>' Visible="false"></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="w-100" />
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>
			        </div>
			        <!--end: Card Body-->
		        </div>
		        <!--end::bar chart-->
			</ContentTemplate>
			</asp:UpdatePanel>
		</div>
		<!--end::content-->
		
        <!--begin::Modal Add New Unit-->
		<div id="mdlANU" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen p-9" role="document">
				<div class="modal-content modal-rounded" id="Stepper">
					<div class="modal-header">
						<h5 class="modal-title">Add New Unit</h5>
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
					<!--begin::Modal body-->
					<div class="modal-body">
						<!--begin::Stepper-->
						<div class="stepper stepper-pills">
							<!--begin::Nav-->
							<div class="stepper-nav flex-center flex-wrap mb-10">
								<!--begin::Step 1-->
								<div class="stepper-item mx-2 my-4 current" data-kt-stepper-element="nav">
									<!--begin::Line-->
									<div class="stepper-line w-40px"></div>
									<!--end::Line-->
									<!--begin::Icon-->
									<div class="stepper-icon w-40px h-40px">
										<i class="stepper-check fas fa-check"></i>
										<span class="stepper-number">1</span>
									</div>
									<!--end::Icon-->
									<!--begin::Label-->
									<div class="stepper-label">
										<h3 class="stepper-title">
											Batch
										</h3>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Step 1-->
								<!--begin::Step 2-->
								<div class="stepper-item mx-2 my-4" data-kt-stepper-element="nav">
									<!--begin::Line-->
									<div class="stepper-line w-40px"></div>
									<!--end::Line-->
									<!--begin::Icon-->
									<div class="stepper-icon w-40px h-40px">
										<i class="stepper-check fas fa-check"></i>
										<span class="stepper-number">2</span>
									</div>
									<!--end::Icon-->
									<!--begin::Label-->
									<div class="stepper-label">
										<h3 class="stepper-title">
											Units
										</h3>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Step 2-->
								
								<!--begin::Step 3-->
								<div class="stepper-item mx-2 my-4" data-kt-stepper-element="nav">
									<!--begin::Line-->
									<div class="stepper-line w-40px"></div>
									<!--end::Line-->
									<!--begin::Icon-->
									<div class="stepper-icon w-40px h-40px">
										<i class="stepper-check fas fa-check"></i>
										<span class="stepper-number">3</span>
									</div>
									<!--begin::Icon-->
									<!--begin::Label-->
									<div class="stepper-label">
										<h3 class="stepper-title">
											Review
										</h3>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Step 3-->

								<!--begin::Step 3-->
								<div class="stepper-item mx-2 my-4" data-kt-stepper-element="nav">
									<!--begin::Line-->
									<div class="stepper-line w-40px"></div>
									<!--end::Line-->
									<!--begin::Icon-->
									<div class="stepper-icon w-40px h-40px">
										<i class="stepper-check fas fa-check"></i>
										<span class="stepper-number">4</span>
									</div>
									<!--begin::Icon-->
									<!--begin::Label-->
									<div class="stepper-label">
										<h3 class="stepper-title">
											Completed
										</h3>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Step 3-->
							</div>
							<!--end::Nav-->
							<!--begin::Form-->
							<div class="form w-lg-1000px mx-auto">
								<!--begin::Group-->
								<div class="mb-5">
									<!--begin::Step 1-->
									<div class="flex-column current" data-kt-stepper-element="content">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Batch</span>
											<asp:DropDownList ID="ddlANUBatch" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddlANUBatch(this);">
												<asp:ListItem Value="">Select batch</asp:ListItem>
											</asp:DropDownList>
										</div>
									</div>
									<!--begin::Step 1-->
									<!--begin::Step 2-->
									<div class="flex-column" data-kt-stepper-element="content">
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
												<input id="tbxSearchUnit" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
											</div>
											<!--end::Search-->
										</div>
										<!--begin::gridview-->
										<table id="gvANU" class="table table-no-border table-row-bordered table-hover align-middle">
											<thead>
												<tr>
													<th>
										
													</th>
													<th class="fw-bold fs-6 text-dark min-w-100px">
														Code
													</th>
													<th class="fw-bold fs-6 text-dark min-w-150px">
														Project
													</th>
													<th class="fw-bold fs-6 text-dark min-w-200px">
														Unit
													</th>
													<th class="fw-bold fs-6 text-dark min-w-100px">
														Batch
													</th>
													<th class="fw-bold fs-6 text-dark min-w-100px">
														Status
													</th>
													<th class="fw-bold fs-6 text-dark min-w-125px">
														Action
													</th>
												</tr>
											</thead>
										</table>
										<!--end::gridview-->
									</div>
									<!--begin::Step 2-->
									<!--begin::Step 3-->
									<div class="flex-column" data-kt-stepper-element="content">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Batch</span>
											<asp:Label ID="lblBatch" runat="server" class="form-control">-</asp:Label>
										</div>
										<!--begin::gridview-->
										<table id="gvReview" class="table table-no-border table-row-bordered table-hover align-middle">
											<thead>
												<tr>
													<th>
										
													</th>
													<th class="fw-bold fs-6 text-dark min-w-100px">
														Code
													</th>
													<th class="fw-bold fs-6 text-dark min-w-150px">
														Project
													</th>
													<th class="fw-bold fs-6 text-dark min-w-200px">
														Unit
													</th>
													<th class="fw-bold fs-6 text-dark min-w-100px">
														Batch
													</th>
													<th class="fw-bold fs-6 text-dark min-w-100px">
														Status
													</th>
													<th class="fw-bold fs-6 text-dark min-w-125px">
														Action	
													</th>
												</tr>
											</thead>
										</table>
										<!--end::gridview-->
									</div>
									<!--begin::Step 3-->
									<!--begin::Step 4-->
									<div class="flex-column" data-kt-stepper-element="content">
										<div class="w-100 text-center">
											<!--begin::Heading-->
											<h1 class="fw-bolder text-dark mb-3">Success!</h1>
											<!--end::Heading-->
											<!--begin::Description-->
											<div class="text-muted fw-bold fs-3">Units are successfully created.</div>
											<!--end::Description-->
											<!--begin::Illustration-->
											<div class="text-center px-4 py-15">
												<img src="Assets/media/illustrations/sigma-1/9.png" alt="" class="mw-100 mh-300px" />
											</div>
											<!--end::Illustration-->
										</div>
									</div>
									<!--begin::Step 4-->
								</div>
								<!--end::Group-->
							</div>
							<!--end::Form-->
						</div>
						<!--end::Stepper-->
					</div>
					<!--end::Modal body-->
					<div class="modal-footer">
						<!--begin::Actions-->
						<div class="d-flex flex-stack">
							<!--begin::Wrapper-->
							<div class="me-2">
								<button type="button" class="btn btn-light btn-active-light-primary" data-kt-stepper-action="previous">
									Back
								</button>
							</div>
							<!--end::Wrapper-->
							<!--begin::Wrapper-->
							<div>
								<button type="button" class="btn btn-primary" data-kt-stepper-action="submit">
									<span class="indicator-label">
										Submit
									</span>
									<span class="indicator-progress">
										Please wait... <span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</button>
								<button type="button" class="btn btn-primary " data-kt-stepper-action="next">
									Continue
								</button>
								<button type="button" class="btn btn-primary " data-kt-stepper-action="finish">
									Finish
								</button>
							</div>
							<!--end::Wrapper-->
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Add New Unit-->

		<!--begin::Modal Contract-->
		<asp:UpdatePanel ID="mdlCON" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Update Contract</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabCONInput">Inputs</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tabCONItem">Items</a>
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
							<div class="tab-pane fade show active" id="tabCONInput" role="tabpanel">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Contractor</span>
									<asp:DropDownList ID="ddlCONContractor" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
										<asp:ListItem Value="">Select contractor</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Category</span>
									<asp:DropDownList ID="ddlCONCategory" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
										<asp:ListItem Value="">Select category</asp:ListItem>
										<asp:ListItem Value="Job Order">Job Order</asp:ListItem>
										<asp:ListItem Value="Contract Agreement">Contract Agreement</asp:ListItem>
										<asp:ListItem Value="Variation Order">Variation Order</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Type</span>
									<asp:DropDownList ID="ddlCONType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
										<asp:ListItem Value="">Select a type</asp:ListItem>
										<asp:ListItem Value="OSM">OSM</asp:ListItem>
										<asp:ListItem Value="Packaged">Packaged</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">No.</span>
									<input id="tbxCONNo" runat="server" class='form-control' placeholder="Add contract no." />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Price</span>
									<input id="tbxCONPrice" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">VAT</span>
									<input id="tbxCONVAT" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">EWT</span>
									<input id="tbxCONEWT" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Down Payment</span>
									<input id="tbxCONDP" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Retention Fee</span>
									<input id="tbxCONRF" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Prior Start</span>
									<input id="tbxCONPriorStart" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:DropDownList ID="ddlCONStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
										<asp:ListItem Value="">Select a status</asp:ListItem>
										<asp:ListItem Value="For Award">For Award</asp:ListItem>
										<asp:ListItem Value="Awarded">Awarded</asp:ListItem>
										<asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Date Awarded</span>
									<input id="tbxCONDateAwarded" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
								</div>
							</div>
							<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin; max-height:486px;min-height:486px" id="tabCONItem" role="tabpanel">
								<asp:GridView ID="gvCONSelected" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
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
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblSubID" runat="server" Text='<%# Eval("SubID") %>' Visible="false"></asp:Label>
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
						<asp:LinkButton ID="lbtnCONUpdOk" runat="server" class="btn btn-primary">Save</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Contract-->
		
		<!--begin::Modal Progress-->
		<asp:UpdatePanel ID="mdlPRG" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Update Progress</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabPRGInput">Inputs</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tabPRGItem">Items</a>
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
							<div class="tab-pane fade show active" id="tabPRGInput" role="tabpanel">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Rate</span>
									<input id="tbxPRGRate" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Date</span>
									<input id="tbxPRGDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
								</div>
								<div class="input-group input-group-sm">
									<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
									<asp:TextBox ID="tbxPRGRemarks" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
								</div>
							</div>
							<div class="tab-pane fade" style="overflow-x:auto; scrollbar-width: thin; max-height:281px;min-height:281px" id="tabPRGItem" role="tabpanel">
								<asp:GridView ID="gvPRGSelected" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
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
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblSubID" runat="server" Text='<%# Eval("SubID") %>' Visible="false"></asp:Label>
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
						<asp:LinkButton ID="lbtnPRGUpdOk" runat="server" class="btn btn-primary">Save changes</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Progress-->

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
										<asp:ListItem Value="">Select status</asp:ListItem>
										<asp:ListItem Value="Assign">Assign</asp:ListItem>
										<asp:ListItem Value="On-Going">On-Going</asp:ListItem>
										<asp:ListItem Value="On-Hold">On-Hold</asp:ListItem>
										<asp:ListItem Value="Complete">Complete</asp:ListItem>
										<asp:ListItem Value="Clarify">Clarify</asp:ListItem>
										<asp:ListItem Value="Close">Close</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div id="divSTSActDateEnd" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
									<span class="input-group-text min-w-150px required">Date Completed</span>
									<input id="tbxSTSActDateEnd" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Assign to</span>
									<asp:DropDownList ID="ddlSTSAssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlSTS" class="form-select form-select-sm form-select-border min-h-35px">
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
													<div class="d-flex flex-column">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
												</div>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblSubID" runat="server" Text='<%# Eval("SubID") %>' Visible="false"></asp:Label>
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
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblSubID" runat="server" Text='<%# Eval("SubID") %>' Visible="false"></asp:Label>
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
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
												<asp:Label ID="lblSubID" runat="server" Text='<%# Eval("SubID") %>' Visible="false"></asp:Label>
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
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hfSubID" runat="server" />
		<asp:HiddenField ID="hfRowIdx" runat="server" />
		<asp:HiddenField ID="hfMention" runat="server" />
		<asp:HiddenField ID="hfBatch" runat="server" />
		<asp:HiddenField ID="hfCodeSrs" runat="server" />
		<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
		<!--begin::hidden variable-->
	</div>
	<!--end::Post-->

	<!-- scripts related to this page -->
    <script type="text/javascript">
        //function related to this page only
        function ShowANU() {
            //show stepper
            $('#mdlANU').modal('show');
            //show stepper
        }
        function ddlANUBatch(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectText = selectObj.options[selectIndex].text;
            var selectValue = selectObj.options[selectIndex].value;
            var hfBatch = document.getElementById("ContentPlaceHolder1_hfBatch");
            hfBatch.value = selectValue;
            var lblBatch = document.getElementById("ContentPlaceHolder1_lblBatch");
            lblBatch.innerText = selectText;
        }
        var input = document.getElementById("tbxSearchUnit");
        input.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                SearchUnit(input.value);
            }
        });
        function SearchUnit(Find) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'MNU000017',
                    'Type': 'View Unit',
                    'Find': Find
                },
                success: function (response) {
                    //datatable
                    var gvANU = $("#gvANU").DataTable({
                        bFilter: false,
                        bSort: false,
                        bPaginate: false,
                        bDestroy: true,
                        bInfo: false,
                        scrollCollapse: true,
                        scrollY: '49vh',
                        scrollX: true,
                        fixedColumns: { left: 3 },
                        data: response,
                        columns: [
                            { data: 'Bullet' },
                            { data: 'Code' },
                            { data: 'Project' },
                            { data: 'Unit' },
                            { data: 'Batch' },
                            { data: 'Status' },
                            { data: 'Button' }]
                    });
                    //datatable
                    //search
                    $('#tbxSearchUnit').on('keyup', function () {
                        gvANU.search(this.value).draw();
                    });
                    //search
                },
            });
        }
        function btnAddCode(aBtn) {
            // Disable button to avoid multiple click 
            aBtn.disabled = true;

            // Show loading indication
            aBtn.setAttribute('data-kt-indicator', 'on');

            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                aBtn.removeAttribute('data-kt-indicator');

                // Enable button
                aBtn.disabled = false;

                var Code = aBtn.getAttribute('code');
                var hfCodeSrs = document.getElementById("ContentPlaceHolder1_hfCodeSrs");
                hfCodeSrs.value = hfCodeSrs.value + "," + Code;

            }, 1000);
        };
        function btnRemoveCode(aBtn) {
            // Disable button to avoid multiple click 
            aBtn.disabled = true;

            // Show loading indication
            aBtn.setAttribute('data-kt-indicator', 'on');

            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                aBtn.removeAttribute('data-kt-indicator');

                // Enable button
                aBtn.disabled = false;

                // set value
                var Code = aBtn.getAttribute('code');
                var hfCodeSrs = document.getElementById("ContentPlaceHolder1_hfCodeSrs");
                let text = hfCodeSrs.value;
                hfCodeSrs.value = text.replace("," + Code, "");

                //hide row
                var parent = aBtn.closest("tr");
                $(parent).fadeOut(function () {
                    aBtn.remove();
                });

            }, 1000);
        };
        function lbtnCONSUpd(ID, SubID, RowIdx) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            var hfSubID = document.getElementById("ContentPlaceHolder1_hfSubID");
            var hfRowIdx = document.getElementById("ContentPlaceHolder1_hfRowIdx");
            hfID.value = ID;
            hfSubID.value = SubID;
            hfRowIdx.value = RowIdx;
            var clickButton = document.getElementById("<%= lbtnCONSUpd.ClientID %>");
            clickButton.click();
        }
        function lbtnCONMUpd(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnCONMUpd.ClientID %>");
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
        function lbtnPRGSUpd(ID, SubID, RowIdx) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            var hfSubID = document.getElementById("ContentPlaceHolder1_hfSubID");
            var hfRowIdx = document.getElementById("ContentPlaceHolder1_hfRowIdx");
            hfID.value = ID;
            hfSubID.value = SubID;
            hfRowIdx.value = RowIdx;
            var clickButton = document.getElementById("<%= lbtnPRGSUpd.ClientID %>");
            clickButton.click();
        }
        function lbtnPRGMUpd(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnPRGMUpd.ClientID %>");
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
        function lbtnSTSSUpd(ID, SubID, RowIdx) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            var hfSubID = document.getElementById("ContentPlaceHolder1_hfSubID");
            var hfRowIdx = document.getElementById("ContentPlaceHolder1_hfRowIdx");
            hfID.value = ID;
            hfSubID.value = SubID;
            hfRowIdx.value = RowIdx;
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

            var divSTSActDateEnd = document.getElementById("ContentPlaceHolder1_divSTSActDateEnd");
            var tbxSTSActDateEnd = document.getElementById("ContentPlaceHolder1_tbxSTSActDateEnd");
            divSTSActDateEnd.style.display = "none";
            tbxSTSActDateEnd.value = "";

            if (selectValue == "Complete") {
                divSTSActDateEnd.style.display = "";
            }
        }
        function lbtnUPLSUpd(ID, SubID, RowIdx) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            var hfSubID = document.getElementById("ContentPlaceHolder1_hfSubID");
            var hfRowIdx = document.getElementById("ContentPlaceHolder1_hfRowIdx");
            hfID.value = ID;
            hfSubID.value = SubID;
            hfRowIdx.value = RowIdx;
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
        function lbtnNTESUpd(ID, SubID, RowIdx) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            var hfSubID = document.getElementById("ContentPlaceHolder1_hfSubID");
            var hfRowIdx = document.getElementById("ContentPlaceHolder1_hfRowIdx");
            hfID.value = ID;
            hfSubID.value = SubID;
            hfRowIdx.value = RowIdx;
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
			var aCONMUpd = document.getElementById("aCONMUpd");
            var aPRGMUpd = document.getElementById("aPRGMUpd");
            var aSTSMUpd = document.getElementById("aSTSMUpd");
            var aUPLMUpd = document.getElementById("aUPLMUpd");
			var aNTEMUpd = document.getElementById("aNTEMUpd");

            if ($(this).is(":checked")) {
                //get tr which is visible ..add checked to that checkboxes
                $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                aSTSMUpd.style.display = "";
                aUPLMUpd.style.display = "";
                aNTEMUpd.style.display = "";
            } else {
                //remove checked
                $(".checkBoxClass").prop('checked', false);
                aSTSMUpd.style.display = "none";
                aUPLMUpd.style.display = "none";
                aNTEMUpd.style.display = "none";
			}
            if ($('.subid005:checked').length > 0) {
                aCONMUpd.style.display = "";
            } else {
                aCONMUpd.style.display = "none";
            }
            if ($('.subid006:checked').length > 0) {
                aPRGMUpd.style.display = "";
            } else {
                aPRGMUpd.style.display = "none";
            }
        })
        $(".checkBoxClass").change(function () {
			var aSTSMUpd = document.getElementById("aSTSMUpd");
            var aUPLMUpd = document.getElementById("aUPLMUpd");
            var aNTEMUpd = document.getElementById("aNTEMUpd");
			if (!$(this).prop("checked")) {
				$(".checkBoxAllClass").prop("checked", false);
			}
            if ($('.checkBoxClass:checked').length > 0) {
                aSTSMUpd.style.display = "";
                aUPLMUpd.style.display = "";
                aNTEMUpd.style.display = "";
            } else {
                aSTSMUpd.style.display = "none";
                aUPLMUpd.style.display = "none";
                aNTEMUpd.style.display = "none";
			}
		});
        $(".subid005").change(function () {
            var aCONMUpd = document.getElementById("aCONMUpd");
            if ($('.subid005:checked').length > 0) {
                aCONMUpd.style.display = "";
            } else {
                aCONMUpd.style.display = "none";
            }
		});
        $(".subid006").change(function () {
            var aPRGMUpd = document.getElementById("aPRGMUpd");
            if ($('.subid006:checked').length > 0) {
                aPRGMUpd.style.display = "";
            } else {
                aPRGMUpd.style.display = "none";
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
                var KTMNU000017 = function () {
					//create variable
					var stepper;
                    var formFinishButton;
					var formSubmitButton;
                    var formContinueButton;
                    var formPreviousButton;
                    var hfBatch;
                    var hfCodeSrs;
					var stepperObj;
					//create variable

                    //stepper Functions
                    var initStepper = function () {
                        //Initialize Stepper
                        stepperObj = new KTStepper(stepper);
						//Initialize Stepper

                        //display button on stepper page
						stepperObj.on('kt.stepper.changed', function (stepper) {
							
							if (stepperObj.getCurrentStepIndex() === 4) {
                                formPreviousButton.classList.add('d-none');
								formContinueButton.classList.add('d-none');
								formSubmitButton.classList.add('d-none');
								formFinishButton.classList.remove('d-none');
								formFinishButton.classList.add('d-inline-block');
							} else if (stepperObj.getCurrentStepIndex() === 3) {
                                formPreviousButton.classList.remove('d-none');
                                formPreviousButton.classList.add('d-inline-block');
                                formContinueButton.classList.add('d-none');
                                formSubmitButton.classList.remove('d-none');
								formSubmitButton.classList.add('d-inline-block');
                                formFinishButton.classList.add('d-none');
                            } else if (stepperObj.getCurrentStepIndex() === 2) {
                                formPreviousButton.classList.remove('d-none');
                                formPreviousButton.classList.add('d-inline-block');
                                formContinueButton.classList.remove('d-none');
                                formContinueButton.classList.add('d-inline-block');
								formSubmitButton.classList.add('d-none');
                                formFinishButton.classList.add('d-none');
                            } else {
                                formPreviousButton.classList.add('d-none');
                                formContinueButton.classList.remove('d-none');
                                formContinueButton.classList.add('d-inline-block');
								formSubmitButton.classList.add('d-none');
                                formFinishButton.classList.add('d-none');
                            }
                        });
						 //display button on stepper page

                        //Validation before going to next page
                        stepperObj.on('kt.stepper.next', function (stepper) {

                            if (stepper.getCurrentStepIndex() === 1 && hfBatch.value == "") {
                                // Show error message popup. 
                                Swal.fire({
                                    text: "Some fields are missing!",
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "Ok, got it!",
                                    customClass: {
                                        confirmButton: "btn btn-light-danger"
                                    }
                                }).then(function () {
                                    //KTUtil.scrollTop();
                                });
                            } else if (stepper.getCurrentStepIndex() === 2 && hfCodeSrs.value == "") {
                                // Show error message popup.
                                Swal.fire({
                                    text: "No unit selected!",
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "Ok, got it!",
                                    customClass: {
                                        confirmButton: "btn btn-light-danger"
                                    }
                                }).then(function () {
                                    //KTUtil.scrollTop();
                                });
                            } else {
                                stepper.goNext();

                                $.ajax({
                                    type: "POST",
                                    url: "HND000003.ashx",
                                    data: {
                                        'FormCode': 'MNU000017',
                                        'Type': 'View Review',
                                        'CodeSrs': hfCodeSrs.value
                                    },
                                    success: function (response) {
                                        //datatable
                                        var gvReview = $("#gvReview").DataTable({
                                            bFilter: false,
                                            bSort: false,
                                            bPaginate: false,
                                            bDestroy: true,
                                            bInfo: false,
                                            scrollCollapse: true,
                                            scrollY: '49vh',
                                            scrollX: true,
                                            fixedColumns: { left: 3 },
                                            data: response,
                                            columns: [
                                                { data: 'Bullet' },
                                                { data: 'Code' },
                                                { data: 'Project' },
                                                { data: 'Unit' },
                                                { data: 'Batch' },
                                                { data: 'Status' },
                                                { data: 'Button' }]
                                        });
                                        //datatable
                                    },
                                });

                                KTUtil.scrollTop();
                            }
                        });
						//Validation before going to next page

                        //Previous event
                        stepperObj.on('kt.stepper.previous', function (stepper) {
                            stepper.goPrevious();
                            KTUtil.scrollTop();
                        });
						//Previous event

                        // Submit event
                        formSubmitButton.addEventListener('click', function (e) {

							if (hfCodeSrs.value == "") {
								// Show error message popup.
								Swal.fire({
									text: "No unit selected!",
									icon: "error",
									buttonsStyling: false,
									confirmButtonText: "Ok, got it!",
									customClass: {
										confirmButton: "btn btn-light-danger"
									}
								}).then(function () {
									//KTUtil.scrollTop();
								});
							} else {
                                // Prevent default button action
                                e.preventDefault();

                                // Disable button to avoid multiple click 
                                formSubmitButton.disabled = true;

                                // Show loading indication
                                formSubmitButton.setAttribute('data-kt-indicator', 'on');

                                // Simulate form submission
                                setTimeout(function () {
                                    // Hide loading indication
                                    formSubmitButton.removeAttribute('data-kt-indicator');

                                    // Enable button
                                    formSubmitButton.disabled = false;

                                    $.ajax({
                                        type: "POST",
                                        url: "HND000003.ashx",
                                        data: {
                                            'FormCode': 'MNU000017',
                                            'Type': 'Submit',
                                            'BatchNo': hfBatch.value,
                                            'LotCodeSrs': hfCodeSrs.value
                                        },
                                        success: function (response) {

                                        },
                                    });

                                    hfCodeSrs.value = "";
                                    stepperObj.goNext();
                                    KTUtil.scrollTop();

                                }, 10000);
							}
						});
						// Submit event

                        // Finish event
                        formFinishButton.addEventListener('click', function (e) {
							//hide stepper
							$('#mdlANU').modal('hide');
							//hide stepper
                            stepperObj.goTo(1);
						});
						// Finish event
                    }
                    return {
                        // Public Functions
                        init: function () {
                            stepper = document.querySelector('#Stepper');
                            formPreviousButton = stepper.querySelector('[data-kt-stepper-action="previous"]');
							formSubmitButton = stepper.querySelector('[data-kt-stepper-action="submit"]');
                            formFinishButton = stepper.querySelector('[data-kt-stepper-action="finish"]');
                            formContinueButton = stepper.querySelector('[data-kt-stepper-action="next"]');
                            hfBatch = document.getElementById("ContentPlaceHolder1_hfBatch");
                            hfCodeSrs = document.getElementById("ContentPlaceHolder1_hfCodeSrs");
                            formPreviousButton.classList.add('d-none');
                            formContinueButton.classList.remove('d-none');
                            formContinueButton.classList.add('d-inline-block');
							formSubmitButton.classList.add('d-none');
                            formFinishButton.classList.add('d-none');

                            initStepper();
                        }
                    };
                }();
                // On document ready
                KTUtil.onDOMContentLoaded(function () {
                    KTMNU000017.init();
                });
			});
            jQuery(function ($) {
                //form variable
				var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
                var lblUPLIDsrs = document.getElementById("ContentPlaceHolder1_lblUPLIDsrs");
                //form variable
				document.querySelector('#ContentPlaceHolder1_gvTask > tbody').setAttribute("onscroll", "scrollPos()");				var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");				document.querySelector('#ContentPlaceHolder1_gvTask > tbody').scrollTop = hfScrollPosition.value;                //metion                jq.fn.atwho.debug = true;
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
                };				//metion

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
                    url: "HND000004.ashx?FormCode=" + ltrlFormCode + "&IDSrs=" + lblUPLIDsrs.value,
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
