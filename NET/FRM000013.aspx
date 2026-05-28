<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000013.aspx.vb" Inherits="NET.FRM000013" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="content flex-row-fluid" id="kt_content">
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white"><a href="FRM010000" class="text-white">Form</a></li>
						<li class="breadcrumb-item text-white">-</li>
						<li class="breadcrumb-item text-white">Occupancy Clearance</li>
					</ul>
				</div>
			</div>
		</div>
		<div class="card">
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
                    <div class="symbol me-5">
                        <img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
                    </div>
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn0101Title">-</span></h2>
						<div class="text-muted fw-bolder">
							<span id="spn0101ID">-</span>
							<span class="mx-3">|</span>
							<span id="spn0101Status">-</span>
						</div>
					</div>
				</div>
			</div>
			<div class="card-body pt-3 pb-0">
				<div class="d-flex flex-stack">
					<div class="d-flex overflow-auto">
						<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary active" title="Overview" data-bs-toggle="tab" href="#tab020101"><i class="las la-file-alt fs-3x"></i></a>
							</li>
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary" title="Subscribers" data-bs-toggle="tab" href="#tab030101"><i class="las la-user-friends fs-3x"></i></a>
							</li>
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary" title="History" data-bs-toggle="tab" href="#tab040101"><i class="las la-history fs-3x"></i></a>
							</li>
						</ul>
					</div>
				</div>
			</div>
			<div class="card" >
				<div class="tab-content" >
					<div class="tab-pane fade show active" id="tab020101">
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">Overview</div>
                            </div>
                            <div class="border-bottom border-gray-200 px-4 py-3">
                                <div class="d-flex flex-stack">
                                    <div class="d-flex ms-5">
                                        <button id="btn0101Find" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Find Record" onclick="fn0101FindRecord();return false;"><i class="las la-search fs-2"></i></button>
                                        <button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
                                        <span class="bullet h-30px w-2px bg-secondary mt-2 m-1"></span>
                                        <button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0101Add();return false;"><i class="las la-plus fs-2"></i></button>
                                        <button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
                                        <button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
                                        <span class="bullet h-30px w-2px bg-secondary mt-2 m-1"></span>
                                        <button id="btn0101Print" class="btn btn-sm btn-icon btn-tools align-self-center m-1" title="Print" onclick="fn0101_RPT000009();return false;"><i class="las la-print fs-2"></i></button>
                                        <button id="btn0101Status" class="btn btn-sm btn-secondary align-self-center m-1" title="Change Status" onclick="fn0101ChangeStatus();return false;">Change Status</button>
                                    </div>
                                </div>
                            </div>
                            <!--begin:: Details -->
                            <div id="div0101Detail" class="card-body">
                                <div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">ID</span>
										<span id="lbl01ID" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Type</span>
										<span id="lbl01FormType" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<span id="lbl01DateRequested" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Required</span>
										<span id="lbl01DateRequired" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Requested By</span>
										<span id="lbl01RequestedBy" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Assigned To</span>
										<span id="lbl01AssignedTo" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Endorsed To</span>
										<span id="lbl01EndorsedTo" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Status</span>
										<span id="lbl01Status" class="form-control"></span>
									</div>

									<div class="separator separator-dashed my-6"></div>

									<div class="card-title fs-5 fw-bolder">Account Information</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Account</span>
										<span id="lbl01AcctNo" class="form-control mw-150px min-w-150px"></span>
										<span id="lbl01AcctName" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Property</span>
										<span id="lbl01PropertyDescription" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">House</span>
										<span id="lbl01House" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">TCP</span>
										<span id="lbl01TCP" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Financing</span>
										<span id="lbl01FinancingScheme" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Bank</span>
										<span id="lbl01Bank" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Equity</span>
										<span id="lbl01Equity" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Contact No.</span>
										<span id="lbl01ContactNo" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                        <textarea id="lbl01Remarks" class="form-control" placeholder="Add remarks" maxlength="1000" rows="3" cols="" readonly="readonly"></textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Engineering</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Occupancy Permit</span>
										<span id="lbl01ENG_Permit" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Accepted</span>
										<span id="lbl01ENG_Accepted" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Contr. Warranty</span>
										<span id="lbl01ENG_Warranty" class="form-control"></span>
									</div>
									<div class="card-title fs-5 fw-bolder">Finance</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Fully Paid</span>
										<span id="lbl01FIN_Paid" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Others</span>
										<span id="lbl01FIN_Others" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<textarea id="lbl01FIN_Remarks" class="form-control" placeholder="Remarks" maxlength="1000" rows="3" readonly="readonly" cols=""></textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Business Development</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Deed of Restrictions</span>
										<span id="lbl01PDD_DOR" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Deed of Sales</span>
										<span id="lbl01PDD_DOAS" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<textarea id="lbl01PDD_Remarks" class="form-control" placeholder="Remarks" maxlength="1000" rows="3" readonly="readonly" cols=""></textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Account Administration</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Contract to Sell</span>
										<span id="lbl01AAD_CTS" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">House and Lot</span>
										<span id="lbl01AAD_HLOR" class="form-control"></span>
										<span id="lbl01AAD_HLAmt" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Electrical Conn. Fee</span>
										<span id="lbl01AAD_ELCOR" class="form-control"></span>
										<span id="lbl01AAD_ELCAmt" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Water Conn. Fee</span>
										<span id="lbl01AAD_WTROR" class="form-control"></span>
										<span id="lbl01AAD_WTRAmt" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Fire Insurance Fee</span>
										<span id="lbl01AAD_FREOR" class="form-control"></span>
										<span id="lbl01AAD_FREAmt" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">CES No.</span>
										<span id="lbl01AAD_CES" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Satisfactory</span>
										<span id="lbl01AAD_Satisfactory" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Explain</span>
										<span id="lbl01AAD_Explain" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Recommendation</span>
										<span id="lbl01AAD_Recomm" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<textarea id="lbl01AAD_Remarks" class="form-control" placeholder="Remarks" maxlength="1000" rows="3" readonly="readonly" cols=""></textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Property Management Group</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Electrical Connection</span>
										<span id="lbl01PMD_ELC" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Water Connection</span>
										<span id="lbl01PMD_WTR" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Unit is Deliverable</span>
										<span id="lbl01PMD_Unit" class="form-control"></span>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<textarea id="lbl01PMD_Remarks" class="form-control" placeholder="Remarks" maxlength="1000" rows="3" readonly="readonly" cols=""></textarea>
									</div>
                            </div>
                             <!--End:: Details -->
                            
                             <!--begin:: Update/Edit/Add -->
                            <div id="div0101Update" class="card-body" style="display: none">
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">ID</span>
                                    <input id="tbx01ID" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Type</span>
                                    <input id="tbx01FormType" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Requested</span>
                                    <input id="tbx01DateRequested" type="text" class="form-control" readonly="readonly" />

                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px required">Date Required</span>
                                    <input id="tbx01DateRequired" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Pick a date" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Requested By</span>
                                    <input id="tbx01RequestedBy" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Assigned To</span>
                                    <input id="tbx01AssignedTo" type="text" class="form-control" readonly="readonly" />

                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Endorsed To</span>
                                    <input id="tbx01EndorsedTo" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Status</span>
                                    <input id="tbx01Status" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <!--end::separator-->
                                <div class="separator separator-dashed my-6"></div>
                                <!--begin::separator-->

								<div class="card-title fs-5 fw-bolder">Account Information</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px required">Account</span>
                                    <input id="tbx01AcctNo" type="text" class="form-control mw-150px min-w-150px" readonly="readonly" placeholder="Account No." />
                                    <div class="d-flex align-items-center position-relative w-100" style="margin-left: 1px">
                                        <input id="tbx01AcctName" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Account Name" />
                                        <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
                                        <span class="svg-icon svg-icon-2 position-absolute pointer end-5px" data-bs-toggle="modal" data-bs-target="#mdl01FindBuyer">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                            </svg>
                                        </span>
                                        <!--end::Svg Icon-->
                                    </div>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Project</span>
                                    <input id="tbx01Project" type="text" class="form-control" readonly="readonly" placeholder="Add project" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Model House</span>
                                    <input id="tbx01House" type="text" class="form-control" readonly="readonly" placeholder="Add model house" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">TCP</span>
                                    <input id="tbx01TCP" class='form-control' readonly="readonly" type="text" value="0.00" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Financing</span>
                                    <input id="tbx01Financing" type="text" class="form-control" readonly="readonly" placeholder="Add financing" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Bank</span>
                                    <input id="tbx01Bank" type="text" class="form-control" readonly="readonly" placeholder="Add bank" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Equity</span>
                                    <input id="tbx01Equity" class='form-control' type="text" readonly="readonly" value="0.00" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Contact No.</span>
                                    <input id="tbx01ContactNo" type="text" class="form-control" readonly="readonly" placeholder="Add contact no." />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                    <textarea id="tbx01Remarks" class="form-control" placeholder="Remarks" maxlength="500" rows="3" cols=""></textarea>
                                </div>
                                <div class="card-title fs-5 fw-bolder">Engineering</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Occupancy Permit</span>
                                    <select id="ddl01ENG_Permit" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Accepted</span>
                                    <input id="tbx01ENG_Accepted" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Pick a date" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Contr. Warranty</span>
                                    <input id="tbx01ENG_Warranty" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Pick a date" />
                                </div>
                                <div class="card-title fs-5 fw-bolder">Finance</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Fully Paid</span>
                                    <select id="ddl01FIN_Paid" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Others</span>
                                    <input id="tbx01FIN_Others" type="text" class="form-control" placeholder="Others" maxlength="500" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                    <textarea id="tbx01FIN_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
                                </div>
                                <div class="card-title fs-5 fw-bolder">Business Development</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Deed of Restrictions</span>
                                    <select id="ddl01PDD_DOR" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Deed of Sales</span>
                                    <select id="ddl01PDD_DOAS" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                    <textarea id="tbx01PDD_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
                                </div>
                                <div class="card-title fs-5 fw-bolder">Account Administration</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Contract to Sell</span>
                                    <select id="ddl01AAD_CTS" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">House and Lot</span>
                                    <input id="tbx01AAD_HLOR" class='form-control' type="text" placeholder="Add reference" maxlength="13" />
                                    <input id="tbx01AAD_HLAmt" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" placeholder="0.00" maxlength="18" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Electrical Conn. Fee</span>
                                    <input id="tbx01AAD_ELCOR" class='form-control' type="text" placeholder="Add reference" maxlength="13" />
                                    <input id="tbx01AAD_ELCAmt" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" placeholder="0.00" maxlength="18" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Water Conn. Fee</span>
                                    <input id="tbx01AAD_WTROR" class='form-control' type="text" placeholder="Add reference" maxlength="20" />
                                    <input id="tbx01AAD_WTRAmt" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" placeholder="0.00" maxlength="18" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Fire Insurance Fee</span>
                                    <input id="tbx01AAD_FREOR" class='form-control' type="text" placeholder="Add reference" maxlength="20" />
                                    <input id="tbx01AAD_FREAmt" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" placeholder="0.00" maxlength="18" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">CES No.</span>
                                    <input id="tbx01AAD_CES" class='form-control' type="text" placeholder="Add reference" maxlength="20" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Satisfactory</span>
                                    <select id="ddl01AAD_Satisfactory" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Explain</span>
                                    <input id="tbx01AAD_Explain" class='form-control' type="text" placeholder="Add explain" maxlength="500" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Recommendation</span>
                                    <input id="tbx01AAD_Recomm" class='form-control' type="text" placeholder="Add recommendation" maxlength="20" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                    <textarea id="tbx01AAD_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
                                </div>
                                <div class="card-title fs-5 fw-bolder">Property Management Group</div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Electrical Connection</span>
                                    <select id="ddl01PMD_ELC" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Water Connection</span>
                                    <select id="ddl01PMD_WTR" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Unit is Deliverable</span>
                                    <select id="ddl01PMD_Unit" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select option</option>
                                        <option value="1">Yes</option>
                                        <option value="0">No</option>
                                    </select>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                    <textarea id="tbx01PMD_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
                                </div>
                            </div>
                            <!--End:: Update/Edit/Add -->
                        </div>

                         <!--begin:: Attatchment -->
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Attachment</div>
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
										<input id="tbx98Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<table id="table98Record" class="table table-row-bordered border table-hover rounded g-2 w-100 align-middle">
										<thead class="fw-bold">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
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
                        <!--End:: Attatchment -->

                        <!--begin:: Approval Path -->
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Approval Path</div>
							</div>
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex ms-5">
										<button id="btn989Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add Approval Path" onclick="fn989Add(event)"><i class="las la-user-plus fs-2"></i></button>
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<table id="table989Record" class="table  table-row-bordered border table-hover rounded g-2 w-100 align-middle">
										<thead class="fw-bold">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="mw-5px min-w-5px" style="color: transparent; font-size: 0; padding: 0;">Bullet</th>
												<th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-150px mw-150px border-end">Type</th>
												<th class="min-w-300px w-100 border-end">User</th>
												<th class="min-w-150px mw-150px border-end">Status</th>
												<th class="min-w-150px mw-150px border-end">Turn Around Time</th>
												<th class="min-w-300px mw-300px">Reason for delay</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
								</div>
							</div>
						</div>
                        <!--End:: Approval Path -->

                        <!--begin:: Notes -->
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Notes</div>
							</div>
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex ms-5">
										<button id="btn99Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn99Add();return false;"><i class="las la-comment fs-2"></i></button>
									</div>
									<div class="position-relative me-5">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<input id="tbx99Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<table id="table99Record" class="table gy-2 gs-2 w-100 align-middle">
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
						</div>
                        <!--End:: Notes -->
					</div>
                    <div class="tab-pane fade" id="tab030101">
                        <!--begin:: Subscriber -->
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">Subscribers</div>
                            </div>
                            <div class="border-bottom border-gray-200 px-4 py-3">
                                <div class="d-flex flex-stack">
                                    <div class="d-flex ms-5">
                                        <button id="btn03010101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="fn03010101AddUser();return false;"><i class="las la-user-plus fs-2"></i></button>
                                    </div>
                                    <div class="position-relative me-5">
                                        <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                            </svg>
                                        </span>
                                        <input id="tbx03010101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table id="table03010101Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                        <thead class="fw-bold">
                                            <tr class="fw-bold fs-7 text-gray-800">
												<th class="mw-5px min-w-5px" style="color: transparent; font-size: 0; padding: 0;">Bullet</th>
                                                <th class="min-w-75px mw-75px">Action</th>
                                                <th class="min-w-200px w-100">User</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!--End:: Subscriber -->
                    </div>
                    <div class="tab-pane fade" id="tab040101">
                       <!--begin:: History -->
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">History</div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table id="table04010101Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                        <thead class="fw-bold">
                                            <tr class="d-none">
                                                <th class="min-w-200px w-100">Data</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!--End:: History -->
                    </div>
				</div>
			</div>
		</div>
				
        <!--begin:: Modal Edit -->
		<div id="mdl02Edit" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Details</h5>
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
						<div class="card-title fs-5 fw-bolder">Engineering</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Occupancy Permit</span>
                            <select id="ddl02ENG_Permit" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Date Accepted</span>
							<input id="tbx02ENG_Accepted" type="text" data-kt-repeater="datepicker" class="form-control" readonly placeholder="Pick a date" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Contr. Warranty</span>
							<input id="tbx02ENG_Warranty" type="text" data-kt-repeater="datepicker" class="form-control" readonly placeholder="Pick a date" />
						</div>
						<div class="card-title fs-5 fw-bolder">Finance</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Fully Paid</span>
							<select id="ddl02FIN_Paid" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Others</span>
							<input id="tbx02FIN_Others" class='form-control' type="text" placeholder="Others" maxlength="500" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<textarea id="tbx02FIN_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
						</div>
						<div class="card-title fs-5 fw-bolder">Business Development</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Deed of Restrictions</span>
							<select id="ddl02PDD_DOR" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Deed of Sales</span>
							<select id="ddl02PDD_DOAS" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<textarea id="tbx02PDD_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
						</div>
						<div class="card-title fs-5 fw-bolder">Account Administration</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Contract to Sell</span>
							<select id="ddl02AAD_CTS" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">House and Lot</span>
							<input id="tbx02AAD_HLOR" class='form-control' type="text" placeholder="Add Reference" maxlength="13" />
							<input id="tbx02AAD_HLAmt" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" maxlength="18" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Electrical Conn. Fee</span>
							<input id="tbx02AAD_ELCOR" class='form-control' type="text" placeholder="Add Reference" maxlength="13" />
							<input id="tbx02AAD_ELCAmt" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00"  maxlength="18"  />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Water Conn. Fee</span>
							<input id="tbx02AAD_WTROR" class='form-control' type="text" placeholder="Add Reference"  maxlength="20" />
							<input id="tbx02AAD_WTRAmt" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" maxlength="18"  />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Fire Insurance Fee</span>
							<input id="tbx02AAD_FREOR" class='form-control' type="text" placeholder="Add Reference"  maxlength="20" />
							<input id="tbx02AAD_FREAmt" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00"  maxlength="18" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">CES No.</span>
							<input id="tbx02AAD_CES" class='form-control' type="text" placeholder="Add Reference"  maxlength="20"  />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Satisfactory</span>
							<select id="ddl02AAD_Satisfactory" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Explain</span>
							<input id="tbx02AAD_Explain" class='form-control' type="text" placeholder="Add explain" maxlength="500" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Recommendation</span>
							<input id="tbx02AAD_Recomm" class='form-control' type="text" placeholder="Add recommendation" maxlength="20" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<textarea id="tbx02AAD_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
						</div>
						<div class="card-title fs-5 fw-bolder">Property Management Group</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Electrical Connection</span>
							<select id="ddl02PMD_ELC" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Water Connection</span>
							<select id="ddl02PMD_WTR" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Unit is Deliverable</span>
							<select id="ddl02PMD_Unit" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                <option value="">Select option</option>
                                <option value="1">Yes</option>
                                <option value="0">No</option>
                            </select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<textarea id="tbx02PMD_Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
						</div>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn02SaveEdit();return false;">
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
		<!--End:: Modal Edit -->

		<!--begin:: Modal Attachment -->
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
						<div class="dropzone mb-5" id="div98DropZone">
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
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--End:: Modal Attachment -->

		<!--begin:: Modal Comment -->
		<div id="mdl9901Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Notes - Add Note</h5>
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
						<textarea id="tbx9901Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Notes"  rows="3" cols=""></textarea>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn9901Add(this);return false;">
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
				</div>
			</div>
		</div>
		<!--End:: Modal Comment -->

		<!--begin::Modal Find Buyer -->
		<div id="mdl01FindBuyer" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Find record
						</h5>
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
					<div class="modal-body min-h-80px mh-80px overflow-hidden">
						<!--begin::toolbar-->
						<div class="d-flex align-items-center">
							<!--begin::Search-->
							<div class="position-relative">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
                                <input id="tbx01FindBuyer" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						    <!--begin::list-->
                            <table id="gv01FindBuyer" class="table table-no-border table-row-bordered table-hover align-middle w-100">
                                <thead>
                                    <tr class="d-none">
                                        <th class="mw-5px min-w-5px">Bullet</th>
                                        <th class="w-100">Data</th>
                                    </tr>           
                                </thead>           
                                <tbody>

                                </tbody>
                            </table>
						</div>
						<!--end::list-->
					</div>
				</div>
			</div>
		</div>
		<!--End::Modal Find Buyer -->

		<!--begin:: Modal Status -->
        <div id="mdl01Status" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Overview - Change Status</h5>
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
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text min-w-150px required">Change status to</span>
                            <select id="ddl01Status" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl01Status_onchange(this.value);">
                            </select>
                        </div>
                        <div id="pnl01ClarifyTo" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Clarify to</span>
                            <select id="ddl01ClarifyTo" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                        <div class="input-group input-group-sm mb-2">
                            <span id="spn01Note" class="input-group-text input-group-text-top min-w-150px">Notes</span>
                            <textarea id="tbx01Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Add extra details" rows="3" cols=""></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn88SaveStatus();return false;">
                            <span class="indicator-label">Save changes
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
		<!--End:: Modal Status -->

		<!--begin:: Modal Subscriber -->
        <div id="mdl01User" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Subscribers - Add User</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">User</span>
							<select id="ddl03User" data-kt-repeater="select2" data-dropdown-parent="#mdl01User" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl04AddFrom_onchange(this.value)">
                            </select>
						</div>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn03010101SaveUser(this);return false;">
                            <span class="indicator-label">Add User
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
		<!--End:: Modal Subscriber -->

		<!--begin:: Modal Approver -->
        <div id="mdl01Approver" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Add User</h5>
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
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text min-w-150px required">Add from</span>
                            <select id="ddl04AddFrom" data-kt-repeater="select2" data-dropdown-parent="#mdl01Approver" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl04AddFrom_onchange(this.value)">
                                <option value="">Select a type</option>
                                <option value="Manual">Manual</option>
                                <option value="Template">Template</option>
                            </select>
                        </div>
                        <div id="pnl04Type" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Type</span>
                            <select id="ddl04Type" data-kt-repeater="select2" data-dropdown-parent="#mdl01Approver" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl04Type_onchange(this.value)">
                                <option value="">Select a type</option>
                                <option value="Endorsed By">Endorsed By</option>
                                <option value="Approved By">Approved By</option>
                                <option value="Implementer">Implementer</option>
                            </select>
                        </div>
                        <div id="pnl04AssignTo" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Approver</span>
                            <select id="ddl04Approver" data-kt-repeater="select2" data-dropdown-parent="#mdl01Approver" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                        <div id="pnl04NoDays" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">No. of days</span>
                            <input id="tbx04NoDays" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" />
                        </div>
                        <div id="pnl04Template" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Type</span>
                            <select id="ddl04Template" data-kt-repeater="select2" data-dropdown-parent="#mdl01Approver" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn989SaveApproval();return false;">
                            <span class="indicator-label">Add
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
		<!--End:: Modal Approver -->

		<!--begin:: Modal Reason for Delay -->
        <div id="mdl01ReasonForDelay" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Reason for delay</h5>
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
                        <!--begin::note-->
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text input-group-text-top min-w-150px">Reason for delay</span>
							<textarea id="tbx04ReasonForDelay" class="form-control" placeholder="Add remarks" maxlength="1000" rows="3" cols=""></textarea>
                        </div>
                        <!--end::note-->
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn989Save();return false;">
                            <span class="indicator-label">Save
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
		<!--End:: Modal Reason for Delay -->

		<!--begin:: Modal Find Record -->
        <div id="mdl01Find" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-fullscreen" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Find record</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body min-h-80px mh-80px overflow-hidden">
						<!--begin::toolbar-->
						<div class="d-flex align-items-center">
							<!--begin::Search-->
							<div class="position-relative">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
                    <div class="modal-body">
                        <div style="overflow-x:auto; scrollbar-width: thin;">
                            <table id="table98Find" class="table table-no-border table-row-bordered table-hover align-middle w-100">
                                <thead>
                                    <tr class="d-none">
                                        <th class="mw-5px min-w-5px">Bullet</th>
                                        <th class="w-100">Data</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
		<!--End:: Modal Find Record -->

	</div>

	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnSeqNo" type="hidden" value="" />
	<input id="hdnAprType" type="hidden" value="" />
	<input id="hdnSMSType" type="hidden" value="" />
	<input id="hdn03IDPrev" type="hidden" value="" />
    <input id="hdn03ID" type="hidden" value="" />
	<input id="hdn03Mode" type="hidden" value="" />
	<input id="hdn99Mention" type="hidden" value="DTL" />
	<input id="hdn02MdlName" type="hidden" value="DTL" />
	<input id="hdn02Project" type="hidden" value="DTL" />


    <script type="text/javascript" src="Assets/js/FRM/FRM000013.js"></script>
	<script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
