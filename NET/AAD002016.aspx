<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002016.aspx.vb" Inherits="NET.AAD002016" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="content flex-row-fluid" id="kt_content">
        <div>
            <style>
		.input-lineTest {
			 font-family: inherit;
			 font-size: 12px;
			 border: 1px solid #ccc;  
			 border-radius: 4px;
			 padding: 6px 8px;
			 background-color: white;
			 color: #333;
			 min-height: 23px;
		 }

		 .input-lineTest:focus {
			 border-color: #007bff;
			 background-color: #eef7ff;
		 }
            </style>
        </div>
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Account Inquiry - Buyers Folder</li>
					</ul>
				</div>
			</div>
		</div>
		
        <div class="card">
		    <div class="card-header">
				<div class="d-flex align-items-center">
					<div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Account Inquiry - Buyers Folder - Documents</span>
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
						   <div class="d-flex gap-2">
                            <button type="button" id="editTableBtn"
                                class="btn btn-sm btn-icon btn-warning"
                                style="width: 32px; height: 32px;" onclick="makeTableEditable();" title="Edit Branch">
                                <i class="las la-pencil-alt fs-2"></i>
                            </button>
                            <button type="button" id="cancelTableBtn"
                                class="btn btn-sm btn-icon btn-danger"
                                style="width: 32px; height: 32px; display: none;" onclick="CancelTableChanges();" title="Cancel Edit">
                                <i class="las la-trash fs-2"></i>
                            </button>
                            <button type="button" id="saveTableBtn"
                                class="btn btn-sm btn-icon btn-warning"
                                style="width: 32px; height: 32px; display: none;" onclick="confirmSaveTableChanges();" title="Save Edit">
                                <i class="las la-save fs-2"></i>
                            </button>
                        </div>
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
                <div class="table-responsive">
                    <table id="tbl02Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                        <thead>
                            <tr>
								<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Received"><i class="bi bi-check-circle fs-3"></i></span></th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Type</th>
                                <th class="min-w-250px mw-250px fw-bold border-end">Document</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Doc. No.</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Doc. Date</th>
                                <th class="min-w-100px mw-100px fw-bold border-end text-start">Expr. Date</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Rcvd. By</th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Rcvd. Date</th>
                                <th class="min-w-250px mw-250px fw-bold border-end">Remarks</th>
                            </tr>
                        </thead>
                        <tbody id="gv01FormBody">
                        </tbody>
                    </table>
                </div>
            </div>
		</div>
        

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
	<!--param-->
	
    <script src="Assets/js/AAD/AAD002016.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
