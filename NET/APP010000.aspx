	<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="APP010000.aspx.vb" Inherits="NET.APP010000"  MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
        <!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Approver</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Approval Path</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="btn02ConfirmAddApprover" runat="server" Text="Button" OnClick="btn02ConfirmAddApprover_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btn04UpdApprover" runat="server" Text="Button" OnClick="btn04UpdApprover_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btn04DelApprover" runat="server" Text="Button" OnClick="btn04DelApprover_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btn04ConfirmUpdApprover" runat="server" Text="Button" OnClick="btn04ConfirmUpdApprover_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn03SaveHdr" runat="server" Text="Button" OnClick="lbtn03SaveHdr_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<!--begin::Card-->
        <div id="card01Form" class="card mb-5">
			<!--begin::Beader-->
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/FRM010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Approval Path</span>
							<span id="spn01Total" runat="server" class="text-muted mt-1 fw-bold fs-7">8 template(s)</span>
						</h3>
					</div>
					<!--end::Title-->
				</div>
			    <div class="card-toolbar">
                    <div class="d-flex flex-stack">
                        <!--begin::Search-->
					    <div class="position-relative me-2">
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
                        <!--begin::Export buttons-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <!--end::Export buttons-->
                        <!--Filter-->
                        <!--Filter-->
                        <!--begin::Menu-->
                        <button type="button" class="btn btn-sm btn-icon btn-primary btn-active-light me-2" onclick="AP01AddTemplate()" title="Add template">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-plus fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-bars fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
							<div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="btn01Filter()">Filter</a>
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
                        <!--end::Menu-->
                    </div>
			    </div>
		    </div>
		    <!--end::Header-->
			<!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
				<div class="border rounded" style="min-height:70.3vh;">
					<table id="gv01Form" class="table table-row-bordered gy-2 gs-2 w-100">
						<thead>
							<tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
								<th class="min-w-150px mw-150px fw-bold border-end">Form No.</th>
								<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
								<th class="min-w-200px w-100 fw-bold border-end">Title</th>
								<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Created Date</span></th>
								<th class="min-w-250px mw-250px fw-bold border-end fs-8 nowrap-auto">Created By</th>
							</tr>
							<tr id="tr01Filter" class="fs-7" style="display:none">
								<td class="border-end"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							</tr>
						</thead>
						<tbody>

						</tbody>
					</table>
				</div>
				<!--end::Files-->
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->

		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdl01APP" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
			<div class="modal-dialog modal-fullscreen modal-dialog-scrollable" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
					    <h5 class="modal-title">
						    Edit Record - <asp:Label ID="lblFormTitle" runat="server"></asp:Label>
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
					<div class="modal-body pt-0">
                        <div class="d-flex justify-content-end mt-5 mb-5">
							<span class="svg-icon svg-icon-primary svg-icon-1x pointer btn btn-light" data-bs-toggle='tooltip' data-bs-placement='top' title="Add Approver" onclick="addApprover();">
								<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
								<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
									<polygon points="0 0 24 0 24 24 0 24"/>
									<path d="M18,8 L16,8 C15.4477153,8 15,7.55228475 15,7 C15,6.44771525 15.4477153,6 16,6 L18,6 L18,4 C18,3.44771525 18.4477153,3 19,3 C19.5522847,3 20,3.44771525 20,4 L20,6 L22,6 C22.5522847,6 23,6.44771525 23,7 C23,7.55228475 22.5522847,8 22,8 L20,8 L20,10 C20,10.5522847 19.5522847,11 19,11 C18.4477153,11 18,10.5522847 18,10 L18,8 Z M9,11 C6.790861,11 5,9.209139 5,7 C5,4.790861 6.790861,3 9,3 C11.209139,3 13,4.790861 13,7 C13,9.209139 11.209139,11 9,11 Z" fill="currentColor" fill-rule="nonzero" opacity="0.3"/>
									<path d="M0.00065168429,20.1992055 C0.388258525,15.4265159 4.26191235,13 8.98334134,13 C13.7712164,13 17.7048837,15.2931929 17.9979143,20.2 C18.0095879,20.3954741 17.9979143,21 17.2466999,21 C13.541124,21 8.03472472,21 0.727502227,21 C0.476712155,21 -0.0204617505,20.45918 0.00065168429,20.1992055 Z" fill="currentColor" fill-rule="nonzero"/>
								</g>
								</svg>
                                <span class="text-gray-800 fw-bold">Add Approver</span>
							</span>
                        </div>
						<div class="border rounded" style="min-height:80vh;">
						    <!--begin::list-->
							<table id="tbl01APP" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr id="tr02Header" class="fw-bold fs-7 text-gray-800">
										<th class="min-w-100px mw-100px fw-bold border-end text-center">Action</th>
										<th class="min-w-200px w-100 fw-bold border-end">Approver</th>
										<th class="min-w-80px mw-80px fw-bold border-end">No.</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-80px mw-80px fw-bold border-end">No. Days</th>
										<th class="min-w-80px mw-80px fw-bold border-end">Project</th>
									</tr>
								</thead>
								<tbody id="tbodyAPP" runat="server">
							
								</tbody>
							</table>
						</div>
						<!--end::list-->
					</div>
				</div>
			</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdl02EMP" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content">
					<div class="modal-header">
					    <h5 class="modal-title">
						    Form Approver - Add Detail
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
					<div class="modal-body">
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px required">Type</span>
							<asp:DropDownList ID="ddl01Type" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl02EMP" class="form-select form-select-sm rounded-start-0 min-h-35px">
								<asp:ListItem Value="">Select a type</asp:ListItem>
								<asp:ListItem Value="Approved By">Approved By</asp:ListItem>
								<asp:ListItem Value="Endorsed By">Endorsed By</asp:ListItem>
								<asp:ListItem Value="Implementer">Implementer</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px required">Approver</span>
							<asp:DropDownList ID="ddl01Approver" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl02EMP" class="form-select form-select-sm rounded-start-0 min-h-35px">
								<asp:ListItem Value="">Select a appprover</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px">#</span>
							<asp:TextBox ID="tbx01SeqNo" runat="server" class="form-control" Placeholder="1" ReadOnly="true"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Days</span>
							<asp:TextBox ID="tbx01Days" runat="server" class="form-control" onblur="FormatNumeric(this.id);" Placeholder="1.00">1.00</asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Project</span>
							<asp:TextBox ID="tbx01Project" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
							<span class="svg-icon svg-icon-primary svg-icon-1x pointer btn btn-light" data-bs-toggle='tooltip' data-bs-placement='top' title="Add Project" onclick="addProject();"><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
								<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
									<rect x="0" y="0" width="24" height="24"/>
									<path d="M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z" fill="currentColor" fill-rule="nonzero" opacity="0.3"/>
									<path d="M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z" fill="currentColor" fill-rule="nonzero"/>
								</g>
							</svg><!--end::Svg Icon--></span>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
						<button type="button" class="btn btn-primary" onclick="btn02ConfirmAddApprover1();">Save Approver</button>
					</div>
				</div>
			</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdl03PRJ" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
					    <h5 class="modal-title">
						    Record
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
					<div class="modal-body m-0 p-0">
					<asp:GridView ID="gvProjects" runat="server" class="table table-no-border table-row-bordered align-middle tscroll" AutoGenerateColumns="False">
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<div class="h-100"><span class='bullet bullet-vertical bullet-margin h-58px bg-light'></span></div> 
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
									<div class="form-check form-check-sm form-check-custom form-check-solid" style='<%# Eval("Project") %>'>
										<input class="form-check-input checkBoxClass" data-code='<%# Eval("Code") %>' id="RowCheckbox" runat="server" type="checkbox" value="1" />
									</div>
								</ItemTemplate>
								<HeaderStyle CssClass="mw-30px min-w-30px" />
								<ItemStyle CssClass="mw-30px min-w-30px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Project">
								<ItemTemplate>
									<div class="overlay overflow-hidden">
										<div class="overlay-wrapper">
											<div class="d-flex align-items-center w-100">
												<div class="d-flex flex-column min-w-400px w-100">
													<span class="text-dark fw-bolder fs-6 nowrap-auto" style='<%# Eval("Align") %>'> <%# Eval("Description") %></span>
													<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Code") %></span>
												</div>
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
					<div class="modal-footer">
						<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
						<%--<asp:LinkButton ID="lbtn01SaveProject" runat="server" type="button" class="btn btn-primary">Save</asp:LinkButton>--%>
						<button id="lbtn01SaveProject" type="button" class="btn btn-primary" onclick="btnSaveProject();">Save</button>
					</div>
				</div>
			</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdl04UPD" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
					    <h5 class="modal-title">
						    Form Approver - Edit Detail
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
					<div class="modal-body">
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px required">Type</span>
							<asp:DropDownList ID="ddl02Type" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl04UPD" class="form-select form-select-sm rounded-start-0 min-h-35px">
								<asp:ListItem Value="">Select a type</asp:ListItem>
								<asp:ListItem Value="Approved By">Approved By</asp:ListItem>
								<asp:ListItem Value="Endorsed By">Endorsed By</asp:ListItem>
								<asp:ListItem Value="Implementer">Implementer</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px required">Approver</span>
							<asp:DropDownList ID="ddl02Approver" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl04UPD" class="form-select form-select-sm rounded-start-0 min-h-35px">
								<asp:ListItem Value="">Select a appprover</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px">#</span>
							<asp:TextBox ID="tbx02SeqNo" runat="server" class="form-control" Placeholder="1" ReadOnly="true"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Days</span>
							<asp:TextBox ID="tbx02Days" runat="server" class="form-control" onblur="FormatNumeric(this.id);" Placeholder="1.00">1.00</asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Project</span>
							<asp:TextBox ID="tbx02Project" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
							<span class="svg-icon svg-icon-primary svg-icon-1x pointer btn btn-light" data-bs-toggle='tooltip' data-bs-placement='top' title="Add Project" onclick="updProject();"><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
								<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
									<rect x="0" y="0" width="24" height="24"/>
									<path d="M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z" fill="currentColor" fill-rule="nonzero" opacity="0.3"/>
									<path d="M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z" fill="currentColor" fill-rule="nonzero"/>
								</g>
							</svg><!--end::Svg Icon--></span>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
						<button type="button" class="btn btn-primary" onclick="btn04ConfirmUpdApprover1();">Update Approver</button>
					</div>
				</div>
			</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->

		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdl05UPJ" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
					    <h5 class="modal-title">
						    Record
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
					<div class="modal-body m-0 p-0">
					<asp:GridView ID="gvUpdProjects" runat="server" class="table table-no-border table-row-bordered align-middle tscroll" AutoGenerateColumns="False">
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<div class="h-100"><span class='bullet bullet-vertical bullet-margin h-58px bg-light'></span></div> 
								</ItemTemplate>
								<HeaderStyle CssClass="mw-5px min-w-5px" />
								<ItemStyle CssClass="mw-5px min-w-5px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="">
								<HeaderTemplate>
									<div class="form-check form-check-sm form-check-custom form-check-solid">
										<input class="form-check-input checkBoxUpdAllClass progre " type="checkbox" value="1" css="" />
									</div>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="form-check form-check-sm form-check-custom form-check-solid" style='<%# Eval("Project") %>'>
										<input class="form-check-input checkBoxUpdClass" data-updated='<%# Eval("Code") %>' id="RowCheckbox" runat="server" type="checkbox" value="1" />
									</div>
								</ItemTemplate>
								<HeaderStyle CssClass="mw-30px min-w-30px" />
								<ItemStyle CssClass="mw-30px min-w-30px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Project">
								<ItemTemplate>
									<div class="overlay overflow-hidden">
										<div class="overlay-wrapper">
											<div class="d-flex align-items-center w-100">
												<div class="d-flex flex-column min-w-400px w-100">
													<span class="text-dark fw-bolder fs-6 nowrap-auto" style='<%# Eval("Align") %>'> <%# Eval("Description") %></span>
													<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("Code") %></span>
												</div>
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
					<div class="modal-footer">
						<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
						<%--<asp:LinkButton ID="lbtn01SaveProject" runat="server" type="button" class="btn btn-primary">Save</asp:LinkButton>--%>
						<button id="lbtn02UpdProject" type="button" class="btn btn-primary" onclick="btnUpdProject();">Save</button>
					</div>
				</div>
			</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Modal FRM Summary -->
		<asp:UpdatePanel ID="mdl06HDR" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
			<div class="modal-dialog modal-lg modal-dialog-centered mw-650px" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
					    <h5 class="modal-title">
						    Add Approval Path
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
					<div class="modal-body">
						<div class="input-group input-group-sm mb-2 flex-nowrap">
							<span class="input-group-text min-w-150px required">Type</span>
							<asp:DropDownList ID="ddl03FormType" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl06HDR" class="form-select form-select-sm rounded-start-0 min-h-35px">
								<asp:ListItem Value="">Select a type</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Title</span>
							<asp:TextBox ID="tbx03Title" runat="server" class="form-control" Placeholder="Add title"></asp:TextBox>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
						<button type="button" class="btn btn-primary" onclick="lbtn03SaveHdr1();">Save</button>
					</div>
				</div>
			</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal FRM Summary-->
		
		<!--begin::Hidden Variable-->
		<asp:HiddenField ID="hfSeq" runat="server" />
		<asp:HiddenField ID="hfCode" runat="server" />
		<asp:HiddenField ID="hfCount" runat="server" />
		<asp:HiddenField ID="hfProject" runat="server" />
		<asp:HiddenField ID="hfType" runat="server" />
		<asp:HiddenField ID="hfApprover" runat="server" />

		<asp:HiddenField ID="hfUpdType" runat="server" />
		<asp:HiddenField ID="hfUpdApprover" runat="server" />
		<asp:HiddenField ID="hfUpdSeqNo" runat="server" />
		<asp:HiddenField ID="hfUpdCode" runat="server" />
		<asp:HiddenField ID="hfUpdDays" runat="server" />
		<asp:HiddenField ID="hfUpdCount" runat="server" />
		<asp:HiddenField ID="hfUpdProject" runat="server" />
		<asp:HiddenField ID="hfFormTitle" runat="server" />
		<!--end::Hidden Variable-->
    </div>

    <script type="text/javascript">

		// add template
		function AP01AddTemplate() {
			$("#ContentPlaceHolder1_mdl06HDR").modal("show");
		};
		// add template

        //fixed column header alignment
        $(document).ready(function () {
            $('#ContentPlaceHolder1_mdl01APP').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
        });
        //fixed column header alignment

		function btn01DelApprover(ID, Code, SeqNo, Type, Project) {
			var hfUpdApprover = document.getElementById("ContentPlaceHolder1_hfUpdApprover"); 
			var hfUpdCode = document.getElementById("ContentPlaceHolder1_hfUpdCode");
			var hfUpdSeqNo = document.getElementById("ContentPlaceHolder1_hfUpdSeqNo");
			var hfUpdType = document.getElementById("ContentPlaceHolder1_hfUpdType");
			var hfUpdProject = document.getElementById("ContentPlaceHolder1_hfUpdProject");

            hfUpdApprover.value = ID;
            hfUpdCode.value = Code;
            hfUpdSeqNo.value = SeqNo;
			hfUpdType.value = Type;
			hfUpdProject.value = Project;

			var clickButton = document.getElementById("<%= btn04DelApprover.ClientID %>");
			clickButton.click();
		};
		function btn01UpdApprover(ID, Code, SeqNo, Type, Project) {
            var hfUpdApprover = document.getElementById("ContentPlaceHolder1_hfUpdApprover");
            var hfUpdCode = document.getElementById("ContentPlaceHolder1_hfUpdCode");
            var hfUpdSeqNo = document.getElementById("ContentPlaceHolder1_hfUpdSeqNo");
            var hfUpdType = document.getElementById("ContentPlaceHolder1_hfUpdType");
            var hfUpdProject = document.getElementById("ContentPlaceHolder1_hfUpdProject");

            hfUpdApprover.value = ID;
            hfUpdCode.value = Code;
            hfUpdSeqNo.value = SeqNo;
			hfUpdType.value = Type;
            hfUpdProject.value = Project;

			var clickButton = document.getElementById("<%= btn04UpdApprover.ClientID %>");
			clickButton.click();
		};

		function btn02ConfirmAddApprover1() {
			var clickButton = document.getElementById("<%= btn02ConfirmAddApprover.ClientID %>");
			clickButton.click();
		}

		function btn04ConfirmUpdApprover1() {
			var clickButton = document.getElementById("<%= btn04ConfirmUpdApprover.ClientID %>");
			clickButton.click();
		};
		function lbtn03SaveHdr1() {
			var ddl03FormType = document.getElementById("ContentPlaceHolder1_ddl03FormType");
            var tbx03Title = document.getElementById("ContentPlaceHolder1_tbx03Title");
            if (tbx03Title.value == "") {
                Swal.fire({
                    title: "Error",
                    text: 'Some fields are missing!',
                    icon: 'error',
                    buttonsStyling: false,
                    confirmButtonText: 'Ok, got it!',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                });
            } else if (ddl03FormType.value == "") {
                Swal.fire({
                    title: "Error",
                    text: 'Some fields are missing!',
                    icon: 'error',
                    buttonsStyling: false,
                    confirmButtonText: 'Ok, got it!',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                });
			} else {

                $.ajax({
                    type: "POST",
                    url: "HNDAPP.ashx",
                    data: {
                        'FormCode': 'APP010000',
						'Type': 'Access',
						'Action': 'Add'
                    },
					success: function (response) {
						if (response[0].Status == "0") {
							Swal.fire({
								title: "Access",
                                text: 'Access Denied!',
                                icon: 'error',
                                buttonsStyling: false,
                                confirmButtonText: 'Ok, got it!',
                                customClass: {
                                    confirmButton: 'btn btn-danger'
                                }
                            });
						} else {
                            $.ajax({
                                type: "POST",
                                url: "HNDAPP.ashx",
                                data: {
                                    'FormCode': 'APP010000',
									'Type': 'Approval Template - HDR',
									'FormType': ddl03FormType.value,
									'Title': tbx03Title.value
                                }
                            });
                            Swal.fire({
                                title: "Success",
                                text: 'Successfully added a record.',
                                icon: 'success',
                                buttonsStyling: false,
                                confirmButtonText: 'Ok, got it!',
                                customClass: {
                                    confirmButton: 'btn btn-primary'
                                }
                            }).then((result) => {
                                tbx03Title.value = "";
								ddl03FormType.value = "";

								bindTemplate();

								$("#ContentPlaceHolder1_mdl06HDR").modal("hide");

                            });
						};
                    },
                });
			};
		};
		//variable
		var Project = [];
		//variable

        //format numeric
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
		};
		//format numeric

		//trigger reset
		function triggerReset() {
            var checkBoxes = document.querySelectorAll(".checkBoxClass");
            checkBoxes.forEach(function (checkbox) {
                if (checkbox.checked == true) {
                    checkbox.checked = false;
                }
            })
		};

        function triggerResetUpd() {
            var checkUpdBoxes = document.querySelectorAll(".checkBoxUpdClass");
            checkUpdBoxes.forEach(function (checkbox) {
                if (checkbox.checked == true) {
                    checkbox.checked = false;
                }
            })
		};
		//trigger reset

		//add project
		function btnSaveProject() {
			var checkBoxes = document.querySelectorAll(".checkBoxClass");
			var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
			var hfCount = document.getElementById("ContentPlaceHolder1_hfCount");
			var hfProject = document.getElementById("ContentPlaceHolder1_hfProject");

			Project = [];

			checkBoxes.forEach((checkbox) => {
				if (checkbox.checked) {
					const code = checkbox.getAttribute('data-code');
                    if (code && !Project.includes(code)) {
                        Project.push(code);
                    }
				}
			})	

			//set value
			tbx01Project.value = Project.length;
			hfCount.value = Project.length;
			hfProject.value = Project.join(",");
			//set value

			//modal
            $("#ContentPlaceHolder1_mdl03PRJ").modal("hide");
			//modal
		};
		//add project

		//view approver
		function viewApprover(FormCode, FormTitle) {
            $.ajax({
                type: "POST",
                url: "HNDAPP.ashx",
                data: {
                    'FormCode': 'APP010000',
                    'Type': 'View Approver (Detail)',
                    'Code': FormCode
                },
				success: function (response) {
					var hfCode = document.getElementById("ContentPlaceHolder1_hfCode");
					var hfFormTitle = document.getElementById("ContentPlaceHolder1_hfFormTitle");
					var lblFormTitle = document.getElementById("ContentPlaceHolder1_lblFormTitle");

					//reset
					hfCode.value = "";
					hfFormTitle.value = "";
                    lblFormTitle.innerHTML = "";
					//reset

					//set value
					hfCode.value = FormCode;
					hfFormTitle.value = FormTitle;
                    lblFormTitle.innerHTML = FormTitle;
					//set value

                    DisplayApprover(response);
                },
            });
		};
		function DisplayApprover(response) {
            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var tbl01APP = $("#tbl01APP").DataTable({
                scrollY: 100,
                scrollX: true,
                processing: true,
                bFilter: true,
                bDestroy: true,
                bInfo: true,
                scrollCollapse: true,
                scrollResize: true,
                lengthChange: false,
                pageLength: 100,
                ordering: false,
                select: false,
                order: [],
                data: response,
                columns: [
                    { data: 'col00' },
                    { data: 'col02' },
                    { data: 'col03' },
                    { data: 'col01' },
                    { data: 'col04' },
                    { data: 'col08' }
                ],
                columnDefs: [
                    {
                        targets: [0, 2, 4, 5],
                        className: "dt-body-center"
					}
                ],
                dom: "<'table-responsive'tr>"
            });
            //datatable

            //search
            $('#tbx01Find').on('keyup', function () {
                gv01Form.search(this.value).draw();
            });
            //search

            //filter
            $('#tbx01Find00').on('keyup', function () {
                gv01Form.columns(0).search(this.value).draw();
            });
            $('#tbx01Find01').on('keyup', function () {
                gv01Form.columns(1).search(this.value).draw();
            });
            $('#tbx01Find02').on('keyup', function () {
                gv01Form.columns(2).search(this.value).draw();
            });
            $('#tbx01Find03').on('keyup', function () {
                gv01Form.columns(3).search(this.value).draw();
            });
            $('#tbx01Find04').on('keyup', function () {
                gv01Form.columns(4).search(this.value).draw();
            });
            //filter


            $('#ContentPlaceHolder1_mdl01APP').modal('show');
		};
		//view approver

		//add project
		function addProject() {
			var hfCode = document.getElementById("ContentPlaceHolder1_hfCode");

			$("#ContentPlaceHolder1_mdl03PRJ").modal("show");
		};
		//add project

		//add approver
		function addApprover() {
            var hfSeq = document.getElementById("ContentPlaceHolder1_hfSeq");
			var hfCode = document.getElementById("ContentPlaceHolder1_hfCode");
            $.ajax({
                type: "POST",
                url: "HNDAPP.ashx",
                data: {
                    'FormCode': 'APP010000',
                    'Type': 'Get Sequence',
                    'Code': hfCode.value
                },
				success: function (response) {
					var tbx01SeqNo = document.getElementById("ContentPlaceHolder1_tbx01SeqNo");

					//reset
					hfSeq.value = "";
					tbx01SeqNo.value = "";
					//reset

					//set value
					hfSeq.value = response[0].Seq;
					tbx01SeqNo.value = response[0].Seq;
					//set value

					//modal
					$("#ContentPlaceHolder1_mdl02EMP").modal("show");
					//modal
                },
            });
		};
		//add approver

		//update project
        function updProject() {
            var hfUpdProject = document.getElementById("ContentPlaceHolder1_hfUpdProject").value;
			var checkBoxUpd = document.querySelectorAll(".checkBoxUpdClass");

			var projectArray = hfUpdProject.split(",").map(function (item) {
				return item.trim();
			});

			projectArray.forEach(function (val) {
				var checkBoxUpd = document.querySelector('input[type="checkbox"][data-updated="' + val + '"]');
                if (checkBoxUpd) {
					checkBoxUpd.checked = true;
				}
			});

            $("#ContentPlaceHolder1_mdl05UPJ").modal("show");
        };
		//update project

		//add updated project
		function btnUpdProject() {
			var hfUpdCount = document.getElementById("ContentPlaceHolder1_hfUpdCount");
			var hfUpdProject = document.getElementById("ContentPlaceHolder1_hfUpdProject");
			var checkUpdBoxes = document.querySelectorAll(".checkBoxUpdClass");
			var tbx02Project = document.getElementById("ContentPlaceHolder1_tbx02Project");

            var updVal = new Set(hfUpdProject.value.split(',').map(item => item.trim()));

			checkUpdBoxes.forEach((checkbox) => {
				if (checkbox.checked) {
                    updVal.add(checkbox.getAttribute("data-updated"));
				} else {
                    updVal.delete(checkbox.getAttribute("data-updated"));
				}

				//reset
				hfUpdProject.value = "";
				hfUpdCount.value = "";
				//reset

				//update current - remove whitespace
				var updFilter = Array.from(updVal).filter(value => value.trim() !== "");
				hfUpdProject.value = updFilter.join(",");
				//update current - remove whitespace

				//update count
                hfUpdCount.value = updFilter.length;
				//update count
			});

			//set value
			tbx02Project.value = hfUpdCount.value;
			//set value

			//modal
			$("#ContentPlaceHolder1_mdl05UPJ").modal("hide");
			//modal
		};
		//add updated project

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

            //checkbox - add approver
			$('.checkBoxAllClass').click(function () {

				if ($(this).is(":checked")) {
					//get tr which is visible ..add checked to that checkboxes
					$('tbody').find('tr:visible .checkBoxClass').prop('checked', true);
				} else {
                    //uncheck
                    $('tbody').find('tr:visible .checkBoxClass').prop('checked', false);
				}

			});
            $(".checkBoxClass").change(function () {

                if (!$(this).prop("checked")) {
                    $(".checkBoxAllClass").prop("checked", false);
				}

            });
			//checkbox - add approver

            //checkbox - update approver
            $('.checkBoxUpdAllClass').click(function () {

                if ($(this).is(":checked")) {
                    //get tr which is visible ..add checked to that checkboxes
                    $('tbody').find('tr:visible .checkBoxUpdClass').prop('checked', true);
                } else {
                    //uncheck
                    $('tbody').find('tr:visible .checkBoxUpdClass').prop('checked', false);
                }

            });
            $(".checkBoxUpdClass").change(function () {

                if (!$(this).prop("checked")) {
                    $(".checkBoxUpdAllClass").prop("checked", false);
                }

            });
			//checkbox - update approver
        }
		//postback

        function bindTemplate() {
            // Disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });

            // Sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');

            // Destroy previous DataTable instance if any
            if ($.fn.DataTable.isDataTable("#gv01Form")) {
                $('#gv01Form').DataTable().clear().destroy();
			}

            $('#gv01Form').on('init.dt', function () {
                $('#gv01Form').DataTable().columns.adjust().draw(false);
			});

            var gv01Form = $("#gv01Form").DataTable({
                autoWidth: false,
                scrollY: 100,
                scrollX: true,
                processing: true, 
                serverSide: false,
                paging: true,
                pageLength: 100,
                bFilter: true,
                bDestroy: true,
                bInfo: true,
                scrollCollapse: true,
                scrollResize: true,
                lengthChange: false,
                ordering: false,
                order: [],
                ajax: {
                    type: "GET",
                    url: "HNDAPP.ashx",
                    data: {
                        FormCode: 'APP010000',
                        Type: 'Approval Template - Bind'
                    },
                    dataSrc: function (json) {
                        return Array.isArray(json) ? json : json.data; 
                    }
                },
                columns: [
                    { data: 'col00' },
                    { data: 'col01' },
                    { data: 'col02' },
                    { data: 'col03' },
                    { data: 'col04' }
                ],
                columnDefs: [
                    {
                        targets: [0, 2, 4],
                        className: "dt-body-center"
                    }
                ],
                orderCellsTop: true
            });

            // Search
            $('#tbx01Find').off('keyup').on('keyup', function () {
                gv01Form.search(this.value).draw();
            });

            //filter
            $('#tbx01Find00').on('keyup', function () {
                gv01Form.columns(0).search(this.value).draw();
            });
            $('#tbx01Find01').on('keyup', function () {
                gv01Form.columns(1).search(this.value).draw();
            });
            $('#tbx01Find02').on('keyup', function () {
                gv01Form.columns(2).search(this.value).draw();
            });
            $('#tbx01Find03').on('keyup', function () {
                gv01Form.columns(3).search(this.value).draw();
            });
            $('#tbx01Find04').on('keyup', function () {
                gv01Form.columns(4).search(this.value).draw();
            });
            //filter

            // Export buttons
            const documentTitle = 'Approval Template';
            var buttons = new $.fn.dataTable.Buttons(gv01Form, {
                buttons: [
                    { extend: 'copyHtml5', title: documentTitle },
                    { extend: 'excelHtml5', title: documentTitle },
                    { extend: 'csvHtml5', title: documentTitle },
                    { extend: 'pdfHtml5', title: documentTitle }
                ]
            }).container().appendTo($('#div01ExportButton'));

            // Hook export dropdown to buttons
            document.querySelectorAll('#div01ExportMenu [data-kt-export]').forEach(button => {
                button.addEventListener('click', e => {
                    e.preventDefault();
                    const value = e.target.getAttribute('data-kt-export');
                    const target = document.querySelector('.dt-buttons .buttons-' + value);
                    target.click();
                });
            });
        }

		function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {
                if (isPostBack == false) {
					bindTemplate();

                    //combobox
                    $('[data-kt-repeater="select2"]').select2();
                    //combobox
				};
			});
			jQuery(function ($) {
				//if (isPostBack == false) {

    //                //disable column type detection
    //                DataTable.types().forEach(type => {
    //                    DataTable.type(type, 'detect', () => false);
    //                });
    //                //disable column type detection

    //                //sort date by yyyy/mm/dd
    //                $.fn.dataTable.moment('MM/DD/YYYY');
    //                //sort date by yyyy/mm/dd

    //                //datatable
    //                var gv01Form = $("#gv01Form").DataTable({
    //                    bFilter: true,
    //                    bPaginate: false,
    //                    bInfo: false,
    //                    scrollCollapse: true,
    //                    scrollResize: true,
    //                    scrollX: true,
    //                    scrollY: 100,
    //                    paging: false,
    //                    lengthChange: false,
    //                    select: false,
    //                    columnDefs: [
    //                        {
    //                            targets: 1,
    //                            className: 'tbody-nowrap-auto'
    //                        }
    //                    ],
    //                    dom: "<'table-responsive'tr>"
    //                });
    //                //datatable

    //                //search
    //                $('#tbx01Find').on('keyup', function () {
    //                    gv01Form.search(this.value).draw();
    //                });
    //                //search

    //                //filter
    //                $('#tbx01Find00').on('keyup', function () {
    //                    gv01Form.columns(0).search(this.value).draw();
    //                });
    //                $('#tbx01Find01').on('keyup', function () {
    //                    gv01Form.columns(1).search(this.value).draw();
    //                });
    //                $('#tbx01Find02').on('keyup', function () {
    //                    gv01Form.columns(2).search(this.value).draw();
    //                });
    //                $('#tbx01Find03').on('keyup', function () {
    //                    gv01Form.columns(3).search(this.value).draw();
    //                });
    //                $('#tbx01Find04').on('keyup', function () {
    //                    gv01Form.columns(4).search(this.value).draw();
    //                });
    //                //filter

    //                //export
    //                const documentTitle = 'Approval Template';
    //                var buttons = new $.fn.dataTable.Buttons(gv01Form, {
    //                    buttons: [
    //                        {
    //                            extend: 'copyHtml5',
    //                            title: documentTitle
    //                        },
    //                        {
    //                            extend: 'excelHtml5',
    //                            title: documentTitle
    //                        },
    //                        {
    //                            extend: 'csvHtml5',
    //                            title: documentTitle
    //                        },
    //                        {
    //                            extend: 'pdfHtml5',
    //                            title: documentTitle
    //                        }
    //                    ]
    //                }).container().appendTo($('#div01ExportButton'));
    //                // Hook dropdown menu click event to datatable export buttons
    //                const exportButtons = document.querySelectorAll('#div01ExportMenu [data-kt-export]');
    //                exportButtons.forEach(exportButton => {
    //                    exportButton.addEventListener('click', e => {
    //                        e.preventDefault();

    //                        // Get clicked export value
    //                        const exportValue = e.target.getAttribute('data-kt-export');
    //                        const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

    //                        // Trigger click event on hidden datatable export buttons
    //                        target.click();
    //                    });
    //                });
    //                //export

    //                //stop loading
    //                isPostBack = true;
    //                //stop loading
				//}
			});
		};
    </script>

</asp:Content>
