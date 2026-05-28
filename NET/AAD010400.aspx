<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010400.aspx.vb" Inherits="NET.SubmittedPDC" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Post Dated Checks (Monitoring)</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<asp:Button ID="btnViewPDCList" runat="server" Text="Button" OnClick="btnViewPDCList_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCPending" runat="server" Text="Button" OnClick="btnViewPDCPending_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCApproved" runat="server" Text="Button" OnClick="btnViewPDCApproved_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnViewPDCDeclined" runat="server" Text="Button" OnClick="btnViewPDCDeclined_Click" ClientIDMode="Static" style="display:none;"/>
		<%--<asp:Button ID="btnCSPDCSubmit" runat="server" Text="Button" OnClick="btnCSPDCSubmit_Click" ClientIDMode="Static" style="display:none;"/>
		<asp:Button ID="btnFINPDCSubmit" runat="server" Text="Button" OnClick="btnFINPDCSubmit_Click" ClientIDMode="Static" style="display:none;"/>--%>
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
											<span class="text-gray-900 fs-2 fw-bolder me-1">Post Dated Checks</span>
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
										<a id="pending_tab_1" class="nav-link text-active-gray-800 me-4 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCPending">Pending &nbsp; <span class="badge badge-square bg-warning py-2 px-3"><asp:Label ID="lbl01PendingTotal" runat="server"></asp:Label></span> </a>
									</li>
									<!--end::Nav item-->

									<!--begin::Nav item-->
									<li class="nav-item">
										<a id="approved_tab_2" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCApproved">Approved &nbsp; <span class="badge badge-square bg-success py-2 px-3"><asp:Label ID="lbl01ApprovedTotal" runat="server"></asp:Label></span></a>
									</li>
									<!--end::Nav item-->											
									<!--begin::Nav item-->
									<li class="nav-item">
										<a id="declined_tab_3" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlPDCDeclined">Declined &nbsp; <span class="badge badge-square bg-danger py-2 px-3"><asp:Label ID="lbl01DeclinedTotal" runat="server"></asp:Label></span></a>
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
							<input id="tbxSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
						</div>
						<!--end::Search-->
					</div>
					<!--end::Card head-->
					<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Tab Content-->
						<div class="tab-content">
							<!--begin::Tab panel-->
							<asp:UpdatePanel ID="upnlPDCPending" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gv01PDCPending" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
													</ItemTemplate>
												<ItemStyle CssClass=" min-w-20px"/>
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
														<%--<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("AcctNo") %>'>
															<span class="svg-icon svg-icon-2">
																<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
																	<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
																</svg>
															</span>
														</asp:Linkbutton>--%>
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCList") %>">
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
							<asp:UpdatePanel ID="upnlPDCApproved" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gv02PDCApproved" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
													</ItemTemplate>
												<ItemStyle CssClass=" min-w-20px"/>
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
												<asp:TemplateField HeaderText="Ref. No.">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<div class="flex-grow-1 me-2">
																<span class="fw-bold fs-7 text-dark"><%# Eval("CheckNo") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Amount">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<span class="fw-bold fs-7 text-dark"><%# Eval("Amount") %></span>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Remarks">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<span class="fw-bold fs-7 text-dark"><%# Eval("Remarks") %></span>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
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
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCApproved") %>">
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

							<!--begin::Tab panel-->
							<asp:UpdatePanel ID="upnlPDCDeclined" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gv03PDCDeclined" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
													</ItemTemplate>
												<ItemStyle CssClass=" min-w-20px"/>
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
												<asp:TemplateField HeaderText="Ref. No.">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<div class="flex-grow-1 me-2">
																<span class="fw-bold fs-7 text-dark"><%# Eval("CheckNo") %></span>
															</div>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Amount">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<span class="fw-bold fs-7 text-dark"><%# Eval("Amount") %></span>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Remarks">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<span class="fw-bold fs-7 text-dark"><%# Eval("Remarks") %></span>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Status">
													<ItemTemplate>
														<div class="d-flex align-items-center flex-row-fluid flex-wrap">
															<span class="badge py-2 px-4 fs-8 badge-danger"><%# Eval("Status") %></span>
														</div>
													</ItemTemplate>
													<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Actions">
													<ItemTemplate>
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCDeclined") %>">
														<%--<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("PDCCode") %>'>--%>
															<span class="svg-icon svg-icon-2">
																<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
																	<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
																</svg>
															</span>
														</a>
														<%--</asp:Linkbutton>--%>
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

