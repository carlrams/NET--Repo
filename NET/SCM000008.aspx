<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM000008.aspx.vb" Inherits="NET.SCM000008" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<style type="text/css">
	/* Hide border left */
	div.dataTables_scrollBody {
		border-left: 0px solid #ddd !important
	}
	</style>

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
						<li class="breadcrumb-item text-white opacity-75">Supply Chain Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Details</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Button-->
				<asp:LinkButton ID="lbtnDone" runat="server" class="btn btn-bg-white btn-active-color-primary m-0" Visible="false" data-toggle="tooltip" title="Change Status">
					<span class="svg-icon svg-icon-2 me-1 svg-icon-success">
						<svg width="800px" height="800px" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
						<circle cx="12" cy="12" r="8" fill="currentColor" fill-opacity="0.24"/>
						<path d="M8.5 11L11.3939 13.8939C11.4525 13.9525 11.5475 13.9525 11.6061 13.8939L19.5 6" stroke="#222222" stroke-width="1.2"/>
						</svg>
					</span>
					Mark as Done
                </asp:LinkButton>
				<!--end::Button-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

        <div class="card-body mb-10">
            <div class="row gy-6 g-xl-9">
				<asp:UpdatePanel ID="upnlOverview" runat="server" UpdateMode="Conditional" class="">
					<ContentTemplate>	
                        <div class="row g-6 g-xl-9">
							<div class="col-lg-6 col-xxl-8">
								<!--begin::Budget-->
								<div class="card h-100">
									<div class="card-body p-9">
										<div class="fs-2hx fw-bolder"><asp:Label ID="lblProjectAmt" runat="server"></asp:Label></div>
										<div class="fs-4 fw-bold text-gray-400 mb-7">Project Budget</div>
										<div class="fs-6 d-flex justify-content-between mb-4">
											<div class="fw-bold">VAT</div>
											<div class="d-flex fw-bolder">
											<!--begin::Svg Icon | path: icons/duotune/arrows/arr007.svg-->
											<span id="spnVATIncrease" runat="server" class="svg-icon svg-icon-3 me-1 svg-icon-success" style="display: none;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="16.9497" y="8.46448" width="13" height="2" rx="1" transform="rotate(135 16.9497 8.46448)" fill="currentColor" />
													<path d="M14.8284 9.97157L14.8284 15.8891C14.8284 16.4749 15.3033 16.9497 15.8891 16.9497C16.4749 16.9497 16.9497 16.4749 16.9497 15.8891L16.9497 8.05025C16.9497 7.49797 16.502 7.05025 15.9497 7.05025L8.11091 7.05025C7.52512 7.05025 7.05025 7.52513 7.05025 8.11091C7.05025 8.6967 7.52512 9.17157 8.11091 9.17157L14.0284 9.17157C14.4703 9.17157 14.8284 9.52975 14.8284 9.97157Z" fill="currentColor" />
												</svg>
											</span>
											<span id="spnVATDecrease" runat="server" class="svg-icon svg-icon-3 me-1 svg-icon-danger" style="display: none;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="7.05026" y="15.5355" width="13" height="2" rx="1" transform="rotate(-45 7.05026 15.5355)" fill="currentColor" />
													<path d="M9.17158 14.0284L9.17158 8.11091C9.17158 7.52513 8.6967 7.05025 8.11092 7.05025C7.52513 7.05025 7.05026 7.52512 7.05026 8.11091L7.05026 15.9497C7.05026 16.502 7.49797 16.9497 8.05026 16.9497L15.8891 16.9497C16.4749 16.9497 16.9498 16.4749 16.9498 15.8891C16.9498 15.3033 16.4749 14.8284 15.8891 14.8284L9.97158 14.8284C9.52975 14.8284 9.17158 14.4703 9.17158 14.0284Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon--><asp:Label ID="lblProjectVAT" runat="server"></asp:Label></div>
										</div>
										<div class="separator separator-dashed"></div>
										<div class="fs-6 d-flex justify-content-between my-4">
											<div class="fw-bold">EWT</div>
											<div class="d-flex fw-bolder">
											<!--begin::Svg Icon | path: icons/duotune/arrows/arr006.svg-->
											<span id="spnEWTIncrease" runat="server" class="svg-icon svg-icon-3 me-1 svg-icon-success" style="display: none;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="16.9497" y="8.46448" width="13" height="2" rx="1" transform="rotate(135 16.9497 8.46448)" fill="currentColor" />
													<path d="M14.8284 9.97157L14.8284 15.8891C14.8284 16.4749 15.3033 16.9497 15.8891 16.9497C16.4749 16.9497 16.9497 16.4749 16.9497 15.8891L16.9497 8.05025C16.9497 7.49797 16.502 7.05025 15.9497 7.05025L8.11091 7.05025C7.52512 7.05025 7.05025 7.52513 7.05025 8.11091C7.05025 8.6967 7.52512 9.17157 8.11091 9.17157L14.0284 9.17157C14.4703 9.17157 14.8284 9.52975 14.8284 9.97157Z" fill="currentColor" />
												</svg>
											</span>
											<span id="spnEWTDecrease" runat="server" class="svg-icon svg-icon-3 me-1 svg-icon-danger" style="display: none;">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="7.05026" y="15.5355" width="13" height="2" rx="1" transform="rotate(-45 7.05026 15.5355)" fill="currentColor" />
													<path d="M9.17158 14.0284L9.17158 8.11091C9.17158 7.52513 8.6967 7.05025 8.11092 7.05025C7.52513 7.05025 7.05026 7.52512 7.05026 8.11091L7.05026 15.9497C7.05026 16.502 7.49797 16.9497 8.05026 16.9497L15.8891 16.9497C16.4749 16.9497 16.9498 16.4749 16.9498 15.8891C16.9498 15.3033 16.4749 14.8284 15.8891 14.8284L9.97158 14.8284C9.52975 14.8284 9.17158 14.4703 9.17158 14.0284Z" fill="currentColor" />
												</svg>
											</span>
											<!--end::Svg Icon--><asp:Label ID="lblProjectEWT" runat="server"></asp:Label></div>
										</div>
										<div class="separator separator-dashed"></div>
										<div class="fs-6 d-flex justify-content-between my-4">
											<div class="fw-bold">Retention Fee</div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblProjectRF" runat="server"></asp:Label></div>
										</div>
										<div class="separator separator-dashed"></div>
										<div class="fs-6 d-flex justify-content-between mt-4">
											<div class="fw-bold">Downpayment</div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblProjectDownpayment" runat="server"></asp:Label>
											</div>
										</div>
										<div class="fs-6 d-flex justify-content-between mt-5">
											<div class="fw-bold text-muted">Awarded Contractor</div>
											<div class="d-flex fw-bolder text-gray-600 text-muted">
												<asp:Label ID="lblProjectContractor" runat="server"></asp:Label>
											</div>
										</div>
										<div class="fs-7 d-flex justify-content-between">
											<div class="fw-bold text-muted">Assigned Personnel</div>
											<div class="d-flex fw-bold text-gray-600 text-muted">
												<asp:Label ID="lblProjectAssigned" runat="server"></asp:Label>
											</div>
										</div>
									</div>
								</div>
								<!--end::Budget-->
							</div>
							<div class="col-lg-6 col-xxl-4">
								<!--begin::Card-->
								<div class="card">
									<!--begin::Card header-->
									<div class="card-header border-0 pt-9">
										<!--begin::Card Title-->
										<div class="card-title m-0">
											<!--begin::Avatar-->
											<div class="symbol symbol-50px w-50px bg-light">
												<img src="assets/media/svg/apps/CON000005.svg" alt="image" class="p-3" />
											</div>
											<!--end::Avatar-->
											<div class="fs-3 fw-bolder text-muted" style="margin-left: 5px;">Construction</div>
										</div>
										<!--end::Car Title-->
										<!--begin::Card toolbar-->
										<div class="card-toolbar">
											<a id="ahrefTag" runat="server" class="badge badge-light-info fw-bolder me-auto px-4 py-3 cursor-pointer">View Form</a>
										</div>
										<!--end::Card toolbar-->
									</div>
									<!--end:: Card header-->
									<!--begin:: Card body-->
									<div class="card-body p-9">
										<!--begin::Name-->
										<div id="divProjectCategory" runat="server" class="fs-3 fw-bolder text-dark"></div>
										<!--end::Name-->
										<p id="divProject" runat="server" class="text-gray-800 fw-bold fs-5 mt-1 mb-7"></p>
										<!--begin::Description-->
										<p class="text-gray-400 fw-bold fs-5 p-0">Billing Progress</p>
										<!--end::Description-->
										<!--begin::Info-->
										<div class="d-flex flex-wrap mb-5">
											<!--begin::Due-->
											<div class="border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-7 mb-3">
												<div id="divStartDate" runat="server" class="fs-6 text-gray-800 fw-bolder"></div>
												<div class="fw-bold text-gray-400">Start Date</div>
											</div>
											<!--end::Due-->
											<!--begin::Budget-->
											<div class="border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 mb-3">
												<div id="divPercentage" runat="server" class="fs-6 text-gray-800 fw-bolder"></div>
												<div class="fw-bold text-gray-400">Percentage</div>
											</div>
											<!--end::Budget-->
										</div>
										<!--end::Info-->
										<!--begin::Progress-->
										<div id="togglePercent" runat="server" class="h-4px w-100 bg-light mb-5" data-bs-toggle="tooltip">
											<div id="divProgressBar" runat="server" class="bg-primary rounded h-4px" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
										</div>
										<!--end::Progress-->
                                        <span class="btn bg-light-info btn-active-success me-n5" onclick="ViewProgress();">View Progress
											<span class="svg-icon svg-icon-2 svg-icon-success">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="18" y="13" width="13" height="2" rx="1" transform="rotate(-180 18 13)" fill="currentColor"></rect>
													<path d="M15.4343 12.5657L11.25 16.75C10.8358 17.1642 10.8358 17.8358 11.25 18.25C11.6642 18.6642 12.3358 18.6642 12.75 18.25L18.2929 12.7071C18.6834 12.3166 18.6834 11.6834 18.2929 11.2929L12.75 5.75C12.3358 5.33579 11.6642 5.33579 11.25 5.75C10.8358 6.16421 10.8358 6.83579 11.25 7.25L15.4343 11.4343C15.7467 11.7467 15.7467 12.2533 15.4343 12.5657Z" fill="currentColor"></path>
												</svg>
											</span>
                                        </span>
									</div>
									<!--end:: Card body-->
								</div>
								<!--end::Card-->
							</div>
                        </div>
                        <div class="row g-6 g-xl-9 mt-1">
							<div class="col-lg-6 col-xxl-4">
								<!--begin::Budget-->
								<div class="card h-100">
									<div class="card-body">
										<div class="fs-2hx fw-bolder"><asp:Label ID="lblTCPBal" runat="server"></asp:Label></div>
										<div class="fs-4 fw-bold text-gray-400 mb-7">TCP Balance</div>
										<div class="fs-6 d-flex justify-content-between my-4">
											<div class="fw-bold pe-10 text-gray-600 fs-7">Deducted Project Budget <br />
                                                <span class="fw-bold text-danger fs-8" style="font-style: italic;">(Project Budget - Total Billed)</span>
                                            </div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblProjectBalance" runat="server"></asp:Label></div>
										</div>
										<div class="fs-6 d-flex justify-content-between mb-4">
											<div class="fw-bold pe-10 text-gray-600 fs-7">Total Contract Billed </div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblSubtotal" runat="server"></asp:Label></div>
										</div>
										<div class="fs-6 d-flex justify-content-between my-4">
											<div class="fw-bold pe-10 text-gray-600 fs-7">Billed Amount</div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblBillAmt" runat="server"></asp:Label></div>
										</div>
										<div class="fs-6 d-flex justify-content-between my-4">
											<div class="fw-bold pe-10 text-gray-600 fs-7">VAT %</div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblVAT" runat="server"></asp:Label></div>
										</div>
										<div class="fs-6 d-flex justify-content-between my-4">
											<div class="fw-bold pe-10 text-gray-600 fs-7">EWT %</div>
											<div class="d-flex fw-bolder"><asp:Label ID="lblEWT" runat="server"></asp:Label></div>
										</div>
									</div>
								</div>
								<!--end::Budget-->
							</div>
							<div class="col-lg-6 col-xxl-8">						
								<!--begin::Col-->
										<div class="card">
											<!--begin::Card widget 12-->
											<div class="card overflow-hidden h-md-50 mb-5 mb-xl-10">
												<!--begin::Card body-->
												<div class="card-body d-flex justify-content-between flex-column px-0 pb-0">
													<!--begin::Statistics-->
													<div class="mb-4 px-9">
														<!--begin::Info-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Value-->
															<span id="divTotalBilled" runat="server" class="fs-2hx fw-bolder text-gray-800 me-2 lh-1 ls-n2"></span>
															<!--end::Value-->
														</div>
														<!--end::Info-->
														<!--begin::Description-->
														<span class="fs-6 fw-bold text-gray-400">Total Billed</span>
														<!--end::Description-->
													</div>
													<!--end::Statistics-->
													<!--begin::Chart-->
													<div id="billing_bar_graph" class="min-h-auto" style="height: 200px"></div>
													<!--end::Chart-->
												</div>
												<!--end::Card body-->
											</div>
											<!--end::Card widget 12-->
										</div>
										<!--end::Col-->
								<!--end::Budget-->
							</div>
                        </div>
						
						<!--begin::Tables Widget 9-->
						<div class="card mt-10 mb-xl-8">
							<!--begin::Header-->
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fw-bolder fs-3 mb-1">Project Details</span>
									<span class="text-muted mt-1 fw-bold fs-7">House Construction</span>
								</h3>
							</div>
							<!--end::Header-->
							<!--begin::Body-->
							<div class="card-body py-3">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">ID</span>
									<asp:Label ID="lblID" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Type</span>
									<asp:Label ID="lblType" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Start</span>
									<asp:Label ID="lblDateStart" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date End</span>
									<asp:Label ID="lblDateEnd" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Assigned to</span>
									<asp:Label ID="lbl01AssignedTo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:Label ID="lblStatus" runat="server" class="form-control">-</asp:Label>
								</div>
								<!--begin::Separator-->
								<div class="separator separator-dashed my-6"></div>
								<!--end::Separator-->
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Category</span>
									<asp:Label ID="lblCategory" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Batch No.</span>
									<asp:Label ID="lblBatchNo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Project</span>
									<asp:Label ID="lblProject" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Project Details</span>
									<asp:Label ID="lblProjectDetails" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Model</span>
									<asp:Label ID="lblModel" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Contract Status</span>
									<asp:Label ID="lblConStatus" runat="server" class="form-control">-</asp:Label>
								</div>
							</div>
							<!--begin::Body-->
						</div>
						<!--end::Tables Widget 9-->

						<!--begin::Tables Widget 9-->
						<div class="card mt-10 mb-xl-8">
							<!--begin::Header-->
							<div class="card-header border-0 pt-5">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fw-bolder fs-3 mb-1">Billing History</span>
									<span id="spnProjectName" runat="server" class="text-muted mt-1 fw-bold fs-7"></span>
								</h3>
							</div>
							<!--end::Header-->
							<!--begin::Body-->
							<div class="card-body py-3">
								<!--begin::Table container-->
								<div class="table-responsive">
									<asp:Panel ID="pnlAlert" runat="server" CssClass="card card-xl-stretch" Visible="false" style="height: 15vh;">
										<div class="d-flex justify-content-center p-10">
											<h3 class="text-gray-500 fs-6" style="font-style: italic;">No current billing posted yet.</h3>
										</div>
									</asp:Panel>
									<!--begin::Table-->
									<asp:Gridview ID="gvHistory" runat="server" class="table table-no-border table-row-bordered" AutoGenerateColumns="false">
										<Columns>
											<asp:TemplateField HeaderText="Remarks">
												<ItemTemplate>
                                                    <div class="d-flex align-items-center">
                                                        <div class="d-flex justify-content-start flex-column">
															<a href="#" class="text-dark fw-bolder text-hover-primary fs-6" style="margin-left: 5px;"><%# Eval("Before") %></a>
															<span class="text-muted fw-bold text-muted d-block fs-7" style="margin-left: 5px;"><%# Eval("After") %></span>
                                                        </div>
                                                    </div>
												</ItemTemplate>
												<HeaderStyle  CssClass="fw-bolder text-muted min-w-400px" />
												<ItemStyle CssClass="min-w-400px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Date">
												<ItemTemplate>
                                                    <span class="text-end text-muted fw-bold"><%# Eval("PostedDate") %></span>
												</ItemTemplate>
												<HeaderStyle  CssClass="fw-bolder text-muted text-end" />
												<ItemStyle CssClass="min-w-100px text-end" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Type">
												<ItemTemplate>
                                                    <span class="text-end text-muted fw-bold"><%# Eval("Type") %></span>
												</ItemTemplate>
												<HeaderStyle CssClass="fw-bolder text-muted text-end" />
												<ItemStyle CssClass="min-w-200px text-end" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Rate">
												<ItemTemplate>
                                                    <span class="text-end text-muted fw-bold"><%# Eval("Rate") %>%</span>
												</ItemTemplate>
												<HeaderStyle CssClass="fw-bolder text-muted text-end" />
												<ItemStyle CssClass="min-w-100px text-end" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Amount">
												<ItemTemplate>
                                                    <span class="text-end fw-bolder mr-5">₱ <%# Eval("Amount") %></span>
												</ItemTemplate>
												<HeaderStyle CssClass="fw-bolder text-muted text-end" />
												<ItemStyle CssClass="min-w-200px text-end" />
											</asp:TemplateField>
										</Columns>
									</asp:Gridview>
									<!--end::Table-->
								</div>
								<!--end::Table container-->
							</div>
							<!--begin::Body-->
						</div>
						<!--end::Tables Widget 9-->

					</ContentTemplate>
				</asp:UpdatePanel>
            </div>
        </div>
		
		<!--begin::Modal Find-->
		<asp:UpdatePanel ID="mdlProgress" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <ContentTemplate>
                <div class="modal-dialog modal-dialog-top modal-dialog-scrollable" role="document" style="min-width: 800px;">
                    <div class="modal-content">
				        <div class="modal-header">
					        <h5 class="modal-title">Current Progress</h5>
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
							<!--begin::Dropzone-->
							<div class="dropzone mb-5" id="DropZone">
								<!--begin::Message-->
								<div class="dz-message needsclick">
									<!--begin::Icon-->
									<i class="bi bi-file-earmark-image text-primary fs-3x"></i>
									<!--end::Icon-->
									<!--begin::Info-->
									<div class="ms-4">
										<h3 class="fs-7 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
										<span class="fs-8 fw-bold text-gray-400">Upload only image, maximum of 4mb per image</span>
									</div>
									<!--end::Info-->
								</div>
							</div>
							<!--end::Dropzone-->

							<!--begin::Row-->
							<asp:UpdatePanel ID="upnlFiles" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<asp:DataList ID="dlContent" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
										<ItemStyle CssClass="col-md-6 col-lg-4 col-xl-3" />
										<ItemTemplate>
											<!--begin::Card-->
											<div class="card h-100">
												<!--begin::Card body-->
												<div class="card-body overlay overflow-hidden card-rounded d-flex justify-content-center text-center flex-column p-8">
													<!--begin::Name-->
													<span class="text-gray-800 text-hover-primary d-flex flex-column">
														<!--begin::Image-->
														<div class="symbol symbol-60px mb-5">
															<img src="<%# Eval("Icon") %>" class="mb-5" alt="" />
														</div>
														<!--end::Image-->
														<!--begin::Title-->
														<div class="fs-5 fw-bolder mb-2"><%# Eval("Name") %></div>
														<!--end::Title-->
													</span>
													<!--end::Name-->
													<!--begin::Description-->
													<div class="fs-7 fw-bold text-gray-400"><%# Eval("CreationTime") %></div>
													<!--end::Description-->
													<div class="overlay-layer bg-dark bg-opacity-25">
														<span class="btn btn-sm btn-icon btn-active-success btn-bg-light mr-5" data-file-name="<%# Eval("FileName") %>" data-toggle="tooltip" title="Remove File" onclick="triggerDeletion(this);"><i class="las la-trash fs-3"></i></span>
														<<%--span class="btn btn-sm btn-icon btn-active-success btn-bg-light" data-file-name="<%# Eval("FileName") %>" data-toggle="tooltip" title="View File" onclick="triggerViewing(this);"><i class="las la-search fs-3"></i></span>--%>
															
														
														<!--begin::Overlay-->
														<a data-fancybox="gallery" class="d-block overlay btn btn-sm btn-icon btn-active-success btn-bg-light" data-src="<%# Eval("Icon") %>" onclick="closeMDL();">
															<!--begin::Image-->
															<div class="overlay-wrapper bgi-no-repeat bgi-position-center bgi-size-cover card-rounded mb-7" style="background-image:url('"<%# Eval("Icon") %>"');"></div>
															<!--end::Image-->
															<!--begin::Action-->
															<div class="overlay-layer m-0 p-0">
																<i class="las la-search fs-3"></i>
															</div>
															<!--end::Action-->
														</a>
														<!--end::Overlay-->

													</div>
												</div>
												<!--end::Card body-->
											</div>
											<!--end::Card-->
										</ItemTemplate>
									</asp:DataList>
								</ContentTemplate>
							</asp:UpdatePanel>
							<!--end:Row-->
                        </div>
                        <div class="modal-footer d-none">
							<asp:LinkButton ID="lbtnSubmit" runat="server" style="display: none;"></asp:LinkButton>
							<asp:LinkButton ID="lbtnDelete" runat="server" style="display: none;"></asp:LinkButton>
							<asp:LinkButton ID="lbtnView" runat="server" style="display: none;"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Find-->

		<!--begin::Hidden Field -->
		<asp:HiddenField ID="hdnFile" runat="server" />
		<!--end::Hidden Field -->
    </div>
	
	<script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0/dist/fancybox/fancybox.umd.js"></script>
    <script type="text/javascript">
        //form variable
		var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
		var ltrlFormNo = '<asp:Literal ID="ltrlFormNo" runat="server" />';
		var ltrlBilledAmt = '<asp:Literal ID="ltrlBilledAmt" runat="server" />';
		var ltrlBilledDate = '<asp:Literal ID="ltrlBilledDate" runat="server" />';
		//form variable

        //hidden variable
		var hdnFile = document.getElementById("ContentPlaceHolder1_hdnFile");
		var lbtnDelete = document.getElementById("ContentPlaceHolder1_lbtnDelete");
		var lbtnView = document.getElementById("ContentPlaceHolder1_lbtnView");
		//hidden variable

		function triggerDeletion(obj) {
			var FileName = obj.getAttribute("data-file-name");
			hdnFile.value = FileName;

			//trigger
			lbtnDelete.click();
			//trigger
		};

		function triggerViewing(obj) {
			var FileName = obj.getAttribute("data-file-name");
			hdnFile.value = FileName;

			//trigger
			lbtnView.click();
			//trigger
		};

		function ViewProgress() {
			$("#ContentPlaceHolder1_mdlProgress").modal("show");
		};

        function closeMDL() {
            $("#ContentPlaceHolder1_mdlProgress").modal("hide");
		};

		function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {

                //fancybox
                Fancybox.bind('[data-fancybox="gallery"]', {
                    // nothing
                });
				//fancybox

                //datatable
				var gvHistory = $("#ContentPlaceHolder1_gvHistory").DataTable({
					scrollX: true,
					scrollY: "450px",
                    scrollCollapse: true,
                    bLengthChange: false,
                    bSort: false,
                    paging: false,
                    bDestroy: true,
                    info: false,
                    fixedColumns: {
						left: 1,
						right: 1
                    }
				});
				//datatable

                //upload
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "SCM000012.ashx?FormCode=ENG010501&ID=" + ltrlID ,
                    autoProcessQueue: true,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 4,
                    //File size
                    maxfilesize: 4,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".png,.jpg,.jpeg,.jpe,.PNG,.JPG,.JPEG,.JPE",
                    addRemoveLinks: true,
                    success: function (file, response) {
						var imgName = response;
						var lbtnSubmit = document.getElementById("ContentPlaceHolder1_lbtnSubmit");
                        file.previewElement.classList.add("dz-success");
                        console.log("Successfully uploaded :" + imgName);
                        setTimeout(function () {
                            lbtnSubmit.click();
                        }, 2500);
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                //upload
			});
			jQuery(function ($) {
                var element = document.getElementById("billing_bar_graph");

                if (!element) {
                    return;
                }

                var borderColor = KTUtil.getCssVariableValue('--bs-border-dashed-color');
                var baseColor = KTUtil.getCssVariableValue('--bs-gray-800');
                var lightColor = KTUtil.getCssVariableValue('--bs-success');
                var ArrayBilledAmt = ltrlBilledAmt.split(",");
				var ArrayBilledDate = ltrlBilledDate.split(",");
                var options = {
                    series: [{
                        name: 'Amount Billed',
                        data: ArrayBilledAmt
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'area',
                        height: '200px',
                        toolbar: {
                            show: false
                        }
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 0
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 2,
                        colors: [baseColor]
                    },
					xaxis: {
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            show: false
                        },
                        crosshairs: {
                            position: 'front',
                            stroke: {
                                color: baseColor,
                                width: 1,
                                dashArray: 3
                            }
                        },
                        tooltip: {
                            enabled: true,
                            formatter: undefined,
                            offsetY: 0,
                            style: {
                                fontSize: '12px'
                            }
                        }
                    },
                    yaxis: {
                        labels: {
                            show: false
                        }
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px'
                        },
                        x: {
							formatter: function (val) {
								var pos = val - 1;
                                return ArrayBilledDate[pos];
                            }
                        },
                        y: {
							formatter: function (val) {
                                const num = parseFloat(val);
                                if (num >= 1000000) {
                                    return Math.floor(num / 1000000).toFixed(1) + 'M'
                                } else if (num >= 1000) {
                                    return Math.floor(num / 1000) + 'K';
                                } else if (num >= 100) {
                                    return Math.floor(num) + 'H';
                                } else {
                                    return Math.floor(num) + 'P';
                                }
                            }
                        }
                    },
                    colors: [lightColor],
                    grid: {
                        strokeDashArray: 4,
                        padding: {
                            top: 0,
                            right: -20,
                            bottom: -20,
                            left: -20
                        },
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    markers: {
                        strokeColor: baseColor,
                        strokeWidth: 2
                    }
                };

				var chart = new ApexCharts(element, options);

                setTimeout(function () {
                    chart.render();
                }, 300);  
			});
		};
    </script>
</asp:Content>
