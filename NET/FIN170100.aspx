<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FIN170100.aspx.vb" Inherits="NET.FIN170100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
						<li class="breadcrumb-item text-white">Cost Estimate</li>
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
			<!--begin::app title-->
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/FIN170000.svg" alt="" />
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
            <!--end::app title-->
            <!--begin::nav app-->
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
            <!--end::nav app-->
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
								<div class="d-flex flex-wrap">
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
									<button id="btn0101Unlock" class="btn btn-sm btn-icon btn-lock align-self-center m-1" title="Unlock" onclick="fn0101Unlock();return false;"><i class="las la-unlock fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<div class="form-check form-check-custom form-check-success form-check-solid form-check-lg m-1">
										<input class="form-check-input" type="checkbox" value="" id="cbx0101Post" onclick="return false;"/>
									</div>
									<button id="btn0101Post" class="btn btn-sm btn-icon btn-post align-self-center m-1" title="Post" onclick="fn0101Post();return false;"><i class="las la-check-circle fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<div class="form-check form-check-custom form-check-success form-check-solid form-check-lg m-1">
										<input class="form-check-input" type="checkbox" value="" id="cbx0101Rvrs" onclick="return false;"/>
									</div>
									<button id="btn0101Cancel" class="btn btn-sm btn-icon btn-cancel align-self-center m-1" title="Cancel" onclick="fn0101Cancel();return false;"><i class="las la-times-circle fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<button id="btn0101Tools" class="btn btn-sm btn-icon btn-secondary align-self-center m-1" title="Tools" onclick="fn0101Tools();return false;"><i class="las la-cog fs-2"></i></button>
								</div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Estimate No.</span>
											<span id="lbl0101EstNo" class="form-control ">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Estimate Date</span>
											<span id="lbl0101EstDate" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Title</span>
											<span id="lbl0101Title" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Category</span>
											<span id="lbl0101Category" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Project</span>
											<span id="lbl0101Project" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Batch</span>
											<span id="lbl0101Batch" class="form-control">-</span>
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
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Posted By</span>
                                            <span id="lbl0101PostedByName" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <span id="lbl0101PostedDate" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Cancelled By</span>
                                            <span id="lbl0101CancelledByName" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <span id="lbl0101CancelledDate" class="form-control">-</span>
                                        </div>
                                    </div>
								</div>
							</div>
							<div id="div0101Update" class="card-body" style="display: none;">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Estimate No.</span>
											<input id="tbx0101EstNo" type="text" class="form-control " maxlength="13" Placeholder="Est. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px required">Estimate Date</span>
											<input id="tbx0101EstDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px required">Title</span>
											<input id="tbx0101Title" type="text" maxlength="180" class="form-control" Placeholder="Title" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Category</span>
											<select id="ddl0101Category" data-kt-repeater="select2" class="form-select form-select-sm form-select-border" onchange="ddl0101Category_onchange(this);">
												<option value="">Category</option>
												<option value="Amenities New">Amenities New</option>
												<option value="Amenities Repair">Amenities Repair</option>
												<option value="Shell to Basic">Shell to Basic</option>
												<option value="Basic to Complete">Basic to Complete</option>
												<option value="Shell to Classic">Shell to Classic</option>
												<option value="Classic to Premium">Classic to Premium</option>
												<option value="Shell to Complete">Shell to Complete</option>
												<option value="Shell to Premium">Shell to Premium</option>
												<option value="CLDC Office">CLDC Office</option>
												<option value="Clearing / Grass Cutting">Clearing / Grass Cutting</option>
												<option value="Container Van">Container Van</option>
												<option value="DOLE Application - Land Development">DOLE Application - Land Development</option>
												<option value="DOLE Application - Model House">DOLE Application - Model House</option>
												<option value="Electrical Consultant">Electrical Consultant</option>
												<option value="House Construction">House Construction</option>
												<option value="House Repair">House Repair</option>
												<option value="Interior Designer">Interior Designer</option>
												<option value="Land Development New">Land Development New</option>
												<option value="Land Development Repair">Land Development Repair</option>
												<option value="Land Scape Project New">Land Scape Project New</option>
												<option value="Land Scape Project Restoration">Land Scape Project Restoration</option>
												<option value="Land Scape Unit">Land Scape Unit</option>
												<option value="NWRB Application">NWRB Application</option>
												<option value="Security Services">Security Services</option>
												<option value="Service Entrance">Service Entrance</option>
												<option value="Structural Consultant - Amenities">Structural Consultant - Amenities</option>
												<option value="Structural Consultant - House Unit">Structural Consultant - House Unit</option>
												<option value="Temporary Facilities Construction">Temporary Facilities Construction</option>
												<option value="Testing and Investigation">Testing and Investigation</option>
												<option value="Utilities Repair">Utilities Repair</option>
												<option value="Waste Hauling Services">Waste Hauling Services</option>
												<option value="Summary">Summary</option>
												<option value="Street Lights">Street Lights</option>
											</select>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101Project" class="input-group-text min-w-150px required">Project</span>
											<select id="ddl0101Project" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Project</option>
											</select>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101Batch" class="input-group-text min-w-150px required">Batch</span>
											<select id="ddl0101Batch" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
												<option value="">Batch</option>
											</select>
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
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Posted By</span>
                                            <input id="tbx0101PostedByName" type="text" class="form-control" Placeholder="Posted By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101PostedDate" type="text" class="form-control" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Cancelled By</span>
                                            <input id="tbx0101CancelledByName" type="text" class="form-control" Placeholder="Cancelled By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101CancelledDate" type="text" class="form-control" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
								</div>
							</div>
							<!--end::Dtl-->
						</div>
						<!--end::Menu Content-->

                        <!--begin::Particular-->
						<div class="card-header border-0">
							<div class="d-flex align-items-center">
								<ul class="nav nav-tabs nav-line-tabs nav-line-tabs-2x fs-6 me-2">
									<li class="nav-item">
										<a class="nav-link active w-85px text-center" data-bs-toggle="tab" href="#tab0301">Budget</a>
									</li>
									<li class="nav-item">
										<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0302">Material</a>
									</li>
									<li class="nav-item">
										<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0303">Labor</a>
									</li>
									<li class="nav-item">
										<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0304">Convertion</a>
									</li>
								</ul>
							</div>
						</div>
						<div class="card">
                            <div class="tab-content" >
								<div class="tab-pane fade show active p-0" id="tab0301">
									<div class="card">
										<div class="border-top border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ml-5">
												</div>
												<div class="position-relative">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0301Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
										</div>
										<div class="table-responsive p-9">
                                            <div class="table-loading">
									            <div id="div0301LoaderRecord" class="table-loading-message">
										            Loading...
									            </div>
											    <table id="table0301Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
												    <thead class="fw-bold">
													    <tr class="fw-bold fs-7 text-gray-800">
														    <th class="min-w-50px mw-50px border-end">No</th>
														    <th class="min-w-200px mw-200px border-end">WBS Code</th>
														    <th class="min-w-150px mw-150px border-end">Type</th>
														    <th class="min-w-300px w-100 border-end">Particular</th>
														    <th class="min-w-150px mw-150px border-end">Cost</th>
														    <th class="min-w-75px mw-75px border-end">UOM</th>
														    <th class="min-w-150px mw-150px border-end">Budget</th>
														    <th class="min-w-150px mw-150px border-end">Release</th>
														    <th class="min-w-150px mw-150px border-end">Actualize</th>
														    <th class="min-w-150px mw-150px border-end">Commitment</th>
													    </tr>
												    </thead>
												    <tbody>

												    </tbody>
                                                    <tfoot>
											            <tr>
												            <th>Total</th>
												            <th></th>
												            <th></th>
												            <th></th>
												            <th class="text-end"></th>
												            <th></th>
												            <th class="text-end"></th>
												            <th class="text-end"></th>
												            <th class="text-end"></th>
												            <th class="text-end"></th>
											            </tr>
                                                    </tfoot>
											    </table>
                                            </div>
										</div>
									</div>
								</div>
								<div class="tab-pane fade p-0" id="tab0302">
									<div class="card">
										<div class="border-top border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ml-5">
                                                    <div class="dropdown">
                                                        <button id="btn0302Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Add Record">
                                                            <i class="las la-plus fs-2"></i>
                                                        </button>
                                                        <div class="dropdown-menu dropdown-menu-end" aria-labelledby="btn0302Add">
                                                            <div class="dropdown-item">
                                                                <a href="#" class="d-block py-2" onclick="fn0302AddManual(); return false;">
                                                                    Add Record
                                                                </a>
                                                            </div>
                                                            <div class="dropdown-item">
                                                                <a href="#" class="d-block py-2" onclick="fn0302AddUpload(); return false;">
                                                                    Upload Record
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
												</div>
												<div class="position-relative">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0302Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
                                            <div id="div0302CheckBox" class="d-flex justify-content-start mt-2">
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0302Estimate" />
												</div>
                                                <span class="d-flex justify-content-start pl-3">Estimate</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0302Request" />
												</div>
                                                <span class="d-flex justify-content-start pl-3">Request</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0302Purchase" />
												</div>
                                                <span class="d-flex justify-content-start pl-3">Purchase</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0302Issue" />
												</div>
                                                <span class="d-flex justify-content-start pl-3">Issue</span>
                                            </div>
										</div>
										<div class="table-responsive p-9">
                                            <div class="table-loading">
									            <div id="div0302LoaderRecord" class="table-loading-message">
										            Loading...
									            </div>
											    <table id="table0302Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
												    <thead class="fw-bold">
                                                        <tr>
                                                            <th class="fw-bold border-end" colspan="7"></th>
                                                            <th id="th0302Overall" class="fw-bold border-end" colspan="2">Overall</th>
                                                            <th id="th0302Estimate" class="fw-bold border-end" colspan="2">Estimate</th>
                                                            <th id="th0302Revision" class="fw-bold border-end" colspan="2">Revision</th>
                                                        </tr>
													    <tr class="fw-bold fs-7 text-gray-800">
														    <th class="min-w-50px mw-50px fw-bold border-end"></th>
														    <th class="min-w-50px mw-50px text-start border-end">No</th>
														    <th class="min-w-200px mw-200px border-end">WBS Code</th>
														    <th class="min-w-150px mw-150px border-end">Type</th>
														    <th class="min-w-300px w-100 border-end">Particular</th>
														    <th class="min-w-150px mw-150px text-start border-end">Cost</th>
														    <th class="min-w-75px mw-75px border-end">UOM</th>
														    <th class="min-w-150px mw-150px text-start border-end">Qty.</th>
														    <th class="min-w-150px mw-150px text-start border-end">Amount</th>
														    <th class="min-w-150px mw-150px text-start border-end">Qty.</th>
														    <th class="min-w-150px mw-150px text-start border-end">Amount</th>
														    <th class="min-w-150px mw-150px text-start border-end">Qty.</th>
														    <th class="min-w-150px mw-150px text-start border-end">Amount</th>
													    </tr>
												    </thead>
												    <tbody>

												    </tbody>
                                                    <tfoot>
													    <tr>
														    <th>Total</th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
													    </tr>
                                                    </tfoot>
											    </table>
                                            </div>
										</div>
									</div>
								</div>
								<div class="tab-pane fade p-0" id="tab0303">
									<div class="card">
										<div class="border-top border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ml-5">
                                                    <div class="dropdown">
                                                        <button id="btn0303Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Add Record">
                                                            <i class="las la-plus fs-2 d-flex"></i>
                                                        </button>
                                                        <div class="dropdown-menu dropdown-menu-end" aria-labelledby="btn0303Add">
                                                            <div class="dropdown-item">
                                                                <a href="#" class="d-block py-2" onclick="fn0303AddUpload(); return false;">
                                                                    Upload Record
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
												</div>
												<div class="position-relative">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0303Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
										</div>
										<div class="table-responsive p-9">
                                            <div class="table-loading">
									            <div id="div0303LoaderRecord" class="table-loading-message">
										            Loading...
									            </div>
											    <table id="table0303Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
												    <thead class="fw-bold">
													    <tr class="fw-bold fs-7 text-gray-800">
														    <th class="min-w-50px mw-50px fw-bold border-end"></th>
														    <th class="min-w-50px mw-50px border-end">No</th>
														    <th class="min-w-200px mw-200px border-end">WBS Code</th>
														    <th class="min-w-150px mw-150px border-end">Milestone</th>
														    <th class="min-w-200px w-100 border-end">Particular</th>
														    <th class="min-w-150px mw-150px border-end">WT</th>
														    <th class="min-w-150px mw-150px border-end">Commulative</th>
														    <th class="min-w-150px mw-150px border-end">Status</th>
													    </tr>
												    </thead>
												    <tbody>

												    </tbody>
                                                    <tfoot>
													    <tr>
														    <th>Total</th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th></th>
														    <th class="text-end"></th>
														    <th class="text-end"></th>
														    <th></th>
													    </tr>
                                                    </tfoot>
											    </table>
                                            </div>
										</div>
									</div>
								</div>
								<div class="tab-pane fade p-0" id="tab0304">
									<div class="card">
										<div class="border-top border-bottom border-gray-200 px-4 py-3">
											<div class="d-flex flex-stack">
												<div class="d-flex ml-5">
												</div>
												<div class="position-relative">
													<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
															<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
														</svg>
													</span>
													<input id="tbx0304Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
												</div>
											</div>
										</div>
										<div class="table-responsive p-9">
                                            <div class="table-loading">
									            <div id="div0304LoaderRecord" class="table-loading-message">
										            Loading...
									            </div>
											    <table id="table0304Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
												<thead class="fw-bold">
													<tr class="fw-bold fs-7 text-gray-800">
                                                        <th class="min-w-50px mw-50px fw-bold border-end"></th>
														<th class="min-w-50px mw-50px text-start border-end">No</th>
														<th class="min-w-200px mw-200px border-end">WBS Code</th>
														<th class="min-w-150px mw-150px border-end">Type</th>
														<th class="min-w-200px w-100 border-end">Particular</th>
														<th class="min-w-150px text-start mw-150px border-end">Cost</th>
														<th class="min-w-75px mw-75px border-end">UOM</th>
														<th class="min-w-250px text-start mw-250px border-end">Convertion Code</th>
														<th class="min-w-150px text-start mw-150px border-end">Convertion Qty.</th>
														<th class="min-w-150px text-start mw-150px border-end">Convertion Unit</th>
													</tr>
												</thead>
												<tbody>

												</tbody>
                                                <tfoot>
													<tr>
                                                        <th>Total</th>
                                                        <th></th>
                                                        <th></th>
                                                        <th></th>
                                                        <th></th>
                                                        <th class="text-end"></th>
                                                        <th></th>
                                                        <th></th>
                                                        <th class="text-end"></th>
                                                        <th></th>
													</tr>
                                                </tfoot>
											</table>
                                            </div>
										</div>
									</div>
								</div>
							</div>
						</div>
                        <!--end::Particular-->

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
			<!--end::Content-->
        </div>
        <!--end::title-->
        
		<!--begin::Modal Cancel-->
		<div id="mdl0101Cancel" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Cost Estimate - Cancel Record</h5>
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
					    <div class="input-group input-group-sm">
						    <span class="input-group-text min-w-150px required">Reason</span>
						    <input id="tbx0101Reason" type="text" class="form-control " Placeholder="Reason" maxlength="500" />
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
        
		<!--begin::Modal Tools -->
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
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Revision</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Cost Estimate)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cost Estimate</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Detail)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cost Estimate</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Summary)</div>
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
		<!--begin::Modal Tools -->

		<!--begin::Modal Edit Material record-->
		<div id="mdl010102CEDtl" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Report</h5>
                        <div class="d-flex align-items-center">
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
						<div class="col-sm-12 col-md-12 col-lg-12">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px required">Batch</span>
								<select id="ddl010102Batch" data-dropdown-parent="#mdl010102CEDtl" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
									<option value="">Batch</option>
								</select>
							</div>
						</div>
						<div class="col-sm-12 col-md-12 col-lg-12">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px required">Type</span>
								<select id="ddl010102Type" data-dropdown-parent="#mdl010102CEDtl" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
									<option value="">Type</option>
								</select>
							</div>
						</div>
                    </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010102Rpt_View(); return false;">
                             Submit
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Edit Material record-->
        
		<!--begin::Modal Edit Material record-->
		<div id="mdl010103CESummary" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Report</h5>
                        <div class="d-flex align-items-center">
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
						<div class="col-sm-12 col-md-12 col-lg-12">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px required">Batch</span>
								<select id="ddl010103Batch" data-dropdown-parent="#mdl010103CESummary" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
									<option value="">Batch</option>
								</select>
							</div>
						</div>
						<div class="col-sm-12 col-md-12 col-lg-12">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px required">Type</span>
								<select id="ddl010103Type" data-dropdown-parent="#mdl010103CESummary" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
									<option value="">Type</option>
									<option value="All">All</option>
									<option value="OSM">OSM</option>
									<option value="Straight">Straight</option>
								</select>
							</div>
						</div>
                    </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010103Rpt_View(); return false;">
                             Submit
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Edit Material record-->
        
		<!--begin::Modal Add Revision record-->
		<div id="mdl0101AddRvrs" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Revision</h5>
                        <div class="d-flex align-items-center">
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Scope of Work</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0101RvrsScope" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Scope of Work" readonly="readonly" />
                                <input id="hf0101RvrsScopeCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101RvrsScope(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Particular</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0101RvrsParticular" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Particular" readonly="readonly" />
                                <input id="hf0101RvrsParticular" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101RvrsParticular(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Qty</span>
						    <input id="tbx0101RvrsQty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberRvrsQty(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" />
					    </div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">UOM</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0101RvrsUOM" type="text" class="form-control form-control-sm border-0 m-0" placeholder="UOM" readonly="readonly" />
                                <input id="hf0101RvrsUOMCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101RvrsUOM(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Cost</span>
						    <input id="tbx0101RvrsCost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberRvrsCost(this);"  type="text" class="form-control" Placeholder="Cost" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Total</span>
						    <input id="tbx0101RvrsTotal" type="text" class="form-control" Placeholder="Total" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Remarks</span>
						    <input id="tbx0101RvrsRemarks" type="text" class="form-control min-h-75px" Placeholder="Remarks" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010101Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add Revision record-->
        
		<!--begin::Modal Scope record -->
		<div id="mdl0101ScopeRvrs" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Scope of Work</h5>
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
                                    <input id="tbx010101FindRvrs" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010101LoaderRvrs" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010101RecordRvrs" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Scope record-->
        
		<!--begin::Modal Particular record -->
		<div id="mdl0102ParticularRvrs" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Particular</h5>
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
                                    <input id="tbx010102FindRvrs" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010102LoaderRvrs" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010102RecordRvrs" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Particular record-->
        
		<!--begin::Modal Unit record -->
		<div id="mdl0103UnitRvrs" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Unit</h5>
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
                                    <input id="tbx010103FindRvrs" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010103LoaderRvrs" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010103RecordRvrs" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Unit record-->
        
		<!--begin::Modal Add Material record-->
		<div id="mdl0302Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Add record</h5>
                        <div class="d-flex align-items-center">
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Scope of Work</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0302AddScope" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Scope of Work" readonly="readonly" />
                                <input id="hf0302AddScopeCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0302AddScope(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Particular</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0302AddParticular" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Particular" readonly="readonly" />
                                <input id="hf0302AddParticularCode" runat="server" type="hidden" value="" />
                                <input id="hf0302AddType" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0302AddParticular(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Qty</span>
						    <input id="tbx0302AddQty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddQty(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" />
					    </div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">UOM</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0302AddUOM" type="text" class="form-control form-control-sm border-0 m-0" placeholder="UOM" readonly="readonly" />
                                <input id="hf0302AddUOMCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0302AddUOM(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Cost</span>
						    <input id="tbx0302AddCost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddCost(this);"  type="text" class="form-control" Placeholder="Cost" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Total</span>
						    <input id="tbx0302AddTotal" type="text" class="form-control" Placeholder="Total" readonly />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn030200Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add Material record-->
        
		<!--begin::Modal Scope record -->
		<div id="mdl0302ScopeManual" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Scope of Work</h5>
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
                                    <input id="tbx030201FindManual" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030201LoaderManual" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030201RecordManual" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Scope record-->
        
		<!--begin::Modal Particular record -->
		<div id="mdl0302ParticularManual" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Particular</h5>
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
                                    <input id="tbx030202FindManual" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030202LoaderManual" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030202RecordManual" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Particular record-->
        
		<!--begin::Modal Unit record -->
		<div id="mdl0302UnitManual" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Unit</h5>
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
                                    <input id="tbx030203FindManual" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030203LoaderManual" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030203RecordManual" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Unit record-->
        
		<!--begin::Modal Edit Material record-->
		<div id="mdl0302Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Edit record</h5>
                        <div class="d-flex align-items-center">
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Scope of Work</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0302Scope" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Scope of Work" readonly="readonly" />
                                <input id="hf0302ScopeCode" runat="server" type="hidden" value="" />
                                <input id="hf0302SeqNo" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0302Scope(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Particular</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0302Particular" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Particular" readonly="readonly" />
                                <input id="hf0302ParticularCode" runat="server" type="hidden" value="" />
                                <input id="hf0302Type" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0302Particular(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Qty</span>
						    <input id="tbx0302Qty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdQty(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" />
					    </div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">UOM</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0302UOM" type="text" class="form-control form-control-sm border-0 m-0" placeholder="UOM" readonly="readonly" />
                                <input id="hf0302UOMCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0302UOM(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Cost</span>
						    <input id="tbx0302Cost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdCost(this);"  type="text" class="form-control" Placeholder="Cost" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Total</span>
						    <input id="tbx0302Total" type="text" class="form-control" Placeholder="Total" readonly />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn030201Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Edit Material record-->
        
		<!--begin::Modal Scope record -->
		<div id="mdl0302Scope" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Scope of Work</h5>
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
                                    <input id="tbx030201Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030201Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030201Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Scope record-->
        
		<!--begin::Modal Particular record -->
		<div id="mdl0302Particular" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Particular</h5>
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
                                    <input id="tbx030202Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030202Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030202Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Particular record-->
        
		<!--begin::Modal Unit record -->
		<div id="mdl0302Unit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Unit</h5>
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
                                    <input id="tbx030203Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030203Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030203Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Unit record-->
        
		<!--begin::Modal Add Material record-->
		<div id="mdl0302AddUpload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Upload record</h5>
                        <div class="d-flex align-items-center">
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
                         <div class="row gx-2 gy-2">
                            <div class="row gx-2 gy-2 mb-2">
                                <div class="col-md-12">
                                    <div class="input-group input-group-sm mb-2 w-100">
                                        <button class="btn btn-secondary btn-sm w-150px" type="button" onclick="document.getElementById('excelFileInput').click();">
                                            Choose file
                                        </button>
                                        <input type="file" id="excelFileInput" accept=".xlsx" class="form-control d-none" />
                                        <input type="text" id="ExcelTextBoxX" readonly="readonly" class="form-control form-control-sm" placeholder="No file chosen..." />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="table-loading" style="min-height:62.3vh;">
                            <div id="div0302LoaderUpload" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0302RecordUpload" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					            <thead>
						            <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-150px fw-bold border-end">Work</th>
                                        <th class="min-w-75px fw-bold border-end">Type</th>
                                        <th class="min-w-75px fw-bold border-end">Code</th>
                                        <th class="min-w-250px fw-bold border-end">Particular</th>
                                        <th class="min-w-75px fw-bold border-end">Cost</th>
                                        <th class="min-w-75px fw-bold border-end">Unit</th>
                                        <th class="min-w-75px fw-bold border-end">Qty</th>
                                        <th class="min-w-75px fw-bold border-end">Total</th>
                                        <th class="min-w-75px fw-bold border-end">Status</th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
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
                         <a href="#" id="fn030203Add_ID" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn030203Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add Material record-->
        
		<!--begin::Modal Add Material record-->
		<div id="mdl0303AddUpload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Upload record</h5>
                        <div class="d-flex align-items-center">
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
                         <div class="row gx-2 gy-2">
                            <div class="row gx-2 gy-2 mb-2">
                                <div class="col-md-12">
                                    <div class="input-group input-group-sm mb-2 w-100">
                                        <button class="btn btn-secondary btn-sm w-150px" type="button" onclick="document.getElementById('excelFileInputLabor').click();">
                                            Choose file
                                        </button>
                                        <input type="file" id="excelFileInputLabor" accept=".xlsx" class="form-control d-none" />
                                        <input type="text" id="ExcelTextBoxXLabor" readonly="readonly" class="form-control form-control-sm" placeholder="No file chosen..." />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="table-loading" style="min-height:62.3vh;">
                            <div id="div0303LoaderUpload" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0303RecordUpload" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					            <thead>
						            <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-150px fw-bold border-end">Work</th>
                                        <th class="min-w-75px fw-bold border-end">WBS Code</th>
                                        <th class="min-w-250px fw-bold border-end">Particular</th>
                                        <th class="min-w-75px fw-bold border-end">WT</th>
                                        <th class="min-w-75px fw-bold border-end">Commulative</th>
                                        <th class="min-w-75px fw-bold border-end">Status</th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
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
                         <a href="#" id="fn030303Add_ID" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn030303Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add Material record-->
        
		<!--begin::Modal Edit Labor record-->
		<div id="mdl0303Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Edit record</h5>
                        <div class="d-flex align-items-center">
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Scope of Work</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0303Scope" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Scope of Work" readonly="readonly" />
                                <input id="hf0303SeqNo" runat="server" type="hidden" value="" />
							</div>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Particular</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0303Particular" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Particular" readonly="readonly" />
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Milestone</span>
						    <input id="tbx0303Milestone"  type="text" class="form-control" maxlength="21" Placeholder="Milestone" value="0" readonly="readonly" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">WT</span>
						    <input id="tbx0303WT" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdWT(this);"  type="text" class="form-control" Placeholder="WT" value="0.00" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Commulative</span>
						    <input id="tbx0303Commulative" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdCommulative(this);"  type="text" class="form-control" Placeholder="Commulative" value="0.00" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn030301Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Edit Labor record-->
        
		<!--begin::Modal Edit Convertion record-->
		<div id="mdl0304Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Edit record</h5>
                        <div class="d-flex align-items-center">
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Convertion Item</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0304Item" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Item" readonly="readonly" />
                                <input id="hf0304ItemCode" runat="server" type="hidden" value="" />
                                <input id="hf0304ItemNo" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0304Item(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Convertion Qty</span>
						    <input id="tbx0304Qty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberNum(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" />
					    </div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Convertion Unit</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx0304Unit" type="text" class="form-control form-control-sm border-0 m-0" placeholder="UOM" readonly="readonly" />
                                <input id="hf0304UnitCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0304UOM(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn030401Add_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Edit Convertion record-->
        
		<!--begin::Modal Particular record -->
		<div id="mdl0304Item" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Item</h5>
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
                                    <input id="tbx030401Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030401Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030401Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Particular record-->
        
		<!--begin::Modal Unit record -->
		<div id="mdl0304Unit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cost Estimate - Unit</h5>
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
                                    <input id="tbx030402Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div030402Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table030402Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
										<th class="min-w-200px w-100 fw-bold border-end">Description</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Unit record-->
        
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

    
	<!--param-->
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<!--param-->
	
	<!-- script related to this page -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <script type="text/javascript">

		//variable
		var FileCount = 0;
        //variable

        //numeric
        function formatNumber(value) {
            return new Intl.NumberFormat('en-US', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }).format(value);
        };
        function fnEnterKeyNumber(event, inputId) {
            const key = event.key;
            // Allow only the following keys: numbers (0-9), decimal point, backspace, delete, arrow keys
            if (
                (key >= '0' && key <= '9') ||    // Allow 0-9
                key === '.' ||                   // Allow decimal point
                key === 'Backspace' ||           // Allow backspace
                key === 'ArrowLeft' ||           // Allow left arrow key
                key === 'ArrowRight' ||          // Allow right arrow key
                key === 'ArrowUp' ||             // Allow up arrow key
                key === 'ArrowDown' ||           // Allow down arrow key
                key === 'Delete'                 // Allow delete key
            ) {
                return true; // Allow the key press
            };
            // Prevent any other keys (including letters and special characters)
            event.preventDefault();
            return false;
        };
        function fnFormatNumberNum(input) {
            var Num = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(Num);
        };
        function fnFormatNumberAddQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("tbx0302AddCost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx0302AddTotal").value = formatNumber(Total);
        };
        function fnFormatNumberAddCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Qty = parseFloat(document.getElementById("tbx0302AddQty").value.replace(/,/g, '')) || 0.00;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx0302AddTotal").value = formatNumber(Total);
        };
        function fnFormatNumberUpdQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("tbx0302Cost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx0302Total").value = formatNumber(Total);
        };
        function fnFormatNumberUpdCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Qty = parseFloat(document.getElementById("tbx0302Qty").value.replace(/,/g, '')) || 0.00;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx0302Total").value = formatNumber(Total);
        };
        function fnFormatNumberRvrsQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("tbx0101RvrsCost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx0101RvrsTotal").value = formatNumber(Total);
        };
        function fnFormatNumberRvrsCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Qty = parseFloat(document.getElementById("tbx0101RvrsQty").value.replace(/,/g, '')) || 0.00;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx0101RvrsTotal").value = formatNumber(Total);
        };
        function fnFormatNumberUpdWT(input) {
            var WT = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(WT);
        };
        function fnFormatNumberUpdCommulative(input) {
            var WT = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(WT);
        };
        //numeric

		//general
		function fn01Load() {
            fnAccess('FIN170000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadBudget(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadMaterial(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadLabor(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadConvertion(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                document.getElementById("btn0302Add").classList.add("d-none");
                document.getElementById("btn0302Add").classList.remove("disabled");
                document.getElementById("div0302CheckBox").classList.add("d-none");
                document.getElementById("btn0303Add").classList.add("d-none");
                document.getElementById("btn0303Add").classList.remove("disabled");
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Lock").classList.remove("btn-lock");
                document.getElementById("btn0101Unlock").classList.remove("btn-lock");
                document.getElementById("btn0101Post").classList.remove("btn-post");
                document.getElementById("btn0101Cancel").classList.remove("btn-cancel");
                document.getElementById("btn0101Tools").classList.remove("btn-secondary");
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
                document.getElementById("btn0302Add").classList.remove("d-none");
                document.getElementById("btn0302Add").classList.add("btn-add");
                document.getElementById("div0302CheckBox").classList.remove("d-none");
                document.getElementById("btn0303Add").classList.remove("d-none");
                document.getElementById("btn0303Add").classList.add("btn-add");
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Lock").classList.add("btn-lock");
                document.getElementById("btn0101Unlock").classList.add("btn-lock");
                document.getElementById("btn0101Post").classList.add("btn-post");
                document.getElementById("btn0101Cancel").classList.add("btn-cancel");
                document.getElementById("btn0101Tools").classList.add("btn-secondary");
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
            document.getElementById("btn0302Add").disabled = pValue;
            document.getElementById("btn0303Add").disabled = pValue;
            document.getElementById("btn0101Delete").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Lock").disabled = pValue;
            document.getElementById("btn0101Unlock").disabled = pValue;
            document.getElementById("btn0101Post").disabled = pValue;
            document.getElementById("btn0101Cancel").disabled = pValue;
            document.getElementById("btn0101Tools").disabled = pValue;
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
        function ddl0101Category_onchange(ddl0101Category) {
            document.getElementById("spn0101Project").classList.remove("required");
            $('#ddl0101Project').val('').trigger('change');
            document.getElementById("ddl0101Project").disabled = true;
            document.getElementById("spn0101Batch").classList.remove("required");
            $('#ddl0101Batch').val('').trigger('change');
            document.getElementById("ddl0101Batch").disabled = true;
            if (ddl0101Category.options[ddl0101Category.selectedIndex].value != "") {
                document.getElementById("spn0101Project").classList.add("required");
                ddl0101Project(ddl0101Category.options[ddl0101Category.selectedIndex].value, '');
                $('#ddl0101Project').val('').trigger('change');
                document.getElementById("ddl0101Project").disabled = false;
            };
            if (ddl0101Category.options[ddl0101Category.selectedIndex].value == "House Construction") {
                document.getElementById("spn0101Batch").classList.add("required");
                ddl0101Batch(ddl0101Category.options[ddl0101Category.selectedIndex].value, '');
                $('#ddl0101Batch').val('').trigger('change');
                document.getElementById("ddl0101Batch").disabled = false;
            };
        };
        function ddl0101Project(pCategory, ID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Get Record',
                    'pTblName': pCategory,
                    'pPlaceHolder': 'Project'
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101Project").html(s);
                    $('#ddl0101Project').val(ID).trigger('change');
                },
            });
        };
        function ddl0101Batch(pCategory, ID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Get Record',
                    'pTblName': "Trxn_CEDtl(Batch)",
                    'pPlaceHolder': 'Batch',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101Batch").html(s);
                    $('#ddl0101Batch').val(ID).trigger('change');
                },
            });
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
                document.getElementById("cbx0101Lock").checked = false;
                document.getElementById("cbx0101Post").checked = false;
                document.getElementById("cbx0101Rvrs").checked = false;
                //toolbar

                //content
                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";
                document.getElementById("tbx0101EstNo").value = "";
                document.getElementById("tbx0101EstDate").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                document.getElementById("tbx0101Title").value = "";
                $('#ddl0101Category').val('').trigger('change');
                $('#ddl0101Project').val('').trigger('change');
                $('#ddl0101Batch').val('').trigger('change');
                document.getElementById("tbx0101UpdatedByName").value = "";
                document.getElementById("tbx0101UpdatedDate").value = "";
                document.getElementById("tbx0101LockedByName").value = "";
                document.getElementById("tbx0101LockedDate").value = "";
                document.getElementById("tbx0101PostedByName").value = "";
                document.getElementById("tbx0101PostedDate").value = "";
                document.getElementById("tbx0101CancelledByName").value = "";
                document.getElementById("tbx0101CancelledDate").value = "";
                //content
            } else if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Cost Estimate - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101ID").innerText = response[0].CECode;
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
                        document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.remove("la-save");
                        fn01DisableButtons(false);
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        if (response[0].Post == "1") {
                            document.getElementById("cbx0101Post").checked = true;
                        } else {
                            document.getElementById("cbx0101Post").checked = false;
                        };
                        if (response[0].Rvrs == "1") {
                            document.getElementById("cbx0101Rvrs").checked = true;
                        } else {
                            document.getElementById("cbx0101Rvrs").checked = false;
                        };
                        //checkbox

                        //content
                        document.getElementById("div0101Detail").style.display = "";
                        document.getElementById("div0101Update").style.display = "none";
                        document.getElementById("lbl0101EstNo").innerText = response[0].EstNo;
                        document.getElementById("lbl0101EstDate").innerText = response[0].EstDate;
                        document.getElementById("lbl0101Title").innerText = response[0].Title;
                        document.getElementById("lbl0101Category").innerText = response[0].Category;
                        document.getElementById("lbl0101Project").innerText = response[0].SubdivisionName;
                        document.getElementById("lbl0101Batch").innerText = (response[0].Batch == "" || response[0].Batch == null) ? "-" : response[0].Batch;
                        document.getElementById("lbl0101UpdatedByName").innerText = (response[0].UpdatedByName == "" || response[0].UpdatedByName == null) ? "-" : response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = (response[0].UpdatedDate == "" || response[0].UpdatedDate == null) ? "-" : response[0].UpdatedDate;
                        document.getElementById("lbl0101LockedByName").innerText = (response[0].LockedByName == "" || response[0].LockedByName == null) ? "-" : response[0].LockedByName;
                        document.getElementById("lbl0101LockedDate").innerText = (response[0].LockedDate == "" || response[0].LockedDate == null) ? "-" : response[0].LockedDate;
                        document.getElementById("lbl0101PostedByName").innerText = (response[0].PostedByName == "" || response[0].PostedByName == null) ? "-" : response[0].PostedByName;
                        document.getElementById("lbl0101PostedDate").innerText = (response[0].PostedDate == "" || response[0].PostedDate == null) ? "-" : response[0].PostedDate;
                        document.getElementById("lbl0101CancelledByName").innerText = (response[0].CancelledByName == "" || response[0].CancelledByName == null) ? "-" : response[0].CancelledByName;
                        document.getElementById("lbl0101CancelledDate").innerText = (response[0].ReversedDate == "" || response[0].ReversedDate == null) ? "-" : response[0].ReversedDate;
                        //content

                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Cost Estimate - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].Title;
                        document.getElementById("spn0101ID").innerText = response[0].CECode;
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
                        if (response[0].Post == "1") {
                            document.getElementById("cbx0101Post").checked = true;
                        } else {
                            document.getElementById("cbx0101Post").checked = false;
                        };
                        if (response[0].Rvrs == "1") {
                            document.getElementById("cbx0101Rvrs").checked = true;
                        } else {
                            document.getElementById("cbx0101Rvrs").checked = false;
                        };
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "none";
                        document.getElementById("div0101Update").style.display = "";
                        document.getElementById("tbx0101EstNo").value = response[0].EstNo;
                        document.getElementById("tbx0101Title").value = response[0].Title;
                        document.getElementById("tbx0101EstDate").value = response[0].EstDate;
                        $('#ddl0101Category').val(response[0].Category).trigger('change');
                        ddl0101Project(response[0].Category, response[0].Subdivision);
                        ddl0101Batch(response[0].Category, response[0].Batch);
                        document.getElementById("tbx0101UpdatedByName").value = (response[0].UpdatedByName == "" || response[0].UpdatedByName == null ? "-" : response[0].UpdatedByName);
                        document.getElementById("tbx0101UpdatedDate").value = (response[0].UpdatedDate == "" || response[0].UpdatedDate == null) ? "-" : response[0].UpdatedDate;
                        document.getElementById("tbx0101LockedByName").value = (response[0].LockedByName == "" || response[0].LockedByName == null) ? "-" : response[0].LockedByName;
                        document.getElementById("tbx0101LockedDate").value = (response[0].LockedDate == "" || response[0].LockedDate == null) ? "-" : response[0].LockedDate;
                        document.getElementById("tbx0101PostedByName").value = (response[0].PostedByName == "" || response[0].PostedByName == null) ? "-" : response[0].PostedByName;
                        document.getElementById("tbx0101PostedDate").value = (response[0].PostedDate == "" || response[0].PostedDate == null) ? "-" : response[0].PostedDate;
                        document.getElementById("tbx0101CancelledByName").value = (response[0].CancelledByName == "" || response[0].CancelledByName == null) ? "-" : response[0].CancelledByName;
                        document.getElementById("tbx0101CancelledDate").value = (response[0].ReversedDate == "" || response[0].ReversedDate == null) ? "-" : response[0].ReversedDate;
                        //content

                    },
                });
            };
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('FIN170000', 'Add', function (response) {
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
            if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "ADD") {
                Cancel_Add_Question();
            } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "DTL") {
                //if exisit
                fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('FIN170000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_CEHdr', ID, '', 'Delete', function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Dtl_Question(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "UPD") {
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
                            fn0101Refresh();
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
                        fnValidateRecord('Trxn_CEHdr', ID, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Detele_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('FIN170000', 'Trxn_CEHdr', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("FIN170000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("FIN170000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                            document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                            document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                            fn0102LoadBudget(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                            fn0102LoadMaterial(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                            fn0102LoadLabor(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                            fn0102LoadConvertion(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                        fn0102LoadBudget(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadMaterial(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadLabor(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadConvertion(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    }
                });
            };
        };
        function fn0101Edit() {
            //validate
            if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                //access
                fnAccess('FIN170000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('FIN170000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('FIN170000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
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
                if (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value != "" && document.getElementById("ddl0101Project").options[document.getElementById("ddl0101Project").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value == "House Construction" && document.getElementById("ddl0101Batch").options[document.getElementById("ddl0101Batch").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101EstDate").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Title").value == "") {
                    //Alert
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
                            fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Edit_Upd_Ok_Await(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        }
                    }
                });
            };
            //do edit
            function Edit_Add_Ok_Await() {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Cost Estimate - Add Record',
                        'pCEDate': document.getElementById("tbx0101EstDate").value,
                        'pTitle': document.getElementById("tbx0101Title").value,
                        'pCategory': document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value,
                        'pProject': document.getElementById("ddl0101Project").options[document.getElementById("ddl0101Project").selectedIndex].value,
                        'pBatch': document.getElementById("ddl0101Batch").options[document.getElementById("ddl0101Batch").selectedIndex].value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Add", response[0].oID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oID;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadBudget(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadMaterial(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadLabor(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadConvertion(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD";
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0102LoadBudget(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0102LoadMaterial(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0102LoadLabor(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0102LoadConvertion(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                // Do Update
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Cost Estimate - Edit Record',
                        'pID': ID,
                        'pCEDate': document.getElementById("tbx0101EstDate").value,
                        'pTitle': document.getElementById("tbx0101Title").value,
                        'pCategory': document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value,
                        'pProject': document.getElementById("ddl0101Project").options[document.getElementById("ddl0101Project").selectedIndex].value,
                        'pBatch': document.getElementById("ddl0101Batch").options[document.getElementById("ddl0101Batch").selectedIndex].value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadBudget(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadMaterial(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadLabor(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadConvertion(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
        };
        function fn0101Lock() {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Lock', function (response) {
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Lock', function (response) {
                                    if (response[0].oReturn == "") {
                                        Lock_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'Trxn_CEHdr', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Unlock', function (response) {
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Unlock', function (response) {
                                    if (response[0].oReturn == "") {
                                        Unlock_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'Trxn_CEHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Post() {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Post', function (response) {
                    if (response[0].oReturn == "") {
                        Post_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function Post_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Post record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101PostPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
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
                        fnValidatePassword(document.getElementById("tbx0101PostPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Post', function (response) {
                                    if (response[0].oReturn == "") {
                                        Post_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function Post_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'Type': "Post",
                        'pRecType': "Cost Estimate",
                        'pTblCode': ID,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully posted.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            }
        };
        function fn0101Cancel() {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Reverse', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        $('#mdl0101Cancel').modal('show');
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
        };
        function fn0101Cancel_Ok(Btn) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Cancel_Ok();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            async function Cancel_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn0101Cancel_Ok_Await(Btn);
            }
        };
        function fn0101Cancel_Ok_Await(Btn) {
            // process
            return new Promise(resolve => {
                //Validate
                if (document.getElementById("tbx0101Reason").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    //Modal
                    $('#mdl0101Cancel').modal('hide');
                    Cancel_Question();
                }
                function Cancel_Question() {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Cancel record?</span>',
                        icon: 'question',
                        html: `<input id="tbx0101CancelPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
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
                            fnValidatePassword(document.getElementById("tbx0101CancelPassword").value, function (response) {
                                if (response[0].oReturn == "") {
                                    fnValidateRecord('Trxn_CEHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Reverse', function (response) {
                                        if (response[0].oReturn == "") {
                                            Add_Cancel_Await();
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        } else {
                            $('#mdl0101Cancel').modal('show');
                        }
                    });
                };
                //add
                function Add_Cancel_Await() {
                    // Do Cancellation
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM140100',
                            'Type': 'Cost Estimate - Cancel Record',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pReason': document.getElementById("tbx0101Reason").value
                        },
                        success: function (response) {
                            //cancel
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            document.getElementById("tbx0101Reason").value = "";
                            if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", document.getElementById('ContentPlaceHolder1_hdnID').value);
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
        function fn0101Tools() {
            $('#mdl010101Tools').modal('show');
        };
        function fn010101_SCM03TLS01() {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save(Rvsn)', function (response) {
                    if (response[0].oReturn == "") {
                        Add(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //add
            function Add(ID) {
                document.getElementById("tbx0101RvrsScope").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101RvrsScopeCode").value = "";
                document.getElementById("tbx0101RvrsParticular").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101RvrsParticular").value = "";
                document.getElementById("tbx0101RvrsQty").value = "0.00";
                document.getElementById("tbx0101RvrsUOM").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101RvrsUOMCode").value = "";
                document.getElementById("tbx0101RvrsCost").value = "0.00";
                document.getElementById("tbx0101RvrsTotal").value = "0.00";
                document.getElementById("tbx0101RvrsTotal").value = "0.00";
                //modal
                $('#mdl010101Tools').modal('hide');
                $('#mdl0101AddRvrs').modal('show');
            };
        };
        function fn010101_SCM03RPT01() {
            //access
            fnAccess('FIN170000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    ddl010102Batch('');
                    ddl010102Type('');
                    $("#mdl010101Tools").modal("hide");
                    $("#mdl010102CEDtl").modal("show");
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function ddl010102Batch(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record',
                        'pTblName': 'Trxn_CEHdr(Batch)',
                        'pPlaceHolder': 'Batch',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl010102Batch").html(s);
                        $('#ddl010102Batch').val(ID).trigger('change');
                    },
                });
            };
            function ddl010102Type(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record',
                        'pTblName': 'Cost_Estimate(Type)',
                        'pPlaceHolder': 'Type',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl010102Type").html(s);
                        $('#ddl010102Type').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn010102Rpt_View() {
            //access
            fnAccess('FIN170000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    if (document.getElementById("ddl010102Batch").options[document.getElementById("ddl010102Batch").selectedIndex].value === "") {
                        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl010102Type").options[document.getElementById("ddl010102Type").selectedIndex].value === "") {
                        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                    } else {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Preview RDLC',
                                'pReport': "Cost Estimate - Detail",
                                'pBatch': document.getElementById("ddl010102Batch").options[document.getElementById("ddl010102Batch").selectedIndex].value,
                                'pRecType': document.getElementById("ddl010102Type").options[document.getElementById("ddl010102Type").selectedIndex].value
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                };
                                $('#mdl010102CEDtl').modal('hide');
                            }
                        });
                    };
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT02() {
            //access
            fnAccess('FIN170000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    ddl010103Batch('');
                    $('#ddl010103Type').val('').trigger('change');
                    $("#mdl010101Tools").modal("hide");
                    $("#mdl010103CESummary").modal("show");
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function ddl010103Batch(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record',
                        'pTblName': 'Trxn_CEHdr(Batch)',
                        'pPlaceHolder': 'Batch',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl010103Batch").html(s);
                        $('#ddl010103Batch').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn010103Rpt_View() {
            //access
            fnAccess('FIN170000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    if (document.getElementById("ddl010103Batch").options[document.getElementById("ddl010103Batch").selectedIndex].value === "") {
                        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl010103Type").options[document.getElementById("ddl010103Type").selectedIndex].value === "") {
                        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                    } else {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Preview RDLC',
                                'pReport': "Cost Estimate - Summary",
                                'pBatch': document.getElementById("ddl010103Batch").options[document.getElementById("ddl010103Batch").selectedIndex].value,
                                'pRecType': document.getElementById("ddl010103Type").options[document.getElementById("ddl010103Type").selectedIndex].value
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                };
                                $('#mdl010103CESummary').modal('hide');
                            }
                        });
                    };
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //overview

        //revision
        function fn0101RvrsScope() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Get Revision Scope'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010101LoaderRvrs").style.display = "";
                    //display loader

                    $('#table010101RecordRvrs').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010101RecordRvrs = $("#table010101RecordRvrs").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010101FindRvrs').on('keyup', function () {
                        table010101RecordRvrs.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010101LoaderRvrs").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0101ScopeRvrs').modal('show');
                },
            });
        };
        function fn010101Add_Scope(pWCode, pDesc, pLock) {
            //validate
            if (pLock == 1) {
                Scope(pWCode, pDesc);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Scope(pWCode, pDesc) {
                //bind
                document.getElementById("tbx0101RvrsScope").value = pDesc;
                document.getElementById("ContentPlaceHolder1_hf0101RvrsScopeCode").value = pWCode;
                $('#mdl0101ScopeRvrs').modal('hide');
            };
        };
        function fn0101RvrsParticular() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Get Revision Particular'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010102LoaderRvrs").style.display = "";
                    //display loader

                    $('#table010102RecordRvrs').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010102RecordRvrs = $("#table010102RecordRvrs").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010102FindRvrs').on('keyup', function () {
                        table010102RecordRvrs.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010102LoaderRvrs").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0102ParticularRvrs').modal('show');
                },
            });
        };
        function fn010102Add_Particular(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Item',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0101RvrsParticular").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0101RvrsParticular").value = response[0].Code;
                        document.getElementById("tbx0101RvrsUOM").value = response[0].UOMName;
                        document.getElementById("ContentPlaceHolder1_hf0101RvrsUOMCode").value = response[0].UOMCode;
                        //modal
                        $('#mdl0102ParticularRvrs').modal('hide');
                    },
                });
            };
        };
        function fn0101RvrsUOM() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Get Revision Unit'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010103LoaderRvrs").style.display = "";
                    //display loader

                    $('#table010103RecordRvrs').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010103RecordRvrs = $("#table010103RecordRvrs").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010103FindRvrs').on('keyup', function () {
                        table010103RecordRvrs.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010103LoaderRvrs").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0103UnitRvrs').modal('show');
                },
            });
        };
        function fn010103Add(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Unit(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Unit(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Unit',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0101RvrsUOM").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0101RvrsUOMCode").value = response[0].Code;
                        //modal
                        $('#mdl0103UnitRvrs').modal('hide');
                    },
                });
            };
        };
        function fn010101Add_Ok(Btn) {
            //if exists
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Add', function (response) {
                    if (response[0].oReturn == "") {
                        Add_DTL_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Add_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Add_DTL_Ok_Await(Btn, ID);
            };
            function Add_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx0101RvrsScope").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0101RvrsParticular").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0101RvrsQty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0101RvrsUOM").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0101RvrsCost").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Add_DTL_Question(ID);
                    };
                    //question
                    function Add_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save(Rvsn)', function (response) {
                                    if (response[0].oReturn == "") {
                                        Add_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Add_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Add Revision Record : Material',
                                'pID': ID,
                                'pCategory': document.getElementById("lbl0101Category").innerText,
                                'pCENo': document.getElementById("lbl0101EstNo").innerText,
                                'pWCode': document.getElementById("ContentPlaceHolder1_hf0101RvrsScopeCode").value,
                                'pTblCode': document.getElementById("ContentPlaceHolder1_hf0101RvrsParticular").value,
                                'pParticular': document.getElementById("tbx0101RvrsParticular").value,
                                'pCost': document.getElementById("tbx0101RvrsCost").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf0101RvrsUOMCode").value,
                                'pQty': document.getElementById("tbx0101RvrsQty").value,
                                'pTotal': document.getElementById("tbx0101RvrsTotal").value,
                                'pEstimate': document.getElementById("cbx0302Estimate").checked,
                                'pRequest': document.getElementById("cbx0302Request").checked
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx0101RvrsScope").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0101RvrsScopeCode").value = "";
                                document.getElementById("tbx0101RvrsParticular").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0101RvrsParticular").value = "";
                                document.getElementById("tbx0101RvrsUOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0101RvrsUOMCode").value = "";
                                document.getElementById("tbx0101RvrsQty").value = "0.00";
                                document.getElementById("tbx0101RvrsCost").value = "0.00";
                                document.getElementById("tbx0101RvrsTotal").value = "0.00";
                                document.getElementById("tbx0101RvrsRemarks").value = "";
                                //load
                                fn0102LoadBudget(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadMaterial(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadConvertion(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            },
                        });
                        //modal
                        $('#mdl0101AddRvrs').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        //revision

        //budget
        function fn0102LoadBudget(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Particular : Budget',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0301LoaderRecord").style.display = "";
                    //display loader

                    $('#table0301Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0301Record = $("#table0301Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: false,
                        data: response,
                        columns: [
                            {
                                data: 'No',
                                render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") {
                                        return '<span title="' + data +'" style="font-weight:bold; color:#000;">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },
                            {
                                data: 'ItmNo',
                                render: function (data, type, row) {
                                    if (type === "display") {
                                        return '<span title="' + data + '">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },
                            {
                                data: 'Type',
                                render: function (data, type, row) {
                                    if (type === "display") {
                                        return '<span title="' + data + '">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },
                            {
                                data: 'Particular',
                                render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") {
                                        return '<span title="' + data + '" style="font-weight:bold; color:#000;">' + data + '</span>';
                                    } else {
                                        return '<span title="' + data + '">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },
                            {
                                data: 'Cost', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'UOM',
                                render: function (data, type, row) {
                                    if (type === "display") {
                                        return '<span title="' + data + '">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },
                            {
                                data: 'Budget', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'Release', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'Actualize', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'Commitment', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false
                            },
                            { targets: [0], className: 'dt-body-left' },
                            {
                                targets: [4, 6, 7, 8, 9],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [1, 3],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        ordering: false,
                        createdRow: function (row, data, dataIndex) {
                            if (data.No && data.No.toString().trim() !== "") {
                                $(row).css("background-color", "#92d050");
                            }
                        },
                        footerCallback: function (row, data, start, end, display) {
                            var api = this.api();
                            // Calculate the total
                            var parseNumber = function (val) {
                                if (typeof val === "string") {
                                    return parseFloat(val.replace(/[^0-9.-]/g, "")) || 0;
                                }
                                return typeof val === "number" ? val : 0;
                            };

                            // Calculate cost
                            var totCost = api.column(4).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Calculate budget
                            var totBudget = api.column(6).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Calculate release
                            var totRelease = api.column(7).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Calculate actualize
                            var totActualize = api.column(8).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Calculate commitment
                            var totCommitment = api.column(9).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Update the footer with the total value
                            var totalCost = totCost.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(4).footer()).html(totalCost);
                            var totalBudget = totBudget.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(6).footer()).html(totalBudget);
                            var totalRelease = totRelease.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(7).footer()).html(totalRelease);
                            var totalActualize = totActualize.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(8).footer()).html(totalActualize);
                            var totalCommitment = totCommitment.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(9).footer()).html(totalCommitment);
                        },
                    });
                    //datatable

                    //search
                    $('#tbx0301Find').on('keyup', function () {
                        table0301Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0301LoaderRecord").style.display = "none";
                    //hide loader

                },
            });
        };
        //budget

        //material
        let table0302Record;
        let currentMode = 'Estimate';
        $(document).ready(function () {

            // Default check Estimate
            $("#cbx0302Estimate").prop("checked", true);

            // Checkbox change
            const checkboxes = $("#div0302CheckBox input[type=checkbox]");
            checkboxes.on("change", function () {
                checkboxes.not(this).prop("checked", false);

                if ($("#cbx0302Estimate").is(":checked")) currentMode = 'Estimate';
                else if ($("#cbx0302Request").is(":checked")) currentMode = 'Request';
                else if ($("#cbx0302Purchase").is(":checked")) currentMode = 'Purchase';
                else if ($("#cbx0302Issue").is(":checked")) currentMode = 'Issue';

                // Update headers
                $("#th0302Estimate").text(currentMode === 'Estimate' ? "Estimate" : currentMode);
                $("#th0302Revision").text(currentMode === 'Estimate' ? "Revision" : "Balance");

                // Move/copy data for empty No rows
                table0302Record.rows().every(function () {
                    const rowData = this.data();

                    // Only update rows without No
                    if (!rowData.No || rowData.No.toString().trim() === "") {
                        if (currentMode === 'Estimate') {
                            rowData.EstQty = rowData.QtyOverall;
                            rowData.EstAmount = rowData.TotalOverall;
                            rowData.RevQty = 0;
                            rowData.RevAmount = 0;
                        } else {
                            rowData.RevQty = rowData.EstQty || rowData.QtyOverall;
                            rowData.RevAmount = rowData.EstAmount || rowData.TotalOverall;
                            rowData.EstQty = 0;
                            rowData.EstAmount = 0;
                        }

                        this.data(rowData);
                    }
                });

                table0302Record.draw(false);
            });

            // Load table
            fn0102LoadMaterial('DTL', document.getElementById("ContentPlaceHolder1_hdnID").value);
        });
        function fn0102LoadMaterial(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Particular : Material',
                    'pID': pID
                },
                success: function (response) {
                    document.getElementById("div0302LoaderRecord").style.display = "";

                    if ($.fn.DataTable.isDataTable("#table0302Record")) {
                        $('#table0302Record').DataTable().destroy();
                    }

                    // Add new fields for dynamic Estimate/Revision columns
                    response.forEach(row => {
                        row.EstQty = row.QtyOverall;
                        row.EstAmount = row.TotalOverall;
                        row.RevQty = 0;
                        row.RevAmount = 0;
                    });

                    table0302Record = $("#table0302Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: false,
                        data: response,
                        columns: [
                            {
                                data: 'Action',
                                render: function (data, type, row) {
                                    return (!row.No || row.No.toString().trim() === "") ? data : '';
                                }
                            },
                            {
                                data: 'No',
                                render: function (data, type, row) {
                                    return (row.No && row.No.toString().trim() !== "") ?
                                        '<span style="font-weight:bold; color:#000;">' + data + '</span>' : data;
                                }
                            },
                            { data: 'ItmNo' },
                            { data: 'Type' },
                            {
                                data: 'Particular',
                                render: function (data, type, row) {
                                    return (row.No && row.No.toString().trim() !== "") ?
                                        '<span style="font-weight:bold; color:#000;">' + data + '</span>' : data;
                                }
                            },
                            {
                                data: 'Cost', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            { data: 'UOM' },
                            {
                                data: 'QtyOverall', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'TotalOverall', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'EstQty', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'EstAmount', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'RevQty', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            {
                                data: 'RevAmount', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            { targets: [0], orderable: false },
                            { targets: [0], className: 'dt-body-left' },
                            { targets: [5, 7, 8, 9, 10, 11, 12], className: 'dt-body-right' },
                            { targets: [2, 4], className: 'tbody-nowrap-auto' }
                        ],
                        ordering: false,
                        createdRow: function (row, data) {
                            if (data.No && data.No.toString().trim() !== "") {
                                $(row).css("background-color", "#92d050");
                            }
                        },
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        },
                        footerCallback: function (row, data, start, end, display) {
                            var api = this.api();
                            // Calculate the total
                            var parseNumber = function (val) {
                                if (typeof val === "string") {
                                    return parseFloat(val.replace(/[^0-9.-]/g, "")) || 0;
                                }
                                return typeof val === "number" ? val : 0;
                            };

                            // Calculate cost
                            var totCost = api.column(5).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // overall qty
                            var allQty = api.column(7).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // overall amount
                            var allAmt = api.column(8).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // estimate qty
                            var estQty = api.column(9).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // estimate amount
                            var estAmt = api.column(10).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // revision qty
                            var revQty = api.column(11).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // revision amount
                            var revAmt = api.column(12).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Update the footer with the total value
                            var totalCost = totCost.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(5).footer()).html(totalCost);
                            var totalOverallQty = allQty.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(7).footer()).html(totalOverallQty);
                            var totalOverallAmt = allAmt.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(8).footer()).html(totalOverallAmt);
                            var totalEstimateQty = estQty.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(9).footer()).html(totalEstimateQty);
                            var totalEstimateAmt = estAmt.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(10).footer()).html(totalEstimateAmt);
                            var totalRevisionQty = revQty.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(11).footer()).html(totalRevisionQty);
                            var totalRevisionAmt = revAmt.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(12).footer()).html(totalRevisionAmt);
                        },
                    });

                    // Search
                    $('#tbx0302Find').on('keyup', function () {
                        table0302Record.search(this.value).draw();
                    });

                    // Handle action buttons based on mode
                    const buttons = document.querySelectorAll('.action-button');
                    if (pMode === "ADD") {
                        buttons.forEach(btn => {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        });
                    } else if (pMode === "DTL") {
                        buttons.forEach(btn => {
                            btn.classList.add("btn-active-light");
                            btn.disabled = false;
                        });
                    } else if (pMode === "UPD") {
                        buttons.forEach(btn => {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        });
                    }

                    document.getElementById("div0302LoaderRecord").style.display = "none";
                }
            });
        };

        //material - manual
        function fn0302AddManual() {
            //if exist
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Add() {
                document.getElementById("tbx0302AddScope").value = "";
                document.getElementById("ContentPlaceHolder1_hf0302AddScopeCode").value = "";
                document.getElementById("tbx0302AddParticular").value = "";
                document.getElementById("ContentPlaceHolder1_hf0302AddParticularCode").value = "";
                document.getElementById("ContentPlaceHolder1_hf0302AddType").value = "";
                document.getElementById("tbx0302AddQty").value = "0.00";
                document.getElementById("tbx0302AddUOM").value = "";
                document.getElementById("ContentPlaceHolder1_hf0302AddUOMCode").value = "";
                document.getElementById("tbx0302AddCost").value = "0.00";
                document.getElementById("tbx0302AddTotal").value = "";
                //modal
                $('#mdl0302Add').modal('show');
            };
        };
        function fn0302AddScope() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Scope of Work (Manual)'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030201LoaderManual").style.display = "";
                    //display loader

                    $('#table030201RecordManual').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030201RecordManual = $("#table030201RecordManual").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030201FindManual').on('keyup', function () {
                        table030201RecordManual.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030201LoaderManual").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0302ScopeManual').modal('show');
                },
            });
        };
        function fn030201Add_Manual(pWCode, pDesc, pLock) {
            //validate
            if (pLock == 1) {
                Scope(pWCode, pDesc);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Scope(pWCode, pDesc) {
                //bind
                document.getElementById("tbx0302AddScope").value = pDesc;
                document.getElementById("ContentPlaceHolder1_hf0302AddScopeCode").value = pWCode;
                $('#mdl0302ScopeManual').modal('hide');
            };
        };
        function fn0302AddParticular() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Particular (Manual)'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030202LoaderManual").style.display = "";
                    //display loader

                    $('#table030202RecordManual').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030202RecordManual = $("#table030202RecordManual").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030202FindManual').on('keyup', function () {
                        table030202RecordManual.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030202LoaderManual").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0302ParticularManual').modal('show');
                },
            });
        };
        function fn030202Add_Manual(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Item',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0302AddParticular").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0302AddParticularCode").value = response[0].Code;
                        document.getElementById("tbx0302AddUOM").value = response[0].UOMName;
                        document.getElementById("ContentPlaceHolder1_hf0302AddUOMCode").value = response[0].UOMCode;
                        //modal
                        $('#mdl0302ParticularManual').modal('hide');
                    },
                });
            };
        };
        function fn0302AddUOM() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Unit (Manual)'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030203LoaderManual").style.display = "";
                    //display loader

                    $('#table030203RecordManual').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030203RecordManual = $("#table030203RecordManual").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030203FindManual').on('keyup', function () {
                        table030203RecordManual.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030203LoaderManual").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0302UnitManual').modal('show');
                },
            });
        };
        function fn030203Add_Manual(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Unit(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Unit(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Unit',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0302AddUOM").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0302AddUOMCode").value = response[0].Code;
                        //modal
                        $('#mdl0302UnitManual').modal('hide');
                    },
                });
            };
        };
        function fn030200Add_Ok(Btn) {
            //if exists
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add_DTL_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Add_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Add_DTL_Ok_Await(Btn, ID);
            };
            function Add_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx0302AddScope").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302AddParticular").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302AddQty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302AddUOM").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302AddCost").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Add_DTL_Question(ID);
                    };
                    //question
                    function Add_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Add_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Add_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Add Manual Record : Material',
                                'pID': ID,
                                'pCategory': document.getElementById("lbl0101Category").innerText,
                                'pCENo': document.getElementById("lbl0101EstNo").innerText,
                                'pWCode': document.getElementById("ContentPlaceHolder1_hf0302AddScopeCode").value,
                                'pTblCode': document.getElementById("ContentPlaceHolder1_hf0302AddParticularCode").value,
                                'pParticular': document.getElementById("tbx0302AddParticular").value,
                                'pCost': document.getElementById("tbx0302AddCost").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf0302AddUOMCode").value,
                                'pQty': document.getElementById("tbx0302AddQty").value,
                                'pTotal': document.getElementById("tbx0302AddTotal").value,
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx0302AddScope").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302AddScopeCode").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302AddType").value = "";
                                document.getElementById("tbx0302AddParticular").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302AddParticularCode").value = "";
                                document.getElementById("tbx0302AddUOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302AddUOMCode").value = "";
                                document.getElementById("tbx0302AddQty").value = "0.00";
                                document.getElementById("tbx0302AddCost").value = "0.00";
                                document.getElementById("tbx0302AddTotal").value = "0.00";
                                //load
                                fn0102LoadBudget(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadMaterial(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadConvertion(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            },
                        });
                        //modal
                        $('#mdl0302Edit').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        //material - manual

        //material - upload
        function fn0302AddUpload() {
            //if exist
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Add() {
                document.getElementById("excelFileInput").value = "";
                document.getElementById("ExcelTextBoxX").value = "";
                $('#table0302RecordUpload').DataTable().clear().draw();
                //display loader
                document.getElementById("div0302LoaderUpload").style.display = "none";
                //modal
                $('#mdl0302AddUpload').modal('show');
            };
        };
        document.getElementById("excelFileInput").addEventListener("change", function (e) {
            const file = e.target.files[0];
            if (!file) return;

            document.getElementById("ExcelTextBoxX").value = file.name;

            const reader = new FileReader();
            reader.onload = function (e) {
                try {
                    const data = new Uint8Array(e.target.result);
                    const workbook = XLSX.read(data, { type: "array" });
                    const worksheet = workbook.Sheets[workbook.SheetNames[0]];

                    const expectedHeaders = ["Work", "Type", "TblCode", "Particular", "Cost", "UM", "Qty", "Total"];
                    const actualHeaders = [
                        worksheet["A1"]?.v?.toString().trim() || "",
                        worksheet["B1"]?.v?.toString().trim() || "",
                        worksheet["C1"]?.v?.toString().trim() || "",
                        worksheet["D1"]?.v?.toString().trim() || "",
                        worksheet["E1"]?.v?.toString().trim() || "",
                        worksheet["F1"]?.v?.toString().trim() || "",
                        worksheet["G1"]?.v?.toString().trim() || "",
                        worksheet["H1"]?.v?.toString().trim() || "",
                    ];

                    for (let i = 0; i < expectedHeaders.length; i++) {
                        if (actualHeaders[i].toLowerCase() !== expectedHeaders[i].toLowerCase()) {
                            fnAlertOnly("Invalid file format!", "error", "btn btn-danger");
                            document.getElementById("excelFileInput").value = "";
                            document.getElementById("ExcelTextBoxX").value = "";
                            return;
                        }
                    }

                    const tableData = [];
                    let rowIndex = 2;

                    while (rowIndex < 1000) {
                        //["Work", "Type", "TblCode", "Particular", "Cost", "UM", "Qty", "Total"];
                        const Work = worksheet["A" + rowIndex]?.v || "";
                        const Type = worksheet["B" + rowIndex]?.v || "";
                        const TblCode = worksheet["C" + rowIndex]?.v || "";
                        const Particular = worksheet["D" + rowIndex]?.v || "";
                        const Cost = worksheet["E" + rowIndex]?.v || "";
                        const UM = worksheet["F" + rowIndex]?.v || "";
                        const Qty = worksheet["G" + rowIndex]?.v || "";
                        const Total = worksheet["H" + rowIndex]?.v || "";
                        

                        // Stop if empty row
                        if (!Work && !Type && !TblCode && !Particular && !Cost && !UM && !Qty && !Total) break;

                        tableData.push({
                            Work: Work.toString(),
                            Type: Type.toString(),
                            TblCode: TblCode.toString(),
                            Particular: Particular.toString(),
                            Cost: Cost.toString(),
                            UM: UM.toString(),
                            Qty: Qty.toString(),
                            Total: Total.toString(),
                            Status: ""
                        });

                        rowIndex++;
                    };

                    if (tableData.length === 0) {
                        fnAlertOnly("No valid rows found in the file.", "warning", "btn btn-warning");
                        document.getElementById("excelFileInput").value = "";
                        document.getElementById("ExcelTextBoxX").value = "";
                        return;
                    };

                    //display loader
                    document.getElementById("div0302LoaderUpload").style.display = "";

                    // Send to backend
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: "SCM140100",
                            Type: "Cost Estimate - Upload Validation",
                            pID: document.getElementById("ContentPlaceHolder1_hdnID").value,
                            pCENo: document.getElementById("lbl0101EstNo").innerText,
                            pCategory: document.getElementById("lbl0101Category").innerText,
                            UploadExcel: JSON.stringify(tableData)
                        },
                        success: function (response) {
                            try {
                                if (!response || response.length === 0) {
                                    fnAlertOnly("No record found.", "warning", "btn btn-warning");
                                    document.getElementById("excelFileInput").value = "";
                                    document.getElementById("ExcelTextBoxX").value = "";
                                    $("#table0302RecordUpload").DataTable().clear().draw();
                                    return;
                                }
                                initDataTable(response);
                            } catch (err) {
                                fnAlertOnly("Invalid response from server.", "warning", "btn btn-warning");
                            }
                        },
                        error: function () {
                            alert("Error occurred while fetching data.");
                        }
                    });

                } catch (err) {
                    fnAlertOnly("Error: " + err.message, 'error', 'btn btn-danger');
                }
            };

            reader.readAsArrayBuffer(file);
        });
        let table0302RecordUpload;
        function initDataTable(data) {
            table0302RecordUpload = $('#table0302RecordUpload').DataTable({
                scrollY: '600px',
                scrollCollapse: true,
                fixedHeader: true,
                bDestroy: true,
                select: false,
                bInfo: false,
                bPaginate: false,
                paging: false,
                data: data,
                columns: [
                    { data: 'Work' },
                    { data: 'Type' },
                    { data: 'TblCode' },
                    { data: 'Particular' },
                    { data: 'Cost' },
                    { data: 'UM' },
                    { data: 'Qty' },
                    { data: 'Total' },
                    { data: 'Status' },
                    { data: 'oWorkCode', visible: false },
                    { data: 'oUMCode', visible: false },
                    { data: 'CECode', visible: false },
                    { data: 'CENo', visible: false },
                    { data: 'Category', visible: false },
                ],
                columnDefs: [
                    {
                        targets: '_all', className: 'tbody-nowrap-auto text-start', orderable: false
                    },
                    {
                        targets: [4, 6, 7, 9],
                        render: $.fn.dataTable.render.number(',', '.', 2)

                    }
                ],
                order: [[0, 'desc']],
                rowCallback: function (row, data) {
                    if (data.Status && data.Status.toLowerCase() === "valid") {
                        $(row).css("background-color", "#d4edda");  // light green
                    } else if (data.Status && data.Status.toLowerCase() === "invalid1" || data.Status && data.Status.toLowerCase() === "invalid2") {
                        $(row).css("background-color", "#f8d7da");  // light red
                    };
                }
            });
            document.getElementById("excelFileInput").value = "";
            //display loader
            document.getElementById("div0302LoaderUpload").style.display = "none";
            //display loader
        };
        function fn030203Add_Ok(Btn) {
            //if exists
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add_Upl_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Add_Upl_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Add_Upl_Ok_Await(Btn, ID);
            };
            function Add_Upl_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    var UploadExcel = $('#table0302RecordUpload').DataTable().rows().data().toArray();
                    //Validate
                    if (UploadExcel.length === 0) {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        return;
                    };
                    var hasInvalid = UploadExcel.some(function (row) {
                        return row.Status && row.Status.toString().toLowerCase() === "invalid2" || row.Status && row.Status.toString().toLowerCase() === "invalid1";
                    });
                    if (hasInvalid) {
                        fnAlertOnly('There are invalid rows!', 'error', 'btn btn-danger');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        return;
                    };
                    //question
                    Swal.fire({
                        text: 'Current record/changes will be saved?',
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
                            fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Add_Ok(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        } else {
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                    //edit
                    function Add_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                FormCode: 'FIN140100',
                                Type: 'Cost Estimate - Add Upload Record : Material',
                                UploadExcel: JSON.stringify(UploadExcel)
                            },
                            beforeSend: function () {
                                // Show Swal loader
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while data is being processed.',
                                    allowOutsideClick: false,
                                    didOpen: () => {
                                        Swal.showLoading();
                                    }
                                });
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                fn0102LoadBudget(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadMaterial(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadConvertion(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                // close Swal loader when everything is done
                                Swal.close();
                            },
                            error: function () {
                                // close Swal loader if error
                                Swal.close();
                                Swal.fire("Error", "Something went wrong while loading data.", "error");
                            }
                        });
                        //modal
                        $('#mdl0302AddUpload').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        //material - upload

        function fn0302Delete(pID, pSeqNo) {
            //if exist
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(pID, pSeqNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //delete question
            function Delete_Question(pID, pSeqNo) {
                Swal.fire({
                    text: 'Delete Item?',
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
                        fnValidateRecord('Trxn_CEHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(pID, pSeqNo);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function Delete_Ok(pID, pSeqNo) {
                //delete
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Delete Record - DTL - Material',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        fn0102LoadBudget(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                        fn0102LoadMaterial(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    },
                });
            };
        };
        function fn0302Edit(pID, pSeqNo) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(pID, pSeqNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Edit(pID, pSeqNo) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record - DTL - Material : Edit',
                        'pID': pID,
                        'pSeqNo': pSeqNo,
                    },
                    success: function (response) {
                        document.getElementById("tbx0302Scope").value = response[0].WName;
                        document.getElementById("ContentPlaceHolder1_hf0302ScopeCode").value = response[0].WCode;
                        document.getElementById("ContentPlaceHolder1_hf0302SeqNo").value = pSeqNo;
                        document.getElementById("tbx0302Particular").value = response[0].TblName;
                        document.getElementById("ContentPlaceHolder1_hf0302ParticularCode").value = response[0].TblCode;
                        document.getElementById("ContentPlaceHolder1_hf0302Type").value = response[0].TblFrom;
                        document.getElementById("tbx0302Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("tbx0302UOM").value = response[0].UOMName;
                        document.getElementById("ContentPlaceHolder1_hf0302UOMCode").value = response[0].UOMCode;
                        document.getElementById("tbx0302Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("tbx0302Total").value = formatNumber(response[0].Total);
                        //modal
                        $('#mdl0302Edit').modal('show');
                    },
                });
            };
        };
        function fn0302Scope() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Scope of Work'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030201Loader").style.display = "";
                    //display loader

                    $('#table030201Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030201Record = $("#table030201Record").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030201Find').on('keyup', function () {
                        table030201Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030201Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0302Scope').modal('show');
                },
            });
        };
        function fn030201Add(pWCode, pDesc, pLock) {
            //validate
            if (pLock == 1) {
                Scope(pWCode, pDesc);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Scope(pWCode, pDesc) {
                //bind
                document.getElementById("tbx0302Scope").value = pDesc;
                document.getElementById("ContentPlaceHolder1_hf0302ScopeCode").value = pWCode;
                $('#mdl0302Scope').modal('hide');
            };
        };
        function fn0302Particular() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Particular'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030202Loader").style.display = "";
                    //display loader

                    $('#table030202Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030202Record = $("#table030202Record").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030202Find').on('keyup', function () {
                        table030202Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030202Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0302Particular').modal('show');
                },
            });
        };
        function fn030202Add(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Item',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0302Particular").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0302ParticularCode").value = response[0].Code;
                        document.getElementById("tbx0302UOM").value = response[0].UOMName;
                        document.getElementById("ContentPlaceHolder1_hf0302UOMCode").value = response[0].UOMCode;
                        //modal
                        $('#mdl0302Particular').modal('hide');
                    },
                });
            };
        };
        function fn0302UOM() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Unit'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030203Loader").style.display = "";
                    //display loader

                    $('#table030203Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030203Record = $("#table030203Record").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030203Find').on('keyup', function () {
                        table030203Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030203Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0302Unit').modal('show');
                },
            });
        };
        function fn030203Add(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Unit(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Unit(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Unit',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0302UOM").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0302UOMCode").value = response[0].Code;
                        //modal
                        $('#mdl0302Unit').modal('hide');
                    },
                });
            };
        };
        function fn030201Add_Ok(Btn) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_DTL_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Edit_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Edit_DTL_Ok_Await(Btn, ID);
            };
            function Edit_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx0302Scope").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302Particular").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302Qty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302UOM").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0302Cost").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Edit_DTL_Question(ID);
                    };
                    //question
                    function Edit_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Edit_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HDN.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Edit Record : Material',
                                'pID': ID,
                                'pSeqNo': document.getElementById("ContentPlaceHolder1_hf0302SeqNo").value,
                                'pWCode': document.getElementById("ContentPlaceHolder1_hf0302ScopeCode").value,
                                'pRecType': document.getElementById("ContentPlaceHolder1_hf0302Type").value,
                                'pTblCode': document.getElementById("ContentPlaceHolder1_hf0302ParticularCode").value,
                                'pParticular': document.getElementById("tbx0302Particular").value,
                                'pCost': document.getElementById("tbx0302Cost").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf0302UOMCode").value,
                                'pQty': document.getElementById("tbx0302Qty").value,
                                'pTotal': document.getElementById("tbx0302Total").value,
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx0302Scope").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302ScopeCode").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302SeqNo").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302Type").value = "";
                                document.getElementById("tbx0302Particular").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302ParticularCode").value = "";
                                document.getElementById("tbx0302UOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0302UOMCode").value = "";
                                document.getElementById("tbx0302Qty").value = "0.00";
                                document.getElementById("tbx0302Cost").value = "0.00";
                                document.getElementById("tbx0302Total").value = "0.00";
                                fn0102LoadMaterial(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            },
                        });
                        //modal
                        $('#mdl0302Edit').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        //material

        //labor
        document.getElementById("excelFileInputLabor").addEventListener("change", function (e) {
            const file = e.target.files[0];
            if (!file) return;

            document.getElementById("ExcelTextBoxXLabor").value = file.name;

            const reader = new FileReader();
            reader.onload = function (e) {
                try {
                    const data = new Uint8Array(e.target.result);
                    const workbook = XLSX.read(data, { type: "array" });
                    const worksheet = workbook.Sheets[workbook.SheetNames[0]];

                    const expectedHeaders = ["Work", "WBSCode", "Particular", "WT", "Commulative"];
                    const actualHeaders = [
                        worksheet["A1"]?.v?.toString().trim() || "",
                        worksheet["B1"]?.v?.toString().trim() || "",
                        worksheet["C1"]?.v?.toString().trim() || "",
                        worksheet["D1"]?.v?.toString().trim() || "",
                        worksheet["E1"]?.v?.toString().trim() || ""
                    ];

                    for (let i = 0; i < expectedHeaders.length; i++) {
                        if (actualHeaders[i].toLowerCase() !== expectedHeaders[i].toLowerCase()) {
                            fnAlertOnly("Invalid file format!", "error", "btn btn-danger");
                            document.getElementById("excelFileInputLabor").value = "";
                            document.getElementById("ExcelTextBoxXLabor").value = "";
                            return;
                        }
                    }

                    const tableData = [];
                    let rowIndex = 2;

                    while (rowIndex < 1000) {
                        const Work = worksheet["A" + rowIndex]?.v || "";
                        const WBSCode = worksheet["B" + rowIndex]?.v || "";
                        const Particular = worksheet["C" + rowIndex]?.v || "";
                        const WT = worksheet["D" + rowIndex]?.v || "";
                        const Commulative = worksheet["E" + rowIndex]?.v || "";

                        // Stop if empty row
                        if (!Work && !WBSCode && !Particular && !WT && !Commulative) break;

                        tableData.push({
                            Work: Work.toString(),
                            WBSCode: WBSCode.toString(),
                            Particular: Particular.toString(),
                            WT: WT.toString(),
                            Commulative: Commulative.toString(),
                            Status: "",
                            CECode: "",
                            CENo: "",
                            Category: ""
                        });

                        rowIndex++;
                    };

                    if (tableData.length === 0) {
                        fnAlertOnly("No valid rows found in the file.", "warning", "btn btn-warning");
                        document.getElementById("excelFileInputLabor").value = "";
                        document.getElementById("ExcelTextBoxX").value = "";
                        return;
                    };

                    //display loader
                    document.getElementById("div0303LoaderUpload").style.display = "";

                    // Send to backend
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            FormCode: "SCM140100",
                            Type: "Cost Estimate - Upload Validation Labor",
                            pID: document.getElementById("ContentPlaceHolder1_hdnID").value,
                            pCENo: document.getElementById("lbl0101EstNo").innerText,
                            pCategory: document.getElementById("lbl0101Category").innerText,
                            UploadExcel: JSON.stringify(tableData)
                        },
                        success: function (response) {
                            try {
                                if (!response || response.length === 0) {
                                    fnAlertOnly("No record found.", "warning", "btn btn-warning");

                                    document.getElementById("excelFileInputLabor").value = "";
                                    document.getElementById("ExcelTextBoxXLabor").value = "";
                                    $("#table0303RecordUpload").DataTable().clear().draw();
                                    return;
                                }
                                initDataTableLabor(response);
                            } catch (err) {
                                fnAlertOnly("Invalid response from server.", "warning", "btn btn-warning");
                            }
                        },
                        error: function () {
                            alert("Error occurred while fetching data.");
                        }
                    });

                } catch (err) {
                    fnAlertOnly("Error: " + err.message, 'error', 'btn btn-danger');
                }
            };

            reader.readAsArrayBuffer(file);
        });
        let table0303RecordUpload;
        function initDataTableLabor(data){
            table0303RecordUpload = $('#table0303RecordUpload').DataTable({
                scrollY: '600px',
                scrollCollapse: true,
                fixedHeader: true,
                bDestroy: true,
                select: false,
                bInfo: false,
                bPaginate: false,
                paging: false,
                data: data,
                columns: [
                    { data: 'Work' },
                    { data: 'WBSCode' },
                    { data: 'Particular' },
                    { data: 'WT' },
                    { data: 'Commulative' },
                    { data: 'Status' },
                    { data: 'CECode', visible: false },
                    { data: 'CENo', visible: false },
                    { data: 'Category', visible: false },
                ],
                columnDefs: [
                    {
                        targets: '_all', className: 'tbody-nowrap-auto text-start', orderable: false
                    },
                    {
                        targets: [3, 4],
                        render: $.fn.dataTable.render.number(',', '.', 2)

                    }
                ],
                order: [[0, 'desc']],
                rowCallback: function (row, data) {
                    if (data.Status && data.Status.toLowerCase() === "valid") {
                        $(row).css("background-color", "#d4edda");  // light green
                    } else if (data.Status && data.Status.toLowerCase() === "invalid") {
                        $(row).css("background-color", "#f8d7da");  // light red
                    }
                },
                initComplete: function () {
                    this.api().cells().every(function () {
                        var cell = this.node();
                        $(cell).attr('title', $(cell).text());
                    });
                }
            });
            document.getElementById("excelFileInputLabor").value = "";
            //display loader
            document.getElementById("div0303LoaderUpload").style.display = "none";
            //display loader
        };
        function fn0303AddUpload() {
            //if exist
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Add() {
                var table0302Record = $('#table0302Record').DataTable();
                var tblRows = table0302Record.rows().count();
                if (tblRows) {
                    document.getElementById("excelFileInputLabor").value = "";
                    document.getElementById("ExcelTextBoxXLabor").value = "";
                    $('#table0303RecordUpload').DataTable().clear().draw();
                    //display loader
                    document.getElementById("div0303LoaderUpload").style.display = "none";
                    //modal
                    $('#mdl0303AddUpload').modal('show');
                };
            };
        };
        function fn0102LoadLabor(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Particular : Labor',
                    'pID': pID
                },
                success: function (response) {
                    document.getElementById("div0303LoaderRecord").style.display = "";

                    if ($.fn.DataTable.isDataTable("#table0303Record")) {
                        $('#table0303Record').DataTable().destroy();
                    }

                    table0303Record = $("#table0303Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: false,
                        data: response,
                        columns: [
                            {
                                data: 'Action',
                                render: function (data, type, row) {
                                    return (!row.No || row.No.toString().trim() === "") ? data : '';
                                }
                            },
                            {
                                data: 'No',
                                render: function (data, type, row) {
                                    return (row.No && row.No.toString().trim() !== "") ?
                                        '<span style="font-weight:bold; color:#000;">' + data + '</span>' : data;
                                }
                            },
                            { data: 'ItmNo' },
                            { data: 'Milestone' },
                            {
                                data: 'Particular',
                                render: function (data, type, row) {
                                    return (row.No && row.No.toString().trim() !== "") ?
                                        '<span style="font-weight:bold; color:#000;">' + data + '</span>' : data;
                                }
                            },
                            { data: 'WT' },
                            { data: 'Commulative' },
                            { data: 'IsPaid' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            { targets: [0], orderable: false },
                            { targets: [0], className: 'dt-body-left' },
                            { targets: [5, 6], className: 'dt-body-right' },
                            { targets: [4], className: 'tbody-nowrap-auto' }
                        ],
                        ordering: false,
                        createdRow: function (row, data) {
                            if (data.No && data.No.toString().trim() !== "") {
                                $(row).css("background-color", "#92d050");
                            }
                        },
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        },
                        footerCallback: function (row, data, start, end, display) {
                            var api = this.api();
                            // Calculate the total
                            var parseNumber = function (val) {
                                if (typeof val === "string") {
                                    return parseFloat(val.replace(/[^0-9.-]/g, "")) || 0;
                                }
                                return typeof val === "number" ? val : 0;
                            };

                            // Calculate WT
                            var totWT = api.column(5).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Calculate Commulative
                            var totCommulative = api.column(6).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Update the footer with the total value
                            var totalWT = totWT.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(5).footer()).html(totalWT);
                            var totalCommulative = totCommulative.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(6).footer()).html(totalCommulative);
                        },
                    });

                    // Search
                    $('#tbx0303Find').on('keyup', function () {
                        table0303Record.search(this.value).draw();
                    });

                    // Handle action buttons based on mode
                    const buttons = document.querySelectorAll('.action-button');
                    if (pMode === "ADD") {
                        buttons.forEach(btn => {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        });
                    } else if (pMode === "DTL") {
                        buttons.forEach(btn => {
                            btn.classList.add("btn-active-light");
                            btn.disabled = false;
                        });
                    } else if (pMode === "UPD") {
                        buttons.forEach(btn => {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        });
                    }

                    document.getElementById("div0303LoaderRecord").style.display = "none";
                }
            });
        };
        function fn030303Add_Ok(Btn) {
            //if exists
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add_Upl_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Add_Upl_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Add_Upl_Ok_Await(Btn, ID);
            };
            function Add_Upl_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    var UploadExcel = $('#table0303RecordUpload').DataTable().rows().data().toArray();
                    //Validate
                    if (UploadExcel.length === 0) {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        return;
                    };
                    var hasInvalid = UploadExcel.some(function (row) {
                        return row.Status && row.Status.toString().toLowerCase() === "invalid";

                    });
                    if (hasInvalid) {
                        fnAlertOnly('There are invalid rows!', 'error', 'btn btn-danger');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        return;
                    }
                    //question
                    Swal.fire({
                        text: 'Current record/changes will be saved?',
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
                            fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Add_Ok(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        } else {
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                    //edit
                    function Add_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                FormCode: 'SCM140100',
                                Type: 'Cost Estimate - Add Upload Record : Labor',
                                UploadExcel: JSON.stringify(UploadExcel)
                            },
                            beforeSend: function () {
                                // Show Swal loader
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while data is being processed.',
                                    allowOutsideClick: false,
                                    didOpen: () => {
                                        Swal.showLoading();
                                    }
                                });
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                fn0102LoadBudget(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadMaterial(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                fn0102LoadLabor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                                document.getElementById("excelFileInputLabor").value = "";
                                document.getElementById("ExcelTextBoxXLabor").value = "";
                                $('#table0303RecordUpload').DataTable().clear().draw();
                                // close Swal loader when everything is done
                                Swal.close();
                            },
                            error: function () {
                                // close Swal loader if error
                                Swal.close();
                                Swal.fire("Error", "Something went wrong while loading data.", "error");
                            }
                        });
                        //modal
                        $('#mdl0303AddUpload').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        function fn0303Delete(pID, pSeqNo) {
            //if exist
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(pID, pSeqNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //delete question
            function Delete_Question(pID, pSeqNo) {
                Swal.fire({
                    text: 'Delete Item?',
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
                        fnValidateRecord('Trxn_CEHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(pID, pSeqNo);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function Delete_Ok(pID, pSeqNo) {
                //delete
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Delete Record - DTL - Labor',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        fn0102LoadLabor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    },
                });
            };
        };
        function fn0303Edit(pID, pSeqNo) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(pID, pSeqNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Edit(pID, pSeqNo) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record - DTL - Labor : Edit',
                        'pID': pID,
                        'pSeqNo': pSeqNo,
                    },
                    success: function (response) {
                        document.getElementById("tbx0303Scope").value = response[0].WName;
                        document.getElementById("ContentPlaceHolder1_hf0303SeqNo").value = pSeqNo;
                        document.getElementById("tbx0303Particular").value = response[0].Particular;
                        document.getElementById("tbx0303Milestone").value = response[0].Milestone;
                        document.getElementById("tbx0303WT").value = formatNumber(response[0].WT);
                        document.getElementById("tbx0303Commulative").value = formatNumber(response[0].Commulative);
                        //modal
                        $('#mdl0303Edit').modal('show');
                    },
                });
            };
        };
        function fn030301Add_Ok(Btn) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_DTL_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Edit_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Edit_DTL_Ok_Await(Btn, ID);
            };
            function Edit_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx0303WT").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0303Commulative").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Edit_DTL_Question(ID);
                    };
                    //question
                    function Edit_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Edit_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Edit Record : Labor',
                                'pID': ID,
                                'pSeqNo': document.getElementById("ContentPlaceHolder1_hf0303SeqNo").value,
                                'pWT': document.getElementById("tbx0303WT").value,
                                'pCommulative': document.getElementById("tbx0303Commulative").value
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("ContentPlaceHolder1_hf0303SeqNo").value = "";
                                document.getElementById("tbx0303WT").value = "0.00";
                                document.getElementById("tbx0303Commulative").value = "0.00";
                                fn0102LoadLabor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            },
                        });
                        //modal
                        $('#mdl0303Edit').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        //labor

        //convertion
        function fn0102LoadConvertion(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Particular : Convertion',
                    'pID': pID
                },
                success: function (response) {
                    document.getElementById("div0304LoaderRecord").style.display = "";

                    if ($.fn.DataTable.isDataTable("#table0304Record")) {
                        $('#table0304Record').DataTable().destroy();
                    }

                    table0304Record = $("#table0304Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: false,
                        data: response,
                        columns: [
                            {
                                data: 'Action',
                                render: function (data, type, row) {
                                    return (!row.No || row.No.toString().trim() === "") ? data : '';
                                }
                            },
                            {
                                data: 'No',
                                render: function (data, type, row) {
                                    return (row.No && row.No.toString().trim() !== "") ?
                                        '<span style="font-weight:bold; color:#000;">' + data + '</span>' : data;
                                }
                            },
                            { data: 'ItmNo' },
                            { data: 'Type' },
                            {
                                data: 'Particular',
                                render: function (data, type, row) {
                                    return (row.No && row.No.toString().trim() !== "") ?
                                        '<span style="font-weight:bold; color:#000;">' + data + '</span>' : data;
                                }
                            },
                            {
                                data: 'Cost', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            { data: 'UOM' },
                            { data: 'CvxName' },
                            {
                                data: 'CvxQty', render: function (data, type, row) {
                                    if (row.No && row.No.toString().trim() !== "") return '';
                                    // remove commas first
                                    let clean = (data && data.toString().trim() !== "") ? data.toString().replace(/,/g, "") : "0";

                                    // pass clean numeric value to the number renderer
                                    return $.fn.dataTable.render.number(',', '.', 2).display(clean);
                                }
                            },
                            { data: 'CvxUnitName' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            { targets: [0], orderable: false },
                            { targets: [0], className: 'dt-body-left' },
                            { targets: [5, 8], className: 'dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2) },
                            { targets: [4, 7], className: 'tbody-nowrap-auto' }
                        ],
                        ordering: false,
                        createdRow: function (row, data) {
                            if (data.No && data.No.toString().trim() !== "") {
                                $(row).css("background-color", "#92d050");
                            }
                        },
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        },
                        footerCallback: function (row, data, start, end, display) {
                            var api = this.api();
                            // Calculate the total
                            var parseNumber = function (val) {
                                if (typeof val === "string") {
                                    return parseFloat(val.replace(/[^0-9.-]/g, "")) || 0;
                                }
                                return typeof val === "number" ? val : 0;
                            };

                            // Calculate WT
                            var totCost = api.column(5).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Calculate Commulative
                            var totQty = api.column(8).data().reduce(function (a, b) {
                                return parseNumber(a) + parseNumber(b);
                            }, 0);

                            // Update the footer with the total value
                            var totalCost = totCost.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(5).footer()).html(totalCost);
                            var totalQty = totQty.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(8).footer()).html(totalQty);
                        },
                    });

                    // Search
                    $('#tbx0304Find').on('keyup', function () {
                        table0304Record.search(this.value).draw();
                    });

                    // Handle action buttons based on mode
                    const buttons = document.querySelectorAll('.action-button');
                    if (pMode === "ADD") {
                        buttons.forEach(btn => {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        });
                    } else if (pMode === "DTL") {
                        buttons.forEach(btn => {
                            btn.classList.remove("action-button");
                            btn.classList.remove("btn-active-light");
                            btn.disabled = false;
                        });
                    } else if (pMode === "UPD") {
                        buttons.forEach(btn => {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        });
                    }

                    document.getElementById("div0304LoaderRecord").style.display = "none";
                }
            });
        };
        function fn0304Edit(ID) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value, ID);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID ,ItemNo) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(ItemNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Edit(ItemNo) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record - DTL - Convertion : Edit',
                        'pID': ItemNo
                    },
                    success: function (response) {
                        document.getElementById("tbx0304Item").value = response[0].CvxName;
                        document.getElementById("ContentPlaceHolder1_hf0304ItemCode").value = response[0].CvxCode;
                        document.getElementById("ContentPlaceHolder1_hf0304ItemNo").value = ItemNo;
                        document.getElementById("tbx0304Qty").value = formatNumber(response[0].CvxQty);
                        document.getElementById("tbx0304Unit").value = response[0].CvxUnitName;
                        document.getElementById("ContentPlaceHolder1_hf0304UnitCode").value = response[0].CvxUnit;
                        //modal
                        $('#mdl0304Edit').modal('show');
                    },
                });
            };
        };
        function fn0304Item() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Get Convertion Item'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030401Loader").style.display = "";
                    //display loader

                    $('#table030401Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030401Record = $("#table030401Record").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030401Find').on('keyup', function () {
                        table030401Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030401Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0304Item').modal('show');
                },
            });
        };
        function fn030401Add(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Item',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0304Item").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0304ItemCode").value = response[0].Code;
                        document.getElementById("tbx0304Unit").value = response[0].UOMName;
                        document.getElementById("ContentPlaceHolder1_hf0304UnitCode").value = response[0].UOMCode;
                        //modal
                        $('#mdl0304Item').modal('hide');
                    },
                });
            };
        };
        function fn0304UOM() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM140100',
                    'Type': 'Cost Estimate - Get Convertion Unit'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div030402Loader").style.display = "";
                    //display loader

                    $('#table030402Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table030402Record = $("#table030402Record").DataTable({
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
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'Description' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx030402Find').on('keyup', function () {
                        table030402Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div030402Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0304Unit').modal('show');
                },
            });
        };
        function fn030402Add(pCode, pLock) {
            //validate
            if (pLock == 1) {
                Unit(pCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Unit(pCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM140100',
                        'Type': 'Get Record : Unit',
                        'pCode': pCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0304Unit").value = response[0].Description;
                        document.getElementById("ContentPlaceHolder1_hf0304UnitCode").value = response[0].Code;
                        //modal
                        $('#mdl0304Unit').modal('hide');
                    },
                });
            };
        };
        function fn030401Add_Ok(Btn) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_DTL_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            async function Edit_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Edit_DTL_Ok_Await(Btn, ID);
            };
            function Edit_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx0304Item").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0304Qty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0304Unit").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Edit_DTL_Question(ID);
                    };
                    //question
                    function Edit_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_CEHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Edit_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM140100',
                                'Type': 'Cost Estimate - Edit Record : Convertion',
                                'pItemNo': document.getElementById("ContentPlaceHolder1_hf0304ItemNo").value,
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf0304ItemCode").value,
                                'pCvxQty': document.getElementById("tbx0304Qty").value,
                                'pUnitCode': document.getElementById("ContentPlaceHolder1_hf0304UnitCode").value,
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("ContentPlaceHolder1_hf0304ItemNo").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0304ItemCode").value = "";
                                document.getElementById("tbx0304Qty").value = "0.00";
                                document.getElementById("ContentPlaceHolder1_hf0304UnitCode").value = "";
                                fn0102LoadConvertion(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            },
                        });
                        /*modal*/
                        $('#mdl0304Edit').modal('hide');
                    };
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                });
            };
        };
        //convertion

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'FIN170000',
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
        function fn0201Download(FormCode, pID, pFileName) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                        'pFormCode': FormCode,
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
        function fn0201Delete(FormCode, pID, pFileName) {
            //if exisit
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN170000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Question(FormCode, pID, pFileName);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //delete question
            function Delete_Question(FormCode, pID, pFileName) {
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
                        Delete_Ok(FormCode, pID, pFileName);
                    }
                });
            };
            function Delete_Ok(FormCode, pID, pFileName) {
                $.ajax({
                    type: "POST",
                    url: "HNDGEN.ashx",
                    data: {
                        'pFormCode': FormCode,
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
                    'pFormCode': 'FIN170000',
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
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('Trxn_CEHdr', 'CECode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                            'pFormCode': 'FIN170000',
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

                //metion
                jq.fn.atwho.debug = true;
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
                };
                //metion

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
                    url: "HNDGEN.ashx?FormCode=FIN170000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('FIN170000', 'Add', function (response) {
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
                    fnAccess('FIN170000', 'Add', function (response) {
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
                            myDropzone.options.url = "HNDGEN.ashx?FormCode=FIN170000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
        };
        //load page

    </script>
	<!-- script related to this page -->

</asp:Content>
