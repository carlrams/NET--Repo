<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="PDD050100.aspx.vb" Inherits="NET.PDD050100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--begin::Content-->
    <div class="content flex-row-fluid" id="kt_content">
        
		<!--begin::breadcrumb bar-->
		<div class="toolbar py-5">
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
						<li class="breadcrumb-item text-white">House Assignment</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		<!--end::breadcrumb bar-->
		
		<!--begin::title-->
		<div class="card card-flush">
			<!--begin::title-->
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/PDD050000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn0101Title">-</span></h2>
						<div class="text-muted fw-bolder">
							<span id="spn0101Status">-</span>
						</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--begin::title-->
			<div class="card-body pt-3 pb-0">
				<div class="d-flex flex-stack">
					<!--begin::Navs-->
					<div class="d-flex overflow-auto">
						<ul id="ul0101Nav" class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
							<!--begin::Nav item-->
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary active" title="Overview" data-bs-toggle="tab" href="#tab0101Overview"><i class="las la-file-alt fs-3x"></i></a>
							</li>
							<!--end::Nav item-->
						</ul>
					</div>
					<!--begin::Navs-->
				</div>
			</div>
			<!--begin::Content-->
			<div class="card" >
				<div class="tab-content" >
					<div class="tab-pane fade show active" id="tab0101Overview">
						<!--begin::Menu Content-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Overview</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex flex-wrap">
									<button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>

									<button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Add" ><i class="las la-plus fs-2"></i></button>
                                        <div id="" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
				                            <div class="menu-item px-3">
                                                <a onclick="fn0101Add();return false;" class="menu-link px-3">Add Model House</a>
                                                <a id="a0103UploadRecord" onclick="return false;" class="menu-link px-3">Upload Record</a>
                                            </div>
                                        </div>

									<button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1 d-none" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
									<button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<div class="form-check form-check-custom form-check-success form-check-solid form-check-lg m-1">
										<input class="form-check-input" type="checkbox" value="" id="cbx0101Lock" onclick="return false;"/>
									</div>
									<button id="btn0101Lock" class="btn btn-sm btn-icon btn-lock align-self-center m-1" title="Lock" onclick="fn0101Lock();return false;"><i class="las la-lock fs-2"></i></button>
									<button id="btn0101Unlock" class="btn btn-sm btn-icon btn-lock align-self-center m-1" title="Unlock" onclick="fn0101Unlock();return false;"><i class="las la-unlock fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
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
                                            <input id="tbx0101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
                            </div>
                            <!--end::Card header-->
							<!--begin::Files-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0101Record" class="table-loading-message">
										Loading...
									</div>
									<table id="table0101Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>

										</thead>
										<tbody>
						
										</tbody>
									</table>
								</div>
							</div>
							<!--end::Files-->
						</div>
						<!--end::particular-->

							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">
								<div class="row g-2">
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Updated By</span>
                                            <span id="lbl0101UpdatedByName" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <span id="lbl0101UpdatedDate" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Locked By</span>
                                            <span id="lbl0101LockedByName" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <span id="lbl0101LockedDate" class="form-control">-</span>
                                        </div>
                                    </div>
								</div>
							</div>
							<div id="div0101Update" class="card-body" style="display:none">
								<div class="row g-2">
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Updated By</span>
                                            <input id="tbx0101UpdatedByName" type="text" class="form-control" Placeholder="Updated By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101UpdatedDate" type="text" class="form-control" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Locked By</span>
                                            <input id="tbx0101LockedByName" type="text" class="form-control" Placeholder="Locked By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101LockedDate" type="text" class="form-control" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
								</div>
							</div>
							<!--end::Dtl-->
						</div>
						<!--end::Menu Content-->

						<!--begin::attachment-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Attachment</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
                                <div class="d-flex align-items-center">
				                    <button id="btn0201Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="return false;"><i class="las la-upload fs-2"></i></button>
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
                                            <input id="tbx0201FindAttachment" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div class="card-body table-loading table-responsive">
								<div id="div0201LoaderAttachment" class="table-loading-message">
									Loading...
								</div>
								<table id="table0201Attachment" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
									<thead>
										<tr class="fw-bold fs-7 text-gray-800">
											<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
											<th class="min-w-60px mw-60px fw-bold border-end">Type</th>
											<th class="min-w-200px w-100 fw-bold">Name</th>
											<th class="min-w-200px mw-200px fw-bold">By</th>
											<th class="min-w-200px mw-200px fw-bold">Date</th>
										</tr>
									</thead>
									<tbody>

									</tbody>
								</table>
							</div>
							<!--end::Dtl-->
						</div>
						<!--begin::attachment-->
                        
						<!--begin::notes-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Notes</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex align-items-center">
									<button id="btn0301Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0301Add();return false;"><i class="las la-comment fs-2"></i></button>
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
				                            <input id="tbx0301FindNotes" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0301LoaderNotes" class="table-loading-message">
										Loading...
									</div>
									<table id="table0301Notes" class="table gy-2 gs-2 w-100 align-middle">
										<thead style="display:none">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-100px w-100">Notes</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
								</div>
							</div>
							<!--end::Dtl-->
						</div>
						<!--end::notes-->

					</div>
			</div>
		</div>
		<!--end::title-->

		<!--begin::Modal Upload-->
		<div id="mdl0203Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Model House - Upload Record</h5>
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
						<!--begin::Dropzone-->
						<div class="dropzone mb-5" id="DropZoneUploadRecord">
							<!--begin::Message-->
							<div class="dz-message needsclick">
								<!--begin::Icon-->
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<!--end::Icon-->
								<!--begin::Info-->
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload a maximum of 10MB per file</span>
								</div>
								<!--end::Info-->
							</div>
						</div>
						<!--end::Dropzone-->
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0203Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Upload-->
        
		<!--begin::Modal Add record -->
		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">House Assignment - Add Model House</h5>
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
                                    <input id="tbx0102Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
                                </div>
                            </div>
                            <!--begin::Close-->
                            <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="selectAllcbx0102.checked = false;">
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
                        <div class="table-loading">
                            <div id="div0102Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0102AddModel" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-75px mw-75px fw-bold">
											<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'>
												<input class='form-check-input widget-9-check border border-dark' id="selectAllcbx0102" type='checkbox' onclick="allcbx0102(this);"/>
											</div>
                                        </th>
						                <th class="min-w-100px mw-100px fw-bold border-end">Sort</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-400px mw-400px fw-bold border-end">Model Name</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Model Finish</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Area</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0102Add_Ok(this); return false;">
                             <span class="indicator-label">Add</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="selectAllcbx0102.checked = false;">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Cancel-->
		<div id="mdl0101Cancel" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">House Assignment - Cancel Record</h5>
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
							<span class="input-group-text min-w-150px required">Date</span>
							<input id="tbx0101ReasonDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
						</div>
					    <div class="input-group input-group-sm">
						    <span class="input-group-text min-w-150px required">Reason</span>
						    <input id="tbx0101Reason" type="text" class="form-control " Placeholder="Reason" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0101Cancel_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0101Cancel_Ok(this); return false;">
                            <span class="indicator-label">
                                Save
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Cancel-->

		<!--begin::Modal Upload-->
		<div id="mdl0202Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
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
						<!--begin::Dropzone-->
						<div class="dropzone mb-5" id="DropZone">
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
                        <button id="btn0202Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Upload-->
	
		<!--begin::Modal Comment-->
		<div id="mdl0302Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Notes - Add Note</h5>
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
						<textarea id="tbx0302Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" Placeholder="Notes"></textarea>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0302Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0302Add_Ok(this);return false;">
                            <span class="indicator-label">
                                Add Note
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Comment-->

    </div>
    <!--end::Content-->
	
	<!--param-->
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<!--param-->

    <!-- script related to this page -->
    <script type="text/javascript">

        //variable
        var FileCount = 0;
        let checkedBoxStates = {};
        //variable

        //general
        function fn01Load() {
            fnAccess('PDD050000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    location.replace("MNU000022");
                };
            });
        };
        function fn01DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0101Refresh").classList.remove("btn-view");
                document.getElementById("btn0101Add").classList.remove("btn-add");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Lock").classList.remove("btn-lock");
                document.getElementById("btn0101Unlock").classList.remove("btn-lock");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = pValue;
                }
            } else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Add").classList.add("btn-add");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Lock").classList.add("btn-lock");
                document.getElementById("btn0101Unlock").classList.add("btn-lock");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = pValue;
                }
            }
            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Add").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Lock").disabled = pValue;
            document.getElementById("btn0101Unlock").disabled = pValue;
        };
        function fn01Toggle(button) {
            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            // Hide all other toggle menus
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) menu.classList.add('d-none');
            });

            // Toggle current menu
            if (toggleMenu) {
                const isVisible = !toggleMenu.classList.contains('d-none');
                toggleMenu.classList.toggle('d-none');

                // If now visible, add outside click listener
                if (!isVisible) {
                    const outsideClickListener = function (event) {
                        if (!wrapper.contains(event.target)) {
                            toggleMenu.classList.add('d-none');
                            document.removeEventListener('click', outsideClickListener);
                        }
                    };
                    setTimeout(() => {
                        // Allow this click to finish before listening
                        document.addEventListener('click', outsideClickListener);
                    }, 0);
                }
            }
        };
        //general

        //overview
        function fn0101LoadOverview(pMode, pID) { 
            if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD050000',
                        'pType': 'Get Info - Dtl',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101Status").innerText = response[0].Status;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.remove("la-save");
                        document.getElementById("btn0101Delete").classList.add("d-none");
                        fn01DisableButtons(false);
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        //toolbar

                        //load table
                        fn0101LoadTblDtl(pID);
                        //load table

                        //content
                        document.getElementById("lbl0101UpdatedByName").innerText = response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = response[0].UpdatedDate;
                        document.getElementById("lbl0101LockedByName").innerText = response[0].LockedByName;
                        document.getElementById("lbl0101LockedDate").innerText = response[0].LockedDate;
                        //content

                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD050000',
                        'pType': 'Get Info - Dtl',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101Status").innerText = response[0].Status;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        fn01DisableButtons(true);
                        document.getElementById("btn0101Edit").classList.add("btn-edit");
                        document.getElementById("btn0101Edit").disabled = false;
                        document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                        document.getElementById("btn0101Delete").classList.remove("d-none");
                        document.getElementById("i0101Edit").classList.add("la-save");
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        //toolbar

                        //load table
                        fn0101LoadTblUpd(pID);
                        //load table

                        //content
                        document.getElementById("lbl0101UpdatedByName").innerText = response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = response[0].UpdatedDate;
                        document.getElementById("lbl0101LockedByName").innerText = response[0].LockedByName;
                        document.getElementById("lbl0101LockedDate").innerText = response[0].LockedDate;
                        //content
                    },
                });
            }
        };

        //checkboxes function
        function handleCheckboxChange(checkbox) {
            const modelcode = $(checkbox).data('modelcode');
            const isChecked = $(checkbox).is(':checked');

            if (isChecked) {
                checkedBoxStates[modelcode] = {
                    modelcode: modelcode,
                    projcode: document.getElementById('ContentPlaceHolder1_hdnID').value,
                    status: 1
                };
            } else {
                delete checkedBoxStates[modelcode];
            }
        }
        function allcbx0102(masterCheckbox) {
            const checkBoxes = document.querySelectorAll(".cbxAddHA0102");
            const projCode = document.getElementById('ContentPlaceHolder1_hdnID').value;

            checkBoxes.forEach(checkBox => {
                // Set checked state
                checkBox.checked = masterCheckbox.checked;

                const modelcode = $(checkBox).data('modelcode');

                if (masterCheckbox.checked) {
                    checkedBoxStates[modelcode] = {
                        modelcode: modelcode,
                        projcode: projCode,
                        status: 1
                    };
                } else {
                    delete checkedBoxStates[modelcode];
                }
            });
        }
        function fn01InitCbxHnd() {
            // Remove any existing handlers to prevent duplicates
            $(document).off('change', '.cbxAddHA0102');

            // Add event handler for checkbox changes
            $(document).on('change', '.cbxAddHA0102', function () {
                handleCheckboxChange(this);
                fn01UpdateSelectAll();
            });
        }
        function fn01UpdateSelectAll() {
            const totalCheckboxes = $('.cbxAddHA0102').length;
            const currentPageChecked = $('.cbxAddHA0102:checked').length;
            const totalCheckedAcrossPages = Object.keys(checkedBoxStates).length;

            const selectAllCheckbox = $('#selectAllcbx0102'); // Adjust ID as needed

            if (totalCheckedAcrossPages === 0) {
                selectAllCheckbox.prop('indeterminate', false);
                selectAllCheckbox.prop('checked', false);
            } else if (currentPageChecked === totalCheckboxes && totalCheckedAcrossPages === fn01GetTotalRowCount()) {
                selectAllCheckbox.prop('indeterminate', false);
                selectAllCheckbox.prop('checked', true);
            } else {
                selectAllCheckbox.prop('indeterminate', true);
            }
        }
        function fn01InitExistingChecked() {
            $('.cbxAddHA0102').each(function () {
                if ($(this).is(':checked')) {
                    // Add already checked items to our state
                    const modelcode = $(this).data('modelcode');
                    checkedBoxStates[modelcode] = {
                        modelcode: modelcode,
                        projcode: document.getElementById('ContentPlaceHolder1_hdnID').value,
                        status: 1
                    };
                }
            });
        }
        function fn01RestoreCbxStates() {
            $('.cbxAddHA0102').each(function () {
                const modelcode = $(this).data('modelcode');
                if (checkedBoxStates[modelcode]) {
                    $(this).prop('checked', true);
                }
            });
            fn01UpdateSelectAll();
        }
        function fn01GetTotalRowCount() {
            return $('#table0102AddModel').DataTable().data().count();
        }

        //function
        async function fn0102Add_Ok(Btn) {
            //access
            fnAccess('PDD050000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn0102Add_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0102Add_Ok_Await(Btn) {
                // Get all checked items from our state object instead of DOM
                let checkboxData = Object.values(checkedBoxStates);
                let ModelCodeSrs = "";

                // Build ModelCodeSrs from stored state
                checkboxData.forEach(item => {
                    if (item.status === 1) {
                        if (ModelCodeSrs === "") {
                            ModelCodeSrs = `${item.modelcode}©${item.status}`;
                        } else {
                            ModelCodeSrs += `®${item.modelcode}©${item.status}`;
                        }
                    }
                });

                // Check if at least one item is selected
                if (checkboxData.length > 0) {
                    const projcode = checkboxData[0].projcode;
                    Add_Question(Btn, projcode, ModelCodeSrs);
                } else {
                    fnAlertOnly('Please select a house model!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                }

                // Rest of your functions remain the same...
                function Add_Question(Btn, projcode, ModelCodeSrs) {
                    Swal.fire({
                        text: 'Add/Modify selected model house(s)?',
                        icon: 'question',
                        iconColor: '#0095e8',
                        buttonsStyling: false,
                        showCancelButton: true,
                        confirmButtonText: "Yes",
                        cancelButtonText: 'Cancel',
                        customClass: {
                            confirmButton: 'btn btn-sm btn-info min-w-100px',
                            cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                        }
                    }).then((result) => {
                        if (result.isConfirmed) {
                            Validate_Add(document.getElementById('ContentPlaceHolder1_hdnID').value, Btn, projcode, ModelCodeSrs);
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                }
                //validate add
                function Validate_Add(ID, Btn, projcode, ModelCodeSrs) {
                    fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Add_Ok(Btn, projcode, ModelCodeSrs);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            checkedBoxStates = {};
                            selectAllcbx0102.checked = false;
                            fn01UpdateColumn(ID);
                            $('#mdl0102Add').modal('hide');
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');

                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                        };
                    });
                };

                function Add_Ok(Btn, projcode, ModelCodeSrs) {
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD050000',
                            'pType': 'Add House Model',
                            'pProjCode': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pModelCodeSrs': ModelCodeSrs,
                        },
                        success: async function (response) {
                            // Clear the checked states after successful save
                            checkedBoxStates = {};
                            selectAllcbx0102.checked = false;

                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');

                            await fn01UpdateColumn(document.getElementById("ContentPlaceHolder1_hdnID").value);

                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                            $('#mdl0102Add').modal('hide');
                        },
                    });
                }
            }
        };
        function fn01UpdateColumn(projectId) {
            return new Promise(async (resolve, reject) => {
                try {
                    if (!$.fn.DataTable.isDataTable('#table0101Record')) {
                        fn0101LoadTblDtl(projectId);
                        resolve();
                        return;
                    }

                    const table = $('#table0101Record').DataTable();

                    // Get current columns
                    const currentColumns = [];
                    table.columns().header().each(function (headerNode) {
                        currentColumns.push($(headerNode).text().trim());
                    });

                    // Get expected columns from server
                    const serverResponse = await fn01GetData(projectId);
                    const expectedColumns = Object.keys(serverResponse[0]).filter(h => h !== "RowID");

                    console.log('Current columns:', currentColumns);
                    console.log('Expected columns:', expectedColumns);

                    // Determine what needs to be done
                    const columnsToRemove = currentColumns.filter(col => !expectedColumns.includes(col));
                    const columnsToAdd = expectedColumns.filter(col => !currentColumns.includes(col));

                    console.log('Columns to remove:', columnsToRemove);
                    console.log('Columns to add:', columnsToAdd);

                    // Remove columns only (this is safe and efficient)
                    function escHtml(str) {
                        return $('<div>').text(str == null ? '' : str).html();
                    }

                    if (columnsToRemove.length > 0 || columnsToAdd.length > 0) {
                        console.log('Structural column changes detected — rebuilding DataTable...');

                        const headers = expectedColumns; // already filtered from serverResponse
                        const data = serverResponse.map(row => headers.map(h => row[h]));

                        // Set datatable column width
                        const columnWidths = [
                            "min-w-125px",
                            "min-w-75px",
                            "min-w-75px",
                            "min-w-75px",
                            "min-w-75px",
                            "min-w-100px",
                            "min-w-100px",
                            "min-w-100px",
                            "min-w-100px",
                        ];
                        const checkboxColumns = headers.slice(columnWidths.length); // extra columns after the first 9

                        // Rebuild <thead>
                        let thead = '<tr>';
                        headers.forEach((h, i) => {
                            if (i < columnWidths.length) {
                                thead += `<th class="fw-bold ${columnWidths[i]} border-end text-center align-middle" style="white-space: normal;">${h}</th>`;
                            } else {
                                thead += `<th class="fw-bold min-w-125px border-end text-center align-middle" style="white-space: normal;">
                                              <span title="${h}">${h}</span>
                                          </th>`;
                            }
                        });
                        thead += '</tr>';
                        $('#table0101Record thead').html(thead);

                        // Destroy previous DataTable instance
                        if ($.fn.DataTable.isDataTable('#table0101Record')) {
                            $('#table0101Record').DataTable().clear().destroy();
                        }

                        // Initialize DataTable with updated structure
                        $('#table0101Record').DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: data,
                            columns: headers.map((h, i) => ({
                                title: h,
                                className: i < columnWidths.length
                                    ? `${columnWidths[i]} border-end tbody-nowrap-auto`
                                    : "border-end",
                                render: function (cellData, type, row, meta) {
                                    if (meta.col < columnWidths.length) {
                                        if (type === 'display' && typeof cellData === 'number') {
                                            return cellData.toFixed(2);
                                        }
                                        return cellData ?? '';
                                    } else {
                                        const rowId = row[0];
                                        const colName = h;
                                        const Project = document.getElementById("ContentPlaceHolder1_hdnID").value;
                                        const ModelCode = "";
                                        return `<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'>
                                                    <input class='form-check-input dynamic-check' type='checkbox' onclick='return false;'
                                                        data-lotcode='${rowId}' 
                                                        data-modelcode='${ModelCode}'
                                                        data-projcode='${Project}'
                                                        data-model='${colName}'
                                                        ${cellData == 1 ? "checked" : ""}/>
                                                </div>`;
                                    }
                                }
                            })),
                            drawCallback: function () {
                                $('.dynamic-check').each(function () {
                                    const $checkbox = $(this);
                                    const project = $checkbox.data('projcode');
                                    const colname = $checkbox.data('model');

                                    if (!$checkbox.attr('data-modelcode') || $checkbox.data('modelcode') === '') {
                                        $.ajax({
                                            type: "POST",
                                            url: "HNDPDD.ashx",
                                            data: {
                                                'pFormCode': 'PDD050000',
                                                'pType': 'Get ModelCode',
                                                'Project': project,
                                                'Model': colname
                                            },
                                            success: function (resp) {
                                                const modelCode = resp?.[0]?.ModelCode || '';
                                                $checkbox.attr('data-modelcode', modelCode);
                                            }
                                        });
                                    }
                                });
                            }
                        });

                        resolve();
                        return;
                    }


                } catch (error) {
                    console.error('Error in smart column update, falling back to full reload:', error);
                    // Fallback to complete table recreation
                    fn0101LoadTblDtl(projectId);
                    resolve(); 
                }
            });
        }
        function fn01GetData(projectId) {
            return new Promise((resolve, reject) => {
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD050000',
                        'pType': 'Get Data',
                        'pProjCode': projectId
                    },
                    success: resolve,
                    error: reject
                });
            });
        }
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('PDD050000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                //load add model
                $.ajax({
                    type: "POST",
                    url: "HNDPDD.ashx",
                    data: {
                        'pFormCode': 'PDD050000',
                        'pType': 'Get House Model',
                        'pProjCode': document.getElementById('ContentPlaceHolder1_hdnID').value
                    },
                    success: function (response) {

                        //display loader
                        document.getElementById("div0102Loader").style.display = 'none';
                        //display loader

                        $('#table0102AddModel').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        // Destroy previous DataTable instance
                        if ($.fn.DataTable.isDataTable('#table0102AddModel')) {
                            $('#table0102AddModel').DataTable().clear().destroy();
                        }

                        // Initialize DataTable
                        var table0102AddModel = $('#table0102AddModel').DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'Sort' },
                                { data: 'Code' },
                                { data: 'ModelName' },
                                { data: 'ModelFinish' },
                                {
                                    data: 'Area',
                                    render: function (data, type, row, meta) {
                                        if (type === 'display') {
                                            if (typeof data === 'number') {
                                                return data.toFixed(2);
                                            }
                                        };
                                        return data;
                                    }
                                }
                            ],
                            columnDefs: [
                                { targets: 0, orderable: false },
                                { targets: 1, orderable: false },
                                { targets: 2, className: 'tbody-nowrap-auto' },
                                { targets: 3, className: 'tbody-nowrap-auto' },
                                { targets: 4, className: 'tbody-nowrap-auto' },
                                { targets: 5, className: 'tbody-nowrap-auto' }],
                        });

                        //search
                        $('#tbx0102Find').on('keyup', function () {
                            table0102AddModel.search(this.value).draw();
                        });
                        //search

                        //show add modal
                        $('#mdl0102Add').modal('show');
                        //show add modal

                        //get existing checkbox
                        fn01InitExistingCheckedAllPages();

                        // Initialize existing checked items first
                        fn01InitExistingChecked();

                        // Restore checkbox states after each draw/page change
                        fn01RestoreCbxStates();

                        // Initialize handlers if not already done
                        fn01InitCbxHnd();
                    },
                    error: function (xhr, status, error) {
                        console.error("AJAX Error:", error);
                        console.error("Status:", status);
                        console.error("XHR Response:", xhr.responseText);
                    }
                });
            //load add model
            };
        };

        function fn0101Edit() { 
                //validate
                if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                    //access
                    fnAccess('PDD050000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            ValidateFields("");
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                    //if exist
                    fnIfExist('calmardblive.dbo.mstr_Projects', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                        if (response[0].oReturn == "1") {
                            Access();
                        } else {
                            window.location.replace("MNU040100");
                        };
                    });
                    //access
                    function Access() {
                        //access
                        fnAccess('PDD050000', 'Save', function (response) {
                            if (response[0].oReturn == "1") {
                                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                            } else {
                                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                            };
                        });
                    };
                    //validate
                    function Validate(ID) {
                        fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Edit_Dtl_Ok_Await(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    };
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                    //if exist
                    fnIfExist('calmardblive.dbo.mstr_Projects', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                        if (response[0].oReturn == "1") {
                            Access();
                        } else {
                            window.location.replace("MNU040100");
                        };
                    });
                    //access
                    function Access() {
                        //access
                        fnAccess('PDD050000', 'Save', function (response) {
                            if (response[0].oReturn == "1") {
                                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                            } else {
                                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                            };
                        });
                    };
                    //validate
                    function Validate(ID) {
                        fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {

                                let checkboxData = [];
                                let LotSrs = "";
                                $('.dynamic-check').each(function () {
                                    const $checkbox = $(this);
                                    const isChecked = $checkbox.is(':checked') ? 1 : 0;
                                    const lotcode = $checkbox.data('lotcode');
                                    const modelcode = $checkbox.data('modelcode');
                                    const projcode = $checkbox.data('projcode');

                                    checkboxData.push({
                                        lotcode: lotcode,
                                        modelcode: modelcode,
                                        projcode: projcode,
                                        status: isChecked
                                    });

                                    // Build LotSrs string
                                    if (LotSrs === "") {
                                        LotSrs = `${lotcode}©${modelcode}©${isChecked}`;
                                    } else {
                                        LotSrs += `®${lotcode}©${modelcode}©${isChecked}`;
                                    }
                                });
                                //get checkbox data
                                if (checkboxData.length > 0) {
                                    const projcode = checkboxData[0].projcode;
                                    Edit_Question(ID, projcode, LotSrs);
                                }
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    };
                }
                //question
                function Edit_Question(ID, ProjCode, LotSrs) {
                    Swal.fire({
                        text: 'Save record?',
                        icon: 'question',
                        iconColor: '#0095e8',
                        buttonsStyling: false,
                        showCancelButton: true,
                        confirmButtonText: "Yes",
                        cancelButtonText: 'Cancel',
                        customClass: {
                            confirmButton: 'btn btn-sm btn-info min-w-100px',
                            cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                        }
                    }).then((result) => {
                        if (result.isConfirmed) {
                            if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                                Edit_Dtl_Ok_Await();
                            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                                Validate_Save(ID, ProjCode, LotSrs);
                            }
                        }
                    });
                };
                //validate save
                function Validate_Save(ID, ProjCode, LotSrs) {
                    fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Upd_Ok_Await(ID, ProjCode, LotSrs);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                        };
                    });
                };
                //do edit
                function Edit_Dtl_Ok_Await(ID) {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD"
                    document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                    document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                };
                function Edit_Upd_Ok_Await(ID, ProjCode, LotSrs) { 
                    $.ajax({
                        type: "POST",
                        url: "HNDPDD.ashx",
                        data: {
                            'pFormCode': 'PDD050000',
                            'pType': 'Edit-Record',
                            'pProjCode': ProjCode,
                            'pLotSrs': LotSrs,
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                            document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                            document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        },
                    });
                };
            };
        function fn0101Delete() {
            if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "UPD") {
                Cancel_Upd_Question(document.getElementById('ContentPlaceHolder1_hdnID').value);
            }

            function Cancel_Upd_Question(ID) {
                Swal.fire({
                    text: 'Cancel changes?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    }
                });
            };
        };
        function fn0101Lock() {
            //if exist
            fnIfExist('calmardblive.dbo.mstr_Projects', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('PDD050000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('mstr_Projects-HLA', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //lock question
            function Lock_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Lock record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101LockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    iconColor: '#009ef7',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                Validate_Lock(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //validate lock
            function Validate_Lock(ID) {
                fnValidateRecord('mstr_Projects-HLA', ID, '', 'Lock', function (response) {
                    console.log(ID, response[0].oReturn);
                    if (response[0].oReturn == "") {
                        Lock_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                    };
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'mstr_Projects-HLA', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exist
            fnIfExist('calmardblive.dbo.mstr_Projects', 'ProjCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('PDD050000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('mstr_Projects-HLA', ID, '', 'Unlock', function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //unlock question
            function Unlock_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Unlock record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101UnlockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    iconColor: '#009ef7',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        fnValidatePassword(document.getElementById("tbx0101UnlockPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                Validate_Unlock(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //validate unlock
            function Validate_Unlock(ID) {
                fnValidateRecord('mstr_Projects-HLA', ID, '', 'Unlock', function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                    };
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'mstr_Projects-HLA', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn01InitExistingCheckedAllPages() {
            var table = $('#table0102AddModel').DataTable();
            var currentPage = table.page(); // Remember current page index

            // Loop through all pages
            for (var i = 0; i < table.page.info().pages; i++) {
                table.page(i).draw('page'); // Go to page i

                // Scan visible rows on this page
                table.rows({ page: 'current' }).every(function () {
                    var $checkbox = $(this.node()).find('.cbxAddHA0102');
                    if ($checkbox.prop('checked')) {
                        const modelcode = $checkbox.data('modelcode');
                        checkedBoxStates[modelcode] = {
                            modelcode: modelcode,
                            projcode: document.getElementById('ContentPlaceHolder1_hdnID').value,
                            status: 1
                        };
                    }
                });
            }

            // Restore the original page
            table.page(currentPage).draw('page');
        }

        //datatable structure
        function fn0101LoadTblDtl(pID) {
            $.ajax({
                type: "POST",
                url: "HNDPDD.ashx",
                data: {
                    'pFormCode': 'PDD050000',
                    'pType': 'Get Data',
                    'pProjCode': pID
                },
                success: function (response) {

                    //display loader
                    document.getElementById("div0101Record").style.display = 'none';
                    //display loader
                    $('#table0101Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //const headers = Object.keys(response[0]);
                    const headers = Object.keys(response[0]).filter(h => h !== "RowID");
                    const data = response.map(row => headers.map(h => row[h]));

                    //set datatable column width
                    const columnWidths = [
                        "min-w-125px",
                        "min-w-75px",
                        "min-w-75px",
                        "min-w-75px",
                        "min-w-75px",
                        "min-w-100px",
                        "min-w-100px",
                        "min-w-100px",
                        "min-w-100px",
                    ];
                    const checkboxColumns = headers.slice(columnWidths.length); // headers after first 9

                    // Rebuild <thead>let thead = '<tr>';
                    let thead = '<tr>';
                    headers.forEach((h, i) => {
                        if (i < columnWidths.length) {
                            thead += `<th class="fw-bold ${columnWidths[i]} border-end border-end text-center align-middle" style="white-space: normal;">${h}</th>`;
                        } else {
                            thead += `<th class="fw-bold min-w-125px border-end align-middle border-end text-center align-middle" style="white-space: normal;">
                                         <span title="${h}">${h}</div>
                                     </th>`;
                        }
                    });
                    thead += '</tr>';
                    $('#table0101Record thead').html(thead);

                    // Destroy previous DataTable instance
                    if ($.fn.DataTable.isDataTable('#table0101Record')) {
                        $('#table0101Record').DataTable().clear().destroy();
                    }

                    // Initialize DataTable
                    var table0101Record = $('#table0101Record').DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 3000,
                        select: true,
                        data: data,
                        columns: headers.map((h, i) => ({
                            title: h,
                            className: i < columnWidths.length
                                ? `${columnWidths[i]} border-end tbody-nowrap-auto`
                                : "border-end",
                            render: function (data, type, row, meta) {
                                if (meta.col < columnWidths.length) {
                                    if (type === 'display') {
                                        if (typeof data === 'number') {
                                            return data.toFixed(2);
                                        }
                                    }
                                };
                                if (meta.col >= columnWidths.length) {
                                    const rowId = row[0];
                                    const colName = h;
                                    const Project = document.getElementById("ContentPlaceHolder1_hdnID").value;
                                    const ModelCode = "";
                                    //const checkboxId = `cbx-${rowId}-${Project}-${colName}`; //detailtbl
                                    var checkboxHTML = `<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'>
                                                        <input class='form-check-input dynamic-check' type='checkbox' onclick='return false;'
                                                            data-lotcode='${rowId}' 
                                                            data-modelcode='${ModelCode}'
                                                            data-projcode='${Project}'
                                                            data-model='${colName}'
                                                            ${data == 1 ? "checked" : ""}/>
                                                    </div>`;

                                    return checkboxHTML;
                                }
                                return data;
                            }
                        })),
                        drawCallback: function (settings) {
                            $('.dynamic-check').each(function () {
                                const $checkbox = $(this);
                                const project = $checkbox.data('projcode');
                                const colname = $checkbox.data('model');

                                 //Prevent duplicate AJAX if already set
                                if (!$checkbox.attr('data-modelcode') || $checkbox.data('modelcode') === '') {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDPDD.ashx",
                                        data: {
                                            'pFormCode': 'PDD050000',
                                            'pType': 'Get ModelCode',
                                            'Project': project,
                                            'Model': colname
                                        },
                                        success: function (response) {
                                            const modelCode = response?.[0]?.ModelCode || '';
                                            $checkbox.attr('data-modelcode', modelCode); // update data-modelcode
                                        }
                                    });
                                }
                            });
                        }
                    });

                    //search
                    $('#tbx0101Find').on('keyup', function () {
                        table0101Record.search(this.value).draw();
                    });
                    //search
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", error);
                    console.error("Status:", status);
                    console.error("XHR Response:", xhr.responseText);
                }
            });
        }
        function fn0101LoadTblUpd(pID) {
            $.ajax({
                type: "POST",
                url: "HNDPDD.ashx",
                data: {
                    'pFormCode': 'PDD050000',
                    'pType': 'Get Data',
                    'pProjCode': pID
                },
                success: function (response) {

                    //display loader
                    document.getElementById("div0101Record").style.display = 'none';
                    //display loader

                    $('#table0101Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //const headers = Object.keys(response[0]);
                    const headers = Object.keys(response[0]).filter(h => h !== "RowID");
                    const data = response.map(row => headers.map(h => row[h]));

                    //set datatable column width
                    const columnWidths = [
                        "min-w-125px",
                        "min-w-75px",
                        "min-w-75px",
                        "min-w-75px",
                        "min-w-75px",
                        "min-w-100px",
                        "min-w-100px",
                        "min-w-100px",
                        "min-w-100px",
                    ];
                    const checkboxColumns = headers.slice(columnWidths.length); // headers after first 9

                    // Rebuild <thead>let thead = '<tr>';
                    let thead = '<tr>';
                    headers.forEach((h, i) => {
                        if (i < columnWidths.length) {
                            thead += `<th class="fw-bold ${columnWidths[i]} border-end border-end text-center align-middle" style="white-space: normal;">${h}</th>`;
                        } else {
                            thead += `<th class="fw-bold min-w-125px border-end align-middle border-end text-center align-middle" style="white-space: normal;">
                                         <span title="${h}">${h}</div>
                                     </th>`;
                        }
                    });
                    thead += '</tr>';
                    $('#table0101Record thead').html(thead);

                    // Destroy previous DataTable instance
                    if ($.fn.DataTable.isDataTable('#table0101Record')) {
                        $('#table0101Record').DataTable().clear().destroy();
                    }

                    // Initialize DataTable
                    var table0101Record = $('#table0101Record').DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: data,
                        columns: headers.map((h, i) => ({
                            title: h,
                            className: i < columnWidths.length
                                ? `${columnWidths[i]} border-end tbody-nowrap-auto`
                                : "border-end",
                            render: function (data, type, row, meta) {
                                if (meta.col < columnWidths.length) {
                                    if (type === 'display') {
                                        if (typeof data === 'number') {
                                            return data.toFixed(2);
                                        }
                                    }
                                };
                                if (meta.col >= columnWidths.length) {
                                    const rowId = row[0];
                                    const colName = h;
                                    const Project = document.getElementById("ContentPlaceHolder1_hdnID").value;
                                    const ModelCode = "";
                                    //const checkboxId = `cbx-${rowId}-${Project}-${colName}`; //detailtbl
                                    var checkboxHTML = `<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'>
                                                        <input class='form-check-input dynamic-check' type='checkbox'
                                                            data-lotcode='${rowId}' 
                                                            data-modelcode='${ModelCode}'
                                                            data-projcode='${Project}'
                                                            data-model='${colName}'
                                                            ${data == 1 ? "checked" : ""}/>
                                                    </div>`;

                                    return checkboxHTML;
                                }
                                return data;
                            }
                        })),
                        drawCallback: function (settings) {
                            $('.dynamic-check').each(function () {
                                const $checkbox = $(this);
                                const project = $checkbox.data('projcode');
                                const colname = $checkbox.data('model');

                                //Prevent duplicate AJAX if already set
                                if (!$checkbox.attr('data-modelcode') || $checkbox.data('modelcode') === '') {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDPDD.ashx",
                                        data: {
                                            'pFormCode': 'PDD050000',
                                            'pType': 'Get ModelCode',
                                            'Project': project,
                                            'Model': colname
                                        },
                                        success: function (response) {
                                            const modelCode = response?.[0]?.ModelCode || '';
                                            $checkbox.attr('data-modelcode', modelCode); // update data-modelcode
                                        }
                                    });
                                }
                            });
                        }
                    });

                    //search
                    $('#tbx0101Find').on('keyup', function () {
                        table0101Record.search(this.value).draw();
                    });
                    //search
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", error);
                    console.error("Status:", status);
                    console.error("XHR Response:", xhr.responseText);
                }
            });
        }
        //datatable structure

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'PDD050000',
                    'pType': 'Upload - Get Record',
                    'pID': pID,
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0201LoaderAttachment").style.display = "";
                    //display loader

                    $('#table0201Attachment').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0201Attachment = $("#table0201Attachment").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Type' },
                            { data: 'Attachment' },
                            { data: 'UploadedBy' },
                            { data: 'UploadedDate' }],
                        columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                        order: [[2, 'asc']],
                    });
                    //datatable

                    //search
                    $('#tbx0201FindAttachment').on('keyup', function () {
                        table0201Attachment.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0201LoaderAttachment").style.display = "none";
                    //hide loader

                    //action button
                    if (pMode == "ADD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    } else if (pMode == "DTL") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.add("btn-active-light");
                            btn.disabled = false;
                        }
                    } else if (pMode == "UPD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    }
                    //action button

                },
            });
        };
        function fn0201Download(pFormCode, pID, pFileName) {
            //if exisit
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Download();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //download
            function Download() {
                $.ajax({
                    type: "POST",
                    url: "HNDGEN.ashx",
                    data: {
                        'pFormCode': pFormCode,
                        'pType': 'Upload - Download',
                        'pID': pID,
                        'pFileName': pFileName,
                    },
                    success: function (response) {
                        window.open('MNU020200?View=' + response[0].View);
                    },
                });
            };
        };
        function fn0201Delete(pFormCode, pID, pFileName) {
            //if exisit
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('PDD050000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Question(pFormCode, pID, pFileName);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //delete question
            function Delete_Question(pFormCode, pID, pFileName) {
                Swal.fire({
                    text: 'Remove attachment?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        Delete_Ok(pFormCode, pID, pFileName);
                    }
                });
            };
            function Delete_Ok(pFormCode, pID, pFileName) {
                $.ajax({
                    type: "POST",
                    url: "HNDGEN.ashx",
                    data: {
                        'pFormCode': pFormCode,
                        'pType': 'Upload - Delete',
                        'pID': pID,
                        'pFileName': pFileName,
                    },
                    success: function (response) {
                        fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
                    },
                });
            };
        };
        //attachment

        //notes
        function fn0301LoadNotes(pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'PDD050000',
                    'pType': 'Notes - Get Record',
                    'pID': pID,
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0301LoaderNotes").style.display = "";
                    //display loader

                    $('#table0301Notes').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0301Notes = $("#table0301Notes").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        data: response,
                        columns: [
                            { data: 'Notes' }],
                        columnDefs: [{ targets: 0, orderable: false }],
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx0301FindNotes').on('keyup', function () {
                        table0301Notes.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0301LoaderNotes").style.display = "none";
                    //hide loader

                },
            });
        };
        function fn0301Add() {
            //if exisit
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //add
            function Add() {
                document.getElementById("tbx0302Note").value = "";
                document.getElementById("hdnMention").value = "";
                $('#mdl0302Notes').modal('show');
            };
        };
        function fn0302Add_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //add
            async function Add_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn0302Add_Ok_Await(Btn);
            }
        };
        function fn0302Add_Ok_Await(Btn) {
            // process
            return new Promise(resolve => {
                //Validate
                if (document.getElementById("tbx0302Note").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Add_Ok_Await();
                }
                //add
                function Add_Ok_Await() {
                    // Do Billing
                    $.ajax({
                        type: "POST",
                        url: "HNDGEN.ashx",
                        data: {
                            'pFormCode': 'PDD050000',
                            'pType': 'Notes - Add',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pNotes': document.getElementById("tbx0302Note").value,
                            'pMention': document.getElementById("hdnMention").value,
                        },
                        success: function (response) {
                            //message
                            fnAlertOnly('Note successfully added.', 'success', 'btn btn-success');
                            document.getElementById("tbx0302Note").value = "";
                            document.getElementById("hdnMention").value = "";
                            fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        },
                    });
                };
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                //resolve
                resolve();
            });
        };
        //notes

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //metion                jq.fn.atwho.debug = true;
                var chatHub = jq.connection.chatHub;
                jq.connection.hub.start().done(function () {
                    loadFunction()
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
                                    $('#hdnMention').val(initialMention.join(','));
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
                };                //metion

                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

                //upload
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "HNDGEN.ashx?pFormCode=PDD050000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0202Upload').modal('hide');
                        //load attachment
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                myDropzone.on("addedfile", function (file) {
                    FileCount = FileCount + 1;
                });
                myDropzone.on("removedfile", function (file) {
                    FileCount = FileCount - 1;
                });
                $('#btn0201Add').on('click', function (e) {
                    //access
                    fnAccess('PDD050000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Add();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    function Add() {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl0202Upload').modal('show');
                    };
                });
                $('#btn0202Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('PDD050000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
                    function Validate() {
                        if (FileCount > 0) {
                            btn0202Add_Ok();
                        } else {
                            fnAlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
                        }
                    }
                    //upload
                    async function btn0202Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0202Add_Ok_Await(Btn);
                    }
                    async function btn0202Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=PDD050000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //upload

                //add record - uploadrecord
                var myDropzone = new Dropzone("#DropZoneUploadRecord", {
                    url: "HNDPDD.ashx?pType=Upload-HLA",
                    autoProcessQueue: false,
                    parallelUploads: 1,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 1,
                    acceptedFiles: ".xlsx,.xls,.XLSX,.XLS",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0203Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0203Upload').modal('hide');
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                        fnAlertOnly('There was an issue uploading your file. Please try again.', 'danger', 'btn btn-danger');
                    }
                });
                myDropzone.on("addedfile", function () { FileCount++; });
                myDropzone.on("removedfile", function () { FileCount--; });
                $('#a0103UploadRecord').on('click', function (e) {
                    //access
                    fnAccess('PDD050000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
                    function Validate(ID) {
                        fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Add();
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    };
                    function Add() {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl0203Upload').modal('show');
                    };
                });
                $('#btn0203Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('PDD050000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate_AddOk(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate add
                    function Validate_AddOk(ID) {
                        fnValidateRecord('mstr_Projects-HLA', ID, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Validate();
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                var Btn = document.getElementById('btn0203Add_Ok');
                                Btn.disabled = false;
                                Btn.removeAttribute('data-kt-indicator');

                                $('#mdl0203Upload').modal('hide');

                                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value); //redrawretyrn
                            };
                        });
                    };
                    //validate empty attachment
                    function Validate() {
                        if (FileCount > 0) {
                            btn0203Add_Ok();
                        } else {
                            fnAlertOnly('Attach an excel file to proceed!', 'error', 'btn btn-danger');
                        }
                    };
                    //upload
                    async function btn0203Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0203Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0203Add_Ok_Await(Btn);
                    }
                    async function btn0203Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone.options.url = "HNDPDD.ashx?pType=Upload-HLA";
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //add record - uploadrecord

            });
            jQuery(function ($) {
                fn01Load();

                // Initialize existing checked items first
                fn01InitExistingChecked();

                // Restore checkbox states after each draw/page change
                fn01RestoreCbxStates();

                // Initialize handlers if not already done
                fn01InitCbxHnd();
            });
        };
        //load page

    </script>
    <!-- script related to this page -->

</asp:Content>
