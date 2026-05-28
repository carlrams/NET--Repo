<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010300.aspx.vb" Inherits="NET.RequestAndInquiry" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Request and Inquiry</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="btnViewINQPendingSubmitted" runat="server" Text="Button" OnClick="btnViewINQPendingSubmitted_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnViewINQPendingSubmittedDtl" runat="server" Text="Button" OnClick="btnViewINQPendingSubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnViewINQHistorySubmitted" runat="server" Text="Button" OnClick="btnViewINQHistorySubmitted_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnViewINQHistorySubmittedDtl" runat="server" Text="Button" OnClick="btnViewINQHistorySubmittedDtl_Click" ClientIDMode="Static" style="display:none;"/>
		</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
		<!--begin::Container-->
		<div id="kt_content_container" class="d-flex flex-column-fluid align-items-start container-xxl">
			<!--begin::Post-->
			<div class="content flex-row-fluid" id="kt_content2">
				<!--begin::Navbar-->
				<div class="card card-flush pb-0 bgi-position-y-center bgi-no-repeat mb-5" style="background-size: auto calc(100% + 10rem); background-position-x: 100%; background-image: url('../assets/media/custom/inquiry.png')">
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
											<span class="text-gray-900 fs-2 fw-bolder me-1">Request and Inquiry</span>
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
						<asp:UpdatePanel ID="upnlINQTotal" runat="server" UpdateMode="Conditional" class="card-toolbar">
							<ContentTemplate>
								<!--begin::Tab nav-->
								<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap" role="tablist">
									<li class="nav-item" role="presentation">
										<a id="pending_tab_1" class="nav-link text-active-gray-800 me-4 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlINQPendingList">Pending &nbsp; <span class="badge badge-square bg-warning py-2 px-3"><asp:Label ID="lbl01PendingTotal" runat="server"></asp:Label></span> </a>
									</li>
									<li class="nav-item" role="presentation">
										<a id="history_tab_2" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlINQHistoryList">History &nbsp; <span class="badge badge-square bg-success py-2 px-3"><asp:Label ID="lbl01HistoryTotal" runat="server"></asp:Label></span></a>
									</li>
								</ul>
								<!--end::Tab nav-->
							</ContentTemplate>
						</asp:UpdatePanel>
						<!--begin::Navs-->
					</div>
				</div>
				<!--end::Navbar-->
				<!--begin::Card-->
				<div class="card">
					<!--begin::Card head-->
					<div class="card-header card-header-stretch">
						<!--begin::Title-->
						<div class="card-title d-flex align-items-center">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fw-bolder text-dark">Request and Inquiry Status</span>
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
							<input id="tbxINQSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
						</div>
						<!--end::Search-->
					</div>
					<!--end::Card head-->
					<!--begin::Card body-->
					<div class="card-body">
						<!--begin::Tab Content-->
						<div class="tab-content">
							<!--begin::Tab panel-->
							<!--begin::Table Pending-->
							<asp:UpdatePanel ID="upnlINQPendingList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvINQPendingList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewINQPendingSubmitted") %>">
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
							<!--end::Table Pending-->
							<!--begin::Table History-->
							<asp:UpdatePanel ID="upnlINQHistoryList" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
								<ContentTemplate>
									<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
										<asp:GridView ID="gvINQHistoryList" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
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
														<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewINQHistorySubmitted") %>">
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
							<!--end::Table History-->
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

	<!--begin::Modal Pending Submitted-->
	<asp:UpdatePanel ID="mdlINQPendingSubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblINQPendingSubmittedTitle" runat="server"></asp:Label></h5>
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
										<span id="spanINQPendingSubmittedSearch" class="svg-icon svg-icon-2 position-absolute ms-4" style="display:block">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<input id="tbxINQPendingSubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block;" placeholder="Search Record" />
									</div>
									<!--end::Search-->
									<!--begin::Batch Options-->
									<button id="btnINQPendingSubmittedBatchOptions" type="button" class="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" style="display:none">
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
										<!--begin::Create TL-->
										<div class="menu-item px-3">
											<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlINQBatchTLCreation">
												<span class="svg-icon svg-icon-2 me-3">
													<svg xmlns="http://www.w3.org/2000/svg" width="24px" height="24px" viewBox="0 0 24 24">
														<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
															<polygon points="0 0 24 0 24 24 0 24"/>
															<path d="M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z" fill="#279852" fill-rule="nonzero" opacity="0.3"/>
															<rect fill="#279852" x="6" y="11" width="9" height="2" rx="1"/>
															<rect fill="#279852" x="6" y="15" width="5" height="2" rx="1"/>
														</g>
													</svg>
												</span>
												Create TL
											</a>
										</div>
										<!--end::Create TL-->
										<!--begin::Change Status-->
										<div class="menu-item px-3">
											<a class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlINQBatchChangeStatus">
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
									<asp:GridView ID="gvINQPendingSubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<span class="bullet bullet-margin bullet-vertical h-40px bg-warning"></span>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="">
											<HeaderTemplate>
												<div class="form-check form-check-sm form-check-custom form-check-solid">
													<input id="cbxINQPendingSubmittedAll" class="form-check-input checkBoxAllClass" type="checkbox" value="1" />
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
														<span class="fw-bold fs-7 text-dark"><%# Eval("CreatedDate") %></span>
													</div>
												</div>
												</ItemTemplate>
												<ItemStyle CssClass="min-w-80px"/>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Inquiry">
												<ItemTemplate>
												<div class="d-flex align-items-center flex-row-fluid flex-wrap">
													<div class="flex-grow-1 me-2">
														<span class="fw-bold fs-7 text-dark"><%# Eval("Inquiry") %></span>
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
												<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewINQPendingSubmittedDtl") %>">
													<span class="svg-icon svg-icon-2">
														<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
															<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
														</svg>
													</span>
												</a>
												<asp:Label ID="lblINQPendingSubmittedID" runat="server" Text='<%# Eval("INQCode") %>' Visible="false"></asp:Label>
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
	<!--begin::Modal Pending Submitted List-->

	<!--begin::Modal Submitted Details-->
	<asp:UpdatePanel ID="mdlINQPendingSubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lblINQPendingSubmittedDtlTitle" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnINQPendingSubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
					<!--begin::Request/Inquiry Details-->
					<div class="card shadow-sm mb-6">
						<div class="card-header">
							<h3 class="card-title">Request/Inquiry Details</h3>
							<!--begin::Tabs-->
							<ul class="nav nav-stretch nav-pills nav-pills-custom d-flex mt-4">
								<!--begin::Nav Details-->
								<li class="nav-item p-0 ms-0">
									<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#INQ_pending_details_nav">
										<i class="las la-info-circle fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="Details"></i>
										<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
									</a>
								</li>
								<!--end::Nav Details-->
								<!--begin::Nav History-->
								<li class="nav-item p-0 ms-0">
									<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#INQ_pending_history_nav">
										<i class="las la-history fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="History"></i>
										<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
									</a>
								</li>
								<!--end::Nav History-->
							</ul>
							<!--end::Tabs-->
							<!--begin::Ribbon-->
							<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
								<div class="ribbon-icon mt-n5 me-n6">
									<i class="bi bi-card-text fs-3 text-white"></i>
								</div>
							</div>
							<!--end::Ribbon-->
						</div>
							<!--begin::Tab Content-->
							<div class="tab-content">
								<!--begin::Tab Details-->
								<div class="tab-pane active" id="INQ_pending_details_nav" role="tabpanel" aria-labelledby="day-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="card-body">
										<asp:Label ID="lblINQPendingSubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Account No.</span>
											<asp:Label ID="lblINQPendingSubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Name</span>
											<asp:Label ID="lblINQPendingSubmittedDtlName" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Subject</span>
											<asp:Label ID="lblINQPendingSubmittedDtlSubject" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Inquiry Type</span>
											<asp:Label ID="lblINQPendingSubmittedDtlType" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Submitted</span>
											<asp:Label ID="lblINQPendingSubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Remarks</span>
											<asp:Label ID="lblINQPendingSubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Status</span>
											<asp:Label ID="lblINQPendingSubmittedDtlStatus" runat="server" class="form-control">-</asp:Label>
										</div>
										<asp:Label ID="lblINQPendingSubmittedDtlEmail" runat="server" class="form-control" Visible="false">-</asp:Label>
									</div>
								</div>
								<!--end::Tab Details-->
								<!--begin::Tab History-->
								<div class="tab-pane" id="INQ_pending_history_nav" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="table-responsive pb-10">
										<div class="card-body mh-300px scroll-y">
											<div id="divINQPendingSubmittedDtlTimeline" runat="server" class="timeline"></div>
										</div>
									</div>
								</div>
								<!--end::Tab History-->
							</div>
							<!--end::Tab Content-->
						</div>
					<!--end::Request/Inquiry Details-->
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
								<asp:Image ID="imgINQPendingSubmittedDtlAttachment" runat="server" class="pointer" ToolTip="Click to view image" style="width:150px;height:150px;" />
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
								<asp:DropDownList ID="ddlINQPendingSubmittedDtlStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
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
								<asp:TextBox ID="tbxINQPendingSubmittedDtlRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
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
					<asp:LinkButton ID="lbtnINQPendingSubmittedDtlCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
					<asp:LinkButton ID="lbtnINQPendingSubmittedDtlSubmit" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
				</div>
				<!--end::Actions-->
			</div>
		</div>
	</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Modal Submitted Details-->

	<!--begin::Modal History-->
	<asp:UpdatePanel ID="mdlINQHistorySubmitted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblINQHistorySubmittedTitle" runat="server"></asp:Label></h5>
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
										<input id="tbxINQHistorySubmittedSearch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" style="display:block;" placeholder="Search Record" />
									</div>
									<!--begin::Search-->
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive" style="max-height:300px; overflow-y:scroll;">
									<!--begin::Table-->
									<asp:GridView ID="gvINQHistorySubmitted" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeader="true">
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
														<span class="fw-bold fs-7 text-dark"><%# Eval("CreatedDate") %></span>
													</div>
												</div>
												</ItemTemplate>
												<ItemStyle CssClass="min-w-80px"/>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Inquiry">
												<ItemTemplate>
												<div class="d-flex align-items-center flex-row-fluid flex-wrap">
													<div class="flex-grow-1 me-2">
														<span class="fw-bold fs-7 text-dark"><%# Eval("Inquiry") %></span>
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
												<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("ViewINQHistorySubmittedDtl") %>">
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
	<!--begin::Modal History-->

	<!--begin::Modal History Details-->
	<asp:UpdatePanel ID="mdlINQHistorySubmittedDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-lg" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblINQHistorySubmittedDtlTitle" runat="server"></asp:Label></h5>
						<!--begin::Close-->
						<asp:LinkButton ID="lbtnINQHistorySubmittedDtlClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
						<!--begin::Request/Inquiry Details-->
						<div class="card shadow-sm mb-6">
							<div class="card-header">
								<h3 class="card-title">Request/Inquiry Details</h3>
								<!--begin::Tabs-->
								<ul class="nav nav-stretch nav-pills nav-pills-custom d-flex mt-4">
								<!--begin::Nav Details-->
								<li class="nav-item p-0 ms-0">
									<a class="nav-link btn btn-color-gray-400 flex-center px-3 active" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#INQ_history_details_nav">
										<i class="las la-info-circle fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="Details"></i>
										<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
									</a>
								</li>
								<!--end::Nav Details-->
								<!--begin::Nav History-->
								<li class="nav-item p-0 ms-0">
									<a class="nav-link btn btn-color-gray-400 flex-center px-3" data-kt-timeline-widget-4="tab" data-bs-toggle="tab" href="#INQ_history_history_nav">
										<i class="las la-history fs-2" data-bs-toggle="tooltip" data-bs-placement="top" title="History"></i>
										<span class="bullet-custom position-absolute z-index-2 w-100 h-1px top-100 bottom-n100 bg-primary rounded"></span>
									</a>
								</li>
								<!--end::Nav History-->
								</ul>
								<!--end::Tabs-->
								<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
									<div class="ribbon-icon mt-n5 me-n6">
										<i class="bi bi-card-text fs-3 text-white"></i>
									</div>
								</div>
							</div>
							<!--begin::Tab content-->
							<div class="tab-content">
								<!--begin::Tab Details-->
								<div class="tab-pane active" id="INQ_history_details_nav" role="tabpanel" aria-labelledby="day-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="card-body">
										<asp:Label ID="lblINQHistorySubmittedDtlCode" runat="server" class="form-control" visible="false"></asp:Label>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Account No.</span>
											<asp:Label ID="lblINQHistorySubmittedDtlAcctNo" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Name</span>
											<asp:Label ID="lblINQHistorySubmittedDtlName" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Inquiry Type</span>
											<asp:Label ID="lblINQHistorySubmittedDtlInquiryType" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Submitted</span>
											<asp:Label ID="lblINQHistorySubmittedDtlDateSubmitted" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Remarks</span>
											<asp:Label ID="lblINQHistorySubmittedDtlRemarks" runat="server" class="form-control">-</asp:Label>
										</div>
									</div>
								</div>
								<!--end::Tab Details-->
								<!--begin::Tab History-->
								<div class="tab-pane" id="INQ_history_history_nav" role="tabpanel" aria-labelledby="week-tab" data-kt-timeline-widget-4-blockui="true">
									<div class="table-responsive pb-10">
										<div class="card-body mh-300px scroll-y">
											<div id="divINQHistorySubmittedDtlTimeline" runat="server" class="timeline"></div>
										</div>
									</div>
								</div>
								<!--end::Tab History-->
							</div>
							<!--end::Tab Content-->
						</div>
						<!--end::Request/Inquiry Details-->
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
									<asp:Image ID="imgINQHistorySubmittedDtlAttachment" runat="server" class="pointer" ToolTip="Click to view image" style="width:150px;height:150px;" />
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
									<asp:Label ID="lblINQHistorySubmittedDtlStatus" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approved By</span>
									<asp:Label ID="lblINQHistorySubmittedDtlApprovedBy" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approved Date</span>
									<asp:Label ID="lblINQHistorySubmittedDtlApprovedDate" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Approver Remarks</span>
									<asp:Label ID="lblINQHistorySubmittedDtlApproverRemarks" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
						</div>
						<!--end::Status-->
					</div>
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal History Details-->

	<!--begin::Modal Batch TL Creation-->
	<asp:UpdatePanel ID="mdlINQBatchTLCreation" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
	  <div class="modal-dialog modal-lg">
		<div class="modal-content">
		  <div class="modal-header">
			<h5 class="modal-title">Create Transaction Log</h5>
			<!--begin::Close-->
			<asp:LinkButton ID="lbtnINQBatchTLClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
					<h3 class="card-title">Transaction Log Details</h3>
				</div>
				<div class="card-body">
					<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
						<span class="input-group-text min-w-150px required">Status</span>
						<asp:DropDownList ID="ddlINQBatchTLCreationLogType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
							<asp:ListItem Value="">Select Log Type</asp:ListItem>
							<asp:ListItem Value="Transaction Log">Transaction Log</asp:ListItem>
							<asp:ListItem Value="Account Refund">Account Refund</asp:ListItem>
							<asp:ListItem Value="TOL">TOL</asp:ListItem>
							<asp:ListItem Value="House Turn Over">House Turn Over</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="error-message mb-2" style="display:none; color: red;">
						Log Type is required.
					</div>
					<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
						<span class="input-group-text min-w-150px required">Origin of Request</span>
						<asp:DropDownList ID="ddlINQBatchTLCreationOriginOfRequest" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
							<asp:ListItem Value="">Select Origin</asp:ListItem>
							<asp:ListItem Value="Call">Call</asp:ListItem>
							<asp:ListItem Value="Email">Email</asp:ListItem>
							<asp:ListItem Value="Walk-in">Walk-in</asp:ListItem>
							<asp:ListItem Value="Social Media">Social Media</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="error-message mb-2" style="display:none; color: red;">
						Origin of Request is required.
					</div>
					<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
						<span class="input-group-text min-w-150px required">Type</span>
						<asp:DropDownList ID="ddlINQBatchTLCreationType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px" AutoPostBack="true">
							<asp:ListItem Value="">Select Type</asp:ListItem>
							<asp:ListItem Value="Inquiry">Inquiry</asp:ListItem>
							<asp:ListItem Value="Request">Request</asp:ListItem>
							<asp:ListItem Value="Complaint">Complaint</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="error-message mb-2" style="display:none; color: red;">
						Type is required.
					</div>
					<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
						<span class="input-group-text min-w-150px h-35px required">Category</span>
						<div class="input-group input-group-sm">
							<asp:DropDownList ID="ddlINQBatchTLCreationCategory" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
								<asp:ListItem Value="">Select Category</asp:ListItem>
							</asp:DropDownList>
						</div>
						<asp:HiddenField ID="hfCategory" runat="server" />
					</div>
					<div class="error-message mb-2" style="display:none; color: red;">
						Category is required.
					</div>
					<div class="input-group select-wrapper input-group-sm mb-2">
						<span class="input-group-text input-group-text-top min-w-150px required">Approver Remarks</span>
						<asp:TextBox ID="tbxINQBatchTLCreationRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
					</div>
					<div class="error-message" style="display:none; color: red;">
						Remarks is required.
					</div>
				</div>
			</div>
			<!--end::Status-->
		  </div>
		  <div class="modal-footer">
			<asp:LinkButton ID="lbtnINQBatchTLCreationCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
			<asp:LinkButton ID="lbtnINQBatchTLCreationSave" runat="server" class="btn btn-primary">Save</asp:LinkButton>
		  </div>
		</div>
	  </div>
	</ContentTemplate>
	</asp:UpdatePanel>
	<!--begin::Modal Batch TL Creation-->

	<!--begin::Modal Batch Change Status-->
	<asp:UpdatePanel ID="mdlINQBatchChangeStatus" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title">Change Status</h5>
					<!--begin::Close-->
					<asp:LinkButton ID="lbtnINQBatchChangeStatusClose" runat="server" CssClass="btn btn-icon btn-sm btn-active-light-primary ms-2">
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
								<asp:DropDownList ID="ddlINQBatchChangeStatusStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
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
								<asp:TextBox ID="tbxINQBatchChangeStatusRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" Placeholder="Add remarks"></asp:TextBox>
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
					<asp:LinkButton ID="lbtnINQBatchChangeStatusCancel" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
					<asp:LinkButton ID="lbtnINQBatchChangeStatusSave" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
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

		//button view modal
        function ViewINQPendingSubmitted(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnViewINQPendingSubmitted.ClientID %>");
            clickButton.click();
		};

        function ViewINQPendingSubmittedDtl(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnViewINQPendingSubmittedDtl.ClientID %>");
            clickButton.click();
		};

        function ViewINQHistorySubmitted(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnViewINQHistorySubmitted.ClientID %>");
            clickButton.click();
		};

        function ViewINQHistorySubmittedDtl(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnViewINQHistorySubmittedDtl.ClientID %>");
            clickButton.click();
		};
        //button view modal

        //populate category dropdownlist
        function ddlBatchTLType(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;
            $.ajax({
                type: 'GET',
                url: 'HND000005.ashx',
                data: {
                    'FormCode': 'AAD010300',
                    'Type': 'GetCategory',
                    'Category': selectValue
                },
                dataType: 'json',
                success: function (response) {
                    var ddlINQBatchTLCreationCategory = document.getElementById("ContentPlaceHolder1_ddlINQBatchTLCreationCategory");
                    ddlINQBatchTLCreationCategory.innerHTML = "";
                    let Option = "";
                    for (var i = 0; i < response.length; i++) {
                        Option += "<option value='" + response[i].Value + "'>" + response[i].Text + "</option>";
                    }
                    ddlINQBatchTLCategory.innerHTML = Option;
                }
            });
            var ddlINQBatchTLCreationCategory = '<%=ddlINQBatchTLCreationCategory.ClientID%>';
            __doPostBack(ddlINQBatchTLCreationCategory, '');
        }
        function ddlINQBatchTLCategory(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;
            var hfCategory = document.getElementById("ContentPlaceHolder1_hfCategory");
            hfCategory.value = selectValue;
        }
        //populate category dropdownlist

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
			jQuery(function ($) {

                //pending and history search
                var $rowsPending = $('#ContentPlaceHolder1_gvINQPendingList tbody tr');
                var $rowsHistory = $('#ContentPlaceHolder1_gvINQHistoryList tbody tr');

                //search input
                $('#tbxINQSearch').on('keyup', function () {
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
                    $('#tbxINQSearch').val('');
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
                //pending and history search

                //modal search history submitted 
                var $rowsGvINQHistorySubmitted = $('#ContentPlaceHolder1_gvINQHistorySubmitted tbody tr');
                $('#tbxINQHistorySubmittedSearch').keyup(function () {
                    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                    $rowsGvINQHistorySubmitted.show().filter(function () {
                        var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                        return !~text.indexOf(val);
                    }).hide();
                });
                //modal search history submitted 

                //modal search pending submitted 
                var $rowsGvINQPendingSubmitted = $('#ContentPlaceHolder1_gvINQPendingSubmitted tbody tr');
                var $cbxINQPendingSubmittedAll = $('#cbxINQPendingSubmittedAll');

                $('#tbxINQPendingSubmittedSearch').keyup(function () {
                    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

                    $rowsGvINQPendingSubmitted.show().filter(function () {
                        var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                        return !~text.indexOf(val);
                    }).hide();

                    //check if any rows are still visible
                    var anyVisible = $rowsGvINQPendingSubmitted.filter(':visible').length > 0;

                    //enable or disable the checkbox
                    $cbxINQPendingSubmittedAll.prop('disabled', !anyVisible);
                });
                //modal search inquiry submitted 

                //checkbox
				$('.checkBoxAllClass').click(function () {
                    var btnINQPendingSubmittedBatchOptions = document.getElementById("btnINQPendingSubmittedBatchOptions");
                    var tbxINQPendingSubmittedSearch = document.getElementById("tbxINQPendingSubmittedSearch");
                    var spanINQPendingSubmittedSearch = document.getElementById("spanINQPendingSubmittedSearch");

                    if ($(this).is(":checked")) {
						$('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                        btnINQPendingSubmittedBatchOptions.style.display = "";
                        tbxINQPendingSubmittedSearch.style.display = "none";
                        spanINQPendingSubmittedSearch.style.display = "none";
                    } else {
						$(".checkBoxClass").prop('checked', false);
                        btnINQPendingSubmittedBatchOptions.style.display = "none";
                        tbxINQPendingSubmittedSearch.value = '';
                        tbxINQPendingSubmittedSearch.style.display = "block";
                        spanINQPendingSubmittedSearch.style.display = "block";
                    }
                })
				$(".checkBoxClass").change(function () {
                    var btnINQPendingSubmittedBatchOptions = document.getElementById("btnINQPendingSubmittedBatchOptions");
                    var tbxINQPendingSubmittedSearch = document.getElementById("tbxINQPendingSubmittedSearch");
                    var spanINQPendingSubmittedSearch = document.getElementById("spanINQPendingSubmittedSearch");

                    if (!$(this).prop("checked")) {
                        $(".checkBoxAllClass").prop("checked", false);
                    }
					if ($('.checkBoxClass:checked').length > 0) {
                        btnINQPendingSubmittedBatchOptions.style.display = "";
                        tbxINQPendingSubmittedSearch.style.display = "none";
                        spanINQPendingSubmittedSearch.style.display = "none";
					} else {
                        btnINQPendingSubmittedBatchOptions.style.display = "none";
                        tbxINQPendingSubmittedSearch.value = '';
                        tbxINQPendingSubmittedSearch.style.display = "block";
                        spanINQPendingSubmittedSearch.style.display = "block";
                        
                    }
                });
                //checkbox

				//higlight input fields
                var inputGroups = [
                    {
                        inputs: ['#ContentPlaceHolder1_tbxINQPendingSubmittedDtlRemarks'],
                        dropdowns: ['#ContentPlaceHolder1_ddlINQPendingSubmittedDtlStatus'],
                        button: '#ContentPlaceHolder1_lbtnINQPendingSubmittedDtlSubmit'
                    },
                    {
                        inputs: ['#ContentPlaceHolder1_tbxINQBatchTLCreationRemarks'],
                        dropdowns: [
                            '#ContentPlaceHolder1_ddlINQBatchTLCreationLogType',
                            '#ContentPlaceHolder1_ddlINQBatchTLCreationOriginOfRequest',
                            '#ContentPlaceHolder1_ddlINQBatchTLCreationType',
                            '#ContentPlaceHolder1_ddlINQBatchTLCreationCategory'
                        ],
                        button: '#ContentPlaceHolder1_lbtnINQBatchTLCreationSave'
                    },
                    {
                        inputs: ['#ContentPlaceHolder1_tbxINQBatchChangeStatusRemarks'],
                        dropdowns: ['#ContentPlaceHolder1_ddlINQBatchChangeStatusStatus'],
                        button: '#ContentPlaceHolder1_lbtnINQBatchChangeStatusSave'
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
                    { selector: "#ContentPlaceHolder1_ddlINQBatchTLCreationLogType", parent: "#ContentPlaceHolder1_mdlINQBatchTLCreation" },
                    { selector: "#ContentPlaceHolder1_ddlINQBatchTLCreationOriginOfRequest", parent: "#ContentPlaceHolder1_mdlINQBatchTLCreation" },
                    { selector: "#ContentPlaceHolder1_ddlINQBatchTLCreationType", parent: "#ContentPlaceHolder1_mdlINQBatchTLCreation" },
                    { selector: "#ContentPlaceHolder1_ddlINQBatchTLCreationCategory", parent: "#ContentPlaceHolder1_mdlINQBatchTLCreation" },
                    { selector: "#ContentPlaceHolder1_ddlINQPendingSubmittedDtlStatus", parent: "#ContentPlaceHolder1_mdlINQPendingSubmittedDtl" },
                    { selector: "#ContentPlaceHolder1_ddlINQBatchChangeStatusStatus", parent: "#ContentPlaceHolder1_mdlINQBatchChangeStatus" }
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
