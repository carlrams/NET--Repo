<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM090100.aspx.vb" Inherits="NET.SCM090100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Warehouse Transfer</li>
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
						<img src="Assets/media/svg/apps/SCM090000.svg" alt="" />
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
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Requested By</span>
											<span id="lbl0101RequestedBy" class="form-control ">-</span>
                                            <input id="hf0101RequestedByCode" runat="server" type="hidden" value="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Issued By</span>
											<span id="lbl0101IssuedBy" class="form-control ">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">From Whse.</span>
											<span id="lbl0101FromWhse" class="form-control">-</span>
                                            <input id="hf0101FromWhse" runat="server" type="hidden" value="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Transfer To</span>
											<span id="lbl0101TransferTo" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Trxn No.</span>
											<span id="lbl0101TrxnNo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">WT No.</span>
											<span id="lbl0101WTNo" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-8 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Authorized By</span>
											<span id="lbl0101AuthorizedBy" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Location</span>
											<span id="lbl0101GPLocation" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">
                                                <span class="d-flex justify-content-start">GP No.</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0101GPNo" onclick="return false;" />
												</div>
											</span>
											<span id="lbl0101GPNo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date</span>
											<span id="lbl0101WTDate" class="form-control">-</span>
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
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Requested By</span>
											<select id="ddl0101RequestedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Requested By</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Issued By</span>
											<select id="ddl0101IssuedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Issued By</option>
											</select>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">From Whse.</span>
											<select id="ddl0101FromWhse" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">From Warehouse</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Transfer To</span>
											<select id="ddl0101TransferTo" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Transfer To</option>
											</select>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Trxn No.</span>
											<input id="tbx0101TrxnNo" type="text" class="form-control " maxlength="13" Placeholder="Trxn No." readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">WT No.</span>
											<input id="tbx0101WTNo" type="text" class="form-control " maxlength="13" Placeholder="WT No." readonly="readonly" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-8 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Authorized By</span>
											<select id="ddl0101AuthorizedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Authorized By</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101GPLocation" class="input-group-text min-w-150px required">Location</span>
											<input id="tbx0101GPLocation" type="text" class="form-control " maxlength="180" Placeholder="Location" readonly="readonly" />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-4 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">
                                                <span class="d-flex justify-content-start">GP No.</span>
												<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm pl-3 ml-5">
													<input class="form-check-input" type="checkbox" value="" id="cbx0201GPNo" onclick="chkBox0201GPNo(this);" />
												</div>
											</span>
											<input id="tbx0101GPNo" type="text" class="form-control " Placeholder="GP No." maxlength="13" readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101WTDate" class="input-group-text min-w-150px">Date</span>
											<input id="tbx0101WTDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
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
                                                <th class="fw-bold border-end" colspan="6">WT Items</th>
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
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cancel Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(TR)</div>
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
								            <div class="fs-5 fw-bolder mb-2">WT</div>
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
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Transfer</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PR)</div>
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
				</div>
			</div>
		</div>
		<!--begin::Modal PR Find-->
        
		<!--begin::Modal Cancel-->
		<div id="mdl0101Cancel" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Warehouse Transfer - Cancel Record</h5>
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
        
		<!--begin::Modal SR > PO -->
		<div id="mdl010105CancelSR" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Warehouse Transfer - Cancel SR Items</h5>
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
                        <h5 class="modal-title">Warehouse Transfer - Add record</h5>
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
						    <input id="tbx010201Qty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddQty(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" />
                            <input id="hf010201Cost" runat="server" type="hidden" value="" />
                            <input id="hf010201Total" runat="server" type="hidden" value="" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
                            <input id="hf010201UOMCode" runat="server" type="hidden" value="" />
						    <input id="tbx010201UOM" type="text" class="form-control" Placeholder="UOM" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Remarks</span>
						    <input id="tbx010201Remarks" type="text" class="form-control min-h-75px w-100" Placeholder="Remarks" />
					    </div>
						<div id="div010201Separator" class="separator separator-dashed mb-2"></div>
						<div id="div010201PRNo" class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PR No.</span>
							<input id="tbx010201PRNo" type="text" class="form-control" readonly Placeholder="PR No." readonly />
						</div>
					    <div id="div010201PRSeqNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">No.</span>
						    <input id="tbx010201PRSeqNo" type="text" class="form-control" Placeholder="No." readonly />
					    </div>
					    <div id="div010201PRItem" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Item</span>
						    <input id="tbx010201PRItem" type="text" class="form-control" Placeholder="Item" readonly />
					    </div>
					    <div id="div010201PRQty" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Qty</span>
						    <input id="tbx010201PRQty" type="text" class="form-control" Placeholder="Qty" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
						    <input id="tbx010201PRUOM" type="text" class="form-control" Placeholder="UOM" readonly />
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
                        <h5 class="modal-title">Warehouse Transfer - Add record</h5>
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
                                        <th class="min-w-100px mw-100px fw-bold border-end">for WT</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Transfer</th>
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
        
		<!--begin::Modal Edit record-->
		<div id="mdl0103Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Warehouse Transfer - Edit record</h5>
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
						    <input id="tbx010301Qty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdQty(this);" type="text" class="form-control" Placeholder="Qty" value="0.00" />
                            <input id="hf010301Cost" runat="server" type="hidden" value="" />
                            <input id="hf010301Total" runat="server" type="hidden" value="" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
                            <input id="hf010301UOMCode" runat="server" type="hidden" value="" />
						    <input id="tbx010301UOM" type="text" class="form-control" Placeholder="UOM" maxlength="21" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Remarks</span>
						    <input id="tbx010301Remarks" type="text" class="form-control min-h-75px w-100" Placeholder="Remarks" />
					    </div>
						<div id="div010301Separator" class="separator separator-dashed mb-2"></div>
						<div id="div010301PRNo" class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PR No.</span>
							<input id="tbx010301PRNo" type="text" class="form-control" readonly Placeholder="PR No." readonly />
						</div>
					    <div id="div010301PRSeqNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">No.</span>
						    <input id="tbx010301PRSeqNo" type="text" class="form-control" Placeholder="No." readonly />
					    </div>
					    <div id="div010301PRItem" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Item</span>
						    <input id="tbx010301PRItem" type="text" class="form-control" Placeholder="Item" readonly />
					    </div>
					    <div id="div010301PRQty" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Qty</span>
						    <input id="tbx010301PRQty" type="text" class="form-control" Placeholder="Qty" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
						    <input id="tbx010301PRUOM" type="text" class="form-control" Placeholder="UOM" readonly />
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
                        <h5 class="modal-title">Warehouse Transfer - Search record</h5>
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
        function fnFormatNumberAddQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("ContentPlaceHolder1_hf010201Cost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("ContentPlaceHolder1_hf010201Total").value = formatNumber(Total);
        };
        function fnFormatNumberUpdQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var PRQty = parseFloat(document.getElementById("tbx010301PRQty").value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("ContentPlaceHolder1_hf010301Cost").value.replace(/,/g, '')) || 0.00;
            if (Qty >= PRQty) {
                Qty = PRQty;
            };
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("ContentPlaceHolder1_hf010301Total").value = formatNumber(Total);
        };
        function fnFormatNumericTransfer(input, maxQty) {
            const rawVal = input.value.trim();
            let val = parseFloat(rawVal);
            if (isNaN(val) || rawVal === '') {
                input.value = '0.00';
                return;
            };
            if (val >= maxQty) {
                val = maxQty;
            };
            if (val < 0) val = 0;
            input.value = val.toFixed(2);
        }
        //numeric

		//general
		function fn01Load() {
            fnAccess('SCM090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadParticular(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                document.getElementById("btn0102Add").classList.add("d-none");
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
                document.getElementById("btn0102Add").classList.remove("d-none");
                document.getElementById("btn0102Add").classList.add("btn-add");
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
            document.getElementById("btn0102Add").disabled = pValue;
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
        function chkBox0201GPNo(el) {
            if (el.checked) {
                document.getElementById("spn0101GPLocation").classList.add("required");
                document.getElementById("tbx0101GPLocation").readOnly = false;
            } else {
                document.getElementById("spn0101GPLocation").classList.remove("required");
                document.getElementById("tbx0101GPLocation").readOnly = true;
                document.getElementById("tbx0101GPLocation").value = "";
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
                ddl0101RequestedBy('');
                $('#ddl0101RequestedBy').val('').trigger('change');
                ddl0101IssuedBy('');
                $('#ddl0101IssuedBy').val('').trigger('change');
                ddl0101AuthorizedBy('');
                $('#ddl0101AuthorizedBy').val('').trigger('change');
                ddl0101FromWhse('');
                $('#ddl0101FromWhse').val('').trigger('change');
                ddl0101TransferTo('');
                $('#ddl0101TransferTo').val('').trigger('change');
                document.getElementById("tbx0101GPLocation").value = "";
                document.getElementById("tbx0101TrxnNo").value = "";
                document.getElementById("tbx0101WTNo").value = "";
                document.getElementById("cbx0201GPNo").checked = false;
                document.getElementById("tbx0101GPNo").value = "";
                document.getElementById("tbx0101WTDate").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
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
                        'FormCode': 'SCM090100',
                        'Type': 'Warehouse Transfer - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].FromWhseName;
                        document.getElementById("spn0101ID").innerText = response[0].WTCode;
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
                        document.getElementById("lbl0101RequestedBy").innerText = response[0].RequestedByName;
                        document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value = response[0].RequestedByCode;
                        document.getElementById("lbl0101IssuedBy").innerText = response[0].IssuedByName;
                        document.getElementById("lbl0101AuthorizedBy").innerText = response[0].AuthorizedByName;
                        document.getElementById("lbl0101GPLocation").innerText = response[0].GPLocation;
                        document.getElementById("lbl0101FromWhse").innerText = response[0].FromWhseName;
                        document.getElementById("ContentPlaceHolder1_hf0101FromWhse").value = response[0].FromWhseCode;
                        document.getElementById("lbl0101TransferTo").innerText = response[0].ToWhseName;
                        document.getElementById("lbl0101TrxnNo").innerText = response[0].WTCode;
                        document.getElementById("lbl0101WTNo").innerText = response[0].WTNo;
                        document.getElementById("cbx0101GPNo").checked = response[0].GP;
                        document.getElementById("lbl0101GPNo").innerText = response[0].GPNo;
                        document.getElementById("lbl0101WTDate").innerText = response[0].WTDate;
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
                        'FormCode': 'SCM090100',
                        'Type': 'Warehouse Transfer - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].FromWhseName;
                        document.getElementById("spn0101ID").innerText = response[0].WTCode;
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
                        ddl0101RequestedBy(response[0].RequestedByCode);
                        ddl0101IssuedBy(response[0].IssuedByCode);
                        ddl0101AuthorizedBy(response[0].AuthorizedByCode);
                        document.getElementById("tbx0101GPLocation").value = response[0].GPLocation;
                        ddl0101FromWhse(response[0].FromWhseCode);
                        ddl0101TransferTo(response[0].ToWhseCode);
                        document.getElementById("tbx0101TrxnNo").value = response[0].WTCode;
                        document.getElementById("tbx0101WTNo").value = response[0].WTNo;
                        document.getElementById("cbx0201GPNo").checked = response[0].GP;
                        document.getElementById("tbx0101GPNo").value = response[0].GPNo;
                        document.getElementById("tbx0101WTDate").value = response[0].WTDate;
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
            function ddl0101Warehouse(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Warehouse',
                        'pPlaceHolder': 'Warehouse',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Warehouse").html(s);
                        $('#ddl0101Warehouse').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101RequestedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee',
                        'pPlaceHolder': 'Requested By',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101RequestedBy").html(s);
                        $('#ddl0101RequestedBy').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101IssuedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record',
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
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record',
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
            function ddl0101FromWhse(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Warehouse',
                        'pPlaceHolder': 'From Warehouse',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101FromWhse").html(s);
                        $('#ddl0101FromWhse').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101TransferTo(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Warehouse',
                        'pPlaceHolder': 'Transfer To',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101TransferTo").html(s);
                        $('#ddl0101TransferTo').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('SCM090000', 'Add', function (response) {
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
                fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM090000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    //if exisit
                    fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                        if (response[0].oReturn == "1") {
                            fnValidateRecord('Trxn_WTHdr', ID, '', 'Delete', function (response) {
                                if (response[0].oReturn == "") {
                                    Delete_Dtl_Question(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        } else {
                            window.location.replace("MNU040100");
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
                        fnValidateRecord('Trxn_WTHdr', ID, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Detele_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('SCM090000', 'Trxn_WTHdr', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM090000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM090000");
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
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM090000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM090000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
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
                if (document.getElementById("ddl0101RequestedBy").options[document.getElementById("ddl0101RequestedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("cbx0201GPNo").checked == true && document.getElementById("tbx0101GPLocation").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101FromWhse").options[document.getElementById("ddl0101FromWhse").selectedIndex].value == "") { 
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101TransferTo").options[document.getElementById("ddl0101TransferTo").selectedIndex].value == "") {
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
                            //if exisit
                            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                if (response[0].oReturn == "1") {
                                    fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
                                        if (response[0].oReturn == "") {
                                            Edit_Upd_Ok_Await(ID);
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                } else {
                                    window.location.replace("MNU040100");
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
                        'FormCode': 'SCM090100',
                        'Type': 'Warehouse Transfer - Add Record',
                        'pRequestedBy': document.getElementById("ddl0101RequestedBy").options[document.getElementById("ddl0101RequestedBy").selectedIndex].value,
                        'pIssuedBy': document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value,
                        'pAuthorizedBy': document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value,
                        'pFromWhse': document.getElementById("ddl0101FromWhse").options[document.getElementById("ddl0101FromWhse").selectedIndex].value,
                        'pTransferTo': document.getElementById("ddl0101TransferTo").options[document.getElementById("ddl0101TransferTo").selectedIndex].value,
                        'pGP': document.getElementById("cbx0201GPNo").checked,
                        'pGPNo': document.getElementById("tbx0101GPNo").value,
                        'pGPLocation': document.getElementById("tbx0101GPLocation").value,
                        'pWTNo': document.getElementById("tbx0101WTNo").value,
                        'pWTDate': document.getElementById("tbx0101WTDate").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Add", response[0].oID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oID;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadParticular(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD";
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                // Do Update
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Warehouse Transfer - Edit Record',
                        'pID': ID,
                        'pRequestedBy': document.getElementById("ddl0101RequestedBy").options[document.getElementById("ddl0101RequestedBy").selectedIndex].value,
                        'pIssuedBy': document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value,
                        'pAuthorizedBy': document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value,
                        'pFromWhse': document.getElementById("ddl0101FromWhse").options[document.getElementById("ddl0101FromWhse").selectedIndex].value,
                        'pTransferTo': document.getElementById("ddl0101TransferTo").options[document.getElementById("ddl0101TransferTo").selectedIndex].value,
                        'pGP': document.getElementById("cbx0201GPNo").checked,
                        'pGPNo': document.getElementById("tbx0101GPNo").value,
                        'pGPLocation': document.getElementById("tbx0101GPLocation").value,
                        'pWTNo': document.getElementById("tbx0101WTNo").value,
                        'pWTDate': document.getElementById("tbx0101WTDate").value
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
        function fn0101Lock() {
            //if exisit
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Lock', function (response) {
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
                                fnValidateRecord('Trxn_WTHdr', ID, '', 'Lock', function (response) {
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
                fnLock('Lock', 'Trxn_WTHdr', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exisit
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Unlock', function (response) {
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
                                fnValidateRecord('Trxn_WTHdr', ID, '', 'Unlock', function (response) {
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
                fnLock('Unlock', 'Trxn_WTHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Post() {
            //if exisit
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Post', function (response) {
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
                                fnValidateRecord('Trxn_WTHdr', ID, '', 'Post', function (response) {
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
                        'pRecType': "WT",
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
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Reverse', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Reverse', function (response) {
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
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                if (document.getElementById("tbx0101ReasonDate").value == "" || document.getElementById("tbx0101Reason").value == "") {
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
                                    //if exisit
                                    fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                        if (response[0].oReturn == "1") {
                                            fnValidateRecord('Trxn_WTHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Reverse', function (response) {
                                                if (response[0].oReturn == "") {
                                                    Add_Cancel_Await();
                                                } else {
                                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                };
                                            });
                                        } else {
                                            window.location.replace("MNU040100");
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
                            'FormCode': 'SCM090100',
                            'Type': 'Warehouse Transfer - Cancel Record',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pReasonDate': document.getElementById("tbx0101ReasonDate").value,
                            'pReason': document.getElementById("tbx0101Reason").value
                        },
                        success: function (response) {
                            //cancel
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            document.getElementById("tbx0101ReasonDate").value = "";
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
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'PR Find',
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div01010201Loader").style.display = "";
                    //display loader

                    $('#table01010201Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01010201Record = $("#table01010201Record").DataTable({
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
                            { data: 'PRNo' },
                            { data: 'Status' },
                            { data: 'DateRequired' },
                            { data: 'PurchaseType' },
                            { data: 'Project' },
                            { data: 'Remarks' },
                            { data: 'Requestor' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: [4, 5, 6, 7], className: 'tbody-nowrap-auto'
                            }
                        ],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx01010201Find').on('keyup', function () {
                        table01010201Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div01010201Loader").style.display = "none";
                    //hide loader

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    //modal
                    $('#mdl010101Tools').modal('hide');
                    $('#mdl010102PRFind').modal('show');
                },
            });
        };
        function fn010101_SCM03TLS02() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'Warehouse Transfer - Trasfer Item : SR > PO',
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div01010301Loader").style.display = "";
                    //display loader

                    $('#table01010301Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01010301Record = $("#table01010301Record").DataTable({
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
                            { data: 'PRNo' },
                            { data: 'DateRequired' },
                            { data: 'Requestor' },
                            { data: 'SeqNo' },
                            { data: 'Item' },
                            { data: 'ForCP' },
                            { data: 'ForCPBalance' },
                            {
                                data: 'Transfer',
                                render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let rowVal = parseFloat(row.ForCPBalance).toFixed(2);

                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        }).format(rowVal);

                                        let textbox = `
                                                    <input prm01010301Transfer="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Transfer" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericTransfer(this, ${row.ForCP});" />
                                                `;
                                        return textbox;
                                    }
                                    return data;
                                }
                            },
                            { data: 'Unit' },
                            {
                                data: 'Purchaser',
                                render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let selectId = `${meta.row}`; // Unique ID for each row
                                        let dropdown = `
								<select id="${selectId}" prm01010301Purchaser="${rowId}" data-dropdown-parent="#mdl010103SRPO" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
                                    <option value="">Select Purchaser</option>
                                </select>`;

                                        // Fetch data asynchronously
                                        $.ajax({
                                            type: 'GET',
                                            url: 'HNDSCM.ashx',
                                            data: {
                                                'FormCode': 'SCM060100',
                                                'Type': 'Purchaser'
                                            },
                                            success: function (response) {
                                                let options = response.map(item => `<option value="${item.ID}">${item.Name}</option>`).join('');
                                                // Update the select dropdown, keeping the default option
                                                $(`#${selectId}`).html(`<option value="">Select Purchaser</option>` + options);
                                            },
                                            error: function () {
                                                $(`#${selectId}`).html('<option>Error loading options</option>');
                                            }
                                        });

                                        return dropdown;
                                    }
                                    return data; 
                                }
                            },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0,
                                orderable: false
                            },
                            {
                                targets: [6, 7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [5],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        drawCallback: function () {
                            $('[data-kt-repeater="select2"]').select2({
                                width: '100%'
                            });
                        },
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx01010301Find').on('keyup', function () {
                        table01010301Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div01010301Loader").style.display = "none";
                    //hide loader

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    //modal
                    $('#mdl010101Tools').modal('hide');
                    $('#mdl010103SRPO').modal('show');
                },
            });
        };
        function fn010101_SCM03TLS03() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'Warehouse Transfer - Trasfer Item : SR > CP',
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div01010401Loader").style.display = "";
                    //display loader

                    $('#table01010401Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01010401Record = $("#table01010401Record").DataTable({
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
                            { data: 'PRNo' },
                            { data: 'DateRequired' },
                            { data: 'Requestor' },
                            { data: 'SeqNo' },
                            { data: 'Item' },
                            { data: 'ForCP' },
                            { data: 'ForCPBalance' },
                            {
                                data: 'Transfer',
                                render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let rowVal = parseFloat(row.ForCPBalance).toFixed(2);

                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        }).format(rowVal);

                                        let textbox = `
                                                    <input prm01010401Transfer="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Transfer" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericTransfer(this, ${row.ForCP});" />
                                                `;
                                        return textbox;
                                    }
                                    return data;
                                }
                            },
                            { data: 'Unit' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0,
                                orderable: false
                            },
                            {
                                targets: [6, 7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [5],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx01010401Find').on('keyup', function () {
                        table01010401Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div01010401Loader").style.display = "none";
                    //hide loader

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    //modal
                    $('#mdl010101Tools').modal('hide');
                    $('#mdl010104SRCP').modal('show');
                },
            });
        };
        function fn010101_SCM03TLS04() {
            //access
            fnAccess('SCM090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Cancel_Item();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //cancel
            function Cancel_Item() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Warehouse Transfer - Cancel Item : SR',
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div01010501Loader").style.display = "";
                        //display loader

                        $('#table01010501Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table01010501Record = $("#table01010501Record").DataTable({
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
                                { data: 'PRNo' },
                                { data: 'DateRequired' },
                                { data: 'Requestor' },
                                { data: 'SeqNo' },
                                { data: 'Item' },
                                { data: 'ForSR' },
                                { data: 'ForSRBalance' },
                                {
                                    data: 'Cancel',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let rowVal = parseFloat(row.ForSRBalance).toFixed(2);

                                            //Format Number
                                            let formattedValue = new Intl.NumberFormat('en-US', {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            }).format(rowVal);

                                            let textbox = `
                                                    <input prm01010501Cancel="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Cancel" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericTransfer(this, ${row.ForSR});" />
                                                `;
                                            return textbox;
                                        }
                                        return data;
                                    }
                                },
                                { data: 'Unit' },
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0,
                                    orderable: false
                                },
                                {
                                    targets: [6, 7],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                },
                                {
                                    targets: [5],
                                    className: 'tbody-nowrap-auto'
                                }
                            ],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01010501Find').on('keyup', function () {
                            table01010501Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01010501Loader").style.display = "none";
                        //hide loader

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                        //modal
                        $('#mdl010101Tools').modal('hide');
                        $('#mdl010105CancelSR').modal('show');
                    },
                });
            };
        };
        function fn010101_SCM03RPT00(ID) {
            //access
            fnAccess('SCM090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM090100',
                            'Type': 'Warehouse Transfer - Preview Report',
                            'pID': ID,
                            'pReport': "PR",
                            'pCategory': 'PR Printout'
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT01() {
            //access
            fnAccess('SCM090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM090100',
                            'Type': 'Warehouse Transfer - Preview Report',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pReport': "WT",
                            'pCategory': "WT Printout"
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT02() {
            if (document.getElementById("cbx0101GPNo").checked) {
                //access
                fnAccess('SCM090000', 'View', function (response) {
                    if (response[0].oReturn == "1") {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM090100',
                                'Type': 'Warehouse Transfer - Preview Report',
                                'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                                'pReport': "GP",
                                'pCategory': ""
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                };
                            }
                        });
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
        };
        function fn010101_SCM03RPT03() {
            //access
            fnAccess('SCM090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM090100',
                            'Type': 'Warehouse Transfer - Preview RDLC',
                            'pCategory': 'For Transfer (PR)'
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //overview

        //tools
        function fn01010201View(pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'PR Find (Trxn)',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010501Loader").style.display = "";
                    //display loader

                    $('#table010501Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010501Record = $("#table010501Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        paging: false,
                        lengthChange: true,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Type' },
                            { data: 'No' },
                            { data: 'Date' },
                            { data: 'Post' },
                            { data: 'Rvrs' },
                            { data: 'PreparedBy' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0, 1, 2, 3, 4, 5, 6], orderable: false
                            },
                            {
                                targets: 6, className: 'tbody-nowrap-auto'
                            }
                        ],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010501Find').on('keyup', function () {
                        table010501Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010501Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0105Trxn').modal('show');
                },
            });
        };
        //tools

        //transfer
        function fn01010501Cancel_Ok(Btn) {
            // Get all
            //var checkBoxes = document.querySelectorAll('.cbx01010501CancelSR');

            // DataTables API
            var table01010501Record = $('#table01010501Record').DataTable();

            // get all checkboxes across all pages
            var checkBoxes = table01010501Record.$('.cbx01010501CancelSR', { page: 'all' });

            // Check if atleast one
            var checkedValues = Array.from(checkBoxes)
                .filter(checkBox => checkBox.checked)
                .map(checkBox => ({
                    PRNo: checkBox.value,
                    SeqNo: checkBox.getAttribute('data-kt-no')
            }));

            if (checkedValues.length > 0) {
                //Array
                let ItemList = [];
                //Loop
                checkedValues.forEach(item => {
                    //var tbx01010501Cancel = document.querySelector('[prm01010501Cancel="rowID01010501' + item.PRNo + '' + item.SeqNo + '"]');

                    // Attributes
                    var $tbx01010501Cancel = table01010501Record.$(
                        '[prm01010501Cancel="rowID01010501' + item.PRNo + item.SeqNo + '"]',
                        { page: 'all' }
                    );

                    // Read values safely
                    let cancelValue = ($tbx01010501Cancel.length > 0 ? $tbx01010501Cancel.val() : "0");

                    // Push as an object to the array
                    ItemList.push({
                        PRNo: item.PRNo,
                        SeqNo: item.SeqNo,
                        //Cancel: parseFloat(tbx01010501Cancel.value.replace(/,/g, ''))
                        Cancel: cancelValue
                    });

                });

                //Format Item
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Cancel}`
                ).join('®');
                let ItemPR = ItemList.map(i => ({
                    PRNo: i.PRNo,
                    SeqNo: i.SeqNo,
                    Cancel: i.Cancel
                }));
                //Question
                Transfer_Question(ItemSrs, ItemPR, Btn);
            } else {
                fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                //Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
            //Return Question
            function Transfer_Question(ItemSrs, ItemPR, Btn) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be cancelled, cancel Item(s)?</span>',
                    html: `<input id="tbx01010501Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    icon: 'question',
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
                        fnValidatePassword(document.getElementById("tbx01010501Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Cancel_Ok(ItemSrs, ItemPR, Btn);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                });
            };
            // Add transfer
            function Cancel_Ok(ItemSrs, ItemPR, Btn) {
                //cancel
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Warehouse Transfer - Add Cancel Item : SR',
                        'pItemSrs': ItemSrs
                    },
                    success: async function (response) {
                        //alert
                        fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        // Modal
                        $("#mdl010105CancelSR").modal("hide");
                    },
                });
            };
        };
        //transfer

        //report
        function fn010501View(pID, pCode, pType) {
            //access
            fnAccess('SCM090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview Report',
                            'pID': pID,
                            'pCode': pCode,
                            'pType': pType
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //report

        //particular
        function fn0102LoadParticular(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'Warehouse Transfer - Particular',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0102LoaderParticular").style.display = "";
                    //display loader

                    $('#table0102Particular').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0102Particular = $("#table0102Particular").DataTable({
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
                            { data: 'No' },
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMName' },
                            { data: 'Remarks' },
                            { data: 'PRNo' },
                            { data: 'PRSeqNo' },
                            { data: 'PRItem' },
                            { data: 'PRQty' },
                            { data: 'PRUnit' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false
                            },
                            {
                                targets: [3, 9],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [2, 5, 8],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx0102FindParticular').on('keyup', function () {
                        table0102Particular.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0102LoaderParticular").style.display = "none";
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
        function fn0102Redraw(Action, pID, pSeqNo) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record - DTL - Particular : Redraw',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table0102Particular').DataTable();
                            gv01.rows().deselect();
                            //last row
                            let lastrowId = "";
                            response.forEach(item => {
                                var row01 = gv01.row.add({
                                    Action: item.Action,
                                    No: item.No,
                                    ItemName: item.ItemName,
                                    Qty: item.Qty,
                                    UMName: item.UMName,
                                    Remarks: item.Remarks,
                                    PRNo: item.PRNo,
                                    PRSeqNo: item.PRSeqNo,
                                    PRItem: item.PRItem,
                                    PRQty: item.PRQty,
                                    PRUnit: item.PRUnit
                                }).draw(false).select();
                                // Set ID for each row
                                $(row01.node()).attr('id', item.rowId);

                                // Keep track of the last row ID to scroll to it later
                                lastRowId = item.rowId;
                            });

                            // Scroll to the last added row
                            if (lastRowId !== '') {
                                let new01 = gv01.row('#' + lastRowId);
                                let index01 = new01.index();
                                var rowNode = gv01.row(index01).node();
                                rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            };
                        } else if (Action == "Edit") {
                            //edit row
                            var gv01 = $('#table0102Particular').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].No).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].ItemName).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Qty).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].UMName).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].Remarks).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].PRNo).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].PRSeqNo).draw(false);
                            gv01.cell({ row: index01, column: 8 }).data(response[0].PRItem).draw(false);
                            gv01.cell({ row: index01, column: 9 }).data(response[0].PRQty).draw(false);
                            gv01.cell({ row: index01, column: 10 }).data(response[0].PRUnit).draw(false);
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
                var gv01 = $('#table0102Particular').DataTable();
                let pCode = pID + '' + pSeqNo;
                gv01.row('#rowID0102' + pCode).remove().draw(false);
            };
        };
        async function fn01020201Redraw(Action, PRNo, SeqNo) {
            return new Promise(resolve => {
                //update list
                if (Action == "Add" || Action == "Edit") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM090100',
                            'Type': 'Get Record - DTL - Particular : PR Redraw',
                            'pRequestor': document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value,
                            'pPRNo': PRNo,
                            'pSeqNo': SeqNo
                        },
                        success: function (response) {
                            if (Action == "Add") {
                                //add row
                                var gv01 = $('#table01020201Record').DataTable();
                                gv01.rows().deselect();
                                //last row
                                let lastRowId = "";
                                response.forEach(item => {
                                    var row01 = gv01.row.add(
                                        {
                                            Action: item.Action,
                                            PRNo: item.PRNo,
                                            SeqNo: item.SeqNo,
                                            Item: item.Item,
                                            ForSR: item.ForSR,
                                            ForSRBalance: item.ForSRBalance,
                                            Issuance: item.Transfer,
                                            Unit: item.Unit
                                        }).draw(false).select();
                                    // Set ID for each row
                                    $(row01.node()).attr('id', item.rowId);

                                    // Keep track of the last row ID to scroll to it later
                                    lastRowId = item.rowId;
                                });

                                // Scroll to the last added row
                                if (lastRowId !== '') {
                                    let new01 = gv01.row('#' + lastRowId);
                                    let index01 = new01.index();
                                    var rowNode = gv01.row(index01).node();
                                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                };

                            } else if (Action == "Edit") {
                                //edit row
                                var gv01 = $('#table01020201Record').DataTable();
                                gv01.rows().deselect();

                                response.forEach(item => {
                                    let row01 = gv01.row('#' + item.rowId);
                                    if (row01.length === 0) return; // Skip if row not found

                                    let index01 = row01.index();

                                    gv01.cell({ row: index01, column: 0 }).data(item.Action).draw(false);
                                    gv01.cell({ row: index01, column: 1 }).data(item.PRNo).draw(false);
                                    gv01.cell({ row: index01, column: 2 }).data(item.SeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 3 }).data(item.Item).draw(false);
                                    gv01.cell({ row: index01, column: 4 }).data(item.ForSR).draw(false);
                                    gv01.cell({ row: index01, column: 5 }).data(item.ForSRBalance).draw(false);
                                    gv01.cell({ row: index01, column: 6 }).data(item.Transfer).draw(false);
                                    gv01.cell({ row: index01, column: 7 }).data(item.Unit).draw(false);

                                    //select and scroll to record
                                    row01.select();
                                    var rowNode = gv01.row(index01).node();
                                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                });
                            };
                        },
                    });
                } else {
                    //assigned
                    var gv01 = $('#table01020201Record').DataTable();
                    let Code = PRNo + '' + SeqNo;
                    gv01.row('#rowID01020201' + Code).remove().draw(false);
                };
                resolve();
            });
        };
        function fn0102Add() {
            //if exist
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                document.getElementById("tbx010201Item").value = "";
                document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value = "";
                document.getElementById("tbx010201Qty").value = "0.00";
                document.getElementById("ContentPlaceHolder1_hf010201Cost").value = "";
                document.getElementById("ContentPlaceHolder1_hf010201Total").value = "";
                document.getElementById("tbx010201UOM").value = "";
                document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value = "";
                document.getElementById("tbx010201Remarks").value = "";
                document.getElementById("tbx010201PRNo").value = "";
                document.getElementById("tbx010201PRSeqNo").value = "";
                document.getElementById("tbx010201PRItem").value = "";
                document.getElementById("tbx010201PRQty").value = "0.00";
                document.getElementById("tbx010201PRUOM").value = "";
                $('#mdl0102Add').modal('show');
            };
        };
        function fn010201Item() {
            //item
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'Warehouse Transfer - Add Record : Item',
                    'pWTDate': document.getElementById("lbl0101WTDate").innerText,
                    'pFromWhse': document.getElementById("ContentPlaceHolder1_hf0101FromWhse").value
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010401Loader").style.display = "";
                    //display loader

                    $('#table010401Item').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010401Item = $("#table010401Item").DataTable({
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
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMName' },
                            { data: 'Cost' },
                            { data: 'Total' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: [4, 6 ,7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
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
                    $('#tbx010401Find').on('keyup', function () {
                        table010401Item.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010401Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0104Item').modal('show');
                },
            });
        };
        function fn010201Add_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID, SeqNo) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
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
                    if (document.getElementById("tbx010201Item").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010201Qty").value == "") {
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
                                //if exisit
                                fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                    if (response[0].oReturn == "1") {
                                        fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
                                            if (response[0].oReturn == "") {
                                                Edit_Ok(ID);
                                            } else {
                                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                            };
                                        });
                                    } else {
                                        window.location.replace("MNU040100");
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
                                'FormCode': 'SCM090100',
                                'Type': 'Warehouse Transfer - Add Record : Particular',
                                'pID': ID,
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value,
                                'pQty': document.getElementById("tbx010201Qty").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value,
                                'pCost': document.getElementById("ContentPlaceHolder1_hf010201Cost").value,
                                'pTotal': document.getElementById("ContentPlaceHolder1_hf010201Total").value,
                                'pRemarks': document.getElementById("tbx010201Remarks").value,
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx010201Item").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value = "";
                                document.getElementById("tbx010201Qty").value = "0.00";
                                document.getElementById("ContentPlaceHolder1_hf010201Cost").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010201Total").value = "";
                                document.getElementById("tbx010201UOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value = "";
                                document.getElementById("tbx010201Remarks").value = "";
                                document.getElementById("tbx010201PRNo").value = "";
                                document.getElementById("tbx010201PRSeqNo").value = "";
                                document.getElementById("tbx010201PRItem").value = "";
                                document.getElementById("tbx010201PRQty").value = "0.00";
                                document.getElementById("tbx010201PRUOM").value = "";
                                fn0102Redraw("Add", response[0].oID, response[0].oSeqNo);
                            },
                        });
                        //modal
                        $('#mdl0102Add').modal('hide');
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
        function fn010202Item(pItemCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record : Item',
                        'pItemCode': pItemCode,
                        'pWTDate': document.getElementById("lbl0101WTDate").innerText,
                        'pFromWhse': document.getElementById("ContentPlaceHolder1_hf0101FromWhse").value
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010201Item").value = response[0].ItemName;
                        document.getElementById("tbx010201Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010201Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010201UOM").value = response[0].UMName;
                        let newCost = parseFloat(document.getElementById("tbx010201Qty").value.replace(/,/g, '')) * response[0].Cost;
                        document.getElementById("ContentPlaceHolder1_hf010201Total").value = formatNumber(newCost);
                        //modal
                        $('#mdl0104Item').modal('hide');
                    },
                });
            };
        };
        function fn0102AddPR() {
            //if exist
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                //if exist
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
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
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record - DTL - Particular : PR',
                        'pRequestor': document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value
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
                        //hide loader
                        document.getElementById("div01020201Loader").style.display = "";
                        //hide loader

                        $('#table01020201Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table01020201Record = $("#table01020201Record").DataTable({
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
                                { data: 'PRNo', },
                                { data: 'SeqNo' },
                                { data: 'Item' },
                                { data: 'ForSR' },
                                { data: 'ForSRBalance' },
                                {
                                    data: 'Transfer',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let rowVal = parseFloat(row.ForSRBalance).toFixed(2);

                                            //Format Number
                                            let formattedValue = new Intl.NumberFormat('en-US', {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            }).format(rowVal);

                                            let textbox = `
                                                    <input prm01020201Transfer="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Issuance" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericTransfer(this, ${row.ForSR});" />
                                                `;
                                            return textbox;
                                        }
                                        return data;
                                    }
                                },
                                { data: 'Unit' },
                            ],
                            drawCallback: function () {
                                $('[data-kt-repeater="select2"]').select2({
                                    width: '100%'
                                });
                            },
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false,
                                }
                                ,
                                {
                                    targets: [3],
                                    className: 'tbody-nowrap-auto'
                                },
                                {
                                    targets: [4, 5, 6],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                }
                            ],
                            order: [[1, 'asc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01020201Find').on('keyup', function () {
                            table01020201Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01020201Loader").style.display = "none";
                        //hide loader

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
                $('#mdl010201AddPR').modal('show');
            };
        };
        async function fn01020201Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });

            //access
            fnAccess('SCM090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn01020201Add_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn01020201Add_Ok_Await(Btn) {
                // Get all
                //var checkBoxes = document.querySelectorAll('.cbxPR01020201');

                // DataTables API (important fix for pagination issue!)
                var table01020201Record = $('#table01020201Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table01020201Record.$('.cbxPR01020201', { page: 'all' });

                // Check if atleast one
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        PRNo: checkBox.value,
                        SeqNo: checkBox.getAttribute('data-kt-no')
                    }));

                if (checkedValues.length > 0) {
                    //Array
                    let ItemList = [];
                    //Loop
                    checkedValues.forEach(item => {
                        //var tbx01020201Transfer = document.querySelector('[prm01020201Transfer="rowID01020201' + item.PRNo + '' + item.SeqNo + '"]');

                        // Selectors must match your HTML attributes!
                        var $tbx01020201Transfer = table01020201Record.$(
                            '[prm01020201Transfer="rowID01020201' + item.PRNo + item.SeqNo + '"]',
                            { page: 'all' }
                        );

                        // Read values safely
                        let transferValue = ($tbx01020201Transfer.length > 0 ? $tbx01020201Transfer.val() : "0");

                        // Push as an object to the array
                        ItemList.push({
                            PRNo: item.PRNo,
                            SeqNo: item.SeqNo,
                            //Transfer: parseFloat(tbx01020201Transfer.value.replace(/,/g, ''))
                            Transfer: transferValue
                        });

                    });

                    //Format Item
                    let ItemSrs = ItemList.map(i =>
                        `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                    ).join('®');
                    let ItemPR = ItemList.map(i => ({
                        PRNo: i.PRNo,
                        SeqNo: i.SeqNo,
                        Transfer: i.Transfer
                    }));
                    //Question
                    Transfer_Question(ItemSrs, ItemPR, Btn);
                } else {
                    Swal.close(); // close loader before confirmation
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
                //Return Question
                function Transfer_Question(ItemSrs, ItemPR, Btn) {
                    Swal.close(); // close loader before confirmation
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Adding the selected items will overwrite the existing WT Item(s), add Item(s)?</span>',
                        icon: 'question',
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
                            // Show loader again while saving
                            Swal.fire({
                                title: 'Saving...',
                                html: 'Please wait',
                                allowOutsideClick: false,
                                allowEscapeKey: false,
                                didOpen: () => Swal.showLoading()
                            });

                            //if exist
                            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                if (response[0].oReturn == "1") {
                                    fnValidateRecord('Trxn_WTHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                                        if (response[0].oReturn == "") {
                                            Transfer_Ok(ItemSrs, ItemPR, Btn);
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                            // Disable the clicked button to avoid multiple clicks
                                            Btn.disabled = false;
                                            // Hide loading indication
                                            Btn.removeAttribute('data-kt-indicator');
                                        };
                                    });
                                } else {
                                    window.location.replace("MNU040100");
                                };
                            });

                        } else {
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                };
                // Add ok
                function Transfer_Ok(ItemSrs, ItemPR, Btn) {
                    //issuance
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM090100',
                            'Type': 'Add Record - DTL - Particular : PR',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pItemSrs': ItemSrs,
                        },
                        success: async function (response) {
                            Swal.close();
                            //alert
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            //load
                            // Destroy the DataTable before reloading
                            if ($.fn.DataTable.isDataTable('#table01020201Record')) {
                                var table = $('#table01020201Record').DataTable();
                                table.clear().destroy();
                            }
                            $('#table01020201Record tbody').empty();

                            fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            $("#mdl010201AddPR").modal("hide");
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        },
                    });
                };
            };
        };
        function fn010201Delete(pID, pSeqNo) {
            //if exist
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
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
                        fnValidateRecord('Trxn_WTHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(pID, pSeqNo);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                        //if exist
                        fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                            if (response[0].oReturn == "1") {
                            } else {
                                window.location.replace("MNU040100");
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
                        'FormCode': 'SCM090100',
                        'Type': 'Delete Record - DTL - Particular',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        fn0102Redraw("", response[0].oID, response[0].oSeqNo);
                    },
                });
            };
        };
        function fn010201Edit(pID, pSeqNo) {
            //if exist
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
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
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record - DTL - Particular : Edit',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value = pSeqNo;
                        document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010301Item").value = response[0].ItemName;
                        document.getElementById("tbx010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = response[0].UMCode;
                        document.getElementById("ContentPlaceHolder1_hf010301Cost").value = response[0].Cost;
                        document.getElementById("ContentPlaceHolder1_hf010301Total").value = response[0].Total;
                        document.getElementById("tbx010301UOM").value = response[0].UMName;
                        document.getElementById("tbx010301Remarks").value = response[0].Remarks;
                        document.getElementById("tbx010301PRNo").value = response[0].PRNo;
                        document.getElementById("tbx010301PRSeqNo").value = response[0].PRSeqNo;
                        document.getElementById("tbx010301PRItem").value = response[0].PRItem;
                        document.getElementById("tbx010301PRQty").value = formatNumber(response[0].PRQty);
                        document.getElementById("tbx010301PRUOM").value = response[0].PRUnit;
                        //modal
                        $('#mdl0103Edit').modal('show');
                    },
                });
            };
        };
        function fn010301Edit_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
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
                    if (document.getElementById("tbx010301Item").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301Qty").value == "") {
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
                                //if exisit
                                fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                    if (response[0].oReturn == "1") {
                                        fnValidateRecord('Trxn_WTHdr', ID, '', 'Save', function (response) {
                                            if (response[0].oReturn == "") {
                                                Edit_Ok(ID);
                                            } else {
                                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                            };
                                        });
                                    } else {
                                        window.location.replace("MNU040100");
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
                                'FormCode': 'SCM090100',
                                'Type': 'Warehouse Transfer - Edit Record : Particular',
                                'pID': ID,
                                'pSeqNo': document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value,
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                'pQty': document.getElementById("tbx010301Qty").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                'pCost': document.getElementById("ContentPlaceHolder1_hf010301Cost").value,
                                'pTotal': document.getElementById("ContentPlaceHolder1_hf010301Total").value,
                                'pRemarks': document.getElementById("tbx010301Remarks").value,
                            },
                            success: function (response) {
                                //edit
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx010301Item").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                document.getElementById("tbx010301Qty").value = "0.00";
                                document.getElementById("ContentPlaceHolder1_hf010301Cost").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010301Total").value = "";
                                document.getElementById("tbx010301UOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = "";
                                document.getElementById("tbx010301Remarks").value = "";
                                document.getElementById("tbx010301PRNo").value = "";
                                document.getElementById("tbx010301PRSeqNo").value = "";
                                document.getElementById("tbx010301PRItem").value = "";
                                document.getElementById("tbx010301PRQty").value = "0.00";
                                document.getElementById("tbx010301PRUOM").value = "";
                                fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                            }
                        });
                        //modal
                        $('#mdl0103Edit').modal('hide');
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
        function fn010301Item() {
            //item
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM090100',
                    'Type': 'Warehouse Transfer - Edit Record : Item',
                    'pWTDate': document.getElementById("lbl0101WTDate").innerText,
                    'pFromWhse': document.getElementById("ContentPlaceHolder1_hf0101FromWhse").value
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010401Loader").style.display = "";
                    //display loader

                    $('#table010401Item').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010401Item = $("#table010401Item").DataTable({
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
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMName' },
                            { data: 'Cost' },
                            { data: 'Total' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: [4, 6, 7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
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
                    $('#tbx010401Find').on('keyup', function () {
                        table010401Item.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010401Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0104Item').modal('show');
                },
            });
        };
        function fn010302Item(pItemCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM090100',
                        'Type': 'Get Record : Item',
                        'pItemCode': pItemCode,
                        'pWTDate': document.getElementById("lbl0101WTDate").innerText,
                        'pFromWhse': document.getElementById("ContentPlaceHolder1_hf0101FromWhse").value
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010301Item").value = response[0].ItemName;
                        document.getElementById("tbx010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010301Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010301UOM").value = response[0].UMName;
                        let newCost = parseFloat(document.getElementById("tbx010301Qty").value.replace(/,/g, '')) * response[0].Cost;
                        document.getElementById("ContentPlaceHolder1_hf010301Total").value = formatNumber(newCost);
                        //modal
                        $('#mdl0104Item').modal('hide');
                    },
                });
            };
        };
        //particular

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'SCM090000',
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
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM090000', 'Delete', function (response) {
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
                    'pFormCode': 'SCM090000',
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
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('ogm_wtran_hdr', 'wt_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                            'pFormCode': 'SCM090000',
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
                    url: "HNDGEN.ashx?pFormCode=SCM090000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('SCM090000', 'Add', function (response) {
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
                    fnAccess('SCM090000', 'Add', function (response) {
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM090000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
