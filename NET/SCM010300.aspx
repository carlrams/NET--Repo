<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM010300.aspx.vb" Inherits="NET.SCM010300" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white opacity-75">Supply Chain Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Overview</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Projects with 95% POC Rate</li>
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

        <div class="card-body">
			
			<!--begin::Row-->
			<div class="row gy-5 g-xl-8">
				<div class="col-xl-3">
					<!--begin::Statistics Widget 5-->
					<a href="SCM010100" class="card bg-body bgi-no-repeat hoverable card-xl-stretch mb-xl-8" style="background-position: right top; background-size: 30% auto; background-image: url(assets/media/svg/shapes/SCM010100.svg);">
						<!--begin::Body-->
						<div class="card-body">
							<!--begin::Svg Icon | path: icons/duotune/general/gen032.svg-->
							<span class="svg-icon svg-icon-primary svg-icon-3x ms-n1">
								<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
									<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
										<rect x="0" y="0" width="24" height="24"/>
										<path d="M8,3 L8,3.5 C8,4.32842712 8.67157288,5 9.5,5 L14.5,5 C15.3284271,5 16,4.32842712 16,3.5 L16,3 L18,3 C19.1045695,3 20,3.8954305 20,5 L20,21 C20,22.1045695 19.1045695,23 18,23 L6,23 C4.8954305,23 4,22.1045695 4,21 L4,5 C4,3.8954305 4.8954305,3 6,3 L8,3 Z" fill="currentColor" opacity="0.3"/>
										<path d="M11,2 C11,1.44771525 11.4477153,1 12,1 C12.5522847,1 13,1.44771525 13,2 L14.5,2 C14.7761424,2 15,2.22385763 15,2.5 L15,3.5 C15,3.77614237 14.7761424,4 14.5,4 L9.5,4 C9.22385763,4 9,3.77614237 9,3.5 L9,2.5 C9,2.22385763 9.22385763,2 9.5,2 L11,2 Z" fill="#000000"/>
										<rect fill="currentColor" opacity="0.3" x="7" y="10" width="5" height="2" rx="1"/>
										<rect fill="currentColor" opacity="0.3" x="7" y="14" width="9" height="2" rx="1"/>
									</g>
								</svg>
							</span>
							<!--end::Svg Icon-->
							<div id="divForAward" runat="server" class="text-gray-900 fw-bolder fs-2 mb-2 mt-5">0</div>
							<div class="fw-bold text-gray-400">For Award Projects</div>
						</div>
						<!--end::Body-->
					</a>
					<!--end::Statistics Widget 5-->
				</div>
				<div class="col-xl-3">
					<!--begin::Statistics Widget 5-->
					<a href="SCM010200" class="card bg-success bgi-no-repeat hoverable card-xl-stretch mb-xl-8" style="background-position: right top; background-size: 30% auto; background-image: url(assets/media/svg/shapes/SCM010200.svg);">
						<!--begin::Body-->
						<div class="card-body">
							<!--begin::Svg Icon | path: icons/duotune/finance/fin006.svg-->
							<span class="svg-icon svg-icon-white svg-icon-3x ms-n1">
								<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
									<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
										<rect x="0" y="0" width="24" height="24"/>
										<path d="M8,3 L8,3.5 C8,4.32842712 8.67157288,5 9.5,5 L14.5,5 C15.3284271,5 16,4.32842712 16,3.5 L16,3 L18,3 C19.1045695,3 20,3.8954305 20,5 L20,21 C20,22.1045695 19.1045695,23 18,23 L6,23 C4.8954305,23 4,22.1045695 4,21 L4,5 C4,3.8954305 4.8954305,3 6,3 L8,3 Z" fill="currentColor" opacity="0.3"/>
										<path d="M10.875,15.75 C10.6354167,15.75 10.3958333,15.6541667 10.2041667,15.4625 L8.2875,13.5458333 C7.90416667,13.1625 7.90416667,12.5875 8.2875,12.2041667 C8.67083333,11.8208333 9.29375,11.8208333 9.62916667,12.2041667 L10.875,13.45 L14.0375,10.2875 C14.4208333,9.90416667 14.9958333,9.90416667 15.3791667,10.2875 C15.7625,10.6708333 15.7625,11.2458333 15.3791667,11.6291667 L11.5458333,15.4625 C11.3541667,15.6541667 11.1145833,15.75 10.875,15.75 Z" fill="currentColor"/>
										<path d="M11,2 C11,1.44771525 11.4477153,1 12,1 C12.5522847,1 13,1.44771525 13,2 L14.5,2 C14.7761424,2 15,2.22385763 15,2.5 L15,3.5 C15,3.77614237 14.7761424,4 14.5,4 L9.5,4 C9.22385763,4 9,3.77614237 9,3.5 L9,2.5 C9,2.22385763 9.22385763,2 9.5,2 L11,2 Z" fill="currentColor"/>
									</g>
								</svg>
							</span>
							<!--end::Svg Icon-->
							<div id="divAwardedProj" runat="server" class="text-white fw-bolder fs-2 mb-2 mt-5">0</div>
							<div class="fw-bold text-white">Awarded Projects</div>
						</div>
						<!--end::Body-->
					</a>
					<!--end::Statistics Widget 5-->
				</div>
				<div class="col-xl-3">
					<!--begin::Statistics Widget 5-->
					<a href="SCM010300" class="card bg-info bgi-no-repeat hoverable card-xl-stretch mb-xl-8" style="background-position: right top; background-size: 30% auto; background-image: url(assets/media/svg/shapes/SCM010300.svg);">
						<!--begin::Body-->
						<div class="card-body">
							<!--begin::Svg Icon | path: icons/duotune/ecommerce/ecm008.svg-->
							<span class="svg-icon svg-icon-gray-100 svg-icon-3x ms-n1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path opacity="0.3" d="M18 21.6C16.3 21.6 15 20.3 15 18.6V2.50001C15 2.20001 14.6 1.99996 14.3 2.19996L13 3.59999L11.7 2.3C11.3 1.9 10.7 1.9 10.3 2.3L9 3.59999L7.70001 2.3C7.30001 1.9 6.69999 1.9 6.29999 2.3L5 3.59999L3.70001 2.3C3.50001 2.1 3 2.20001 3 3.50001V18.6C3 20.3 4.3 21.6 6 21.6H18Z" fill="currentColor" />
									<path d="M12 12.6H11C10.4 12.6 10 12.2 10 11.6C10 11 10.4 10.6 11 10.6H12C12.6 10.6 13 11 13 11.6C13 12.2 12.6 12.6 12 12.6ZM9 11.6C9 11 8.6 10.6 8 10.6H6C5.4 10.6 5 11 5 11.6C5 12.2 5.4 12.6 6 12.6H8C8.6 12.6 9 12.2 9 11.6ZM9 7.59998C9 6.99998 8.6 6.59998 8 6.59998H6C5.4 6.59998 5 6.99998 5 7.59998C5 8.19998 5.4 8.59998 6 8.59998H8C8.6 8.59998 9 8.19998 9 7.59998ZM13 7.59998C13 6.99998 12.6 6.59998 12 6.59998H11C10.4 6.59998 10 6.99998 10 7.59998C10 8.19998 10.4 8.59998 11 8.59998H12C12.6 8.59998 13 8.19998 13 7.59998ZM13 15.6C13 15 12.6 14.6 12 14.6H10C9.4 14.6 9 15 9 15.6C9 16.2 9.4 16.6 10 16.6H12C12.6 16.6 13 16.2 13 15.6Z" fill="currentColor" />
									<path d="M15 18.6C15 20.3 16.3 21.6 18 21.6C19.7 21.6 21 20.3 21 18.6V12.5C21 12.2 20.6 12 20.3 12.2L19 13.6L17.7 12.3C17.3 11.9 16.7 11.9 16.3 12.3L15 13.6V18.6Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
							<div id="divWithBalance" runat="server" class="text-gray-100 fw-bolder fs-2 mb-2 mt-5">0</div>
							<div class="fw-bold text-gray-100">Projects with 95% POC Rate</div>
						</div>
						<!--end::Body-->
					</a>
					<!--end::Statistics Widget 5-->
				</div>
				<div class="col-xl-3">
					<!--begin::Statistics Widget 5-->
					<a href="SCM010400" class="card bg-danger bgi-no-repeat hoverable hoverable card-xl-stretch mb-5 mb-xl-8" style="background-position: right top; background-size: 30% auto; background-image: url(assets/media/svg/shapes/SCM010400.svg);">
						<!--begin::Body-->
						<div class="card-body">
							<!--begin::Svg Icon | path: icons/duotune/graphs/gra007.svg-->
							<span class="svg-icon svg-icon-white svg-icon-3x ms-n1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<path opacity="0.3" d="M10.9607 12.9128H18.8607C19.4607 12.9128 19.9607 13.4128 19.8607 14.0128C19.2607 19.0128 14.4607 22.7128 9.26068 21.7128C5.66068 21.0128 2.86071 18.2128 2.16071 14.6128C1.16071 9.31284 4.96069 4.61281 9.86069 4.01281C10.4607 3.91281 10.9607 4.41281 10.9607 5.01281V12.9128Z" fill="currentColor" />
									<path d="M12.9607 10.9128V3.01281C12.9607 2.41281 13.4607 1.91281 14.0607 2.01281C16.0607 2.21281 17.8607 3.11284 19.2607 4.61284C20.6607 6.01284 21.5607 7.91285 21.8607 9.81285C21.9607 10.4129 21.4607 10.9128 20.8607 10.9128H12.9607Z" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
							<div id="divCancelledProj" runat="server" class="text-white fw-bolder fs-2 mb-2 mt-5">0</div>
							<div class="fw-bold text-white">Cancelled Projects</div>
						</div>
						<!--end::Body-->
					</a>
					<!--end::Statistics Widget 5-->
				</div>
			</div>
			<!--end::Row-->
			
			<!--begin::Toolbar-->
			<div class="d-flex flex-wrap flex-stack pt-10 pb-8">
				<div class="d-flex justify-content-start">
					<h2 class="text-muted">Project with Billing Balance</h2>
				</div>
				<!--begin::Controls-->
				<div class="d-flex flex-wrap my-1">
					<!--begin::Tab nav-->
					<ul class="nav nav-pills me-5">
						<li class="nav-item m-0">
							<a class="btn btn-sm btn-icon btn-light btn-color-muted btn-active-secondary active me-3" data-bs-toggle="tab" data-bs-placement="top" title="Project" href="#MNU_TabContent01">
								<!--begin::Svg Icon | path: icons/duotune/abstract/abs015.svg-->
								<span class="svg-icon svg-icon-2">
									<svg version='1.1' id='Capa_1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px'
											viewBox='0 0 350 350' style='enable-background:new 0 0 350 350;' xml:space='preserve'>
									<g id='XMLID_1088_'>
										<rect id='XMLID_1089_' x='55' y='30' style='fill:#FFDA44;' width='240' height='320'/>
										<rect id='XMLID_1090_' x='175' y='130' style='fill:#FFFFFF;' width='90' height='30'/>
										<circle id='XMLID_1091_' style='fill:#006DF0;' cx='175' cy='30' r='30'/>
										<path id='XMLID_1092_' style='fill:#0052B4;' d='M175,60c-16.568,0-30-13.432-30-30s13.432-30,30-30'/>
										<rect id='XMLID_1093_' x='105' y='30' style='fill:#0052B4;' width='70' height='50'/>
										<rect id='XMLID_1094_' x='175' y='30' style='fill:#006DF0;' width='70' height='50'/>
										<polyline id='XMLID_1095_' style='fill:none;stroke:#FF9811;stroke-width:30;stroke-miterlimit:10;' points='85,140 105,160 
											145,120 	'/>
										<rect id='XMLID_1096_' x='175' y='200' style='fill:#FFFFFF;' width='90' height='30'/>
										<polyline id='XMLID_1097_' style='fill:none;stroke:#FF9811;stroke-width:30;stroke-miterlimit:10;' points='85,210 105,230 
											145,190 	'/>
										<rect id='XMLID_1098_' x='175' y='270' style='fill:#FFFFFF;' width='90' height='30'/>
										<polyline id='XMLID_1099_' style='fill:none;stroke:#FF9811;stroke-width:30;stroke-miterlimit:10;' points='85,280 105,300 
											145,260 	'/>
									</g>
									</svg>
								</span>
								<!--end::Svg Icon-->
							</a>
						</li>
						<li class="nav-item m-0">
							<a class="btn btn-sm btn-icon btn-light btn-color-muted btn-active-secondary" data-bs-toggle="tab" data-bs-placement="top" title="Batch" href="#MNU_TabContent02">
								<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
								<span class="svg-icon svg-icon-1">
									<svg width="800px" height="800px" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
									<path fill-rule="evenodd" clip-rule="evenodd" d="M8.04582 10.8715C8.52718 10.6007 8.6979 9.99103 8.42713 9.50967C8.15637 9.02831 7.54665 8.85759 7.0653 9.12836L3.50974 11.1284C3.18725 11.3098 2.99128 11.6544 3.0003 12.0243C3.00931 12.3942 3.22184 12.7289 3.55279 12.8944L5.63258 13.9343L3.50974 15.1284C3.18725 15.3098 2.99128 15.6544 3.0003 16.0243C3.00931 16.3942 3.22184 16.7289 3.55279 16.8944L11.5528 20.8944C11.8343 21.0351 12.1657 21.0351 12.4472 20.8944L20.4472 16.8944C20.7782 16.7289 20.9907 16.3942 20.9997 16.0243C21.0087 15.6544 20.8128 15.3098 20.4903 15.1284L18.3674 13.9343L20.4472 12.8944C20.7782 12.7289 20.9907 12.3942 20.9997 12.0243C21.0087 11.6544 20.8128 11.3098 20.4903 11.1284L16.9347 9.12836C16.4533 8.85759 15.8436 9.02831 15.5729 9.50967C15.3021 9.99103 15.4728 10.6007 15.9542 10.8715L17.8679 11.948L12 14.8819L6.13213 11.948L8.04582 10.8715ZM16.2077 15.0141L12.4472 16.8944C12.1657 17.0351 11.8343 17.0351 11.5528 16.8944L7.7923 15.0141L6.13213 15.948L12 18.8819L17.8679 15.948L16.2077 15.0141Z" fill="#152C70"/>
									<path d="M12.4472 3.10557C12.1657 2.96481 11.8343 2.96481 11.5528 3.10557L3.55279 7.10557C3.214 7.27496 3 7.62123 3 8C3 8.37877 3.214 8.72504 3.55279 8.89443L11.5528 12.8944C11.8343 13.0352 12.1657 13.0352 12.4472 12.8944L20.4472 8.89443C20.786 8.72504 21 8.37877 21 8C21 7.62123 20.786 7.27496 20.4472 7.10557L12.4472 3.10557Z" fill="#4296FF"/>
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
			
            <div class="tab-content">
				
                <div class="tab-pane fade show active" id="MNU_TabContent01">
					
					<div class="card" id="projectEmpty" runat="server" style="display: none;">
						<div class="card-body">
							<div class="card-px text-center pt-15 pb-15">
								<h2 class="fs-2x fw-bolder mb-0">No Data.</h2>
							</div>
							<div class="text-center pb-15 px-5">
								<img src="assets/media/illustrations/sigma-1/10.jpg" alt="" class="mw-100 h-200px h-sm-325px" />
							</div>
						</div>
					</div>

					<div class="row g-6 mb-6 g-xl-9 mb-xl-9" id="ProjectContainer" runat="server">

					</div>

                </div>

                <div class="tab-pane fade" id="MNU_TabContent02">

					<div class="card" id="batchEmpty" runat="server" style="display: none;">
						<div class="card-body">
							<div class="card-px text-center pt-15 pb-15">
								<h2 class="fs-2x fw-bolder mb-0">No Data.</h2>
							</div>
							<div class="text-center pb-15 px-5">
								<img src="assets/media/illustrations/sigma-1/10.jpg" alt="" class="mw-100 h-200px h-sm-325px" />
							</div>
						</div>
					</div>

					<div class="row g-6 mb-6 g-xl-9 mb-xl-9" id="BatchContainer" runat="server">

					</div>

                </div>

            </div>

        </div>

		
		<!--begin::Modal Find -->
		<asp:UpdatePanel ID="mdl01Project" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Project
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
                                <input id="tbx01Project" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" onkeyup="Search_Project()" />
							</div>
							<!--end::Search-->
							
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div class="table-responsive" style="overflow-x:auto; scrollbar-width: thin; max-height: 750px; overflow-y: scroll;">
						    <!--begin::list-->
                            <table id="gv01Project" class="table table-no-border table-row-bordered table-hover align-middle w-100">
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
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Find-->
		
		<!--begin::Modal Find -->
		<asp:UpdatePanel ID="mdl01Batch" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Batch
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
                                <input id="tbx01Batch" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" onkeyup="Search_Batch()" />
							</div>
							<!--end::Search-->
							
						</div>
						<!--end::toolbar-->
					</div>
					<div class="modal-body pt-0">
						<div class="table-responsive" style="overflow-x:auto; scrollbar-width: thin; max-height: 750px; overflow-y: scroll;">
						    <!--begin::list-->
                            <table id="gv01Batch" class="table table-no-border table-row-bordered table-hover align-middle w-100">
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
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Find-->

    </div>
	
    <script type="text/javascript">

        //view sort by subdivision - Project
        function SortedProject(Subd) {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'FormCode': "SCM010300",
                    'Type': "Form Details (Project)",
                    'Subd': Subd
                },
                success: function (response) {
                    DisplayProject(response);
                    //modal
                    $("#ContentPlaceHolder1_mdl01Project").modal("show");
                    //modal
                },
                error: function (xhr, status, error) {
                    console.error("Error fetching Project Data", error);
                }
            });
        };
        function DisplayProject(response) {
            var gv01Project = document.getElementById("gv01Project");

            //Remove all rows.
            var rowCount = gv01Project.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                gv01Project.deleteRow(i);
            }

            //Add the data rows.
            for (var i = 0; i < response.length; i++) {
                row = gv01Project.insertRow(-1);

                var cell = row.insertCell(-1);
                cell.innerHTML = response[i].Bullet;
                cell.setAttribute("class", "mw-5px min-w-5px");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Data;
                cell.setAttribute("class", "w-100");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Tag;
            }
        };

        //view sort by subdivision - Batch
        function SortedBatch(Subd) {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'FormCode': "SCM010200",
                    'Type': "Form Details (Batch)",
                    'Subd': Subd
                },
                success: function (response) {
                    DisplayBatch(response);
                    //modal
                    $("#ContentPlaceHolder1_mdl01Batch").modal("show");
                    //modal
                },
                error: function (xhr, status, error) {
                    console.error("Error fetching Batch Data", error);
                }
            });
        };
        function DisplayBatch(response) {
            var gv01Batch = document.getElementById("gv01Batch");

            //Remove all rows.
            var rowCount = gv01Batch.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                gv01Batch.deleteRow(i);
            }

            //Add the data rows.
            for (var i = 0; i < response.length; i++) {
                row = gv01Batch.insertRow(-1);

                var cell = row.insertCell(-1);
                cell.innerHTML = response[i].Bullet;
                cell.setAttribute("class", "mw-5px min-w-5px");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Data;
                cell.setAttribute("class", "w-100");

                cell = row.insertCell(-1);
                cell.innerHTML = response[i].Tag;
            }
        };

        //search - Project
        function Search_Project() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("tbx01Project");
            filter = input.value.toUpperCase();
            table = document.getElementById("gv01Project");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        };

        //search - Batch
        function Search_Batch() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("tbx01Batch");
            filter = input.value.toUpperCase();
            table = document.getElementById("gv01Batch");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        };

        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {

		}
    </script>

</asp:Content>
