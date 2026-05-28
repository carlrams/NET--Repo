<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB100100.aspx.vb" Inherits="NET.DSB100100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
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
						<li class="breadcrumb-item text-white">Supply Chain Management</li>
						<!--end::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<li class="breadcrumb-item text-white">Purchase Monitoring</li>
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</div>
		
		<div class="row g-5 g-xl-8">
			<!--begin::Col-->
			<div class="col-xl-4">
				<!--begin::Mixed Widget 1-->
				<div class="card card-xl-stretch mb-xl-8">
					<!--begin::Body-->
					<div class="card-body p-0">
						<!--begin::Header-->
						<div class="px-9 pt-7 card-rounded h-275px w-100 bg-dark">
							<!--begin::Heading-->
							<div class="d-flex flex-stack">
								<h3 class="m-0 text-white fw-bolder fs-3">Purchase Order</h3>
							</div>
							<!--end::Heading-->
							<!--begin::Balance-->
							<div class="d-flex text-center flex-column text-white pt-8">
								<span class="fw-bold fs-7">YTD Overall PO's</span>
								<span id="spn01Overall" class="fw-bolder fs-2x pt-1">0</span>
							</div>
							<!--end::Balance-->
						</div>
						<!--end::Header-->
						<!--begin::Items-->
						<div class="bg-body shadow-sm card-rounded mx-9 mb-9 px-6 py-9 position-relative z-index-1 scroll h-350px px-5" style="margin-top: -100px">
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-primary fw-bolder">Delivered</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Delivered" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-primary fw-bolder">Prtl. Dlvrd.</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Partial" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-primary fw-bolder">Processed</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Processed" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-primary fw-bolder">for Printing</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Print" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-primary fw-bolder">for Posting</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Post" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-primary fw-bolder">for Locking</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Lock" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center mb-6">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-danger fw-bolder">Cancelled</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01Cancelled" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
							<!--begin::Item-->
							<div class="d-flex align-items-center">
								<!--begin::Symbol-->
								<div class="symbol symbol-45px w-40px me-5">
									<span class="symbol-label bg-lighten">
										<!--begin::Svg Icon | path: icons/duotune/general/gen005.svg-->
										<span class="svg-icon svg-icon-1">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22ZM12.5 18C12.5 17.4 12.6 17.5 12 17.5H8.5C7.9 17.5 8 17.4 8 18C8 18.6 7.9 18.5 8.5 18.5L12 18C12.6 18 12.5 18.6 12.5 18ZM16.5 13C16.5 12.4 16.6 12.5 16 12.5H8.5C7.9 12.5 8 12.4 8 13C8 13.6 7.9 13.5 8.5 13.5H15.5C16.1 13.5 16.5 13.6 16.5 13ZM12.5 8C12.5 7.4 12.6 7.5 12 7.5H8C7.4 7.5 7.5 7.4 7.5 8C7.5 8.6 7.4 8.5 8 8.5H12C12.6 8.5 12.5 8.6 12.5 8Z" fill="currentColor" />
												<rect x="7" y="17" width="6" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="12" width="10" height="2" rx="1" fill="currentColor" />
												<rect x="7" y="7" width="6" height="2" rx="1" fill="currentColor" />
												<path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</span>
								</div>
								<!--end::Symbol-->
								<!--begin::Description-->
								<div class="d-flex align-items-center flex-wrap w-100">
									<!--begin::Title-->
									<div class="mb-1 pe-3 flex-grow-1">
										<a href="#" class="fs-5 text-gray-800 text-hover-info fw-bolder">New</a>
										<div class="text-gray-400 fw-bold fs-7">PO's</div>
									</div>
									<!--end::Title-->
									<!--begin::Label-->
									<div class="d-flex align-items-center">
										<div id="div01New" class="fw-bolder fs-5 text-gray-800 pe-1">0</div>
									</div>
									<!--end::Label-->
								</div>
								<!--end::Description-->
							</div>
							<!--end::Item-->
						</div>
						<!--end::Items-->
					</div>
					<!--end::Body-->
				</div>
				<!--end::Mixed Widget 1-->
			</div>
			<!--end::Col-->
            <div class="col-xl-8">
				<div class="card card-xl-stretch mb-xl-8">
					<div class="card-body">
						<h3 class="m-0 fw-bold fs-3">Top Overall Suppliers</h3>
						<div id="kt_vendor_chart"></div>
					</div>
				</div>
            </div>
		</div>
		
		<div class="row g-5 g-xl-8">
			<div class="col-xl-4">
				<!--begin::Statistics Widget 3-->
				<div class="card card-xl-stretch mb-xl-8">
					<!--begin::Body-->
					<div class="card-body d-flex flex-column p-0">
						<div class="d-flex flex-stack flex-grow-1 card-p">
							<div class="d-flex flex-column me-2">
								<a href="#" class="text-dark text-hover-primary fw-bolder fs-3">Cost of Purchase Order</a>
								<span class="text-muted fw-bold mt-1">Monthly Monitoring</span>
							</div>
							<span class="symbol symbol-50px">
								<span class="symbol-label fs-5 fw-bolder bg-light-success text-success">+100</span>
							</span>
						</div>
						<div class="kt_cost_purchase_chart card-rounded-bottom" data-kt-chart-color="success" style="height: 150px"></div>
					</div>
					<!--end::Body-->
				</div>
				<!--end::Statistics Widget 3-->
			</div>
			<div class="col-xl-4">
				<!--begin::Statistics Widget 3-->
				<div class="card card-xl-stretch mb-xl-8">
					<!--begin::Body-->
					<div class="card-body d-flex flex-column p-0">
						<div class="d-flex flex-stack flex-grow-1 card-p">
							<div class="d-flex flex-column me-2">
								<a href="#" class="text-dark text-hover-primary fw-bolder fs-3">Discount of Purchase Order</a>
								<span class="text-muted fw-bold mt-1">Monthly Monitoring</span>
							</div>
							<span class="symbol symbol-50px">
								<span class="symbol-label fs-5 fw-bolder bg-light-danger text-danger">-260</span>
							</span>
						</div>
						<div class="kt_disc_purchase_chart card-rounded-bottom" data-kt-chart-color="danger" style="height: 150px"></div>
					</div>
					<!--end::Body-->
				</div>
				<!--end::Statistics Widget 3-->
			</div>
			<div class="col-xl-4">
				<!--begin::Statistics Widget 3-->
				<div class="card card-xl-stretch mb-5 mb-xl-8">
					<!--begin::Body-->
					<div class="card-body d-flex flex-column p-0">
						<div class="d-flex flex-stack flex-grow-1 card-p">
							<div class="d-flex flex-column me-2">
								<a href="#" class="text-dark text-hover-primary fw-bolder fs-3">Net Purchase Cost</a>
								<span class="text-muted fw-bold mt-1">Monthly Monitoring</span>
							</div>
							<span class="symbol symbol-50px">
								<span class="symbol-label fs-5 fw-bolder bg-light-primary text-primary">+180</span>
							</span>
						</div>
						<div class="kt_net_purchase_chart card-rounded-bottom" data-kt-chart-color="primary" style="height: 150px"></div>
					</div>
					<!--end::Body-->
				</div>
				<!--end::Statistics Widget 3-->
			</div>
		</div>
    </div>

	<script src="https://cdn.jsdelivr.net/npm/countup.js@latest/dist/countUp.umd.js"></script>
    <script type="text/javascript">

		//variable
        var prevOverall = 0;
        var prevDelivered = 0;
        var prevPartial = 0;
        var prevProcessed = 0;
        var prevPrint = 0;
        var prevPost = 0;
        var prevLock = 0;
        var prevCancel = 0;
        var prevNew = 0;
		//variable

        // noConflict
		var jQry = jQuery.noConflict();

		// Initials
        function getInitials(name) {
            return name
                .split(' ')
                .filter(w => w.length > 0)
                .map(w => w[0].toUpperCase())
                .join('');
        }
		// Initials

        function pageLoad(sender, args) { InitialiseSettings(); };
        function InitialiseSettings() {

            jQuery(function ($) {

                var chatHub = jQry.connection.chatHub;

                chatHub.client.updatePurchaseOrder = function () {
                    loadPurchaseOrder();
                    loadSuppliers();
                };

                // Start connection
                jQry.connection.hub.start().done(function () {
                    // Initial load
					loadPurchaseOrder();
                    loadSuppliers();
					loadCostPurchase();
					loadDiscountPurchase();
                }).fail(function (error) {
                    console.error("SignalR connection failed: " + error);
                });

                // Function to load data
				function loadPurchaseOrder() {
                    chatHub.server.getPurchaseOrder()
						.then(function (data) {
							var newOverall = data[0].Overall;
							var newDelivered = data[0].Delivered;
							var newPartial = data[0].Partial;
							var newProcessed = data[0].Processed;
							var newPrint = data[0].Print;
							var newPost = data[0].Post;
							var newLock = data[0].Lock;
							var newCancelled = data[0].Cancelled;
							var newTotal = data[0].New;

							//overall
                            const overAll = new countUp.CountUp(document.getElementById("spn01Overall"), newOverall, {
                                startVal: prevOverall,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overAll.error) {
                                overAll.start();
							};

							//deliver
                            const overDelivered = new countUp.CountUp(document.getElementById("div01Delivered"), newDelivered, {
                                startVal: prevDelivered,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overDelivered.error) {
                                overDelivered.start();
                            };

                            //partial
                            const overPartial = new countUp.CountUp(document.getElementById("div01Partial"), newPartial, {
                                startVal: prevPartial,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overPartial.error) {
                                overPartial.start();
                            };

                            //processed
                            const overProcessed = new countUp.CountUp(document.getElementById("div01Processed"), newProcessed, {
                                startVal: prevProcessed,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overProcessed.error) {
                                overProcessed.start();
                            };

                            //print
                            const overPrint = new countUp.CountUp(document.getElementById("div01Print"), newPrint, {
                                startVal: prevPrint,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overPrint.error) {
                                overPrint.start();
                            };

                            //post
                            const overPost = new countUp.CountUp(document.getElementById("div01Post"), newPost, {
                                startVal: prevPost,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overPost.error) {
                                overPost.start();
                            };

                            //lock
                            const overLock = new countUp.CountUp(document.getElementById("div01Lock"), newLock, {
                                startVal: prevLock,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overLock.error) {
                                overLock.start();
							};

                            //cancel
                            const overCancel = new countUp.CountUp(document.getElementById("div01Cancelled"), newCancelled, {
                                startVal: prevCancel,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overCancel.error) {
                                overCancel.start();
							};

                            //cancel
                            const overNew = new countUp.CountUp(document.getElementById("div01New"), newTotal, {
                                startVal: prevNew,
                                decimalPlaces: 0,
                                duration: 3,
                                useGrouping: true,
                                separator: ',',
                                decimal: '.',
                                prefix: '',
                                suffix: ''
                            });
                            if (!overNew.error) {
                                overNew.start();
                            };

							prevOverall = newOverall;
							prevDelivered = newDelivered;
							prevPartial = newPartial;
							prevProcessed = newProcessed;
							prevPrint = newPrint;
							prevPost = newPost;
							prevLock = newLock;
							prevCancel = newCancelled;
							prevNew = newTotal;
                        })

                        .catch(function (error) {
                            console.error("Error loading Purchase Order:", error);
                        });
                }

                // Arrays
                var SupplierList = [];
                var SupplierTotal = [];
                var SupplierFullName = [];

                // Apex chart instance
                var supplierChart = null;

                // Load suppliers
                function loadSuppliers() {

                    chatHub.server.getOverallSuppliers()
                        .then(function (data) {
                            // CLEAR arrays (IMPORTANT)
                            SupplierList = [];
                            SupplierTotal = [];
                            SupplierFullName = [];

                            data.forEach(function (list) {
                                SupplierList.push(getInitials(list.Vendor));
                                SupplierFullName.push(list.Vendor);
                                SupplierTotal.push(list.Total);
                            });

                            // First time → create chart
                            if (supplierChart === null) {
                                var chartElement = document.querySelector("#kt_vendor_chart");

                                if (!chartElement) {
                                    return
                                };

                                var options = {
                                    series: [{
                                        name: 'Posted PO(s)',
                                        data: SupplierTotal
                                    }],
                                    chart: {
                                        type: 'bar',
                                        height: 475
                                    },
                                    plotOptions: {
                                        bar: {
                                            horizontal: false,
                                            columnWidth: '70%',
                                            borderRadius: 5,
                                            borderRadiusApplication: 'end'
                                        }
                                    },
                                    dataLabels: {
                                        enabled: false
                                    },
                                    yaxis: {
                                        labels: {
                                            formatter: function (val) {
                                                return val.toLocaleString();
                                            }
                                        }
                                    },
                                    xaxis: {
                                        categories: SupplierList
                                    },
                                    fill: {
                                        opacity: 1
                                    },
                                    tooltip: {
                                        x: {
                                            formatter: function (val, opts) {
                                                return SupplierFullName[opts.dataPointIndex];
                                            }
                                        }
                                    }
                                };

                                supplierChart = new ApexCharts(
                                    chartElement,
                                    options
                                );

                                supplierChart.render();

                            } else {
                                // Real-time update (NO re-render)
                                supplierChart.updateOptions({
                                    xaxis: { categories: SupplierList }
                                });

                                supplierChart.updateSeries([{
                                    data: SupplierTotal
                                }]);
                            }

                        })
                        .catch(function (error) {
                            console.error("Error loading Suppliers:", error);
                        });
                }

                // Apex chart instance
                var costPurchaseChart = null;

                // Data arrays
                var costMonth = [];
                var costVal = [];
				var costTotal = [];

                function loadCostPurchase() {

                    chatHub.server.getCostPurchase()
                        .then(function (data) {

                            // CLEAR arrays
                            costMonth = [];
							costVal = [];
							costTotal = [];

                            data.forEach(function (list) {
                                costMonth.push(list.MonthName);
								costVal.push(list.Cost);
								costTotal.push(list.TotalPO);
                            });

                            var chartElement = document.querySelector(".kt_cost_purchase_chart");
                            if (!chartElement) return;

                            // First time → CREATE chart
                            if (costPurchaseChart === null) {

                                var height = parseInt(KTUtil.css(chartElement, 'height'));
                                var color = chartElement.getAttribute('data-kt-chart-color');

                                var labelColor = KTUtil.getCssVariableValue('--bs-gray-800');
                                var baseColor = KTUtil.getCssVariableValue('--bs-' + color);
								var lightColor = KTUtil.getCssVariableValue('--bs-light-' + color);

								var MonTotal = costMonth.map(function (month, index) {
									return month + " (" + costTotal[index].toLocaleString() + ")";
								});

                                var options = {
                                    series: [{
                                        name: 'Cost Purchase',
                                        data: costVal
                                    }],
                                    chart: {
                                        fontFamily: 'inherit',
                                        type: 'area',
                                        height: height,
                                        toolbar: { show: false },
                                        zoom: { enabled: false },
                                        sparkline: { enabled: true }
                                    },
                                    dataLabels: { enabled: false },
                                    fill: { type: 'solid', opacity: 0.3 },
                                    stroke: {
                                        curve: 'smooth',
                                        width: 3,
                                        colors: [baseColor]
                                    },
                                    xaxis: {
                                        categories: MonTotal,
                                        labels: { show: false }
                                    },
                                    yaxis: {
                                        labels: { show: false }
                                    },
                                    tooltip: {
                                        y: {
                                            formatter: function (val) {
                                                return "₱" + val.toLocaleString() + " Cost";
                                            }
                                        }
                                    },
                                    colors: [baseColor],
                                    markers: {
                                        colors: [baseColor],
                                        strokeColor: [lightColor],
                                        strokeWidth: 3
                                    }
                                };

                                costPurchaseChart = new ApexCharts(chartElement, options);
                                costPurchaseChart.render();

                            } else {
                                // Real-time UPDATE only (NO re-render)
                                costPurchaseChart.updateOptions({
                                    xaxis: { categories: costMonth }
                                }, false, true);

                                costPurchaseChart.updateSeries([{
                                    data: costVal
                                }], true);
                            }

                        })
                        .catch(function (error) {
                            console.error("Error loading Cost Purchase:", error);
                        });
				}

				// Apex chart instance
				var discountPurchaseChart = null;

				// Data arrays
				var discMonth = [];
				var discVal = [];
				var discTotal = [];

				function loadDiscountPurchase() {

                    chatHub.server.getDiscountPurchase()
                        .then(function (data) {

                            // CLEAR arrays
                            discMonth = [];
                            discVal = [];
                            discTotal = [];

                            data.forEach(function (list) {
                                discMonth.push(list.MonthName);
                                discVal.push(list.Cost);
                                discTotal.push(list.TotalPO);
                            });

                            var chartElement = document.querySelector(".kt_disc_purchase_chart");
                            if (!chartElement) return;

                            // First time → CREATE chart
                            if (discountPurchaseChart === null) {

                                var height = parseInt(KTUtil.css(chartElement, 'height'));
                                var color = chartElement.getAttribute('data-kt-chart-color');

                                var labelColor = KTUtil.getCssVariableValue('--bs-gray-800');
                                var baseColor = KTUtil.getCssVariableValue('--bs-' + color);
                                var lightColor = KTUtil.getCssVariableValue('--bs-light-' + color);

                                var MonTotal = discMonth.map(function (month, index) {
                                    return month + " (" + discTotal[index].toLocaleString() + ")";
                                });

                                var options = {
                                    series: [{
                                        name: 'Discount Purchase',
                                        data: discVal
                                    }],
                                    chart: {
                                        fontFamily: 'inherit',
                                        type: 'area',
                                        height: height,
                                        toolbar: { show: false },
                                        zoom: { enabled: false },
                                        sparkline: { enabled: true }
                                    },
                                    dataLabels: { enabled: false },
                                    fill: { type: 'solid', opacity: 0.3 },
                                    stroke: {
                                        curve: 'smooth',
                                        width: 3,
                                        colors: [baseColor]
                                    },
                                    xaxis: {
                                        categories: MonTotal,
                                        labels: { show: false }
                                    },
                                    yaxis: {
                                        labels: { show: false }
                                    },
                                    tooltip: {
                                        y: {
                                            formatter: function (val) {
                                                return "₱" + val.toLocaleString() + " Discount";
                                            }
                                        }
                                    },
                                    colors: [baseColor],
                                    markers: {
                                        colors: [baseColor],
                                        strokeColor: [lightColor],
                                        strokeWidth: 3
                                    }
                                };

                                discountPurchaseChart = new ApexCharts(chartElement, options);
                                discountPurchaseChart.render();

                            } else {
                                // Real-time UPDATE only (NO re-render)
                                discountPurchaseChart.updateOptions({
                                    xaxis: { categories: costMonth }
                                }, false, true);

                                discountPurchaseChart.updateSeries([{
                                    data: costVal
                                }], true);
                            }

                        })
                        .catch(function (error) {
                            console.error("Error loading Cost Purchase:", error);
                        });
				};

			});

        }

    </script> 

</asp:Content>
