<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FIN010000.aspx.vb" Inherits="NET.FIN010000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Billing</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white"><span id="spn00Total"></span></li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
            <asp:Button ID="btn01BillingAmount" runat="server" Text="Button" OnClick="btn01BillingAmount_Click" ClientIDMode="Static" style="display:none;"/>
            <asp:Button ID="btn01BillingRate" runat="server" Text="Button" OnClick="btn01BillingRate_Click" ClientIDMode="Static" style="display:none;"/>
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
					    <img src="Assets/media/svg/apps/FIN010000.svg" alt="" />
				    </div>
				    <!--end::Icon-->
				    <!--begin::Title-->
				    <div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Billing</span>
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
                        <div>
							<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Create Billing">
				                <i class="las la-money-bill fs-2"></i>
                            </button>
							<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
					            <!--begin::Menu item-->
					            <div class="menu-item px-3">
						            <a href="#" class="menu-link flex-stack px-3" onclick="fn01BillingAmount(this);">Fixed Amount</a>
					            </div>
					            <!--end::Menu item-->
					            <!--begin::Menu item-->
					            <div class="menu-item px-3">
						            <a href="#" class="menu-link px-3" onclick="fn01BillingRate(this);">Milestone</a>
					            </div>
					            <!--end::Menu item-->
	                        </div>
						</div>
                        <div>
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
                                <th class="min-w-200px w-100 fw-bold border-end fs-8 nowrap-auto">Title</th>
                                <th class="min-w-200px w-100 fw-bold border-end fs-8 nowrap-auto">Contractor</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8">No.</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8">Price</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8">Billed</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                <th class="min-w-150px mw-150px fw-bold border-end fs-8">Assign To</th>
                            </tr>
                            <tr id="tr01Filter" class="fs-7" style="display:none">
                                <td class="min-w-50px mw-50px fw-bold border-end text-left"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-150px mw-150px fw-bold border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-200px w-100 fw-bold border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-200px w-100 fw-bold border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find06" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find07" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-150px mw-150px fw-bold border-end"><input id="tbx01Find08" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
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
                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbx02Archive" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbx02Archive">
								Archive / Fully Billed Contract
							</label>
						</div>
                        <div class="mb-2">
							<asp:TextBox ID="tbx02WONo" runat="server" class="form-control form-control-sm" placeholder="ID" ></asp:TextBox>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddl02AssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#mdl02Filter" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Assign To</asp:ListItem>
							</asp:DropDownList>
						</div>
                        <div class="mb-2">
							<asp:DropDownList ID="ddl02Category" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlFLT" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Category</asp:ListItem>
								<asp:ListItem Value="Amenities New">Amenities New</asp:ListItem>
                                <asp:ListItem Value="Amenities Repair">Amenities Repair</asp:ListItem>
                                <asp:ListItem Value="Basic to Complete">Basic to Complete</asp:ListItem>
                                <asp:ListItem Value="CLDC Office">CLDC Office</asp:ListItem>
                                <asp:ListItem Value="Clearing / Grass Cutting">Clearing / Grass Cutting</asp:ListItem>
                                <asp:ListItem Value="Container Van">Container Van</asp:ListItem>
                                <asp:ListItem Value="DOLE Application - Land Development">DOLE Application - Land Development</asp:ListItem>
                                <asp:ListItem Value="DOLE Application - Model House">DOLE Application - Model House</asp:ListItem>
                                <asp:ListItem Value="Electrical Consultant">Electrical Consultant</asp:ListItem>
                                <asp:ListItem Value="House Construction">House Construction</asp:ListItem>
                                <asp:ListItem Value="House Repair">House Repair</asp:ListItem>
                                <asp:ListItem Value="Interior Designer">Interior Designer</asp:ListItem>
                                <asp:ListItem Value="Land Development New">Land Development New</asp:ListItem>
                                <asp:ListItem Value="Land Development Repair">Land Development Repair</asp:ListItem>
                                <asp:ListItem Value="Land Scape Project New">Land Scape Project New</asp:ListItem>
                                <asp:ListItem Value="Land Scape Project Restoration">Land Scape Project Restoration</asp:ListItem>
                                <asp:ListItem Value="Land Scape Unit">Land Scape Unit</asp:ListItem>
                                <asp:ListItem Value="NWRB Application">NWRB Application</asp:ListItem>
                                <asp:ListItem Value="Security Services">Security Services</asp:ListItem>
                                <asp:ListItem Value="Service Entrance">Service Entrance</asp:ListItem>
                                <asp:ListItem Value="Structural Consultant - House Unit">Structural Consultant - House Unit</asp:ListItem>
                                <asp:ListItem Value="Structural Consultant - Amenities">Structural Consultant - Amenities</asp:ListItem>
                                <asp:ListItem Value="Temporary Facilities Construction">Temporary Facilities Construction</asp:ListItem>
                                <asp:ListItem Value="Testing and Investigation">Testing and Investigation</asp:ListItem>
                                <asp:ListItem Value="Utilities Repair">Utilities Repair</asp:ListItem>
                                <asp:ListItem Value="Waste Hauling Services">Waste Hauling Services</asp:ListItem>
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
						<div class="mb-2">
							<asp:DropDownList ID="ddl02Contractor" runat="server" data-kt-repeater="select2" data-dropdown-parent="#mdl02Filter" class="form-select form-select-sm min-h-35px">
								<asp:ListItem Value="">Contractor</asp:ListItem>
							</asp:DropDownList>
						</div>
                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
							<input id="cbx02Retention" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbx02Retention">
								With Remaining Retention Fee
							</label>
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
        
		<!--begin::Modal Billing-->
		<asp:UpdatePanel ID="mdl03Billing" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-2" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Create Billing - Fixed Amount</h5>
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
					        <table id="table03Billing" class="table table-row-bordered align-middle">
						        <thead>
							        <tr class="fw-bold fs-7 text-gray-800">
								        <th class="min-w-150px mw-150px fw-bold border-end pl-3">ID</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end nowrap-auto">Title</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end nowrap-auto">Contractor</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Price</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Billed</th>
								        <th class="min-w-150px mw-150px fw-bold border-end">Balance</th>
								        <th class="min-w-150px mw-150px fw-bold border-end">Type</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Amount</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Create</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">APV No.</th>
							        </tr>
						        </thead>
                                <tbody id="tbody03CS" runat="server">
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0 min-w-250px mw-250px w-100 nowrap-auto">
                                    </td>
                                    <td class="p-0 min-w-250px mw-250px w-100 nowrap-auto">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                        <asp:DropDownList ID="ddl03Type_Hdr" runat="server" AutoPostBack="false" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03Billing" CssClass="form-select form-select-sm border-0 w-100" onchange="ddl03Type_Hdr_onchange(this)">
                                            <asp:ListItem Value="">Select Type (All)</asp:ListItem>
                                            <asp:ListItem Value="Downpayment">Downpayment</asp:ListItem>
                                            <asp:ListItem Value="Progress Bill">Progress Bill</asp:ListItem>
                                            <asp:ListItem Value="Final Billing">Final Billing</asp:ListItem>
                                            <asp:ListItem Value="Retention Fee">Retention Fee</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="p-0">
                                        <input id="tbx03Amount_Hdr" runat="server" class='form-control form-control-sm border-0' oninput="tbx03Amount_Hdr_oninput(this)" onblur="FormatNumeric_Hdr(this.id);" type="text" value="0.00" />
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <asp:Repeater ID="rptr03Billing" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <!-- Project -->
                                                <td class="p-0 pl-3"><%# Eval("ID") %></td>
                                                <!-- Project -->
                                                <td class="p-0 min-w-250px mw-250px nowrap-auto"><%# Eval("Title") %></td>
                                                <!-- Project -->
                                                <td class="p-0 min-w-250px mw-250px nowrap-auto"><%# Eval("Contractor") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("No") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Price") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Billed") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Balance") %></td>
                                                <!-- Status -->
                                                <td class="p-0">
                                                    <asp:DropDownList ID="ddl03Type_Dtl" runat="server" prm03type='<%# Eval("ID") %>' data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03Billing" class="form-select form-select-sm border-0 ddl03Type_Dtl">
                                                        <asp:ListItem Value="">Select Status</asp:ListItem>
                                                        <asp:ListItem Value="Downpayment">Downpayment</asp:ListItem>
                                                        <asp:ListItem Value="Progress Bill">Progress Bill</asp:ListItem>
                                                        <asp:ListItem Value="Final Billing">Final Billing</asp:ListItem>
                                                        <asp:ListItem Value="Retention Fee">Retention Fee</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <!-- Assign To -->
                                                <td class="p-0">
                                                    <input id="tbx03Amount_Dtl" runat="server" prm03amount='<%# Eval("ID") %>' class='form-control form-control-sm border-0 tbx03Amount_Dtl' onblur="FormatNumeric_Dtl(this.id);" type="text" value="0.00" />
                                                </td>
                                                <!-- Action -->
                                                <td class="p-0"><button prm03button='<%# Eval("ID") %>' class="btn btn-sm btn-active-success w-100 btn03Create" onclick="fn03Create(this);"><span class='indicator-label'>Create</span><span class='indicator-progress'><span class='spinner-border spinner-border-sm align-middle'></span></span></button></td>
                                                <!-- Update Status -->
                                                <td class="p-0">
                                                    <span id="spn03Label" prm03label='<%# Eval("ID") %>' class="d-flex align-middle"></span>
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
						<button class="btn btn-primary" runat="server" onclick="fn03CreateAll(this);">Create</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Billing-->

        <!--begin::Modal Billing-->
        <asp:UpdatePanel ID="mdl05Billing" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-2" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
        <ContentTemplate>
	        <div class="modal-dialog modal-fullscreen">
		        <div class="modal-content shadow-none">
			        <div class="modal-header">
				        <h5 class="modal-title">Create Billing - Milestone</h5>
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
			                <table id="table05Billing" class="table table-row-bordered align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
						                <th class="min-w-150px mw-150px fw-bold border-end pl-3">ID</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end nowrap-auto">Title</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end nowrap-auto">Contractor</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Price</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Billed</th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Balance</th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Type</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Rate</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Create</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">APV No.</th>
					                </tr>
				                </thead>
                                <tbody id="tbody05CS" runat="server">
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0 min-w-250px mw-250px w-100 nowrap-auto">
                                    </td>
                                    <td class="p-0 min-w-250px mw-250px w-100 nowrap-auto">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                        <asp:DropDownList ID="ddl05Type_Hdr" runat="server" AutoPostBack="false" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl05Billing" CssClass="form-select form-select-sm border-0 w-100" onchange="ddl05Type_Hdr_onchange(this)">
                                            <asp:ListItem Value="">Select Type (All)</asp:ListItem>
                                            <asp:ListItem Value="Downpayment">Downpayment</asp:ListItem>
                                            <asp:ListItem Value="Progress Bill">Progress Bill</asp:ListItem>
                                            <asp:ListItem Value="Final Billing">Final Billing</asp:ListItem>
                                            <asp:ListItem Value="Retention Fee">Retention Fee</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="p-0">
                                        <input id="tbx05Amount_Hdr" runat="server" class='form-control form-control-sm border-0' oninput="tbx05Amount_Hdr_oninput(this)" onblur="FormatNumeric_Hdr(this.id);" type="text" value="0.00" />
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <td class="p-0">
                                    </td>
                                    <asp:Repeater ID="rptr05Billing" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <!-- Project -->
                                                <td class="p-0 pl-3"><%# Eval("ID") %></td>
                                                <!-- Project -->
                                                <td class="p-0 min-w-250px mw-250px nowrap-auto"><%# Eval("Title") %></td>
                                                <!-- Project -->
                                                <td class="p-0 min-w-250px mw-250px nowrap-auto"><%# Eval("Contractor") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("No") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Price") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Billed") %></td>
                                                <!-- Project -->
                                                <td class="p-0"><%# Eval("Balance") %></td>
                                                <!-- Status -->
                                                <td class="p-0">
                                                    <asp:DropDownList ID="ddl05Type_Dtl" runat="server" prm05type='<%# Eval("ID") %>' data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl05Billing" class="form-select form-select-sm border-0 ddl05Type_Dtl">
                                                        <asp:ListItem Value="">Select Status</asp:ListItem>
                                                        <asp:ListItem Value="Downpayment">Downpayment</asp:ListItem>
                                                        <asp:ListItem Value="Progress Bill">Progress Bill</asp:ListItem>
                                                        <asp:ListItem Value="Final Billing">Final Billing</asp:ListItem>
                                                        <asp:ListItem Value="Retention Fee">Retention Fee</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <!-- Assign To -->
                                                <td class="p-0">
                                                    <input id="tbx05Amount_Dtl" runat="server" prm05amount='<%# Eval("ID") %>' class='form-control form-control-sm border-0 tbx05Amount_Dtl' onblur="FormatNumeric_Dtl(this.id);" type="text" value="0.00" />
                                                </td>
                                                <!-- Action -->
                                                <td class="p-0"><button prm05button='<%# Eval("ID") %>' class="btn btn-sm btn-active-success w-100 btn05Create" onclick="fn05Create(this);"><span class='indicator-label'>Create</span><span class='indicator-progress'><span class='spinner-border spinner-border-sm align-middle'></span></span></button></td>
                                                <!-- Update Status -->
                                                <td class="p-0">
                                                    <span id="spn05Label" prm05label='<%# Eval("ID") %>' class="d-flex align-middle"></span>
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
				        <button class="btn btn-primary" runat="server" onclick="fn05CreateAll(this);">Create</button>
			        </div>
			        <!--end::Actions-->
		        </div>
	        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <!--begin::Modal Billing-->

        <!--begin::Modal Detail-->
		<div id="mdl04Detail" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Contract Details</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul id="nav04Tabs" class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tab04Contract">Contract</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" data-bs-toggle="tab" href="#tab04Billing">Billing</a>
								</li>
							</ul>
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
						<div class="tab-content h-100">
							<div class="tab-pane fade show active" id="tab04Contract" role="tabpanel">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">ID</span>
									<asp:Label ID="lbl04ID" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Title</span>
									<asp:Label ID="lbl04Title" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Contractor</span>
									<asp:Label ID="lbl04Contractor" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Category</span>
									<asp:Label ID="lbl04Category" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Type</span>
									<asp:Label ID="lbl04Type" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">No.</span>
									<asp:Label ID="lbl04No" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Price</span>
									<asp:Label ID="lbl04Price" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">VAT</span>
									<asp:Label ID="lbl04VAT" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">EWT</span>
									<asp:Label ID="lbl04EWT" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Down Payment</span>
									<asp:Label ID="lbl04DP" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Retention Fee</span>
									<asp:Label ID="lbl04RF" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Prior Start</span>
									<asp:Label ID="lbl04PriorStart" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:Label ID="lbl04Status" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2 ">
									<span class="input-group-text min-w-150px">Date Awarded</span>
									<asp:Label ID="lbl04DateAwarded" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Billed</span>
									<asp:Label ID="lbl04Billed" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Balance</span>
									<asp:Label ID="lbl04Balance" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
							<div class="tab-pane fade h-100" id="tab04Billing" role="tabpanel">
								<div class="table-responsive border rounded h-100">
                                    <table id="table04Billing" class="table table-row-bordered gy-2 gs-2 w-100">
                                        <thead>
                                            <tr class="fw-bold fs-7 text-gray-800">
                                                <th class="min-w-150px mw-150px fw-bold border-end">Date</th>
                                                <th class="min-w-150px mw-150px fw-bold border-end fs-8">Type</th>
                                                <th class="min-w-150px mw-150px fw-bold border-end fs-8">Amount</th>
                                                <th class="min-w-300px w-100 fw-bold border-end fs-8">Remarks</th>
                                                <th class="min-w-150px mw-150px fw-bold border-end fs-8">Status</th>
                                                <th class="min-w-150px mw-150px fw-bold border-end fs-8">APV</th>
                                                <th class="min-w-150px mw-150px fw-bold border-end fs-8">Status</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbody04Billing">
						
                                        </tbody>
                                    </table>
		                        </div>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<a href="#" class="btn btn-primary" onclick="fn04Billing()" runat="server"> Create Billing</a>
						<a href="#" class="btn btn-primary" onclick="fn04Balance()" >Update Balance</a>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Detail-->

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
        function fn01BillingAmount(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btn01BillingAmount.ClientID %>");
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
        function fn01BillingRate(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btn01BillingRate.ClientID %>");
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
        function fn01Detail(ID) {
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Detail - Info',
                    'ID': ID,
                },
                success: function (response) {
                    var lbl04ID = document.getElementById("ContentPlaceHolder1_lbl04ID");
                    var lbl04Title = document.getElementById("ContentPlaceHolder1_lbl04Title");
                    var lbl04Contractor = document.getElementById("ContentPlaceHolder1_lbl04Contractor");
                    var lbl04Category = document.getElementById("ContentPlaceHolder1_lbl04Category");
                    var lbl04Type = document.getElementById("ContentPlaceHolder1_lbl04Type");
                    var lbl04No = document.getElementById("ContentPlaceHolder1_lbl04No");
                    var lbl04Price = document.getElementById("ContentPlaceHolder1_lbl04Price");
                    var lbl04VAT = document.getElementById("ContentPlaceHolder1_lbl04VAT");
                    var lbl04EWT = document.getElementById("ContentPlaceHolder1_lbl04EWT");
                    var lbl04DP = document.getElementById("ContentPlaceHolder1_lbl04DP");
                    var lbl04RF = document.getElementById("ContentPlaceHolder1_lbl04RF");
                    var lbl04PriorStart = document.getElementById("ContentPlaceHolder1_lbl04PriorStart");
                    var lbl04DateAwarded = document.getElementById("ContentPlaceHolder1_lbl04DateAwarded");
                    var lbl04Billed = document.getElementById("ContentPlaceHolder1_lbl04Billed");
                    var lbl04Balance = document.getElementById("ContentPlaceHolder1_lbl04Balance");

                    lbl04ID.innerText = response[0].ID;
                    lbl04Title.innerText = response[0].Title;
                    lbl04Contractor.innerText = response[0].Contractor;
                    lbl04Category.innerText = response[0].Category;
                    lbl04Type.innerText = response[0].Type;
                    lbl04No.innerText = response[0].No;
                    lbl04Price.innerText = response[0].Price;
                    lbl04VAT.innerText = response[0].VAT;
                    lbl04EWT.innerText = response[0].EWT;
                    lbl04DP.innerText = response[0].DP;
                    lbl04RF.innerText = response[0].RF;
                    lbl04PriorStart.innerText = response[0].PriorStart;
                    lbl04DateAwarded.innerText = response[0].DateAwarded;
                    lbl04Billed.innerText = response[0].Billed;
                    lbl04Balance.innerText = response[0].Balance;
                },
            });
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Detail - Billing',
                    'ID': ID
                },
                success: function (response) {
                    $('#table04Billing').DataTable().destroy();
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
                var table04Billing = $("#table04Billing").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollResize: true,
                    scrollX: true,
                    scrollY: 100,
                    paging: false,
                    lengthChange: false,
                    select: false,
                    data: response,
                    columns: [
                        { data: 'Date' },
                        { data: 'Type' },
                        { data: 'Amount' },
                        { data: 'Remarks' },
                        { data: 'Status' },
                        { data: 'APVNo' },
                        { data: 'APVStatus' }],
                    order: [],
                    orderCellsTop: true
                });
                //datatable
            }
            //initial load
            $('#mdl04Detail').modal('show');
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
                var cbx02Archive = document.getElementById("ContentPlaceHolder1_cbx02Archive");
                var tbx02WONo = document.getElementById("ContentPlaceHolder1_tbx02WONo");
                var ddl02AssignTo = document.getElementById("ContentPlaceHolder1_ddl02AssignTo");
                var ddl02Category = document.getElementById("ContentPlaceHolder1_ddl02Category");
                var tbx02Subdivision = document.getElementById("ContentPlaceHolder1_tbx02Subdivision");
                var tbx02Phase = document.getElementById("ContentPlaceHolder1_tbx02Phase");
                var tbx02Block = document.getElementById("ContentPlaceHolder1_tbx02Block");
                var tbx02Lot = document.getElementById("ContentPlaceHolder1_tbx02Lot");
                var ddl02Batch = document.getElementById("ContentPlaceHolder1_ddl02Batch");
                var ddl02Contractor = document.getElementById("ContentPlaceHolder1_ddl02Contractor");
                var cbx02Retention = document.getElementById("ContentPlaceHolder1_cbx02Retention");
                //initial load
                $.ajax({
                    type: "POST",
                    url: "HNDFIN.ashx",
                    data: {
                        'pFormCode': 'FIN010000',
                        'pType': 'Filter',
                        'Archive': cbx02Archive.checked,
                        'WONo': tbx02WONo.value,
                        'AssignTo': ddl02AssignTo.options[ddl02AssignTo.selectedIndex].value,
                        'Category': ddl02Category.options[ddl02Category.selectedIndex].value,
                        'Subd': tbx02Subdivision.value,
                        'Phase': tbx02Phase.value,
                        'Block': tbx02Block.value,
                        'Lot': tbx02Lot.value,
                        'Batch': ddl02Batch.options[ddl02Batch.selectedIndex].value,
                        'Contractor': ddl02Contractor.options[ddl02Contractor.selectedIndex].value,
                        'Retention': cbx02Retention.checked
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
                            { data: 'Contractor' },
                            { data: 'ConNo' },
                            { data: 'Price' },
                            { data: 'Billed' },
                            { data: 'Balance' },
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
                                targets: 2,
                                className: 'tbody-nowrap-auto',
                                render: function (data, type, row) {
                                    return `<span class="tbody-nowrap-auto" title="${data}">${data}</span>`;
                                }
                            },
                            {
                                targets: 3,
                                className: 'tbody-nowrap-auto',
                                render: function (data, type, row) {
                                    return `<span class="tbody-nowrap-auto" title="${data}">${data}</span>`;
                                }
                            },
                            {
                                targets: 8,
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
                    $('#tbx01Find07').on('keyup', function () {
                        table01Task.columns(7).search(this.value).draw();
                    });
                    $('#tbx01Find08').on('keyup', function () {
                        table01Task.columns(8).search(this.value).draw();
                    });
                    //filter

                    //export
                    const documentTitle = 'For Billing';
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
        function fn03CreateAll(updBtn) {
            // Disable button to avoid multiple click
            updBtn.disabled = true;
            // select all create button
            const Btn = document.querySelectorAll('.btn03Create');
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
            fn03CreateEach(Btn);
        }
        async function fn03CreateEach(Btn) {
            for (const button of Btn) {
                await fn03Save(button);
            }
        }
        function fn03Create(updBtn) {
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
            var ddl03Type_Dtl = document.querySelector('[prm03type="' + ID + '"]');
            var tbx03Amount_Dtl = document.querySelector('[prm03amount="' + ID + '"]');
            var spn03Label = document.querySelector('[prm03label="' + ID + '"]');
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
                        url: "HNDFIN.ashx",
                        data: {
                            'pFormCode': 'FIN010000',
                            'pType': 'Billing-Amount',
                            'CBID': ID,
                            'CBType': ddl03Type_Dtl.options[ddl03Type_Dtl.selectedIndex].value,
                            'CBAmt': tbx03Amount_Dtl.value
                        },
                        success: function (response) {
                            console.log(response);
                            spn03Label.innerHTML = response;
                            fn03Draw(ID);
                        },
                    });
                    resolve();
                }, 350);
            });
        }
        function fn03Draw(ID) {
            //update counter
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Counter'
                },
                success: function (response) {
                    var spn00Total = document.getElementById("spn00Total");
                    spn00Total.innerText = "You have " + response[0].Total + " for billing";
                    var spn01Total = document.getElementById("spn01Total");
                    spn01Total.innerText = "You have " + response[0].Total + " for billing";
                },
            });
            //redraw list
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Redraw',
                    'ID': ID
                },
                success: function (response) {
                    var table01 = $('#table01Task').DataTable();
                    let tr01 = table01.row('#tr01' + ID);
                    let idx01 = tr01.index();
                    table01.cell({ row: idx01, column: 6 }).data(response[0].Status).draw(false);
                    table01.cell({ row: idx01, column: 7 }).data(response[0].AssignTo).draw(false);
                },
            });
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Detail - Info',
                    'ID': ID,
                },
                success: function (response) {
                    var lbl04ID = document.getElementById("ContentPlaceHolder1_lbl04ID");
                    var lbl04Title = document.getElementById("ContentPlaceHolder1_lbl04Title");
                    var lbl04Contractor = document.getElementById("ContentPlaceHolder1_lbl04Contractor");
                    var lbl04Category = document.getElementById("ContentPlaceHolder1_lbl04Category");
                    var lbl04Type = document.getElementById("ContentPlaceHolder1_lbl04Type");
                    var lbl04No = document.getElementById("ContentPlaceHolder1_lbl04No");
                    var lbl04Price = document.getElementById("ContentPlaceHolder1_lbl04Price");
                    var lbl04VAT = document.getElementById("ContentPlaceHolder1_lbl04VAT");
                    var lbl04EWT = document.getElementById("ContentPlaceHolder1_lbl04EWT");
                    var lbl04DP = document.getElementById("ContentPlaceHolder1_lbl04DP");
                    var lbl04RF = document.getElementById("ContentPlaceHolder1_lbl04RF");
                    var lbl04PriorStart = document.getElementById("ContentPlaceHolder1_lbl04PriorStart");
                    var lbl04DateAwarded = document.getElementById("ContentPlaceHolder1_lbl04DateAwarded");
                    var lbl04Billed = document.getElementById("ContentPlaceHolder1_lbl04Billed");
                    var lbl04Balance = document.getElementById("ContentPlaceHolder1_lbl04Balance");

                    lbl04ID.innerText = response[0].ID;
                    lbl04Title.innerText = response[0].Title;
                    lbl04Contractor.innerText = response[0].Contractor;
                    lbl04Category.innerText = response[0].Category;
                    lbl04Type.innerText = response[0].Type;
                    lbl04No.innerText = response[0].No;
                    lbl04Price.innerText = response[0].Price;
                    lbl04VAT.innerText = response[0].VAT;
                    lbl04EWT.innerText = response[0].EWT;
                    lbl04DP.innerText = response[0].DP;
                    lbl04RF.innerText = response[0].RF;
                    lbl04PriorStart.innerText = response[0].PriorStart;
                    lbl04DateAwarded.innerText = response[0].DateAwarded;
                    lbl04Billed.innerText = response[0].Billed;
                    lbl04Balance.innerText = response[0].Balance;
                },
            });
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Detail - Billing',
                    'ID': ID
                },
                success: function (response) {
                    $('#table04Billing').DataTable().destroy();
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
                var table04Billing = $("#table04Billing").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollResize: true,
                    scrollX: true,
                    scrollY: 100,
                    paging: false,
                    lengthChange: false,
                    select: false,
                    data: response,
                    columns: [
                        { data: 'Date' },
                        { data: 'Type' },
                        { data: 'Amount' },
                        { data: 'Remarks' },
                        { data: 'Status' },
                        { data: 'APVNo' },
                        { data: 'APVStatus' }],
                    order: [],
                    orderCellsTop: true
                });
                //datatable
            }
        }
        function ddl03Type_Hdr_onchange(mainDropdown) {
            var selectedValue = mainDropdown.value;
            var dropdowns = document.querySelectorAll(".ddl03Type_Dtl");

            dropdowns.forEach(function (dropdown) {
                dropdown.value = selectedValue;

                var event = new Event("change", { bubbles: true });
                dropdown.dispatchEvent(event);
            });
        }
        function tbx03Amount_Hdr_oninput(mainTextbox) {
            var enteredValue = mainTextbox.value;
            var textboxes = document.querySelectorAll(".tbx05Amount_Dtl");

            textboxes.forEach(function (textbox) {
                textbox.value = enteredValue;

                var event = new Event("input", { bubbles: true });
                textbox.dispatchEvent(event);
            });
        }

        function fn05CreateAll(updBtn) {
            // Disable button to avoid multiple click
            updBtn.disabled = true;
            // select all create button
            const Btn = document.querySelectorAll('.btn05Create');
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
            Btn.forEach(button => button.addEventListener("click", fn05Disable(button)));
            function fn05Disable(button) {
                button.disabled = true;
            };
            // simulate click
            fn05CreateEach(Btn);
        }
        async function fn05CreateEach(Btn) {
            for (const button of Btn) {
                await fn05Save(button);
            }
        }
        function fn05Create(updBtn) {
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
            fn05Save(updBtn);
        }
        async function fn05Save(button) {
            // Get Parameter
            var ID = button.getAttribute("prm05button");
            var ddl05Type_Dtl = document.querySelector('[prm05type="' + ID + '"]');
            var tbx05Amount_Dtl = document.querySelector('[prm05amount="' + ID + '"]');
            var spn05Label = document.querySelector('[prm05label="' + ID + '"]');
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
                        url: "HNDFIN.ashx",
                        data: {
                            'pFormCode': 'FIN010000',
                            'pType': 'Billing-Rate',
                            'CBID': ID,
                            'CBType': ddl05Type_Dtl.options[ddl05Type_Dtl.selectedIndex].value,
                            'CBRate': tbx05Amount_Dtl.value
                        },
                        success: function (response) {
                            spn05Label.innerHTML = response;
                            fn05Draw(ID);
                        },
                    });
                    resolve();
                }, 350);
            });
        }
        function fn05Draw(ID) {
            //update counter
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Counter'
                },
                success: function (response) {
                    var spn00Total = document.getElementById("spn00Total");
                    spn00Total.innerText = "You have " + response[0].Total + " for billing";
                    var spn01Total = document.getElementById("spn01Total");
                    spn01Total.innerText = "You have " + response[0].Total + " for billing";
                },
            });
            //redraw list
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Redraw',
                    'ID': ID
                },
                success: function (response) {
                    var table01 = $('#table01Task').DataTable();
                    let tr01 = table01.row('#tr01' + ID);
                    let idx01 = tr01.index();
                    table01.cell({ row: idx01, column: 6 }).data(response[0].Status).draw(false);
                    table01.cell({ row: idx01, column: 7 }).data(response[0].AssignTo).draw(false);
                },
            });
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Detail - Info',
                    'ID': ID,
                },
                success: function (response) {
                    var lbl04ID = document.getElementById("ContentPlaceHolder1_lbl04ID");
                    var lbl04Title = document.getElementById("ContentPlaceHolder1_lbl04Title");
                    var lbl04Contractor = document.getElementById("ContentPlaceHolder1_lbl04Contractor");
                    var lbl04Category = document.getElementById("ContentPlaceHolder1_lbl04Category");
                    var lbl04Type = document.getElementById("ContentPlaceHolder1_lbl04Type");
                    var lbl04No = document.getElementById("ContentPlaceHolder1_lbl04No");
                    var lbl04Price = document.getElementById("ContentPlaceHolder1_lbl04Price");
                    var lbl04VAT = document.getElementById("ContentPlaceHolder1_lbl04VAT");
                    var lbl04EWT = document.getElementById("ContentPlaceHolder1_lbl04EWT");
                    var lbl04DP = document.getElementById("ContentPlaceHolder1_lbl04DP");
                    var lbl04RF = document.getElementById("ContentPlaceHolder1_lbl04RF");
                    var lbl04PriorStart = document.getElementById("ContentPlaceHolder1_lbl04PriorStart");
                    var lbl04DateAwarded = document.getElementById("ContentPlaceHolder1_lbl04DateAwarded");
                    var lbl04Billed = document.getElementById("ContentPlaceHolder1_lbl04Billed");
                    var lbl04Balance = document.getElementById("ContentPlaceHolder1_lbl04Balance");

                    lbl04ID.innerText = response[0].ID;
                    lbl04Title.innerText = response[0].Title;
                    lbl04Contractor.innerText = response[0].Contractor;
                    lbl04Category.innerText = response[0].Category;
                    lbl04Type.innerText = response[0].Type;
                    lbl04No.innerText = response[0].No;
                    lbl04Price.innerText = response[0].Price;
                    lbl04VAT.innerText = response[0].VAT;
                    lbl04EWT.innerText = response[0].EWT;
                    lbl04DP.innerText = response[0].DP;
                    lbl04RF.innerText = response[0].RF;
                    lbl04PriorStart.innerText = response[0].PriorStart;
                    lbl04DateAwarded.innerText = response[0].DateAwarded;
                    lbl04Billed.innerText = response[0].Billed;
                    lbl04Balance.innerText = response[0].Balance;
                },
            });
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Detail - Billing',
                    'ID': ID
                },
                success: function (response) {
                    $('#table04Billing').DataTable().destroy();
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
                var table04Billing = $("#table04Billing").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollResize: true,
                    scrollX: true,
                    scrollY: 100,
                    paging: false,
                    lengthChange: false,
                    select: false,
                    data: response,
                    columns: [
                        { data: 'Date' },
                        { data: 'Type' },
                        { data: 'Amount' },
                        { data: 'Remarks' },
                        { data: 'Status' },
                        { data: 'APVNo' },
                        { data: 'APVStatus' }],
                    order: [],
                    orderCellsTop: true
                });
                //datatable
            }
        }
        function ddl05Type_Hdr_onchange(mainDropdown) {
            var selectedValue = mainDropdown.value;
            var dropdowns = document.querySelectorAll(".ddl05Type_Dtl");

            dropdowns.forEach(function (dropdown) {
                dropdown.value = selectedValue;

                var event = new Event("change", { bubbles: true });
                dropdown.dispatchEvent(event);
            });
        }
        function tbx05Amount_Hdr_oninput(mainTextbox) {
            var enteredValue = mainTextbox.value;
            var textboxes = document.querySelectorAll(".tbx05Amount_Dtl");

            textboxes.forEach(function (textbox) {
                textbox.value = enteredValue;

                var event = new Event("input", { bubbles: true });
                textbox.dispatchEvent(event);
            });
        }
        //status

        //detail
        function fn04Billing() {
            var lbl04ID = document.getElementById("ContentPlaceHolder1_lbl04ID");
            var selectedIDs = document.getElementById("selectedIDs");
            selectedIDs.value = lbl04ID.innerText;
            // Perform button
            var clickButton = document.getElementById("<%= btn01BillingAmount.ClientID %>");
            clickButton.click();
        }
        function fn04Balance() {
            var lbl04ID = document.getElementById("ContentPlaceHolder1_lbl04ID");
            var ID = lbl04ID.innerText;
            // Do Update
            $.ajax({
                type: "POST",
                url: "HNDFIN.ashx",
                data: {
                    'pFormCode': 'FIN010000',
                    'pType': 'Update - Balance',
                    'ID': ID,
                },
                success: function (response) {
                    Swal.fire({
                        text: "Balance successfully updated.!",
                        icon: "success",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {confirmButton: "btn btn-primary"}
                        }).then((result) => {
                            if (result.isConfirmed) {
                                fn03Draw(ID);
                            }
                        });
                },
            });
        }
        //detail

        //fixed column header alignment
        $(document).ready(function () {
            $('#mdl04Detail').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
            $('#nav04Tabs a.nav-link').on('shown.bs.tab', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
        });
        //fixed column header alignment

        //numeric formatting
        function FormatNumeric_Hdr(ID) {
            var NumVal = document.getElementById(ID);
            var RawValue = NumVal.value.replace(/,/g, "");
            var Val = parseFloat(RawValue);
            if (isNaN(Val)) {
                NumVal.value = "0.00";
                return;
            }
            // Format the number
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
            NumVal.value = Num;

            var enteredValue = NumVal.value;
            var textboxes03 = document.querySelectorAll(".tbx03Amount_Dtl");
            var textboxes05 = document.querySelectorAll(".tbx05Amount_Dtl");

            textboxes03.forEach(function (textbox) {
                textbox.value = enteredValue;

                var event = new Event("input", { bubbles: true });
                textbox.dispatchEvent(event);
            });

            textboxes05.forEach(function (textbox) {
                textbox.value = enteredValue;

                var event = new Event("input", { bubbles: true });
                textbox.dispatchEvent(event);
            });
        }
        function FormatNumeric_Dtl(ID) {
            var NumVal = document.getElementById(ID);
            var RawValue = NumVal.value.replace(/,/g, "");
            var Val = parseFloat(RawValue);
            if (isNaN(Val)) {
                NumVal.value = "0.00";
                return;
            }
            // Format the number
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
            NumVal.value = Num;
        }
        //numeric formatting

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
                        url: "HNDFIN.ashx",
                        data: {
                            'pFormCode': 'FIN010000',
                            'pType': 'Counter'
                        },
                        success: function (response) {
                            var spn00Total = document.getElementById("spn00Total");
                            spn00Total.innerText = "You have " + response[0].Total + " for billing";
                            var spn01Total = document.getElementById("spn01Total");
                            spn01Total.innerText = "You have " + response[0].Total + " for billing";
                        },
                    });
                    //value
                    var cbx02Archive = document.getElementById("ContentPlaceHolder1_cbx02Archive");
                    var tbx02WONo = document.getElementById("ContentPlaceHolder1_tbx02WONo");
                    var ddl02AssignTo = document.getElementById("ContentPlaceHolder1_ddl02AssignTo");
                    var ddl02Category = document.getElementById("ContentPlaceHolder1_ddl02Category");
                    var tbx02Subdivision = document.getElementById("ContentPlaceHolder1_tbx02Subdivision");
                    var tbx02Phase = document.getElementById("ContentPlaceHolder1_tbx02Phase");
                    var tbx02Block = document.getElementById("ContentPlaceHolder1_tbx02Block");
                    var tbx02Lot = document.getElementById("ContentPlaceHolder1_tbx02Lot");
                    var ddl02Batch = document.getElementById("ContentPlaceHolder1_ddl02Batch");
                    var ddl02Contractor = document.getElementById("ContentPlaceHolder1_ddl02Contractor");
                    var cbx02Retention = document.getElementById("ContentPlaceHolder1_cbx02Retention");
                    //initial load
                    $.ajax({
                        type: "POST",
                        url: "HNDFIN.ashx",
                        data: {
                            'pFormCode': 'FIN010000',
                            'pType': 'Filter',
                            'Archive': cbx02Archive.checked,
                            'WONo': tbx02WONo.value,
                            'AssignTo': ddl02AssignTo.options[ddl02AssignTo.selectedIndex].value,
                            'Category': ddl02Category.options[ddl02Category.selectedIndex].value,
                            'Subd': tbx02Subdivision.value,
                            'Phase': tbx02Phase.value,
                            'Block': tbx02Block.value,
                            'Lot': tbx02Lot.value,
                            'Batch': ddl02Batch.options[ddl02Batch.selectedIndex].value,
                            'Contractor': ddl02Contractor.options[ddl02Contractor.selectedIndex].value,
                            'Retention': cbx02Retention.checked
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
                                { data: 'Contractor' },
                                { data: 'ConNo' },
                                { data: 'Price' },
                                { data: 'Billed' },
                                { data: 'Balance' },
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
                                    targets: 2,
                                    className: 'tbody-nowrap-auto',
                                    render: function (data, type, row) {
                                        return `<span class="tbody-nowrap-auto" title="${data}">${data}</span>`;
                                    }
                                },
                                {
                                    targets: 3,
                                    className: 'tbody-nowrap-auto',
                                    render: function (data, type, row) {
                                        return `<span class="tbody-nowrap-auto" title="${data}">${data}</span>`;
                                    }
                                },
                                {
                                    targets: 8,
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
                        $('#tbx01Find07').on('keyup', function () {
                            table01Task.columns(7).search(this.value).draw();
                        });
                        $('#tbx01Find08').on('keyup', function () {
                            table01Task.columns(8).search(this.value).draw();
                        });
                        //filter

                        //export
                        const documentTitle = 'For Billing';
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
                }

                //stop loading
                isPostBack = true;
                //stop loading
            });
            //datatable

        }

    </script>
	<!-- scripts related to this page -->

</asp:Content>
