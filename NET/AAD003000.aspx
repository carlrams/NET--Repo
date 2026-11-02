<%@ Page Title="Buyers Announcement" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD003000.aspx.vb" Inherits="NET.AAD003000" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="content flex-row-fluid" id="kt_content">

        <div class="toolbar py-5">
            <div class="container-xxl d-flex flex-stack flex-wrap p-0">
                <div class="page-title d-flex flex-column me-3">
                    <h1 class="d-flex text-white fw-bolder my-1 fs-3">Buyers Admin</h1>
                    <ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
                        <lis class="breadcrumb-item text-white">Announcement</lis>
                    </ul>
                </div>
                <div class="d-flex align-items-center py-3 py-md-1">
                    <a class="btn btn-bg-white btn-active-color-primary pointer" onclick="fn02Add('ADD'); return false;">Add New</a>
                </div>
            </div>
        </div>

        <div id="card01Content" class="card mb-5">
            <div class="card-header border-0 py-5">
                <div class="d-flex align-items-center">
                    <div class="symbol symbol-35px me-2">
                        <img src="Assets/media/svg/apps/AAD003000.svg" alt="" />
                    </div>
                    <div class="d-flex flex-column">
                        <h3 class="card-title align-items-start flex-column">
                            <span class="text-gray-800 fw-bolder fs-2 me-3">Announcement</span>
                            <span class="text-muted fw-bold fs-7">Admin</span>
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
                    </div>
                </div>
            </div>
            <div class="card-body pt-0 mt-0">
                <div class="table-loading" style="min-height: 62.3vh;">
                    <div id="div01Loader" class="table-loading-message">
                        Loading...
                    </div>
                    <table id="table01Record" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
                        <thead>
                            <tr class="fw-bold fs-7 text-gray-800">
							    <th class="min-w-50px w-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                <th class="min-w-150px mw-50px fw-bold border-end">Title</th>
                                <th class="min-w-150px w-14 fw-bold border-end">Created Date</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

	    <div id="mdl01View" class="modal fade" tabindex="-1" aria-modal="true" role="dialog">
		    <div class="modal-dialog modal-dialog-centered mw-650px">
			    <div class="modal-content rounded">
				    <div class="modal-header pb-0 border-0 justify-content-end">
					    <div class="btn btn-sm btn-icon btn-active-color-primary" data-bs-dismiss="modal">
						    <span class="svg-icon svg-icon-1">
							    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor"></rect>
								    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor"></rect>
							    </svg>
						    </span>
					    </div>
				    </div>
				    <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">
					    <div class="mb-13 text-center">
						    <h1 class="mb-3">Bulletin</h1>
						    <div class="text-muted fw-bold fs-5">Sales News & Updates</div>
					    </div>
					    <div class="d-flex flex-column mb-5 fv-row fv-plugins-icon-container">
						    <label class="d-flex align-items-center fs-6 fw-bold mb-2">
							    <span class="me-3">Title :</span> <span id="spn02Title" class="fw-normal"></span>
						    </label>
					    </div>
					    <div class="d-flex flex-column mb-5 fv-row fv-plugins-icon-container">
						    <label class="d-flex align-items-center fs-6 fw-bold mb-2">
							    <span class="me-3">Created :</span> <span id="spn02Date" class="fw-normal"></span>
						    </label>
					    </div>
					    <div class="d-flex flex-column">
						    <label class="fs-6 fw-bold mb-2">Details :</label>
						    <div id="div02Content">
							
						    </div>
					    </div>
				    </div>
			    </div>
		    </div>
	    </div>

        <div id="mdl01Compose" data-bs-focus="false" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable mw-1000px" role="document" data-bs-focus="false">
                <div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Compose Announcement</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
                    <div class="modal-body">
		                <div class="card">
			                <div class="card-body p-0">
				                <div class="d-block">
					                <div class="border-bottom mb-2">
						                <input class="form-control form-control-transparent border-0 px-8 min-h-45px" id="compose_title" placeholder="Title" />
					                </div>
					                <textarea id="compose_message" name="compose_message" class="bg-transparent border-0 h-350px px-8 form-control" placeholder="Write your announcement message here..."></textarea>
				                </div>
			                </div>
		                </div>
                    </div>
                    <div class="modal-footer">
						<span id="btn02Submit" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1 d-none" onclick="fn02Submit(this); return false;">
							<span class="indicator-label">Submit</span>
							<span class="indicator-progress">Please wait...<span class="spinner-border spinner-border-sm align-middle ms-2"></span>
							</span>
						</span>
						<span id="btn02Edit" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1 d-none" onclick="fn02Edit_Ok(this); return false;">
							<span class="indicator-label">Update</span>
							<span class="indicator-progress">Please wait...<span class="spinner-border spinner-border-sm align-middle ms-2"></span>
							</span>
						</span>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <input id="hdnID" type="hidden" value="" />

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tinymce/8.1.2/tinymce.min.js"></script>
    <script type="text/javascript" src="Assets/js/AAD/AAD003000.js"></script>
	<script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
