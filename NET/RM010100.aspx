<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="RM010100.aspx.vb" Inherits="NET.RM010100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
						<li class="breadcrumb-item text-white">Form</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Receive Materials</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<li class="breadcrumb-item text-white">Details</li>
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->
		
		<!--begin::Title-->
		<asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional" class="card card-flush mb-5 ">
		<ContentTemplate>
			<!--begin::title-->
			<div class="card-header pt-10">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
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
			</div>
			<!--end::title-->
			<!--begin::menu-->
			<div class="card-body pb-0">
				<!--begin::Navs-->
				<div class="d-flex overflow-auto h-55px">
					<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1 active" title="Overview" data-bs-toggle="tab" href="#Menu01_TabContent"><i class="las la-file-alt fs-3x"></i></a>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1 position-relative" title="Files" data-bs-toggle="tab" href="#Menu02_TabContent">
								<i class="las la-paperclip fs-3x"></i>
								<span id="blink01Attachment" runat="server" class="bullet bullet-dot bg-warning h-8px w-8px position-absolute translate-middle top-10 start-50 animation-blink" style="display:none"></span>
							</a>
						</li>
						<!--end::Nav item-->
					</ul>
				</div>
				<!--begin::Navs-->
			</div>
			<!--end::menu-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Title-->
		
		<!--begin::Content-->
		<div class="card card-flush mb-5" >
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
						<div class="card-body">
							<!--begin::Dtl-->
							<asp:Panel ID="pnl01Dtl" runat="server" Visible="false">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">RR No.</span>
									<asp:Label ID="lbl01RRNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Vendor</span>
									<asp:Label ID="lbl01Vendor" runat="server" class="form-control">-</asp:Label>
								</div>
							</asp:Panel>
						</div>
						<!--end::Dtl-->
					</ContentTemplate>
					</asp:UpdatePanel>
					<asp:UpdatePanel ID="upnl06RMDtl" runat="server" UpdateMode="Conditional">
					<ContentTemplate>
						<!--begin::Card header-->
						<div class="card-header">
							<!--begin::Card header-->
							<div class="card-title fs-3 fw-bolder">Materials</div>
							<!--end::Card header-->
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<!--begin::Transaction Log Details-->
							<div class="table-responsive">
								<asp:GridView ID="gv06RMDtl" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowFooter="true">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="PR No.">
										<ItemTemplate>
											<%# Eval("PRNo") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="SI/DR No.">
										<ItemTemplate>
											<%# Eval("SIDRNo") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Particular">
										<ItemTemplate>
											<div class="min-w-300px mw-300px">
												<span class=" nowrap-300px"><%# Eval("ItemName") %></span>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px mw-300px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Qty.">
										<ItemTemplate>
											<%# Eval("Qty") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="UOM">
										<ItemTemplate>
											<%# Eval("UMInit") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Contractor">
										<ItemTemplate>
											<%# Eval("Contractor") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Type">
										<ItemTemplate>
											<%# Eval("Type") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px" />
										<ItemStyle CssClass="nowrap-auto align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Remarks">
										<ItemTemplate>
											<div class="min-w-250px mw-250px">
												<span class=" nowrap-240px"><%# Eval("Remarks") %></span>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-250px mw-250px" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							<!--end::Transaction Log Details-->
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
			</div>
			<!--end:  Content-->
		</div>
		<!--end::Content-->
		
    </div>
    <script type="text/javascript">

		function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {
				// Literal
				var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
			});
		};
    </script>
</asp:Content>
