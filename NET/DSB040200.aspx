<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB040200.aspx.vb" Inherits="NET.DSB040200" MaintainScrollPositionOnPostback = "true" %>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Work Order (Contract)</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Overview</li>
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
		
		<div class="row g-5 mb-5">
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Calmar Construction Inc.</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblCCITotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCCIGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCCIDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCCIDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvCCI" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Finance</span>
							<span class="text-muted fw-bold fs-6"">Departmant</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblFINTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblFINGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblFINDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblFINDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvFIN" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Marketing</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblMKTTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblMKTGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblMKTDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblMKTDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvMKT" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
		</div>
		
		<div class="row g-5 mb-5">
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Project Development</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblPDDTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblPDDGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblPDDDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblPDDDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvPDD" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Supply Chain Management</span>
							<span class="text-muted fw-bold fs-6"">Departmant</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblSCMTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblSCMGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblSCMDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblSCMDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvSCM" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">TSG-COS</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblTSGCOSTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGCOSGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGCOSDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGCOSDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvTSGCOS" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
		</div>
		
		<div class="row g-5 mb-5">
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">TSG-PAD</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblTSGPADTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPADGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPADDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPADDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvTSGPAD" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">TSG-PE</span>
							<span class="text-muted fw-bold fs-6"">Departmant</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblTSGPETotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPEGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPEDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPEDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvTSGPE" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">TSG-PMD</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblTSGPMDTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPMDGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPMDDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblTSGPMDDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvTSGPMD" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
		</div>
		
		<div class="d-flex justify-content-center row g-5 mb-5">
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Completed</span>
							<span class="text-muted fw-bold fs-6"">Form</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblCompletedTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCompletedGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCompletedDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCompletedDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvCompleted" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
			<div class="col-lg-4">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Cancelled</span>
							<span class="text-muted fw-bold fs-6"">Form</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lblCancelledTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCancelledGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCancelledDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lblCancelledDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gvCancelled" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
										</ItemTemplate>
										<ItemStyle />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <a href='<%# Eval("Link") %>' class="d-flex">
												<div class="symbol symbol-60px me-3">
													<img src='<%# Eval("AssignTo") %>'' alt="blank" />
												</div>
												<div class="flex-grow-1">
													<span class="text-gray-800 fw-bolder fs-6"><%# Eval("FormNo") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Project") %></span>
													<span class="text-muted fw-bold d-block fs-7"><%# Eval("Assigned") %> <%# Eval("DueDate") %></span>
												</div>
                                            </a>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
								</Columns>
                            </asp:GridView>
                        </div>
					</div>
					<!--end::Body-->
				</div>
			</div>
		</div>
    </div>
</asp:Content>
