<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB050000.aspx.vb" Inherits="NET.DSB050000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">House Turn-Over</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Overview and status</li>
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
							<span class="card-label fw-bolder fs-3 mb-1">Customer Service</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl01CSDTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl01CSDGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl01CSDDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl01CSDDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv01CSD" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
							<span class="card-label fw-bolder fs-3 mb-1">CLDC</span>
							<span class="text-muted fw-bold fs-6"">Director</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl02DirectorTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl02DirectorGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl02DirectorDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl02DirectorDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv02Director" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
							<span class="card-label fw-bolder fs-3 mb-1">Other</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl03OtherTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl03OtherGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl03OtherDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl03OtherDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv03Other" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
			<div class="col-lg-4 ml-auto">
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
						<asp:Label ID="lbl04COSTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl04COSGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl04COSDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl04COSDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv04COS" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
			<div class="col-lg-4 mr-auto">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Supply Chain Management</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl05SCMTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl05SCMGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl05SCMDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl05SCMDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv05SCM" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
							<span class="card-label fw-bolder fs-3 mb-1">TSG-PE</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl06PETotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl06PEGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl06PEDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl06PEDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv06PE" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
						<asp:Label ID="lbl07PMDTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl07PMDGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl07PMDDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl07PMDDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv07PMD" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
							<span class="card-label fw-bolder fs-3 mb-1">CCI</span>
							<span class="text-muted fw-bold fs-6"">Department</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl08CCITotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl08CCIGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl08CCIDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl08CCIDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv08CCI" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
			<div class="col-lg-4 ml-auto">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Cancelled</span>
							<span class="text-muted fw-bold fs-6"">Repair</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl09CancelTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl09CancelGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl09CancelDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl09CancelDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv09Cancel" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
			<div class="col-lg-4 mr-auto">
				<div class="card card-flush h-100">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder fs-3 mb-1">Completed</span>
							<span class="text-muted fw-bold fs-6"">Repair</span>
						</h3>
						<!--end::Title-->
					</div>
					<!--end::Header-->
					<div class="card-body pt-0 pb-0 min-h-20px mh-20px">
						<asp:Label ID="lbl10CompleteTotal" runat="server" data-toggle="tooltip" title="Overall" class="badge badge-light-success badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl10CompleteGood" runat="server" data-toggle="tooltip" title="Good" class="badge badge-light-info badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl10CompleteDue" runat="server" data-toggle="tooltip" title="Due" class="badge badge-light-warning badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
						<asp:Label ID="lbl10CompleteDelay" runat="server" data-toggle="tooltip" title="Delay" class="badge badge-light-danger badge-square badge-lg text-center fs-8 fw-bolder">0</asp:Label>
					</div>
					<!--begin::Body-->
					<div class="card-body">
                        <div class="table-responsive" style="max-height: 400px; overflow-y: scroll;">
                            <asp:GridView ID="gv10Complete" runat="server" class="table table-no-border table-row-dashed table-hover align-middle" AutoGenerateColumns="false" ShowHeader="false" EmptyDataText="No Data">
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
