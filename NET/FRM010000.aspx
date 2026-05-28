<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM010000.aspx.vb" Inherits="NET.FRM010000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Form</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white"><span id="spn00Total" runat="server">You have 253 tasks</span></li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
                <!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" data-bs-toggle="modal" data-bs-target="#mdl02FRM">Create</a>
					<!--end::Button-->
				</div>
				<!--end::Actions-->
			</div>
			<!--begin::Container-->
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
							<span class="card-label fw-bolder text-dark">Forms</span>
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
						<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2 position-relative" onclick="fn01New()" title="Newly Assigned Forms">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
							<i class="las la-inbox fs-3"></i>
	                        <!--end::Svg Icon-->
							<span id="blink01New" runat="server" class="bullet bullet-dot bg-warning h-8px w-8px position-absolute translate-middle top-0 start-50 animation-blink" style="display:none"></span>
                        </button>
						<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2" onclick="fn01Subscribed()" title="Subsription">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-bell fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
						<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2" onclick="fn01Approved()" title="Approved Form(s)">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-flag fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2" onclick="fn01Request()" title="My Request">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-archive fs-3"></i>
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
				<asp:UpdatePanel ID="upnl01Form" runat="server" UpdateMode="Conditional" class="border rounded" style="min-height:62.3vh;">
				<ContentTemplate>
					<table id="gv01Form" class="table table-row-bordered gy-2 gs-2 w-100">
						<thead>
							<tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
								<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
								<th class="min-w-200px w-100 fw-bold border-end">Title</th>
								<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
								<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
								<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
								<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
								<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
							</tr>
							<tr id="tr01Filter" class="fs-7" style="display:none">
								<td class="border-end"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
								<td class="border-end"><input id="tbx01Find06" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							</tr>
						</thead>
						<tbody id="tbody01Form" runat="server">
							
						</tbody>
					</table>
				</ContentTemplate>
				</asp:UpdatePanel>
				<!--end::Files-->
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->

        <!--begin::Modal New Form-->
		<div id="mdl02FRM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_GEN()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/GEN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">General</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_PDD()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Project Development</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_ENG()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Engineering</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_SLS()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_AAD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AAD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_FIN()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/FIN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Finance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_SCM()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/SCM.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Supply Chain Management</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_HRA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/HRA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Human Resources Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_CSD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_BTD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/BTD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech.</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_ILA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/ILA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Investment and Land Acquisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form-->

		<!--begin::Modal New Form > GEN-->
		<div id="mdl02FRM_GEN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > General</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000001-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000037-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order (Contract)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > GEN-->

		<!--begin::Modal New Form > PDD-->
		<div id="mdl02FRM_PDD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Project Development</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000027-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000043-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000043.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Holding Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > PDD-->
		
		<!--begin::Modal New Form > ENG-->
		<div id="mdl02FRM_ENG" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Engineering</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000019-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000019.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Approval</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000020-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000020.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Information</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000021-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000021.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Site Instruction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000036-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000036.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Survey Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000038-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000038.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Notice of Delay</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000039-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000039.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Non Conformance Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000022-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000022.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Construction Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000023-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000023.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electrical Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000024-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000024.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request for RFO Keys</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000013-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Occupancy Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000025-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000025.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > ENG-->
		
		<!--begin::Modal New Form > SLS-->
		<div id="mdl02FRM_SLS" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Sales</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000028-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000028.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000029-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000029.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Request Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > SLS-->
		
		<!--begin::Modal New Form > AAD-->
		<div id="mdl02FRM_AAD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Accounts Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000030-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000030.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Activity Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000031-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000031.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Cash Remittance Verification Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000032-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transfer of Title Routing Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000042-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000042.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT-HDMF DOA Annotation Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > AAD-->
		
		<!--begin::Modal New Form > FIN-->
		<div id="mdl02FRM_FIN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Finance</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000018-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000018.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Capital Expenditure Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000015-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000033-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000033.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Billing</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000017-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000017.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payment Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000016-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000016.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Petty Cash</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > FIN-->
		
		<!--begin::Modal New Form > SCM-->
		<div id="mdl02FRM_SCM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Supply Chain Management</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000009-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000010-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Purchase Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > SCM-->
		
		<!--begin::Modal New Form > HRA-->
		<div id="mdl02FRM_HRA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Human Resources Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000003-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000003.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Off</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000004-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000004.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Shift</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000005-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000005.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Leave of Absence</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000006-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000006.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Out of Office Work</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000007-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000007.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Undertime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000008-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000008.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000034-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000034.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Job Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000035-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000035.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Conference Room Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000040-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000040.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Personnel Requisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > HRA-->
		
		<!--begin::Modal New Form > CSD-->
		<div id="mdl02FRM_CSD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Customer Service</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000011-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000011.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000012-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000012.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Service Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000014-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000014.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transaction Log</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > CSD-->
		
		<!--begin::Modal New Form > BTD-->
		<div id="mdl02FRM_BTD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Business Tech.</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000002-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000002.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech. Support</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > BTD-->
		
		<!--begin::Modal New Form > ILA-->
		<div id="mdl02FRM_ILA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Investment and Land Acquisition</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000026-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000026.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Rawland Documents Turn-over</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > ILA-->
		
		<!--begin::Modal New Assigned-->
		<div id="mdl03New" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Newly Assigned Forms</h5>
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
						            <input id="tbx03Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					            </div>
					            <!--end::Search-->
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
							<table id="table03New" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
									</tr>
									</thead>
								<tbody id="tbody03New">
									
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Assigned-->
		
		<!--begin::Modal Subscribed-->
		<div id="mdl04Subscribed" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Subscribed Forms</h5>
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
							<table id="table04Subscribed" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
									</tr>
								</thead>
								<tbody id="tbody04Subscribed">
									
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Subscribed-->
		
        <!--begin::Modal Request-->
		<div id="mdl05Request" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s)</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_GEN()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/GEN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">General</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_PDD()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Project Development</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_ENG()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Engineering</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_SLS()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_AAD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AAD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_FIN()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/FIN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Finance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_SCM()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/SCM.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Supply Chain Management</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_HRA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/HRA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Human Resources Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_CSD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_BTD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/BTD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech.</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request_ILA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/ILA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Investment and Land Acquisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request-->
		
		<!--begin::Modal Request Form > GEN-->
		<div id="mdl05Request_GEN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > General</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000001')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000037')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order (Contract)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > GEN-->

		<!--begin::Modal Request Form > PDD-->
		<div id="mdl05Request_PDD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Project Development</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000027')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > PDD-->
		
		<!--begin::Modal Request Form > ENG-->
		<div id="mdl05Request_ENG" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Engineering</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000019')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000019.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Approval</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000020')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000020.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Information</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000021')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000021.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Site Instruction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000036')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000036.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Survey Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000038')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000038.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Notice of Delay</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000039')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000039.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Non Conformance Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000022')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000022.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Construction Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000023')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000023.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electrical Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000024')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000024.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request for RFO Keys</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000013')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Occupancy Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000025')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000025.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > ENG-->
		
		<!--begin::Modal Request Form > SLS-->
		<div id="mdl05Request_SLS" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Sales</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000028')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000028.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000029')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000029.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Request Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > SLS-->
		
		<!--begin::Modal Request Form > AAD-->
		<div id="mdl05Request_AAD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Accounts Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000030')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000030.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Activity Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000031')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000031.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Cash Remittance Verification Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000032')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transfer of Title Routing Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000042')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000042.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT-HDMF DOA Annotation Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > AAD-->
		
		<!--begin::Modal Request Form > FIN-->
		<div id="mdl05Request_FIN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Finance</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000018')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000018.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Capital Expenditure Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000015')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000033')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000033.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Billing</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000017')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000017.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payment Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000016')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000016.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Petty Cash</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > FIN-->
		
		<!--begin::Modal Request Form > SCM-->
		<div id="mdl05Request_SCM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Supply Chain Management</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000009')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000010')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Purchase Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > SCM-->
		
		<!--begin::Modal Request Form > HRA-->
		<div id="mdl05Request_HRA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Human Resources Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000003')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000003.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Off</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000004')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000004.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Shift</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000005')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000005.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Leave of Absence</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000006')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000006.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Out of Office Work</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000007')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000007.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Undertime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000008')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000008.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000034')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000034.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Job Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000035')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000035.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Conference Room Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000040')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000040.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Personnel Requisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > HRA-->
		
		<!--begin::Modal Request Form > CSD-->
		<div id="mdl05Request_CSD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Customer Service</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000011')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000011.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000012')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000012.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Service Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000014')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000014.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transaction Log</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > CSD-->
		
		<!--begin::Modal Request Form > BTD-->
		<div id="mdl05Request_BTD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Business Tech.</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000002')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000002.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech. Support</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > BTD-->
		
		<!--begin::Modal Request Form > ILA-->
		<div id="mdl05Request_ILA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Request Form(s) > Investment and Land Acquisition</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn05Request('FRM000026')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000026.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Rawland Documents Turn-over</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request Form > ILA-->
		
        <!--begin::Modal Request - Form-->
		<div id="mdl05Request_Form" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header d-flex justify-content-between">
                        <div>
						    <h5 class="modal-title"><span id="span05RequestForm"></span></h5>
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
						            <input id="tbx05Find_RequestForm" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					            </div>
					            <!--end::Search-->
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
							<table id="table05RequestForm" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
                                    <tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Assigned To</th>
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
		<!--begin::Modal Request - Form-->
		
        <!--begin::Modal Approved-->
		<div id="mdl06Approved" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s)</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_GEN()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/GEN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">General</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_PDD()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Project Development</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_ENG()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Engineering</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_SLS()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_AAD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AAD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_FIN()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/FIN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Finance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_SCM()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/SCM.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Supply Chain Management</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_HRA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/HRA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Human Resources Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_CSD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_BTD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/BTD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech.</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved_ILA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/ILA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Investment and Land Acquisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved-->
		
		<!--begin::Modal Approved Form > GEN-->
		<div id="mdl06Approved_GEN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > General</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000001')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000037')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order (Contract)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > GEN-->

		<!--begin::Modal Approved Form > PDD-->
		<div id="mdl06Approved_PDD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Project Development</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000027')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > PDD-->
		
		<!--begin::Modal Approved Form > ENG-->
		<div id="mdl06Approved_ENG" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Engineering</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000019')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000019.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Approval</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000020')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000020.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Information</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000021')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000021.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Site Instruction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000036')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000036.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Survey Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000038')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000038.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Notice of Delay</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000039')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000039.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Non Conformance Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000022')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000022.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Construction Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000023')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000023.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electrical Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000024')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000024.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request for RFO Keys</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000013')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Occupancy Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000025')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000025.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > ENG-->
		
		<!--begin::Modal Approved Form > SLS-->
		<div id="mdl06Approved_SLS" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Sales</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000028')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000028.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000029')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000029.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Request Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > SLS-->
		
		<!--begin::Modal Approved Form > AAD-->
		<div id="mdl06Approved_AAD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Accounts Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000030')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000030.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Activity Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000031')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000031.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Cash Remittance Verification Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000032')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transfer of Title Routing Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000042')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000042.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT-HDMF DOA Annotation Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > AAD-->
		
		<!--begin::Modal Approved Form > FIN-->
		<div id="mdl06Approved_FIN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Finance</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000018')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000018.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Capital Expenditure Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000015')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000033')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000033.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Billing</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000017')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000017.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payment Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000016')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000016.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Petty Cash</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > FIN-->
		
		<!--begin::Modal Approved Form > SCM-->
		<div id="mdl06Approved_SCM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Supply Chain Management</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000009')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000010')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Purchase Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > SCM-->
		
		<!--begin::Modal Approved Form > HRA-->
		<div id="mdl06Approved_HRA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Human Resources Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000003')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000003.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Off</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000004')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000004.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Shift</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000005')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000005.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Leave of Absence</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000006')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000006.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Out of Office Work</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000007')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000007.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Undertime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000008')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000008.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000034')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000034.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Job Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000035')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000035.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Conference Room Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000040')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000040.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Personnel Requisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > HRA-->
		
		<!--begin::Modal Approved Form > CSD-->
		<div id="mdl06Approved_CSD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Customer Service</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000011')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000011.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000012')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000012.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Service Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000014')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000014.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transaction Log</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > CSD-->
		
		<!--begin::Modal Approved Form > BTD-->
		<div id="mdl06Approved_BTD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Business Tech.</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000002')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000002.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech. Support</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > BTD-->
		
		<!--begin::Modal Approved Form > ILA-->
		<div id="mdl06Approved_ILA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Approved Form(s) > Investment and Land Acquisition</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="#" class="text-gray-800 d-flex flex-column pointer" onclick="fn06Approved('FRM000026')">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000026.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Rawland Documents Turn-over</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Approved Form > ILA-->
		
        <!--begin::Modal Approved - Form-->
		<div id="mdl06Approved_Form" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header d-flex justify-content-between">
                        <div>
						    <h5 class="modal-title"><span id="span06ApprovedForm"></span></h5>
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
						            <input id="tbx06Find_ApprovedForm" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					            </div>
					            <!--end::Search-->
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
							<table id="table06ApprovedForm" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
                                    <tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Approved">Date Approved</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
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
		<!--begin::Modal Approved - Form-->

    </div>
    <!--content-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">

		//refresh
		function FRMUpdate(ID) {
			//update counter
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'Counter'
                },
				success: function (response) {
                    var spn00Total = document.getElementById("ContentPlaceHolder1_spn00Total");
					var spn01Total = document.getElementById("ContentPlaceHolder1_spn01Total");
					var blink01New = document.getElementById("ContentPlaceHolder1_blink01New");
					spn00Total.innerText = "You have " + response[0].Total + " assigned form(s)";
                    spn01Total.innerText = response[0].Total + " total assigned form(s)";
					if (response[0].New == "0") {
						blink01New.style.display = "none";
					} else {
                        blink01New.style.display = "";
					}
                },
            });
			//update list
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
					'Type': 'Update',
                    'ID': ID
                },
				success: function (response) {
					if (response[0].Action == "Update") {
						//assigned
                        if (document.getElementById("tr01" + ID) != null) {
							var gv01 = $('#gv01Form').DataTable();
                            let row01 = gv01.row('#tr01' + ID);
                            let index01 = row01.index();  
                            gv01.cell({ row: index01, column: 0 }).data(response[0].col00).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].col01).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].col02).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].col03).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].col04).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].col05).draw(false);
							gv01.cell({ row: index01, column: 6 }).data(response[0].col06).draw(false);
						} else {
                            var gv01 = $('#gv01Form').DataTable();
                            var row01Data = [response[0].col00, response[0].col01, response[0].col02, response[0].col03, response[0].col04, response[0].col05, response[0].col06];
                            var row01ID = 'tr01' + ID;
                            var row01 = gv01.row.add(row01Data).draw();
                            $(row01.node()).attr('id', row01ID);
						}
						//new
                        if (document.getElementById("tr03" + ID) != null) {
                            var gv03 = $('#table03New').DataTable();
                            let row03 = gv03.row('#tr03' + ID);
                            let index03 = row03.index();
                            gv03.cell({ row: index03, column: 0 }).data(response[0].col00).draw(false);
                            gv03.cell({ row: index03, column: 1 }).data(response[0].col01).draw(false);
                            gv03.cell({ row: index03, column: 2 }).data(response[0].col02).draw(false);
                            gv03.cell({ row: index03, column: 3 }).data(response[0].col03).draw(false);
                            gv03.cell({ row: index03, column: 4 }).data(response[0].col04).draw(false);
                            gv03.cell({ row: index03, column: 5 }).data(response[0].col05).draw(false);
                            gv03.cell({ row: index03, column: 6 }).data(response[0].col06).draw(false);
						}
						//subscribed
                        if (document.getElementById("tr04" + ID) != null) {
                            var gv04 = $('#table04Subscribed').DataTable();
                            let row04 = gv04.row('#tr04' + ID);
                            let index04 = row04.index();
                            gv04.cell({ row: index04, column: 0 }).data(response[0].col00).draw(false);
                            gv04.cell({ row: index04, column: 1 }).data(response[0].col01).draw(false);
                            gv04.cell({ row: index04, column: 2 }).data(response[0].col02).draw(false);
                            gv04.cell({ row: index04, column: 3 }).data(response[0].col03).draw(false);
                            gv04.cell({ row: index04, column: 4 }).data(response[0].col04).draw(false);
                            gv04.cell({ row: index04, column: 5 }).data(response[0].col05).draw(false);
                            gv04.cell({ row: index04, column: 6 }).data(response[0].col06).draw(false);
						}
						//request
                        if (document.getElementById("tr05" + ID) != null) {
                            var gv05 = $('#table05Request').DataTable();
                            let row05 = gv05.row('#tr05' + ID);
                            let index05 = row05.index();
                            gv05.cell({ row: index05, column: 0 }).data(response[0].col00).draw(false);
                            gv05.cell({ row: index05, column: 1 }).data(response[0].col01).draw(false);
                            gv05.cell({ row: index05, column: 2 }).data(response[0].col02).draw(false);
                            gv05.cell({ row: index05, column: 3 }).data(response[0].col03).draw(false);
                            gv05.cell({ row: index05, column: 4 }).data(response[0].col04).draw(false);
                            gv05.cell({ row: index05, column: 5 }).data(response[0].col05).draw(false);
                            gv05.cell({ row: index05, column: 6 }).data(response[0].col06).draw(false);
                        }
					} else {
						//assigned
                        var gv01 = $('#gv01Form').DataTable();
						gv01.row('#tr01' + ID).remove().draw(false);
						//new
                        var gv03 = $('#table03New').DataTable();
						gv03.row('#tr03' + ID).remove().draw(false);
						//subscribed
                        var gv04 = $('#table04Subscribed').DataTable();
                        let row04 = gv04.row('#tr04' + ID);
                        let index04 = row04.index();
                        gv04.cell({ row: index04, column: 0 }).data(response[0].col00).draw(false);
                        gv04.cell({ row: index04, column: 1 }).data(response[0].col01).draw(false);
                        gv04.cell({ row: index04, column: 2 }).data(response[0].col02).draw(false);
                        gv04.cell({ row: index04, column: 3 }).data(response[0].col03).draw(false);
                        gv04.cell({ row: index04, column: 4 }).data(response[0].col04).draw(false);
                        gv04.cell({ row: index04, column: 5 }).data(response[0].col05).draw(false);
						gv04.cell({ row: index04, column: 6 }).data(response[0].col06).draw(false);
                        //request
                        var gv05 = $('#table05Request').DataTable();
                        let row05 = gv05.row('#tr05' + ID);
                        let index05 = row05.index();
                        gv05.cell({ row: index05, column: 0 }).data(response[0].col00).draw(false);
                        gv05.cell({ row: index05, column: 1 }).data(response[0].col01).draw(false);
                        gv05.cell({ row: index05, column: 2 }).data(response[0].col02).draw(false);
                        gv05.cell({ row: index05, column: 3 }).data(response[0].col03).draw(false);
                        gv05.cell({ row: index05, column: 4 }).data(response[0].col04).draw(false);
                        gv05.cell({ row: index05, column: 5 }).data(response[0].col05).draw(false);
                        gv05.cell({ row: index05, column: 6 }).data(response[0].col06).draw(false);
					}
                },
            });
		}

		//create form
        function FRM_GEN() {
            $('#mdl02FRM_GEN').modal('show');
        }
        function FRM_PDD() {
            $('#mdl02FRM_PDD').modal('show');
        }
        function FRM_ENG() {
            $('#mdl02FRM_ENG').modal('show');
        }
        function FRM_SLS() {
            $('#mdl02FRM_SLS').modal('show');
        }
        function FRM_AAD() {
            $('#mdl02FRM_AAD').modal('show');
        }
        function FRM_FIN() {
            $('#mdl02FRM_FIN').modal('show');
        }
        function FRM_SCM() {
            $('#mdl02FRM_SCM').modal('show');
        }
        function FRM_HRA() {
            $('#mdl02FRM_HRA').modal('show');
        }
        function FRM_CSD() {
            $('#mdl02FRM_CSD').modal('show');
        }
        function FRM_BTD() {
            $('#mdl02FRM_BTD').modal('show');
        }
		function FRM_ILA() {
			$('#mdl02FRM_ILA').modal('show');
		}
		//create form

		//newly assigned form
		function fn01New() {
			//initial load
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'List-New'
                },
                success: function (response) {
					var tbody03New = document.getElementById("tbody03New");
					tbody03New.innerHTML = response;
                    $('#table03New').DataTable().destroy();
					Display()
                },
            });
			function Display() {
				//disable column type detection
                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });
                //disable column type detection

                //sort date by yyyy/mm/dd
                $.fn.dataTable.moment('MM/DD/YYYY');
				//sort date by yyyy/mm/dd

                //datatable
                var table03New = $("#table03New").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bInfo: false,
					scrollCollapse: true,
                    scrollX: true,
                    paging: false,
                    lengthChange: false,
                    
					select: false,
                    columnDefs: [
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
                $('#tbx03Find').on('keyup', function () {
                    table03New.search(this.value).draw();
                });
                //search

                $('#mdl03New').modal('show');
			}
			//initial load
		}
		//newly assigned form

        //newly Subscribed
        function fn01Subscribed() {
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'List-Subscribed'
                },
                success: function (response) {
                    var tbody04Subscribed = document.getElementById("tbody04Subscribed");
                    tbody04Subscribed.innerHTML = response;
                    $('#table04Subscribed').DataTable().destroy();
                    Display()
                },
            });
			function Display() {

                //disable column type detection
                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });
                //disable column type detection

                //sort date by yyyy/mm/dd
                $.fn.dataTable.moment('MM/DD/YYYY');
                //sort date by yyyy/mm/dd

                //datatable
                var table04Subscribed = $("#table04Subscribed").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bDestroy: true,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollX: true,
                    paging: false,
                    lengthChange: false,
                    
                    select: false,
                    columnDefs: [
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
                $('#tbx04Find').on('keyup', function () {
                    table04Subscribed.search(this.value).draw();
                });
                //search

                $('#mdl04Subscribed').modal('show');
            }
            //initial load
        }
		//newly Subscribed

		//approved
        function fn01Approved() {
            $('#mdl06Approved').modal('show');
		}
        function fn06Approved_GEN() {
            $('#mdl06Approved_GEN').modal('show');
        }
        function fn06Approved_PDD() {
            $('#mdl06Approved_PDD').modal('show');
        }
        function fn06Approved_ENG() {
            $('#mdl06Approved_ENG').modal('show');
        }
        function fn06Approved_SLS() {
            $('#mdl06Approved_SLS').modal('show');
        }
        function fn06Approved_AAD() {
            $('#mdl06Approved_AAD').modal('show');
        }
        function fn06Approved_FIN() {
            $('#mdl06Approved_FIN').modal('show');
        }
        function fn06Approved_SCM() {
            $('#mdl06Approved_SCM').modal('show');
        }
        function fn06Approved_HRA() {
            $('#mdl06Approved_HRA').modal('show');
        }
        function fn06Approved_CSD() {
            $('#mdl06Approved_CSD').modal('show');
        }
        function fn06Approved_BTD() {
            $('#mdl06Approved_BTD').modal('show');
        }
        function fn06Approved_ILA() {
            $('#mdl06Approved_ILA').modal('show');
		}
        function fn06Approved(FormType) {
			//title
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'Form - Name',
                    'FormType': FormType
                },
                success: function (response) {
                    var span06ApprovedForm = document.getElementById('span06ApprovedForm');
                    span06ApprovedForm.innerText = "Approved " + response[0].FormName ;
                },
            });
            //title
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'Approved - Form',
                    'FormType': FormType
                },
                success: function (response) {
                    Display(response);
                },
            });
            function Display(response) {
                //destroy to reinitialize
                $('#table06ApprovedForm').DataTable().destroy();
                //destroy to reinitialize

                //disable column type detection
                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });
                //disable column type detection

                //sort date by yyyy/mm/dd
                $.fn.dataTable.moment('MM/DD/YYYY');
                //sort date by yyyy/mm/dd

                //datatable
                var table06ApprovedForm = $("#table06ApprovedForm").DataTable({
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
                        { data: 'Link' },
                        { data: 'Title' },
                        { data: 'Type' },
                        { data: 'DateExpected' },
                        { data: 'DateApproved' },
                        { data: 'Status' },
                        { data: 'RequestedBy' }],
                    rowId: 'ID',
                    orderCellsTop: true
                });
                //datatable

                //search
                $('#tbx06Find_ApprovedForm').on('keyup', function () {
                    table06ApprovedForm.search(this.value).draw();
                });
                //search

                $('#mdl06Approved_Form').modal('show');
            };
        }
		//approved

        //newly Request
        function fn01Request() {
            $('#mdl05Request').modal('show');
        }
        function fn05Request_GEN() {
            $('#mdl05Request_GEN').modal('show');
        }
        function fn05Request_PDD() {
            $('#mdl05Request_PDD').modal('show');
        }
        function fn05Request_ENG() {
            $('#mdl05Request_ENG').modal('show');
        }
        function fn05Request_SLS() {
            $('#mdl05Request_SLS').modal('show');
        }
        function fn05Request_AAD() {
            $('#mdl05Request_AAD').modal('show');
        }
        function fn05Request_FIN() {
            $('#mdl05Request_FIN').modal('show');
        }
        function fn05Request_SCM() {
            $('#mdl05Request_SCM').modal('show');
        }
        function fn05Request_HRA() {
            $('#mdl05Request_HRA').modal('show');
        }
        function fn05Request_CSD() {
            $('#mdl05Request_CSD').modal('show');
        }
        function fn05Request_BTD() {
            $('#mdl05Request_BTD').modal('show');
        }
        function fn05Request_ILA() {
            $('#mdl05Request_ILA').modal('show');
        }
        function fn05Request(FormType) {
            //title
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'Form - Name',
                    'FormType': FormType
                },
                success: function (response) {
                    var span05RequestForm = document.getElementById('span05RequestForm');
                    span05RequestForm.innerText = "Request " + response[0].FormName;
                },
            });
            //title
            $.ajax({
                type: "POST",
                url: "HNDFRM.ashx",
                data: {
                    'FormCode': 'FRM010000',
                    'Type': 'Request - Form',
                    'FormType': FormType
                },
                success: function (response) {
                    Display(response);
                },
            });
            function Display(response) {
                //destroy to reinitialize
                $('#table05RequestForm').DataTable().destroy();
                //destroy to reinitialize

                //disable column type detection
                DataTable.types().forEach(type => {
                    DataTable.type(type, 'detect', () => false);
                });
                //disable column type detection

                //sort date by yyyy/mm/dd
                $.fn.dataTable.moment('MM/DD/YYYY');
                //sort date by yyyy/mm/dd

                //datatable
                var table05RequestForm = $("#table05RequestForm").DataTable({
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
                        { data: 'Link' },
                        { data: 'Title' },
                        { data: 'Type' },
                        { data: 'DateRequired' },
                        { data: 'DateExpected' },
                        { data: 'Status' },
                        { data: 'RequestedBy' }],
                    rowId: 'ID',
                    orderCellsTop: true
                });
                //datatable

                //search
                $('#tbx05Find_RequestForm').on('keyup', function () {
                    table05RequestForm.search(this.value).draw();
                });
                //search

                $('#mdl05Request_Form').modal('show');
            };
        }
		//newly Request

		//fixed column header alignment
		$(document).ready(function () {
            $('#mdl03New').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
			$('#mdl04Subscribed').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
			});
            $('#mdl05Request_Form').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
			});
            $('#mdl06Approved_Form').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
		});
       //fixed column header alignment

		//filter form
		function btn01Filter() {
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
		//filter form

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
                    var gv01Form = $("#gv01Form").DataTable({
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
                        columnDefs: [
                            {
                                targets: 1,
                                className: 'tbody-nowrap-auto'
                            },
                            {
                                targets: 6,
                                className: 'tbody-nowrap-150px'
                            }
						],
						orderCellsTop: true,
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
                    $('#tbx01Find05').on('keyup', function () {
                        gv01Form.columns(5).search(this.value).draw();
                    });
                    $('#tbx01Find06').on('keyup', function () {
                        gv01Form.columns(6).search(this.value).draw();
                    });
                    //filter

                    //export
                    const documentTitle = 'Assigned Forms';
                    var buttons = new $.fn.dataTable.Buttons(gv01Form, {
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

					//stop loading
					isPostBack = true;
					//stop loading
				}
            });
        }
		//load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
