<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002013.aspx.vb" Inherits="NET.AAD002013" %>
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
						<button id="btn02Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn02Add();return false;"><i class="las la-plus fs-2"></i></button>
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
							    <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                <th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Reminder"><i class="bi bi-calendar-check fs-3"></i></span></th>
                                <th class="min-w-200px mw-200px fw-bold border-end">Type</th>
                                <th class="min-w-200px mw-200px text-start fw-bold border-end">Date</th>
                                <th class="min-w-500px w-100 fw-bold">Note</th>   
						    </tr>
						</thead>
						<tbody>

						</tbody>
					</table>
				</div>
			</div>
		</div>
        
		<div id="mdl03View" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-800px">
				<div class="modal-content">
					<div class="modal-header">
                        <div class="d-flex flex-column">
				            <h2 class="mb-1"><span id="spn03Title">-</span></h2>
				            <div class="text-muted fw-bolder">
					            <span id="spn03Status">-</span>
				            </div>
                        </div>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="border-bottom border-gray-200 px-4 py-3">
						<div class="d-flex flex-stack">
							<div class="d-flex">
								<button id="btn03Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn03Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
								<span class="bullet h-25px w-2px bg-secondary mt-2 m-1"></span>
								<button id="btn03Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn03Add();return false;"><i class="las la-plus fs-2"></i></button>
								<button id="btn03Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn03Delete();return false;"><i class="las la-trash fs-2"></i></button>
								<button id="btn03Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn03Edit();return false;"><i id="i03Edit" class="las la-pencil-alt fs-2"></i></button>
							</div>
						</div>
					</div>
					<div class="modal-body">
                        <div id="div03Detail" class="row g-2 mb-2"  style="display:none">
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Type</span>
									<span id="lbl03Type" class="form-control">-</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text w-100">
										<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm" style="margin-right: 5px;">
											<input class="form-check-input" type="checkbox" value="" id="cbx03Reminder01" onclick="return false;" style="pointer-events: none;" />
										</div>
										is Reminder
									</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Date</span>
									<span id="lbl03DateNote" class="form-control">-</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Notes</span>
									<span id="lbl03Notes" class="form-control">-</span>
								</div>
							</div>
                        </div>
                        <div id="div03Update" class="row g-2 mb-2">
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px required">Type
									</span>
									<select id="ddl03Type" data-kt-repeater="select2" data-dropdown-parent="#mdl03View" class="form-select form-select-sm form-select-border min-h-38px">
									</select>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span class="input-group-text w-100">
										<div class="form-check form-check-custom checkbox checkbox-outline checkbox-success form-check-sm" style="margin-right: 5px;">
											<input class="form-check-input" type="checkbox" value="" id="cbx03Reminder02" />
										</div>
										<label class="form-check-label" for="cbx03Reminder02">
											Is Reminder
										</label>
									</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span id="spn03DateNote" class="input-group-text min-w-150px required">Date</span>
									<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
										<input id="tbx03DateNote" type="text" class="form-control form-control-sm border-0 m-0" data-kt-repeater="datepicker" readonly Placeholder="Date" maxlength="20" />
										<a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fn01ClearTime('tbx03DateNote');return false;">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
												<rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
											</svg>
										</a>
									</div>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-12">
								<div class="input-group input-group-sm">
									<span id="spn03Notes" class="input-group-text min-w-150px required">Notes</span>
									<input id="tbx03Notes" type="text" class="form-control" Placeholder="Notes" maxlength="8000"  />
								</div>
							</div>
                        </div>
						<div class="card-title fs-5 fw-bolder ms-2">Prepared By</div>
						<div class="row g-2">
							<div class="col-sm-12 col-md-12 col-lg-6">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Updated By</span>
									<span id="lbl03UpdatedByName" class="form-control">-</span>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-6">
								<div class="input-group input-group-sm">
									<span class="input-group-text min-w-150px">Date</span>
									<span id="lbl03UpdatedDate" class="form-control">-</span>
								</div>
							</div>
						</div>
					</div>
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
	<input id="hdn03Trxno" type="hidden" value="" />
	<!--param-->
	
    <script src="Assets/js/AAD/AAD002013.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>