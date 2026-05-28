<%@ Page Title="Agent Masterlist" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SLS010000.aspx.vb" Inherits="NET.SLS010000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--begin::Post-->
    <div class="content flex-row-fluid" id="kt_content">

		<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white my-1 fs-3">Sales Admin</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Agent Monitoring</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Agent Masterlist</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Toolbar-->
				<div class="d-flex flex-wrap flex-stack">
					<!--begin::Controls-->
					<div class="d-flex flex-wrap my-1">
						<!--begin::Tab nav-->
						<ul class="nav nav-pills me-5">
							<li class="nav-item m-0">
								<a href="SLS010000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Agent Masterlist">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/agent-masterlist.svg" alt="agent-masterlist" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS020000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Seller Management">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/seller-management.svg" alt="seller-management" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS030000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Reservation Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/reservation-monitoring.svg" alt="reservation-monitoring" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS040000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Lot Inventory Masterlist">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/lot-inventory-masterlist.svg" alt="lot-inventory-masterlist" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="SLS050000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Sales Monitoring">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sales-monitoring1.svg" alt="sales-monitoring" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="SLS060000" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Seller's Ranking" >
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<div class="symbol symbol-25px">
										<img class="mw-125px mw-lg-125px" src="assets/media/svg/apps/sellers-ranking.svg" alt="sellers-ranking" />
									</div>
									<!--end::Svg Icon-->
								</a>
							</li>
						</ul>
						<!--end::Tab nav-->
					</div>
					<!--end::Controls-->
				</div>
				<!--end::Toolbar-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::Navbar-->
		<asp:UpdatePanel ID="upnlNavBar" runat="server" UpdateMode="Conditional" class="card mb-6 mb-xl-3">
		<ContentTemplate>
			<div class="col-lg-12">
				<div class="card card-flush h-lg-100">
					<div class="card-header">
						<div class="d-flex align-items-center">
							<%-- begin::header img --%>
							<div class="symbol me-5">
								<img id="imgProject" runat="server" class="mw-125px mw-lg-125px" src="assets/media/svg/apps/agent-masterlist.svg" alt="project-image" />
							</div>
							<%-- end::header img --%>
                            <%-- begin::title --%>
							<div class="d-flex flex-column">
								<span class="text-gray-800 fw-bolder fs-2 me-3">Agent Masterlist</span>
								<span class="text-muted fw-bold fs-7">Admin</span> 
							</div>
                            <%-- end::title --%>
						</div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Navbar-->

			<%-- begin::Seller Management --%>
			<asp:UpdatePanel ID="mdlAgentMstr" runat="server" UpdateMode="Conditional" class="row g-6 g-xl-9">
			<ContentTemplate>
				<%-- begin::gridview --%>
				<div class="col-lg-12">
					<div class="card card-flush h-lg-100">
						<div class="card-header border-0 pt-5">
							<h3 class="card-title align-items-start flex-column">
								<span class="card-label fs-4 fw-bolder mb-1">List of Agents</span>
								<!-- <span class="text-muted mt-1 fw-bold fs-7">Over 500 members</span> -->
							</h3>
							<div class="d-flex align-items-center position-relative my-1">
							<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
							<span class="svg-icon svg-icon-1 position-absolute ms-4">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
									<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
							<input id="tbxSearchAgents" type="text" data-kt-ecommerce-product-filter="search" class="form-control form-control-solid w-250px ps-14" placeholder="Search Record" />
								<button runat="server" type="button" data-bs-toggle="modal" data-bs-target="#ContentPlaceHolder1_mdlAddAgent" class="btn btn-primary ms-2"  data-kt-menu-placement="end">
									<svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="currentColor" class="bi bi-person-add" viewBox="0 0 16 16">
									  <path d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7m.5-5v1h1a.5.5 0 0 1 0 1h-1v1a.5.5 0 0 1-1 0v-1h-1a.5.5 0 0 1 0-1h1v-1a.5.5 0 0 1 1 0m-2-6a3 3 0 1 1-6 0 3 3 0 0 1 6 0M8 7a2 2 0 1 0 0-4 2 2 0 0 0 0 4"/>
									  <path d="M8.256 14a4.5 4.5 0 0 1-.229-1.004H3c.001-.246.154-.986.832-1.664C4.484 10.68 5.711 10 8 10q.39 0 .74.025c.226-.341.496-.65.804-.918Q8.844 9.002 8 9c-5 0-6 3-6 4s1 1 1 1z"/>
									</svg>
								</button>
							</div>
						</div>
						<div class="card-body py-3">
							<!--begin::Gridview-->
							<div style="overflow-x:auto; scrollbar-width: thin;">
								<asp:GridView ID="gvAgents" runat="server" class="table table-no-border table-row-bordered tscroll table-hover align-middle w-100" AutoGenerateColumns="False" >
								<Columns>
									<asp:TemplateField HeaderText="Agents">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<span onclick="ViewAgentDetail(this)" data-value='<%# Eval("Link") %>' class="d-flex flex-column min-w-400px w-100 pointer" >
															<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Name") %></span>
															<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("TIN") %> | <%# Eval("Email") %></span>
														</span>
													</div>
												</div>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-500px" />
										<ItemStyle CssClass="mw-5px min-w-500px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Remarks">
										<ItemTemplate>
											<div class="overlay overflow-hidden">
												<div class="overlay-wrapper">
													<div class="d-flex align-items-center w-100">
														<asp:UpdatePanel ID="upnlRemarks" runat="server" UpdateMode="Conditional" class="d-flex flex-column min-w-300px">
														<ContentTemplate>
															<asp:Label ID="lblRemarks" runat="server" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" CssClass="text-dark fw-bold fs-6" Text='<%# Eval("Remarks") %>'></asp:Label>
															<%--<span class="text-muted fw-bold text-muted d-block fs-7">Remarks</span>--%>
														</ContentTemplate>
														</asp:UpdatePanel>
													</div>
												</div>
											</div>
											<%--<asp:Label ID="lblLotCode" runat="server" Text='<%# Eval("LotCode") %>' Visible="false"></asp:Label>--%>
										</ItemTemplate>
										<HeaderStyle CssClass="mw-5px min-w-400px" />
										<ItemStyle CssClass="mw-5px min-w-400px" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							<!--end::Gridview-->
						</div>
					</div>
				</div>
				<%-- end::gridview --%>

				<%-- begin::Modals --%>
					<%-- begin::seller detail modal --%>
					<div id="kt_sellerdtl_modal" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
						<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
							<div class="modal-content">
								<div class="modal-header">
									<h5 class="modal-title">Seller Details</h5>
									<!--begin::Close-->
									<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
									<div class="card-body py-3">
										<%-- begin:: Input group --%>
										<div class="row mb-3">
											<div class="input-group input-group-sm mb-2" style="display:none;">
												<input id="tbxAgentCode" runat="server" type="text" class="form-control" readonly="" style="display:none;"/>
											</div>
											<div class="input-group input-group-sm mb-2">
												<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Name">
													<img src="assets/media/svg/apps/name.svg" alt="" />
												</div>
												<input id="tbxFirstName" runat="server" type="text" class="form-control" readonly="" />
												<input id="tbxMiddleName" runat="server" type="text" class="form-control" readonly="" />
												<input id="tbxLastName" runat="server" type="text" class="form-control" readonly="" />
											</div>
											<div class="input-group input-group-sm mb-2">
												<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Email">
													<img src="assets/media/svg/apps/email.svg" alt="" />
												</div>
												<input id="tbxEmail" runat="server" type="text" class="form-control" readonly="" />
											</div>
											<%--<div class="input-group input-group-sm mb-2">
												<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Type">
													<img src="assets/media/svg/apps/type.svg" alt="" />
												</div>
												<input id="tbxType" runat="server" type="text" class="form-control" readonly="" />
											</div>
											<div class="input-group input-group-sm mb-2">
												<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Group">
													<img src="assets/media/svg/apps/group.svg" alt="" />
												</div>
												<input id="tbxGroup" runat="server" type="text" class="form-control" readonly="" />
											</div>--%>
											<div class="input-group input-group-sm mb-2">
												<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Status">
													<img src="assets/media/svg/apps/status.svg" alt="" />
												</div>
												<input id="tbxStatus" runat="server" type="text" class="form-control" readonly="" />
											</div>
											<div class="input-group input-group-sm mb-2">
												<div class="symbol symbol-35px me-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Date Created">
													<img src="assets/media/svg/apps/datecreated.svg" alt="" />
												</div>
												<input id="tbxDateCreated" runat="server" type="text" class="form-control" readonly="" />
											</div>
										<%-- end:: Input group --%>
									</div>
				
										<%-- begin:: confirm --%>
										<div class="d-flex align-items-center py-3 py-md-1 gap-4">
											<asp:Linkbutton id="btnApprove" runat="server" OnClientClick="confirmApprove(event); return false;" class="btn btn-primary">Approve</asp:Linkbutton>
											<asp:Linkbutton id="btnReject" runat="server" OnClientClick="rejectSeller(event); return false;" class="btn btn-light-danger">Reject</asp:Linkbutton>
											<%--<a class="btn btn-primary" role="button">Approve</a>
											<a class="btn btn-light-danger" role="button">Reject</a>--%>
										</div>
										<%-- end:: confirm --%>
								</div>
							</div>
						</div>
					</div>
					</div>
					<%-- end::seller detail modal --%>
				<%-- end::Modals --%>

			</ContentTemplate>
			</asp:UpdatePanel>
			<%-- end::Seller Management --%>

		<%-- begin::add agent modal --%>
		<asp:UpdatePanel id="mdlAddAgent" runat="server" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
					<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Agent</h5>
						<!--begin::Close-->
						<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
						<!--begin::table-->
						<div class="card-body py-3">
							<%-- begin:: Input group --%>
							<div class="row mb-3">
								<div class="card-title fs-5 fw-bolder">Fullname</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-100px required">Agent</span>
										<input id="inpFirstName" runat="server" type="text" class="form-control" placeholder="Enter first name" />
										<input id="inpMiddleName" runat="server" type="text" class="form-control" placeholder="Enter middle name" />
										<input id="inpLastName" runat="server" type="text" class="form-control" placeholder="Enter last name" />
									</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-100px required">Email</span>
										<asp:TextBox ID="tbxPersonalEmail" runat="server" TextMode="Email" class="form-control" placeholder="Personal Email"  autocomplete="off"></asp:TextBox>
									</div>
								<div class="card-title fs-5 fw-bolder">Address</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-100px required">Address</span>
										<input id="inpAddress" runat="server" type="text" class="form-control" placeholder="Enter address" />
									</div>
								<div class="card-title fs-5 fw-bolder">Tax</div>
									<div class="input-group input-group-sm mb-2">
										<span class="input-group-text min-w-100px required">TIN</span>
										<input id="inpTIN" runat="server" type="text" class="form-control" placeholder="Enter TIN" />
									</div>
								<%-- end:: Input group --%>
							</div>
	
							<%-- begin:: confirm --%>
							<div class="d-flex align-items-center py-3 py-md-1 gap-4">
								<asp:Linkbutton ID="lbtnSubmit" runat="server" class="btn btn-primary">Submit</asp:Linkbutton>
								<%--<asp:Linkbutton id="lbtn" runat="server" OnClientClick="rejectSeller(event); return false;" class="btn btn-light-danger">Reject</asp:Linkbutton>--%>
								<%--<a class="btn btn-primary" role="button">Approve</a>
								<a class="btn btn-light-danger" role="button">Reject</a>--%>
							</div>
							<%-- end:: confirm --%>

						</div>
						</div>
						<!--end::table-->
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<%-- end::add agent modal --%>

		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlDialogBox" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Message</h5>
							<!--begin::Close-->
							<div class="btn btn-sm btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->

		<%-- begin::seller detail modal --%>
		<div id="mdlAgentDetail" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-1000px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Agent Detail</h5>
						<div class="d-flex align-items-center position-relative my-1">
                            <%-- begin::edit --%>
							<button id="btnEdit" onclick="toggleEdit(); return false;"  runat="server" type="button" class="btn btn-warning ms-2" data-kt-menu-placement="end">
								<svg xmlns="http://www.w3.org/2000/svg" width="17" height="17" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
								  <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
								  <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
								</svg>
							</button>
                            <%-- end::edit --%>
                            <%-- begin::save --%>
							<asp:Linkbutton id="lbtnSave" runat="server" OnClientClick="confirmSave(event); return false;" class="btn btn-primary d-none">
								<svg xmlns="http://www.w3.org/2000/svg" width="17" height="17" fill="currentColor" class="bi bi-floppy" viewBox="0 0 16 16">
								  <path d="M11 2H9v3h2z"/>
								  <path d="M1.5 0h11.586a1.5 1.5 0 0 1 1.06.44l1.415 1.414A1.5 1.5 0 0 1 16 2.914V14.5a1.5 1.5 0 0 1-1.5 1.5h-13A1.5 1.5 0 0 1 0 14.5v-13A1.5 1.5 0 0 1 1.5 0M1 1.5v13a.5.5 0 0 0 .5.5H2v-4.5A1.5 1.5 0 0 1 3.5 9h9a1.5 1.5 0 0 1 1.5 1.5V15h.5a.5.5 0 0 0 .5-.5V2.914a.5.5 0 0 0-.146-.353l-1.415-1.415A.5.5 0 0 0 13.086 1H13v4.5A1.5 1.5 0 0 1 11.5 7h-7A1.5 1.5 0 0 1 3 5.5V1H1.5a.5.5 0 0 0-.5.5m3 4a.5.5 0 0 0 .5.5h7a.5.5 0 0 0 .5-.5V1H4zM3 15h10v-4.5a.5.5 0 0 0-.5-.5h-9a.5.5 0 0 0-.5.5z"/>
								</svg>
							</asp:Linkbutton>
                            <%-- end::save --%>
                            <%-- end:: edit --%>
							<!--begin::Close-->
							<div id="btnClose" onclick="toggleClose(); return false;" class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
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
						<div class="card-body py-3">
							<div class="row mb-3">
								<div class="card-title fs-5 fw-bolder">Personal Data<div id="mdlTitle" runat="server" class="d-none" style="display:inline;"> - Edit</div></div>
									<asp:Panel ID="pnlDtl" CssClass="" runat="server">
										<div class="input-group input-group-sm mb-2" style="display:none;">
											<input id="tbxAgentCodeDtl" runat="server" type="text" class="form-control" readonly="" style="display:none;"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px ">Fullname</span>
											<asp:TextBox ID="tbxAgentFName" runat="server" class="form-control" placeholder="Firstname" readonly="true" ></asp:TextBox>
											<asp:TextBox ID="tbxAgentMName" runat="server" class="form-control" placeholder="Middlename" readonly="true" ></asp:TextBox>
											<asp:TextBox ID="tbxAgentLName" runat="server" class="form-control" placeholder="Lastname" readonly="true" ></asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px ">Email</span>
											<asp:TextBox ID="tbxAgentEmail" runat="server" class="form-control" placeholder="Email" readonly="true" ></asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px ">Address</span>
											<asp:TextBox ID="tbxAgentAddress" runat="server" class="form-control" placeholder="Address" readonly="true" ></asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px ">TIN</span>
											<asp:TextBox ID="tbxAgentTIN" runat="server" class="form-control" placeholder="TIN" readonly="true" ></asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
											<asp:TextBox ID="tbxAgentRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" placeholder="Remarks" TextMode="MultiLine" readonly="true" ></asp:TextBox>
										</div>
									</asp:Panel>
									<asp:Panel ID="pnlEdit" CssClass="d-none" runat="server">
										<div class="input-group input-group-sm mb-2" style="display:none;">
											<input id="tbxAgentCodeDtl1" runat="server" type="text" class="form-control" readonly="" style="display:none;"/>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Fullname</span>
											<asp:TextBox ID="tbxAgentFName1" runat="server" class="form-control" placeholder="Firstname">-</asp:TextBox>
											<asp:TextBox ID="tbxAgentMName1" runat="server" class="form-control" placeholder="Middlename">-</asp:TextBox>
											<asp:TextBox ID="tbxAgentLName1" runat="server" class="form-control" placeholder="Lastname">-</asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px required">Email</span>
											<asp:TextBox ID="tbxAgentEmail1" runat="server" class="form-control" placeholder="Email">-</asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px ">Address</span>
											<asp:TextBox ID="tbxAgentAddress1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px ">TIN</span>
											<asp:TextBox ID="tbxAgentTIN1" runat="server" class="form-control" readonly="true">-</asp:TextBox>
										</div>
										<div class="input-group input-group-sm mb-2">
										<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
											<asp:TextBox ID="tbxAgentRemarks1" runat="server" class="form-control h-75px min-h-75px mh-75px" readonly="true" TextMode="MultiLine">-</asp:TextBox>
										</div>
									</asp:Panel>
								<%-- end:: Input group --%>
							</div>
					</div>
				</div>
			</div>
			</div>
		</div>
		<%-- end::seller detail modal --%>

		<asp:HiddenField ID="hfScrollPosition" runat="server" />

    </div>
    <%-- end::Post --%>

	<script type="text/javascript">

		//edit btn
		function toggleEdit() {
          $('#<%= btnEdit.ClientID %>').addClass('d-none'); 
          $('#<%= pnlDtl.ClientID %>').addClass('d-none'); 
          $('#<%= pnlEdit.ClientID %>').removeClass('d-none'); 
			document.getElementById("ContentPlaceHolder1_lbtnSave").classList.remove('d-none'); 
            document.getElementById("ContentPlaceHolder1_mdlTitle").classList.remove('d-none'); 
			var AgentCode = document.getElementById("ContentPlaceHolder1_tbxAgentCodeDtl").value; 
            EditAgentDetail(AgentCode)
        }
        function EditAgentDetail(AgentCode) {
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS010000',
                    'Type': 'Edit Agent Detail (AgentCode)',
                    'AgentCode': AgentCode
                },
				success: function (response) {
                    var tbxAgentCodeDtl1 = document.getElementById("ContentPlaceHolder1_tbxAgentCodeDtl1");
                    var tbxAgentFName1 = document.getElementById("ContentPlaceHolder1_tbxAgentFName1");
                    var tbxAgentMName1 = document.getElementById("ContentPlaceHolder1_tbxAgentMName1");
                    var tbxAgentLName1 = document.getElementById("ContentPlaceHolder1_tbxAgentLName1");
                    var tbxAgentEmail1 = document.getElementById("ContentPlaceHolder1_tbxAgentEmail1");
                    var tbxAgentAddress1 = document.getElementById("ContentPlaceHolder1_tbxAgentAddress1");
                    var tbxAgentTIN1 = document.getElementById("ContentPlaceHolder1_tbxAgentTIN1");
                    var tbxAgentRemarks1 = document.getElementById("ContentPlaceHolder1_tbxAgentRemarks1");

                    tbxAgentCodeDtl1.value = response[0].AgentCodeDtl1;
                    tbxAgentFName1.value = response[0].AgentFName1;
                    tbxAgentMName1.value = response[0].AgentMName1;
                    tbxAgentLName1.value = response[0].AgentLName1;
                    tbxAgentEmail1.value = response[0].AgentEmail1;
                    tbxAgentAddress1.value = response[0].AgentAddress1;
                    tbxAgentTIN1.value = response[0].AgentTIN1;
                    tbxAgentRemarks1.value = response[0].AgentRemarks1;
                },
            });
		} //approve seller

		//save edited details
        function confirmSave(event) {
            event.preventDefault();
            Swal.fire({
                title: 'Are you sure?',
                text: 'You are about to update this agent.',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Save',
                cancelButtonText: 'Cancel'

        }).then((result) => {
            if (result.isConfirmed) {
                // Show success message before form submission
				__doPostBack('<%= lbtnSave.UniqueID %>', '');
				//toggleClose()
    //            $('#mdlAgentDetail').modal('show');
         } else {
					// If the user cancels, do nothing
					Swal.fire(
						'Cancelled',
						"Please review the changes you've made.",
						'error'
					);
				}
			});
        } 

		//close btn
		function toggleClose() {
          $('#<%= btnEdit.ClientID %>').removeClass('d-none');
          $('#<%= pnlDtl.ClientID %>').removeClass('d-none'); 
          $('#<%= pnlEdit.ClientID %>').addClass('d-none'); 
			document.getElementById("ContentPlaceHolder1_lbtnSave").classList.add('d-none');
			document.getElementById("ContentPlaceHolder1_mdlTitle").classList.add('d-none'); 
        }

        //view seller detail for approval - modal --------------------------------------------------------------------------------------------------
        function ViewAgentDetail(AgentCode) {
            AgentCode = AgentCode.getAttribute("data-value");
            $.ajax({
                type: "POST",
                url: "HND000006.ashx",
                data: {
                    'FormCode': 'SLS010000',
                    'Type': 'View Agent Detail (AgentCode)',
                    'AgentCode': AgentCode
                },
				success: function (response) {
					var tbxAgentCodeDtl = document.getElementById("ContentPlaceHolder1_tbxAgentCodeDtl");
                    var tbxAgentFName = document.getElementById("ContentPlaceHolder1_tbxAgentFName");
                    var tbxAgentMName = document.getElementById("ContentPlaceHolder1_tbxAgentMName");
                    var tbxAgentLName = document.getElementById("ContentPlaceHolder1_tbxAgentLName");
                    var tbxAgentEmail = document.getElementById("ContentPlaceHolder1_tbxAgentEmail");
                    var tbxAgentAddress = document.getElementById("ContentPlaceHolder1_tbxAgentAddress");
                    var tbxAgentTIN = document.getElementById("ContentPlaceHolder1_tbxAgentTIN");
                    var tbxAgentRemarks = document.getElementById("ContentPlaceHolder1_tbxAgentRemarks");

					tbxAgentCodeDtl.value = response[0].AgentCodeDtl;
                    tbxAgentFName.value = response[0].AgentFName;
                    tbxAgentMName.value = response[0].AgentMName;
                    tbxAgentLName.value = response[0].AgentLName;
                    tbxAgentEmail.value = response[0].AgentEmail;
                    tbxAgentAddress.value = response[0].AgentAddress;
                    tbxAgentTIN.value = response[0].AgentTIN;
                    tbxAgentRemarks.value = response[0].AgentRemarks;
                    $('#mdlAgentDetail').modal('show');
                },
            });
        }

        //table search
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var $gvAgents = $('#ContentPlaceHolder1_gvAgents tbody tr');
            $('#tbxSearchAgents').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $gvAgents.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
        }
        //table search

        //tbody scroll
        var $table = $('table.tscroll'), $bodyCells = $table.find('tbody tr:first').children(), colWidth;
        $(window).resize(function () {
            colWidth = $bodyCells.map(function () {
                return $(this).width();
            }).get();
            $table.find('thead tr').children().each(function (i, v) {
                $(v).width(colWidth[i]);
            });
        });
        function scrollPos() {
            var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");
            hfScrollPosition.value = document.querySelector('#ContentPlaceHolder1_gvAgents > tbody').scrollTop;
        }
        //tbody scroll

        //tbody scroll
        var $table = $('table.tscroll'), $bodyCells = $table.find('tbody tr:first').children(), colWidth;
        $(window).resize(function () {
            colWidth = $bodyCells.map(function () {
                return $(this).width();
            }).get();
            $table.find('thead tr').children().each(function (i, v) {
                $(v).width(colWidth[i]);
            });
        });
        //tbody scroll
		//form load
		function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox
			});
		}

    </script>

</asp:Content>
