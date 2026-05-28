<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AMD030100.aspx.vb" Inherits="NET.AMD030100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Fixed Asset Issuance</li>
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
						<img src="Assets/media/svg/apps/AMD030000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn0101Title">-</span></h2>
						<div class="text-muted fw-bolder">
							<span id="spn0101ID">-</span>
							<span class="mx-3">|</span>
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
				<!--begin::Content-->
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
								<div class="d-flex">
									<button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0101Add();return false;"><i class="las la-plus fs-2"></i></button>
									<button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
									<button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<div class="form-check form-check-custom form-check-success form-check-solid form-check-lg m-1">
										<input class="form-check-input" type="checkbox" value="" id="cbx0101Lock" onclick="return false;"/>
									</div>
									<button id="btn0101Lock" class="btn btn-sm btn-icon btn-lock align-self-center m-1" title="Lock" onclick="fn0101Lock();return false;"><i class="las la-lock fs-2"></i></button>
                                    <span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<button id="btn0101Tools" class="btn btn-sm btn-icon btn-tools align-self-center m-1" title="Tools" onclick="fn0101Tools();return false;"><i class="las la-cog fs-2"></i></button>
								</div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Issue No.</span>
											<span id="lbl0101IssueNo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Issued Date</span>
											<span id="lbl0101IssueDate" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Status</span>
											<span id="lbl0101Status" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Type</span>
											<span id="lbl0101Type" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Issued To</span>
											<span id="lbl0101IssuedTo" class="form-control">-</span>
										</div>
										<div class="row g-2">
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Location</span>
													<span id="lbl0101Location" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Issued By</span>
													<span id="lbl0101IssueBy" class="form-control">-</span>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">
				                                <div class="form-check form-check-custom form-check-solid form-check-sm me-1">
								                    <input id="cbx0101GP01" class="form-check-input" type="checkbox" value="" onclick="return false;"/>
				                                </div>
				                                 <label class="form-check-label">
								                        GP No.
				                                 </label>
                                            </span>
											<span id="lbl0101GPNo" class="form-control">-</span>
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-9">
                                        <div class="row g-2">
                                            <div class="col-sm-12 col-md-12 col-lg-6">
				                                <div class="input-group input-group-sm">
								                    <span class="input-group-text min-w-150px">Deliver to</span>
								                    <span id="lbl0101DeliverTo" class="form-control">-</span>
				                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-12 col-lg-6">
				                                <div class="input-group input-group-sm">
								                    <span class="input-group-text min-w-150px">Authorized By</span>
								                    <span id="lbl0101AuthorizedBy" class="form-control">-</span>
				                                </div>
                                             </div>
                                        </div>
                                    </div>
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
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Issue No.</span>
											<input id="tbx0101IssueNo" type="text" class="form-control" Placeholder="Issue No." maxlength="13" readonly />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Issued Date</span>
											<input id="tbx0101IssueDate" type="text" class="form-control" Placeholder="Issued Date" maxlength="20" readonly />
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Status</span>
											<input id="tbx0101Status" type="text" class="form-control" Placeholder="Status" maxlength="20" readonly />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Type</span>
											<select id="ddl0101Type" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0101Type_onchange(this);">
												<option value="">Type</option>
												<option value="Issuance">Issuance</option>
												<option value="Returnable">Returnable</option>
												<option value="Non-Returnable">Non-Returnable</option>
												<option value="For Repair">For Repair</option>
												<option value="Return">Return</option>
												<option value="Disposal">Disposal</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101IssuedTo" class="input-group-text min-w-150px">Issued To</span>
											<select id="ddl0101IssuedTo" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" >
												<option value="">Issued To</option>
											</select>
										</div>
										<div class="row g-2">
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span id="spn0101Location" class="input-group-text min-w-150px">Location</span>
													<input id="tbx0101Location" type="text" class="form-control" Placeholder="Location" maxlength="180" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span id="spn0101IssuedBy" class="input-group-text min-w-150px">Issued By</span>
													<select id="ddl0101IssuedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
														<option value="">Issued By</option>
													</select>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">
												<div class="form-check form-check-custom form-check-solid form-check-sm me-1">
													<input id="cbx0101GP02" class="form-check-input" type="checkbox" onchange="cbx0101GP02_onchange(this)" value=""/>
												</div>
												 <label class="form-check-label" for="cbx0101GP02">
													 GP No.
												 </label>
											</span>
											<input id="tbx0101GPNo" type="text" class="form-control" Placeholder="GP No." maxlength="13" readonly />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-9">
                                        <div class="row g-2">
                                            <div class="col-sm-12 col-md-12 col-lg-6">
                                                <div class="input-group input-group-sm">
			                                        <span id="spn0101DeliverTo" class="input-group-text min-w-150px">Deliver to</span>
			                                        <input id="tbx0101DeliverTo" type="text" class="form-control" Placeholder="Deliver to" maxlength="180" />
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-12 col-lg-6">
                                                <div class="input-group input-group-sm">
			                                        <span id="spn0101AuthorizedBy" class="input-group-text min-w-150px">Authorized By</span>
			                                        <select id="ddl0101AuthorizedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
				                                        <option value="">Authorized By</option>
			                                        </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
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

						<!--begin::Asset-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Asset</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
                            <!--begin::Card header-->
                            <div class="card-header">
                                <div class="d-flex align-items-center">
                                    <button id="btn0102Add" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Add" onclick="fn0102Add();return false;"><i class="las la-pencil-alt fs-2"></i></button>
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
                                            <input id="tbx0102FindAsset" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
                            </div>
                            <!--end::Card header-->
							<!--begin::Files-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0102LoaderAsset" class="table-loading-message">
										Loading...
									</div>
									<table id="table0102Asset" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-150px mw-150px fw-bold border-end">Asset No.</th>
												<th class="min-w-150px w-50 fw-bold border-end">Description</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Qty</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Unit</th>
                                                <th class="min-w-150px mw-150px fw-bold border-end">Tag No.</th>
												<th class="min-w-100px mw-100px fw-bold border-end"><span title="Disposal Amt">Disposal Amt</span></th>
												<th class="min-w-150px w-50 fw-bold">Remarks</th>
											</tr>
										</thead>
										<tbody>
						
										</tbody>
									</table>
								</div>
							</div>
							<!--end::Files-->
						</div>
						<!--end::Asset-->

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
											<th class="min-w-50px mw-50px fw-bold border-end">Type</th>
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
				<!--end:  Content-->
			</div>
			<!--end::Content-->
		</div>
		<!--end::title-->
                
		<!--begin::Modal Add record-->
		<div id="mdl010101Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Tools</h5>
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
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_AMD03RPT01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">GP</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        				
		<!--begin::Modal Add record-->
		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Asset - Add record</h5>
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
                                    <input id="tbx010201Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
                                </div>
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
                        <div class="table-loading">
                            <div id="div010201Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010201Add" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
						                <th class="min-w-150px mw-150px fw-bold border-end">Asset No.</th>
                                        <th class="min-w-150px w-50 fw-bold border-end">Description</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Qty</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Unit</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Tag No.</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end"><span title="Disposal Amt">Disposal Amt</span></th>
                                        <th class="min-w-150px w-50 fw-bold">Remarks</th>
                                        <th class="min-w-100px mw-100px fw-bold">Action</th>
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
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        				
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
	
	<!-- scripts related to this page -->
	<script type="text/javascript">

        //variable
        var FileCount = 0;
        //variable

        //general
        function fn01Load() {
            fnAccess('AMD030000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadAsset(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Lock").classList.remove("btn-lock");
                document.getElementById("btn0101Tools").classList.remove("btn-tools");
                document.getElementById("btn0102Add").classList.remove("btn-edit");
                document.getElementById("btn0201Add").classList.remove("btn-add");
                document.getElementById("btn0301Add").classList.remove("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = pValue;
                }
            } else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Add").classList.add("btn-add");
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Lock").classList.add("btn-lock");
                document.getElementById("btn0101Tools").classList.add("btn-tools");
                document.getElementById("btn0102Add").classList.add("btn-edit");
                document.getElementById("btn0201Add").classList.add("btn-add");
                document.getElementById("btn0301Add").classList.add("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = pValue;
                }
            }

            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Add").disabled = pValue;
            document.getElementById("btn0101Delete").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Lock").disabled = pValue;
            document.getElementById("btn0101Tools").disabled = pValue;
            document.getElementById("btn0102Add").disabled = pValue;
            document.getElementById("btn0201Add").disabled = pValue;
            document.getElementById("btn0301Add").disabled = pValue;
        };
        function fn01Toggle(button) {
            // Find the closest wrapper and toggle the child menu
            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            // Hide all other open toggle menus first
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) menu.classList.add('d-none');
            });

            // Toggle the clicked one 
            if (toggleMenu) {
                toggleMenu.classList.toggle('d-none');
            }
        };
        function ddl0101IssuedTo(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAMD.ashx",
                data: {
                    'pType': 'Get Record - List',
                    'pTblName': 'Mstr_Employee',
                    'pPlaceHolder': 'Issued To',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101IssuedTo").html(s);
                    $('#ddl0101IssuedTo').val(ID).trigger('change');
                },
            });
        };
        function ddl0101IssuedBy(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAMD.ashx",
                data: {
                    'pType': 'Get Record - List',
                    'pTblName': 'Mstr_Employee',
                    'pPlaceHolder': 'Issued By',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101IssuedBy").html(s);
                    $('#ddl0101IssuedBy').val(ID).trigger('change');
                },
            });
        };
        function ddl0101AuthorizedBy(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAMD.ashx",
                data: {
                    'pType': 'Get Record - List',
                    'pTblName': 'Mstr_Employee',
                    'pPlaceHolder': 'Authorized By',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101AuthorizedBy").html(s);
                    $('#ddl0101AuthorizedBy').val(ID).trigger('change');
                },
            });
        };
        function ddl0101Type_onchange(ddl0101Type) {
            document.getElementById("spn0101IssuedTo").classList.remove("required");
            $('#ddl0101IssuedTo').val('').trigger('change');
            document.getElementById("ddl0101IssuedTo").disabled = true;
            document.getElementById("spn0101Location").classList.remove("required");
            document.getElementById("tbx0101Location").value = "";
            document.getElementById("tbx0101Location").readOnly = true;
            document.getElementById("spn0101IssuedBy").classList.remove("required");
            $('#ddl0101IssuedBy').val('').trigger('change');
            document.getElementById("ddl0101IssuedBy").disabled = true;
            if (ddl0101Type.options[ddl0101Type.selectedIndex].value == "Issuance") {
                document.getElementById("spn0101IssuedTo").classList.add("required");
                document.getElementById("ddl0101IssuedTo").disabled = false;
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
                document.getElementById("spn0101IssuedBy").classList.add("required");
                document.getElementById("ddl0101IssuedBy").disabled = false;
            } else if (ddl0101Type.options[ddl0101Type.selectedIndex].value == "Returnable") {
                document.getElementById("spn0101IssuedTo").classList.add("required");
                document.getElementById("ddl0101IssuedTo").disabled = false;
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
                document.getElementById("spn0101IssuedBy").classList.add("required");
                document.getElementById("ddl0101IssuedBy").disabled = false;
            } else if (ddl0101Type.options[ddl0101Type.selectedIndex].value == "Non-Returnable") {
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
                document.getElementById("spn0101IssuedBy").classList.add("required");
                document.getElementById("ddl0101IssuedBy").disabled = false;
            } else if (ddl0101Type.options[ddl0101Type.selectedIndex].value == "For Repair") {
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
                document.getElementById("spn0101IssuedBy").classList.add("required");
                document.getElementById("ddl0101IssuedBy").disabled = false;
            } else if (ddl0101Type.options[ddl0101Type.selectedIndex].value == "Return") {
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
                document.getElementById("spn0101IssuedBy").classList.add("required");
                document.getElementById("ddl0101IssuedBy").disabled = false;
            } else if (ddl0101Type.options[ddl0101Type.selectedIndex].value == "Disposal") {
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
                document.getElementById("spn0101IssuedBy").classList.add("required");
                document.getElementById("ddl0101IssuedBy").disabled = false;
            }
        };
        function cbx0101GP02_onchange(cbx0101GP02) {
            document.getElementById("spn0101DeliverTo").classList.remove("required");
            document.getElementById("tbx0101DeliverTo").value = "";
            document.getElementById("tbx0101DeliverTo").readOnly = true;
            document.getElementById("spn0101AuthorizedBy").classList.remove("required");
            $('#ddl0101AuthorizedBy').val('').trigger('change');
            document.getElementById("ddl0101AuthorizedBy").disabled = true;

            if (cbx0101GP02.checked == true) {
                document.getElementById("spn0101DeliverTo").classList.add("required");
                document.getElementById("tbx0101DeliverTo").readOnly = false;
                document.getElementById("spn0101AuthorizedBy").classList.add("required");
                document.getElementById("ddl0101AuthorizedBy").disabled = false;
            }
        };
        //general

        //overview
        function fn0101LoadOverview(pMode, pID) {
            if (pMode == "ADD") {

                //title
                document.getElementById("spn0101Title").innerText = "New Record";
                document.getElementById("spn0101ID").innerText = "000000000000";
                document.getElementById("spn0101Status").innerText = "New";
                if (document.getElementById("spn0101Status").innerText == "New") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                } else if (document.getElementById("spn0101Status").innerText == "Accepted") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                };
                //title

                //toolbar
                fn01DisableButtons(true);
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Delete").disabled = false;
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Edit").disabled = false;
                document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                document.getElementById("i0101Edit").classList.add("la-save");
                document.getElementById("cbx0101Lock").checked = false;
                //toolbar

                //content
                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";
                document.getElementById("tbx0101IssueNo").value = "";
                document.getElementById("tbx0101IssueDate").value = "";
                document.getElementById("tbx0101Status").value = "";
                $('#ddl0101Type').val('').trigger('change');
                ddl0101Type_onchange(document.getElementById("ddl0101Type"));
                ddl0101IssuedTo('');
                document.getElementById("tbx0101Location").value = "";
                ddl0101IssuedBy('');
                document.getElementById("cbx0101GP02").checked = false;
                cbx0101GP02_onchange(document.getElementById("cbx0101GP02"));
                document.getElementById("tbx0101GPNo").value = "";
                document.getElementById("tbx0101DeliverTo").value = "";
                ddl0101AuthorizedBy('');
                document.getElementById("tbx0101UpdatedByName").value = "";
                document.getElementById("tbx0101UpdatedDate").value = "";
                document.getElementById("tbx0101LockedByName").value = "";
                document.getElementById("tbx0101LockedDate").value = "";
                //content

            } else if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Get Info - DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Type + " / " + response[0].IssuedToName;
                        document.getElementById("spn0101ID").innerText = response[0].IssueCode;
                        document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Accepted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.remove("la-save");
                        fn01DisableButtons(false);
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        //checkbox

                        //content
                        document.getElementById("div0101Detail").style.display = "";
                        document.getElementById("div0101Update").style.display = "none";
                        document.getElementById("lbl0101IssueNo").innerText = response[0].IssueNo;
                        document.getElementById("lbl0101IssueDate").innerText = response[0].IssueDate;
                        document.getElementById("lbl0101Status").innerText = response[0].Status;
                        document.getElementById("lbl0101Type").innerText = response[0].Type;
                        document.getElementById("lbl0101IssuedTo").innerText = response[0].IssuedToName;
                        document.getElementById("lbl0101Location").innerText = response[0].Location;
                        document.getElementById("lbl0101IssueBy").innerText = response[0].IssuedByName;
                        if (response[0].GP == "1") {
                            document.getElementById("cbx0101GP01").checked = true;
                        } else {
                            document.getElementById("cbx0101GP01").checked = false;
                        };
                        document.getElementById("lbl0101GPNo").innerText = response[0].GPNo;
                        document.getElementById("lbl0101DeliverTo").innerText = response[0].DeliverTo;
                        document.getElementById("lbl0101AuthorizedBy").innerText = response[0].AuthorizedByName;
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
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Get Info - DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Type + " / " + response[0].IssuedToName;
                        document.getElementById("spn0101ID").innerText = response[0].IssueCode;
                        document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
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
                        document.getElementById("btn0101Delete").classList.add("btn-delete");
                        document.getElementById("btn0101Delete").disabled = false;
                        document.getElementById("btn0101Edit").classList.add("btn-edit");
                        document.getElementById("btn0101Edit").disabled = false;
                        document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.add("la-save");
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "none";
                        document.getElementById("div0101Update").style.display = "";
                        document.getElementById("tbx0101IssueNo").value = response[0].IssueNo;
                        document.getElementById("tbx0101IssueDate").value = response[0].IssueDate;
                        document.getElementById("tbx0101Status").value = response[0].Status;
                        $('#ddl0101Type').val(response[0].Type).trigger('change');
                        ddl0101Type_onchange(document.getElementById("ddl0101Type"));
                        ddl0101IssuedTo(response[0].IssuedTo);
                        document.getElementById("tbx0101Location").value = response[0].Location;
                        ddl0101IssuedBy(response[0].IssuedBy);
                        document.getElementById("ddl0101IssuedBy").disabled = true;
                        if (response[0].GP == "1") {
                            document.getElementById("cbx0101GP02").checked = true;
                        } else {
                            document.getElementById("cbx0101GP02").checked = false;
                        };
                        cbx0101GP02_onchange(document.getElementById("cbx0101GP02"));
                        document.getElementById("tbx0101GPNo").value = response[0].GPNo;
                        document.getElementById("tbx0101DeliverTo").value = response[0].DeliverTo;
                        ddl0101AuthorizedBy(response[0].AuthorizedBy);
                        document.getElementById("tbx0101UpdatedByName").value = response[0].UpdatedByName;
                        document.getElementById("tbx0101UpdatedDate").value = response[0].UpdatedDate;
                        document.getElementById("tbx0101LockedByName").value = response[0].LockedByName;
                        document.getElementById("tbx0101LockedDate").value = response[0].LockedDate;
                        //content

                    },
                });
            }
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('AMD030000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add() {
                document.getElementById("ContentPlaceHolder1_hdnMode").value = "ADD";
                document.getElementById("ContentPlaceHolder1_hdnID").value = "000000000000";
                fn01Load();
            };
        };
        function fn0101Delete() {
            if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                Cancel_Add_Question();
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('AMD030000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_FAIHdr', ID, '', 'Delete', function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Dtl_Question(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                Cancel_Upd_Question(document.getElementById('ContentPlaceHolder1_hdnID').value);
            }

            function Cancel_Add_Question() {
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
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.close();
                        } else {
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                            document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                            fn01Load();
                        }
                    }
                });
            };
            function Delete_Dtl_Question(ID) {
                Swal.fire({
                    text: 'Remove record?',
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
                        Detele_Ok(ID);
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('AMD030000', 'Trxn_FAIHdr', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener.fn01Redraw("Delete", ID);
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener.fn01Redraw("Delete", ID);
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                            document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                            document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        }
                    });
                };
            };
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
        function fn0101Edit() {
            //validate
            if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                //access
                fnAccess('AMD030000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('AMD030000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_FAIHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('AMD030000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_FAIHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            ValidateFields(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            }
            //validate fields
            function ValidateFields(ID) {
                if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "Issuance") && (document.getElementById("ddl0101IssuedTo").options[document.getElementById("ddl0101IssuedTo").selectedIndex].value == "")) {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "Returnable") && (document.getElementById("ddl0101IssuedTo").options[document.getElementById("ddl0101IssuedTo").selectedIndex].value == "")) {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Location").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("cbx0101GP02").checked == true) && (document.getElementById("tbx0101DeliverTo").value == "")) {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("cbx0101GP02").checked == true) && (document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value == "")) {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Edit_Question(ID);
                }
            }
            //question
            function Edit_Question(ID) {
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
                        if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                            Edit_Add_Ok_Await();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                            Edit_Dtl_Ok_Await();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                            Edit_Upd_Ok_Await(ID);
                        }
                    }
                });
            };
            //do edit
            function Edit_Add_Ok_Await() {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Add Record',
                        'pIssuedType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                        'pIssuedTo': document.getElementById("ddl0101IssuedTo").options[document.getElementById("ddl0101IssuedTo").selectedIndex].value,
                        'pLocation': document.getElementById("tbx0101Location").value,
                        'pIssuedBy': document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value,
                        'pGP': document.getElementById("cbx0101GP02").checked,
                        'DeliverTo': document.getElementById("tbx0101DeliverTo").value,
                        'AuthorizedBy': document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        window.opener.fn01Redraw("Add", response[0].oID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                        document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oID
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oID
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Edit Record',
                        'pID': ID,
                        'pIssuedType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                        'pIssuedTo': document.getElementById("ddl0101IssuedTo").options[document.getElementById("ddl0101IssuedTo").selectedIndex].value,
                        'pLocation': document.getElementById("tbx0101Location").value,
                        'pIssuedBy': document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value,
                        'pGP': document.getElementById("cbx0101GP02").checked,
                        'DeliverTo': document.getElementById("tbx0101DeliverTo").value,
                        'AuthorizedBy': document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        window.opener.fn01Redraw("Edit", ID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
        };
        function fn0101Lock() {
            //if exisit
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('AMD030000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_FAIHdr', ID, '', 'Lock', function (response) {
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
                                Lock_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'Trxn_FAIHdr', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exisit
            fnIfExist('Trxn_FAIHdr', 'FACode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('AMD030000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_FAIHdr', ID, '', 'Unlock', function (response) {
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
                                Unlock_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'Trxn_FAIHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Tools() {
            $('#mdl010101Tools').modal('show');
        };
        function fn010101_AMD03RPT01() {
            window.open('AMDRPTView?RPTCode=AMD03RPT01&pIssueCode=' + document.getElementById("ContentPlaceHolder1_hdnID").value);
        }
        //overview

        //asset
        function fn0102LoadAsset(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDAMD.ashx",
                data: {
                    'pFormCode': 'AMD030000',
                    'pType': 'Get Record - DTL - Asset - HDR',
                    'pID': pID,
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0102LoaderAsset").style.display = "";
                    //display loader

                    $('#table0102Asset').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0102Asset = $("#table0102Asset").DataTable({
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
                            { data: 'FACode' },
                            { data: 'Description' },
                            { data: 'Qty' },
                            { data: 'Unit' },
                            { data: 'TagNo' },
                            { data: 'DisposalAmt' },
                            { data: 'Remarks' }],
                        rowId: 'rowId',
                        columnDefs: [{ targets: 0, orderable: false }, { targets: 1, className: 'tbody-nowrap-auto' }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'dt-body-right' }, { targets: 4, className: 'tbody-nowrap-auto' }, { targets: 5, className: 'tbody-nowrap-auto' }, { targets: 6, className: 'dt-body-right' }, { targets: 7, className: 'tbody-nowrap-auto' },],
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx0102FindAsset').on('keyup', function () {
                        table0102Asset.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0102LoaderAsset").style.display = "none";
                    //hide loader

                    //action button
                    if (pMode == "ADD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    } else if (pMode = "DTL") {
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
        function fn0102Redraw(Action, IssueCode, FACode) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Redraw - DTL - Asset',
                        'pIssueCode': IssueCode,
                        'pFACode': FACode
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table0102Asset').DataTable();
                            gv01.rows().deselect();
                            var row01 = gv01.row.add({ Action: response[0].Action, FACode: response[0].FACode, Description: response[0].Description, Qty: response[0].Qty, Unit: response[0].Unit, TagNo: response[0].TagNo, DisposalAmt: response[0].DisposalAmt, Remarks: response[0].Remarks}).draw(false).select();
                            $(row01.node()).attr('id', response[0].rowId);
                            gv01.row({ selected: true }).scrollTo(false);
                            //add row

                            //select and go to record
                            let new01 = gv01.row('#' + response[0].rowId);
                            let index01 = new01.index();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        } else if (Action == "Edit") {
                            //edit row
                            var gv01 = $('#table0102Asset').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].FACode).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].Description).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Qty).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Unit).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].TagNo).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].DisposalAmt).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].Remarks).draw(false);
                            //edit row

                            //select and go to record
                            row01.select();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        };
                    },
                });
            } else {
                //assigned
                var gv01 = $('#table0102Asset').DataTable();
                gv01.row('#rowID0102' + FACode).remove().draw(false);
            };
        };
        function fn0102Add() {
            //if exisit
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('AMD030000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_FAIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Get Record - DTL - Asset - DTL',
                        'pIssueCode': document.getElementById('ContentPlaceHolder1_hdnID').value,
                        'pIssuedType': document.getElementById("lbl0101Type").innerText,
                    },
                    success: function (response) {
                        //hide loader
                        document.getElementById("div010201Loader").style.display = "";
                        //hide loader

                        $('#table010201Add').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table010201Add = $("#table010201Add").DataTable({
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
                                { data: 'FACode' },
                                { data: 'Description' },
                                { data: 'Qty' },
                                { data: 'Unit' },
                                { data: 'TagNo' },
                                { data: 'DisposalAmt' },
                                { data: 'Remarks' },
                                { data: 'Action' }],
                            rowId: 'rowId',
                            columnDefs: [{ targets: 0, className: 'tbody-nowrap-auto' }, { targets: 1, className: 'tbody-nowrap-auto' }, { targets: 2, className: 'tbody-nowrap-auto dt-body-right' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' },{ targets: 5, className: 'tbody-nowrap-auto' }, { targets: 6, className: 'tbody-nowrap-auto' }],
                            order: [[1, 'asc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx010201Find').on('keyup', function () {
                            table010201Add.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div010201Loader").style.display = "none";
                        //hide loader
                    },
                });
                $('#mdl0102Add').modal('show');
            };
        };
        async function fn010201Add_Ok(pIssueCode, pFACode, Btn) {
            //access
            fnAccess('AMD030000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn010201Add_Ok_Await(pIssueCode, pFACode, Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn010201Add_Ok_Await(pIssueCode, pFACode, Btn) {
                var tbx010201DisposalAmt = document.querySelector('[prm010201disposalamt="' + pFACode + '"]');
                var tbx010201Remarks = document.querySelector('[prm010201remarks="' + pFACode + '"]');
                //add
                $.ajax({
                    type: "POST",
                    url: "HNDAMD.ashx",
                    data: {
                        'pFormCode': 'AMD030000',
                        'pType': 'Add Record - DTL - Asset',
                        'pIssueCode': pIssueCode,
                        'pFACode': pFACode,
                        'pDisposalAmt': tbx010201DisposalAmt.value,
                        'pRemarks': tbx010201Remarks.value,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        //redraw
                        fn0102Redraw(response[0].oAction, pIssueCode, pFACode);
                        //status
                        document.getElementById("spn010201Add" + pFACode).innerText = 'Update';
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    },
                });
            };
        };
        function fn0102Delete(pIssueCode, pFACode) {
            //if exisit
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Delete(pIssueCode, pFACode);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Delete(pIssueCode, pFACode) {
                fnAccess('AMD030000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(pIssueCode, pFACode);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(pIssueCode, pFACode) {
                fnValidateRecord('Trxn_FAIHdr', pIssueCode, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(pIssueCode, pFACode);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //question
            function Delete_Question(pIssueCode, pFACode) {
                Swal.fire({
                    text: 'Remove record?',
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
                        Delete_Ok(pIssueCode, pFACode);
                    }
                });
            };
            function Delete_Ok(pIssueCode, pFACode) {
                fnDelete('AMD030000', 'Trxn_FAIDtl', pIssueCode + "-" + pFACode, function (response) {
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn0102Redraw("Delete", pIssueCode, pFACode);
                });
            };
        };
        //asset

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'AMD030000',
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
                    } else if (pMode = "DTL") {
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
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('AMD030000', 'Delete', function (response) {
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
                    'pFormCode': 'AMD030000',
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
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('Trxn_FAIHdr', 'IssueCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                            'pFormCode': 'AMD030000',
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

        //fixed column header alignment
        $(document).ready(function () {
            $('#ul0101Nav a.nav-link').on('shown.bs.tab', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
        });
        //fixed column header alignment

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
                    url: "HNDGEN.ashx?pFormCode=AMD030000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('AMD030000', 'Add', function (response) {
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
                    fnAccess('AMD030000', 'Add', function (response) {
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
                            fnAlertOnly('Attach atleast one file to proceed!', 'error', 'btn btn-danger');
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=AMD030000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //upload
            });
            jQuery(function ($) {
                fn01Load();
            });
        }
        //load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