<!--begin::Modal Declined-->
<asp:UpdatePanel ID="mdl03DeclinedPDC" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lbl03PDCTitle" runat="server"></asp:Label></h5>
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
							<h3 class="card-title">PDC Details</h3>
						</div>
						<div class="card-body">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Account No.</span>
								<asp:Label ID="lbl03AcctNo" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Name</span>
								<asp:Label ID="lbl03Name" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Check Date</span>
								<asp:Label ID="lbl03CheckDate" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Check No.</span>
								<asp:Label ID="lbl03CheckNo" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Amount</span>
								<asp:Label ID="lbl03Amount" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Bank</span>
								<asp:Label ID="lbl03Bank" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Date Submitted</span>
								<asp:Label ID="lbl03DateSubmitted" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:Label ID="lbl03Remarks" runat="server" class="form-control">-</asp:Label>
							</div>
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
								<asp:Label ID="lbl03Status" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved By</span>
								<asp:Label ID="lbl03ApprovedBy" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved Date</span>
								<asp:Label ID="lbl03ApprovedDate" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approver Remarks</span>
								<asp:Label ID="lbl03ApproverRemarks" runat="server" class="form-control">-</asp:Label>
							</div>
						</div>
					</div>
					<!--end::Status-->
				</div>
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
<!--begin::Modal Declined-->
	
<!--begin::Modal Approved-->
<asp:UpdatePanel ID="mdl02ApprovedPDC" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lbl02PDCTitle" runat="server"></asp:Label></h5>
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
							<h3 class="card-title">PDC Details</h3>
						</div>
						<div class="card-body">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Account No.</span>
								<asp:Label ID="lbl02AcctNo" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Name</span>
								<asp:Label ID="lbl02Name" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Check Date</span>
								<asp:Label ID="lbl02CheckDate" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Check No.</span>
								<asp:Label ID="lbl02CheckNo" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Amount</span>
								<asp:Label ID="lbl02Amount" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Bank</span>
								<asp:Label ID="lbl02Bank" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Date Submitted</span>
								<asp:Label ID="lbl02DateSubmitted" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:Label ID="lbl02Remarks" runat="server" class="form-control">-</asp:Label>
							</div>
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
								<asp:Label ID="lbl02Status" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved By</span>
								<asp:Label ID="lbl02ApprovedBy" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approved Date</span>
								<asp:Label ID="lbl02ApprovedDate" runat="server" class="form-control">-</asp:Label>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Approver Remarks</span>
								<asp:Label ID="lbl02ApproverRemarks" runat="server" class="form-control">-</asp:Label>
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

