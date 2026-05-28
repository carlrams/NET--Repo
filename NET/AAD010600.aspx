<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010600.aspx.vb" Inherits="NET.PendingRequirements" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="~/MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<!--begin::Post-->
	<div class="content flex-row-fluid" id="kt_content">
	<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
		<div class="toolbar py-5">
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">
							<a href="AAD010000" class="text-white text-hover-primary">Dashboard</a>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Requirements</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<asp:Button ID="btnViewREQForVerificationSubmitted" runat="server" Text="Button" OnClick="btnViewREQForVerificationSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewREQForVerificationSubmittedDtl" runat="server" Text="Button" OnClick="btnViewREQForVerificationSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		<%--<asp:Button ID="btnREQForVerificationSubmittedBatchVerify" runat="server" Text="Button" OnClick="btnREQForVerificationSubmittedBatchVerify_Click" ClientIDMode="Static" style="display:none;"/>--%>
		<asp:Button ID="btnREQVerifySubmittedRevert" runat="server" Text="Button" OnClick="btnREQVerifySubmittedRevert_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewREQVerifiedSubmitted" runat="server" Text="Button" OnClick="btnViewREQVerifiedSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewREQVerifiedSubmittedDtl" runat="server" Text="Button" OnClick="btnViewREQVerifiedSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
		<!--begin::Container-->
		<div id="kt_content_container" class="d-flex flex-column-fluid align-items-start container-xxl">
			<!--begin::Post-->
			<div class="content flex-row-fluid" id="kt_content2">
			<!--begin::Navbar-->
				<div class="card card-flush pb-0 bgi-position-y-center bgi-no-repeat mb-5" style="background-size: auto calc(100% + 10rem); background-position-x: 100%; background-image: url('assets/media/custom/pdc.png')">
					<div class="card-body pt-20 pb-10">
						<!--begin::Details-->
						<div class="d-flex flex-wrap flex-sm-nowrap">
							<!--begin::Info-->
							<div class="flex-grow-1">
								<!--begin::Title-->
								<div class="d-flex justify-content-between align-items-start flex-wrap mb-2">
									<!--begin::User-->
									<div class="d-flex flex-column">
										<!--begin::Name-->
										<div class="d-flex align-items-center mb-2">
											<span class="text-gray-900 fs-2 fw-bolder me-1">Requirements</span>
										</div>
										<!--end::Name-->
									</div>
									<!--end::User-->
								</div>
								<!--end::Title-->
							</div>
							<!--end::Info-->
						</div>
						<!--end::Details-->
						<!--begin::Navs-->
						<asp:UpdatePanel ID="upnlPDCTotal" runat="server" UpdateMode="Conditional" >
							<ContentTemplate>
								<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
									<!--begin::Nav item-->
									<li class="nav-item">
										<a id="pending_tab_1" class="nav-link text-active-gray-800 me-4 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlREQForVerificationList">For Verification &nbsp; <span class="badge badge-square bg-warning py-2 px-3"><asp:Label ID="lblREQForVerificationListTotal" runat="server"></asp:Label></span> </a>
									</li>
									<!--end::Nav item-->

									<!--begin::Nav item-->
									<li class="nav-item">
										<a id="history_tab_2" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlREQVerifiedList">Verified &nbsp; <span class="badge badge-square bg-success py-2 px-3"><asp:Label ID="lblREQVerifiedListTotal" runat="server"></asp:Label></span></a>
									</li>
									<!--end::Nav item-->											
								</ul>
							</ContentTemplate>
						</asp:UpdatePanel>
						<!--begin::Navs-->
					</div>
				</div>
				<!--end::Navbar-->
				<!--begin::Timeline-->
				<div class="card">
					<!--begin::Card head-->
					<div class="card-header card-header-stretch">
						<!--begin::Title-->
						<div class="card-title d-flex align-items-center">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder text-dark">Requirements Status</span>
								<span class="text-gray-400 pt-2 fw-bold fs-6"><asp:Label ID="lblDate" runat="server"></asp:Label></span>
							</h3>
						</div>
						<!--end::Title-->
						<!--begin::Search-->
						<div class="d-flex align-items-center position-relative m-1">
							<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
							<span class="svg-icon svg-icon-2 position-absolute ms-4">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
									<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
							<input id="tbxREQSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
						</div>
						<!--end::Search-->
					</div>
					<!--end::Card head-->
					<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Tab Content-->
						<div class="tab-content">
							<!--begin::Tab panel-->
							<asp:UpdatePanel ID="upnlREQForVerificationList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvREQForVerificationList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<span class="bullet bullet-margin bullet-vertical h-40px bg-warning"></span>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Account No.">
													<ItemTemplate>
														<div class="d-flex align-items-center">
															<div class="d-flex flex-column">
																<span class="fw-bold fs-7 text-dark"><%# Eval("AcctNo") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="min-w-80px"/>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Name">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<div class="flex-grow-1 me-2">
																<span class="fw-bold fs-7 text-dark"><%# Eval("Fullname") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Total Submitted">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<div class="flex-grow-1 me-2">
																<span class="badge badge-light-success"><%# Eval("TotalSubmitted") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Actions">
													<ItemTemplate>
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewREQForVerificationSubmitted") %>">
															<span class="svg-icon svg-icon-2">
															<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
																<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
															</svg>
															</span>
														</a>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
												</asp:TemplateField>
											</Columns>
											<EmptyDataTemplate>
												<div align="center">No data available.</div>
											</EmptyDataTemplate>
										</asp:GridView>
									</div>
								</ContentTemplate>
							</asp:UpdatePanel>
							<!--end::Tab panel-->

							<!--begin::Tab panel-->
							<asp:UpdatePanel ID="upnlREQVerifiedList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvREQVerifiedList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<span class="bullet bullet-margin bullet-vertical h-40px bg-success"></span>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Account No.">
													<ItemTemplate>
														<div class="d-flex align-items-center">
															<div class="d-flex flex-column">
																<span class="fw-bold fs-7 text-dark"><%# Eval("AcctNo") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="min-w-80px"/>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Name">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<div class="flex-grow-1 me-2">
																<span class="fw-bold fs-7 text-dark"><%# Eval("Fullname") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Actions">
													<ItemTemplate>
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewREQVerifiedList") %>">
															<span class="svg-icon svg-icon-2">
																<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
																	<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
																</svg>
															</span>
														</a>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
												</asp:TemplateField>
											</Columns>
											<EmptyDataTemplate>
												<div align="center">No data available.</div>
											</EmptyDataTemplate>
										</asp:GridView>
									</div>
								</ContentTemplate>
							</asp:UpdatePanel>
							<!--end::Tab panel-->
						</div>
					</div>
					<!--end::Tab panel-->
				</div>
				<!--end::Tab Content-->
			</div>
			<!--end::Card body-->
		</div>
		<!--end::Container-->
	</div>
	<!--end::Post-->

	<!--begin::Modal Edit-->
	<asp:UpdatePanel ID="mdlREQForVerificationSubmitted2" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lbl01RequirementsTitle" runat="server"></asp:Label></h5>
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
						<!--begin::Requirement Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">Client Details</h3>
								<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
									<div class="ribbon-icon mt-n5 me-n6">
										<i class="bi bi-card-text fs-3 text-white"></i>
									</div>
								</div>
							</div>
							<div class="card-body">
								<asp:Label ID="lbl01REQCode" runat="server" visible="false"></asp:Label>
								<asp:Label ID="lbl01DocsCode" runat="server" visible="false"></asp:Label>
								<asp:Label ID="lbl01FilePath" runat="server" style="display:none;"></asp:Label>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Account No.</span>
									<asp:Label ID="lbl01AcctNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Name</span>
									<asp:Label ID="lbl01Name" runat="server" class="form-control">-</asp:Label>
								</div>
								<asp:Label ID="lbl01Email" runat="server" class="form-control" Visible="false">-</asp:Label>
							</div>
						</div>
						<!--end::Requirement Details-->
							<!--begin::Docs Details-->
								<div class="card shadow-sm mb-6">
		<!--begin::Header-->
		<div class="card-header position-relative min-h-50px p-0 border-bottom-2">
			<!--begin::Nav-->
			<ul class="nav nav-pills nav-pills-custom d-flex position-relative w-100">
				<!--begin::Item-->
				<li class="nav-item mx-0 p-0 w-50">
					<!--begin::Link-->
					<a class="nav-link btn btn-color-muted active border-0 h-100 px-0" data-bs-toggle="pill" id="kt_forms_widget_1_tab_1" href="#kt_forms_widget_1_tab_content_1">
						<!--begin::Subtitle-->
						<span class="nav-text fw-bolder fs-4 mb-3">Overview</span>
						<span class="badge badge-lg badge-square badge-success align-self-center px-2"><asp:Label ID="lbl01TotalOverview" runat="server"></asp:Label></span>
						<!--end::Subtitle-->
						<!--begin::Bullet-->
						<span class="bullet-custom position-absolute z-index-2 w-100 h-2px top-100 bottom-n100 bg-primary rounded"></span>
						<!--end::Bullet-->
					</a>
					<!--end::Link-->
				</li>
				<!--end::Item-->
				<!--begin::Item-->
				<li class="nav-item mx-0 px-0 w-50">
					<!--begin::Link-->
					<a class="nav-link btn btn-color-muted border-0 h-100 px-0" data-bs-toggle="pill" id="kt_forms_widget_1_tab_2" href="#kt_forms_widget_1_tab_content_2">
						<!--begin::Subtitle-->
						<span class="nav-text fw-bolder fs-4 mb-3">Submitted</span>
						<span class="badge badge-lg badge-square badge-success" ><asp:Label ID="lbl01SubmittedTotal" runat="server"></asp:Label></span>
						<!--end::Subtitle-->
						<!--begin::Bullet-->
						<span class="bullet-custom position-absolute z-index-2 w-100 h-2px top-100 bottom-n100 bg-primary rounded"></span>
						<!--end::Bullet-->
					</a>
					<!--end::Link-->
				</li>
				<!--end::Item-->
			</ul>
			<!--end::Nav-->
		</div>
		<!--end::Header-->
		<!--begin::Body-->
		<div class="card-body">
			<!--begin::Tab Content-->
			<div class="tab-content">
				<!--begin::Tap pane-->
				<div class="tab-pane fade active show" id="kt_forms_widget_1_tab_content_1">
					<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
						<!--begin::Table-->
						<asp:GridView ID="gv01LackingDocs" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="False">
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
									</ItemTemplate>
									<ItemStyle Width="3%" />
								</asp:TemplateField>
								<asp:TemplateField>
									<ItemTemplate>
										<div class="d-flex align-items-center flex-row-fluid flex-wrap">
											<div class="symbol symbol-35px me-3">
												<div class="symbol-label bg-light">
													<img src="Assets/media/svg/files/doc.svg" class="h-50" alt="" />
												</div>
											</div>
										</div>
									</ItemTemplate>
									<ItemStyle Width="10%" />
								</asp:TemplateField>
								<asp:TemplateField>
									<ItemTemplate>
										<div class="d-flex align-items-center flex-row-fluid flex-wrap">
											<div class="flex-grow-1 me-2">
												<span class="text-gray-800 fs-7 fw-bolder"><%# Eval("ReqDesc") %></span>
											</div>
										</div>
									</ItemTemplate>
									<ItemStyle Width="80%" />
								</asp:TemplateField>
								<asp:TemplateField>
									<ItemTemplate>
										<div class="d-flex align-items-center flex-row-fluid flex-wrap">
											<span class="svg-icon svg-icon-2x svg-icon-danger">
												<img src="Assets/media/svg/docs-verified/check.svg" class="h-50" alt="" />
											</span>
										</div>
									</ItemTemplate>
									<ItemStyle Width="5%" />
								</asp:TemplateField>
								<asp:TemplateField>
									<ItemTemplate>
										<div class="d-flex align-items-center flex-row-fluid flex-wrap">
											<span class="svg-icon svg-icon-2x svg-icon-danger">
												<img src='<%# Eval("SubmittedStatus") %>' class="h-50" alt="" />
											</span>
										</div>
									</ItemTemplate>
									<ItemStyle Width="100%" />
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
						<!--end::Table-->
					</div>
				</div>
				<!--end::Tap pane-->
				<!--begin::Tap pane-->
				<div class="tab-pane fade" id="kt_forms_widget_1_tab_content_2">
					<!--begin::PDC Details-->
					<div class="card shadow-sm mb-6">
						<div class="card-header">
							<h3 class="card-title">List of Submitted Requirements</h3>
							<div class="card-toolbar">
								<!--begin::Search-->
								<div class="d-flex align-items-center position-relative m-1">
									<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
									<span id="spanREQForVerificationAttachmentSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxREQForVerificationAttachmentSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
								</div>
								<!--begin::Search-->
								<%--<asp:LinkButton ID="lbtn01VerifiedPDC" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-check-circle fs-2"></i></asp:LinkButton>--%>				
								<!--begin::Batch Options-->
								<button id="btnREQForVerificationAttachmentBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
									<span class="svg-icon svg-icon-2">
										<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
												<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
												<rect x="0" y="0" width="24" height="24"/>
												<path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#279852"/>
											</g>
										</svg>
									</span>
								</button>
								<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-800 menu-state-bg-light-primary fw-bold w-200px py-3" data-kt-menu="true">
								<div class="menu-item px-3">
									<div class="menu-content fs-6 text-dark fw-bolder px-3 py-4">Options</div>
								</div>
								<div class="separator mb-3 opacity-75"></div>
								<!--begin::Menu item-->
								<div class="menu-item px-3">
									<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlREQBatchChangeStatus">
										<span class="svg-icon svg-icon-3 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
												<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
													<rect x="0" y="0" width="24" height="24"/>
													<path d="M3.5,3 L5,3 L5,19.5 C5,20.3284271 4.32842712,21 3.5,21 L3.5,21 C2.67157288,21 2,20.3284271 2,19.5 L2,4.5 C2,3.67157288 2.67157288,3 3.5,3 Z" fill="#279852"/>
													<path d="M6.99987583,2.99995344 L19.754647,2.99999303 C20.3069317,2.99999474 20.7546456,3.44771138 20.7546439,3.99999613 C20.7546431,4.24703684 20.6631995,4.48533385 20.497938,4.66895776 L17.5,8 L20.4979317,11.3310353 C20.8673908,11.7415453 20.8341123,12.3738351 20.4236023,12.7432941 C20.2399776,12.9085564 20.0016794,13 19.7546376,13 L6.99987583,13 L6.99987583,2.99995344 Z" fill="#279852" opacity="0.3"/>
												</g>
											</svg>
										</span>
										Change Status
									</a>
								</div>
								<!--end::Menu item-->
								</div>
								<!--end::Batch Options-->
							</div>
						</div>
						<div class="card-body">
							<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
								<!--begin::Table-->
								<asp:GridView ID="gv02Files" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
										</ItemTemplate>
										<ItemStyle CssClass="pt-10-px pb-10-px min-w-20px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="">
										<HeaderTemplate>
											<div class="form-check form-check-sm form-check-custom form-check-solid">
												<input id="cbxREQSubmittedDocsAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
											</div>
										</HeaderTemplate>
										<ItemTemplate>
											<div class="form-check form-check-sm form-check-custom form-check-solid">
												<input class="form-check-input checkBoxClass" id="RowCheckbox" runat="server" type="checkbox" value="1" />
											</div>
										</ItemTemplate>
										<ItemStyle CssClass="mw-30px min-w-30px" />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="d-flex align-items-center flex-row-fluid flex-wrap">
												<div class="flex-grow-1 me-2">
													<span class="text-gray-800 fs-7 fw-bolder"><%# Eval("Description") %></span>
												</div>
											</div>
										</ItemTemplate>
										<ItemStyle CssClass="pt-10-px pb-10-px min-w-30px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Actions">
										<ItemTemplate>
											<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewREQForVerificationSubmittedDtl") %>">
												<span class="svg-icon svg-icon-2">
												<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
													<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
												</svg>
												</span>
											</a>
											<asp:Label ID="lblID" runat="server" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
										</ItemTemplate>
										<ItemStyle CssClass="pt-10-px pb-10-px min-w-20px" />
									</asp:TemplateField>
								</Columns>
								<EmptyDataTemplate>
									<div align="center">No data available.</div>
								</EmptyDataTemplate>
								</asp:GridView>
								<!--end::Table-->
							</div>
						</div>
						<!--end::PDC Details-->
					</div>
				</div>
				<!--end::Tap pane-->
			</div>
			<!--end::Tab Content-->
		</div>
		<!--end: Card Body-->
	</div>
								<!--end::Docs Details-->

							</div>
						</div>
						</div>
				</ContentTemplate>
				<Triggers>
					<asp:PostBackTrigger ControlID="gv02Files" />
				</Triggers>
			</asp:UpdatePanel>
	<!--begin::Modal Edit-->

	<!--begin::Modal Batch Change Status-->
	<asp:UpdatePanel ID="mdlREQBatchChangeStatus" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title">Change Status</h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnPDCBatchChangeStatusClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
						<span class="svg-icon svg-icon-1">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
								<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
							</svg>
						</span>
					</asp:LinkButton>
					<!--end::Close-->
				</div>
				<div class="modal-body">
					<!--begin::Status-->
					<div class="card shadow-sm">
						<div class="card-header">
							<h3 class="card-title">Status</h3>
							<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
								<div class="ribbon-icon mt-n5 me-n6">
									<i class="bi bi-check2-square fs-3 text-white"></i>
								</div>
							</div>
						</div>
						<div class="card-body">
							<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
								<span class="input-group-text min-w-150px required">Status</span>
								<asp:DropDownList ID="ddlPDCBatchChangeStatusStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
									<asp:ListItem Value="">Select status</asp:ListItem>
									<asp:ListItem Value="Approved">Approved</asp:ListItem>
									<asp:ListItem Value="In Process">In Process</asp:ListItem>
									<asp:ListItem Value="Declined">Declined</asp:ListItem>
								</asp:DropDownList>
							</div>
							<div class="error-message mb-2" style="display:none; color: red;">
								Status is required.
							</div>
							<div class="input-group select-wrapper input-group-sm mb-2">
								<span class="input-group-text input-group-text-top min-w-150px required">Remarks</span>
								<asp:TextBox ID="tbxPDCBatchChangeStatusRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="error-message" style="display:none; color: red;">
								Remarks is required.
							</div>				
						</div>
					</div>
					<!--end::Status-->
				</div>
				<!--begin::Actions-->
				<div class="modal-footer text-center">
					<asp:LinkButton ID="lbtnPDCBatchChangeStatusCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
					<asp:LinkButton ID="lbtnPDCBatchChangeStatusSave" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
				</div>
				<!--end::Actions-->
			</div>
		</div>
	</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Batch Change Status-->

	<!--begin::Modal Edit-->
	<asp:UpdatePanel ID="mdlREQForVerificationSubmitted3" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lbl01RequirementsTitle3" runat="server"></asp:Label></h5>
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
					<!--begin::Requirement Details-->
					<div class="card shadow-sm mb-6">
						<div class="card-header">
							<h3 class="card-title">Client Details</h3>
							<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
								<div class="ribbon-icon mt-n5 me-n6">
									<i class="bi bi-card-text fs-3 text-white"></i>
								</div>
							</div>
						</div>
						<div class="card-body">
							<asp:Label ID="lbl01REQCode3" runat="server" visible="false"></asp:Label>
							<asp:Label ID="lbl01DocsCode3" runat="server" visible="false"></asp:Label>
							<asp:Label ID="lbl01FilePath3" runat="server" style="display:none;"></asp:Label>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Account No.</span>
								<asp:Label ID="lbl01AcctNo3" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Name</span>
								<asp:Label ID="lbl01Name3" runat="server" class="form-control">-</asp:Label>
							</div>
							<asp:Label ID="lbl01Email3" runat="server" class="form-control" Visible="false">-</asp:Label>
						</div>
					</div>
					<!--end::Requirement Details-->
						<!--begin::Docs Details-->
							<div class="card shadow-sm mb-6">
	<!--begin::Header-->
	<div class="card-header position-relative min-h-50px p-0 border-bottom-2">
		<!--begin::Nav-->
		<ul class="nav nav-pills nav-pills-custom d-flex position-relative w-100">
			<!--begin::Item-->
			<li class="nav-item mx-0 p-0 w-50">
				<!--begin::Link-->
				<a class="nav-link btn btn-color-muted active border-0 h-100 px-0" data-bs-toggle="pill" id="kt_forms_widget_1_tab_3333" href="#kt_forms_widget_1_tab_content_3333">
					<!--begin::Subtitle-->
					<span class="nav-text fw-bolder fs-4 mb-3">Overview</span>
					<span class="badge badge-lg badge-square badge-success align-self-center px-2"><asp:Label ID="lbl03TotalOverview" runat="server"></asp:Label></span>
					<!--end::Subtitle-->
					<!--begin::Bullet-->
					<span class="bullet-custom position-absolute z-index-2 w-100 h-2px top-100 bottom-n100 bg-primary rounded"></span>
					<!--end::Bullet-->
				</a>
				<!--end::Link-->
			</li>
			<!--end::Item-->
			<!--begin::Item-->
			<li class="nav-item mx-0 px-0 w-50">
				<!--begin::Link-->
				<a class="nav-link btn btn-color-muted border-0 h-100 px-0" data-bs-toggle="pill" id="kt_forms_widget_1_tab_333" href="#kt_forms_widget_1_tab_content_333">
					<!--begin::Subtitle-->
					<span class="nav-text fw-bolder fs-4 mb-3">Submitted</span>
					<span class="badge badge-lg badge-square badge-success" ><asp:Label ID="lbl03SubmittedTotal" runat="server"></asp:Label></span>
					<!--end::Subtitle-->
					<!--begin::Bullet-->
					<span class="bullet-custom position-absolute z-index-2 w-100 h-2px top-100 bottom-n100 bg-primary rounded"></span>
					<!--end::Bullet-->
				</a>
				<!--end::Link-->
			</li>
			<!--end::Item-->
		</ul>
		<!--end::Nav-->
	</div>
	<!--end::Header-->
	<!--begin::Body-->
	<div class="card-body">
		<!--begin::Tab Content-->
		<div class="tab-content">
			<!--begin::Tap pane-->
			<div class="tab-pane fade active show" id="kt_forms_widget_1_tab_content_3333">
				<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
					<!--begin::Table-->
					<asp:GridView ID="gv03LackingDocs" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="False">
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
								</ItemTemplate>
								<ItemStyle Width="3%" />
							</asp:TemplateField>
							<asp:TemplateField>
								<ItemTemplate>
									<div class="d-flex align-items-center flex-row-fluid flex-wrap">
										<div class="symbol symbol-35px me-3">
											<div class="symbol-label bg-light">
												<img src="Assets/media/svg/files/doc.svg" class="h-50" alt="" />
											</div>
										</div>
									</div>
								</ItemTemplate>
								<ItemStyle Width="10%" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Documents">
								<ItemTemplate>
									<div class="d-flex align-items-center flex-row-fluid flex-wrap">
										<div class="flex-grow-1 me-2">
											<span class="text-gray-800 fs-7 fw-bolder"><%# Eval("ReqDesc") %></span>
										</div>
									</div>
								</ItemTemplate>
								<ItemStyle Width="80%" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Submitted">
								<ItemTemplate>
									<div class="d-flex align-items-center flex-row-fluid flex-wrap">
										<span class="svg-icon svg-icon-2x svg-icon-danger">
											<img src='<%# Eval("Status") %>' class="h-50" alt="" />
										</span>
									</div>
								</ItemTemplate>
								<ItemStyle Width="100%" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Approved">
								<ItemTemplate>
									<div class="d-flex align-items-center flex-row-fluid flex-wrap">
										<span class="svg-icon svg-icon-2x svg-icon-danger">
											<img src='<%# Eval("SubmittedStatus") %>' class="h-50" alt="" />
										</span>
									</div>
								</ItemTemplate>
								<ItemStyle Width="100%" />
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
					<!--end::Table-->
				</div>
			</div>
			<!--end::Tap pane-->
			<!--begin::Tap pane-->
			<div class="tab-pane fade" id="kt_forms_widget_1_tab_content_333">
				<!--begin::PDC Details-->
				<div class="card shadow-sm mb-6">
					<div class="card-header">
						<h3 class="card-title">List of Submitted Requirements</h3>
						<div class="card-toolbar">
							<!--begin::Search-->
							<div class="d-flex align-items-center position-relative m-1">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span id="spanREQForVerificationAttachmentSearch3" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxREQForVerificationAttachmentSearch3" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
							</div>
							<!--begin::Search-->
							<%--<asp:LinkButton ID="lbtn01VerifiedPDC" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-check-circle fs-2"></i></asp:LinkButton>--%>				
							<!--begin::Batch Options-->
							<button id="btnREQForVerificationAttachmentBatchOptions3" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
								<span class="svg-icon svg-icon-2">
									<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
											<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
											<rect x="0" y="0" width="24" height="24"/>
											<path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#279852"/>
										</g>
									</svg>
								</span>
							</button>
							<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-800 menu-state-bg-light-primary fw-bold w-200px py-3" data-kt-menu="true">
							<div class="menu-item px-3">
								<div class="menu-content fs-6 text-dark fw-bolder px-3 py-4">Options</div>
							</div>
							<div class="separator mb-3 opacity-75"></div>
							<!--begin::Menu item-->
							<div class="menu-item px-3">
								<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlREQBatchChangeStatus">
									<span class="svg-icon svg-icon-3 me-3">
										<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
											<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
												<rect x="0" y="0" width="24" height="24"/>
												<path d="M3.5,3 L5,3 L5,19.5 C5,20.3284271 4.32842712,21 3.5,21 L3.5,21 C2.67157288,21 2,20.3284271 2,19.5 L2,4.5 C2,3.67157288 2.67157288,3 3.5,3 Z" fill="#279852"/>
												<path d="M6.99987583,2.99995344 L19.754647,2.99999303 C20.3069317,2.99999474 20.7546456,3.44771138 20.7546439,3.99999613 C20.7546431,4.24703684 20.6631995,4.48533385 20.497938,4.66895776 L17.5,8 L20.4979317,11.3310353 C20.8673908,11.7415453 20.8341123,12.3738351 20.4236023,12.7432941 C20.2399776,12.9085564 20.0016794,13 19.7546376,13 L6.99987583,13 L6.99987583,2.99995344 Z" fill="#279852" opacity="0.3"/>
											</g>
										</svg>
									</span>
									Change Status
								</a>
							</div>
							<!--end::Menu item-->
							</div>
							<!--end::Batch Options-->
						</div>
					</div>
					<div class="card-body">
						<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
							<!--begin::Table-->
							<asp:GridView ID="gv03Files" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<span class="bullet bullet-margin bullet-vertical h-40px bg-success"></span>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Documents">
									<ItemTemplate>
										<div class="d-flex align-items-center flex-row-fluid flex-wrap">
											<div class="flex-grow-1 me-2">
												<span class="text-gray-800 fs-7 fw-bolder"><%# Eval("Description") %></span>
											</div>
										</div>
									</ItemTemplate>
									<ItemStyle CssClass="pt-10-px pb-10-px min-w-30px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Actions">
									<ItemTemplate>
										<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewREQVerifiedSubmittedDtl") %>">
											<span class="svg-icon svg-icon-2">
											<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
												<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
											</svg>
											</span>
										</a>
										<asp:Label ID="lblID" runat="server" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
									</ItemTemplate>
									<ItemStyle CssClass="pt-10-px pb-10-px min-w-20px" />
								</asp:TemplateField>
							</Columns>
							<EmptyDataTemplate>
								<div align="center">No data available.</div>
							</EmptyDataTemplate>
							</asp:GridView>
							<!--end::Table-->
						</div>
					</div>
					<!--end::PDC Details-->
				</div>
			</div>
			<!--end::Tap pane-->
		</div>
		<!--end::Tab Content-->
	</div>
	<!--end: Card Body-->
