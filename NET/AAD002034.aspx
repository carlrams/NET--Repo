<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002034.aspx.vb" Inherits="NET.AAD002034" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Account Inquiry - Tools - House Turnover Schedule</li>
					</ul>
				</div>
			</div>
		</div>
		
        <div class="card">
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/AAD002000.svg" alt="" />
					</div>
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn02Title">-</span></h2>
						<div class="text-muted fw-bolder">
							<span id="spn02Status">-</span>
						</div>
					</div>
				</div>
			</div>
			<div class="border-bottom border-gray-200 px-4 py-3">
				<div class="d-flex flex-stack">
					<div class="d-flex ms-3">
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
					<div class="d-flex ms-3">
						<button id="btn03Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn03Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
						<span class="bullet h-25px w-2px bg-secondary mt-2 m-1"></span>
						<button id="btn03Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1 d-none" title="Remove" onclick="fn03Delete();return false;"><i class="las la-trash fs-2"></i></button>
						<button id="btn03Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn03Edit();return false;"><i id="i03Edit" class="las la-pencil-alt fs-2"></i></button>
					</div>
				</div>
			</div>
			<div class="card-body">
                <div id="div03Detail" class="row g-2 mb-2"  style="display:none">
					<div class="col-sm-12 col-md-12 col-lg-12">
						<div class="input-group input-group-sm">
							<span class="input-group-text min-w-150px">TO Date</span>
							<span id="lbl03TODate" class="form-control">-</span>
						</div>
					</div>
                </div>
                <div id="div03Update" class="row g-2 mb-2">
					<div class="col-sm-12 col-md-12 col-lg-12">
						<div class="input-group input-group-sm">
							<span class="input-group-text min-w-150px required">TO Date</span>
							<input id="tbx03TODate" type="text" class="form-control" data-kt-repeater="datepicker" Placeholder="Date"  readonly="readonly" />
						</div>
					</div>
                </div>
				<div class="col-sm-12 col-md-12 col-lg-12">
					<div class="input-group input-group-sm">
						<span class="input-group-text min-w-150px">Time</span>
						<input id="tbx03Time" type="text" class="form-control" data-kt-repeater="timepicker" Placeholder="Time" readonly="readonly" />
					</div>
				</div>
			</div>
            <div class="card-footer d-flex justify-content-center">
                <a href="#" id="btn03Send" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn03Send(); return false;">
                    Send
                </a>
            </div>
		</div>
        
    </div>
	
	<!--param-->
    <input id="hdn02IDPrev" type="hidden" value="" />
	<input id="hdn02ID" type="hidden" value="" />
	<input id="hdn02Mode" type="hidden" value="DTL" />

	<input id="hdn03IDPrev" type="hidden" value="" />
    <input id="hdn03ID" type="hidden" value="" />
	<input id="hdn03Mode" type="hidden" value="" />
	<!--param-->
	
    <script src="Assets/js/AAD/AAD002034.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
