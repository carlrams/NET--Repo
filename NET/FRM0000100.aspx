<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM0000100.aspx.vb" Inherits="NET.FRM0000100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Purchase Request</li>
					</ul>
				</div>
			</div>
		</div>

        <div class="card">
			
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
                    <div class="symbol me-5">
                        <img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
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
                            <!--begin:: Details -->
                            <div id="div0101Detail" class="card-body">
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">ID</span>
                                    <span id="lbl0101ID" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Type</span>
                                    <span id="lbl0101FormType" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Requested</span>
                                    <span id="lbl0101DateRequested" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Required</span>
                                    <span id="lbl0101DateRequired" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Requested By</span>
                                    <span id="lbl0101RequestedBy" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Assigned To</span>
                                    <span id="lbl0101AssignedTo" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Endorsed To</span>
                                    <span id="lbl0101EndorsedTo" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Status</span>
                                    <span id="lbl0101Status" class="form-control"></span>
                                </div>
                                <div class="separator separator-dashed my-6"></div>
                                <div class="input-group input-group-sm mb-2">
				                    <span class="input-group-text input-group-text-top min-w-150px">Purchase Type</span>
				                    <span id="lbl0101PurchaseType" class="form-control">-</span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
				                    <span class="input-group-text input-group-text-top min-w-150px">Project Type</span>
				                    <span id="lbl0101ProjectType" class="form-control">-</span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
				                    <span class="input-group-text input-group-text-top min-w-150px">Purpose</span>
				                    <span id="lbl0101Purpose" class="form-control">-</span>
                                </div>
                                <div id="div0101Vehicle" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Vehicle</span>
				                    <span id="lbl0101Vehicle" class="form-control">-</span>
                                </div>
                                <div id="div0101Category" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Category</span>
				                    <span id="lbl0101Category" class="form-control">-</span>
                                </div>
                                <div id="div0102Category" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span id="spn0102Category" class="input-group-text input-group-text-top min-w-150px">-</span>
				                    <span id="lbl0102Category" class="form-control">-</span>
                                </div>
                                <div id="div0101ActName" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Activity</span>
				                    <span id="lbl0101ActName" class="form-control">-</span>
                                </div>
                                <div id="div0101ActLocation" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Location</span>
				                    <span id="lbl0101ActLocation" class="form-control">-</span>
                                </div>
                                <div id="div0101ActDate" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Date</span>
				                    <span id="lbl0101ActDate" class="form-control">-</span>
                                </div>
                                <div id="div0101Subdivision" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Subdivision</span>
				                    <span id="lbl0101Subdivision" class="form-control">-</span>
                                </div>
                                <div id="div0101Estimate" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span id="spn0101Estimate" class="input-group-text input-group-text-top min-w-150px">Estimate</span>
				                    <span id="lbl0101Estimate" class="form-control">-</span>
                                </div>
                                <div id="div0101Project" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Project</span>
				                    <span id="lbl0101Project" class="form-control">-</span>
                                </div>
                                <div id="div0101ChargeTo" class="input-group input-group-sm mb-2" style="display: none;">
				                    <span class="input-group-text input-group-text-top min-w-150px">Charge To</span>
				                    <span id="lbl0101ChargeTo" class="form-control">-</span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
				                    <span class="input-group-text input-group-text-top min-w-150px">Division</span>
				                    <span id="lbl0101Division" class="form-control">-</span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
				                    <span class="input-group-text input-group-text-top min-w-150px">Department</span>
				                    <span id="lbl0101Department" class="form-control">-</span>
                                </div>
                                <div class="input-group input-group-sm mt-2">
                                    <span class="input-group-text min-w-150px">Remarks</span>
									<textarea id="lbl0101Remarks" class="form-control" maxlength="1000" rows="3" cols="" readonly="readonly">-</textarea>
                                </div>
                            </div>
                            <!--End:: Details -->

                            <!--begin:: Update/Edit/Add -->
                            <div id="div0101Update" class="card-body" style="display: none;">
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">ID</span>
                                    <input id="tbx0101ID" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Type</span>
                                    <input id="tbx0101FormType" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Requested</span>
                                    <input id="tbx0101DateRequested" type="text" class="form-control" readonly="readonly" />

                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px required">Date Required</span>
                                    <input id="tbx0101DateRequired" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Pick a date" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Requested By</span>
                                    <input id="tbx0101RequestedBy" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Assigned To</span>
                                    <input id="tbx0101AssignedTo" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Endorsed To</span>
                                    <input id="tbx0101EndorsedTo" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Status</span>
                                    <input id="tbx0101Status" type="text" class="form-control" readonly="readonly" />
                                </div>

                                <div class="separator separator-dashed my-6"></div>

								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Purchase Type</span>
							        <select id="ddl0101PurchaseType" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0101PurchaseType_onchange(this);">
                                        <option value="">Select Purchase Type</option>
                                        <option value="Cash Advance">Cash Advance</option>
                                        <option value="Cash Reimbursement">Cash Reimbursement</option>
                                        <option value="Credit Purchase">Credit Purchase</option>
                                        <option value="Department Petty Cash Fund">Department Petty Cash Fund</option>
                                        <option value="Gate Pass">Gate Pass</option>
                                        <option value="Return">Return</option>
                                        <option value="Stock Request">Stock Request</option>
                                        <option value="Transfer">Transfer</option>
                                    </select>
								</div>

								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Project Type</span>
                                    <input id="hf0101ProjectType" type="hidden" value="" />
							        <select id="ddl0101ProjectType" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="dd0101ProjectType_onchange(this);">
                                        <option value="">Select Project Type</option>
                                        <option value="Non OSM Project">Non OSM Project</option>
                                        <option value="OSM Project">OSM Project</option>
                                        <option value="OSM Project (Advance PO)">OSM Project (Advance PO)</option>
                                        <option value="OSM Project (Stock Request)">OSM Project (Stock Request)</option>
                                        <option value="CCI Project (Advance PO)">CCI Project (Advance PO)</option>
                                        <option value="CCI Project (Stock Request)">CCI Project (Stock Request)</option>
                                    </select>
								</div>

								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Purpose</span>
							        <select id="ddl0101Purpose" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0101Purpose_onchange(this);">
                                        <option value="">Select Purpose</option>
                                    </select>
								</div>

								<div id="div0102Vehicle" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Vehicle</span>
							        <select id="ddl0101Vehicle" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select Vehicle</option>
                                    </select>
								</div>
                                
								<div id="div0201Category" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Category</span>
							        <select id="ddl0101Category" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0101Category_onchange(this);">
                                        <option value="">Select Category</option>
                                    </select>
								</div>
                                
								<div id="div0202Category" class="input-group input-group-sm mb-2" style="display: none;">
									<span id="spn0202Category" class="input-group-text min-w-150px required">-</span>
							        <input id="tbx0202Category" type="text" class="form-control" value="" />
								</div>
                                
								<div id="div0102ActName" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Activity</span>
							        <input id="tbx0101ActName" type="text" class="form-control" Placeholder="Add category" value="" />
								</div>
                                
								<div id="div0102ActLocation" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Activity</span>
							        <input id="tbx0101ActLocation" type="text" class="form-control" Placeholder="Add location" value="" />
								</div>
                                
								<div id="div0102ActDate" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Activity</span>
							        <input id="tbx0101ActDate" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Pick a date" value="" />
								</div>
                                
								<div id="div0102Subdivision" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Subdivision</span>
							        <select id="ddl0101Subdivision" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select Subdivision</option>
                                    </select>
								</div>
                                
								<div id="div0102Estimate" class="input-group input-group-sm mb-2" style="display: none;">
									<span id="spn0102Estimate" class="input-group-text min-w-150px required">Estimate</span>
									<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
										<input id="tbx0101Estimate" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Add estimate" readonly="readonly" />
										<input id="hf0101Estimate" type="hidden" value="" />
										<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101Estimate(); return false;">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
                                
								<div id="div0102Project" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Project</span>
									<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
										<input id="tbx0101Project" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Add project" readonly="readonly" value="" />
										<input id="hf0101Subdivision" type="hidden" value="" />
										<input id="hf0101Phase" type="hidden" value="" />
										<input id="hf0101Block" type="hidden" value="" />
										<input id="hf0101Lot" type="hidden" value="" />
										<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101Project(); return false;">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
                                
								<div id="div0102ChargeTo" class="input-group input-group-sm mb-2" style="display: none;">
									<span class="input-group-text min-w-150px required">Charge To</span>
									<input id="tbx0101ChargeTo" type="text" class="form-control" placeholder="Charge To" readonly="readonly" value="" />
                                    <input id="hf0101ChargeCode" type="hidden" value="" />
                                    <input id="hf0101AcctCode" type="hidden" value="" />
                                    <input id="hf0101Subsidiary" type="hidden" value="" />
									<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
										<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn0101ChargeTo(); return false;">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
                                
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Division</span>
                                    <input id="tbx0101Division" type="text" class="form-control" readonly="readonly" placeholder="Add division" value="" />
                                    <input id="hf0101DivCode" type="hidden" value="" />
                                </div>
                                
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Department</span>
                                    <input id="tbx0101Department" type="text" class="form-control" readonly="readonly" placeholder="Add department" value="" />
                                    <input id="hf0101DeptCode" type="hidden" value="" />
                                </div>

                                <div class="input-group input-group-sm mt-2">
                                    <span class="input-group-text min-w-150px required">Remarks</span>
                                    <textarea id="tbx0101Remarks" class="form-control" placeholder="Add remarks" maxlength="1000" rows="3" cols=""></textarea>
                                </div>

                            </div>
                            
                         <!--begin:: Particular -->
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Particular</div>
							</div>
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex ms-5">
										<button id="btn11Add" class="btn btn-sm btn-icon btn-add align-self-center m-1 p-5" title="Add Particular" onclick="fn11Add();return false;" style="display: none;"><i class="las la-plus fs-2"></i></button>
                                        
										<div id="div11SCM" title="(SCM - Estimate - Purchase Request)" class="menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-add align-self-center m-1" data-kt-menu="true" style="display: none;">
											<div data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" class="menu-item menu-lg-down-accordion">
												<span class="menu-link">
													<span class="menu-title text-white" id="mnuSCM" runat="server">SCM - Purchase Req.</span>
												</span>
												<div class="menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown menu-rounded-0 py-lg-4 w-lg-300px">
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn11SCM(); return false;">
															<span class="menu-title">Add Item</span>
														</a>
													</div>
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn11UplSCM(); return false;">
															<span class="menu-title">Upload Item</span>
														</a>
													</div>
												</div>
											</div>
										</div>
                                        
										<div id="div11OSM" title="(OSM - Estimate - Stock Request)" class="menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-add align-self-center m-1" data-kt-menu="true" style="display: none;">
											<div data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" class="menu-item menu-lg-down-accordion">
												<span class="menu-link">
													<span class="menu-title text-white" id="Span1" runat="server">OSM - Stock Req.</span>
												</span>
												<div class="menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown menu-rounded-0 py-lg-4 w-lg-300px">
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn11OSM(); return false;">
															<span class="menu-title">Add Item</span>
														</a>
													</div>
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn11UplOSM(); return false;">
															<span class="menu-title">Upload Item</span>
														</a>
													</div>
												</div>
											</div>
										</div>

									</div>
                                    
                                    <div class="position-relative me-5">
                                        <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                            </svg>
                                        </span>
                                        <input id="tbx1101FindRecord" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                    </div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<div id="div0102LoaderParticular" class="table-loading-message">
										Loading...
									</div>

                                    <!-- Non House Construction -->
									<table id="table11Record" class="table table-row-bordered border table-hover rounded g-2 w-100 align-middle" style="display: none;">
										<thead class="fw-bold">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-75px mw-75px border-end">Type</th>
												<th class="min-w-300px mw-300px border-end">Particular</th>
												<th class="min-w-50px mw-50px border-end">QTY</th>
												<th class="min-w-75px mw-75px border-end">Unit</th>
												<th class="min-w-150px mw-150px border-end">Budget</th>
												<th class="min-w-150px mw-150px border-end">Status</th>
												<th class="min-w-50px mw-50px border-end">PO</th>
												<th class="min-w-150px mw-150px border-end">SR / WT / RT</th>
												<th class="min-w-50px mw-50px border-end">CP</th>
                                                <th class="min-w-150px mw-150px border-end">Cost</th>
                                                <th class="min-w-150px mw-150px border-end">Total</th>
												<th class="min-w-200px mw-200px border-end nowrap">Remarks</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
                                    <!-- Non House Construction -->

                                    <!-- House Construction -->
									<table id="table12Record" class="table table-row-bordered border table-hover rounded g-2 w-100 align-middle" style="display: none;">
										<thead class="fw-bold">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-75px mw-75px border-end">Type</th>
												<th class="min-w-300px mw-300px border-end">Particular</th>
												<th class="min-w-50px mw-50px border-end">QTY</th>
												<th class="min-w-75px mw-75px border-end">Unit</th>
												<th class="min-w-150px mw-150px border-end">Budget</th>
												<th class="min-w-150px mw-150px border-end">Status</th>
												<th class="min-w-75px mw-75px border-end">For PO</th>
												<th class="min-w-75px mw-75px border-end">For SR</th>
												<th class="min-w-200px mw-200px border-end nowrap">Remarks</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
                                    <!-- House Construction -->

								</div>
							</div>
						</div>
                        <!--End:: Particular -->

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
                                        <input id="tbx0201FindAttachment" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
									<div id="div0201LoaderAttachment" class="table-loading-message">
										Loading...
									</div>
                                    <table id="table0201Attachment" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                        <thead class="fw-bold">
                                            <tr class="fw-bold fs-7 text-gray-800">
                                                <th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
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
										<button id="btn989Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add Approval Path" onclick="fn0401AddApproval(); return false;"><i class="las la-user-plus fs-2"></i></button>
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
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
                                        <button id="btn99Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0301Add();return false;"><i class="las la-comment fs-2"></i></button>
                                    </div>
                                    <div class="position-relative me-5">
                                        <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                            </svg>
                                        </span>
                                        <input id="tbx0301FindNotes" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
									<div id="div0301LoaderNotes" class="table-loading-message">
										Loading...
									</div>
                                    <table id="table0301Notes" class="table gy-2 gs-2 w-100 align-middle">
                                        <thead style="display: none">
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
                                        <button id="btn03010101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add Subscriber" onclick="fn0502AddSubscriber(); return false;"><i class="las la-user-plus fs-2"></i></button>
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
			</div>
        </div>
		
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
						<div class="dropzone mb-5" id="divDropzone">
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
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl0302Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
						<textarea id="tbx0302Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Notes"  rows="3" cols=""></textarea>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0301Add_Ok(this);return false;">
                            <span class="indicator-label">
                                Add Note
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

        <div id="mdl0103Status" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
                            <select id="ddl0103ChangeStatus" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0103ChangeStatus_onchange(this);">
                            </select>
                        </div>
                        <div id="pnl01ClarifyTo" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Clarify to</span>
                            <select id="ddl0103Clarifyto" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                        <div class="input-group input-group-sm mb-2">
                            <span id="spn01Note" class="input-group-text input-group-text-top min-w-150px">Notes</span>
                            <textarea id="tbx0103Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Add extra details" rows="3" cols=""></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0101SaveChangeStatus(this); return false;">
                            <span class="indicator-label">Save changes
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl0501AddSubscriber" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
							<select id="ddl0501AddUser" data-kt-repeater="select2" data-dropdown-parent="#mdl0501AddSubscriber" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
						</div>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0502AddSubscriber_Ok(this);return false;">
                            <span class="indicator-label">Add User
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl0401Aprroval" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
                            <select id="ddl0401AddFrom" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0401AddFrom_onchange(this)">
                                <option value="">Select a type</option>
                                <option value="Manual">Manual</option>
                                <option value="Template">Template</option>
                            </select>
                        </div>
                        <div id="pnl04Type" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Type</span>
                            <select id="ddl0401Type" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0401Type_onchange(this)">
                                <option value="">Select a type</option>
                                <option value="Endorsed By">Endorsed By</option>
                                <option value="Approved By">Approved By</option>
                                <option value="Implementer">Implementer</option>
                            </select>
                        </div>
                        <div id="pnl04AssignTo" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Approver</span>
                            <select id="ddl0401Approver" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                        <div id="pnl04NoDays" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">No. of days</span>
                            <input id="tbx04NoDays" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" />
                        </div>
                        <div id="pnl04Template" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Type</span>
                            <select id="ddl0401Template" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0401AddApprover_Ok(this);return false;">
                            <span class="indicator-label">Add
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl0402Reason4Delays" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text input-group-text-top min-w-150px required">Reason for delay</span>
							<textarea id="tbx0402ReasonForDelay" class="form-control" placeholder="Add remarks" maxlength="1000" rows="3" cols=""></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0402AddReason_Ok(this);return false;">
                            <span class="indicator-label">Save
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

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
						<div class="d-flex align-items-center">
							<div class="position-relative">
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
						</div>
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
                </div>
            </div>
        </div>

        <div id="mdl01UpdateApprover" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Update Approver</h5>
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
                            <span class="input-group-text input-group-text-top min-w-150px required">Approver</span>
                            <select id="ddl01UpdApprover" data-kt-repeater="select2" class="form-select form-select-transparent form-select-sm h-5px mt-2">
                                <option value="">Select an approver</option>
                            </select>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn989SaveUpdApprover();return false;">
                            <span class="indicator-label">Save
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
        
		<div id="mdl0101Estimate" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-1000px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 id="h0101EstimateTitle" class="modal-title">-</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid01Api.setGridOption('quickFilterText', document.getElementById('tbx0101Find').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0101Estimate" style="height: 70vh;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl0101Charge" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog mw-650px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 id="h01Title" class="modal-title">-</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <div class="position-relative me-1">
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
				                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
					                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
					                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
				                        </svg>
                                    </span>
                                    <input id="tbx0101FindCharge" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="grid02Api.setGridOption('quickFilterText', document.getElementById('tbx0101FindCharge').value);" />
                                </div>
                            </div>
                            <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
				                <span class="svg-icon svg-icon-1">
					                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
						                <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
						                <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
					                </svg>
				                </span>
                            </div>
                        </div>
					</div>
					<div class="modal-body">
                        <div id="table0101Charging" style="height: 70vh;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl0101Project" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 id="h0101ProjectTitle" class="modal-title">-</h5>
						<div class="card-toolbar">
							<div class="d-flex flex-stack">
								<div class="position-relative me-5">
									<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1"
												transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
											<path
												d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z"
												fill="currentColor" />
										</svg>
									</span>
									<input id="tbx0101FindProject" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" oninput="grid03Api.setGridOption('quickFilterText', document.getElementById('tbx0101FindProject').value);" />
								</div>
								<div class="d-flex align-items-center">
									<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
												<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
											</svg>
										</span>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="modal-body">
						<div id="table0101Project" style="height: 70vh;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
        
		<div id="mdl0101SCM" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Add Particular - SCM (Stock Request)</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <div class="position-relative me-1">
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
				                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
					                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
					                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
				                        </svg>
                                    </span>
                                    <input id="tbx0101FindSCM" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="grid04Api.setGridOption('quickFilterText', document.getElementById('tbx0101FindSCM').value);" />
                                </div>
                            </div>
                            <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
				                <span class="svg-icon svg-icon-1">
					                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
						                <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
						                <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
					                </svg>
				                </span>
                            </div>
                        </div>
					</div>
					<div class="modal-body">
                        <div id="table0101SCM" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl0101OSM" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Add Particular - OSM (Stock Request)</h5>
                        <div class="d-flex align-items-center">
                            <div class="d-flex flex-stack">
                                <div class="position-relative me-1">
                                    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
				                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
					                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
					                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
				                        </svg>
                                    </span>
                                    <input id="tbx0101FindOSM" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" oninput="grid05Api.setGridOption('quickFilterText', document.getElementById('tbx0101FindOSM').value);" />
                                </div>
                            </div>
                            <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
				                <span class="svg-icon svg-icon-1">
					                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
						                <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
						                <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
					                </svg>
				                </span>
                            </div>
                        </div>
					</div>
					<div class="modal-body">
                        <div id="table0101OSM" style="height: 100%; border: none;"></div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
    </div>
    
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<input id="hdnSeqNo" runat="server" type="hidden" value="" />

    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/ag-grid-community/dist/ag-grid-community.min.js"></script>
    <script type="text/javascript" src="Assets/js/FRM/FRM000010.js"></script>
	<script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
