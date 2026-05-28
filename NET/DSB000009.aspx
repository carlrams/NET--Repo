<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000009.aspx.vb" Inherits="NET.DSB000009" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    
    <!--begin::Post-->
	<div class="content flex-row-fluid" id="kt_content">
				
		<!--begin::breadcrumb bar-->
		<div class="toolbar py-5">
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
						<li class="breadcrumb-item text-white">House Construction</li>
						<!--end::Item-->
                        <!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Territory</li>
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
								<a href="DSB000008" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Overview">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <path d="M21.7 18.9L18.6 15.8C17.9 16.9 16.9 17.9 15.8 18.6L18.9 21.7C19.3 22.1 19.9 22.1 20.3 21.7L21.7 20.3C22.1 19.9 22.1 19.3 21.7 18.9Z" fill="currentColor"/>
                                            <path opacity="0.3" d="M11 20C6 20 2 16 2 11C2 6 6 2 11 2C16 2 20 6 20 11C20 16 16 20 11 20ZM11 4C7.1 4 4 7.1 4 11C4 14.9 7.1 18 11 18C14.9 18 18 14.9 18 11C18 7.1 14.9 4 11 4ZM8 11C8 9.3 9.3 8 11 8C11.6 8 12 7.6 12 7C12 6.4 11.6 6 11 6C8.2 6 6 8.2 6 11C6 11.6 6.4 12 7 12C7.6 12 8 11.6 8 11Z" fill="currentColor"/>
                                        </svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="DSB000009" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Territory" >
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <path opacity="0.3" d="M6 22H4V3C4 2.4 4.4 2 5 2C5.6 2 6 2.4 6 3V22Z" fill="currentColor"/>
                                            <path d="M18 14H4V4H18C18.8 4 19.2 4.9 18.7 5.5L16 9L18.8 12.5C19.3 13.1 18.8 14 18 14Z" fill="currentColor"/>
                                        </svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
							<li class="nav-item m-0">
								<a href="DSB000010" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Project" >
									<!--begin::Svg Icon | path: icons/duotune/abstract/abs015.svg-->
									<span class="svg-icon svg-icon-2">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <path opacity="0.3" d="M18.0624 15.3454L13.1624 20.7453C12.5624 21.4453 11.5624 21.4453 10.9624 20.7453L6.06242 15.3454C4.56242 13.6454 3.76242 11.4452 4.06242 8.94525C4.56242 5.34525 7.46242 2.44534 11.0624 2.04534C15.8624 1.54534 19.9624 5.24525 19.9624 9.94525C20.0624 12.0452 19.2624 13.9454 18.0624 15.3454ZM13.0624 10.0453C13.0624 9.44534 12.6624 9.04534 12.0624 9.04534C11.4624 9.04534 11.0624 9.44534 11.0624 10.0453V13.0453H13.0624V10.0453Z" fill="currentColor"/>
                                            <path d="M12.6624 5.54531C12.2624 5.24531 11.7624 5.24531 11.4624 5.54531L8.06241 8.04531V12.0453C8.06241 12.6453 8.46241 13.0453 9.06241 13.0453H11.0624V10.0453C11.0624 9.44531 11.4624 9.04531 12.0624 9.04531C12.6624 9.04531 13.0624 9.44531 13.0624 10.0453V13.0453H15.0624C15.6624 13.0453 16.0624 12.6453 16.0624 12.0453V8.04531L12.6624 5.54531Z" fill="currentColor"/>
                                        </svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="DSB000013" class="btn btn-custom  btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Batch">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <path opacity="0.5" d="M18 2H9C7.34315 2 6 3.34315 6 5H8C8 4.44772 8.44772 4 9 4H18C18.5523 4 19 4.44772 19 5V16C19 16.5523 18.5523 17 18 17V19C19.6569 19 21 17.6569 21 16V5C21 3.34315 19.6569 2 18 2Z" fill="currentColor"/>
                                            <path fill-rule="evenodd" clip-rule="evenodd" d="M14.7857 7.125H6.21429C5.62255 7.125 5.14286 7.6007 5.14286 8.1875V18.8125C5.14286 19.3993 5.62255 19.875 6.21429 19.875H14.7857C15.3774 19.875 15.8571 19.3993 15.8571 18.8125V8.1875C15.8571 7.6007 15.3774 7.125 14.7857 7.125ZM6.21429 5C4.43908 5 3 6.42709 3 8.1875V18.8125C3 20.5729 4.43909 22 6.21429 22H14.7857C16.5609 22 18 20.5729 18 18.8125V8.1875C18 6.42709 16.5609 5 14.7857 5H6.21429Z" fill="currentColor"/>
                                        </svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</li>
                            <li class="nav-item m-0">
								<a href="DSB000015" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white" data-bs-toggle="tooltip" data-bs-placement="top"  title="Report">
									<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
									<span class="svg-icon svg-icon-1">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                            <path opacity="0.3" d="M10.9607 12.9128H18.8607C19.4607 12.9128 19.9607 13.4128 19.8607 14.0128C19.2607 19.0128 14.4607 22.7128 9.26068 21.7128C5.66068 21.0128 2.86071 18.2128 2.16071 14.6128C1.16071 9.31284 4.96069 4.61281 9.86069 4.01281C10.4607 3.91281 10.9607 4.41281 10.9607 5.01281V12.9128Z" fill="currentColor"/>
                                            <path d="M12.9607 10.9128V3.01281C12.9607 2.41281 13.4607 1.91281 14.0607 2.01281C16.0607 2.21281 17.8607 3.11284 19.2607 4.61284C20.6607 6.01284 21.5607 7.91285 21.8607 9.81285C21.9607 10.4129 21.4607 10.9128 20.8607 10.9128H12.9607Z" fill="currentColor"/>
                                        </svg>
									</span>
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
		</div>
		<!--begin::breadcrumb bar-->

		<!--begin::piechart-->
        <div class="row g-5 mb-5">
			<div class="col-lg-4">
				<!--begin::List widget 7-->
				<div class="card h-100 card-flush mb-5">
					<!--begin::Header-->
					<div class="card-header">
						<!--begin::Title-->
						<h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Summary</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARAll()"><asp:Label ID="lblTotal" runat="server" Text="345 Units"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
					</div>
					<!--end::Header-->
					<!--begin::Body-->
					<div class="card-body pt-0 pb-0">
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARDivision('Quezon')">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder">Q</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">Quezon</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Territory</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblQUETotCnt" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-primary fs-base"><asp:Label ID="lblQUETotRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Quezon','On-going')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">On-going</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblQUEOngCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-warning fs-base"><asp:Label ID="lblQUEOngRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<div class=" pl-5 pr-5">
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Quezon','On-time')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-warning me-3"></span>
										<span class="text-gray-600 fs-6">On-time</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblQUEOntCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblQUEOntRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Quezon','Delayed')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-danger me-3"></span>
										<span class="text-gray-600 fs-6">Delayed</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblQUEDelCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblQUEDelRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
						</div>
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Quezon','Not yet started')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">Not yet started</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblQUEForCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-info fs-base"><asp:Label ID="lblQUEForRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--begin::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARDivision('Laguna')">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder">L</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">Laguna</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Territory</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblLAGTotCnt" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-primary fs-base"><asp:Label ID="lblLAGTotRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Laguna','On-going')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">On-going</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblLAGOngCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-warning fs-base"><asp:Label ID="lblLAGOngRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<div class=" pl-5 pr-5">
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Laguna','On-time')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-warning me-3"></span>
										<span class="text-gray-600 fs-6">On-time</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblLAGOntCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblLAGOntRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Laguna','Delayed')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-danger me-3"></span>
										<span class="text-gray-600 fs-6">Delayed</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblLAGDelCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblLAGDelRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
						</div>
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Laguna','Not yet started')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">Not yet started</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblLAGForCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-info fs-base"><asp:Label ID="lblLAGForRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--begin::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARDivision('Batangas')">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder">B</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">Batangas</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Territory</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblBATTotCnt" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-primary fs-base"><asp:Label ID="lblBATTotRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Batangas','On-going')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">On-going</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblBATOngCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-warning fs-base"><asp:Label ID="lblBATOngRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<div class=" pl-5 pr-5">
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Batangas','On-time')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-warning me-3"></span>
										<span class="text-gray-600 fs-6">On-time</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblBATOntCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblBATOntRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Batangas','Delayed')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-danger me-3"></span>
										<span class="text-gray-600 fs-6">Delayed</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblBATDelCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblBATDelRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
						</div>
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARDivisionStatus('Batangas','Not yet started')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">Not yet started</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblBATForCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-info fs-base"><asp:Label ID="lblBATForRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--begin::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARAll()">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder">T</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">Total</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Units</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblTOTTotCnt" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-primary fs-base"><asp:Label ID="lblTOTTotRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARAllStatus('On-going')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">On-going</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblTOTOngCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-warning fs-base"><asp:Label ID="lblTOTOngRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
						<div class=" pl-5 pr-5">
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARAllStatus('On-time')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-warning me-3"></span>
										<span class="text-gray-600 fs-6">On-time</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblTOTOntCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblTOTOntRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
							<!--begin::Item-->
							<a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARAllStatus('Delayed')">
								<div class="d-flex align-items-center me-5">
									<div class="me-5">
										<span class="bullet bg-danger me-3"></span>
										<span class="text-gray-600 fs-6">Delayed</span>
									</div>
								</div>
								<div class="d-flex align-items-center">
									<asp:Label ID="lblTOTDelCnt" runat="server" class="text-gray-600 fs-6 me-3" Text="0"></asp:Label>
									<div class="d-flex text-start w-60px"><asp:Label ID="lblTOTDelRate" runat="server" CssClass="text-gray-600" Text="0.00%"></asp:Label></div>
								</div>
							</a>
							<!--end::Item-->
						</div>
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARAllStatus('Not yet started')">
							<div class="d-flex align-items-center me-5">
								<div class="me-5">
									<span class="text-gray-700 fw-bold fs-6">Not yet started</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblTOTForCnt" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
								<div class="d-flex text-start w-60px badge badge-info fs-base"><asp:Label ID="lblTOTForRate" runat="server" Text="0.00%"></asp:Label></div>
							</div>
						</a>
						<!--end::Item-->
					
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::List widget 7-->
			</div>
			<div class="col-lg-8">
				<!--begin::Card-->
				<div class="card card-flush mb-5">
                    <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Quezon</span>
                            <span class="text-muted fw-bold fs-7"><asp:Label ID="lblQUETotal" runat="server" Text="0 Units"></asp:Label></span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
					<!--begin::Card body-->
					<div class="card-body p-0 pl-5">
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap">
							<!--begin::Chart-->
							<div class="d-flex flex-center h-200px w-200px mb-5">
                                <div id="que_pie_chart" ></div>
							</div>
							<!--end::Chart-->
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-warning me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Quezon','On-time')">On-time</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblQUEOntime" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-danger me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Quezon','Delayed')">Delayed</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblQUEDelayed" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-info me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Quezon','Not yet started')">Not yet started</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblQUENotYetStarted" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
						</div>
						<!--end::Wrapper-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Card-->
               <!--begin::Card-->
				<div class="card card-flush mb-5">
                    <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Laguna</span>
                            <span class="text-muted fw-bold fs-7"><asp:Label ID="lblLAGTotal" runat="server" Text="0 Units"></asp:Label></span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
					<!--begin::Card body-->
					<div class="card-body p-0 pl-5">
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap">
							<!--begin::Chart-->
							<div class="d-flex flex-center h-200px w-200px mb-5">
								<div id="lag_pie_chart"></div>
							</div>
							<!--end::Chart-->
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-warning me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Laguna','On-time')">On-time</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblLAGOntime" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-danger me-3"></div>
                                    <a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Laguna','Delayed')">Delayed</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblLAGDelayed" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center">
									<div class="bullet bg-info me-3"></div>
									<a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Laguna','Not yet started')">Not yet started</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblLAGNotYetStarted" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
						</div>
						<!--end::Wrapper-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Card-->
                <!--begin::Card-->
				<div class="card card-flush">
                    <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Batangas</span>
                            <span class="text-muted fw-bold fs-7"><asp:Label ID="lblBATTotal" runat="server" Text="0 Units"></asp:Label></span>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
					<!--begin::Card body-->
					<div class="card-body p-0 pl-5">
						<!--begin::Wrapper-->
						<div class="d-flex flex-wrap">
							<!--begin::Chart-->
							<div class="d-flex flex-center h-200px w-200px mb-5">
								<div id="bat_pie_chart"></div>
							</div>
							<!--end::Chart-->
							<!--begin::Labels-->
							<div class="d-flex flex-column justify-content-center flex-row-fluid pe-11 mb-5">
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-warning me-3"></div>
									<a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Batangas','On-time')">On-time</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblBATOntime" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center mb-3">
									<div class="bullet bg-danger me-3"></div>
									<a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Batangas','Delayed')">Delayed</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblBATDelayed" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
								<!--begin::Label-->
								<div class="d-flex fs-6 fw-bold align-items-center">
									<div class="bullet bg-info me-3"></div>
									<a class="text-gray-400 pointer" onclick="ViewWARDivisionStatus('Batangas','Not yet started')">Not yet started</a>
									<div class="ms-auto fw-bolder text-gray-700"><asp:Label ID="lblBATNotYetStarted" runat="server" Text="0"></asp:Label></div>
								</div>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
						</div>
						<!--end::Wrapper-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Card-->
			</div>
		</div>
		<!--end::piechart-->
		
        <!--begin::Modal WAR-->
		<div id="mdlWAR" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Weekly Accomplishment Report</h5>
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
						<!--begin::toolbar-->
						<div class="d-flex flex-stack align-items-center me-5">
							<!--begin::Search-->
							<div class="d-flex align-items-center position-relative w-md-400px me-md-2">
								<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
								<span class="svg-icon svg-icon-2 position-absolute ms-4">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
								<!--end::Svg Icon-->
								<input id="tbxFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
							</div>
							<!--end::Search-->
                            <!--begin::Export buttons-->
                            <div id="kt_datatable_example_buttons" class="d-none">
                            </div>
                            <!--end::Export buttons-->
                            <!--begin::Export dropdown-->
                           <button type="button" class="btn btn-sm btn-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
                                Export
                           </button>
                           <!--begin::Menu-->
                           <div id="kt_datatable_example_export_menu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-200px py-4" data-kt-menu="true">
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="copy">Copy to clipboard</a>
                                </div>
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                                </div>
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="csv">Export as CSV</a>
                                </div>
                                <div class="menu-item px-3">
                                    <a href="#" class="menu-link px-3" data-kt-export="pdf">Export as PDF</a>
                                </div>
                           </div>
                           <!--end::Menu-->
                           <!--end::Export dropdown-->
   
						</div>
						<!--end::toolbar-->
						<!--begin::gridview-->
						<div class="table-responsive overflow-hidden min-h-350px">
							<table id="gvWAR" class="table table-no-border table-row-bordered table-hover align-middle">
								<thead>
                                    <tr>
									    <th>
										
									    </th>
									    <th class="fw-bold fs-6 text-dark min-w-100px">
										    WO#
									    </th>
									    <th class="fw-bold fs-6 text-dark min-w-100px">
										    Territory
									    </th>
									    <th class="fw-bold fs-6 text-dark min-w-150px">
										    Project
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-200px">
										    Unit
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-150px">
										    Status
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-300px">
										    Contractor
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-100px">
										    Batch
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-100px">
										    Accomplisment
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-75px">
										    As of
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-300px">
										    Remarks
									    </th>
                                        <th class="fw-bold fs-6 text-dark min-w-150px">
										    PE
									    </th>
								    </tr>
								</thead>
                                <tbody>
                                    
                                </tbody>
							</table>
						</div>
						<!--end::gridview-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal WAR-->

	</div>
	<!--end::Post-->
	
	<script type="text/javascript">

        //form variable
        let ltrlPieQUEOntime = <asp:Literal ID="ltrlPieQUEOntime" runat="server" />;
        let ltrlPieQUEDelayed = <asp:Literal ID="ltrlPieQUEDelayed" runat="server" />;
        let ltrlPieQUENotYetStarted = <asp:Literal ID="ltrlPieQUENotYetStarted" runat="server" />;
        let ltrlPieLAGOntime = <asp:Literal ID="ltrlPieLAGOntime" runat="server" />;
        let ltrlPieLAGDelayed = <asp:Literal ID="ltrlPieLAGDelayed" runat="server" />;
        let ltrlPieLAGNotYetStarted = <asp:Literal ID="ltrlPieLAGNotYetStarted" runat="server" />;
        let ltrlPieBATOntime = <asp:Literal ID="ltrlPieBATOntime" runat="server" />;
        let ltrlPieBATDelayed = <asp:Literal ID="ltrlPieBATDelayed" runat="server" />;
        let ltrlPieBATNotYetStarted = <asp:Literal ID="ltrlPieBATNotYetStarted" runat="server" />;
        //form variable

        //view war
        function ViewWARAll() {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000009',
                    'Type': 'View WAR (All)'
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
		}
        function ViewWARAllStatus(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000009',
					'Type': 'View WAR (All - Status)',
					'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARDivision(Division) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000009',
					'Type': 'View WAR (Division)',
                    'Division': Division
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
		}
        function ViewWARDivisionStatus(Division,Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000009',
                    'Type': 'View WAR (Division - Status)',
					'Division': Division,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function DisplayWAR(response) {
            //datatable
            var gvWAR = $("#gvWAR").DataTable({
                bFilter: true,
                bSort: false,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollCollapse: true,
				scrollY: '300px',
                scrollX: true,
                fixedColumns: { left: 2 },
                select: true,
                data: response,
                columns: [
                    { data: 'Bullet' },
                    { data: 'HWCode' },
                    { data: 'Territory' },
                    { data: 'Project' },
                    { data: 'ModelName' },
                    { data: 'Status' },
                    { data: 'vendor' },
                    { data: 'BatchNo' },
                    { data: 'POCRate' },
                    { data: 'POCDate' },
                    { data: 'Remarks' },
                    { data: 'PE' }]
            });
            //datatable
            //search
            $('#tbxSearchWAR').on('keyup', function () {
                gvWAR.search(this.value).draw();
            });
            //search
            //export
            const documentTitle = 'Weekly Accomplishment Report';
            var buttons = new $.fn.dataTable.Buttons(gvWAR, {
                buttons: [
                    {
                        extend: 'copyHtml5',
                        title: documentTitle
                    },
                    {
                        extend: 'excelHtml5',
                        title: documentTitle
                    },
                    {
                        extend: 'csvHtml5',
                        title: documentTitle
                    },
                    {
                        extend: 'pdfHtml5',
                        title: documentTitle
                    }
                ]
            }).container().appendTo($('#kt_datatable_example_buttons'));
            // Hook dropdown menu click event to datatable export buttons
            const exportButtons = document.querySelectorAll('#kt_datatable_example_export_menu [data-kt-export]');
            exportButtons.forEach(exportButton => {
                exportButton.addEventListener('click', e => {
                    e.preventDefault();

                    // Get clicked export value
                    const exportValue = e.target.getAttribute('data-kt-export');
                    const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                    // Trigger click event on hidden datatable export buttons
                    target.click();
                    console.log(target);
                });
            });
            //export
            $('#mdlWAR').modal('show');
        }
        //view war

        //loan data
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                document.getElementById('que_pie_chart').innerHTML = "";
                var element = document.getElementById('que_pie_chart');
                if (!element) {
                    return;
                }

                var options = {
                    series: [ltrlPieQUEOntime, ltrlPieQUEDelayed, ltrlPieQUENotYetStarted],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Quezon', Status)}},  },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['On-time', 'Delayed', 'Not yet started'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],   
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
            jQuery(function ($) {
                document.getElementById('lag_pie_chart').innerHTML = "";
                var element = document.getElementById('lag_pie_chart');
                if (!element) {
                    return;
                }

                var options = {
                    series: [ltrlPieLAGOntime, ltrlPieLAGDelayed, ltrlPieLAGNotYetStarted],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Laguna', Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['On-time', 'Delayed', 'Not yet started'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],
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
            jQuery(function ($) {
                document.getElementById('bat_pie_chart').innerHTML = "";
                var element = document.getElementById('bat_pie_chart');
                if (!element) {
                    return;
                }

                var options = {
                    series: [ltrlPieBATOntime, ltrlPieBATDelayed, ltrlPieBATNotYetStarted],
                    chart: { type: 'donut', events: { dataPointSelection: function (event, chartContext, config) { const Status = config.w.config.labels[config.dataPointIndex]; ViewWARDivisionStatus('Batangas', Status) } }, },
                    plotOptions: { pie: { donut: { size: '0%', labels: { value: { fontSize: '10px' } } } } },
                    labels: ['On-time', 'Delayed', 'Not yet started'],
                    legend: { show: false, },
                    colors: ['#ffc700', '#f1416c', '#009ef7'],
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
        }
        //loan data

    </script>

</asp:Content>
