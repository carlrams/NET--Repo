<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB020000.aspx.vb" Inherits="NET.DSB020000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" class="content flex-row-fluid" id="kt_content">

		<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
			<!--begin::Container-->
			<div class="container-fluid d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Personal</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">View personal data, overview and stats</li>
						<!--end::Item-->
						<!--begin::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
            <asp:Button ID="btnView" runat="server" Text="Button" OnClick="btnView_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
        
		<asp:Panel ID="pnl01Assigned" runat="server" class="row g-5 mb-5">

		    <div class="col-xxl-8">
			    <!--begin::Chart widget 22-->
			    <div class="card h-100 card-flush">
                    <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Form</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="View_Form('All')"><asp:Label ID="lbl01Total" runat="server" Text="0 Form"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body">
					     <!--begin::Wrapper-->
						<div class="d-flex flex-wrap flex-md-nowrap">
							<!--begin::Items-->
							<div class="me-md-5 w-100">
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<!--begin::Symbol-->
										<div class="symbol symbol-50px me-4">
											<span class="symbol-label">
												<span class="svg-icon svg-icon-2qx svg-icon-info">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
														<path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
													</svg>
												</span>
											</span>
										</div>
										<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<span class="text-gray-800 text-hover-info fs-6 fw-bolder pointer" onclick="View_Form('Good')">Good</span>
											<span class="text-gray-400 fw-bolder d-block fs-7">Form Assigned approved within the date.</span>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span id="spn01WithinTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
										<span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
										<span id="spn01FormWithinTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
										<span id="spn01FormPercentageWithin" runat="server" class="badge badge-lg badge-info align-self-center px-2"></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<!--begin::Symbol-->
										<div class="symbol symbol-50px me-4">
											<span class="symbol-label">
												<span class="svg-icon svg-icon-2qx svg-icon-warning">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
														<path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
													</svg>
												</span>
											</span>
										</div>
										<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<span class="text-gray-800 text-hover-warning fs-6 fw-bolder pointer" onclick="View_Form('Due')">Due</span>
											<span class="text-gray-400 fw-bolder d-block fs-7">Form Assigned approved due to date.</span>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span id="spn01DueTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
										<span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
										<span id="spn01FormDueTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
										<span id="spn01FormPercentageDue" runat="server" class="badge badge-lg badge-warning align-self-center px-2"></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<!--begin::Symbol-->
										<div class="symbol symbol-50px me-4">
											<span class="symbol-label">
												<span class="svg-icon svg-icon-2qx svg-icon-danger">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
														<path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
													</svg>
												</span>
											</span>
										</div>
										<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<span class="text-gray-800 text-hover-danger fs-6 fw-bolder pointer" onclick="View_Form('Delay')">Delay</span>
											<span class="text-gray-400 fw-bolder d-block fs-7">Form Assigned approved delay to date.</span>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span id="spn01DelayTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
										<span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
										<span id="spn01FormDelayTotal" runat="server"  class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
										<span id="spn01FormPercentageDelay" runat="server" class="badge badge-lg badge-danger align-self-center px-2"></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
							</div>
							<!--end::Items-->
							<!--begin::Container-->
							<div class="d-flex justify-content-between flex-column w-225px w-md-600px mx-auto mx-md-0">
								<!--begin::Title-->
								<div class="fs-4 fw-bolder text-gray-900 text-center">Overview Form Assigned
								<br />Overall</div>
								<!--end::Title-->
								<!--begin::Chart-->
								<div id="assigned_donut_chart" class="mx-auto"></div>
								<!--end::Chart-->
							</div>
							<!--end::Container-->
						</div>
						<!--end::Wrapper-->
				    </div>
				    <!--end: Card Body-->
			    </div>
			    <!--end::Chart widget 22-->
		    </div>

		    <div class="col-xxl-4">
			    <!--begin::Slider Widget 3-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
					    <!--begin::Title-->
					    <h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Overall Forms</span>
						    <span id="spn01OverallDetails" class="text-gray-400 mt-1 fw-bold fs-7"></span>
					    </h3>
					    <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body p-0">
					    <!--begin::Title-->
						<span id="spn01Status" class="text-gray-800 fw-bolder fs-4 mb-3 px-8"></span>
						<!--end::Title-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 px-8">
							<!--begin::Number-->
							<span id="spn01Total" class="fs-2qx text-gray-800 fw-bolder"></span>
							<!--end::Number-->
							<!--begin::Progress-->
							<div class="progress h-6px w-100 mx-3 bg-light-primary">
								<div id="div01PercentageBar" class="progress-bar" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span id="spn01OverallPercentage" class="text-gray-400 fw-bolder fs-4"></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
						<!--begin::Chart-->
						<div id="overall_form_area_chart" class="min-h-auto ps-4 pe-6"></div>
						<!--end::Chart-->
				    </div>
				    <!--end::Body-->
			    </div>
			    <!--end::Slider Widget 3-->
		    </div>

		</asp:Panel>
        
		<asp:Panel ID="pnl02WorkOrder" runat="server" class="row g-5 mb-5">

		    <div class="col-xxl-8">
			    <!--begin::Chart widget 22-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Work Order</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARAll()"><asp:Label ID="lbl02Total" runat="server" Text="0 work order"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body">
					    <!--begin::Wrapper-->
					    <div class="d-flex flex-wrap flex-md-nowrap">
						    <!--begin::Items-->
						    <div class="me-md-5 w-100">
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-info">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-info fs-6 fw-bolder pointer" onclick="woStatusGood(this)">Good</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Work Order approved within the date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn02WithinTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn02FormWithinTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn02FormPercentageWithin" runat="server" class="badge badge-lg badge-info align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-warning">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-warning fs-6 fw-bolder pointer" onclick="woStatusDue(this)">Due</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Work Order approved due to date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn02DueTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn02FormDueTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn02FormPercentageDue" runat="server" class="badge badge-lg badge-warning align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-danger">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-danger fs-6 fw-bolder pointer" onclick="woStatusDelay(this)">Delay</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Work Order approved delay to date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn02DelayTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn02FormDelayTotal" runat="server"  class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn02FormPercentageDelay" runat="server" class="badge badge-lg badge-danger align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
						    </div>
						    <!--end::Items-->
						    <!--begin::Container-->
						    <div class="d-flex justify-content-between flex-column w-225px w-md-600px mx-auto mx-md-0">
							    <!--begin::Title-->
							    <div class="fs-4 fw-bolder text-gray-900 text-center">Overview Work Order
							    <br />Overall</div>
							    <!--end::Title-->
							    <!--begin::Chart-->
							    <div id="workorder_donut_chart" class="mx-auto"></div>
							    <!--end::Chart-->
						    </div>
						    <!--end::Container-->
					    </div>
					    <!--end::Wrapper-->
				    </div>
				    <!--end: Card Body-->
			    </div>
			    <!--end::Chart widget 22-->
		    </div>

		    <div class="col-xxl-4">
			<!--begin::Slider Widget 3-->
			<div class="card h-100 card-flush">
				<!--begin::Header-->
				<div class="card-header">
					<!--begin::Title-->
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder text-dark">Overall Work Order</span>
						<span id="spn02OverallDetails" class="text-gray-400 mt-1 fw-bold fs-7"></span>
					</h3>
					<!--end::Title-->
				</div>
				<!--end::Header-->
				<!--begin::Body-->
				<div class="card-body p-0">
					<!--begin::Title-->
					<span id="spn02Status" class="text-gray-800 fw-bolder fs-4 mb-3 px-8"></span>
					<!--end::Title-->
					<!--begin::Statistics-->
					<div class="d-flex align-items-center w-100 px-8">
						<!--begin::Number-->
						<span id="spn02Total" class="fs-2qx text-gray-800 fw-bolder"></span>
						<!--end::Number-->
						<!--begin::Progress-->
						<div class="progress h-6px w-100 mx-3 bg-light-primary">
							<div id="div02PercentageBar" class="progress-bar" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
						</div>
						<!--end::Progress-->
						<!--begin::Value-->
						<span id="spn02OverallPercentage" class="text-gray-400 fw-bolder fs-4"></span>
						<!--end::Value-->
					</div>
					<!--end::Statistics-->
					<!--begin::Chart-->
					<div id="overall_wo_area_chart" class="min-h-auto ps-4 pe-6"></div>
					<!--end::Chart-->
				</div>
				<!--end::Body-->
			</div>
			<!--end::Slider Widget 3-->
		</div>

		</asp:Panel>

		<asp:Panel ID="pnl03ConstructionTask" runat="server" class="row g-5 mb-5">

		    <div class="col-xxl-8">
			    <!--begin::Chart widget 22-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
                         <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Construction Task</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARAll()"><asp:Label ID="lbl03Total" runat="server" Text="0 task"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body">
					    <!--begin::Wrapper-->
					    <div class="d-flex flex-wrap flex-md-nowrap">
						    <!--begin::Items-->
						    <div class="me-md-5 w-100">
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-info">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-info fs-6 fw-bolder pointer" onclick="ctStatusGood(this)">Good</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Construction Task approved within the date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn03WithinTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn03CTWithinTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn03CTPercentageWithin" runat="server" class="badge badge-lg badge-info align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-warning">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-warning fs-6 fw-bolder pointer" onclick="ctStatusDue(this)">Due</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Construction Task approved due to date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn03DueTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn03CTDueTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn03CTPercentageDue" runat="server" class="badge badge-lg badge-warning align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-danger">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-danger fs-6 fw-bolder pointer" onclick="ctStatusDelay(this)">Delay</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Construction Task approved delay to date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn03DelayTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn03CTDelayTotal" runat="server"  class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn03CTPercentageDelay" runat="server" class="badge badge-lg badge-danger align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
						    </div>
						    <!--end::Items-->
						    <!--begin::Container-->
						    <div class="d-flex justify-content-between flex-column w-225px w-md-600px mx-auto mx-md-0">
							    <!--begin::Title-->
							    <div class="fs-4 fw-bolder text-gray-900 text-center">Overview Construction Task(s)
							    <br />Overall</div>
							    <!--end::Title-->
							    <!--begin::Chart-->
							    <div id="construction_donut_chart" class="mx-auto"></div>
							    <!--end::Chart-->
						    </div>
						    <!--end::Container-->
					    </div>
					    <!--end::Wrapper-->
				    </div>
				    <!--end: Card Body-->
			    </div>
			    <!--end::Chart widget 22-->
		    </div>

		    <div class="col-xxl-4">
			    <!--begin::Slider Widget 3-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
					    <!--begin::Title-->
					    <h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Overall Construction Task</span>
						    <span id="spn03OverallDetails" class="text-gray-400 mt-1 fw-bold fs-7"></span>
					    </h3>
					    <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body p-0">
					    <!--begin::Title-->
					    <span id="spn03Status" class="text-gray-800 fw-bolder fs-4 mb-3 px-8"></span>
					    <!--end::Title-->
					    <!--begin::Statistics-->
					    <div class="d-flex align-items-center w-100 px-8">
						    <!--begin::Number-->
						    <span id="spn03Total" class="fs-2qx text-gray-800 fw-bolder"></span>
						    <!--end::Number-->
						    <!--begin::Progress-->
						    <div class="progress h-6px w-100 mx-3 bg-light-primary">
							    <div id="div03PercentageBar" class="progress-bar" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
						    </div>
						    <!--end::Progress-->
						    <!--begin::Value-->
						    <span id="spn03OverallPercentage" class="text-gray-400 fw-bolder fs-4"></span>
						    <!--end::Value-->
					    </div>
					    <!--end::Statistics-->
					    <!--begin::Chart-->
					    <div id="overall_construction_area_chart" class="min-h-auto ps-4 pe-6"></div>
					    <!--end::Chart-->
				    </div>
				    <!--end::Body-->
			    </div>
			    <!--end::Slider Widget 3-->
		    </div>

		</asp:Panel>
        
		<asp:Panel ID="pnl04Request" runat="server" class="row g-5 mb-5">

		    <div class="col-xxl-8">
			    <!--begin::Chart widget 22-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
                         <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">My Request (Form)</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARAll()"><asp:Label ID="lbl04Total" runat="server" Text="0 work order"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body">
					    <!--begin::Wrapper-->
						<div class="d-flex flex-wrap flex-md-nowrap">
							<!--begin::Items-->
							<div class="me-md-5 w-100">
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<!--begin::Symbol-->
										<div class="symbol symbol-50px me-4">
											<span class="symbol-label">
												<span class="svg-icon svg-icon-2qx svg-icon-info">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
														<path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
													</svg>
												</span>
											</span>
										</div>
										<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<span class="text-gray-800 text-hover-info fs-6 fw-bolder pointer" onclick="reqStatusGood(this)">Good</span>
											<span class="text-gray-400 fw-bolder d-block fs-7">Request Assigned approved within the date.</span>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span id="spn04WithinTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
										<span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
										<span id="spn04ReqWithinTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
										<span id="spn04ReqPercentageWithin" runat="server" class="badge badge-lg badge-info align-self-center px-2"></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<!--begin::Symbol-->
										<div class="symbol symbol-50px me-4">
											<span class="symbol-label">
												<span class="svg-icon svg-icon-2qx svg-icon-warning">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
														<path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
													</svg>
												</span>
											</span>
										</div>
										<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<span class="text-gray-800 text-hover-warning fs-6 fw-bolder pointer" onclick="reqStatusDue(this)">Due</span>
											<span class="text-gray-400 fw-bolder d-block fs-7">Request Assigned approved due to date.</span>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span id="spn04DueTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
										<span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
										<span id="spn04ReqDueTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
										<span id="spn04ReqPercentageDue" runat="server" class="badge badge-lg badge-warning align-self-center px-2"></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
								<!--begin::Item-->
								<div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
									<!--begin::Block-->
									<div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
										<!--begin::Symbol-->
										<div class="symbol symbol-50px me-4">
											<span class="symbol-label">
												<span class="svg-icon svg-icon-2qx svg-icon-danger">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
														<path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
													</svg>
												</span>
											</span>
										</div>
										<!--end::Symbol-->
										<!--begin::Section-->
										<div class="me-2">
											<span class="text-gray-800 text-hover-danger fs-6 fw-bolder pointer" onclick="reqStatusDelay(this)">Delay</span>
											<span class="text-gray-400 fw-bolder d-block fs-7">Request assigned approved delay to date.</span>
										</div>
										<!--end::Section-->
									</div>
									<!--end::Block-->
									<!--begin::Info-->
									<div class="d-flex align-items-center">
										<span id="spn04DelayTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
										<span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
										<span id="spn04ReqDelayTotal" runat="server"  class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
										<span id="spn04ReqPercentageDelay" runat="server" class="badge badge-lg badge-danger align-self-center px-2"></span>
									</div>
									<!--end::Info-->
								</div>
								<!--end::Item-->
							</div>
							<!--end::Items-->
							<!--begin::Container-->
							<div class="d-flex justify-content-between flex-column w-225px w-md-600px mx-auto mx-md-0">
								<!--begin::Title-->
								<div class="fs-4 fw-bolder text-gray-900 text-center">Overview Request Assigned
								<br />Overall</div>
								<!--end::Title-->
								<!--begin::Chart-->
								<div id="request_donut_chart" class="mx-auto"></div>
								<!--end::Chart-->
							</div>
							<!--end::Container-->
						</div>
						<!--end::Wrapper-->
				    </div>
				    <!--end: Card Body-->
			    </div>
			    <!--end::Chart widget 22-->
		    </div>

		    <div class="col-xxl-4">
			    <!--begin::Slider Widget 3-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
					    <!--begin::Title-->
					    <h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Overall Request Forms</span>
						    <span id="spn04OverallDetails" class="text-gray-400 mt-1 fw-bold fs-7"></span>
					    </h3>
					    <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body p-0">
					    <!--begin::Title-->
						<span id="spn04Status" class="text-gray-800 fw-bolder fs-4 mb-3 px-8"></span>
						<!--end::Title-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 px-8">
							<!--begin::Number-->
							<span id="spn04Total" class="fs-2qx text-gray-800 fw-bolder"></span>
							<!--end::Number-->
							<!--begin::Progress-->
							<div class="progress h-6px w-100 mx-3 bg-light-primary">
								<div id="div04PercentageBar" class="progress-bar" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span id="spn04OverallPercentage" class="text-gray-400 fw-bolder fs-4"></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
						<!--begin::Chart-->
						<div id="overall_request_area_chart" class="min-h-auto ps-4 pe-6"></div>
						<!--end::Chart-->
				    </div>
				    <!--end::Body-->
			    </div>
			    <!--end::Slider Widget 3-->
		    </div>

		</asp:Panel>
        
		<asp:Panel ID="pnl05RequestWO" runat="server" class="row g-5">

		    <div class="col-xxl-8">
			    <!--begin::Chart widget 22-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
                        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">My Request (Work Order)</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARAll()"><asp:Label ID="lbl05Total" runat="server" Text="0 work order"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body">
					    <!--begin::Wrapper-->
					    <div class="d-flex flex-wrap flex-md-nowrap">
						    <!--begin::Items-->
						    <div class="me-md-5 w-100">
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-info">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-info fs-6 fw-bolder pointer" onclick="reqWOStatusGood(this)">Good</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Request Assigned (WO) approved within the date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn05WithinTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn05ReqWOWithinTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn05ReqPercentageWithin" runat="server" class="badge badge-lg badge-info align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-warning">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-warning fs-6 fw-bolder pointer" onclick="reqWOStatusDue(this)">Due</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Request Assigned (WO) approved due to date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn05DueTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn05ReqWODueTotal" runat="server" class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn05ReqWOPercentageDue" runat="server" class="badge badge-lg badge-warning align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
							    <!--begin::Item-->
							    <div class="d-flex border border-gray-300 border-dashed rounded p-3 mb-6">
								    <!--begin::Block-->
								    <div class="d-flex align-items-center flex-grow-1 me-2 me-sm-5">
									    <!--begin::Symbol-->
									    <div class="symbol symbol-50px me-4">
										    <span class="symbol-label">
											    <span class="svg-icon svg-icon-2qx svg-icon-danger">
												    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													    <path opacity="0.3" d="M20.9 12.9C20.3 12.9 19.9 12.5 19.9 11.9C19.9 11.3 20.3 10.9 20.9 10.9H21.8C21.3 6.2 17.6 2.4 12.9 2V2.9C12.9 3.5 12.5 3.9 11.9 3.9C11.3 3.9 10.9 3.5 10.9 2.9V2C6.19999 2.5 2.4 6.2 2 10.9H2.89999C3.49999 10.9 3.89999 11.3 3.89999 11.9C3.89999 12.5 3.49999 12.9 2.89999 12.9H2C2.5 17.6 6.19999 21.4 10.9 21.8V20.9C10.9 20.3 11.3 19.9 11.9 19.9C12.5 19.9 12.9 20.3 12.9 20.9V21.8C17.6 21.3 21.4 17.6 21.8 12.9H20.9Z" fill="currentColor" />
													    <path d="M16.9 10.9H13.6C13.4 10.6 13.2 10.4 12.9 10.2V5.90002C12.9 5.30002 12.5 4.90002 11.9 4.90002C11.3 4.90002 10.9 5.30002 10.9 5.90002V10.2C10.6 10.4 10.4 10.6 10.2 10.9H9.89999C9.29999 10.9 8.89999 11.3 8.89999 11.9C8.89999 12.5 9.29999 12.9 9.89999 12.9H10.2C10.4 13.2 10.6 13.4 10.9 13.6V13.9C10.9 14.5 11.3 14.9 11.9 14.9C12.5 14.9 12.9 14.5 12.9 13.9V13.6C13.2 13.4 13.4 13.2 13.6 12.9H16.9C17.5 12.9 17.9 12.5 17.9 11.9C17.9 11.3 17.5 10.9 16.9 10.9Z" fill="currentColor" />
												    </svg>
											    </span>
										    </span>
									    </div>
									    <!--end::Symbol-->
									    <!--begin::Section-->
									    <div class="me-2">
										    <span class="text-gray-800 text-hover-danger fs-6 fw-bolder pointer" onclick="reqWOStatusDelay(this)">Delay</span>
										    <span class="text-gray-400 fw-bolder d-block fs-7">Request Assigned (WO) approved delay to date.</span>
									    </div>
									    <!--end::Section-->
								    </div>
								    <!--end::Block-->
								    <!--begin::Info-->
								    <div class="d-flex align-items-center">
									    <span id="spn05DelayTotal" runat="server" class="text-dark fw-boldest fs-2x"></span>
									    <span class="fw-bold fs-2 text-gray-600 mx-1 pt-1">/</span>
									    <span id="spn05ReqWODelayTotal" runat="server"  class="text-gray-600 fw-bold fs-2 me-3 pt-2"></span>
									    <span id="spn05ReqWOPercentageDelay" runat="server" class="badge badge-lg badge-danger align-self-center px-2"></span>
								    </div>
								    <!--end::Info-->
							    </div>
							    <!--end::Item-->
						    </div>
						    <!--end::Items-->
						    <!--begin::Container-->
						    <div class="d-flex justify-content-between flex-column w-225px w-md-600px mx-auto mx-md-0">
							    <!--begin::Title-->
							    <div class="fs-4 fw-bolder text-gray-900 text-center">Overview Request Assigned (WO)
							    <br />Overall</div>
							    <!--end::Title-->
							    <!--begin::Chart-->
							    <div id="requestwo_donut_chart" class="mx-auto"></div>
							    <!--end::Chart-->
						    </div>
						    <!--end::Container-->
					    </div>
					    <!--end::Wrapper-->
				    </div>
				    <!--end: Card Body-->
			    </div>
			    <!--end::Chart widget 22-->
		    </div>

		    <div class="col-xxl-4">
			    <!--begin::Slider Widget 3-->
			    <div class="card h-100 card-flush">
				    <!--begin::Header-->
				    <div class="card-header">
					    <!--begin::Title-->
					    <h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Overall Request (WO) Forms</span>
						    <span id="spn05OverallDetails" class="text-gray-400 mt-1 fw-bold fs-7"></span>
					    </h3>
					    <!--end::Title-->
				    </div>
				    <!--end::Header-->
				    <!--begin::Body-->
				    <div class="card-body p-0">
					    <!--begin::Title-->
						<span id="spn05Status" class="text-gray-800 fw-bolder fs-4 mb-3 px-8"></span>
						<!--end::Title-->
						<!--begin::Statistics-->
						<div class="d-flex align-items-center w-100 px-8">
							<!--begin::Number-->
							<span id="spn05Total" class="fs-2qx text-gray-800 fw-bolder"></span>
							<!--end::Number-->
							<!--begin::Progress-->
							<div class="progress h-6px w-100 mx-3 bg-light-primary">
								<div id="div05PercentageBar" class="progress-bar" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
							<!--end::Progress-->
							<!--begin::Value-->
							<span id="spn05OverallPercentage" class="text-gray-400 fw-bolder fs-4"></span>
							<!--end::Value-->
						</div>
						<!--end::Statistics-->
						<!--begin::Chart-->
						<div id="overall_requestwo_area_chart" class="min-h-auto ps-4 pe-6"></div>
						<!--end::Chart-->
				    </div>
				    <!--end::Body-->
			    </div>
			    <!--end::Slider Widget 3-->
		    </div>

		</asp:Panel>
        
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

    </asp:Panel>

    <script type="text/javascript">
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
        }
        function View_Form(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'Form',
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response)
                },
            });
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
        
        //form variable
        var ltrlFormTblName = '<asp:Literal ID="ltrlFormTblName" runat="server" />';
        var ltrlFormNo = '<asp:Literal ID="ltrlFormNo" runat="server" />';
        var ltrlFormGood = '<asp:Literal ID="ltrlFormGood" runat="server" />';
        var ltrlFormDue = '<asp:Literal ID="ltrlFormDue" runat="server" />';
        var ltrlFormDelay = '<asp:Literal ID="ltrlFormDelay" runat="server" />';
        var ltrlFormTotal = '<asp:Literal ID="ltrlFormTotal" runat="server" />';

        var ltrlWOProject = '<asp:Literal ID="ltrlWOProject" runat="server" />';
        var ltrlWONo = '<asp:Literal ID="ltrlWONo" runat="server" />';
        var ltrlWOGood = '<asp:Literal ID="ltrlWOGood" runat="server" />';
        var ltrlWODelay = '<asp:Literal ID="ltrlWODelay" runat="server" />';
        var ltrlWODue = '<asp:Literal ID="ltrlWODue" runat="server" />';
        var ltrlWOTotal = '<asp:Literal ID="ltrlWOTotal" runat="server" />';

        var ltrlTask = '<asp:Literal ID="ltrlTask" runat="server" />';
        var ltrlTaskNo = '<asp:Literal ID="ltrlTaskNo" runat="server" />';
        var ltrlTaskGood = '<asp:Literal ID="ltrlTaskGood" runat="server" />';
        var ltrlTaskDue = '<asp:Literal ID="ltrlTaskDue" runat="server" />';
        var ltrlTaskDelay = '<asp:Literal ID="ltrlTaskDelay" runat="server" />';
        var ltrlTaskTotal = '<asp:Literal ID="ltrlTaskTotal" runat="server" />'

        var ltrlRequest = '<asp:Literal ID="ltrlRequest" runat="server" />';
        var ltrlRequestNo = '<asp:Literal ID="ltrlRequestNo" runat="server" />';
        var ltrlRequestGood = '<asp:Literal ID="ltrlRequestGood" runat="server" />';
        var ltrlRequestDue = '<asp:Literal ID="ltrlRequestDue" runat="server" />';
        var ltrlRequestDelay = '<asp:Literal ID="ltrlRequestDelay" runat="server" />';
        var ltrlRequestTotal = '<asp:Literal ID="ltrlRequestTotal" runat="server" />';

        var ltrlRequestWOProject = '<asp:Literal ID="ltrlRequestWOProject" runat="server" />';
        var ltrlRequestWONo = '<asp:Literal ID="ltrlRequestWONo" runat="server" />';
        var ltrlRequestWOGood = '<asp:Literal ID="ltrlRequestWOGood" runat="server" />';
        var ltrlRequestWODue = '<asp:Literal ID="ltrlRequestWODue" runat="server" />';
        var ltrlRequestWODelay = '<asp:Literal ID="ltrlRequestWODelay" runat="server" />';
        var ltrlRequestWOTotal = '<asp:Literal ID="ltrlRequestWOTotal" runat="server" />';
        //form variable

        //view form
        function ViewWorkOrderAll(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Work Order)',
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewTaskAll(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Construction Task)',
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewRequestAll(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Request)',
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewRequestWO(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Request Work Order)',
                    'Status': Status
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        //view form

        //view form details
        function ViewFormDetails(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Details)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayFormDetails(response, Status);
                },
            });
        }
        function ViewWODetails(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Work Order Details)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayWODetails(response, Status);
                },
            });
        }
        function ViewTaskDetails(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Construction Task Details)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayCTDetails(response, Status);
                },
            });
        }
        function ViewRequestDetails(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Request Details)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayReqDetails(response, Status);
                },
            });
        }
        function ViewRequestWODetails(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Request Work Order Details)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayReqWODetails(response, Status);
                },
            });
        }
        //view form details

        //view form details - date
        function ViewFormDays(Status, Days) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Form Days)',
                    'Status': Status,
                    'Days': Days
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewWorkOrderDepartment(Status, Department) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Work Order Department)',
                    'Status': Status,
                    'Department': Department
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewConstructionTaskName(Status, TaskName) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Construction Task Name)',
                    'Status': Status,
                    'TaskName': TaskName
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewRequestFormInit(Status, FormInit) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Request FormInit)',
                    'Status': Status,
                    'FormInit': FormInit
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        function ViewRequestWODepartment(Status, Department) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB020000',
                    'Type': 'My Dashboard (Request Work Order Department)',
                    'Status': Status,
                    'Department': Department
                },
                success: function (response) {
                    Display_Form(response);
                },
            });
        }
        //view form details - date

        //onclick
        function woStatusGood(val) {
            ViewWorkOrderAll(val.innerText);
        }
        function woStatusDue(val) {
            ViewWorkOrderAll(val.innerText);
        }
        function woStatusDelay(val) {
            ViewWorkOrderAll(val.innerText);
        }
        function ctStatusGood(val) {
            ViewTaskAll(val.innerText);
        }
        function ctStatusDue(val) {
            ViewTaskAll(val.innerText);
        }
        function ctStatusDelay(val) {
            ViewTaskAll(val.innerText);
        }
        function reqStatusGood(val) {
            ViewRequestAll(val.innerText);
        }
        function reqStatusDue(val) {
            ViewRequestAll(val.innerText);
        }
        function reqStatusDelay(val) {
            ViewRequestAll(val.innerText);
        }
        function reqWOStatusGood(val) {
            ViewRequestWO(val.innerText);
        }
        function reqWOStatusDue(val) {
            ViewRequestWO(val.innerText);
        }
        function reqWOStatusDelay(val) {
            ViewRequestWO(val.innerText);
        }
        //onclick

        //status
        function form(val) {
            ViewFormAll(val.innerText);
        }
        function workoder(val) {
            ViewWorkOrderAll(val.innerText);
        }
        function construction(val) {
            ViewTaskAll(val.innerText);
        }
        function myReq(val) {
            ViewRequestAll(val.innerText);
        }
        function reqWO(val) {
            ViewRequestWO(val.innerText);
        }
        //status

        //form details - form assigned
        function DisplayFormDetails(response, Status) {
            var element = document.getElementById("overall_form_area_chart");
            var color;

            //form details
            var spn01Status = document.getElementById("spn01Status");
            var spn01Total = document.getElementById("spn01Total");
            var div01PercentageBar = document.getElementById("div01PercentageBar");
            var spn01OverallPercentage = document.getElementById("spn01OverallPercentage");
            var spn01OverallDetails = document.getElementById("spn01OverallDetails");
            //form details

            //reset
            spn01Status.innerHTML = "";
            spn01Total.innerHTML = "";
            spn01OverallPercentage.innerHTML = "";
            spn01OverallDetails.innerHTML = "";
            div01PercentageBar.classList.remove('bg-info');
            div01PercentageBar.classList.remove('bg-warning');
            div01PercentageBar.classList.remove('bg-danger');
            element.innerHTML = "";
            //reset

            //append
            if (Status === "Good") {
                color = KTUtil.getCssVariableValue('--bs-info');

                spn01Status.innerHTML = "<strong class='text-hover-info' onclick='View_Form(\"" + Status + "\")' style='cursor: pointer;'>" + Status + "</strong>";
                spn01Total.append(ltrlFormGood);
                div01PercentageBar.setAttribute('aria-valuenow', ltrlFormGood);
                div01PercentageBar.classList.add('bg-info');
                div01PercentageBar.style.width = (parseInt(ltrlFormGood) / parseInt(ltrlFormTotal) * 100) + '%';
                spn01OverallPercentage.append(parseInt(ltrlFormGood / ltrlFormTotal * 100) + '%');
                spn01OverallDetails.append('Avg. ' + parseInt(ltrlFormGood / ltrlFormTotal * 100) + '% completed within date.');

            } else if (Status === "Due") {
                color = KTUtil.getCssVariableValue('--bs-warning');

                spn01Status.innerHTML = "<strong class='text-hover-warning' onclick='View_Form(\"" + Status + "\")' style='cursor: pointer;'>" + Status + "</strong>";
                spn01Total.append(ltrlFormDue);
                div01PercentageBar.setAttribute('aria-valuenow', ltrlFormDue);
                div01PercentageBar.classList.add('bg-warning')
                div01PercentageBar.style.width = (parseInt(ltrlFormDue) / parseInt(ltrlFormTotal) * 100) + '%';
                spn01OverallPercentage.append(parseInt(ltrlFormDue / ltrlFormTotal * 100) + '%');
                spn01OverallDetails.append('Avg. ' + parseInt(ltrlFormDue / ltrlFormTotal * 100) + '% completed due date.');

            } else if (Status === "Delay") {
                color = KTUtil.getCssVariableValue('--bs-danger');

                spn01Status.innerHTML = "<strong class='text-hover-danger' onclick='View_Form(\"" + Status + "\")' style='cursor: pointer;'>" + Status + "</strong>";
                spn01Total.append(ltrlFormDelay);
                div01PercentageBar.setAttribute('aria-valuenow', ltrlFormDelay);
                div01PercentageBar.classList.add('bg-danger')
                div01PercentageBar.style.width = (parseInt(ltrlFormDelay) / parseInt(ltrlFormTotal) * 100) + '%';
                spn01OverallPercentage.append(parseInt(ltrlFormDelay / ltrlFormTotal * 100) + '%');
                spn01OverallDetails.append('Avg. ' + parseInt(ltrlFormDelay / ltrlFormTotal * 100) + '% completed delay date.');

            }
            //append

            //value
            var Less5;
            var Less10;
            var Less30;
            var Less60;
            var Less90;
            var Less180;
            var Less360;
            var Above360;
            response.forEach(function (obj) {
                Less5 = parseInt(obj.Less5);
                Less10 = parseInt(obj.Less10);
                Less30 = parseInt(obj.Less30);
                Less60 = parseInt(obj.Less60);
                Less90 = parseInt(obj.Less90);
                Less180 = parseInt(obj.Less180);
                Less360 = parseInt(obj.Less360);
                Above360 = parseInt(obj.Above360);
            });
            //value

            jQuery(function ($) {
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');


                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: Status,
                        data: [Less5, Less10, Less30, Less60, Less90, Less180, Less360, Above360]
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: 300,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var Days = config.w.config.xaxis.categories[config.dataPointIndex];
                                var FormDays;
                                if (Days === "0 - 5") {
                                    FormDays = "<= 5";
                                } else if (Days === "6 - 10") {
                                    FormDays = "between 6 and 10";
                                } else if (Days === "11 - 30") {
                                    FormDays = "between 11 and 30";
                                } else if (Days === "31 - 60") {
                                    FormDays = "between 31 and 60";
                                } else if (Days === "61 - 90") {
                                    FormDays = "between 61 - 90"
                                } else if (Days === "91 - 180") {
                                    FormDays = "between 91 and 180";
                                } else if (Days === "181 - 360") {
                                    FormDays = "between 181 and 360";
                                } else if (Days === "Above 360") {
                                    FormDays = ">= 360";
                                }
                                ViewFormDays(Status, FormDays);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['100%'],
                            borderRadius: 4
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 1,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ['0 - 5', '6 - 10', '11 - 30', '31 - 60', '61 - 90', '91 - 180', '181 - 360', 'Above 360'],
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '8px'
                            },
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
                    fill: {
                        opacity: 1
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
                        y: {
                            formatter: function (val) {
                                return + val + ' Forms'
                            }
                        }
                    },
                    colors: [color],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
        //form details - form assigned

        //form details - work order
        function DisplayWODetails(response, Status) {
            var element = document.getElementById("overall_wo_area_chart");
            var color;

            //form details
            var spn02Status = document.getElementById("spn02Status");
            var spn02Total = document.getElementById("spn02Total");
            var div02PercentageBar = document.getElementById("div02PercentageBar");
            var spn02OverPercentage = document.getElementById("spn02OverallPercentage");
            var spn02OverallDetails = document.getElementById("spn02OverallDetails");
            //form details

            //reset
            spn02Status.innerHTML = "";
            spn02Total.innerHTML = "";
            spn02OverPercentage.innerHTML = "";
            spn02OverallDetails.innerHTML = "";
            div02PercentageBar.classList.remove('bg-info');
            div02PercentageBar.classList.remove('bg-warning');
            div02PercentageBar.classList.remove('bg-danger');
            element.innerHTML = "";
            //reset

            //append
            if (Status === "Good") {
                color = KTUtil.getCssVariableValue('--bs-info');

                spn02Status.innerHTML = "<strong class='text-hover-info' onclick='workoder(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn02Total.append(ltrlWOGood);
                div02PercentageBar.setAttribute('aria-valuenow', ltrlWOGood);
                div02PercentageBar.classList.add('bg-info');
                div02PercentageBar.style.width = (parseInt(ltrlWOGood) / parseInt(ltrlWOTotal) * 100) + '%';
                spn02OverPercentage.append(parseInt(ltrlWOGood / ltrlWOTotal * 100) + '%');
                spn02OverallDetails.append('Avg. ' + parseInt(ltrlWOGood / ltrlWOTotal * 100) + '% completed within date.');

            } else if (Status === "Due") {
                color = KTUtil.getCssVariableValue('--bs-warning');

                spn02Status.innerHTML = "<strong class='text-hover-warning' onclick='workoder(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn02Total.append(ltrlWODue);
                div02PercentageBar.setAttribute('aria-valuenow', ltrlWODue);
                div02PercentageBar.classList.add('bg-warning')
                div02PercentageBar.style.width = (parseInt(ltrlWODue) / parseInt(ltrlWOTotal) * 100) + '%';
                spn02OverPercentage.append(parseInt(ltrlWODue / ltrlWOTotal * 100) + '%');
                spn02OverallDetails.append('Avg. ' + parseInt(ltrlWODue / ltrlWOTotal * 100) + '% completed due date.');

            } else if (Status === "Delay") {
                color = KTUtil.getCssVariableValue('--bs-danger');

                spn02Status.innerHTML = "<strong class='text-hover-danger' onclick='workoder(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn02Total.append(ltrlWODelay);
                div02PercentageBar.setAttribute('aria-valuenow', ltrlWODelay);
                div02PercentageBar.classList.add('bg-danger')
                div02PercentageBar.style.width = (parseInt(ltrlWODelay) / parseInt(ltrlWOTotal) * 100) + '%';
                spn02OverPercentage.append(parseInt(ltrlWODelay / ltrlWOTotal * 100) + '%');
                spn02OverallDetails.append('Avg. ' + parseInt(ltrlWODelay / ltrlWOTotal * 100) + '% completed delay date.');

            }
            //append

            //value
            var Department = [];
            var Count = [];
            var Dept = [];
            response.forEach(function (obj) {
                Department.push(obj.Department);
                Count.push(obj.Count);
                Dept.push(obj.Dept);
            });
            //value

            jQuery(function ($) {
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');

                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: Status,
                        data: Count,
                        meta: {
                            hiddenDepartment: Dept
                        }
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: 300,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var Code = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Department = config.w.config.series[config.seriesIndex].meta.hiddenDepartment[config.dataPointIndex];
                                ViewWorkOrderDepartment(Status, Department);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['100%'],
                            borderRadius: 4
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 1,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: Department,
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            },
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
                    fill: {
                        opacity: 1
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
                        y: {
                            formatter: function (val) {
                                return + val + ' Forms'
                            }
                        }
                    },
                    colors: [color],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
        //form details - work order

        //form details - construction task
        function DisplayCTDetails(response, Status) {
            var element = document.getElementById("overall_construction_area_chart");
            var color;

            //form details
            var spn03Status = document.getElementById("spn03Status");
            var spn03Total = document.getElementById("spn03Total");
            var div03PercentageBar = document.getElementById("div03PercentageBar");
            var spn03OverPercentage = document.getElementById("spn03OverallPercentage");
            var spn03OverallDetails = document.getElementById("spn03OverallDetails");
            //form details

            //reset
            spn03Status.innerHTML = "";
            spn03Total.innerHTML = "";
            spn03OverPercentage.innerHTML = "";
            spn03OverallDetails.innerHTML = "";
            div03PercentageBar.classList.remove('bg-info');
            div03PercentageBar.classList.remove('bg-warning');
            div03PercentageBar.classList.remove('bg-danger');
            element.innerHTML = "";
            //reset

            //append
            if (Status === "Good") {
                color = KTUtil.getCssVariableValue('--bs-info');

                spn03Status.innerHTML = "<strong class='text-hover-info' onclick='construction(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn03Total.append(ltrlTaskGood);
                div03PercentageBar.setAttribute('aria-valuenow', ltrlTaskGood);
                div03PercentageBar.classList.add('bg-info');
                div03PercentageBar.style.width = (parseInt(ltrlTaskGood) / parseInt(ltrlTaskTotal) * 100) + '%';
                spn03OverPercentage.append(parseInt(ltrlTaskGood / ltrlTaskTotal * 100) + '%');
                spn03OverallDetails.append('Avg. ' + parseInt(ltrlTaskGood / ltrlTaskTotal * 100) + '% completed within date.');

            } else if (Status === "Due") {
                color = KTUtil.getCssVariableValue('--bs-warning');

                spn03Status.innerHTML = "<strong class='text-hover-warning' onclick='construction(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn03Total.append(ltrlTaskDue);
                div03PercentageBar.setAttribute('aria-valuenow', ltrlTaskDue);
                div03PercentageBar.classList.add('bg-warning')
                div03PercentageBar.style.width = (parseInt(ltrlTaskDue) / parseInt(ltrlTaskTotal) * 100) + '%';
                spn03OverPercentage.append(parseInt(ltrlTaskDue / ltrlTaskTotal * 100) + '%');
                spn03OverallDetails.append('Avg. ' + parseInt(ltrlTaskDue / ltrlTaskTotal * 100) + '% completed due date.');

            } else if (Status === "Delay") {
                color = KTUtil.getCssVariableValue('--bs-danger');

                spn03Status.innerHTML = "<strong class='text-hover-danger' onclick='construction(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn03Total.append(ltrlTaskDelay);
                div03PercentageBar.setAttribute('aria-valuenow', ltrlTaskDelay);
                div03PercentageBar.classList.add('bg-danger')
                div03PercentageBar.style.width = (parseInt(ltrlTaskDelay) / parseInt(ltrlTaskTotal) * 100) + '%';
                spn03OverPercentage.append(parseInt(ltrlTaskDelay / ltrlTaskTotal * 100) + '%');
                spn03OverallDetails.append('Avg. ' + parseInt(ltrlTaskDelay / ltrlTaskTotal * 100) + '% completed delay date.');

            }
            //append

            //value
            var TaskNames = [];
            var Count = [];
            response.forEach(function (obj) {
                TaskNames.push(obj.TaskName);
                Count.push(obj.Count);
            });
            //value

            jQuery(function ($) {
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: Status,
                        data: Count
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: 300,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var TaskName = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewConstructionTaskName(Status, TaskName);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['100%'],
                            borderRadius: 4
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 1,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: TaskNames,
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            },
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
                    fill: {
                        opacity: 1
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
                        y: {
                            formatter: function (val) {
                                return + val + ' Forms'
                            }
                        }
                    },
                    colors: [color],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
        //form details - construction task

        //form details - request
        function DisplayReqDetails(response, Status) {
            var element = document.getElementById("overall_request_area_chart");
            var color;

            //form details
            var spn04Status = document.getElementById("spn04Status");
            var spn04Total = document.getElementById("spn04Total");
            var div04PercentageBar = document.getElementById("div04PercentageBar");
            var spn04OverPercentage = document.getElementById("spn04OverallPercentage");
            var spn04OverallDetails = document.getElementById("spn04OverallDetails");
            //form details

            //reset
            spn04Status.innerHTML = "";
            spn04Total.innerHTML = "";
            spn04OverPercentage.innerHTML = "";
            spn04OverallDetails.innerHTML = "";
            div04PercentageBar.classList.remove('bg-info');
            div04PercentageBar.classList.remove('bg-warning');
            div04PercentageBar.classList.remove('bg-danger');
            element.innerHTML = "";
            //reset

            //append
            if (Status === "Good") {
                color = KTUtil.getCssVariableValue('--bs-info');

                spn04Status.innerHTML = "<strong class='text-hover-info' onclick='myReq(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn04Total.append(ltrlRequestGood);
                div04PercentageBar.setAttribute('aria-valuenow', ltrlRequestGood);
                div04PercentageBar.classList.add('bg-info');
                div04PercentageBar.style.width = (parseInt(ltrlRequestGood) / parseInt(ltrlRequestTotal) * 100) + '%';
                spn04OverPercentage.append(parseInt(ltrlRequestGood / ltrlRequestTotal * 100) + '%');
                spn04OverallDetails.append('Avg. ' + parseInt(ltrlRequestGood / ltrlRequestTotal * 100) + '% completed within date.');

            } else if (Status === "Due") {
                color = KTUtil.getCssVariableValue('--bs-warning');

                spn04Status.innerHTML = "<strong class='text-hover-warning' onclick='myReq(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn04Total.append(ltrlRequestDue);
                div04PercentageBar.setAttribute('aria-valuenow', ltrlRequestDue);
                div04PercentageBar.classList.add('bg-warning')
                div04PercentageBar.style.width = (parseInt(ltrlRequestDue) / parseInt(ltrlRequestTotal) * 100) + '%';
                spn04OverPercentage.append(parseInt(ltrlRequestDue / ltrlRequestTotal * 100) + '%');
                spn04OverallDetails.append('Avg. ' + parseInt(ltrlRequestDue / ltrlRequestTotal * 100) + '% completed due date.');

            } else if (Status === "Delay") {
                color = KTUtil.getCssVariableValue('--bs-danger');

                spn04Status.innerHTML = "<strong class='text-hover-danger' onclick='myReq(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn04Total.append(ltrlRequestDelay);
                div04PercentageBar.setAttribute('aria-valuenow', ltrlRequestDelay);
                div04PercentageBar.classList.add('bg-danger')
                div04PercentageBar.style.width = (parseInt(ltrlRequestDelay) / parseInt(ltrlRequestTotal) * 100) + '%';
                spn04OverPercentage.append(parseInt(ltrlRequestDelay / ltrlRequestTotal * 100) + '%');
                spn04OverallDetails.append('Avg. ' + parseInt(ltrlRequestDelay / ltrlRequestTotal * 100) + '% completed delay date.');

            }
            //append

            //value
            var TotalArray = [];
            var FormInit = [];
            response.forEach(function (obj) {
                TotalArray.push(obj.Count);
                FormInit.push(obj.Department);
            });
            //value

            jQuery(function ($) {
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: Status,
                        data: TotalArray
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: 300,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var FormInit = config.w.config.xaxis.categories[config.dataPointIndex];
                                ViewRequestFormInit(Status, FormInit);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            dataLabels: {
                                position: 'top',
                            }
                        }
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: FormInit,
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '12px'
                            },
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
                                return val + ' Form(s)'
                            }
                        }
                    },
                    colors: [color],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    markers: {
                        colors: [baseLightColor, secondaryLightColor],
                        strokeColor: [baseLightColor, secondaryLightColor],
                        strokeWidth: 3,
                        size: 3
                    },
                    responsive: [
                        {
                            breakpoint: undefined,
                            options: {},
                        }
                    ]
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
        //form details - request

        //form details - requets work order
        function DisplayReqWODetails(response, Status) {
            var element = document.getElementById("overall_requestwo_area_chart");
            var color;

            //form details
            var spn05Status = document.getElementById("spn05Status");
            var spn05Total = document.getElementById("spn05Total");
            var div05PercentageBar = document.getElementById("div05PercentageBar");
            var spn05OverPercentage = document.getElementById("spn05OverallPercentage");
            var spn05OverallDetails = document.getElementById("spn05OverallDetails");
            //form details

            //reset
            spn05Status.innerHTML = "";
            spn05Total.innerHTML = "";
            spn05OverPercentage.innerHTML = "";
            spn05OverallDetails.innerHTML = "";
            div05PercentageBar.classList.remove('bg-info');
            div05PercentageBar.classList.remove('bg-warning');
            div05PercentageBar.classList.remove('bg-danger');
            element.innerHTML = "";
            //reset

            //append
            if (Status === "Good") {
                color = KTUtil.getCssVariableValue('--bs-info');

                spn05Status.innerHTML = "<strong class='text-hover-info' onclick='reqWO(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn05Total.append(ltrlRequestWOGood);
                div05PercentageBar.setAttribute('aria-valuenow', ltrlRequestWOGood);
                div05PercentageBar.classList.add('bg-info');
                div05PercentageBar.style.width = (parseInt(ltrlRequestWOGood) / parseInt(ltrlRequestWOTotal) * 100) + '%';
                spn05OverPercentage.append(parseInt(ltrlRequestWOGood / ltrlRequestWOTotal * 100) + '%');
                spn05OverallDetails.append('Avg. ' + parseInt(ltrlRequestWOGood / ltrlRequestWOTotal * 100) + '% completed within date.');

            } else if (Status === "Due") {
                color = KTUtil.getCssVariableValue('--bs-warning');

                spn05Status.innerHTML = "<strong class='text-hover-warning' onclick='reqWO(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn05Total.append(ltrlRequestWODue);
                div05PercentageBar.setAttribute('aria-valuenow', ltrlRequestWODue);
                div05PercentageBar.classList.add('bg-warning')
                div05PercentageBar.style.width = (parseInt(ltrlRequestWODue) / parseInt(ltrlRequestWOTotal) * 100) + '%';
                spn05OverPercentage.append(parseInt(ltrlRequestWODue / ltrlRequestWOTotal * 100) + '%');
                spn05OverallDetails.append('Avg. ' + parseInt(ltrlRequestWODue / ltrlRequestWOTotal * 100) + '% completed due date.');

            } else if (Status === "Delay") {
                color = KTUtil.getCssVariableValue('--bs-danger');

                spn05Status.innerHTML = "<strong class='text-hover-danger' onclick='reqWO(this)' style='cursor: pointer;'>" + Status + "</strong>";
                spn05Total.append(ltrlRequestWODelay);
                div05PercentageBar.setAttribute('aria-valuenow', ltrlRequestWODelay);
                div05PercentageBar.classList.add('bg-danger')
                div05PercentageBar.style.width = (parseInt(ltrlRequestWODelay) / parseInt(ltrlRequestWOTotal) * 100) + '%';
                spn05OverPercentage.append(parseInt(ltrlRequestWODelay / ltrlRequestWOTotal * 100) + '%');
                spn05OverallDetails.append('Avg. ' + parseInt(ltrlRequestWODelay / ltrlRequestWOTotal * 100) + '% completed delay date.');

            }
            //append

            //value
            var Count = [];
            var Department = [];
            var Dept = [];
            response.forEach(function (obj) {
                Count.push(obj.Count);
                Department.push(obj.Department);
                Dept.push(obj.Dept);
            });
            //value

            jQuery(function ($) {
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');


                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: Status,
                        data: Count,
                        meta: {
                            hiddenDepartment: Dept
                        }
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: 300,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                var Department = config.w.config.series[config.seriesIndex].meta.hiddenDepartment[config.dataPointIndex];
                                ViewRequestWODepartment(Status, Department);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['100%'],
                            borderRadius: 4
                        },
                    },
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 1,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: Department,
                        labels: {
                            style: {
                                colors: labelColor,
                                fontSize: '8px'
                            },
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
                    fill: {
                        opacity: 1
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
                        y: {
                            formatter: function (val) {
                                return + val + ' Forms'
                            }
                        }
                    },
                    colors: [color],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
        //form details - requets work order

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                var element = document.getElementById("assigned_donut_chart");

                var withinColor = KTUtil.getCssVariableValue('--bs-info');
                var dueColor = KTUtil.getCssVariableValue('--bs-warning');
                var delayColor = KTUtil.getCssVariableValue('--bs-danger');

                const ArrayFormValueData = [parseInt(ltrlFormGood), parseInt(ltrlFormDue), parseInt(ltrlFormDelay)];
                const ArrayFormValueStatus = ['Good', 'Due', 'Delay'];

                //spn01Total.append(0);
                //div01PercentageBar.setAttribute('aria-valuenow', '0');
                //div01PercentageBar.classList.add('bg-danger')
                //div01PercentageBar.style.width = '0%';
                //spn01OverallPercentage.append('0%');
                //spn01OverallDetails.append('Avg. 0% completed  date.');

                if (!element) {
                    return;
                }
                var options = {
                    series: ArrayFormValueData,
                    labels: ArrayFormValueStatus,
                    chart: {
                        type: 'donut',
                        height: 250,
                        stacked: true,
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                const Status = config.w.config.labels[config.dataPointIndex];
                                ViewFormDetails(Status);
                            }
                        }
                    },

                    plotOptions: {
                        bar: {
                            horizontal: true,
                            dataLabels: {
                                total: {
                                    enabled: true,
                                    offsetX: 0,
                                    style: {
                                        fontSize: '13px',
                                        fontWeight: 900
                                    }
                                }
                            }
                        },
                    },
                    stroke: {
                        width: 1,
                        colors: ['#fff']
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    colors: [withinColor, dueColor, delayColor],
                    fill: {
                        opacity: 1
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left',
                        offsetX: 40
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });

            jQuery(function ($) {

                var element = document.getElementById("workorder_donut_chart");

                var withinColor = KTUtil.getCssVariableValue('--bs-info');
                var dueColor = KTUtil.getCssVariableValue('--bs-warning');
                var delayColor = KTUtil.getCssVariableValue('--bs-danger');

                const ArrayFormValueData = [parseInt(ltrlWOGood), parseInt(ltrlWODue), parseInt(ltrlWODelay)];
                const ArrayFormValueStatus = ['Good', 'Due', 'Delay'];

                //spn02Total.append(0);
                //div02PercentageBar.setAttribute('aria-valuenow', '0');
                //div02PercentageBar.classList.add('bg-danger')
                //div02PercentageBar.style.width = '0%';
                //spn02OverallPercentage.append('0%');
                //spn02OverallDetails.append('Avg. 0% completed  date.');

                if (!element) {
                    return;
                }
                var options = {
                    series: ArrayFormValueData,
                    labels: ArrayFormValueStatus,
                    chart: {
                        type: 'donut',
                        height: 250,
                        stacked: true,
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                const Status = config.w.config.labels[config.dataPointIndex];
                                ViewWODetails(Status);
                            }
                        }
                    },

                    plotOptions: {
                        bar: {
                            horizontal: true,
                            dataLabels: {
                                total: {
                                    enabled: true,
                                    offsetX: 0,
                                    style: {
                                        fontSize: '13px',
                                        fontWeight: 900
                                    }
                                }
                            }
                        },
                    },
                    stroke: {
                        width: 1,
                        colors: ['#fff']
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    colors: [withinColor, dueColor, delayColor],
                    fill: {
                        opacity: 1
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left',
                        offsetX: 40
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });

            jQuery(function ($) {

                var element = document.getElementById("construction_donut_chart");

                var withinColor = KTUtil.getCssVariableValue('--bs-info');
                var dueColor = KTUtil.getCssVariableValue('--bs-warning');
                var delayColor = KTUtil.getCssVariableValue('--bs-danger');

                const ArrayFormValueData = [parseInt(ltrlTaskGood), parseInt(ltrlTaskDue), parseInt(ltrlTaskDelay)];
                const ArrayFormValueStatus = ['Good', 'Due', 'Delay'];

                //spn03Total.append(0);
                //div03PercentageBar.setAttribute('aria-valuenow', '0');
                //div03PercentageBar.classList.add('bg-danger')
                //div03PercentageBar.style.width = '0%';
                //spn03OverallPercentage.append('0%');
                //spn03OverallDetails.append('Avg. 0% completed  date.');

                if (!element) {
                    return;
                }
                var options = {
                    series: ArrayFormValueData,
                    labels: ArrayFormValueStatus,
                    chart: {
                        type: 'donut',
                        height: 250,
                        stacked: true,
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                const Status = config.w.config.labels[config.dataPointIndex];
                                ViewTaskDetails(Status);
                            }
                        }
                    },

                    plotOptions: {
                        bar: {
                            horizontal: true,
                            dataLabels: {
                                total: {
                                    enabled: true,
                                    offsetX: 0,
                                    style: {
                                        fontSize: '13px',
                                        fontWeight: 900
                                    }
                                }
                            }
                        },
                    },
                    stroke: {
                        width: 1,
                        colors: ['#fff']
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    colors: [withinColor, dueColor, delayColor],
                    fill: {
                        opacity: 1
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left',
                        offsetX: 40
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });

            jQuery(function ($) {

                var element = document.getElementById("request_donut_chart");

                var withinColor = KTUtil.getCssVariableValue('--bs-info');
                var dueColor = KTUtil.getCssVariableValue('--bs-warning');
                var delayColor = KTUtil.getCssVariableValue('--bs-danger');

                const ArrayFormValueData = [parseInt(ltrlRequestGood), parseInt(ltrlRequestDue), parseInt(ltrlRequestDelay)];
                const ArrayFormValueStatus = ['Good', 'Due', 'Delay'];

                console.log(ltrlRequestGood);

                //spn04Total.append(0);
                //div04PercentageBar.setAttribute('aria-valuenow', '0');
                //div04PercentageBar.classList.add('bg-danger')
                //div04PercentageBar.style.width = '0%';
                //spn04OverallPercentage.append('0%');
                //spn04OverallDetails.append('Avg. 0% completed  date.');

                if (!element) {
                    return;
                }
                var options = {
                    series: ArrayFormValueData,
                    labels: ArrayFormValueStatus,
                    chart: {
                        type: 'donut',
                        height: 250,
                        stacked: true,
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                const Status = config.w.config.labels[config.dataPointIndex];
                                ViewRequestDetails(Status);
                            }
                        }
                    },

                    plotOptions: {
                        bar: {
                            horizontal: true,
                            dataLabels: {
                                total: {
                                    enabled: true,
                                    offsetX: 0,
                                    style: {
                                        fontSize: '13px',
                                        fontWeight: 900
                                    }
                                }
                            }
                        },
                    },
                    stroke: {
                        width: 1,
                        colors: ['#fff']
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    colors: [withinColor, dueColor, delayColor],
                    fill: {
                        opacity: 1
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left',
                        offsetX: 40
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });

            jQuery(function ($) {

                var element = document.getElementById("requestwo_donut_chart");

                var withinColor = KTUtil.getCssVariableValue('--bs-info');
                var dueColor = KTUtil.getCssVariableValue('--bs-warning');
                var delayColor = KTUtil.getCssVariableValue('--bs-danger');

                const ArrayFormValueData = [parseInt(ltrlRequestWOGood), parseInt(ltrlRequestWODue), parseInt(ltrlRequestWODelay)];
                const ArrayFormValueStatus = ['Good', 'Due', 'Delay'];

                //spn05Total.append(0);
                //div05PercentageBar.setAttribute('aria-valuenow', '0');
                //div05PercentageBar.classList.add('bg-danger')
                //div05PercentageBar.style.width = '0%';
                //spn05OverallPercentage.append('0%');
                //spn05OverallDetails.append('Avg. 0% completed delay date.');

                if (!element) {
                    return;
                }
                var options = {
                    series: ArrayFormValueData,
                    labels: ArrayFormValueStatus,
                    chart: {
                        type: 'donut',
                        height: 250,
                        stacked: true,
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                const Status = config.w.config.labels[config.dataPointIndex];
                                ViewRequestWODetails(Status);
                            }
                        }
                    },

                    plotOptions: {
                        bar: {
                            horizontal: true,
                            dataLabels: {
                                total: {
                                    enabled: true,
                                    offsetX: 0,
                                    style: {
                                        fontSize: '13px',
                                        fontWeight: 900
                                    }
                                }
                            }
                        },
                    },
                    stroke: {
                        width: 1,
                        colors: ['#fff']
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    colors: [withinColor, dueColor, delayColor],
                    fill: {
                        opacity: 1
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left',
                        offsetX: 40
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });

            // default - form assigned
            jQuery(function ($) {
                var element = document.getElementById("overall_form_area_chart");

                if (!element) {
                    return;
                }
                var options = {
                    series: [
                        {
                            name: '',
                            data: ['']
                        }
                    ],
                    chart: {
                        type: 'bar',
                        height: 300,
                        stacked: true
                    },
                    colors: '#fff',
                    stroke: {
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: [''],
                        labels: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + ' Form(s)'
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left'
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            // default - form assigned

            // default - work order
            jQuery(function ($) {
                var element = document.getElementById("overall_wo_area_chart");

                if (!element) {
                    return;
                }
                var options = {
                    series: [
                        {
                            name: '',
                            data: ['']
                        }
                    ],
                    chart: {
                        type: 'bar',
                        height: 300,
                        stacked: true
                    },
                    colors: '#fff',
                    stroke: {
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: [''],
                        labels: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + ' Form(s)'
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left'
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            // default - work order

            // default - construction task
            jQuery(function ($) {
                var element = document.getElementById("overall_construction_area_chart");

                if (!element) {
                    return;
                }
                var options = {
                    series: [
                        {
                            name: '',
                            data: ['']
                        }
                    ],
                    chart: {
                        type: 'bar',
                        height: 300,
                        stacked: true
                    },
                    colors: '#fff',
                    stroke: {
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: [''],
                        labels: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + ' Form(s)'
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left'
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            // default - construction task

            // default - request
            jQuery(function ($) {
                var element = document.getElementById("overall_request_area_chart");

                if (!element) {
                    return;
                }
                var options = {
                    series: [
                        {
                            name: '',
                            data: ['']
                        }
                    ],
                    chart: {
                        type: 'bar',
                        height: 300,
                        stacked: true
                    },
                    colors: '#fff',
                    stroke: {
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: [''],
                        labels: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + ' Form(s)'
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left'
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            // default - request

            // default - request
            jQuery(function ($) {
                var element = document.getElementById("overall_requestwo_area_chart");

                if (!element) {
                    return;
                }
                var options = {
                    series: [
                        {
                            name: '',
                            data: ['']
                        }
                    ],
                    chart: {
                        type: 'bar',
                        height: 300,
                        stacked: true
                    },
                    colors: '#fff',
                    stroke: {
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: [''],
                        labels: {
                            formatter: function (val) {
                                return val
                            }
                        }
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return val + ' Form(s)'
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'left'
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            // default - request
        }
    </script>

</asp:Content>