<!--begin::Modal Pending-->
<asp:UpdatePanel ID="mdl01PDCPending" runat="server" UpdateMode="Conditional" class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lbl01PDCTitle" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList" aria-label="Close">
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
											<asp:LinkButton ID="lbtn01CancelPDC" runat="server" ToolTip="Cancel record" class="btn btn-sm btn-icon btn-danger align-self-center m-1" Visible="false"><i class="las la-ban fs-2"></i></asp:LinkButton>
											<asp:LinkButton ID="lbtn01EditPDC" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-success btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
											<asp:LinkButton ID="lbtn01SavePDC" runat="server" ToolTip="Save record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1" Visible="false"><i class="las la-save fs-2"></i></asp:LinkButton>
										</div>
									</div>
									<div class="card-body">
										<asp:Label ID="lbl01PDCCode" runat="server" class="form-control" visible="false"></asp:Label>
										<asp:Label ID="lbl01Email" runat="server" class="form-control" Visible="false">-</asp:Label>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Account No.</span>
											<asp:Label ID="lbl01AcctNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Name</span>
											<asp:Label ID="lbl01Name" runat="server" class="form-control">-</asp:Label>
										</div>
										<asp:Panel ID="pnl01Edit" runat="server" Visible="false">
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Check No.</span>
												<input id="tbx01CheckNo" runat="server" type="text" class="form-control" placeholder="Enter Check No." />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Check No. is required.
											</div>
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Check Date</span>
												<input id="tbx01CheckDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" placeholder="Pick a Date" readonly="readonly" />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Check Date is required.
											</div>
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Amount</span>
												<input id="tbx01Amount" runat="server" class='form-control' MaxLength="12" onblur="FormatNumeric(this.id);" type="text" value="0.00" />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Amount is required.
											</div>
											<div class="input-group select-wrapper input-group-sm mb-2">
												<span class="input-group-text min-w-150px required">Bank</span>
												<input id="tbx01Bank" runat="server" class='form-control' type="text" placeholder="Enter Bank" />
											</div>
											<div class="error-message mb-2" style="display:none; color: red;">
												Bank is required.
											</div>
										</asp:Panel>
										<asp:Panel ID="pnl01Dtl" runat="server" Visible="false">
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Check Date</span>
												<asp:Label ID="lbl01CheckDate" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Check No.</span>
												<asp:Label ID="lbl01CheckNo" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Amount</span>
												<asp:Label ID="lbl01Amount" runat="server" class="form-control">-</asp:Label>
											</div>
											<div class="input-group input-group-sm mb-2">
												<span class="input-group-text min-w-150px">Bank</span>
												<asp:Label ID="lbl01Bank" runat="server" class="form-control">-</asp:Label>
											</div>
										</asp:Panel>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Submitted</span>
											<asp:Label ID="lbl01DateSubmitted" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lbl01Remarks" runat="server" class="form-control">-</asp:Label>
										</div>
									</div>
								</div>
								<!--end::Tab pane-->
								<!--begin::Tab pane-->
								<div class="tab-pane" id="kt_timeline_widget_4_tab_week" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="table-responsive pb-10">
										<div class="card-body mh-300px scroll-y">
											<div id="divTimeline" runat="server" class="timeline"></div>
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
					<div id="div01CSStatus" runat="server" class="card shadow-sm" visible="false">
						<div class="card-header">
							<h3 class="card-title">Status</h3>
						</div>
						<div class="card-body">
							<div class="input-group select-wrapper input-group-sm mb-2">
								<span class="input-group-text input-group-text-top min-w-150px required">Remarks</span>
								<asp:TextBox ID="tbx01CSRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="error-message" style="display:none; color: red;">
								Remarks is required.
							</div>
						</div>
					</div>
					<div id="div01FINStatus" runat="server" class="card shadow-sm" visible="false">
						<div class="card-header">
							<h3 class="card-title">Status</h3>
						</div>
						<div class="card-body">
							<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
								<span class="input-group-text min-w-150px required">Status</span>
								<asp:DropDownList ID="ddl01FINStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
									<asp:ListItem Value="">Select Status</asp:ListItem>
									<asp:ListItem Value="Approved">Approved</asp:ListItem>
									<asp:ListItem Value="Declined">Declined</asp:ListItem>
								</asp:DropDownList>
							</div>
							<div class="error-message mb-2" style="display:none; color: red;">
								Status is required.
							</div>
							<div class="input-group select-wrapper input-group-sm mb-2">
								<span class="input-group-text input-group-text-top min-w-150px required">Approver Remarks</span>
								<asp:TextBox ID="tbx01FINRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="error-message" style="display:none; color: red;">
								Remarks is required.
							</div>
						</div>
					</div>
					<!--end::Status-->
				</div>
				<!--begin::Actions-->
				<div id="divCSButton" runat="server" class="modal-footer text-center" visible="false">
					<button type="button" class="btn btn-light me-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList">Cancel</button>
					<asp:LinkButton ID="lbtn01CSSubmit" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
				</div>
				<div id="divFINButton" runat="server" class="modal-footer text-center" visible="false">
					<button type="button" class="btn btn-light me-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdl01PDCList">Cancel</button>
					<asp:LinkButton ID="lbtn01FINSubmit" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
				</div>
				<!--end::Actions-->
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
<!--begin::Modal Pending-->

