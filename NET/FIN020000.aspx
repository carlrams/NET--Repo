<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FIN020000.aspx.vb" Inherits="NET.FIN020000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Replenishment</li>
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
			<asp:Button ID="btnRefresh_REP" runat="server" Text="Button" OnClick="btnRefresh_REP_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCreate_REP01" runat="server" Text="Button" OnClick="btnCreate_REP01_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCreate_REP02" runat="server" Text="Button" OnClick="btnCreate_REP02_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCreate_REP03" runat="server" Text="Button" OnClick="btnCreate_REP03_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnRefresh_CA" runat="server" Text="Button" OnClick="btnRefresh_CA_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCancel_CA01" runat="server" Text="Button" OnClick="btnCancel_CA01_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCancel_CA02" runat="server" Text="Button" OnClick="btnCancel_CA02_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCancel_CA03" runat="server" Text="Button" OnClick="btnCancel_CA03_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnRefresh_APV" runat="server" Text="Button" OnClick="btnRefresh_APV_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCancel_APV01" runat="server" Text="Button" OnClick="btnCancel_APV01_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCancel_APV02" runat="server" Text="Button" OnClick="btnCancel_APV02_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnCancel_APV03" runat="server" Text="Button" OnClick="btnCancel_APV02_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnRPT_REP" runat="server" Text="Button" OnClick="btnRPT_REP_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnRPT_CA" runat="server" Text="Button" OnClick="btnRPT_CA_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnRPT_APV" runat="server" Text="Button" OnClick="btnRPT_APV_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<!--begin::content-->
		<div class="card card-flush">
			<!--begin::title-->
			<div class="card-header pt-5 pb-5" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/FIN020000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<div class="card-title fs-3 fw-bolder">Replenishment</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<!--begin::Card header-->
			<div class="card-header" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex">
					<div class="form-check form-check-sm form-check-custom form-check-solid me-2 pl-6">
						<input class="form-check-input checkBoxAllClass" type="checkbox" value="1" css="" />
					</div>
					<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="Refresh_REP(this);">
						<span class="indicator-label">
							<i class="las la-redo-alt fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<button id="btnCreate_REP" class="btn btn-sm btn-icon btn-success align-self-center m-1" title="Create Replenishment" onclick="Create_REP01(this);">
						<span class="indicator-label">
							<i class="las la-plus fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<button class="btn btn-sm btn-icon btn-secondary align-self-center m-1" title="More" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start">
						<!--begin::Svg Icon | path: icons/duotune/arrows/arr072.svg-->
						<span class="svg-icon svg-icon-1 m-0">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<path d="M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z" fill="currentColor"/>
								<path opacity="0.3" d="M21 14H3C2.4 14 2 13.6 2 13V11C2 10.4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z" fill="currentColor"/>
							</svg>
						</span>
						<!--end::Svg Icon-->
					</button>
					<!--begin::Menu-->
					<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-200px py-4" data-kt-menu="true">
						<!--begin::Menu item-->
						<div class="menu-item px-3">
							<a class="menu-link px-3" onclick="Cancel_CA01(this)">Cash Advance</a>
						</div>
						<div class="menu-item px-3">
							<a class="menu-link px-3" onclick="Cancel_APV01(this)">APV</a>
						</div>
						<!--end::Menu item-->
					</div>
					<!--end::Menu-->
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
						<input id="tbxFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
					</div>
				</div>
			</div>
			<!--end::Card header-->
			<!--begin::Card body-->
			<asp:UpdatePanel ID="upnlContent" runat="server" UpdateMode="Conditional" class="card-body">
			<ContentTemplate>
				<div style="overflow-x:auto; scrollbar-width: thin;">
					<asp:GridView ID="gvTask" runat="server" class="table table-no-border table-row-bordered table-hover align-middle tscroll" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					<Columns>
						<asp:TemplateField HeaderText="">
							<ItemTemplate>
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
						<asp:TemplateField HeaderText="Open Task">
							<ItemTemplate>
								<div class="overlay overflow-hidden">
									<div class="overlay-wrapper">
										<a href='<%# Eval("Link") %>' class="d-flex align-items-center w-100">
											<div class="d-flex flex-column min-w-30px mw-30px me-3"  >
												<div class="symbol symbol-30px overflow-hidden">
													<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
												</div>
											</div>
											<div class="d-flex flex-column min-w-400px w-100">
												<span class="text-dark fw-bolder fs-6 nowrap-auto"> <%# Eval("Title") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
											</div>
											<div class="d-flex flex-column min-w-150px">
												<span class="text-dark fw-bolder fs-6"><%# Eval("Amount") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7">Amount</span>
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
													<a class="menu-link px-3" onclick="<%# Eval("Create_REP02") %>">Create Replenishment</a>
												</div>
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("RPT_REP") %>">Print Preview</a>
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
				</div>
				<asp:UpdateProgress ID="uprgContent" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="upnlContent">
					<ProgressTemplate>
						<div class="table-loading-message d-flex align-items-center">
							<span class="loader"></span>&nbsp&nbsp<span class="fs-5">Loading...</span>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::Card body-->
		</div>
		<!--begin::content-->
		
		<!--begin::Modal Replenishment-->
		<asp:UpdatePanel ID="mdlREP" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Create Replenishment</h5>
						<div class="d-flex align-items-center flex-wrap">
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
						<div class="row mb-5">
							<div class="col-lg-6 mr-auto ml-auto">
								<asp:GridView ID="gvREP" runat="server" class="table table-no-border table-row-bordered align-middle"  ShowFooter="true" AutoGenerateColumns="False" EmptyDataText="No Data" >
									<Columns>
										<asp:TemplateField HeaderText="Form No.">
											<ItemTemplate>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
											</ItemTemplate>
											<ItemStyle CssClass="min-w-150px mw-150px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Date">
											<ItemTemplate>
												<%# Eval("Date") %>
											</ItemTemplate>
											<ItemStyle CssClass="min-w-150px mw-150px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Requested By">
											<ItemTemplate>
												<%# Eval("RequestedBy") %>
											</ItemTemplate>
											<ItemStyle CssClass="min-w-200px mw-200px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Remarks">
											<ItemTemplate>
												<%# Eval("Remarks") %>
											</ItemTemplate>
											<ItemStyle CssClass="w-100 min-w-200px nowrap-table-cell" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Amount">
											<ItemTemplate>
												<%# Eval("Amount") %>
											</ItemTemplate>
											<ItemStyle CssClass="min-w-150px mw-150px" />
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
						<div class="row mb-5">
							<div class="col-lg-6 mr-auto ml-auto">
								<table class="table table-no-border table-row-bordered align-middle">
									<thead>
										<tr>
											<th class="min-w-550px w-100">
												Currency and Coins
											</th>
											<th class="min-w-150px mw-150px">
												No.
											</th>
											<th class="min-w-150px mw-150px">
												Peso Amount
											</th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td class="fw-bold text-dark min-w-550px w-100">
												BILL
											</td>
											<td class="min-w-150px mw-150px">

											</td>
											<td class="min-w-150px mw-150px">

											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												1000
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill1000" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt1000" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												500
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill500" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt500" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												200
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill200" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt200" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												100
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill100" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt100" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												50
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill50" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt50" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												20
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill20" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt20" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="fw-bold text-dark min-w-550px w-100">
												COINS
											</td>
											<td class="min-w-150px mw-150px">

											</td>
											<td class="min-w-150px mw-150px">

											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												10
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill10" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt10" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												5
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill5" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt5" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												1
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill1" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt1" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												0.25
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill025" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt025" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												0.10
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill010" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt010" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												0.05
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill005" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt005" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-550px w-100">
												0.01
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxBill001" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" value="0"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmt001" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="fw-bold text-dark min-w-550px w-100">
												Total Cash on Hand
											</td>
											<td class="min-w-150px mw-150px">

											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxAmtTotal" runat="server" type="text" class="border-0 p-0 w-75 fw-bold text-dark" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
									</tbody>
								</table>
							</div>
						</div>
						<div class="row mb-5">
							<div class="col-lg-6 mr-auto ml-auto">
								<table class="table table-no-border table-row-bordered align-middle">
									<tbody>
										<tr>
											<td class="fw-bold text-dark min-w-700px w-100">
												Amount of Revolving Fund
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxRF" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)" onblur="numberWithDecimal(this)" value="0.00"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
										</tr>
									</tbody>
								</table>
							</div>
						</div>
						<div class="row mb-5">
							<div class="col-lg-6 mr-auto ml-auto">
								<table class="table table-no-border table-row-bordered align-middle">
									<thead>
										<tr>
											<th class="min-w-700px w-100">
												Breakdown of Fund:
											</th>
											<th class="min-w-150px mw-150px">
												Amount
											</th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td class="min-w-700px w-100">
												Expenses
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxEXP" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-700px w-100">
												Cash on Hand
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxCOH" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
										<tr>
											<td class="min-w-700px w-100">
												Cash Advance
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxCA" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)"  onblur="numberWithDecimal(this)" value="0.00"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
										</tr>
										<tr>
											<td class="min-w-700px w-100">
												On-going Replenishment
											</td>
											<td class="min-w-150px mw-150px">
												<div class="position-relative">
													<input id="tbxREP" runat="server" type="text" class="border-0 p-0 w-75" style="outline:none" onkeyup="FormatNumeric(this)"  onblur="numberWithDecimal(this)" value="0.00"/>
													<i class="position-absolute start-90 top-20 las la-pencil-alt"></i>
												</div>
											</td>
										</tr>
										<tr>
											<td class="fw-bold text-dark min-w-700px w-100">
												Total 
											</td>
											<td class="min-w-150px mw-150px">
												<input id="tbxTOT" runat="server" type="text" class="border-0 p-0 w-75 fw-bold text-dark" style="outline:none" value="0.00" readonly/>
											</td>
										</tr>
									</tbody>
								</table>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="Create_REP03(this);">
							Create
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Replenishment-->
		
		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdlCA" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Cash Advance
						</h5>
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
					<div class="modal-body min-h-80px mh-80px overflow-hidden">
						<!--begin::toolbar-->
						<div class="d-flex align-items-center">
							<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="Refresh_CA(this);">
								<span class="indicator-label">
									<i class="las la-redo-alt fs-2"></i>
								</span>
								<span class="indicator-progress">
									<span class="spinner-border spinner-border-sm align-middle"></span>
								</span>
							</button>
							<!--begin::Search-->
							<div class="position-relative">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxFind_CA" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						<!--begin::list-->
							<asp:GridView ID="gvCA" runat="server" class="table table-no-border table-row-bordered table-hover align-middle w-100" AutoGenerateColumns="False" showheader="false" EmptyDataText="No Data" >
							<Columns>
								<asp:TemplateField HeaderText="">
									<ItemTemplate>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-5px min-w-5px" />
									<ItemStyle CssClass="mw-5px min-w-5px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Open Task">
									<ItemTemplate>
										<div class="overlay overflow-hidden">
											<div class="overlay-wrapper">
												<a href='<%# Eval("Link") %>' class="d-flex align-items-center w-100">
													<div class="d-flex flex-column min-w-30px mw-30px me-3"  >
														<div class="symbol symbol-30px overflow-hidden">
															<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
														</div>
													</div>
													<div class="d-flex flex-column min-w-400px w-100">
														<span class="text-dark fw-bolder fs-6 nowrap-auto"> <%# Eval("Title") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
													</div>
													<div class="d-flex flex-column min-w-150px">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Amount") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Amount</span>
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
															<a class="menu-link px-3" onclick="<%# Eval("Cancel_CA02") %>">Cancel Cash Advance</a>
														</div>
														<div class="menu-item px-3">
															<a class="menu-link px-3" onclick="<%# Eval("RPT_CA") %>">Print Preview</a>
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
						</div>
						<!--end::list-->
						<asp:UpdateProgress ID="uprgCA" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="mdlCA">
							<ProgressTemplate>
								<div class="table-loading-message d-flex align-items-center">
									<span class="loader"></span>&nbsp&nbsp<span class="fs-5">Loading...</span>
								</div>
							</ProgressTemplate>
						</asp:UpdateProgress>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlDBCA" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Message</h5>
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
						<p>Cancel Cash Advance?</p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
						<button class="btn btn-primary" onclick="Cancel_CA03(this);">
							Yes
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdlAPV" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							APV
						</h5>
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
					<div class="modal-body min-h-80px mh-80px overflow-hidden">
						<!--begin::toolbar-->
						<div class="d-flex align-items-center">
							<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="Refresh_CA(this);">
								<span class="indicator-label">
									<i class="las la-redo-alt fs-2"></i>
								</span>
								<span class="indicator-progress">
									<span class="spinner-border spinner-border-sm align-middle"></span>
								</span>
							</button>
							<!--begin::Search-->
							<div class="position-relative">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxFind_APV" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						<!--begin::list-->
							<asp:GridView ID="gvAPV" runat="server" class="table table-no-border table-row-bordered table-hover align-middle w-100" AutoGenerateColumns="False" showheader="false" EmptyDataText="No Data" >
							<Columns>
								<asp:TemplateField HeaderText="">
									<ItemTemplate>
										<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
									</ItemTemplate>
									<HeaderStyle CssClass="mw-5px min-w-5px" />
									<ItemStyle CssClass="mw-5px min-w-5px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Open Task">
									<ItemTemplate>
										<div class="overlay overflow-hidden">
											<div class="overlay-wrapper">
												<div class="d-flex align-items-center w-100">
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("APVNo") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">APV No.</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("APVDate") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Date</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("RF") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Total Revolving Fund</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("EXP") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Expense</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("COH") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Cash on Hand</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("CA") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Cash Advance</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("REP") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-8">On-Going Replenishment</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Total") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Total</span>
													</div>
													<div class="d-flex flex-column min-w-150px w-100">
														<span class="text-dark fw-bolder fs-6"><%# Eval("Status") %></span>
														<span class="text-muted fw-bold text-muted d-block fs-7">Status</span>
													</div>
												</div>
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
															<a class="menu-link px-3" onclick="<%# Eval("Cancel_APV02") %>">Cancel APV</a>
														</div>
														<div class="menu-item px-3">
															<a class="menu-link px-3" onclick="<%# Eval("RPT_APV") %>">Print Preview</a>
														</div>
														<!--end::Menu item-->
													</div>
													<!--end::Menu-->
												</div>
											</div>
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="w-100" />
									<ItemStyle CssClass="w-100" />
								</asp:TemplateField>
							</Columns>
							</asp:GridView>
						</div>
						<!--end::list-->
						<asp:UpdateProgress ID="uprgAPV" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="mdlAPV">
							<ProgressTemplate>
								<div class="table-loading-message d-flex align-items-center">
									<span class="loader"></span>&nbsp&nbsp<span class="fs-5">Loading...</span>
								</div>
							</ProgressTemplate>
						</asp:UpdateProgress>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlDBAPV" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Message</h5>
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
						<p>Cancel APV?</p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
						<button class="btn btn-primary" onclick="Cancel_APV03(this);">
							Yes
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Post-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">
        //function related to this page only
        function Refresh_REP(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnRefresh_REP.ClientID %>");
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
        function Create_REP01(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnCreate_REP01.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        function Create_REP02(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= btnCreate_REP02.ClientID %>");
            clickButton.click();
		};
        function Create_REP03(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnCreate_REP03.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function RPT_REP(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= btnRPT_REP.ClientID %>");
            clickButton.click();
        };
        function Refresh_CA(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnRefresh_CA.ClientID %>");
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
        function Cancel_CA01(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnCancel_CA01.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function Cancel_CA02(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
			hfID.value = ID;
            $('#ContentPlaceHolder1_mdlDBCA').modal('show');
		};
		function Cancel_CA03(Btn) {
            $('#ContentPlaceHolder1_mdlDBCA').modal('hide');
            // Perform button
            var clickButton = document.getElementById("<%= btnCancel_CA03.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function RPT_CA(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= btnRPT_CA.ClientID %>");
            clickButton.click();
        };
        function Refresh_APV(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnRefresh_APV.ClientID %>");
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
        function Cancel_APV01(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnCancel_APV01.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function Cancel_APV02(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
			hfID.value = ID;
            $('#ContentPlaceHolder1_mdlDBAPV').modal('show');
		};
		function Cancel_APV03(Btn) {
            $('#ContentPlaceHolder1_mdlDBAPV').modal('hide');
            // Perform button
            var clickButton = document.getElementById("<%= btnCancel_APV03.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function RPT_APV(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= btnRPT_APV.ClientID %>");
            clickButton.click();
        };
        //function related to this page only

        //postback
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
		function loadscript() {
			//search
            var $rows = $('#ContentPlaceHolder1_gvTask tbody tr');
            $('#tbxFind').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $rows.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
			});
			//search

            //search
            var $rows_CA = $('#ContentPlaceHolder1_gvCA tbody tr');
			$('#tbxFind_CA').keyup(function () {
				var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $rows_CA.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
			//search

            //search
            var $rows_APV = $('#ContentPlaceHolder1_gvAPV tbody tr');
            $('#tbxFind_APV').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $rows_APV.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
			//search

            //checkbox
            $('.checkBoxAllClass').click(function () {
                if ($(this).is(":checked")) {
                    //get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                } else {
                    //remove checked
                    $(".checkBoxClass").prop('checked', false);
                }
            })
            $(".checkBoxClass").change(function () {
                if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
                }
            });
			//checkbox
        }
        //postback

        //tbody scroll
        var $table = $('table.tscroll'), $bodyCells = $table.find('tbody tr:first').children(), colWidth;
        $(window).resize(function () {
            colWidth = $bodyCells.map(function () {
                return $(this).width();
            }).get();
            $table.find('thead tr').children().each(function (i, v) {
                $(v).width(colWidth[i]);
            });
        });
        //tbody scroll

        //numeric formating
        function FormatNumeric(ID) {
            var start = ID.selectionStart; // get the selection start
            var end = ID.selectionEnd;    // and end, as per the linked post
            var s1 = ID.value.split(",").length - 1; //count the commas before edit
            ID.value = numberWithCommas(ID.value.replace(/,|[^\d.]/g, ''));
            var s2 = ID.value.split(",").length - s1 - 1; //count the commas after edit so as to know where to place the cursor, as the position changes, if there are new commas or some commas have been removed
			ID.setSelectionRange(start + s2, end + s2); // set the selection start and end, as per the linked post

            var tbxBill1000 = document.getElementById("ContentPlaceHolder1_tbxBill1000");
            var tbxAmt1000 = document.getElementById("ContentPlaceHolder1_tbxAmt1000");
            var tbxBill500 = document.getElementById("ContentPlaceHolder1_tbxBill500");
			var tbxAmt500 = document.getElementById("ContentPlaceHolder1_tbxAmt500");
            var tbxBill200 = document.getElementById("ContentPlaceHolder1_tbxBill200");
			var tbxAmt200 = document.getElementById("ContentPlaceHolder1_tbxAmt200");
            var tbxBill100 = document.getElementById("ContentPlaceHolder1_tbxBill100");
			var tbxAmt100 = document.getElementById("ContentPlaceHolder1_tbxAmt100");
            var tbxBill50 = document.getElementById("ContentPlaceHolder1_tbxBill50");
			var tbxAmt50 = document.getElementById("ContentPlaceHolder1_tbxAmt50");
            var tbxBill20 = document.getElementById("ContentPlaceHolder1_tbxBill20");
			var tbxAmt20 = document.getElementById("ContentPlaceHolder1_tbxAmt20");
            var tbxBill10 = document.getElementById("ContentPlaceHolder1_tbxBill10");
			var tbxAmt10 = document.getElementById("ContentPlaceHolder1_tbxAmt10");
            var tbxBill5 = document.getElementById("ContentPlaceHolder1_tbxBill5");
			var tbxAmt5 = document.getElementById("ContentPlaceHolder1_tbxAmt5");
            var tbxBill1 = document.getElementById("ContentPlaceHolder1_tbxBill1");
			var tbxAmt1 = document.getElementById("ContentPlaceHolder1_tbxAmt1");
            var tbxBill025 = document.getElementById("ContentPlaceHolder1_tbxBill025");
            var tbxAmt025 = document.getElementById("ContentPlaceHolder1_tbxAmt025");
            var tbxBill010 = document.getElementById("ContentPlaceHolder1_tbxBill010");
            var tbxAmt010 = document.getElementById("ContentPlaceHolder1_tbxAmt010");
            var tbxBill005 = document.getElementById("ContentPlaceHolder1_tbxBill005");
            var tbxAmt005 = document.getElementById("ContentPlaceHolder1_tbxAmt005");
            var tbxBill001 = document.getElementById("ContentPlaceHolder1_tbxBill001");
			var tbxAmt001 = document.getElementById("ContentPlaceHolder1_tbxAmt001");
			var tbxAmtTotal = document.getElementById("ContentPlaceHolder1_tbxAmtTotal");
            var tbxRF = document.getElementById("ContentPlaceHolder1_tbxRF");
            var tbxEXP = document.getElementById("ContentPlaceHolder1_tbxEXP");
            var tbxCOH = document.getElementById("ContentPlaceHolder1_tbxCOH");
            var tbxCA = document.getElementById("ContentPlaceHolder1_tbxCA");
            var tbxREP = document.getElementById("ContentPlaceHolder1_tbxREP");
            var tbxTOT = document.getElementById("ContentPlaceHolder1_tbxTOT");

            tbxAmt1000.value = 1000 * parseFloat(tbxBill1000.value.replace(',',''));
            tbxAmt500.value = 500 * parseFloat(tbxBill500.value.replace(',', ''));
            tbxAmt200.value = 200 * parseFloat(tbxBill200.value.replace(',', ''));
            tbxAmt100.value = 100 * parseFloat(tbxBill100.value.replace(',', ''));
            tbxAmt50.value = 50 * parseFloat(tbxBill50.value.replace(',', ''));
            tbxAmt20.value = 20 * parseFloat(tbxBill20.value.replace(',', ''));
            tbxAmt10.value = 10 * parseFloat(tbxBill10.value.replace(',', ''));
            tbxAmt5.value = 5 * parseFloat(tbxBill5.value.replace(',', ''));
            tbxAmt1.value = 1 * parseFloat(tbxBill1.value.replace(',', ''));
            tbxAmt025.value = 0.25 * parseFloat(tbxBill025.value.replace(',', ''));
            tbxAmt010.value = 0.10 * parseFloat(tbxBill010.value.replace(',', ''));
            tbxAmt005.value = 0.05 * parseFloat(tbxBill005.value.replace(',', ''));
            tbxAmt001.value = 0.01 * parseFloat(tbxBill001.value.replace(',', ''));
			tbxAmtTotal.value = parseFloat(tbxAmt1000.value) + parseFloat(tbxAmt500.value) + parseFloat(tbxAmt200.value) + parseFloat(tbxAmt100.value) + parseFloat(tbxAmt50.value) + parseFloat(tbxAmt20.value) + parseFloat(tbxAmt10.value) + parseFloat(tbxAmt5.value) + parseFloat(tbxAmt1.value) + parseFloat(tbxAmt025.value) + parseFloat(tbxAmt010.value) + parseFloat(tbxAmt005.value) + parseFloat(tbxAmt001.value)
            tbxCOH.value = parseFloat(tbxAmt1000.value) + parseFloat(tbxAmt500.value) + parseFloat(tbxAmt200.value) + parseFloat(tbxAmt100.value) + parseFloat(tbxAmt50.value) + parseFloat(tbxAmt20.value) + parseFloat(tbxAmt10.value) + parseFloat(tbxAmt5.value) + parseFloat(tbxAmt1.value) + parseFloat(tbxAmt025.value) + parseFloat(tbxAmt010.value) + parseFloat(tbxAmt005.value) + parseFloat(tbxAmt001.value)
            tbxTOT.value = parseFloat(tbxEXP.value.replaceAll(",", "")) + parseFloat(tbxCOH.value.replaceAll(",", "")) + parseFloat(tbxCA.value.replaceAll(",", "")) + parseFloat(tbxREP.value.replaceAll(",", ""));
            numberWithDecimal(tbxAmt1000);
			numberWithDecimal(tbxAmt500);
			numberWithDecimal(tbxAmt200);
			numberWithDecimal(tbxAmt100);
			numberWithDecimal(tbxAmt50);
			numberWithDecimal(tbxAmt20);
            numberWithDecimal(tbxAmt10);
            numberWithDecimal(tbxAmt5);
            numberWithDecimal(tbxAmt1);
            numberWithDecimal(tbxAmt025);
            numberWithDecimal(tbxAmt010);
            numberWithDecimal(tbxAmt005);
			numberWithDecimal(tbxAmt001);
			numberWithDecimal(tbxAmtTotal);
			numberWithDecimal(tbxEXP);
			numberWithDecimal(tbxCOH);
            numberWithDecimal(tbxTOT);
        }
        function numberWithCommas(str) {
            var a = str.split('.');
            var p = /\B(?=(\d{3})+(?!\d))/g;
            if (a.length > 1)
                return a[0].toString().replace(p, ",") + "." + a[1];
            else
                return str.toString().replace(p, ",");
        }
		function numberWithDecimal(ID) {
            ID.value = ID.value.replace(/,|[^\d.]/g, '');
            var Val = parseFloat(ID.value);
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
            if (Num == "NaN") {
                Num = "0.00";
            }
			ID.value = Num;
        }
        //numeric formating

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //form variable
                var hfUF_IDSrs = document.getElementById("ContentPlaceHolder1_hfUF_IDSrs");
                //form variable
                //scroll position                document.querySelector('#ContentPlaceHolder1_gvTask > tbody').setAttribute("onscroll", "scrollPos()");                var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");                document.querySelector('#ContentPlaceHolder1_gvTask > tbody').scrollTop = hfScrollPosition.value;                //scroll position
                //menu
                KTMenu.createInstances();
                //menu
            });
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
