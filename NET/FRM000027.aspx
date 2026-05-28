<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000027.aspx.vb" Inherits="NET.FRM000027" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item"><a href="FRM010000" class="text-white">Form</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">TCT Clearance</li>
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
			<!--begin::title-->
			<asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional" class="card-header pt-5 border-bottom-0">
			<ContentTemplate>
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
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
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--begin::title-->
			<div class="card-body pt-3 pb-0">
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
									<asp:LinkButton ID="lbtn01Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-plus fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Delete" runat="server" ToolTip="Delete record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-trash fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Edit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Print" runat="server" ToolTip="Print" class="btn btn-sm btn-icon btn-secondary align-self-center m-1"><i class="las la-print fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Status" runat="server" ToolTip="Change Status" class="btn btn-sm btn-icon btn-secondary align-self-center m-1">Change Status</asp:LinkButton>
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
										<asp:TextBox ID="tbx01FormType" runat="server" class="form-control" ReadOnly="true">TCT Clearance</asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<asp:TextBox ID="tbx01DateRequested" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Date Required</span>
										<input id="tbx01DateRequired" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly="" placeholder="Pick a date" />
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
									<div class="card-title fs-5 fw-bolder">Details</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Category</span>
										<asp:DropDownList ID="ddl01Category" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddl01Category(this);">
											<asp:ListItem Value="">Select category</asp:ListItem>
											<asp:ListItem Value="Rawland">Rawland</asp:ListItem>
										</asp:DropDownList>
									</div>
									
									<div id="pnl01TitleNo" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Title No.</span>
										<asp:TextBox ID="tbx01TitleNo" runat="server" class="form-control" placeholder="Title No."></asp:TextBox>
									</div>
									<div id="pnl01LotNo" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Lot No.</span>
										<asp:TextBox ID="tbx01LotNo" runat="server" class="form-control" placeholder="Lot No."></asp:TextBox>
									</div>
									<div id="pnl01Area" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Area</span>
										<input id="tbx01Area" runat="server" class="form-control" onblur="FormatNumeric(this.id)" placeholder="0.00" />
									</div>
									<div id="pnl01Buyer" runat="server" class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Buyer</span>
										<input id="tbx01AcctNo" runat="server" type="text" class="form-control mw-150px min-w-150px" ReadOnly="readonly" placeholder="Account No." />
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01AcctName" runat="server" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Account Name" />
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
									<div id="pnl01Project" runat="server" class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Project</span>
										<input id="tbx01Project" runat="server" type="text" class="form-control" ReadOnly="readonly" placeholder="Project" />
										<asp:HiddenField ID="hf01LotCode" runat="server" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">New TCT No. T-</span>
										<asp:TextBox ID="tbx01TCTNo" runat="server" class="form-control" placeholder="add tct no."></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Check List</div>
									<div class="row border border-radius-047rem pt-3 m-05 m-05">
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101OCOT" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101OCOT">
													Owner's Copy of Title
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101TD" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101TD">
													Tax Declaration
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101DOAS" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101DOAS">
													Deed of Absolute Sale
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101DOR" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101DOR">
													Deed of Restriction
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101LM" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101LM">
													Location Map
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101LMA" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101LMA">
													Loan Mortgage Agreement
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101PN" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101PN">
													Promissory Note
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101DOA" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101DOA">
													Deed of Assignment
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101RPTR" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101RPTR">
													Real Property Tax Receipt
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101TIN" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101TIN">
													TIN - 1994
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input" type="checkbox" value="" id="cb0101CAR" runat="server"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0101CAR">
													Certificate of Registration
												</label>
											</div>
										</div>
									</div>
									<div class="card-title fs-5 fw-bolder">Processed By</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">RS#</span>
										<asp:TextBox ID="tbx01RSNo" runat="server" class="form-control" placeholder="Add rs#"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:TextBox ID="tbx01Remarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Verified By (FIN/AAD)</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:TextBox ID="tbx01FINRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">PMG/HOA Clearance</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:TextBox ID="tbx01PMGRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Audited By (AUD)</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:TextBox ID="tbx01AUDRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Released By (Custodian)</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:TextBox ID="tbx01CUSRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
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
									<div class="card-title fs-5 fw-bolder">Details</div>
									<div id="pnl02Buyer" runat="server" class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Buyer</span>
										<asp:Label ID="lbl01AcctNo" runat="server" class="form-control mw-150px min-w-150px">-</asp:Label>
										<asp:Label ID="lbl01AcctName" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Project</span>
										<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
									</div>
									<div id="pnl02TitleNo" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px">Title No.</span>
										<asp:Label ID="lbl01TitleNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div id="pnl02LotNo" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px">Lot No.</span>
										<asp:Label ID="lbl01LotNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div id="pnl02Area" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px">Area</span>
										<asp:Label ID="lbl01Area" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">New TCT No. T-</span>
										<asp:Label ID="lbl01TCTNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Check List</div>
									<div class="row border border-radius-047rem pt-3 m-05 m-05">
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102OCOT" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102OCOT">
													Owner's Copy of Title
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102TD" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102TD">
													Tax Declaration
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102DOAS" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102DOAS">
													Deed of Absolute Sale
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102DOR" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102DOR">
													Deed of Restriction
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102LM" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102LM">
													Location Map
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102LMA" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102LMA">
													Loan Mortgage Agreement
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102PN" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102PN">
													Promissory Note
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102DOA" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102DOA">
													Deed of Assignment
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102RPTR" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102RPTR">
													Real Property Tax Receipt
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102TIN" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102TIN">
													TIN - 1994
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb0102CAR" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb0102CAR">
													Certificate of Registration
												</label>
											</div>
										</div>
									</div>
									<div class="card-title fs-5 fw-bolder">Processed By</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">RS#</span>
										<asp:Label ID="lbl01RSNo" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lbl01Remarks" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Verified By (FIN/AAD)</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lbl01FINRemarks" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">PMG/HOA Clearance</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lbl01PMGRemarks" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Audited By (AUD)</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lbl01AUDRemarks" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Released By (Custodian)</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Remarks</span>
										<asp:Label ID="lbl01CUSRemarks" runat="server" class="form-control">-</asp:Label>
									</div>
								</asp:Panel>
								<!--end::Dtl-->
							</div>
						</ContentTemplate>
						</asp:UpdatePanel>
						<!--end::Menu Content-->

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
							<asp:DropDownList ID="ddl01Status" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border" AutoPostBack="true">
								<asp:ListItem Value="">Select a category</asp:ListItem>
							</asp:DropDownList>
						</div>
						<asp:Panel ID="pnl01ClarifyTo" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px required">Clarify to</span>
							<asp:DropDownList ID="ddl01ClarifyTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border">
								<asp:ListItem Value="">Select a category</asp:ListItem>
							</asp:DropDownList>
						</asp:Panel>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
							<asp:TextBox ID="tbx01Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
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
						<div class="card-title fs-5 fw-bolder">Check List</div>
							<div class="row border border-radius-047rem pt-3 m-05 m-05">
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06OCOT" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06OCOT">
											Owner's Copy of Title
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06TD" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06TD">
											Tax Declaration
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06DOAS" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06DOAS">
											Deed of Absolute Sale
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06DOR" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06DOR">
											Deed of Restriction
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06LM" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06LM">
											Location Map
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06LMA" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06LMA">
											Loan Mortgage Agreement
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06PN" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06PN">
											Promissory Note
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06DOA" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06DOA">
											Deed of Assignment
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06RPTR" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06RPTR">
											Real Property Tax Receipt
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06TIN" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06TIN">
											TIN - 1994
										</label>
									</div>
								</div>
								<div class="col-lg-6 col-sm-12">
									<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
										<input class="form-check-input" type="checkbox" value="" id="cb06CAR" runat="server"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cb06CAR">
											Certificate of Registration
										</label>
									</div>
								</div>
							</div>
							<div class="card-title fs-5 fw-bolder">Processed By</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">RS#</span>
								<asp:TextBox ID="tbx06RSNo" runat="server" class="form-control" placeholder="Add rs#"></asp:TextBox>
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:TextBox ID="tbx06Remarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="card-title fs-5 fw-bolder">Verified By (FIN/AAD)</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:TextBox ID="tbx06FINRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="card-title fs-5 fw-bolder">PMG/HOA Clearance</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:TextBox ID="tbx06PMGRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="card-title fs-5 fw-bolder">Audited By (AUD)</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:TextBox ID="tbx06AUDRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
							</div>
							<div class="card-title fs-5 fw-bolder">Released By (Custodian)</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Remarks</span>
								<asp:TextBox ID="tbx06CUSRemarks" runat="server" class="form-control" placeholder="Add remarks"></asp:TextBox>
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
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000027',
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
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000027',
                    'Type': 'Select Buyer',
                    'AcctNo': AcctNo
                },
                success: function (response) {
                    var tbx01AcctNo = document.getElementById("ContentPlaceHolder1_tbx01AcctNo");
                    var tbx01AcctName = document.getElementById("ContentPlaceHolder1_tbx01AcctName");
                    var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
                    var hf01LotCode = document.getElementById("ContentPlaceHolder1_hf01LotCode");
                    tbx01AcctNo.value = response[0].AcctNo;
                    tbx01AcctName.value = response[0].AcctName;
                    tbx01Project.value = response[0].Project;
                    hf01LotCode.value = response[0].LotCode;
                    $('#mdl01FindBuyer').modal('hide');
                },
            });
		};
		function ddl01Category(selectObj) {
            var selectIndex = selectObj.selectedIndex;
			var selectValue = selectObj.options[selectIndex].value;
			var pnl01TitleNo = document.getElementById("ContentPlaceHolder1_pnl01TitleNo");
			var pnl01LotNo = document.getElementById("ContentPlaceHolder1_pnl01LotNo");
			var pnl01Area = document.getElementById("ContentPlaceHolder1_pnl01Area");
			var pnl01Buyer = document.getElementById("ContentPlaceHolder1_pnl01Buyer");
			var pnl01Project = document.getElementById("ContentPlaceHolder1_pnl01Project");
			if (selectValue === "Rawland") {
				pnl01TitleNo.style.display = "";
				pnl01LotNo.style.display = "";
				pnl01Area.style.display = "";
				pnl01Buyer.style.display = "none";
				pnl01Project.style.display = "none";
            } else {
                pnl01TitleNo.style.display = "none";
                pnl01LotNo.style.display = "none";
                pnl01Area.style.display = "none";
                pnl01Buyer.style.display = "";
                pnl01Project.style.display = "";
			};
		};
		//find buyer


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

        //numeric formatting
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
        //numeric formatting

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
                        setTimeout(function () {
                            $('#ContentPlaceHolder1_mdl02Upload').modal('hide');
                            myDropzone.removeAllFiles(true);
                        }, 3000);
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
