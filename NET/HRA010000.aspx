<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="HRA010000.aspx.vb" Inherits="NET.HRA010000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Human Resources Administration</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Work Shift</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="btnAdd" runat="server" Text="Button" OnClick="btnAdd_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnAdd_Ok" runat="server" Text="Button" OnClick="btnAdd_Ok_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnDelete" runat="server" Text="Button" OnClick="btnDelete_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnDelete_Ok" runat="server" Text="Button" OnClick="btnDelete_Ok_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnView" runat="server" Text="Button" OnClick="btnView_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnView_Edit" runat="server" Text="Button" OnClick="btnView_Edit_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnEdit" runat="server" Text="Button" OnClick="btnEdit_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnEdit_Ok" runat="server" Text="Button" OnClick="btnEdit_Ok_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnLock" runat="server" Text="Button" OnClick="btnLock_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnLock_Ok" runat="server" Text="Button" OnClick="btnLock_Ok_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnUnlock" runat="server" Text="Button" OnClick="btnUnlock_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btnUnlock_Ok" runat="server" Text="Button" OnClick="btnUnlock_Ok_Click" ClientIDMode="Static" style="display:none;"/>
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
						<img src="Assets/media/svg/apps/HRA010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<div class="card-title fs-3 fw-bolder">Work Shift</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<!--begin::Card header-->
			<div class="card-header" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex">
					<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="Refresh(this);">
						<span class="indicator-label">
							<i class="las la-redo-alt fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<button class="btn btn-sm btn-icon btn-success align-self-center m-1" title="Add record" onclick="Add(this);">
						<span class="indicator-label">
							<i class="las la-plus fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
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
				<asp:Button ID="btnRefresh" runat="server" Text="Button" OnClick="lbtnRefresh_Click" ClientIDMode="Static" style="display:none;"/>
				<div style="overflow-x:auto; scrollbar-width: thin;">
					<asp:GridView ID="gvTask" runat="server" class="table table-no-border table-row-bordered table-hover align-middle tscroll" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
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
										<a class="d-flex align-items-center w-100 pointer" onclick="<%# Eval("View") %>">
											<asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-400px w-100">
											<ContentTemplate>
												<span class="text-dark fw-bolder fs-6 nowrap-auto"><asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label></span>
												<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %></span>
											</ContentTemplate>
											</asp:UpdatePanel>
											<asp:UpdatePanel ID="upnlStatus" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-150px">
											<ContentTemplate>
												<span class='text-dark fw-bolder fs-6 '><asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label></span>
												<span class="text-muted fw-bold text-muted d-block fs-7">Status</span>
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
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("Delete") %>">Remove record</a>
												</div>
												<!--end::Menu item-->
												<!--begin::Menu item-->
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("Edit") %>">Edit record</a>
												</div>
												<!--end::Menu item-->
												<!--begin::Menu item-->
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("Lock") %>">Lock record</a>
												</div>
												<!--end::Menu item-->
												<!--begin::Menu item-->
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("Unlock") %>">Unlock record</a>
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

		<!--begin::Modal Add Record-->
		<asp:UpdatePanel ID="mdlAdd" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Record</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Description</span>
							<asp:TextBox ID="tbxAdd_Description" runat="server" class="form-control" Placeholder="Add description"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Initial</span>
							<asp:TextBox ID="tbxAdd_Abbr" runat="server" class="form-control" Placeholder="Add initial"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Rest Day</span>
							<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
								<input id="cbxAdd_DayOff" runat="server" class="form-check-input" type="checkbox" value=""/>
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Open Time</span>
							<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
								<input id="cbxAdd_OpenTime" runat="server" class="form-check-input" type="checkbox" value=""/>
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">AM In</span>
							<input id="tbxAdd_FrstStart" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">AM Out</span>
							<input id="tbxAdd_FrstEnd" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">PM In</span>
							<input id="tbxAdd_ScndStart" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">PM Out</span>
							<input id="tbxAdd_ScndEnd" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="Add_Ok(this);">
							Add
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Add Record-->
		
        <!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlDelete" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
						<p>Removed current record?</p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
						<button class="btn btn-primary" onclick="Delete_Ok(this);">
							Yes
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
		<!--begin::Modal View Record-->
		<asp:UpdatePanel ID="mdlView" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">View Detail</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">ID</span>
							<asp:Label ID="lblView_ID" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="separator separator-dashed my-6"></div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Description</span>
							<asp:Label ID="lblView_Description" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Initial</span>
							<asp:Label ID="lblView_Abbr" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Rest Day</span>
							<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
								<input id="cbxView_DayOff" runat="server" class="form-check-input disable-check" type="checkbox" value=""/>
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Open Time</span>
							<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
								<input id="cbxView_OpenTime" runat="server" class="form-check-input disable-check" type="checkbox" value=""/>
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">AM In</span>
							<asp:Label ID="lblView_FrstStart" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">AM Out</span>
							<asp:Label ID="lblView_FrstEnd" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PM In</span>
							<asp:Label ID="lblView_ScndStart" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PM Out</span>
							<asp:Label ID="lblView_ScndEnd" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="separator separator-dashed my-6"></div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Prepared By</span>
							<asp:Label ID="lblView_PreparedBy" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Locked by</span>
							<asp:Label ID="lblView_LockedBy" runat="server" class="form-control">-</asp:Label>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Close</button>
						<button class="btn btn-primary" onclick="View_Edit(this);">
							Edit
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal View Record-->
		
		<!--begin::Modal Edit Record-->
		<asp:UpdatePanel ID="mdlEdit" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Edit Record</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Description</span>
							<asp:TextBox ID="tbxEdit_Description" runat="server" class="form-control" Placeholder="Add description"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Initial</span>
							<asp:TextBox ID="tbxEdit_Abbr" runat="server" class="form-control" Placeholder="Add initial"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Rest Day</span>
							<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
								<input id="cbxEdit_DayOff" runat="server" class="form-check-input" type="checkbox" value=""/>
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Open Time</span>
							<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
								<input id="cbxEdit_OpenTime" runat="server" class="form-check-input" type="checkbox" value=""/>
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">AM In</span>
							<input id="tbxEdit_FrstStart" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">AM Out</span>
							<input id="tbxEdit_FrstEnd" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">PM In</span>
							<input id="tbxEdit_ScndStart" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">PM Out</span>
							<input id="tbxEdit_ScndEnd" runat="server" type="text" data-kt-repeater="timepicker" class="form-control" readonly Placeholder="Pick a time" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="Edit_Ok(this);">
							Save
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Edit Record-->
		
        <!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlLock" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content divLock">
					<div class="modal-header">
						<h5 class="modal-title">Lock Record</h5>
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
						<div class="mb-2">
							<input id="tbxLock_Password" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
						<button id="btnLock_Yes" class="btn btn-primary btnLock_Yes" onclick="Lock_Ok(this);">
							Yes
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
        <!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlUnlock" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content divUnlock">
					<div class="modal-header">
						<h5 class="modal-title">Unlock Record</h5>
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
						<div class="mb-2">
							<input id="tbxUnlock_Password" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
						<button id="btnUnlock_Yes" class="btn btn-primary btnUnlock_Yes" onclick="Unlock_Ok(this);">
							Yes
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfFormCode" runat="server" />
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Post-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">
		//function related to this page only
        function Refresh(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnRefresh.ClientID %>");
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
        function Add(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnAdd.ClientID %>");
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
        function Add_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnAdd_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
		function Delete(ID) {
			// Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnDelete.ClientID %>");
            clickButton.click();
		};
		function Delete_Ok(Btn) {
            $('#ContentPlaceHolder1_mdlDelete').modal('hide');
            // Perform button
            var clickButton = document.getElementById("<%= btnDelete_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
			// Simulate form submission
            setTimeout(function () {
                // Enable button
				Btn.disabled = false;
            }, 3000);
		};
        function View(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnView.ClientID %>");
            clickButton.click();
		};
        function View_Edit(Btn) {
            $('#ContentPlaceHolder1_mdlView').modal('hide');
            // Perform button
            var clickButton = document.getElementById("<%= btnView_Edit.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function Edit(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnEdit.ClientID %>");
            clickButton.click();
		};
        function Edit_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnEdit_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function Lock(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnLock.ClientID %>");
            clickButton.click();
		};
        function Lock_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnLock_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function Unlock(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnUnlock.ClientID %>");
            clickButton.click();
		};
        function Unlock_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnUnlock_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
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

			//diable checkbox
            const nodeList = document.querySelectorAll(".disable-check");
            for (let i = 0; i < nodeList.length; i++) {
                nodeList[i].onclick = (e) => {
                    e.preventDefault();
                }
			}
			//diable checkbox
            $('.divLock').keypress(function (e) {
                console.log(e.keyCode);
                if (e.keyCode == '13') {
                    $(this).find('.btnLock_Yes').click();
                }
            });
			$('.divUnlock').keypress(function (e) {
				console.log(e.keyCode);
                if (e.keyCode == '13') {
                    $(this).find('.btnUnlock_Yes').click();
                }
            });
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

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

                //time
                $('[data-kt-repeater="timepicker"]').flatpickr({
                    enableTime: true,
                    noCalendar: true,
                    dateFormat: "h:i K"
                });
                //time

                //menu
                KTMenu.createInstances();
                //menu
            });
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
