<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC030200.aspx.vb" Inherits="NET.ACC030200" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link href="https://unpkg.com/tabulator-tables@5.5.2/dist/css/tabulator_bootstrap5.min.css" rel="stylesheet">
    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Cost Control Monitoring</li>
					</ul>
				</div>
			</div>
		</div>
		
        <div class="card mb-5">
		    <div class="card-header border-0">
				<div class="d-flex align-items-center">
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/ACC030200.svg" alt="" />
					</div>
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Cost Control Monitoring</span>
						</h3>
					</div>
				</div>
            </div>
            <div class="card">
                <div class="card-body pt-3 pb-0">
                    <div class="d-flex flex-stack">
                        <div class="d-flex overflow-auto">
                            <ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
                                <li class="nav-item m-0">
                                    <a class="nav-link text-active-primary active" title="House Construction" data-bs-toggle="tab" href="#tab020101"><i class="bi bi-house-door fs-3x"></i></a>
                                </li>
                                <li class="nav-item m-0">
                                    <a class="nav-link text-active-primary" title="Others" data-bs-toggle="tab" href="#tab030101"><i class="las la-file-alt fs-3x"></i></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="tab-content">
                        <div class="tab-pane fade show active" id="tab020101">
                            <div class="card">
                                <div class="card-header">
                                    <div class="card-title fs-3 fw-bolder">House Construction</div>

                                    <div class="d-flex align-items-center gap-2">
                                        <button type="button" class="btn btn-sm btn-light-success me-2" onclick="exportAllToExcel01();">
                                            <i class="las la-file-excel fs-4 me-1"></i>Export Excel
                                        </button>
                                        <div class="position-relative me-2">
                                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                                </svg>
                                            </span>
                                            <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                    </div>
                                </div>

                                <div class="card-body pt-0 mt-0">
                                    <div class="table-loading" style="min-height: 62.3vh;">
                                        <div id="table01Record">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="tab030101">
                            <div class="card">
                                <div class="card-header">
                                    <div class="card-title fs-3 fw-bolder">Others</div>
                                    <div class="d-flex align-items-center gap-2">
                                        <button type="button" class="btn btn-sm btn-light-success me-2" onclick="exportAllToExcel02();">
                                            <i class="las la-file-excel fs-4 me-1"></i>Export Excel
                                        </button>   
                                        <div class="position-relative me-2">
                                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                                </svg>
                                            </span>
                                            <input id="tbx02Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                    </div>
                                </div>

                                <div class="card-body pt-0 mt-0">
                                    <div class="table-loading" style="min-height: 62.3vh;">
                                        <div id="table02Record">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
			
		</div>
    </div>

	<script src="https://unpkg.com/tabulator-tables@5.5.2/dist/js/tabulator.min.js"></script>
    <script src="https://oss.sheetjs.com/sheetjs/xlsx.full.min.js"></script>
	<script src="Assets/js/ACC/ACC030200.js"></script>

</asp:Content>
