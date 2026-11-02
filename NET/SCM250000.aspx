<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM250000.aspx.vb" Inherits="NET.SCM250000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Classification Masterlist</li>
					</ul>
				</div>
				<div class="d-flex align-items-center py-3 py-md-1">
					<a class="btn btn-bg-white pointer" onclick="fn01Add();return false;">Add New</a>
				</div>
			</div>
		</div>
		
        <div id="card01Content" class="card mb-5">
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/SCM250000.svg" alt="Classification" />
					</div>
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Classification Masterlist</span>
						</h3>
					</div>
				</div>
			    <div class="card-toolbar">
                    <div class="d-flex flex-stack">
					    <div class="position-relative me-2">
						    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
							    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
								    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
							    </svg>
						    </span>
						    <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
					    </div>
                        <div id="div01ExportButton" class="d-none"></div>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
                           <i class="las la-bars fs-3"></i>
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-150px py-4" data-kt-menu="true">
				            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                            </div>
                        </div>
                    </div>
			    </div>
            </div>
			<div class="card-body pt-0 mt-0">
                <div class="table-loading" style="min-height:62.3vh;">
                    <div id="div01Loader" class="table-loading-message">
                        Loading...
                    </div>
                    <table id="table01Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					    <thead>
						    <tr class="fw-bold fs-7 text-gray-800">
							    <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-lock fs-3'></i></span></th>
                                <th class="min-w-150px w-100 fw-bold border-end">Description</th>
						    </tr>
					    </thead>
					    <tbody>
							
					    </tbody>
				    </table>
                </div>
            </div>
		</div>
        
    </div>
	
	<script type="text/javascript" src="Assets/js/SCM/SCM250000.js"></script>

</asp:Content>
