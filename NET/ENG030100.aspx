<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ENG030100.aspx.vb" Inherits="NET.ENG030100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           
    <!--content-->
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
						<li class="breadcrumb-item text-white">Cost Estimate</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">House</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
            <asp:Button ID="btn01Status" runat="server" Text="Button" OnClick="btn01Status_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

        <!--begin::content-->
        <div id="card01Form" class="card">
		    <!--begin::Beader-->
		    <div class="card-header border-0 py-5">
			    <div class="d-flex align-items-center">
				    <!--begin::Icon-->
				    <div class="symbol symbol-35px me-2">
					    <img src="Assets/media/svg/apps/ENG030000.svg" alt="" />
				    </div>
				    <!--end::Icon-->
				    <!--begin::Title-->
				    <div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Cost Estimate : House</span>
						    <span id="spn01Total" class="text-muted mt-1 fw-bold fs-7">8 assigned form(s)</span>
					    </h3>
				    </div>
				    <!--end::Title-->
			    </div>
			    <div class="card-toolbar">
                    <div class="d-flex flex-stack">
                        <!--begin::Search-->
					    <div class="position-relative me-1">
						    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
						    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
							    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
								    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
							    </svg>
						    </span>
						    <!--end::Svg Icon-->
						    <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					    </div>
					    <!--end::Search-->
					    <button class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" onclick="fn01Filter(this);" title="Filter record">
						    <span class="indicator-label">
							    <i class="las la-filter fs-2"></i>
						    </span>
						    <span class="indicator-progress">
							    <span class="spinner-border spinner-border-sm align-middle"></span>
						    </span>
					    </button>
					    <button class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" onclick="fn01Status(this);" title="Change Status">
						    <span class="indicator-label">
							    <i class="las la-flag fs-2"></i>
						    </span>
						    <span class="indicator-progress">
							    <span class="spinner-border spinner-border-sm align-middle"></span>
						    </span>
					    </button>
                        <button class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" onclick="fn01Close(this);" title="Close Task(s)">
						    <span class="indicator-label">
							    <i class="las la-clipboard-check fs-2"></i>
						    </span>
						    <span class="indicator-progress">
							    <span class="spinner-border spinner-border-sm align-middle"></span>
						    </span>
                        </button>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                        <i class="las la-bars fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
						    <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="fn01Search()">Filter</a>
                            </div>
						    <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="csv">Export as CSV</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="pdf">Export as PDF</a>
                            </div>
                        </div>
                        <!--begin::Export buttons-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <!--end::Export buttons-->
                        <!--end::Menu-->
                    </div>
			    </div>
		    </div>
		    <!--end::Header-->
		    <!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                <div class="border rounded" style="min-height:62.3vh;">
                    <table id="table01Task" class="table table-row-bordered gy-2 gs-2 w-100">
                        <thead>
                            <tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
								<th class="min-w-50px mw-50px border-end p-0 pb-2">
                                    <div class="form-check form-check-sm form-check-custom form-check-solid justify-content-center">
                                        <input class="form-check-input" type="checkbox" id="selectAll" style="width: 18px; height: 18px;">
                                    </div>								
								</th>
                                <th class="min-w-150px mw-150px fw-bold border-end">ID</th>
                                <th class="min-w-150px w-100 fw-bold border-end fs-8 nowrap-auto">Title</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Start">Date Start</span></th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date End">Date End</span></th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Status</th>
                                <th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Assign To</th>
                            </tr>
                            <tr id="tr01Filter" class="fs-7" style="display:none">
                                <td class="min-w-50px mw-50px fw-bold border-end text-left"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-150px mw-150px fw-bold border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-150px w-100 fw-bold border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-150px mw-150px fw-bold border-end"><input id="tbx01Find06" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                            </tr>
                        </thead>
                        <tbody id="tbody01Task">
						
                        </tbody>
                    </table>
		        </div>
				<!--end::Files-->
            </div>
		    <!--end::Card body-->
		</div>
		<!--end::content-->
        
		<!--begin::Modal Filter-->
		<div id="mdl02Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
							<asp:DropDownList ID="ddl02AssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#mdl02Filter" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Assign To</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="row gx-2 mb-2">
							<div class="col-3"><asp:TextBox ID="tbx02Subdivision" runat="server" class="form-control form-control-sm" placeholder="Subdivision" ></asp:TextBox></div>
							<div class="col-3"><asp:TextBox ID="tbx02Phase" runat="server" class="form-control form-control-sm" placeholder="Phase" ></asp:TextBox></div>
							<div class="col-3"><asp:TextBox ID="tbx02Block" runat="server" class="form-control form-control-sm" placeholder="Block" ></asp:TextBox></div>
							<div class="col-3"><asp:TextBox ID="tbx02Lot" runat="server" class="form-control form-control-sm" placeholder="Lot" ></asp:TextBox></div>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddl02Batch" runat="server" data-kt-repeater="select2" data-dropdown-parent="#mdl02Filter" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Batch</asp:ListItem>
							</asp:DropDownList>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="fn02Filter(this);">
							Filter
						</button>
                        
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Filter-->
        
		<!--begin::Modal Change Status-->
		<asp:UpdatePanel ID="mdl03Status" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-2" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
                    <div class="modal-body" style="overflow: hidden;">
				        <div class="table-responsive border rounded h-100">
					        <table id="table03Status" class="table table-row-bordered align-middle">
						        <thead>
							        <tr class="fw-bold fs-7 text-gray-800">
								        <th class="min-w-150px mw-150px fw-bold border-end pl-3">ID</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Title</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Status</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Assign To</th>
								        <th class="min-w-100px mw-100px fw-bold border-end">Action</th>
								        <th class="min-w-100px mw-100px fw-bold border-end">Update</th>
							        </tr>
						        </thead>
                                <tbody id="tbody03CS" runat="server">
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                        <asp:DropDownList ID="ddl03Status_Hdr" runat="server" AutoPostBack="false" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03Status" CssClass="form-select form-select-sm border-0 w-100" onchange="ddl03Status_Hdr_onchange(this)">
                                            <asp:ListItem Value="">Select Status (All)</asp:ListItem>
                                            <asp:ListItem Value="Not Started">Not Started</asp:ListItem>
                                            <asp:ListItem Value="On-Going">On-Going</asp:ListItem>
                                            <asp:ListItem Value="On-Hold">On-Hold</asp:ListItem>
                                            <asp:ListItem Value="Complete">Complete</asp:ListItem>
                                            <asp:ListItem Value="Clarify">Clarify</asp:ListItem>
                                            <asp:ListItem Value="Close">Close</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="p-0">
                                        <asp:DropDownList ID="ddl03AssignTo_Hdr" runat="server" AutoPostBack="false" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03Status" CssClass="form-select form-select-sm border-0 w-100" onchange="ddl03AssignTo_Hdr_onchange(this)">
                                            <asp:ListItem Value="">Select User (All)</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <asp:Repeater ID="rptr03Status" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <!-- Project -->
                                                <td class="p-0 pl-3"><%# Eval("ID") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Title") %></td>
                                                <!-- Status -->
                                                <td class="p-0">
                                                    <asp:DropDownList ID="ddl03Status_Dtl" runat="server" prm03status='<%# Eval("ID") %>' data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03Status" class="form-select form-select-sm border-0 ddl03Status_Dtl">
                                                        <asp:ListItem Value="">Select Status</asp:ListItem>
                                                        <asp:ListItem Value="Not Started">Not Started</asp:ListItem>
                                                        <asp:ListItem Value="On-Going">On-Going</asp:ListItem>
                                                        <asp:ListItem Value="On-Hold">On-Hold</asp:ListItem>
                                                        <asp:ListItem Value="Complete">Complete</asp:ListItem>
                                                        <asp:ListItem Value="Clarify">Clarify</asp:ListItem>
                                                        <asp:ListItem Value="Close">Close</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <!-- Assign To -->
                                                <td class="p-0">
                                                    <asp:DropDownList ID="ddl03AssignTo_Dtl" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03Status" class="form-select form-select-sm border-0 ddl03AssignTo_Dtl">
                                                        <asp:ListItem Value="">Select AssignTo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <!-- Action -->
                                                <td class="p-0"><button prm03button='<%# Eval("ID") %>' class="btn btn-sm btn-active-success w-100 btn03Update" onclick="fn03Update(this);"><span class='indicator-label'>Update</span><span class='indicator-progress'><span class='spinner-border spinner-border-sm align-middle'></span></span></button></td>
                                                <!-- Update Status -->
                                                <td class="p-0">
                                                    <asp:UpdatePanel ID="upnlCSUpdate" UpdateMode="Conditional" runat="server">
									                    <ContentTemplate>
                                                            <span id="spn03Label" prm03label='<%# Eval("ID") %>' class="d-flex align-middle"></span>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
					        </table>
				        </div>
                    </div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" runat="server" onclick="fn03UpdateAll(this);">Update</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Change Status-->

		<!--begin::Modal Close-->
		<div id="mdl04Close" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header d-flex justify-content-between">
                        <div>
						    <h5 class="modal-title">Complete / Closed Tasks</h5>
                        </div>
                        <div class="d-flex align-items-center">
						    <div class="d-flex flex-stack">
                                <!--begin::Search-->
					            <div class="position-relative me-1">
						            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
						            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
							            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								            <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
								            <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
							            </svg>
						            </span>
						            <!--end::Svg Icon-->
						            <input id="tbx04Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					            </div>
					            <!--end::Search-->
                                <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
	                                <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                                <i class="las la-bars fs-3"></i>
	                                <!--end::Svg Icon-->
                                </button>
                                <div id="div04ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
						            <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" onclick="fn04Search()">Filter</a>
                                    </div>
						            <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                                    </div>
                                    <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" data-kt-export="csv">Export as CSV</a>
                                    </div>
                                    <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" data-kt-export="pdf">Export as PDF</a>
                                    </div>
                                </div>
                                <!--begin::Export buttons-->
                                <div id="div04ExportButton" class="d-none"></div>
                                <!--end::Export buttons-->
                                <!--end::Menu-->
                            </div>
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
						<!--begin::Files-->
						<div class="table-responsive border rounded h-100">
							<table id="table04Close" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
                                    <tr id="tr04Header" class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end pl-3">ID</th>
										<th class="min-w-300px w-100 fw-bold border-end fs-8 nowrap-auto">Title</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Start">Date Start</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date End">Date End</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Assign To</th>
									</tr>
                                    <tr id="tr04Filter" class="fs-7" style="display:none">
                                        <td class="min-w-150px mw-150px fw-bold border-end text-left"><input id="tbx04Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                        <td class="min-w-300px mw-100 fw-bold border-end"><input id="tbx04Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                        <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx04Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                        <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx04Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                        <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx04Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                        <td class="min-w-150px mw-150px fw-bold border-end"><input id="tbx04Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                    </tr>
								</thead>
								<tbody id="tbody04Close">
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
        </div>
		<!--begin::Modal Close-->

        <input type="hidden" id="selectedIDs" name="selectedIDs" />

    </div>
    <!--content-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">

        //content
        function fn01Filter(Btn) {
            //show modal
            $('#mdl02Filter').modal('show');
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
        function fn01Status(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btn01Status.ClientID %>");
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
        function fn01Close(Btn) {
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
                //initial load
                $.ajax({
                    type: "POST",
                    url: "HNDENG.ashx",
                    data: {
                        'FormCode': 'ENG030101',
                        'Type': 'Close'
                    },
                    success: function (response) {
                        $('#table04Close').DataTable().destroy();
                        Display(response);
                    },
                });
                function Display(response) {
                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table04Close = $("#table04Close").DataTable({
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        scrollResize: true,
                        scrollX: true,
                        scrollY: 100,
                        paging: false,
                        lengthChange: false,
                        fixedColumns: { left: 1 },
                        select: false,
                        data: response,
                        columns: [
                            { data: 'Link' },
                            { data: 'Title' },
                            { data: 'DateStart' },
                            { data: 'DateEnd' },
                            { data: 'Status' },
                            { data: 'AssignTo' }],
                        rowId: 'ID',
                        order: [],
                        columnDefs: [
                            {
                                targets: 0,
                                className: 'tbody-nowrap-auto'
                            },
                            {
                                targets: 1,
                                className: 'tbody-nowrap-auto',
                                render: function (data, type, row) {
                                    return `<span class="tbody-nowrap-auto" title="${data}">${data}</span>`;
                                }
                            },
                            {
                                targets: 5,
                                className: 'tbody-nowrap-150px'
                            }
                        ],
                        orderCellsTop: true
                    });
                    //datatable

                    //search
                    $('#tbx04Find').on('keyup', function () {
                        table04Close.search(this.value).draw();
                    });
                    //search

                    //filter
                    $('#tbx04Find00').on('keyup', function () {
                        table04Close.columns(0).search(this.value).draw();
                    });
                    $('#tbx04Find01').on('keyup', function () {
                        table04Close.columns(1).search(this.value).draw();
                    });
                    $('#tbx04Find02').on('keyup', function () {
                        table04Close.columns(2).search(this.value).draw();
                    });
                    $('#tbx04Find03').on('keyup', function () {
                        table04Close.columns(3).search(this.value).draw();
                    });
                    $('#tbx04Find04').on('keyup', function () {
                        table04Close.columns(4).search(this.value).draw();
                    });
                    $('#tbx04Find05').on('keyup', function () {
                        table04Close.columns(5).search(this.value).draw();
                    });
                    //filter

                    //export
                    const documentTitle = 'Complete / Close Task(s)';
                    var buttons = new $.fn.dataTable.Buttons(table04Close, {
                        buttons: [
                            {
                                extend: 'copyHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'excelHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'csvHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'pdfHtml5',
                                title: documentTitle
                            }
                        ]
                    }).container().appendTo($('#div04ExportButton'));
                    // Hook dropdown menu click event to datatable export buttons
                    const exportButtons = document.querySelectorAll('#div04ExportMenu [data-kt-export]');
                    exportButtons.forEach(exportButton => {
                        exportButton.addEventListener('click', e => {
                            e.preventDefault();

                            // Get clicked export value
                            const exportValue = e.target.getAttribute('data-kt-export');
                            const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                            // Trigger click event on hidden datatable export buttons
                            target.click();
                        });
                    });
                    //export

                    $('#mdl04Close').modal('show');
                }
                //initial load
            }, 3000);
        };
        function fn01Search() {
            var tr01Header = document.getElementById("tr01Header");
            var tr01Filter = document.getElementById("tr01Filter");
            if (window.getComputedStyle(tr01Filter).display === "none") {
                tr01Header.style.display = "none";
                tr01Filter.style.display = "";
            } else {
                tr01Header.style.display = "";
                tr01Filter.style.display = "none";
            }
        }
        //content

        //filter
        function fn02Filter(Btn) {
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
                //value
                var ddl02AssignTo = document.getElementById("ContentPlaceHolder1_ddl02AssignTo");
                var tbx02Subdivision = document.getElementById("ContentPlaceHolder1_tbx02Subdivision");
                var tbx02Phase = document.getElementById("ContentPlaceHolder1_tbx02Phase");
                var tbx02Block = document.getElementById("ContentPlaceHolder1_tbx02Block");
                var tbx02Lot = document.getElementById("ContentPlaceHolder1_tbx02Lot");
                var ddl02Batch = document.getElementById("ContentPlaceHolder1_ddl02Batch");
                //initial load
                $.ajax({
                    type: "POST",
                    url: "HNDENG.ashx",
                    data: {
                        'FormCode': 'ENG030101',
                        'Type': 'Filter',
                        'SubID': '003',
                        'AssignTo': ddl02AssignTo.options[ddl02AssignTo.selectedIndex].value,
                        'Subd': tbx02Subdivision.value,
                        'Phase': tbx02Phase.value,
                        'Block': tbx02Block.value,
                        'Lot': tbx02Lot.value,
                        'Batch': ddl02Batch.options[ddl02Batch.selectedIndex].value
                    },
                    success: function (response) {
                        $('#table01Task').DataTable().destroy();
                        Display(response);
                    },
                });
                function Display(response) {
                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01Task = $("#table01Task").DataTable({
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        scrollResize: true,
                        scrollX: true,
                        scrollY: 100,
                        paging: false,
                        lengthChange: false,
                        fixedColumns: { left: 1 },
                        select: false,
                        data: response,
                        columns: [
                            { data: 'CheckBox' },
                            { data: 'Link' },
                            { data: 'Title' },
                            { data: 'DateStart' },
                            { data: 'DateEnd' },
                            { data: 'Status' },
                            { data: 'AssignTo' }],
                        rowId: 'ID',
                        order: [],
                        columnDefs: [
                            {
                                targets: 0,
                                orderable: false,
                                searchable: false,
                            },
                            {
                                targets: 1,
                                className: 'tbody-nowrap-auto'
                            },
                            {
                                targets: 6,
                                className: 'tbody-nowrap-150px'
                            }
                        ],
                        orderCellsTop: true
                    });
                    //datatable

                    //search
                    $('#tbx01Find').on('keyup', function () {
                        table01Task.search(this.value).draw();
                    });
                    //search

                    //filter
                    $('#tbx01Find00').on('keyup', function () {
                        table01Task.columns(0).search(this.value).draw();
                    });
                    $('#tbx01Find01').on('keyup', function () {
                        table01Task.columns(1).search(this.value).draw();
                    });
                    $('#tbx01Find02').on('keyup', function () {
                        table01Task.columns(2).search(this.value).draw();
                    });
                    $('#tbx01Find03').on('keyup', function () {
                        table01Task.columns(3).search(this.value).draw();
                    });
                    $('#tbx01Find04').on('keyup', function () {
                        table01Task.columns(4).search(this.value).draw();
                    });
                    $('#tbx01Find05').on('keyup', function () {
                        table01Task.columns(5).search(this.value).draw();
                    });
                    $('#tbx01Find06').on('keyup', function () {
                        table01Task.columns(6).search(this.value).draw();
                    });
                    //filter

                    //export
                    const documentTitle = 'Assigned Task(s)';
                    var buttons = new $.fn.dataTable.Buttons(table01Task, {
                        buttons: [
                            {
                                extend: 'copyHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'excelHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'csvHtml5',
                                title: documentTitle
                            },
                            {
                                extend: 'pdfHtml5',
                                title: documentTitle
                            }
                        ]
                    }).container().appendTo($('#div01ExportButton'));
                    // Hook dropdown menu click event to datatable export buttons
                    const exportButtons = document.querySelectorAll('#div01ExportMenu [data-kt-export]');
                    exportButtons.forEach(exportButton => {
                        exportButton.addEventListener('click', e => {
                            e.preventDefault();

                            // Get clicked export value
                            const exportValue = e.target.getAttribute('data-kt-export');
                            const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                            // Trigger click event on hidden datatable export buttons
                            target.click();
                        });
                    });
                    //export

                }
                //initial load
            }, 3000);
        }
		//filter

        //status
        function resetSelectedIDs() {
            $('#selectAll').prop("checked", false);
            let inputs = document.querySelectorAll(".row-checkbox")
            inputs.forEach(item => {
                item.checked = false
            })
            $("#selectedIDs").val("");
        }
        function fn03UpdateAll(updBtn) {
            // Disable button to avoid multiple click
            updBtn.disabled = true;
            // select all create button
            const Btn = document.querySelectorAll('.btn03Update');
            // Show loading indicator
            updBtn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indicator
                updBtn.removeAttribute('data-kt-indicator');
                // Enable button again
                updBtn.disabled = false;
                resetSelectedIDs();
            }, 3000);
            // Disable button to avoid multiple click
            Btn.forEach(button => button.addEventListener("click", fn03Disable(button)));
            function fn03Disable(button) {
                button.disabled = true;
            };
            // simulate click
            fn03UpdateEach(Btn);
        }
        async function fn03UpdateEach(Btn) {
            for (const button of Btn) {
                await fn03Save(button);
            }
        }
        function fn03Update(updBtn) {
            // Disable the clicked button to avoid multiple clicks
            updBtn.disabled = true;
            // Show loading indicator
            updBtn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indicator
                updBtn.removeAttribute('data-kt-indicator');
                // Enable button again
                updBtn.disabled = false;
                resetSelectedIDs();
            }, 3000);

            // Call ProcessChangeStatus only for the clicked button
            fn03Save(updBtn);
        }
        async function fn03Save(button) {
            // Get Parameter
            var ID = button.getAttribute("prm03button");
            var ddl03Status_Dtl = document.querySelector('[prm03status=' + ID + ']');
            var ddl03AssignTo_Dtl = document.querySelector('[prm03assign=' + ID + ']');
            var spn03Label = document.querySelector('[prm03label=' + ID + ']');
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
                        url: "HNDENG.ashx",
                        data: {
                            'FormCode': 'ENG030101',
                            'Type': 'Update',
                            'ID': ID,
                            'SUBID': '003',
                            'Status': ddl03Status_Dtl.options[ddl03Status_Dtl.selectedIndex].value,
                            'AssignTo': ddl03AssignTo_Dtl.options[ddl03AssignTo_Dtl.selectedIndex].value
                        },
                        success: function (response) {
                            spn03Label.innerHTML = response;
                            if (response.includes("<i class='las la-check-circle text-success fs-2'></i>&nbsp Success")) {
                                fn03Draw(ID);
                            }
                        },
                    });
                    resolve();
                }, 350);
            });
        }
        function fn03Draw(ID) {
            var ddl02AssignTo = document.getElementById("ContentPlaceHolder1_ddl02AssignTo");
            //update counter
            $.ajax({
                type: "POST",
                url: "HNDENG.ashx",
                data: {
                    'FormCode': 'ENG030101',
                    'Type': 'Counter',
                    'SubID': '003'
                },
                success: function (response) {
                    var spn01Total = document.getElementById("spn01Total");
                    spn01Total.innerText = "You have " + response[0].InProgress + " assigned task(s)";
                },
            });
            //redraw list
            $.ajax({
                type: "POST",
                url: "HNDENG.ashx",
                data: {
                    'FormCode': 'ENG030101',
                    'Type': 'Redraw',
                    'ID': ID,
                    'AssignTo': ddl02AssignTo.options[ddl02AssignTo.selectedIndex].value 
                },
                success: function (response) {
                    if (response[0].Action == "Update") {
                        //assigned
                        if (document.getElementById("tr01" + ID) != null) {
                            var table01 = $('#table01Task').DataTable();
                            let tr01 = table01.row('#tr01' + ID);
                            let idx01 = tr01.index();
                            table01.cell({ row: idx01, column: 5 }).data(response[0].Status).draw(false);
                            table01.cell({ row: idx01, column: 6 }).data(response[0].AssignTo).draw(false);
                        } else {
                            var table01 = $('#table01Task').DataTable();
                            var data01 = [response[0].CheckBox, response[0].Link, response[0].Title, response[0].DateStart, response[0].DateEnd, response[0].Status, response[0].AssignTo];
                            var tr01 = 'tr01' + ID;
                            var td01 = table01.row.add(data01).draw();
                            $(td01.node()).attr('id', tr01);
                        }
                    } else {
                        //assigned
                        var table01 = $('#table01Task').DataTable();
                        table01.row('#tr01' + ID).remove().draw(false);
                    }
                },
            });
        }
        function ddl03Status_Hdr_onchange(mainDropdown) {
            var selectedValue = mainDropdown.value;
            var dropdowns = document.querySelectorAll(".ddl03Status_Dtl");

            dropdowns.forEach(function (dropdown) {
                dropdown.value = selectedValue;

                var event = new Event("change", { bubbles: true });
                dropdown.dispatchEvent(event);
            });
        }
        function ddl03AssignTo_Hdr_onchange(mainDropdown) {
            var selectedValue = mainDropdown.value;
            var dropdowns = document.querySelectorAll(".ddl03AssignTo_Dtl");

            dropdowns.forEach(function (dropdown) {
                dropdown.value = selectedValue;

                var event = new Event("change", { bubbles: true });
                dropdown.dispatchEvent(event);
            });
        }
        //status

        //close
        function fn04Search() {
            var tr04Header = document.getElementById("tr04Header");
            var tr04Filter = document.getElementById("tr04Filter");
            if (window.getComputedStyle(tr04Filter).display === "none") {
                tr04Header.style.display = "none";
                tr04Filter.style.display = "";
            } else {
                tr04Header.style.display = "";
                tr04Filter.style.display = "none";
            }
        };
        //close

        //fixed column header alignment
        $(document).ready(function () {
            $('#mdl04Close').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
        });
        //fixed column header alignment

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {

            //general
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
            //general

            //checkbox
            jQuery(function ($) {

                function toggleCheckboxes(headerSelector, checkboxSelector) {
                    $(headerSelector).on("click", function () {
                        $(checkboxSelector).prop("checked", this.checked);
                        collectSelectedIDs(); // Collect IDs after toggling select all
                    });

                    $(document).on("click", checkboxSelector, function () {
                        if ($(checkboxSelector + ":checked").length === $(checkboxSelector).length) {
                            $(headerSelector).prop("checked", true);
                        } else {
                            $(headerSelector).prop("checked", false);
                        }
                        collectSelectedIDs(); // Collect IDs after checkbox change
                    });
                }
                toggleCheckboxes("#selectAll", ".row-checkbox");

                function collectSelectedIDs() {
                    let selectedIDs = [];

                    $(".row-checkbox:checked").each(function () {
                        let rawID = $(this).data("id"); // Ensure this is correctly set in the checkbox element
                        if (rawID) {
                            rawID = rawID.replace(/<[^>]*>/g, ""); // Remove any HTML tags
                            selectedIDs.push(rawID);
                        }
                    });

                    $("#selectedIDs").val(selectedIDs.join(",")); // Store in hidden field

                }
                // Attach the collectSelectedIDs function to the change event of checkboxes
                $(document).on("change", ".row-checkbox", collectSelectedIDs);

            });
            //checkbox

            //datatable
            jQuery(function ($) {

                if (isPostBack == false) {
                    //update counter
                    $.ajax({
                        type: "POST",
                        url: "HNDENG.ashx",
                        data: {
                            'FormCode': 'ENG030101',
                            'Type': 'Counter',
                            'SubID': '003'
                        },
                        success: function (response) {
                            var spn01Total = document.getElementById("spn01Total");
                            spn01Total.innerText = "You have " + response[0].InProgress + " assigned task(s)";
                        },
                    });
                    //value
                    var ddl02AssignTo = document.getElementById("ContentPlaceHolder1_ddl02AssignTo");
                    var tbx02Subdivision = document.getElementById("ContentPlaceHolder1_tbx02Subdivision");
                    var tbx02Phase = document.getElementById("ContentPlaceHolder1_tbx02Phase");
                    var tbx02Block = document.getElementById("ContentPlaceHolder1_tbx02Block");
                    var tbx02Lot = document.getElementById("ContentPlaceHolder1_tbx02Lot");
                    var ddl02Batch = document.getElementById("ContentPlaceHolder1_ddl02Batch");
                    //initial load
                    $.ajax({
                        type: "POST",
                        url: "HNDENG.ashx",
                        data: {
                            'FormCode': 'ENG030101',
                            'Type': 'Filter',
                            'SubID': '003',
                            'AssignTo': ddl02AssignTo.options[ddl02AssignTo.selectedIndex].value,
                            'Subd': tbx02Subdivision.value,
                            'Phase': tbx02Phase.value,
                            'Block': tbx02Block.value,
                            'Lot': tbx02Lot.value,
                            'Batch': ddl02Batch.options[ddl02Batch.selectedIndex].value
                        },
                        success: function (response) {
                            $('#table01Task').DataTable().destroy();
                            Display(response);
                        },
                    });
                    function Display(response) {
                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table01Task = $("#table01Task").DataTable({
                            bFilter: true,
                            bPaginate: false,
                            bInfo: false,
                            scrollCollapse: true,
                            scrollResize: true,
                            scrollX: true,
                            scrollY: 100,
                            paging: false,
                            lengthChange: false,
                            fixedColumns: { left: 1 },
                            select: false,
                            data: response,
                            columns: [
                                { data: 'CheckBox' },
                                { data: 'Link' },
                                { data: 'Title' },
                                { data: 'DateStart' },
                                { data: 'DateEnd' },
                                { data: 'Status' },
                                { data: 'AssignTo' }],
                            rowId: 'ID',
                            order: [],
                            columnDefs: [
                                {
                                    targets: 0,
                                    orderable: false,
                                    searchable: false,
                                },
                                {
                                    targets: 1,
                                    className: 'tbody-nowrap-auto'
                                },
                                {
                                    targets: 6,
                                    className: 'tbody-nowrap-150px'
                                }
                            ],
                            orderCellsTop: true
                        });
                        //datatable

                        //search
                        $('#tbx01Find').on('keyup', function () {
                            table01Task.search(this.value).draw();
                        });
                        //search

                        //filter
                        $('#tbx01Find00').on('keyup', function () {
                            table01Task.columns(0).search(this.value).draw();
                        });
                        $('#tbx01Find01').on('keyup', function () {
                            table01Task.columns(1).search(this.value).draw();
                        });
                        $('#tbx01Find02').on('keyup', function () {
                            table01Task.columns(2).search(this.value).draw();
                        });
                        $('#tbx01Find03').on('keyup', function () {
                            table01Task.columns(3).search(this.value).draw();
                        });
                        $('#tbx01Find04').on('keyup', function () {
                            table01Task.columns(4).search(this.value).draw();
                        });
                        $('#tbx01Find05').on('keyup', function () {
                            table01Task.columns(5).search(this.value).draw();
                        });
                        $('#tbx01Find06').on('keyup', function () {
                            table01Task.columns(6).search(this.value).draw();
                        });
                        //filter

                        //export
                        const documentTitle = 'Assigned Task(s)';
                        var buttons = new $.fn.dataTable.Buttons(table01Task, {
                            buttons: [
                                {
                                    extend: 'copyHtml5',
                                    title: documentTitle
                                },
                                {
                                    extend: 'excelHtml5',
                                    title: documentTitle
                                },
                                {
                                    extend: 'csvHtml5',
                                    title: documentTitle
                                },
                                {
                                    extend: 'pdfHtml5',
                                    title: documentTitle
                                }
                            ]
                        }).container().appendTo($('#div01ExportButton'));
                        // Hook dropdown menu click event to datatable export buttons
                        const exportButtons = document.querySelectorAll('#div01ExportMenu [data-kt-export]');
                        exportButtons.forEach(exportButton => {
                            exportButton.addEventListener('click', e => {
                                e.preventDefault();

                                // Get clicked export value
                                const exportValue = e.target.getAttribute('data-kt-export');
                                const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                                // Trigger click event on hidden datatable export buttons
                                target.click();
                            });
                        });
                        //export

                    }
                    //initial load
                }                //stop loading
                isPostBack = true;
                //stop loading            });
            //datatable

        }

    </script>
	<!-- scripts related to this page -->

</asp:Content>
