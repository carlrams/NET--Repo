<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002000.aspx.vb" Inherits="NET.AAD002000" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<div class="content flex-row-fluid" id="kt_content">

		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Account Inquiry</li>
					</ul>
				</div>
			</div>
		</div>

		<div class="card">
			<div class="card-header card-header-stretch border-bottom border-gray-200">
				<div class="card-title">
					<h3 class="fw-bolder m-0">Account Inquiry</h3>
				</div>
			</div>
			<div class="border-bottom border-gray-200 px-4 py-3">
				<div class="d-flex flex-stack">
					<div class="d-flex">
						<button type="button" class="btn btn-sm btn-icon btn-info me-2" title="Filter" onclick="fn02Filter();return false;"><i class="las la-filter fs-3"></i></button>
						<button type="button" class="btn btn-sm btn-icon btn-info me-2" title="Refresh record" onclick="fn02Refresh();return false;"><i class="las la-redo-alt fs-3"></i></button>
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
								<th class="min-w-50px mw-50px border-end text-center" style="padding-right:10px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
								<td class="min-w-100px mw-100px border-end">Acct. No.</td>
								<td class="min-w-250px mw-250px border-end">Acct. Name</td>
								<td class="min-w-150px mw-150px">Project</td>
								<td class="min-w-100px mw-100px border-end text-start">DOE</td>
								<td class="min-w-75px mw-75px border-end">Paid</td>
								<td class="min-w-75px mw-75px border-end text-truncate"><span title="Cancelled">Cancelled</span></td>
								<td class="min-w-75px mw-75px border-end text-truncate"><span title="Transferred">Transferred</span></td>
								<td class="w-100"></td>
							</tr>
						</thead>
						<tbody class="text-gray-600">

						</tbody>
					</table>
				</div>
			</div>
		</div>
	
		<div id="mdl0201Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Filter record</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
						<div class="row g-2">
							<div class="col-sm-12 col-md-12 col-lg-4">
								<input id="tbx0201AcctNo" class="form-control form-control-sm" Placeholder="Acct. No." maxlength="13" />
							</div>
							<div class="col-sm-12 col-md-12 col-lg-8">
								<input id="tbx0201AcctName" class="form-control form-control-sm" Placeholder="Acct. Name" maxlength="180" />
							</div>
							<div class="col-sm-12 col-md-12 col-lg-3">
								<input id="tbx0201Subd" class="form-control form-control-sm" Placeholder="Subd." maxlength="60" />
							</div>
							<div class="col-sm-12 col-md-12 col-lg-3">
								<input id="tbx0201Phase" class="form-control form-control-sm" Placeholder="Phase" maxlength="60" />
							</div>
							<div class="col-sm-12 col-md-12 col-lg-3">
								<input id="tbx0201Block" class="form-control form-control-sm" Placeholder="Block" maxlength="60" />
							</div>
							<div class="col-sm-12 col-md-12 col-lg-3">
								<input id="tbx0201Lot" class="form-control form-control-sm" Placeholder="Lot" maxlength="60" />
							</div>
							<div class="col-sm-12 col-md-12 col-lg-6">
								<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
									<input id="tbx0201DOEFrom" type="text" class="form-control form-control-sm m-0" data-kt-repeater="datepicker" readonly Placeholder="DOE From" maxlength="20" />
									<a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0201DOEFrom');return false;">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
											<rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
										</svg>
									</a>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-6">
								<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
									<input id="tbx0201DOETo" type="text" class="form-control form-control-sm m-0" data-kt-repeater="datepicker" readonly Placeholder="DOE To" maxlength="20" />
									<a class="svg-icon svg-icon-2 position-absolute pointer end-5px text-hover-danger" title="Clear" onclick="fnClearTime('tbx0201DOETo');return false;">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="7.05025" y="15.5356" width="12" height="2" rx="1" transform="rotate(-45 7.05025 15.5356)" fill="currentColor"/>
											<rect x="8.46447" y="7.05029" width="12" height="2" rx="1" transform="rotate(45 8.46447 7.05029)" fill="currentColor"/>
										</svg>
									</a>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-4">
								<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
									<input id="cbx0201Paid" class="form-check-input" type="checkbox" value=""/>
									<label class="form-check-label" for="cbx0201Paid">
										Paid
									</label>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-4">
								<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
									<input id="cbx0201Cancelled" class="form-check-input" type="checkbox" value=""/>
									<label class="form-check-label" for="cbx0201Cancelled">
										Cancelled
									</label>
								</div>
							</div>
							<div class="col-sm-12 col-md-12 col-lg-4">
								<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
									<input id="cbx0201Transferred" class="form-check-input" type="checkbox" value=""/>
									<label class="form-check-label" for="cbx0201Transferred">
										Transferred
									</label>
								</div>
							</div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<div class="d-flex flex-center flex-row-fluid">
							<button id="" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0201Filter_Ok(this);return false;">
								<span class="indicator-label">
									Filter
								</span>
								<span class="indicator-progress">
									Loading
								</span>
							</button>
							<button class="btn btn-sm btn-light-danger min-w-100px" onclick="$('#mdl0201Filter').modal('hide');return false;">
								Cancel
							</button>
						</div>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</div>

	</div>
    
	<!--param-->
	<input id="hdn0201AcctNo" type="hidden" value="" />
	<input id="hdn0201AcctName" type="hidden" value="" />
	<input id="hdn0201Subd" type="hidden" value="" />
	<input id="hdn0201Phase" type="hidden" value="" />
	<input id="hdn0201Block" type="hidden" value="" />
	<input id="hdn0201Lot" type="hidden" value="" />
	<input id="hdn0201DOEFrom" type="hidden" value="" />
	<input id="hdn0201DOETo" type="hidden" value="" />
	<input id="hdn0201Paid" class="d-none" type="checkbox" />
	<input id="hdn0201Cancelled" class="d-none" type="checkbox" />
	<input id="hdn0201Transferred" class="d-none" type="checkbox" />
	<!--param-->

    <script src="Assets/js/AAD/AAD002000.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
