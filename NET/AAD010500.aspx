<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010500.aspx.vb" Inherits="NET.SubmittedRemittance" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Remittance Slip</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="btnViewRSPendingSubmitted" runat="server" Text="Button" OnClick="btnViewRSPendingSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnViewRSPendingSubmittedDtl" runat="server" Text="Button" OnClick="btnViewRSPendingSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnViewRSHistorySubmitted" runat="server" Text="Button" OnClick="btnViewRSHistorySubmitted_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnViewRSHistorySubmittedDtl" runat="server" Text="Button" OnClick="btnViewRSHistorySubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
		<!--begin::Container-->
	<div id="kt_content_container" class="d-flex flex-column-fluid align-items-start container-xxl">
		<!--begin::Post-->
		<div class="content flex-row-fluid" id="kt_content2">
			<!--begin::Navbar-->
			<div class="card card-flush pb-0 bgi-position-y-center bgi-no-repeat mb-5" style="background-size: auto calc(100% + 10rem); background-position-x: 100%; background-image: url('assets/media/custom/remittance.png')">
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
										<span class="text-gray-900 fs-2 fw-bolder me-1">Remittance Slip</span>
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
					<asp:UpdatePanel ID="upnlRemittanceTotal" runat="server" UpdateMode="Conditional" >
					<ContentTemplate>
						<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder">
							<!--begin::Nav item-->
							<li class="nav-item">
								<a id="pending_tab_1" class="nav-link text-active-primary me-6 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlRSPendingList">Pending &nbsp <span class="badge badge-square badge-warning"><asp:Label ID="lblPendingTotal" runat="server"></asp:Label></span></a>
							</li>
							<!--end::Nav item-->
							<!--begin::Nav item-->
							<li class="nav-item">
								<a id="history_tab_2" class="nav-link text-active-primary me-6" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlRSHistoryList">History &nbsp <span class="badge badge-square badge-success"><asp:Label ID="lblHistoryTotal" runat="server"></asp:Label></span></a>
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
							<span class="card-label fw-bolder text-dark">Remittance Slip Status</span>
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
						<input id="tbxRSSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					</div>
					<!--end::Search-->
				</div>
				<!--end::Card head-->
				<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Tab Content-->
							<div class="tab-content">
								<!--begin::Tab panel-->
								<asp:UpdatePanel ID="upnlRSPendingList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
									<ContentTemplate>
										<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
											<asp:GridView ID="gvRSPendingList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
													<ItemStyle CssClass=" min-w-20px"/>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Name">
														<ItemTemplate>
															<div class="d-flex align-items-center">
																<div class="d-flex flex-column">
																	<span class="fw-bold fs-7 text-dark"><%# Eval("Fullname") %></span>
																</div>
															</div>
														</ItemTemplate>
														<ItemStyle CssClass="min-w-80px"/>
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
															<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewRSPendingSubmitted") %>">
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
								<asp:UpdatePanel ID="upnlRSHistoryList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
									<ContentTemplate>
										<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
											<asp:GridView ID="gvRSHistoryList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
													<ItemStyle CssClass=" min-w-20px"/>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Name">
														<ItemTemplate>
															<div class="d-flex align-items-center">
																<div class="d-flex flex-column">
																	<span class="fw-bold fs-7 text-dark"><%# Eval("Fullname") %></span>
																</div>
															</div>
														</ItemTemplate>
														<ItemStyle CssClass="min-w-80px"/>
													</asp:TemplateField>
													<asp:TemplateField HeaderText="Actions">
														<ItemTemplate>
															<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewRSHistorySubmitted") %>">
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

	<!--begin::Modal Pending Submitted Detail-->
	<asp:UpdatePanel ID="mdlRSPendingSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblRSPendingSubmittedDtlTitle" runat="server"></asp:Label></h5>
						<!--begin::Close-->
						<asp:LinkButton ID="lbtnRSPendingSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
						<!--begin::Remittance Details-->
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
								<asp:Label ID="lblRSPendingSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Account No.</span>
									<asp:Label ID="lblRSPendingSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Name</span>
									<asp:Label ID="lblRSPendingSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Remittance Date</span>
									<asp:Label ID="lblRSPendingSubmittedDtlRemittanceDate" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Reference No.</span>
									<asp:Label ID="lblRSPendingSubmittedDtlReferenceNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Amount</span>
									<asp:Label ID="lblRSPendingSubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Submitted</span>
									<asp:Label ID="lblRSPendingSubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Remarks</span>
									<asp:Label ID="lblRSPendingSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
								</div>
								<asp:Label ID="lblRSPendingSubmittedDtlEmail" runat="server" class="form-control" Visible="false">-</asp:Label>
							</div>
						</div>
						<!--end::Remittance Details-->
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
								<a class="d-block overlay" href="javascript:void(0);" onclick="openViewer(this)" title="View image">
									<asp:Image ID="imgRSPendingSubmittedDtlAttachment" runat="server" class="pointer" ToolTip="Click to view image" style="width:150px;height:150px;" />
									<div class="overlay-layer card-rounded bg-dark bg-opacity-25" style="width:150px;height:150px;">
										<i class='bi bi-eye-fill fs-2x text-white'></i>
									</div>
								</a>
							</div>
						</div>
						<!--end::Attachments-->
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
									<asp:DropDownList ID="ddlRSPendingSubmittedDtlStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
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
									<asp:TextBox ID="tbxRSPendingSubmittedDtlRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
								</div>
								<div class="error-message" style="display:none; color: red;">
									Approver Remarks is required.
								</div>
							</div>
						</div>
						<!--end::Status-->
					</div>
					<!--begin::Actions-->
					<div class="modal-footer text-center">
						<asp:LinkButton ID="lbtnRSPendingSubmittedDtlCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
						<asp:LinkButton ID="lbtnRSPendingSubmittedDtlSubmit" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Pending Submitted Detail-->

	<!--begin::Modal History Submitted-->
	<asp:UpdatePanel ID="mdlRSHistorySubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblRSHistorySubmittedTitle" runat="server"></asp:Label></h5>
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
						<!--begin::INQ Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">List of Submitted Inquiry</h3>
								<div class="card-toolbar">
									<!--begin::Search-->
									<div class="d-flex align-items-center position-relative m-1">
										<span class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<input id="tbxRSHistorySubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block;" placeholder="Search Record" />
									</div>
									<!--begin::Search-->
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
									<!--begin::Table-->
									<asp:GridView ID="gvRSHistorySubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
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
														<span class="fw-bold fs-7 text-dark"><%# Eval("RSDate") %></span>
													</div>
												</div>
												</ItemTemplate>
												<ItemStyle CssClass="min-w-80px"/>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Inquiry">
												<ItemTemplate>
												<div class="d-flex align-items-center flex-row-fluid flex-wrap">
													<div class="flex-grow-1 me-2">
														<span class="fw-bold fs-7 text-dark"><%# Eval("RSRefNo") %></span>
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
												<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewRSHistorySubmittedDtl") %>">
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
						<!--end::INQ Details-->
						</div>
					</div>
				</div>
				</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal History Submitted-->

	<!--begin::Modal History Details-->
	<asp:UpdatePanel ID="mdlRSHistorySubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblRSHistorySubmittedDtlTitle" runat="server"></asp:Label></h5>
						<!--begin::Close-->
						<asp:LinkButton ID="lbtnRSHistorySubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
						<!--begin::Remittance Details-->
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
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Account No.</span>
									<asp:Label ID="lblRSHistorySubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Name</span>
									<asp:Label ID="lblRSHistorySubmittedDtlName" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Remittance Date</span>
									<asp:Label ID="lblRSHistorySubmittedDtlRemittanceDate" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Reference No.</span>
									<asp:Label ID="lblRSHistorySubmittedDtlReferenceNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Amount</span>
									<asp:Label ID="lblRSHistorySubmittedDtlAmount" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Submitted</span>
									<asp:Label ID="lblRSHistorySubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Remarks</span>
									<asp:Label ID="lblRSHistorySubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
						</div>
						<!--end::Remittance Details-->
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
								<a class="d-block overlay" href="javascript:void(0);" onclick="openViewer(this)" title="View image">
									<asp:Image ID="imgRSHistorySubmittedDtlAttachment" runat="server" class="pointer" ToolTip="Click to view image" style="width:150px;height:150px;" />
									<div class="overlay-layer card-rounded bg-dark bg-opacity-25" style="width:150px;height:150px;">
										<i class='bi bi-eye-fill fs-2x text-white'></i>
									</div>
								</a>
							</div>
						</div>
						<!--end::Attachments-->
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
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:Label ID="lblRSHistorySubmittedDtlStatus" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approved By</span>
									<asp:Label ID="lblRSHistorySubmittedDtlApprovedBy" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approved Date</span>
									<asp:Label ID="lblRSHistorySubmittedDtlApprovedDate" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approver Remarks</span>
									<asp:Label ID="lblRSHistorySubmittedDtlApproverRemarks" runat="server" class="form-control">-</asp:Label>
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

	<!--begin::Modal Pending Submitted-->
	<asp:UpdatePanel ID="mdlRSPendingSubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblRSPendingSubmittedTitle" runat="server"></asp:Label></h5>
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
						<!--begin::RS Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">List of Submitted Remittance Slip</h3>
								<div class="card-toolbar">
									<!--begin::Search-->
									<div class="d-flex align-items-center position-relative m-1">
										<span id="spanRSPendingSubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<input id="tbxRSPendingSubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block;" placeholder="Search Record" />
									</div>
									<!--end::Search-->
									<!--begin::Batch Options-->
									<button id="btnRSPendingSubmittedBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
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
										<!--begin::Change Status-->
										<div class="menu-item px-3">
											<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlRSBatchChangeStatus">
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
										<!--end::Change Status-->
									</div>
									<!--end::Batch Options-->
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
									<!--begin::Table-->
									<asp:GridView ID="gvRSPendingSubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<span class="bullet bullet-margin bullet-vertical h-40px bg-warning"></span>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="">
												<HeaderTemplate>
													<div class="form-check form-check-sm form-check-custom form-check-solid">
														<input id="cbxRSPendingSubmittedAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
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
														<span class="fw-bold fs-7 text-dark"><%# Eval("RSDate") %></span>
													</div>
												</div>
												</ItemTemplate>
												<ItemStyle CssClass="min-w-80px"/>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Reference No.">
												<ItemTemplate>
												<div class="d-flex align-items-center flex-row-fluid flex-wrap">
													<div class="flex-grow-1 me-2">
														<span class="fw-bold fs-7 text-dark"><%# Eval("RSRefNo") %></span>
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
												<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewRSPendingSubmittedDtl") %>">
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
						<!--end::RS Details-->
						</div>
					</div>
				</div>
				</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Pending Submitted -->

	<!--begin::Modal Batch Change Status-->
	<asp:UpdatePanel ID="mdlRSBatchChangeStatus" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title">Change Status</h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnRSBatchChangeStatusClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
								<asp:DropDownList ID="ddlRSBatchChangeStatusStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
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
								<asp:TextBox ID="tbxRSBatchChangeStatusRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
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
					<asp:LinkButton ID="lbtnRSBatchChangeStatusCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
					<asp:LinkButton ID="lbtnRSBatchChangeStatusSave" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
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

        function ViewRSPendingSubmitted(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnViewRSPendingSubmitted.ClientID %>");
			clickButton.click();
		 };

		 function ViewRSPendingSubmittedDtl(ID) {
			 // Save ID
			 var hfID = document.getElementById("ContentPlaceHolder1_hfID");
			 hfID.value = ID;
			 // Perform button
			var clickButton = document.getElementById("<%= btnViewRSPendingSubmittedDtl.ClientID %>");
			clickButton.click();
		};

		function ViewRSHistorySubmitted(ID) {
			// Save ID
			var hfID = document.getElementById("ContentPlaceHolder1_hfID");
			hfID.value = ID;
			// Perform button
			var clickButton = document.getElementById("<%= btnViewRSHistorySubmitted.ClientID %>");
			clickButton.click();
		};

		  function ViewRSHistorySubmittedDtl(ID) {
			// Save ID
			var hfID = document.getElementById("ContentPlaceHolder1_hfID");
			hfID.value = ID;
			// Perform button
			var clickButton = document.getElementById("<%= btnViewRSHistorySubmittedDtl.ClientID %>");
            clickButton.click();
        };

        //viewer JS
        function openViewer(element) {
            var imgElement = element.querySelector('img');
            var viewer = new Viewer(imgElement, {
                inline: false,
                toolbar: {
                    zoomIn: 1,
                    zoomOut: 1,
                    oneToOne: 1,
                    reset: 1,
                    rotateLeft: 1,
                    rotateRight: 1
                },
                viewed() {
                    viewer.zoomTo(1);
                },
                hidden() {
                    viewer.destroy();
                }
            });
            viewer.show();
        }
        //viewer JS

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

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //search
                var $rowsPending = $('#ContentPlaceHolder1_gvRSPendingList tbody tr');
                var $rowsHistory = $('#ContentPlaceHolder1_gvRSHistoryList tbody tr');

                //search input
                $('#tbxRSSearch').on('keyup', function () {
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
                    $('#tbxRSSearch').val('');

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
                //search

                //modal search pending submitted 
                var $rowsGvRSPendingSubmitted = $('#ContentPlaceHolder1_gvRSPendingSubmitted tbody tr');
                var $cbxRSPendingSubmittedAll = $('#cbxRSPendingSubmittedAll');

                $('#tbxRSPendingSubmittedSearch').keyup(function () {
                    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

                    $rowsGvRSPendingSubmitted.show().filter(function () {
                        var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                        return !~text.indexOf(val);
                    }).hide();

                    //check if any rows are still visible
                    var anyVisible = $rowsGvINQPendingSubmitted.filter(':visible').length > 0;

                    //enable or disable the checkbox
                    $cbxRSPendingSubmittedAll.prop('disabled', !anyVisible);
                });
                //modal search inquiry submitted

                //modal search history submitted 
                var $rowsGvINQHistorySubmitted = $('#ContentPlaceHolder1_gvRSHistorySubmitted tbody tr');
                $('#tbxRSHistorySubmittedSearch').keyup(function () {
                    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                    $rowsGvINQHistorySubmitted.show().filter(function () {
                        var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                        return !~text.indexOf(val);
                    }).hide();
                });
                //modal search history submitted 

                //checkbox
                $('.checkBoxAllClass').click(function () {
                    var lbtnRSPendingSubmittedChangeStatus = document.getElementById("btnRSPendingSubmittedBatchOptions");
                    var tbxRSPendingSubmittedSearch = document.getElementById("tbxRSPendingSubmittedSearch");
                    var spanRSPendingSubmittedSearch = document.getElementById("spanRSPendingSubmittedSearch");

                    if ($(this).is(":checked")) {
                        $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                        btnRSPendingSubmittedBatchOptions.style.display = "";
                        tbxRSPendingSubmittedSearch.style.display = "none";
                        spanRSPendingSubmittedSearch.style.display = "none";
                    } else {
                        $(".checkBoxClass").prop('checked', false);
                        btnRSPendingSubmittedBatchOptions.style.display = "none";
                        tbxRSPendingSubmittedSearch.value = '';
                        tbxRSPendingSubmittedSearch.style.display = "block";
                        spanRSPendingSubmittedSearch.style.display = "block";
                    }
                })
                $(".checkBoxClass").change(function () {
                    var btnRSPendingSubmittedBatchOptions = document.getElementById("btnRSPendingSubmittedBatchOptions");
                    var tbxRSPendingSubmittedSearch = document.getElementById("tbxRSPendingSubmittedSearch");
                    var spanRSPendingSubmittedSearch = document.getElementById("spanRSPendingSubmittedSearch");

                    if (!$(this).prop("checked")) {
                        $(".checkBoxAllClass").prop("checked", false);
                    }
                    if ($('.checkBoxClass:checked').length > 0) {
                        btnRSPendingSubmittedBatchOptions.style.display = "";
                        tbxRSPendingSubmittedSearch.style.display = "none";
                        spanRSPendingSubmittedSearch.style.display = "none";
                    } else {
                        btnRSPendingSubmittedBatchOptions.style.display = "none";
                        tbxRSPendingSubmittedSearch.value = '';
                        tbxRSPendingSubmittedSearch.style.display = "block";
                        spanRSPendingSubmittedSearch.style.display = "block";

                    }
                });
                //checkbox

                //higlight input fields
                var inputGroups = [
                    {
                        inputs: ['#ContentPlaceHolder1_tbxRSPendingSubmittedDtlRemarks'],
                        dropdowns: ['#ContentPlaceHolder1_ddlRSPendingSubmittedDtlStatus'],
                        button: '#ContentPlaceHolder1_lbtnRSPendingSubmittedDtlSubmit'
                    },
                    {
                        inputs: ['#ContentPlaceHolder1_tbxRSBatchChangeStatusRemarks'],
                        dropdowns: ['#ContentPlaceHolder1_ddlRSBatchChangeStatusStatus'],
                        button: '#ContentPlaceHolder1_lbtnRSBatchChangeStatusSave'
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
                    { selector: "#ContentPlaceHolder1_ddlRSPendingSubmittedDtlStatus", parent: "#ContentPlaceHolder1_mdlRSPendingSubmittedDtl" },
                    { selector: "#ContentPlaceHolder1_ddlRSBatchChangeStatusStatus", parent: "#ContentPlaceHolder1_mdlRSBatchChangeStatus" }
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