</div>
							<!--end::Docs Details-->

						</div>
					</div>
					</div>
			</ContentTemplate>
			<Triggers>
				<asp:PostBackTrigger ControlID="gv03Files" />
			</Triggers>
		</asp:UpdatePanel>
	<!--begin::Modal Edit-->

	<!--begin::Modal Approved-->
	<asp:UpdatePanel ID="mdlREQVerifiedSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblREQVerifiedSubmittedDtlTitle" runat="server"></asp:Label></h5>
						<!--begin::Close-->
						<asp:LinkButton ID="lbtnREQVerifiedSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</asp:LinkButton>
						<!--end::Close-->
					</div>
					<div class="modal-body">
						<!--begin::PDC Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">Requirement Details</h3>
								<!--begin::Tabs-->
								<ul class="nav nav-stretch nav-pills nav-pills-custom d-flex mt-4">
									<!--begin::Nav item-->
									<li class="nav-item p-0 ms-0">
										<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#REQVerifiedTab_1">
											<!--begin::Title-->
											<i class="las la-info-circle fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="Details"></i>
											<!--end::Title-->
											<!--begin::Bullet-->
											<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
											<!--end::Bullet-->
										</a>
									</li>
									<!--end::Nav item-->
									<!--begin::Nav item-->
									<li class="nav-item p-0 ms-0">
										<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#REQVerifiedTab_2">
											<!--begin::Title-->
											<i class="las la-history fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="History"></i>
											<!--end::Title-->
											<!--begin::Bullet-->
											<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
											<!--end::Bullet-->
										</a>
									</li>
									<!--end::Nav item-->
								</ul>
								<!--end::Tabs-->
							</div>
							<div class="card-body">
								<!--begin::Tab content-->
								<div class="tab-content">
									<!--begin::Tab pane-->
									<div class="tab-pane active" id="REQVerifiedTab_1" role="tabpanel" aria-labelledby="day-tab" data-kt-timeline-widget-4-blockui="true">
										<div class="card-body">
											<asp:Label ID="lblREQVerifiedSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Account No.</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Name</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Check Date</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlCheckDate" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Check No.</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlCheckNo" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Amount</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Bank</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlBank" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Date Submitted</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Remarks</span>
												<asp:Label ID="lblREQVerifiedSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
											</div>
										</div>
									</div>
									<!--end::Tab pane-->
									<!--begin::Tab pane-->
									<div class="tab-pane" id="REQVerifiedTab_2" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
										<div class="table-responsive pb-10">
											<div class="card-body mh-300px scroll-y">
												<div id="divREQVerifiedSubmittedDtlTimeline" runat="server" class="timeline"></div>
											</div>
										</div>
									</div>
									<!--end::Tab pane-->
								</div>
								<!--end::Tab content-->
							</div>
						</div>
						<!--end::PDC Details-->
						<!--begin::Status-->
						<div class="card shadow-sm">
							<div class="card-header">
								<h3 class="card-title">Status</h3>
							</div>
							<div class="card-body">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:Label ID="lblREQVerifiedSubmittedDtlStatus" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approved By</span>
									<asp:Label ID="lblREQVerifiedSubmittedDtlApprovedBy" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approved Date</span>
									<asp:Label ID="lblREQVerifiedSubmittedDtlApprovedDate" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approver Remarks</span>
									<asp:Label ID="lblREQVerifiedSubmittedDtlApproverRemarks" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
						</div>
						<!--end::Status-->
					</div>
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Approved-->

	<!--begin::Modal PDC Verified List-->
	<asp:UpdatePanel ID="mdlREQVerifiedSubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblREQVerifiedSubmittedTitle" runat="server"></asp:Label></h5>
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
						<!--begin::PDC Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">List of Verified Requirements</h3>
								<div class="card-toolbar">
									<!--begin::Search-->
									<div class="d-flex align-items-center position-relative m-1">
										<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
										<span id="spanREQVerifiedSubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
										<input id="tbxREQVerifiedSubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
									</div>
									<!--begin::Search-->
									<%--<asp:LinkButton ID="lbtn02RevertPDCVerified" runat="server" ToolTip="Revert record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-undo-alt fs-2"></i></asp:LinkButton>--%>
									<!--begin::Batch Options-->
									<button id="btnREQVerifiedSubmittedBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
										<span class="svg-icon svg-icon-2">
											<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
													<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
													<rect x="0" y="0" width="24" height="24"/>
													<path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#279852"/>
												</g>
											</svg>
										</span>
									</button>
									<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-800 menu-state-bg-light-primary fw-bold w-200px py-3" data-kt-menu="true">
									<div class="menu-item px-3">
										<div class="menu-content fs-6 text-dark fw-bolder px-3 py-4">Options</div>
									</div>
									<div class="separator mb-3 opacity-75"></div>
									<!--begin::Verify PDC-->
									<div class="menu-item px-3">
										<asp:LinkButton ID="lbtnREQVerifiedSubmittedBatchRevert" runat="server" class="menu-link px-3">
										<%--<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlINQBatchTLCreation">--%>
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
												<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
													<rect x="0" y="0" width="24" height="24"/>
													<circle fill="#279852" opacity="0.3" cx="12" cy="12" r="10"/>
													<path d="M16.7689447,7.81768175 C17.1457787,7.41393107 17.7785676,7.39211077 18.1823183,7.76894473 C18.5860689,8.1457787 18.6078892,8.77856757 18.2310553,9.18231825 L11.2310553,16.6823183 C10.8654446,17.0740439 10.2560456,17.107974 9.84920863,16.7592566 L6.34920863,13.7592566 C5.92988278,13.3998345 5.88132125,12.7685345 6.2407434,12.3492086 C6.60016555,11.9298828 7.23146553,11.8813212 7.65079137,12.2407434 L10.4229928,14.616916 L16.7689447,7.81768175 Z" fill="#279852" fill-rule="nonzero"/>
												</g>
											</svg>
										</span>
										Revert PDC
										<%--</a>--%>
										</asp:LinkButton>
									</div>
									<!--end::Verify PDC-->
									</div>
									<!--end::Batch Options-->
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
									<!--begin::Table-->
									<asp:GridView ID="gvREQVerifiedSubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<span class='<%# Eval("Bullet") %>'></span>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbxREQVerifiedSubmittedAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
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
											<asp:TemplateField HeaderText="Date">
												<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="d-flex flex-column">
														<span class="fw-bold fs-7 text-dark"><%# Eval("CheckDate") %></span>
													</div>
												</div>
												</ItemTemplate>
												<ItemStyle CssClass="min-w-80px"/>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Check No.">
												<ItemTemplate>
												<div class="d-flex align-items-center flex-row-fluid flex-wrap">
													<div class="flex-grow-1 me-2">
														<span class="fw-bold fs-7 text-dark"><%# Eval("CheckNo") %></span>
													</div>
												</div>
												</ItemTemplate>
												<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Status">
												<ItemTemplate>
													<div class="d-flex align-items-center flex-row-fluid flex-wrap">
														<span class="badge py-2 px-4 fs-8 badge-success"><%# Eval("Status") %></span>
													</div>
												</ItemTemplate>
												<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Actions">
												<ItemTemplate>
												<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewREQVerifiedSubmitted") %>">
												<%--<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("PDCCode") %>'>--%>
													<span class="svg-icon svg-icon-2">
														<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
															<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
														</svg>
													</span>
												<%--</asp:Linkbutton>--%>
												</a>
												<asp:Label ID="lblREQVerifiedSubmittedID" runat="server" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
												</ItemTemplate>
												<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
											</asp:TemplateField>
										</Columns>
										<EmptyDataTemplate>
											<div align="center">No data available.</div>
										</EmptyDataTemplate>
									</asp:GridView>
									<!--end::Table-->
								</div>
							</div>
						<!--end::PDC Details-->
						</div>
					</div>
				</div>
				</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal PDC Verified List-->

	<!--begin::Modal Pending-->
	<asp:UpdatePanel ID="mdlREQForVerificationSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblREQForVerificationSubmittedDtlTitle" runat="server"></asp:Label></h5>
						<!--begin::Close-->
						<asp:LinkButton ID="lbtnREQForVerificationSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</asp:LinkButton>
						<!--end::Close-->
					</div>
					<div class="modal-body">
						<!--begin::Requirement Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">Remittance Details</h3>
								<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
									<div class="ribbon-icon mt-n5 me-n6">
										<i class="bi bi-card-text fs-3 text-white"></i>
									</div>
								</div>
							</div>
							<div class="card-body">
								<asp:Label ID="lblREQForVerificationSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
								<asp:Label ID="lblREQForVerificationSubmittedDtlEmail" runat="server" class="form-control" Visible="false">-</asp:Label>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Account No.</span>
									<asp:Label ID="lblREQForVerificationSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Name</span>
									<asp:Label ID="lblREQForVerificationSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Document</span>
									<asp:Label ID="lblREQForVerificationSubmittedDtlDocument" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Remarks</span>
									<asp:Label ID="lblREQForVerificationSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
						</div>
						<!--end::Requirement Details-->
						<!--begin::Attachments-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">Attachments</h3>
								<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
									<div class="ribbon-icon mt-n5 me-n6">
										<i class="bi bi-paperclip fs-3 text-white"></i>
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
									<!--begin::Table-->
									<asp:GridView ID="gvAttachments" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class="bullet bullet-vertical h-40px bg-secondary"></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Action">
											<ItemTemplate>
												<div class="d-flex ">
													<asp:LinkButton ID="lbtn02Download" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' ToolTip="Download file" OnClick="DownloadPending"><i class="las la-download fs-3"></i></asp:LinkButton>
												</div>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="File">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="symbol symbol-30px overflow-hidden me-3">
														<asp:Label ID="lblFileIcon" runat="server" CssClass="w-100" Text='<%# Bind("Icon") %>'></asp:Label>
													</div>
													<div class="d-flex flex-column">
														<asp:Label ID="lbl02FileName" runat="server" CssClass="text-weight-500 text-gray-800" Text='<%# Bind("Name") %>'></asp:Label>
														<asp:Label ID="lbl02FileDate" runat="server" Cssclass="text-weight-500 text-gray-600" Text='<%# Bind("CreationTime") %>'></asp:Label>
													</div>
												</div>
											</ItemTemplate>
											<ItemStyle Width="100%"/>
										</asp:TemplateField>
									</Columns>
									<EmptyDataTemplate>
										<div align="center">No data available.</div>
									</EmptyDataTemplate>
									</asp:GridView>
									<!--end::Table-->
								</div>
							</div>
						</div>
						<!--end::Attachments-->
					<!--begin::Status-->
					<div class="card shadow-sm">
						<div class="card-header">
							<h3 class="card-title">Status</h3>
						</div>
						<div class="card-body">
							<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
								<span class="input-group-text min-w-150px required">Status</span>
								<asp:DropDownList ID="ddlPDCPendingSubmittedDtlStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
									<asp:ListItem Value="">Select status</asp:ListItem>
									<asp:ListItem Value="Approved">Approved</asp:ListItem>
									<asp:ListItem Value="Declined">Declined</asp:ListItem>
								</asp:DropDownList>
							</div>
							<div class="error-message mb-2" style="display:none; color: red;">
								Status is required.
							</div>
							<div class="input-group select-wrapper input-group-sm mb-2">
								<span class="input-group-text input-group-text-top min-w-150px required">Approver Remarks</span>
								<asp:TextBox ID="tbxPDCPendingSubmittedDtlRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="error-message" style="display:none; color: red;">
								Remarks is required.
							</div>
						</div>
					</div>
					<!--end::Status-->
					</div>
					<!--begin::Actions-->
					<div runat="server" class="modal-footer text-center">
						<%--<button type="button" class="btn btn-light me-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList">Cancel</button>--%>
						<asp:LinkButton ID="lbtnREQForVerificationSubmittedDtlCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
						<%--<asp:LinkButton ID="lbtnCSCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>--%>
						<asp:LinkButton ID="lbtnREQForVerificationSubmittedDtlVerified" runat="server" class="btn btn-primary">Verified</asp:LinkButton>
						<%--<button id="btnCSVerified" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList">
							Verified
						</button>--%>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Pending-->

	<asp:UpdatePanel ID="mdlREQForVerificationSubmittedDtl2" runat="server" UpdateMode="Conditional" class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblREQForVerificationSubmittedDtlTitle2" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnREQForVerificationSubmittedDtlClose2" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
						<span class="svg-icon svg-icon-1">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
								<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
							</svg>
						</span>
					</asp:LinkButton>
					<!--end::Close-->
				</div>
				<div class="modal-body">
					<!--begin::Requirement Details-->
					<div class="card shadow-sm mb-6">
						<div class="card-header">
							<h3 class="card-title">Remittance Details</h3>
							<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
								<div class="ribbon-icon mt-n5 me-n6">
									<i class="bi bi-card-text fs-3 text-white"></i>
								</div>
							</div>
						</div>
						<div class="card-body">
							<asp:Label ID="lblREQForVerificationSubmittedDtlCode2" runat="server" class="form-control" visible="false"></asp:Label>
							<asp:Label ID="lblREQForVerificationSubmittedDtlEmail2" runat="server" class="form-control" Visible="false">-</asp:Label>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Account No.</span>
								<asp:Label ID="lblREQForVerificationSubmittedDtlAcctNo2" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Name</span>
								<asp:Label ID="lblREQForVerificationSubmittedDtlName2" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Document</span>
								<asp:Label ID="lblREQForVerificationSubmittedDtlDocument2" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:Label ID="lblREQForVerificationSubmittedDtlRemarks2" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Status</span>
								<asp:Label ID="lblREQForVerificationSubmittedDtlStatus2" runat="server" class="form-control">-</asp:Label>
							</div>
						</div>
					</div>
					<!--end::Requirement Details-->
					<!--begin::Attachments-->
					<div class="card shadow-sm mb-6">
						<div class="card-header">
							<h3 class="card-title">Attachments</h3>
							<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
								<div class="ribbon-icon mt-n5 me-n6">
									<i class="bi bi-paperclip fs-3 text-white"></i>
								</div>
							</div>
						</div>
						<div class="card-body">
							<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
								<!--begin::Table-->
								<asp:GridView ID="gvAttachments2" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-vertical h-40px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Action">
										<ItemTemplate>
											<div class="d-flex ">
												<asp:LinkButton ID="lbtn02Download" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' ToolTip="Download file" OnClick="DownloadPending"><i class="las la-download fs-3"></i></asp:LinkButton>
											</div>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="File">
										<ItemTemplate>
											<div class="d-flex align-items-center">
												<div class="symbol symbol-30px overflow-hidden me-3">
													<asp:Label ID="lblFileIcon" runat="server" CssClass="w-100" Text='<%# Bind("Icon") %>'></asp:Label>
												</div>
												<div class="d-flex flex-column">
													<asp:Label ID="lbl02FileName" runat="server" CssClass="text-weight-500 text-gray-800" Text='<%# Bind("Name") %>'></asp:Label>
													<asp:Label ID="lbl02FileDate" runat="server" Cssclass="text-weight-500 text-gray-600" Text='<%# Bind("CreationTime") %>'></asp:Label>
												</div>
											</div>
										</ItemTemplate>
										<ItemStyle Width="100%"/>
									</asp:TemplateField>
								</Columns>
								<EmptyDataTemplate>
									<div align="center">No data available.</div>
								</EmptyDataTemplate>
								</asp:GridView>
								<!--end::Table-->
							</div>
						</div>
					</div>
					<!--end::Attachments-->
				</div>
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>

