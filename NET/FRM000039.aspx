<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000039.aspx.vb" Inherits="NET.FRM000039" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Non Conformance Report</li>
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
							<img src="Assets/media/svg/apps/FRM000039.svg" alt="" />
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
						<asp:UpdatePanel ID="upnl01Overview" runat="server" UpdateMode="Conditional">
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
										<asp:TextBox ID="tbx01FormType" runat="server" class="form-control" ReadOnly="true">Notice of Delay</asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<asp:TextBox ID="tbx01DateRequested" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Date Required</span>
										<input id="tbx01DateRequired" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
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
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Project</span>
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01Project" runat="server" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Select project" />
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="FindProject()">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon-->
										</div>
										<asp:HiddenField ID="hf01Project" runat="server" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Contractor</span>
										<input ID="tbx01Contractor" runat="server" class="form-control" Placeholder="Contractor" readonly />
										<asp:HiddenField ID="hf01Contractor" runat="server" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Type of Work</span>
										<asp:TextBox ID="tbx01TypeWork" runat="server" class="form-control min-h-75px" Placeholder="Add type of work" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Work Activity</span>
										<asp:TextBox ID="tbx01WorkActivity" runat="server" class="form-control min-h-75px" Placeholder="Add work activity" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Area/Structure</span>
										<asp:TextBox ID="tbx01AreaStructure" runat="server" class="form-control min-h-75px" Placeholder="Add area/structure" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Gridline/Location <br /> Level/Chainage</span>
										<asp:TextBox ID="tbx01Location" runat="server" class="form-control min-h-75px" Placeholder="Add chainage" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Non-Conformance <br /> Details</span>
										<asp:TextBox ID="tbx01NonConformance" runat="server" class="form-control min-h-75px" Placeholder="Add non-conformance" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Rem./Corrective<br /> Action Details</span>
										<asp:TextBox ID="tbx01CorrectiveDetails" runat="server" class="form-control min-h-75px" Placeholder="Add non-conformance" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Remedial/Corrective Action</div>
									<div class="row border border-radius-047rem pt-3 m-05">
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input chkBox" type="checkbox" value="" id="cb01CA001001" runat="server" onclick="selectAction(this);"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001001">
													REJECT/REPLACE
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input chkBox" type="checkbox" value="" id="cb01CA001002" runat="server" onclick="selectAction(this);"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001002">
													REPAIR
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input chkBox" type="checkbox" value="" id="cb01CA001003" runat="server" onclick="selectAction(this);"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001003">
													RE-WORK
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input chkBox" type="checkbox" value="" id="cb01CA001004" runat="server" onclick="selectAction(this);"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001004">
													USE AS-IS
												</label>
											</div>
										</div>
									</div>
									<div class="input-group input-group-sm mt-4 mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Root Cause</span>
										<asp:TextBox ID="tbx01RootCause" runat="server" class="form-control min-h-75px" Placeholder="Add root cause" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Risk and <br /> Opportunity</span>
										<asp:TextBox ID="tbx01Opportunity" runat="server" class="form-control min-h-75px" Placeholder="Add risk and opportunity" TextMode="MultiLine"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Cost Implications</div>
									<div class="row border border-radius-047rem pt-3 m-05">
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input impBox" type="checkbox" value="" id="cb01CI001001" runat="server" onclick="selectImplication(this);"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CI001001">
													Yes
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input impBox" type="checkbox" value="" id="cb01CI001002" runat="server" onclick="selectImplication(this);"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CI001002">
													No
												</label>
											</div>
										</div>
									</div>
									<div id="div01WorkOrder" runat="server" class="input-group input-group-sm mb-2 mt-4" style="display: none;">
										<span class="input-group-text input-group-text-top min-w-150px required">Work Order No.</span>
										<asp:TextBox ID="tbx01WorkOrder" runat="server" class="form-control" Placeholder="Add work order no."></asp:TextBox>
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
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Assign Project</span>
										<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Contractor</span>
										<asp:Label ID="lbl01Contractor" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Type of Work</span>
										<asp:Label ID="lbl01TypeWork" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Work Activity</span>
										<asp:Label ID="lbl01WorkActivity" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Area/Structure</span>
										<asp:Label ID="lbl01AreaStructure" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Gridline/Location <br /> Level/Chainage</span>
										<asp:Label ID="lbl01Location" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Non-Conformance <br /> Details</span>
										<asp:Label ID="lbl01NonConformance" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Rem./Conformance <br />Action Details </span>
										<asp:Label ID="lbl01CorrectiveDetails" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true">-</asp:Label>
									</div>
									<div class="card-title fs-5 fw-bolder">Remedial/Corrective Action</div>
									<div class="row border border-radius-047rem pt-3 m-05">
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb01CA001001_" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001001_">
													REJECT/REPLACE
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb01CA001002_" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001002_">
													REPAIR
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb01CA001003_" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001003_">
													RE-WORK
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb01CA001004_" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA001004_">
													USE AS-IS
												</label>
											</div>
										</div>
									</div>
									<div class="input-group input-group-sm mb-2 mt-4">
										<span class="input-group-text input-group-text-top min-w-150px">Root Cause</span>
										<asp:TextBox ID="lbl01RootCause" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Risk and <br /> Opportunity</span>
										<asp:TextBox ID="lbl01Opportunity" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="card-title fs-5 fw-bolder">Cost Implication</div>
									<div class="row border border-radius-047rem pt-3 m-05 ">
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb01CI002001" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CA002001_">
													Yes
												</label>
											</div>
										</div>
										<div class="col-lg-3 col-md-4 col-sm-12">
											<div class="form-check form-check-custom form-check-solid form-check-sm mb-4">
												<input class="form-check-input disable-check" type="checkbox" value="" id="cb01CI002002" runat="server" onclick="return false;"/>
												<label class="form-check-label" for="ContentPlaceHolder1_cb01CI002002_">
													No
												</label>
											</div>
										</div>
									</div>
									<div id="div02WorkOrder" runat="server" class="input-group input-group-sm mb-2 mt-4" style="display: none;">
										<span class="input-group-text input-group-text-top min-w-150px">Work Order No.</span>
										<asp:TextBox ID="lbl01WorkOrder" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
								</asp:Panel>
								<!--end::Dtl-->
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

		<!--begin::Modal Find Project -->
		<div id="mdl01FindProject" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen" >
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
                                <input id="tbx01FindProject" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						    <!--begin::list-->
                            <table id="gv01FindProject" class="table table-no-border table-row-bordered table-hover align-middle w-100">
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
		<!--begin::Modal Find Project -->

		<!--begin::Modal Find-->
		<asp:UpdatePanel ID="mdl01Find" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Find record</h5>
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
								<input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
						<!--begin::gridview-->
						<div class="table-responsive">
							<asp:GridView ID="gv01Find" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" >
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-margin bullet-vertical h-40px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="ID">
										<ItemTemplate>
											<a href='<%# Eval("Link") %>' class="pointer">
												<%# Eval("ID") %>
											</a>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px mw-100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Status">
										<ItemTemplate>
											<%# Eval("Status") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px mw-100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Requested By">
										<ItemTemplate>
											<span class="nowrap-200px"><%# Eval("RequestedBy") %></span> 
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px mw-200px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Assigned To">
										<ItemTemplate>
											<span class="nowrap-200px"><%# Eval("AssignedTo") %></span> 
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px mw-200px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Description">
										<ItemTemplate>
											<span class="nowrap-500px"><%# Eval("Description") %></span> 
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-500px w-100" />
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>
						<!--end::gridview-->
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
    //search Project
    function FindProject() {
        $.ajax({
            type: "POST",
            url: "HND000003.ashx",
            data: {
                'FormCode': 'FRM000038',
                'Type': 'Search Project'
            },
            success: function (response) {
                $('#mdl01FindProject').modal('show');
                DisplayProject(response)
            },
        });
    };
    function DisplayProject(response) {
        var gv01FindProject = document.getElementById("gv01FindProject");

        //Remove all rows.
        var rowCount = gv01FindProject.rows.length;
        for (var i = rowCount - 1; i > 0; i--) {
            gv01FindProject.deleteRow(i);
        }

        //Add the data rows.
        for (var i = 0; i < response.length; i++) {
            row = gv01FindProject.insertRow(-1);

            var cell = row.insertCell(-1);
            cell.innerHTML = response[i].Bullet;
            cell.setAttribute("class", "mw-5px min-w-5px");

            cell = row.insertCell(-1);
            cell.innerHTML = response[i].Data;
            cell.setAttribute("class", "w-100");
        }
    };
    function SelectProject(Code) {
        $.ajax({
            type: "POST",
            url: "HND000003.ashx",
            data: {
                'FormCode': 'FRM000038',
                'Type': 'Select Project',
                'Code': Code
            },
            success: function (response) {
                var hf01Project = document.getElementById("ContentPlaceHolder1_hf01Project");
                var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
                var hf01Contractor = document.getElementById("ContentPlaceHolder1_hf01Contractor");
                var tbx01Contractor = document.getElementById("ContentPlaceHolder1_tbx01Contractor");
                hf01Project.value = response[0].Code;
                tbx01Project.value = response[0].Description;
                hf01Contractor.value = response[0].ConCode;
                tbx01Contractor.value = response[0].ConName;
                $('#mdl01FindProject').modal('hide');
            },
        });
    };
    //search buyer

    //fix for fixed column header
    $(function () {
        $('#ContentPlaceHolder1_mdl01Find').on('shown.bs.modal', function () {
            //datatable
            var gv01Find = $("#ContentPlaceHolder1_gv01Find").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
                scrollY: '77vh',
                fixedColumns: { left: 2 },
                select: true
            });
            //datatable

            //search
            $('#tbx01Find').on('keyup', function () {
                gv01Find.search(this.value).draw();
            });
            //search
        });
    });
	//fix for fixed column header

	//checkbox
	function selectAction(Obj) {
		var checkBox = document.querySelectorAll(".chkBox");
        Array.prototype.forEach.call(checkBox, function (el) {
            el.checked = false;
        });
        Obj.checked = true;
	};
	function selectImplication(Obj) {
		var checkBox = document.querySelectorAll(".impBox");
		var div01WorkOrder = document.getElementById("ContentPlaceHolder1_div01WorkOrder");
        Array.prototype.forEach.call(checkBox, function (el) {
            el.checked = false;
        });
		Obj.checked = true; 
		if (Obj.id == "ContentPlaceHolder1_cb01CI001001" && Obj.checked) {
            div01WorkOrder.style.display = "";
		} else {
            div01WorkOrder.style.display = "none";
		};
	};
	//checkbox

	//onchange - dropdown
	function ddl01Reason(selectObj) {
        var selectIndex = selectObj.selectedIndex;
		var selectValue = selectObj.options[selectIndex].value;
		var div01OtherReason = document.getElementById("ContentPlaceHolder1_div01OtherReason");
		if (selectValue == "Others") {
			div01OtherReason.style.display = "";
		} else {
			div01OtherReason.style.display = "none";
		};
	};
	//onchange - dropdown

    //numeric formating
    function FormatNumeric(ID) {
        var NumVal = document.getElementById(ID);
        var Val = parseFloat(NumVal.value);
        var NewVal = Val.toFixed(2);
        var Parts = NewVal.toString().split(".");
        var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
        if (Num == "NaN") {
            Num = "0.00";
        }
        NumVal.value = Num;
	}
	function FormatEWT(ID) {
		var tbx01GrossAmt = document.getElementById("ContentPlaceHolder1_tbx01GrossAmt");
		var tbx01NetAmt = document.getElementById("ContentPlaceHolder1_tbx01NetAmt");
        var NumVal = document.getElementById(ID);
        var Val = parseFloat(NumVal.value);
        var NewVal = Val.toFixed(2);
        var Parts = NewVal.toString().split(".");
        var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
        if (Num == "NaN") {
            Num = "0.00";
		}
		if (tbx01GrossAmt.value == "0.00" || tbx01GrossAmt.value == "") {
			tbx01NetAmt.value = "0.00";
		} else {
			var NetVal = parseFloat(tbx01GrossAmt.value.replace(/,/g, "") - Num);
			var NewNet = NetVal.toFixed(2);
            var NetParts = NewNet.toString().split(".");
            var TotalNet = NetParts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (NetParts[1] ? "." + NetParts[1] : "");
            tbx01NetAmt.value = TotalNet;
		}
        NumVal.value = Num;
	};
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
            var ltrlDtlMode = '<asp:Literal ID="ltrlDtlMode" runat="server" />';
            var ltrlSeqNo = '<asp:Literal ID="ltrlSeqNo" runat="server" />';
            //form variable

			//check box
            $(".cbx0101IsDeposit").change(function () {
                var tbx01BankName = document.getElementById("ContentPlaceHolder1_tbx01BankName");
                var tbx01AcctName = document.getElementById("ContentPlaceHolder1_tbx01AcctName");
                var tbx01AcctNo = document.getElementById("ContentPlaceHolder1_tbx01AcctNo");
                if ($('.cbx0101IsDeposit:checked').length > 0) {
                    tbx01BankName.readOnly = false;
                    tbx01AcctName.readOnly = false;
                    tbx01AcctNo.readOnly = false;
                } else {
                    tbx01BankName.readOnly = true;
                    tbx01BankName.value = "-";
                    tbx01AcctName.readOnly = true;
                    tbx01AcctName.value = "-";
                    tbx01AcctNo.readOnly = true;
                    tbx01AcctNo.value = "-";
                }
			});
            $(".cbx0101WithEWT").change(function () {
                var tbx01GrossAmt = document.getElementById("ContentPlaceHolder1_tbx01GrossAmt");
                var tbx01EWT = document.getElementById("ContentPlaceHolder1_tbx01EWT");
                var tbx01NetAmt = document.getElementById("ContentPlaceHolder1_tbx01NetAmt");
				if ($('.cbx0101WithEWT:checked').length > 0) {
					tbx01GrossAmt.readOnly = true;
                    tbx01EWT.readOnly = false;
                    tbx01NetAmt.readOnly = true;
				} else {
					tbx01GrossAmt.readOnly = true;
					tbx01EWT.readOnly = true;
					tbx01EWT.value = "0.00";
					tbx01NetAmt.readOnly = true;
                }
			});
			//check box

            //metion            jq.fn.atwho.debug = true;
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
            };            //metion

            //combobox
            $('[data-kt-repeater="select2"]').select2();
            //combobox

            //date
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y"
            });
            //date

            //datatable
            var gv01Find = $("#ContentPlaceHolder1_gv01Find").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
                scrollY: '77vh',
                fixedColumns: { left: 2 },
                select: true
            });
            //datatable

            //search
            $('#tbx01Find').on('keyup', function () {
                gv01Find.search(this.value).draw();
            });
            //search

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
