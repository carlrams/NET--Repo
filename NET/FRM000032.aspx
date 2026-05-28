<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000032.aspx.vb" Inherits="NET.FRM000032" MaintainScrollPositionOnPostback = "true"%>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--begin::Content-->
	<div class="content flex-row-fluid" id="kt_content">
		
		<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
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
						<li class="breadcrumb-item"><a href="FRM010000" class="text-white-hover">Form</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Transfer of Title Routing Slip</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtn02UploadSave" runat="server" Text="Button" OnClick="lbtn02UploadSave_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::title-->
		<div class="card card-flush">
			<asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<!--begin::title-->
				<div class="card-header pt-5 border-bottom-0">
					<div class="d-flex align-items-center">
						<!--begin::Icon-->
						<div class="symbol me-5">
							<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
						</div>
						<!--end::Icon-->
						<!--begin::Title-->
						<div class="d-flex flex-column">
							<h2 class="mb-1"><asp:Label id="lblTitle" runat="server"></asp:Label></h2>
							<div class="text-muted fw-bolder">
								<asp:Label ID="lblID" runat="server"></asp:Label>
								<span class="mx-3">|</span>
								<asp:Label ID="lblStatus" runat="server"></asp:Label>
							</div>
						</div>
						<!--end::Title-->
					</div>
					<div class="card-toolbar">
						<div class="d-flex flex-stack">
							<!--begin::Navs-->
							<div class="d-flex overflow-auto">
								<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
									<!--begin::Nav item-->
									<li class="nav-item m-0">
										<a class="nav-link text-active-primary active" title="Overview" data-bs-toggle="tab" href="#Menu01_TabContent"><i class="las la-file-alt fs-3x"></i></a>
									</li>
									<!--end::Nav item-->
									<!--begin::Nav item-->
									<li class="nav-item m-0">
										<a class="nav-link text-active-primary position-relative" title="Files" data-bs-toggle="tab" href="#Menu02_TabContent">
											<i class="las la-paperclip fs-3x"></i>
											<span id="blink01Attachment" runat="server" class="bullet bullet-dot bg-warning h-8px w-8px position-absolute translate-middle top-10 start-50 animation-blink" style="display:none"></span>
										</a>
									</li>
									<!--end::Nav item-->
									<!--begin::Nav item-->
									<li class="nav-item m-0">
										<a class="nav-link text-active-primary" title="Subscribers" data-bs-toggle="tab" href="#Menu03_TabContent"><i class="las la-user-friends fs-3x"></i></a>
									</li>
									<!--end::Nav item-->
									<!--begin::Nav item-->
									<li class="nav-item m-0">
										<a class="nav-link text-active-primary" title="History" data-bs-toggle="tab" href="#Menu06_TabContent"><i class="las la-history fs-3x"></i></a>
									</li>
									<!--end::Nav item-->
								</ul>
							</div>
							<!--begin::Navs-->
						</div>
					</div>
				</div>
				<!--end::title-->
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::menu-->
			<!--begin::Content-->
			<div class="card" >
				<!--begin::Content-->
				<div class="tab-content" >
					<div class="tab-pane fade show active" id="Menu01_TabContent">
						<!--begin::Menu Content-->
						<asp:UpdatePanel ID="upnl01Overview" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Overview</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex">
									<asp:LinkButton ID="lbtn01Find" runat="server" ToolTip="Find record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-search fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Refresh" runat="server" ToolTip="Refresh record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-redo-alt fs-2"></i></asp:LinkButton>
									<span class="pt-8"><i class="las la-ellipsis-v fs-2"></i></span>
									<asp:LinkButton ID="lbtn01Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-plus fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Delete" runat="server" ToolTip="Delete record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-trash fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Edit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
									<span class="pt-8"><i class="las la-ellipsis-v fs-2"></i></span>
									<asp:LinkButton ID="lbtn01Status" runat="server" ToolTip="Change Status" class="btn btn-sm btn-icon btn-secondary align-self-center m-1"><i class="las la-flag fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Print" runat="server" ToolTip="Print" class="btn btn-sm btn-icon btn-secondary align-self-center m-1"><i class="las la-print fs-2"></i></asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<!--begin::Edit-->
								<asp:Panel ID="pnl01Edit" runat="server" Visible="false">
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">ID</span>
										<asp:TextBox ID="tbx01ID" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Type</span>
										<asp:TextBox ID="tbx01FormType" runat="server" class="form-control" ReadOnly="true">Sales Request Advice</asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<asp:TextBox ID="tbx01DateRequested" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Date Required</span>
										<input id="tbx01DateRequired" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" Placeholder="Pick a date" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Requested By</span>
										<asp:TextBox ID="tbx01RequestedBy" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Assigned To</span>
										<asp:TextBox ID="tbx01AssignedTo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Endorsed To</span>
										<asp:TextBox ID="tbx01EndorsedTo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Status</span>
										<asp:TextBox ID="tbx01Status" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<!--end::separator-->
									<div class="separator separator-dashed my-6"></div>
									<!--begin::separator-->
									<div class="card-title fs-5 fw-bolder">Account</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Account</span>
										<input id="tbx01AcctNo" runat="server" type="text" class="form-control mw-150px min-w-150px" readonly Placeholder="Account No." />
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01AcctName" runat="server" type="text" class="form-control form-control-sm border-0 m-0" readonly placeholder="Account Name" />
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
										<input id="tbx01Project" runat="server" type="text" class="form-control" Placeholder="Add project" readonly />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Title No.</span>
										<input id="tbx01TCTNo" runat="server" type="text" class="form-control" Placeholder="Add title No" />
									</div>
									<div class="card-title fs-5 fw-bolder">Total Contract Price</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Actual</span>
										<input id="tbx01TCPAmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Paid</span>
										<input id="tbx01TCPDatePaid" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Other Instructions</span>
										<textarea id="tbx01TCPOtherInstructions" type="text" runat="server" class="form-control min-h-75px" Placeholder="Add other Instructions"></textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Processing Fee - Full</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Full Payment</span>
										<input id="tbx01PFFullPmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Paid</span>
										<input id="tbx01PFFullDatePaid" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">OR No.</span>
										<input id="tbx01PFFullORNo" runat="server" type="text" class="form-control" Placeholder="OR No." />
									</div>
									<div class="card-title fs-5 fw-bolder">Processing Fee - Partial</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Partial</span>
										<input id="tbx01PFPrtlPmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Paid</span>
										<input id="tbx01PFPrtlDatePaid" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">OR No.</span>
										<input id="tbx01PFPrtlORNo" runat="server" type="text" class="form-control" Placeholder="Add OR No." />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Balance</span>
										<input id="tbx01PFPrtlBalance" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
									</div>
									<div class="card-title fs-5 fw-bolder">Processing Fee - Remarks</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<textarea id="tbx01PFRemarks" type="text" runat="server" class="form-control min-h-75px" Placeholder="Add remarks"></textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Remarks</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">AAD/Billing & Collect.</span>
										<input id="tbx01AAdRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">FIN/Treasury</span>
										<input id="tbx01FINTreasuryRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">FIN/Accounting</span>
										<input id="tbx01FINAcccountingRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">ENG/Survey</span>
										<input id="tbx01ENGRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
									</div>
									<div class="card-title fs-5 fw-bolder">Requirements</div>
									<div class="row border border-radius-047rem pt-3 m-05 ">
										<div class="col-12">
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01BIS_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01BIS_upd">
													a. Completely filled up Buyer's Information Sheet (BIS)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01DOAS_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01DOAS_upd">
													b. Signed Deed of Absolute Sales (DOAS)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01DOR_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01DOR_upd">
													c. Signed Deed of Restriction (DOR)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb011904_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb011904_upd">
													d. Completely filled up 1904
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01S1904_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01S1904_upd">
													e. Spouse' completely filled up 1904 (if applicable)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb012ID_upd" runat="server" onclick="cb012ID(this.id)"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb012ID_upd">
													f. Two (2) valid government issued ID's
												</label>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm ">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Pls specify (1):</span>
														<input id="tbx01ID1" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Pls specify (2):</span>
														<input id="tbx01ID2" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS. (if applicable) (1):</span>
														<input id="tbx01SID1" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-4">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS. (if applicable) (2):</span>
														<input id="tbx01SID2" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
													</div>
												</div>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01TIN_upd" runat="server" onclick="cb01TIN(this.id)"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01TIN_upd">
													g. Tax Identification Number (TIN)
												</label>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Single:</span>
														<input id="tbx01TINSingle" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-4">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS (if applicable):</span>
														<input id="tbx01TINSpouse" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
													</div>
												</div>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01NSO_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01NSO_upd">
													h. NSO Birth Certificate
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01SNSO_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01SNSO_upd">
													i. Spouse NSO Birth Certificate (if applicable)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01MNSO_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01MNSO_upd">
													j. NSO Marriage Contract (if applicable)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01BP_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01BP_upd">
													k. Building Permit
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01COO_upd" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01COO_upd">
													l. COO
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01ADD_upd" runat="server" onclick="cb01ADD(this.id)"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01ADD_upd">
													m. Additional Requirements
												</label>
											</div>
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<div class="input-group input-group-sm">
													<asp:Label runat="server" class="input-group-text input-group-text-top bg-white fs-7 fw-normal">Please specify:</asp:Label>
													<textarea id="tbx01DTL" type="text" runat="server" class="form-control form-control-flush h-75px min-h-75px mh-75px" Placeholder="specify" readonly></textarea>
												</div>
											</div>
										</div>
									</div>
								</asp:Panel>
								<!--end::Edit-->
								<!--begin::Dtl-->
								<asp:Panel ID="pnl01Dtl" runat="server" Visible="false">
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">ID</span>
										<asp:Label ID="lbl01ID" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Type</span>
										<asp:Label ID="lbl01FormType" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<asp:Label ID="lbl01DateRequested" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Required</span>
										<asp:Label ID="lbl01DateRequired" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Requested By</span>
										<asp:Label ID="lbl01RequestedBy" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Assigned To</span>
										<asp:Label ID="lbl01AssignedTo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Endorsed To</span>
										<asp:Label ID="lbl01EndorsedTo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Status</span>
										<asp:Label ID="lbl01Status" runat="server" class="form-control">-</asp:Label>
									</div>
									<!--begin::Separator-->
									<div class="separator separator-dashed my-6"></div>
									<!--end::Separator-->
									<div class="card-title fs-5 fw-bolder">Account</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Account</span>
										<asp:Label ID="lbl01AcctNo" runat="server" class="form-control mw-150px min-w-150px">-</asp:Label>
										<asp:Label ID="lbl01AcctName" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Project</span>
										<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Title No.</span>
										<asp:Label ID="lbl01TCTNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Total Contract Price</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Actual</span>
										<asp:Label ID="lbl01TCPAmt" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Paid</span>
										<asp:Label ID="lbl01TCPDatePaid" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Other Instructions</span>
										<textarea id="lbl01TCPOtherInstructions" type="text" runat="server" class="form-control min-h-75px" readonly>-</textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Processing Fee - Full</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Full Payment</span>
										<asp:Label ID="lbl01PFFullPmt" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Paid</span>
										<asp:Label ID="lbl01PFFullDatePaid" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">OR No.</span>
										<asp:Label ID="lbl01PFFullORNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Processing Fee - Partial</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Partial</span>
										<asp:Label ID="lbl01PFPrtlPmt" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Paid</span>
										<asp:Label ID="lbl01PFPrtlDatepaid" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">OR No.</span>
										<asp:Label ID="lbl01PFPrtlORNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Balance</span>
										<asp:Label ID="lbl01PFPrtlBalance" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Processing Fee - Remarks</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<textarea id="lbl01PFRemarks" type="text" runat="server" class="form-control min-h-75px" readonly>-</textarea>
									</div>
									<div class="card-title fs-5 fw-bolder">Remarks</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">AAD/Billing & Collect.</span>
										<asp:Label ID="lbl01RemarksAAD" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">FIN/Treasury</span>
										<asp:Label ID="lbl01RemarksFINTreasury" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">FIN/Accounting</span>
										<asp:Label ID="lbl01RemarksFINAcccounting" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">ENG/Survey</span>
										<asp:Label ID="lbl01RemarksENG" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Requirements</div>
									<div class="row border border-radius-047rem pt-3 m-05 ">
										<div class="col-12">
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01BIS_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01BIS_dtl">
													a. Completely filled up Buyer's Information Sheet (BIS)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01DOAS_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01DOAS_dtl">
													b. Signed Deed of Absolute Sales (DOAS)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01DOR_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01DOR_dtl">
													c. Signed Deed of Restriction (DOR)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb011904_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb011904_dtl">
													d. Completely filled up 1904
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01S1904_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01S1904_dtl">
													e. Spouse' completely filled up 1904 (if applicable)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb012ID_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb012ID_dtl">
													f. Two (2) valid government issued ID's
												</label>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm ">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Pls specify (1):</span>
														<asp:Label ID="lbl01ID1" runat="server" class="form-control"></asp:Label>
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Pls specify (2):</span>
														<asp:Label ID="lbl01ID2" runat="server" class="form-control"></asp:Label>
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS (if applicable) (2):</span>
														<asp:Label ID="lbl01SID1" runat="server" class="form-control"></asp:Label>
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-4">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS (if applicable) (2):</span>
														<asp:Label ID="lbl01SID2" runat="server" class="form-control"></asp:Label>
													</div>
												</div>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01TIN_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01TIN_dtl">
													g. Tax Identification Number (TIN)
												</label>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-2">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Single:</span>
														<asp:Label ID="lbl01TINSingle" runat="server" class="form-control"></asp:Label>
													</div>
												</div>
											</div>
											<div class="col-lg-12 col-md-6 col-sm-12">
												<div class="form-check form-check-custom form-check-solid form-check-sm">
													<div class="input-group input-group-sm mb-4">
														<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS (if applicable):</span>
														<asp:Label ID="lbl01TINSpouse" runat="server" class="form-control"></asp:Label>
													</div>
												</div>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01NSO_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01NSO_dtl">
													h. NSO Birth Certificate
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01SNSO_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01SNSO_dtl">
													i. Spouse NSO Birth Certificate (if applicable)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01MNSO_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01MNSO_dtl">
													j. NSO Marriage Contract (if applicable)
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01BP_Dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01BP_dtl">
													k. Building Permit
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01COO_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01COO_dtl">
													l. COO
												</label>
											</div>
											<div class="form-check form-check-custom form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb01ADD_dtl" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01ADD_dtl">
													m. Additional Requirements
												</label>
											</div>
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<div class="input-group input-group-sm">
													<span class="input-group-text input-group-text-top bg-white fs-7 fw-normal">Please specify:</span>
													<textarea id="lbl01DTL" type="text" runat="server" class="form-control h-75px min-h-75px mh-75px" Placeholder="specify" readonly></textarea>
												</div>
											</div>
										</div>
									</div>
								</asp:Panel>
							</div>
							<!--end::Dtl-->
						</ContentTemplate>
						</asp:UpdatePanel>
						<!--end::Menu Content-->

						<!--begin::Menu Content-->
						<asp:UpdatePanel ID="upnl05Notes" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Notes</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex">
									<asp:LinkButton ID="lbtn05Add" runat="server" ToolTip="Add note" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-comment fs-2"></i></asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<div class="table-responsive">
									<asp:GridView ID="gv05Notes" runat="server" class="table table-no-border" AutoGenerateColumns="False" ShowHeader="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center mb-5">
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<div class="symbol-label">
															<img alt="" class="w-100" src="<%# Eval("Icon") %>" />
														</div>
													</div>
													<!--end::Avatar-->
													<!--begin::User details-->
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark"><%# Eval("By") %></span>
														<span class="text-muted"><%# Eval("Date") %></span>
													</div>
													<!--begin::User details-->
												</div>
												<!--begin::Desc-->
												<p class="text-dark"><%# Eval("Notes") %></p>
												<!--end::Desc-->
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::ID-->
							</div>
						</ContentTemplate>
						</asp:UpdatePanel>
						<!--end::Menu Content-->

						<!--begin::Menu Content-->
						<asp:UpdatePanel ID="upnl04ApprovalPath" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Approval Path</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex">
									<asp:LinkButton ID="lbtn04Add" runat="server" ToolTip="Add approver" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-user-plus fs-2"></i></asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<!--begin::ID-->
								<div class="table-responsive">
									<asp:GridView ID="gv04ApprovalPath" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class='<%# Eval("Bullet") %>'></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Action">
											<ItemTemplate>
												<div class="d-flex ">
													<asp:LinkButton ID="lbtn04Delete" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("SeqNo") %>' OnClick="lbtn04Delete" ToolTip="Remove user"><i class="las la-trash fs-3"></i></asp:LinkButton>
													<asp:LinkButton ID="lbtn04Update" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("SeqNo") %>' OnClick="lbtn04Update" ToolTip="Update reason for delay"><i class="las la-pencil-alt fs-3"></i></asp:LinkButton>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark" />
											<ItemStyle CssClass=" align-middle" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Move">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<asp:LinkButton ID="lbtn04Up" runat="server" CssClass="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("SeqNo") %>' OnClick="lbtn04up" ToolTip="Move user up"><i class="las la-angle-up"></i></asp:LinkButton>
													<asp:LinkButton ID="lbtn04Down" runat="server" CssClass="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("SeqNo") %>' OnClick="lbtn04Down" ToolTip="Move user down"><i class="las la-angle-down"></i></asp:LinkButton>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark" />
											<ItemStyle CssClass=" align-middle " />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Type">
											<ItemTemplate>
												<%# Eval("Type") %>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px mw-100px" />
											<ItemStyle CssClass=" align-middle" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="User">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<div class="symbol-label">
															<img alt="" class="w-100" src="<%# Eval("Icon") %>" />
														</div>
													</div>
													<!--end::Avatar-->
													<!--begin::User details-->
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark nowrap-240px"><%# Eval("ApprName") %></span>
														<span class="text-muted nowrap-240px"><%# Eval("ApprJob") %></span>
													</div>
													<!--begin::User details-->
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-250px mw-250px" />
											<ItemStyle CssClass=" align-middle " />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Status">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark"><%# Eval("ApprStatus") %></span>
														<span class="text-muted"><%# Eval("ApprDate") %></span>
													</div>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px mw-100px" />
											<ItemStyle CssClass=" align-middle" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Turn around time">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark nowrap-240px"><%# Eval("Coverage") %></span>
														<span class="text-muted nowrap-240px"><%# Eval("Duration") %> Day(s)</span>
													</div>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px mw-100px" />
											<ItemStyle CssClass=" align-middle" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Reason for delay">
											<ItemTemplate>
												<%# Eval("Reason") %>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px w-100" />
											<ItemStyle CssClass=" align-middle" />
										</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::ID-->
							</div>
						</ContentTemplate>
						</asp:UpdatePanel>
						<!--end::Menu Content-->
					</div>
					<div class="tab-pane fade" id="Menu02_TabContent">
						<!--begin::Menu Content-->
						<asp:UpdatePanel ID="upnl02Files" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
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
								<div class="d-flex">
									<asp:LinkButton ID="lbtn02Upload" runat="server" ToolTip="Upload file" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-upload fs-2"></i></asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<!--begin::Files-->
								<div class="table-responsive">
									<asp:GridView ID="gv02Files" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Action">
											<ItemTemplate>
												<div class="d-flex ">
													<asp:LinkButton ID="lbtn02Delete" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("Name") %>' ToolTip="Remove file" OnClick="lbtn02Delete"><i class="las la-trash fs-3"></i></asp:LinkButton>
													<asp:LinkButton ID="lbtn02Download" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' ToolTip="Download file" OnClick="lbtn02Download"><i class="las la-download fs-3"></i></asp:LinkButton>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark" />
											<ItemStyle CssClass=" align-middle" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="File">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<span class="w-100"><%# Eval("Icon") %></span>
													</div>
													<!--end::Avatar-->
													<!--begin::User details-->
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark"><%# Eval("Name") %></span>
														<span class="text-muted"><%# Eval("CreationTime") %></span>
													</div>
													<!--begin::User details-->
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px w-100" />
											<ItemStyle CssClass="align-middle" />
										</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::Files-->
							</div>
						</div>
						<!--end::Menu Content-->
						</ContentTemplate>
						</asp:UpdatePanel>
					</div>
					<div class="tab-pane fade" id="Menu03_TabContent">
						<!--begin::Menu Content-->
						<asp:UpdatePanel ID="upnl03Subscribers" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Subscribers</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex">
									<asp:LinkButton ID="lbtn03Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-user-plus fs-2"></i></asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<!--begin::ID-->
								<div class="table-responsive">
									<asp:GridView ID="gv03Subscribers" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Action">
											<ItemTemplate>
												<div class="d-flex">
													<asp:LinkButton ID="lbtn03Delete" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Code") %>' OnClick="lbtn03Delete"><i class="las la-trash fs-3"></i></asp:LinkButton>
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="User">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<div class="symbol-label">
															<img alt="" class="w-100" src="<%# Eval("Icon") %>" />
														</div>
													</div>
													<!--end::Avatar-->
													<!--begin::User details-->
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark"><%# Eval("Name") %></span>
														<span class="text-muted"><%# Eval("JobDesc") %></span>
													</div>
													<!--begin::User details-->
												</div>
											</ItemTemplate>
											<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px w-100" />
										</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::ID-->
							</div>
						</ContentTemplate>
						</asp:UpdatePanel>
						<!--end::Menu Content-->
					</div>
					<div class="tab-pane fade" id="Menu06_TabContent">
						<!--begin::Menu Content-->
						<asp:UpdatePanel ID="upnl06History" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">History</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<div class="table-responsive">
									<asp:GridView ID="gv06History" runat="server" class="table table-no-border" AutoGenerateColumns="False" ShowHeader="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<div class="symbol-label">
															<img alt="" class="w-100" src="<%# Eval("Icon01") %>" />
														</div>
													</div>
													<!--end::Avatar-->
													<!--begin::User details-->
													<div class="d-flex flex-column min-w-200px me-3">
														<span class="fw-bold text-dark nowrap-200px"><%# Eval("Name") %></span>
														<span class="text-muted nowrap-200px"><%# Eval("Date") %></span>
													</div>
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<div class='<%# Eval("Class02") %>'>
															<i class='<%# Eval("Icon02") %>'></i>
														</div>
													</div>
													<!--end::Avatar-->
													<div class="d-flex flex-column min-w-300px w-100">
														<span class="fw-bold text-dark"><%# Eval("Type") %></span>
														<span class="text-muted"><%# Eval("Description") %></span>
													</div>
													<!--begin::User details-->
												</div>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
								<!--end::ID-->
							</div>
						</ContentTemplate>
						</asp:UpdatePanel>
						<!--end::Menu Content-->
					</div>
				</div>
				<!--end:  Content-->
			</div>
			<!--end::Content-->
		</div>
		<!--end::title-->

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
		<!--begin::Modal Find Buyer -->

		<!--begin::Modal Find -->
		<asp:UpdatePanel ID="mdl01Find" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						<!--begin::list-->
							<asp:GridView ID="gv01Find" runat="server" class="table table-no-border table-row-bordered table-hover align-middle w-100" AutoGenerateColumns="False" showheader="false" >
								<Columns>
									<asp:TemplateField HeaderText="">
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-5px" />
										<ItemStyle CssClass="mw-5px min-w-5px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="">
										<ItemTemplate>
											<a href='<%# Eval("Link") %>' class="d-flex align-items-center w-100">
												<div class="d-flex flex-column min-w-30px mw-30px me-3"  >
													<div class="symbol symbol-30px overflow-hidden">
														<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
													</div>
												</div>
												<div class="d-flex flex-column min-w-400px w-100">
													<span class="text-dark fw-bolder fs-6 nowrap-auto"> <%# Eval("Title") %></span>
													<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
												</div>
											</a>
										</ItemTemplate>
										<HeaderStyle CssClass="w-100" />
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>
						<!--end::list-->
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Find-->
		
		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdl01DialogBox" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Message</h5>
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
						<p><asp:Label ID="lbl01ConfirmMessageDialogBox" runat="server"></asp:Label></p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn01DeleteOk" runat="server" class="btn btn-primary" Visible="false">Ok</asp:LinkButton>
						<asp:LinkButton ID="lbtn01SaveOk" runat="server" class="btn btn-primary" Visible="false">Ok</asp:LinkButton>
						<asp:LinkButton ID="lbtn02DeleteOk" runat="server" class="btn btn-primary" Visible="false">Ok</asp:LinkButton>
						<asp:HiddenField ID="hfFileName" runat="server" />
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
		<!--begin::Modal Edit Record-->
		<asp:UpdatePanel ID="mdl06Edit" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-focus="false" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Details</h5>
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
						<div class="card-title fs-5 fw-bolder">Form</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Date Required</span>
							<input id="tbx06DateRequired" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" Placeholder="Pick a date" />
						</div>
						<div class="card-title fs-5 fw-bolder">Account</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Account</span>
							<input id="tbx06AcctNo" runat="server" type="text" class="form-control mw-150px min-w-150px" readonly Placeholder="Account No." />
							<input id="tbx06AcctName" runat="server" type="text" class="form-control" Placeholder="Account Name" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Title No.</span>
							<input id="tbx06TCTNo" runat="server" type="text" class="form-control" Placeholder="Add title No" />
						</div>
						<div class="card-title fs-5 fw-bolder">Total Contract Price</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Actual</span>
							<input id="tbx06TCPAmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Date Paid</span>
							<input id="tbx06TCPDatePaid" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Other Instructions</span>
							<textarea id="tbx06TCPOtherInstructions" type="text" runat="server" class="form-control min-h-75px" Placeholder="Add other Instructions"></textarea>
						</div>
						<div class="card-title fs-5 fw-bolder">Processing Fee - Full</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Full Payment</span>
							<input id="tbx06PFFullPmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Date Paid</span>
							<input id="tbx06PFFullDatePaid" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">OR No.</span>
							<input id="tbx06PFFullORNo" runat="server" type="text" class="form-control" Placeholder="OR No." />
						</div>
						<div class="card-title fs-5 fw-bolder">Processing Fee - Partial</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Partial</span>
							<input id="tbx06PFPrtlPmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Date Paid</span>
							<input id="tbx06PFPrtlDatePaid" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">OR No.</span>
							<input id="tbx06PFPrtlORNo" runat="server" type="text" class="form-control" Placeholder="Add OR No." />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Balance</span>
							<input id="tbx06PFPrtlBalance" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="card-title fs-5 fw-bolder">Processing Fee - Remarks</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<textarea id="tbx06PFRemarks" type="text" runat="server" class="form-control min-h-75px" Placeholder="Add remarks"></textarea>
						</div>
						<div class="card-title fs-5 fw-bolder">Remarks</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">AAD/Billing & Collect.</span>
							<input id="tbx06AAdRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">FIN/Treasury</span>
							<input id="tbx06FINTreasuryRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">FIN/Accounting</span>
							<input id="tbx06FINAcccountingRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">ENG/Survey</span>
							<input id="tbx06ENGRemarks" runat="server" type="text" class="form-control" Placeholder="Add remarks" />
						</div>
						<div class="card-title fs-5 fw-bolder">Requirements</div>
						<div class="row border border-radius-047rem pt-3 m-05 ">
							<div class="col-12">
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06BIS_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06BIS_upd">
										a. Completely filled up Buyer's Information Sheet (BIS)
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06DOAS_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06DOAS_upd">
										b. Signed Deed of Absolute Sales (DOAS)
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06DOR_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06DOR_upd">
										c. Signed Deed of Restriction (DOR)
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb061904_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb061904_upd">
										d. Completely filled up 1904
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06S1904_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06S1904_upd">
										e. Spouse' completely filled up 1904 (if applicable)
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb062ID_upd" runat="server" onclick="cb062ID(this.id)"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb062ID_upd">
										f. Two (2) valid government issued ID's
									</label>
								</div>
								<div class="col-lg-12 col-md-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm ">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Pls specify (1):</span>
											<input id="tbx06ID1" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
										</div>
									</div>
								</div>
								<div class="col-lg-12 col-md-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Pls specify (2):</span>
											<input id="tbx06ID2" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
										</div>
									</div>
								</div>
								<div class="col-lg-12 col-md-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS. (if applicable) (1):</span>
											<input id="tbx06SID1" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
										</div>
									</div>
								</div>
								<div class="col-lg-12 col-md-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm">
										<div class="input-group input-group-sm mb-4">
											<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS. (if applicable) (2):</span>
											<input id="tbx06SID2" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
										</div>
									</div>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06TIN_upd" runat="server" onclick="cb06TIN(this.id)"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06TIN_upd">
										g. Tax Identification Number (TIN)
									</label>
								</div>
								<div class="col-lg-12 col-md-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm">
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">Single:</span>
											<input id="tbx06TINSingle" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
										</div>
									</div>
								</div>
								<div class="col-lg-12 col-md-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm">
										<div class="input-group input-group-sm mb-4">
											<span class="input-group-text min-w-150px bg-white fs-7 fw-normal ">SPS (if applicable):</span>
											<input id="tbx06TINSpouse" runat="server" type="text" class="form-control" Placeholder="specify" readonly />
										</div>
									</div>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06NSO_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06NSO_upd">
										h. NSO Birth Certificate
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06SNSO_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06SNSO_upd">
										i. Spouse NSO Birth Certificate (if applicable)
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06MNSO_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06MNSO_upd">
										j. NSO Marriage Contract (if applicable)
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06BP_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06BP_upd">
										k. Building Permit
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06COO_upd" runat="server"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06COO_upd">
										l. COO
									</label>
								</div>
								<div class="form-check form-check-custom form-check-sm mb-4">
									<input class="form-check-input" type="checkbox" value="" id="cb06ADD_upd" runat="server" onclick="cb06ADD(this.id)"/>
									<label class="form-check-label" for="ContentPlaceHolder1_cb06ADD_upd">
										m. Additional Requirements
									</label>
								</div>
								<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
									<div class="input-group input-group-sm">
										<asp:Label runat="server" class="input-group-text input-group-text-top bg-white fs-7 fw-normal">Please specify:</asp:Label>
										<textarea id="tbx06DTL" type="text" runat="server" class="form-control form-control-flush h-75px min-h-75px mh-75px" Placeholder="specify" readonly></textarea>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn06Edit_Ok" runat="server" class="btn btn-primary">Save</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Edit Record-->
		
		<!--begin::Modal Status-->
		<asp:UpdatePanel ID="mdl01Status" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
							<asp:DropDownList ID="ddl01Status" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a category</asp:ListItem>
							</asp:DropDownList>
						</div>
						<asp:Panel ID="pnl01ClarifyTo" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px required">Clarify to</span>
							<asp:DropDownList ID="ddl01ClarifyTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select a category</asp:ListItem>
							</asp:DropDownList>
						</asp:Panel>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
							<asp:TextBox ID="tbx01Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn01SaveStatus" runat="server" class="btn btn-primary">Save changes</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Status-->
				
		<!--begin::Modal Upload-->
		<asp:UpdatePanel ID="mdl02Upload" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
						<asp:LinkButton ID="lbtn02CancelUpload" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
						<button id="lbtn02SaveUpload" type="button" class="btn btn-primary">Upload</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Upload-->
		
		<!--begin::Modal Subscribers-->
		<asp:UpdatePanel ID="mdl03User" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
							<asp:DropDownList ID="ddl03User" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03User" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a user</asp:ListItem>
							</asp:DropDownList>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn03AddUser" runat="server" class="btn btn-primary">Add</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Subscribers-->
		
		<!--begin::Modal Approver-->
		<asp:UpdatePanel ID="mdl04Approver" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
							<asp:DropDownList ID="ddl04AddFrom" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl04Approver" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a type</asp:ListItem>
                                <asp:ListItem Value="Manual">Manual</asp:ListItem>
                                <asp:ListItem Value="Template">Template</asp:ListItem>
							</asp:DropDownList>
						</div>
						<asp:Panel ID="pnl04Type" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px required">Type</span>
							<asp:DropDownList ID="ddl04Type" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl04Approver" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a type</asp:ListItem>
                                <asp:ListItem Value="Endorsed By">Endorsed By</asp:ListItem>
                                <asp:ListItem Value="Approved By">Approved By</asp:ListItem>
                                <asp:ListItem Value="Implementer">Implementer</asp:ListItem>
							</asp:DropDownList>
						</asp:Panel>
						<asp:Panel ID="pnl04AssignTo" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px required">Approver</span>
							<asp:DropDownList ID="ddl04Approver" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl04Approver" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a user</asp:ListItem>
							</asp:DropDownList>
						</asp:Panel>
						<asp:Panel ID="pnl04NoDays" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px required">No. of days</span>
							<input id="tbx04NoDays" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</asp:Panel>
						<asp:Panel ID="pnl04Template" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px required">Type</span>
							<asp:DropDownList ID="ddl04Template" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl04Approver" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select a template</asp:ListItem>
							</asp:DropDownList>
						</asp:Panel>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn04AddApprover" runat="server" class="btn btn-primary">Add</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Approver-->
		
		<!--begin::Modal Comment-->
		<asp:UpdatePanel ID="mdl04ReasonForDelay" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
						<!--begin::note-->
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Reason for delay</span>
							<asp:TextBox ID="tbx04ReasonForDelay" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add reason" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
						<!--end::note-->
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn04SaveReasonForDelay" runat="server" class="btn btn-primary">Save</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->

		<!--begin::Modal Comment-->
		<asp:UpdatePanel ID="mdl05Comment" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
							<asp:TextBox ID="tbx05Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
							<asp:HiddenField ID="hdnMention" runat="server" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn05AddNote" runat="server" class="btn btn-primary lbtn05AddNote">Add</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->

	</div>
	<!--end::Content-->

	<!-- scripts related to this page -->
    <script type="text/javascript">
		
        //find buyer
        var input_buyer = document.getElementById("tbx01FindBuyer");
        input_buyer.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                FindBuyer(input_buyer.value);
            }
        });
        function FindBuyer(Find) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'FormCode': 'FRM000032',
                    'Type': 'Search Buyer',
                    'Find': Find
                },
                success: function (response) {
                    DisplayBuyer(response)
                },
            });
        };
        function DisplayBuyer(response) {
            var gv01FindBuyer = document.getElementById("gv01FindBuyer");

            //Remove all rows.
            var rowCount = gv01FindBuyer.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                gv01FindBuyer.deleteRow(i);
            }

            //Add the data rows.
            for (var i = 0; i < response.length; i++) {
                row = gv01FindBuyer.insertRow(-1);

                var cell = row.insertCell(-1);
                cell.innerHTML = response[i].Bullet;
                cell.setAttribute("class", "mw-5px min-w-5px");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Data;
                cell.setAttribute("class", "w-100");
            }
        };
        function SelectBuyer(AcctNo) {
            $.ajax({
                type: "POST",
                url: "HNDAAD.ashx",
                data: {
                    'FormCode': 'FRM000032',
                    'Type': 'Select Buyer',
                    'AcctNo': AcctNo
                },
                success: function (response) {
                    var tbx01AcctNo = document.getElementById("ContentPlaceHolder1_tbx01AcctNo");
                    var tbx01AcctName = document.getElementById("ContentPlaceHolder1_tbx01AcctName");
                    var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
                    var tbx01TCTNo = document.getElementById("ContentPlaceHolder1_tbx01TCTNo");
                    var tbx01TCPAmt = document.getElementById("ContentPlaceHolder1_tbx01TCPAmt");
                    var tbx01TCPDatePaid = document.getElementById("ContentPlaceHolder1_tbx01TCPDatePaid");
                    var tbx01PFFullPmt = document.getElementById("ContentPlaceHolder1_tbx01PFFullPmt");
                    var tbx01PFFullDatePaid = document.getElementById("ContentPlaceHolder1_tbx01PFFullDatePaid");
                    var tbx01PFFullORNo = document.getElementById("ContentPlaceHolder1_tbx01PFFullORNo");
                    tbx01AcctNo.value = response[0].AcctNo;
                    tbx01AcctName.value = response[0].AcctName;
                    tbx01Project.value = response[0].Project;
                    tbx01TCTNo.value = response[0].TCTNo;
                    tbx01TCPAmt.value = response[0].TCPNet;
                    tbx01TCPDatePaid.value = (response[0].TCPDatePaid === null || response[0].TCPDatePaid === "01/01/1900") ? "" : response[0].TCPDatePaid;
                    tbx01PFFullPmt.value = response[0].PF;
                    tbx01PFFullDatePaid.value = (response[0].PFDatePaid === null || response[0].PFDatePaid === "01/01/1900") ? "" : response[0].PFDatePaid;
                    tbx01PFFullORNo.value = response[0].PFORNo;
                    $('#mdl01FindBuyer').modal('hide');
                },
            });
        };
		//find buyer

		//checkbox
		function cb012ID(ID) {
            var cb012ID = document.getElementById(ID);
			if (cb012ID.checked == false) {
				var tbx01ID1 = document.getElementById("ContentPlaceHolder1_tbx01ID1");
				tbx01ID1.readOnly = true;
				tbx01ID1.value = "";
				var tbx01ID2 = document.getElementById("ContentPlaceHolder1_tbx01ID2");
				tbx01ID2.readOnly = true;
				tbx01ID2.value = "";
				var tbx01SID1 = document.getElementById("ContentPlaceHolder1_tbx01SID1");
				tbx01SID1.readOnly = true;
				tbx01SID1.value = "";
				var tbx01SID2 = document.getElementById("ContentPlaceHolder1_tbx01SID2");
				tbx01SID2.readOnly = true;
				tbx01SID2.value = "";
			} else {
                var tbx01ID1 = document.getElementById("ContentPlaceHolder1_tbx01ID1");
                tbx01ID1.readOnly = false;
				tbx01ID1.value = "";
                var tbx01ID2 = document.getElementById("ContentPlaceHolder1_tbx01ID2");
                tbx01ID2.readOnly = false;
				tbx01ID2.value = "";
                var tbx01SID1 = document.getElementById("ContentPlaceHolder1_tbx01SID1");
                tbx01SID1.readOnly = false;
                tbx01SID1.value = "";
                var tbx01SID2 = document.getElementById("ContentPlaceHolder1_tbx01SID2");
                tbx01SID2.readOnly = false;
                tbx01SID2.value = "";
			}
		}
        function cb01TIN(ID) {
            var cb01TIN = document.getElementById(ID);
            if (cb01TIN.checked == false) {
                var tbx01TINSingle = document.getElementById("ContentPlaceHolder1_tbx01TINSingle");
                tbx01TINSingle.readOnly = true;
                tbx01TINSingle.value = "";
                var tbx01TINSpouse = document.getElementById("ContentPlaceHolder1_tbx01TINSpouse");
                tbx01TINSpouse.readOnly = true;
                tbx01TINSpouse.value = "";
            } else {
                var tbx01TINSingle = document.getElementById("ContentPlaceHolder1_tbx01TINSingle");
                tbx01TINSingle.readOnly = false;
                tbx01TINSingle.value = "";
                var tbx01TINSpouse = document.getElementById("ContentPlaceHolder1_tbx01TINSpouse");
                tbx01TINSpouse.readOnly = false;
                tbx01TINSpouse.value = "";
            }
		}
        function cb01ADD(ID) {
            var cb01ADD = document.getElementById(ID);
            if (cb01ADD.checked == false) {
                var tbx01DTL = document.getElementById("ContentPlaceHolder1_tbx01DTL");
                tbx01DTL.readOnly = true;
                tbx01DTL.value = "";
            } else {
                var tbx01DTL = document.getElementById("ContentPlaceHolder1_tbx01DTL");
                tbx01DTL.readOnly = false;
                tbx01DTL.value = "";
            }
		}
        function cb062ID(ID) {
            var cb062ID = document.getElementById(ID);
            if (cb062ID.checked == false) {
                var tbx06ID1 = document.getElementById("ContentPlaceHolder1_tbx06ID1");
                tbx06ID1.readOnly = true;
                tbx06ID1.value = "";
                var tbx06ID2 = document.getElementById("ContentPlaceHolder1_tbx06ID2");
                tbx06ID2.readOnly = true;
                tbx06ID2.value = "";
                var tbx06SID1 = document.getElementById("ContentPlaceHolder1_tbx06SID1");
                tbx06SID1.readOnly = true;
                tbx06SID1.value = "";
                var tbx06SID2 = document.getElementById("ContentPlaceHolder1_tbx06SID2");
                tbx06SID2.readOnly = true;
                tbx06SID2.value = "";
            } else {
                var tbx06ID1 = document.getElementById("ContentPlaceHolder1_tbx06ID1");
                tbx06ID1.readOnly = false;
                tbx06ID1.value = "";
                var tbx06ID2 = document.getElementById("ContentPlaceHolder1_tbx06ID2");
                tbx06ID2.readOnly = false;
                tbx06ID2.value = "";
                var tbx06SID1 = document.getElementById("ContentPlaceHolder1_tbx06SID1");
                tbx06SID1.readOnly = false;
                tbx06SID1.value = "";
                var tbx06SID2 = document.getElementById("ContentPlaceHolder1_tbx06SID2");
                tbx06SID2.readOnly = false;
                tbx06SID2.value = "";
            }
        }
        function cb06TIN(ID) {
            var cb06TIN = document.getElementById(ID);
            if (cb06TIN.checked == false) {
                var tbx06TINSingle = document.getElementById("ContentPlaceHolder1_tbx06TINSingle");
                tbx06TINSingle.readOnly = true;
                tbx06TINSingle.value = "";
                var tbx06TINSpouse = document.getElementById("ContentPlaceHolder1_tbx06TINSpouse");
                tbx06TINSpouse.readOnly = true;
                tbx06TINSpouse.value = "";
            } else {
                var tbx06TINSingle = document.getElementById("ContentPlaceHolder1_tbx06TINSingle");
                tbx06TINSingle.readOnly = false;
                tbx06TINSingle.value = "";
                var tbx06TINSpouse = document.getElementById("ContentPlaceHolder1_tbx06TINSpouse");
                tbx06TINSpouse.readOnly = false;
                tbx06TINSpouse.value = "";
            }
        }
        function cb06ADD(ID) {
            var cb06ADD = document.getElementById(ID);
            if (cb06ADD.checked == false) {
                var tbx06DTL = document.getElementById("ContentPlaceHolder1_tbx06DTL");
                tbx06DTL.readOnly = true;
                tbx06DTL.value = "";
            } else {
                var tbx06DTL = document.getElementById("ContentPlaceHolder1_tbx06DTL");
                tbx06DTL.readOnly = false;
                tbx06DTL.value = "";
            }
        }
		//checkbox

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $gv01Find = $('#ContentPlaceHolder1_gv01Find tbody tr');
            $('#tbx01Find').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gv01Find.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
        }
        //table search

        //numeric formating
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
        //numeric formating

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //form variable
                var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
				var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
                var ltrlMode = '<asp:Literal ID="ltrlMode" runat="server" />';
                var ltrlSeqNo = '<asp:Literal ID="ltrlSeqNo" runat="server" />';
                //form variable

                //metion                jq.fn.atwho.debug = true;
                var chatHub = jq.connection.chatHub;
                jq.connection.hub.start().done(function () {
                    // mention load
                    loadFunction()
                    //// mention save
                    //jq('.lbtn05AddNote').click(function () {
                    //    // Call the Send method on the hub.
                    //    chatHub.server.send(ltrlFormCode, ltrlID, ltrlFormCode, initialMention.join(','), ltrlCreatedBy);
                    //    // clear
                    //    initialMention = [];
                    //    mentionUser = [];
                    //})
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
                                    $('#<%=hdnMention.ClientID %>').val(initialMention.join(','));
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
                    url: "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + ltrlID.replace("#", "No"),
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
                        console.log("Successfully uploaded :" + imgName);
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                $('#lbtn02SaveUpload').on('click', function (e) {
                    var lbl01ID = document.getElementById("ContentPlaceHolder1_lbl01ID");
                    myDropzone.options.url = "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + lbl01ID.innerText.replace("#", "No");
                    myDropzone.processQueue();
                    // Perform button
                    var Btn = document.getElementById('lbtn02SaveUpload');
                    // Disable button to avoid multiple click
                    Btn.disabled = true;
                    // Show loading indication
                    // Simulate form submission
                    setTimeout(function () {
                        // Perform button
                        var clickButton = document.getElementById("<%= lbtn02UploadSave.ClientID %>");
                        clickButton.click();
                        // Enable button
                        Btn.disabled = false;
                    }, 3000);
                });
                //upload
            });
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
