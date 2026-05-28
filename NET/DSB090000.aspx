<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB090000.aspx.vb" Inherits="NET.DSB090000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">House Contruction Monitoring</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Overview</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<asp:DropDownList ID="ddlBatch" runat="server" data-kt-repeater="select2" class="form-select min-h-43px w-150px" AutoPostBack="true">
						
					</asp:DropDownList>
				</div>
				<!--end::Actions-->
			</div>
			<!--begin::Container-->

		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
		
        <!--begin::Card-->
        <div class="card"  >
            <div class="card-header border-0 py-5">
                <div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/DSB080000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">House Construction</span>
							<span id="spn01Total" runat="server" class="text-muted mt-1 fw-bold fs-7">8 assigned form(s)</span>
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
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-bars fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                         <!--begin::Menu-->
                        <div id="divExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="btn01Filter()">Filter</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="csv">Export as CSV</a>
                            </div>
                            <div class="menu-item px-3 mb-4">
                                <a href="#" class="menu-link px-3" data-kt-export="pdf">Export as PDF</a>
                            </div>
                            <label class="form-label fw-bold px-6">Display</label>
                            <!--begin::Options-->
						    <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="7" />
							    <span class="form-check-label text-gray-600">TOPO</span>
						    </label>
						    <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="10" />
							    <span class="form-check-label text-gray-600">Construction Drawings</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="13" />
							    <span class="form-check-label text-gray-600">Permit Plans</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="16" />
							    <span class="form-check-label text-gray-600">Temporary Facility</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="19" />
							    <span class="form-check-label text-gray-600">Inspection</span>
						    </label>
						    <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="22" />
							    <span class="form-check-label text-gray-600">Building Permit</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="25" />
							    <span class="form-check-label text-gray-600">Cost Estimate</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="28" />
							    <span class="form-check-label text-gray-600">Relocation</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="31" />
							    <span class="form-check-label text-gray-600">Contract Awarding</span>
						    </label>
						    <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="34" />
							    <span class="form-check-label text-gray-600">Extension of Facilities</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="37" />
							    <span class="form-check-label text-gray-600">Construction</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="40" />
							    <span class="form-check-label text-gray-600">COO / CEI</span>
						    </label>
                            <label class="form-check form-check-sm form-check-custom form-check-solid px-5 mb-2">
							    <input class="form-check-input toggle-vis" type="checkbox" checked="checked" value="43" />
							    <span class="form-check-label text-gray-600">Punchlist / COC</span>
						    </label>
						    <!--end::Options-->
                        </div>
                        <!--end::Menu-->
                    </div>
			    </div>
            </div>
			<!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                <div class="border rounded" style="min-height:62.3vh;">
                    <table id="gv01Unit" class="table table-striped table-row-bordered table-rounded gy-2 gs-2">
                        <thead>
                            <tr class="fs-7 text-gray-800 ">
                                <th colspan="1" class="min-w-100px border-end"></th> 
                                <th colspan="6" class="border-bottom border-end fw-bold">Unit</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">TOPO</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Construction Drawings</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Permit Plans</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Temporary Facility</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Inspection</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Building Permit</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Cost Estimate</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Relocation</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Contract Awarding</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Extension of Facilities</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Construction</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">COO / CEI</th>
                                <th colspan="3" class="border-bottom border-end fw-bold">Punchlist / COC</th>
                            </tr>
                            <tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
                                <th class="min-w-100px fw-bold border-end">No.</th>
                                <th class="min-w-100px fw-bold">Batch</th>
                                <th class="min-w-100px fw-bold">Subd</th>
                                <th class="min-w-100px fw-bold">Phase</th>
                                <th class="min-w-100px fw-bold">Block</th>
                                <th class="min-w-100px fw-bold">Lot</th>
                                <th class="min-w-150px fw-bold border-end">House</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                                <th class="min-w-100px fw-bold">Target Date</th>
                                <th class="min-w-100px fw-bold">Status</th>
                                <th class="min-w-100px fw-bold border-end">Date Secured</th>
                            </tr>
                            <tr id="tr01Filter" class="fs-7" style="display:none">
                                <td class="border-end"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find06" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find07" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find08" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find09" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find10" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find11" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find12" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find13" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find14" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find15" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find16" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find17" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find18" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find19" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find20" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find21" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find22" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find23" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find24" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find25" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find26" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find27" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find28" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find29" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find30" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find31" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find32" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find33" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find34" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find35" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find36" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find37" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find38" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find39" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find40" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find41" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find42" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find43" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find44" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find45" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                            </tr>
                        </thead>
                        <tbody>
                            <%For Each dr As Data.DataRow In Me.dsUnit.Tables(0).Rows%>
							<tr>
								<%For Each dc As Data.DataColumn In Me.dsUnit.Tables(0).Columns%>
								<td>
									<%=dr(dc.ColumnName)%>
								</td>
								<% Next%>
							</tr>
							<% Next%>
                        </tbody>
                    </table>
                </div>
				<!--end::Files-->
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->
        	
		<!--begin::Modal List -->
        <div id="mdlInfo" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-800px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">
                            <div class='d-flex flex-column'>
                                <span id="lblInfo_Project" class="fs-6 fw-bold text-dark">Project</span>
                                <span id="lblInfo_No" class="text-muted fs-7">No</span>
                            </div>
						</h5>
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
					</div>
					<div class="modal-body">
						<!--begin::Files-->
                        <div class="border rounded">
                            <table id="gvInfo" class="table table-striped table-row-bordered gy-2 gs-2 min-w-700px">
                                <thead>
                                    <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-200px fw-bold">Task</th>
                                        <th class="min-w-200px fw-bold">Assign To</th>
                                        <th class="min-w-100px fw-bold">Target Date</th>
                                        <th class="min-w-100px fw-bold">Status</th>
                                        <th class="min-w-100px fw-bold">Date Secured</th>
                                    </tr>
                                </thead>
                                <tbody>
                  
                                </tbody>
                            </table>
                        </div>
				        <!--end::Files-->
					</div>
				</div>
			</div>
		</div>
        <!--begin::Modal List -->

    </div>

	<!-- scripts related to this page -->
    <script type="text/javascript">

        //Event
        function ddlBatch_onchange(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;
            bindProject(selectValue)
        }
        $('.toggle-vis').on('change', function () {
            let clmIdx01 = parseInt($(this).val());
            let clmIdx02 = parseInt($(this).val()) + 1;
            let clmIdx03 = parseInt($(this).val()) + 2;
            // Get the column API object
            var column01 = $('#gvProject').DataTable().column(clmIdx01);
            var column02 = $('#gvProject').DataTable().column(clmIdx02);
            var column03 = $('#gvProject').DataTable().column(clmIdx03);
            // Toggle the visibility
            column01.visible(!column01.visible());
            column02.visible(!column02.visible());
            column03.visible(!column03.visible());
        });
        //Event

        //View batch
        function bindInfo(Project, No) {
            document.getElementById("lblInfo_Project").innerHTML = Project;
            document.getElementById("lblInfo_No").innerHTML = No;

            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Info',
                    'No': No
                },
                success: function (response) {
                    DisplayInfo(response)
                },
            });
        }
        function DisplayInfo(response) {
            //datatable
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            var gvInfo = $("#gvInfo").DataTable({
                bFilter: true,
                bPaginate: false,
                bSort: false,
                bDestroy: true,
                bInfo: false,
                paging: false,
                lengthChange: false,
                fixedColumns: { left: 1 },
                select: false,
                data: response,
                columns: [
                    { data: 'Task' },
                    { data: 'AssignTo' },
                    { data: 'TargetDate' },
                    { data: 'Status' },
                    { data: 'DateSecured' }]
            });
            //datatable

            // show modal
            $('#mdlInfo').modal('show');
            // show modal
        }
        function bindProject(Batch) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Project',
                    'Batch': Batch
                },
                success: function (response) {
                    DisplayProject(response)
                },
            });
        }
        function DisplayProject(response) {
            //datatable
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });

            var gvProject = $("#gvProject").DataTable({
                bFilter: true,
                bPaginate: false,
                bDestroy: true,
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
                    { data: 'No' },
                    { data: 'Batch' },
                    { data: 'Subd' },
                    { data: 'Phase' },
                    { data: 'Block' },
                    { data: 'Lot' },
                    { data: 'House' },
                    { data: 'Target011' },
                    { data: 'Status011' },
                    { data: 'DateSecured011' },
                    { data: 'Target002' },
                    { data: 'Status002' },
                    { data: 'DateSecured002' },
                    { data: 'Target014' },
                    { data: 'Status014' },
                    { data: 'DateSecured014' },
                    { data: 'Target008' },
                    { data: 'Status008' },
                    { data: 'DateSecured008' },
                    { data: 'Target012' },
                    { data: 'Status012' },
                    { data: 'DateSecured012' },
                    { data: 'Target001' },
                    { data: 'Status001' },
                    { data: 'DateSecured001' },
                    { data: 'Target003' },
                    { data: 'Status003' },
                    { data: 'DateSecured003' },
                    { data: 'Target013' },
                    { data: 'Status013' },
                    { data: 'DateSecured013' },
                    { data: 'Target005' },
                    { data: 'Status005' },
                    { data: 'DateSecured005' },
                    { data: 'Target009' },
                    { data: 'Status009' },
                    { data: 'DateSecured009' },
                    { data: 'Target006' },
                    { data: 'Status006' },
                    { data: 'DateSecured006' },
                    { data: 'Target007' },
                    { data: 'Status007' },
                    { data: 'DateSecured007' },
                    { data: 'Target010' },
                    { data: 'Status010' },
                    { data: 'DateSecured010' }]
            });
            //datatable
            //search
            $('#tbx01Find').on('keyup', function () {
                gvProject.search(this.value).draw();
            });
            //search
            //export
            const documentTitle = 'House Construction';
            var buttons = new $.fn.dataTable.Buttons(gvProject, {
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
            }).container().appendTo($('#divExportButton'));
            // Hook dropdown menu click event to datatable export buttons
            const exportButtons = document.querySelectorAll('#divExportMenu [data-kt-export]');
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
        //View batch

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                if (isPostBack == false) {
                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var gv01Unit = $("#gv01Unit").DataTable({
                        bFilter: true,
                        bPaginate: false,
                        bDestroy: true,
                        bInfo: false,
                        scrollCollapse: true,
                        scrollResize: true,
                        scrollX: true,
                        scrollY: 100,
                        paging: false,
                        lengthChange: false,
                        fixedColumns: { left: 1 },
                        select: false,
                        dom: "<'table-responsive'tr>"
                    });
                    //datatable

                    //search
                    $('#tbx01Find').on('keyup', function () {
                        gv01Unit.search(this.value).draw();
                    });
                    //search

                    //filter
                    $('#tbx01Find00').on('keyup', function () {
                        gv01Unit.columns(0).search(this.value).draw();
                    });
                    $('#tbx01Find01').on('keyup', function () {
                        gv01Unit.columns(1).search(this.value).draw();
                    });
                    $('#tbx01Find02').on('keyup', function () {
                        gv01Unit.columns(2).search(this.value).draw();
                    });
                    $('#tbx01Find03').on('keyup', function () {
                        gv01Unit.columns(3).search(this.value).draw();
                    });
                    $('#tbx01Find04').on('keyup', function () {
                        gv01Unit.columns(4).search(this.value).draw();
                    });
                    $('#tbx01Find05').on('keyup', function () {
                        gv01Unit.columns(5).search(this.value).draw();
                    });
                    $('#tbx01Find06').on('keyup', function () {
                        gv01Unit.columns(6).search(this.value).draw();
                    });
                    $('#tbx01Find07').on('keyup', function () {
                        gv01Unit.columns(7).search(this.value).draw();
                    });
                    $('#tbx01Find08').on('keyup', function () {
                        gv01Unit.columns(8).search(this.value).draw();
                    });
                    $('#tbx01Find09').on('keyup', function () {
                        gv01Unit.columns(9).search(this.value).draw();
                    });
                    $('#tbx01Find10').on('keyup', function () {
                        gv01Unit.columns(10).search(this.value).draw();
                    });
                    $('#tbx01Find11').on('keyup', function () {
                        gv01Unit.columns(11).search(this.value).draw();
                    });
                    $('#tbx01Find12').on('keyup', function () {
                        gv01Unit.columns(12).search(this.value).draw();
                    });
                    $('#tbx01Find13').on('keyup', function () {
                        gv01Unit.columns(13).search(this.value).draw();
                    });
                    $('#tbx01Find14').on('keyup', function () {
                        gv01Unit.columns(14).search(this.value).draw();
                    });
                    $('#tbx01Find15').on('keyup', function () {
                        gv01Unit.columns(15).search(this.value).draw();
                    });
                    $('#tbx01Find16').on('keyup', function () {
                        gv01Unit.columns(16).search(this.value).draw();
                    });
                    $('#tbx01Find17').on('keyup', function () {
                        gv01Unit.columns(17).search(this.value).draw();
                    });
                    $('#tbx01Find18').on('keyup', function () {
                        gv01Unit.columns(18).search(this.value).draw();
                    });
                    $('#tbx01Find19').on('keyup', function () {
                        gv01Unit.columns(19).search(this.value).draw();
                    });
                    $('#tbx01Find20').on('keyup', function () {
                        gv01Unit.columns(20).search(this.value).draw();
                    });
                    $('#tbx01Find21').on('keyup', function () {
                        gv01Unit.columns(21).search(this.value).draw();
                    });
                    $('#tbx01Find22').on('keyup', function () {
                        gv01Unit.columns(22).search(this.value).draw();
                    });
                    $('#tbx01Find23').on('keyup', function () {
                        gv01Unit.columns(23).search(this.value).draw();
                    });
                    $('#tbx01Find24').on('keyup', function () {
                        gv01Unit.columns(24).search(this.value).draw();
                    });
                    $('#tbx01Find25').on('keyup', function () {
                        gv01Unit.columns(25).search(this.value).draw();
                    });
                    $('#tbx01Find26').on('keyup', function () {
                        gv01Unit.columns(26).search(this.value).draw();
                    });
                    $('#tbx01Find27').on('keyup', function () {
                        gv01Unit.columns(27).search(this.value).draw();
                    });
                    $('#tbx01Find28').on('keyup', function () {
                        gv01Unit.columns(28).search(this.value).draw();
                    });
                    $('#tbx01Find29').on('keyup', function () {
                        gv01Unit.columns(29).search(this.value).draw();
                    });
                    $('#tbx01Find30').on('keyup', function () {
                        gv01Unit.columns(30).search(this.value).draw();
                    });
                    $('#tbx01Find31').on('keyup', function () {
                        gv01Unit.columns(31).search(this.value).draw();
                    });
                    $('#tbx01Find32').on('keyup', function () {
                        gv01Unit.columns(32).search(this.value).draw();
                    });
                    $('#tbx01Find33').on('keyup', function () {
                        gv01Unit.columns(33).search(this.value).draw();
                    });
                    $('#tbx01Find34').on('keyup', function () {
                        gv01Unit.columns(34).search(this.value).draw();
                    });
                    $('#tbx01Find35').on('keyup', function () {
                        gv01Unit.columns(35).search(this.value).draw();
                    });
                    $('#tbx01Find36').on('keyup', function () {
                        gv01Unit.columns(36).search(this.value).draw();
                    });
                    $('#tbx01Find37').on('keyup', function () {
                        gv01Unit.columns(37).search(this.value).draw();
                    });
                    $('#tbx01Find38').on('keyup', function () {
                        gv01Unit.columns(38).search(this.value).draw();
                    });
                    $('#tbx01Find39').on('keyup', function () {
                        gv01Unit.columns(39).search(this.value).draw();
                    });
                    $('#tbx01Find40').on('keyup', function () {
                        gv01Unit.columns(40).search(this.value).draw();
                    });
                    $('#tbx01Find41').on('keyup', function () {
                        gv01Unit.columns(41).search(this.value).draw();
                    });
                    $('#tbx01Find42').on('keyup', function () {
                        gv01Unit.columns(42).search(this.value).draw();
                    });
                    $('#tbx01Find43').on('keyup', function () {
                        gv01Unit.columns(43).search(this.value).draw();
                    });
                    $('#tbx01Find44').on('keyup', function () {
                        gv01Unit.columns(44).search(this.value).draw();
                    });
                    $('#tbx01Find45').on('keyup', function () {
                        gv01Unit.columns(45).search(this.value).draw();
                    });
                    //filter

                    //export
                    const documentTitle = 'House Construction';
                    var buttons = new $.fn.dataTable.Buttons(gv01Unit, {
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
            });
        }
		//load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
