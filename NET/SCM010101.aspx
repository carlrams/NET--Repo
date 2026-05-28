<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM010101.aspx.vb" Inherits="NET.SCM010101"  MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/tom-select@2.6.1/dist/css/tom-select.css" rel="stylesheet">
    <style>
		div.dataTables_scrollBody {
			border-left: 0px solid #ddd !important
		}
    </style>

    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white opacity-75">Contracts</li>
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<li class="breadcrumb-item text-white opacity-75">For Award</li>
					</ul>
				</div>
				<div class="d-flex align-items-center py-3 py-md-1">
					<a href="#" class="btn btn-sm btn-info fw-bolder min-w-100px" onclick="fn01View(); return false;">View Form</a>
				</div>
			</div>
		</div>

		<!--begin::Content-->
		<div class="card-body">
			
            <div class="d-flex flex-column flex-lg-row">
				<div class="d-flex flex-column gap-7 gap-lg-10 w-100 w-lg-300px mb-7 me-lg-10">
					<div class="card card-flush py-4">
						<div class="card-header">
							<div class="card-title">
								<h2>Project</h2>
							</div>
						</div>
						<div class="card-body text-center pt-0">
							<div id="div01SubdImg" class="image-input image-input-empty">
								<div class="w-200px h-150px"></div>
							</div>
							<div class="text-muted fs-7">Subdivision</div>
						</div>
					</div>
				</div>
				<div class="d-flex flex-column flex-row-fluid gap-7 gap-lg-10">
					<ul class="nav nav-custom nav-tabs nav-line-tabs nav-line-tabs-2x border-0 fs-4 fw-bold mb-n2">
						<li class="nav-item">
							<a class="nav-link text-active-primary pb-4 active" data-bs-toggle="tab" href="#MNU_TabContent01">Overview</a>
						</li>
					</ul>
					<div class="tab-content">
						<div class="tab-pane fade show active" id="MNU_TabContent01" role="tab-panel">
							<div class="d-flex flex-column gap-7 gap-lg-10">
								<div class="card card-flush py-4">
									<div class="card-header">
										<div class="card-title">
											<h2>General</h2>
										</div>
									</div>
                                    <div class="card-body">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">ID</span>
											<span id="lbl01ID" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Type</span>
											<span id="lbl01FormType" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Requested</span>
											<span id="lbl01DateRequested" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Required</span>
											<span id="lbl01DateRequired" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Requested By</span>
											<span id="lbl01RequestedBy" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Assigned To</span>
											<span id="lbl01AssignedTo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Endorsed To</span>
											<span id="lbl01EndorsedTo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Status</span>
											<span id="lbl01Status" class="form-control">-</span>
										</div>
										<!--begin::Seperator-->
										<div class="separator separator-dashed my-6"></div>
										<!--end::Seperator-->
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Category</span>
											<span id="lbl01Category" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Project</span>
											<span id="lbl01Project" class="form-control">-</span>
										</div>
										<div id="div01House" class="input-group input-group-sm mb-2" style="display: none;">
											<span class="input-group-text min-w-150px">House</span>
											<span id="lbl01House" class="form-control">-</span>
										</div>
										<div id="div01Batch" class="input-group input-group-sm mb-2" style="display: none;">
											<span class="input-group-text min-w-150px">Batch</span>
											<span id="lbl01Batch" class="form-control">-</span>
										</div>
										<div id="div01Theme" class="input-group input-group-sm mb-2" style="display: none;">
											<span class="input-group-text min-w-150px">Theme</span>
											<span id="lbl01Theme" class="form-control">-</span>
										</div>
										<div id="div01Budget" class="input-group input-group-sm mb-2" style="display: none;">
											<span class="input-group-text min-w-150px">Estimated Budget</span>
											<span id="lbl01Budget" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text input-group-text-top min-w-150px">Purpose</span>
											<textarea id="lbl01Purpose" class="form-control min-h-75px" readonly="readonly">-</textarea>
										</div>
                                    </div>
								</div>

								<div class="card card-flush py-4">
									<div class="card card-flush py-4">
										<div class="card-header">
											<div class="card-title">
												<h2>Attachment</h2>
											</div>
										</div>
									
										<div class="border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ms-5">
													<button id="btn98Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="return false;"><i class="las la-upload fs-2"></i></button>
												</div>
												<div class="position-relative me-5">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0201FindAttachment" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
										</div>
										<div class="card-body">
											<div class="table-responsive">
												<div id="div0201LoaderAttachment" class="table-loading-message">
													Loading...
												</div>
												<table id="table0201Attachment" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
															<th class="min-w-50px mw-50px border-end">Type</th>
															<th class="min-w-200px w-100">Name</th>
															<th class="min-w-200px mw-200px">By</th>
															<th class="min-w-200px mw-200px">Date</th>
														</tr>
													</thead>
													<tbody>
													</tbody>
												</table>
											</div>
										</div>
									</div>
								</div>
								
								<div class="card card-flush py-4">
									<div class="card card-flush py-4">
										<div class="card-header">
											<div class="card-title">
												<h2>Contractor</h2>
											</div>
										</div>
									
										<div class="border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ms-5">
													<button class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Tag" onclick="fn03Tag(); return false;"><i class="las la-plus fs-2"></i></button>
												</div>
												<div class="position-relative me-5">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0301FindContractor" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
										</div>
										<div class="card-body">
											<div class="table-responsive">
												<div id="div0301LoadContractor" class="table-loading-message">
													Loading...
												</div>
												<table id="table0301Contractor" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
															<th class="min-w-200px w-100">Name</th>
															<th class="min-w-200px mw-200px">By</th>
															<th class="min-w-150px mw-200px">Date</th>
															<th class="min-w-200px mw-200px">Status</th>
														</tr>
													</thead>
													<tbody>
													</tbody>
												</table>
											</div>
										</div>
									</div>
								</div>
								
								<div class="card card-flush py-4">
									<div class="card card-flush py-4">
										<div class="card-header">
											<div class="card-title">
												<h2>Notice Attachment</h2>
											</div>
										</div>
									
										<div class="border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ms-5">
													<button id="btn99Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="return false;"><i class="las la-upload fs-2"></i></button>
												</div>
												<div class="position-relative me-5">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0401FindAttachment" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
										</div>
										<div class="card-body">
											<div class="table-responsive">
												<div id="div0401LoaderAttachment" class="table-loading-message">
													Loading...
												</div>
												<table id="table0401Attachment" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
															<th class="min-w-50px mw-50px border-end">Type</th>
															<th class="min-w-200px w-100">Name</th>
															<th class="min-w-200px mw-200px">By</th>
															<th class="min-w-200px mw-200px">Date</th>
														</tr>
													</thead>
													<tbody>
													</tbody>
												</table>
											</div>
										</div>
									</div>
								</div>

							</div>
						</div>
					</div>
				</div>
            </div>

		</div>
		<!--end::Content-->
		
		<div id="mdl9801Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
						<div class="dropzone mb-5" id="divDropzone">
							<div class="dz-message needsclick">
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
							</div>
						</div>
					</div>
                    <div class="modal-footer">
                        <button id="btn9801Add" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		
		<div id="mdl9901Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload Notice</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
						<div class="dropzone mb-5" id="div01Dropzone">
							<div class="dz-message needsclick">
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
							</div>
						</div>
					</div>
                    <div class="modal-footer">
                        <button id="btn9901Add" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		
		<div id="mdl0301Record" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Contractor</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0301Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid01Api.setGridOption('quickFilterText', document.getElementById('tbx0301Find').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0301Record" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                        <button id="btn0301Tag_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0301Tag_Ok(this); return false;">
                            <span class="indicator-label">
                                Save
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl0301Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Deadline</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <input id="tbx0301DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                        <input id="tbx0301DateTo" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
                        <button id="fn0301Filter" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0301Filter_Ok(this); return false;">
                            <span class="indicator-label">
				                Submit
                            </span>
                            <span class="indicator-progress">
				                Loading
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl0301Mail" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-1000px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Mail</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
                        <div class="d-block">
							<div class="d-flex align-items-center border-bottom ps-8 pe-5 min-h-50px mb-2">
								<div class="text-dark fw-bolder w-75px">Cc:</div>
								<input id="txt0301ComposeCC" type="text" value="lorettaelsa_fabie@calmarland.com,evangeline.pasinio@calmarland.com,haryete.alperez@calmarland.com,arvin.rey@calmarland.com,ira.satur@calmarland.com,joseph.valenzuela@calmarland.com,lloyd.hernandez@calmarland.com,anthony.borgueta@calmarland.com" class="form-control form-control-transparent border-0" />
							</div>
                        </div>
						<textarea id="txt0301MailContent"></textarea>
					</div>
					<div class="modal-footer">
						<button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0301Send_Ok(this);return false;">
							<span class="indicator-label">
								Submit
							</span>
							<span class="indicator-progress">
								Loading
							</span>
						</button>
							<a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
								<span class="indicator-label">Cancel</span>
							</a>
					</div>
				</div>
			</div>
		</div>
        
		<div id="mdl0302Record" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-fullscreen">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Awarded Projects</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0302Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid02Api.setGridOption('quickFilterText', document.getElementById('tbx0302Find').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0302Record" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		
		<div id="mdl0303Award" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Awarded Projects</h5>
					</div>
					<div class="modal-body">
						<input id="tbx0303Code" runat="server" type="hidden" value="" />
						<input id="tbx0303NTPNo" type="text" class="form-control form-control-sm border border-danger mb-2" Placeholder="NTP No." maxlength="20" />
						<input id="tbx0303NTPDate" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="NTP Date" maxlength="20" readonly />
						<input id="tbx0303POCStart" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="POC Start" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
						<button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0303Submit_Ok(this);return false;">
							<span class="indicator-label">
								Submit
							</span>
							<span class="indicator-progress">
								Loading
							</span>
						</button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		
		<div id="mdl0304Update" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Update Deadline</h5>
					</div>
					<div class="modal-body">
						<input id="tbx0304Code" runat="server" type="hidden" value="" />
						<input id="tbx0304DateFrom" type="text" class="form-control form-control-sm border border-danger mb-2" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
						<input id="tbx0304DateTo" type="text" class="form-control form-control-sm border border-danger" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
					</div>
                    <div class="modal-footer">
						<button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0304Submit_Ok(this);return false;">
							<span class="indicator-label">
								Submit
							</span>
							<span class="indicator-progress">
								Loading
							</span>
						</button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		
		<div id="mdl0305Note" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Contract Management - Note</h5>
					</div>
					<div class="modal-body">
						<input id="tbx0305Code" runat="server" type="hidden" value="" />
						<textarea id="tbx0305Note" class="form-control border border-danger" placeholder="Reason" rows="4" readonly="readonly" title="Note/Cancellation Remarks"></textarea>
					</div>
                    <div class="modal-footer">
						<button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0305ReOpen_Ok(this);return false;">
							<span class="indicator-label">
								Re-Open
							</span>
							<span class="indicator-progress">
								Loading
							</span>
						</button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
    </div>
	
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<input id="hdnSeqNo" runat="server" type="hidden" value="" />
	<input id="hdnCodeSrs" runat="server" type="hidden" value="" />
	<input id="hdnEmailSrs" runat="server" type="hidden" value="" />
	
	<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/@tinymce/tinymce-webcomponent/dist/tinymce-webcomponent.min.js"></script>
	<%--<script type="text/javascript" src="https://cdn.tiny.cloud/1/14k186wcnnna2eslufwcl4qwfjedjw8mjuizb9s9yau9082a/tinymce/7/tinymce.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tinymce/8.1.2/tinymce.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/apexcharts/3.52.0/apexcharts.min.js"></script>
	<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/countup.js@latest/dist/countUp.umd.js"></script>
	<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/tom-select@2.6.1/dist/js/tom-select.complete.min.js"></script>
    <script type="text/javascript" src="Assets/js/SCM/SCM010101.js"></script>
    <script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
