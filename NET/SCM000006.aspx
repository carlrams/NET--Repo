<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM000006.aspx.vb" Inherits="NET.SCM000006" MaintainScrollPositionOnPostback = "true" %>
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
				<asp:LinkButton ID="lbtnViewBilling" runat="server" class="btn btn-bg-white btn-active-color-primary m-0" Visible="false" data-toggle="tooltip" title="Posted Billing">
					<asp:Label ID="lblPostedCount" runat="server" class="badge badge-light-success me-2 badge-circle"></asp:Label>
					View Billing
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
												<img src="assets/media/svg/apps/FRM000009.svg" alt="image" class="p-3" />
											</div>
											<!--end::Avatar-->
											<div class="fs-3 fw-bolder text-muted" style="margin-left: 5px;">Contract Order</div>
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
												<div id="divAwardedDate" runat="server" class="fs-6 text-gray-800 fw-bolder"></div>
												<div class="fw-bold text-gray-400">Awarded Date</div>
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
										<div class="fs-4 fw-bold text-gray-400 mb-7">Accounts Receivable (Estimate)</div>
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
							</div>
                        </div>
						<!--begin::Tables Widget 9-->
						<div class="card mt-8 mb-xl-8">
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
									<asp:Panel ID="pnlAlert" runat="server" CssClass="card card-xl-stretch" Visible="false" style="height: 20vh;">
										<div class="d-flex justify-content-center p-10">
											<h3 class="text-gray-500 fs-6" style="font-style: italic;">No current billing posted yet.</h3>
										</div>
									</asp:Panel>
									<!--begin::Table-->
									<asp:Gridview ID="gvHistory" runat="server" class="table table-no-border table-row-bordered" AutoGenerateColumns="false">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
                                                    <div style='<%# Eval("Received") %>' class="mt-3">
                                                        <span data-bg-toggle="tooltip" data-bs-placement="top" title="Received Billing">
                                                            <span class="svg-icon svg-icon-3">
																<svg width="800px" height="800px" viewBox="0 0 1024 1024" class="icon"  version="1.1" xmlns="http://www.w3.org/2000/svg"><path d="M905.92 237.76a32 32 0 0 0-52.48 36.48A416 416 0 1 1 96 512a418.56 418.56 0 0 1 297.28-398.72 32 32 0 1 0-18.24-61.44A480 480 0 1 0 992 512a477.12 477.12 0 0 0-86.08-274.24z" fill="#008000" /><path d="M630.72 113.28A413.76 413.76 0 0 1 768 185.28a32 32 0 0 0 39.68-50.24 476.8 476.8 0 0 0-160-83.2 32 32 0 0 0-18.24 61.44zM489.28 86.72a36.8 36.8 0 0 0 10.56 6.72 30.08 30.08 0 0 0 24.32 0 37.12 37.12 0 0 0 10.56-6.72A32 32 0 0 0 544 64a33.6 33.6 0 0 0-9.28-22.72A32 32 0 0 0 505.6 32a20.8 20.8 0 0 0-5.76 1.92 23.68 23.68 0 0 0-5.76 2.88l-4.8 3.84a32 32 0 0 0-6.72 10.56A32 32 0 0 0 480 64a32 32 0 0 0 2.56 12.16 37.12 37.12 0 0 0 6.72 10.56zM230.08 467.84a36.48 36.48 0 0 0 0 51.84L413.12 704a36.48 36.48 0 0 0 51.84 0l328.96-330.56A36.48 36.48 0 0 0 742.08 320l-303.36 303.36-156.8-155.52a36.8 36.8 0 0 0-51.84 0z" fill="#008000" /></svg>
                                                            </span>
                                                        </span>
                                                    </div>
                                                    <div style='<%# Eval("Fixed") %>' class="mt-3">
                                                        <span data-bg-toggle="tooltip" data-bs-placement="top" title="For Confirmation">
                                                            <span class="svg-icon svg-icon-3">
																<svg fill="#5bc0de" width="800px" height="800px" viewBox="0 0 36 36" version="1.1"  preserveAspectRatio="xMidYMid meet" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
																	<path d="M18,2A16,16,0,1,0,34,18,16,16,0,0,0,18,2Zm0,30A14,14,0,1,1,32,18,14,14,0,0,1,18,32Z" class="clr-i-outline clr-i-outline-path-1"></path><path d="M18.92,18.4V10.75a1,1,0,0,0-2,0v8.72l5.9,4a1,1,0,1,0,1.11-1.66Z" class="clr-i-outline clr-i-outline-path-2"></path><path d="M8,17.94A9.94,9.94,0,0,1,23.41,9.59l.85-1.36a11.55,11.55,0,1,0-8.53,21L16,27.7A10,10,0,0,1,8,17.94Z" class="clr-i-outline clr-i-outline-path-3"></path>
																	<rect x="0" y="0" width="36" height="36" fill-opacity="0"/>
																</svg>
                                                            </span>
                                                        </span>
                                                    </div>
												</ItemTemplate>
												<HeaderStyle HorizontalAlign="Right" />
												<ItemStyle HorizontalAlign="Right" />
											</asp:TemplateField>
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
						<div class="card-title fs-5 fw-bolder">Files</div>
						<!--begin::Seperator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Seperator-->
						<!--begin::Tables Widget 9-->
						<div class="row g-6 g-xl-9">
							<div class="col-lg-6 col-xxl-4">
								<!--begin::Budget-->
								<div class="card h-100">
									<div class="card-body p-9">
										<div class="fs-3 fw-bolder">Documents</div>
										<div class="fs-7 fw-bold text-gray-400 mb-8">Contractor Documents</div>
                                        <div class="table-responsive">
											<!--begin::Files-->
												<table id="gvFiles" class="table table-no-border table-row-bordered table-hover">
													<thead>
														<tr>
															<th>

															</th>
															<th class="fw-bold fs-6 text-dark min-w-150px">
																File
															</th>
															<th class="min-w-50px">

															</th>
														</tr>
													</thead>
													<tbody>

													</tbody>
												</table>
											<!--end::Files-->
                                        </div>
									</div>
								</div>
								<!--end::Budget-->
							</div>
                            <div class="col-lg-6 col-xxl-8">
								<!--begin::List widget 10-->
								<div class="card card-flush h-lg-100">
									<!--begin::Header-->
									<div class="card-header pt-7">
										<!--begin::Title-->
										<h3 class="card-title align-items-start flex-column">
											<span class="card-label fw-bolder text-gray-800">Attachment</span>
											<span class="text-gray-400 mt-1 fw-bold fs-6">Uploaded File</span>
										</h3>
										<!--end::Title-->
									</div>
									<!--end::Header-->
									<!--begin::Body-->
									<div class="card-body">
										<!--begin::Nav-->
										<ul class="nav nav-pills nav-pills-custom row position-relative mx-0 d-flex justify-content-end">
											<!--begin::Item-->
											<li class="nav-item col-1 m-0 p-0" data-bs-toggle="tooltip" data-bs-placement="top" title="Notice Attachment">
												<!--begin::Link-->
												<a class="nav-link active d-flex justify-content-center w-100 border-0 h-100" data-bs-toggle="pill" href="#kt_list_widget_10_tab_1">
													<!--begin::Svg Icon | path: icons/duotune/general/gen015.svg-->
													<span class="svg-icon svg-icon-2 svg-icon-primary">
														<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
															<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
																<rect x="0" y="0" width="24" height="24"/>
																<path d="M11.7573593,15.2426407 L8.75735931,15.2426407 C8.20507456,15.2426407 7.75735931,15.6903559 7.75735931,16.2426407 C7.75735931,16.7949254 8.20507456,17.2426407 8.75735931,17.2426407 L11.7573593,17.2426407 L11.7573593,18.2426407 C11.7573593,19.3472102 10.8619288,20.2426407 9.75735931,20.2426407 L5.75735931,20.2426407 C4.65278981,20.2426407 3.75735931,19.3472102 3.75735931,18.2426407 L3.75735931,14.2426407 C3.75735931,13.1380712 4.65278981,12.2426407 5.75735931,12.2426407 L9.75735931,12.2426407 C10.8619288,12.2426407 11.7573593,13.1380712 11.7573593,14.2426407 L11.7573593,15.2426407 Z" fill="currentColor" opacity="0.3" transform="translate(7.757359, 16.242641) rotate(-45.000000) translate(-7.757359, -16.242641) "/>
																<path d="M12.2426407,8.75735931 L15.2426407,8.75735931 C15.7949254,8.75735931 16.2426407,8.30964406 16.2426407,7.75735931 C16.2426407,7.20507456 15.7949254,6.75735931 15.2426407,6.75735931 L12.2426407,6.75735931 L12.2426407,5.75735931 C12.2426407,4.65278981 13.1380712,3.75735931 14.2426407,3.75735931 L18.2426407,3.75735931 C19.3472102,3.75735931 20.2426407,4.65278981 20.2426407,5.75735931 L20.2426407,9.75735931 C20.2426407,10.8619288 19.3472102,11.7573593 18.2426407,11.7573593 L14.2426407,11.7573593 C13.1380712,11.7573593 12.2426407,10.8619288 12.2426407,9.75735931 L12.2426407,8.75735931 Z" fill="currentColor" transform="translate(16.242641, 7.757359) rotate(-45.000000) translate(-16.242641, -7.757359) "/>
																<path d="M5.89339828,3.42893219 C6.44568303,3.42893219 6.89339828,3.87664744 6.89339828,4.42893219 L6.89339828,6.42893219 C6.89339828,6.98121694 6.44568303,7.42893219 5.89339828,7.42893219 C5.34111353,7.42893219 4.89339828,6.98121694 4.89339828,6.42893219 L4.89339828,4.42893219 C4.89339828,3.87664744 5.34111353,3.42893219 5.89339828,3.42893219 Z M11.4289322,5.13603897 C11.8194565,5.52656326 11.8194565,6.15972824 11.4289322,6.55025253 L10.0147186,7.96446609 C9.62419433,8.35499039 8.99102936,8.35499039 8.60050506,7.96446609 C8.20998077,7.5739418 8.20998077,6.94077682 8.60050506,6.55025253 L10.0147186,5.13603897 C10.4052429,4.74551468 11.0384079,4.74551468 11.4289322,5.13603897 Z M0.600505063,5.13603897 C0.991029355,4.74551468 1.62419433,4.74551468 2.01471863,5.13603897 L3.42893219,6.55025253 C3.81945648,6.94077682 3.81945648,7.5739418 3.42893219,7.96446609 C3.0384079,8.35499039 2.40524292,8.35499039 2.01471863,7.96446609 L0.600505063,6.55025253 C0.209980772,6.15972824 0.209980772,5.52656326 0.600505063,5.13603897 Z" fill="currentColor" opacity="0.3" transform="translate(6.014719, 5.843146) rotate(-45.000000) translate(-6.014719, -5.843146) "/>
																<path d="M17.9142136,15.4497475 C18.4664983,15.4497475 18.9142136,15.8974627 18.9142136,16.4497475 L18.9142136,18.4497475 C18.9142136,19.0020322 18.4664983,19.4497475 17.9142136,19.4497475 C17.3619288,19.4497475 16.9142136,19.0020322 16.9142136,18.4497475 L16.9142136,16.4497475 C16.9142136,15.8974627 17.3619288,15.4497475 17.9142136,15.4497475 Z M23.4497475,17.1568542 C23.8402718,17.5473785 23.8402718,18.1805435 23.4497475,18.5710678 L22.0355339,19.9852814 C21.6450096,20.3758057 21.0118446,20.3758057 20.6213203,19.9852814 C20.2307961,19.5947571 20.2307961,18.9615921 20.6213203,18.5710678 L22.0355339,17.1568542 C22.4260582,16.76633 23.0592232,16.76633 23.4497475,17.1568542 Z M12.6213203,17.1568542 C13.0118446,16.76633 13.6450096,16.76633 14.0355339,17.1568542 L15.4497475,18.5710678 C15.8402718,18.9615921 15.8402718,19.5947571 15.4497475,19.9852814 C15.0592232,20.3758057 14.4260582,20.3758057 14.0355339,19.9852814 L12.6213203,18.5710678 C12.2307961,18.1805435 12.2307961,17.5473785 12.6213203,17.1568542 Z" fill="currentColor" opacity="0.3" transform="translate(18.035534, 17.863961) scale(1, -1) rotate(45.000000) translate(-18.035534, -17.863961) "/>
															</g>
														</svg>
													</span>
													<!--end::Svg Icon-->
													<!--begin::Bullet-->
													<span class="bullet-custom position-absolute z-index-2 bottom-0 w-100 h-4px bg-primary rounded"></span>
													<!--end::Bullet-->
												</a>
												<!--end::Link-->
											</li>
											<!--end::Item-->
											<!--begin::Item-->
											<li class="nav-item col-1 m-0 p-0" data-bs-toggle="tooltip" data-bs-placement="top" title="Uploaded by Contractor">
												<!--begin::Link-->
												<a class="nav-link d-flex justify-content-center w-100 border-0 h-100" data-bs-toggle="pill" href="#kt_list_widget_10_tab_2">
													<!--begin::Svg Icon | path: icons/duotune/general/gen015.svg-->
													<span class="svg-icon svg-icon-2 svg-icon-info">
														<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
															<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
																<polygon points="0 0 24 0 24 24 0 24"/>
																<path d="M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z" fill="currentColor" fill-rule="nonzero" opacity="0.3"/>
																<path d="M8.95128003,13.8153448 L10.9077535,13.8153448 L10.9077535,15.8230161 C10.9077535,16.0991584 11.1316112,16.3230161 11.4077535,16.3230161 L12.4310522,16.3230161 C12.7071946,16.3230161 12.9310522,16.0991584 12.9310522,15.8230161 L12.9310522,13.8153448 L14.8875257,13.8153448 C15.1636681,13.8153448 15.3875257,13.5914871 15.3875257,13.3153448 C15.3875257,13.1970331 15.345572,13.0825545 15.2691225,12.9922598 L12.3009997,9.48659872 C12.1225648,9.27584861 11.8070681,9.24965194 11.596318,9.42808682 C11.5752308,9.44594059 11.5556598,9.46551156 11.5378061,9.48659872 L8.56968321,12.9922598 C8.39124833,13.2030099 8.417445,13.5185067 8.62819511,13.6969416 C8.71848979,13.773391 8.8329684,13.8153448 8.95128003,13.8153448 Z" fill="currentColor"/>
															</g>
														</svg>
													</span>
													<!--end::Svg Icon-->
													<!--begin::Bullet-->
													<span class="bullet-custom position-absolute z-index-2 bottom-0 w-100 h-4px bg-info rounded"></span>
													<!--end::Bullet-->
												</a>
												<!--end::Link-->
											</li>
											<!--end::Item-->
										</ul>
										<!--end::Nav-->
										<!--begin::Tab Content-->
										<div class="tab-content">
											<!--begin::Tap pane-->
											<div class="tab-pane fade show active" id="kt_list_widget_10_tab_1">
												<asp:Panel ID="pnlNoticeAttach" runat="server" CssClass="card card-xl-stretch" Visible="false" style="height: 1vh;">
													<div class="d-flex justify-content-center p-10">
														<h3 class="text-gray-500 fs-6" style="font-style: italic;">No notice attachment uploaded yet.</h3>
													</div>
												</asp:Panel>     
                                                <div class="table-responsive" style="overflow-y: scroll; height: 300px;">
													<asp:GridView ID="gvNoticeAttachment" runat="server" class="table table-no-border table-row-bordered border-dashed" AutoGenerateColumns="false">
														<Columns>
															<asp:TemplateField HeaderText="File">
																<ItemTemplate>
																	<div class="d-flex align-items-center">
																		<div class="m-3">
																			<asp:LinkButton ID="lbtnDLNoticeAttachment" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' ToolTip="Download file" OnClick="lbtnDLNoticeAttachment"><i class="las la-download fs-3"></i></asp:LinkButton>
																		</div>
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
															</asp:TemplateField>
														</Columns>
													</asp:GridView>
                                                </div>
											</div>
											<!--end::Tap pane-->
											<!--begin::Tap pane-->
											<div class="tab-pane fade" id="kt_list_widget_10_tab_2">
												<asp:Panel ID="pnlNotice" runat="server" CssClass="card card-xl-stretch" Visible="false" style="height: 1vh;">
													<div class="d-flex justify-content-center p-10">
														<h3 class="text-gray-500 fs-6" style="font-style: italic;">No uploaded file yet.</h3>
													</div>
												</asp:Panel>     
												<div class="table-responsive" style="overflow-y: scroll; height: 300px;">
													<!--begin::Files-->
													<asp:GridView ID="gvAttachment" runat="server" class="table table-no-border table-row-bordered border-dashed" AutoGenerateColumns="False">
														<Columns>
															<asp:TemplateField HeaderText="File">
																<ItemTemplate>
																	<div class="d-flex align-items-center">
																		<div class="m-3">
																			<asp:LinkButton ID="lbtnDLAttachment" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' CommandName='<%# Bind("Code") %>' ToolTip="Download file" OnClick="lbtnDLAttachment"><i class="las la-download fs-3"></i></asp:LinkButton>
																		</div>
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
															</asp:TemplateField>
														</Columns>
														</asp:GridView>
													<!--end::Files-->
											   </div>
											</div>
											<!--end::Tap pane-->
										</div>
										<!--end::Tab Content-->
									</div>
									<!--end: Card Body-->
								</div>
								<!--end::List widget 10-->
                            </div>
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
														
														<!--begin::Overlay-->
														<a class="d-block overlay btn btn-sm btn-icon btn-active-success btn-bg-light" data-fslightbox="lightbox-hot-sales" href="<%# Eval("Icon") %>" onclick="closeMDL();">
															<!--begin::Image-->
															<div class="overlay-wrapper bgi-no-repeat bgi-position-center bgi-size-cover card-rounded mb-7" style="background-image:url('"<%# Eval("Icon") %>"');"></div>
															<!--end::Image-->
															<!--begin::Action-->
															<div class="overlay-layer m-0 p-0">
																<i class="las la-eye fs-3"></i>
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
		
		<!--begin::Modal Find-->
		<asp:UpdatePanel ID="mdlBillingPosted" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <ContentTemplate>
                <div class="modal-dialog modal-dialog-top modal-dialog-scrollable" role="document" style="min-width: 800px;">
                    <div class="modal-content">
				        <div class="modal-header">
					        <h5 class="modal-title">Contractor Posted Billing</h5>
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
							<!--begin::Card header-->
							<div class="card-title fs-5 fw-bolder mb-0">Billing Details</div>
							<!--end::Card header-->
							<!--begin::Seperator-->
							<div class="separator separator-dashed my-3"></div>
							<!--end::Seperator-->
							<asp:GridView ID="gvUploadedBilling" runat="server" class="table table-no-border align-middle" AutoGenerateColumns="False" ShowHeader="false" >
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<div class="d-flex align-items-center">
												<div class="d-flex flex-column">
													<span class="text-dark fw-bolder fs-6"><%# Eval("Remarks") %></span>
													<span class="fw-bold d-block fs-7 text-gray-800"><strong class="text-muted fw-bolder">Date Filed: </strong><%# Eval("DateRequired") %></span>
												</div>
											</div>
										</ItemTemplate>
										<ItemStyle CssClass="w-100" />
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
                                            <div class="d-flex justify-content-end">
                                                <div style='<%# Eval("Approved") %>'>
                                                    <span data-bg-toggle="tooltip" data-bs-placement="top" title="Approved">
                                                        <span class="svg-icon svg-icon-3">
															<svg width="800px" height="800px" viewBox="0 0 1024 1024" class="icon"  version="1.1" xmlns="http://www.w3.org/2000/svg"><path d="M905.92 237.76a32 32 0 0 0-52.48 36.48A416 416 0 1 1 96 512a418.56 418.56 0 0 1 297.28-398.72 32 32 0 1 0-18.24-61.44A480 480 0 1 0 992 512a477.12 477.12 0 0 0-86.08-274.24z" fill="#008000" /><path d="M630.72 113.28A413.76 413.76 0 0 1 768 185.28a32 32 0 0 0 39.68-50.24 476.8 476.8 0 0 0-160-83.2 32 32 0 0 0-18.24 61.44zM489.28 86.72a36.8 36.8 0 0 0 10.56 6.72 30.08 30.08 0 0 0 24.32 0 37.12 37.12 0 0 0 10.56-6.72A32 32 0 0 0 544 64a33.6 33.6 0 0 0-9.28-22.72A32 32 0 0 0 505.6 32a20.8 20.8 0 0 0-5.76 1.92 23.68 23.68 0 0 0-5.76 2.88l-4.8 3.84a32 32 0 0 0-6.72 10.56A32 32 0 0 0 480 64a32 32 0 0 0 2.56 12.16 37.12 37.12 0 0 0 6.72 10.56zM230.08 467.84a36.48 36.48 0 0 0 0 51.84L413.12 704a36.48 36.48 0 0 0 51.84 0l328.96-330.56A36.48 36.48 0 0 0 742.08 320l-303.36 303.36-156.8-155.52a36.8 36.8 0 0 0-51.84 0z" fill="#008000" /></svg>
                                                        </span>
                                                    </span>
                                                </div>
                                                <div style='<%# Eval("Declined") %>'>
                                                    <span data-bg-toggle="tooltip" data-bs-placement="top" title="Declined">
                                                        <span class="svg-icon svg-icon-3">
															<svg width="800px" height="800px" viewBox="0 0 48 48" version="1" xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 48 48">
																<path fill="#D50000" d="M24,6C14.1,6,6,14.1,6,24s8.1,18,18,18s18-8.1,18-18S33.9,6,24,6z M24,10c3.1,0,6,1.1,8.4,2.8L12.8,32.4 C11.1,30,10,27.1,10,24C10,16.3,16.3,10,24,10z M24,38c-3.1,0-6-1.1-8.4-2.8l19.6-19.6C36.9,18,38,20.9,38,24C38,31.7,31.7,38,24,38 z"/>
															</svg>
                                                        </span>
                                                    </span>
                                                </div>
                                                <div style='<%# Eval("Submitted") %>'>
														<span class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-2" data-bs-toggle="tooltip" data-bs-placement="top" title="For Approval" onclick="lbtnViewPosted('<%# Eval("Contractor") %>', '<%# Eval("CreatedDate") %>', '<%# Eval("SeqNo") %>');">
															<span class="svg-icon svg-icon-3">
																<svg width="800px" height="800px" viewBox="0 0 100 100" xmlns="http://www.w3.org/2000/svg" version="1.1">
																	<path style="fill:currentColor" d="m 66,59 c 0,0 34,23 31,36 C 86,110 57,66 57,66"/>
																	<path style="fill:currentColor;stroke:#222222;stroke-width:6" d="M 71,44 A 33,33 0 0 1 6,44 33,33 0 1 1 71,44 z"/>
																</svg>
															</span>
														</span>
                                                </div>
                                            </div>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
                        </div>
                    </div>
                </div>

                <!--begin::Hidden Button -->
				<asp:LinkButton ID="lbtnPosted" runat="server" style="display: none;"></asp:LinkButton>
                <!--end::Hidden Button -->
            </ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Find-->

		<!--begin::Modal Comment-->
		<asp:UpdatePanel ID="mdlBilling" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Billing</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabUploaded">Uploaded Billing</a>
								</li>
							</ul>
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
					</div>
					<div class="modal-body">
						<div class="tab-content">
                            <div class="tab-pane fade show active" id="tabUploaded" role="tabpanel" style="overflow-x:auto; scrollbar-width: thin;max-height:300px;min-height:300px;">
								<asp:UpdatePanel ID="upnlBillingUploaded" runat="server" UpdateMode="Conditional">
									<ContentTemplate>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Date</span>
											<asp:Label ID="lblDateReq" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Status</span>
											<asp:Label ID="lblStatus" runat="server" class="form-control">-</asp:Label>
										</div>
										<div class="input-group input-group-sm mb-2">
											<span class="input-group-text min-w-150px">Remarks</span>
											<asp:TextBox ID="lblRemarks" runat="server" class="form-control h-75px min-h-75px mh-75px" TextMode="MultiLine" ReadOnly="true">-</asp:TextBox>
										</div>
										<!--begin::Card header-->
										<div class="card-title fs-5 fw-bolder mb-0 mt-5">Attached File</div>
										<!--end::Card header-->
										<!--begin::Seperator-->
										<div class="separator separator-dashed my-3"></div>
										<!--end::Seperator-->
										<!--begin::Files-->
										<asp:GridView ID="gvUploadedAttachment" runat="server" class="table table-no-border table-row-bordered m-0" ShowHeader="false" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<div class="d-flex align-items-center">
															<div class="d-flex mr-10">
																<asp:LinkButton ID="lbtnDLView" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' CommandName='<%# Bind("Code") %>' ToolTip="Download file" OnClick="lbtnDLView"><i class="las la-file-download fs-3"></i></asp:LinkButton>
															</div>
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
										<!--end::Files-->
									</ContentTemplate>
								</asp:UpdatePanel>
                            </div>
						</div>
					</div>
                    <div class="modal-footer">
						<asp:LinkButton ID="lbtnConApproved" runat="server" class="btn btn-primary">Approved</asp:LinkButton>
						<asp:LinkButton ID="lbtnConDeclined" runat="server" class="btn btn-danger">Declined</asp:LinkButton>
                    </div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->
		
		<!--begin::Modal Comment-->
		<asp:UpdatePanel ID="mdlNote" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Note</h5>
						<div class="d-flex align-items-center flex-wrap gap-1">
							<ul class="nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0">
								<li class="nav-item">
									<a class="nav-link active" data-bs-toggle="tab" href="#tabNTEInput">Inputs</a>
								</li>
							</ul>
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
					</div>
					<div class="modal-body">
						<div class="tab-content">
							<div class="tab-pane fade show active" id="tabNTEInput" role="tabpanel">
								<div class="input-group input-group-sm">
									<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
									<asp:TextBox ID="tbxNote" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
								</div>
							</div>
						</div>
					</div>
                    <div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtnDeclined" runat="server" class="btn btn-primary">Submit</asp:LinkButton>
                    </div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->
		
		<!--begin::Hidden Field -->
		<asp:HiddenField ID="hdnFile" runat="server" />
		<asp:HiddenField ID="hdnCode" runat="server" />
		<asp:HiddenField ID="hdnDate" runat="server" />
		<asp:HiddenField ID="hdnSeqNo" runat="server" />
		<!--end::Hidden Field -->

    </div>	
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

        function previewNotification() {
            Swal.fire({
                text: "Preview not supported for this file type.",
                icon: "error",
                buttonsStyling: false,
                confirmButtonText: "Ok, got it!",
                customClass: {
                    confirmButton: "btn btn-light-danger"
                }
            });
        };

        function openFile(action, fileName) {
            var hdnCode = document.getElementById("ContentPlaceHolder1_hdnCode").value;
			if (action === 'View') {
                var fileType = getFileType(fileName);

                // Open in new tab based on file type
                switch (fileType) {
                    case 'image/png':
                    case 'image/jpeg':
                    case 'image/jpg':
                    case 'image/jpe':
                    case 'image/jfif':
                        //window.open('Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        //window.open('C:/inetpub/contractor/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        //window.open('http://192.168.1.100:804/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        window.open('http://192.168.0.11:808/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        break;
                    case 'application/pdf':
                        //window.open('Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        //window.open('C:/inetpub/contractor/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        //window.open('http://192.168.1.100:804/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        window.open('http://192.168.0.11:808/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                        break;
                    default:
                        previewNotification();
                        break;
                }
            } else if (action === 'Download') {
                //window.open('Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                //window.open('C:/inetpub/contractor/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                //window.open('http://192.168.1.100:804/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                window.open('http://192.168.0.11:808/Assets/Upload/' + hdnCode + '/' + fileName, '_blank');
                //window.location.href = '~/Assets/Upload/Temp/' + fileName;
            }
		};

        function getFileType(fileName) {
            var extension = fileName.split('.').pop().toLowerCase();

            switch (extension) {
                case 'png':
                case 'jpg':
                case 'jpeg':
                case 'jfif':
                    return 'image/' + extension;
                case 'pdf':
                    return 'application/pdf';
                default:
                    return 'application/octet-stream'; // Default for unknown types
            }
		};

		function triggerDeletion(obj) {
			var FileName = obj.getAttribute("data-file-name");
			hdnFile.value = FileName;
            Swal.fire({
                title: 'Question',
                text: 'Remove image?',
                icon: 'question',
                buttonsStyling: false,
                confirmButtonText: 'Ok, got it!',
                customClass: {
                    confirmButton: 'btn btn-primary'
                }
			}).then((result) => {
				if (result.isConfirmed) {
                    //trigger
                    lbtnDelete.click();
				};
			});
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

		function lbtnViewPosted(Code, CDate, SeqNo) {
			var hdnCode = document.getElementById("ContentPlaceHolder1_hdnCode");
			var hdnDate = document.getElementById("ContentPlaceHolder1_hdnDate");
			var hdnSeqNo = document.getElementById("ContentPlaceHolder1_hdnSeqNo");
			var lbtnPosted = document.getElementById("ContentPlaceHolder1_lbtnPosted");

			//reset
			hdnCode.value = "";
			hdnDate.value = "";
			hdnSeqNo.value = "";
			//reset

			//set
			hdnCode.value = Code;
			hdnDate.value = CDate;
			hdnSeqNo.value = SeqNo;
			//set 

            $("#ContentPlaceHolder1_mdlBillingPosted").modal("hide");
			$("#ContentPlaceHolder1_mdlBilling").modal("show");

			//trigger
			lbtnPosted.click();
		};

        //view gallery
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var script_tag = document.createElement('script');
            script_tag.src = 'assets/plugins/custom/fslightbox/fslightbox.bundle.js';
            document.head.appendChild(script_tag);
        }
        //view gallery

		function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {

                //datatable
                var gvHistory = $("#ContentPlaceHolder1_gvHistory").DataTable({
					scrollX: true,
					scrollY: '450px',
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

                //Load
				setTimeout(function () {
					var hdnCode = document.getElementById("ContentPlaceHolder1_hdnCode");
                    $.ajax({
                        type: "POST",
                        url: "SCM000006.aspx/GetFileList",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ parentFolder: hdnCode.value }),
                        success: function (response) {
                            var gvFiles = $("#gvFiles").DataTable({
                                scrollY: "300px",
                                scrollX: true,
                                scrollCollapse: true,
                                bLengthChange: false,
								bSort: false,
								paging: false,
								info: false,
                                bDestroy: true,
                                data: response.d,
                                columns: [
                                    { data: 'Icon' },
                                    { data: 'Name' },
                                    { data: 'Check' }]
                            });
                        },
                        error: function (error) {
                            console.error("Error fetching file details:", error);
                        }
                    });
                }, 1000);
                //Load

                //upload
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "SCM000012.ashx?FormCode=SCM000006&ID=" + ltrlID + "&Temp",
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
                        }, 2000);
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
