<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010800.aspx.vb" Inherits="NET.VerifiedPDC" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Post Dated Checks (For Approval)</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<asp:Button ID="btnViewPDCPendingSubmitted" runat="server" Text="Button" OnClick="btnViewPDCPendingSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCPendingSubmittedDtl" runat="server" Text="Button" OnClick="btnViewPDCPendingSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnPDCPendingSubmittedDtlReVerify" runat="server" Text="Button" OnClick="btnPDCPendingSubmittedDtlReVerify_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCHistorySubmitted" runat="server" Text="Button" OnClick="btnViewPDCHistorySubmitted_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCHistorySubmittedDtl" runat="server" Text="Button" OnClick="btnViewPDCHistorySubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnPDCPendingSubmittedReVerify" runat="server" Text="Button" OnClick="btnPDCPendingSubmittedReVerify_Click" ClientIDMode="Static" style="display:none;"/>
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
											<span class="text-gray-900 fs-2 fw-bolder me-1">Post Dated Checks (For Approval)</span>
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
										<a id="pending_tab_1" class="nav-link text-active-gray-800 me-4 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCPendingList">For Approval &nbsp; <span class="badge badge-square bg-warning py-2 px-3"><asp:Label ID="lblPendingTotal" runat="server"></asp:Label></span> </a>
									</li>
									<!--end::Nav item-->

									<!--begin::Nav item-->
									<li class="nav-item">
										<a id="history_tab_2" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCHistoryList">History &nbsp; <span class="badge badge-square bg-success py-2 px-3"><asp:Label ID="lblHistoryTotal" runat="server"></asp:Label></span></a>
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
							<span class="svg-icon svg-icon-2 position-absolute ms-4">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
									<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
								</svg>
							</span>
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
							<asp:UpdatePanel ID="upnlPDCPendingList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvPDCPendingList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
														<div class="d-flex align-items-center">
															<div class="d-flex flex-column">
																<span class="badge badge-light-success"><%# Eval("TotalSubmitted") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="min-w-80px"/>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Actions">
													<ItemTemplate>
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCPendingSubmitted") %>">
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
							<asp:UpdatePanel ID="upnlPDCHistoryList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvPDCHistoryList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
																<span class="fw-bold fs-7 text-dark"><%# Eval("Name") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Actions">
													<ItemTemplate>
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCHistorySubmitted") %>">
														<%--<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("PDCCode") %>'>--%>
															<span class="svg-icon svg-icon-2">
																<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
																	<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
																</svg>
															</span>
														<%--</asp:Linkbutton>--%>
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
	
<!--begin::Modal PDC History Submitted Dtl-->
<asp:UpdatePanel ID="mdlPDCHistorySubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCHistorySubmittedDtlTitle" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnPDCHistorySubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
									<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#PDC_history_details_nav">
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
									<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#PDC_history_history_nav">
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
								<div class="tab-pane active" id="PDC_history_details_nav" role="tabpanel" aria-labelledby="day-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="card-body">
										<asp:Label ID="lblPDCHistorySubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Account No.</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Name</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlName" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Check Date</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlCheckDate" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Check No.</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlCheckNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Amount</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Bank</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlBank" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Submitted</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Remarks</span>
											<asp:Label ID="lblPDCHistorySubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
										</div>
									</div>
								</div>
								<!--end::Tab pane-->
								<!--begin::Tab pane-->
								<div class="tab-pane" id="PDC_history_history_nav" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="table-responsive pb-10">
										<div class="card-body mh-300px scroll-y">
											<div id="divPDCHistorySubmittedDtlTimeline" runat="server" class="timeline"></div>
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
								<asp:Label ID="lblPDCHistorySubmittedDtlStatus" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved By</span>
								<asp:Label ID="lblPDCHistorySubmittedDtlApprovedBy" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved Date</span>
								<asp:Label ID="lblPDCHistorySubmittedDtlApprovedDate" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approver Remarks</span>
								<asp:Label ID="lblPDCHistorySubmittedDtlApproverRemarks" runat="server" class="form-control">-</asp:Label>
							</div>
						</div>
					</div>
					<!--end::Status-->
				</div>
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
<!--begin::Modal PDC History Submitted Dtl-->


