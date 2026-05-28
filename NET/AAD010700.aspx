<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010700.aspx.vb" Inherits="NET.ForVerificationPDC" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Post Dated Checks (For Verification)</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<asp:Button ID="btnViewPDCForVerificationSubmitted" runat="server" Text="Button" OnClick="btnViewPDCForVerificationSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCForVerificationSubmittedDtl" runat="server" Text="Button" OnClick="btnViewPDCForVerificationSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnPDCForVerificationSubmittedBatchVerify" runat="server" Text="Button" OnClick="btnPDCForVerificationSubmittedBatchVerify_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnPDCVerifySubmittedRevert" runat="server" Text="Button" OnClick="btnPDCVerifySubmittedRevert_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCVerifiedSubmitted" runat="server" Text="Button" OnClick="btnViewPDCVerifiedSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCVerifiedSubmittedDtl" runat="server" Text="Button" OnClick="btnViewPDCVerifiedSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
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
											<span class="text-gray-900 fs-2 fw-bolder me-1">Post Dated Checks (For Verification)</span>
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
										<a id="pending_tab_1" class="nav-link text-active-gray-800 me-4 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCForVerificationList">For Verification &nbsp; <span class="badge badge-square bg-warning py-2 px-3"><asp:Label ID="lblPDCForVerificationListTotal" runat="server"></asp:Label></span> </a>
									</li>
									<!--end::Nav item-->

									<!--begin::Nav item-->
									<li class="nav-item">
										<a id="approved_tab_2" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCVerifiedList">Verified &nbsp; <span class="badge badge-square bg-success py-2 px-3"><asp:Label ID="lblPDCVerifiedListTotal" runat="server"></asp:Label></span></a>
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
								<span class="card-label fw-bolder text-dark">Post Dated Checks Status</span>
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
							<input id="tbxPDCSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
						</div>
						<!--end::Search-->
					</div>
					<!--end::Card head-->
					<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Tab Content-->
						<div class="tab-content">
							<!--begin::Tab panel-->
							<asp:UpdatePanel ID="upnlPDCForVerificationList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvPDCForVerificationList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCForVerificationSubmitted") %>">
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
							<asp:UpdatePanel ID="upnlPDCVerifiedList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvPDCVerifiedList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCVerifiedSubmittedDtl") %>">
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
	
