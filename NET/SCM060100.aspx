<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM060100.aspx.vb" Inherits="NET.SCM060100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
		/* 1. Draggable Header */
		#modalFilePreview .modal-header {
			cursor: move;
			user-select: none;
		}

		/* 2. Modeless: Click through to parent page */
		#modalFilePreview {
			pointer-events: none !important;
			background-color: transparent !important;
		}
		#modalFilePreview .modal-dialog {
			pointer-events: auto !important;
			min-width: 450px;
			min-height: 300px;
		}

		/* 3. Modal Flexbox Layout for resizing */
		#modalFilePreview .modal-content {
			display: flex;
			flex-direction: column;
			height: 100%;
			min-height: 300px;
		}

		#previewViewport {
			flex: 1 1 auto !important;
			height: 75vh; /* Default height */
			width: 100% !important;
			overflow: hidden;
			background: #525659;
			position: relative;
		}

		#previewTransformContainer,
		#iframeFilePreview {
			width: 100% !important;
			height: 100% !important;
			border: none !important;
			display: block;
		}

		/* 4. Page scrolling & backdrop removal */
		body.modal-open {
			overflow: auto !important;
			padding-right: 0 !important;
		}
		.modal-backdrop {
			display: none !important;
		}

		/* 5. Pan & Drag Glass Overlay */
		#panGlassOverlay {
			position: absolute;
			top: 0;
			left: 0;
			width: 100%;
			height: 100%;
			z-index: 10;
			display: none;
			cursor: grab;
		}
		#panGlassOverlay.grabbing {
			cursor: grabbing !important;
		}

		/* 6. RESIZE HANDLES */
		.modal-resizer {
			position: absolute;
			z-index: 20;
		}
		.resizer-e {
			top: 0;
			right: -3px;
			width: 8px;
			height: 100%;
			cursor: e-resize;
		}
		.resizer-s {
			bottom: -3px;
			left: 0;
			width: 100%;
			height: 8px;
			cursor: s-resize;
		}
		.resizer-se {
			bottom: 2px;
			right: 2px;
			width: 18px;
			height: 18px;
			cursor: se-resize;
			display: flex;
			align-items: center;
			justify-content: center;
			user-select: none;
		}

		/* 7. MAXIMIZED STATE */
		#modalFilePreview.modal-maximized .modal-dialog {
			position: fixed !important;
			top: 0 !important;
			left: 0 !important;
			width: 100vw !important;
			max-width: 100vw !important;
			height: 100vh !important;
			margin: 0 !important;
		}
		#modalFilePreview.modal-maximized .modal-content {
			height: 100vh !important;
			border-radius: 0 !important;
		}
		#modalFilePreview.modal-maximized .modal-resizer {
			display: none !important; /* Hide resizer handles when maximized */
		}
		.custom-select-darkgreen .select2-container--bootstrap5 .select2-selection--single,
		.custom-select-darkgreen .form-select {
			background-color: #1e604d !important;
			border-color: #1e604d !important;
			border-radius: 6px !important;
			height: 36px !important;
			display: flex !important;
			align-items: center !important;
		}

		.custom-select-darkgreen .select2-container--bootstrap5 .select2-selection__rendered,
		.custom-select-darkgreen .form-select {
			color: #ffffff !important;
			font-size: 11px !important;
			font-weight: 600 !important;
			letter-spacing: 0.3px !important;
			padding-left: 12px !important;
		}

		.custom-select-darkgreen .select2-container--bootstrap5 .select2-selection__arrow b {
			border-color: #ffffff transparent transparent transparent !important;
		}

		.custom-select-darkgreen .form-select {
			background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16'%3e%3cpath fill='none' stroke='%23ffffff' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='m2 5 6 6 6-6'/%3e%3c/svg%3e") !important;
			background-repeat: no-repeat !important;
			background-position: right 0.75rem center !important;
			background-size: 12px 10px !important;
		}
		.custom-input-darkgreen .form-control {
			background-color: #1e604d !important;
			border-color: #1e604d !important;
			color: #ffffff !important;
			border-radius: 6px !important;
			height: 36px !important;
			font-size: 11px !important;
			font-weight: 600 !important;
			letter-spacing: 0.3px !important;
			padding-left: 12px !important;
		}

		.custom-input-darkgreen .form-control::placeholder {
			color: rgba(255, 255, 255, 0.7) !important;
		}

		.custom-input-darkgreen .form-control:focus,
		.custom-input-darkgreen .form-control[readonly] {
			background-color: #1e604d !important;
			border-color: #1e604d !important;
			color: #ffffff !important;
		}
		.custom-checkbox-box .form-check-wrapper {
			height: 36px;
			border: 1px solid #e4e6ef;
			border-radius: 6px;
			background-color: transparent;
		}
		.custom-checkbox-group .checkbox-group-wrapper {
			height: 36px;
			border: 1px solid #e4e6ef;
			border-radius: 6px;
			background-color: transparent;
		}

		.custom-checkbox-group .form-check {
			margin-bottom: 0 !important;
		}
    </style>

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
									<button id="btn0101Find" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Find" onclick="fn0101Find();return false;"><i class="las la-search fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
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
										<div id="div0101Vendor" class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Vendor</label>
											<input type="text" id="lbl0101Vendor" class="form-control form-control-sm" placeholder="Vendor" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Warehouse" class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Warehouse</label>
											<input type="text" id="lbl0101Warehouse" class="form-control form-control-sm" Placeholder="Warehouse" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">PO. No.</label>
											 <input type="text" id="lbl0101PONo" title="PO. No." class="form-control form-control-sm" Placeholder="PO. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div id="div0101PODate" class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">PO. Date</label>
											<input type="text" id="lbl0101PODate" title="PO. Date" class="form-control form-control-sm" Placeholder="PO. Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div id="div0101Schedule" class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Schedule</label>
											<input type="text" id="lbl0101Schedule" class="form-control form-control-sm" Placeholder="Schedule" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Status</label>
											<div class="position-relative d-flex align-items-center">
												<input id="lbl0101Status" type="text" class="form-control form-control-sm pe-8" placeholder="Status" readonly="readonly" />
												<span class="svg-icon svg-icon-2 position-absolute end-0 me-3 cursor-pointer" onclick="fn0101Status(); return false;">
													<svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="none">
														<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
														<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
													</svg>
												</span>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-checkbox-box">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">With Canvass</label>
											<div class="form-check-wrapper d-flex align-items-center justify-content-between px-3">
												<label class="form-check-label fs-7 fw-bold text-gray-800 m-0" for="cbxCanvassDtl0101">
													With Canvass
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<input class="form-check-input" type="checkbox" value="" id="cbxCanvassDtl0101" onclick="return false;" />
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-checkbox-box">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">With Payment Req.</label>
											<div class="form-check-wrapper d-flex align-items-center justify-content-between px-3">
												<label class="form-check-label fs-7 fw-bold text-gray-800 text-truncate m-0" title="With Payment Req." for="cbxPaymentDtl0101">
													With Payment Req.
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<input class="form-check-input" type="checkbox" value="" id="cbxPaymentDtl0101" onclick="return false;" />
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="d-flex flex-column mb-3 custom-checkbox-group">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Delivery Option</label>
											<div class="checkbox-group-wrapper d-flex align-items-center justify-content-between px-2">
												<div class="form-check form-check-custom form-check-solid form-check-sm me-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxPickUpDtl0101" onclick="return false;" />
													<label class="form-check-label fs-8 fw-semibold text-gray-800 text-truncate ms-1" title="Pick-Up" for="cbxPickUpDtl0101">
														Pick-Up
													</label>
												</div>
												<div class="form-check form-check-custom form-check-solid form-check-sm me-2">
													<input class="form-check-input" type="checkbox" value="" id="cbxDlvrToDtl0101" onclick="return false;" />
													<label class="form-check-label fs-8 fw-semibold text-gray-800 text-truncate ms-1" title="Deliver To" for="cbxDlvrToDtl0101">
														Deliver To
													</label>
												</div>
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<input class="form-check-input" type="checkbox" value="" id="cbxForWhseDtl0101" onclick="return false;" />
													<label class="form-check-label fs-8 fw-semibold text-gray-800 text-truncate ms-1" title="For Warehouse Pick-Up" for="cbxForWhseDtl0101">
														Whse Pick-Up
													</label>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-1">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Pick-Up Date</label>
											<input type="text" id="lbl0101PickUpDate" title="Date" class="form-control form-control-sm" Placeholder="Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">PO. Remarks</label>
											<input type="text" id="lbl0101PORemarks" class="form-control form-control-sm" Placeholder="Remarks" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">RR. No.</label>
											<input type="text" id="lbl0101RRNo" title="RR. No." class="form-control form-control-sm" Placeholder="RR. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">APV No.</label>
											<input type="text" id="lbl0101APVNo" title="APV. No." class="form-control form-control-sm" Placeholder="APV. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-8">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Dlvr. Address</label>
											<input type="text" id="lbl0101DlvrAddress" title="Address" class="form-control form-control-sm" Placeholder="Address" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Payment Ref.</label>
											<input type="text" id="lbl0101PaymentRef" title="Full Payment Ref." class="form-control form-control-sm" Placeholder="Full Payment Ref." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Partial Ref.</label>
											<input type="text" id="lbl0101PartialRef" title="Partial Payment Ref." class="form-control form-control-sm" Placeholder="Partial Payment Ref." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101PmtMode" class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Payment Mode</label>
											<input type="text" id="lbl0101PmtMode" class="form-control form-control-sm" Placeholder="Payment Mode" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Terms" class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Terms</label>
											<input type="text" id="lbl0101Terms" class="form-control form-control-sm" Placeholder="Terms" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Personal Remarks</label>
											<input type="text" id="lbl0101PersonalRemarks" class="form-control form-control-sm" Placeholder="Remarks" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101VAT" class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">VAT</label>
											<input type="text" id="lbl0101VAT" class="form-control form-control-sm" Placeholder="VAT" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div id="div0101Withholding" class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Withholding</label>
											<input type="text" id="lbl0101Withholding" class="form-control form-control-sm" Placeholder="Withholding" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Account Remarks</label>
											<input type="text" id="lbl0101AcctRemarks" class="form-control form-control-sm" Placeholder="Remarks" readonly="readonly" />
										</div>
									</div>
								</div>
							</div>
							<div id="div0101Update" class="card-body" style="display: none;">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-4">
                                        <div class="d-flex flex-column mb-3 custom-select-darkgreen">
                                            <label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Vendor</label>
                                            <select id="ddl0101Vendor" data-control="select2" data-hide-search="false" class="form-select form-select-sm form-select-solid" onchange="ddl0101Vendor_onchange(this);">
                                                <option value="">Vendor</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3 custom-select-darkgreen">
                                            <label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Warehouse</label>
											<select id="ddl0101Warehouse" data-kt-repeater="select2" class="form-select form-select-sm form-select-solid" onchange="ddl0101Warehouse_onchange(this);">
												<option value="">Warehouse</option>
											</select>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">PO. No.</label>
											<input type="text" id="tbx0101PONo" class="form-control form-control-sm" placeholder="PO. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">PO. Date</label>
											<div class="input-group input-group-sm">
												<input type="text" id="tbx0101PODate" title="PO. Date" data-kt-repeater="datepicker" class="form-control form-control-sm" Placeholder="PO. Date" readonly="readonly" />
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Schedule</label>
											<input list="dl0101Schedule" type="text" id="tbx0101Schedule" class="form-select form-select-sm form-select-solid" Placeholder="Schedule" />
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
									    <div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Status</label>
										    <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											    <input id="tbx0101Status"type="text" class="form-control form-control-sm border m-0" placeholder="Status" readonly="readonly" />
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
										<div class="d-flex flex-column mb-3 custom-checkbox-box">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">With Canvass</label>
											<div class="form-check-wrapper d-flex align-items-center justify-content-between border px-3">
												<label class="form-check-label fs-7 fw-bold text-gray-800 m-0" for="cbxCanvassUpd0101">
													With Canvass
												</label>
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<input class="form-check-input" type="checkbox" value="" id="cbxCanvassUpd0101" onclick="return false;" />
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-checkbox-box">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">With Payment Req.</label>
											<div class="form-check-wrapper d-flex align-items-center justify-content-between border px-3">
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
										<div class="d-flex flex-column mb-3 custom-checkbox-group">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Delivery Option</label>
											<div class="checkbox-group-wrapper d-flex align-items-center justify-content-between px-2">
												<div class="form-check form-check-custom form-check-solid form-check-sm me-2">
													<input class="form-check-input checkBox" type="checkbox" value="" id="cbxPickUpUpd0101" onclick="checkBox(this);" />
													<label class="form-check-label fs-8 fw-semibold text-gray-800 text-truncate ms-1" title="Pick-Up" for="cbxPickUpUpd0101">
														Pick-Up
													</label>
												</div>
												<div class="form-check form-check-custom form-check-solid form-check-sm me-2">
													<input class="form-check-input checkBox" type="checkbox" value="" id="cbxDlvrToUpd0101" onclick="checkBox(this);" />
													<label class="form-check-label fs-8 fw-semibold text-gray-800 text-truncate ms-1" title="Deliver To" for="cbxDlvrToUpd0101">
														Deliver To
													</label>
												</div>
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<input class="form-check-input checkBox" type="checkbox" value="" id="cbxForWhseUpd0101" onclick="checkBox(this);" />
													<label class="form-check-label fs-8 fw-semibold text-gray-800 text-truncate ms-1" title="For Warehouse Pick-Up" for="cbxForWhseUpd0101">
														Whse Pick-Up
													</label>
												</div>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-1">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Pick-Up Date</label>
											<input type="text" id="tbx0101PickUpDate" data-kt-repeater="datepicker" class="form-control form-control-sm text-center" placeholder="Date" readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">PO. Remarks</label>
											<input list="dl0101PORemarks" type="text" id="tbx0101PORemarks" class="form-control form-control-sm" Placeholder="Remarks" />
											<datalist id="dl0101PORemarks">

											</datalist>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">RR. No.</label>
											<input type="text" id="tbx0101RRNo" title="RR. No." class="form-control form-control-sm" Placeholder="RR. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">APV No.</label>
											<input type="text" id="tbx0101APVNo" title="APV. No." class="form-control form-control-sm" Placeholder="APV. No." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-8">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Dlvr. Address</label>
											<input list="dl0101DlvrAddress" type="text" id="tbx0101DlvrAddress" title="Address" class="form-control form-control-sm" Placeholder="Address" />
											<datalist id="dl0101DlvrAddress">

											</datalist>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Payment Ref.</label>
											<input type="text" id="tbx0101PaymentRef" title="Full Payment Ref." class="form-control form-control-sm" Placeholder="Full Payment Ref." readonly="readonly" />
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-2">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Partial Ref.</label>
											<input type="text" id="tbx0101PartialRef" title="Partial Payment Ref." class="form-control form-control-sm" Placeholder="Partial Payment Ref." readonly="readonly" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
                                        <div class="d-flex flex-column mb-3 custom-select-darkgreen">
                                            <label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Payment Mode</label>
											<select id="ddl0101PmtMode" data-kt-repeater="select2" class="form-select form-select-sm form-select-solid">
												<option value="">Mode</option>
												<option value="Cash">Cash</option>
												<option value="Check">Check</option>
												<option value="Cash Advance">Cash Advance</option>
												<option value="Cash and Check">Cash and Check</option>
												<option value="Cash on Delivery">Cash on Delivery</option>
												<option value="Corporate Credit Card">Corporate Credit Card</option>
												<option value="Revolving Fund">Revolving Fund</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
                                        <div class="d-flex flex-column mb-3 custom-select-darkgreen">
                                            <label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Terms</label>
											<select id="ddl0101Terms" data-kt-repeater="select2" class="form-select form-select-sm form-select-solid">
												<option value="">Terms</option>
											</select>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Personal Remarks</label>
											<input type="text" id="tbx0101PersonalRemarks" class="form-control form-control-sm" Placeholder="Remarks" />
										</div>
									</div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
                                        <div class="d-flex flex-column mb-3 custom-select-darkgreen">
                                            <label class="form-label fs-7 fw-semibold text-gray-700 mb-1">VAT</label>
											<select id="ddl0101VAT" data-kt-repeater="select2" class="form-select form-select-sm form-select-solid">
												<option value="">VAT</option>
											</select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-4">
                                        <div class="d-flex flex-column mb-3 custom-select-darkgreen">
                                            <label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Withholding</label>
											<select id="ddl0101Withholding" data-kt-repeater="select2" class="form-select form-select-sm form-select-solid">
												<option value="">Withholding</option>
											</select>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-4">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Account Remarks</label>
											<input type="text" id="tbx0101AcctRemarks" class="form-control form-control-sm" Placeholder="Remarks" readonly="readonly" />
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
												<th class="min-w-100px mw-100px fw-bold border-end">Qty.</th>
												<th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Cost</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Total</th>
												<th class="min-w-175px mw-175px fw-bold border-end">Commodity</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Strategy</th>
												<th class="min-w-150px mw-150px fw-bold border-end">Remarks</th>
												<th class="min-w-150px mw-150px fw-bold border-end">PR No.</th>
												<th class="min-w-50px mw-50px fw-bold border-end">No.</th>
												<th class="min-w-250px w-100 fw-bold border-end">Item</th>
												<th class="min-w-100px mw-100px fw-bold border-end">Qty.</th>
												<th class="min-w-75px mw-75px fw-bold border-end">UOM</th>
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
                            <div id="div0102Detail" class="card-body">
                                <div class="row g-2">
									
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Updated By</label>
                                            <span id="lbl0101UpdatedByName" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <span id="lbl0101UpdatedDate" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Locked By</label>
                                            <span id="lbl0101LockedByName" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <span id="lbl0101LockedDate" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Posted By</label>
                                            <span id="lbl0101PostedByName" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <span id="lbl0101PostedDate" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Cancelled By</label>
                                            <span id="lbl0101CancelledByName" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <span id="lbl0101CancelledDate" class="form-control form-control-sm">-</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="div0102Update" class="card-body" style="display: none;">
                                <div class="row g-2">
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Updated By</label>
                                            <input id="tbx0101UpdatedByName" type="text" class="form-control form-control-sm" Placeholder="Updated By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <input id="tbx0101UpdatedDate" type="text" class="form-control form-control-sm" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Locked By</label>
                                            <input id="tbx0101LockedByName" type="text" class="form-control form-control-sm" Placeholder="Locked By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <input id="tbx0101LockedDate" type="text" class="form-control form-control-sm" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Posted By</label>
                                            <input id="tbx0101PostedByName" type="text" class="form-control form-control-sm" Placeholder="Posted By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <input id="tbx0101PostedDate" type="text" class="form-control form-control-sm" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3 custom-input-darkgreen">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Cancelled By</label>
                                            <input id="tbx0101CancelledByName" type="text" class="form-control form-control-sm" Placeholder="Cancelled By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
										<div class="d-flex flex-column mb-3">
											<label class="form-label fs-7 fw-semibold text-gray-700 mb-1">Date</label>
                                            <input id="tbx0101CancelledDate" type="text" class="form-control form-control-sm" Placeholder="Date" maxlength="20" readonly />
                                        </div>
                                    </div>
                                </div>
                            </div>
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
        
		<!--begin::Modal Find -->
		<div id="mdl0101Find" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="true" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Find Record - Purchase Order</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
								<button type="button" class="btn btn-sm btn-icon btn-info btn-active-info m-1 flex-shrink-0" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" title="Filter" onclick="fn0101Filter();">
								   <i class="las la-filter fs-3"></i>
								</button>
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
                                    <input id="tbx0101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput=" findApi.setGridOption('quickFilterText',document.getElementById('tbx0101Find').value);" />
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
                        <div id="table0101Find" style="width: 100%; height: 100%;"></div>
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
		<!--begin::Modal Find -->
		
		<!--begin::Modal Filter-->
		<div id="mdl0101Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
				            <input id="cbx0101Posted" class="form-check-input" type="checkbox" value=""/>
				            <label class="form-check-label" for="cbx0101Posted">
					            Posted
				            </label>
                         </div>
                        <select id="ddl0102Vendor" data-kt-repeater="select2" data-dropdown-parent="#mdl0101Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Vendor</option>
                        </select>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0101Filter_Ok(this);return false;">
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
	        <div class="modal-dialog mw-750px">
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
					<div class="modal-body m-0 p-0">
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div class="border border-radius-047rem mb-1" style="padding-top: 8px; padding-left: 5px; padding-right: 5px;">
							        <div class="d-flex flex-wrap justify-content-between">
								        <label class="form-check-label fw-bolder" for="cbxChangeItemAdd0102">
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
								        <label class="form-check-label fw-bolder" for="cbxChangeQtyAdd0102">
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
							        <span class="input-group-text bg-secondary min-w-150px fw-bolder">Item</span>
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
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Qty</span>
						            <input id="tbx0102AddQty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddQty(this);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Qty" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">UOM</span>
						            <input id="tbx0102AddUOM" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Unit" readonly="readonly" />
                                    <input id="hf0102AddUOMCode" runat="server" type="hidden" value="" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1 border border-danger">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Cost</span>
						            <input id="tbx0102AddCost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddCost(this);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Cost" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Total</span>
						            <input id="tbx0102AddTotal" onkeypress="return fnEnterKeyNumber(event,this.id);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Total" value="0.00" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Canvass</span>
						            <input id="tbx0102AddCanvass" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberAddCanvass(this);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Canvass" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Commodity</span>
									<select id="ddl0102AddCommodity" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Commodity</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Strategy</span>
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
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">OSM Code</span>
									<select id="ddl0102AddOSMCode" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Code</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Stdrd. Type</span>
									<select id="ddl0102AddStandard" data-kt-repeater="select2" data-dropdown-parent="#mdl0102Add" class="form-select form-select-sm form-select-border">
										<option value="">Type</option>
										<option value="Standard">Standard</option>
										<option value="Non Standard">Non Standard</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Ld. Stdrd. Type</span>
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
                                    <textarea id="tbx0102AddRemarks" class="form-control form-control-sm" placeholder="Remarks" rows="2"></textarea>
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
	        <div class="modal-dialog mw-750px">
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
					<div class="modal-body m-0 p-0">
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
						        <div class="border border-radius-047rem mb-1" style="padding-top: 8px; padding-left: 5px; padding-right: 5px;">
							        <div class="d-flex flex-wrap justify-content-between">
								        <label class="form-check-label fw-bolder" for="cbxChangeItemUpd0104">
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
								        <label class="form-check-label fw-bolder" for="cbxChangeQtyUpd0104">
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
							        <span class="input-group-text bg-secondary min-w-150px fw-bolder">Item</span>
							        <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
								        <input id="tbx0104UpdItem" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Item" readonly="readonly" />
                                        <input id="hf0104UpdSeqNo" runat="server" type="hidden" value="" />
                                        <input id="hf0104UpdItemCode" runat="server" type="hidden" value="" />
								        <span id="spn0104UpdItem" class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0104UpdItem(); return false;">
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
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Qty</span>
						            <input id="tbx0104UpdQty" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdQty(this);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Qty" value="0.00" readonly />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">UOM</span>
						            <input id="tbx0104UpdUOM" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Unit" readonly="readonly" />
                                    <input id="hf0104UpdUOMCode" runat="server" type="hidden" value="" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1 border border-danger">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Cost</span>
						            <input id="tbx0104UpdCost" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdCost(this);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Cost" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Total</span>
						            <input id="tbx0104UpdTotal" onkeypress="return fnEnterKeyNumber(event,this.id);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Total" value="0.00" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Canvass</span>
						            <input id="tbx0104UpdCanvass" onkeypress="return fnEnterKeyNumber(event,this.id);" onblur="fnFormatNumberUpdCanvass(this);" type="text" class="form-control form-control-sm" maxlength="21" Placeholder="Canvass" value="0.00" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Commodity</span>
									<select id="ddl0104UpdCommodity" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Commodity</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Strategy</span>
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
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">OSM Code</span>
									<select id="ddl0104UpdOSMCode" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Code</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1 border border-danger">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Stdrd. Type</span>
									<select id="ddl0104UpdStandard" data-kt-repeater="select2" data-dropdown-parent="#mdl0104Edit" class="form-select form-select-sm form-select-border">
										<option value="">Type</option>
										<option value="Standard">Standard</option>
										<option value="Non Standard">Non Standard</option>
									</select>
								</div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm mb-1">
									<span class="input-group-text bg-secondary min-w-150px fw-bolder">Ld. Stdrd. Type</span>
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
                                    <textarea id="tbx0104UpdRemarks" class="form-control form-control-sm" placeholder="Remarks" rows="2"></textarea>
					            </div>
                            </div>
                            <div class="separator separator-dashed mb-1"></div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">PR No.</span>
						            <input id="tbx0104UpdPRNo" type="text" class="form-control form-control-sm" Placeholder="PR No." readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">No.</span>
						            <input id="tbx0104UpdPRSeqNo" type="text" class="form-control form-control-sm" Placeholder="No." readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Item</span>
						            <input id="tbx0104UpdPRItem" type="text" class="form-control form-control-sm" Placeholder="Item" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">Qty</span>
						            <input id="tbx0104UpdPRQty" type="text" class="form-control form-control-sm" Placeholder="Qty" readonly="readonly" />
					            </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
					            <div class="input-group input-group-sm mb-1">
						            <span class="input-group-text bg-secondary min-w-150px fw-bolder">UOM</span>
						            <input id="tbx0104UpdPRUOM" type="text" class="form-control form-control-sm" Placeholder="Unit" readonly="readonly" />
					            </div>
                            </div>
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" id="a010400Edit_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn010400Edit_Ok(this); return false;">
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

		<div class="modal fade" id="modalFilePreview" tabindex="-1" role="dialog" aria-hidden="true" data-bs-backdrop="false" data-backdrop="false">
			<div class="modal-dialog modal-xl modal-dialog-centered" role="document">
				<div class="modal-content shadow-lg position-relative">

					<!-- Modal Header with Zoom & Window Controls -->
					<div class="modal-header d-flex justify-content-between align-items-center py-2">
						<h5 class="modal-title m-0">Document Preview</h5>
    
						<div class="d-flex align-items-center">
							<!-- ZOOM TOOLBAR -->
							<div class="d-flex align-items-center bg-light rounded px-2 py-1 me-3">
								<button type="button" class="btn btn-icon btn-sm btn-active-light-primary" id="btnZoomOut" title="Zoom Out">
									<i class="fa fa-search-minus"></i>
								</button>
								<span class="fw-bold px-2 text-gray-700" id="lblZoomLevel" style="font-size: 11px; min-width: 45px; text-align: center;">100%</span>
								<button type="button" class="btn btn-icon btn-sm btn-active-light-primary" id="btnZoomIn" title="Zoom In">
									<i class="fa fa-search-plus"></i>
								</button>
								<button type="button" class="btn btn-icon btn-sm btn-active-light-primary ms-1" id="btnTogglePan" title="Toggle Pan / Drag Mode">
									<i class="fa fa-hand-paper" id="iconPan"></i>
								</button>
								<button type="button" class="btn btn-icon btn-sm btn-active-light-primary ms-1" id="btnZoomReset" title="Reset Zoom">
									<i class="fa fa-undo"></i>
								</button>
							</div>

							<!-- WINDOW CONTROLS -->
							<button type="button" class="btn btn-icon btn-sm btn-active-light-primary me-1" id="btnModalMaximize" title="Maximize">
								<i class="fa fa-expand" id="iconMaximize"></i>
							</button>
							<button type="button" class="btn btn-icon btn-sm btn-active-light-danger" data-bs-dismiss="modal" data-dismiss="modal" title="Close">
								<i class="fa fa-times"></i>
							</button>
						</div>
					</div>

					<!-- Modal Body (Flexes to fill resized space) -->
					<div class="modal-body p-0 position-relative" id="previewViewport">
						<div id="panGlassOverlay"></div>
						<div id="previewTransformContainer">
							<iframe id="iframeFilePreview" src=""></iframe>
						</div>
					</div>

					<!-- RESIZE HANDLES (Right, Bottom, Bottom-Right) -->
					<div class="modal-resizer resizer-e"></div>
					<div class="modal-resizer resizer-s"></div>
					<div class="modal-resizer resizer-se" title="Drag to resize">
						<i class="fa fa-grip-lines-vertical" style="transform: rotate(45deg); font-size: 10px; color: #a1a5b7;"></i>
					</div>

				</div>
			</div>
		</div>

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
	<script type="text/javascript" src="Assets/js/SCM/SCM060100.js"></script>
	<!-- script related to this page -->

</asp:Content>