<!--begin::Modal PDC History Submitted-->
<asp:UpdatePanel ID="mdlPDCHistorySubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCHistorySubmittedTitle" runat="server"></asp:Label></h5>
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
							<h3 class="card-title">List of Verified PDC</h3
							<!--begin::Search-->
							<div class="d-flex align-items-center position-relative m-1">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span id="spanPDCHistorySubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxPDCHistorySubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
							</div>
							<!--begin::Search-->
							<asp:LinkButton ID="lbtnPDCHistorySubmittedReVerify" runat="server" ToolTip="Revert record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-undo-alt fs-2"></i></asp:LinkButton>
						</div>
						<div class="card-body">
							<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
								<!--begin::Table-->
								<asp:GridView ID="gvPDCHistorySubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class='<%# Eval("Bullet") %>'></span>
											</ItemTemplate>
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
													<span class='<%# Eval("BadgeStyle") %>'><%# Eval("Status") %></span>
												</div>
											</ItemTemplate>
											<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Actions">
											<ItemTemplate>
											<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCHistorySubmittedDtl") %>">
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
<!--begin::Modal PDC History Submitted-->

<!--begin::Modal Pending-->
<asp:UpdatePanel ID="mdlPDCPendingSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCPendingSubmittedDtlTitle" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnPDCPendingSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
										<asp:LinkButton ID="lbtnPDCPendingSubmittedDtlReVerify" runat="server" ToolTip="Re-Verify Record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1"><i class="las la-undo-alt fs-2"></i></asp:LinkButton>
										<%--<button class="btn btn-sm btn-icon btn-success btn align-self-center m-1" onclick="Unlock_Ok(this);"><i class="las la-ban fs-2"></i></button>
										<button class="btn btn-sm btn-icon btn-success btn align-self-center m-1" onclick="Edit_PDC(this);"><i class="las la-pencil-alt fs-2"></i></button>
										<button class="btn btn-sm btn-icon btn-success btn align-self-center m-1" onclick="Unlock_Ok(this);"><i class="las la-save fs-2"></i></button>--%>
									</div>
								</div>
								<div class="card-body">
									<asp:Label ID="lblPDCPendingSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
									<asp:Label ID="lblPDCPendingSubmittedDtlEmail" runat="server" class="form-control" Visible="false">-</asp:Label>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Account No.</span>
										<asp:Label ID="lblPDCPendingSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Name</span>
										<asp:Label ID="lblPDCPendingSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
									</div>
									<asp:Panel ID="pnlPDCPendingSubmittedDtlEdit" runat="server" Visible="false">
										<div class="input-group select-wrapper input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Check No.</span>
											<input id="tbxPDCPendingSubmittedDtlCheckNo" runat="server" type="text" class="form-control" placeholder="Enter Check No." />
										</div>
										<div class="error-message mb-2" style="display:none; color: red;">
											Check No. is required.
										</div>
										<div class="input-group select-wrapper input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Check Date</span>
											<input id="tbxPDCPendingSubmittedDtlCheckDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" placeholder="Pick a Date" readonly="readonly" />
										</div>
										<div class="error-message mb-2" style="display:none; color: red;">
											Check Date is required.
										</div>
										<div class="input-group select-wrapper input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Amount</span>
											<input id="tbxPDCPendingSubmittedDtlAmount" runat="server" class='form-control' MaxLength="12" onblur="FormatNumeric(this.id);" type="text" value="0.00" />
										</div>
										<div class="error-message mb-2" style="display:none; color: red;">
											Amount is required.
										</div>
										<div class="input-group select-wrapper input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Bank</span>
											<input id="tbxPDCPendingSubmittedDtlBank" runat="server" class='form-control' type="text" placeholder="Enter Bank" />
										</div>
										<div class="error-message mb-2" style="display:none; color: red;">
											Bank is required.
										</div>
									</asp:Panel>
									<asp:Panel ID="pnlPDCPendingSubmittedDtlDetail" runat="server" Visible="false">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Check Date</span>
											<asp:Label ID="lblPDCPendingSubmittedDtlCheckDate" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Check No.</span>
											<asp:Label ID="lblPDCPendingSubmittedDtlCheckNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Amount</span>
											<asp:Label ID="lblPDCPendingSubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Bank</span>
											<asp:Label ID="lblPDCPendingSubmittedDtlBank" runat="server" class="form-control">-</asp:Label>
										</div>
									</asp:Panel>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Submitted</span>
										<asp:Label ID="lblPDCPendingSubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Remarks</span>
									<asp:Label ID="lblPDCPendingSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
									</div>
								</div>
							</div>
							<!--end::Tab pane-->
							<!--begin::Tab pane-->
							<div class="tab-pane" id="kt_timeline_widget_4_tab_week" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
								<div class="table-responsive pb-10">
									<div class="card-body mh-300px scroll-y">
										<div id="divPDCPendingSubmittedDtlTimeline" runat="server" class="timeline"></div>
									</div>
								</div>
							</div>
							<!--end::Tab pane-->
						</div>
						<!--end::Tab content-->
					</div>
				<%--</div>--%>
				<!--end::PDC Details-->
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
				<div id="divFINButton" runat="server" class="modal-footer text-center" visible="false">
					<%--<button type="button" class="btn btn-light me-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList">Cancel</button>--%>
					<asp:LinkButton ID="lbtnPDCPendingSubmittedDtlCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
					<%--<asp:LinkButton ID="lbtnCSCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>--%>
					<asp:LinkButton ID="lbtnPDCPendingSubmittedDtlSave" runat="server" class="btn btn-primary">Save</asp:LinkButton>
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

