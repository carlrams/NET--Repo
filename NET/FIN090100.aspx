<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FIN090100.aspx.vb" Inherits="NET.FIN090100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Cashiering (Receipting)</li>
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
						<img src="Assets/media/svg/apps/FIN090000.svg" alt="" />
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
									<button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
									<button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
									<div class="form-check form-check-custom form-check-success form-check-solid form-check-lg m-1">
										<input class="form-check-input" type="checkbox" value="" id="cbx0101Post" onclick="return false;"/>
									</div>
									<button id="btn0101Post" class="btn btn-sm btn-icon btn-post align-self-center m-1" title="Post" onclick="fn0101Post();return false;"><i class="las la-check-circle fs-2"></i></button>
									<span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
                                    <button id="btn0101Tools" class="btn btn-sm btn-icon btn-tools align-self-center m-1" title="Tools" onclick="fn0101Tools();return false;"><i class="las la-cog fs-2"></i></button>
								</div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Type</span>
											<span id="lbl0101Type" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">OR No</span>
											<span id="lbl0101ORNo" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">OR Date</span>
											<span id="lbl0101ORDate" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Particular</span>
											<span id="lbl0101Particular" class="form-control">-</span>
										</div>
                                    </div>
						            <div class="separator separator-dashed my-4"></div>

									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Payor Class</span>
											<span id="lbl0101PayorClass" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-4 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Payor</span>
											<span id="lbl0101AcctNo" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-8 col-lg-8">
										<div class="input-group input-group-sm">
											<span id="lbl0101PayorName" class="form-control">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Project</span>
											<span id="lbl0101Subdivision" class="form-control">-</span>
										</div>
										<div class="input-group input-group-sm d-none">
											<span class="input-group-text min-w-150px">Project Code</span>
											<span id="lbl0101SubdivisionCode" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Phase</span>
											<span id="lbl0101Phase" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Block</span>
											<span id="lbl0101Block" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Lot</span>
											<span id="lbl0101Lot" class="form-control">-</span>
										</div>
									</div>
						            <div class="separator separator-dashed my-4"></div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Transaction Number</span>
											<span id="lbl0101TransactionNumber" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Transaction Date</span>
											<span id="lbl0101TransactionDate" class="form-control">-</span>
										</div>
									</div>
						            <div class="separator separator-dashed my-4"></div>
                                </div>

						        <!--begin::Payment Application-->
                                <div class="row g-2">
                                    <div class="col-sm-12 col-md-12 col-lg-12 mb-2">
                                        <div class="card card-xl-stretch">
                                            <table id="table0101Application" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
                                                <thead>
                                                <tr class="fw-bold fs-7 text-gray-800">
                                                    <th class="min-w-150px w-70 fw-bold border-end">Application</th>
                                                    <th class="min-w-150px w-30 fw-bold">Amount</th>
                                                </tr>
                                                </thead>
                                                <tbody>
                                            </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
						        <!--end::Payment Application-->
								<div class="row g-2">
						            <div class="separator separator-dashed my-4"></div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px" style="font-weight: bold;">For Payment</span>
											<span id="lbl0101ForPayment" class="form-control text-end" style="font-weight: bold;">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-1 col-lg-1">
                                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
				                            <input id="lbl0101IsCash" class="form-check-input" type="checkbox" value="" onclick="return false;" />
				                            <label class="form-check-label">
					                            Cash
				                            </label>
                                        </div>
									</div>
									<div class="col-sm-12 col-md-11 col-lg-11">
										<div class="input-group input-group-sm">
											<span id="lbl0101Cash" class="form-control text-end">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-1 col-lg-1">
                                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
				                            <input id="lbl0101IsCheck" class="form-check-input" type="checkbox" value="" onclick="return false;" />
				                            <label class="form-check-label">
					                            Check
				                            </label>
                                        </div>
									</div>
									<div class="col-sm-12 col-md-11 col-lg-11">
	                                    <div class="input-group input-group-sm position-relative">
											<span id="CheckDetailsVisible" class="svg-icon svg-icon-2 top-50 translate-middle-y ps-2 pointer position-absolute d-none" style="z-index: 10;" onclick="fn0101CheckDetails();return false;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
		                                    </span>
											<span id="lbl0101Check" class="form-control border-left-1 text-end">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-1 col-lg-1">
                                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm text-nowrap" style="padding-left:5px">
				                            <input id="lbl0101IsRem" class="form-check-input" type="checkbox" value="" onclick="return false;" />
				                            <label class="form-check-label">
					                            Bank Rmt
				                            </label>
                                        </div>
									</div>
									<div class="col-sm-12 col-md-2 col-lg-2">
										<div class="input-group input-group-sm">
											<span id="lbl0101BankRem" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span id="lbl0101Bank" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span id="lbl0101PRDate" class="form-control">-</span>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span id="lbl0101RmtAmt" class="form-control text-end">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px" style="font-weight: bold;">Received</span>
											<span id="lbl0101Received" class="form-control text-end" style="font-weight: bold;">-</span>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px" style="font-weight: bold;">Change</span>
											<span id="lbl0101Change" class="form-control text-end" style="font-weight: bold;">-</span>
										</div>
									</div>
						            <div class="separator separator-dashed my-4"></div>
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Prepared By</span>
                                            <span id="lbl0101PreparedByName" class="form-control">-</span>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <span id="lbl0101PreparedDate" class="form-control">-</span>
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
								</div>
							</div>
							<div id="div0101Update" class="card-body" style="display:none">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Type</span>
											<input id="tbx0101Type" type="text" class="form-control" Placeholder="Type" readonly />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">OR No</span>
											<input id="tbx0101ORNo" type="text" class="form-control" Placeholder="OR No" readonly />
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm d-flex align-items-center position-relative">
										<span class="input-group-text min-w-150px required">OR Date</span>
                                            <input id="tbx0101ORDate" type="text" class="form-control" data-kt-repeater="datepicker" readonly Placeholder="OR Date" maxlength="20" />
                                            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                            <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0101ORDate');return false;">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                                    <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                                </svg>
                                            </a>
                                            <!--end::Svg Icon-->
										</div>
                                    </div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Particular</span>
											<input id="tbx0101Particular" type="text" class="form-control" Placeholder="Particular" maxlength="5000" />
										</div>
                                    </div>
						            <div class="separator separator-dashed my-4"></div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Payor Class</span>
											<input id="tbx0101PayorClass" type="text" class="form-control" Placeholder="Payor Class" readonly />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-4 col-lg-4">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Payor</span>
											<input id="tbx0101AcctNo" type="text" class="form-control" Placeholder="Payor" readonly />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-8 col-lg-8">
										<div class="input-group input-group-sm">
											<input id="tbx0101PayorName" type="text" class="form-control" Placeholder="Payor Name" readonly />
										</div>
									</div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Project</span>
											<input id="tbx0101Subdivision" type="text" class="form-control" Placeholder="Project" readonly/>
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Phase</span>
											<input id="tbx0101Phase" type="text" class="form-control" Placeholder="Phase" readonly />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Block</span>
											<input id="tbx0101Block" type="text" class="form-control" Placeholder="Block" readonly />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Lot</span>
											<input id="tbx0101Lot" type="text" class="form-control" Placeholder="Lot" readonly />
										</div>
									</div>
						            <div class="separator separator-dashed my-4"></div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px">Transaction Number</span>
											<input id="tbx0101TransactionNumber" type="text" class="form-control" Placeholder="Transaction No." readonly />
										</div>
                                    </div>
									<div class="col-sm-12 col-md-6 col-lg-6">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Transaction Date</span>
											<input id="tbx0101TransactionDate" type="text" class="form-control" Placeholder="Transaction Date" readonly />
										</div>
									</div>
						            <div class="separator separator-dashed my-4"></div>
                                </div>

						        <!--begin::Payment Application-->
                                <div class="row g-2">
                                    <div class="col-sm-12 col-md-12 col-lg-12 mb-2">
                                        <div class="card card-xl-stretch">
                                            <table id="table0101ApplicationUpdate" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
                                                <thead>
                                                <tr class="fw-bold fs-7 text-gray-800">
                                                    <th class="min-w-150px w-70 fw-bold border-end">Application</th>
                                                    <th class="min-w-150px w-30 fw-bold">Amount</th>
                                                </tr>
                                                </thead>
                                                <tbody>
                                            </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
						        <!--end::Payment Application-->

								<div class="row g-2">
						            <div class="separator separator-dashed my-4"></div>
									<div class="col-sm-12 col-md-12 col-lg-12">
										<div class="input-group input-group-sm">
											<span class="input-group-text min-w-150px" style="font-weight: bold;">For Payment</span>
											<input id="tbx0101ForPayment" type="text" class="form-control text-end" style="font-weight: bold;" Placeholder="For Payment" readonly />
										</div>
									</div>
									<div class="col-sm-12 col-md-1 col-lg-1">
                                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
				                            <input id="cbx0101IsCash" class="form-check-input" type="checkbox" value="" onchange="cbx0101IsCash_onchange(this);" />
				                            <label class="form-check-label" for="cbx0101IsCash">
					                            Cash
				                            </label>
                                        </div>
									</div>
									<div class="col-sm-12 col-md-11 col-lg-11">
										<div class="input-group input-group-sm">
											<input id="tbx0101Cash" type="text" class="form-control text-end" Placeholder="Cash" maxlength="18" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" oninput="computeChange()" readonly />
										</div>
									</div>
									<div class="col-sm-12 col-md-1 col-lg-1">
                                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
				                            <input id="cbx0101IsCheck" class="form-check-input" type="checkbox" value="" onchange="cbx0101IsCheck_onchange(this);"/>
				                            <label class="form-check-label" for="cbx0101IsCheck">
					                            Check
				                            </label>
                                        </div>
									</div>
                                    <div class="col-sm-12 col-md-11 col-lg-11">
										<div class="input-group input-group-sm">
		                                    <input id="tbx0101Check" type="text" class="form-control text-end" placeholder="Check" maxlength="18" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" oninput="computeChange()" readonly />
                                        </div>
                                    </div>
									<div class="col-sm-12 col-md-1 col-lg-1">
                                        <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm text-nowrap" style="padding-left:5px">
				                            <input id="cbx0101IsRem" class="form-check-input" type="checkbox" value="" onchange="cbx0101IsRem_onchange(this);"/>
				                            <label class="form-check-label" for="cbx0101IsRem">
					                            Bank Rmt
				                            </label>
                                        </div>
									</div>
                                    <div class="col-sm-12 col-md-2 col-lg-2">
                                        <div class="input-group input-group-sm">
                                            <input id="tbx0101BankRem" type="text" class="form-control" Placeholder="Reference No" maxlength="13" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm">
											<select id="ddl0101Bank" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" disabled >
										        <option value="">Bank</option>
									        </select>
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-3 col-lg-3">
										<div class="input-group input-group-sm d-flex align-items-center position-relative">
                                            <input id="tbx0101PRDate" type="text" class="form-control" data-kt-repeater="datepicker" readonly Placeholder="PR Date" maxlength="20" disabled />
                                            <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                            <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0101PRDate');return false;">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                                    <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                                </svg>
                                            </a>
                                            <!--end::Svg Icon-->
										</div>
                                    </div>
                                    <div class="col-sm-12 col-md-3 col-lg-3">
                                        <div class="input-group input-group-sm">
                                            <input id="tbx0101RmtAmt" type="text" class="form-control text-end" Placeholder="Remittance" maxlength="18" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" oninput="computeChange()" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px" style="font-weight: bold;">Received</span>
                                            <input id="tbx0101Received" type="text" class="form-control text-end" style="font-weight: bold;" Placeholder="Received" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12">
                                        <div class="input-group input-group-sm mb-2">
                                            <span class="input-group-text min-w-150px" style="font-weight: bold;">Change</span>
                                            <input id="tbx0101Change" type="text" class="form-control text-end" style="font-weight: bold;" Placeholder="Change" readonly />
                                        </div>
                                    </div>
						            <div class="separator separator-dashed my-4"></div>
                                    <div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Prepared By</span>
                                            <input id="tbx0101PreparedByName" type="text" class="form-control" Placeholder="Prepared By" maxlength="180" readonly />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-6">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-text min-w-150px">Date</span>
                                            <input id="tbx0101PreparedDate" type="text" class="form-control" Placeholder="Date" maxlength="20" readonly />
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

		<!--begin::Modal Check Details-->
		<div id="mdl0101CheckDetails" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-850px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Cashiering (Receipting) - Check Details</h5>
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
                    <div class="row gx-2">
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <div class="input-group input-group-sm border-0">
                                <a class="mb-2" title="Clear Fields" onclick="fnClearCheckDetails(this); return false;">
                                    <span class="btn btn-sm btn-icon btn-light-danger form-control form-control-sm me-2">
                                        <!--begin::Svg Icon | path: icons/duotune/general/gen019.svg-->
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor" />
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor" />
                                        </svg>
                                        <!--end::Svg Icon-->
                                    </span>
                                </a>
                                <select id="ddl0101BankCheckDetails" data-kt-repeater="select2" data-dropdown-parent="#mdl0101CheckDetails" class="form-select form-select-sm min-h-38px mb-2">
                                    <option value="">Bank</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <input id="tbx0101CheckNoDetails" type="text" class="form-control form-control-sm mb-2" placeholder="Check No." value="" maxlength="50" />
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <div class="d-flex align-items-center position-relative w-100 mb-2" style="margin-left:1px">
                                <input id="tbx0101CheckDateDetails" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly placeholder="Date" maxlength="20" />
                                <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0101CheckDateDetails');return false;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                        <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1"transform="rotate(-45 7.05025 15.5356)" fill="currentColor" />
                                        <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor" />
                                    </svg>
                                </a>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <input id="tbx0101CheckAmtDetails" type="text" class="form-control form-control-sm text-end mb-2" placeholder="Amount" maxlength="18" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" oninput="computeCheckTotal()" />
                        </div>
                    </div>
                    <div class="row gx-2">
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <div class="input-group input-group-sm border-0">
                                <a class="mb-2" title="Clear Fields" onclick="fnClearCheckDetails2(this); return false;">
                                    <span class="btn btn-sm btn-icon btn-light-danger form-control form-control-sm me-2">
                                        <!--begin::Svg Icon | path: icons/duotune/general/gen019.svg-->
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor" />
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor" />
                                        </svg>
                                        <!--end::Svg Icon-->
                                    </span>
                                </a>
                                <select id="ddl0101BankCheckDetails2" data-kt-repeater="select2" data-dropdown-parent="#mdl0101CheckDetails" class="form-select form-select-sm min-h-38px mb-2">
                                    <option value="">Bank</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <input id="tbx0101CheckNoDetails2" type="text" class="form-control form-control-sm mb-2" placeholder="Check No." value="" maxlength="50" />
                        </div>
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <div class="d-flex align-items-center position-relative w-100 mb-2" style="margin-left:1px">
                                <input id="tbx0101CheckDateDetails2" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly Placeholder="Date" maxlength="20" />
                                <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0101CheckDateDetails2');return false;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                        <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                        <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                    </svg>
                                </a>
                                <!--end::Svg Icon-->
                            </div>
						</div>
                        <div class="col-sm-12 col-md-3 col-lg-3">
							<input id="tbx0101CheckAmtDetails2" type="text" class="form-control form-control-sm text-end mb-2" Placeholder="Amount" maxlength="18" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" oninput="computeCheckTotal()" />
						</div>
                    </div>
                    <div class="row gx-2">
                            <div class="col">
                                <div class="input-group input-group-sm">
                                    <span class="input-group-text min-w-150px">Total</span>
                                    <input id="tbx0101CheckDetailsTotal" type="text" class="form-control form-control-sm text-end" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" value ="0.00" readonly />
                                </div>
                            </div>
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0101SaveCheck(this);return false;">
                            <span class="indicator-label">
				                Save
                            </span>
                            <span class="indicator-progress">
				                Processing
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
		<!--begin::Modal Check Details-->

		<!--begin::Modal Tools-->
		<div id="mdl0101Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT01();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Payment Order (PDC)</div>
							            </a>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT02();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Payment Order (Remittance)</div>
							            </a>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT03();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">OR Settings</div>
							            </a>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT04();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/TOOLS.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">OR Reversal</div>
							            </a>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="row">
				            <div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT05();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Official Receipt</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT06();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Cash Invoice</div>
							            </a>
							            <div class="fs-7 fw-bold text-gray-400">(Printout)</div>
						            </div>
					            </div>
				            </div>
				            <div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
					            <div class="card h-100">
						            <div class="card-body d-flex justify-content-center text-center flex-column p-8">
							            <a class="text-gray-800 d-flex flex-column pointer" onclick="fn0101_FIN09RPT07();return false;">
								            <div class="symbol symbol-60px mb-5">
									            <img src="Assets/media/svg/apps/RPT.svg" alt="" />
								            </div>
								            <div class="fs-5 fw-bolder mb-2">Proof List</div>
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
		<!--begin::Modal Tools-->
        
		<!--begin::Modal PDC record-->
		<div id="mdl0102PDC" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - Payment Order (PDC/ADA)</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <!-- Search -->
                                <div class="position-relative flex-grow-1 me-2">
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
                                                transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                            <path
                                                d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
                                                fill="currentColor" />
                                        </svg>
                                    </span>
                                    <input id="tbx0102Find" type="text"
                                        data-kt-inbox-listing-filter="search"
                                        class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12"
                                        placeholder="Search" />
                                </div>

                                <!-- Bars button -->
                                <div>
                                    <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                                        <i class="las la-bars fs-3"></i>
                                    </button>
                                    <div id="div0102ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
                                        <div class="menu-item px-3">
                                            <a href="#" class="menu-link px-3" onclick="fn0102Filter();return false;">Filter</a>
                                        </div>
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
                        <div class="table-loading">
                            <div id="div0102Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0102Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">Acct. No.</th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Acct. Name</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Drawee Bank</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Type</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check No.</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check Date</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Check Amt.</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Depository Bank</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Application</th>
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
		<!--begin::Modal PDC record-->

		<!--begin::Modal Filter-->
		<div id="mdl0102Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Cashiering (Receipting) Payment Order (PDC/ADA) - Filter record</h5>
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
                        <div class="row gx-2 gy-2 mb-2">
                            <div class="col-12">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
                                    <input id="tbx0102Date" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly Placeholder="Date" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0102Date');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
						    </div>
                        </div>
					</div>

                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0102Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Processing
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
        
		<!--begin::Modal Remittance record-->
		<div id="mdl0103Remittance" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - Payment Order (Remittance)</h5>
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
                                    <input id="tbx0103Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div0103Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0103Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
						                <th class="min-w-150px mw-150px fw-bold border-end">Reference</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Bank</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Date</th>
                                        <th class="min-w-150px mw-100px fw-bold border-end">Amount</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Class</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Payor</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Payor Name</th>
                                        <th class="min-w-250px mw-250px fw-bold border-end">Application</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Status</th>
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
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0103Add_Ok(this); return false;">
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
		<!--begin::Modal Remittance record-->
        
        <!--begin::Modal OR record-->
        <div id="mdl0104OR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
		        <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - OR Settings</h5>
					</div>
                    <div class="card-header">
                        <div class="d-flex flex-wrap">
                            <button id="btn0104Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0104Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
                            <span class="bullet h-30px w-2px bg-secondary mt-6 m-1"></span>
                            <button id="btn0104Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0104Delete();return false;"><i class="las la-trash fs-2"></i></button>
                            <button id="btn0104Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0104Edit();return false;"><i id="i0104Edit" class="las la-pencil-alt fs-2"></i></button>
                        </div>
                    </div>
			        <div class="modal-body">
                        <div id="div0104Detail">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">User</span>
                                <span id="lbl0104User" type="text" class="form-control" Placeholder="User"></span>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Branch</span>
                                <span id="lbl0104Branch" type="text" class="form-control" Placeholder="Branch"></span>
                            </div>
                            <div class="row g-2">
                                <div class="col-sm-12 col-md-12 col-lg-9"> 
                                    <div class="input-group input-group-sm mb-2">
                                        <span class="input-group-text min-w-150px">OR No.</span>
                                        <span id="lbl0104ORNo" type="text" class="form-control" Placeholder="OR No."></span>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-12 col-lg-3"> 
                                    <div class="input-group input-group-sm mb-2">
                                        <span id="lbl0104Location" type="text" class="form-control" Placeholder="Location"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Small OR No.</span>
                                <span id="lbl0104SmallORNo" type="text" class="form-control" Placeholder="Small OR No."></span>
                            </div>
                        </div>
                        <div id="div0104Update" style="display:none">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">User</span>
                                <input id="tbx0104User" type="text" class="form-control" Placeholder="User" readonly />
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px">Branch</span>
                                <input id="tbx0104Branch" type="text" class="form-control" Placeholder="Branch" readonly />
                            </div>
                            <div class="row g-2">
                                <div class="col-sm-12 col-md-12 col-lg-9">
                                    <div class="input-group input-group-sm mb-2">
                                        <span class="input-group-text min-w-150px required">OR No.</span>
                                        <input id="tbx0104ORNo" type="text" class="form-control" Placeholder="OR No." maxlength="500" />
                                    </div>
                                 </div>
                                <div class="col-sm-12 col-md-12 col-lg-3">
                                    <div class="input-group input-group-sm mb-2">
                                        <input id="tbx0104Location" type="text" class="form-control" Placeholder="Location" readonly />
                                    </div>
                                 </div>
                            </div>
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Small OR No.</span>
                                <input id="tbx0104SmallORNo" type="text" class="form-control" Placeholder="Small OR No." maxlength="500" />
                            </div>
                        </div>
			        </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
                    <!--end::Actions-->
		        </div>
	        </div>
        </div>
        <!--begin::Modal OR record-->
        
		<!--begin::Modal OR Reversal record-->
		<div id="mdl0105Reversal" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog  modal-dialog-centered mw-1000px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Cashiering (Receipting) - OR Reversal</h5>
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
                                    <input id="tbx0105Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div0105Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table0105Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-150px mw-150px fw-bold border-end">OR No.</th>
                                        <th class="min-w-200px mw-150px fw-bold border-end">OR Date</th>
                                        <th class="min-w-150px w-100 fw-bold border-end">Payee</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Amount</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text min-w-150px">Reason</span>
                            <input id="tbx0105Reason" type="text" class="form-control" Placeholder="Reason" maxlength="500" />
                        </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0105Add_Ok(this); return false;">
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
		<!--begin::Modal OR Reversal record-->

		<!--begin::Modal Filter-->
		<div id="mdl0106Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Proof List Report - Filter record</h5>
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
                        <select id="ddl0106Format" data-kt-repeater="select2" data-dropdown-parent="#mdl0106Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Select Format</option>
                            <option value="Group">Group</option>
                            <option value="Series">Series</option>
                        </select>
                        <select id="ddl0106Branch" data-kt-repeater="select2" data-dropdown-parent="#mdl0106Filter" class="form-select form-select-sm min-h-38px mb-2">
                            <option value="">Select Branch</option>
                            <option value="0">All</option>
                            <option value="3">Bay Office</option>
                            <option value="4">Lipa Office</option>
                            <option value="1">Main Office</option>
                            <option value="5">Makati Office</option>
                            <option value="2">SM Lucena Office</option>
                            <option value="6">Sonrisa Office</option>
                        </select>
                        <div class="row gx-2 gy-2 mb-2">
                            <div class="col-12">
                                <div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
                                    <input id="tbx0106Date" type="text" class="form-control form-control-sm" data-kt-repeater="datepicker" readonly Placeholder="Date" maxlength="20" />
                                    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                    <a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0106Date');return false;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
                                            <rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
                                        </svg>
                                    </a>
                                    <!--end::Svg Icon-->
                                </div>
						    </div>
                        </div>
					</div>

                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0106Filter_Ok(this);return false;">
                            <span class="indicator-label">
				                Filter
                            </span>
                            <span class="indicator-progress">
				                Processing
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
        
		<!--begin::Modal Upload-->
		<div id="mdl0202Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
		<div id="mdl0302Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
	<input id="hdnORMode" runat="server" type="hidden" value="" />
	<input id="hdnDate" runat="server" type="hidden" value="" />
	<input id="hdnAcctNo" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
    <input id="hdnBranchName" type="hidden" value="false" />

	<!--param-->

	<!-- scripts related to this page -->
	<script type="text/javascript">

        //variable
        var FileCount = 0;
        //variable

		//general
        function fn01Load() {
            fnAccess('FIN090000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090000',
                            'pType': 'Get Branch',
                        },
                        success: function (response) {
                            document.getElementById("hdnBranchName").value = response[0].BranchName;
                        },
                    });
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
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
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Post").classList.remove("btn-post");
                document.getElementById("btn0101Tools").classList.remove("btn-tools");
                document.getElementById("btn0201Add").classList.remove("btn-add");
                document.getElementById("btn0301Add").classList.remove("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = pValue;
                }
			} else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Post").classList.add("btn-post");
                document.getElementById("btn0101Tools").classList.add("btn-tools");
                document.getElementById("btn0201Add").classList.add("btn-add");
                document.getElementById("btn0301Add").classList.add("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = pValue;
                }
			}

            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Delete").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Post").disabled = pValue;
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
        }
        function ddl0101Bank(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'pFormCode': 'FIN090000',
                    'pType': 'Get Bank',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101Bank").html(s);
                    $('#ddl0101Bank').val(ID).trigger('change');
                },
            });
        }
        function ddl0101BankCheckDetails(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'pFormCode': 'FIN090000',
                    'pType': 'Get Bank',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101BankCheckDetails").html(s);
                    $('#ddl0101BankCheckDetails').val(ID).trigger('change');
                },
            });
        }
        function ddl0101BankCheckDetails2(ID) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'pFormCode': 'FIN090000',
                    'pType': 'Get Bank',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101BankCheckDetails2").html(s);
                    $('#ddl0101BankCheckDetails2').val(ID).trigger('change');
                },
            });
        }
        function cbx0101IsCash_onchange() {
            if (document.getElementById("cbx0101IsCash").checked == true) {
                document.getElementById("tbx0101Cash").readOnly = false;
                document.getElementById("cbx0101IsRem").checked = false
                document.getElementById("tbx0101BankRem").value = "";
                document.getElementById("tbx0101BankRem").readOnly = true;
                $('#ddl0101Bank').val('0').trigger('change');
                document.getElementById("ddl0101Bank").disabled = true;
                document.getElementById("tbx0101PRDate").value = "";
                document.getElementById("tbx0101PRDate").disabled = true;
                document.getElementById("tbx0101RmtAmt").value = "0.00";
                document.getElementById("tbx0101RmtAmt").readOnly = true;

            } else if (document.getElementById("cbx0101IsCash").checked == false) {
                document.getElementById("tbx0101Cash").value = "0.00";
                document.getElementById("tbx0101Cash").readOnly = true;
            }
            document.getElementById("tbx0101Received").value = (((parseFloat(document.getElementById("tbx0101Cash").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101Check").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101RmtAmt").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            document.getElementById("tbx0101Change").value = (((parseFloat(document.getElementById("tbx0101Received").value.replace(/,/g, '')) || 0) - (parseFloat(document.getElementById("tbx0101ForPayment").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
        function cbx0101IsCheck_onchange() {
            if (document.getElementById("cbx0101IsCheck").checked == true) {
                document.getElementById("cbx0101IsRem").checked = false
                document.getElementById("tbx0101BankRem").value = "";
                document.getElementById("tbx0101BankRem").readOnly = true;
                $('#ddl0101Bank').val('0').trigger('change');
                document.getElementById("ddl0101Bank").disabled = true;
                document.getElementById("tbx0101PRDate").value = "";
                document.getElementById("tbx0101PRDate").disabled = true;
                document.getElementById("tbx0101RmtAmt").value = "0.00";
                document.getElementById("tbx0101RmtAmt").readOnly = true;

            } else if (document.getElementById("cbx0101IsCheck").checked == false) {
                document.getElementById("tbx0101Check").value = "0.00";
                document.getElementById("tbx0101Check").readOnly = true;
            }
            document.getElementById("tbx0101Received").value = (((parseFloat(document.getElementById("tbx0101Cash").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101Check").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101RmtAmt").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            document.getElementById("tbx0101Change").value = (((parseFloat(document.getElementById("tbx0101Received").value.replace(/,/g, '')) || 0) - (parseFloat(document.getElementById("tbx0101ForPayment").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
        function cbx0101IsRem_onchange() {
            if (document.getElementById("cbx0101IsRem").checked == true) {
                document.getElementById("cbx0101IsCash").checked = false
                document.getElementById("tbx0101Cash").value = "0.00";
                document.getElementById("tbx0101Cash").readOnly = true;
                document.getElementById("cbx0101IsCheck").checked = false
                document.getElementById("tbx0101Check").value = "0.00";
                document.getElementById("tbx0101Check").readOnly = true;
                document.getElementById("tbx0101BankRem").readOnly = false;
                document.getElementById("ddl0101Bank").disabled = false;
                document.getElementById("tbx0101PRDate").disabled = false;
                document.getElementById("tbx0101RmtAmt").readOnly = false;
            } else if (document.getElementById("cbx0101IsRem").checked == false) {
                document.getElementById("tbx0101Cash").readOnly = false;
                document.getElementById("tbx0101BankRem").readOnly = true;
                $('#ddl0101Bank').val('0').trigger('change');
                document.getElementById("ddl0101Bank").disabled = true;
                document.getElementById("tbx0101PRDate").value = "";
                document.getElementById("tbx0101PRDate").disabled = true;
                document.getElementById("tbx0101RmtAmt").value = "0.00";
                document.getElementById("tbx0101RmtAmt").readOnly = true;
            }
            document.getElementById("tbx0101Received").value = (((parseFloat(document.getElementById("tbx0101Cash").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101Check").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101RmtAmt").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            document.getElementById("tbx0101Change").value = (((parseFloat(document.getElementById("tbx0101Received").value.replace(/,/g, '')) || 0) - (parseFloat(document.getElementById("tbx0101ForPayment").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
        function computeChange() {
            document.getElementById("tbx0101Received").value = (((parseFloat(document.getElementById("tbx0101Cash").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101Check").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101RmtAmt").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            document.getElementById("tbx0101Change").value = (((parseFloat(document.getElementById("tbx0101Received").value.replace(/,/g, '')) || 0) - (parseFloat(document.getElementById("tbx0101ForPayment").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
        //general

        //overview
        function fn0101LoadOverview(pMode, pID, pDate, pAcctNo) {
            if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090000',
                        'pType': 'Get Info - DTL',
                        'pID': pID,
                        'pDate': pDate,
                        'pAcctNo': pAcctNo
                    },
                    success: function (response) {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Get Application - DTL',
                                'pID': pID,
                                'pDate': pDate,
                                'pAcctNo': pAcctNo
                            },
                            success: function (response) {
                                $('#table0101Application').DataTable().destroy();

                                //disable column type detection
                                DataTable.types().forEach(type => {
                                    DataTable.type(type, 'detect', () => false);
                                });
                                //disable column type detection

                                //sort date by yyyy/mm/dd
                                $.fn.dataTable.moment('MM/DD/YYYY');
                                //sort date by yyyy/mm/dd

                                //datatable
                                var table0101Application = $("#table0101Application").DataTable({
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
                                        { data: 'Application' },
                                        { data: 'Amount', className: 'text-end' }],
                                    rowId: 'rowId',
                                    columnDefs: [],
                                    ordering: false
                                });
                                //datatable
                            },
                        });
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].PayorName;
                        document.getElementById("spn0101ID").innerText = response[0].ORNo;
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
                        if (response[0].Posted == "1") {
                            document.getElementById("cbx0101Post").checked = true;
                        } else {
                            document.getElementById("cbx0101Post").checked = false;
                        };
                        //checkbox

                        //content
                        document.getElementById("div0101Detail").style.display = "";
                        document.getElementById("div0101Update").style.display = "none";
                        document.getElementById("lbl0101Type").innerText = response[0].Type;
                        document.getElementById("lbl0101ORNo").innerText = response[0].ORNo;
                        document.getElementById("lbl0101ORDate").innerText = response[0].ORDate;
                        document.getElementById("lbl0101Particular").innerText = response[0].Particular;
                        document.getElementById("lbl0101PayorClass").innerText = response[0].PayorClass;
                        document.getElementById("lbl0101AcctNo").innerText = response[0].AcctNo;
                        document.getElementById("lbl0101PayorName").innerText = response[0].PayorName;
                        document.getElementById("lbl0101Subdivision").innerText = response[0].ProjName;
                        document.getElementById("lbl0101SubdivisionCode").innerText = response[0].ProjCode;
                        document.getElementById("lbl0101Phase").innerText = response[0].Phase;
                        document.getElementById("lbl0101Block").innerText = response[0].Block;
                        document.getElementById("lbl0101Lot").innerText = response[0].Lot;
                        document.getElementById("lbl0101TransactionNumber").innerText = response[0].TransactionNumber;
                        document.getElementById("lbl0101TransactionDate").innerText = response[0].TransactionDate;
                        document.getElementById("lbl0101ForPayment").innerText = response[0].DocAmount;
                        if (response[0].IsCash == "1") {
                            document.getElementById("lbl0101IsCash").checked = true;
                        } else {
                            document.getElementById("lbl0101IsCash").checked = false;
                        };
                        document.getElementById("lbl0101Cash").innerText = response[0].CashAmt;
                        if (response[0].IsCheck == "1") {
                            document.getElementById("lbl0101IsCheck").checked = true;
                        } else {
                            document.getElementById("lbl0101IsCheck").checked = false;
                        };
                        document.getElementById("lbl0101Check").innerText = response[0].CheckAmt;
                        document.getElementById("lbl0101BankRem").innerText = response[0].RmtCode;
                        document.getElementById("lbl0101Bank").innerText = response[0].BankCodeName;
                        document.getElementById("lbl0101PRDate").innerText = response[0].PRDate;
                        if (response[0].IsRemittance == "1") {
                            document.getElementById("lbl0101IsRem").checked = true;
                        } else {
                            document.getElementById("lbl0101IsRem").checked = false;
                        };
                        document.getElementById("lbl0101RmtAmt").innerText = response[0].RemittanceAmt;
                        document.getElementById("lbl0101Received").innerText = response[0].Received;
                        document.getElementById("lbl0101Change").innerText = response[0].Change;
                        document.getElementById("lbl0101PreparedByName").innerText = response[0].PreparedByName;
                        document.getElementById("lbl0101PreparedDate").innerText = response[0].PreparedDate;
                        document.getElementById("lbl0101PostedByName").innerText = response[0].PostedByName;
                        document.getElementById("lbl0101PostedDate").innerText = response[0].PostedDate;
                        ddl0101Bank('0');
                        ddl0101BankCheckDetails('0');
                        ddl0101BankCheckDetails2('0');
                        if (document.getElementById("lbl0101IsCheck").checked == true) {
                            document.getElementById("CheckDetailsVisible").classList.remove("d-none");
                        } else {
                            document.getElementById("CheckDetailsVisible").classList.add("d-none");
                        };
                        //content
                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090000',
                        'pType': 'Get Info - DTL',
                        'pID': pID,
                        'pDate': pDate,
                        'pAcctNo': pAcctNo
                    },
                    success: function (response) {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Get Application - DTL',
                                'pID': pID,
                                'pDate': pDate,
                                'pAcctNo': pAcctNo
                            },
                            success: function (response) {

                                $('#table0101ApplicationUpdate').DataTable().destroy();

                                //disable column type detection
                                DataTable.types().forEach(type => {
                                    DataTable.type(type, 'detect', () => false);
                                });
                                //disable column type detection

                                //sort date by yyyy/mm/dd
                                $.fn.dataTable.moment('MM/DD/YYYY');
                                //sort date by yyyy/mm/dd

                                //datatable
                                var table0101ApplicationUpdate = $("#table0101ApplicationUpdate").DataTable({
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
                                        { data: 'Application' },
                                        { data: 'Amount', className: 'text-end' }],
                                    rowId: 'rowId',
                                    columnDefs: [],
                                    ordering: false
                                });
                                //datatable
                            },
                        });
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].PayorName;
                        document.getElementById("spn0101ID").innerText = response[0].ORNo;
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
                        if (response[0].Posted == "1") {
                            document.getElementById("cbx0101Post").checked = true;
                        } else {
                            document.getElementById("cbx0101Post").checked = false;
                        };
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "none";
                        document.getElementById("div0101Update").style.display = "";
                        document.getElementById("tbx0101Type").value = response[0].Type;
                        document.getElementById("tbx0101ORNo").value = response[0].ORNo;
                        document.getElementById("tbx0101ORDate").value = response[0].ORDate;
                        document.getElementById("tbx0101Particular").value = response[0].Particular;
                        document.getElementById("tbx0101PayorClass").value = response[0].PayorClass;
                        document.getElementById("tbx0101AcctNo").value = response[0].AcctNo;
                        document.getElementById("tbx0101PayorName").value = response[0].PayorName;
                        document.getElementById("tbx0101Subdivision").value = response[0].ProjName;
                        document.getElementById("tbx0101Phase").value = response[0].Phase;
                        document.getElementById("tbx0101Block").value = response[0].Block;
                        document.getElementById("tbx0101Lot").value = response[0].Lot;
                        document.getElementById("tbx0101TransactionNumber").value = response[0].TransactionNumber;
                        document.getElementById("tbx0101TransactionDate").value = response[0].TransactionDate;
                        document.getElementById("tbx0101ForPayment").value = response[0].DocAmount;
                        if (response[0].IsCash == "1") {
                            document.getElementById("cbx0101IsCash").checked = true;
                            document.getElementById("tbx0101Cash").readOnly = false;
                        } else {
                            document.getElementById("cbx0101IsCash").checked = false;
                        };
                        document.getElementById("tbx0101Cash").value = response[0].CashAmt;
                        if (response[0].IsCheck == "1") {
                            document.getElementById("cbx0101IsCheck").checked = true;
                        } else {
                            document.getElementById("cbx0101IsCheck").checked = false;
                        };
                        document.getElementById("tbx0101Check").value = response[0].CheckAmt;
                        document.getElementById("tbx0101BankRem").value = response[0].RmtCode;
                        if (!response[0].BankCode) {
                            ddl0101Bank('0');
                        } else {
                            ddl0101Bank(response[0].BankCode);
                        }
                        document.getElementById("tbx0101PRDate").value = response[0].PRDate;
                        if (response[0].IsRemittance == "1") {
                            document.getElementById("cbx0101IsRem").checked = true;
                            document.getElementById("tbx0101BankRem").readOnly = false;
                            document.getElementById("ddl0101Bank").disabled = false;
                            document.getElementById("tbx0101PRDate").disabled = false;
                            document.getElementById("tbx0101RmtAmt").readOnly = false;
                        } else {
                            document.getElementById("cbx0101IsRem").checked = false;
                        };
                        document.getElementById("tbx0101RmtAmt").value = response[0].RemittanceAmt;
                        document.getElementById("tbx0101Received").value = response[0].Received;
                        document.getElementById("tbx0101Change").value = response[0].Change;
                        document.getElementById("tbx0101PreparedByName").value = response[0].PreparedByName;
                        document.getElementById("tbx0101PreparedDate").value = response[0].PreparedDate;
                        document.getElementById("tbx0101PostedByName").value = response[0].PostedByName;
                        document.getElementById("tbx0101PostedDate").value = response[0].PostedDate;
                        //content

                    },
                });
            }

        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Delete() {
            if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('FIN090000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('ICR_PaymentHeader', ID, '', 'Delete', function (response) {
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
                        //if exisit
                        fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                            if (response[0].oReturn == "1") {
                                Access();
                            } else {
                                window.location.replace("MNU040100");
                            };
                        });
                        //access
                        function Access() {
                            //access
                            fnAccess('FIN090000', 'Delete', function (response) {
                                if (response[0].oReturn == "1") {
                                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                                } else {
                                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                };
                            });
                        };
                        //validate
                        function Validate(ID) {
                            fnValidateRecord('ICR_PaymentHeader', ID, '', 'Delete', function (response) {
                                if (response[0].oReturn == "") {
                                    Detele_Ok(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        };
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('FIN090000','ICR_PaymentHeader', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("FIN090000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("FIN090000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                            document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                            document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
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
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
                    }
                });
            };
        };
        function fn0101Edit() {
            //validate
            if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('FIN090000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('ICR_PaymentHeader', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('FIN090000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('ICR_PaymentHeader', ID, '', 'Save', function (response) {
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
                if (document.getElementById("tbx0101ORDate").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101Particular").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("cbx0101IsRem").checked == true && (document.getElementById("tbx0101BankRem").value == "" || document.getElementById("tbx0101BankRem").value == "-")) {
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
                        if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                            //if exisit
                            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                if (response[0].oReturn == "1") {
                                    Access();
                                } else {
                                    window.location.replace("MNU040100");
                                };
                            });
                            //access
                            function Access() {
                                //access
                                fnAccess('FIN090000', 'Save', function (response) {
                                    if (response[0].oReturn == "1") {
                                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                                    } else {
                                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                    };
                                });
                            };
                            //validate
                            function Validate(ID) {
                                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Dtl_Ok_Await();
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            };
                        } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                            //if exisit
                            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                if (response[0].oReturn == "1") {
                                    Access();
                                } else {
                                    window.location.replace("MNU040100");
                                };
                            });
                            //access
                            function Access() {
                                //access
                                fnAccess('FIN090000', 'Save', function (response) {
                                    if (response[0].oReturn == "1") {
                                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                                    } else {
                                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                    };
                                });
                            };
                            //validate
                            function Validate(ID) {
                                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Upd_Ok_Await(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            };
                        }
                    }
                });
            };
            //do edit
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                if (document.getElementById("tbx0101BankRem").value == "-") {
                    document.getElementById("tbx0101BankRem").value = "";
                }
                if (document.getElementById("tbx0101PRDate").value == "-") {
                    document.getElementById("tbx0101PRDate").value = "";
                }
                if (document.getElementById("tbx0101RmtAmt").value == "-") {
                    document.getElementById("tbx0101RmtAmt").value = "";
                }
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090000',
                        'pType': 'Edit Record',
                        'pID': ID,
                        'pDocNo': document.getElementById("tbx0101ORNo").value,
                        'pDocDate': document.getElementById("tbx0101ORDate").value,
                        'pTransactionNumber': document.getElementById("tbx0101TransactionNumber").value,
                        'pParticular': document.getElementById("tbx0101Particular").value,
                        'pIsCash': document.getElementById("cbx0101IsCash").checked,
                        'pCashAmt': document.getElementById("tbx0101Cash").value,
                        'pIsCheck': document.getElementById("cbx0101IsCheck").checked,
                        'pCheckAmt': document.getElementById("tbx0101Check").value,
                        'pIsRem': document.getElementById("cbx0101IsRem").checked,
                        'pRmtCode': document.getElementById("tbx0101BankRem").value,
                        'pBankCode': document.getElementById("ddl0101Bank").options[document.getElementById("ddl0101Bank").selectedIndex].value,
                        'pPRDate': document.getElementById("tbx0101PRDate").value,
                        'pRemAmt': document.getElementById("tbx0101RmtAmt").value,
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                        document.getElementById('ContentPlaceHolder1_hdnDate').value = document.getElementById("tbx0101ORDate").value;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
                    },
                });
            };
        };
        function fn0101Post() {
            //if exist
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN090000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Post', function (response) {
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
                                //if exist
                                fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                    if (response[0].oReturn == "1") {
                                        Access();
                                    } else {
                                        window.location.replace("MNU040100");
                                    };
                                });
                                //access
                                function Access() {
                                    fnAccess('FIN090000', 'Post', function (response) {
                                        if (response[0].oReturn == "1") {
                                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                                        } else {
                                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                        };
                                    });
                                };
                                //validate
                                function Validate(ID) {
                                    fnValidateRecord('ICR_PaymentHeader', ID, '', 'Post', function (response) {
                                        if (response[0].oReturn == "") {
                                            Post_Ok(ID);
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                };
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function Post_Ok(ID) {
                fnValidateRecord('ICR_PaymentHeader', ID, '', 'Post', function (response) {
                    if (response[0].oReturn == "") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Post Record',
                                'pDocNo': ID,
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully posted.', 'success', 'btn btn-success');
                                if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
                                if (document.getElementById('lbl0101Type').innerText == "Regular OR") {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Generate CI',
                                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                            'pDate': document.getElementById('lbl0101ORDate').innerText,
                                        },
                                        success: function (response) {
                                            if (response.status === "success") {
                                                window.open(response.viewUrl, '_blank');
                                            } else {
                                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                            }
                                        }
                                    });
                                } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Generate SOR',
                                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                            'pDate': document.getElementById('lbl0101ORDate').innerText,
                                        },
                                        success: function (response) {
                                            if (response.status === "success") {
                                                window.open(response.viewUrl, '_blank');
                                            } else {
                                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                            }
                                        }
                                    });
                                }
                            },
                        });
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
        };
        function fn0101Tools() {
            $('#mdl0101Tools').modal('show');
        };
        //overview

        //check details
        function fn0101CheckDetails() {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'pFormCode': 'FIN090000',
                    'pType': 'Get Check',
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                },
                success: function (response) {
                    ddl0101BankCheckDetails(response[0].BankCode1);
                    document.getElementById("tbx0101CheckNoDetails").value = response[0].CheckNo1;
                    document.getElementById("tbx0101CheckDateDetails").value = response[0].CheckDate1;
                    document.getElementById("tbx0101CheckAmtDetails").value = response[0].CheckAmount1
                    ddl0101BankCheckDetails2(response[0].BankCode2);
                    document.getElementById("tbx0101CheckNoDetails2").value = response[0].CheckNo2;
                    document.getElementById("tbx0101CheckDateDetails2").value = response[0].CheckDate2;
                    document.getElementById("tbx0101CheckAmtDetails2").value = response[0].CheckAmount2
                    computeCheckTotal();
                },
            });

            $('#mdl0101CheckDetails').modal('show');
        };
        function fn0101SaveCheck() {
            fnValidateRecord('ICR_PaymentHeader', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    TotalCheckAmount = 0;

                    if (document.getElementById("ddl0101BankCheckDetails").options[document.getElementById("ddl0101BankCheckDetails").selectedIndex].value != 0 && document.getElementById("tbx0101CheckNoDetails").value != "" && document.getElementById("tbx0101CheckDateDetails").value != "" && parseFloat(document.getElementById("tbx0101CheckAmtDetails").value.replace(/,/g, '')) > 0) {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Get Mode',
                                'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                'pSeqNo': 1,
                            },
                            success: function (response) {
                                if (response[0].Mode == "Add") {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Add Check',
                                            'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                            'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                            'pSeqNo': 1,
                                            'pORNo': document.getElementById("lbl0101ORNo").innerText,
                                            'pProjCode': document.getElementById("lbl0101SubdivisionCode").innerText,
                                            'pPhase': document.getElementById("lbl0101Phase").innerText,
                                            'pBlock': document.getElementById("lbl0101Block").innerText,
                                            'pLot': document.getElementById("lbl0101Lot").innerText,
                                            'pAcctname': document.getElementById("lbl0101PayorName").innerText,
                                            'pBank': document.getElementById("ddl0101BankCheckDetails").options[document.getElementById("ddl0101BankCheckDetails").selectedIndex].value,
                                            'pCheckNo': document.getElementById("tbx0101CheckNoDetails").value,
                                            'pCheckDate': document.getElementById("tbx0101CheckDateDetails").value,
                                            'pCheckAmt': document.getElementById("tbx0101CheckAmtDetails").value
                                        },
                                        success: function (response) {
                                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                        },
                                    });

                                } else if (response[0].Mode == "Update") {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Update Check',
                                            'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                            'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                            'pSeqNo': 1,
                                            'pBank': document.getElementById("ddl0101BankCheckDetails").options[document.getElementById("ddl0101BankCheckDetails").selectedIndex].value,
                                            'pCheckNo': document.getElementById("tbx0101CheckNoDetails").value,
                                            'pCheckDate': document.getElementById("tbx0101CheckDateDetails").value,
                                            'pCheckAmt': document.getElementById("tbx0101CheckAmtDetails").value,
                                        },
                                        success: function (response) {
                                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                        },
                                    });
                                }
                            },
                        });
                        TotalCheckAmount += parseFloat(document.getElementById("tbx0101CheckAmtDetails").value.replace(/,/g, '')) || 0;
                    } else if (document.getElementById("ddl0101BankCheckDetails").options[document.getElementById("ddl0101BankCheckDetails").selectedIndex].value == 0 || document.getElementById("tbx0101CheckNoDetails").value == "" || document.getElementById("tbx0101CheckDateDetails").value == "" || parseFloat(document.getElementById("tbx0101CheckAmtDetails").value.replace(/,/g, '')) <= 0) {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Delete Check',
                                'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                'pSeqNo': 1,
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                            },
                        });
                    }
                    if (document.getElementById("ddl0101BankCheckDetails2").options[document.getElementById("ddl0101BankCheckDetails2").selectedIndex].value != 0 && document.getElementById("tbx0101CheckNoDetails2").value != "" && document.getElementById("tbx0101CheckDateDetails2").value != "" && parseFloat(document.getElementById("tbx0101CheckAmtDetails2").value.replace(/,/g, '')) > 0) {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Get Mode',
                                'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                'pSeqNo': 2,
                            },
                            success: function (response) {
                                if (response[0].Mode == "Add") {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Add Check',
                                            'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                            'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                            'pSeqNo': 2,
                                            'pORNo': document.getElementById("lbl0101ORNo").innerText,
                                            'pProjCode': document.getElementById("lbl0101SubdivisionCode").innerText,
                                            'pPhase': document.getElementById("lbl0101Phase").innerText,
                                            'pBlock': document.getElementById("lbl0101Block").innerText,
                                            'pLot': document.getElementById("lbl0101Lot").innerText,
                                            'pAcctname': document.getElementById("lbl0101PayorName").innerText,
                                            'pBank': document.getElementById("ddl0101BankCheckDetails2").options[document.getElementById("ddl0101BankCheckDetails2").selectedIndex].value,
                                            'pCheckNo': document.getElementById("tbx0101CheckNoDetails2").value,
                                            'pCheckDate': document.getElementById("tbx0101CheckDateDetails2").value,
                                            'pCheckAmt': document.getElementById("tbx0101CheckAmtDetails2").value
                                        },
                                        success: function (response) {
                                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                        },
                                    });

                                } else if (response[0].Mode == "Update") {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090000',
                                            'pType': 'Update Check',
                                            'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                            'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                            'pSeqNo': 2,
                                            'pBank': document.getElementById("ddl0101BankCheckDetails2").options[document.getElementById("ddl0101BankCheckDetails2").selectedIndex].value,
                                            'pCheckNo': document.getElementById("tbx0101CheckNoDetails2").value,
                                            'pCheckDate': document.getElementById("tbx0101CheckDateDetails2").value,
                                            'pCheckAmt': document.getElementById("tbx0101CheckAmtDetails2").value,
                                        },
                                        success: function (response) {
                                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                        },
                                    });
                                }
                            },
                        });
                        TotalCheckAmount += parseFloat(document.getElementById("tbx0101CheckAmtDetails2").value.replace(/,/g, '')) || 0;
                    } else if (document.getElementById("ddl0101BankCheckDetails2").options[document.getElementById("ddl0101BankCheckDetails2").selectedIndex].value == 0 || document.getElementById("tbx0101CheckNoDetails2").value == "" || document.getElementById("tbx0101CheckDateDetails2").value == "" || parseFloat(document.getElementById("tbx0101CheckAmtDetails2").value.replace(/,/g, '')) <= 0) {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Delete Check',
                                'pAcctNo': document.getElementById("lbl0101AcctNo").innerText,
                                'pTrxnNo': document.getElementById("lbl0101TransactionNumber").innerText,
                                'pSeqNo': 2,
                            },
                            success: function (response) {
                                fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                            },
                        });
                    }

                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090000',
                            'pType': 'Update OR',
                            'pTotalAmount': TotalCheckAmount,
                            'pORNo': document.getElementById("lbl0101ORNo").innerText,
                            'pORDate': document.getElementById("lbl0101ORDate").innerText,
                        },
                        success: function (response) {
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnDate').value, document.getElementById('ContentPlaceHolder1_hdnAcctNo').value);
                            $('#mdl0101CheckDetails').modal('hide');

                        },
                    });
                } else {
                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                };
            });
        };
        function fnClearCheckDetails() {
            $('#ddl0101BankCheckDetails').val('0').trigger('change');
            document.getElementById("tbx0101CheckNoDetails").value = "";
            document.getElementById("tbx0101CheckDateDetails").value = "";
            document.getElementById("tbx0101CheckAmtDetails").value = "0.00";
            computeCheckTotal();
        };
        function fnClearCheckDetails2() {
            $('#ddl0101BankCheckDetails2').val('0').trigger('change');
            document.getElementById("tbx0101CheckNoDetails2").value = "";
            document.getElementById("tbx0101CheckDateDetails2").value = "";
            document.getElementById("tbx0101CheckAmtDetails2").value = "0.00";
            computeCheckTotal();
        };
        function computeCheckTotal() {
            document.getElementById("tbx0101CheckDetailsTotal").value = ((parseFloat(document.getElementById("tbx0101CheckAmtDetails").value.replace(/,/g, '')) || 0) + (parseFloat(document.getElementById("tbx0101CheckAmtDetails2").value.replace(/,/g, '')) || 0)).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        };
        //check details

        //tools

        // PDC
        function fn0101_FIN09RPT01() {
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Payment Order',
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
                        document.getElementById("div0102Loader").style.display = "";
                        //hide loader

                        $('#table0102Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table0102Record = $("#table0102Record").DataTable({
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
                                { data: 'AcctNo', },
                                { data: 'AcctName' },
                                { data: 'DraweeBankCodeName' },
                                { data: 'Type' },
                                { data: 'CheckNo' },
                                { data: 'CheckDate' },
                                { data: 'CheckAmt' },
                                { data: 'DepositoryBankCodeName' },
                                { data: 'Application' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0],
                                    orderable: false,
                                }
                                ,
                                {
                                    targets: [2, 3, 9],
                                    className: 'tbody-nowrap-auto'
                                },
                                {
                                    targets: [7],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
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
                        $('#tbx0102Find').on('keyup', function () {
                            table0102Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div0102Loader").style.display = "none";
                        //hide loader

                        // close Swal loader when everything is done
                        Swal.close();
                        }
                    });
                //modal
                $('#mdl0102PDC').modal('show');
            };
        };
        function fn0102Filter() {
            document.getElementById("tbx0102Date").value = '';
            $('#mdl0102Filter').modal('show');
        };
        function fn0102Filter_Ok(Btn) {
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
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090100',
                            'pType': 'Cashiering Tools - Payment Order',
                            'pDate': document.getElementById("tbx0102Date").value
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
                            document.getElementById("div0102Loader").style.display = "";
                            //hide loader

                            $('#table0102Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table0102Record = $("#table0102Record").DataTable({
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
                                    { data: 'AcctNo', },
                                    { data: 'AcctName' },
                                    { data: 'DraweeBankCodeName' },
                                    { data: 'Type' },
                                    { data: 'CheckNo' },
                                    { data: 'CheckDate' },
                                    { data: 'CheckAmt' },
                                    { data: 'DepositoryBankCodeName' },
                                    { data: 'Application' }
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0],
                                        orderable: false,
                                    }
                                    ,
                                    {
                                        targets: [2, 3, 9],
                                        className: 'tbody-nowrap-auto'
                                    },
                                    {
                                        targets: [7],
                                        className: 'dt-body-right',
                                        render: $.fn.dataTable.render.number(',', '.', 2)
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
                            $('#tbx0102Find').on('keyup', function () {
                                table0102Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div0102Loader").style.display = "none";
                            //hide loader

                            fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                            //resolve
                            resolve();
                            // close Swal loader when everything is done
                            Swal.close();
                        }
                    });
                });
            };
        };
        function fn0102Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
            //access
            fnAccess('FIN090000', 'Save', function (response) {
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
                var table0102Record = $('#table0102Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table0102Record.$('.row-checkbox', { page: 'all' });

                // Check if atleast one
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        AcctNo: checkBox.getAttribute('data-kt-code'),
                        CheckNo: checkBox.getAttribute('data-kt-no')
                }));
                if (checkedValues.length > 0) {
                    // Array
                    let ItemList = [];

                    // Loop
                    checkedValues.forEach(item => {

                        // Push
                        ItemList.push({
                            AcctNo: item.AcctNo,
                            CheckNo: item.CheckNo
                        });
                    });

                    let CheckSrs = ItemList.map(i =>
                        `${i.AcctNo}©${i.CheckNo}`
                    ).join('®');
                    PDC_Question(CheckSrs, Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
                function PDC_Question(CheckSrs, Btn) {
                    Swal.close(); // close loader before confirmation
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Current record/changes will be saved?</span>',
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
                            // Add Ok
                            $.ajax({
                                type: "POST",
                                url: "HNDAAD.ashx",
                                data: {
                                    'pFormCode': 'FIN090100',
                                    'pType': 'Cashiering Tools - New PDC Payment',
                                    'pCheckSrs': CheckSrs,
                                },
                                success: async function (response) {
                                    Swal.close();
                                    //alert
                                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                    //load
                                    // Destroy the DataTable before reloading
                                    if ($.fn.DataTable.isDataTable('#table0102Record')) {
                                        var table = $('#table0102Record').DataTable();
                                        table.clear().destroy();
                                    }
                                    $('#table0102Record tbody').empty();
                                    $("#mdl0102PDC").modal("hide");
                                    if (window.opener && typeof window.opener.fn01Add === 'function') {
                                        window.opener.fn01Add();
                                    }
                                    // Disable the clicked button to avoid multiple clicks
                                    Btn.disabled = false;
                                    // Hide loading indication
                                    Btn.removeAttribute('data-kt-indicator');
                                },
                            });
                        } else {
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                };
            };
        };
        // PDC

        // Remittance
        function fn0101_FIN09RPT02() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Remittance'
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
                        document.getElementById("div0103Loader").style.display = "";
                        //hide loader

                        $('#table0103Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table0103Record = $("#table0103Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            rowId: 'rowId',
                            columns: [
                                { data: 'RmtCode' },
                                { data: 'BankName' },
                                { data: 'Date' },
                                { data: 'Amount' },

                                // CLASS DROPDOWN
                                {
                                    data: 'Class',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let selectId = `class_${meta.row}`;
                                            let dropdown = `
                                                    <select id="class_${rowId}" prm0103Class="${rowId}" data-dropdown-parent="#mdl0103Remittance" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ddl-class" style="width:100%">
                                                        <option value="">Select Class</option>
                                                    </select>`;


                                            return dropdown;
                                        }
                                        return data;
                                    },
                                    createdCell: function (cell, cellData, rowData, rowIndex, colIndex) {
                                        let rowId = rowData.rowId;
                                        let dropdown = $(cell).find('[prm0103Class="' + rowId + '"]');

                                        // Fetch data asynchronously
                                        $.ajax({
                                            type: 'GET',
                                            url: 'HNDAAD.ashx',
                                            data: {
                                                'pFormCode': 'FIN090100',
                                                'pType': 'Remittance Class'
                                            },
                                            success: function (response) {
                                                let options = response.map(item => `<option value="${item.Code}">${item.Description}</option>`).join('');
                                                dropdown.html(`<option value="">Select Class</option>` + options);

                                                dropdown.select2();
                                            },
                                            error: function () {
                                                dropdown.html('<option>Error loading options</option>');
                                            }
                                        });
                                    }
                                },

                                // PAYOR (hidden, will be updated by PayorName)
                                {
                                    data: 'Payor',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;

                                            let textbox = `
                                                    <input prm0103Payor="${rowId}" type="text" class="w-100 outline-none border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" readonly />
                                                `;
                                            return textbox || "";
                                        }
                                        return data;
                                    }
                                },

                                // PAYORNAME DROPDOWN
                                {
                                    data: 'PayorName',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let selectId = `payor_${meta.row}`;
                                            let dropdown = `
                                                    <select id="payor_${rowId}" prm0103PayorName="${rowId}" data-dropdown-parent="#mdl0103Remittance" data-kt-repeater="select2"  class="form-select form-select-sm form-select-border ddl-payorname" style="width:100%">
                                                        <option value="">Select Payor</option>
                                                    </select>`;
                                            return dropdown;
                                        }
                                        return data;
                                    }
                                },

                                // APPLICATION DROPDOWN
                                {
                                    data: 'Application',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let selectId = `app_${meta.row}`;
                                            let dropdown = `
                                                        <select id="application_${rowId}" prm0103Application="${rowId}" data-dropdown-parent="#mdl0103Remittance" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ddl-application" style="width:100%">
                                                            <option value="">Select Application</option>
                                                        </select>`;
                                            return dropdown;
                                        }
                                        return data;
                                    }
                                },

                                { data: 'Status' }
                            ],

                            columnDefs: [
                                {
                                    targets: [3],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                }
                            ],

                            drawCallback: function () {
                                // initialize select2
                                $('[data-kt-repeater="select2"]').select2({
                                    width: '100%'
                                });

                                // Class
                                $("#table0103Record").on("change", ".ddl-class", function () {
                                    let classVal = $(this).val();
                                    let rowId = $(this).attr("prm0103Class");
                                    let ddlPayor = $(`[prm0103PayorName=${rowId}]`);
                                    ddlPayor.html(`<option>Select Class</option>`);

                                    $.ajax({
                                        type: 'GET',
                                        url: 'HNDAAD.ashx',
                                        data: {
                                            'pFormCode': 'FIN090100',
                                            'pType': 'Remittance Payor',
                                            'pClass': classVal
                                        },
                                        success: function (response) {
                                            let options = response.map(item =>
                                                `<option value="${item.Code}" data-payor="${item.Code}">${item.Description}</option>`
                                            ).join('');
                                            ddlPayor.html(`<option value="">Select Payor</option>` + options);
                                        },
                                        error: function () {
                                            ddlPayor.html('<option>Error loading options</option>');
                                        }
                                    });
                                });

                                // Payor
                                $("#table0103Record").on("change", ".ddl-payorname", function () {
                                    let payorVal = $(this).val();
                                    let rowId = $(this).data("rowId");
                                    let tr = $(this).closest("tr");     
                                    let tbxPayor = tr.find("[prm0103Payor]"); 
                                    tbxPayor.val(payorVal);
                                });

                                // Application
                                $("#table0103Record").on("change", ".ddl-class, .ddl-payorname", function () {
                                    let tr = $(this).closest("tr");
                                    let classVal = tr.find(".ddl-class").val();
                                    let payorVal = tr.find(".ddl-payorname").val();
                                    let ddlApplication = tr.find("[prm0103Application]");

                                    if (classVal && payorVal) {
                                        ddlApplication.html(`<option>Select Application</option>`);

                                        $.ajax({
                                            type: 'GET',
                                            url: 'HNDAAD.ashx',
                                            data: {
                                                'pFormCode': 'FIN090100',
                                                'pType': 'Remittance - Application'
                                            },
                                            success: function (response) {
                                                let options = response.map(item =>
                                                    `<option value="${item.Code}">${item.Description}</option>`
                                                ).join('');
                                                ddlApplication.html(`<option value="">Select Application</option>` + options);
                                            },
                                            error: function () {
                                                ddlApplication.html('<option>Error loading options</option>');
                                            }
                                        });
                                    } else {
                                        let tbxPayor = tr.find("[prm0103Payor]");
                                        tbxPayor.val('');
                                        // reset if one is missing
                                        ddlApplication.html('<option value="">Select Application</option>');
                                    }
                                });
                            },
                            initComplete: function () {
                                this.api().cells().every(function () {
                                    var cell = this.node();
                                    $(cell).attr('title', $(cell).text());
                                });
                            }
                        });
                        //datatable

                        //search
                        $('#tbx0103Find').on('keyup', function () {
                            table0103Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div0103Loader").style.display = "none";
                        //hide loader

                        // close Swal loader when everything is done
                        Swal.close();
                    }
                });
                //modal
                $('#mdl0103Remittance').modal('show');
            };
        };
        function fn0103Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
            //access
            fnAccess('FIN090000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn0103dd_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            async function fn0103dd_Ok_Await(Btn) {
                let table0103Record = $('#table0103Record').DataTable();
                var allRows = [];
                let cntr = 0;
                let hasError = false;

                table0103Record.rows().every(function () {
                    let rowData = this.data();
                    let tr = $(this.node());

                    let RmtCode = rowData.RmtCode || "";
                    let ClassCode = tr.find(".ddl-class").val() || "";
                    let AcctNo = tr.find("[prm0103Payor]").val() || "";
                    let AcctName = tr.find(".ddl-payorname option:selected").text() || "";
                    let PmtType = tr.find(".ddl-application").val() || "";

                    // Only proceed if all required fields are filled
                    if (RmtCode && ClassCode && AcctName && PmtType) {
                        allRows.push({
                            rowData: rowData,
                            tr: tr,
                            RmtCode: RmtCode,
                            ClassCode: ClassCode,
                            AcctNo: AcctNo,
                            AcctName: AcctName,
                            PmtType: PmtType
                        });
                    }
                });

                if (allRows.length === 0) {
                    fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    return;
                } else {
                    Add_Question();
                }

                async function Add_Question() {
                    const result = await Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Current record/changes will be saved?</span>',
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
                    });

                    if (result.isConfirmed) {
                        for (let row of allRows) {
                            try {
                                await $.ajax({
                                    type: "POST",
                                    url: "HNDAAD.ashx",
                                    data: {
                                        pFormCode: "FIN090100",
                                        pType: "Cashiering Tools - Add Remittance",
                                        pRmtCode: row.RmtCode,
                                        pClassCode: row.ClassCode,
                                        pAcctNo: row.AcctNo,
                                        pAcctName: row.AcctName,
                                        pPmtType: row.PmtType
                                    }
                                });
                                row.rowData.Status = "Success";
                                table0103Record.row(row.tr).data(row.rowData).invalidate();

                                cntr++;
                            } catch (err) {
                                hasError = true;
                            }
                        }

                        // Final message after loop
                        if (cntr === 0) {
                            fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                            //Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        } else if (!hasError) {
                            fnAlertOnly('Record successfully saved!', 'success', 'btn btn-success');
                            $("#mdl0103Remittance").modal("hide");
                            //Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        };
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                }
            };
        };
        // Remittance

        // OR
        function fn0101_FIN09RPT03() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    OR();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function OR() {
                document.getElementById("ContentPlaceHolder1_hdnORMode").value = "DTL";
                fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value)
            };
        };
        function fn0104Refresh() {
            document.getElementById("ContentPlaceHolder1_hdnORMode").value = "DTL";
            fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value)
        };
        function fn0104Edit() {
            if (document.getElementById("ContentPlaceHolder1_hdnORMode").value == "DTL") {
                //access
                fnAccess('FIN090000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        Edit_Dtl_Ok_Await("UPD");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
                //validate
                function Edit_Dtl_Ok_Await(pMode) {
                    document.getElementById("ContentPlaceHolder1_hdnORMode").value = pMode;
                    fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value);
                };
            } else if (document.getElementById("ContentPlaceHolder1_hdnORMode").value == "UPD") {
                //access
                fnAccess('FIN090000', 'Save', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields();
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
                function ValidateFields() {
                    if (document.getElementById("tbx0104ORNo").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx0104SmallORNo").value == "") {
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Upd_Question();
                    }
                };
                //question
                function Upd_Question() {
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
                            if (document.getElementById('ContentPlaceHolder1_hdnORMode').value == "DTL") {
                                Edit_Dtl_Ok_Await();
                            } else if (document.getElementById('ContentPlaceHolder1_hdnORMode').value == "UPD") {
                                Validate_Upd();
                            }
                        }
                    });
                };
                //validate
                function Validate_Upd() {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090100',
                            'pType': 'Cashiering Tools - Update OR/SOR',
                            'pORNo': document.getElementById("tbx0104ORNo").value,
                            'pSORNo': document.getElementById("tbx0104SmallORNo").value
                        },
                        success: function (response) {
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                            document.getElementById('ContentPlaceHolder1_hdnORMode').value = "DTL";
                            fn0104LoadOR(document.getElementById("ContentPlaceHolder1_hdnORMode").value);
                        }
                    });
                };
            };
        };
        function fn0104Delete() {
            if (document.getElementById("ContentPlaceHolder1_hdnORMode").value == "UPD") {
                Cancel_Upd_Question();
            };
            function Cancel_Upd_Question() {
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
                        document.getElementById('ContentPlaceHolder1_hdnORMode').value = "DTL"
                        fn0104LoadOR(document.getElementById('ContentPlaceHolder1_hdnORMode').value);
                    }
                });
            };
        };
        function fn0104LoadOR(pMode) {
            if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Get OR Settings',
                    },
                    success: function (response) {
                        fn04DisableButtons(false);
                        document.getElementById("i0104Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0104Edit").classList.remove("la-save");

                        document.getElementById("div0104Detail").style.display = "";
                        document.getElementById("div0104Update").style.display = "none";
                        document.getElementById("lbl0104User").innerText = response[0].User;
                        document.getElementById("lbl0104Branch").innerText = response[0].Branch;
                        document.getElementById("lbl0104ORNo").innerText = response[0].ORNo;
                        document.getElementById("lbl0104Location").innerText = response[0].Location;
                        document.getElementById("lbl0104SmallORNo").innerText = response[0].SORNo;
                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDAAD.ashx",
                    data: {
                        'pFormCode': 'FIN090100',
                        'pType': 'Cashiering Tools - Get OR Settings',
                    },
                    success: function (response) {
                        fn04DisableButtons(true);
                        document.getElementById("btn0104Delete").classList.add("btn-delete");
                        document.getElementById("btn0104Delete").disabled = false;
                        document.getElementById("btn0104Edit").classList.add("btn-edit");
                        document.getElementById("btn0104Edit").disabled = false;
                        document.getElementById("i0104Edit").classList.remove("la-pencil-alt");
                        document.getElementById("i0104Edit").classList.add("la-save");

                        document.getElementById("div0104Detail").style.display = "none";
                        document.getElementById("div0104Update").style.display = "";
                        document.getElementById("tbx0104User").value = response[0].User;
                        document.getElementById("tbx0104Branch").value = response[0].Branch;
                        document.getElementById("tbx0104ORNo").value = response[0].ORNo;
                        document.getElementById("tbx0104Location").value = response[0].Location;
                        document.getElementById("tbx0104SmallORNo").value = response[0].SORNo;
                    },
                });
            }

            // modal
            $("#mdl0101Tools").modal("hide");
            $("#mdl0104OR").modal("show");
        };
        function fn04DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0104Refresh").classList.remove("btn-view");
                document.getElementById("btn0104Delete").classList.remove("btn-delete");
                document.getElementById("btn0104Delete").classList.remove("d-none");
                document.getElementById("btn0104Edit").classList.remove("btn-edit");
            } else {
                document.getElementById("btn0104Refresh").classList.add("btn-view");
                document.getElementById("btn0104Delete").classList.add("btn-delete");
                document.getElementById("btn0104Delete").classList.add("d-none");
                document.getElementById("btn0104Edit").classList.add("btn-edit");
            }
            document.getElementById("btn0104Refresh").disabled = pValue;
            document.getElementById("btn0104Delete").disabled = pValue;
            document.getElementById("btn0104Edit").disabled = pValue;
        };
        // OR

        // OR Reversal
        function fn0101_FIN09RPT04() {
            //access
            fnAccess('FIN090000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //add
            function Add() {
                var table = $('#table0105Record').DataTable();
                if (table) {
                    table.clear().draw();
                };

                $('#mdl0101Tools').modal('hide');
                $('#mdl0105Reversal').modal('show');
            };
        };
        var input_DocNo = document.getElementById("tbx0105Find");
        input_DocNo.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                FindORReversal(input_DocNo.value);
            }
        });
        function FindORReversal(Find) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'pFormCode': 'FIN090100',
                    'pType': 'Cashiering Tools - OR Reversal',
                    'pDocNo': Find
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
                    document.getElementById("div0105Loader").style.display = "";
                    //hide loader

                    // Destroy old table safely if exists
                    if ($.fn.DataTable.isDataTable('#table0105Record')) {
                        $('#table0105Record').DataTable().clear().destroy();
                    };

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0105Record = $("#table0105Record").DataTable({
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
                            { data: 'DocNo', },
                            { data: 'DocDate' },
                            { data: 'Payee' },
                            { data: 'DocAmount' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false,
                            }
                            ,
                            {
                                targets: [2],
                                className: 'tbody-nowrap-auto'
                            },
                            {
                                targets: [4],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
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
                    $('#tbx0105Find').on('keyup', function () {
                        table0105Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0105Loader").style.display = "none";
                    //hide loader

                    // close Swal loader when everything is done
                    Swal.close();
                }
            });
        };
        function fn0105Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
            //access
            fnAccess('FIN090000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Simulate form submission
                    fn0105Add_Ok_Await(Btn);
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function fn0105Add_Ok_Await(Btn) {
                var table0105Record = $('#table0105Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table0105Record.$('.row-checkbox', { page: 'all' });

                // Check if atleast one
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        AcctNo: checkBox.getAttribute('data-kt-no'),
                        DocNo: checkBox.getAttribute('data-kt-doc'),
                        DocDate: checkBox.getAttribute('data-kt-date')
                    }));
                if (checkedValues.length > 0) {
                    // Array
                    let ItemList = [];

                    // Loop
                    checkedValues.forEach(item => {
                        Swal.close(); // close loader before confirmation
                        Swal.fire({
                            title: '<span class="fs-6 fw-normal text-gray-700">Reverse current record?</span>',
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
                                checkedValues.forEach(item => {
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDAAD.ashx",
                                        data: {
                                            'pFormCode': 'FIN090100',
                                            'pType': 'Cashiering Tools - Reverse OR Record',
                                            'pDocNo': item.DocNo,
                                            'pDocDate': item.DocDate,
                                            'pAcctNo': item.AcctNo,
                                            'pReason': document.getElementById("tbx0105Reason").value
                                        },
                                        success: function (response) {
                                            //nothing
                                        }
                                    });
                                });
                                //alert
                                fnAlertOnly('Record successfully reversed.', 'success', 'btn btn-success');
                                //load
                                // Destroy the DataTable before reloading
                                var table = $('#table0105Record').DataTable();
                                table.clear().destroy();
                                $('#table0105Record tbody').empty();
                                document.getElementById("tbx0105Find").value = "";
                                document.getElementById("tbx0105Reason").value = "";
                                $("#mdl0105Reversal").modal("hide");
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            }
                        });
                    });

                } else {
                    Swal.close();
                    fnAlertOnly('No selected record(s)!', 'error', 'btn btn-danger');
                    //Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            };
        };
        // OR Reversal

        // Official Receipt
        function fn0101_FIN09RPT05() {
            if (document.getElementById("cbx0101Post").checked == true) {
                if (document.getElementById("hdnBranchName").value == "Main Office" || document.getElementById("hdnBranchName").value == "Makati Office") {

                    if (document.getElementById('lbl0101Type').innerText == "Regular OR") {

                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate RORMN',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate SORMN',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    }

                } else if (document.getElementById("hdnBranchName").value == "SM Lucena Office") {

                    if (document.getElementById('lbl0101Type').innerText == "Regular OR") {

                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate RORSM',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate SORSM',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    }

                } else if (document.getElementById("hdnBranchName").value == "Bay Office") {

                    if (document.getElementById('lbl0101Type').innerText == "Regular OR") {

                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate RORLO',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate SORLO',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    }

                } else if (document.getElementById("hdnBranchName").value == "Lipa Office") {

                    if (document.getElementById('lbl0101Type').innerText == "Regular OR") {

                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate RORBT',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate SORBT',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    }

                } else if (document.getElementById("hdnBranchName").value == "Sonrisa Office") {

                    if (document.getElementById('lbl0101Type').innerText == "Regular OR") {

                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate RORSO',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate SORSO',
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pDate': document.getElementById('lbl0101ORDate').innerText,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                            }
                        });
                    }
                }
            } else {
                fnAlertOnly('Record must be posted first.', 'warning', 'btn btn-warning');
            }
        }
        // Official Receipt

        // Cash Invoice
        function fn0101_FIN09RPT06() {
            if (document.getElementById("cbx0101Post").checked == true) {
                if (document.getElementById('lbl0101Type').innerText == "Regular OR") {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090000',
                            'pType': 'Generate CI',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pDate': document.getElementById('lbl0101ORDate').innerText,
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            }
                        }
                    });
                } else if (document.getElementById('lbl0101Type').innerText == "Small OR") {
                    $.ajax({
                        type: "POST",
                        url: "HNDAAD.ashx",
                        data: {
                            'pFormCode': 'FIN090000',
                            'pType': 'Generate SOR',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pDate': document.getElementById('lbl0101ORDate').innerText,
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            }
                        }
                    });
                }
            } else {
                fnAlertOnly('Record must be posted first.', 'warning', 'btn btn-warning');
            }
        }
        // Cash Invoice

        // Proof List
        function fn0101_FIN09RPT07() {
            $('#ddl0106Format').val('').trigger('change');
            $('#ddl0106Branch').val('').trigger('change');
            document.getElementById("tbx0106Date").value = "";

            $('#mdl0106Filter').modal('show');
        }
        function fn0106Filter_Ok(Btn) {
            if (document.getElementById("ddl0106Format").value == "" || document.getElementById("ddl0106Branch").value == "" || document.getElementById("tbx0106Date").value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else {
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
            };
            async function Filter_Ok_Await(Btn) {
                // process
                return new Promise(resolve => {
                    if (document.getElementById("ddl0106Format").value == "Group") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate PL',
                                'pBranch': document.getElementById('ddl0106Branch').value,
                                'pDate': document.getElementById('tbx0106Date').value,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                                $('#mdl0106Filter').modal('hide');
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                                //resolve
                                resolve();
                            }
                        });
                    } else if (document.getElementById("ddl0106Format").value == "Series") {
                        $.ajax({
                            type: "POST",
                            url: "HNDAAD.ashx",
                            data: {
                                'pFormCode': 'FIN090000',
                                'pType': 'Generate PLA',
                                'pBranch': document.getElementById('ddl0106Branch').value,
                                'pDate': document.getElementById('tbx0106Date').value,
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                }
                                $('#mdl0106Filter').modal('hide');
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = false;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                                //resolve
                                resolve();
                            }
                        });
                    }
                });
            };
        };
        // Proof List

        //tools

		//attachment
        function fn0201LoadAttachment(pMode,pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'FIN090000',
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
                    if (pMode = "DTL") {
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
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('FIN090000', 'Delete', function (response) {
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
                        fnAlertOnly('File successfully removed.', 'success', 'btn btn-success');
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
                    'pFormCode': 'FIN090000',
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
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
            fnIfExist('calmardblive.dbo.ICR_PaymentHeader', 'DocNo', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                            'pFormCode': 'FIN090000',
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

        //format numeric
        function isNumberKey(e, input) {
            const key = e.key;
            const val = input.value;

            // Allow control keys (backspace, delete, arrows)
            if (e.ctrlKey || e.metaKey || e.altKey || e.keyCode < 32) return true;

            // Allow digits
            if (/[0-9]/.test(key)) return true;

            // Allow one "-" at the start
            if (key === '-' && val.indexOf('-') === -1 && input.selectionStart === 0) {
                return true;
            }

            // Allow one decimal point (but not at start)
            if (key === '.' && val.indexOf('.') === -1) {
                return true;
            }

            // Block everything else
            return false;
        }
        function FormatNumeric(ID) {
            var NumVal = document.getElementById(ID);
            var RawValue = NumVal.value.replace(/,/g, "");
            var Val = parseFloat(RawValue);
            if (isNaN(Val)) {
                NumVal.value = "0.00";
                return;
            }
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
            NumVal.value = Num;
        }
        //format numeric

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
                    url: "HNDGEN.ashx?pFormCode=FIN090000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    fnAccess('FIN090000', 'Add', function (response) {
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
                    fnAccess('FIN090000', 'Add', function (response) {
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
                            fnAlertOnly('Please attach at least one file to proceed.', 'error', 'btn btn-danger');
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=FIN090000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
