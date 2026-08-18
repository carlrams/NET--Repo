<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB080000.aspx.vb" Inherits="NET.DSB080000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Batch Monitoring</li>
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
					<asp:DropDownList ID="ddlBatch" runat="server" data-kt-repeater="select2" class="form-select min-h-43px w-150px" onchange="ddlBatch_onchange(this)">
						
					</asp:DropDownList>
				</div>
				<!--end::Actions-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
		
        <!--begin::Card-->
        <div class="card mb-5"  >
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
							<span id="Batchname" class="card-label fw-bolder text-dark">Batch Monitoring</span>
                            <span id="unitcount" class="text-muted mt-1 fw-bold fs-7"></span>
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
						    <input id="tbxFindProject" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					    </div>
					    <!--end::Search-->
                        <!--begin::Export buttons-->
                        <div id="divExportButton" class="d-none"></div>
                        <!--end::Export buttons-->
                        <!--begin::Export dropdown-->
                         <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                        <i class="las la-bars fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <!--begin::Menu-->
                        <div id="divExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
                        
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
                        <!--end::Export dropdown-->
                    </div>
                </div>
            </div>
			<!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                <div class="border h-400px">
                    <table id="gvProject" class="table table-striped table-row-bordered gy-2 gs-2">
                        <thead>
                            <tr class="fs-7 text-gray-800 ">
                                <th rowspan="2" class="min-w-100px align-middle border-bottom border-end  fw-bold">No.</th> 
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
                            <tr class="fw-bold fs-7 text-gray-800">
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

		<!--begin::Charts-->
        <div class="row g-5 mb-5">
            <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="card card-flush h-100">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Batch Status</span>
                            <span class="text-muted fw-bold fs-6"">Overview</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
                    <div class="card-body min-h-300px" >
                        <div id="divConstructionStatus" ></div>
			        </div>
			        <!--end::Body-->
		        </div>
           </div>

           <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="card card-flush h-100">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Status</span>
                            <span class="text-muted fw-bold fs-6"">Per Section</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body min-h-300px pt-0" >
                        <div id="divStatusPerSection" ></div>
			        </div>
			        <!--end::Body-->
		        </div>
            </div>

        </div>
        
        <div class="row g-5 mb-5">
            <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="card card-flush h-100">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Accomplishment</span>
                            <span class="text-muted fw-bold fs-6"">Per Section</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
                    <div class="card-body min-h-300px pt-0" >
                        <div id="divAccomplishmentPerSection" ></div>
			        </div>
			        <!--end::Body-->
		        </div>
           </div>

             <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="card card-flush h-100">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Accomplishment</span>
                            <span class="text-muted fw-bold fs-6"">Per Batch</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
                    <div class="card-body min-h-300px pt-0" >
                        <div id="divAccomplishmentPerContractor" ></div>
			        </div>
			        <!--end::Body-->
		        </div>
           </div>
        </div>

        <div class="card card-flush">
			<!--begin::Header-->
			<div class="card-header">
                <!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Overall Batch Status</span>
                    <span class="text-muted fw-bold fs-6"">Overview</span>
				</h3>
				<!--end::Title-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
            <div class="card-body min-h-300px pt-0" >
                <div id="divOverallBatchStatus" ></div>
			</div>
			<!--end::Body-->
		</div>
        <!--end::Charts-->
        	
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-footer">
                                <asp:Button ID="btnGenerate_Ok" runat="server" Text="Generate COCA" OnClick="btnGenerate_Ok_Click" ClientIDMode="Static" style="display:none;" />
                                <button class="btn btn-primary" onclick="Generate_Ok(this);">
                                    Generate COCA
                                </button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnGenerate_Ok" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
				</div>
			</div>
		</div>
        <!--begin::Modal List -->

		<!--begin::Modal Chart Status -->
        <div id="mdlStatus" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 id="ModalTitle" class="modal-title"></h5>
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
                        <div class="border h-100">
                            <table id="gvStatus" class="table table-striped table-row-bordered gy-2 gs-2">
                                <thead>
                                    <tr class="fs-7 text-gray-800 ">
                                        <th rowspan="2" class="min-w-100px align-middle border-bottom border-end  fw-bold">No.</th> 
                                        <th colspan="6" class="border-bottom border-end fw-bold">Unit</th>
                                        <th colspan="3" class="border-bottom border-end fw-bold"><span id="thTitle"></span></th>
                                    </tr>
                                    <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-100px mw-100px fw-bold">Batch</th>
                                        <th class="min-w-100px mw-100px fw-bold">Subd</th>
                                        <th class="min-w-100px mw-100px fw-bold">Phase</th>
                                        <th class="min-w-100px mw-100px fw-bold">Block</th>
                                        <th class="min-w-100px mw-100px fw-bold">Lot</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">House</th>
                                        <th class="min-w-100px mw-100px fw-bold">Target Date</th>
                                        <th class="min-w-100px mw-100px fw-bold">Status</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Date Secured</th>
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
        <!--begin::Modal Chart Status -->

        <asp:HiddenField ID="hfID" runat="server" />
        <asp:HiddenField ID="hfPostback" runat="server" Value="false" />

    </div>

	<!-- scripts related to this page -->
    <script type="text/javascript">

        function Generate_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnGenerate_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };

       // show hide columns
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
        // show hide columns

        //fixed column header alignment
        $(document).ready(function () {
            $('#mdlStatus').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
        });
       //fixed column header alignment

        //load batch
        function ddlBatch_onchange(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;
            bindProject(selectValue);
        }
        function bindProject(Batch) {
            // Table
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Project',
                    'Batch': Batch
                },
                success: function (response) {
                    DisplayProject(response);
                },
            });
            // Table

            // Construction Status
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Get Status',
                    'Batch': Batch
                },
                success: function (response) {
                    var NotStarted;
                    var InProgress;
                    var Complete;

                    response.forEach(status => {
                        NotStarted = status.NotStarted;
                        InProgress = status.InProgress;
                        Complete = status.Complete;
                    });



                    jQuery(function ($) {
                        document.getElementById('divConstructionStatus').innerHTML = "";
                        var element = document.getElementById('divConstructionStatus');

                        var notstartedColor = '#08a9f4';
                        var inprogressColor = '#ff7800';
                        var completeColor = KTUtil.getCssVariableValue('--bs-success');

                        var total = NotStarted + InProgress + Complete;
                        var NotStartedPercent = ((NotStarted / total) * 100).toFixed(2);
                        var InProgressPercent = ((InProgress / total) * 100).toFixed(2);
                        var CompletePercent = ((Complete / total) * 100).toFixed(2);

                        if (!element) {
                            return;
                        }
                        var options = {
                            series: [NotStarted, InProgress, Complete],
                            chart: {
                                type: 'donut',
                                height: '350px',
                                toolbar: {show: false},
                                events: {
                                    dataPointSelection: function (event, chartContext, config) {
                                        const Status = config.w.config.labels[config.dataPointIndex];
                                        document.getElementById("ModalTitle").innerText = "Construction - " + Status;
                                        document.getElementById("thTitle").innerText = "Contruction";
                                        bindConstructionStatus(Batch, Status)
                                        $("#mdlStatus").modal("show");
                                    }
                                }
                            },
                            plotOptions: {
                                pie: {donut: {size: '50%',labels: {value: {fontSize: '14px'}}}}
                            },
                            labels: ['Not Started', 'In Progress', 'Complete'],
                            legend: {
                                show: true,
                                position: 'bottom',
                                horizontalAlign: 'center',
                                formatter: function (seriesName, opts) {
                                    var index = opts.seriesIndex;
                                    var percentages = [NotStartedPercent, InProgressPercent, CompletePercent];
                                    return `${seriesName} (${percentages[index]}%)`;
                                }
                            },
                            colors: [notstartedColor, inprogressColor, completeColor],
                            fill: { colors: [notstartedColor, inprogressColor, completeColor] },
                            dataLabels: {
                                enabled: true,
                                formatter: function (val, opt) {
                                    return opt.w.config.series[opt.seriesIndex];
                                },
                            },
                            tooltip: {
                                enabled: true,
                                y: {
                                    formatter: function (val, { seriesIndex }) {
                                        var percentages = [NotStartedPercent, InProgressPercent, CompletePercent];
                                        var units = [NotStarted, InProgress, Complete][seriesIndex];
                                        return `${units} Units: (${percentages[seriesIndex]}%)`;
                                    }
                                }
                            }

                        };

                        var chart = new ApexCharts(element, options);
                        chart.render();
                    });
                },
            });
            // Construction Status

            // Status Per Section
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Get Status Per Section',
                    'Batch': Batch
                },
                success: function (response) {
                    var TaskName = response.map(item => item.TaskName);
                    var NotStartedRate = response.map(item => parseFloat(item.NotStartedRate));
                    var InProgressRate = response.map(item => parseFloat(item.InProgressRate));
                    var CompletionRate = response.map(item => parseFloat(item.CompletionRate));
                    var maxTotal = Math.max(
                        ...NotStartedRate.map((value, index) => value + InProgressRate[index] + CompletionRate[index])
                    );

                    jQuery(function ($) {
                        document.getElementById('divStatusPerSection').innerHTML = "";
                        var element = document.getElementById('divStatusPerSection');

                        var notstartedrateColor = '#08a9f4';
                        var inprogressrateColor = '#ff7800';
                        var completionrateColor = KTUtil.getCssVariableValue('--bs-success');
                        
                        if (!element) {
                            return;
                        }
                        var options = {
                            series: [
                                {
                                    name: 'Not Started',
                                    data: NotStartedRate
                                },
                                {
                                    name: 'In Progress',
                                    data: InProgressRate
                                },
                                {
                                    name: 'Complete',
                                    data: CompletionRate
                                }
                            ],
                            chart: {
                                type: 'bar',
                                stacked: true,
                                height: "350px",
                                toolbar: {show: false},
                                events:
                                {
                                    dataPointSelection: function (event, chartContext, config) {
                                        const TaskName = config.w.config.xaxis.categories[config.dataPointIndex];
                                        const Status = config.w.config.series[config.seriesIndex].name;
                                        document.getElementById("ModalTitle").innerText = TaskName + " - " + Status;
                                        document.getElementById("thTitle").innerText = TaskName;
                                        bindStatusPerSection(Batch, TaskName, Status)
                                        $("#mdlStatus").modal("show");
                                    }
                                },
                            },
                            colors: [notstartedrateColor, inprogressrateColor, completionrateColor],
                            plotOptions: {bar: {borderRadiusApplication: 'end',borderRadiusWhenStacked: 'all',horizontal: true,},},
                            xaxis: {categories: TaskName,labels: {show: true,rotate: -45},max: maxTotal},
                            yaxis: {labels: {show: true,}},
                            legend: { show: true, position: 'bottom', fontSize: '12px', markers: { fillColors: [notstartedrateColor, inprogressrateColor, completionrateColor], width: 14, height: 14 } },
                            tooltip: {
                                y: {
                                    formatter: function (val, opts) {
                                        var total = NotStartedRate[opts.dataPointIndex] + InProgressRate[opts.dataPointIndex] + CompletionRate[opts.dataPointIndex];
                                        var percentage = ((val / total) * 100).toFixed(2);
                                        return `${val} Units: (${percentage}%)`;
                                    }
                                }
                            }
                        };

                        var chart = new ApexCharts(element, options);
                        chart.render();
                    });
                },
            });
            // Status Per Section

            // Accomplishment Per Section
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Get Accomplishment Per Section',
                    'Batch': Batch
                },
                success: function (response) {
                    var TaskName = response.map(item => item.TaskName);
                    var CompletedWithinTAT = response.map(item => parseFloat(item.CompletedWithinTAT));
                    var CompletedBeyondTAT = response.map(item => parseFloat(item.CompletedBeyondTAT));

                    jQuery(function ($) {
                        document.getElementById('divAccomplishmentPerSection').innerHTML = "";
                        var element = document.getElementById('divAccomplishmentPerSection');

                        var withinTATColor = KTUtil.getCssVariableValue('--bs-success');
                        var beyondTATColor = KTUtil.getCssVariableValue('--bs-danger');
                        if (!element) {
                            return;
                        }

                        var maxValue = Math.max(
                            ...[CompletedWithinTAT, CompletedBeyondTAT].map(arr => Math.max(...arr))
                        );

                        var options = {
                            series: [
                                {
                                    name: 'Completed Within TAT',
                                    data: CompletedWithinTAT
                                },
                                {
                                    name: 'Completed Beyond TAT',
                                    data: CompletedBeyondTAT
                                }
                            ],
                            chart: {
                                type: 'bar',
                                stacked: true,
                                height: "350px",
                                toolbar: {
                                    show: false
                                },
                                zoom: {
                                    enabled: true
                                },
                                events:
                                {
                                    dataPointSelection: function (event, chartContext, config) {



                                        const TaskName = config.w.config.xaxis.categories[config.dataPointIndex];
                                        const Status = config.w.config.series[config.seriesIndex].name;
                                        document.getElementById("ModalTitle").innerText = TaskName + " - " + Status;
                                        document.getElementById("thTitle").innerText = TaskName;
                                        bindAccomplishmentPerSection(Batch, TaskName, Status)
                                        $("#mdlStatus").modal("show");
                                    }
                                },
                            },
                            colors: [withinTATColor, beyondTATColor],
                            plotOptions: {bar: {borderRadiusApplication: 'end',borderRadiusWhenStacked: 'all',horizontal: true,}},
                            xaxis: {categories: TaskName,labels: {show: true,rotate: -45},max: maxValue},
                            yaxis: {labels: {show: true,}},
                            legend: {position: 'bottom',fontSize: '14px',itemMargin: {horizontal: 20},markers: {fillColors: [withinTATColor, beyondTATColor],width: 14,height: 14}},
                            tooltip: {
                                y: {
                                    formatter: function (val, opts) {
                                        var total = CompletedWithinTAT[opts.dataPointIndex] + CompletedBeyondTAT[opts.dataPointIndex];
                                        var percentage = ((val / total) * 100).toFixed(2);
                                        return `${val} Units: (${percentage}%)`;
                                    }
                                }
                            }

                        };

                        var chart = new ApexCharts(element, options);
                        chart.render();
                    });
                },
            });
            // Accomplishment Per Section

            // Accomplishment Per Contractor
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Get Accomplishment Per Contractor',
                    'Batch': Batch
                },
                success: function (response) {
                    var ConName = response.map(item => item.ConName);
                    var CompletedWithinTAT = response.map(item => parseFloat(item.CompletedWithinTAT));
                    var CompletedBeyondTAT = response.map(item => parseFloat(item.CompletedBeyondTAT));

                    jQuery(function ($) {
                        document.getElementById('divAccomplishmentPerContractor').innerHTML = "";
                        var element = document.getElementById('divAccomplishmentPerContractor');

                        var withinTATColor = KTUtil.getCssVariableValue('--bs-success');
                        var beyondTATColor = KTUtil.getCssVariableValue('--bs-danger');

                        if (!element) {
                            return;
                        }
                        var maxValue = Math.max(
                            ...[CompletedWithinTAT, CompletedBeyondTAT].map(arr => Math.max(...arr))
                        );

                        var options = {
                            series: [{
                                name: 'Completed Within TAT',
                                data: CompletedWithinTAT
                            },
                            {
                                name: 'Completed Beyond TAT',
                                data: CompletedBeyondTAT
                            }
                            ],
                            chart: {type: 'bar',stacked: true,height: '350px',toolbar: {show: false},zoom: {enabled: true},
                                events:
                                {
                                    dataPointSelection: function (event, chartContext, config) {
                                        const ContractorName = config.w.config.xaxis.categories[config.dataPointIndex];
                                        const Status = config.w.config.series[config.seriesIndex].name;
                                        document.getElementById("ModalTitle").innerText = ContractorName + " - " + Status;
                                        document.getElementById("thTitle").innerText = 'Construction';
                                        bindAccomplishmentPerContractor(Batch, ContractorName, Status)
                                        $("#mdlStatus").modal("show");
                                    }
                                },
                            },
                            colors: [withinTATColor, beyondTATColor],
                            plotOptions: {bar: {borderRadiusApplication: 'end',borderRadiusWhenStacked: 'all',horizontal: true,},},
                            xaxis: {categories: ConName,labels: {show: true,rotate: -45},max: maxValue},
                            yaxis: {labels: {show: true,}},
                            legend: {position: 'bottom',fontSize: '14px',itemMargin: {horizontal: 20},markers: {fillColors: [withinTATColor, beyondTATColor],width: 14,height: 14}},
                            tooltip: {y: { formatter: function (value) { return value + "%"; } }},
                            dataLabels: { enabled: true, formatter: function (value) { return value + "%"; } }
                        };

                        var chart = new ApexCharts(element, options);
                        chart.render();
                    });
                },
            });
            // Accomplishment Per Contractor

            // Overall Batch Status
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Get Overall Batch Status',
                    'Batch': Batch
                },
                success: function (response) {
                    var BatchNo = response.map(item => item.BatchNo);
                    var CompletedWithinTAT = response.map(item => parseFloat(item.CompletedWithinTAT));
                    var CompletedBeyondTAT = response.map(item => parseFloat(item.CompletedBeyondTAT));
                    var InProgress = response.map(item => parseFloat(item.InProgress));

                    jQuery(function ($) {
                        document.getElementById('divOverallBatchStatus').innerHTML = "";
                        var element = document.getElementById('divOverallBatchStatus');

                        var withinTATColor = KTUtil.getCssVariableValue('--bs-success');
                        var beyondTATColor = KTUtil.getCssVariableValue('--bs-danger');
                        var inProgressColor = '#ff7800';

                        if (!element) {
                            return;
                        }

                        var chartHeight = (BatchNo.length <= 1) ? '180px' : 'auto';
                        var barHeight = (BatchNo.length === 1) ? '30%' : '50%';
                        var maxValue = Math.max(
                            ...[CompletedWithinTAT, CompletedBeyondTAT, InProgress].map(arr => Math.max(...arr))
                        );


                        var options = {
                            series: [
                                {
                                    name: 'In Progress',
                                    data: InProgress
                                },
                                {
                                    name: 'Completed Within TAT',
                                    data: CompletedWithinTAT
                                },
                                {
                                    name: 'Completed Beyond TAT',
                                    data: CompletedBeyondTAT
                                }
                            ],
                            chart: {
                                type: 'bar', stacked: true, height: 'auto', toolbar: { show: false }, zoom: { enabled: true },
                                events:
                                {
                                    dataPointSelection: function (event, chartContext, config) {
                                        const BatchNo = config.w.config.xaxis.categories[config.dataPointIndex];
                                        const Status = config.w.config.series[config.seriesIndex].name;
                                        document.getElementById("ModalTitle").innerText = BatchNo + " - " + Status;
                                        document.getElementById("thTitle").innerText = 'Punchlist / COC';
                                        bindOverallBatchStatus(Batch, BatchNo, Status)
                                        $("#mdlStatus").modal("show");
                                    }
                                },
                            },
                            colors: [inProgressColor, withinTATColor, beyondTATColor],
                            plotOptions: { bar: { borderRadiusApplication: 'end', borderRadiusWhenStacked: 'all', horizontal: true, }, },
                            xaxis: { categories: BatchNo, labels: { show: true, }, max: maxValue },
                            yaxis: { labels: { show: true, } },
                            legend: { position: 'bottom', fontSize: '14px', itemMargin: { horizontal: 30, }, markers: { fillColors: [inProgressColor, withinTATColor, beyondTATColor], width: 14, height: 14 } },
                            dataLabels: { enabled: true, formatter: function (value) { return value; } },
                            tooltip: {
                                y: {
                                    formatter: function (val, opts) {
                                        var total = InProgress[opts.dataPointIndex] + CompletedWithinTAT[opts.dataPointIndex] + CompletedBeyondTAT[opts.dataPointIndex];
                                        var percentage = ((val / total) * 100).toFixed(2);
                                        return `${val} Units: (${percentage}%)`;
                                    }
                                }
                            }
                        };
                        var chart = new ApexCharts(element, options);
                        chart.render();
                    });
                },
            });
            // Overall Batch Status
        }
        function DisplayProject(response) {
            let batches = [...new Set(response.map(item => item.Batch))];
            let Batch = batches.length === 1 ? `Batch ${batches[0]}` : "All Batches";
            let Units = response.length;
            document.getElementById("Batchname").innerText = Batch;
            document.getElementById("unitcount").innerText = Units + " Units";
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
                scrollY: '500px',
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
                    { data: 'DateSecured010' }],
                columnDefs: [
                    {
                        targets: [8, 11, 14, 17, 20, 23, 26, 29, 32, 35, 38, 41, 44],
                        render: function (data, type, row, meta) {
                            if (type === 'display') {
                                var label = '';
                                if (data === '') {
                                    label = 'badge-hc-new';
                                } else if (data === 'Not Started') {
                                    label = 'badge-hc-new';
                                } else if (data === 'Assign') {
                                    label = 'badge-hc-new';
                                } else if (data === 'On-Going') {
                                    label = 'badge-hc-ongoing';
                                } else if (data === 'On-Hold') {
                                    label = 'badge-hc-onhold';
                                } else if (data === 'Clarify') {
                                    label = 'badge-hc-clarify';
                                } else if (data === 'Complete') {
                                    label = 'badge-hc-complete';
                                } else if (data === 'Close') {
                                    label = 'badge-hc-complete';
                                }
                                return '<span class="badge ' + label + '">' + data + '</span>';
                            }
                            return data;
                        }
                    }
                ],
                rowCallback: function (row, data, index) {
                    var Target010 = new Date(data.Target010);
                    var Today010 = new Date();
                    var Class010 = 'info';
                    if (data.DateSecured010 == '-') {
                        Today010 = new Date();
                        Class010 = 'info';
                    } else {
                        Today010 = new Date(data.DateSecured010);
                        Class010 = 'success';
                    }
                    if (Target010 >= Today010) {
                        $(row).find('td:eq(43)').addClass('text-light-' + Class010 + ' bg-' + Class010 + ' fs-7 fw-bold');
                        $(row).find('td:eq(44)').addClass('text-light-' + Class010 + ' bg-' + Class010 + ' fs-7 fw-bold');
                        $(row).find('td:eq(45)').addClass('text-light-' + Class010 + ' bg-' + Class010 + ' fs-7 fw-bold');
                    } else if (Target010 < Today010) {
                        $(row).find('td:eq(43)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(44)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(45)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target007 = new Date(data.Target007);
                    var Today007 = new Date();
                    var Class007 = 'info';
                    if (data.DateSecured007 == '-') {
                        Today007 = new Date();
                        Class007 = 'info';
                    } else {
                        Today007 = new Date(data.DateSecured007);
                        Class007 = 'success';
                    }
                    if (Target007 >= Today007) {
                        $(row).find('td:eq(40)').addClass('text-light-' + Class007 + ' bg-' + Class007 + ' fs-7 fw-bold');
                        $(row).find('td:eq(41)').addClass('text-light-' + Class007 + ' bg-' + Class007 + ' fs-7 fw-bold');
                        $(row).find('td:eq(42)').addClass('text-light-' + Class007 + ' bg-' + Class007 + ' fs-7 fw-bold');
                    } else if (Target007 < Today007) {
                        $(row).find('td:eq(40)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(41)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(42)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target006 = new Date(data.Target006);
                    var Today006 = new Date();
                    var Class006 = 'info';
                    if (data.DateSecured006 == '-') {
                        Today006 = new Date();
                        Class006 = 'info';
                    } else {
                        Today006 = new Date(data.DateSecured006);
                        Class006 = 'success';
                    }
                    if (Target006 >= Today006) {
                        $(row).find('td:eq(37)').addClass('text-light-' + Class006 + ' bg-' + Class006 + ' fs-7 fw-bold');
                        $(row).find('td:eq(38)').addClass('text-light-' + Class006 + ' bg-' + Class006 + ' fs-7 fw-bold');
                        $(row).find('td:eq(39)').addClass('text-light-' + Class006 + ' bg-' + Class006 + ' fs-7 fw-bold');
                    } else if (Target006 < Today006) {
                        $(row).find('td:eq(37)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(38)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(39)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target009 = new Date(data.Target009);
                    var Today009 = new Date();
                    var Class009 = 'info';
                    if (data.DateSecured009 == '-') {
                        Today009 = new Date();
                        Class009 = 'info';
                    } else {
                        Today009 = new Date(data.DateSecured009);
                        Class009 = 'success';
                    }
                    if (Target009 >= Today009) {
                        $(row).find('td:eq(34)').addClass('text-light-' + Class009 + ' bg-' + Class009 + ' fs-7 fw-bold');
                        $(row).find('td:eq(35)').addClass('text-light-' + Class009 + ' bg-' + Class009 + ' fs-7 fw-bold');
                        $(row).find('td:eq(36)').addClass('text-light-' + Class009 + ' bg-' + Class009 + ' fs-7 fw-bold');
                    } else if (Target009 < Today009) {
                        $(row).find('td:eq(34)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(35)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(36)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target005 = new Date(data.Target005);
                    var Today005 = new Date();
                    var Class005 = 'info';
                    if (data.DateSecured005 == '-') {
                        Today005 = new Date();
                        Class005 = 'info';
                    } else {
                        Today005 = new Date(data.DateSecured005);
                        Class005 = 'success';
                    }
                    if (Target005 >= Today005) {
                        $(row).find('td:eq(31)').addClass('text-light-' + Class005 + ' bg-' + Class005 + ' fs-7 fw-bold');
                        $(row).find('td:eq(32)').addClass('text-light-' + Class005 + ' bg-' + Class005 + ' fs-7 fw-bold');
                        $(row).find('td:eq(33)').addClass('text-light-' + Class005 + ' bg-' + Class005 + ' fs-7 fw-bold');
                    } else if (Target005 < Today005) {
                        $(row).find('td:eq(31)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(32)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(33)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target013 = new Date(data.Target013);
                    var Today013 = new Date();
                    var Class013 = 'info';
                    if (data.DateSecured013 == '-') {
                        Today013 = new Date();
                        Class013 = 'info';
                    } else {
                        Today013 = new Date(data.DateSecured013);
                        Class013 = 'success';
                    }
                    if (Target013 >= Today013) {
                        $(row).find('td:eq(28)').addClass('text-light-' + Class013 + ' bg-' + Class013 + ' fs-7 fw-bold');
                        $(row).find('td:eq(29)').addClass('text-light-' + Class013 + ' bg-' + Class013 + ' fs-7 fw-bold');
                        $(row).find('td:eq(30)').addClass('text-light-' + Class013 + ' bg-' + Class013 + ' fs-7 fw-bold');
                    } else if (Target013 < Today013) {
                        $(row).find('td:eq(28)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(29)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(30)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target003 = new Date(data.Target003);
                    var Today003 = new Date();
                    var Class003 = 'info';
                    if (data.DateSecured003 == '-') {
                        Today003 = new Date();
                        Class003 = 'info';
                    } else {
                        Today003 = new Date(data.DateSecured003);
                        Class003 = 'success';
                    }
                    if (Target003 >= Today003) {
                        $(row).find('td:eq(25)').addClass('text-light-' + Class003 + ' bg-' + Class003 + ' fs-7 fw-bold');
                        $(row).find('td:eq(26)').addClass('text-light-' + Class003 + ' bg-' + Class003 + ' fs-7 fw-bold');
                        $(row).find('td:eq(27)').addClass('text-light-' + Class003 + ' bg-' + Class003 + ' fs-7 fw-bold');
                    } else if (Target003 < Today003) {
                        $(row).find('td:eq(25)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(26)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(27)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target001 = new Date(data.Target001);
                    var Today001 = new Date();
                    var Class001 = 'info';
                    if (data.DateSecured001 == '-') {
                        Today001 = new Date();
                        Class001 = 'info';
                    } else {
                        Today001 = new Date(data.DateSecured001);
                        Class001 = 'success';
                    }
                    if (Target001 >= Today001) {
                        $(row).find('td:eq(22)').addClass('text-light-' + Class001 + ' bg-' + Class001 + ' fs-7 fw-bold');
                        $(row).find('td:eq(23)').addClass('text-light-' + Class001 + ' bg-' + Class001 + ' fs-7 fw-bold');
                        $(row).find('td:eq(24)').addClass('text-light-' + Class001 + ' bg-' + Class001 + ' fs-7 fw-bold');
                    } else if (Target001 < Today001) {
                        $(row).find('td:eq(22)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(23)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(24)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target012 = new Date(data.Target012);
                    var Today012 = new Date();
                    var Class012 = 'info';
                    if (data.DateSecured012 == '-') {
                        Today012 = new Date();
                        Class012 = 'info';
                    } else {
                        Today012 = new Date(data.DateSecured012);
                        Class012 = 'success';
                    }
                    if (Target012 >= Today012) {
                        $(row).find('td:eq(19)').addClass('text-light-' + Class012 + ' bg-' + Class012 + ' fs-7 fw-bold');
                        $(row).find('td:eq(20)').addClass('text-light-' + Class012 + ' bg-' + Class012 + ' fs-7 fw-bold');
                        $(row).find('td:eq(21)').addClass('text-light-' + Class012 + ' bg-' + Class012 + ' fs-7 fw-bold');
                    } else if (Target012 < Today012) {
                        $(row).find('td:eq(19)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(20)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(21)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target008 = new Date(data.Target008);
                    var Today008 = new Date();
                    var Class008 = 'info';
                    if (data.DateSecured008 == '-') {
                        Today008 = new Date();
                        Class008 = 'info';
                    } else {
                        Today008 = new Date(data.DateSecured008);
                        Class008 = 'success';
                    }
                    if (Target008 >= Today008) {
                        $(row).find('td:eq(16)').addClass('text-light-' + Class008 + ' bg-' + Class008 + ' fs-7 fw-bold');
                        $(row).find('td:eq(17)').addClass('text-light-' + Class008 + ' bg-' + Class008 + ' fs-7 fw-bold');
                        $(row).find('td:eq(18)').addClass('text-light-' + Class008 + ' bg-' + Class008 + ' fs-7 fw-bold');
                    } else if (Target008 < Today008) {
                        $(row).find('td:eq(16)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(17)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(18)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target014 = new Date(data.Target014);
                    var Today014 = new Date();
                    var Class014 = 'info';
                    if (data.DateSecured014 == '-') {
                        Today014 = new Date();
                        Class014 = 'info';
                    } else {
                        Today014 = new Date(data.DateSecured014);
                        Class014 = 'success';
                    }
                    if (Target014 >= Today014) {
                        $(row).find('td:eq(13)').addClass('text-light-' + Class014 + ' bg-' + Class014 + ' fs-7 fw-bold');
                        $(row).find('td:eq(14)').addClass('text-light-' + Class014 + ' bg-' + Class014 + ' fs-7 fw-bold');
                        $(row).find('td:eq(15)').addClass('text-light-' + Class014 + ' bg-' + Class014 + ' fs-7 fw-bold');
                    } else if (Target014 < Today014) {
                        $(row).find('td:eq(13)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(14)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(15)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target002 = new Date(data.Target002);
                    var Today002 = new Date();
                    var Class002 = 'info';
                    if (data.DateSecured002 == '-') {
                        Today002 = new Date();
                        Class002 = 'info';
                    } else {
                        Today002 = new Date(data.DateSecured002);
                        Class002 = 'success';
                    }
                    if (Target002 >= Today002) {
                        $(row).find('td:eq(10)').addClass('text-light-' + Class002 + ' bg-' + Class002 + ' fs-7 fw-bold');
                        $(row).find('td:eq(11)').addClass('text-light-' + Class002 + ' bg-' + Class002 + ' fs-7 fw-bold');
                        $(row).find('td:eq(12)').addClass('text-light-' + Class002 + ' bg-' + Class002 + ' fs-7 fw-bold');
                    } else if (Target002 < Today002) {
                        $(row).find('td:eq(10)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(11)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(12)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }

                    var Target011 = new Date(data.Target011);
                    var Today011 = new Date();
                    var Class011 = 'info';
                    if (data.DateSecured011 == '-') {
                        Today011 = new Date();
                        Class011 = 'info';
                    } else {
                        Today011 = new Date(data.DateSecured011);
                        Class011 = 'success';
                    }
                    if (Target011 >= Today011) {
                        $(row).find('td:eq(7)').addClass('text-light-' + Class011 + ' bg-' + Class011 + ' fs-7 fw-bold');
                        $(row).find('td:eq(8)').addClass('text-light-' + Class011 + ' bg-' + Class011 + ' fs-7 fw-bold');
                        $(row).find('td:eq(9)').addClass('text-light-' + Class011 + ' bg-' + Class011 + ' fs-7 fw-bold');
                    } else if (Target011 < Today011) {
                        $(row).find('td:eq(7)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(8)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(9)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }
                }
            });
            //datatable

            //search
            $('#tbxFindProject').on('keyup', function () {
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
        //load batch

        //View batch
        function bindInfo(Project, No) {
            document.getElementById("lblInfo_Project").innerHTML = Project;
            document.getElementById("lblInfo_No").innerHTML = No;
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = No;

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
            $('#mdlInfo').css('z-index', 1057);
            // show modal
        }

        // Construction Status Modal
        function bindConstructionStatus(Batch, Status) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Construction Status List',
                    'Batch': Batch,
                    'Status': Status
                },
                success: function (response) {
                    DisplayChart(response)
                },
            });
        }

        // Status Per Section Modal
        function bindStatusPerSection(Batch, Status, seriesName) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Status Per Section List',
                    'Batch': Batch,
                    'Status': Status,
                    'seriesName': seriesName
                },
                success: function (response) {
                    DisplayChart(response)
                },
            });
        }

        // Accomplishment Per Section Modal
        function bindAccomplishmentPerSection(Batch, Status, seriesName) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Accomplishment Per Section List',
                    'Batch': Batch,
                    'Status': Status,
                    'seriesName': seriesName
                },
                success: function (response) {
                    DisplayChart(response)
                },
            });
        }

        // Accomplishment Per Contractor Modal
        function bindAccomplishmentPerContractor(Batch, Status, seriesName) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Accomplishment Per Contractor List',
                    'Batch': Batch,
                    'Status': Status,
                    'seriesName': seriesName
                },
                success: function (response) {
                    DisplayChart(response)
                },
            });
        }

        // Overall Batch Status
        function bindOverallBatchStatus(Batch, Status, seriesName) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Overall Batch Status List',
                    'Batch': Batch,
                    'Status': Status,
                    'seriesName': seriesName
                },
                success: function (response) {
                    console.log(response)
                    DisplayChart(response)
                },
            });
        }

        // Chart Modal
        function DisplayChart(response) {
            // Destroy any existing DataTable instance to avoid conflicts
            if ($.fn.DataTable.isDataTable("#gvStatus")) {
                $("#gvStatus").DataTable().clear().destroy();
            }

            $("#gvStatus").DataTable({
                bFilter: true,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
                scrollX: true,
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
                    { data: 'Target' },
                    { data: 'Status' },
                    { data: 'DateSecured' }],
                columnDefs: [
                    {
                        targets: [8],
                        render: function (data, type, row, meta) {
                            if (type === 'display') {
                                var label = '';
                                if (data === '') {
                                    label = 'badge-hc-new';
                                } else if (data === 'Not Started') {
                                    label = 'badge-hc-new';
                                } else if (data === 'Assign') {
                                    label = 'badge-hc-new';
                                } else if (data === 'On-Going') {
                                    label = 'badge-hc-ongoing';
                                } else if (data === 'On-Hold') {
                                    label = 'badge-hc-onhold';
                                } else if (data === 'Clarify') {
                                    label = 'badge-hc-clarify';
                                } else if (data === 'Complete') {
                                    label = 'badge-hc-complete';
                                } else if (data === 'Close') {
                                    label = 'badge-hc-complete';
                                }
                                return '<span class="badge ' + label + '">' + data + '</span>';
                            }
                            return data;
                        }
                    }
                ],
                rowCallback: function (row, data, index) {
                    var Target = new Date(data.Target);
                    var Today = new Date();
                    var Class = 'info';
                    if (data.DateSecured == '-') {
                        Today = new Date();
                        Class = 'info';
                    } else {
                        Today = new Date(data.DateSecured);
                        Class = 'success';
                    }
                    if (Target >= Today) {
                        $(row).find('td:eq(7)').addClass('text-light-' + Class + ' bg-' + Class + ' fs-7 fw-bold');
                        $(row).find('td:eq(8)').addClass('text-light-' + Class + ' bg-' + Class + ' fs-7 fw-bold');
                        $(row).find('td:eq(9)').addClass('text-light-' + Class + ' bg-' + Class + ' fs-7 fw-bold');
                    } else if (Target < Today) {
                        $(row).find('td:eq(7)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(8)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                        $(row).find('td:eq(9)').addClass('text-light-danger bg-danger fs-7 fw-bold');
                    }
                }
            });
        }

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {

            jQuery(function ($) {
                var hfPostback = $('#<%= hfPostback.ClientID %>');
                if (hfPostback.val() == "true") {

                    //initial load
                    $.ajax({
                        type: "POST",
                        url: "HNDDSB.ashx",
                        data: {
                            'FormCode': 'DSB080000',
                            'Type': 'Project',
                            'Batch': '-'
                        },
                        success: function (response) {
                            Display(response)
                        },
                    });
                    function Display(response) {
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //datatable
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
                                { data: 'DateSecured010' }],
                            columnDefs: [
                                {
                                    targets: [8, 11, 14, 17, 20, 23, 26, 29, 32, 35, 38, 41, 44],
                                    render: function (data, type, row, meta) {
                                        if (type === 'display') {
                                            var label = '';
                                            if (data === '') {
                                                label = 'badge-hc-new';
                                            } else if (data === 'Not Started') {
                                                label = 'badge-hc-new';
                                            } else if (data === 'Assign') {
                                                label = 'badge-hc-new';
                                            } else if (data === 'On-Going') {
                                                label = 'badge-hc-ongoing';
                                            } else if (data === 'On-Hold') {
                                                label = 'badge-hc-onhold';
                                            } else if (data === 'Clarify') {
                                                label = 'badge-hc-clarify';
                                            } else if (data === 'Complete') {
                                                label = 'badge-hc-complete';
                                            } else if (data === 'Close') {
                                                label = 'badge-hc-complete';
                                            }
                                            return '<span class="badge ' + label + '">' + data + '</span>';
                                        }
                                        return data;
                                    }
                                }
                            ],
                        });
                        //datatable
                        //search
                        $('#tbxFindProject').on('keyup', function () {
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
                    //initial load

                    //combobox
                    $('[data-kt-repeater="select2"]').select2();
                    //combobox

                    //menu
                    KTMenu.createInstances();
                    //menu
                }

                hfPostback.val("false");


            });
        }
        //load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
