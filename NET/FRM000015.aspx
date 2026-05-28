<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000015.aspx.vb" Inherits="NET.FRM000015" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item"><a href="FRM010000" class="text-white">Form</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Cash Advance</li>
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
						<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
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
							<!--begin::Nav item-->
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary" title="Subscribers" data-bs-toggle="tab" href="#tab0101Subscriber"><i class="las la-user-friends fs-3x"></i></a>
							</li>
							<!--end::Nav item-->
							<!--begin::Nav item-->
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary" title="History" data-bs-toggle="tab" href="#tab0101History"><i class="las la-history fs-3x"></i></a>
							</li>
							<!--end::Nav item-->
						</ul>
					</div>
					<!--begin::Navs-->
				</div>
			</div>
			<!--begin::Content-->
			<div class="card">
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
									<button id="btn0101Find" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Find" onclick="fn0101Find();return false;"><i class="las la-search fs-2"></i></button>
									<button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
									<button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0101Add();return false;"><i class="las la-plus fs-2"></i></button>
									<button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
									<button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
									<button id="btn0101Print" class="btn btn-sm btn-icon btn-tools align-self-center m-1" title="Print" onclick="fn0101Print();return false;"><i class="las la-print fs-2"></i></button>
									<button id="btn0101ChangeStatus" class="btn btn-sm btn-secondary align-self-center m-1" title="Change Status" onclick="fn0101ChangeStatus();return false;">Change Status</button>
								
								</div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div id="div0101Detail" class="card-body">

								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-12">
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">ID</span>
				                            <span id="lbl0101ID" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Type</span>
				                            <span id="lbl0101FormType" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Date Requested</span>
				                            <span id="lbl0101DateRequested" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Date Required</span>
				                            <span id="lbl0101DateRequired" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Requested By</span>
				                            <span id="lbl0101Requestedby" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Assigned To</span>
				                            <span id="lbl0101AssignedTo" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Endorsed To</span>
				                            <span id="lbl0101EndorsedTo" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Status</span>
				                            <span id="lbl0101Status" class="form-control">-</span>
                                        </div>
										<div class="separator separator-dashed my-6"></div>
                                        
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Type</span>
				                            <span id="lbl0101Type" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Fund</span>
				                            <span id="lbl0101Fund" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Branch</span>
				                            <span id="lbl0101Branch" class="form-control">-</span>
                                        </div>
                                        <div class="input-group input-group-sm mb-2">
				                            <span class="input-group-text input-group-text-top min-w-150px">Reference No.</span>
				                            <span id="lbl0101RefNo" class="form-control">-</span>
                                        </div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
                                             <textarea id="lbl0101Remarks" class="form-control min-h-75px" readonly="readonly">-</textarea>
										</div>
                                        <div id="div0101DetailPayment" style="display:none">
                                            <div class="card-title fs-5 fw-bolder">Payment Details</div>
                                            <div class="input-group input-group-sm mb-2">
                                                <span class="input-group-text input-group-text-top min-w-150px">Due Date</span>
                                                <span id="lbl0101DueDate" class="form-control">-</span>
                                            </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px">For Pick-Up</span>
											    <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
												    <input id="cbx0101IsPickUp" class="form-check-input" type="checkbox" value="" onclick="return false"/>
											    </div>
										    </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px">For Deposit</span>
											    <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
												    <input id="cbx0101IsDeposit" class="form-check-input" type="checkbox" value="" onclick="return false"/>
											    </div>
										    </div>
                                            <div class="input-group input-group-sm mb-2">
                                                <span class="input-group-text input-group-text-top min-w-150px">Bank Name</span>
                                                <span id="lbl0101Bankname" class="form-control">-</span>
                                            </div>
                                            <div class="input-group input-group-sm mb-2">
                                                <span class="input-group-text input-group-text-top min-w-150px">Account Name</span>
                                                <span id="lbl0101AcctName" class="form-control">-</span>
                                            </div>
                                            <div class="input-group input-group-sm mb-2">
                                                <span class="input-group-text input-group-text-top min-w-150px">Account No.</span>
                                                <span id="lbl0101AcctNo" class="form-control">-</span>
                                            </div>
                                        </div>
									</div>
                                </div>
							</div>
							<div id="div0101Update" class="card-body" style="display:none">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-12">
                                        
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">ID</span>
                                            <input id="tbx0101ID" type="text" class="form-control" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Type</span>
                                            <input id="tbx0101FormType" type="text" class="form-control" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date Requested</span>
                                            <input id="tbx0101DateRequested" type="text" class="form-control" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Date Required</span>
                                            <input id="tbx0101DateRequired" type="text" data-kt-repeater="datepicker" class="form-control" Placeholder="Pick a date" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Requested By</span>
                                            <input id="tbx0101Requestedby" type="text" class="form-control" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Assigned To</span>
                                            <input id="tbx0101AssignedTo" type="text" class="form-control" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Endorsed To</span>
                                            <input id="tbx0101EndorsedTo" type="text" class="form-control" readonly="readonly"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Status</span>
                                            <input id="tbx0101Status" type="text" class="form-control" readonly="readonly"/>
										</div>
                                        <div class="separator separator-dashed my-6"></div>
                                        
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Type</span>
							                 <select id="ddl0101Type" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                                 <option value="">Select type</option>
                                                 <option value="Cash Advance">Cash Advance</option>
                                                 <option value="Cash Liquidation">Cash Liquidation</option>
                                             </select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Fund</span>
							                 <select id="ddl0101Fund" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                                 <option value="">Select fund</option>
                                                 <option value="General Fund">General Fund</option>
                                             </select>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Branch</span>
							                 <select id="ddl0101Branch" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                                 <option value="">Select branch</option>
                                             </select>
										</div>
                                        
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Reference No.</span>
                                            <input id="tbx0101RefNo" type="text" class="form-control" Placeholder="Add reference number" maxlength="13"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text input-group-text-top min-w-150px required">Remarks</span>
                                            <textarea id="tbx0101Remarks" class="form-control min-h-75px" Placeholder="Add remarks" maxlength="1000"></textarea>
										</div>
									      <div id="div0101EditPayment" style="display:none">
										    <div class="card-title fs-5 fw-bolder">Payment Details</div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px required">Due Date</span>
											    <input id="tbx0101DueDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" Placeholder="Pick a date" />
										    </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px required">For Pick-Up</span>
											    <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
												    <input id="cbx0101EditIsPickUp" class="form-check-input" type="checkbox" value=""/>
											    </div>
										    </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px required">For Deposit</span>
											    <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
												    <input id="cbx0101EditIsDeposit" class="form-check-input" type="checkbox" onchange="cbx0101EditIsDeposit_onchange(this)" value=""/>
											    </div>
										    </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px required">Bank Name</span>
											    <input id="tbx0101BankName" type="text" class="form-control" readonly="readonly" Placeholder="Add bank name" value="-" maxlength="180"/>
										    </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px required">Account Name</span>
											    <input id="tbx0101AcctName" type="text" class="form-control" readonly="readonly" Placeholder="Add account name" value="-" maxlength="180"/>
										    </div>
										    <div class="input-group input-group-sm mb-2">
											    <span class="input-group-text min-w-150px required">Account No.</span>
											    <input id="tbx0101AcctNo" type="text" class="form-control" readonly="readonly" Placeholder="Add account no." value="-" maxlength="180"/>
										    </div>
									    </div>
									</div>
								</div>
							</div>
                                
                                          
							<!--end::Dtl-->
						</div>
						<!--end::Menu Content-->

						<!--begin::movement-->
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
                                    <button id="btn0102Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0102Add();return false;"><i class="las la-plus fs-2"></i></button>
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
                                            <input id="tbx0102FindMovement" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                        <!--end::Search-->
                                    </div>
                                </div>
                            </div>
                            <!--end::Card header-->
							<!--begin::Files-->
							<div class="card-body">
								<div class="table-loading">
									<div id="div0102LoaderMovement" class="table-loading-message">
										Loading...
									</div>
									<table id="table0102Movement" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>
											 <tr class="fw-bold fs-7 text-gray-800">
												<th colspan="4"></th>
												<th>Budget</th>
												<th></th>
											</tr>
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                                <th class="min-w-300px mw-300px fw-bold border-end">Particular</th>
                                                <th class="min-w-75px mw-75px fw-bold border-end">Qty.</th>
                                                <th class="min-w-100px mw-100px fw-bold text-truncate border-end">Unit</th>
                                                <th class="min-w-250px w-100 fw-bold border-end">Description</th>
                                                <th class="min-w-200px mw-200px fw-bold border-end">Amount</th>
											</tr>
										</thead>
										<tbody>
										</tbody>
                                         <tfoot>
                                             <tr>
                                               	<th colspan="4"></th>
                                                 <th>Total</th>
                                                 <th class="text-end"></th>
                                             </tr>
                                             
                                         </tfoot>
									</table>
								</div>
							</div>
							<!--end::Files-->
						</div>
						<!--end::movement-->

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

						<!--begin::approver-->
						<div class="card card-xl-stretch">
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Approval Path</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
                                <div class="d-flex align-items-center">
				                    <button id="btn0401Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="fn0401AddApproval();return false;"><i class="las la-user-plus fs-2"></i></button>
                                </div>
							</div>
							<!--end::Card header-->
							<!--begin::Dtl-->
							<div class="card-body table-loading table-responsive">
								<div id="div0401LoaderApprover" class="table-loading-message">
									Loading...
								</div>
                                <table id="table0401Approver" class="table  table-row-bordered border table-hover rounded g-2 w-100 align-middle">
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
							<!--end::Dtl-->
						</div>
						<!--end::approver-->

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
                    <div class="tab-pane fade" id="tab0101Subscriber">
                        <!--begin:: Subscriber -->
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">Subscribers</div>
                            </div>
                            <div class="border-bottom border-gray-200 px-4 py-3">
                                <div class="d-flex flex-stack">
                                    <div class="d-flex ms-5">
                                        <button id="btn03010101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="fn0502AddSbuscriber();return false;"><i class="las la-user-plus fs-2"></i></button>
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
								<div id="div0501LoaderSubscriber" class="table-loading-message">
									Loading...
								</div>
                                <table id="table0501Subscriber" class="table table-row-bordered border rounded g-2 w-100 align-middle">
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
                        <!--End:: Subscriber -->
                    </div>
                    <div class="tab-pane fade" id="tab0101History">
                        <!--begin:: History -->
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">History</div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table id="table0601History" class="table table-row-bordered border rounded g-2 w-100 align-middle">
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
				<!--end:  Content-->
			</div>
			<!--end::Content-->
		</div>
		<!--end::title-->
     <!--begin::Modal Request - Form-->
		
	

        <!--begin::Modal Cancel-->
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
                        <div style="overflow-x: auto; scrollbar-width: thin;">
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
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Close</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>


		<div id="mdl0102Add" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
					   <h5 class="modal-title"><span id="spn0102parTitle">-</span></h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-warning" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick ="updToDTL() ">
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
				
						<div class="col-12 mb-2">
							<div class="input-group input-group-sm">
								<span class="input-group-text input-group-text-top  min-w-150px required">Particular</span>
								<input id="tbx0102Particular" type="text" class="form-control" Placeholder="Add particular" maxlength="100"/>
							</div>
						</div>
						<div class="col-12 mb-2">
							<div class="input-group input-group-sm">
								<span class="input-group-text input-group-text-top  min-w-150px required">Qty.</span>
								<input id="tbx0102Qty" type="text" class="form-control" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" maxlength="21" Placeholder="0.00"/>
							</div>
						</div>
						<div class="col-12 mb-2">
							<div class="input-group input-group-sm">
								<span class="input-group-text input-group-text-top  min-w-150px required">Unit</span>
								<input id="tbx0102Unit" type="text" class="form-control" Placeholder="Add unit" maxlength="100"/>
							</div>
						</div>
						<div id="divPaymentOnly" class="card-title fs-5 fw-bolder">Budget</div>
						<div class="col-12 mb-2">
							<div class="input-group input-group-sm">
								<span class="input-group-text input-group-text-top  min-w-150px required">Description</span>
								<input id="tbx0102Description" type="text" class="form-control" Placeholder="Add description"/>
							</div>
						</div>
						<div class="col-12 mb-2">
							<div class="input-group input-group-sm">
								<span class="input-group-text input-group-text-top  min-w-150px required">Amount</span>
								<input id="tbx0102Amount" type="text" class="form-control" onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event,this)" maxlength="21" Placeholder="0.00"/>
							</div>
						</div>
					</div>
					   <!--begin::Actions-->
					   <div class="modal-footer">
						   <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0102Edit_OK(this);return false;">
							   <span class="indicator-label">
								Save
							   </span>
							    <span class="indicator-progress">
									Loading
								</span>
						   </button>
							<a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="updToDTL()"> 
								<span class="indicator-label">Cancel</span>
							</a>
					   </div>
					   <!--end::Actions-->
				</div> 
			</div>
		   </div>
		<div id="mdl0103Status" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Overview - Change Status</h5>
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
							<span class="input-group-text min-w-150px required">Change status to</span>
								 <select id="ddl0103ChangeStatus" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0103ChangeStatus_onchange(this)">
										<option value="">Select a category</option>
								</select>
						</div>
						<div id="pnl01ClarifyTo" class="input-group input-group-sm mb-2" style="display:none;">
							<span class="input-group-text min-w-150px required">Clarify to</span>
								 <select id="ddl0103Clarifyto" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
										<option value="">Select a category</option>
								</select>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span id="spn01Note" class="input-group-text input-group-text-top min-w-150px">Notes</span>
								<textarea id="tbx0103Note" type="text" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details"></textarea>
						</div>
					</div>
					<!--begin::Actions-->
					   <div class="modal-footer">
						   <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0101SaveChangeStatus(this);return false;">
							   <span class="indicator-label">
								Save changes
							   </span>
						   </button>
							<a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="updToDTL()"> 
								<span class="indicator-label">Cancel</span>
							</a>
					   </div>
					<!--end::Actions-->
				</div>
			</div>
		</div>
        <!--begin::Modal Cancel-->

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

		<div id="mdl0401Aprroval" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Add User</h5>
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
                            <span class="input-group-text min-w-150px required">Add from</span>
                            <select id="ddl0401AddFrom" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0401AddFrom_onchange(this)">
                                <option value="">Select a type</option>
                                <option value="Manual">Manual</option>
                                <option value="Template">Template</option>
                            </select>
                        </div>
                        <div id="pnl04Type" style="display:none;">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Type</span>
                                <select id="ddl0401Type" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0401Type_onchange(this)">
                                    <option value="">Select a type</option>
                                    <option value="Endorsed By">Endorsed By</option>
                                    <option value="Approved By">Approved By</option>
                                    <option value="Implementer">Implementer</option>
                                </select>
                            </div>
                        </div>
                        <div id="pnl04AssignTo" style="display:none;">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Approver</span>
                                <select id="ddl0401Approver" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                    <option value="">Select a user</option>
                                </select>
                            </div>
                        </div>
                        <div id="pnl04NoDays" style="display:none;">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">No. of days</span>
                                <input id="tbx04NoDays" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" maxlength="21"/>
                            </div>
                        </div>
                        <div id="pnl04Template" style="display:none;">
                            <div class="input-group input-group-sm mb-2">
                                <span class="input-group-text min-w-150px required">Type</span>
                                <select id="ddl0401Template" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                    <option value="">Select a template</option>
                                </select>
                            </div>
                        </div>

                    </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0401AddApprover_OK(this);return false;">
                            <span class="indicator-label">Add
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close" onclick="updToDTL()">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                    <!--end::Actions-->
                </div>
            </div>
        </div>
		  <!--begin::Modal Comment-->
		<div id="mdl0402Reason4Delays" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Approval Path - Reason for delay</h5>
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
							<span class="input-group-text input-group-text-top min-w-150px">Reason for delay</span>
							<textarea id="tbx0402ReasonForDelay" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" Placeholder="Add reason" maxlength="1000"></textarea>
						</div>
					</div>
						<!--begin::Actions-->
					<div class="modal-footer">
						<button id="btn0402Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0402AddReason_OK(this);return false;">
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
		<!--begin::Modal Comment-->

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
						<textarea id="tbx0302Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" Placeholder="Notes" maxlength="1000"></textarea>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0302Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0302Add_Ok(this);return false;">
                            <span class="indicator-label">
                                Add
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

        <!--begin::Modal Comment-->
		<div id="mdl0501AddSubscriber" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Subscribers - Add User</h5>
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
                                <span class="input-group-text min-w-150px required">User</span>
                                <select id="ddl0501AddUser" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                    <option value="">Select a user</option>
                                </select>
                            </div>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0501Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0502AddSubscriber_OK(this);return false;">
                            <span class="indicator-label">
                                Add
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
    <input id="hdnSeqNo" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnTblName" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
    <input id="hdnTranNo" type="hidden" value="" />
    <input id="hdncode" type="hidden" value="" />
    <input id="hdnCLSub" type="hidden" value="" />
	<!--param-->
	<script type="text/javascript" src="Assets/js/FRM/FRM000015.js"></script>
	<script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