<!--begin::hidden variable-->
<asp:HiddenField ID="hfID" runat="server" />
<!--begin::hidden variable-->
	
<script type="text/javascript">

    function ViewREQForVerificationSubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewREQForVerificationSubmittedDtl.ClientID %>");
        clickButton.click();
	};

    function ViewREQVerifiedSubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewREQVerifiedSubmittedDtl.ClientID %>");
        clickButton.click();
    };

    function ViewREQForVerificationSubmitted(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewREQForVerificationSubmitted.ClientID %>");
        clickButton.click();
	};

    function ViewREQVerifiedList(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewREQVerifiedSubmitted.ClientID %>");
        clickButton.click();
	};

    function ViewREQVerifiedSubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewREQVerifiedSubmittedDtl.ClientID %>");
        clickButton.click();
    };

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

    //postback
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        // re-bind your jQuery events here
        loadscript();
    });
    $(document).ready(loadscript);
    function loadscript() {

        //search PDC Submitted List
        var $rowsGv02Files = $('#ContentPlaceHolder1_gv02Files tbody tr');
        var cbxREQSubmittedDocsAll = $('#cbxREQSubmittedDocsAll');

        $('#tbxREQForVerificationAttachmentSearch').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            $rowsGv02Files.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();

            // Check if any rows are still visible
            var anyVisible = $rowsGv02Files.filter(':visible').length > 0;

            // Enable or disable the checkbox based on visibility
            $cbxREQSubmittedDocsAll.prop('disabled', !anyVisible);
        });

        //search PDC Submitted List

        //search PDC Verified
        var $rowsGvREQVerifiedSubmitted = $('#ContentPlaceHolder1_gvREQVerifiedSubmitted tbody tr');
        var $cbxREQVerifiedSubmittedAll = $('#cbxREQVerifiedSubmittedAll');

        $('#tbxREQForVerificationAttachmentSearch').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            $rowsGvREQVerifiedSubmitted.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();

            // Check if any rows are still visible
            var anyVisible = $rowsGvREQVerifiedSubmitted.filter(':visible').length > 0;

            // Enable or disable the checkbox based on visibility
            $cbxREQVerifiedSubmittedAll.prop('disabled', !anyVisible);
        });
		//search PDC Verified

        var $rowsGv03Files = $('#ContentPlaceHolder1_gv03Files tbody tr');
        $('#tbxREQForVerificationAttachmentSearch3').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
            $rowsGv03Files.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();
        });

        //search PDC
        var $rowsREQForVerification = $('#ContentPlaceHolder1_gvREQForVerificationList tbody tr');
        var $rowsREQVerified = $('#ContentPlaceHolder1_gvREQVerifiedList tbody tr');

        //search input
        $('#tbxREQSearch').on('keyup', function () {
            var searchVal = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            // Check which tab is active and filter the corresponding GridView
            if ($('#pending_tab_1').hasClass('active')) {
                filterRows($rowsREQForVerification, searchVal);
            } else if ($('#history_tab_2').hasClass('active')) {
                filterRows($rowsREQVerified, searchVal);
            }
        });

        //reset search
        $('.nav-link').on('click', function () {
            $('#tbxREQSearch').val('');

            $rowsREQForVerification.show();
            $rowsREQVerified.show();
        });

        //function to filter rows
        function filterRows($rows, val) {
            $rows.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();
        }
        //search PDC
    }
    //postback

    function pageLoad(sender, args) { InitialiseSettings(); }
    function InitialiseSettings() {
        jQuery(function ($) {

            //checkbox
            $('.checkBoxAllClass').click(function () {
                var btnREQForVerificationAttachmentBatchOptions = document.getElementById("btnREQForVerificationAttachmentBatchOptions");
                var spanREQForVerificationAttachmentSearch = document.getElementById("spanREQForVerificationAttachmentSearch");
                var tbxREQForVerificationAttachmentSearch = document.getElementById("tbxREQForVerificationAttachmentSearch");

                if ($(this).is(":checked")) {
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    btnREQForVerificationAttachmentBatchOptions.style.display = "block";
                    tbxREQForVerificationAttachmentSearch.style.display = "none";
                    spanREQForVerificationAttachmentSearch.style.display = "none";
                } else {
                    $(".checkBoxClass").prop('checked', false);
                    btnREQForVerificationAttachmentBatchOptions.style.display = "none";
                    tbxREQForVerificationAttachmentSearch.style.display = "block";
                    spanREQForVerificationAttachmentSearch.style.display = "block";
                    tbxREQForVerificationAttachmentSearch.value = '';
                }
            })
            $(".checkBoxClass").change(function () {
                var btnREQForVerificationAttachmentBatchOptions = document.getElementById("btnREQForVerificationAttachmentBatchOptions");
                var spanREQForVerificationAttachmentSearch = document.getElementById("spanREQForVerificationAttachmentSearch");
                var tbxREQForVerificationAttachmentSearch = document.getElementById("tbxREQForVerificationAttachmentSearch");

                if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
                }
                if ($('.checkBoxClass:checked').length > 0) {
                    btnREQForVerificationAttachmentBatchOptions.style.display = "block";
                    tbxREQForVerificationAttachmentSearch.style.display = "none";
                    spanREQForVerificationAttachmentSearch.style.display = "none";
                } else {
                    btnREQForVerificationAttachmentBatchOptions.style.display = "none";
                    tbxREQForVerificationAttachmentSearch.style.display = "block";
                    spanREQForVerificationAttachmentSearch.style.display = "block";
                    tbxREQForVerificationAttachmentSearch.value = '';
                }
            });
            //checkbox

            //higlight input fields
            var inputGroups = [
                {
                    inputs: ['#ContentPlaceHolder1_tbxPDCBatchChangeStatusRemarks'],
                    dropdowns: ['#ContentPlaceHolder1_ddlPDCBatchChangeStatusStatus'],
                    button: '#ContentPlaceHolder1_lbtnPDCBatchChangeStatusSave'
                }
            ];

            //reusable validation function
            function validateField(field, errorMessage, condition) {
                var wrapper = field.closest('.select-wrapper');
                var isValid = !condition(field.val());
                wrapper.css(isValid ? { 'border': '' } : { 'border': '1px solid red', 'border-radius': '3px' });
                errorMessage.toggle(!isValid);
                return isValid;
            }

            //Apply validation
            inputGroups.forEach(group => {
                group.inputs.concat(group.dropdowns).forEach(selector => {
                    var element = $(selector);
                    var errorMessage = element.closest('.select-wrapper').next('.error-message');
                    element.on('blur change', () => validateField(element, errorMessage, val => !val.trim()));
                });

                $(group.button).on('click', function () {
                    var isValid = true;

                    group.inputs.concat(group.dropdowns).forEach(selector => {
                        var element = $(selector);
                        var errorMessage = element.closest('.select-wrapper').next('.error-message');
                        if (!validateField(element, errorMessage, val => !val.trim())) isValid = false;
                    });

                    return isValid;
                });
            });
            //highlight input fields

            //combobox
            $('[data-kt-repeater="select2"]').on('select2:open', function (e) {
                const targetSelect2 = $(e.target).data('select2');
                if (targetSelect2) {
                    targetSelect2.$dropdown.css('position', 'fixed');
                }
            });

            const select2Configs = [
                { selector: "#ContentPlaceHolder1_ddlPDCPendingSubmittedDtlStatus", parent: "#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl" },
                { selector: "#ContentPlaceHolder1_ddlPDCBatchChangeStatusStatus", parent: "#ContentPlaceHolder1_mdlREQBatchChangeStatus" }
            ];

            select2Configs.forEach(config => {
                $(config.selector).select2({
                    dropdownParent: $(config.parent)
                });
            });
            //combobox

            //date
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y"
            });
            //date

            //menu
            KTMenu.createInstances();
            //menu

        });
    }

</script>
<!-- scripts related to this page -->

</asp:Content>
