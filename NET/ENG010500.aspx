<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ENG010500.aspx.vb" Inherits="NET.ENG010500" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Construction</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">House (New)</li>
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
			<asp:Button ID="lbtnRFH" runat="server" Text="Button" OnClick="lbtnRFH_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnFLT" runat="server" Text="Button" OnClick="lbtnFLT_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnView" runat="server" Text="Button" OnClick="lbtnView_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnCSS" runat="server" Text="Button" OnClick="lbtnCSS_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnCSM" runat="server" Text="Button" OnClick="lbtnCSM_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnCS" runat="server" Text="Button" OnClick="lbtnCS_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnUPS" runat="server" Text="Button" OnClick="lbtnUPS_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnUPM" runat="server" Text="Button" OnClick="lbtnUPM_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnUP" runat="server" Text="Button" OnClick="lbtnUP_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnANS" runat="server" Text="Button" OnClick="lbtnANS_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnAN" runat="server" Text="Button" OnClick="lbtnAN_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtnUFS" runat="server" Text="Button" OnClick="lbtnUFS_Click" ClientIDMode="Static" style="display:none;"/>
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
						<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<div class="card-title fs-3 fw-bolder">Construction : House (New)</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<!--begin::Card header-->
			<div class="card-header" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex">
					<div class="form-check form-check-sm form-check-custom form-check-solid me-2 pl-4">
						<input class="form-check-input checkBoxAllClass" type="checkbox" value="1" css="" />
					</div>
					<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Filter record" onclick="lbtnFLTShow(this);">
						<span class="indicator-label">
							<i class="las la-filter fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="lbtnRFHRefresh(this);">
						<span class="indicator-label">
							<i class="las la-redo-alt fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<button class="btn btn-sm btn-icon btn-success align-self-center m-1" title="Change Status" onclick="lbtnCSSelected(this);">
						<span class="indicator-label">
							<i class="las la-flag fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<button class="btn btn-sm btn-icon btn-success align-self-center m-1" title="Update Progress" onclick="lbtnUPSelected(this);">
						<span class="indicator-label">
							<i class="las la-percent fs-2"></i>
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
				<div class="d-flex align-items-center position-relative m-1">
					<ul class="nav nav-tabs nav-line-tabs nav-stretch border-0">
						<li class="nav-item ">
							<a class="nav-link active position-relative" onclick="lbtnVWOnGoing()" data-bs-toggle="tab" href="#" title="On-Going">
								<i class="las la-edit fs-1"></i>
								<asp:Label ID="lblCntOnGoing" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-square badge-primary" Text="0"></asp:Label>
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link position-relative" onclick="lbtnVWOnHold()" data-bs-toggle="tab" href="#" title="On-Hold">
								<i class="las la-exclamation-circle fs-1"></i>
								<asp:Label ID="lblCntOnHold" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-square badge-primary" Text="0"></asp:Label>
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link position-relative" onclick="lbtnVWComplete()" data-bs-toggle="tab" href="#" title="Complete">
								<i class="lar la-check-square fs-1"></i>
								<asp:Label ID="lblCntCompleted" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-square badge-primary" Text="0"></asp:Label>
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link position-relative" onclick="lbtnVWClarify()" data-bs-toggle="tab" href="#" title="Clarification">
								<i class="las la-question-circle fs-1"></i>
								<asp:Label ID="lblCntClarify" runat="server" CssClass="position-absolute top-0 start-100 translate-middle badge badge-square badge-primary" Text="0"></asp:Label>
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link position-relative" onclick="lbtnVWClose()" data-bs-toggle="tab" href="#" title="Archive/Closed">
								<i class="las la-archive fs-1"></i>
							</a>
						</li>
					</ul>
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
							<HeaderTemplate>
								<div class="form-check form-check-sm form-check-custom form-check-solid">
									<input class="form-check-input checkBoxAllClass" type="checkbox" value="1" css="" />
								</div>
							</HeaderTemplate>
							<ItemTemplate>
								<asp:UpdatePanel ID="upnlCheckbox" runat="server" UpdateMode="Conditional" >
								<ContentTemplate>
									<div id="divCheckbox" runat="server" class="form-check form-check-sm form-check-custom form-check-solid pl-4">
										<input class='<%# Eval("cbxClass") %>' id="RowCheckbox" runat="server" type="checkbox" value="1" disabled='<%# Eval("cbxDisable") %>' />
									</div>
								</ContentTemplate>
								</asp:UpdatePanel>
							</ItemTemplate>
							<HeaderStyle CssClass="mw-40px min-w-40px" />
							<ItemStyle CssClass="mw-40px min-w-40px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="For Billing">
							<ItemTemplate>
								<div class="overlay overflow-hidden">
									<div class="overlay-wrapper">
										<div class="d-flex align-items-center w-100">
											<a href='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer"  >
												<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Title") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
											</a>
											<asp:UpdatePanel ID="upnlStatus" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-150px">
											<ContentTemplate>
												<asp:Label ID="lblStatus" runat="server" CssClass="text-dark fw-bolder fs-6" Text='<%# Eval("Status") %>'></asp:Label>
												<span class="text-muted fw-bold text-muted d-block fs-7">Status</span>
											</ContentTemplate>
											</asp:UpdatePanel>
											<asp:UpdatePanel ID="upnlAssignTo" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-150px">
											<ContentTemplate>
												<asp:Label ID="lblAssignTo" runat="server" CssClass="text-dark fw-bolder fs-6 nowrap-150px" Text='<%# Eval("AssignTo") %>'></asp:Label>
												<span class="text-muted fw-bold text-muted d-block fs-7">Assign To</span>
											</ContentTemplate>
											</asp:UpdatePanel>
											<asp:UpdatePanel ID="upnlProgress" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-150px">
											<ContentTemplate>
												<%# Eval("Progress") %>
											</ContentTemplate>
											</asp:UpdatePanel>
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
													<a class="menu-link px-3" onclick="<%# Eval("lbtnCSS") %>">Change Status</a>
												</div>
												<!--end::Menu item-->
												<!--begin::Menu item-->
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("lbtnUPS") %>">Update Progress</a>
												</div>
												<!--end::Menu item-->
												<!--begin::Menu item-->
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("lbtnUFS") %>">Upload File</a>
												</div>
												<!--end::Menu item-->
												<!--begin::Menu item-->
												<div class="menu-item px-3">
													<a class="menu-link px-3" onclick="<%# Eval("lbtnANS") %>">Add Note</a>
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

		<!--begin::Modal Filter-->
		<asp:UpdatePanel ID="mdlFLT" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Filter</h5>
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
							<asp:DropDownList ID="ddlFLTRAssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlFLT" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Assign To</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="row gx-2 mb-2">
							<div class="col-3"><asp:TextBox ID="tbxFLTRSubdivision" runat="server" class="form-control form-control-sm" placeholder="Subdivision" ></asp:TextBox></div>
							<div class="col-3"><asp:TextBox ID="tbxFLTRPhase" runat="server" class="form-control form-control-sm" placeholder="Phase" ></asp:TextBox></div>
							<div class="col-3"><asp:TextBox ID="tbxFLTRBlock" runat="server" class="form-control form-control-sm" placeholder="Block" ></asp:TextBox></div>
							<div class="col-3"><asp:TextBox ID="tbxFLTRLot" runat="server" class="form-control form-control-sm" placeholder="Lot" ></asp:TextBox></div>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddlFLTRBatch" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlFLT" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Batch</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddlFLTRContractor" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlFLT" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Contractor</asp:ListItem>
							</asp:DropDownList>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="lbtnFLTFilter(this);">
							Filter
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Filter-->
		
		<!--begin::Modal Change Status-->
		<asp:UpdatePanel ID="mdlCS" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-2" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Change Status</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
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
						<div class="table-responsive">
							<asp:GridView ID="gvCS" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateField HeaderText="Project">
									<ItemTemplate>
										<div class="d-flex align-items-center w-100">
											<div class="d-flex flex-column min-w-450px mw-450px"  >
												<span class="text-dark fw-bolder fs-6 nowrap-auto"> <%# Eval("Title") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
											</div>
										</div>
										<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="w-100 min-w-400px" />
									<ItemStyle CssClass="w-100 min-w-400px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Status">
									<ItemTemplate>
										<div class="input-group input-group-sm flex-nowrap">
											<asp:DropDownList ID="ddlCSStatus" runat="server" prm_csm_status='<%# Eval("ID") %>' data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlCS" class="form-select form-select-sm min-h-35px">
												<asp:ListItem Value="">Select status</asp:ListItem>
												<asp:ListItem Value="Not Started">Not Started</asp:ListItem>
												<asp:ListItem Value="Assign">Assign</asp:ListItem>
												<asp:ListItem Value="On-Going">On-Going</asp:ListItem>
												<asp:ListItem Value="On-Hold">On-Hold</asp:ListItem>
												<asp:ListItem Value="Complete">Complete</asp:ListItem>
												<asp:ListItem Value="Clarify">Clarify</asp:ListItem>
												<asp:ListItem Value="Close">Close</asp:ListItem>
											</asp:DropDownList>
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-200px min-w-200px" />
									<ItemStyle CssClass="mw-200px min-w-200px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Assign To">
									<ItemTemplate>
										<div class="input-group input-group-sm flex-nowrap">
											<asp:DropDownList ID="ddlCSAssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlCS" class="form-select form-select-sm min-h-35px">
												<asp:ListItem Value="">Select a user</asp:ListItem>
											</asp:DropDownList>
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-200px min-w-200px" />
									<ItemStyle CssClass="mw-200px min-w-200px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Action">
									<ItemTemplate>
										<button id="lbtnCSUpdate" runat="server" prm_cs_updbutton='<%# Eval("ID") %>' class="btn btn btn-sm btn-success btn-light-success w-100 cs-update-button" onclick="lbtnCSUpdate(this);"><span class='indicator-label'>Update</span><span class='indicator-progress'><span class='spinner-border spinner-border-sm align-middle'></span></span></button>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-150px min-w-150px" />
									<ItemStyle CssClass="mw-150px min-w-150px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Update">
									<ItemTemplate>
										<asp:UpdatePanel ID="upnlCSUpdate" UpdateMode="Conditional" runat="server">
										<ContentTemplate>
											<span id="spnCSUpdate" runat="server" prm_cs_updlabel='<%# Eval("ID") %>' class="d-flex align-middle"></span>
										</ContentTemplate>
										</asp:UpdatePanel>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-150px min-w-150px" />
									<ItemStyle CssClass="mw-150px min-w-150px" />
								</asp:TemplateField>
							</Columns>
							</asp:GridView>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" runat="server" onclick="lbtnCSA(this);">Update All</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Change Status-->
		
		<!--begin::Modal Progress-->
		<asp:UpdatePanel ID="mdlUP" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-2" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Update Progress</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
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
						<div class="table-responsive">
							<asp:GridView ID="gvUP" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateField HeaderText="Project">
									<ItemTemplate>
										<div class="d-flex align-items-center w-100">
											<div class="d-flex flex-column min-w-450px mw-450px"  >
												<span class="text-dark fw-bolder fs-6 nowrap-auto"> <%# Eval("Title") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
											</div>
										</div>
										<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="w-100 min-w-400px" />
									<ItemStyle CssClass="w-100 min-w-400px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Rate">
									<ItemTemplate>
										<div class="input-group input-group-sm">
											<input id="tbxPOCRate" runat="server" prm_up_rate='<%# Eval("ID") %>' class='form-control' onkeyup="FormatNumeric(this)"  onblur="numberWithDecimal(this)" type="text" value="0.00" />
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-150px min-w-150px" />
									<ItemStyle CssClass="mw-150px min-w-150px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Date">
									<ItemTemplate>
										<div class="input-group input-group-sm">
											<input id="tbxPOCDate" runat="server" prm_up_date='<%# Eval("ID") %>' type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-150px min-w-150px" />
									<ItemStyle CssClass="mw-150px min-w-150px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Action">
									<ItemTemplate>
										<button id="lbtnUPUpdate" runat="server" prm_up_updbutton='<%# Eval("ID") %>' class="btn btn btn-sm btn-success btn-light-success w-100 up-update-button" onclick="lbtnUPUpdate(this);"><span class='indicator-label'>Update</span><span class='indicator-progress'><span class='spinner-border spinner-border-sm align-middle'></span></span></button>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-150px min-w-150px" />
									<ItemStyle CssClass="mw-150px min-w-150px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Update">
									<ItemTemplate>
										<asp:UpdatePanel ID="upnlUpdate" UpdateMode="Conditional" runat="server">
										<ContentTemplate>
											<span id="spnUPUpdate" runat="server" prm_up_updlabel='<%# Eval("ID") %>' class="d-flex align-middle"></span>
										</ContentTemplate>
										</asp:UpdatePanel>
									</ItemTemplate>
									<HeaderStyle CssClass="mw-150px min-w-150px" />
									<ItemStyle CssClass="mw-150px min-w-150px" />
								</asp:TemplateField>
							</Columns>
							</asp:GridView>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" runat="server" onclick="lbtnUPA(this);">Update All</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Progress-->
				
		<!--begin::Modal Upload File-->
		<asp:UpdatePanel ID="mdlUF" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Upload File</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
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
						<div class="d-flex align-items-center mb-5">
							<div class="d-flex flex-column">
								<span class="text-dark fw-bolder fs-6"><asp:Label ID="lblUFTitle" runat="server"></asp:Label></span>
								<span class="text-muted fw-bold text-muted d-block fs-7"><asp:Label ID="lblUFID" runat="server"></asp:Label> <asp:Label ID="lblUFName" runat="server"></asp:Label> <asp:Label ID="lblUFDate" runat="server"></asp:Label></span>
							</div>
						</div>
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
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button id="lbtnUFUpload" type="button" class="btn btn-primary">Upload</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Upload File-->
		
		<!--begin::Modal Add Note-->
		<asp:UpdatePanel ID="mdlAN" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Note</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
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
						<div class="d-flex align-items-center mb-5">
							<div class="d-flex flex-column">
								<span class="text-dark fw-bolder fs-6"><asp:Label ID="lblANTitle" runat="server"></asp:Label></span>
								<span class="text-muted fw-bold text-muted d-block fs-7"><asp:Label ID="lblANID" runat="server"></asp:Label> <asp:Label ID="lblANName" runat="server"></asp:Label> <asp:Label ID="lblANDate" runat="server"></asp:Label></span>
							</div>
						</div>
						<div class="input-group input-group-sm">
							<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
							<asp:TextBox ID="tbxANNote" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="lbtnANAad(this);">Add Note</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Add Note-->

		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hfView" runat="server" />
		<asp:HiddenField ID="hfMention" runat="server" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Post-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">
        //function related to this page only
        function lbtnVWOnGoing() {
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = 'On-Going';
            var clickButton = document.getElementById("<%= lbtnView.ClientID %>");
            clickButton.click();
		};
        function lbtnVWOnHold() {
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = 'On-Hold';
            var clickButton = document.getElementById("<%= lbtnView.ClientID %>");
            clickButton.click();
		};
        function lbtnVWComplete() {
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = 'Complete';
            var clickButton = document.getElementById("<%= lbtnView.ClientID %>");
            clickButton.click();
		};
        function lbtnVWClarify() {
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = 'Clarify';
            var clickButton = document.getElementById("<%= lbtnView.ClientID %>");
            clickButton.click();
		};
        function lbtnVWClose() {
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = 'Close';
            var clickButton = document.getElementById("<%= lbtnView.ClientID %>");
            clickButton.click();
        };
		function lbtnFLTShow(Btn) {
            $('#ContentPlaceHolder1_mdlFLT').modal('show');
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
		function lbtnFLTFilter(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnFLT.ClientID %>");
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
        function lbtnRFHRefresh(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnRFH.ClientID %>");
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
        function lbtnCSS(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnCSS.ClientID %>");
            clickButton.click();
        }
        function lbtnCSSelected(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnCSM.ClientID %>");
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
        function lbtnCSUpdate(Btn) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = Btn.getAttribute("prm_cs_updbutton");
            // Perform button
            var clickButton = document.getElementById("<%= lbtnCS.ClientID %>");
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
        function lbtnCSA(UpdateButton) {
            // Disable button to avoid multiple click
            UpdateButton.disabled = true;
            // select all create button
            const Btn = document.querySelectorAll('.cs-update-button');
            // Disable button to avoid multiple click
            Btn.forEach(button => button.addEventListener("click", CreateBilling(button)));
            function CreateBilling(button) {
                button.disabled = true;
            };
            // simulate click
            ProcessChangeStatus(Btn);
            // process billing
            async function ProcessChangeStatus(Btn) {
                for (const button of Btn) {
                    await ChangeStatus(button);
				}
                // Perform refresh
                var lbtnRFH = document.getElementById("<%= lbtnRFH.ClientID %>");
                lbtnRefresh.click();
            }
            // create billing
            async function ChangeStatus(button) {
                // Get Parameter
                var CSID = button.getAttribute("prm_cs_updbutton");
                var ddlCSStatus = document.querySelector('[prm_csm_status=' + CSID + ']');
                var ddlCSAssignTo = document.querySelector('[prm_cs_assignto=' + CSID + ']');
                var spnCSUpdate = document.querySelector('[prm_cs_updlabel=' + CSID + ']');
                // Show loading indication
                button.setAttribute('data-kt-indicator', 'on');
				// process
                return new Promise(resolve => {
                    // Simulate form submission
                    setTimeout(function () {
                        // Hide loading indication
                        button.removeAttribute('data-kt-indicator');
                        // Do Billing
                        $.ajax({
                            type: "POST",
                            url: "HND000003.ashx",
                            data: {
                                'FormCode': 'ENG010500',
                                'Type': 'Change Status',
								'CSID': CSID,
                                'CSStatus': ddlCSStatus.options[ddlCSStatus.selectedIndex].value,
								'CSAssignTo': ddlCSAssignTo.options[ddlCSAssignTo.selectedIndex].value
                            },
                            success: function (response) {
                                spnCSUpdate.innerHTML = response;
                            },
                        });
                        resolve();
                    }, 3000);
                });
            }
		}
        function lbtnUPS(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnUPS.ClientID %>");
            clickButton.click();
        }
        function lbtnUPSelected(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnUPM.ClientID %>");
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
        function lbtnUPUpdate(Btn) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = Btn.getAttribute("prm_up_updbutton");
            // Perform button
            var clickButton = document.getElementById("<%= lbtnUP.ClientID %>");
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
        function lbtnUPA(UpdateButton) {
            // Disable button to avoid multiple click
            UpdateButton.disabled = true;
            // select all create button
            const Btn = document.querySelectorAll('.up-update-button');
            // Disable button to avoid multiple click
            Btn.forEach(button => button.addEventListener("click", CreateBilling(button)));
            function CreateBilling(button) {
                button.disabled = true;
            };
            // simulate click
            ProcessUpdateProgress(Btn);
            // process billing
            async function ProcessUpdateProgress(Btn) {
                for (const button of Btn) {
                    await UpdateProgress(button);
                }
                // Perform refresh
                var lbtnRFH = document.getElementById("<%= lbtnRFH.ClientID %>");
                lbtnRefresh.click();
            }
            // create billing
            async function UpdateProgress(button) {
                // Get Parameter
                var UPID = button.getAttribute("prm_up_updbutton");
                var tbxPOCRate = document.querySelector('[prm_up_rate=' + UPID + ']');
                var tbxPOCDate = document.querySelector('[prm_up_date=' + UPID + ']');
                var spnUPUpdate = document.querySelector('[prm_up_updlabel=' + UPID + ']');
                // Show loading indication
                button.setAttribute('data-kt-indicator', 'on');
                // process
                return new Promise(resolve => {
                    // Simulate form submission
                    setTimeout(function () {
                        // Hide loading indication
                        button.removeAttribute('data-kt-indicator');
                        // Do Billing
                        $.ajax({
                            type: "POST",
                            url: "HND000003.ashx",
                            data: {
                                'FormCode': 'ENG010500',
                                'Type': 'Update Progress',
                                'UPID': UPID,
                                'UPRate': tbxPOCRate.value,
                                'UPDate': tbxPOCDate.value
                            },
                            success: function (response) {
                                spnUPUpdate.innerHTML = response;
                            },
                        });
                        resolve();
                    }, 3000);
                });
            }
		}
        function lbtnANS(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnANS.ClientID %>");
            clickButton.click();
		}
        function lbtnANAad(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtnAN.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        }
        function lbtnUFS(ID) {
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var clickButton = document.getElementById("<%= lbtnUFS.ClientID %>");
            clickButton.click();
        }
        //function related to this page only

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $rows = $('#ContentPlaceHolder1_gvTask tbody tr');
            $('#tbxFind').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $rows.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
        }
        //table search

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

        //checkbox
        $('.checkBoxAllClass').click(function () {
            var aCBM = document.getElementById("aCBM");

            if ($(this).is(":checked")) {
                //get tr which is visible ..add checked to that checkboxes
                $('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
                aCBM.style.display = "";
            } else {
                //remove checked
                $(".checkBoxClass").prop('checked', false);
                aCBM.style.display = "none";
            }
        })
        $(".checkBoxClass").change(function () {
            var aCBM = document.getElementById("aCBM");
            if (!$(this).prop("checked")) {
                $(".checkBoxAllClass").prop("checked", false);
            }
            if ($('.checkBoxClass:checked').length > 0) {
                aCBM.style.display = "";
            } else {
                aCBM.style.display = "none";
            }
        });
        //checkbox

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
			// general
			jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
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
			// general
			//metion
            jQuery(function ($) {
                jq.fn.atwho.debug = true;
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
                };			});
			//metion
            //upload
			jQuery(function ($) {
                var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
                var hfID = document.getElementById("ContentPlaceHolder1_hfID");
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + hfID.value,
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
				$('#lbtnUFUpload').on('click', function (e) {
                    var Btn = document.getElementById("lbtnUFUpload");
                    Btn.disabled = true;
					myDropzone.processQueue();
                    setTimeout(function () {
                        // Enable button
                        Btn.disabled = false;
                    }, 3000);
                });            });
			//upload
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