<!--begin::Modal Submitted PDC-->
<asp:UpdatePanel ID="mdl01PDCList" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lbl01PDCListTitle" runat="server"></asp:Label></h5>
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
						</div>
						<div class="card-body">
							<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
								<!--begin::Table-->
								<asp:GridView ID="gv01PDCList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
											</ItemTemplate>
										<ItemStyle CssClass=" min-w-20px"/>
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
											<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewPDCPending") %>">
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
<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
<!--begin::hidden variable-->
	
<script type="text/javascript">

    function ViewPDCPending(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCPending.ClientID %>");
        clickButton.click();
    };

    function ViewPDCList(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCList.ClientID %>");
        clickButton.click();
	};

    function ViewPDCApproved(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCApproved.ClientID %>");
        clickButton.click();
	};

    function ViewPDCDeclined(ID) {
        // Save ID
        var hfID = document.getElementById("ContentPlaceHolder1_hfID");
        hfID.value = ID;
        // Perform button
        var clickButton = document.getElementById("<%= btnViewPDCDeclined.ClientID %>");
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

		//search
        var $rowsPending = $('#ContentPlaceHolder1_gv01PDCPending tbody tr');
        var $rowsApproved = $('#ContentPlaceHolder1_gv02PDCApproved tbody tr');
        var $rowsDeclined = $('#ContentPlaceHolder1_gv03PDCDeclined tbody tr');

        //search input
        $('#tbxSearch').on('keyup', function () {
            var searchVal = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

            // Check which tab is active and filter the corresponding GridView
            if ($('#pending_tab_1').hasClass('active')) {
                filterRows($rowsPending, searchVal);
            } else if ($('#approved_tab_2').hasClass('active')) {
                filterRows($rowsApproved, searchVal);
            } else if ($('#declined_tab_3').hasClass('active')) {
                filterRows($rowsDeclined, searchVal);
            }
        });

        //reset search
        $('.nav-link').on('click', function () {
            $('#tbxSearch').val('');

            $rowsPending.show();
            $rowsApproved.show();
            $rowsDeclined.show();
        });

        //function to filter rows
        function filterRows($rows, val) {
            $rows.show().filter(function () {
                var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                return !~text.indexOf(val);
            }).hide();
        }
        //search
    }
    //postback

    function pageLoad(sender, args) { InitialiseSettings(); }
    function InitialiseSettings() {
		jQuery(function ($) {

			//validate inputs
            var inputsHighlightEdit = ['#ContentPlaceHolder1_tbx01CheckNo', '#ContentPlaceHolder1_tbx01CheckDate', '#ContentPlaceHolder1_tbx01Amount', '#ContentPlaceHolder1_tbx01Bank'];
			var inputsEmptyEdit = ['#ContentPlaceHolder1_tbx01CheckNo', '#ContentPlaceHolder1_tbx01CheckDate', '#ContentPlaceHolder1_tbx01Amount', '#ContentPlaceHolder1_tbx01Bank'];
			var dropdownEmptyStatus = ['#ContentPlaceHolder1_ddl01Status'];
            var inputsEmptyRemarks = ['#ContentPlaceHolder1_tbx01Remarks'];

            inputsEmptyEdit.forEach(function (inputId) {
                var inputField = $(inputId);
                var wrapper = inputField.closest('.select-wrapper');
                var errorMessage = wrapper.next('.error-message');

                inputField.on('blur', function () {
                    validateInputField(inputField, wrapper, errorMessage);
                });
            });

            inputsEmptyRemarks.forEach(function (inputId) {
                var inputField = $(inputId);
                var wrapper = inputField.closest('.select-wrapper');
                var errorMessage = wrapper.next('.error-message');

                inputField.on('blur', function () {
                    validateInputField(inputField, wrapper, errorMessage);
                });
            });

            dropdownEmptyStatus.forEach(function (dropdownId) {
                var dropdown = $(dropdownId);
                var wrapper = dropdown.closest('.select-wrapper');
                var errorMessage = wrapper.next('.error-message');

                dropdown.on('change', function () {
                    validateDropdown(dropdown, wrapper, errorMessage);
                });
            });

            var lbtn01FINSubmit = $("#ContentPlaceHolder1_lbtn01FINSubmit");
            $(lbtn01FINSubmit).on('click', function () {
                var isValid = true;
                inputsEmptyRemarks.forEach(function (inputId) {
                    var inputField = $(inputId);
                    var wrapper = inputField.closest('.select-wrapper');
                    var errorMessage = wrapper.next('.error-message');
                    if (!validateInputField(inputField, wrapper, errorMessage)) {
                        isValid = false;
                    }
                });

                dropdownEmptyStatus.forEach(function (dropdownId) {
                    var dropdown = $(dropdownId);
                    var wrapper = dropdown.closest('.select-wrapper');
                    var errorMessage = wrapper.next('.error-message');
                    if (!validateDropdown(dropdown, wrapper, errorMessage)) {
                        isValid = false;
                    }
                });

                return isValid;
			});

            var lbtn01EditPDC = $("#ContentPlaceHolder1_lbtn01EditPDC");
			$(lbtn01EditPDC).on('click', function () {

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

            var lbtn01SavePDC = $("#ContentPlaceHolder1_lbtn01SavePDC");
            $(lbtn01SavePDC).on('click', function () {
                var isValid = true;
                inputsEmptyEdit.forEach(function (inputId) {
                    var inputField = $(inputId);
                    var wrapper = inputField.closest('.select-wrapper');
                    var errorMessage = wrapper.next('.error-message');
                    if (!validateInputField(inputField, wrapper, errorMessage)) {
                        isValid = false;
                    }
                });

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

            function validateInputField(inputField, wrapper, errorMessage) {
                wrapper.css({
                    'border-color': '',
                    'border-width': '',
                    'border-style': ''
                });
                errorMessage.hide();

                if (inputField.val().trim() === "" || inputField.val().trim() === "0.00") {
                    wrapper.css({
                        'border-color': 'red',
                        'border-width': '1px',
                        'border-style': 'solid'
                    });
                    errorMessage.show();
                    return false;
                }
                return true;
            }

            function validateDropdown(dropdown, wrapper, errorMessage) {
                // Reset styles
                wrapper.css({
                    'border-color': '',
                    'border-width': '',
                    'border-style': '',
                    'border-radius': ''
                });
                errorMessage.hide();

                if (dropdown.val() === "" || dropdown.val() === null) {
                    wrapper.css({
                        'border-color': 'red',
                        'border-width': '1px',
                        'border-style': 'solid',
                        'border-radius': '3px'
                    });
                    errorMessage.show();
                    return false;
                }
                return true;
            }
            //validate inputs

			//combobox
            $('[data-kt-repeater="select2"]').on('select2:open', function (e) {
                const targetSelect2 = $(e.target).data('select2');
                if (targetSelect2) {
                    targetSelect2.$dropdown.css('position', 'fixed');
                }
            });

            $('[data-kt-repeater="select2"]').select2({
                dropdownParent: $('#ContentPlaceHolder1_mdl01PDCPending')
            });
			//combobox

			//date
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y"
            });
			//date

        });
    }

</script>
<!-- scripts related to this page -->

</asp:Content>
