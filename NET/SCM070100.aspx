<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM070100.aspx.vb" Inherits="NET.SCM070100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Item Receiving</li>
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
						<img src="Assets/media/svg/apps/SCM070000.svg" alt="" />
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
											<span class="input-group-text min-w-150px">RR No.</span>
											<span id="lbl0101RRNo" class="form-control ">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date</span>
											<span id="lbl0101Date" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Warehouse</span>
											<span id="lbl0101Warehouse" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">CP Vendor</span>
											<span id="lbl0101CPVendor" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Checked By</span>
											<span id="lbl0101CheckedBy" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Deliver</span>
											<span id="lbl0101DateDelivered" class="form-control">-</span>
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-3 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Origin</span>
											<span id="lbl0101Origin" class="form-control">-</span>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Type</span>
											<span id="lbl0101Type" class="form-control">-</span>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12 m-0">
									    <div class="input-group input-group-sm mb-2">
										    <span class="input-group-text min-w-150px">Received By</span>
										    <span id="lbl0101ReceivedBy" class="form-control ">-</span>
									    </div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Verified By</span>
											<span id="lbl0101VerifiedBy" class="form-control ">-</span>
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
							<div id="div0101Update" class="card-body" style="display:none">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Trxn. No.</span>
											<input id="tbx0101TrxnNo" type="text" class="form-control " Placeholder="Trxn. No." maxlength="13" readonly />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">RR No.</span>
											<input id="tbx0101RRNo" type="text" class="form-control " Placeholder="RR No." maxlength="13" />
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px required">Date</span>
											<input id="tbx0101Date" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Warehouse</span>
											<select id="ddl0101Warehouse" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Warehouse</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">CP Vendor</span>
											<input id="tbx0101CPVendor" type="text" class="form-control " Placeholder="CP Vendor" maxlength="180" readonly />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Checked By</span>
											<select id="ddl0101CheckedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Checked By</option>
											</select>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3 m-0">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px required">Date Deliver</span>
											<input id="tbx0101DateDelivered" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date Deliver" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-3 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Origin</span>
											<select id="ddl0101Origin" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl0101Origin_onchange(this);">
												<option value="">Origin</option>
												<option value="PO">PO</option>
												<option value="CP">CP</option>
												<option value="WT">WT</option>
												<option value="Return">Return</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6 m-0">
										<div class="input-group input-group-sm mb-2">
											<span id="spn0101Type" class="input-group-text min-w-150px">Type</span>
											<select id="ddl0101Type" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Type</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12 m-0">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Received By</span>
											<input list="ddl0101ReceivedBy" type="text" id="tbx0101ReceivedBy" title="Address" class="form-control" Placeholder="Received By" />
											<datalist id="ddl0101ReceivedBy">

											</datalist>
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px required">Verified By</span>
											<select id="ddl0101VerifiedBy" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Verified By</option>
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
				                    <button id="btn0102Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="fn0102Add(); return false;"><i class="las la-plus fs-2"></i></button>
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
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-125px mw-125px fw-bold border-end">PR No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-150px w-30 fw-bold border-end">PO No. / WT No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-150px w-70 fw-bold border-end">SI / DR No.</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Type</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-150px w-70 fw-bold border-end">Qty.</th>
												<th class="min-w-150px w-50 fw-bold border-end">UOM</th>
												<th class="min-w-150px w-50 fw-bold border-end">Cost</th>
												<th class="min-w-150px w-70 fw-bold border-end">Total</th>
												<th class="min-w-250px w-100 fw-bold border-end">Remarks</th>
											</tr>
										</thead>
										<tbody>
						
										</tbody>
                                        <tfoot>
											<tr>
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
												<th class="text-end">Total</th>
												<th class="text-end"></th>
												<th></th>
											</tr>
                                        </tfoot>
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
				<!--end:  Content-->
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
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Return to</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">Supplier</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">RR</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT05();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Receive</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT06();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Receive</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(WT)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT07();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Receive</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Return)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT08();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Received</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT09();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">For Warehouse</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">Pick-Up</div>
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
        				
		<!--begin::Modal Date record-->
		<div id="mdl010102Date" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Date</h5>
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
							<span class="input-group-text min-w-150px required">Date From</span>
							<input id="tbx01010201DateFrom" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date From" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Date To</span>
							<input id="tbx01010201DateTo" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date From" />
						</div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn01010201Fill_Ok(this); return false;">
                             <span class="indicator-label">Fill</span>
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
		<!--begin::Modal Date record-->
        
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
						<h5 class="modal-title">Item Receiving - Cancel Record</h5>
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
        
		<!--begin::Modal Add record-->
		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Item Receiving - Add record</h5>
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
                            <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="selectAllcbx010201.checked = false;">
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
                                    <tr>
                                        <th colspan="7" class="border-bottom border-end fw-bold">Origin of Transaction</th>
                                        <th colspan="8" class="border-bottom fw-bold">Quantity</th>
                                    </tr>
					                <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-75px mw-75px fw-bold">
											<div class='form-check form-check-sm form-check-custom form-check-solid d-flex justify-content-center'>
												<input class='form-check-input widget-9-check' id="selectAllcbx010201" type='checkbox' onclick="allcbx010201(this);"/>
											</div>
                                        </th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">PO No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">SI / DR No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Type</th>
                                        <th class="min-w-250px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Qty</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Balance</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Receive</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Cost</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Total</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Remarks</th>
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
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010201Add_Ok(this); return false;">
                             <span class="indicator-label">Add</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="selectAllcbx010201.checked = false;">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Add record-->
        
		<!--begin::Modal Edit record-->
		<div id="mdl0103Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Item Receiving - Edit record</h5>
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
						<div id="div010301PRNo" class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">PR No.</span>
                            <input id="hf010301pID" runat="server" type="hidden" value="" />
							<input id="tbx010301PRNo" type="text" class="form-control" readonly Placeholder="PR No." maxlength="13" readonly />
						</div>
					    <div id="div010301PRSeqNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">No.</span>
                            <input id="hf010301pSeqNo" runat="server" type="hidden" value="" />
						    <input id="tbx010301PRSeqNo" type="text" class="form-control" Placeholder="No." readonly />
					    </div>
					    <div id="div010301POWTNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">PO No. / WT No.</span>
						    <input id="tbx010301POWTNo" type="text" class="form-control" Placeholder="PO No. / WT No." maxlength="20" readonly />
					    </div>
					    <div id="div010301POWTSeqNo" class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">No</span>
						    <input id="tbx010301POWTSeqNo" type="text" class="form-control" Placeholder="No." readonly />
					    </div>
						<div id="div010301Separator" class="separator separator-dashed mb-2"></div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">SI / DR No.</span>
						    <input id="tbx010301SIDRNo" type="text" class="form-control" Placeholder="SI / DR No." maxlength="20" />
					    </div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Type</span>
							<select id="ddl010301Type" data-kt-repeater="select2" data-dropdown-parent="#mdl0103Edit" class="form-select form-select-sm form-select-border">
								<option value="">Type</option>
								<option value="SI">SI</option>
								<option value="DI">DI</option>
							</select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Item</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx010301Item" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Add item" readonly="readonly" />
                                <input id="hf010301ItemCode" runat="server" type="hidden" value="" />
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
						    <input id="tbx010301Qty" onkeypress="return fnEnterKeyCost(event,this.id);" maxlength="21" onblur="fnFormatNumericUpdQty(this);" type="text" class="form-control" Placeholder="Qty" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
                            <input id="hf010301UOMCode" runat="server" type="hidden" value="" />
						    <input id="tbx010301UOM" type="text" class="form-control" Placeholder="UOM" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Cost</span>
						    <input id="tbx010301Cost" onkeypress="return fnEnterKeyCost(event,this.id);" maxlength="21" onblur="fnFormatNumericUpdCost(this)" type="text" class="form-control" Placeholder="Cost" />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">Total</span>
						    <input id="tbx010301Total" type="text" maxlength="21" class="form-control" Placeholder="Total" readonly />
					    </div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px required">Remarks</span>
						    <input id="tbx010301Remarks" type="text" class="form-control min-h-75px w-100" maxlength="500" Placeholder="Remarks" />
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
                        <h5 class="modal-title">Item Receiving - Search record</h5>
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
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Cost</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Canvass</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Date Encoded</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Vendor</th>
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
        
		<!--begin::Modal Search record-->
		<div id="mdl0106Return" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Item Receiving - Return to Supplier</h5>
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
                                    <input id="tbx010601Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
					    <div class="row g-2">
						    <div class="col-sm-12 col-md-12 col-lg-9">
							    <div class="input-group input-group-sm mb-2">
								    <span class="input-group-text min-w-150px required">Project</span>
								    <input id="tbx010601Project" type="text" class="form-control " Placeholder="Project" />
							    </div>
							    <div class="input-group input-group-sm mb-2">
								    <span class="input-group-text min-w-150px">Vendor</span>
								    <input id="tbx010601Vendor" type="text" class="form-control " Placeholder="Vendor" readonly />
							    </div>
						    </div>
						    <div class="col-sm-12 col-md-12 col-lg-3">
							    <div class="input-group input-group-sm mb-2">
								    <span class="input-group-text min-w-150px">RS No.</span>
                                    <input id="hf010601RSCode" runat="server" type="hidden" value="" />
								    <input id="tbx010601RSNo" type="text" class="form-control " Placeholder="RS No." readonly />
							    </div>
							    <div class="input-group input-group-sm">
								    <span class="input-group-text min-w-150px required">RS Date</span>
								    <input id="tbx010601RSDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
							    </div>
						    </div>
					    </div>
                        <!--begin::Files-->
                        <div class="table-loading">
                            <div id="div010601Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010601Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">PO No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">RR No.</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">SI / DR No.</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Type</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Rcvd.</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">Return</th>
                                        <th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Remarks</th>
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
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010601Add_Ok(this); return false;">
                             <span class="indicator-label">Add</span>
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
    <!--end::Content-->
	
	<!--param-->
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<input id="hdnWarehouse" type="hidden" value="" />
	<input id="hdnType" type="hidden" value="" />
	<!--param-->

    <!-- script related to this page -->
    <script type="text/javascript">

        //variable
        var FileCount = 0;
        //variable

        //format
        function fnFormatNumericCost(input, cost, qtyBal) {
            // Get the value from the Cost input and remove commas
            let value = input.value.replace(/,/g, '');

            // Ensure the value is a valid number
            let numericValue = parseFloat(value);

            // If the value is NaN or empty, revert to the initial cost
            if (isNaN(numericValue) || value === '') {
                input.value = formatNumber(cost);  // Revert to original cost
                numericValue = cost;  // Set numeric value to original cost
            }

            // Format the number with commas and 2 decimals
            input.value = formatNumber(numericValue);

            // Calculate the new Total
            let newTotal = numericValue * qtyBal;

            // Update the Total in the row
            if (document.querySelector('[prm010201Total="' + input.getAttribute('prm010201Cost') + '"]')) {
                document.querySelector('[prm010201Total="' + input.getAttribute('prm010201Cost') + '"]').value = formatNumber(newTotal);
            } else if (document.querySelector('[prm010202Total="' + input.getAttribute('prm010202Cost') + '"]')) {
                document.querySelector('[prm010202Total="' + input.getAttribute('prm010202Cost') + '"]').value = formatNumber(newTotal);
            };
        };
        function fnFormatNumericTotal(input, qtyBal) {
            // Get the value from the Total input and remove commas
            let value = input.value.replace(/,/g, '');

            // Ensure the value is a valid number
            let numericValue = parseFloat(value);

            // If the value is NaN or empty, revert to 0 (or some default behavior)
            if (isNaN(numericValue) || value === '') {
                input.value = '0.00';  // Revert to zero if invalid
                numericValue = 0;      // Set numeric value to zero
            }

            // Format the number with commas and 2 decimals
            input.value = formatNumber(numericValue);

            // Calculate the new Cost based on Total / QtyBal
            let newCost = numericValue / qtyBal;

            // Update the Cost in the row
            if (document.querySelector('[prm010201Cost="' + input.getAttribute('prm010201Total') + '"]')) {
                document.querySelector('[prm010201Cost="' + input.getAttribute('prm010201Total') + '"]').value = formatNumber(newCost);
            } else if (document.querySelector('[prm010202Cost="' + input.getAttribute('prm010202Total') + '"]')) {
                document.querySelector('[prm010202Cost="' + input.getAttribute('prm010202Total') + '"]').value = formatNumber(newCost);
            }
        };
        function fnFormatNumericReturn(input, maxQty) {
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
        function formatNumber(value) {
            // Format the number with commas and 2 decimals
            return new Intl.NumberFormat('en-US', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }).format(value);
        };
        function fnEnterKeyCost(event, inputId) {
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
            }

            // Prevent any other keys (including letters and special characters)
            event.preventDefault();
            return false;
        }
        function fnFormatNumericUpdQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0;
            var Cost = parseFloat(document.getElementById("tbx010301Cost").value.replace(/,/g, '')) || 0;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx010301Total").value = formatNumber(Total);
        };
        function fnFormatNumericUpdCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0;
            var Qty = parseFloat(document.getElementById("tbx010301Qty").value.replace(/,/g, '')) || 0;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx010301Total").value = formatNumber(Total);
        };
        function fnFormatNumericAddQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0;
            var Cost = parseFloat(document.getElementById("tbx010501Cost").value.replace(/,/g, '')) || 0;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx010501Total").value = formatNumber(Total);
        };
        function fnFormatNumericAddCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0;
            var Qty = parseFloat(document.getElementById("tbx010501Qty").value.replace(/,/g, '')) || 0;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx010501Total").value = formatNumber(Total);
        };
        function fnFormatNumericAddTotal(input) {
            var Total = parseFloat(input.value.replace(/,/g, '')) || 0;
            var Qty = parseFloat(document.getElementById("tbx010501Qty").value.replace(/,/g, '')) || 0;
            var Cost = Total / Qty;
            input.value = formatNumber(Total);
            document.getElementById("tbx010501Cost").value = formatNumber(Cost);
        };
        //format

		//general
		function fn01Load() {
            fnAccess('SCM070000', 'View', function (response) {
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
                document.getElementById("btn0102Add").classList.remove("btn-add");
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
        function ddl0101Origin_onchange(ddl0101Origin) {
            document.getElementById("tbx0101CPVendor").readOnly = true;
            document.getElementById("tbx0101CPVendor").value = "";
            document.getElementById("spn0101Type").classList.remove("required");
            $('#ddl0101Type').val('').trigger('change');
            document.getElementById("ddl0101Type").disabled = true;
            if (ddl0101Origin.options[ddl0101Origin.selectedIndex].value == "PO") {
                document.getElementById("tbx0101CPVendor").readOnly = true;
                document.getElementById("tbx0101CPVendor").value = "N/A";
                document.getElementById("spn0101Type").classList.add("required");
                ddl0101Type(ddl0101Origin.options[ddl0101Origin.selectedIndex].value, '');
                $('#ddl0101Type').val('').trigger('change');
                document.getElementById("ddl0101Type").disabled = false;
            } else if (ddl0101Origin.options[ddl0101Origin.selectedIndex].value == "CP") {
                document.getElementById("tbx0101CPVendor").readOnly = false;
                document.getElementById("tbx0101CPVendor").value = "";
                document.getElementById("spn0101Type").classList.add("required");
                ddl0101Type(ddl0101Origin.options[ddl0101Origin.selectedIndex].value, '');
                $('#ddl0101Type').val('').trigger('change');
                document.getElementById("ddl0101Type").disabled = false;
            } else if (ddl0101Origin.options[ddl0101Origin.selectedIndex].value == "WT") {
                document.getElementById("tbx0101CPVendor").readOnly = true;
                document.getElementById("tbx0101CPVendor").value = "N/A";
                document.getElementById("spn0101Type").classList.add("required");
                ddl0101Type(ddl0101Origin.options[ddl0101Origin.selectedIndex].value, '');
                $('#ddl0101Type').val('').trigger('change');
                document.getElementById("ddl0101Type").disabled = false;
            } else if (ddl0101Origin.options[ddl0101Origin.selectedIndex].value == "Return") {
                document.getElementById("tbx0101CPVendor").readOnly = true;
                document.getElementById("tbx0101CPVendor").value = "N/A";
                document.getElementById("spn0101Type").classList.add("required");
                ddl0101Type(ddl0101Origin.options[ddl0101Origin.selectedIndex].value, '');
                $('#ddl0101Type').val('').trigger('change');
                document.getElementById("ddl0101Type").disabled = false;
            }
        };
        function ddl0101Type(Origin, ID) {
            if (Origin == "PO") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Vendor',
                        'pPlaceHolder': 'Type',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Type").html(s);
                        $('#ddl0101Type').val(ID).trigger('change');
                    },
                });
            } else if (Origin == "CP") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Trxn_PRHdr(CP)',
                        'pPlaceHolder': 'Type',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Type").html(s);
                        $('#ddl0101Type').val(ID).trigger('change');
                    },
                });
            } else if (Origin == "WT") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Warehouse',
                        'pPlaceHolder': 'Type',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Type").html(s);
                        $('#ddl0101Type').val(ID).trigger('change');
                    },
                });
            } else if (Origin == "Return") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Trxn_PRHdr(Return)',
                        'pPlaceHolder': 'Type',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Type").html(s);
                        $('#ddl0101Type').val(ID).trigger('change');
                    },
                });
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
                ddl0101Warehouse('');
                $('#ddl01Warehouse').val('').trigger('change');
                document.getElementById("tbx0101CPVendor").value = "";
                ddl0101CheckedBy('');
                $('#ddl0101CheckedBy').val('').trigger('change');
                $('#ddl0101Origin').val('').trigger('change');
                ddl0101Origin_onchange(document.getElementById("ddl0101Origin"));
                ddl0101Type('', '');
                ddl0101ReceivedBy('');
                document.getElementById("tbx0101ReceivedBy").value = "";
                ddl0101VerifiedBy('');
                $('#ddl0101VerifiedBy').val('').trigger('change');
                document.getElementById("tbx0101TrxnNo").value = "";
                document.getElementById("tbx0101RRNo").value = "";
                document.getElementById("tbx0101Date").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                document.getElementById("tbx0101DateDelivered").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
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
                        'FormCode': 'SCM070100',
                        'Type': 'Item Receiving - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].WhseName;
                        document.getElementById("spn0101ID").innerText = response[0].IRCode;
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
                        document.getElementById("lbl0101Warehouse").innerText = response[0].WhseName;
                        document.getElementById("lbl0101CPVendor").innerText = response[0].CPVendor;
                        document.getElementById("lbl0101CheckedBy").innerText = response[0].CheckedName;
                        document.getElementById("lbl0101Origin").innerText = response[0].Origin;
                        document.getElementById("lbl0101ReceivedBy").innerText = response[0].ReceivedBy;
                        document.getElementById("lbl0101VerifiedBy").innerText = response[0].VerifiedName;
                        document.getElementById("lbl0101Type").innerText = response[0].VenName;
                        document.getElementById("lbl0101TrxnNo").innerText = response[0].IRCode;
                        document.getElementById("lbl0101RRNo").innerText = response[0].RRNo;
                        document.getElementById("lbl0101Date").innerText = response[0].RRDate;
                        document.getElementById("lbl0101DateDelivered").innerText = response[0].ORDate;
                        document.getElementById("hdnWarehouse").value = response[0].WhseCode;
                        document.getElementById("hdnType").value = response[0].VenCode;
                        document.getElementById("lbl0101UpdatedByName").innerText = (response[0].UpdatedByName == "" ||  response[0].UpdatedByName == null) ?  "-" : response[0].UpdatedByName;
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
                        'FormCode': 'SCM070100',
                        'Type': 'Item Receiving - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].WhseName;
                        document.getElementById("spn0101ID").innerText = response[0].IRCode;
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
                        document.getElementById("tbx0101TrxnNo").value = response[0].IRCode;
                        ddl0101Warehouse(response[0].WhseCode);
                        document.getElementById("tbx0101CPVendor").value = response[0].CPVendor;
                        ddl0101CheckedBy(response[0].CheckedCode);
                        $('#ddl0101Origin').val(response[0].Origin).trigger('change');
                        ddl0101Type(response[0].Origin, response[0].VenCode);
                        document.getElementById("tbx0101ReceivedBy").value = response[0].ReceivedBy;
                        ddl0101VerifiedBy(response[0].VerifiedCode);
                        document.getElementById("tbx0101RRNo").value = response[0].RRNo;
                        document.getElementById("tbx0101Date").value = response[0].RRDate;
                        document.getElementById("tbx0101DateDelivered").value = response[0].ORDate;
                        document.getElementById("hdnWarehouse").value = response[0].WhseCode;
                        document.getElementById("hdnType").value = response[0].VenCode;
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
            }
            function ddl0101Warehouse(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
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
            function ddl0101CheckedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee',
                        'pPlaceHolder': 'Checked By',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101CheckedBy").html(s);
                        $('#ddl0101CheckedBy').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101ReceivedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee',
                        'pPlaceHolder': '',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].Name + '"></option>';
                        }
                        // Populate datalist, not the input
                        $("#ddl0101ReceivedBy").html(s);

                        // Optional: clear the input value
                        $("#tbx0101ReceivedBy").val(ID);
                    },
                });
            };
            function ddl0101VerifiedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee',
                        'pPlaceHolder': 'Verified By',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101VerifiedBy").html(s);
                        $('#ddl0101VerifiedBy').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('SCM070000', 'Add', function (response) {
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
                fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM070000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_IRHdr', ID, '', 'Delete', function (response) {
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
                        fnValidateRecord('Trxn_IRHdr', ID, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Detele_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('SCM070000', 'Trxn_IRHdr', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM070000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM070000");
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
                fnAccess('SCM070000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
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
                    //access
                    fnAccess('SCM070000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
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
                    //access
                    fnAccess('SCM070000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
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
                if (document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101CheckedBy").options[document.getElementById("ddl0101CheckedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value == "PO") && (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "")) {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value == "CP") && (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "")) {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value == "WT") && (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "")) {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if ((document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value == "Return") && (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "")) {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101ReceivedBy").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101VerifiedBy").options[document.getElementById("ddl0101VerifiedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Date").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101DateDelivered").value == "") {
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
                            fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
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
                        'FormCode': 'SCM070100',
                        'Type': 'Item Receiving - Add Record',
                        'pRRNo': document.getElementById("tbx0101RRNo").value,
                        'pDate': document.getElementById("tbx0101Date").value,
                        'pDateDelivered': document.getElementById("tbx0101DateDelivered").value,
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pOrigin': document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value,
                        'pType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                        'pCPVendor': document.getElementById("tbx0101CPVendor").value,
                        'pReceivedBy': document.getElementById("tbx0101ReceivedBy").value,
                        'pCheckedBy': document.getElementById("ddl0101CheckedBy").options[document.getElementById("ddl0101CheckedBy").selectedIndex].value,
                        'pVerifiedBy': document.getElementById("ddl0101VerifiedBy").options[document.getElementById("ddl0101VerifiedBy").selectedIndex].value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Add", response[0].oID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oID;
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
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Item Receiving - Edit Record',
                        'pID': ID,
                        'pRRNo': document.getElementById("tbx0101RRNo").value,
                        'pDate': document.getElementById("tbx0101Date").value,
                        'pDateDelivered': document.getElementById("tbx0101DateDelivered").value,
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pOrigin': document.getElementById("ddl0101Origin").options[document.getElementById("ddl0101Origin").selectedIndex].value,
                        'pType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                        'pCPVendor': document.getElementById("tbx0101CPVendor").value,
                        'pReceivedBy': document.getElementById("tbx0101ReceivedBy").value,
                        'pCheckedBy': document.getElementById("ddl0101CheckedBy").options[document.getElementById("ddl0101CheckedBy").selectedIndex].value,
                        'pVerifiedBy': document.getElementById("ddl0101VerifiedBy").options[document.getElementById("ddl0101VerifiedBy").selectedIndex].value
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
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM070000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Lock', function (response) {
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
                    didOpen: () => {
                        const input = document.getElementById("tbx0101LockPassword");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                                fnValidateRecord('Trxn_IRHdr', ID, '', 'Lock', function (response) {
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
                fnLock('Lock', 'Trxn_IRHdr', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
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
                fnAccess('SCM070000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Unlock', function (response) {
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
                    didOpen: () => {
                        const input = document.getElementById("tbx0101UnlockPassword");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                                fnValidateRecord('Trxn_IRHdr', ID, '', 'Unlock', function (response) {
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
                fnLock('Unlock', 'Trxn_IRHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Post() {
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
                fnAccess('SCM070000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Post', function (response) {
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
                    didOpen: () => {
                        const input = document.getElementById("tbx0101PostPassword");
                        input.focus();
                        input.addEventListener("keydown", function (e) {
                            if (e.key === "Enter") {
                                Swal.clickConfirm();
                            };
                        });
                    },
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
                                fnValidateRecord('Trxn_IRHdr', ID, '', 'Post', function (response) {
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
                        'pRecType': "IR",
                        'pTblCode': ID
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
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM070000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Reverse', function (response) {
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
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                        didOpen: () => {
                            const input = document.getElementById("tbx0101CancelPassword");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                };
                            });
                        },
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
                                    fnValidateRecord('Trxn_IRHdr', document.getElementById("ContentPlaceHolder1_hdnID").value, '', 'Reverse', function (response) {
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
                            'FormCode': 'SCM070100',
                            'Type': 'Item Receiving - Cancel Record',
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
                    'FormCode': 'SCM070100',
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
            //access
            fnAccess('SCM070000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        Return_Await(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //return
            function Return_Await(ID) {
                if (document.getElementById("lbl0101Origin").innerText == "PO") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Return to Supplier',
                            'pID': ID
                        },
                        success: function (response) {
                            //display loader
                            document.getElementById("div010601Loader").style.display = "";
                            //display loader

                            $('#table010601Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table010601Record = $("#table010601Record").DataTable({
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
                                    { data: 'PRSeqNo' },
                                    { data: 'PONo' },
                                    { data: 'POSeqNo' },
                                    { data: 'RRNo' },
                                    { data: 'RRSeqNo' },
                                    { data: 'SIDRNo' },
                                    { data: 'Type' },
                                    { data: 'ItemName' },
                                    { data: 'Qty' },
                                    {
                                        data: 'Return',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.Qty).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                // Subtract small value from max (e.g. 0.01)
                                                let maxValue = (row.Qty - 0.01).toFixed(2);

                                                let textbox = `
                                                    <input prm010601Return="${rowId}" type="text" onkeypress="return fnEnterKeyCost(event,this.id)" onblur="fnFormatNumericReturn(this, ${row.Qty});" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="${formattedValue}" Placeholder="Return" maxLength="21" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'UMInit' },
                                    {
                                        data: 'Remarks',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let textbox = `
                                                    <input prm010601Remarks="${rowId}" type="text" class="w-100 outline-none text-right border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Remarks" maxLength="180" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: 0, orderable: false
                                    },
                                    {
                                        targets: 10, render: $.fn.dataTable.render.number(',', '.', 2), className: 'dt-body-right'
                                    },
                                    {
                                        targets: [9, 13], className: 'tbody-nowrap-auto'
                                    }
                                ],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx010601Find').on('keyup', function () {
                                table010601Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div010601Loader").style.display = "none";
                            //hide loader

                            //condition
                            if (response.length > 10) {
                                fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                            };
                            //condition

                            //New Code
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'New Code',
                                    'pTblName': 'Trxn_RTSHDr(RSNo)',
                                    'pPreffix': 'RS#'
                                },
                                success: function (response) {
                                    document.getElementById("tbx010601RSNo").value = response[0].oID;
                                },
                            });
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'New Code',
                                    'pTblName': 'Trxn_RTSHDr(RSCode)',
                                    'pPreffix': 'MN'
                                },
                                success: function (response) {
                                    document.getElementById("ContentPlaceHolder1_hf010601RSCode").value = response[0].oID;
                                },
                            });
                            //New Code

                            //date
                            const DateToday = new Intl.DateTimeFormat('en-US', {
                                month: '2-digit',
                                day: '2-digit',
                                year: 'numeric'
                            }).format(new Date());
                            //date
                            document.getElementById("tbx010601Vendor").value = document.getElementById("lbl0101Type").innerText;
                            document.getElementById("tbx010601RSDate").value = DateToday;

                            //modal
                            $('#mdl010101Tools').modal('hide');
                            $('#mdl0106Return').modal('show');
                        },
                    });
                };
            };
        };
        function fn010101_SCM03RPT01(pID) {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview Report',
                            'pID': pID,
                            'pCode': '',
                            'pType': 'PR'
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
        function fn010101_SCM03RPT02(pCode) {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview Report',
                            'pID': '',
                            'pCode': pCode,
                            'pType': 'PO'
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
        function fn010101_SCM03RPT03(pCode) {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview Report',
                            'pID': '',
                            'pCode': pCode,
                            'pType': 'WT'
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
        function fn010101_SCM03RPT04() {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview Report',
                            'pID': '',
                            'pCode': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pType': 'IR'
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
        function fn010101_SCM03RPT05() {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview RDLC',
                            'pType': 'PO Item Balance'
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
        function fn010101_SCM03RPT06() {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview RDLC',
                            'pType': 'WT Item Balance'
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
        function fn010101_SCM03RPT07() {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview RDLC',
                            'pType': 'IR Balance'
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
        function fn010101_SCM03RPT08() {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $('#mdl010102Date').modal('show');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT09() {
            //access
            fnAccess('SCM070000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview RDLC',
                            'pType': 'PO Item Balance FWP'
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
                    'FormCode': 'SCM070100',
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
        function fn01010201Fill_Ok() {
            if (document.getElementById("tbx01010201DateFrom").value == "") {
                //Alert
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else if (document.getElementById("tbx01010201DateTo").value == "") {
                //Alert
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else {
                Fill_Ok(document.getElementById("tbx01010201DateFrom").value, document.getElementById("tbx01010201DateTo").value);
            };
            // Fill
            function Fill_Ok(pDateFrom, pDateTo) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Preview RDLC w/ Parm',
                        'pType': 'PO Received',
                        'pDateFrom': pDateFrom,
                        'pDateTo': pDateTo
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                            //reset
                            $('#mdl010102Date').modal('hide');
                            document.getElementById("tbx01010201DateFrom").value = "";
                            document.getElementById("tbx01010201DateTo").value = "";
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    }
                });
            };
        };
        //tools

        //particular
        function fn0102LoadParticular(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM070100',
                    'Type': 'Get Record - DTL - Particular',
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
                            { data: 'PRNo' },
                            { data: 'PRSeqNo' },
                            { data: 'PONo' },
                            { data: 'POSeqNo' },
                            { data: 'SIDRNo' },
                            { data: 'Type' },
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMInit' },
                            { data: 'Cost' },
                            { data: 'Total' },
                            { data: 'Remarks' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                                orderable: false
                            },
                            {
                                targets: [8, 10, 11],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [7, 12],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        footerCallback: function (row, data, start, end, display) {
                            var api = this.api();
                            // Calculate the total
                            var totalValue = api.column(11).data().reduce(function (a, b) {
                                return a + b; // Sum the values
                            }, 0);

                            // Update the footer with the total value
                            var totalVal = totalValue.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            $(api.column(11).footer()).html("₱ " + totalVal);
                        },
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
        function fn0102Redraw(Action, pID, pSeqNo) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record - DTL - Particular - Redraw',
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
                                    PRNo: item.PRNo,
                                    PRSeqNo: item.PRSeqNo,
                                    PONo: item.PONo,
                                    POSeqNo: item.POSeqNo,
                                    SIDRNo: item.SIDRNo,
                                    Type: item.Type,
                                    ItemName: item.ItemName,
                                    Qty: item.Qty,
                                    UMInit: item.UMInit,
                                    Cost: item.Cost,
                                    Total: item.Total,
                                    Remarks: item.Remarks
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
                            gv01.cell({ row: index01, column: 1 }).data(response[0].PRNo).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].PRSeqNo).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].PONo).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].POSeqNo).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].SIDRNo).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].Type).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].ItemName).draw(false);
                            gv01.cell({ row: index01, column: 8 }).data(response[0].Qty).draw(false);
                            gv01.cell({ row: index01, column: 9 }).data(response[0].UMInit).draw(false);
                            gv01.cell({ row: index01, column: 10 }).data(response[0].Cost).draw(false);
                            gv01.cell({ row: index01, column: 11 }).data(response[0].Total).draw(false);
                            gv01.cell({ row: index01, column: 12 }).data(response[0].Remarks).draw(false);
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
        async function fn010201Redraw(Action, PONo, SeqNo) {
            return new Promise(resolve => {
                //update list
                if (Action == "Add" || Action == "Edit") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Redraw - DTL - Add',
                            'pWarehouse': document.getElementById("hdnWarehouse").value,
                            'pType': document.getElementById("hdnType").value,
                            'pPONo': PONo,
                            'pSeqNo': SeqNo
                        },
                        success: function (response) {
                            if (Action == "Add") {
                                //add row
                                var gv01 = $('#table010201Add').DataTable();
                                gv01.rows().deselect();
                                //last row
                                let lastRowId = "";
                                response.forEach(item => {
                                    var row01 = gv01.row.add(
                                        {
                                            Action: item.Action,
                                            PRNo: item.PRNo,
                                            PRSeqNo: item.PRSeqNo,
                                            PONo: item.PONo,
                                            POSeqNo: item.POSeqNo,
                                            SIDRNo: item.SIDRNo,
                                            Type: item.Type,
                                            ItemName: item.ItemName,
                                            Qty: item.Qty,
                                            QtyBal: item.QtyBal,
                                            QtyRcvd: item.QtyRcvd,
                                            UMName: item.UMName,
                                            Cost: item.Cost,
                                            Total: item.Total,
                                            Remarks: item.Remarks,
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
                                var gv01 = $('#table010201Add').DataTable();
                                gv01.rows().deselect();

                                response.forEach(item => {
                                    let row01 = gv01.row('#' + item.rowId);
                                    if (row01.length === 0) return; // Skip if row not found

                                    let index01 = row01.index();

                                    gv01.cell({ row: index01, column: 0 }).data(item.Action).draw(false);
                                    gv01.cell({ row: index01, column: 1 }).data(item.PRNo).draw(false);
                                    gv01.cell({ row: index01, column: 2 }).data(item.PRSeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 3 }).data(item.PONo).draw(false);
                                    gv01.cell({ row: index01, column: 4 }).data(item.POSeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 5 }).data(item.SIDRNo).draw(false);
                                    gv01.cell({ row: index01, column: 6 }).data(item.Type).draw(false);
                                    gv01.cell({ row: index01, column: 7 }).data(item.ItemName).draw(false);
                                    gv01.cell({ row: index01, column: 8 }).data(item.Qty).draw(false);
                                    gv01.cell({ row: index01, column: 9 }).data(item.QtyBal).draw(false);
                                    gv01.cell({ row: index01, column: 10 }).data(item.QtyRcvd).draw(false);
                                    gv01.cell({ row: index01, column: 11 }).data(item.UMName).draw(false);
                                    gv01.cell({ row: index01, column: 12 }).data(item.Cost).draw(false);
                                    gv01.cell({ row: index01, column: 13 }).data(item.Total).draw(false);
                                    gv01.cell({ row: index01, column: 14 }).data(item.Remarks).draw(false);

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
                    var gv01 = $('#table010201Add').DataTable();
                    let Code = PONo + '' + SeqNo;
                    gv01.row('#rowID010201' + Code).remove().draw(false);
                };
                resolve();
            });
        };
        function fn0102Add() {
            //if exist
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM070000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                document.getElementById("div010301PRNo").classList.remove("d-none");
                document.getElementById("div010301PRSeqNo").classList.remove("d-none");
                document.getElementById("div010301POWTNo").classList.remove("d-none");
                document.getElementById("div010301POWTSeqNo").classList.remove("d-none");
                document.getElementById("div010301Separator").classList.remove("d-none");
                if (document.getElementById("lbl0101Origin").innerText == "PO") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Get Record - DTL - Particular - PO',
                            'pWarehouse': document.getElementById("hdnWarehouse").value,
                            'pType': document.getElementById("hdnType").value
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
                                    { data: 'Action' },
                                    { data: 'PRNo' },
                                    { data: 'PRSeqNo' },
                                    {
                                        data: 'PONo'
                                    },
                                    {
                                        data: 'POSeqNo'
                                    },
                                    {
                                        data: 'SIDRNo',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let textbox = `
                                                    <input prm010201SIDRNo="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="SI / DR No." maxlength="20" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'Type',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let dropdown = `
                                                            <select prm010201ddlType="${rowId}" data-dropdown-parent="#mdl0102Add" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
                                                                <option value="">Type</option>
                                                                <option value="SI">SI</option>
                                                                <option value="DI">DI</option>
                                                            </select>`;
                                                return dropdown;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'ItemName',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let textbox = `
                                                      <span title='${row.ItemName}'>${row.ItemName}</span>
                                                  `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'Qty' },
                                    { data: 'QtyBal' },
                                    {
                                        data: 'QtyRcvd',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.QtyBal).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm010201Rcvd="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="${formattedValue}" data-max-value="${rowVal}" Placeholder="Receive" readonly />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'UMName' },
                                    {
                                        data: 'Cost',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.Cost).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm010201Cost="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" onkeypress="return fnEnterKeyCost(event,this.id)" maxlength="21" onblur="fnFormatNumericCost(this, ${row.Cost}, ${row.QtyBal});" value="${formattedValue}" data-max-value="${rowVal}" Placeholder="Cost" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'Total',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.Total).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm010201Total="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" onkeypress="return fnEnterKeyCost(event,this.id)" maxlength="21" onblur="fnFormatNumericTotal(this, ${row.QtyBal})" value="${formattedValue}" data-max-value="${rowVal}" Placeholder="Total" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'Remarks',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let textbox = `
                                                    <input prm010201Remarks="${rowId}" type="text" class="w-100 outline-none text-right border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Remarks" maxlength="180" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                ],
                                drawCallback: function () {
                                    $('[data-kt-repeater="select2"]').select2({
                                        width: '100%'
                                    });
                                },
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14],
                                        orderable: false,
                                        className: 'tbody-nowrap-auto'
                                    },
                                    {
                                        targets: [7, 8, 9, 11, 12],
                                        render: $.fn.dataTable.render.number(',', '.', 2)
                                    }
                                ],
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
                    //modal
                    $('#mdl0102Add').modal('show');
                } else if (document.getElementById("lbl0101Origin").innerText == "CP") {
                    document.getElementById("ContentPlaceHolder1_hf010301pID").value = "";
                    document.getElementById("tbx010301PRNo").value = "";
                    document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value = "";
                    document.getElementById("tbx010301PRSeqNo").value = "";
                    document.getElementById("tbx010301POWTNo").value = "";
                    document.getElementById("tbx010301SIDRNo").value = "";
                    $('#ddl010301Type').val('').trigger('change');
                    document.getElementById("tbx010301Item").value = "";
                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                    document.getElementById('tbx010301Qty').value = "0.00";
                    document.getElementById("tbx010301Cost").value = "0.00";
                    document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = "";
                    document.getElementById("tbx010301UOM").value = "";
                    document.getElementById("tbx010301Cost").value = "0.00";
                    document.getElementById("tbx010301Total").value = "0.00";
                    document.getElementById("tbx010301Remarks").value = "";
                    //modal
                    $('#mdl0103Edit').modal('show');
                } else if (document.getElementById("lbl0101Origin").innerText == "WT") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Get Record - DTL - Particular - WT',
                            'pWarehouse': document.getElementById("hdnWarehouse").value,
                            'pType': document.getElementById("hdnType").value
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
                                    { data: 'Action' },
                                    { data: 'PRNo' },
                                    { data: 'PRSeqNo' },
                                    {
                                        data: 'PONo'
                                    },
                                    {
                                        data: 'POSeqNo'
                                    },
                                    {
                                        data: 'SIDRNo',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let textbox = `
                                                    <input prm010202SIDRNo="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="SI / DR No." maxlength="20" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'Type',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let dropdown = `
                                                            <select prm010202ddlType="${rowId}" data-dropdown-parent="#mdl0102Add" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
                                                                <option value="">Type</option>
                                                                <option value="SI">SI</option>
                                                                <option value="DI">DI</option>
                                                            </select>`;
                                                return dropdown;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'ItemName' },
                                    { data: 'Qty' },
                                    { data: 'QtyBal' },
                                    {
                                        data: 'QtyRcvd',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.QtyBal).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm010202Rcvd="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="${formattedValue}" data-max-value="${rowVal}" Placeholder="Receive" readonly />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'UMName' },
                                    {
                                        data: 'Cost',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.Cost).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm010202Cost="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" onkeypress="return fnEnterKeyCost(event,this.id)" maxlength="21" onblur="fnFormatNumericCost(this, ${row.Cost}, ${row.QtyBal});" value="${formattedValue}" data-max-value="${rowVal}" Placeholder="Cost" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'Total',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.Total).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm010202Total="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" onkeypress="return fnEnterKeyCost(event,this.id)" maxlength="21" onblur="fnFormatNumericTotal(this, ${row.QtyBal})" value="${formattedValue}" data-max-value="${rowVal}" Placeholder="Total" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    {
                                        data: 'Remarks',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let textbox = `
                                                    <input prm010202Remarks="${rowId}" type="text" class="w-100 outline-none text-right border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Remarks" maxlength="180" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                ],
                                drawCallback: function () {
                                    $('[data-kt-repeater="select2"]').select2({
                                        width: '100%'
                                    });
                                },
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14],
                                        orderable: false,
                                        className: 'tbody-nowrap-auto'
                                    },
                                    {
                                        targets: [7, 8, 9, 11, 12],
                                        render: $.fn.dataTable.render.number(',', '.', 2)
                                    }
                                ],
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
                    //modal
                    $('#mdl0102Add').modal('show');
                } else if (document.getElementById("lbl0101Origin").innerText == "Return") {
                    document.getElementById("div010301PRNo").classList.add("d-none");
                    document.getElementById("div010301PRSeqNo").classList.add("d-none");
                    document.getElementById("div010301POWTNo").classList.add("d-none");
                    document.getElementById("div010301POWTSeqNo").classList.add("d-none");
                    document.getElementById("div010301Separator").classList.add("d-none");
                    document.getElementById("tbx010301SIDRNo").value = "";
                    $('#ddl010301Type').val('').trigger('change');
                    document.getElementById("tbx010301Item").value = "";
                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                    document.getElementById('tbx010301Qty').value = "0.00";
                    document.getElementById("tbx010301Cost").value = "0.00";
                    document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = "";
                    document.getElementById("tbx010301UOM").value = "";
                    document.getElementById("tbx010301Cost").value = "0.00";
                    document.getElementById("tbx010301Total").value = "0.00";
                    document.getElementById("tbx010301Remarks").value = "";

                    //modal
                    $('#mdl0103Edit').modal('show');
                } else {
                    document.getElementById("div010301PRNo").classList.remove("d-none");
                    document.getElementById("div010301PRSeqNo").classList.remove("d-none");
                    document.getElementById("div010301POWTNo").classList.remove("d-none");
                    document.getElementById("div010301POWTSeqNo").classList.remove("d-none");
                    document.getElementById("div010301Separator").classList.remove("d-none");
                };
            };
        };
        function allcbx010201(Obj) {
            var checkBoxes;
            if (document.getElementById("lbl0101Origin").innerText == "PO") {
                checkBoxes = document.querySelectorAll(".cbxPO010201");
            } else if (document.getElementById("lbl0101Origin").innerText == "WT") {
                checkBoxes = document.querySelectorAll(".cbxWT010202");
            };

            checkBoxes.forEach(checkBox => {
                checkBox.checked = Obj.checked;
            });
        };
        async function fn010201Add_Ok(Btn) {
            //access
            fnAccess('SCM070000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    Validate(document.getElementById("ContentPlaceHolder1_hdnID").value, Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });

            //validate
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        fn010201Add_Ok_Await(Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        //Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function fn010201Add_Ok_Await(ID, Btn) {
                if (document.getElementById("lbl0101Origin").innerText == "PO") {
                    // Get all
                    var checkBoxes = document.querySelectorAll('.cbxPO010201');

                    // Check if atleast one
                    var checkedValues = Array.from(checkBoxes)
                        .filter(checkBox => checkBox.checked)
                        .map(checkBox => ({
                            PONo: checkBox.value,
                            SeqNo: checkBox.getAttribute('data-kt-no'),
                            Code: checkBox.getAttribute('data-kt-code')
                        }));

                    if (checkedValues.length > 0) {
                        //Array
                        let ItemList = [];
                        //Loop
                        checkedValues.forEach(item => {
                            var tbx010201SIDRNo = document.querySelector('[prm010201SIDRNo="rowID010201' + item.Code + '"]');
                            var ddl010201Type = document.querySelector('[prm010201ddlType="rowID010201' + item.Code + '"]').options[document.querySelector('[prm010201ddlType="rowID010201' + item.Code + '"]').selectedIndex].value;
                            var tbx010201Rcvd = document.querySelector('[prm010201Rcvd="rowID010201' + item.Code + '"]');
                            var tbx010201Cost = document.querySelector('[prm010201Cost="rowID010201' + item.Code + '"]');
                            var tbx010201Total = document.querySelector('[prm010201Total="rowID010201' + item.Code + '"]');
                            var tbx010201Remarks = document.querySelector('[prm010201Remarks="rowID010201' + item.Code + '"]');

                            // Push as an object to the array
                            ItemList.push({
                                PONo: item.PONo,
                                SeqNo: item.SeqNo,
                                SIDRNo: tbx010201SIDRNo.value,
                                Type: ddl010201Type == "" ? "SI" : ddl010201Type,
                                Rcvd: parseFloat(tbx010201Rcvd.value.replace(/,/g, '')),
                                Cost: parseFloat(tbx010201Cost.value.replace(/,/g, '')),
                                Total: parseFloat(tbx010201Total.value.replace(/,/g, '')),
                                Remarks: tbx010201Remarks.value
                            });

                        });
                        //Format Item
                        let ItemSrs = ItemList.map(i =>
                            `${i.PONo}©${i.SeqNo}©${i.SIDRNo}©${i.Type}©${i.Rcvd}©${i.Cost}©${i.Total}©${i.Remarks}`
                        ).join('®');
                        let ItemPO = ItemList.map(i => ({
                            PONo: i.PONo,
                            SeqNo: i.SeqNo
                        }));

                        //Question
                        Add_Question(ItemSrs, ItemPO, Btn);
                    } else {
                        fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                        //Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                } else if (document.getElementById("lbl0101Origin").innerText == "WT") {
                    // Get all
                    var checkBoxes = document.querySelectorAll('.cbxWT010202');

                    // Check if atleast one
                    var checkedValues = Array.from(checkBoxes)
                        .filter(checkBox => checkBox.checked)
                        .map(checkBox => ({
                            PONo: checkBox.value,
                            SeqNo: checkBox.getAttribute('data-kt-no'),
                            Code: checkBox.getAttribute('data-kt-code')
                        }));

                    if (checkedValues.length > 0) {
                        //Array
                        let ItemList = [];
                        //Loop
                        checkedValues.forEach(item => {
                            var tbx010202SIDRNo = document.querySelector('[prm010202SIDRNo="rowID010201' + item.Code + '"]');
                            var ddl010202Type = document.querySelector('[prm010202ddlType="rowID010201' + item.Code + '"]').options[document.querySelector('[prm010202ddlType="rowID010201' + item.Code + '"]').selectedIndex].value;
                            var tbx010202Rcvd = document.querySelector('[prm010202Rcvd="rowID010201' + item.Code + '"]');
                            var tbx010202Cost = document.querySelector('[prm010202Cost="rowID010201' + item.Code + '"]');
                            var tbx010202Total = document.querySelector('[prm010202Total="rowID010201' + item.Code + '"]');
                            var tbx010202Remarks = document.querySelector('[prm010202Remarks="rowID010201' + item.Code + '"]');

                            // Push as an object to the array
                            ItemList.push({
                                PONo: item.PONo,
                                SeqNo: item.SeqNo,
                                SIDRNo: tbx010202SIDRNo.value,
                                Type: ddl010202Type == "" ? "SI" : ddl010202Type,
                                Rcvd: parseFloat(tbx010202Rcvd.value.replace(/,/g, '')),
                                Cost: parseFloat(tbx010202Cost.value.replace(/,/g, '')),
                                Total: parseFloat(tbx010202Total.value.replace(/,/g, '')),
                                Remarks: tbx010202Remarks.value
                            });

                        });
                        //Format Item
                        let ItemSrs = ItemList.map(i =>
                            `${i.PONo}©${i.SeqNo}©${i.SIDRNo}©${i.Type}©${i.Rcvd}©${i.Cost}©${i.Total}©${i.Remarks}`
                        ).join('®');
                        let ItemPO = ItemList.map(i => ({
                            PONo: i.PONo,
                            SeqNo: i.SeqNo
                        }));

                        //Question
                        Add_Question(ItemSrs, ItemPO, Btn);
                    } else {
                        fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                        //Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                };
                //Add Question
                function Add_Question(ItemSrs, ItemPO, Btn) {
                    Swal.fire({
                        text: 'Adding the selected items will overwrite the existing IR Item(s), add Item(s)?',
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
                            fnValidateRecord('Trxn_IRHdr', document.getElementById("ContentPlaceHolder1_hdnID").value, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Add_Ok(ItemSrs, ItemPO, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    //Disable the clicked button to avoid multiple clicks
                                    Btn.disabled = false;
                                    // Hide loading indication
                                    Btn.removeAttribute('data-kt-indicator');
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
                // Add ok
                function Add_Ok(ItemSrs, ItemPO, Btn) {
                    //add
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Add Record - DTL - Particular',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pItemSrs': ItemSrs,
                        },
                        success: async function (response) {
                            //disable check
                            selectAllcbx010201.checked = false;
                            //alert
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            //load
                            fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            $("#mdl0102Add").modal("hide");
                            //for (let item of ItemPO) {
                            //    await fn010201Redraw("", item.PONo, item.SeqNo);
                            //    await fn010201Redraw("Add", item.PONo, item.SeqNo);
                            //};
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
            fnIfExist('ogm_por_hdr', 'r_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM070000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
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
                        fnValidateRecord('Trxn_IRHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
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
                        'FormCode': 'SCM070100',
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
                fnAccess('SCM070000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
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
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record - DTL - Particular - Edit',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010301pID").value = response[0].IRCode;
                        document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value = response[0].SeqNo;
                        document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010301PRNo").value = response[0].PRNo;
                        document.getElementById("tbx010301PRSeqNo").value = response[0].PRSeqNo;
                        document.getElementById("tbx010301POWTNo").value = response[0].PONo;
                        document.getElementById("tbx010301POWTSeqNo").value = response[0].POSeqNo;
                        document.getElementById("tbx010301SIDRNo").value = response[0].SIDRNo;
                        $('#ddl010301Type').val(response[0].Type).trigger('change');
                        document.getElementById("tbx010301Item").value = response[0].ItemName;
                        document.getElementById("tbx010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010301UOM").value = response[0].UMInit;
                        document.getElementById("tbx010301Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("tbx010301Total").value = formatNumber(response[0].Total);
                        document.getElementById("tbx010301Remarks").value = response[0].Remarks;
                        //modal
                        $('#mdl0103Edit').modal('show');
                    },
                });
            };
        };
        function fn010301Item() {
            //item
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM070100',
                    'Type': 'Edit Record - DTL - Particular - Item',
                    'pTblFrom': 'IR',
                    'pCategory': ''
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
                            { data: 'ItemCode' },
                            { data: 'Lock' },
                            { data: 'ItemName' },
                            { data: 'UMName' },
                            { data: 'Cost' },
                            { data: 'Canvass' },
                            { data: 'UpdatedDate' },
                            { data: 'VenName' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: 5,
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: 6,
                                className: 'dt-body-right'
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
        function fn010301Edit_Ok(Btn) {
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
                fnAccess('SCM070000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hf010301pID').value, document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value, Btn);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID, SeqNo, Btn) {
                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit_DTL_Ok(ID, SeqNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            //edit
            async function Edit_DTL_Ok(ID, SeqNo) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Edit_DTL_Ok_Await(Btn, ID, SeqNo);
            };
            function Edit_DTL_Ok_Await(Btn, ID, SeqNo) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx010301SIDRNo").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301Item").value == "" && document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301UOM").value == "" && document.getElementById("ContentPlaceHolder1_tbx010301UOMCode").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301Qty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301Cost").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301Remarks").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Edit_DTL_Question(ID, SeqNo);
                    };
                    //question
                    function Edit_DTL_Question(ID, SeqNo) {
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
                                fnValidateRecord('Trxn_IRHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Ok(ID, SeqNo);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        // Disable the clicked button to avoid multiple clicks
                                        Btn.disabled = true;
                                        // Hide loading indication
                                        Btn.removeAttribute('data-kt-indicator');
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
                    function Edit_Ok(ID, SeqNo) {
                        if (document.getElementById("lbl0101Origin").innerText == "PO" && SeqNo != "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'Edit Record - DTL - Particular',
                                    'pID': ID,
                                    'pSeqNo': SeqNo,
                                    'pSIDRNo': document.getElementById("tbx010301SIDRNo").value,
                                    'pType': document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value,
                                    'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                    'pQty': document.getElementById("tbx010301Qty").value,
                                    'pUnit': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                    'pCost': document.getElementById("tbx010301Cost").value,
                                    'pTotal': document.getElementById("tbx010301Total").value,
                                    'pRemarks': document.getElementById("tbx010301Remarks").value
                                },
                                success: function (response) {
                                    //update
                                    fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                    document.getElementById("tbx010301SIDRNo").value = "";
                                    $('#ddl010301Type').val('').trigger('change');
                                    document.getElementById("tbx010301Qty").value = "0.00";
                                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                    document.getElementById("tbx010301Item").value = "";
                                    document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = "";
                                    document.getElementById("tbx010301UOM").value = "";
                                    document.getElementById("tbx010301Cost").value = "0.00";
                                    document.getElementById("tbx010301Total").value = "0.00";
                                    document.getElementById("tbx010301Remarks").value = "";
                                    fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                                },
                            });
                        } else if (document.getElementById("lbl0101Origin").innerText == "CP" && SeqNo == "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'Save Record - DTL - Particular',
                                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                                    'pSIDRNo': document.getElementById("tbx010301SIDRNo").value,
                                    'pType': document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value,
                                    'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                    'pQty': document.getElementById("tbx010301Qty").value,
                                    'pUnit': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                    'pCost': document.getElementById("tbx010301Cost").value,
                                    'pTotal': document.getElementById("tbx010301Total").value,
                                    'pRemarks': document.getElementById("tbx010301Remarks").value
                                },
                                success: function (response) {
                                    //add
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    document.getElementById("tbx010301SIDRNo").value = "";
                                    $('#ddl010301Type').val('').trigger('change');
                                    document.getElementById("tbx010301Qty").value = "0.00";
                                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                    document.getElementById("tbx010301UOM").value = "";
                                    document.getElementById("tbx010301Cost").value = "0.00";
                                    document.getElementById("tbx010301Total").value = "0.00";
                                    document.getElementById("tbx010301Remarks").value = "";
                                    fn0102Redraw("Add", response[0].oID, response[0].oSeqNo);
                                },
                            });
                        } else if (document.getElementById("lbl0101Origin").innerText == "CP" && SeqNo != "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'Edit Record - DTL - Particular',
                                    'pID': ID,
                                    'pSeqNo': SeqNo,
                                    'pSIDRNo': document.getElementById("tbx010301SIDRNo").value,
                                    'pType': document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value,
                                    'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                    'pQty': document.getElementById("tbx010301Qty").value,
                                    'pUnit': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                    'pCost': document.getElementById("tbx010301Cost").value,
                                    'pTotal': document.getElementById("tbx010301Total").value,
                                    'pRemarks': document.getElementById("tbx010301Remarks").value
                                },
                                success: function (response) {
                                    //add
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    document.getElementById("tbx010301SIDRNo").value = "";
                                    $('#ddl010301Type').val('').trigger('change');
                                    document.getElementById("tbx010301Qty").value = "0.00";
                                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                    document.getElementById("tbx010301UOM").value = "";
                                    document.getElementById("tbx010301Cost").value = "0.00";
                                    document.getElementById("tbx010301Total").value = "0.00";
                                    document.getElementById("tbx010301Remarks").value = "";
                                    fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                                },
                            });
                        } else if (document.getElementById("lbl0101Origin").innerText == "WT" && SeqNo != "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'Edit Record - DTL - Particular',
                                    'pID': ID,
                                    'pSeqNo': SeqNo,
                                    'pSIDRNo': document.getElementById("tbx010301SIDRNo").value,
                                    'pType': document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value,
                                    'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                    'pQty': document.getElementById("tbx010301Qty").value,
                                    'pUnit': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                    'pCost': document.getElementById("tbx010301Cost").value,
                                    'pTotal': document.getElementById("tbx010301Total").value,
                                    'pRemarks': document.getElementById("tbx010301Remarks").value
                                },
                                success: function (response) {
                                    //add
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    document.getElementById("tbx010301SIDRNo").value = "";
                                    $('#ddl010301Type').val('').trigger('change');
                                    document.getElementById("tbx010301Qty").value = "0.00";
                                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                    document.getElementById("tbx010301UOM").value = "";
                                    document.getElementById("tbx010301Cost").value = "0.00";
                                    document.getElementById("tbx010301Total").value = "0.00";
                                    document.getElementById("tbx010301Remarks").value = "";
                                    fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                                },
                            });
                        } else if (document.getElementById("lbl0101Origin").innerText == "Return" && SeqNo == "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'Save Record - DTL - Particular',
                                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                                    'pSIDRNo': document.getElementById("tbx010301SIDRNo").value,
                                    'pType': document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value,
                                    'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                    'pQty': document.getElementById("tbx010301Qty").value,
                                    'pUnit': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                    'pCost': document.getElementById("tbx010301Cost").value,
                                    'pTotal': document.getElementById("tbx010301Total").value,
                                    'pRemarks': document.getElementById("tbx010301Remarks").value
                                },
                                success: function (response) {
                                    //add
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    document.getElementById("tbx010301SIDRNo").value = "";
                                    $('#ddl010301Type').val('').trigger('change');
                                    document.getElementById("tbx010301Qty").value = "0.00";
                                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                    document.getElementById("tbx010301UOM").value = "";
                                    document.getElementById("tbx010301Cost").value = "0.00";
                                    document.getElementById("tbx010301Total").value = "0.00";
                                    document.getElementById("tbx010301Remarks").value = "";
                                    fn0102Redraw("Add", response[0].oID, response[0].oSeqNo);
                                },
                            });
                        } else if (document.getElementById("lbl0101Origin").innerText == "Return" && SeqNo != "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'Edit Record - DTL - Particular',
                                    'pID': ID,
                                    'pSeqNo': SeqNo,
                                    'pSIDRNo': document.getElementById("tbx010301SIDRNo").value,
                                    'pType': document.getElementById("ddl010301Type").options[document.getElementById("ddl010301Type").selectedIndex].value,
                                    'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                    'pQty': document.getElementById("tbx010301Qty").value,
                                    'pUnit': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                    'pCost': document.getElementById("tbx010301Cost").value,
                                    'pTotal': document.getElementById("tbx010301Total").value,
                                    'pRemarks': document.getElementById("tbx010301Remarks").value
                                },
                                success: function (response) {
                                    //add
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    document.getElementById("tbx010301SIDRNo").value = "";
                                    $('#ddl010301Type').val('').trigger('change');
                                    document.getElementById("tbx010301Qty").value = "0.00";
                                    document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                    document.getElementById("tbx010301UOM").value = "";
                                    document.getElementById("tbx010301Cost").value = "0.00";
                                    document.getElementById("tbx010301Total").value = "0.00";
                                    document.getElementById("tbx010301Remarks").value = "";
                                    fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                                },
                            });
                        };

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
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record - Item',
                        'pTblFrom': 'IR',
                        'pItemCode': pItemCode
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010301Item").value = response[0].ItemName;
                        document.getElementById("tbx010301Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010301UOM").value = response[0].UMName;
                        let newCost = parseFloat(document.getElementById("tbx010301Qty").value.replace(/,/g, '')) * response[0].Cost;
                        document.getElementById("tbx010301Total").value = formatNumber(newCost);
                        //callback
                        $('[data-kt-repeater="select2"]').select2({ width: '100%' });
                        //modal
                        $('#mdl0104Item').modal('hide');
                    },
                });
            };
        };
        //particular

        //report
        function fn010501View(pID, pCode, pType) {
            //access
            fnAccess('SCM070000', 'View', function (response) {
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

        //return
        async function fn010601Redraw(Action, pID, pSeqNo) {
            return new Promise(resolve => {
                //update return list
                if (Action == "Add" || Action == "Edit") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Redraw - DTL - Return',
                            'pID': pID,
                            'pSeqNo': pSeqNo
                        },
                        success: function (response) {
                            if (Action == "Add") {
                                //add row
                                var gv01 = $('#table010601Record').DataTable();
                                gv01.rows().deselect();
                                //last row
                                let lastRowId = "";
                                response.forEach(item => {
                                    var row01 = gv01.row.add(
                                        {
                                            Action: item.Action,
                                            PRNo: item.PRNo,
                                            PRSeqNo: item.PRSeqNo,
                                            PONo: item.PONo,
                                            POSeqNo: item.POSeqNo,
                                            RRNo: item.RRNo,
                                            RRSeqNo: item.RRSeqNo,
                                            SIDRNo: item.SIDRNo,
                                            Type: item.Type,
                                            ItemName: item.ItemName,
                                            Qty: item.Qty,
                                            QtyBal: item.Return,
                                            UMInit: item.UMInit,
                                            Remarks: item.Remarks,
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
                                var gv01 = $('#table010601Record').DataTable();
                                gv01.rows().deselect();

                                response.forEach(item => {
                                    let row01 = gv01.row('#' + item.rowId);
                                    if (row01.length === 0) return; // Skip if row not found

                                    let index01 = row01.index();

                                    gv01.cell({ row: index01, column: 0 }).data(item.Action).draw(false);
                                    gv01.cell({ row: index01, column: 1 }).data(item.PRNo).draw(false);
                                    gv01.cell({ row: index01, column: 2 }).data(item.PRSeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 3 }).data(item.PONo).draw(false);
                                    gv01.cell({ row: index01, column: 4 }).data(item.POSeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 5 }).data(item.RRNo).draw(false);
                                    gv01.cell({ row: index01, column: 6 }).data(item.RRSeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 7 }).data(item.SIDRNo).draw(false);
                                    gv01.cell({ row: index01, column: 8 }).data(item.Type).draw(false);
                                    gv01.cell({ row: index01, column: 9 }).data(item.ItemName).draw(false);
                                    gv01.cell({ row: index01, column: 10 }).data(item.Qty).draw(false);
                                    gv01.cell({ row: index01, column: 11 }).data(item.Return).draw(false);
                                    gv01.cell({ row: index01, column: 12 }).data(item.UMInit).draw(false);
                                    gv01.cell({ row: index01, column: 13 }).data(item.Remarks).draw(false);

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
                    var gv01 = $('#table010601Record').DataTable();
                    let Code = pID + '' + pSeqNo;
                    gv01.row('#rowID010601' + Code).remove().draw(false);
                };
                resolve();
            });
        };
        async function fn010601Add_Ok(Btn) {
            //access
            fnAccess('SCM070000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn010601Add_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn010601Add_Ok_Await(Btn) {
                if (document.getElementById("lbl0101Origin").innerText == "PO") {
                    if (document.getElementById("tbx010601Project").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        //Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    } else {
                        // Get all
                        var checkBoxes = document.querySelectorAll('.cbxRT010601');

                        // Check if atleast one
                        var checkedValues = Array.from(checkBoxes)
                            .filter(checkBox => checkBox.checked)
                            .map(checkBox => ({
                                RRNo: checkBox.value,
                                SeqNo: checkBox.getAttribute('data-kt-no')
                            }));

                        if (checkedValues.length > 0) {
                            //Array
                            let ItemList = [];
                            //Loop
                            checkedValues.forEach(item => {
                                var tbx010601Return = document.querySelector('[prm010601Return="rowID010601' + item.RRNo + '' + item.SeqNo + '"]');
                                var tbx010601Remarks = document.querySelector('[prm010601Remarks="rowID010601' + item.RRNo + '' + item.SeqNo + '"]');

                                // Push as an object to the array
                                ItemList.push({
                                    RRNo: item.RRNo,
                                    SeqNo: item.SeqNo,
                                    Return: parseFloat(tbx010601Return.value.replace(/,/g, '')),
                                    Remarks: tbx010601Remarks.value
                                });

                            });
                            //Format Item
                            let ItemSrs = ItemList.map(i =>
                                `${i.RRNo}©${i.SeqNo}©${i.Return}©${i.Remarks}`
                            ).join('®');
                            let ItemRR = ItemList.map(i => ({
                                RRNo: i.RRNo,
                                SeqNo: i.SeqNo,
                            }));
                            //Question
                            Return_Question(ItemSrs, ItemRR, Btn);
                        } else {
                            fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                            //Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    }
                };
                //Return Question
                function Return_Question(ItemSrs, ItemRR, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Return record?</span>',
                        icon: 'question',
                        html: `<input id="tbx010601ReturnPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
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
                            fnValidatePassword(document.getElementById("tbx010601ReturnPassword").value, function (response) {
                                if (response[0].oReturn == "") {
                                    Return_Ok(ItemSrs, ItemRR, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    // Disable the clicked button to avoid multiple clicks
                                    Btn.disabled = false;
                                    // Hide loading indication
                                    Btn.removeAttribute('data-kt-indicator');
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
                function Return_Ok(ItemSrs, ItemRR, Btn) {
                    //return
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Return Record - DTL - Particular',
                            'pIRCode': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pRTSCode': document.getElementById("ContentPlaceHolder1_hf010601RSCode").value,
                            'pRTSNo': document.getElementById("tbx010601RSNo").value,
                            'pRSDate': document.getElementById("tbx010601RSDate").value,
                            'pProject': document.getElementById("tbx010601Project").value,
                            'pItemSrs': ItemSrs
                        },
                        success: async function (response) {
                            fnAlertOnly('Record successfully returned.', 'success', 'btn btn-success');
                            //load
                            fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            for (let item of ItemRR) {
                                await fn010601Redraw("Edit", item.RRNo, item.SeqNo);
                            };
                            //Report
                            Report(document.getElementById("ContentPlaceHolder1_hf010601RSCode").value);

                            //New Code
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'New Code',
                                    'pTblName': 'Trxn_RTSHDr(RSNo)',
                                    'pPreffix': 'RS#'
                                },
                                success: function (response) {
                                    document.getElementById("tbx010601RSNo").value = response[0].oID;
                                },
                            });
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM070100',
                                    'Type': 'New Code',
                                    'pTblName': 'Trxn_RTSHDr(RSCode)',
                                    'pPreffix': 'MN'
                                },
                                success: function (response) {
                                    document.getElementById("ContentPlaceHolder1_hf010601RSCode").value = response[0].oID;
                                },
                            });
                            //New Code
                            document.getElementById("tbx010601Project").value = "";

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        },
                    });
                    //Report
                    function Report(pID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM070100',
                                'Type': 'Return Preview Report',
                                'pID': pID,
                            },
                            success: async function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                };
                            },
                        });
                    };
                };
            };
        };
        //return

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'SCM070000',
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
                fnAccess('SCM070000', 'Delete', function (response) {
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
                    'pFormCode': 'SCM070000',
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
                            'pFormCode': 'SCM070000',
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
                    url: "HNDGEN.ashx?pFormCode=SCM070000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('SCM070000', 'Add', function (response) {
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
                    fnAccess('SCM070000', 'Add', function (response) {
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM070000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
