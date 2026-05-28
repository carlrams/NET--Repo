<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000008.aspx.vb" Inherits="NET.DSB000008" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Overview</li>
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
								<a href="DSB000008" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white active me-3" data-bs-toggle="tooltip" data-bs-placement="top" title="Overview">
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
								<a href="DSB000009" class="btn btn-custom btn-sm btn-icon btn-color-white btn-active-white me-3" data-bs-toggle="tooltip" data-bs-placement="top"  title="Territory" >
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
				<!--begin::Card-->
				<div class="card h-100 card-flush">
                    <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Overall Status of Units</span>
                            <a class="text-muted fw-bold fs-6 pointer" onclick="ViewWARAll()"><asp:Label ID="lblTotal1" runat="server" Text="0 Units"></asp:Label></a>
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
					<!--begin::Card body-->
					<div class="card-body pt-0 pb-0">
                        <!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARCompleted()">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder bg-success text-white">C</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">Completed</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Units</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblCompletedAll" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
                        <div class=" pl-5 pr-5">
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('1')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">January</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedJan" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('2')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">February</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedFeb" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('3')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">March</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedMar" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('4')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">April</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedApr" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('5')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">May</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedMay" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('6')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">June</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedJun" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('7')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">July</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedJul" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('8')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">August</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedAug" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('9')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">September</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedSep" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('10')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">October</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedOct" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('11')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">November</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedNov" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARCompletedMonth('12')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-success me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">December</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblCompletedDec" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
                        </div>
						<!--end::Item-->
                        <!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWAROnGoing()">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder bg-warning text-white">O</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">On-going</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Units</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblOngoing" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
                        <!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARForConstruction()">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder bg-info text-white">F</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">For Construction</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Units</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblForConstruction" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
                        <div class=" pl-5 pr-5">
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARForConstructionStatus('Newly Endorsed')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-NewlyEndorsed me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">Newly Endorsed</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblNewlyEndorsed" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARForConstructionStatus('for Costing')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-ForCosting me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">For Costing</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblForCosting" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARForConstructionStatus('for Budget')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-ForBudget me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">For Budget</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblForBudget" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARForConstructionStatus('for Award')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-ForAward me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">For Award</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblForAward" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                            <!--begin::Item-->
						    <a class="d-flex flex-stack mb-3 pointer" onclick="ViewWARForConstructionStatus('Awarded')">
							    <div class="d-flex align-items-center me-5">
								    <div class="me-5">
                                        <span class="bullet bg-Awarded me-3"></span>
									    <span class="text-gray-700 fw-bold fs-6">Awarded</span>
								    </div>
							    </div>
							    <div class="d-flex align-items-center">
								    <asp:Label ID="lblAwarded" runat="server" class="text-gray-700 fw-bold fs-6 me-3" Text="0"></asp:Label>
							    </div>
						    </a>
						    <!--end::Item-->
                        </div>
                        <!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
						<!--begin::Item-->
						<a class="d-flex flex-stack pointer" onclick="ViewWARAll()">
							<div class="d-flex align-items-center me-5">
								<div class="symbol symbol-30px me-5">
									<span class="symbol-label fw-bolder bg-success text-white">T</span>
								</div>
								<div class="me-5">
									<span class="text-gray-800 fw-bolder fs-6">Total</span>
									<span class="text-muted fw-bolder fs-7 d-block text-start ps-0">Units</span>
								</div>
							</div>
							<div class="d-flex align-items-center">
								<asp:Label ID="lblTotal2" runat="server" class="text-gray-800 fw-bolder fs-6 me-3" Text="0"></asp:Label>
							</div>
						</a>
						<!--end::Item-->
						<!--begin::Separator-->
						<div class="separator separator-dashed my-3"></div>
						<!--end::Separator-->
					</div>
					<!--end::Card body-->
				</div>
				<!--end::Card-->
			</div>
			<div class="col-lg-8">
				<!--begin::bar chart-->
		        <div class="card card-flush mb-5">
                    <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">Completed</span>
                            <!--begin::Labels-->
							<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold">
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARCompletedStatus('On-time')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-primary"></span></span>On-time
								</a>
								<!--end::Label-->
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARCompletedStatus('Delayed')">
								    <span class="menu-bullet d-flex align-items-center me-2"><span class="bullet bg-danger"></span></span>Delayed
								</a>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body">
				        <div id="completed_bar_chart" style="height:200px;"></div>
			        </div>
			        <!--end: Card Body-->
		        </div>
		        <!--end::bar chart-->
                <!--begin::bar chart-->
		        <div class="card card-flush mb-5">
                     <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">On-Going</span>
                            <!--begin::Labels-->
							<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold">
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWAROnGoingStatus('On-time')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-primary"></span></span>On-time
								</a>
								<!--end::Label-->
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWAROnGoingStatus('Delayed')">
								    <span class="menu-bullet d-flex align-items-center me-2"><span class="bullet bg-danger"></span></span>Delayed
								</a>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body">
				        <div id="ongoing_bar_chart" style="height:200px;"></div>
			        </div>
			        <!--end: Card Body-->
		        </div>
		        <!--end::bar chart-->
                <!--begin::bar chart-->
		        <div class="card card-flush">
                     <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3 mb-1">For Construction</span>
                            <!--begin::Labels-->
							<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold">
								<!--begin::Label-->
                                <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARForConstructionStatus('Newly Endorsed')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-NewlyEndorsed"></span></span>Newly Endorsed
								</a>
								<!--end::Label-->
								<!--begin::Label-->
                                <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARForConstructionStatus('for Costing')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-ForCosting"></span></span>for Costing
								</a>
								<!--end::Label-->
                                <!--begin::Label-->
                                <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARForConstructionStatus('for Budget')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-ForBudget"></span></span>for Budget
								</a>
								<!--end::Label-->
                                <!--begin::Label-->
                                <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARForConstructionStatus('for Award')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-ForAward"></span></span>for Award
								</a>
								<!--end::Label-->
                                <!--begin::Label-->
                                <a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARForConstructionStatus('Awarded')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-Awarded"></span></span>Awarded
								</a>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body">
				        <div id="forconstruction_bar_chart" style="height:200px;"></div>
			        </div>
			        <!--end: Card Body-->
		        </div>
		        <!--end::bar chart-->
			</div>
		</div>
		<!--end::piechart-->
  
        <!--begin::chart-->
		<div class="row g-5">
			<div class="col-lg-6">
				<!--begin::line chart-->
		        <div class="card h-100 card-flush">
			        <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3">Accomplishment By Year</span>
                            <!--begin::Labels-->
							<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold">
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARYear('COC')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-primary"></span></span>COC
								</a>
								<!--end::Label-->
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARYear('PMD')">
								    <span class="menu-bullet d-flex align-items-center me-2"><span class="bullet bg-warning"></span></span>PMD
								</a>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
				        </h3>
				        <!--end::Title-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div class="card-body">
				        <div id="year_line_chart" style="height:200px;"></div>
			        </div>
			        <!--end: Card Body-->
		        </div>
		        <!--end::line chart-->
			</div>
			<div class="col-lg-6">
				<!--begin::bar chart-->
		        <div class="card h-100 card-flush">
			        <!--begin::Header-->
			        <div class="card-header">
				        <!--begin::Title-->
				        <h3 class="card-title align-items-start flex-column">
					        <span class="card-label fw-bolder fs-3">Accomplishment By Current Year</span>
                            <!--begin::Labels-->
							<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold">
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARMonth('Target')">
								    <span class="menu-bullet d-flex align-items-center me-2" ><span class="bullet bg-primary"></span></span>Target
								</a>
								<!--end::Label-->
								<!--begin::Label-->
								<a class="d-flex align-items-center me-6 pointer fs-6 text-muted" onclick="ViewWARMonth('Actual')">
								    <span class="menu-bullet d-flex align-items-center me-2"><span class="bullet bg-warning"></span></span>Actual
								</a>
								<!--end::Label-->
							</div>
							<!--end::Labels-->
				        </h3>
				        <!--end::Title-->
				        <!--begin::Card toolbar-->
				        <div class="card-toolbar flex-row-fluid justify-content-end gap-5">
					        <div class="w-100 mw-100px">
						        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-select form-select-sm form-select-border min-h-35px" data-control="select2" data-hide-search="true" data-placeholder="Status" data-kt-ecommerce-order-filter="status" onchange="ddlYearOnChange(this)">

						        </asp:DropDownList>
					        </div>
				        </div>
				        <!--end::Card toolbar-->
			        </div>
			        <!--end::Header-->
			        <!--begin::Body-->
			        <div id="month_bar_container" class="card-body p-0">
				        <div id="month_bar_chart" style="height:200px;"></div>
			        </div>
			        <!--end: Card Body-->
		        </div>
		        <!--end::bar chart-->
			</div>
		</div>
		<!--end::chart-->

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
        var ltrlCompletedBarCategory = '<asp:Literal ID="ltrlCompletedBarCategory" runat="server" />';
        var ltrlCompletedBarDelayedValueData = '<asp:Literal ID="ltrlCompletedBarDelayedValueData" runat="server" />';
        var ltrlCompletedBarOntimeValueData = '<asp:Literal ID="ltrlCompletedBarOntimeValueData" runat="server" />';
        var ltrlOngoingBarCategory = '<asp:Literal ID="ltrlOngoingBarCategory" runat="server" />';
        var ltrlOngoingBarDelayedValueData = '<asp:Literal ID="ltrlOngoingBarDelayedValueData" runat="server" />';
        var ltrlOngoingBarOntimeValueData = '<asp:Literal ID="ltrlOngoingBarOntimeValueData" runat="server" />';
        var ltrlForconstructionBarCategory = '<asp:Literal ID="ltrlForconstructionBarCategory" runat="server" />';
        var ltrlForconstructionBarNewlyEndorsed = '<asp:Literal ID="ltrlForconstructionBarNewlyEndorsed" runat="server" />';
        var ltrlForconstructionBarForCosting = '<asp:Literal ID="ltrlForconstructionBarForCosting" runat="server" />';
        var ltrlForconstructionBarForBudget = '<asp:Literal ID="ltrlForconstructionBarForBudget" runat="server" />';
        var ltrlForconstructionBarForAward = '<asp:Literal ID="ltrlForconstructionBarForAward" runat="server" />';
        var ltrlForconstructionBarAwarded = '<asp:Literal ID="ltrlForconstructionBarAwarded" runat="server" />';
        var ltrlYearLineCategory = '<asp:Literal ID="ltrlYearLineCategory" runat="server" />';
        var ltrlYearLineCOCValueData = '<asp:Literal ID="ltrlYearLineCOCValueData" runat="server" />';
        var ltrlYearLinePMDValueData = '<asp:Literal ID="ltrlYearLinePMDValueData" runat="server" />';
        var ltrlMonthBarTarValueData = '<asp:Literal ID="ltrlMonthBarTarValueData" runat="server" />';
        var ltrlMonthBarActValueData = '<asp:Literal ID="ltrlMonthBarActValueData" runat="server" />';
        //form variable

        //view war
        function ViewWARAll() {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (All)'
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARCompleted() {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Completed)'
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARCompletedMonth(Month) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Completed - Month)',
                    'Month': Month
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARCompletedStatus(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Completed - Status)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARCompletedBatch(BatchNo, Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Completed - Batch)',
                    'BatchNo': BatchNo,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWAROnGoing() {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (On-Going)'
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWAROnGoingStatus(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (On-Going - Status)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWAROnGoingBatch(BatchNo, Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (On-Going - Batch)',
                    'BatchNo': BatchNo,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARForConstruction() {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (For Construction)'
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARForConstructionStatus(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (For Construction - Status)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARForConstructionBatch(BatchNo, Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (For Construction - Batch)',
                    'BatchNo': BatchNo,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARYear(Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Year)',
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARYearStatus(Year, Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Year - Status)',
                    'Year': Year,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARMonth(Status) {
            var ddlYear = document.getElementById('ContentPlaceHolder1_ddlYear');
            var selectIndex = ddlYear.selectedIndex;
            var Year = ddlYear.options[selectIndex].text;

            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Month)',
                    'Year': Year,
                    'Status': Status
                },
                success: function (response) {
                    DisplayWAR(response)
                },
            });
        }
        function ViewWARMonthStatus(Year, Month, Status) {
            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View WAR (Month - Status)',
                    'Year': Year,
                    'Month': Month,
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
                bFilter: false,
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

        //change year
        function ddlYearOnChange(selectObj) {
            var selectIndex = selectObj.selectedIndex;
			var selectValue = selectObj.options[selectIndex].text;

            $.ajax({
                type: "POST",
                url: "HND000003.ashx",
                data: {
                    'FormCode': 'DSB000008',
                    'Type': 'View Year',
                    'Year': selectValue
                },
				success: function (response) {
                    document.getElementById('month_bar_container').innerHTML = "";
                    document.getElementById('month_bar_container').innerHTML = "<div id='month_bar_chart' style='height: 200px;'></div>";
					var ltrlBarActValueData = response[0].Actual;
                    var ltrlBarTarValueData = response[0].Target;

                    var element = document.getElementById('month_bar_chart');
                    var height = parseInt(KTUtil.css(element, 'height'));
                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                    var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                    var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                    const ArrayTarValueData = ltrlBarTarValueData.split(",");
                    const ArrayActValueData = ltrlBarActValueData.split(",");
                    if (!element) {
                        return;
                    }
                    var options = {
                        series: [{
                            name: 'Target',
                            data: ArrayTarValueData
                        }, {
                            name: 'Actual',
                            data: ArrayActValueData
                        }],
                        chart: {
                            fontFamily: 'inherit',
                            type: 'bar',
                            height: height,
                            toolbar: {
                                show: false
                            },
                            events: {
                                dataPointSelection: function (event, chartContext, config) {
                                    var ddlYear = document.getElementById('ContentPlaceHolder1_ddlYear');
                                    var selectIndex = ddlYear.selectedIndex;
                                    var Year = ddlYear.options[selectIndex].text;
                                    var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                    var Status = config.w.globals.seriesNames[config.seriesIndex];
                                    ViewWARMonthStatus(Year, Month, Status);
                                },
                            },
                        },
                        plotOptions: {
                            bar: {
                                horizontal: false,
                                columnWidth: ['70%'],
                                endingShape: 'rounded'
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
                            width: 2,
                            colors: ['transparent']
                        },
                        xaxis: {
                            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
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
                                    return + val + ' Units'
                                }
                            }
                        },
                        colors: [baseColor, secondaryColor],
                        grid: {
                            borderColor: borderColor,
                            strokeDashArray: 4,
                            yaxis: {
                                lines: {
                                    show: true
                                }
                            }
                        },
                        title: {
                            text: 'Monthly Inflation in Argentina, 2002',
                            floating: true,
                            offsetY: 330,
                            align: 'center',
                            style: {
                                color: '#444'
                            }
                        }
                    };
                    var chart = new ApexCharts(element, options);
                    chart.render();
                }
            });
        }
        //change year

        //loan data
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //combobox
                $('[data-kt-repeater="select2"]').select2();
			    //combobox


                var element = document.getElementById('completed_bar_chart');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-gray-300');
                const ArrayDelayedValueData = ltrlCompletedBarDelayedValueData.split(",");
                const ArrayOntimeValueData = ltrlCompletedBarOntimeValueData.split(",");
                const ArrayCategory = ltrlCompletedBarCategory.split(",");
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'Delayed',
                        data: ArrayDelayedValueData
                    }, {
                        name: 'On-time',
                        data: ArrayOntimeValueData
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var BatchNo = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                ViewWARCompletedBatch(BatchNo, Status);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['70%'],
                            endingShape: 'rounded'
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
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ArrayCategory,
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
                                return + val + ' Units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    title: {
                        text: 'Completed',
                        floating: true,
                        offsetY: 330,
                        align: 'center',
                        style: {
                            color: '#444'
                        }
                    }
                };
                var chart = new ApexCharts(element, options);
                chart.render();
            });
            jQuery(function ($) {
                var element = document.getElementById('ongoing_bar_chart');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-danger');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-primary');
                const ArrayDelayedValueData = ltrlOngoingBarDelayedValueData.split(",");
                const ArrayOntimeValueData = ltrlOngoingBarOntimeValueData.split(",");
                const ArrayCategory = ltrlOngoingBarCategory.split(",");
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'Delayed',
                        data: ArrayDelayedValueData
                    }, {
                        name: 'On-time',
                        data: ArrayOntimeValueData
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var BatchNo = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                ViewWAROnGoingBatch(BatchNo, Status);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['70%'],
                            endingShape: 'rounded'
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
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ArrayCategory,
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
                                return + val + ' Units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    title: {
                        text: 'On-Going',
                        floating: true,
                        offsetY: 330,
                        align: 'center',
                        style: {
                            color: '#444'
                        }
                    }
                };
                var chart = new ApexCharts(element, options);
                chart.render();
            });
            jQuery(function ($) {
                var element = document.getElementById('forconstruction_bar_chart');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-danger');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-primary');
                const ArrayNewlyEndorsedValueData = ltrlForconstructionBarNewlyEndorsed.split(",");
                const ArrayForCostingValueData = ltrlForconstructionBarForCosting.split(",");
                const ArrayForBudgetValueData = ltrlForconstructionBarForBudget.split(",");
                const ArrayForAwardValueData = ltrlForconstructionBarForAward.split(",");
                const ArrayAwardedValueData = ltrlForconstructionBarAwarded.split(",");
                const ArrayCategory = ltrlForconstructionBarCategory.split(",");
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'Newly Endorsed',
                        data: ArrayNewlyEndorsedValueData
                    }, {
                        name: 'for Costing',
                        data: ArrayForCostingValueData
                    }, {
                        name: 'for Budget',
                        data: ArrayForBudgetValueData
                    }, {
                        name: 'for Award',
                        data: ArrayForAwardValueData
                    }, {
                        name: 'Awarded',
                        data: ArrayAwardedValueData
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var BatchNo = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                ViewWARForConstructionBatch(BatchNo, Status);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['70%'],
                            endingShape: 'rounded'
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
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ArrayCategory,
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
                                return + val + ' Units'
                            }
                        }
                    },
                    colors: ['#83E2E9', '#619FFC', '#A777C9', '#ED7DB1', '#6991A7'],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    title: {
                        text: 'On-Going',
                        floating: true,
                        offsetY: 330,
                        align: 'center',
                        style: {
                            color: '#444'
                        }
                    }
                };
                var chart = new ApexCharts(element, options);
                chart.render();
            });
            jQuery(function ($) {
                var element = document.getElementById('year_line_chart');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                var baseColor = KTUtil.getCssVariableValue('--bs-success');
                var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');

                const ArrayYearCategory = ltrlYearLineCategory.split(",");
                const ArrayCOCValueData = ltrlYearLineCOCValueData.split(",");
                const ArrayPMDValueData = ltrlYearLinePMDValueData.split(",");

                if (!element) {
                    return;
                }

                var options = {
                    series: [{
                        name: 'COC',
                        data: ArrayCOCValueData
                    }, {
                        name: 'PMD',
                        data: ArrayPMDValueData
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'line',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var Year = config.w.globals.categoryLabels[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                ViewWARYearStatus(Year, Status);
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
                        curve: 'smooth'
                    },
                    xaxis: {
                        categories: ArrayYearCategory,
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
                                return val + ' Units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
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
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
            });
            jQuery(function ($) {
                var element = document.getElementById('month_bar_chart');

                var height = parseInt(KTUtil.css(element, 'height'));
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-primary');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                const ArrayTarValueData = ltrlMonthBarTarValueData.split(",");
                const ArrayActValueData = ltrlMonthBarActValueData.split(",");
                if (!element) {
                    return;
                }
                var options = {
                    series: [{
                        name: 'Target',
                        data: ArrayTarValueData
                    }, {
                        name: 'Actual',
                        data: ArrayActValueData
                    }],
                    chart: {
                        fontFamily: 'inherit',
                        type: 'bar',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var ddlYear = document.getElementById('ContentPlaceHolder1_ddlYear');
                                var selectIndex = ddlYear.selectedIndex;
                                var Year = ddlYear.options[selectIndex].text;
                                var Month = config.w.config.xaxis.categories[config.dataPointIndex];
                                var Status = config.w.globals.seriesNames[config.seriesIndex];
                                ViewWARMonthStatus(Year, Month, Status);
                            },
                        },
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: ['70%'],
                            endingShape: 'rounded'
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
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
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
                                return + val + ' Units'
                            }
                        }
                    },
                    colors: [baseColor, secondaryColor],
                    grid: {
                        borderColor: borderColor,
                        strokeDashArray: 4,
                        yaxis: {
                            lines: {
                                show: true
                            }
                        }
                    },
                    title: {
                        text: 'Monthly Inflation in Argentina, 2002',
                        floating: true,
                        offsetY: 330,
                        align: 'center',
                        style: {
                            color: '#444'
                        }
                    }
                };
                var chart = new ApexCharts(element, options);
                chart.render();
            });
        }
        //loan data

    </script>

</asp:Content>

