<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002014.aspx.vb" Inherits="NET.AAD002014" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Account Inquiry - Account Diary</li>
					</ul>
				</div>
			</div>
		</div>
		
        <div class="card">
		    <div class="card-header">
				<div class="d-flex align-items-center">
					<div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Account Inquiry - Account Diary</span>
						</h3>
					</div>
				</div>
            </div>
			<div class="border-bottom border-gray-200 px-4 py-3">
				<div class="d-flex flex-stack">
					<div class="d-flex">
						<button id="btn02Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-2" title="Refresh" onclick="fn02Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
					</div>
				</div>
			</div>
			<div class="card-body">
				<div class="row g-2">
					<div class="col-sm-12 col-md-12 col-lg-9">
						<div class="row g-2">
							<div class="col-sm-12 col-md-12 col-lg-5">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Account</span>
									<span id="lbl02AcctNo" class="form-control">-</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-7">
								<span id="lbl02AcctName" class="form-control form-control-sm">-</span>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-5">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Project</span>
									<span id="lbl02Project" class="form-control text-truncate">-</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-7">
								<span id="lbl02ModelName" class="form-control form-control-sm">-</span>
							</div>
						</div>
					</div>
					<div class="col-sm-12 col-md-12 col-lg-3">
						<div class="row g-2">
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Status</span>
									<span id="lbl02Status" class="form-control">-</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Balance</span>
									<span id="lbl02Balance" class="form-control">-</span>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="border-bottom border-top border-gray-200 px-4 py-3">
				<div class="d-flex flex-stack">
					<div class="d-flex">
						<button id="btn0102Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0102Setup();return false;"><i id="i0102Edit" class="las la-pencil-alt fs-2"></i></button>
					</div>
					<div class="position-relative">
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
            <div class="card-body">
                <div class="input-group input-group-sm mb-3">
                    <span class="input-group-text min-w-150px">Seller</span>
                    <span id="lbl02SellerName" class="form-control">-</span>
                </div>
                <div class="table-responsive">
                    <table id="tbl02Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                        <thead>
                            <tr>
                                <th class="min-w-250px mw-250px fw-bold border-end">Realty</th>
                                <th class="min-w-50px mw-50px fw-bold border-end">Group</th>
                                <th class="min-w-50px mw-50px fw-bold border-end">Type</th>
                                <th class="min-w-275px mw-275px fw-bold border-end">Seller</th>
                                <th class="min-w-50px mw-50px fw-bold border-end">LO</th>
                                <th class="min-w-50px mw-50px fw-bold border-end">HL</th>
                                <th class="min-w-50px mw-50px fw-bold border-end">WT</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
		</div>
        
        <!--begin::Modal Setup-->
        <div id="mdl0102Setup" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Account Inquiry - Seller</h5>
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
                        
                         <div class="card-body">

						    <div class="table-loading">
							    <div id="div0102LoaderSetup" class="table-loading-message">
								    Loading...
							    </div>
				            <table id="table0102Setup" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
					            <thead>
						            <tr class="fw-bold fs-7 text-gray-800">
							            <th class="min-w-50px mw-200px fw-bold border-end">Type</th>
							            <th class="min-w-200px mw-200px fw-bold border-end">Realty</th>
							            <th class="min-w-200px mw-200px fw-bold border-end">Group</th>
							            <th class="min-w-200px mw-200px fw-bold border-end">Seller</th>
							            <th class="min-w-50px mw-50px fw-bold border-end">LO Comm_</th>
							            <th class="min-w-50px mw-50px fw-bold">HL Comm_</th>
						            </tr>
					            </thead>
					            <tbody>

					            </tbody>
				            </table>
					        </div>
					    </div>

					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0102Setup" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="saveSellerSetup(); return false;">
                            <span class="indicator-label">
                                Save
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">

                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
        <!--begin::Modal Setup -->

    </div>
    <!--content-->
    
	<!--param-->
    <input id="hdn02IDPrev" type="hidden" value="" />
	<input id="hdn02ID" type="hidden" value="" />
	<input id="hdn02Mode" type="hidden" value="DTL" />
	<input id="hdn02Trxno" type="hidden" value="DTL" />

	<input id="hdn03IDPrev" type="hidden" value="" />
    <input id="hdn03ID" type="hidden" value="" />
	<input id="hdn03Mode" type="hidden" value="" />
	<input id="hdn03Trxno" type="hidden" value="" />
	<!--param-->
	
    <script src="Assets/js/AAD/AAD002014.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
