<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC020200.aspx.vb" Inherits="NET.ACC020200" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Account</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">HRMS and Payroll</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Leave Status</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->

		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
				
		<!--begin::Content-->
		<asp:UpdatePanel ID="upnlLeave" runat="server" UpdateMode="Conditional" class="row">
		<ContentTemplate>
			<div class="col-lg-8 col-xl-8 col-xxl-8 ml-auto mr-auto">
				<div class="card">
					<!--begin::title-->
					<div class="card-header pt-5 pb-5">
						<div class="d-flex align-items-center">
							<!--begin::Icon-->
							<div class="symbol me-5">
								<img src="Assets/media/svg/apps/ACC020200.svg" alt="" />
							</div>
							<!--end::Icon-->
							<!--begin::Title-->
							<div class="d-flex flex-column">
								<h2 class="mb-1">Leave Status</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<table class="table align-middle">
							<thead>
								<tr class="w-100">
									<th>
										<div class="d-flex flex-row">
											<div class="d-flex flex-column flex-row-auto" style="width:calc(100% - 300px);">
												Type
											</div>
											<div class="d-flex flex-column flex-row-auto min-w-100px">
												Credit
											</div>
											<div class="d-flex flex-column flex-row-auto min-w-100px">
												Used
											</div>
											<div class="d-flex flex-column flex-row-auto min-w-100px">
												Balance
											</div>
										</div>
									</th>
								</tr>
								<!--end::Table row-->
							</thead>
							<!--end::Table head-->
							<!--begin::Table body-->
							<tbody>
								<tr class="w-100">
									<td>
										<div class="accordion accordion-icon-toggle" id="divHdrVL">
											<div class="accordion-header collapsed" data-bs-toggle="collapse" data-bs-target="#ContentPlaceHolder1_divDtlVL">
												<div class="d-flex flex-row">
													<div class="d-flex flex-column flex-row-auto" style="width:calc(100% - 300px);">
														Vacation Leave
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblVLCredit" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblVLUsed" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblVLBalance" runat="server"></asp:Label>
													</div>
												</div>
											</div>
											<div id="divDtlVL" runat="server" class="collapse pt-5" data-bs-parent="#divHdrVL">
				
											</div>
										</div>
									</td>
								</tr>
								<tr class="w-100">
									<td>
										<div class="accordion accordion-icon-toggle" id="divHdrSL">
											<div class="accordion-header collapsed" data-bs-toggle="collapse" data-bs-target="#ContentPlaceHolder1_divDtlSL">
												<div class="d-flex flex-row">
													<div class="d-flex flex-column flex-row-auto" style="width:calc(100% - 300px);">
														Sick Leave
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblSLCredit" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblSLUsed" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblSLBalance" runat="server"></asp:Label>
													</div>
												</div>
											</div>
											<div id="divDtlSL" runat="server" class="collapse" data-bs-parent="#divHdrSL">
												
											</div>
										</div>
									</td>
								</tr>
								<tr class="w-100">
									<td>
										<div class="accordion accordion-icon-toggle" id="divHdrPML">
											<div class="accordion-header collapsed" data-bs-toggle="collapse" data-bs-target="#ContentPlaceHolder1_divDtlPML">
												<div class="d-flex flex-row">
													<div class="d-flex flex-column flex-row-auto" style="width:calc(100% - 300px);">
														Paternity / Maternity Leave
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblPMLCredit" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblPMLUsed" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblPMLBalance" runat="server"></asp:Label>
													</div>
												</div>
											</div>
											<div id="divDtlPML" runat="server" class="collapse" data-bs-parent="#divHdrPML">
												
											</div>
										</div>
									</td>
								</tr>
								<tr class="w-100">
									<td>
										<div class="accordion accordion-icon-toggle" id="divHdrSPL">
											<div class="accordion-header collapsed" data-bs-toggle="collapse" data-bs-target="#ContentPlaceHolder1_divDtlSPL">
												<div class="d-flex flex-row">
													<div class="d-flex flex-column flex-row-auto" style="width:calc(100% - 300px);">
														Solo Parent Leave
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblSPLCredit" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblSPLUsed" runat="server"></asp:Label>
													</div>
													<div class="d-flex flex-column flex-row-auto min-w-100px">
														<asp:Label ID="lblSPLBalance" runat="server"></asp:Label>
													</div>
												</div>
											</div>
											<div id="divDtlSPL" runat="server" class="collapse" data-bs-parent="#divHdrSPL">
												
											</div>
										</div>
									</td>
									<tr class="w-100">
										<td>
											<div class="accordion accordion-icon-toggle" id="divHdrBL">
												<div class="accordion-header collapsed" data-bs-toggle="collapse" data-bs-target="#ContentPlaceHolder1_divDtlBL">
													<div class="d-flex flex-row">
														<div class="d-flex flex-column flex-row-auto" style="width:calc(100% - 300px);">
															Bereavement Leave
														</div>
														<div class="d-flex flex-column flex-row-auto min-w-100px">
															<asp:Label ID="lblBLCredit" runat="server"></asp:Label>
														</div>
														<div class="d-flex flex-column flex-row-auto min-w-100px">
															<asp:Label ID="lblBLUsed" runat="server"></asp:Label>
														</div>
														<div class="d-flex flex-column flex-row-auto min-w-100px">
															<asp:Label ID="lblBLBalance" runat="server"></asp:Label>
														</div>
													</div>
												</div>
												<div id="divDtlBL" runat="server" class="collapse" data-bs-parent="#divHdrBL">
													
												</div>
											</div>
										</td>
									</tr>
								</tr>
							</tbody>
							<!--end::Table body-->
						</table>
						<!--end::Table-->
					</div>
				</div>
			</div>
		<!--end::Content-->
		</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<!--end::Content-->

</asp:Content>
