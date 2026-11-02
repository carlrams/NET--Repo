<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM080100.aspx.vb" Inherits="NET.SCM080100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentplaceholderID="Contentplaceholder1" runat="server">

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
						<li class="breadcrumb-item text-white">Stock Issuance</li>
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
						<img src="Assets/media/svg/apps/SCM080000.svg" alt="" />
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
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Trxn. No.</span>
											<span id="lbl0101TrxnNo" class="form-control ">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date</span>
											<span id="lbl0101Date" class="form-control ">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Created</span>
											<span id="lbl0101DateCreated" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Type</span>
											<span id="lbl0101Type" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Charge To</span>
											<span id="lbl0101ChargeTo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Warehouse</span>
											<span id="lbl0101Warehouse" class="form-control">-</span>
                                            <input id="hf0101Warehouse" runat="server" type="hidden" value="" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">
                                                <span class="d-flex justify-content-start">SI No.</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-5 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0101SINo" onclick="return false;" />
												</div>
											</span>
											<span id="lbl0101SINo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">
                                                <span class="d-flex justify-content-start">GP No.</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0101GPNo" onclick="return false;" />
												</div>
											</span>
											<span id="lbl0101GPNo" class="form-control">-</span>
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-9 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Deliver To</span>
											<span id="lbl0101SILocation" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Location</span>
											<span id="lbl0101GPLocation" class="form-control">-</span>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12 m-0">
									    <div class="input-group input-group-sm mb-2">
										    <span class="input-group-text min-w-150px">Requested By</span>
										    <span id="lbl0101RequestedBy" class="form-control ">-</span>
                                            <input id="hf0101RequestedByCode" runat="server" type="hidden" value="" />
									    </div>
									    <div class="input-group input-group-sm mb-2">
										    <span class="input-group-text min-w-150px">Issued By</span>
										    <span id="lbl0101IssuedBy" class="form-control ">-</span>
									    </div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Authorized By</span>
											<span id="lbl0101AuthorizedBy" class="form-control ">-</span>
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
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Trxn. No.</span>
											<input id="tbx0101TrxnNo" type="text" class="form-control " placeholder="Trxn. No." maxlength="13" readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101Date" class="input-group-text min-w-150px required">Date</span>
											<input id="tbx0101Date" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Date" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Date Created</span>
											<input id="tbx0101DateCreated" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Date" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Type</span>
											<select id="ddl0101Type" data-kt-repeater="select2" class="form-select form-select-sm form-select-border" onchange="ddl0101Type_onchange(this);">
												<option value="">Type</option>
												<option value="Land Development">Land Development</option>
												<option value="Model House">Model House</option>
												<option value="Water Connection">Water Connection</option>
												<option value="Electricity Connection">Electricity Connection</option>
												<option value="Subdivision Maintenance">Subdivision Maintenance</option>
												<option value="Office Supplies">Office Supplies</option>
												<option value="Advances (Employee)">Advances (Employee)</option>
												<option value="Advances (Contractor)">Advances (Contractor)</option>
												<option value="Service Vehicle">Service Vehicle</option>
												<option value="Branch Marketing">Branch Marketing</option>
												<option value="OSM Project">OSM Project</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101ChargeTo" class="input-group-text min-w-150px required">Charge To</span>
											<select id="ddl0101ChargeTo" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Charge To</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101Warehouse" class="input-group-text min-w-150px required">Warehouse</span>
											<select id="ddl0101Warehouse" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Warehouse</option>
											</select>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">
                                                <span class="d-flex justify-content-start">SI No.</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-5 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0201SINo" onclick="chkBox0201SINo(this);" />
												</div>
											</span>
											<input id="tbx0101SINo" type="text" class="form-control " placeholder="SI No." maxlength="13" readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">
                                                <span class="d-flex justify-content-start">GP No.</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0201GPNo" onclick="chkBox0201GPNo(this);" />
												</div>
											</span>
											<input id="tbx0101GPNo" type="text" class="form-control " placeholder="GP No." maxlength="13" readonly="readonly" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-9 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Deliver To</span>
											<input id="tbx0101DeliverTo" type="text" class="form-control " maxlength="180" placeholder="Deliver To" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101Location" class="input-group-text min-w-150px required">Location</span>
											<input id="tbx0101Location" type="text" class="form-control " maxlength="180" placeholder="Location" readonly="readonly" />
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Requested By</span>
                                            <div id="div0101RequestedBy" class="w-100">
										        <select id="ddl0101RequestedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl0101RequestedBy_onchange(this);">
											        <option value="">Requested By</option>
										        </select>
                                            </div>
											<input id="tbx0101RequestedBy" type="text" class="form-control d-none" placeholder="Requested By" readonly="readonly" />
                                            <input id="hf0101RequestedBy" runat="server" type="hidden" value="" />
                                            <input id="hf0101DeptCode" runat="server" type="hidden" value="" />
                                            <input id="hf0101PRNo" runat="server" type="hidden" value="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Issued By</span>
											<select id="ddl0101IssuedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Issued By</option>
											</select>
										</div>
										<div class="input-group input-group-sm">
											<span id="spn0101AuthorizedBy" class="input-group-text min-w-150px required">Authorized By</span>
											<select id="ddl0101AuthorizedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Authorized By</option>
											</select>
										</div>
                                    </div>
                                    
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Updated By</span>
                                            <input id="tbx0101UpdatedByName" type="text" class="form-control" placeholder="Updated By" maxlength="180" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101UpdatedDate" type="text" class="form-control" placeholder="Date" maxlength="20" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Locked By</span>
                                            <input id="tbx0101LockedByName" type="text" class="form-control" placeholder="Locked By" maxlength="180" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101LockedDate" type="text" class="form-control" placeholder="Date" maxlength="20" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Posted By</span>
                                            <input id="tbx0101PostedByName" type="text" class="form-control" placeholder="Posted By" maxlength="180" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101PostedDate" type="text" class="form-control" placeholder="Date" maxlength="20" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Cancelled By</span>
                                            <input id="tbx0101CancelledByName" type="text" class="form-control" placeholder="Cancelled By" maxlength="180" readonly="readonly" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101CancelledDate" type="text" class="form-control" placeholder="Date" maxlength="20" readonly="readonly" />
                                        </div>
                                    </div>
								</div>
							</div>
							<!--end::Dtl-->
						</div>
						<!--end::Menu Content-->

						<!--begin::particular-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Particular</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
                            <!--begin::Card header-->
                            <div class="card-header">
                                <div class="d-flex align-items-center">
                                    <div class="d-flex">
                                        <div class="dropdown">
                                            <button id="btn0102Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Add Record">
                                                <i class="las la-plus fs-2" style="padding: 0.55rem;"></i>
                                            </button>
                                            <div class="dropdown-menu dropdown-menu-end" aria-labelledby="btn0102Add">
                                                <div class="dropdown-item">
                                                    <a class="d-block py-2" onclick="fn0102Add(); return false;">
                                                        Add Record
                                                    </a>
                                                </div>
                                                <div class="dropdown-item">
                                                    <a class="d-block py-2" onclick="fn0102AddPR(); return false;">
                                                        Add Record (from PR)
                                                    </a>
                                                </div>
                                                <div class="dropdown-item">
                                                    <a class="d-block py-2" onclick="fn0102AddDI(); return false;">
                                                        Add Record (from DI)
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
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
                                            <input id="tbx0102FindParticular" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
                            </div>
                            <!--end::Card header-->
							<!--begin::Files-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0102LoaderParticular" class="table-loading-message">
										Loading...
									</div>
									<table id="table0102Particular" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>
                                            <tr>
                                                <th class="fw-bold border-end" colspan="6">SI Items</th>
                                                <th class="fw-bold border-end" colspan="5">PR Reference</th>
                                            </tr>
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Qty.</th>
												<th class="min-w-100px mw-100px fw-bold border-end">UOM</th>
												<th class="min-w-250px w-100 fw-bold border-end">Remarks</th>
												<th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Qty.</th>
												<th class="min-w-150px mw-100px fw-bold border-end">UOM</th>
											</tr>
										</thead>
										<tbody>
						
										</tbody>
									</table>
								</div>
							</div>
							<!--end::Files-->
						</div>
						<!--end::particular-->

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
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Find</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(SR > PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(SR > CP)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cancel Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(SR)</div>
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
								            <div class="fs-5 fw-bolder mb-2">MIS</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">GP</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Issuance</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(SR - OSM)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Issuance</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(SR - Non OSM)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT05();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Issuance</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(DI)</div>
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
        			
		<!--begin::Modal PR Find-->
		<div id="mdl010102PRFind" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Search record</h5>
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
                                    <input id="tbx01010201Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div01010201Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01010201Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Status</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Date Required</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Purchase Type</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Project</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Remarks</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Requestor</th>
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
		<!--begin::Modal PR Find-->
        
		<!--begin::Modal Cancel-->
		<div id="mdl0101Cancel" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Stock Issuance - Cancel Record</h5>
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
							<input id="tbx0101ReasonDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Date" />
						</div>
					    <div class="input-group input-group-sm">
						    <span class="input-group-text min-w-150px required">Reason</span>
						    <input id="tbx0101Reason" type="text" class="form-control " placeholder="Reason" maxlength="500" />
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
        
		<!--begin::Modal SR > PO -->
		<div id="mdl010103SRPO" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Transfer Item (SR > PO)</h5>
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
                                    <input id="tbx01010301Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div01010301Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01010301Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Date Required</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Requestor</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Qty</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Transfer</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Purchaser</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn01010301Transfer_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal SR > PO -->
        
		<!--begin::Modal SR > PO -->
		<div id="mdl010104SRCP" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Transfer Item (SR > CP)</h5>
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
                                    <input id="tbx01010401Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div01010401Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01010401Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Date Required</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Requestor</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Qty</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Transfer</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn01010401Transfer_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal SR > PO -->
        
		<!--begin::Modal SR > PO -->
		<div id="mdl010105CancelSR" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Cancel SR Items</h5>
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
                                    <input id="tbx01010501Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div01010501Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01010501Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Date Required</th>
                                        <th class="min-w-200px mw-200px fw-bold border-end">Requestor</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">for SR</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Cancel</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn01010501Cancel_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal SR > PO -->
        
		<!--begin::Modal Add record-->
		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Add record</h5>
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
							<span class="input-group-text min-w-150px required">Item</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx010201Item" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Add item" readonly="readonly" />
                                <input id="hf010201ItemCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn010201Item();">
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
						    <input id="tbx010201Qty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddQty(this);" type="text" class="form-control" maxlength="21" placeholder="Qty" value="0.00" />
                            <input id="hf010201Cost" runat="server" type="hidden" value="" />
                            <input id="hf010201Total" runat="server" type="hidden" value="" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
                            <input id="hf010201UOMCode" runat="server" type="hidden" value="" />
						    <input id="tbx010201UOM" type="text" class="form-control" placeholder="UOM" readonly="readonly" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Remarks</span>
						    <input id="tbx010201Remarks" type="text" class="form-control min-h-75px w-100" placeholder="Remarks" />
					    </div>
						<div id="div010201Separator" class="separator separator-dashed mb-2"></div>
						<div id="div010201PRNo" class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PR No.</span>
							<input id="tbx010201PRNo" type="text" class="form-control" readonly="readonly" placeholder="PR No." readonly="readonly" />
						</div>
					    <div id="div010201PRSeqNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">No.</span>
						    <input id="tbx010201PRSeqNo" type="text" class="form-control" placeholder="No." readonly="readonly" />
					    </div>
					    <div id="div010201PRItem" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Item</span>
						    <input id="tbx010201PRItem" type="text" class="form-control" placeholder="Item" readonly="readonly" />
					    </div>
					    <div id="div010201PRQty" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Qty</span>
						    <input id="tbx010201PRQty" type="text" class="form-control" placeholder="Qty" readonly="readonly" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
						    <input id="tbx010201PRUOM" type="text" class="form-control" placeholder="UOM" readonly="readonly" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010201Add_Ok(this); return false;">
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
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Add PR record-->
		<div id="mdl010201AddPR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Add record</h5>
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
                                    <input id="tbx01020201Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                        <div class="table-loading">
                            <div id="div01020201Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01020201Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">for SR</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Issue</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">UOM</th>
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
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn01020201Add_Ok(this); return false;">
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
		<!--begin::Modal Add PR record-->
        
		<!--begin::Modal Add RR record-->
		<div id="mdl010202AddDI" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Add record</h5>
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
                                    <input id="tbx01020202Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                        <div class="table-loading">
                            <div id="div01020202Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01020202Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">RR No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">for GP</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Issue</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">UOM</th>
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
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn01020202Add_Ok(this); return false;">
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
		<!--begin::Modal Add RR record-->
        
		<!--begin::Modal Edit record-->
		<div id="mdl0103Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Edit record</h5>
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
							<span class="input-group-text min-w-150px required">Item</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx010301Item" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Add item" readonly="readonly" />
                                <input id="hf010301ItemCode" runat="server" type="hidden" value="" />
                                <input id="hf010301pSeqNo" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn010301Item();">
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
						    <input id="tbx010301Qty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdQty(this);" type="text" class="form-control" placeholder="Qty" value="0.00" />
                            <input id="hf010301Cost" runat="server" type="hidden" value="" />
                            <input id="hf010301Total" runat="server" type="hidden" value="" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
                            <input id="hf010301UOMCode" runat="server" type="hidden" value="" />
						    <input id="tbx010301UOM" type="text" class="form-control" placeholder="UOM" readonly="readonly" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Remarks</span>
						    <input id="tbx010301Remarks" type="text" class="form-control min-h-75px w-100" placeholder="Remarks" />
					    </div>
						<div id="div010301Separator" class="separator separator-dashed mb-2"></div>
						<div id="div010301PRNo" class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PR No.</span>
							<input id="tbx010301PRNo" type="text" class="form-control" readonly="readonly" placeholder="PR No." readonly="readonly" />
						</div>
					    <div id="div010301PRSeqNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">No.</span>
						    <input id="tbx010301PRSeqNo" type="text" class="form-control" placeholder="No." readonly="readonly" />
					    </div>
					    <div id="div010301PRItem" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Item</span>
						    <input id="tbx010301PRItem" type="text" class="form-control" placeholder="Item" readonly="readonly" />
					    </div>
					    <div id="div010301PRQty" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Qty</span>
						    <input id="tbx010301PRQty" type="text" class="form-control" placeholder="Qty" readonly="readonly" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
						    <input id="tbx010301PRUOM" type="text" class="form-control" placeholder="UOM" readonly="readonly" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010301Edit_Ok(this); return false;">
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
		<!--begin::Modal Edit record-->

		<!--begin::Modal Search record-->
		<div id="mdl0104Item" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Stock Issuance - Search record</h5>
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
                                    <input id="tbx010401Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010401Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010401Item" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Item Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">Lock</th>
                                        <th class="min-w-250px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Qty</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Cost</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Total</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl0105Trxn" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered  mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">PR Transaction</h5>
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
                                    <input id="tbx010501Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010501Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010501Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-75px mw-75px fw-bold border-end">Type</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Date</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Posted"><i class='las la-check-circle fs-3'></i></span></th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Reversed"><i class='las la-times-circle fs-3'></i></span></th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Prepared By</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
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
						<textarea id="tbx0302Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Notes"></textarea>
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
	<input id="hdnCECode" type="hidden" value="" />
	<input id="hdnWCode" type="hidden" value="" />
	<input id="hdnType" type="hidden" value="" />
	<input id="hdn010201Qty" type="hidden" value="" />
	<input id="hdn010301Qty" type="hidden" value="" />
	<!--param-->


    <script src="Assets/js/SCM/SCM080100.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>


</asp:Content>
