<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000010.aspx.vb" Inherits="NET.FRM000010" MaintainScrollPositionOnPostback = "true" EnableEventValidation="false" %>
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
						<li class="breadcrumb-item text-white">Purchase Request</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtn02UploadSave" runat="server" Text="Button" OnClick="lbtn02UploadSave_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btn06PRDtlAdd_OSM" runat="server" Text="Button" OnClick="btn06PRDtlAdd_OSM_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btn06PRDtlAdd_SCM" runat="server" Text="Button" OnClick="btn06PRDtlAdd_SCM_Click" ClientIDMode="Static" style="display:none;" />
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
						<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
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
								<a class="nav-link text-active-primary" title="Subscribers" data-bs-toggle="tab" href="#Menu03_TabContent"><%--<i class="las la-user-friends fs-3x"></i>--%></a>
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
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex">
									<asp:LinkButton ID="lbtn01Find" runat="server" ToolTip="Find record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-search fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Refresh" runat="server" ToolTip="Refresh record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-redo-alt fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-plus fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Delete" runat="server" ToolTip="Delete record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-trash fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Edit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Print" runat="server" ToolTip="Print" class="btn btn-sm btn-icon btn-secondary align-self-center m-1"><i class="las la-print fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Status" runat="server" class="btn btn-sm btn-secondary align-self-center m-1">Change Status</asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
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
										<asp:TextBox ID="tbx01FormType" runat="server" class="form-control" ReadOnly="true">Purchase Request</asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<asp:TextBox ID="tbx01DateRequested" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Date Required</span>
										<asp:TextBox ID="tbx01DateRequired" runat="server" data-kt-repeater="datepicker" class="form-control"></asp:TextBox>
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
									<!--begin::separator-->
									<div class="separator separator-dashed my-6"></div>
									<!--end::separator-->
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Purchase Type</span>
										<asp:DropDownList ID="ddl01PurchaseType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
											<asp:ListItem Value="">Select type</asp:ListItem>
											<asp:ListItem Value="Cash Advance">Cash Advance</asp:ListItem>
											<asp:ListItem Value="Cash Reimbursement">Cash Reimbursement</asp:ListItem>
											<asp:ListItem Value="Credit Purchase">Credit Purchase</asp:ListItem>
											<asp:ListItem Value="Department Petty Cash Fund">Department Petty Cash Fund</asp:ListItem>
											<asp:ListItem Value="Gate Pass">Gate Pass</asp:ListItem>
											<asp:ListItem Value="Return">Return</asp:ListItem>
											<asp:ListItem Value="Stock Request">Stock Request</asp:ListItem>
											<asp:ListItem Value="Transfer">Transfer</asp:ListItem>
										</asp:DropDownList>
										<asp:HiddenField ID="hf01PurchaseType" runat="server" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Project Type</span>
										<asp:DropDownList ID="ddl01OSMAType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
											<asp:ListItem Value="">Select project</asp:ListItem>
											<asp:ListItem Value="Non OSM Project">Non OSM Project</asp:ListItem>
											<asp:ListItem Value="OSM Project">OSM Project</asp:ListItem>
											<asp:ListItem Value="OSM Project (Advance PO)">OSM Project (Advance PO)</asp:ListItem>
											<asp:ListItem Value="OSM Project (Stock Request)">OSM Project (Stock Request)</asp:ListItem>
											<asp:ListItem Value="CCI Project (Advance PO)">CCI Project (Advance PO)</asp:ListItem>
											<asp:ListItem Value="CCI Project (Stock Request)">CCI Project (Stock Request)</asp:ListItem>
										</asp:DropDownList>
										<asp:HiddenField ID="hf01OSMType" runat="server" />
									</div>
									<div id="div01Department" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Department</span>
										<asp:DropDownList ID="ddl01Department" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
											<asp:ListItem Value="">Select department</asp:ListItem>
										</asp:DropDownList>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Purpose</span>
										<asp:DropDownList ID="ddl01Purpose" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
											<asp:ListItem>Select purpose</asp:ListItem>
										</asp:DropDownList>
										<asp:HiddenField ID="hf01Purpose" runat="server" />
									</div>
									<div id="div01ProjectCat" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Category</span>
										<asp:DropDownList ID="ddl01ProjectCat" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
											<asp:ListItem>Select Category</asp:ListItem>
										</asp:DropDownList>
									</div>
									<div id="div01DateReturn" runat="server" class="input-group input-group-sm mb-2" style="display:none">
										<span class="input-group-text min-w-150px required">Date Return</span>
										<input id="tbx01DateReturn" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
									</div>
									<div id="div01DateReIssue" runat="server" class="input-group input-group-sm mb-2" style="display:none">
										<span class="input-group-text min-w-150px required">Date Re-Issue</span>
										<input id="tbx01DateReIssue" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
									</div>
									<div id="div01Subdivision" runat="server" class="input-group input-group-sm mb-2" style="display:none">
										<span class="input-group-text min-w-150px required">Subdivision</span>
										<asp:DropDownList ID="ddl01Subdivision" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddl01Subdivision(this)">
											<asp:ListItem>Select subdivision</asp:ListItem>
										</asp:DropDownList>
									</div>
									<%--<div id="div01Estimate" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Estimate</span>
										<asp:DropDownList ID="ddl01Estimate" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
											<asp:ListItem Value="">Select Estimate</asp:ListItem>
										</asp:DropDownList>
									</div>--%>
									<div id="div02Estimate" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span id="spn02Estimate" runat="server" class="input-group-text min-w-150px required">Batch</span>
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01Estimate" runat="server" type="text" class="form-control form-control-sm border-0 m-0" readonly placeholder="Batch" />
											<asp:HiddenField ID="hf01Estimate" runat="server" />
											<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn01Estimate(); return false;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
										</div>
									</div>
									<div ID="div01WorkCode" runat="server" class="input-group input-group-sm mb-2" style="display:none">
										<span class="input-group-text min-w-150px required">Scope of WorkCode</span>
										<input id="tbx01WorkCode" runat="server" type="text" class="form-control" Placeholder="Add scope of workcode" />
									</div>
									<div id="div01Project" runat="server" class="input-group input-group-sm mb-2" style="display:none">
										<span class="input-group-text min-w-150px required">Project</span>
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01Project" runat="server" type="text" class="form-control form-control-sm border-0 m-0" readonly placeholder="Select project" />
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" data-bs-toggle="modal" data-bs-target="#mdl01FindProject">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon-->
										</div>
										<asp:HiddenField ID="hf01Subdivision" runat="server" />
										<asp:HiddenField ID="hf01Phase" runat="server" />
										<asp:HiddenField ID="hf01Block" runat="server" />
										<asp:HiddenField ID="hf01Lot" runat="server" />
									</div>
									<div ID="div01VehiclePlate" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Vehicle</span>
										<asp:DropDownList ID="ddl01VehiclePlate" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddl01VehiclePlate(this)">
											<asp:ListItem>Select vehicle</asp:ListItem>
										</asp:DropDownList>
										<asp:HiddenField ID="hf01Vehicle" runat="server" />
										<asp:HiddenField ID="hf01PlateNo" runat="server" />
									</div>
									<div id="div01Type" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Type</span>
										<asp:DropDownList ID="ddl01Type" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true" >
											<asp:ListItem>Select Type</asp:ListItem>
										</asp:DropDownList>
										<asp:HiddenField ID="hf01Type" runat="server" />
									</div>
									<div id="div0101Category" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<asp:Label ID="lbl0101TitleCategory" runat="server" class="input-group-text min-w-150px required">Category</asp:Label>
										<asp:DropDownList ID="ddl0101Category" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
											<asp:ListItem>Select Category</asp:ListItem>
										</asp:DropDownList>
										<asp:HiddenField ID="hf01Category" runat="server" />
									</div>
									<div id="div0102Category" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<asp:Label ID="lbl0102TitleCategory" runat="server" class="input-group-text min-w-150px required">Category</asp:Label>
										<input id="tbx0102Category" runat="server" type="text" class="form-control" Placeholder="Add category" />
									</div>
									<div id="div01ActName" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Activity</span>
										<input id="tbx01ActName" runat="server" type="text" class="form-control" Placeholder="Add activity" />
									</div>
									<div id="div01ActLocation" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Location</span>
										<input id="tbx01ActLocation" runat="server" type="text" class="form-control" Placeholder="Add location" />
									</div>
									<div id="div01ActDate" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Date</span>
										<input id="tbx01ActDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
									</div>
									<div id="div01ChargeTo" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Charge To</span>
										<input id="tbx01ChargeTo" runat="server" type="text" class="form-control" placeholder="Charge To" readonly="readonly" />
										<asp:HiddenField ID="hf01ChargeCode" runat="server" />
										<asp:HiddenField ID="hf01AcctCode" runat="server" />
										<asp:HiddenField ID="hf01Subsidiary" runat="server" />
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn01ChargeTo(); return false;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon-->
										</div>
									</div>
									<div id="div01Division" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px">Division</span>
										<input id="tbx01Division" runat="server" type="text" class="form-control" Placeholder="Division" readonly="readonly" />
										<asp:HiddenField ID="hf01Division" runat="server" />
									</div>
									<div id="div02Department" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px">Department</span>
										<input id="tbx01Department" runat="server" type="text" class="form-control" Placeholder="Department" readonly="readonly" />
										<asp:HiddenField ID="hf01Department" runat="server" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<asp:TextBox ID="tbx01Remarks" runat="server" class="form-control min-h-75px" Placeholder="Add remarks" TextMode="MultiLine"></asp:TextBox>
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
									<div class="separator separator-dashed my-6"></div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Purchase Type</span>
										<asp:Label ID="lbl01PurchaseType" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Project</span>
										<asp:Label ID="lbl01OSMType" runat="server" class="form-control">-</asp:Label>
									</div>
									<asp:Panel ID="pnl01Department" runat="server" class="input-group input-group-sm mb-2" Visibe="false">
										<span class="input-group-text min-w-150px">Department</span>
										<asp:Label ID="lbl01Department" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Purpose</span>
										<asp:Label ID="lbl01Purpose" runat="server" class="form-control">-</asp:Label>
									</div>
									<asp:Panel ID="pnl01ProjectCat" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Category</span>
										<asp:Label ID="lbl01ProjectCat" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01DateReturn" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Date Return</span>
										<asp:Label ID="lbl01DateReturn" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01DateIssue" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Date Re-Issue</span>
										<asp:Label ID="lbl01DateIssue" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Batch" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Batch</span>
										<asp:Label ID="lbl01Batch" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Subdivision" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Subdivision</span>
										<asp:Label ID="lbl01Subdivision" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Estimate" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span id="spn01Estimate" runat="server" class="input-group-text min-w-150px">Estimate</span>
										<asp:Label ID="lbl01Estimate" runat="server" class="form-control">-</asp:Label>
										<asp:HiddenField ID="hf02Estimate" runat="server" />
									</asp:Panel>
									<asp:Panel ID="pnl01WorkCode" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Scope of WorkCode</span>
										<asp:Label ID="lbl01WorkCode" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Project" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Project</span>
										<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01VehiclePlate" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Vehicle</span>
										<asp:Label ID="lbl01VehiclePlate" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Type" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Type</span>
										<asp:Label ID="lbl01Type" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Category" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<asp:Label ID="lbl01TitleCategory" runat="server" class="input-group-text min-w-150px">Category</asp:Label>
										<asp:Label ID="lbl01Category" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>	
									<asp:Panel ID="pnl01ActName" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Activity</span>
										<asp:Label ID="lbl01ActName" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01ActLocation" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Location</span>
										<asp:Label ID="lbl01ActLocation" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01ActDate" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Location</span>
										<asp:Label ID="lbl01ActDate" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01ChargeTo" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text input-group-text-top min-w-150px">Charge To</span>
										<asp:Label ID="lbl01ChargeTo" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Division" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text input-group-text-top min-w-150px">Division</span>
										<asp:Label ID="lbl01Division" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl02Department" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text input-group-text-top min-w-150px">Department</span>
										<asp:Label ID="lbl02Department" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
										<asp:TextBox ID="lbl01Remarks" runat="server" class="form-control min-h-75px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
									</div>
								</asp:Panel>
								<!--end::Dtl-->
							</div>
						</ContentTemplate>
						</asp:UpdatePanel>
						<asp:UpdatePanel ID="upnl06PRDtl" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Particulars</div>
								<!--end::Card header-->
								<input type="file" runat="server" id="fileOSM" clientidmode="Static" accept=".xls,.xlsx" style="display: none;"/>
								<input type="file" runat="server" id="fileSCM" clientidmode="Static" accept=".xls,.xlsx" style="display: none;"/>
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex justify-content-between">
										<asp:Button ID="btnBind" runat="server" Text="Button" OnClick="btnBind_Click" ClientIDMode="Static" style="display:none;"/>
										<asp:LinkButton ID="lbtn06PRDtlAdd" runat="server" ToolTip="Add Item" class="btn btn-sm btn-icon btn-primary align-self-center m-1 p-5"><i class="las la-plus fs-2"></i></asp:LinkButton>
										<!--begin::Menu-->
										<div id="div06PRDtlAdd_SCM" runat="server" title="(SCM - Estimate - Purchase Request)" class="menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-primary align-self-center m-1" data-kt-menu="true">
											<div data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" class="menu-item menu-lg-down-accordion">
												<span class="menu-link">
													<span class="menu-title text-white" id="mnuSCM" runat="server">SCM - Purchase Req.</span>
												</span>
												<div class="menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown menu-rounded-0 py-lg-4 w-lg-300px">
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn06PRDtlAdd_SCM();">
															<span class="menu-title">Add Item</span>
														</a>
													</div>
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn06PRDtlUpl_SCM();">
															<span class="menu-title">Upload Item</span>
														</a>
													</div>
												</div>
											</div>
										</div>
										<!--end::Menu-->
										<!--begin::Menu-->
										<div id="div06PRDtlAdd_OSM" runat="server" title="(OSM - Estimate - Stock Request)" class="menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-secondary align-self-center m-1" data-kt-menu="true">
											<div data-kt-menu-trigger="click" data-kt-menu-placement="bottom-start" class="menu-item menu-lg-down-accordion">
												<span class="menu-link">
													<span class="menu-title text-white" id="mnuOSM" runat="server">OSM - Stock Request</span>
												</span>
												<div class="menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown menu-rounded-0 py-lg-4 w-lg-300px">
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn06PRDtlAdd_OSM();">
															<span class="menu-title">Add Item</span>
														</a>
													</div>
													<div class="menu-item">
														<a class="menu-link py-3" onclick="btn06PRDtlUpl_OSM();">
															<span class="menu-title">Upload Item</span>
														</a>
													</div>
												</div>
											</div>
										</div>
										<!--end::Menu-->
								</div>
						</div>
						<!--end::Card header-->
						<div id="div06Body" runat="server" class="card-body" style="display: none;">
							<!--begin::ID-->
							<div class="table-responsive">
								<asp:GridView ID="gv06PRDtl" runat="server" class="table table-no-border table-row-bordered table-hover align-middle g-0" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Action">
										<ItemTemplate>
											<div class="d-flex align-items-center">
												<asp:LinkButton ID="lbtn06PRDtlDel" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("SeqNo") %>' ToolTip="Remove particular" OnClick="lbtn06PRDtlDel" ><i class="las la-trash fs-3"></i></asp:LinkButton>
												<asp:LinkButton ID="lbtn06PRDtlUpd" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("SeqNo") %>' ToolTip="Update particular" OnClick="lbtn06PRDtlUpd"><i class="las la-pencil-alt fs-3"></i></asp:LinkButton>
												<asp:LinkButton ID="lbtn06PRDtlTag" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("SeqNo") %>'  CommandName='<%# Bind("ItemNo") %>' ToolTip="Tag particular" OnClick="lbtn06PRDtlTag"><i class="las la-tag fs-3"></i></asp:LinkButton>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark text-center" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="OSM">
										<ItemTemplate>
											<asp:Label ID="lbl06OSM" runat="server" Text='<%# Eval("OSM") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Particular">
										<ItemTemplate>
											<asp:Label ID="lbl06Item" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Qty.">
										<ItemTemplate>
											<%# Eval("Qty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Unit">
										<ItemTemplate>
											<asp:Label ID="lbl06Unit" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Status">
										<ItemTemplate>
											<%# Eval("Status") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="For PO">
										<ItemTemplate>
											<%# Eval("POQty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText=" For SR">
										<ItemTemplate>
											<%# Eval("SRQty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Remarks">
										<ItemTemplate>
											<%# Eval("Remarks") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							<!--end::ID-->
						</div>
						<div id="div0601Body" runat="server" class="card-body" style="display: none;">
							<!--begin::ID-->
							<div class="table-responsive">
								<asp:GridView ID="gv0601PRDtl" runat="server" class="table table-no-border table-row-bordered table-hover align-middle g-0" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Action">
										<ItemTemplate>
											<div class="d-flex align-items-center">
												<asp:LinkButton ID="lbtn0601PRDtlDel" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("SeqNo") %>' ToolTip="Remove particular" OnClick="lbtn0601PRDtlDel" ><i class="las la-trash fs-3"></i></asp:LinkButton>
												<asp:LinkButton ID="lbtn0601PRDtlUpd" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("SeqNo") %>' ToolTip="Update particular" OnClick="lbtn0601PRDtlUpd"><i class="las la-pencil-alt fs-3"></i></asp:LinkButton>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark text-center" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="OSM">
										<ItemTemplate>
											<%# Eval("OSM") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Particular">
										<ItemTemplate>
											<asp:Label ID="lbl0601Item" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Qty.">
										<ItemTemplate>
											<%# Eval("Qty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Unit">
										<ItemTemplate>
											<asp:Label ID="lbl0601Unit" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Budget">
										<ItemTemplate>
											<%# Eval("BdgtAmt") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Status">
										<ItemTemplate>
											<%# Eval("Status") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="PO">
										<ItemTemplate>
											<%# Eval("POQty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="SR/WT/RT">
										<ItemTemplate>
											<%# Eval("SRQty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="CP">
										<ItemTemplate>
											<%# Eval("CPQty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Cost">
										<ItemTemplate>
											<%# Eval("CPCost") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Total">
										<ItemTemplate>
											<%# Eval("CPTotal") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Remarks">
										<ItemTemplate>
											<%# Eval("Remarks") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-200px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
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
					<div class="tab-pane fade" id="Menu02_TabContent">
						
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
						<!--begin::status-->
						<div class="row mb-5">
							<!--begin::Label-->
							<label class="col-lg-3 fw-bold text-muted pt-2 required">Change status to</label>
							<!--end::Label-->
							<!--begin::Col-->
							<div class="col-lg-9">
								<div class="input-group input-group-sm">
								<asp:DropDownList ID="ddl01Status" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-solid form-select-sm" AutoPostBack="true"></asp:DropDownList>
								</div>
							</div>
							<!--end::Col-->
						</div>
						<!--end::status-->
						<!--begin::assigned to-->
						<asp:Panel ID="pnl01ClarifyTo" runat="server" class="row mb-5" Visible="false">
							<!--begin::Label-->
							<label class="col-lg-3 fw-bold text-muted pt-2 required">Clarify to</label>
							<!--end::Label-->
							<!--begin::Col-->
							<div class="col-lg-9">
								<div class="input-group input-group-sm">
									<asp:DropDownList ID="ddl01ClarifyTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-solid form-select-sm"></asp:DropDownList>
								</div>
							</div>
							<!--end::Col-->
						</asp:Panel>
						<!--end::assigned to-->
						<!--begin::note-->
						<div class="row mb-5">
							<!--begin::Label-->
							<label id="spn01Note" runat="server" class="col-lg-3 fw-bold text-muted pt-2">Notes</label>
							<!--end::Label-->
							<!--begin::Col-->
							<div class="col-lg-9">
								<div class="input-group input-group-sm">
									<textarea id="tbx01Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" placeholder="Add extra details" style="height:200px"></textarea>
								</div>
							</div>
							<!--end::Col-->
						</div>
						<!--end::note-->
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
				
		<!--begin::PR New Particular-->
		<asp:UpdatePanel ID="mdl06PRDtlAdd" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Particular</h5>
						<!--begin::Close-->
						<a class="btn btn-sm btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
							<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</a>
						<!--end::Close-->
					</div>
					<div class="modal-body">
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Particular</span>
							<asp:TextBox ID="tbx06PRDtlAddItem" runat="server" class="form-control" Placeholder="Add particular"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Qty.</span>
							<input id="tbx06PRDtlAddQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Unit</span>
							<asp:TextBox ID="tbx06PRDtlAddUnit" runat="server" class="form-control" Placeholder="Add unit"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Budget</span>
							<input id="tbx06PRDtlAddBdgtAmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="card-title fs-5 fw-bolder">For Purchaser/Implementer</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Status</span>
							<asp:DropDownList ID="ddl06PRDtlAddStatus" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl06PRDtlAdd" class="form-select form-select-sm form-select-border min-h-35px">
                                <asp:ListItem Value="">Select status</asp:ListItem>
                            </asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">for PO</span>
							<input id="tbx06PRDtlAddPOQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">for SR</span>
							<input id="tbx06PRDtlAddSRQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="card-title fs-5 fw-bolder">For Cash Purchase</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Qty.</span>
							<input id="tbx06PRDtlAddCPQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Cost</span>
							<input id="tbx06PRDtlAddCPCost" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Total</span>
							<input id="tbx06PRDtlAddCPTotal" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<asp:TextBox ID="tbx06PRDtlAddCPRemarks" runat="server" class="form-control min-h-75px" Placeholder="Add remarks" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn06PRDtlAddOk" runat="server" class="btn btn-primary">Add</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::PR New Particular-->
				
		<!--begin::Modal PR New Particular SCM-->
		<asp:UpdatePanel ID="mdl06PRDtlAddSCM" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Add Particular (SCM - Estimate - Credit Purchase)</h5>
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
						<asp:GridView ID="gv06SCMMaterial" runat="server" class="table table-no-border table-row-bordered align-middle" AutoGenerateColumns="False" EmptyDataText="No Data" >
						<Columns>
							<asp:TemplateField HeaderText="Particular">
								<ItemTemplate>
									<asp:Label ID="lbl06SCMScope" runat="server" Text='<%# Eval("Scope") %>'></asp:Label>
									<asp:Label ID="lbl06SCMParticular" runat="server" Text='<%# Eval("Particular") %>'></asp:Label>
									<asp:Label ID="lbl06SCMWBSNo" runat="server" Text='<%# Eval("WBSNo") %>' Visible="false"></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-200px" />
								<ItemStyle CssClass="min-w-200px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="QTY - Balance">
								<ItemTemplate>
									<asp:Label ID="lbl06SCM01Qty" runat="server" Text='<%# Eval("Qty1") %>' ></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px text-center" />
								<ItemStyle CssClass="min-w-100px mw-100px text-end" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="QTY - Approval">
								<ItemTemplate>
									<asp:Label ID="lbl06SCM02Qty" runat="server" Text='<%# Eval("Qty2") %>' ></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px text-center" />
								<ItemStyle CssClass="min-w-100px mw-100px text-end" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="QTY - Available">
								<ItemTemplate>
									<asp:Label ID="lbl06SCM03Qty" runat="server" Text='<%# Eval("Qty3") %>' ></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px text-center" />
								<ItemStyle CssClass="min-w-100px mw-100px text-end" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Request">
								<ItemTemplate>
									<input id="tbx06SCMQty" runat="server" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" onblur="FormatNumeric(this.id);" value="0.00"/>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Unit">
								<ItemTemplate>
									<asp:Label ID="lbl06SCMUnit" runat="server" Text='<%# Eval("UOM") %>' ></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Remarks">
								<ItemTemplate>
									<input id="tbx06SCMRemarks" runat="server" type="text" class="w-100 outline-none text-start border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="-" />
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-200px" />
								<ItemStyle CssClass="min-w-200px" />
								</asp:TemplateField>
                        </Columns>
						</asp:GridView>
                    </div>
                    <div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn06PRDtlAdd_SCM_Ok" runat="server" class="btn btn-primary">Add</asp:LinkButton>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal PR New Particular SCM-->
		
		<!--begin::Modal PR Find-->
		<div id="mdl06PRDtlTag" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-scrollable mw-1000px">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 class="modal-title">Project Tagging</h5>
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
                                    <input id="tbx06PRDtlFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div06PRDtlLoader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table06PRDtl" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-200px w-100 fw-bold border-end">Project</th>
                                        <th class="min-w-100px mw-100px fw-bold border-end">Unit</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Qty - Balance</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Qty - Approval</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Qty - Available</th>
										<th class="min-w-30px mw-30px" style="padding-right:4px">
											<div class='form-check form-check-custom form-check-solid w-100 flex-center'>
												<input class='form-check-input cbx06AddAll' type='checkbox'/>
											</div>
										</th>
                                        <th class="min-w-150px mw-150px fw-bold border-end">Qty - Request</th>
					                </tr>
				                </thead>                                                                                             
				                <tbody>
						
				                </tbody>
                            </table>
                            <!--end::Files-->
                        </div>
					</div>
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0106Add_Ok(); return false;">
                             <span class="indicator-label">Save</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-warning fw-bolder min-w-100px" onclick="fn0106Return_Ok(); return false;">
                             <span class="indicator-label">Return</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
		<!--begin::Modal PR Find-->
        
		<!--begin::Modal PR New Particular OSM-->
		<asp:UpdatePanel ID="mdl0601PRDtlAddOSM" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Add Particular (OSM - Estimate - Stock Request)</h5>
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
						<asp:GridView ID="gv0601OSMMaterial" runat="server" class="table table-no-border table-row-bordered align-middle" AutoGenerateColumns="False" >
						<Columns>
							<asp:TemplateField HeaderText="Particular">
								<ItemTemplate>
									<%--<asp:Label ID="lbl06OSMParticular" runat="server" Text='<%# Eval("Particular") %>' CssClass='<%# Eval("TextStyle") %>'></asp:Label>--%>
									<asp:Label ID="lbl0601OSMParticular" runat="server" Text='<%# Eval("Particular") %>' ></asp:Label>
                                    <asp:Label ID="lbl0601OSMItemNo" runat="server" class="d-none" Text='<%# Eval("ItmNo") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-200px" />
								<ItemStyle CssClass="min-w-200px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="QTY - Balance">
								<ItemTemplate>
									<asp:Label ID="lbl0601OSMQty1" runat="server" Text='<%# Eval("Qty1") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="QTY - For Approval">
								<ItemTemplate>
									<asp:Label ID="lbl0601OSMQty2" runat="server" Text='<%# Eval("Qty2") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="QTY - Available">
								<ItemTemplate>
									<asp:Label ID="lbl0601OSMQty3" runat="server" Text='<%# Eval("Qty3") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Request">
								<ItemTemplate>
                                    <div class='<%# Eval("Style") %>'>
										<input id="tbx0601OSMQty" runat="server" type="text" class="w-100 outline-none text-start border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" style="outline:none;" onblur="FormatNumeric(this.id); FormatNumericUpdBal(this);" value="0.00" />
                                    </div>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Unit">
								<ItemTemplate>
									<asp:Label ID="lbl0601OSMUnit" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Balance">
								<ItemTemplate>
                                    <div class='<%# Eval("Style") %>'>
										<input id="tbx0601OSMBalQty" runat="server" type="text" class="w-100 outline-none text-start border-0" style="outline:none;" value="0.00" readonly="" />
                                    </div>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-100px mw-100px" />
								<ItemStyle CssClass="min-w-100px mw-100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Remarks">
								<ItemTemplate>
                                    <div class='<%# Eval("Style") %>'>
										<input id="tbx0601OSMRemarks" runat="server" type="text" class="w-100 outline-none text-start border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" style="outline:none" value="-"/>
                                    </div>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-200px" />
								<ItemStyle CssClass="min-w-200px" />
							</asp:TemplateField>
						</Columns>
						</asp:GridView>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn0601PRDtlAdd_OSM_Ok" runat="server" class="btn btn-primary">Add</asp:LinkButton>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal PR New Particular SCM-->
		
		<!--begin::Modal PR New Particular OSM-->
		<asp:UpdatePanel ID="mdl06PRDtlAddOSM" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Add Particular (OSM - Estimate - Stock Request)</h5>
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
                        <div class="table-responsive">
							<asp:GridView ID="gv06OSMMaterial" runat="server" class="table table-no-border table-row-bordered align-middle" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateField HeaderText="Particular">
									<ItemTemplate>
										<asp:Label ID="lbl06OSMParticular" runat="server" Text='<%# Eval("Particular") %>' ></asp:Label>
										<asp:Label ID="lbl06OSMItemNo" runat="server" class="d-none" Text='<%# Eval("WBSNo") %>'></asp:Label>
										<asp:Label ID="lbl06OSMCount" runat="server" class="d-none" Text='<%# Eval("Count") %>'></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="min-w-200px" />
									<ItemStyle CssClass="min-w-200px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="QTY - Balance">
									<ItemTemplate>
										<asp:Label ID="lbl06OSMQty1" runat="server" Text='<%# Eval("Qty1") %>'></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="min-w-100px mw-100px" />
									<ItemStyle CssClass="min-w-100px mw-100px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="QTY - For Approval">
									<ItemTemplate>
										<asp:Label ID="lbl06OSMQty2" runat="server" Text='<%# Eval("Qty2") %>'></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="min-w-100px mw-100px" />
									<ItemStyle CssClass="min-w-100px mw-100px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="QTY - Available">
									<ItemTemplate>
										<asp:Label ID="lbl06OSMQty3" runat="server" Text='<%# Eval("Qty3") %>'></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="min-w-100px mw-100px" />
									<ItemStyle CssClass="min-w-100px mw-100px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Unit">
									<ItemTemplate>
										<asp:Label ID="lbl06OSMUnit" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
									</ItemTemplate>
									<HeaderStyle CssClass="min-w-100px mw-100px" />
									<ItemStyle CssClass="min-w-100px mw-100px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Remarks">
									<ItemTemplate>
										<div>
											<input id="tbx06OSMRemarks" runat="server" type="text" class="w-100 outline-none text-start border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" style="outline:none" value="-"/>
										</div>
									</ItemTemplate>
									<HeaderStyle CssClass="min-w-200px" />
									<ItemStyle CssClass="min-w-200px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Action">
									<ItemTemplate>
										<div class="d-flex ">
											<asp:LinkButton ID="lbtn06Add" runat="server" class="btn btn-sm btn-icon btn-success w-100" CommandArgument='<%# Bind("WBSNo") %>' OnClick="lbtn06Add" ToolTip="Add">Add</asp:LinkButton>
										</div>
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
							</asp:GridView>
                        </div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal PR New Particular SCM-->
		
		<!--begin::PR Update Particular-->
		<asp:UpdatePanel ID="mdl06PRDtlUpd" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Update Particular</h5>
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
							<span class="input-group-text min-w-150px required">Particular</span>
							<asp:TextBox ID="tbx06PRDtlUpdItem" runat="server" class="form-control"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Qty.</span>
							<input id="tbx06PRDtlUpdQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);Compute();" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Unit</span>
							<asp:TextBox ID="tbx06PRDtlUpdUnit" runat="server" class="form-control"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Budget</span>
							<input id="tbx06PRDtlUpdBdgtAmt" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="card-title fs-5 fw-bolder">For Purchaser/Implementer</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Status</span>
							<asp:DropDownList ID="ddl06PRDtlUpdStatus" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl06PRDtlUpd" class="form-select form-select-sm form-select-border min-h-35px">
                                <asp:ListItem Value="">Select status</asp:ListItem>
                                <asp:ListItem Value="Not in BOQ">Not in BOQ</asp:ListItem>
                                <asp:ListItem Value="Over">Over</asp:ListItem>
                                <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                            </asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">for PO</span>
							<input id="tbx06PRDtlUpdPOQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">for SR</span>
							<input id="tbx06PRDtlUpdSRQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);Compute();" type="text" value="0.00" />
						</div>
						<div class="card-title fs-5 fw-bolder">For Cash Purchase</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Qty.</span>
							<input id="tbx06PRDtlUpdCPQty" runat="server" class='form-control' onblur="FormatNumeric(this.id);Compute();" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Cost</span>
							<input id="tbx06PRDtlUpdCPCost" runat="server" class='form-control' onblur="FormatNumeric(this.id);Compute();" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Total</span>
							<input id="tbx06PRDtlUpdCPTotal" runat="server" class='form-control' onblur="FormatNumeric(this.id);" type="text" value="0.00" readonly />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
							<asp:TextBox ID="tbx06PRDtlUpdRemarks" runat="server" class="form-control min-h-75px" Placeholder="Add remarks" TextMode="MultiLine"></asp:TextBox>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn06PRDtlUpdOk" runat="server" class="btn btn-primary">Update</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::PR Update Particular-->
				
        <!--begin::Phase-->
		<div id="mdl01Charge" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-fullscreen">
	            <div class="modal-content shadow-none">
					<div class="modal-header">
                        <h5 id="h01Title" class="modal-title"> - Search record</h5>
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
                                    <input id="tbx01FindCharge" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div01Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="tbl01Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
						                <th class="min-w-100px mw-100px fw-bold border-end">Code</th>
                                        <th class="min-w-50px mw-50px fw-bold border-end">Lock</th>
						                <th class="min-w-150px w-100 fw-bold border-end">Description</th>
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
        <!--end::Phase-->
	
        <!--begin::Estimate-->
		<div id="mdl01Estimate" class="modal fade" tabindex="-999" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-scrollable mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Estimate - Search record</h5>
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
                                    <input id="tbx01FindEstimate" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
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
                            <div id="div04Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="tbl04Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
				                <thead>
					                <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                        <th class="min-w-200px w-100 fw-bold border-end">Project</th>
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
        <!--end::Estimate-->

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
							<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
							<textarea id="tbx05Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" placeholder="Add note" style="height:200px"></textarea>
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

		//format
        function fnFormatNumericQty(input, maxQty, Qty) {
            const rawVal = input.value.trim();
            let val = parseFloat(rawVal);
            if (isNaN(val) || rawVal === '') {
                input.value = '0.00';
                return;
            };
            if (val >= maxQty) {
                val = maxQty;
			};
			if (Qty > 0 && val > Qty) val = maxQty - Qty;
            if (val < 0) val = 0;
			input.value = val.toFixed(2);
		};
        function fn01EnterKey(evt, input) {
            try {
                var charCode = (evt.which) ? evt.which : event.keyCode;
                var txt = input.value;

                if (charCode === 46) {
                    if (txt.indexOf('.') > -1) {
                        return false;
                    }
                    return true; 
                }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }

                return true; 
			} catch (w) {
				//nothing
            }
        }
		//format

        //balance
        // Bind this to input change or blur event
        $('#table06PRDtl tbody').on('input', 'input[prm0106Qty]', function () {
            updateCumulativeBalances();
        });
        function updateCumulativeBalances() {
            const table = $('#table06PRDtl').DataTable();
            const rows = table.rows().nodes();

            // Assuming Approval qty is the same for all rows, get from first row data
            const totalApproval = parseFloat(table.row(0).data().Approval) || 0;

            let cumulativeInput = 0;

            rows.each(function (rowElem, idx) {
                const $row = $(rowElem);
                const inputElem = $row.find('input[prm0106Qty]');
                const balanceElem = $row.find('input[prm0106Balance]');

                if (!inputElem.length || !balanceElem.length) return;

                // Parse user input, sanitize commas
                let inputValRaw = inputElem.val().replace(/,/g, '').trim();
                let inputVal = parseFloat(inputValRaw) || 0;

                // Calculate remaining qty left
                const remainingQty = totalApproval - cumulativeInput;

                // If user input exceeds remaining, cap it and update input box
                if (inputVal > remainingQty) {
                    inputVal = remainingQty;
                    inputElem.val(inputVal.toFixed(2));
                }

                // Calculate balance after deducting cumulative inputs + this input
                const balance = totalApproval - (cumulativeInput + inputVal);

                // Update balance field with formatted value
                balanceElem.val(balance.toFixed(2));

                // Update cumulative input for next rows
                cumulativeInput += inputVal;
            });
        }
		//balance

		//tag
		function fn01PRDtlTag(pID, pItemNo) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000010',
					'Type': 'PR-Tagging',
					'pID': pID,
					'pWBSNo': pItemNo,
					'pProjectCat': document.getElementById("ContentPlaceHolder1_lbl01ProjectCat").innerText
                },
                beforeSend: function () {
                    // Show Swal loader
                    Swal.fire({
                        title: 'Loading...',
                        text: 'Please wait while data is being processed.',
						allowOutsideClick: false,
                        allowEscapeKey: false,
                        didOpen: () => {
                            Swal.showLoading();
                        }
                    });
                },
				success: function (response) {
                    //display loader
					document.getElementById("div06PRDtlLoader").style.display = "";
					document.querySelector(".cbx06AddAll").checked = false;
                    //display loader

                    $('#table06PRDtl').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table06PRDtl = $("#table06PRDtl").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: false,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Project' },
                            { data: 'Unit' },
							{
								data: 'Qty1',
								render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let rowVal = parseFloat(row.Qty1).toFixed(2);

                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        }).format(rowVal);
                                        let textbox = `
                                                    <input id_qty="${row.ItemNo}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-0" value="${formattedValue}" Placeholder="Request" maxLength="21" readonly />
                                                `;

                                        return textbox;
                                    }
                                    return data;
								}
							},
							{
								data: 'Qty2',
								render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
										let rowVal = parseFloat(row.Qty2).toFixed(2);

                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        }).format(rowVal);
										let textbox;
                                        if (row.Qty2 == 0) {
                                            textbox = `
                                                    <input prm0106Return="${meta.row}" id_return="${row.ItemNo}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="${rowVal}" Placeholder="Request" maxLength="21" readonly />
                                                `;
                                        } else {
                                            textbox = `
                                                    <input prm0106Return="${meta.row}" id_return=${row.ItemNo} type="text" onkeypress="return fn01EnterKey(event,this.id)" data-itemno="${row.ItemNo}" data-lotcode="${row.LotCode}" data-acctcode="${row.AcctCode}" data-divcode="${row.DivCode}" data-deptcode="${row.DeptCode}" data-subsidiary="${row.Subsidiary}" data-code="${row.Code}" data-particular='${row.Particular}' onblur="fnFormatNumericQty(this, ${row.Qty2});" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="${rowVal}" Placeholder="Request" maxLength="21" />
                                                `;
                                        };

                                        return textbox;
                                    }
                                    return data;
								}
                            },
							{
								data: 'Available',
								render: function (data, type, row, meta) {
									var Balance = parseFloat(row.Qty1) - parseFloat(row.Qty2);
                                    return Balance.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
								}
							},
                            { data: 'Return' },
							{
								data: 'Qty3',
                                render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let rowVal = parseFloat(row.Approval).toFixed(2);
                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
										}).format(rowVal);
										let textbox;
										if (row.Qty2 == row.Qty1) {
                                            textbox = `
                                                    <input prm0106Qty="${meta.row}" id_select="${row.ItemNo}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="0.00" Placeholder="Request" maxLength="21" readonly />
                                                `;
										} else {
                                            textbox = `
                                                    <input prm0106Qty="${meta.row}" id_select="${row.ItemNo}" type="text" onkeypress="return fn01EnterKey(event,this.id)" data-itemno="${row.ItemNo}" data-lotcode="${row.LotCode}" data-acctcode="${row.AcctCode}" data-divcode="${row.DivCode}" data-deptcode="${row.DeptCode}" data-subsidiary="${row.Subsidiary}" data-code="${row.Code}" data-particular='${row.Particular}' onblur="fnFormatNumericQty(this, ${row.Qty1}, ${row.Qty2});" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" value="0.00" Placeholder="Request" maxLength="21" />
                                                `;
										};

                                        return textbox;
                                    }
                                    return data;
                                }
                            }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [1], className: 'tbody-nowrap-auto'
							},
							{
                                targets: [2, 4],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
							},
							{
                                targets: [2, 3, 4, 5, 6],
                                orderable: false
							}
                        ],
                        order: [[0, 'asc']],
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
                    $('#tbx06PRDtlFind').on('keyup', function () {
                        table06PRDtl.search(this.value).draw();
                    });
                    //search

                    // close Swal loader if error
					Swal.close();

                    //hide loader
                    document.getElementById("div06PRDtlLoader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl06PRDtlTag').modal('show');
                }
            });
		};
		function fn0106Add_Ok() {
            const table = $('#table06PRDtl').DataTable();
            const rows = table.rows().nodes();
            const result = [];
            let resultData = '';

            rows.each(function (rowElem, rowIndex) {
                const inputElem = $(rowElem).find('input[prm0106Qty]');
                if (inputElem.length) {
                    const inputValRaw = inputElem.val().replace(/,/g, '').trim();
                    const inputVal = parseFloat(inputValRaw) || 0;

                    if (inputVal !== 0) {
                        result.push({
                            InputQty: inputVal.toFixed(2),
                            ItemNo: inputElem.attr('data-itemno'),
                            Particular: inputElem.attr('data-particular'),
                            LotCode: inputElem.attr('data-lotcode'),
                            AcctCode: inputElem.attr('data-acctcode'),
                            DivCode: inputElem.attr('data-divcode'),
                            DeptCode: inputElem.attr('data-deptcode'),
                            Subsidiary: inputElem.attr('data-subsidiary'),
                            Code: inputElem.attr('data-code')
                        });

                    };
                };
            });

            resultData = result.map(i =>
                `${i.ItemNo}©${i.Particular}©${i.InputQty}©${i.LotCode}©${i.AcctCode}©${i.DivCode}©${i.DeptCode}©${i.Subsidiary}©${i.Code}`
            ).join('®');

			//save
            if (resultData) {
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
                }).then((res) => {
                    if (res.isConfirmed) {
                        $.ajax({
                            type: "POST",
                            url: "HND000003.ashx",
                            data: {
                                'FormCode': 'FRM000010',
                                'Type': 'Save-PR-Tagging',
                                'pID': document.getElementById("ContentPlaceHolder1_lbl01ID").innerText,
                                'pResultData': resultData
                            },
                            success: async function (response) {
                                //modal
                                $("#mdl06PRDtlTag").modal("hide");
                                //alert
                                fnAlertOnly('Record successfully tagged.', 'success', 'btn btn-success');
                                //trigger
                                document.getElementById("<%= btnBind.ClientID %>").click();
                            }
                        });
                    };
                });
            } else {
                fnAlertOnly('No record selected.', 'error', 'btn btn-danger');
			}
		};
        function fn0106Return_Ok() {
            const table = $('#table06PRDtl').DataTable();
            const rows = table.rows().nodes();
            const result = [];
            rows.each(function (rowElem, rowIndex) {
                const inputElem = $(rowElem).find('input[prm0106Return]');
                if (inputElem.length) {
                    // Get user-entered value
                    const ItemNo = inputElem.attr('data-itemno');
                    const LotCode = inputElem.attr('data-lotcode');
                    const Particular = inputElem.attr('data-particular');
                    const inputValRaw = inputElem.val().replace(/,/g, '').trim();
                    const inputVal = parseFloat(inputValRaw) || 0;

                    // Only process if value is NOT zero
                    if (inputVal !== 0) {
                        result.push({
                            InputQty: inputVal.toFixed(2),
							ItemNo: ItemNo,
							Particular: Particular,
                            LotCode: LotCode
                        });
                    };
                };
            });
			//save
			if (Array.isArray(result) && result.length !== 0) {
                Swal.fire({
                    text: 'Return record?',
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
                }).then((res) => {
					if (res.isConfirmed) {
                        let completed = 0;
                        const total = result.length;
                        result.forEach(function (rec) {
                            $.ajax({
                                type: "POST",
                                url: "HND000003.ashx",
                                data: {
                                    'FormCode': 'FRM000010',
                                    'Type': 'Return-PR-Tagging',
									'pItemNo': rec.ItemNo,
									'pParticular': rec.Particular,
                                    'pQty': rec.InputQty,
                                    'pID': document.getElementById("ContentPlaceHolder1_lbl01ID").innerText,
                                    'pLotCode': rec.LotCode,

                                },
                                success: async function (response) {
                                    completed++;
                                    if (completed === total) {
                                        //modal
                                        $("#mdl06PRDtlTag").modal("hide");
                                        //alert
                                        fnAlertOnly('Record successfully returned.', 'success', 'btn btn-success');
                                        //trigger
                                        document.getElementById("<%= btnBind.ClientID %>").click();
                                    };
                                },
                            });
                        });
                    };
                });
            } else {
                //alert
                fnAlertOnly('No record selected.', 'error', 'btn btn-danger');
			};
		};
		//tag

		//charge to
		function fn01ChargeTo() {
            if (document.getElementById("ContentPlaceHolder1_hf01AcctCode").value != "" && document.getElementById("ContentPlaceHolder1_hf01Subsidiary").value != "NO SUBSIDIARY") {
                $.ajax({
                    type: "POST",
                    url: "HND000003.ashx",
                    data: {
                        'FormCode': 'FRM000010',
						'Type': 'Charge Code',
						'pTblFrom': document.getElementById("ContentPlaceHolder1_hf01Subsidiary").value,
						'pCode1': document.getElementById("ContentPlaceHolder1_hf01AcctCode").value,
						'pCode2': '',
						'pCode3': '',
						'pCode4': '',
						'pCode5': ''
                    },
					success: function (response) {
                        //display loader
						document.getElementById("div01Loader").style.display = "";
						document.getElementById("h01Title").innerText = "";
                        //display loader

                        $('#tbl01Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var tbl01Record = $("#tbl01Record").DataTable({
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
                                { data: 'Description' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: [0, 2], orderable: false
                                },
                                {
                                    targets: 3, className: 'tbody-nowrap-auto'
                                }
                            ],
                            order: false,
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
                        $('#tbx01FindCharge').on('keyup', function () {
                            tbl01Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01Loader").style.display = "none";
                        document.getElementById("h01Title").innerText = document.getElementById("ContentPlaceHolder1_hf01Subsidiary").value + " - Search Record";
                        //hide loader

                        //modal
                        $('#mdl01Charge').modal('show');
                    }
                });
			};
		};
        function fn01AddChargeTo(pCode, pDescription, pLock) {
            if (pLock == 1) {
                Description(pCode, pDescription);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
			};
			function Description(pCode, pDescription) {
				document.getElementById("ContentPlaceHolder1_hf01ChargeCode").value = pCode;
				document.getElementById("ContentPlaceHolder1_tbx01ChargeTo").value = pDescription;

				//modal
				$("#mdl01Charge").modal("hide");
			};
		};
		//charge to

		//estimate
        var start = new Date().getTime();
		function fn01Estimate() {
            if (document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").options[document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").selectedIndex].value == "House Construction" || document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").options[document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").selectedIndex].value == "House Construction - CCI") {
                if (document.getElementById("ContentPlaceHolder1_ddl01Subdivision").options[document.getElementById("ContentPlaceHolder1_ddl01Subdivision").selectedIndex].value == "") {
                    fnAlertOnly('Please select a subdivision!', 'error', 'btn btn-danger');
                } else {
                    $.ajax({
                        type: "POST",
                        url: "HND000003.ashx",
                        data: {
                            'FormCode': 'FRM000010',
                            'Type': 'Cost-Estimate',
                            'pProjectType': document.getElementById("ContentPlaceHolder1_ddl01OSMAType").options[document.getElementById("ContentPlaceHolder1_ddl01OSMAType").selectedIndex].value,
                            'pSubd': document.getElementById("ContentPlaceHolder1_ddl01Subdivision").options[document.getElementById("ContentPlaceHolder1_ddl01Subdivision").selectedIndex].value,
                            'pCategory': document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").options[document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").selectedIndex].value
                        },
						success: function (response) {
                            var end = new Date().getTime();
                            //display loader
                            document.getElementById("div04Loader").style.display = "";
                            //display loader

                            $('#tbl04Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var tbl04Record = $("#tbl04Record").DataTable({
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
                                    { data: 'Project' }
                                ],
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: 0, orderable: false
                                    },
                                    {
                                        targets: 1, className: 'tbody-nowrap-auto'
                                    }
                                ],
                                order: false,
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
                            $('#tbx01FindEstimate').on('keyup', function () {
                                tbl04Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div04Loader").style.display = "none";
                            //hide loader

                            //modal
                            $('#mdl01Estimate').modal('show');
                        }
                    });
                }
			} else {
                $.ajax({
                    type: "POST",
                    url: "HND000003.ashx",
                    data: {
                        'FormCode': 'FRM000010',
                        'Type': 'Cost-Estimate-Construction',
						'pSubd': document.getElementById("ContentPlaceHolder1_ddl01Subdivision").options[document.getElementById("ContentPlaceHolder1_ddl01Subdivision").selectedIndex].value,
                        'pCategory': document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").options[document.getElementById("ContentPlaceHolder1_ddl01ProjectCat").selectedIndex].value
                    },
                    success: function (response) {
                        var end = new Date().getTime();
                        //display loader
                        document.getElementById("div04Loader").style.display = "";
                        //display loader

                        $('#tbl04Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var tbl04Record = $("#tbl04Record").DataTable({
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
                                { data: 'Project' }
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0, orderable: false
                                },
                                {
                                    targets: 1, className: 'tbody-nowrap-auto'
                                }
                            ],
                            order: false,
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
                        $('#tbx01FindEstimate').on('keyup', function () {
                            tbl04Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div04Loader").style.display = "none";
                        //hide loader

                        //modal
                        $('#mdl01Estimate').modal('show');
                    }
                });
			};
		};
		function fn01AddEstimate(pCode, pTitle, pDivCode, pDivName) {
			document.getElementById("ContentPlaceHolder1_tbx01Estimate").value = pTitle;
			document.getElementById("ContentPlaceHolder1_hf01Estimate").value = pCode;
			document.getElementById("ContentPlaceHolder1_hf01Division").value = pDivCode;
			document.getElementById("ContentPlaceHolder1_tbx01Division").value = pDivName;
            document.getElementById("ContentPlaceHolder1_hf01Department").value = "2012000000"
            document.getElementById("ContentPlaceHolder1_tbx01Department").value = "INDIRECT DEPARTMENT"

			//modal
			$("#mdl01Estimate").modal("hide");
		};
		//estimate

		//function related to this page only
        var input = document.getElementById("tbx01FindProject");
        input.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                FindProject(input.value);
            }
        });
        function FindProject(Find) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000010',
                    'Type': 'Search Project',
                    'Find': Find
                },
                success: function (response) {
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
                    'FormCode': 'FRM000010',
                    'Type': 'Select Project',
                    'Code': Code
                },
                success: function (response) {
                    var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
                    var hf01Subdivision = document.getElementById("ContentPlaceHolder1_hf01Subdivision");
                    var hf01Phase = document.getElementById("ContentPlaceHolder1_hf01Phase");
                    var hf01Block = document.getElementById("ContentPlaceHolder1_hf01Block");
                    var hf01Lot = document.getElementById("ContentPlaceHolder1_hf01Lot");

                    tbx01Project.value = ""
                    hf01Subdivision.value = "";
                    hf01Phase.value = "";
                    hf01Block.value = "";
                    hf01Lot.value = "";

                    tbx01Project.value = response[0].Project;
                    hf01Subdivision.value = response[0].Subdivision;
                    hf01Phase.value = response[0].Phase;
                    hf01Block.value = response[0].Block;
					hf01Lot.value = response[0].Lot;

                    $('#mdl01FindProject').modal('hide');
                },
            });
		};
        function ddl01ProjectCat_onchange(selectObj) {
            var selectIndex = selectObj.selectedIndex;
			var selectValue = selectObj.options[selectIndex].value;
			if (selectValue !== "") {
                document.getElementById("ContentPlaceHolder1_tbx01Estimate").value = "";
                document.getElementById("ContentPlaceHolder1_hf01Estimate").value = "";
			};
		};
        function ddl01Subdivision(selectObj) {
            var selectIndex = selectObj.selectedIndex;
			var selectValue = selectObj.options[selectIndex].value;

			var hf01Subdivision = document.getElementById("ContentPlaceHolder1_hf01Subdivision");
			hf01Subdivision.value = selectValue;
		};
        function ddl01VehiclePlate(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].value;

            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000010',
                    'Type': 'Select Vehicle',
                    'Code': selectValue
                },
                success: function (response) {
                    var hf01Vehicle = document.getElementById("ContentPlaceHolder1_hf01Vehicle");
                    var hf01PlateNo = document.getElementById("ContentPlaceHolder1_hf01PlateNo");
                    hf01Vehicle.value = "";
                    hf01PlateNo.value = "";
                    hf01Vehicle.value = response[0].Vehicle;
                    hf01PlateNo.value = response[0].PlateNo;
                },
            });
        }
		function Compute() {
            var lbl01PurchaseType = document.getElementById("ContentPlaceHolder1_lbl01PurchaseType");
            var tbx06PRDtlUpdQty = document.getElementById("ContentPlaceHolder1_tbx06PRDtlUpdQty");
            var tbx06PRDtlUpdPOQty = document.getElementById("ContentPlaceHolder1_tbx06PRDtlUpdPOQty");
			var tbx06PRDtlUpdSRQty = document.getElementById("ContentPlaceHolder1_tbx06PRDtlUpdSRQty");
            var tbx06PRDtlUpdCPQty = document.getElementById("ContentPlaceHolder1_tbx06PRDtlUpdCPQty");
            var tbx06PRDtlUpdCPCost = document.getElementById("ContentPlaceHolder1_tbx06PRDtlUpdCPCost");
			var tbx06PRDtlUpdCPTotal = document.getElementById("ContentPlaceHolder1_tbx06PRDtlUpdCPTotal");

			if (lbl01PurchaseType.innerHTML == "Return") {
				tbx06PRDtlUpdSRQty.value = tbx06PRDtlUpdQty.value;
				tbx06PRDtlUpdCPQty.value = "0.00";
			}
            if (lbl01PurchaseType.innerHTML == "Transfer") {
                tbx06PRDtlUpdSRQty.value = tbx06PRDtlUpdQty.value;
                tbx06PRDtlUpdCPQty.value = "0.00";
			}

            var POVal = parseFloat(tbx06PRDtlUpdQty.value.replace(',', '')) - (parseFloat(tbx06PRDtlUpdSRQty.value.replace(',', '')) + parseFloat(tbx06PRDtlUpdCPQty.value.replace(',', '')));
            var PONewVal = POVal.toFixed(2);
            var POParts = PONewVal.toString().split(".");
            var PONum = POParts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (POParts[1] ? "." + POParts[1] : "");
            if (PONum == "NaN") {
                PONum = "0.00";
            }
            tbx06PRDtlUpdPOQty.value = PONum;

            var TotVal = parseFloat(tbx06PRDtlUpdCPQty.value.replace(',', '')) * parseFloat(tbx06PRDtlUpdCPCost.value.replace(',', ''));
			var TotNewVal = TotVal.toFixed(2);
            var TotParts = TotNewVal.toString().split(".");
            var TotNum = TotParts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (TotParts[1] ? "." + TotParts[1] : "");
            if (TotNum == "NaN") {
                TotNum = "0.00";
            }
            tbx06PRDtlUpdCPTotal.value = TotNum;
		}
		function btn06PRDtlAdd_SCM() {
			var clickButton = document.getElementById("<%= btn06PRDtlAdd_SCM.ClientID %>");
			clickButton.click();
		};
		function btn06PRDtlUpl_SCM() {
            var fileSCM = document.getElementById("fileSCM");
            // Manually trigger file input click only ONCE
            if (!fileSCM.hasAttribute("data-clicked")) {
                fileSCM.setAttribute("data-clicked", "true");
                // Reset
                fileSCM.value = "";

                // Trigger
                fileSCM.click();

                // Reset flag after a slight delay to allow file selection
                setTimeout(() => fileSCM.removeAttribute("data-clicked"), 500);
            }
		};
		function btn06PRDtlAdd_OSM() {
            var clickButton = document.getElementById("<%= btn06PRDtlAdd_OSM.ClientID %>");
			clickButton.click();
		};
		function btn06PRDtlUpl_OSM() {
			var fileOSM = document.getElementById("fileOSM");
            // Manually trigger file input click only ONCE
            if (!fileOSM.hasAttribute("data-clicked")) {
				fileOSM.setAttribute("data-clicked", "true");
				// Reset
				fileOSM.value = "";

				// Trigger
                fileOSM.click();

                // Reset flag after a slight delay to allow file selection
                setTimeout(() => fileOSM.removeAttribute("data-clicked"), 500);
            }
		};
		//function related to this page only

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
                NumVal.value = "0";
                return;
            }
			//var NewVal = Val.toFixed(0);
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
			NumVal.value = NewVal;
		};
        function FormatNumericUpdBal(input) {
            const row = input.closest('tr');

            const lblQtyElem = row.querySelector('[id*="lbl0601OSMQty3"]');
            const balElem = row.querySelector('[id*="tbx0601OSMBalQty"]');

            // Get available quantity
            const available = parseFloat((lblQtyElem?.innerText || "0").replace(/,/g, ""));

            // Get requested (remove commas)
            let requested = parseFloat(input.value.replace(/,/g, "")) || 0;

            // If requested > available, limit it
            if (requested > available) {
                requested = available;
                input.value = requested.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }

            // Compute balance
            const balance = available - requested;
            if (balElem) {
                balElem.value = balance.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }
        }
        //numeric formatting

		function Alert01(Icon,Message) {
			Swal.fire({
				text: Message,
				icon: Icon,
				buttonsStyling: false,
				confirmButtonText: 'Ok, got it!',
				customClass: {
                    confirmButton: 'btn btn-primary'
				}
			});
		};

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

		//checkbox
		function cbx06Add_onchange(cbx06Add) {
			var ID = cbx06Add.getAttribute("parm_select06");
			var Select = document.querySelector('[id_select="' + ID + '"]');
			var Return = document.querySelector('[id_return="' + ID + '"]');
			var ToQty = document.querySelector('[id_qty="' + ID + '"]');
            if (parseFloat(Return.value.replace(/,/g, '')) < parseFloat(ToQty.value.replace(/,/g, ''))) {
				if (cbx06Add.checked == true) {
                    var totSelect = parseFloat(ToQty.value.replace(/,/g, '')) - parseFloat(Return.value.replace(/,/g, ''));
					Select.value = totSelect.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
				} else {
					Select.value = "0.00";
				};
            } else if (parseFloat(Return.value.replace(/,/g, '')) == parseFloat(ToQty.value).replace(/,/g, '')) {
				if (cbx06Add.checked == true) {
					cbx06Add.checked = false;
                    Select.value = "0.00"
                } else {
                    Select.value = "0.00";
                };
			}else {
                if (cbx06Add.checked == true) {
                    Select.value = parseFloat(ToQty.value.replace(/,/g, ''));
                } else {
                    Select.value = "0.00";
                };
			};
        };
		//checkbox

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {
                //checkbox
                $('.cbx06AddAll').click(function () {
                    if ($(this).is(":checked")) {
                        //get tr which is visible ..add checked to that checkboxes
                        $('#table06PRDtl').find('tr:visible .cbx06Add').prop('checked', true);

                        const checkbox = document.querySelectorAll('.cbx06Add');
                        for (const cbx of checkbox) {
                            var ID = cbx.getAttribute("parm_select06");
                            var Select = document.querySelector('[id_select="' + ID + '"]');
                            var Return = document.querySelector('[id_return="' + ID + '"]');
                            var ToQty = document.querySelector('[id_qty="' + ID + '"]');
                            if (parseFloat(Return.value.replace(/,/g, '')) < parseFloat(ToQty.value.replace(/,/g, ''))) {
								if (cbx.checked == true) {
                                    var totSelect = parseFloat(ToQty.value.replace(/,/g, '')) - parseFloat(Return.value.replace(/,/g, ''));
									Select.value = totSelect.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
								} else {
									Select.value = "0.00";
								}
                            } else if (parseFloat(Return.value.replace(/,/g, '')) == parseFloat(ToQty.value.replace(/,/g, ''))) {
								if (cbx.checked == true) {
									cbx.checked = false;
									Select.value = "0.00";
                                } 
							} else {
                                if (cbx.checked == true) {
                                    Select.value = parseFloat(ToQty.value.replace(/,/g, ''));
                                } else {
                                    Select.value = "0.00";
                                }
							};
						};
                    } else {
                        //remove checked
                        $(".cbx06Add").prop('checked', false);
                        const checkbox = document.querySelectorAll('.cbx06Add');
                        for (const cbx of checkbox) {
                            var ID = cbx.getAttribute("parm_select06");
                            var Select = document.querySelector('[id_select="' + ID + '"]');
                            var Return = document.querySelector('[id_return="' + ID + '"]');
                            var ToQty = document.querySelector('[id_qty="' + ID + '"]');
                            if (parseFloat(Return.value.replace(/,/g, '')) < parseFloat(ToQty.value).replace(/,/g, '')) {
                                if (cbx.checked == true) {
                                    var totSelect = parseFloat(ToQty.value.replace(/,/g, '')) - parseFloat(Return.value.replace(/,/g, ''));
                                    Select.value = totSelect.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                                } else {
                                    Select.value = "0.00";
                                }
                            } else if (parseFloat(Return.value.replace(/,/g, '')) == parseFloat(ToQty.value.replace(/,/g, ''))) {
                                if (cbx.checked == true) {
                                    cbx.checked = false;
                                    Select.value = "0.00";
                                } 
                            } else {
                                if (cbx.checked == true) {
                                    Select.value = parseFloat(ToQty.value.replace(/,/g, ''));
                                } else {
                                    Select.value = "0.00";
                                };
                            };
                        };
                    }
                })
                $(".cbx06Add").change(function () {
                    if (!$(this).prop("checked")) {
						$(".cbx06AddAll").prop("checked", false);
                    }
				});
                //checkbox

			});
            jQuery(function ($) {

                //form variable
                var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
				var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
				var ltrlCode = '<asp:Literal ID="ltrlCode" runat="server" />';
                var ltrlMode = '<asp:Literal ID="ltrlMode" runat="server" />';
                var ltrlDtlMode = '<asp:Literal ID="ltrlDtlMode" runat="server" />';
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
			jQuery(function ($) {
				setTimeout(function () {
                    var element = document.querySelector('[data-kt-menu="true"]');
                    if (element) {
                        KTMenu.createInstances();
                    }
				}, 500);
                document.getElementById("fileSCM").addEventListener("change", function (event) {
                    var file = event.target.files[0];

                    // Check if exists
                    if (!file) {
                        Swal.fire({
                            title: "Error",
                            text: "No file selected.",
                            icon: "error"
                        });
                        return;
                    };
                    // Check if exits

                    // Proceed confirmation
                    Swal.fire({
                        text: "Proceed on uploading?",
                        icon: "question",
                        buttonsStyling: false,
                        confirmButtonText: 'Ok, got it!',
                        showCancelButton: true,
                        customClass: {
                            confirmButton: 'btn btn-primary',
                            cancelButton: 'btn btn-secondary'
                        }
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                var based64 = e.target.result.split(",")[1];
                                var ID = "<%= ltrlID.Text %>";
                                var Code = "<%= ltrlCode.Text %>";

                                var uplOSM = {
                                    fileName: file.name,
                                    fileData: based64
                                };
                                fetch("FRM000010.aspx/UploadAndReadExcel", {
                                    method: "POST",
                                    headers: { "Content-Type": "application/json" },
                                    body: JSON.stringify(uplOSM)
                                })
                                    .then(response => response.json())
                                    .then(data => {
                                        if (!data || !data.d || !data.d.success) {
                                            Alert01("error", "Invalid Format!");
                                            return;
                                        };
                                        let result = data.d.data;
                                        if (!Array.isArray(result) || result.length == 0) {
                                            console.warn("No data returned.")
                                            return;
                                        };
                                        fetch("FRM000010.aspx/SaveToSCM", {
                                            method: "POST",
                                            headers: { "Content-Type": "application/json" },
                                            body: JSON.stringify({ ID, Code, data: result })
                                        })
                                            .then(response => response.json())
                                            .then(data => {
                                                try {
                                                    let parsedData = JSON.parse(data.d);
                                                    if (!parsedData.success) {
                                                        console.error("Error Saving to Database:", parsedData.message);
                                                        return;
                                                    }

                                                    Swal.fire({
                                                        text: "Record saved successfully!",
                                                        icon: "success",
                                                        buttonsStyling: false,
                                                        confirmButtonText: "Ok, got it!",
                                                        customClass: { confirmButton: "btn btn-primary" }
                                                    }).then((result) => {
                                                        // Reload
                                                        location.reload();
                                                    });

                                                } catch (error) {
                                                    Alert01("error", error);
                                                }
                                            })
                                    });

                                // Reset 
                                document.getElementById("fileSCM").value = "";
                            };

                            // Read File
                            reader.readAsDataURL(file);
                        } else {
                            document.getElementById("fileSCM").value = "";
                            return;
                        }
                    });
                    // Proceed confirmation
				});
				document.getElementById("fileOSM").addEventListener("change", function (event) {
					var file = event.target.files[0];

                    // Check if exists
                    if (!file) {
                        Swal.fire({
                            title: "Error",
                            text: "No file selected.",
                            icon: "error"
                        });
                        return;
                    };
                    // Check if exits

                    // Proceed confirmation
                    Swal.fire({
                        text: "Proceed on uploading?",
                        icon: "question",
                        buttonsStyling: false,
                        confirmButtonText: 'Ok, got it!',
                        showCancelButton: true,
                        customClass: {
                            confirmButton: 'btn btn-primary',
                            cancelButton: 'btn btn-secondary'
                        }
                    }).then((result) => {
						if (result.isConfirmed) {
							var reader = new FileReader();
							reader.onload = function (e) {
								var based64 = e.target.result.split(",")[1];
								var ID = "<%= ltrlID.Text %>";
								var Code = "<%= ltrlCode.Text %>";

								var uplOSM = {
									fileName: file.name,
									fileData: based64
								};
								fetch("FRM000010.aspx/UploadAndReadExcel", {
									method: "POST",
									headers: { "Content-Type": "application/json" },
									body: JSON.stringify(uplOSM)
								})
									.then(response => response.json())
									.then(data => {
										if (!data || !data.d || !data.d.success) {
											Alert01("error", "Invalid Format!");
											return;
										};
										let result = data.d.data;
										if (!Array.isArray(result) || result.length == 0) {
											console.warn("No data returned.")
											return;
										};
										fetch("FRM000010.aspx/SaveToOSM", {
                                            method: "POST",
                                            headers: { "Content-Type": "application/json" },
                                            body: JSON.stringify({ ID, Code, data: result })
										})
											.then(response => response.json())
											.then(data => {
                                                try {
                                                    let parsedData = JSON.parse(data.d);
                                                    if (!parsedData.success) {
                                                        console.error("Error Saving to Database:", parsedData.message);
                                                        return;
                                                    }

													Swal.fire({
														text: "Record saved successfully!",
														icon: "success",
														buttonsStyling: false,
														confirmButtonText: "Ok, got it!",
														customClass: { confirmButton: "btn btn-primary" }
													}).then((result) => {
														// Reload
														location.reload();
													});

												} catch (error) {
                                                    Alert01("error", error);
                                                }
											})
									});

								// Reset 
								document.getElementById("fileOSM").value = "";
							};

							// Read File
							reader.readAsDataURL(file);
						} else {
							document.getElementById("fileOSM").value = "";
							return;
						}
                    });
					// Proceed confirmation
                });
			});
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>