<!--begin::Modal PDC Pending Submitted-->
<asp:UpdatePanel ID="mdlPDCPendingSubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblPDCPendingSubmittedTitle" runat="server"></asp:Label></h5>
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
							<%--<asp:LinkButton ID="lbtn01VerifiedPDC" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1" style="display:none"><i class="las la-check-circle fs-2"></i></asp:LinkButton>--%>
							<div class="card-toolbar">
								<!--begin::Search-->
								<div class="d-flex align-items-center position-relative m-1">
									<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
									<span id="spanPDCPendingSubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
									<input id="tbxPDCPendingSubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block" placeholder="Search Record" />
								</div>
								<!--begin::Search-->
								<!--begin::Menu-->
								<%--<asp:LinkButton ID="lbtn01VerifiedPDC" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">--%>
								<button id="btnPDCPendingSubmittedBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-2">
										<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
											 <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
												<rect x="0" y="0" width="24" height="24"/>
												<path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#279852"/>
											</g>
										</svg>
									</span>
									<!--end::Svg Icon-->
								</button>
								<%--</asp:LinkButton>--%>
								<!--begin::Menu 3-->
								<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-800 menu-state-bg-light-primary fw-bold w-200px py-3" data-kt-menu="true">
									<!--begin::Heading-->
									<div class="menu-item px-3">
										<div class="menu-content fs-6 text-dark fw-bolder px-3 py-4">Options</div>
									</div>
									<!--begin::Menu separator-->
									<div class="separator mb-3 opacity-75"></div>
									<!--end::Menu separator-->
									<!--end::Heading-->
									<!--begin::Menu item-->
									<div class="menu-item px-3">
										<asp:LinkButton ID="lbtn01ReVerifyPDC" runat="server" class="menu-link px-3">
											<span class="svg-icon svg-icon-3 me-3">
												<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
													<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
														<rect x="0" y="0" width="24" height="24"/>
														<path d="M8.43296491,7.17429118 L9.40782327,7.85689436 C9.49616631,7.91875282 9.56214077,8.00751728 9.5959027,8.10994332 C9.68235021,8.37220548 9.53982427,8.65489052 9.27756211,8.74133803 L5.89079566,9.85769242 C5.84469033,9.87288977 5.79661753,9.8812917 5.74809064,9.88263369 C5.4720538,9.8902674 5.24209339,9.67268366 5.23445968,9.39664682 L5.13610134,5.83998177 C5.13313425,5.73269078 5.16477113,5.62729274 5.22633424,5.53937151 C5.384723,5.31316892 5.69649589,5.25819495 5.92269848,5.4165837 L6.72910242,5.98123382 C8.16546398,4.72182424 10.0239806,4 12,4 C16.418278,4 20,7.581722 20,12 C20,16.418278 16.418278,20 12,20 C7.581722,20 4,16.418278 4,12 L6,12 C6,15.3137085 8.6862915,18 12,18 C15.3137085,18 18,15.3137085 18,12 C18,8.6862915 15.3137085,6 12,6 C10.6885336,6 9.44767246,6.42282109 8.43296491,7.17429118 Z" fill="#279852" fill-rule="nonzero"/>
													</g>
												</svg>
											</span>
											Re-Verify PDC
										</asp:LinkButton>
									</div>
									<!--end::Menu item-->
									<!--begin::Menu item-->
									<div class="menu-item px-3">
										<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlPDCBatchChangeStatus">
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
								<!--end::Menu 3-->
								<!--end::Menu-->
							</div>
						</div>
						<div class="card-body">
							<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
								<!--begin::Table-->
								<asp:GridView ID="gvPDCPendingSubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
											</ItemTemplate>
										<ItemStyle CssClass=" min-w-20px"/>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="">
										<HeaderTemplate>
											<div class="form-check form-check-sm form-check-custom form-check-solid">
												<input id="cbxPDCPendingSubmittedAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
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
													<span class="badge py-2 px-4 fs-8 badge-light-warning"><%# Eval("Status") %></span>
												</div>
											</ItemTemplate>
											<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Actions">
											<ItemTemplate>
											<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCPendingSubmittedDtl") %>">
											<%--<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("PDCCode") %>'>--%>
												<span class="svg-icon svg-icon-2">
													<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
														<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
													</svg>
												</span>
											<%--</asp:Linkbutton>--%>
											</a>
											<asp:Label ID="lblID" runat="server" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
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

	<!--begin::Modal Batch Change Status-->
	<asp:UpdatePanel ID="mdlPDCBatchChangeStatus" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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

