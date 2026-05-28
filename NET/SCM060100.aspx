<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM060100.aspx.vb" Inherits="NET.SCM060100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Purchase Order</li>
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
		<div class="card card-flush w-100">

			<!--begin::title-->
			<div class="card-header pt-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/SCM060000.svg" alt="" />
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
						<div id="parentCardHeader" class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Overview</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header bg-white" data-kt-sticky-name="toolbar" data-kt-sticky="true" data-kt-sticky-width="{target: '#parentCardHeader'}" data-kt-sticky-left="auto" data-kt-sticky-top="60px" data-kt-sticky-animation="true" data-kt-sticky-zindex="95">
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
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<button id="btn0101Open" class="btn btn-sm btn-icon btn-secondary align-self-center m-1" title="Open Record" onclick="fn0101Open();return false;"><i class="las la-book-open fs-2"></i></button>
									<button id="btn0101RePrint" class="btn btn-sm btn-icon btn-secondary align-self-center m-1" title="Re-Print Record" onclick="fn0101RePrint();return false;"><i class="las la-print fs-2"></i></button>
								</div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Vendor" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Vendor</span>
											<input type="text" id="lbl0101Vendor" class="form-control" Placeholder="Vendor" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Warehouse" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Warehouse</span>
											<input type="text" id="lbl0101Warehouse" class="form-control" Placeholder="Warehouse" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											 <input type="text" id="lbl0101PONo" title="PO. No." class="form-control" Placeholder="PO. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div id="div0101PODate" class="input-group input-group-sm">
											<input type="text" id="lbl0101PODate" title="PO. Date" class="form-control" Placeholder="PO. Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div id="div0101Schedule" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Schedule</span>
											<input type="text" id="lbl0101Schedule" class="form-control form-control-sm" Placeholder="Schedule" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
									    <div class="input-group input-group-sm">
										    <div class="d-flex align-items-center position-relative w-100">
											    <input id="lbl0101Status" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Status" readonly="readonly" />
											    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											    <span class="svg-icon svg-icon-3 position-absolute pointer end-5px m-0 p-0" onclick="fn0101Status(); return false;">
												    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none">
													    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												    </svg>
											    </span>
											    <!--end::Svg Icon-->
										    </div>
									    </div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="row border border-radius-047rem m-0" style="padding-top: 8px;">
											<div class="d-flex flex-wrap justify-content-between">
												<label class="form-check-label" for="cbxCanvassDtl0101">
													With Canvass
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxCanvassDtl0101" onclick="return false;"/>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="row border border-radius-047rem m-0" style="padding-top: 8px;">
											<div class="d-flex flex-wrap justify-content-between">
												<label class="form-check-label text-truncate" title="With Payment Request" for="cbxPaymentDtl0101">
													With Payment Req.
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxPaymentDtl0101" onclick="return false;"/>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="row border border-radius-047rem pt-2 m-0">
											<div class="col-lg-4 col-md-4 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxPickUpDtl0101" onclick="return false;"/>
													<label class="form-check-label text-truncate" title="Pick-Up" for="cbxPickUpDtl0101">
														Pick-Up
													</label>
												</div>
											</div>
											<div class="col-lg-4 col-md-4 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxDlvrToDtl0101" onclick="return false;"/>
													<label class="form-check-label text-truncate" title="Deliver To" for="ContentPlaceHolder1_rb01PO002003">
														Deliver To
													</label>
												</div>
											</div>
											<div class="col-lg-4 col-md-4 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxForWhseDtl0101" onclick="return false;"/>
													<label class="form-check-label text-truncate" title="For Warehouse Pick-Up" for="cbxForWhseDtl0101">
														For Warehouse Pick-Up
													</label>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-1">
										<div class="input-group input-group-sm">
											<input type="text" id="lbl0101PickUpDate" title="Date" class="form-control" Placeholder="Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">PO Remarks</span>
											<input type="text" id="lbl0101PORemarks" class="form-control" Placeholder="Remarks" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="lbl0101RRNo" title="RR. No." class="form-control" Placeholder="RR. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="lbl0101APVNo" title="APV. No." class="form-control" Placeholder="APV. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-8">
										<div class="input-group input-group-sm">
											<input type="text" id="lbl0101DlvrAddress" title="Address" class="form-control" Placeholder="Address" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="lbl0101PaymentRef" title="Full Payment Ref." class="form-control" Placeholder="Full Payment Ref." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="lbl0101PartialRef" title="Partial Payment Ref." class="form-control" Placeholder="Partial Payment Ref." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101PmtMode" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Pmt. Mode</span>
											<input type="text" id="lbl0101PmtMode" class="form-control" Placeholder="Payment Mode" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Terms" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Terms</span>
											<input type="text" id="lbl0101Terms" class="form-control" Placeholder="Terms" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Personal Remarks</span>
											<input type="text" id="lbl0101PersonalRemarks" class="form-control" Placeholder="Remarks" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101VAT" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">VAT</span>
											<input type="text" id="lbl0101VAT" class="form-control" Placeholder="VAT" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Withholding" class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Withholding</span>
											<input type="text" id="lbl0101Withholding" class="form-control" Placeholder="Withholding" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Acct. Remarks</span>
											<input type="text" id="lbl0101AcctRemarks" class="form-control" Placeholder="Remarks" readonly="readonly" />
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
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Vendor</span>
											<select id="ddl0101Vendor" data-kt-repeater="select2" class="form-select form-select-sm form-select-border" onchange="ddl0101Vendor_onchange(this);">
												<option value="">Vendor</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Warehouse</span>
											<select id="ddl0101Warehouse" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl0101Warehouse_onchange(this);">
												<option value="">Warehouse</option>
											</select>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											 <input type="text" id="tbx0101PONo" title="PO. No." class="form-control" Placeholder="PO. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm border border-danger">
											<input type="text" id="tbx0101PODate" title="PO. Date" data-kt-repeater="datepicker" class="form-control" Placeholder="PO. Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Schedule</span>
											<input list="dl0101Schedule" type="text" id="tbx0101Schedule" class="form-control form-control-sm" Placeholder="Schedule" />
											<datalist id="dl0101Schedule">
											  <option value="upon Receipt of PO">
											  <option value="10-15 days upon Receipt of Payment (cash/check)">
											  <option value="upon Receipt of PO & release of 70% downpayment">
											  <option value="within 5 days, upon Receipt of PO">
											  <option value="45-70 days upon receipt of PO">
											</datalist>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
									    <div class="input-group input-group-sm">
										    <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											    <input id="tbx0101Status"type="text" class="form-control form-control-sm border-0 m-0" placeholder="Status" readonly="readonly" />
											    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											    <span class="svg-icon svg-icon-3 position-absolute pointer end-5px m-0 p-0">
												    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none">
													    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												    </svg>
											    </span>
											    <!--end::Svg Icon-->
										    </div>
									    </div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="row border border-radius-047rem m-0" style="padding-top: 8px;">
											<div class="d-flex flex-wrap justify-content-between">
												<label class="form-check-label" for="cbxCanvassUpd0101">
													With Canvass
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxCanvassUpd0101" onclick="return false;"/>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="row border border-radius-047rem m-0" style="padding-top: 8px;">
											<div class="d-flex flex-wrap justify-content-between">
												<label class="form-check-label text-truncate" title="With Payment Request" for="cbxPaymentUpd0101">
													With Payment Req.
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxPaymentUpd0101" onclick="return false;"/>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="row border border-radius-047rem pt-2 m-0">
											<div class="col-lg-4 col-md-4 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input checkBox" type="checkbox" value="" id="cbxPickUpUpd0101" onclick="checkBox(this);"/>
													<label class="form-check-label text-truncate" title="Pick-Up" for="cbxPickUpUpd0101">
														Pick-Up
													</label>
												</div>
											</div>
											<div class="col-lg-4 col-md-4 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input checkBox" type="checkbox" value="" id="cbxDlvrToUpd0101" onclick="checkBox(this);"/>
													<label class="form-check-label text-truncate" title="Deliver To" for="cbxDlvrToUpd0101">
														Deliver To
													</label>
												</div>
											</div>
											<div class="col-lg-4 col-md-4 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
													<input class="form-check-input checkBox" type="checkbox" value="" id="cbxForWhseUpd0101" onclick="checkBox(this);"/>
													<label class="form-check-label text-truncate" title="For Warehouse Pick-Up" for="cbxForWhseUpd0101">
														For Warehouse Pick-Up
													</label>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-1">
										<div class="input-group input-group-sm">
											<input type="text" id="tbx0101PickUpDate" title="Date" data-kt-repeater="datepicker" class="form-control" Placeholder="Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">PO Remarks</span>
											<input list="dl0101PORemarks" type="text" id="tbx0101PORemarks" class="form-control" Placeholder="Remarks" />
											<datalist id="dl0101PORemarks">

											</datalist>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="tbx0101RRNo" title="RR. No." class="form-control" Placeholder="RR. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="tbx0101APVNo" title="APV. No." class="form-control" Placeholder="APV. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-8">
										<div class="input-group input-group-sm">
											<input list="dl0101DlvrAddress" type="text" id="tbx0101DlvrAddress" title="Address" class="form-control" Placeholder="Address" />
											<datalist id="dl0101DlvrAddress">

											</datalist>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="tbx0101PaymentRef" title="Full Payment Ref." class="form-control" Placeholder="Full Payment Ref." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="input-group input-group-sm">
											<input type="text" id="tbx0101PartialRef" title="Partial Payment Ref." class="form-control" Placeholder="Partial Payment Ref." readonly="readonly" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Pmt. Mode</span>
											<select id="ddl0101PmtMode" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
												<option value="">Mode</option>
												<option value="Cash">Cash</option>
												<option value="Check">Check</option>
												<option value="Cash and Check">Cash and Check</option>
												<option value="Corporate Credit Card">Corporate Credit Card</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Terms</span>
											<select id="ddl0101Terms" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
												<option value="">Terms</option>
											</select>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Personal Remarks</span>
											<input type="text" id="tbx0101PersonalRemarks" class="form-control" Placeholder="Remarks" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">VAT</span>
											<select id="ddl0101VAT" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
												<option value="">VAT</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Withholding</span>
											<select id="ddl0101Withholding" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
												<option value="">Withholding</option>
											</select>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Acct. Remarks</span>
											<input type="text" id="tbx0101AcctRemarks" class="form-control" Placeholder="Remarks" readonly="readonly" />
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
                                    <div class="dropdown">
                                        <button id="btn0102Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Add Record">
                                            <i class="las la-plus fs-2"></i>
                                        </button>
                                        <div class="dropdown-menu dropdown-menu-end" aria-labelledby="btn0302Add">
                                            <div class="dropdown-item">
                                                <a href="#" class="d-block py-2" onclick="fn0102AddRecord(); return false;">
                                                    Add Record
                                                </a>
                                            </div>
                                            <div class="dropdown-item">
                                                <a href="#" class="d-block py-2" onclick="fn0102AddRecordPR(); return false;">
                                                    Add Record (from PR)
                                                </a>
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
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-50px mw-50px fw-bold border-end">CI</th>
												<th class="min-w-50px mw-50px fw-bold border-end">CQ</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Qty.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">UOM</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Cost</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Total</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Commodity</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Strategy</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Remarks</th>
												<th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-75px mw-75px fw-bold border-end">Qty.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">UOM</th>
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
												<th class="text-end text-dark"></th>
												<th></th>
												<th class="text-end text-dark"></th>
												<th class="text-end text-dark"></th>
												<th></th>
												<th></th>
												<th></th>
												<th></th>
												<th></th>
												<th></th>
												<th class="text-end text-dark"></th>
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
		<div id="mdl010101Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
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
				            <div class="col-lg-2 col-md-3 col-sm-3 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Find Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Price)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Find</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Price</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">Update</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Purchaser)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-3 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS05();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(CP > PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS06();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(CP > SR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS07();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO > CP)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS08();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO > CCC)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-3 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS09();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Transfer Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO > SR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS10();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cancel Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PR)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS11();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cancel Item</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-3 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS12();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Re-Open</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-4 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS13();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Re-Printing</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-4 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03TLS14();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Online Tagging</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Monitoring)</div>
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
								            <div class="fs-5 fw-bolder mb-2">PR</div>
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
								            <div class="fs-5 fw-bolder mb-2">PO</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
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
								            <div class="fs-5 fw-bolder mb-2">For</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(PO)</div>
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
								            <div class="fs-5 fw-bolder mb-2">For</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(CP)</div>
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
								            <div class="fs-5 fw-bolder mb-2">Price</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">History</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT09();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">PO Movement</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">History</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT10();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Pending</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">PR</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn010101_SCM03RPT11();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Receiving</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">History</div>
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
        
		<!--begin::Modal Search record-->
		<div id="mdl010102YRFilter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Filter record</h5>
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
                        <div class="row">
						    <div class="col-sm-12 col-md-12 col-lg-6">
							    <div class="input-group input-group-sm mb-2 border border-danger">
								    <input id="tbx010102PrevYR" type="text" onkeypress="return fnEnterKeyNumber(event,this.id);" maxlength="4" class="form-control" Placeholder="Previous Year" />
							    </div>
						    </div>
						    <div class="col-sm-12 col-md-12 col-lg-6">
							    <div class="input-group input-group-sm mb-2 border border-danger">
								    <input id="tbx010102CurrYR" type="text" onkeypress="return fnEnterKeyNumber(event,this.id);" maxlength="4" class="form-control" Placeholder="Current Year" />
							    </div>
						    </div>
                        </div>
					</div>
                    <div class="modal-footer">
                        <button id="btn010102Filter" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn010102Filter_Ok(this); return false;">
                            <span class="indicator-label">
                                Submit
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl010102Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
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
                                    <input id="tbx010102FindTools" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010102FindTools').value);" />
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
                        <div id="table010102Record" style="width: 100%; height: 100%;"></div>
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
		<div id="mdl010103Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
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
                                    <input id="tbx010103FindTools" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010103FindTools').value);" />
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
                        <div id="table010103Record" style="width: 100%; height: 100%;"></div>
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
		<div id="mdl010103Trxn" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
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
                                    <input id="tbx010103FindTrxn" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div010103TrxnLoader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table010103Trxn" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-75px mw-75px fw-bold border-end">Type</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">No</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Date</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Post"><i class='las la-check-circle fs-3'></i></span></th>
                                        <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Cancel"><i class='las la-times-circle fs-3'></i></span></th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Prepared By</th>
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
		<div id="mdl010104Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Price Update</h5>
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
                                    <input id="tbx010104Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010104Find').value);" />
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
					    <div class="input-group input-group-sm mb-2 p-1 border border-danger">
						    <select id="ddl010104Vendor" data-kt-repeater="select2" data-dropdown-parent="#mdl010104Tools" class="form-select form-select-sm form-select-border" onchange="ddl010104Vendor_onchange(this);">
							    <option value="">Vendor</option>
						    </select>
					    </div>
                        <div id="table010104Record" style="width: 100%; height: 100%;"></div>
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
		<div id="mdl010104Item" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-600px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Update Record</h5>
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
						<div class="input-group input-group-sm mb-2 border border-danger">
							<span class="input-group-text min-w-150px">Item</span>
							<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								<input id="tbx010104Item" type="text" class="form-control form-control-sm border-0 m-0" readonly placeholder="Item" />
                                <input id="hf010104Vendor" runat="server" type="hidden" value="" />
                                <input id="hf010104ItemCode" runat="server" type="hidden" value="" />
                                <input id="hf010104OrigItemCode" runat="server" type="hidden" value="" />
								<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn010104Item(); return false;">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</div>
						</div>
					    <div class="input-group input-group-sm mb-2">
						    <span class="input-group-text min-w-150px">UOM</span>
						    <input id="tbx010104UOM" type="text" class="form-control" Placeholder="UOM" maxlength="20" readonly />
                            <input id="hf010104UOMCode" runat="server" type="hidden" value="" />
					    </div>
					    <div class="input-group input-group-sm mb-2 border border-danger">
						    <span class="input-group-text min-w-150px">Price</span>
						    <input id="tbx010104Price" type="text" class="form-control" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumber(this);" Placeholder="Price" maxlength="21" />
					    </div>
					    <div class="input-group input-group-sm border border-danger">
						    <span class="input-group-text min-w-150px">Date</span>
						    <input id="tbx010104Date" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
                            <input id="hf010104OrigDate" runat="server" type="hidden" value="" />
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010104_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        		
		<!--begin::Modal Search record-->
		<div id="mdl010104FindItem" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Search Record</h5>
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
                                    <input id="tbx010104FindItem" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010104FindItem').value);" />
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
                        <div id="table010104FindItem" style="width: 100%; height: 100%;"></div>
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
		<div id="mdl010105Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (Purchaser)</h5>
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
                                    <input id="tbx010105Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010105Find').value);" />
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
                        <div id="table010105Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010105_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        		
        <!--begin::Modal Search record-->
		<div id="mdl010106Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (CP > PO)</h5>
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
                                    <input id="tbx010106Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010106Find').value);" />
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
                        <div id="table010106Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010106_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010107Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (CP > SR)</h5>
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
                                    <input id="tbx010107Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010107Find').value);" />
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
                        <div id="table010107Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010107_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010108Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (PO > CP)</h5>
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
                                    <input id="tbx010108Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010108Find').value);" />
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
                        <div id="table010108Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010108_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010109Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (PO > CCC)</h5>
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
                                    <input id="tbx010109Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010109Find').value);" />
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
                        <div id="table010109Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010109_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010110Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Transfer Item (PO > SR)</h5>
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
                                    <input id="tbx010110Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010110Find').value);" />
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
                        <div id="table010110Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010110_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010111Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Cancel Item (PR)</h5>
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
                                    <input id="tbx010111Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010111Find').value);" />
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
                        <div id="table010111Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010111_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010112Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Cancel Item (PO)</h5>
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
                                    <input id="tbx010112Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010112Find').value);" />
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
                        <div id="table010112Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010112_Ok(this); return false;">
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
		<!--begin::Modal Search record-->
        	
        <!--begin::Modal Search record-->
		<div id="mdl010113Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-500px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Re-Open (PO)</h5>
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
					    <div class="input-group input-group-sm border border-danger">
                            <textarea id="tbx010113Reason" class="form-control border border-danger" placeholder="Reason" rows="4"></textarea>
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010113_Ok(this); return false;">
                             <span class="indicator-label">Re-Open PO</span>
                             <span class='indicator-progress'>Processing</span>
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
        	
        <!--begin::Modal Search record-->
		<div id="mdl010114Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-500px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Re-Open (PO)</h5>
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
					    <div class="input-group input-group-sm border border-danger">
                            <textarea id="tbx010114PersonalRemarks" class="form-control border border-danger" placeholder="Remarks" rows="4"></textarea>
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010114_Ok(this); return false;">
                             <span class="indicator-label">Re-Print PO</span>
                             <span class='indicator-progress'>Processing</span>
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
        	
        <!--begin::Modal Search record-->
		<div id="mdl010115Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Online PO Monitoring</h5>
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
                                    <input id="tbx010115Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" gridApi.setGridOption('quickFilterText',document.getElementById('tbx010115Find').value);" />
                                </div>
                                <div id="div010115ExportButton" class="d-none"></div>
                                <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
                                   <i class="las la-bars fs-3"></i>
                                    <!--end::Svg Icon-->
                                </button>
                                <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
				                    <div class="menu-item px-3">
                                        <a href="#" class="menu-link px-3" data-kt-export="filter" onclick="fn010115Filter();return false;">Filter</a>
                                        <a href="#" class="menu-link px-3" data-kt-export="excel" onclick="fn010115Export(); return false;">Export as Excel</a>
                                    </div>
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
                        <div id="table010115Record" style="width: 100%; height: 100%;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->

		<!--begin::Modal Filter-->
		<div id="mdl010115Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Order - Filter record</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-warning" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
					    <div class="row g-2">
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115PONoFrom" type="text" class="form-control" Placeholder="PO No. From" maxlength="13" />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115PONoTo" type="text" class="form-control" Placeholder="PO No. To" maxlength="13" />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115DateFrom" type="text" class="form-control" data-kt-repeater="datepicker" Placeholder="Date From" maxlength="20" readonly />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="input-group input-group-sm">
                                    <input id="tbx010115DateTo" type="text" class="form-control" data-kt-repeater="datepicker" Placeholder="Date To" maxlength="20" readonly />
                                </div>
                            </div>
					    </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn010115Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Loading
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
		<!--begin::Modal Filter-->
        
		<!--begin::Modal Cancel-->
		<div id="mdl0101Cancel" class="modal fade" tabindex="-1" data-bs-backdrop="status" data-bs-keyboard="true" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Purchase Order - Cancel Record</h5>
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
						    <%--<input id="tbx0101Reason" type="text" class="form-control " Placeholder="Reason" maxlength="500" />--%>
                            <textarea id="tbx0101Reason" class="form-control border border-danger" placeholder="Reason" rows="4"></textarea>
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
        
		<!--begin::Modal Add Material record-->
		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="false" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Add record</h5>
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
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div class="border border-radius-047rem mb-1" style="padding-top: 8px; padding-left: 5px; padding-right: 5px;">
							        <div class="d-flex flex-wrap justify-content-between">
								        <label class="form-check-label" for="cbxChangeItemAdd0102">
									        Change Item
								        </label>
								        <div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
									        <input class="form-check-input" type="checkbox" value="" id="cbxChangeItemAdd0102" onclick="return false;"/>
								        </div>
							        </div>
						        </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div class="border border-radius-047rem mb-1" style="padding-top: 8px; padding-left: 5px; padding-right: 5px;">
							        <div class="d-flex flex-wrap justify-content-between">
								        <label class="form-check-label" for="cbxChangeQtyAdd0102">
									        Change Qty.
								        </label>
								        <div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
									        <input class="form-check-input" type="checkbox" value="" id="cbxChangeQtyAdd0102" onclick="return false;"/>
								        </div>
							        </div>
						        </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div id="div0102AddItem" class="input-group input-group-sm mb-1 border border-danger">
							        <span class="input-group-text min-w-150px">Item</span>
							        <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								        <input id="tbx0102AddItem" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Item" readonly="readonly" />
                                        <input id="hf0102AddItemCode" runat="server" type="hidden" value="" />
								        <span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0102AddItem(); return false;">
									        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									        </svg>
								        </span>
							        </div>
						        </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1 border border-danger">
						            <span class="input-group-text min-w-150px">Qty</span>
						            <input id="tbx0102AddQty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddQty(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">UOM</span>
						            <input id="tbx0102AddUOM" type="text" class="form-control" maxlength="21" Placeholder="Unit" readonly="readonly" />
                                    <input id="hf0102AddUOMCode" runat="server" type="hidden" value="" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1 border border-danger">
						            <span class="input-group-text min-w-150px">Cost</span>
						            <input id="tbx0102AddCost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddCost(this);" type="text" class="form-control" maxlength="21" Placeholder="Cost" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">Total</span>
						            <input id="tbx0102AddTotal" onkeypress="return fnEnterKeyNumber(event,this.id);" type="text" class="form-control" maxlength="21" Placeholder="Total" value="0.00" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">Canvass</span>
						            <input id="tbx0102AddCanvass" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddCanvass(this);" type="text" class="form-control" maxlength="21" Placeholder="Canvass" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">Commodity</span>
									<select id="ddl0102AddCommodity" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Commodity</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">Strategy</span>
									<select id="ddl0102AddStrategy" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Strategy</option>
										<option value="SEALED BID">SEALED BID</option>
										<option value="CANVASS">CANVASS</option>
										<option value="OUTRIGHT NEGO">OUTRIGHT NEGO</option>
										<option value="SUPPLY AGREEMENT">SUPPLY AGREEMENT</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">OSM Code</span>
									<select id="ddl0102AddOSMCode" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Code</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">Stdrd. Type</span>
									<select id="ddl0102AddStandard" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Type</option>
										<option value="Standard">Standard</option>
										<option value="Non Standard">Non Standard</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1">
									<span class="input-group-text min-w-150px">Ld. Stdrd. Type</span>
									<select id="ddl0102AddLeadStandard" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Type</option>
										<option value="On-Time Request">On-Time Request</option>
										<option value="Late Request">Late Request</option>
										<option value="Early Request">Early Request</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
                                    <textarea id="tbx0102AddRemarks" class="form-control" placeholder="Remarks" rows="4"></textarea>
					            </div>
                            </div>
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010200Add_Ok(this); return false;">
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
        
		<!--begin::Modal Search record-->
		<div id="mdl0103Item" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Search record</h5>
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
                                    <input id="tbx010301Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="onFilter();" />
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
                        <div id="table010301Item" style="width: 100%; height: 100%;"></div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Update record-->
		<div id="mdl0104Edit" class="modal fade" tabindex="-1" data-bs-backdrop="true" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px modal-dialog-scrollable">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Update record</h5>
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
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div class="border border-radius-047rem mb-1" style="padding-top: 8px; padding-left: 5px; padding-right: 5px;">
							        <div class="d-flex flex-wrap justify-content-between">
								        <label class="form-check-label" for="cbxChangeItemUpd0104">
									        Change Item
								        </label>
								        <div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
									        <input class="form-check-input" type="checkbox" value="" id="cbxChangeItemUpd0104"/>
								        </div>
							        </div>
						        </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div class="border border-radius-047rem mb-1" style="padding-top: 8px; padding-left: 5px; padding-right: 5px;">
							        <div class="d-flex flex-wrap justify-content-between">
								        <label class="form-check-label" for="cbxChangeQtyUpd0104">
									        Change Qty.
								        </label>
								        <div class="form-check form-check-custom form-check-solid form-check-sm mb-2">
									        <input class="form-check-input" type="checkbox" value="" id="cbxChangeQtyUpd0104" onclick="cbxChangeQtyUpd0104_onclick(this);"/>
								        </div>
							        </div>
						        </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div id="div0104UpdItem" class="input-group input-group-sm mb-1 border border-danger">
							        <span class="input-group-text min-w-150px">Item</span>
							        <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								        <input id="tbx0104UpdItem" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Item" readonly="readonly" />
                                        <input id="hf0104UpdSeqNo" runat="server" type="hidden" value="" />
                                        <input id="hf0104UpdItemCode" runat="server" type="hidden" value="" />
								        <span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0104UpdItem(); return false;">
									        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									        </svg>
								        </span>
							        </div>
						        </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1 border border-danger">
						            <span class="input-group-text min-w-150px">Qty</span>
						            <input id="tbx0104UpdQty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdQty(this);" type="text" class="form-control" maxlength="21" Placeholder="Qty" value="0.00" readonly />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">UOM</span>
						            <input id="tbx0104UpdUOM" type="text" class="form-control" maxlength="21" Placeholder="Unit" readonly="readonly" />
                                    <input id="hf0104UpdUOMCode" runat="server" type="hidden" value="" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1 border border-danger">
						            <span class="input-group-text min-w-150px">Cost</span>
						            <input id="tbx0104UpdCost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdCost(this);" type="text" class="form-control" maxlength="21" Placeholder="Cost" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">Total</span>
						            <input id="tbx0104UpdTotal" onkeypress="return fnEnterKeyNumber(event,this.id);" type="text" class="form-control" maxlength="21" Placeholder="Total" value="0.00" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">Canvass</span>
						            <input id="tbx0104UpdCanvass" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdCanvass(this);" type="text" class="form-control" maxlength="21" Placeholder="Canvass" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">Commodity</span>
									<select id="ddl0104UpdCommodity" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Commodity</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">Strategy</span>
									<select id="ddl0104UpdStrategy" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Strategy</option>
										<option value="SEALED BID">SEALED BID</option>
										<option value="CANVASS">CANVASS</option>
										<option value="OUTRIGHT NEGO">OUTRIGHT NEGO</option>
										<option value="SUPPLY AGREEMENT">SUPPLY AGREEMENT</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">OSM Code</span>
									<select id="ddl0104UpdOSMCode" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Code</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text min-w-150px">Stdrd. Type</span>
									<select id="ddl0104UpdStandard" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Type</option>
										<option value="Standard">Standard</option>
										<option value="Non Standard">Non Standard</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1">
									<span class="input-group-text min-w-150px">Ld. Stdrd. Type</span>
									<select id="ddl0104UpdLeadStandard" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Type</option>
										<option value="On-Time Request">On-Time Request</option>
										<option value="Late Request">Late Request</option>
										<option value="Early Request">Early Request</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
                                    <textarea id="tbx0104UpdRemarks" class="form-control" placeholder="Remarks" rows="4"></textarea>
					            </div>
                            </div>
                            <div class="separator separator-dashed mb-2"></div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">PR No.</span>
						            <input id="tbx0104UpdPRNo" type="text" class="form-control" Placeholder="PR No." readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">No.</span>
						            <input id="tbx0104UpdPRSeqNo" type="text" class="form-control" Placeholder="No." readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">Item</span>
						            <input id="tbx0104UpdPRItem" type="text" class="form-control" Placeholder="Item" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">Qty</span>
						            <input id="tbx0104UpdPRQty" type="text" class="form-control" Placeholder="Qty" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text min-w-150px">UOM</span>
						            <input id="tbx0104UpdPRUOM" type="text" class="form-control" Placeholder="Unit" readonly="readonly" />
					            </div>
                            </div>
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010400Edit_Ok(this); return false;">
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
		<!--begin::Modal Update record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl0104Item" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Search record</h5>
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
                                    <input id="tbx010401Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="onUpdFilter();" />
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
                        <div id="table010401Item" style="width: 100%; height: 100%;"></div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Add PR record-->
		<div id="mdl0105AddPR" class="modal fade" tabindex="-1" data-bs-backdrop="true" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Purchase Order - Add record</h5>
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
                                    <input id="tbx010501Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="onAddPRFilter();" />
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
                        <div id="table010501Item" style="width: 100%; height: 100%;"></div>
					</div>
                    <div class="modal-footer">
                        <button id="btn0105Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0105Add_Ok(this); return false;">
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
				</div>
			</div>
		</div>
		<!--begin::Modal Add PR record-->
        
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


		<!--param-->
		<input id="hdnPrevID" runat="server" type="hidden" value="" />
		<input id="hdnID" runat="server" type="hidden" value="" />
		<input id="hdnMode" runat="server" type="hidden" value="" />
		<input id="hdnMention" type="hidden" value="" />
		<!--param-->
	
    </div>
	
	<!-- script related to this page -->
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
    <script type="text/javascript">


        //variable
        var FileCount = 0;
        let gridApi;
        let grid010104Record;
        let grid010105Record;
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
            var Cost = parseFloat(document.getElementById("tbx0102AddCost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx0102AddTotal").value = formatNumber(Total);
        };
        function fnFormatNumberAddCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Qty = parseFloat(document.getElementById("tbx0102AddQty").value.replace(/,/g, '')) || 0.00;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx0102AddTotal").value = formatNumber(Total);
        };
        function fnFormatNumberAddCanvass(input) {
            var Canvass = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(Canvass);
        };
        function fnFormatNumberUpdQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("tbx0104UpdCost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("tbx0104UpdTotal").value = formatNumber(Total);
        };
        function fnFormatNumberUpdCost(input) {
            var Cost = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Qty = parseFloat(document.getElementById("tbx0104UpdQty").value.replace(/,/g, '')) || 0.00;
            var Total = Cost * Qty;
            input.value = formatNumber(Cost);
            document.getElementById("tbx0104UpdTotal").value = formatNumber(Total);
        };
        function fnFormatNumberUpdCanvass(input) {
            var Canvass = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(Canvass);
        };
        function fnFormatNumber(input) {
            var num = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            input.value = formatNumber(num);
        }
        //numeric

        // checkbox
        function checkBox(chkBox) {
            document.querySelectorAll(".checkBox").forEach(cb => {
                if (cb !== chkBox) {
                    var ddl0101Vendor = document.getElementById("ddl0101Vendor");
                    var ddl0101Warehouse = document.getElementById("ddl0101Warehouse");
                    document.getElementById("tbx0101DlvrAddress").value = "";
                    cb.checked = false;
                    if (chkBox.id == "cbxPickUpUpd0101" || chkBox.id == "cbxForWhseUpd0101") {
                        if (ddl0101Vendor.options[ddl0101Vendor.selectedIndex].value != "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM060100',
                                    'Type': 'Purchase Order - Get Vendor Address',
                                    'pVendor': ddl0101Vendor.options[ddl0101Vendor.selectedIndex].value
                                },
                                success: function (response) {
                                    document.getElementById("tbx0101DlvrAddress").value = response[0].oVenAddress;
                                }
                            });
                        };
                    } else if (chkBox.id == "cbxDlvrToUpd0101") {
                        if (ddl0101Warehouse.options[ddl0101Warehouse.selectedIndex].value != "") {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM060100',
                                    'Type': 'Purchase Order - Get Warehouse Address',
                                    'pWarehouse': ddl0101Warehouse.options[ddl0101Warehouse.selectedIndex].value
                                },
                                success: function (response) {
                                    document.getElementById("tbx0101DlvrAddress").value = response[0].oWhseAddress;
                                }
                            });
                        };
                    };
                };
            });
        };
        // checkbox

        //general
        function fn01Load() {
            fnAccess('SCM060000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadParticular(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0401LoadStatus(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                document.getElementById("btn0101Unlock").classList.remove("btn-lock");
                document.getElementById("btn0101Post").classList.remove("btn-post");
                document.getElementById("btn0101Cancel").classList.remove("btn-cancel");
                document.getElementById("btn0101Tools").classList.remove("btn-secondary");
                document.getElementById("btn0101Open").classList.remove("btn-secondary");
                document.getElementById("btn0101RePrint").classList.remove("btn-secondary");
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
                document.getElementById("btn0101Unlock").classList.add("btn-lock");
                document.getElementById("btn0101Post").classList.add("btn-post");
                document.getElementById("btn0101Cancel").classList.add("btn-cancel");
                document.getElementById("btn0101Tools").classList.add("btn-secondary");
                document.getElementById("btn0101Open").classList.add("btn-secondary");
                document.getElementById("btn0101RePrint").classList.add("btn-secondary");
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
            document.getElementById("btn0101Unlock").disabled = pValue;
            document.getElementById("btn0101Post").disabled = pValue;
            document.getElementById("btn0101Cancel").disabled = pValue;
            document.getElementById("btn0101Tools").disabled = pValue;
            document.getElementById("btn0101Open").disabled = pValue;
            document.getElementById("btn0101RePrint").disabled = pValue;
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

        // Store the original parent nodes safely (DOM reference, not string)
        const toggleMenuMap = new WeakMap();
        function fn02Toggle(button, event) {
            if (event) {
                event.preventDefault();
                event.stopPropagation();
            }

            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            const rowElement = button.closest('.ag-row');
            if (rowElement) {
                const rowIndex = parseInt(rowElement.getAttribute('row-index'), 10);
                const rowNode = gridApi.getDisplayedRowAtIndex(rowIndex);
                if (rowNode) {
                    gridApi.deselectAll();
                    rowNode.setSelected(true);
                }
            }

            // Hide any other open menus first
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) {
                    menu.classList.add('d-none');
                    const parent = toggleMenuMap.get(menu);
                    if (parent) parent.appendChild(menu);
                    toggleMenuMap.delete(menu);
                }
            });

            if (toggleMenu) {
                const isVisible = !toggleMenu.classList.contains('d-none');
                toggleMenu.classList.toggle('d-none');

                if (!isVisible) {
                    // Move to body
                    toggleMenuMap.set(toggleMenu, wrapper);
                    document.body.appendChild(toggleMenu);

                    const rect = button.getBoundingClientRect();
                    const offsetX = 40; // horizontal offset
                    toggleMenu.style.position = 'absolute';
                    toggleMenu.style.left = `${rect.left + window.scrollX + offsetX}px`;
                    toggleMenu.style.top = `${rect.top + window.scrollY + (rect.height / 2) - (toggleMenu.offsetHeight / 2)}px`;
                    toggleMenu.style.zIndex = '9999';

                    // Close when clicking outside
                    const outsideClickListener = (ev) => {
                        if (!toggleMenu.contains(ev.target) && ev.target !== button) {
                            toggleMenu.classList.add('d-none');
                            const parent = toggleMenuMap.get(toggleMenu);
                            if (parent) parent.appendChild(toggleMenu);
                            toggleMenuMap.delete(toggleMenu);
                            document.removeEventListener('click', outsideClickListener);
                        }
                    };

                    setTimeout(() => document.addEventListener('click', outsideClickListener), 0);
                } else {
                    const parent = toggleMenuMap.get(toggleMenu);
                    if (parent) parent.appendChild(toggleMenu);
                    toggleMenuMap.delete(toggleMenu);
                }
            }
        }
        //resize
        window.addEventListener('resize', () => {
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                menu.classList.add('d-none');
                const parent = toggleMenuMap.get(menu);
                if (parent) parent.appendChild(menu);
                toggleMenuMap.delete(menu);
            });

            // Remove AG Grid highlight
            if (gridApi) gridApi.deselectAll();
        });
        //scroll
        window.addEventListener('scroll', () => {
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                menu.classList.add('d-none');
                const parent = toggleMenuMap.get(menu);
                if (parent) parent.appendChild(menu);
                toggleMenuMap.delete(menu);
            });

            // Remove AG Grid highlight
            if (gridApi) gridApi.deselectAll();
        });
        function fn01DisableToggle() {
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                menu.classList.add('d-none');
                const parent = toggleMenuMap.get(menu);
                if (parent) parent.appendChild(menu);
                toggleMenuMap.delete(menu);
            });

            // Remove AG Grid highlight
            if (gridApi) gridApi.deselectAll();
        };
        function ddl0101Vendor_onchange(ddl0101Vendor) {
            if (ddl0101Vendor.options[ddl0101Vendor.selectedIndex].value != "") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Vendor Address',
                        'pVendor': ddl0101Vendor.options[ddl0101Vendor.selectedIndex].value
                    },
                    success: function (response) {
                        if (document.getElementById("cbxPickUpUpd0101").checked == true || document.getElementById("cbxForWhseUpd0101").checked == true) {
                            document.getElementById("tbx0101DlvrAddress").value = response[0].oVenAddress;
                        };
                        if (response.length > 0) {
                            $('#ddl0101VAT').val(response[0].oVenVAT).trigger('change');
                            $('#ddl0101Withholding').val(response[0].oVenEWT).trigger('change');
                            $('#ddl0101Terms').val(response[0].oVenTerms).trigger('change');
                        };
                    }
                });
            };
        }
        function ddl0101Warehouse_onchange(ddl0101Warehouse) {
            if (ddl0101Warehouse.options[ddl0101Warehouse.selectedIndex].value != "") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Warehouse Address',
                        'pWarehouse': ddl0101Warehouse.options[ddl0101Warehouse.selectedIndex].value
                    },
                    success: function (response) {
                        if (document.getElementById("cbxDlvrToUpd0101").checked == true) {
                            document.getElementById("tbx0101DlvrAddress").value = response[0].oWhseAddress;
                        };
                    }
                });
            };
        };
        document.getElementById("tbx0101PORemarks").addEventListener("input", function () {
            const tbx0101PORemarks = this.value;
            const dl0101PORemarks = document.getElementById('dl0101PORemarks');

            // Check if the entered value matches any option in the datalist
            let isValidSelection = false;
            for (let option of dl0101PORemarks.options) {
                if (tbx0101PORemarks === option.value) {
                    isValidSelection = true;
                    break;
                };
            };

            // If the user selected a valid option, transfer it to the plain input
            if (isValidSelection) {
                document.getElementById('tbx0101PersonalRemarks').value = tbx0101PORemarks;
                // Clear the vendor input after selection
                document.getElementById('tbx0101PORemarks').value = "";
            };
        });
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
                ddl0101Vendor('');
                ddl0101Warehouse('');
                document.getElementById("tbx0101PONo").value = "";
                document.getElementById("tbx0101Schedule").value = "";
                document.getElementById("cbxCanvassUpd0101").checked = false;
                document.getElementById("cbxPaymentUpd0101").checked = false;
                document.getElementById("cbxPickUpUpd0101").checked = false;
                document.getElementById("cbxDlvrToUpd0101").checked = true;
                document.getElementById("cbxForWhseUpd0101").checked = false;
                document.getElementById("tbx0101PickUpDate").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                ddl0101PORemarks('');
                document.getElementById("tbx0101RRNo").value = "";
                document.getElementById("tbx0101APVNo").value = "";
                ddl0101DlvrAddress('');
                document.getElementById("tbx0101PaymentRef").value = "";
                document.getElementById("tbx0101PartialRef").value = "";
                $('#ddl0101PmtMode').val('Check').trigger('change');
                ddl0101Terms('');
                document.getElementById("tbx0101PersonalRemarks").value = "";
                ddl0101VAT('');
                ddl0101Withholding('');
                document.getElementById("tbx0101AcctRemarks").value = "";
                document.getElementById("tbx0101PODate").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
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
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].VenName;
                        document.getElementById("spn0101ID").innerText = response[0].POCode;
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
                        document.getElementById("lbl0101Vendor").value = response[0].VenName;
                        document.getElementById("lbl0101Vendor").setAttribute("title", response[0].VenName);
                        document.getElementById("lbl0101Warehouse").value = response[0].WhseName;
                        document.getElementById("lbl0101Warehouse").setAttribute("title", response[0].WhseName);
                        document.getElementById("lbl0101PONo").value = response[0].PONo;
                        document.getElementById("lbl0101PODate").value = response[0].PODate;
                        document.getElementById("lbl0101Schedule").value = response[0].DlvrSched;
                        document.getElementById("lbl0101Schedule").setAttribute("title", response[0].DlvrSched);
                        document.getElementById("lbl0101Status").value = response[0].Status;
                        document.getElementById("cbxCanvassDtl0101").checked = response[0].wCanvass == 1 ? true : false;
                        document.getElementById("cbxPaymentDtl0101").checked = response[0].wPaymentRequest == 1 ? true : false;
                        document.getElementById("cbxPickUpDtl0101").checked = response[0].DlvrType == 0 ? true : false;
                        document.getElementById("cbxDlvrToDtl0101").checked = response[0].DlvrType == 1 ? true : false;
                        document.getElementById("cbxForWhseDtl0101").checked = response[0].DlvrType == 2 ? true : false;
                        document.getElementById("lbl0101PickUpDate").value = response[0].PickUpDate;
                        document.getElementById("lbl0101PORemarks").value = response[0].Remarks;
                        document.getElementById("lbl0101PORemarks").setAttribute("title", response[0].Remarks);
                        document.getElementById("lbl0101RRNo").value = response[0].RRNo;
                        document.getElementById("lbl0101APVNo").value = response[0].VchNo;
                        document.getElementById("lbl0101DlvrAddress").value = response[0].DlvrAddress;
                        document.getElementById("lbl0101PaymentRef").value = response[0].PaymentRefNo;
                        document.getElementById("lbl0101PartialRef").value = response[0].PartialRefNo;
                        document.getElementById("lbl0101PmtMode").value = response[0].PmtMode;
                        document.getElementById("lbl0101PmtMode").setAttribute("title", response[0].PmtMode);
                        document.getElementById("lbl0101Terms").value = response[0].CTName;
                        document.getElementById("lbl0101Terms").setAttribute("title", response[0].CTName);
                        document.getElementById("lbl0101PersonalRemarks").value = response[0].PersonalRemarks;
                        document.getElementById("lbl0101PersonalRemarks").setAttribute("title", response[0].PersonalRemarks);
                        document.getElementById("lbl0101VAT").value = response[0].VATName;
                        document.getElementById("lbl0101VAT").setAttribute("title", response[0].VATName);
                        document.getElementById("lbl0101Withholding").value = response[0].EWTName;
                        document.getElementById("lbl0101Withholding").setAttribute("title", response[0].EWTName);
                        document.getElementById("lbl0101AcctRemarks").value = response[0].AcctRemarks;
                        document.getElementById("lbl0101AcctRemarks").setAttribute("title", response[0].AcctRemarks);
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
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].VenName;
                        document.getElementById("spn0101ID").innerText = response[0].POCode;
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
                        ddl0101Vendor(response[0].VenCode);
                        ddl0101Warehouse(response[0].WhseCode);
                        document.getElementById("tbx0101PONo").value = response[0].PONo;
                        document.getElementById("tbx0101PODate").value = response[0].PODate;
                        document.getElementById("tbx0101Schedule").value = response[0].DlvrSched;
                        document.getElementById("tbx0101Status").value = response[0].Status;
                        document.getElementById("cbxCanvassUpd0101").checked = response[0].wCanvass == 1 ? true : false;
                        document.getElementById("cbxPaymentUpd0101").checked = response[0].wPaymentRequest == 1 ? true : false;
                        document.getElementById("cbxPickUpUpd0101").checked = response[0].DlvrType == 0 ? true : false;
                        document.getElementById("cbxDlvrToUpd0101").checked = response[0].DlvrType == 1 ? true : false;
                        document.getElementById("cbxForWhseUpd0101").checked = response[0].DlvrType == 2 ? true : false;
                        document.getElementById("tbx0101PickUpDate").value = response[0].PickUpDate;
                        ddl0101PORemarks(response[0].Remarks);
                        document.getElementById("tbx0101RRNo").value = response[0].RRNo;
                        document.getElementById("tbx0101APVNo").value = response[0].VchNo;
                        ddl0101DlvrAddress(response[0].DlvrAddress);
                        document.getElementById("tbx0101PaymentRef").value = response[0].PaymentRefNo;
                        document.getElementById("tbx0101PartialRef").value = response[0].PartialRefNo;
                        $('#ddl0101PmtMode').val(response[0].PmtMode).trigger('change');
                        ddl0101VAT(response[0].VATCode);
                        ddl0101Terms(response[0].CTCode);
                        document.getElementById("tbx0101PersonalRemarks").value = response[0].PersonalRemarks;
                        ddl0101Withholding(response[0].EWTCode);
                        document.getElementById("tbx0101AcctRemarks").value = response[0].AcctRemarks;
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
            function ddl0101Vendor(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Vendor',
                        'pPlaceHolder': 'Vendor',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Vendor").html(s);
                        $('#ddl0101Vendor').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101Warehouse(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Warehouse(Receiving)',
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
            function ddl0101PORemarks(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Vehicle',
                        'pPlaceHolder': '',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].Name + '"></option>';
                        }
                        // Populate datalist, not the input
                        $("#dl0101PORemarks").html(s);

                        // Optional: clear the input value
                        $("#tbx0101PORemarks").val(ID);
                    }
                });
            };
            function ddl0101DlvrAddress(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Destination',
                        'pPlaceHolder': '',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].Name + '"></option>';
                        }
                        // Populate datalist, not the input
                        $("#dl0101DlvrAddress").html(s);

                        // Optional: clear the input value
                        $("#tbx0101DlvrAddress").val(ID);
                    }
                });
            };
            function ddl0101Terms(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_CreditTerms',
                        'pPlaceHolder': 'Terms',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Terms").html(s);
                        $('#ddl0101Terms').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101VAT(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_VAT',
                        'pPlaceHolder': 'VAT',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101VAT").html(s);
                        $('#ddl0101VAT').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101Withholding(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_EWT',
                        'pPlaceHolder': 'Withholding',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Withholding").html(s);
                        $('#ddl0101Withholding').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
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
                //if exists
                fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM060000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_POHdr', ID, '', 'Delete', function (response) {
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
                    title: '<span class="fs-6 fw-normal text-gray-700">Delete record?</span>',
                    icon: 'question',
                    html: `<input id="tbx03Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx03Password");
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
                        fnValidatePassword(document.getElementById("tbx03Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
                function Delete_Ok(ID) {
                    fnDelete('SCM060000', 'Trxn_POHdr', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM060000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM060000");
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
                fnAccess('SCM060000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM060000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM060000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                if (document.getElementById("tbx0101PODate").value == "") {
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
                            fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Add Record',
                        'pPODate': document.getElementById("tbx0101PODate").value,
                        'pVendor': document.getElementById("ddl0101Vendor").options[document.getElementById("ddl0101Vendor").selectedIndex].value,
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pDlvrTo': document.getElementById("cbxPickUpUpd0101").checked == true ? 0 : document.getElementById("cbxDlvrToUpd0101").checked == true ? 1 : document.getElementById("cbxForWhseUpd0101").checked == true ? 2 : 1,
                        'pPickUpDate': document.getElementById("tbx0101PickUpDate").value,
                        'pDlvrAddress': document.getElementById("tbx0101DlvrAddress").value,
                        'pDlvrSched': document.getElementById("tbx0101Schedule").value,
                        'pPmtMode': document.getElementById("ddl0101PmtMode").options[document.getElementById("ddl0101PmtMode").selectedIndex].value,
                        'pTerms': document.getElementById("ddl0101Terms").options[document.getElementById("ddl0101Terms").selectedIndex].value,
                        'pVAT': document.getElementById("ddl0101VAT").options[document.getElementById("ddl0101VAT").selectedIndex].value,
                        'pWithholding': document.getElementById("ddl0101Withholding").options[document.getElementById("ddl0101Withholding").selectedIndex].value,
                        'pRemarks': document.getElementById("tbx0101PORemarks").value,
                        'pPersonalRemarks': document.getElementById("tbx0101PersonalRemarks").value
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
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Edit Record',
                        'pID': ID,
                        'pPONo': document.getElementById("tbx0101PONo").value,
                        'pPODate': document.getElementById("tbx0101PODate").value,
                        'pVendor': document.getElementById("ddl0101Vendor").options[document.getElementById("ddl0101Vendor").selectedIndex].value,
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pDlvrTo': document.getElementById("cbxPickUpUpd0101").checked == true ? 0 : document.getElementById("cbxDlvrToUpd0101").checked == true ? 1 : document.getElementById("cbxForWhseUpd0101").checked == true ? 2 : 1,
                        'pPickUpDate': document.getElementById("tbx0101PickUpDate").value,
                        'pDlvrAddress': document.getElementById("tbx0101DlvrAddress").value,
                        'pDlvrSched': document.getElementById("tbx0101Schedule").value,
                        'pPmtMode': document.getElementById("ddl0101PmtMode").options[document.getElementById("ddl0101PmtMode").selectedIndex].value,
                        'pTerms': document.getElementById("ddl0101Terms").options[document.getElementById("ddl0101Terms").selectedIndex].value,
                        'pVAT': document.getElementById("ddl0101VAT").options[document.getElementById("ddl0101VAT").selectedIndex].value,
                        'pWithholding': document.getElementById("ddl0101Withholding").options[document.getElementById("ddl0101Withholding").selectedIndex].value,
                        'pRemarks': document.getElementById("tbx0101PORemarks").value,
                        'pPersonalRemarks': document.getElementById("tbx0101PersonalRemarks").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
        };
        function fn0101Lock() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else if (response[0].oReturn == "0") { 
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        ValidateFields(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
            //validate fields
            function ValidateFields(ID) {
                // Array
                var fields = [
                    { field: "lbl0101Vendor", div: "div0101Vendor" },
                    { field: "lbl0101Warehouse", div: "div0101Warehouse" },
                    { field: "lbl0101PODate", div: "div0101PODate" },
                    { field: "lbl0101Schedule", div: "div0101Schedule" },
                    { field: "lbl0101PmtMode", div: "div0101PmtMode" },
                    { field: "lbl0101Terms", div: "div0101Terms" },
                    { field: "lbl0101VAT", div: "div0101VAT" },
                    { field: "lbl0101Withholding", div: "div0101Withholding" }
                ];

                // Loop
                var missingFieldFound = false; 
                fields.forEach(function (fieldObj) {
                    var fieldValue = document.getElementById(fieldObj.field).value;
                    var divElement = document.getElementById(fieldObj.div);

                    if (fieldValue == "") {
                        missingFieldFound = true;
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                        divElement.classList.add("border", "border-danger");

                        // Remove the border after 5 seconds
                        setTimeout(function () {
                            divElement.classList.remove("border", "border-danger");
                        }, 5000);
                    }
                });

                if (!missingFieldFound) {
                    Lock_Question(ID);
                };
            };
            //lock question
            function Lock_Question(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Lock Status'
                    },
                    success: function (response) {
                        if (response[0].oLock == "1") {
                            Swal.fire({
                                title: '<span class="fs-6 fw-normal text-gray-700">Lock record w. Canvass?</span>',
                                icon: 'question',
                                html: `<input id="tbx0101LockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                                iconColor: '#009ef7',
                                buttonsStyling: false,
                                showCancelButton: true,
                                showDenyButton: true,
                                confirmButtonText: "Yes",
                                denyButtonText: "No",
                                cancelButtonText: 'Cancel',
                                customClass: {
                                    confirmButton: 'btn btn-sm btn-info min-w-100px',
                                    denyButton: 'btn btn-sm btn-warning min-w-100px',
                                    cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                                }
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                                        if (response[0].oReturn == "") {
                                            fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                                                if (response[0].oReturn == "") {
                                                    Lock_Ok(ID, true);
                                                } else {
                                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                };
                                            });
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                } else if (result.isDenied) {
                                    fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                                        if (response[0].oReturn == "") {
                                            fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                                                if (response[0].oReturn == "") {
                                                    Lock_Ok(ID, false);
                                                } else {
                                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                                };
                                            });
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                };
                            });
                        } else {
                            Swal.fire({
                                title: '<span class="fs-6 fw-normal text-gray-700">Set status for Locking?</span>',
                                icon: 'question',
                                html: `<input id="tbx0101LockStatusPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                                didOpen: () => {
                                    const input = document.getElementById("tbx0101LockStatusPassword");
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
                                    fnValidatePassword(document.getElementById("tbx0101LockStatusPassword").value, function (response) {
                                        if (response[0].oReturn == "") {
                                            fnValidateRecord('Trxn_POHdr', ID, '', 'Lock', function (response) {
                                                if (response[0].oReturn == "") {
                                                    Lock_Status(ID);
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
                    }
                });
            };
            //lock status
            function Lock_Status(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Lock Change Status',
                        'pID': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    }
                });
            };

            //lock ok
            function Lock_Ok(ID, Mode) {
                if (Mode) {
                    fnLock('Lock', 'Trxn_POHdr(wCanvass)', ID, function (response) {
                        fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    });
                } else {
                    fnLock('Lock', 'Trxn_POHdr', ID, function (response) {
                        fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    });
                };
            };
        };
        function fn0101Unlock() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Unlock', function (response) {
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
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Unlock', function (response) {
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
                fnLock('Unlock', 'Trxn_POHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Post() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Post', function (response) {
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
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Post', function (response) {
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
                        'pRecType': "Purchase Order",
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
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Unpost', function (response) {
                    if (response[0].oReturn == "1") {
                        withValidate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        woValidate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    };
                });
            };
            //with access
            function withValidate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        wCancel_Ok(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function wCancel_Ok(ID) {
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
                                Direct_Cancel(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    };
                });
            };
            function Direct_Cancel(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Direct Cancel Record',
                        'pID': ID
                    },
                    success: function (response) {
                        //cancel
                        fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        //modal
                    },
                });
            };

            //validate
            function woValidate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        $('#mdl0101Cancel').modal('show');
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
        };
        function fn0101Cancel_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    window.location.replace("MNU040100");
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        if (document.getElementById("tbx0101Reason").value == "") {
                            fnAlertOnly("Some fields are missing!", 'warning', 'btn btn-warning');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        } else {
                            Cancel_Question(ID);
                            //modal
                            $('#mdl0101Cancel').modal('hide');
                        }
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            //post question
            function Cancel_Question(ID) {
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
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Unpost', function (response) {
                                    if (response[0].oReturn == "") {
                                        Cancel_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    } else {
                        $('#mdl0101Cancel').modal('show');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                });
            };
            //post ok
            function Cancel_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM060100",
                        'Type': "Purchase Order - Cancel Record (PO)",
                        'pID': ID,
                        'pRemarks': document.getElementById("tbx0101Reason").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        //clear
                        document.getElementById("tbx0101Reason").value = "";
                        //modal
                        $("#mdl0101Cancel").modal("hide");
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    },
                });
            }
        };
        function fn0101Status() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Purchase Order - PO Status',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                },
                success: function (response) {
                    if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "DTL" && response[0].oStatus == "for Re-Open") {
                        if (response[0].oReOpenRemarks == "") {
                            Swal.fire({
                                title: 'Re-Open',
                                text: 'Remarks : No reason for re-open.',
                                icon: 'warning',
                                buttonsStyling: false,
                                showCancelButton: false,
                                confirmButtonText: "Ok",
                                customClass: {
                                    confirmButton: 'btn btn-sm btn-warning min-w-100px'
                                }
                            });
                        } else {
                            Swal.fire({
                                title: 'Re-Open',
                                text: 'Remarks : ' + response[0].oReOpenRemarks,
                                icon: 'warning',
                                buttonsStyling: false,
                                showCancelButton: false,
                                confirmButtonText: "Ok",
                                customClass: {
                                    confirmButton: 'btn btn-sm btn-warning min-w-100px'
                                }
                            });
                        }
                    };
                }
            });
        };
        function fn0101Tools() {
            $('#mdl010101Tools').modal('show');
        };
        function fn010101_SCM03TLS01() {
            $('#mdl010102YRFilter').modal('show');
        };
        function fn010102Filter_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            if (document.getElementById("tbx010102PrevYR").value == "") {
                fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } else if (document.getElementById("tbx010102CurrYR").value == "") {
                fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } else if (document.getElementById("tbx010102PrevYR").value > document.getElementById("tbx010102CurrYR").value) {
                fnAlertOnly('Incorrect Format!', 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } else {
                Filter_Ok();
            };
            //function
            async function Filter_Ok() {
                await Filter_Ok_Await(Btn);
            };
            async function Filter_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Get Item Price',
                            'pPrevYR': document.getElementById("tbx010102PrevYR").value,
                            'pCurrYR': document.getElementById("tbx010102CurrYR").value,
                        },
                        success: function (response) {

                            let gridDiv = document.querySelector('#table010102Record');
                            let gridOptions;

                            // Destroy old grid if exists
                            gridDiv.innerHTML = "";

                            gridOptions = {
                                suppressCellFocus: true,
                                suppressVerticalScroll: true,
                                enableCellTextSelection: true,
                                rowSelection: 'single',
                                //popupParent: document.body,
                                loading: false,
                                columnDefs: [
                                    {
                                        headerName: "Code",
                                        field: "ItemCode",
                                        width: 150,
                                        tooltipField: "ItemCode"
                                    },
                                    {
                                        headerName: "Lock",
                                        field: "Lock",
                                        resizable: false,
                                        width: 65,
                                        cellRenderer: params => params.value
                                    },
                                    {
                                        headerName: "Item",
                                        field: "ItemName",
                                        tooltipField: "ItemName",
                                        flex: 1
                                    },
                                    {
                                        headerName: "UOM",
                                        field: "UMName",
                                        width: 75,
                                        tooltipField: "UMName"
                                    },
                                    {
                                        headerName: "Cost",
                                        field: "Cost",
                                        width: 150,
                                        tooltipField: "Cost",
                                        cellClass: "text-end",
                                        valueFormatter: params => {
                                            if (params.value == null || params.value === "") return "";
                                            return Number(params.value).toLocaleString("en-US", {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            });
                                        },
                                    },
                                    {
                                        headerName: "Canvass",
                                        field: "Canvass",
                                        width: 150,
                                        tooltipField: "Canvass",
                                        cellClass: "text-end",
                                        valueFormatter: params => {
                                            if (params.value == null || params.value === "") return "";
                                            return Number(params.value).toLocaleString("en-US", {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            });
                                        },
                                    },
                                    {
                                        headerName: "Date Encoded",
                                        field: "UpdatedDate",
                                        width: 150,
                                        tooltipField: "UpdatedDate"
                                    },
                                    {
                                        headerName: "Vendor",
                                        field: "Vendor",
                                        flex: 1,
                                        tooltipField: "Vendor"
                                    },
                                ],
                                rowData: response,
                                pagination: false,
                                paginationPageSize: 25
                            };
                            gridApi = agGrid.createGrid(gridDiv, gridOptions);
                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            $('#mdl010102YRFilter').modal('hide');
                            $('#mdl010102Tools').modal('show');
                            document.getElementById("tbx010102PrevYR").value = "";
                            document.getElementById("tbx010102CurrYR").value = "";
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //resolve
                            resolve();
                        },
                    });
                });
            };
        }
        function fn010101_SCM03TLS02() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Purchase Order - Find PR',
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
                    let gridDiv = document.querySelector('#table010103Record');
                    let gridOptions;

                    // Destroy old grid if exists
                    gridDiv.innerHTML = "";


                    gridOptions = {
                        suppressCellFocus: true,
                        enableCellTextSelection: true,
                        rowSelection: 'single',
                        //popupParent: document.body,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action",
                                field: "Action",
                                sortable: false,
                                resizable: false,
                                width: 75,
                                cellRenderer: params => params.value
                            },
                            {
                                headerName: "PR No.",
                                field: "PRNo",
                                width: 150,
                                tooltipField: "PRNo"
                            },
                            {
                                headerName: "Date Required",
                                field: "DateRequired",
                                width: 120,
                                tooltipField: "DateRequired"
                            },
                            {
                                headerName: "Purchase Type",
                                field: "PurchaseType",
                                width: 150,
                                tooltipField: "PurchaseType"
                            },
                            {
                                headerName: "Project",
                                field: "Project",
                                width: 150,
                                tooltipField: "Project"
                            },
                            {
                                headerName: "Remarks",
                                field: "Remarks",
                                tooltipField: "Remarks",
                                flex: 1
                            },
                            {
                                headerName: "Requestor",
                                field: "Requestor",
                                flex: 1,
                                tooltipField: "Requestor"
                            }
                        ],
                        rowData: response,
                        pagination: false,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                    //close 
                    Swal.close();
                    //modal
                    $('#mdl010103Tools').modal('show');
                },
            });
        };
        function fn010103View(pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Purchase Order - PR Trxn',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010103TrxnLoader").style.display = "";
                    //display loader

                    $('#table010103Trxn').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010103Trxn = $("#table010103Trxn").DataTable({
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
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        }
                    });
                    //datatable

                    //search
                    $('#tbx010103FindTrxn').on('keyup', function () {
                        table010103Trxn.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010103TrxnLoader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl010103Trxn').modal('show');
                },
            });
        };
        function fn010103ViewTrxn(pID, pCode, pType) {
            //access
            fnAccess('SCM060000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
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
        }
        function fn010101_SCM03TLS03() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    ddl010104Vendor('');
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function ddl010104Vendor(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Vendor',
                        'pPlaceHolder': 'Vendor',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl010104Vendor").html(s);
                        $('#ddl010104Vendor').val(ID).trigger('change');
                        //reset
                        document.getElementById("table010104Record").innerHTML = "";
                        //modal
                        $("#mdl010104Tools").modal("show");
                    },
                });
            };
        };
        function ddl010104Vendor_onchange(ddl010104Vendor) {
            if (ddl010104Vendor.options[ddl010104Vendor.selectedIndex].value != "") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Price Update',
                        'pVendor': ddl010104Vendor.options[ddl010104Vendor.selectedIndex].value
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010104Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "ItemName",
                                    field: "ItemName",
                                    flex: 1,
                                    tooltipField: "ItemName"
                                },
                                {
                                    headerName: "UOM",
                                    field: "UMName",
                                    width: 75,
                                    tooltipField: "UMName"
                                },
                                {
                                    headerName: "Price",
                                    field: "Price",
                                    width: 150,
                                    tooltipField: "Price",
                                    cellClass: "text-end",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                },
                                {
                                    headerName: "Project",
                                    field: "Project",
                                    width: 150,
                                    tooltipField: "Project"
                                },
                                {
                                    headerName: "Date",
                                    field: "Date",
                                    tooltipField: "Date",
                                    width: 120
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25,
                            onBodyScroll: function (event) {
                                document.querySelectorAll('.toggle-menu').forEach(menu => {
                                    menu.classList.add('d-none');
                                    const parent = toggleMenuMap.get(menu);
                                    if (parent) parent.appendChild(menu);
                                    toggleMenuMap.delete(menu);
                                });

                                // Remove AG Grid highlight
                                if (gridApi) gridApi.deselectAll();
                            }
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        if (!grid010104Record) {
                            grid010104Record = gridApi;
                        };

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                        //close 
                        Swal.close();
                    },
                });
            };
        };
        function fn010104Edit(pItemCode, pVendor) {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(pItemCode, pVendor);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate(pItemCode, pVendor) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Item Record',
                        'pItemCode': pItemCode,
                        'pVendor': pVendor
                    },
                    success: function (response) {
                        document.getElementById("tbx010104Item").value = response[0].ItemName;
                        document.getElementById("ContentPlaceHolder1_hf010104Vendor").value = pVendor;
                        document.getElementById("ContentPlaceHolder1_hf010104OrigItemCode").value = pItemCode;
                        document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010104UOM").value = response[0].UMName;
                        document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010104Price").value = formatNumber(response[0].Price);
                        document.getElementById("tbx010104Date").value = response[0].Date;
                        document.getElementById("ContentPlaceHolder1_hf010104OrigDate").value = response[0].Date;

                        $("#mdl010104Item").modal("show");
                    },
                });
            };
        };
        function fn010104Item() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    LoadMaterial();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function LoadMaterial() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Find Item',
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
                        let gridDiv = document.querySelector('#table010104FindItem');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";


                        gridOptions = {
                            suppressCellFocus: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "Item Code",
                                    field: "ItemCode",
                                    width: 150,
                                    tooltipField: "ItemCode"
                                },
                                {
                                    headerName: "Lock",
                                    field: "Lock",
                                    resizable: false,
                                    orderable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "ItemName",
                                    field: "ItemName",
                                    flex: 1,
                                    tooltipField: "ItemName"
                                },
                                {
                                    headerName: "UOM",
                                    field: "UMName",
                                    width: 150,
                                    tooltipField: "UMName"
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                        //close 
                        Swal.close();
                        //modal
                        $('#mdl010104FindItem').modal('show');
                    },
                });
            };
        };
        function fn010104ViewItem(pItemName, pItemCode, pUMCode, pUMName, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemName, pItemCode, pUMName, pUMCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemName, pItemCode, pUMName, pUMCode) {
                document.getElementById("tbx010104Item").value = pItemName;
                document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value = pItemCode;
                document.getElementById("tbx010104UOM").value = pUMName;
                document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value = pUMCode;

                //modal
                $("#mdl010104FindItem").modal("hide");
            };
        };
        function fn010104_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
            function Validate() {
                //Validate
                if (document.getElementById("tbx010104Item").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                } else if (document.getElementById("tbx010104Price").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                } else if (document.getElementById("tbx010104Date").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                } else {
                    Upd_Item_Question();
                };
            };
            function Upd_Item_Question() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Update Item Price',
                        'pVendor': document.getElementById("ContentPlaceHolder1_hf010104Vendor").value,
                        'pItemCode': document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value,
                        'pOrigItemCode': document.getElementById("ContentPlaceHolder1_hf010104OrigItemCode").value,
                        'pUOMCode': document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value,
                        'pPrice': document.getElementById("tbx010104Price").value,
                        'pDate': document.getElementById("tbx010104Date").value,
                        'pOrigDate': document.getElementById("ContentPlaceHolder1_hf010104OrigDate").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        fn0103Redraw("Edit", document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value, document.getElementById("ContentPlaceHolder1_hf010104Vendor").value, document.getElementById("tbx010104Date").value);
                        document.getElementById("tbx010104Item").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104Vendor").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104OrigItemCode").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104ItemCode").value = "";
                        document.getElementById("tbx010104UOM").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104UOMCode").value = "";
                        document.getElementById("tbx010104Price").value = "0.00";
                        document.getElementById("tbx010104Date").value = "";
                        document.getElementById("ContentPlaceHolder1_hf010104OrigDate").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //modal
                        $("#mdl010104Item").modal("hide");
                    }
                });
            };
        };
        function fn010104Delete(pItemCode, pVendor, pDate) {
            //access
            fnAccess('SCM060000', 'Delete', function (response) {
                if (response[0].oReturn == "1") {
                    Del_Item_Question(pItemCode, pVendor, pDate);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Del_Item_Question(pItemCode, pVendor, pDate) {
                Swal.fire({
                    text: 'Delete record?',
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
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Delete Item Price',
                                'pItemCode': pItemCode,
                                'pVendor': pVendor,
                                'pDate': pDate
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                                //Load010104Tbl(pVendor);

                                fn0103Redraw("Delete", pItemCode, pVendor, pDate);
                                //modal
                                //$("#mdl010104Tools").modal("hide");
                            }
                        });
                    }
                });
            };
            function Load010104Tbl(pVendor) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Price Update',
                        'pVendor': pVendor
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010104Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            enableCellTextSelection: true,
                            rowSelection: 'single',
                            //popupParent: document.body,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    sortable: false,
                                    resizable: false,
                                    width: 75,
                                    cellRenderer: params => params.value
                                },
                                {
                                    headerName: "ItemName",
                                    field: "ItemName",
                                    flex: 1,
                                    tooltipField: "ItemName"
                                },
                                {
                                    headerName: "UOM",
                                    field: "UMName",
                                    width: 75,
                                    tooltipField: "UMName"
                                },
                                {
                                    headerName: "Price",
                                    field: "Price",
                                    width: 150,
                                    tooltipField: "Price",
                                    cellClass: "text-end",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                },
                                {
                                    headerName: "Project",
                                    field: "Project",
                                    width: 150,
                                    tooltipField: "Project"
                                },
                                {
                                    headerName: "Date",
                                    field: "Date",
                                    tooltipField: "Date",
                                    width: 120
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25,
                            onBodyScroll: function (event) {
                                document.querySelectorAll('.toggle-menu').forEach(menu => {
                                    menu.classList.add('d-none');
                                    const parent = toggleMenuMap.get(menu);
                                    if (parent) parent.appendChild(menu);
                                    toggleMenuMap.delete(menu);
                                });

                                // Remove AG Grid highlight
                                if (gridApi) gridApi.deselectAll();
                            }
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        if (!grid010104Record) {
                            grid010104Record = gridApi;
                        };

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');
                        //close 
                        Swal.close();
                    },
                });
            }
        };
        function fn010101_SCM03TLS04() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate() {
                let purchaserList = [];
                //purchaser
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Purchaser (Employee)'
                    },
                    success: function (responsePurchaser) {
                        purchaserList = responsePurchaser;
                        let purchaserDescList = purchaserList.map(x => x.Desc);
                        //list
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Transfer Item (Purchaser)'
                            },
                            success: function (response) {
                                let gridDiv = document.querySelector('#table010105Record');
                                let gridOptions;

                                // Destroy old grid if exists
                                gridDiv.innerHTML = "";

                                gridOptions = {
                                    suppressCellFocus: true,
                                    enableCellTextSelection: true,
                                    rowSelection: 'single',
                                    //popupParent: document.body,
                                    loading: false,
                                    columnDefs: [
                                        {
                                            headerName: "PR No.",
                                            field: "PRNo",
                                            tooltipField: "PRNo"
                                        },
                                        {
                                            headerName: "No.",
                                            field: "SeqNo",
                                            width: 75,
                                            tooltipField: "SeqNo"
                                        },
                                        {
                                            headerName: "Item",
                                            field: "Item",
                                            flex: 1,
                                            tooltipField: "Item"
                                        },
                                        {
                                            headerName: "Qty.",
                                            field: "ForPOBalance",
                                            width: 150,
                                            tooltipField: "ForPOBalance",
                                            cellClass: "text-end",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                        },
                                        {
                                            headerName: "UOM",
                                            field: "Unit",
                                            width: 75,
                                            tooltipField: "Unit"
                                        },
                                        {
                                            headerName: "Purchaser",
                                            field: "Purchaser",
                                            editable: true,
                                            cellEditor: 'agSelectCellEditor',
                                            cellEditorParams: {
                                                values: purchaserDescList
                                            },
                                            valueFormatter: (params) => params.value || "Select Purchaser",
                                            onCellValueChanged: function (params) {
                                                const match = purchaserList.find(x => x.Desc === params.newValue);
                                                if (match) {
                                                    params.data.Purchaser = match.Desc;
                                                    params.data.PurchaserCode = match.Code;
                                                }
                                            }
                                        },
                                        {
                                            headerName: "Purchaser Code",
                                            field: "PurchaserCode",
                                            hide: true
                                        }
                                    ],
                                    rowData: response,
                                    pagination: false,
                                    paginationPageSize: 25,
                                    onBodyScroll: function (event) {
                                        document.querySelectorAll('.toggle-menu').forEach(menu => {
                                            menu.classList.add('d-none');
                                            const parent = toggleMenuMap.get(menu);
                                            if (parent) parent.appendChild(menu);
                                            toggleMenuMap.delete(menu);
                                        });

                                        // Remove AG Grid highlight
                                        if (gridApi) gridApi.deselectAll();
                                    }
                                };
                                gridApi = agGrid.createGrid(gridDiv, gridOptions);

                                if (!grid010105Record) {
                                    grid010105Record = gridApi;
                                };

                                //modal
                                $("#mdl010105Tools").modal("show");
                            },
                        });
                    }
                });
            };
        };
        function fn010105_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
            function Validate() {
                if (!grid010105Record) return;
                let allRows = [];
                grid010105Record.forEachNode(node => {
                    if (node.data.PurchaserCode && node.data.PurchaserCode.trim() !== "") {
                        allRows.push(node.data);
                    }
                });
                //array
                let ItemSrs = allRows
                    .map(row => row.PRNo + "©" + row.SeqNo + "©" + row.PurchaserCode)
                    .join("®");
                //validation
                if (allRows.length === 0) {
                    fnAlertOnly('Please select a Purchaser!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
                //result
                if (ItemSrs != "") Upd_Item_Purchaser(ItemSrs);
                
            };
            function Upd_Item_Purchaser(ItemSrs) {
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
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Update Item Purchaser',
                                'pItemSrs': ItemSrs
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                                //modal
                                $("#mdl010105Tools").modal("hide");
                            }
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
        };
        function fn010101_SCM03TLS05() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (CP > PO)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010106Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Cash Purchase",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForCP",
                                            tooltipField: "ForCP",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForCPBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForCPBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForCPBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010106Tools").modal("show");
                    },
                });
            };
        };
        function fn010106_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0106Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0106Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForCPBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to PO, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx06Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx06Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx06Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CPtoPO_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CPtoPO_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (CP > PO)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010106Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS05();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS06() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (CP > SR)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010107Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Cash Purchase",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForCP",
                                            tooltipField: "ForCP",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForCPBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForCPBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForCPBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010107Tools").modal("show");
                    },
                });
            };
        };
        function fn010107_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0107Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0107Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForCPBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to SR, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx07Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx07Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx07Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CPtoSR_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CPtoSR_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (CP > SR)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010107Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS06();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS07() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (PO > CP)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010108Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010108Tools").modal("show");
                    },
                });
            };
        };
        function fn010108_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0108Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0108Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForPOBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to CP, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx08Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx08Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx08Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    POtoCP_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function POtoCP_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (PO > CP)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010108Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS07();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS08() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (PO > CCC)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010109Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010109Tools").modal("show");
                    },
                });
            };
        };
        function fn010109_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0109Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0109Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForPOBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to CCC, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx09Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx09Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx09Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    POtoCCC_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function POtoCCC_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (PO > CCC)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010109Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS08();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS09() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Transfer Item (PO > CCC)'
                    },
                    success: function (response) {

                        let gridDiv = document.querySelector('#table010110Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Transfer",
                                            field: "Transfer",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Transfer", maxQty);
                                                    return false;
                                                }

                                                params.data.Transfer = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010110Tools").modal("show");
                    },
                });
            };
        };
        function fn010110_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0110Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0110Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Transfer: (row.Transfer !== undefined && row.Transfer !== null && row.Transfer !== "")
                            ? parseFloat(row.Transfer)
                            : parseFloat(row.ForPOBalance) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');

                Transfer_Question(ItemSrs, Btn);
                function Transfer_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to SR, transfer Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx10Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx10Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx10Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    POtoSR_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function POtoSR_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Transfer Item (PO > SR)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010110Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS09();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS10() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Cancel Item (PR)'
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010111Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "Date Required",
                                    field: "DateRequired",
                                    width: 150,
                                    tooltipField: "DateRequired"
                                },
                                {
                                    headerName: "Requestor",
                                    field: "Requestor",
                                    tooltipField: "Requestor",
                                    flex: 1
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for Purchase Order",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPO",
                                            tooltipField: "ForPO",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            editable: false,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Cancel",
                                            field: "Cancel",
                                            valueFormatter: params => {
                                                let value = parseFloat(params.value);
                                                if (isNaN(value)) {
                                                    value = parseFloat(params.data.ForPOBalance) || 0;
                                                }
                                                return value.toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue);
                                                if (isNaN(newValue)) newValue = 0;

                                                let maxQty = parseFloat(params.data.ForPOBalance);
                                                if (isNaN(maxQty)) maxQty = 0;

                                                if (newValue > maxQty) {
                                                    params.node.setDataValue("Cancel", maxQty);
                                                    return false;
                                                }

                                                params.data.Cancel = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end fw-bolder",
                                            width: 100
                                        }
                                    ],
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                },
                                {
                                    headerName: "Reason",
                                    field: "Reason",
                                    sortable: false,
                                    editable: true,
                                    width: 250
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010111Tools").modal("show");
                    },
                });
            };
        };
        function fn010111_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0111Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0111Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Cancel: (row.Cancel !== undefined && row.Cancel !== null && row.Cancel !== "")
                            ? parseFloat(row.Cancel)
                            : parseFloat(row.ForPOBalance) || 0,
                        Reason: (row.Reason !== undefined && row.Reason !== null && row.Reason !== "")
                            ? row.Reason
                            : "",
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Cancel}©${i.Reason}`
                ).join('®');

                Cancel_Question(ItemSrs, Btn);
                function Cancel_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be cancelled, cancel Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx11Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx11Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx11Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CancelPR_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CancelPR_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Cancel Item (PR)',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010110Tools").modal("hide");
                            //trigger
                            fn010101_SCM03TLS10();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS11() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        Load_Record(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //load record
            function Load_Record(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Cancel PO Item',
                        'pID': ID
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010112Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "No.",
                                    field: "POSeqNo",
                                    tooltipField: "POSeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "ItemName",
                                    tooltipField: "ItemName",
                                    flex: 1
                                },
                                {
                                    headerName: "Qty.",
                                    field: "Qty",
                                    tooltipField: "Qty",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    cellClass: "text-end",
                                    width: 100
                                },
                                {
                                    headerName: "Cancel",
                                    field: "Cancel",
                                    valueFormatter: params => {
                                        let value = parseFloat(params.value);
                                        if (isNaN(value)) {
                                            value = parseFloat(params.data.QtyBal) || 0;
                                        }
                                        return value.toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    valueSetter: (params) => {
                                        let newValue = parseFloat(params.newValue);
                                        if (isNaN(newValue)) newValue = 0;

                                        let maxQty = parseFloat(params.data.QtyBal);
                                        if (isNaN(maxQty)) maxQty = 0;

                                        if (newValue > maxQty) {
                                            params.node.setDataValue("Cancel", maxQty);
                                            return false;
                                        }

                                        params.data.Cancel = newValue;
                                        return true;
                                    },
                                    editable: true,
                                    cellClass: "text-end fw-bolder",
                                    width: 100
                                },
                                {
                                    headerName: "UOM",
                                    field: "Unit",
                                    tooltipField: "Unit",
                                    width: 75
                                }
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010112Tools").modal("show");
                    },
                });
            };
        };
        function fn010112_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access(Btn);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access(Btn) {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Btn.disabled = true;
                        Btn.setAttribute('data-kt-indicator', 'on');
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value, Btn);
                    } else {
                        Swal.close();
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        fn0112Add_Ok_Await(ID, Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
            function fn0112Add_Ok_Await(ID, Btn) {
                const selectedRows = gridApi.getSelectedRows();
                //Array
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRCode: ID,
                        POSeqNo: row.POSeqNo,
                        Cancel: (row.Cancel !== undefined && row.Cancel !== null && row.Cancel !== "")
                            ? parseFloat(row.Cancel)
                            : parseFloat(row.QtyBal) || 0
                    });
                });
                //Condition
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                };
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRCode}©${i.POSeqNo}©${i.Cancel}`
                ).join('®');

                Cancel_Question(ItemSrs, Btn);
                function Cancel_Question(ItemSrs, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be cancelled, cancel Item(s)?</span>',
                        icon: 'question',
                        html: `<input id="tbx12Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx12Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx12Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    CancelPO_Ok(ItemSrs, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                }
                function CancelPO_Ok(ItemSrs, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Cancel PO Item',
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            //$("#mdl010112Tools").modal("hide");
                            //trigger
                            fn0101Refresh();
                            fn010101_SCM03TLS11();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS12() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Open', function (response) {
                    if (response[0].oReturn == "") {
                        Load_Modal(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //modal
            function Load_Modal(ID) {
                document.getElementById("tbx010113Reason").value = "";
                $("#mdl010113Tools").modal("show");
            };
        };
        function fn010113_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access(Btn);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access(Btn) {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Btn.disabled = true;
                        Btn.setAttribute('data-kt-indicator', 'on');
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value, Btn);
                    } else {
                        Swal.close();
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Open', function (response) {
                    if (response[0].oReturn == "") {
                        fn010113Add_Ok_Await(ID, Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            }
            function fn010113Add_Ok_Await(ID, Btn) {
                if (document.getElementById("tbx010113Reason").value == "") {
                    fnAlertOnly("Some fields are missing!", 'warning', 'btn btn-warning');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                } else {
                    //swal
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Re-Open Record?</span>',
                        icon: 'question',
                        html: `<input id="tbx13Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx13Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx13Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    ReOpenPO_Ok(ID, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                };
                function ReOpenPO_Ok(ID, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Re-Open PO',
                            'pID': ID,
                            'pRemarks': document.getElementById("tbx010113Reason").value
                        },
                        success: function (response) {
                            fnAlertOnly('Request for re-open successfully updated.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            document.getElementById("tbx010113Reason").value = "";
                            $("#mdl010101Tools").modal("hide");
                            $("#mdl010113Tools").modal("hide");
                            //trigger
                            fn0101Refresh();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS13() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                //access
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Printing', function (response) {
                    if (response[0].oReturn == "") {
                        Load_Modal(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //modal
            function Load_Modal(ID) {
                document.getElementById("tbx010114PersonalRemarks").value = "";
                $("#mdl010114Tools").modal("show");
            };
        };
        function fn010114_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access(Btn);
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access(Btn) {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Btn.disabled = true;
                        Btn.setAttribute('data-kt-indicator', 'on');
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value, Btn);
                    } else {
                        Swal.close();
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            };
            function Validate(ID, Btn) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'for Re-Printing', function (response) {
                    if (response[0].oReturn == "") {
                        fn010114Add_Ok_Await(ID, Btn);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        Btn.disabled = false;
                        Btn.removeAttribute('data-kt-indicator');
                    };
                });
            }
            function fn010114Add_Ok_Await(ID, Btn) {
                if (document.getElementById("tbx010114PersonalRemarks").value == "") {
                    fnAlertOnly("Some fields are missing!", 'warning', 'btn btn-warning');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                } else {
                    //swal
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Re-Print Record?</span>',
                        icon: 'question',
                        html: `<input id="tbx14Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        didOpen: () => {
                            const input = document.getElementById("tbx14Password");
                            input.focus();
                            input.addEventListener("keydown", function (e) {
                                if (e.key === "Enter") {
                                    Swal.clickConfirm();
                                }
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
                            fnValidatePassword(document.getElementById("tbx14Password").value, function (response) {
                                if (response[0].oReturn == "") {
                                    RePrintPO_Ok(ID, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    });
                };
                function RePrintPO_Ok(ID, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Update Re-Print PO',
                            'pID': ID,
                            'pRemarks': document.getElementById("tbx010114PersonalRemarks").value
                        },
                        success: function (response) {
                            fnAlertOnly('Request for re-printing successfully updated.', 'success', 'btn btn-success');
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = true;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            document.getElementById("tbx010113Reason").value = "";
                            $("#mdl010101Tools").modal("hide");
                            $("#mdl010114Tools").modal("hide");
                            //trigger
                            fn0101Refresh();
                        }
                    });
                }
            }
        };
        function fn010101_SCM03TLS14() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Online Tagging',
                        'pPONoFrom': '',
                        'pPONoTo': '',
                        'pPODateFrom': '',
                        'pPODateTo': ''
                    },
                    success: function (response) {
                        let gridDiv = document.querySelector('#table010115Record');
                        let gridOptions;

                        // Destroy old grid if exists
                        gridDiv.innerHTML = "";

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "PO No.",
                                    field: "PONo",
                                    tooltipField: "PONo",
                                    width: 150
                                },
                                {
                                    headerName: "PO Date",
                                    field: "PODate",
                                    width: 150,
                                    tooltipField: "PODate"
                                },
                                {
                                    headerName: "Vendor",
                                    field: "Vendor",
                                    tooltipField: "Vendor",
                                    flex: 1
                                },
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    tooltipField: "Status",
                                    width: 75
                                },
                                {
                                    headerName: "Online Ref. No.",
                                    field: "OnlineReferenceNo",
                                    sortable: false,
                                    editable: true,
                                    width: 250
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        //modal
                        $("#mdl010115Tools").modal("show");
                    },
                });
            };
        };
        function fn010115Filter() {
            document.getElementById("tbx010115PONoFrom").value = "";
            document.getElementById("tbx010115PONoTo").value = "";
            document.getElementById("tbx010115DateFrom").value = "";
            document.getElementById("tbx010115DateTo").value = "";
            $("#mdl010115Filter").modal("show");
        };
        function fn010115Filter_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            Filter_Ok();
            //function
            async function Filter_Ok() {
                await Filter_Ok_Await(Btn);
            };
            async function Filter_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Purchase Order - Online Tagging',
                            'pPONoFrom': document.getElementById("tbx010115PONoFrom").value,
                            'pPONoTo': document.getElementById("tbx010115PONoTo").value,
                            'pPODateFrom': document.getElementById("tbx010115DateFrom").value,
                            'pPODateTo': document.getElementById("tbx010115DateTo").value
                        },
                        success: function (response) {
                            let gridDiv = document.querySelector('#table010115Record');
                            let gridOptions;

                            // Destroy old grid if exists
                            gridDiv.innerHTML = "";

                            gridOptions = {
                                suppressCellFocus: true,
                                loading: false,
                                rowSelection: 'multiple',
                                suppressRowClickSelection: true,
                                columnDefs: [
                                    {
                                        headerName: "PO No.",
                                        field: "PONo",
                                        tooltipField: "PONo",
                                        width: 150
                                    },
                                    {
                                        headerName: "PO Date",
                                        field: "PODate",
                                        width: 150,
                                        tooltipField: "PODate"
                                    },
                                    {
                                        headerName: "Vendor",
                                        field: "Vendor",
                                        tooltipField: "Vendor",
                                        flex: 1
                                    },
                                    {
                                        headerName: "Status",
                                        field: "Status",
                                        tooltipField: "Status",
                                        width: 150
                                    },
                                    {
                                        headerName: "Online Ref. No.",
                                        field: "OnlineReferenceNo",
                                        sortable: false,
                                        editable: true,
                                        width: 250
                                    },
                                ],
                                rowData: response,
                                pagination: false,
                                paginationPageSize: 25
                            };
                            gridApi = agGrid.createGrid(gridDiv, gridOptions);

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            //clear
                            document.getElementById("tbx010115PONoFrom").value = "";
                            document.getElementById("tbx010115PONoTo").value = "";
                            document.getElementById("tbx010115DateFrom").value = "";
                            document.getElementById("tbx010115DateTo").value = "";

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //modal
                            $("#mdl010115Filter").modal("hide");
                        },
                    });
                });
            };
        };
        function fn010115Export() {
            if (gridApi) {
                gridApi.exportDataAsCsv({
                    fileName: 'Purhase Order - Online Monitoring.csv',
                    columnKeys: ['PONo', 'PODate', 'Vendor', 'Status', 'OnlineReferenceNo']
                });
            }
        }
        function fn010101_SCM03RPT04() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById("ContentPlaceHolder1_hdnID").value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PR Printout',
                        'pID': ID
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT05() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById("ContentPlaceHolder1_hdnID").value);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PO Printout',
                        'pID': ID
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                            if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                            //trigger
                            fn0101Refresh();
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT06() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - For (PO)'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT07() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - For (CP)'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT08() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Price History'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT09() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PO Movement',
                        'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT10() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Pending PR'
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn010101_SCM03RPT11() {
            //access
            fnAccess('SCM060000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //validate
            function Validate() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Receiving History',
                        'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                    },
                    success: function (response) {
                        if (response.status === "success") {
                            window.open(response.viewUrl, '_blank');
                        } else {
                            fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                        };
                    },
                });
            };
        };
        function fn0101Open() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Open', function (response) {
                    if (response[0].oReturn == "") {
                        ReOpen_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function ReOpen_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Re-Open record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101ReOpenPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx0101ReOpenPassword");
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
                        fnValidatePassword(document.getElementById("tbx0101ReOpenPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Open', function (response) {
                                    if (response[0].oReturn == "") {
                                        ReOpen_Ok(ID);
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
            function ReOpen_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM060100",
                        'Type': "Purchase Order - Re-Open Record",
                        'pID': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            }
        };
        function fn0101RePrint() {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Print', function (response) {
                    if (response[0].oReturn == "") {
                        RePrint_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function RePrint_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Re-Print record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101RePrintPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    didOpen: () => {
                        const input = document.getElementById("tbx0101RePrintPassword");
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
                        fnValidatePassword(document.getElementById("tbx0101RePrintPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Re-Print', function (response) {
                                    if (response[0].oReturn == "") {
                                        RePrint_Ok(ID);
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
            function RePrint_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM060100",
                        'Type': "Purchase Order - Re-Print Record",
                        'pID': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            }
        };
        //overview

        //particular
        function fn0102LoadParticular(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Purchase Order - Get Record : Particular',
                    'pID': pID
                },
                success: function (response) {
                    try {
                        //display loader
                        document.getElementById("div0102LoaderParticular").style.display = "";
                        //display loader

                        //$('#table0102Particular').DataTable().destroy();
                        if ($.fn.DataTable.isDataTable('#table0102Particular')) {
                            $('#table0102Particular').DataTable().clear().destroy();
                        }

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
                            rowCallback: function (row, data, index) {
                                if (index % 2 === 0) {
                                    $(row).css('background-color', '#f0f9ff');
                                } else {
                                    $(row).css('background-color', '#ffffff');
                                }
                            },
                            columns: [
                                { data: 'Action' },
                                { data: 'ChangeItem' },
                                { data: 'ChangeQty' },
                                { data: 'ItemName' },
                                { data: 'Qty' },
                                { data: 'UMName' },
                                { data: 'Cost' },
                                { data: 'Total' },
                                { data: 'Classification' },
                                { data: 'Commodity' },
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
                                    targets: [0, 1, 2],
                                    orderable: false
                                },
                                {
                                    targets: [4, 6, 7, 14],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                },
                                {
                                    targets: [3, 8, 9, 10, 13],
                                    className: 'tbody-nowrap-auto'
                                }
                            ],
                            initComplete: function () {
                                this.api().cells().every(function () {
                                    var cell = this.node();
                                    $(cell).attr('title', $(cell).text());
                                });
                            },
                            createdRow: function (row, data, dataIndex) {
                                $(row).css('cursor', 'pointer');
                            },
                            footerCallback: function (row, data, start, end, display) {
                                var api = this.api();

                                function sumColumn(colIndex) {
                                    return api.column(colIndex, { search: 'applied' }).data().reduce(function (a, b) {
                                        return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                                    }, 0);
                                };

                                //variable
                                var totQty = sumColumn(4);
                                var totCost = sumColumn(6);
                                var totTotal = sumColumn(7);
                                var totPRQty = sumColumn(14);

                                //Qty
                                $(api.column(4).footer()).html(totQty.toLocaleString("en-US", { minimumFractionDigits: 2 }));

                                //Cost
                                $(api.column(6).footer()).html(totCost.toLocaleString("en-US", { minimumFractionDigits: 2 }));

                                //Total
                                $(api.column(7).footer()).html(totTotal.toLocaleString("en-US", { minimumFractionDigits: 2 }));

                                //Qty
                                $(api.column(14).footer()).html(totPRQty.toLocaleString("en-US", { minimumFractionDigits: 2 }));

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
                    } catch (err) {
                        console.error('Error initializing DataTable:', err);
                    };
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
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Record : Particular - Redraw',
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
                                    ChangeItem: item.ChangeItem,
                                    ChangeQty: item.ChangeQty,
                                    ItemName: item.ItemName,
                                    Qty: item.Qty,
                                    UMName: item.UMName,
                                    Cost: item.Cost,
                                    Total: item.Total,
                                    Classification: item.Classification,
                                    Commodity: item.Commodity,
                                    Remarks: item.Remarks,
                                    PRNo: item.PRNo,
                                    PRSeqNo: item.PRSeqNo,
                                    PRItem: item.PRItem,
                                    PRQty: item.PRQty,
                                    PRUnit: item.PRUnit,
                                    SeqNo: item.SeqNo
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
                            gv01.cell({ row: index01, column: 1 }).data(response[0].ChangeItem).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].ChangeQty).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].ItemName).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].Qty).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].UMName).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].Cost).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].Total).draw(false);
                            gv01.cell({ row: index01, column: 8 }).data(response[0].Classification).draw(false);
                            gv01.cell({ row: index01, column: 9 }).data(response[0].Commodity).draw(false);
                            gv01.cell({ row: index01, column: 10 }).data(response[0].Remarks).draw(false);
                            gv01.cell({ row: index01, column: 11 }).data(response[0].PRNo).draw(false);
                            gv01.cell({ row: index01, column: 12 }).data(response[0].PRSeqNo).draw(false);
                            gv01.cell({ row: index01, column: 13 }).data(response[0].PRItem).draw(false);
                            gv01.cell({ row: index01, column: 14 }).data(response[0].PRQty).draw(false);
                            gv01.cell({ row: index01, column: 15 }).data(response[0].PRUnit).draw(false);
                            gv01.cell({ row: index01, column: 16 }).data(response[0].SeqNo).draw(false);
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
            }
        };
        //function fn0103Redraw(Action, pItemCode, pVendor, pDate) {
        //    if (!grid010104Record) return;

        //    if (Action === "Add" || Action === "Edit") {
        //        $.ajax({
        //            type: "POST",
        //            url: "HNDSCM.ashx",
        //            data: {
        //                'FormCode': 'SCM060100',
        //                'Type': 'Purchase Order - Update Item Price : Redraw',
        //                'pItemCode': pItemCode,
        //                'pVendor': pVendor,
        //                'pDate': pDate
        //            },
        //            success: function (response) {
        //                const record = response[0];
        //                if (!record) return;

        //                const newRecord = { ...record };

        //                if (Action === "Add") {
        //                    const result = grid010104Record.applyTransaction({
        //                        add: [newRecord],
        //                        addIndex: 0
        //                    });

        //                    const node = result.add[0];
        //                    if (node) {
        //                        grid010104Record.flashCells({ rowNodes: [node] });
        //                        node.setSelected(true);
        //                        grid010104Record.ensureNodeVisible(node, 'top');
        //                    }

        //                } else if (Action === "Edit") {
        //                    grid010104Record.applyTransaction({ update: [newRecord] });

        //                    // Move to top visually if needed
        //                    grid010104Record.applyTransaction({
        //                        remove: [newRecord],
        //                        add: [newRecord],
        //                        addIndex: 0
        //                    });

        //                    const topNode = grid010104Record.getDisplayedRowAtIndex(0);
        //                    grid010104Record.flashCells({ rowNodes: [topNode] });
        //                    topNode.setSelected(true);
        //                    grid010104Record.ensureNodeVisible(topNode, 'top');
        //                }
        //            }
        //        });
        //    } else {
        //        // Remove record
        //        grid010104Record.forEachNode(function (node) {
        //            if (node.data.ItemCode === pItemCode && node.data.Vendor === pVendor && node.data.Date === pDate) {
        //                grid010104Record.applyTransaction({ remove: [node.data] });
        //            }
        //        });
        //    }
        //};
        function fn0103Redraw(Action, pItemCode, pVendor, pDate) {
            if (!grid010104Record) return;

            if (Action === "Add" || Action === "Edit") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Update Item Price : Redraw',
                        'pItemCode': pItemCode,
                        'pVendor': pVendor,
                        'pDate': pDate
                    },
                    success: function (response) {
                        const record = response[0];
                        if (!record) return;

                        const newRecord = { ...record }; // shallow clone

                        if (Action === "Add" || Action === "Edit") {
                            // Remove old row if exists (for Edit)
                            grid010104Record.forEachNode(function (node) {
                                if (node.data.ItemCode === pItemCode &&
                                    node.data.Vendor === pVendor &&
                                    node.data.Date === pDate) {
                                    grid010104Record.applyTransaction({ remove: [node.data] });
                                }
                            });

                            // Add new/updated record at top
                            const result = grid010104Record.applyTransaction({
                                add: [newRecord],
                                addIndex: 0
                            });

                            const node = result.add[0];
                            if (node) {
                                grid010104Record.flashCells({ rowNodes: [node] });
                                node.setSelected(true);
                                grid010104Record.ensureNodeVisible(node, 'top');
                            }
                        }
                    }
                });
            } else if (Action === "Delete") {
                // Remove record
                grid010104Record.forEachNode(function (node) {
                    if (node.data.ItemCode === pItemCode &&
                        node.data.Vendor === pVendor &&
                        node.data.Date === pDate) {
                        grid010104Record.applyTransaction({ remove: [node.data] });
                    }
                });
            }
        };

        function fn0102AddRecord() {
            //if exist
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Add() {
                document.getElementById("cbxChangeItemAdd0102").checked = false;
                document.getElementById("cbxChangeQtyAdd0102").checked = false;
                document.getElementById("tbx0102AddItem").value = "";
                document.getElementById("ContentPlaceHolder1_hf0102AddItemCode").value = "";
                document.getElementById("tbx0102AddQty").value = "0.00";
                document.getElementById("tbx0102AddUOM").value = "";
                document.getElementById("ContentPlaceHolder1_hf0102AddUOMCode").value = "";
                document.getElementById("tbx0102AddCost").value = "0.00";
                document.getElementById("tbx0102AddTotal").value = "0.00";
                document.getElementById("tbx0102AddCanvass").value = "0.00";
                ddl0102Commodity('');
                $('#ddl0102AddStrategy').val('').trigger('change');
                ddl0102OSMCode('');
                $('#ddl0102AddStandard').val('').trigger('change');
                $('#ddl0102AddLeadStandard').val('').trigger('change');
                document.getElementById("tbx0102AddRemarks").value = "";
                //modal
                $('#mdl0102Add').modal('show');
            };
            function ddl0102Commodity(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Classification',
                        'pPlaceHolder': 'Commodity',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0102AddCommodity").html(s);
                        $('#ddl0102AddCommodity').val(ID).trigger('change');
                    },
                });
            };
            function ddl0102OSMCode(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_OSMCodes',
                        'pPlaceHolder': 'Code',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0102AddOSMCode").html(s);
                        $('#ddl0102AddOSMCode').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn010200Add_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID, SeqNo) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                    if (document.getElementById("tbx0102AddItem").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0102AddQty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0102AddCost").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0102AddCommodity").options[document.getElementById("ddl0102AddCommodity").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0102AddStrategy").options[document.getElementById("ddl0102AddStrategy").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0102AddOSMCode").options[document.getElementById("ddl0102AddOSMCode").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0102AddStandard").options[document.getElementById("ddl0102AddStandard").selectedIndex].value == "") {
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
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                    //add
                    function Add_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "HNDSCM.ashx",
                            data: {
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Add Record : Particular',
                                'pID': ID,
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf0102AddItemCode").value,
                                'pQty': document.getElementById("tbx0102AddQty").value,
                                'pUMCode': document.getElementById("ContentPlaceHolder1_hf0102AddUOMCode").value,
                                'pCost': document.getElementById("tbx0102AddCost").value,
                                'pTotal': document.getElementById("tbx0102AddTotal").value,
                                'pCanvass': document.getElementById("tbx0102AddCanvass").value,
                                'pCommodity': document.getElementById("ddl0102AddCommodity").options[document.getElementById("ddl0102AddCommodity").selectedIndex].value,
                                'pStrategy': document.getElementById("ddl0102AddStrategy").options[document.getElementById("ddl0102AddStrategy").selectedIndex].value,
                                'pOSMCode': document.getElementById("ddl0102AddOSMCode").options[document.getElementById("ddl0102AddOSMCode").selectedIndex].value,
                                'pStdrdType': document.getElementById("ddl0102AddStandard").options[document.getElementById("ddl0102AddStandard").selectedIndex].value,
                                'pLdType': document.getElementById("ddl0102AddLeadStandard").options[document.getElementById("ddl0102AddLeadStandard").selectedIndex].value,
                                'pRemarks': document.getElementById("tbx0102AddRemarks").value
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully added.', 'success', 'btn btn-success');
                                document.getElementById("tbx0102AddItem").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0102AddItemCode").value = "";
                                document.getElementById("tbx0102AddQty").value = "0.00";
                                document.getElementById("tbx0102AddUOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0102AddUOMCode").value = "";
                                document.getElementById("tbx0102AddCost").value = "0.00";
                                document.getElementById("tbx0102AddTotal").value = "0.00";
                                document.getElementById("tbx0102AddCanvass").value = "0.00";
                                $('#ddl0102AddCommodity').val('').trigger('change');
                                $('#ddl0102AddStrategy').val('').trigger('change');
                                $('#ddl0102AddOSMCode').val('').trigger('change');
                                $('#ddl0102AddStandard').val('').trigger('change');
                                $('#ddl0102AddLeadStandard').val('').trigger('change');
                                document.getElementById("tbx0102AddRemarks").value = "";
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
        function fn0102AddItem() {
            let gridDiv = document.querySelector('#table010301Item');
            let gridOptions;

            // Destroy old grid if exists
            gridDiv.innerHTML = "";

            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    FormCode: 'SCM060100',
                    Type: 'Purchase Order - Get Record : Item',
                },
                beforeSend: function () {
                    // Show modal
                    $('#mdl0103Item').modal('show');

                    // Show Swal loader
                    Swal.fire({
                        title: 'Loading...',
                        text: 'Please wait while data is being processed.',
                        allowOutsideClick: false,
                        allowEscapeKey: false, 
                        allowEnterKey: false, 
                        didOpen: () => {
                            Swal.showLoading();
                        }
                    });
                },
                dataType: "json",
                success: function (response) {
                    
                    gridOptions = {
                        suppressCellFocus: true,
                        loading: false,
                        columnDefs: [
                            {
                                headerName: "Action", 
                                field: "Action",
                                width: 75,
                                resizable: false,
                                sortable: false,
                                cellRenderer: params => params.value,
                                cellClass: "mt-1"
                            },
                            {
                                headerName: "Code",
                                field: "Code",
                                width: 150,
                                tooltipField: "Code"
                            },
                            {
                                headerName: "Lock",
                                field: "Lock",
                                width: 75,
                                resizable: false,
                                cellRenderer: params => params.value,
                                cellClass: "mt-3"
                            },
                            {
                                headerName: "Item Name",
                                field: "ItemName",
                                tooltipField: "ItemName",
                                flex: 1
                            },
                            {
                                headerName: "UM",
                                field: "UMName",
                                width: 75,
                                tooltipField: "UMName"
                            },
                            {
                                headerName: "Cost",
                                field: "Cost",
                                valueFormatter: params => {
                                    if (params.value == null || params.value === "") return "";
                                    return Number(params.value).toLocaleString("en-US", {
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                    });
                                },
                                cellClass: "text-end",
                                tooltipField: "Cost"
                            },
                            {
                                headerName: "Canvass",
                                field: "Canvass",
                                valueFormatter: params => {
                                    if (params.value == null || params.value === "") return "";
                                    return Number(params.value).toLocaleString("en-US", {
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                    });
                                },
                                cellClass: "text-end",
                                tooltipField: "Canvass"
                            },
                            {
                                headerName: "Date Encoded",
                                field: "DateEncoded",
                                valueFormatter: params => {
                                    if (!params.value) return "";
                                    const date = new Date(params.value);
                                    return date.toLocaleDateString("en-US", {
                                        year: "numeric",
                                        month: "2-digit",
                                        day: "2-digit"
                                    });
                                },
                                width: 125,
                                tooltipField: "DateEncoded"
                            },
                            {
                                headerName: "Vendor",
                                field: "VenName",
                                tooltipField: "VenName",
                                flex: 1
                            }
                        ],
                        rowData: response,
                        pagination: true,
                        paginationPageSize: 25
                    };
                    gridApi = agGrid.createGrid(gridDiv, gridOptions);

                    // close Swal loader when everything is done
                    Swal.close();
                }
            });

        };
        function onFilter() {
            gridApi.setGridOption(
                "quickFilterText",
                document.getElementById("tbx010301Find").value,
            );
        };
        function fn010201ItemCode(pItemName, pItemCode, pUMName, pUMCode, pCost, pCanvass, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemName, pItemCode, pUMName, pUMCode, pCost, pCanvass);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemName, pItemCode, pUMName, pUMCode, pCost, pCanvass) {
                document.getElementById("tbx0102AddItem").value = pItemName;
                document.getElementById("ContentPlaceHolder1_hf0102AddItemCode").value = pItemCode;
                document.getElementById("tbx0102AddUOM").value = pUMName;
                document.getElementById("ContentPlaceHolder1_hf0102AddUOMCode").value = pUMCode;
                document.getElementById("tbx0102AddCost").value = formatNumber(pCost);
                fnFormatNumberAddCost(document.getElementById("tbx0102AddCost"));
                document.getElementById("tbx0102AddCanvass").value = formatNumber(pCanvass);

                //modal
                $("#mdl0103Item").modal("hide");
            };
        };
        function fn0102Delete(pID, pSeqNo) {
            //if exist
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Delete', function (response) {
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
                        fnValidateRecord('Trxn_POHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
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
                        'FormCode': 'SCM060100',
                        'Type': 'Delete Record - DTL - Particular',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        fn0102Redraw("", pID, pSeqNo);
                    },
                });
            };
        };
        $('#table0102Particular tbody').on('dblclick', 'tr', function () {
            var table = $('#table0102Particular').DataTable();
            var rowData = table.row(this).data();
            if (rowData && rowData.SeqNo) {
                fn0102Edit(document.getElementById("ContentPlaceHolder1_hdnID").value, rowData.SeqNo);
            };
        });
        function fn0102Edit(pID, pSeqNo) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - Get Record : Update Particular',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        document.getElementById("cbxChangeItemUpd0104").checked = response[0].ChangeItem;
                        document.getElementById("cbxChangeQtyUpd0104").checked = response[0].ChangeQty;
                        document.getElementById("tbx0104UpdItem").value = response[0].ItemName;
                        document.getElementById("ContentPlaceHolder1_hf0104UpdItemCode").value = response[0].ItemCode;
                        document.getElementById("ContentPlaceHolder1_hf0104UpdSeqNo").value = pSeqNo;
                        document.getElementById("tbx0104UpdQty").value = formatNumber(response[0].Qty);
                        document.getElementById("tbx0104UpdUOM").value = response[0].UMName;
                        document.getElementById("ContentPlaceHolder1_hf0104UpdUOMCode").value = response[0].UMCode;
                        document.getElementById("tbx0104UpdCost").value = formatNumber(response[0].Cost);
                        document.getElementById("tbx0104UpdTotal").value = formatNumber(response[0].Total);
                        document.getElementById("tbx0104UpdCanvass").value = formatNumber(response[0].Canvass);
                        ddl0104Commodity(response[0].ICCode);
                        $('#ddl0104UpdStrategy').val(response[0].Commodity).trigger('change');
                        ddl0104OSMCode(response[0].OSMCode);
                        $('#ddl0104UpdStandard').val(response[0].StandardType).trigger('change');
                        $('#ddl0104UpdLeadStandard').val(response[0].LeadTimeType).trigger('change');
                        document.getElementById("tbx0104UpdRemarks").value = response[0].Remarks;
                        document.getElementById("tbx0104UpdPRNo").value = response[0].PRNo;
                        document.getElementById("tbx0104UpdPRSeqNo").value = response[0].PRSeqNo;
                        document.getElementById("tbx0104UpdPRItem").value = response[0].PRItem;
                        document.getElementById("tbx0104UpdPRQty").value = formatNumber(response[0].PRQty);
                        document.getElementById("tbx0104UpdPRUOM").value = response[0].PRUnit;
                        //modal
                        $('#mdl0104Edit').modal('show');
                    },
                });
            };
            function ddl0104Commodity(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Classification',
                        'pPlaceHolder': 'Commodity',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0104UpdCommodity").html(s);
                        $('#ddl0104UpdCommodity').val(ID).trigger('change');
                    },
                });
            };
            function ddl0104OSMCode(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_OSMCodes',
                        'pPlaceHolder': 'Code',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0104UpdOSMCode").html(s);
                        $('#ddl0104UpdOSMCode').val(ID).trigger('change');
                    },
                });
            };
        };
        function cbxChangeQtyUpd0104_onclick(input) {
            if (input.checked) {
                $('#tbx0104UpdQty').prop('readonly', false);
            } else {
                $('#tbx0104UpdQty').prop('readonly', true);
            }
        };
        function fn010400Edit_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                    if (document.getElementById("tbx0104UpdItem").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0104UpdQty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0104UpdCost").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0104UpdCommodity").options[document.getElementById("ddl0104UpdCommodity").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0104UpdStrategy").options[document.getElementById("ddl0104UpdStrategy").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0104UpdOSMCode").options[document.getElementById("ddl0104UpdOSMCode").selectedIndex].value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("ddl0104UpdStandard").options[document.getElementById("ddl0104UpdStandard").selectedIndex].value == "") {
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
                                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
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
                                'FormCode': 'SCM060100',
                                'Type': 'Purchase Order - Edit Record : Particular',
                                'pID': ID,
                                'pSeqNo': document.getElementById("ContentPlaceHolder1_hf0104UpdSeqNo").value,
                                'pChangeItem': document.getElementById("cbxChangeItemUpd0104").checked,
                                'pChangeQty': document.getElementById("cbxChangeQtyUpd0104").checked,
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf0104UpdItemCode").value,
                                'pQty': document.getElementById("tbx0104UpdQty").value,
                                'pUMCode': document.getElementById("ContentPlaceHolder1_hf0104UpdUOMCode").value,
                                'pCost': document.getElementById("tbx0104UpdCost").value,
                                'pTotal': document.getElementById("tbx0104UpdTotal").value,
                                'pCanvass': document.getElementById("tbx0104UpdCanvass").value,
                                'pCommodity': document.getElementById("ddl0104UpdCommodity").options[document.getElementById("ddl0104UpdCommodity").selectedIndex].value,
                                'pStrategy': document.getElementById("ddl0104UpdStrategy").options[document.getElementById("ddl0104UpdStrategy").selectedIndex].value,
                                'pOSMCode': document.getElementById("ddl0104UpdOSMCode").options[document.getElementById("ddl0104UpdOSMCode").selectedIndex].value,
                                'pStandardType': document.getElementById("ddl0104UpdStandard").options[document.getElementById("ddl0104UpdStandard").selectedIndex].value,
                                'pLeadType': document.getElementById("ddl0104UpdLeadStandard").options[document.getElementById("ddl0104UpdLeadStandard").selectedIndex].value,
                                'pRemarks': document.getElementById("tbx0104UpdRemarks").value
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx0104UpdItem").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0104UpdSeqNo").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0104UpdItemCode").value = "";
                                document.getElementById("tbx0104UpdQty").value = "0.00";
                                document.getElementById("tbx0104UpdUOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf0104UpdUOMCode").value = "";
                                document.getElementById("tbx0104UpdCost").value = "0.00";
                                document.getElementById("tbx0104UpdTotal").value = "0.00";
                                document.getElementById("tbx0104UpdCanvass").value = "0.00";
                                $('#ddl0104UpdCommodity').val('').trigger('change');
                                $('#ddl0104UpdStrategy').val('').trigger('change');
                                $('#ddl0104UpdOSMCode').val('').trigger('change');
                                $('#ddl0104UpdStandard').val('').trigger('change');
                                $('#ddl0104UpdLeadStandard').val('').trigger('change');
                                document.getElementById("tbx0104UpdRemarks").value = "";
                                fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                            },
                        });
                        //modal
                        $('#mdl0104Edit').modal('hide');
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
        function fn0104UpdItem() {
            if (document.getElementById("cbxChangeItemUpd0104").checked) {
                let gridDiv = document.querySelector('#table010401Item');
                let gridOptions;

                // Destroy old grid if exists
                gridDiv.innerHTML = "";

                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        FormCode: 'SCM060100',
                        Type: 'Purchase Order - Get Record : Update Item',
                    },
                    beforeSend: function () {
                        // Show modal
                        $('#mdl0104Item').modal('show');

                        // Show Swal loader
                        Swal.fire({
                            title: 'Loading...',
                            text: 'Please wait while data is being processed.',
                            allowOutsideClick: false,
                            allowEscapeKey: false,
                            allowEnterKey: false,
                            didOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    dataType: "json",
                    success: function (response) {

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "Action",
                                    width: 75,
                                    cellRenderer: params => params.value,
                                    cellClass: "mt-1"
                                },
                                {
                                    headerName: "Code",
                                    field: "Code",
                                    width: 150,
                                    tooltipField: "Code"
                                },
                                {
                                    headerName: "Lock",
                                    field: "Lock",
                                    width: 75,
                                    cellRenderer: params => params.value,
                                    cellClass: "mt-3"
                                },
                                {
                                    headerName: "Item Name",
                                    field: "ItemName",
                                    tooltipField: "ItemName",
                                    flex: 1
                                },
                                {
                                    headerName: "UM",
                                    field: "UMName",
                                    width: 75,
                                    tooltipField: "UMName"
                                },
                                {
                                    headerName: "Cost",
                                    field: "Cost",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    cellClass: "text-end",
                                    tooltipField: "Cost"
                                },
                                {
                                    headerName: "Canvass",
                                    field: "Canvass",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    cellClass: "text-end",
                                    tooltipField: "Canvass"
                                },
                                {
                                    headerName: "Date Encoded",
                                    field: "DateEncoded",
                                    valueFormatter: params => {
                                        if (!params.value) return "";
                                        const date = new Date(params.value);
                                        return date.toLocaleDateString("en-US", {
                                            year: "numeric",
                                            month: "2-digit",
                                            day: "2-digit"
                                        });
                                    },
                                    width: 125,
                                    tooltipField: "DateEncoded"
                                },
                                {
                                    headerName: "Vendor",
                                    field: "VenName",
                                    tooltipField: "VenName",
                                    flex: 1
                                }
                            ],
                            rowData: response,
                            pagination: true,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        // close
                        Swal.close();
                    }
                });
            };
        };
        function onUpdFilter() {
            gridApi.setGridOption(
                "quickFilterText",
                document.getElementById("tbx010401Find").value,
            );
        };
        function onAddPRFilter(){
            gridApi.setGridOption(
                "quickFilterText",
                document.getElementById("tbx010501Find").value,
            );
        };
        function fn010401ItemCode(pItemName, pItemCode, pUMName, pUMCode, pCost, pCanvass, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemName, pItemCode, pUMName, pUMCode, pCost, pCanvass);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemName, pItemCode, pUMName, pUMCode, pCost, pCanvass) {
                document.getElementById("tbx0104UpdItem").value = pItemName;
                document.getElementById("ContentPlaceHolder1_hf0104UpdItemCode").value = pItemCode;
                document.getElementById("tbx0104UpdUOM").value = pUMName;
                document.getElementById("ContentPlaceHolder1_hf0104UpdUOMCode").value = pUMCode;
                document.getElementById("tbx0104UpdCost").value = formatNumber(pCost);
                fnFormatNumberUpdCost(document.getElementById("tbx0104UpdCost"));
                document.getElementById("tbx0104UpdCanvass").value = formatNumber(pCanvass);

                //modal
                $("#mdl0104Item").modal("hide");
            };
        };
        function fn0102AddRecordPR() {
            //if exist
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_POHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {

                let gridDiv = document.querySelector('#table010501Item');
                let gridOptions;

                // Destroy old grid if exists
                gridDiv.innerHTML = "";

                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        FormCode: 'SCM060100',
                        Type: 'Purchase Order - Get Record : Particular PR',
                    },
                    dataType: "json",
                    success: function (response) {

                        gridOptions = {
                            suppressCellFocus: true,
                            loading: false,
                            rowSelection: 'multiple',
                            suppressRowClickSelection: true,
                            columnDefs: [
                                {
                                    headerName: "Action",
                                    field: "isChecked",
                                    resizable: false,
                                    sortable: false,
                                    width: 75,
                                    checkboxSelection: true
                                },
                                {
                                    headerName: "Date Approved",
                                    field: "DateApproved",
                                    width: 150,
                                    tooltipField: "DateApproved"
                                },
                                {
                                    headerName: "PR No.",
                                    field: "PRNo",
                                    tooltipField: "PRNo",
                                    width: 150
                                },
                                {
                                    headerName: "No.",
                                    field: "SeqNo",
                                    tooltipField: "SeqNo",
                                    width: 75
                                },
                                {
                                    headerName: "Item",
                                    field: "Item",
                                    tooltipField: "Item",
                                    flex: 1
                                },
                                {
                                    headerName: "for PO",
                                    field: "ForPO",
                                    tooltipField: "ForPO",
                                    valueFormatter: params => {
                                        if (params.value == null || params.value === "") return "";
                                        return Number(params.value).toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });
                                    },
                                    cellClass: "text-end",
                                    tooltipField: "ForPO",
                                    width: 100
                                },
                                {
                                    headerName: "for PO",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForPOBalance",
                                            tooltipField: "ForPOBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "Purchase",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue) || 0;
                                                let maxQty = parseFloat(params.data.ForPOBalance) || 0;

                                                if (newValue > maxQty) {
                                                    params.data.Purchase = maxQty;
                                                    params.node.setDataValue("Purchase", maxQty);
                                                    return false;
                                                }

                                                params.data.Purchase = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Process",
                                            field: "ForCP",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                    ],
                                },
                                {
                                    headerName: "for Cash Purchase",
                                    children: [
                                        {
                                            headerName: "Qty.",
                                            field: "ForCPBalance",
                                            tooltipField: "ForCPBalance",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Balance",
                                            field: "Credit",
                                            valueFormatter: params => {
                                                if (params.value == null || params.value === "") return "";
                                                return Number(params.value).toLocaleString("en-US", {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                });
                                            },
                                            valueSetter: (params) => {
                                                let newValue = parseFloat(params.newValue) || 0;
                                                let maxQty = parseFloat(params.data.ForPOBalance) || 0;

                                                if (newValue > maxQty) {
                                                    params.data.Purchase = maxQty;
                                                    params.node.setDataValue("Credit", maxQty);
                                                    return false;
                                                }

                                                params.data.Purchase = newValue;
                                                return true;
                                            },
                                            editable: true,
                                            cellClass: "text-end",
                                            width: 100
                                        },
                                        {
                                            headerName: "Process",
                                            field: "Unit",
                                            width: 100
                                        },
                                    ],
                                },
                            ],
                            rowData: response,
                            pagination: false,
                            paginationPageSize: 25
                        };
                        gridApi = agGrid.createGrid(gridDiv, gridOptions);

                        // Show modal
                        $('#mdl0105AddPR').modal('show');
                    }
                });
            };
        };
        async function fn0105Add_Ok(Btn) {
            //access
            fnAccess('SCM060000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn0105Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0105Add_Ok_Await(Btn) {
                const selectedRows = gridApi.getSelectedRows();
                let ItemList = [];
                selectedRows.forEach(row => {
                    ItemList.push({
                        PRNo: row.PRNo,
                        SeqNo: row.SeqNo,
                        Purchase: row.Purchase || 0,
                        Credit: row.Credit || 0
                    });
                });
                if (selectedRows.length === 0) {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                }
                // data format
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Purchase}©${i.Credit}`
                ).join('®');

                let ItemPR = ItemList.map(i => ({
                    PRNo: i.PRNo,
                    SeqNo: i.SeqNo,
                    Purchase: i.Purchase,
                    Credit: i.Credit
                }));
                Purchase_Question(ItemSrs, ItemPR, Btn);
                function Purchase_Question(ItemSrs, ItemPR, Btn) {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Add selected item(s)?</span>',
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
                            fnValidateRecord('Trxn_POHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Purchase_Ok(ItemSrs, ItemPR, Btn);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                }
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                }
                function Purchase_Ok(ItemSrs, ItemPR, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "HNDSCM.ashx",
                        data: {
                            'FormCode': 'SCM060100',
                            'Type': 'Add Record - DTL - Particular : PR',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pItemSrs': ItemSrs
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            // Hide Modal
                            fn0102LoadParticular("DTL", document.getElementById("ContentPlaceHolder1_hdnID").value);
                            $("#mdl0105AddPR").modal("hide");
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        },
                        error: function () {
                            Swal.close();
                            fnAlertOnly('Error saving record!', 'error', 'btn btn-danger');
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                }
            }

        };
        //particular

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM060100',
                    'Type': 'Upload - Get Record',
                    'pFormCode': 'SCM060000',
                    'pID': pID
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
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Delete', function (response) {
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
        function fn0202Download(pFormCode, pID, pSeqNo) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    window.open('MNU020300?ID=' + pID + '&No=' + pSeqNo);
                } else {
                    window.location.replace("MNU040100");
                };
            });
        };
        function fn0202Delete(pFormCode, pID, pSeqNo) {
            //if exisit
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM060000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Question(pFormCode, pID, pSeqNo);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //delete question
            function Delete_Question(pFormCode, pID, pSeqNo) {
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
                        Delete_Ok(pFormCode, pID, pSeqNo);
                    }
                });
            };
            function Delete_Ok(pFormCode, pID, pSeqNo) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM060100",
                        'Type': 'Purchase Order - Delete Upload',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
                    }
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
                    'pFormCode': 'SCM060000',
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
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('ogm_po_hdr', 'po_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                            'pFormCode': 'SCM060000',
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

        //status
        function fn0401LoadStatus(pMode, pID) {
            //status 
            if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM060100',
                        'Type': 'Purchase Order - PO Status',
                        'pID': pID
                    },
                    success: function (response) {
                        if (response[0].oStatus == "for Re-Open") {
                            if (response[0].oReOpenRemarks == "") {
                                Swal.fire({
                                    title: 'Re-Open',
                                    text: 'Remarks : No reason for re-open.',
                                    icon: 'warning',
                                    buttonsStyling: false,
                                    showCancelButton: false,
                                    confirmButtonText: "Ok",
                                    customClass: {
                                        confirmButton: 'btn btn-sm btn-warning min-w-100px'
                                    }
                                });
                            } else {
                                Swal.fire({
                                    title: 'Re-Open',
                                    text: 'Remarks : ' + response[0].oReOpenRemarks,
                                    icon: 'warning',
                                    buttonsStyling: false,
                                    showCancelButton: false,
                                    confirmButtonText: "Ok",
                                    customClass: {
                                        confirmButton: 'btn btn-sm btn-warning min-w-100px'
                                    }
                                });
                            }
                        };
                    }
                });
            };
        };
        //status

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
                    url: "HNDGEN.ashx?pFormCode=SCM060000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('SCM060000', 'Add', function (response) {
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
                    fnAccess('SCM060000', 'Add', function (response) {
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM060000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
                    url: "HNDGEN.ashx?pFormCode=SCM060000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('SCM060000', 'Add', function (response) {
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
                    fnAccess('SCM060000', 'Add', function (response) {
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM060000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