<!--begin::Modal Approved-->
<asp:UpdatePanel ID="mdlPDCVerifiedSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCVerifiedSubmittedDtlTitle" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnPDCVerifiedSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
							<h3 class="card-title">PDC Details</h3>
							<!--begin::Tabs-->
							<ul class="nav nav-stretch nav-pills nav-pills-custom d-flex mt-4">
								<!--begin::Nav item-->
								<li class="nav-item p-0 ms-0">
									<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#PDCVerifiedTab_1">
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
									<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#PDCVerifiedTab_2">
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
								<div class="tab-pane active" id="PDCVerifiedTab_1" role="tabpanel" aria-labelledby="day-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="card-body">
										<asp:Label ID="lblPDCVerifiedSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Account No.</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Name</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Check Date</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlCheckDate" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Check No.</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlCheckNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Amount</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Bank</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlBank" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Submitted</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Remarks</span>
											<asp:Label ID="lblPDCVerifiedSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
										</div>
									</div>
								</div>
								<!--end::Tab pane-->
								<!--begin::Tab pane-->
								<div class="tab-pane" id="PDCVerifiedTab_2" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="table-responsive pb-10">
										<div class="card-body mh-300px scroll-y">
											<div id="divPDCVerifiedSubmittedDtlTimeline" runat="server" class="timeline"></div>
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
								<asp:Label ID="lblPDCVerifiedSubmittedDtlStatus" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved By</span>
								<asp:Label ID="lblPDCVerifiedSubmittedDtlApprovedBy" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved Date</span>
								<asp:Label ID="lblPDCVerifiedSubmittedDtlApprovedDate" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approver Remarks</span>
								<asp:Label ID="lblPDCVerifiedSubmittedDtlApproverRemarks" runat="server" class="form-control">-</asp:Label>
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
<asp:UpdatePanel ID="mdlPDCVerifiedSubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCVerifiedSubmittedTitle" runat="server"></asp:Label></h5>
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
							<h3 class="card-title">List of Verified PDC</h3>
							<div class="card-toolbar">
								<!--begin::Search-->
								<div class="d-flex align-items-center position-relative m-1">
									<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
									<span id="spanPDCVerifiedSubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxPDCVerifiedSubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
								</div>
								<!--begin::Search-->
								<%--<asp:LinkButton ID="lbtn02RevertPDCVerified" runat="server" ToolTip="Revert record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-undo-alt fs-2"></i></asp:LinkButton>--%>
							<!--begin::Batch Options-->
							<button id="btnPDCVerifiedSubmittedBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
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
								<asp:LinkButton ID="lbtnPDCVerifiedSubmittedBatchRevert" runat="server" class="menu-link px-3">
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
								<asp:GridView ID="gvPDCVerifiedSubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class='<%# Eval("Bullet") %>'></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="">
											<HeaderTemplate>
												<div class="form-check form-check-sm form-check-custom form-check-solid">
													<input id="cbxPDCVerifiedSubmittedAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
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
											<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCVerifiedSubmittedDtl") %>">
											<%--<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("PDCCode") %>'>--%>
												<span class="svg-icon svg-icon-2">
													<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
														<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
													</svg>
												</span>
											<%--</asp:Linkbutton>--%>
											</a>
											<asp:Label ID="lblPDCVerifiedSubmittedID" runat="server" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
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
<asp:UpdatePanel ID="mdlPDCForVerificationSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCForVerificationSubmittedDtlTitle" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnPDCForVerificationSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
							<h3 class="card-title">PDC Details</h3>
							<!--begin::Tabs-->
							<ul class="nav nav-stretch nav-pills nav-pills-custom d-flex mt-4">
								<!--begin::Nav item-->
								<li class="nav-item p-0 ms-0">
									<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#kt_timeline_widget_4_tab_day">
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
									<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#kt_timeline_widget_4_tab_week">
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
						<%--<div class="card-body">--%>
							<!--begin::Tab content-->
							<div class="tab-content">
								<!--begin::Tab pane-->
								<div class="tab-pane active" id="kt_timeline_widget_4_tab_day" role="tabpanel" aria-labelledby="day-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="card-header">
										<div class="d-flex">
											<asp:LinkButton ID="lbtnPDCForVerificationSubmittedDtlCancelEdit" runat="server" ToolTip="Cancel record" class="btn btn-sm btn-icon btn-danger align-self-center m-1" Visible="false"><i class="las la-ban fs-2"></i></asp:LinkButton>
											<asp:LinkButton ID="lbtnPDCForVerificationSubmittedDtlEdit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
											<asp:LinkButton ID="lbtnPDCForVerificationSubmittedDtlSave" runat="server" ToolTip="Save record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1" Visible="false"><i class="las la-save fs-2"></i></asp:LinkButton>
										</div>
									</div>
									<div class="card-body">
										<asp:Label ID="lblPDCForVerificationSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
										<asp:Label ID="lblPDCForVerificationSubmittedDtlEmail" runat="server" class="form-control" Visible="false">-</asp:Label>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Account No.</span>
											<asp:Label ID="lblPDCForVerificationSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Name</span>
											<asp:Label ID="lblPDCForVerificationSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
										</div>
										<asp:Panel ID="pnlPDCForVerificationSubmittedDtlEdit" runat="server" Visible="false">
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Check No.</span>
												<input id="tbxPDCForVerificationSubmittedDtlCheckNo" runat="server" type="text" class="form-control" placeholder="Enter Check No." />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Check No. is required.
											</div>
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Check Date</span>
												<input id="tbxPDCForVerificationSubmittedDtlCheckDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" placeholder="Pick a Date" readonly="readonly" />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Check Date is required.
											</div>
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Amount</span>
												<input id="tbxPDCForVerificationSubmittedDtlAmount" runat="server" class='form-control' MaxLength="12" onblur="FormatNumeric(this.id);" type="text" value="0.00" />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Amount is required.
											</div>
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Bank</span>
												<input id="tbxPDCForVerificationSubmittedDtlBank" runat="server" class='form-control' type="text" placeholder="Enter Bank" />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Bank is required.
											</div>
										</asp:Panel>
										<asp:Panel ID="pnlPDCForVerificationSubmittedDtlDetail" runat="server" Visible="false">
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Check Date</span>
												<asp:Label ID="lblPDCForVerificationSubmittedDtlCheckDate" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Check No.</span>
												<asp:Label ID="lblPDCForVerificationSubmittedDtlCheckNo" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Amount</span>
												<asp:Label ID="lblPDCForVerificationSubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Bank</span>
												<asp:Label ID="lblPDCForVerificationSubmittedDtlBank" runat="server" class="form-control">-</asp:Label>
											</div>
										</asp:Panel>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Submitted</span>
											<asp:Label ID="lblPDCForVerificationSubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lblPDCForVerificationSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
										</div>
									</div>
								</div>
								<!--end::Tab pane-->
								<!--begin::Tab pane-->
								<div class="tab-pane" id="kt_timeline_widget_4_tab_week" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="table-responsive pb-10">
										<div class="card-body mh-300px scroll-y">
											<div id="divPDCForVerificationSubmittedDtlTimeline" runat="server" class="timeline"></div>
										</div>
									</div>
								</div>
								<!--end::Tab pane-->
							</div>
							<!--end::Tab content-->
						</div>
					<%--</div>--%>
					<!--end::PDC Details-->
				</div>
				<!--begin::Actions-->
				<div id="divCSButton" runat="server" class="modal-footer text-center" visible="false">
					<%--<button type="button" class="btn btn-light me-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList">Cancel</button>--%>
					<asp:LinkButton ID="lbtnPDCForVerificationSubmittedDtlCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
					<%--<asp:LinkButton ID="lbtnCSCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>--%>
					<asp:LinkButton ID="lbtnPDCForVerificationSubmittedDtlVerified" runat="server" class="btn btn-primary">Verified</asp:LinkButton>
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

