<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM100100.aspx.vb" Inherits="NET.SCM100100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Item Convertion</li>
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
						<img src="Assets/media/svg/apps/SCM100000.svg" alt="" />
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
								</div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Warehouse</span>
											<span id="lbl0101Warehouse" class="form-control ">-</span>
                                            <input id="hf0101WhseCode" runat="server" type="hidden" value="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Reason</span>
											<span id="lbl0101Reason" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Conv. No.</span>
											<span id="lbl0101ConvNo" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Conv. Date</span>
											<span id="lbl0101ConvDate" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<!--begin::separator-->
										<div class="card-title fs-6 fw-bolder m-0">Item to Convert</div>
										<div class="separator separator-dashed mb-2"></div>
										<!--end::separator-->
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Item</span>
											<span id="lbl0101FromItem" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Qty</span>
											<span id="lbl0101FromQty" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">UOM</span>
											<span id="lbl0101FromUOM" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Cost</span>
											<span id="lbl0101FromCost" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Total</span>
											<span id="lbl0101FromTotal" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<!--begin::separator-->
										<div class="card-title fs-6 fw-bolder m-0">Convert To</div>
										<div class="separator separator-dashed mb-2"></div>
										<!--end::separator-->
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Item</span>
											<span id="lbl0101ToItem" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Qty</span>
											<span id="lbl0101ToQty" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">UOM</span>
											<span id="lbl0101ToUOM" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Cost</span>
											<span id="lbl0101ToCost" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Total</span>
											<span id="lbl0101ToTotal" class="form-control">-</span>
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
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Warehouse</span>
											<select id="ddl0101Warehouse" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
												<option value="">Warehouse</option>
											</select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Reason</span>
											<input id="tbx0101Reason" type="text" class="form-control " maxlength="180" Placeholder="Reason" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Conv. No.</span>
											<input id="tbx0101ConvNo" type="text" class="form-control " maxlength="13" Placeholder="Trxn No." readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Conv. Date</span>
											<input id="tbx0101ConvDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<!--begin::separator-->
										<div class="card-title fs-6 fw-bolder m-0">Item to Convert</div>
										<div class="separator separator-dashed mb-2"></div>
										<!--end::separator-->
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Item</span>
											<input id="tbx0101FromItem" type="text" class="form-control " maxlength="180" Placeholder="Item"  readonly="readonly" />
                                            <input id="hf0101FromItemCode" runat="server" type="hidden" value="" />
											<div class="d-flex align-items-center position-relative" style="margin-left:1px">
												<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
												<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101GetItem(); return false;">
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
											<input id="tbx0101FromQty" type="text" class="form-control " onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberFromQty(this);" maxlength="21" value="0.00" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">UOM</span>
											<input id="tbx0101FromUOM" type="text" class="form-control " maxlength="180" value="Unit" readonly="readonly" />
                                            <input id="hf0101FromUOMCode" runat="server" type="hidden" value="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Cost</span>
											<input id="tbx0101FromCost" type="text" class="form-control " maxlength="21" value="0.00" readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Total</span>
											<input id="tbx0101FromTotal" type="text" class="form-control " maxlength="21" value="0.00" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<!--begin::separator-->
										<div class="card-title fs-6 fw-bolder m-0">Convert To</div>
										<div class="separator separator-dashed mb-2"></div>
										<!--end::separator-->
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Item</span>
											<input id="tbx0101ToItem" type="text" class="form-control" maxlength="180" placeholder="Item" readonly="readonly" />
                                            <input id="hf0101ToItemCode" runat="server" type="hidden" value="" />
											<div class="d-flex align-items-center position-relative" style="margin-left:1px">
												<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
												<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0102GetItem(); return false;">
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
											<input id="tbx0101ToQty" type="text" class="form-control " maxlength="21" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberToQty(this);" value="0.00" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">UOM</span>
											<input id="tbx0101ToUOM" type="text" class="form-control " maxlength="180" value="Unit" readonly="readonly" />
                                            <input id="hf0101ToUOMCode" runat="server" type="hidden" value="" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Cost</span>
											<input id="tbx0101ToCost" type="text" class="form-control " maxlength="21" value="0.00" readonly="readonly" />
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Total</span>
											<input id="tbx0101ToTotal" type="text" class="form-control " maxlength="21" value="0.00" readonly="readonly" />
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
						<h5 class="modal-title">Item Convertion - Cancel Record</h5>
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
							<input id="tbx0102ReasonDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Date" />
						</div>
					    <div class="input-group input-group-sm">
						    <span class="input-group-text min-w-150px required">Reason</span>
						    <input id="tbx0102Reason" type="text" class="form-control " Placeholder="Reason" maxlength="500" />
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
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Cancel-->
        
		<!--begin::Modal Search record-->
		<div id="mdl0104ToItem" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Item Convertion - Search record</h5>
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
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal Search record-->
        
		<!--begin::Modal Search record-->
		<div id="mdl0105FromItem" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Item Convertion - Search record</h5>
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
                            <table id="table010501Item" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Item Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">Lock</th>
                                        <th class="min-w-250px w-100 fw-bold border-end">Item</th>
                                        <th class="min-w-250px w-100 fw-bold border-end">Category</th>
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
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
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
        function fnFormatNumberFromQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var FromCost = parseFloat(document.getElementById("tbx0101FromCost").value.replace(/,/g, '')) || 0.00;
            var ToQty = parseFloat(document.getElementById("tbx0101ToQty").value.replace(/,/g, '')) || 0.00;

            var FromTotal = Qty * FromCost;
            var ToTotal = FromTotal;
            var ToCost = (ToQty > 0 && FromTotal > 0) ? ToTotal / ToQty : 0.00;

            input.value = formatNumber(Qty);
            document.getElementById("tbx0101FromTotal").value = formatNumber(FromTotal);
            document.getElementById("tbx0101ToTotal").value = formatNumber(ToTotal);
            document.getElementById("tbx0101ToCost").value = formatNumber(ToCost);
        };
        function fnFormatNumberToQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var FromTotal = parseFloat(document.getElementById("tbx0101FromTotal").value.replace(/,/g, '')) || 0.00;
            var ToTotal = parseFloat(document.getElementById("tbx0101ToTotal").value.replace(/,/g, '')) || 0.00;

            // Format ToQty input
            input.value = formatNumber(Qty);

            // Recalculate ToCost same as VB.NET logic
            var ToCost = (Qty === 0 || FromTotal === 0) ? 0.00 : (ToTotal / Qty);

            // Update fields
            document.getElementById("tbx0101ToTotal").value = formatNumber(ToTotal);
            document.getElementById("tbx0101ToCost").value = formatNumber(ToCost);
        };
        //numeric

		//general
		function fn01Load() {
            fnAccess('SCM100000', 'View', function (response) {
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
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Lock").classList.remove("btn-lock");
                document.getElementById("btn0101Unlock").classList.remove("btn-lock");
                document.getElementById("btn0101Post").classList.remove("btn-post");
                document.getElementById("btn0101Cancel").classList.remove("btn-cancel");
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
                document.getElementById("tbx0101ConvNo").value = "";
                document.getElementById("tbx0101ConvDate").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                ddl0101Warehouse('');
                document.getElementById("tbx0101Reason").value = "";
                document.getElementById("tbx0101FromItem").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101FromItemCode").value = "";
                document.getElementById("tbx0101FromQty").value = "0.00";
                document.getElementById("tbx0101FromUOM").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101FromUOMCode").value = "";
                document.getElementById("tbx0101FromCost").value = "0.00";
                document.getElementById("tbx0101FromTotal").value = "0.00";
                document.getElementById("tbx0101ToItem").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101ToItemCode").value = "";
                document.getElementById("tbx0101ToQty").value = "0.00";
                document.getElementById("tbx0101ToUOM").value = "";
                document.getElementById("ContentPlaceHolder1_hf0101ToUOMCode").value = "";
                document.getElementById("tbx0101ToCost").value = "0.00";
                document.getElementById("tbx0101ToTotal").value = "0.00";
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
                        'FormCode': 'SCM100100',
                        'Type': 'Item Convertion - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].WhseName;
                        document.getElementById("spn0101ID").innerText = response[0].ICCode;
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
                        document.getElementById("lbl0101ConvNo").innerText = response[0].ConvNo;
                        document.getElementById("lbl0101ConvDate").innerText = response[0].ConvDate;
                        document.getElementById("lbl0101Warehouse").innerText = response[0].WhseName;
                        document.getElementById("lbl0101Reason").innerText = response[0].Remarks;
                        document.getElementById("lbl0101FromItem").innerText = response[0].FromItemName;
                        document.getElementById("ContentPlaceHolder1_hf0101FromItemCode").value = response[0].FromItemCode;
                        document.getElementById("lbl0101FromQty").innerText = formatNumber(response[0].FromQty);
                        document.getElementById("lbl0101FromUOM").innerText = response[0].FromUMName;
                        document.getElementById("ContentPlaceHolder1_hf0101FromUOMCode").value = response[0].FromUMCode;
                        document.getElementById("lbl0101FromCost").innerText = formatNumber(response[0].FromCost);
                        document.getElementById("lbl0101FromTotal").innerText = formatNumber(response[0].FromTotal);
                        document.getElementById("lbl0101ToItem").innerText = response[0].ToItemName;
                        document.getElementById("ContentPlaceHolder1_hf0101ToItemCode").value = response[0].ToItemCode;
                        document.getElementById("lbl0101ToQty").innerText = formatNumber(response[0].ToQty);
                        document.getElementById("lbl0101ToUOM").innerText = response[0].ToUMName;
                        document.getElementById("ContentPlaceHolder1_hf0101ToUOMCode").value = response[0].ToUMCode;
                        document.getElementById("lbl0101ToCost").innerText = formatNumber(response[0].ToCost);
                        document.getElementById("lbl0101ToTotal").innerText = formatNumber(response[0].ToTotal);
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
                        'FormCode': 'SCM100100',
                        'Type': 'Item Convertion - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //titlef
                        document.getElementById("spn0101Title").innerText = response[0].WhseName;
                        document.getElementById("spn0101ID").innerText = response[0].ICCode;
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
                        document.getElementById("tbx0101ConvNo").value = response[0].ConvNo;
                        document.getElementById("tbx0101ConvDate").value = response[0].ConvDate;
                        ddl0101Warehouse(response[0].WhseCode);
                        document.getElementById("tbx0101Reason").value = response[0].Remarks;
                        document.getElementById("tbx0101FromItem").value = response[0].FromItemName;
                        document.getElementById("ContentPlaceHolder1_hf0101FromItemCode").value = response[0].FromItemCode;
                        document.getElementById("tbx0101FromQty").value = formatNumber(response[0].FromQty);
                        document.getElementById("tbx0101FromUOM").value = response[0].FromUMName;
                        document.getElementById("ContentPlaceHolder1_hf0101FromUOMCode").value = response[0].FromUMCode;
                        document.getElementById("tbx0101FromCost").value = formatNumber(response[0].FromCost);
                        document.getElementById("tbx0101FromTotal").value = formatNumber(response[0].FromTotal);
                        document.getElementById("tbx0101ToItem").value = response[0].ToItemName;
                        document.getElementById("ContentPlaceHolder1_hf0101ToItemCode").value = response[0].ToItemCode;
                        document.getElementById("tbx0101ToQty").value = formatNumber(response[0].ToQty);
                        document.getElementById("tbx0101ToUOM").value = response[0].ToUMName;
                        document.getElementById("ContentPlaceHolder1_hf0101ToUOMCode").value = response[0].ToUMCode;
                        document.getElementById("tbx0101ToCost").value = formatNumber(response[0].ToCost);
                        document.getElementById("tbx0101ToTotal").value = formatNumber(response[0].ToTotal);
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
                        'FormCode': 'SCM100100',
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
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('SCM100000', 'Add', function (response) {
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
                fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM100000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Delete', function (response) {
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
                        fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Detele_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('SCM100000', 'Trxn_ItemConvertion', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM100000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM100000");
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
                fnAccess('SCM100000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM100000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM100000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Save', function (response) {
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
                } else if (document.getElementById("tbx0101Reason").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101ConvDate").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101FromItem").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101FromQty").value == "" || document.getElementById("tbx0101FromQty").value == 0) {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101ToItem").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101ToQty").value == "" || document.getElementById("tbx0101ToQty").value == 0) {
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
                            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                if (response[0].oReturn == "1") {
                                    fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Save', function (response) {
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
                        'FormCode': 'SCM100100',
                        'Type': 'Item Convertion - Add Record',
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pReason': document.getElementById("tbx0101Reason").value,
                        'pConvDate': document.getElementById("tbx0101ConvDate").value,
                        'pFromItemCode': document.getElementById("ContentPlaceHolder1_hf0101FromItemCode").value,
                        'pFromQty': document.getElementById("tbx0101FromQty").value,
                        'pFromUOMCode': document.getElementById("ContentPlaceHolder1_hf0101FromUOMCode").value,
                        'pFromCost': document.getElementById("tbx0101FromCost").value,
                        'pFromTotal': document.getElementById("tbx0101FromTotal").value,
                        'pToItemCode': document.getElementById("ContentPlaceHolder1_hf0101ToItemCode").value,
                        'pToQty': document.getElementById("tbx0101ToQty").value,
                        'pToUOMCode': document.getElementById("ContentPlaceHolder1_hf0101ToUOMCode").value,
                        'pToCost': document.getElementById("tbx0101ToCost").value,
                        'pToTotal': document.getElementById("tbx0101ToTotal").value
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
                        'FormCode': 'SCM100100',
                        'Type': 'Item Convertion - Edit Record',
                        'pID': ID,
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pReason': document.getElementById("tbx0101Reason").value,
                        'pConvDate': document.getElementById("tbx0101ConvDate").value,
                        'pFromItemCode': document.getElementById("ContentPlaceHolder1_hf0101FromItemCode").value,
                        'pFromQty': document.getElementById("tbx0101FromQty").value,
                        'pFromUOMCode': document.getElementById("ContentPlaceHolder1_hf0101FromUOMCode").value,
                        'pFromCost': document.getElementById("tbx0101FromCost").value,
                        'pFromTotal': document.getElementById("tbx0101FromTotal").value,
                        'pToItemCode': document.getElementById("ContentPlaceHolder1_hf0101ToItemCode").value,
                        'pToQty': document.getElementById("tbx0101ToQty").value,
                        'pToUOMCode': document.getElementById("ContentPlaceHolder1_hf0101ToUOMCode").value,
                        'pToCost': document.getElementById("tbx0101ToCost").value,
                        'pToTotal': document.getElementById("tbx0101ToTotal").value
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM100000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Lock', function (response) {
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
                                fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Lock', function (response) {
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
                fnLock('Lock', 'Trxn_ItemConvertion', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exisit
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM100000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Unlock', function (response) {
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
                                fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Unlock', function (response) {
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
                fnLock('Unlock', 'Trxn_ItemConvertion', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Post() {
            //if exisit
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM100000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Post', function (response) {
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
                                //if exisit
                                fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                    if (response[0].oReturn == "1") {
                                        fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Post', function (response) {
                                            if (response[0].oReturn == "") {
                                                Post_Ok(ID);
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
                        'pRecType': "Item Convertion",
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM100000', 'Reverse', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_ItemConvertion', ID, '', 'Reverse', function (response) {
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                if (document.getElementById("tbx0102ReasonDate").value == "" || document.getElementById("tbx0102Reason").value == "") {
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
                                    fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                        if (response[0].oReturn == "1") {
                                            fnValidateRecord('Trxn_ItemConvertion', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Reverse', function (response) {
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
                            'FormCode': 'SCM100100',
                            'Type': 'Item Convertion - Cancel Record',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pReasonDate': document.getElementById("tbx0102ReasonDate").value,
                            'pReason': document.getElementById("tbx0102Reason").value
                        },
                        success: function (response) {
                            //cancel
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            document.getElementById("tbx0102ReasonDate").value = "";
                            document.getElementById("tbx0102Reason").value = "";
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
        //overview

        //item
        function fn0101GetItem() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM100100',
                    'Type': 'Item Convertion - Add Record : Item',
                    'pConvDate': document.getElementById("tbx0101ConvDate").value,
                    'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value
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
                    $('#mdl0104ToItem').modal('show');
                },
            });
        };
        function fn0101FromItem(pItemCode, pLock) {
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
                        'FormCode': 'SCM100100',
                        'Type': 'Get Record : Item',
                        'pItemCode': pItemCode,
                        'pConvDate': document.getElementById("tbx0101ConvDate").value,
                        'pWarehouse': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf0101FromItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx0101FromItem").value = response[0].ItemName;
                        document.getElementById("tbx0101FromQty").value = formatNumber(response[0].Qty);
                        document.getElementById("tbx0101FromCost").value = formatNumber(response[0].Cost);
                        document.getElementById("ContentPlaceHolder1_hf0101FromUOMCode").value = response[0].UMCode;
                        document.getElementById("tbx0101FromUOM").value = response[0].UMName;
                        let newTotal = parseFloat(document.getElementById("tbx0101FromQty").value.replace(/,/g, '')) * response[0].Cost;
                        document.getElementById("tbx0101FromTotal").value = formatNumber(newTotal);
                        fnFormatNumberFromQty(document.getElementById("tbx0101FromQty"));
                        //modal
                        $('#mdl0104ToItem').modal('hide');
                    },
                });
            };
        };
        function fn0102GetItem() {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM100100',
                    'Type': 'Item Convertion - Add Record : Item To'
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010501Loader").style.display = "";
                    //display loader

                    $('#table010501Item').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010501Item = $("#table010501Item").DataTable({
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
                            { data: 'Category' },
                            { data: 'UMName' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: [3, 4], className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010501Find').on('keyup', function () {
                        table010501Item.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010501Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0105FromItem').modal('show');
                },
            })
        };
        function fn0101ToItem(pItemCode, pLock) {
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
                        'FormCode': 'SCM100100',
                        'Type': 'Get Record : Item To',
                        'pItemCode': pItemCode
                    },
                    success: function (response) {
                        document.getElementById("tbx0101ToItem").value = response[0].ItemName;
                        document.getElementById("ContentPlaceHolder1_hf0101ToItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx0101ToUOM").value = response[0].UMName;
                        document.getElementById("ContentPlaceHolder1_hf0101ToUOMCode").value = response[0].UMCode;
                        //modal
                        $('#mdl0105FromItem').modal('hide');
                    },
                });
            };
        };
        //item

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'SCM100000',
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM100000', 'Delete', function (response) {
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
                    'pFormCode': 'SCM100000',
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('Trxn_ItemConvertion', 'ICCode', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                            'pFormCode': 'SCM100000',
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
                    url: "HNDGEN.ashx?pFormCode=SCM100000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('SCM100000', 'Add', function (response) {
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
                    fnAccess('SCM100000', 'Add', function (response) {
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM100000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
