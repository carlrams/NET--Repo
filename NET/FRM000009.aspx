<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000009.aspx.vb" Inherits="NET.FRM000009" MaintainScrollPositionOnPostback = "true" enableEventValidation="false"%>
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
						<li class="breadcrumb-item text-white">Contracts Request</li>
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
						<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
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
									<asp:LinkButton ID="lbtn01Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-plus fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Delete" runat="server" ToolTip="Delete record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-trash fs-2"></i></asp:LinkButton>
									<asp:LinkButton ID="lbtn01Edit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
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
										<asp:TextBox ID="tbx01FormType" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Date Requested</span>
										<asp:TextBox ID="tbx01DateRequested" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required" >Date Required</span>
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
									<!--begin::Seperator-->
									<div class="separator separator-dashed my-6"></div>
									<!--end::Seperator-->
									<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
										<input id="cbx01IsHDMF01" runat="server" class="form-check-input" type="checkbox" value="" onclick="cbx01IsHDMF01(this);"/>
										<label class="form-check-label" for="ContentPlaceHolder1_cbx01IsHDMF01">
											HDMF
										</label>
									</div>
									<div id="div01Type" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px required">Type</span>
										<asp:DropDownList ID="ddl01Type" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
											<asp:ListItem Value="">Select type</asp:ListItem>
											<asp:ListItem Value="Pre-Inspection of Unit">Pre-Inspection of Unit</asp:ListItem>
											<asp:ListItem Value="Done Pre-Inspection of Unit">Done Pre-Inspection of Unit</asp:ListItem>
										</asp:DropDownList>
									</div>
									<div id="div01Status" runat="server" class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm border-0 m-2" style="display: none;">
										<input id="cbx010101" runat="server" class="form-check-input ml-5" type="checkbox" value="" />
										<label class="form-check-label" for="ContentPlaceHolder1_cbx010101">
											The unit has been assessed and findings were observed.
										</label>
										<input id="cbx010102" runat="server" class="form-check-input ml-5" type="checkbox" value="" />
										<label class="form-check-label" for="ContentPlaceHolder1_cbx010102">
											The unit has been assessed and is ready for inspection.
										</label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Category</span>
										<asp:DropDownList ID="ddl01Category" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddl01Category(this);">
											<asp:ListItem Value="">Select category</asp:ListItem>
										</asp:DropDownList>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Estimate</span>
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01Estimate" runat="server" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Select estimate" readonly />
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="fn01Estimate(); return false;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
													<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon-->
										</div>
										<asp:HiddenField ID="hf01EstimateCode" runat="server" />
									</div>
									<div id="div01Project" runat="server" class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px required">Project</span>
										<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
											<input id="tbx01Project" runat="server" type="text" class="form-control form-control-sm border-0 m-0" placeholder="Select project" readonly />
											<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
											<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="FindProject('None')">
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
										<asp:HiddenField ID="hf01Branch" runat="server" />
									</div>
									<div id="div01Renovation" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Project</span>
										<div class="form-control p-0 border-0">
											<asp:DropDownList ID="ddl01Project" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
												<asp:ListItem Value="">Select type</asp:ListItem>
												<asp:ListItem Value="Calayan Residences">Calayan Residences</asp:ListItem>
											</asp:DropDownList>
										</div>
									</div>
									<div id="div01House" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">House</span>
										<div class="form-control p-0 border-0">
											<asp:DropDownList ID="ddl01House01" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
												<asp:ListItem Value="">Select house</asp:ListItem>
											</asp:DropDownList>
										</div>
									</div>
									<div id="div01Batch" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Batch</span>
										<input id="tbx01Batch01" runat="server" type="text" class="form-control" Placeholder="Add batch" />
									</div>
									<div id="div01Theme" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Theme</span>
										<input id="tbx01Theme01" runat="server" type="text" class="form-control" Placeholder="Add theme" />
									</div>
									<div id="div01Budget" runat="server" class="input-group input-group-sm mb-2" style="display:none;">
										<span class="input-group-text min-w-150px required">Estimated Budget</span>
										<input id="tbx01Budget01" runat="server" class='form-control NumVal' onblur="FormatNumeric();" type="text" value="0.00" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px required">Purpose</span>
										<asp:TextBox ID="tbx01Purpose" runat="server" class="form-control min-h-75px" Placeholder="Add purpose" TextMode="MultiLine"></asp:TextBox>
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
										<asp:TextBox ID="lbl01FormType" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
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
									<!--begin::Seperator-->
									<div class="separator separator-dashed my-6"></div>
									<!--end::Seperator-->
									<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
										<input id="cbx01IsHDMF02" runat="server" class="form-check-input disable-check" type="checkbox" value=""/>
										<label class="form-check-label" for="ContentPlaceHolder1_cbx01IsHDMF02">
											HDMF
										</label>
									</div>
									<div id="div02Type" runat="server" class="input-group input-group-sm mb-2" style="display: none;">
										<span class="input-group-text min-w-150px">Type</span>
										<asp:Label ID="lbl01Type" runat="server" class="form-control">-</asp:Label>
									</div>
									<div id="div02Status" runat="server" class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm border-0 m-2" style="display: none;">
										<input id="cbx010201" runat="server" class="form-check-input ml-5" type="checkbox" value="" onclick="return false;" />
										<label class="form-check-label" for="ContentPlaceHolder1_cbx010201">
											The unit has been assessed and findings were observed.
										</label>
										<input id="cbx010202" runat="server" class="form-check-input ml-5" type="checkbox" value="" onclick="return false;" />
										<label class="form-check-label" for="ContentPlaceHolder1_cbx010202">
											The unit has been assessed and is ready for inspection.
										</label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Category</span>
										<asp:Label ID="lbl01Category" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Estimate</span>
										<asp:Label ID="lbl01Estimate" runat="server" class="form-control">-</asp:Label>
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-150px">Project</span>
										<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
									</div>
									<asp:Panel ID="pnl01House" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">House</span>
										<asp:Label ID="lbl01House" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Batch" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Batch</span>
										<asp:Label ID="lbl01Batch" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Theme" runat="server" class="input-group input-group-sm mb-2" Visible="false">
										<span class="input-group-text min-w-150px">Theme</span>
										<asp:Label ID="lbl01Theme" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<asp:Panel ID="pnl01Budget" runat="server" Visible="false">
										<span class="input-group-text min-w-150px">Estimated Budget</span>
										<asp:Label ID="lbl01Budget" runat="server" class="form-control">-</asp:Label>
									</asp:Panel>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Purpose</span>
										<asp:TextBox ID="lbl01Purpose" runat="server" class="form-control min-h-75px" TextMode="MultiLine" Text="-"></asp:TextBox>
									</div>
								</asp:Panel>
							</div>
							<!--end::Dtl-->
						</ContentTemplate>
						</asp:UpdatePanel>
						<asp:UpdatePanel ID="upnl06AWRDDtl" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
						<ContentTemplate>
							<!--begin::Card header-->
							<div class="card-header">
								<!--begin::Card header-->
								<div class="card-title fs-3 fw-bolder">Contract</div>
								<!--end::Card header-->
							</div>
							<!--end::Card header-->
							<!--begin::Card header-->
							<div class="card-header">
								<div class="d-flex">
									<asp:LinkButton ID="lbtn06AWRDDtlEdit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
								</div>
							</div>
							<!--end::Card header-->
							<div class="card-body">
								<!--begin::Contract Detail-->
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Contractor</span>
									<asp:Label ID="lbl06AWRDDtlContractor" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Category</span>
									<asp:Label ID="lbl06AWRDDtlCategory" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Type</span>
									<asp:Label ID="lbl06AWRDDtlType" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">No.</span>
									<asp:Label ID="lbl06AWRDDtlNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Price</span>
									<asp:Label ID="lbl06AWRDDtlPrice" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">VAT</span>
									<asp:Label ID="lbl06AWRDDtlVAT" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">EWT</span>
									<asp:Label ID="lbl06AWRDDtlEWT" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Downpayment</span>
									<asp:Label ID="lbl06AWRDDtlDP" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Retention Fee</span>
									<asp:Label ID="lbl06AWRDDtlRF" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Prior Start</span>
									<asp:Label ID="lbl06AWRDDtlPriorStart" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:Label ID="lbl06AWRDDtlStatus" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Awarded</span>
									<asp:Label ID="lbl06AWRDDtlDate" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
							<!--end::Contract Detail-->
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
	
		<!--begin::Modal Find Project -->
		<div id="mdl01Estimate" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Find record - Estimate
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
                                <input id="tbx01FindEstimate" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						    <!--begin::list-->
                            <table id="gv01Estimate" class="table table-no-border table-row-bordered table-hover align-middle w-100">
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
							<span id="spn01Note" runat="server" class="input-group-text input-group-text-top min-w-150px">Notes</span>
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
		
		<!--begin::Modal Contract-->
		<asp:UpdatePanel ID="mdl06AWRDDtlUpd" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Update Contract</h5>
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
							<span class="input-group-text min-w-150px">Contractor</span>
							<asp:DropDownList ID="ddl06AWRDDtlUpdContractor" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select contractor</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Contractor</span>
							<asp:DropDownList ID="ddl06AWRDDtlUpdCategory" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select category</asp:ListItem>
								<asp:ListItem Value="Job Order">Job Order</asp:ListItem>
								<asp:ListItem Value="Contract Agreement">Contract Agreement</asp:ListItem>
								<asp:ListItem Value="Variation Order">Variation Order</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Type</span>
							<asp:DropDownList ID="ddl06AWRDDtlUpdType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select a type</asp:ListItem>
								<asp:ListItem Value="OSM">OSM</asp:ListItem>
								<asp:ListItem Value="Packaged">Packaged</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">No.</span>
							<asp:TextBox ID="tbx06AWRDDtlUpdNo" runat="server" class="form-control" Placeholder="Add contract no."></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Price</span>
							<input id="tbx06AWRDDtlUpdPrice" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Type</span>
							<asp:DropDownList ID="ddl06AWDDtlUpdType2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a type</asp:ListItem>
								<asp:ListItem Value="With VAT">With VAT</asp:ListItem>
								<asp:ListItem Value="Non-VAT">Non-VAT</asp:ListItem>
							</asp:DropDownList>
						</div>
						<asp:Panel ID="pnl06AWDDtlUpdVAT" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px">VAT</span>
							<input id="tbx06AWRDDtlUpdVAT" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</asp:Panel>
						<asp:Panel ID="pnl06AWDDtlUpdEWT" runat="server" class="input-group input-group-sm mb-2" Visible="false">
							<span class="input-group-text min-w-150px">EWT</span>
							<input id="tbx06AWRDDtlUpdEWT" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</asp:Panel>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Down Payment</span>
							<input id="tbx06AWRDDtlUpdDP" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Retention Fee</span>
							<input id="tbx06AWRDDtlUpdRF" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Prior Start</span>
							<input id="tbx06AWRDDtlUpdPriorStart" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Status</span>
							<asp:DropDownList ID="ddl06AWRDDtlUpdStatus" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select a status</asp:ListItem>
								<asp:ListItem Value="For Award">For Award</asp:ListItem>
								<asp:ListItem Value="Awarded">Awarded</asp:ListItem>
								<asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Date Awarded</span>
							<input id="tbx06AWRDDtlUpdDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn06AWRDDtlUpdOk" runat="server" class="btn btn-primary">Save</asp:LinkButton>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Contract-->
				
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

        //function related to this page only
		function ddl01Category(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;

            var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
            var hf01Subdivision = document.getElementById("ContentPlaceHolder1_hf01Subdivision");
            var hf01Phase = document.getElementById("ContentPlaceHolder1_hf01Phase");
            var hf01Block = document.getElementById("ContentPlaceHolder1_hf01Block");
            var hf01Lot = document.getElementById("ContentPlaceHolder1_hf01Lot");
            var hf01Branch = document.getElementById("ContentPlaceHolder1_hf01Branch");

            hf01Subdivision.value = "";
            hf01Phase.value = "";
            hf01Block.value = "";
            hf01Lot.value = "";
            hf01Branch.value = "";

            var div01House = document.getElementById("ContentPlaceHolder1_div01House");
            var div01Batch = document.getElementById("ContentPlaceHolder1_div01Batch");
            var div01Theme = document.getElementById("ContentPlaceHolder1_div01Theme");
			var div01Budget = document.getElementById("ContentPlaceHolder1_div01Budget");
			var div01Renovation = document.getElementById("ContentPlaceHolder1_div01Renovation");
			var div01Project = document.getElementById("ContentPlaceHolder1_div01Project");

			tbx01Project.value = "";
            div01House.style.display = "none";
            div01Batch.style.display = "none";
            div01Theme.style.display = "none";
			div01Budget.style.display = "none";
			div01Project.style.display = "";

			if (selectValue == "Shell to Premium") {
                div01House.style.display = "";
            }
			else if (selectValue == "Shell to Complete") {
                div01House.style.display = "";
			}
			else if (selectValue == "Renovation") {
				div01Renovation.style.display = "";
				div01Project.style.display = "none";
			}
			else if (selectValue == "Classic to Premium") {
                div01House.style.display = "";
			}
			else if (selectValue == 'Premium to Classic') {
				div01House.style.display = "";
			}
			else if (selectValue == "Shell to Classic") {
                div01House.style.display = "";
            }
            else if (selectValue == "Shell to Basic") {
                div01House.style.display = "";
            }
            else if (selectValue == "Structural Consultant - Amenities") {
                div01Budget.style.display = "";
            } else if (selectValue == "Structural Consultant - House Unit") {
                div01House.style.display = "";
            } else if (selectValue == "Land Scape Unit") {
                div01House.style.display = "";
                div01Budget.style.display = "";
            } else if (selectValue == "Land Scape Project Restoration") {
                div01Budget.style.display = "";
            } else if (selectValue == "Land Scape Project New") {
                div01Budget.style.display = "";
            } else if (selectValue == "Interior Designer") {
                div01House.style.display = "";
                div01Theme.style.display = "";
                div01Budget.style.display = "";
            } else if (selectValue == "House Repair") {
                div01House.style.display = "";
            } else if (selectValue == "Initial Inspection") {
                div01House.style.display = "";
            } else if (selectValue == "House Construction") {
                div01House.style.display = "";
                div01Batch.style.display = "";
            } else if (selectValue == "Take-Over Unit") {
                div01House.style.display = "";
                div01Batch.style.display = "";
            } else if (selectValue == "Electrical Consultant") {
                div01House.style.display = "";
            } else if (selectValue == "DOLE Application - Model House") {
                div01House.style.display = "";
            } else if (selectValue == "Basic to Complete") {
                div01House.style.display = "";
            } else {
                div01House.style.display = "none";
                div01Batch.style.display = "none";
                div01Theme.style.display = "none";
				div01Budget.style.display = "none";
				div01Renovation.style.display = "none";
				div01Project.style.display = "";
            }
		}
        const nodeList = document.querySelectorAll(".disable-check");
        for (let i = 0; i < nodeList.length; i++) {
            nodeList[i].onclick = (e) => {
                e.preventDefault();
            }
        }
        //function related to this page only

        //find poject
        var input_project = document.getElementById("tbx01FindProject");
        input_project.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                FindProject(input_project.value);
            }
        });
		function FindProject(Find) {
			$('#mdl01FindProject').modal('show');

			var selectIndex = document.getElementById("ContentPlaceHolder1_ddl01Category").selectedIndex;
			var selectValue = document.getElementById("ContentPlaceHolder1_ddl01Category").options[selectIndex].text;

            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000009',
					'Type': 'Search Project',
                    'Category': selectValue,
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
            var selectIndex = document.getElementById("ContentPlaceHolder1_ddl01Category").selectedIndex;
            var selectValue = document.getElementById("ContentPlaceHolder1_ddl01Category").options[selectIndex].text;

            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'FRM000009',
					'Type': 'Select Project',
                    'Category': selectValue,
                    'Code': Code
                },
				success: function (response) {
                    var tbx01Project = document.getElementById("ContentPlaceHolder1_tbx01Project");
                    var hf01Subdivision = document.getElementById("ContentPlaceHolder1_hf01Subdivision");
                    var hf01Phase = document.getElementById("ContentPlaceHolder1_hf01Phase");
                    var hf01Block = document.getElementById("ContentPlaceHolder1_hf01Block");
                    var hf01Lot = document.getElementById("ContentPlaceHolder1_hf01Lot");
                    var hf01Branch = document.getElementById("ContentPlaceHolder1_hf01Branch");
                    tbx01Project.value = ""
                    hf01Subdivision.value = "";
                    hf01Phase.value = "";
                    hf01Block.value = "";
                    hf01Lot.value = "";
                    hf01Branch.value = "";
                    tbx01Project.value = response[0].Project;
                    hf01Subdivision.value = response[0].Subdivision;
                    hf01Phase.value = response[0].Phase;
                    hf01Block.value = response[0].Block;
                    hf01Lot.value = response[0].Lot;
                    hf01Branch.value = response[0].Branch;
                    $('#mdl01FindProject').modal('hide');
                },
            });
        };
		//find poject

		//find estimate
		function fn01Estimate() {
			$("#mdl01Estimate").modal("show");
            var selectIndex = document.getElementById("ContentPlaceHolder1_ddl01Category").selectedIndex;
			var selectValue = document.getElementById("ContentPlaceHolder1_ddl01Category").options[selectIndex].text;

			if (selectValue != "") {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/FRM/FRM000009HND.ashx",
                    data: {
                        'pFormCode': 'FRM000009',
                        'pType': 'Get Record - Estimate',
                        'pCategory': selectValue
                    },
					success: function (response) {
                        var gv01Estimate = document.getElementById("gv01Estimate");

                        //Remove all rows.
                        var rowCount = gv01Estimate.rows.length;
                        for (var i = rowCount - 1; i > 0; i--) {
                            gv01Estimate.deleteRow(i);
                        }

                        //Add the data rows.
                        for (var i = 0; i < response.length; i++) {
                            row = gv01Estimate.insertRow(-1);
                            var cell = row.insertCell(-1);
                            cell.innerHTML = response[i].Bullet;
                            cell.setAttribute("class", "mw-5px min-w-5px");

                            cell = row.insertCell(-1);
                            cell.innerHTML = response[i].Data;
                            cell.setAttribute("class", "w-100");
                        }
                    }
                });
			}
		};
        $(document).ready(function () {
            $("#tbx01FindEstimate").on("keyup input", function () {
                var filter = $(this).val().toLowerCase();
                var table = document.getElementById("gv01Estimate");
                if (!table) return;

                var rows = table.getElementsByTagName("tr");
                for (var i = 1; i < rows.length; i++) {
                    var text = rows[i].textContent || rows[i].innerText;
                    rows[i].style.display = text.toLowerCase().indexOf(filter) > -1 ? "" : "none";
                }
            });
        });
		//find estimate

		//get estimate
		function fn01GetEstimate(pCode, pTitle) {
			document.getElementById("ContentPlaceHolder1_tbx01Estimate").value = pTitle;
			document.getElementById("ContentPlaceHolder1_hf01EstimateCode").value = pCode;
            $("#mdl01Estimate").modal("hide");
		};
		//get estimate

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
            var $gv01FindProject = $('#gv01FindProject tbody tr');
            $('#tbx01FindProject').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gv01FindProject.show().filter(function () {
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

		//checkbox
		function cbx01IsHDMF01(Obj) {
			var checkBox = Obj.checked;
			if (checkBox) {
				document.getElementById("ContentPlaceHolder1_div01Type").style.display = "";
                document.getElementById("ContentPlaceHolder1_div01Status").style.display = "";
			} else {
                document.getElementById("ContentPlaceHolder1_div01Type").style.display = "none";
                document.getElementById("ContentPlaceHolder1_div01Status").style.display = "none";
			};
		};
		//checkbox

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

                //date
                $('[data-kt-repeater="timepicker"]').flatpickr({
                    enableTime: true,
                    noCalendar: true,
                    dateFormat: "h:i K"
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