<!--begin::Modal Submitted PDC-->
<asp:UpdatePanel ID="mdlPDCForVerificationSubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCForVerificationSubmittedTitle" runat="server"></asp:Label></h5>
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
							<h3 class="card-title">List of Submitted PDC</h3>
							<div class="card-toolbar">
								<!--begin::Search-->
								<div class="d-flex align-items-center position-relative m-1">
									<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
									<span id="spanPDCForVerificationSubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxPDCForVerificationSubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
								</div>
								<!--begin::Search-->
								<%--<asp:LinkButton ID="lbtn01VerifiedPDC" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-check-circle fs-2"></i></asp:LinkButton>--%>				
								<!--begin::Batch Options-->
								<button id="btnPDCForVerificationSubmittedBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
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
									<asp:LinkButton ID="lbtnPDCForVerificationSubmittedBatchVerify" runat="server" class="menu-link px-3">
										<span class="svg-icon svg-icon-2 me-3">
											<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
												<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
													<rect x="0" y="0" width="24" height="24"/>
													<circle fill="#279852" opacity="0.3" cx="12" cy="12" r="10"/>
													<path d="M16.7689447,7.81768175 C17.1457787,7.41393107 17.7785676,7.39211077 18.1823183,7.76894473 C18.5860689,8.1457787 18.6078892,8.77856757 18.2310553,9.18231825 L11.2310553,16.6823183 C10.8654446,17.0740439 10.2560456,17.107974 9.84920863,16.7592566 L6.34920863,13.7592566 C5.92988278,13.3998345 5.88132125,12.7685345 6.2407434,12.3492086 C6.60016555,11.9298828 7.23146553,11.8813212 7.65079137,12.2407434 L10.4229928,14.616916 L16.7689447,7.81768175 Z" fill="#279852" fill-rule="nonzero"/>
												</g>
											</svg>
										</span>
										Verify PDC
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
								<asp:GridView ID="gvPDCForVerificationSubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class="bullet bullet-margin bullet-vertical h-40px bg-warning"></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="">
										<HeaderTemplate>
											<div class="form-check form-check-sm form-check-custom form-check-solid">
												<input id="cbxPDCForVerificationSubmittedAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
											</div>
										</HeaderTemplate>
										<ItemTemplate>
											<div class="form-check form-check-sm form-check-custom form-check-solid">
												<input class="form-check-input checkBoxClass" id="RowCheckbox" runat="server" type="checkbox" value="1" />
											</div>
										</ItemTemplate>
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
													<span class="badge py-2 px-4 fs-8 badge-light-warning"><%# Eval("Status") %></span>
												</div>
											</ItemTemplate>
											<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Actions">
											<ItemTemplate>
											<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCForVerificationSubmittedDtl") %>">
												<span class="svg-icon svg-icon-2">
													<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
														<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
													</svg>
												</span>
											</a>
											<asp:Label ID="lblPDCForVerificationSubmittedID" runat="server" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
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
<!--begin::Modal Submitted PDC-->