<!--begin::hidden variable-->
<asp:HiddenField ID="hfID" runat="server" />
<!--begin::hidden variable-->
	
<script type="text/javascript">

    function ViewPDCPendingSubmitted(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCPendingSubmitted.ClientID %>");
        clickButton.click();
    };

    function ViewPDCPendingSubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCPendingSubmittedDtl.ClientID %>");
        clickButton.click();
    };

    function ViewPDCHistorySubmitted(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCHistorySubmitted.ClientID %>");
        clickButton.click();
	};

    function ViewPDCHistorySubmittedDtl(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCHistorySubmittedDtl.ClientID %>");
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
        var $rowsGvPDCPendingSubmitted = $('#ContentPlaceHolder1_gvPDCPendingSubmitted tbody tr');
        var cbxPDCPendingSubmittedAll = $('#cbxPDCPendingSubmittedAll');

        $('#tbxPDCPendingSubmittedSearch').keyup(function () {
            var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            $rowsGvPDCPendingSubmitted.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();

            // Check if any rows are still visible
            var anyVisible = $rowsGvPDCPendingSubmitted.filter(':visible').length > 0;

            // Enable or disable the checkbox based on visibility
            cbxPDCPendingSubmittedAll.prop('disabled', !anyVisible);
        });

		//search PDC
        var $rowsPending = $('#ContentPlaceHolder1_gvPDCPendingList tbody tr');
        var $rowsHistory = $('#ContentPlaceHolder1_gvPDCHistoryList tbody tr');

        //search input
        $('#tbxPDCSearch').on('keyup', function () {
            var searchVal = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            // Check which tab is active and filter the corresponding GridView
            if ($('#pending_tab_1').hasClass('active')) {
                filterRows($rowsPending, searchVal);
            } else if ($('#history_tab_2').hasClass('active')) {
                filterRows($rowsHistory, searchVal);
            }
        });

        //reset search
        $('.nav-link').on('click', function () {
            $('#tbxPDCSearch').val('');

            $rowsPending.show();
            $rowsHistory.show();
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

            //modal search history submitted 
            var $rowsGvPDCHistorySubmitted = $('#ContentPlaceHolder1_gvPDCHistorySubmitted tbody tr');
            $('#tbxPDCHistorySubmittedSearch').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $rowsGvPDCHistorySubmitted.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            //modal search history submitted 

			//checkbox
            $('.checkBoxAllClass').click(function () {
                var btnPDCPendingSubmittedBatchOptions = document.getElementById("btnPDCPendingSubmittedBatchOptions");
                var tbxPDCPendingSubmittedSearch = document.getElementById("tbxPDCPendingSubmittedSearch");
                var spanPDCPendingSubmittedSearch = document.getElementById("spanPDCPendingSubmittedSearch");

                if ($(this).is(":checked")) {
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                    btnPDCPendingSubmittedBatchOptions.style.display = "";
                    tbxPDCPendingSubmittedSearch.style.display = "none";
                    spanPDCPendingSubmittedSearch.style.display = "none";
                } else {
                    $(".checkBoxClass").prop('checked', false);
                    btnPDCPendingSubmittedBatchOptions.style.display = "none";
                    tbxPDCPendingSubmittedSearch.style.display = "block";
                    spanPDCPendingSubmittedSearch.style.display = "block";
                }
            })
            $(".checkBoxClass").change(function () {
                var btnPDCPendingSubmittedBatchOptions = document.getElementById("btnPDCPendingSubmittedBatchOptions");
                var tbxPDCPendingSubmittedSearch = document.getElementById("tbxPDCPendingSubmittedSearch");
                var spanPDCPendingSubmittedSearch = document.getElementById("spanPDCPendingSubmittedSearch");

                if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
                }
                if ($('.checkBoxClass:checked').length > 0) {
                    btnPDCPendingSubmittedBatchOptions.style.display = "";
                    tbxPDCPendingSubmittedSearch.style.display = "none";
                    spanPDCPendingSubmittedSearch.style.display = "none";
                } else {
                    btnPDCPendingSubmittedBatchOptions.style.display = "none";
                    tbxPDCPendingSubmittedSearch.style.display = "block";
                    spanPDCPendingSubmittedSearch.style.display = "block";
                    tbxPDCPendingSubmittedSearch.value = '';
                }
            });
            //checkbox

            //higlight input fields
            var inputGroups = [
                {
                    inputs: ['#ContentPlaceHolder1_tbxPDCPendingSubmittedDtlRemarks'],
                    dropdowns: ['#ContentPlaceHolder1_ddlPDCPendingSubmittedDtlStatus'],
                    button: '#ContentPlaceHolder1_lbtnPDCPendingSubmittedDtlSubmit'
                },
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
                { selector: "#ContentPlaceHolder1_ddlPDCPendingSubmittedDtlStatus", parent: "#ContentPlaceHolder1_mdlPDCPendingSubmittedDtl" },
                { selector: "#ContentPlaceHolder1_ddlPDCBatchChangeStatusStatus", parent: "#ContentPlaceHolder1_mdlPDCBatchChangeStatus" }
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
