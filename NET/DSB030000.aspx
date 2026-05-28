<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB030000.aspx.vb" Inherits="NET.DSB030000" MaintainScrollPositionOnPostback = "true"%>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Forms</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Overview and stats</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<div class="card card-flush mb-5">
			<!--begin::Header-->
			<div class="card-header">
                <!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Overall</span>
                    <span class="text-muted fw-bold fs-6"">Total Forms</span>
				</h3>
				<!--end::Title-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
			<div class="card-body pt-0 pb-0" >
                <div class="row g-5">
                    <div class="col-lg-3">
                        <!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
							    <div class="symbol symbol-50px me-4">
								    <div class="symbol-label fs-2 fw-bold bg-danger text-inverse-danger pointer"><a onclick="ViewOverview('Total');">T</a></div>
							    </div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Total');">Total</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Total');"><asp:Label ID="lbl01TotalForm_Total" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
                        <!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
							    <div class="symbol symbol-50px me-4">
								    <div class="symbol-label fs-2 fw-bold bg-success text-inverse-danger pointer"><a onclick="ViewOverview('Open');">O</a></div>
							    </div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Open');">Open</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Open');"><asp:Label ID="lbl01TotalForm_Open" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
                        <!--begin::Item-->
						<div class="d-flex border border-gray-300 border-dashed rounded p-3">
							<!--begin::Block-->
							<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
							    <div class="symbol symbol-50px me-4">
								    <div class="symbol-label fs-2 fw-bold bg-info text-inverse-danger pointer"><a onclick="ViewOverview('Closed');">C</a></div>
							    </div>
      							<!--end::Symbol-->
								<!--begin::Section-->
								<div class="me-2">
									<a href="#" class="text-gray-800 text-hover-primary fs-6 fw-bolder pointer" onclick="ViewOverview('Closed');">Closed</a>
								</div>
								<!--end::Section-->
							</div>
							<!--end::Block-->
							<!--begin::Info-->
							<div class="d-flex align-items-center">
								<span class="text-gray-800 fw-bolder fs-4 me-3 pointer"><a onclick="ViewOverview('Closed');"><asp:Label ID="lbl01TotalForm_Closed" runat="server"></asp:Label></a></span>
							</div>
							<!--end::Info-->
						</div>
						<!--end::Item-->
                    </div>
                    <div class="col-lg-9">
                        <div id="div01TotalForm" style="height:270px"></div>
                    </div>
                </div>
						
			</div>
			<!--end::Body-->
		</div>

        <div class="row g-5 mb-5">
            <div class="col-lg-6">
                <div class="card card-flush">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Open Forms</span>
                            <span class="text-muted fw-bold fs-6"">Per Department</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body pt-0 pb-0" >
                        <div class="row g-5">
                            <div class="col-lg-6 pb-7">
                                <div style="overflow-x:auto; scrollbar-width: thin;height:260px">
                                    <asp:GridView ID="gv02OpenFormPerDepartment" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					                <Columns>
						                <asp:TemplateField HeaderText="Open Task">
							                <ItemTemplate>
								               <div class="d-flex align-items-center pl-3">
											        <div class="d-flex flex-column me-3">
												       <span class="bullet h-15px w-15px" style='<%# Eval("Background") %>'></span>
											        </div>
											        <div class="d-flex flex-column w-100">
												        <span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("DepName") %></span>
											        </div>
                                                   <div class="d-flex flex-column min-w-100px me-3">
												        <%# Eval("Total") %>
											        </div>
										        </div>
							                </ItemTemplate>
						                </asp:TemplateField>
					                </Columns>
				                </asp:GridView>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <!--begin::Chart-->
					            <div class="d-flex flex-center">
						            <div id="div02OpenFormPerDepartment" style="height: 260px; width:260px; position:relative;top:0px"></div>
					            </div>
					            <!--end::Chart-->
                            </div>
                        </div>
						
			        </div>
			        <!--end::Body-->
		        </div>
            </div>
            <div class="col-lg-6">
                <div class="card card-flush">
			        <!--begin::Header-->
			        <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Open Forms</span>
                            <span class="text-muted fw-bold fs-6"">Per Year</span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body pt-0 pb-0" >
                        <div class="row g-5">
                            <div class="col-lg-6 pb-7">
                                <div style="overflow-x:auto; scrollbar-width: thin;height:260px">
                                    <asp:GridView ID="gv02OpenFormPerYear" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					                <Columns>
						                <asp:TemplateField HeaderText="Open Task">
							                <ItemTemplate>
								               <div class="d-flex align-items-center pl-3">
											        <div class="d-flex flex-column me-3">
												       <span class="bullet h-15px w-15px" style='<%# Eval("Background") %>'></span>
											        </div>
											        <div class="d-flex flex-column w-100">
												        <span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Year") %></span>
											        </div>
                                                   <div class="d-flex flex-column min-w-100px me-3">
												        <%# Eval("Total") %>
											        </div>
										        </div>
							                </ItemTemplate>
						                </asp:TemplateField>
					                </Columns>
				                </asp:GridView>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <!--begin::Chart-->
					            <div class="d-flex flex-center">
						            <div id="div02OpenFormPerYear" style="height: 260px;"></div>
					            </div>
					            <!--end::Chart-->
                            </div>
                        </div>
						
			        </div>
			        <!--end::Body-->
		        </div>
            </div>
        </div>
		
		<div class="card card-flush mb-5">
			<!--begin::Header-->
			<div class="card-header">
                <!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Open Forms</span>
                    <span class="text-muted fw-bold fs-6"">Aging</span>
				</h3>
				<!--end::Title-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
			<div class="card-body pt-0 pb-0" >
                <div class="row g-5">
                    <div class="col-lg-3 pb-7">
                        <div style="overflow-x:auto; scrollbar-width: thin;height:260px">
                            <asp:GridView ID="gv04OpenFormAging" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					        <Columns>
						        <asp:TemplateField HeaderText="Open Task">
							        <ItemTemplate>
								        <div class="d-flex align-items-center pl-3">
											<div class="d-flex flex-column w-100">
												<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("Aging") %></span>
											</div>
                                            <div class="d-flex flex-column min-w-100px me-3">
												<%# Eval("Total") %>
											</div>
										</div>
							        </ItemTemplate>
						        </asp:TemplateField>
					        </Columns>
				        </asp:GridView>
                        </div>
                    </div>
                    <div class="col-lg-9">
                        <!--begin::Chart-->
					    <div class="d-flex flex-center">
						    <div id="div04OpenFormAging" style="height: 270px; width:100%"></div>
					    </div>
					    <!--end::Chart-->
                    </div>
                </div>
						
			</div>
			<!--end::Body-->
		</div>
		
        <asp:UpdatePanel ID="upnl05InOut" runat="server" UpdateMode="Conditional" class="card card-flush">
		<ContentTemplate>
            <!--begin::Header-->
			<div class="card-header">
                <!--begin::Title-->
				<h3 class="card-title align-items-start flex-column">
					<span class="card-label fw-bolder fs-3 mb-1">Accomplishment</span>
                    <span class="text-muted fw-bold fs-6"">Per Department</span>
				</h3>
				<!--end::Title-->
				<!--begin::Card toolbar-->
  				<div class="card-toolbar flex-row-fluid justify-content-end">
                    <div class="d-flex align-items-center">
                        <div class="d-flex flex-column me-3">
						    <span class="bullet h-15px w-15px bg-info"></span>
					    </div>
                        <div class="d-flex flex-column me-3">
						    Within
					    </div>
                        <div class="d-flex flex-column me-3">
						    <span class="bullet h-15px w-15px bg-warning"></span>
					    </div>
                        <div class="d-flex flex-column me-3">
						    Due
					    </div>
                        <div class="d-flex flex-column me-3">
						    <span class="bullet h-15px w-15px bg-danger"></span>
					    </div>
                        <div class="d-flex flex-column me-3">
						    Delay
					    </div>
					</div>
					 <div class="d-flex align-items-center">
						<div class="d-flex flex-column w-100px me-3">
							 <input id="tbx05DateFrom" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Pick a date" />
						</div>
						<div class="d-flex flex-column w-100px me-3">
							 <input id="tbx05DateTo" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Pick a date" />
						</div>
                        <div class="d-flex flex-column w-100px me-3">
                            <asp:Button ID="btn05Filter" runat="server" CssClass="btn btn-sm btn-light" Text="Filter" />
						</div>
					</div>
				</div>
				<!--end::Card toolbar-->
			</div>
			<!--end::Header-->
			<!--begin::Body-->
			<div class="card-body pt-0 pb-7" >
                <div style="overflow-x:auto; scrollbar-width: thin;height:260px">
                    <asp:GridView ID="gv05InOut" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					<Columns>
						<asp:TemplateField HeaderText="Open Task">
							<ItemTemplate>
								<div class="d-flex align-items-center pl-3">
									<div id="<%# Eval("DepCode") %>" class="d-flex flex-column pointer min-w-100px" onclick="ViewAccomplishment(this.id);">
										<span class="text-dark fw-bolder fs-6 nowrap-auto"><%# Eval("DepName") %></span>
									</div>
                                    <div class="d-flex flex-column min-w-100px me-3">
										<span class="text-dark fw-bold fs-6 nowrap-auto"><%# Eval("IN") %></span><span class='text-muted fs-8 fw-bold'>In</span>
									</div>
									<div class="d-flex flex-column min-w-100px me-3">
                                        <span class="text-dark fw-bold fs-6 nowrap-auto"><%# Eval("OUT") %></span><span class='text-muted fs-8 fw-bold'>Out</span>
									</div>
									<div class="d-flex flex-column min-w-300 w-100 me-3">
										<div class="progress h-20px">
											<div class="progress-bar bg-info" role="progressbar" style='<%# Eval("GoodStyle") %>' aria-valuenow='<%# Eval("GoodValue") %>' aria-valuemin="0" aria-valuemax="100"><span class="text-white"><%# Eval("Good") %></span></div>
											<div class="progress-bar bg-warning" role="progressbar" style='<%# Eval("DueStyle") %>' aria-valuenow='<%# Eval("DueValue") %>' aria-valuemin="0" aria-valuemax="100"><span class="text-white"><%# Eval("Due") %></span></div>
											<div class="progress-bar bg-danger" role="progressbar" style='<%# Eval("DelayStyle") %>' aria-valuenow='<%# Eval("DelayValue") %>' aria-valuemin="0" aria-valuemax="100"><span class="text-white"><%# Eval("Delay") %></span></div>
										</div>
									</div>
								</div>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
                </div>
			</div>
			<!--end::Body-->
        </ContentTemplate>
		</asp:UpdatePanel>
        
		<!--begin::Modal FRM Summary -->
		<div id="mdl01FRM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Form
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
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" onkeyup="Search_Form()" />
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						    <!--begin::list-->
                            <table id="tbl01FRM" class="table table-no-border table-row-bordered table-hover align-middle w-100">
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
		<!--end::Modal FRM Summary-->
        
		<!--begin::Modal FRM Summary -->
		<div id="mdl02FRM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen modal-dialog-scrollable" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Aging of CIIS Forms per Department
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
					<div class="modal-body pt-0">
						<div style="overflow-x:auto; scrollbar-width: thin;">
						    <!--begin::list-->
                            <table id="tbl02FRM" class="table table-no-border table-row-bordered table-hover align-middle w-100">
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
		<!--end::Modal FRM Summary-->
        
		<!--begin::Modal FRM Summary -->
		<div id="mdl03FRM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen modal-dialog-scrollable" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Accomplishment
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
					<div class="modal-body pt-0">
                        <!--begin::Page loading(append to body)-->
                        <div class="page-loader flex-column">
                            <span class="spinner-border text-primary" role="status"></span>
                            <span class="text-muted fs-6 fw-semibold mt-5">Loading...</span>
                        </div>
                        <!--end::Page loading-->

                        <!--begin::Header-->
			            <div class="card-header">
				            <!--begin::Card toolbar-->
  				            <div class="card-toolbar flex-row-fluid">
                                <div class="d-flex align-items-center justify-content-center">
                                    <div class="d-flex flex-center me-3 text-muted fw-bolder">
						                <span class="bullet h-15px w-15px bg-info"></span>
                                        Within
					                </div>
                                    <div class="d-flex flex-center me-3 text-muted fw-bolder">
						                <span class="bullet h-15px w-15px bg-warning"></span>
						                Due
					                </div>
                                    <div class="d-flex flex-center me-3 text-muted fw-bolder">
						                <span class="bullet h-15px w-15px bg-danger"></span>
						                Delay
					                </div>
					            </div>
				            </div>
				            <!--end::Card toolbar-->
			            </div>
			            <!--end::Header-->

						<div style="overflow-x:auto; scrollbar-width: thin;">
						    <!--begin::list-->
                            <table id="tbl03FRM" class="table table-no-border table-row-bordered table-hover align-middle w-100">
                                <thead>
                                    <tr class="d-none">
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
		<!--end::Modal FRM Summary-->
        
		<!--begin::Modal FRM Summary -->
		<div id="mdl04Loader" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen modal-dialog-scrollable" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Accomplishment
						</h5>
					</div>
				</div>
			</div>
		</div>
		<!--end::Modal FRM Summary-->
	</div>
    <!--end::Accomplishments-->
    <!--end::Col-->

	<!-- scripts related to this page -->	
    <script type="text/javascript">
        //mdl01FRM
        function Search_Form() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("tbx01Find");
            filter = input.value.toUpperCase();
            table = document.getElementById("tbl01FRM");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    console.log(td.innerText);
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        };
        function Display_Form(response) {
            var tbl01FRM = document.getElementById("tbl01FRM");

            //Remove all rows.
            var rowCount = tbl01FRM.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                tbl01FRM.deleteRow(i);
            }

            //Add the data rows.
            for (var i = 0; i < response.length; i++) {
                row = tbl01FRM.insertRow(-1);

                var cell = row.insertCell(-1);
                cell.innerHTML = response[i].Bullet;
                cell.setAttribute("class", "mw-5px min-w-5px");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Data;
                cell.setAttribute("class", "w-100");
            }

            $('#mdl01FRM').modal('show');
        };
        //mdl01FRM

        //mdl02FRM
        function Display_Aging(response) {
            var tbl02FRM = document.getElementById("tbl02FRM");

            //Remove all rows.
            var rowCount = tbl02FRM.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                tbl02FRM.deleteRow(i);
            }

            //Add the data rows.
            for (var i = 0; i < response.length; i++) {
                row = tbl02FRM.insertRow(-1);

                var cell = row.insertCell(-1);
                cell.innerHTML = response[i].Bullet;
                cell.setAttribute("class", "mw-5px min-w-5px");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Data;
                cell.setAttribute("class", "w-100");
            }

            $('#mdl02FRM').modal('show');
        };
        //mdl02FRM

        //mdl03FRM
        function Display_Accomplishment(response) {
            var tbl03FRM = document.getElementById("tbl03FRM");

            //Remove all rows.
            var rowCount = tbl03FRM.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                tbl03FRM.deleteRow(i);
            }

            //Add the data rows.
            for (var i = 0; i < response.length; i++) {
                row = tbl03FRM.insertRow(-1);

                var cell = row.insertCell(-1);
                cell.innerHTML = response[i].Data;
                cell.setAttribute("class", "w-100");
            }

            $('#mdl03FRM').modal('show');
        };
        //mdl03FRM

        //Overall Form 
        function ViewOverview(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Overview Count Per Forms',
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response);
                },
			});
        };
        //Overall Form

        //Overall Form - Bar Chart
        function ViewFormsTotal(Month, Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Overview Count Per Month',
                    'Month': Month,
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        };
        //Overall Form - Bar Chart

        //Open Form - Per Department
        function ViewOpenForm(Obj, Code) {
            var DeptName = Obj.getAttribute("data-name");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Department',
                    'DeptCode': Code
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Per Department


        //Open Form - Per Year
        function ViewOpenYear(Year) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Year',
                    'Year': Year
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Per Year


        //Open Form - Aging Modal Details (Per Department)
        function ViewAgingDetails(Obj, Code) {
            var DeptName = Obj.getAttribute("data-name");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Employee',
                    'DeptCode': Code
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Details (Per Department)

        //Open Form - Aging Modal Details (Per Department - Employee)
        function ViewEmpDetails(Code) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Details',
                    'EmpCode': Code
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Details (Per Department - Employee)

        //Open Form - Aging Modal Details (Per Year)
        function ViewAgingYrDetails(Obj, Code) {
            var Year = Obj.getAttribute("data-year");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Year Details',
                    'Year': Year,
                    'DeptCode': Code
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Details (Per Year)

        //Open Form - Aging Modal Details (Per Year - Employee)
        function ViewEmpYrDetails(Obj, Code) {
            var Year = Obj.getAttribute("data-year");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Year Emp Details',
                    'EmpCode': Code,
                    'Year': Year
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Details (Per Year - Employee)

        //Open Form - Aging Modal Per Day
        function ViewOpenAgingDetails(Obj, Code) {
            var Aging = Obj.getAttribute("data-aging");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Aging Details',
                    'Aging': Aging,
                    'DeptCode': Code
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Per Day

        //Open Form - Aging Modal Per Day (Employee)
        function ViewPerAgingDetails(Obj, Code) {
            var Aging = Obj.getAttribute("data-aging");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Emp Aging Details',
                    'Aging': Aging,
                    'EmpCode': Code
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Per Day (Employee)

        //Open Form - Aging Modal Per Day (Aging)
        function ViewAgingForm(Aging) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Aging Form Per Aging',
                    'Aging': Aging
                },
                success: function (response) {
                    Display_Aging(response);
                },
            });
        };
        //Open Form - Aging Modal Per Day (Aging)

        //Accomplishment - Per Department
        function ViewAccomplishment(Code) {
            var tbx05DateFrom = document.getElementById("ContentPlaceHolder1_tbx05DateFrom");
            var tbx05DateTo = document.getElementById("ContentPlaceHolder1_tbx05DateTo");
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                cache: false,
                data: {
                    'FormCode': 'DSB030000',
                    'Type': 'Accomplishment Details',
                    'Code': Code,
                    'DateFrom': tbx05DateFrom.value,
                    'DateTo': tbx05DateTo.value
                },
                beforeSend: function () {
                    console.log("LOADING");
                },
                complete: function () {
                    console.log("DONE LOADING HIDING CONTENT....");
                },
                success: function (response) {
                    Display_Accomplishment(response);
                }
            });
        };
        //Accomplishment - Per Department

        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {

            //date
            $('[data-kt-repeater="datepicker"]').flatpickr({
                dateFormat: "m/d/Y"
            });
            //date

            //Total form
            var ltrl01TotalForm_Total = '<asp:Literal ID="ltrl01TotalForm_Total" runat="server" />';
            var ltrl01TotalForm_Closed = '<asp:Literal ID="ltrl01TotalForm_Closed" runat="server" />';
            var ltrl01TotalForm_Open = '<asp:Literal ID="ltrl01TotalForm_Open" runat="server" />';
            jQuery(function ($) {
                var yearnow = new Date().getFullYear();
                document.getElementById('div01TotalForm').innerHTML = "";
                var element = document.getElementById('div01TotalForm');
                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

                const ArrayTotalForm_Total = ltrl01TotalForm_Total.split(",");
                const ArrayTotalForm_Closed = ltrl01TotalForm_Closed.split(",");
                const ArrayTotalForm_Open = ltrl01TotalForm_Open.split(",");

                var options = {
                    series: [{
                        name: 'Total',
                        data: ArrayTotalForm_Total
                    }, {
                        name: 'Closed',
                        data: ArrayTotalForm_Closed
                    }, {
                        name: 'Open',
                        data: ArrayTotalForm_Open
                    }],
                    chart: {
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var monthVal;
                                if (Month == "<" + yearnow) {
                                    monthVal = yearnow;
                                } else if (Month == "Jan") {
                                    monthVal = 1;
                                } else if (Month == "Feb") {
                                    monthVal = 2;
                                } else if (Month == "Mar") {
                                    monthVal = 3;
                                } else if (Month == "Apr") {
                                    monthVal = 4;
                                } else if (Month == "May") {
                                    monthVal = 5;
                                } else if (Month == "Jun") {
                                    monthVal = 6;
                                } else if (Month == "Jul") {
                                    monthVal = 7;
                                } else if (Month == "Aug") {
                                    monthVal = 8;
                                } else if (Month == "Sep") {
                                    monthVal = 9;
                                } else if (Month == "Oct") {
                                    monthVal = 10;
                                } else if (Month == "Nov") {
                                    monthVal = 11;
                                } else if (Month == "Dec") {
                                    monthVal = 12;
                                } else {
                                    monthVal = 0;
                                }
                                ViewFormsTotal(monthVal, Status);
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '90%',
                            endingShape: 'rounded'
                        },
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ['<' + yearnow, 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    },
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + " Forms"
                            }
                        }
                    },
                    colors: ['#f1416c', '#009ef7', '#279852'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    height: "200px"
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            //Total Form

            //Open Form per Department
            var ltrl02OpenFormPerDepartment_Code = '<asp:Literal ID="ltrl02OpenFormPerDepartment_Code" runat="server" />';
            var ltrl02OpenFormPerDepartment_Value = '<asp:Literal ID="ltrl02OpenFormPerDepartment_Value" runat="server" />';
            var ltrl02OpenFormPerDepartment_Color = '<asp:Literal ID="ltrl02OpenFormPerDepartment_Color" runat="server" />';
            var ltrl02OpenFormPerDepartment_DeptName = '<asp:Literal ID="ltrl02OpenFormPerDepartment_DeptName" runat="server" />';
            jQuery(function ($) {
                document.getElementById('div02OpenFormPerDepartment').innerHTML = "";
                var element = document.getElementById('div02OpenFormPerDepartment');
                const Array02OpenFormPerDepartment_Code = ltrl02OpenFormPerDepartment_Code.split(",");
                const Array02OpenFormPerDepartment_Value = ltrl02OpenFormPerDepartment_Value.split(",");
                const Array02OpenFormPerDepartment_Color = ltrl02OpenFormPerDepartment_Color.split(",");
                const Array02OpenFormPerDepartment_DeptName = ltrl02OpenFormPerDepartment_DeptName.split(",");
                const newArray02OpenFormPerDepartment_Value = Array02OpenFormPerDepartment_Value.map(Number);
                if (!element) {
                    return;
                }
                var options = {
                    series: newArray02OpenFormPerDepartment_Value,
                    chart: {
                        type: 'donut', events:
                        {
                            dataPointSelection: function (event, chartContext, config) {
                                const currPos = config.dataPointIndex;
                                const Status = config.w.config.labels[config.dataPointIndex];
                                //ViewWARDivisionStatus('Laguna', Status)
                                $.ajax({
                                    type: "POST",
                                    url: "HND000003.ashx",
                                    data: {
                                        'FormCode': 'DSB030000',
                                        'Type': 'Aging Form Per Department',
                                        'DeptCode': Array02OpenFormPerDepartment_Code[currPos]
                                    },
                                    success: function (response) {
                                        Display_Aging(response);
                                    },
                                });
                            }
                        },
                    },
                    plotOptions:
                    {
                        pie:
                        {
                            donut:
                            {
                                size: '0%',
                                labels:
                                {
                                    value:
                                    {
                                        fontSize: '10px'
                                    }
                                }
                            }
                        }
                    },
                    labels: Array02OpenFormPerDepartment_DeptName,
                    legend: {
                        show: false,
                    },
                    colors: Array02OpenFormPerDepartment_Color,
                    grid: {
                        padding: {
                            top: -2,
                            left: -5
                        }
                    },
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
			//Open Form per Department

            //Open Form per Year
            var ltrl03OpenFormPerYear_Previous = '<asp:Literal ID="ltrl03OpenFormPerYear_Previous" runat="server" />';
            var ltrl03OpenFormPerYear_Current = '<asp:Literal ID="ltrl03OpenFormPerYear_Current" runat="server" />';
            jQuery(function ($) {
                var yearnow = new Date().getFullYear();
                document.getElementById('div02OpenFormPerYear').innerHTML = "";
                var element = document.getElementById('div02OpenFormPerYear');
                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');

				const ArrayOpenFormPerYear_Previous = ltrl03OpenFormPerYear_Previous.split(",");
                const ArrayOpenFormPerYear_Current = ltrl03OpenFormPerYear_Current.split(",");

                var options = {
                    series: [{
                        name: yearnow,
                        data: ArrayOpenFormPerYear_Current
						},{
                        name: '<' + yearnow,
                        data: ArrayOpenFormPerYear_Previous
						}],
                    chart: {
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var CurrentYr = new Date();
                                var Year;
                                if (Status == "<" + CurrentYr.getFullYear()) {
                                    Year = "Previous";
                                } else {
                                    Year = Status;
                                };
                                $.ajax({
                                    type: "POST",
                                    url: "HND000003.ashx",
                                    data: {
                                        'FormCode': 'DSB030000',
                                        'Type': 'Aging Form Per Year Chart',
                                        'Year': Year
                                    },
                                    success: function (response) {
                                        Display_Form(response);
                                    },
                                });
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '90%',
                            endingShape: 'rounded'
                        },
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ['Year'],
                    },
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + " Forms"
                            }
                        }
                    },
                    colors: ['#279852', '#f1416c'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    height: "200px"
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
			//Open Form per Year

			//Open Form Aging
            var ltrl04OpenFormAging_Category = '<asp:Literal ID="ltrl04OpenFormAging_Category" runat="server" />';
            var ltrl04OpenFormAging_Data = '<asp:Literal ID="ltrl04OpenFormAging_Data" runat="server" />';
			jQuery(function ($) {
                document.getElementById('div04OpenFormAging').innerHTML = "";
                var element = document.getElementById('div04OpenFormAging');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');

                const Array04OpenFormAging_Category = ltrl04OpenFormAging_Category.split(",");
                const Array04OpenFormAging_Data = ltrl04OpenFormAging_Data.split(",");

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'Aging',
                        data: Array04OpenFormAging_Data
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'area',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Aging = config.w.globals.categoryLabels[config.dataPointIndex];
                                $.ajax({
                                    type: "POST",
                                    url: "HND000003.ashx",
                                    data: {
                                        'FormCode': 'DSB030000',
                                        'Type': 'Aging Form Per Aging',
                                        'Aging': Aging
                                    },
                                    success: function (response) {
                                        Display_Aging(response);
                                    },
                                });
                            },
                        },
                    },
                    plotOptions: {},
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 1
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [baseColor]
                    }, 
                    xaxis: {
                        categories: Array04OpenFormAging_Category,
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
                        },
                        crosshairs: {
                            position: 'front',
                            stroke: {
                                color: labelColor,
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
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            }
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
                        intersect: true,
                        shared: false,
                        style: {
                            fontSize: '12px'
                        },
                        y: {
                            formatter: function (val) {
                                return val + ' Forms'
                            }
                        }
                    },
                    colors: [baseLightColor],
                    grid: {
                        borderColor: baseColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    markers: {
						colors: [baseLightColor],
						strokeColor: [baseColor],
                        strokeWidth: 3,
                        size: 3
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
			//Open Form Aging

		}

    </script>
	<!-- scripts related to this page -->

</asp:Content>