<!--begin::hidden variable-->
<asp:HiddenField ID="hfID" runat="server" />
<!--begin::hidden variable-->
	
<script type="text/javascript">

    function ViewPDCForVerificationSubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCForVerificationSubmittedDtl.ClientID %>");
        clickButton.click();
    };

    function ViewPDCForVerificationSubmitted(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCForVerificationSubmitted.ClientID %>");
        clickButton.click();
	};

    function ViewPDCVerifiedSubmitted(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCVerifiedSubmitted.ClientID %>");
        clickButton.click();
	};

    function ViewPDCVerifiedSubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCVerifiedSubmittedDtl.ClientID %>");
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
        var $rowsGvPDCForVerificationSubmitted = $('#ContentPlaceHolder1_gvPDCForVerificationSubmitted tbody tr');
        var $cbxPDCForVerificationSubmittedAll = $('#cbxPDCForVerificationSubmittedAll');

        $('#tbxPDCForVerificationSubmittedSearch').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            $rowsGvPDCForVerificationSubmitted.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();

            // Check if any rows are still visible
            var anyVisible = $rowsGvPDCForVerificationSubmitted.filter(':visible').length > 0;

            // Enable or disable the checkbox based on visibility
            $cbxPDCForVerificationSubmittedAll.prop('disabled', !anyVisible);
        });

        //search PDC Submitted List

        //search PDC Verified
        //var $rows = $('#ContentPlaceHolder1_gv02PDCVerifiedList tbody tr');
        //$('#tbx02PDCVerifiedSearch').keyup(function () {
        //    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
        //    $rows.show().filter(function () {
        //        var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
        //        return !~text.indexOf(val);
        //    }).hide();
        //});
        var $rowsGvPDCVerifiedSubmitted = $('#ContentPlaceHolder1_gvPDCVerifiedSubmitted tbody tr');
        var $cbxPDCVerifiedSubmittedAll = $('#cbxPDCVerifiedSubmittedAll');

        $('#tbxPDCVerifiedSubmittedSearch').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            $rowsGvPDCVerifiedSubmitted.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();

            // Check if any rows are still visible
            var anyVisible = $rowsGvPDCVerifiedSubmitted.filter(':visible').length > 0;

            // Enable or disable the checkbox based on visibility
            $cbxPDCVerifiedSubmittedAll.prop('disabled', !anyVisible);
        });
        //search PDC Verified

        //search PDC
        var $rowsPDCForVerification = $('#ContentPlaceHolder1_gvPDCForVerificationList tbody tr');
        var $rowsPDCVerified = $('#ContentPlaceHolder1_gvPDCVerifiedList tbody tr');

        //search input
        $('#tbxPDCSearch').on('keyup', function () {
            var searchVal = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            // Check which tab is active and filter the corresponding GridView
            if ($('#pending_tab_1').hasClass('active')) {
                filterRows($rowsPDCForVerification, searchVal);
            } else if ($('#approved_tab_2').hasClass('active')) {
                filterRows($rowsPDCVerified, searchVal);
            }
        });

        //reset search
        $('.nav-link').on('click', function () {
            $('#tbxPDCSearch').val('');

            $rowsPDCForVerification.show();
            $rowsPDCVerified.show();
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
                var btnPDCForVerificationSubmittedBatchOptions = document.getElementById("btnPDCForVerificationSubmittedBatchOptions");
                var btnPDCVerifiedSubmittedBatchOptions = document.getElementById("btnPDCVerifiedSubmittedBatchOptions");
                var tbxPDCForVerificationSubmittedSearch = document.getElementById("tbxPDCForVerificationSubmittedSearch");
                var spanPDCForVerificationSubmittedSearch = document.getElementById("spanPDCForVerificationSubmittedSearch");
                var tbxPDCVerifiedSubmittedSearch = document.getElementById("tbxPDCVerifiedSubmittedSearch");
                var spanPDCVerifiedSubmittedSearch = document.getElementById("spanPDCVerifiedSubmittedSearch");

                if ($(this).is(":checked")) {
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    btnPDCForVerificationSubmittedBatchOptions.style.display = "";
                    btnPDCVerifiedSubmittedBatchOptions.style.display = "";
                    tbxPDCForVerificationSubmittedSearch.style.display = "none";
                    spanPDCForVerificationSubmittedSearch.style.display = "none";
                    tbxPDCVerifiedSubmittedSearch.style.display = "none";
                    spanPDCVerifiedSubmittedSearch.style.display = "none";
                } else {
                    $(".checkBoxClass").prop('checked', false);
                    btnPDCForVerificationSubmittedBatchOptions.style.display = "none";
                    btnPDCVerifiedSubmittedBatchOptions.style.display = "none";
                    tbxPDCForVerificationSubmittedSearch.style.display = "block";
                    spanPDCForVerificationSubmittedSearch.style.display = "block";
                    tbxPDCVerifiedSubmittedSearch.style.display = "block";
                    spanPDCVerifiedSubmittedSearch.style.display = "block";
                    tbxPDCVerifiedSubmittedSearch.value = '';
                    tbxPDCForVerificationSubmittedSearch.value = '';
                }
            })
            $(".checkBoxClass").change(function () {
                var btnPDCForVerificationSubmittedBatchOptions = document.getElementById("btnPDCForVerificationSubmittedBatchOptions");
                var btnPDCVerifiedSubmittedBatchOptions = document.getElementById("btnPDCVerifiedSubmittedBatchOptions");
                var tbxPDCForVerificationSubmittedSearch = document.getElementById("tbxPDCForVerificationSubmittedSearch");
                var spanPDCForVerificationSubmittedSearch = document.getElementById("spanPDCForVerificationSubmittedSearch");
                var tbxPDCVerifiedSubmittedSearch = document.getElementById("tbxPDCVerifiedSubmittedSearch");
                var spanPDCVerifiedSubmittedSearch = document.getElementById("spanPDCVerifiedSubmittedSearch");

                if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
                }
                if ($('.checkBoxClass:checked').length > 0) {
                    btnPDCForVerificationSubmittedBatchOptions.style.display = "";
                    btnPDCVerifiedSubmittedBatchOptions.style.display = "";
                    tbxPDCForVerificationSubmittedSearch.style.display = "none";
                    spanPDCForVerificationSubmittedSearch.style.display = "none";
                    tbxPDCVerifiedSubmittedSearch.style.display = "none";
                    spanPDCVerifiedSubmittedSearch.style.display = "none";
                } else {
                    btnPDCForVerificationSubmittedBatchOptions.style.display = "none";
                    btnPDCVerifiedSubmittedBatchOptions.style.display = "none";
                    tbxPDCForVerificationSubmittedSearch.style.display = "block";
                    spanPDCForVerificationSubmittedSearch.style.display = "block";
                    tbxPDCVerifiedSubmittedSearch.style.display = "block";
                    spanPDCVerifiedSubmittedSearch.style.display = "block";
                    tbxPDCVerifiedSubmittedSearch.value = '';
                    tbxPDCForVerificationSubmittedSearch.value = '';
                }
            });
            //checkbox

            //validate inputs
            var inputsHighlightEdit = ['#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlCheckNo', '#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlCheckDate', '#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlAmount', '#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlBank'];

            var lbtnPDCForVerificationSubmittedDtlCancelEdit = $("#ContentPlaceHolder1_lbtnPDCForVerificationSubmittedDtlCancelEdit");

            $(lbtnPDCForVerificationSubmittedDtlCancelEdit).on('click', function () {

                var isValid = true;

                setTimeout(function () {
                    inputsHighlightEdit.forEach(function (inputId) {
                        var inputField = $(inputId);
                        var wrapper = inputField.closest('.select-wrapper');

                        if (!validateHiglightField(inputField, wrapper)) {
                            isValid = false;
                        }
                    });
                }, 500);

                return isValid;
            });

            function validateHiglightField(inputField, wrapper) {
                wrapper.css({
                    'border-color': '',
                    'border-width': '',
                    'border-style': ''
                });

                if (inputField.val().trim() === "" || inputField.val().trim() === "0.00") {
                    wrapper.css({
                        'border-color': 'green',
                        'border-width': '1px',
                        'border-style': 'solid'
                    });
                    return false;
                }
                return true;
            }
            //validate inputs

            //higlight input fields
            var inputGroups = [
                {
                    inputs: ['#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlCheckDate', '#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlCheckNo', '#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlAmount', '#ContentPlaceHolder1_tbxPDCForVerificationSubmittedDtlBank'],
                    button: '#ContentPlaceHolder1_lbtnPDCForVerificationSubmittedDtlSave'
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

