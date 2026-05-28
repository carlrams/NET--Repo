<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM020100.aspx.vb" Inherits="NET.SCM020100" MaintainScrollPositionOnPostback = "true" %>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Account</h1>
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
						<li class="breadcrumb-item text-white opacity-75">Details</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->


        <div class="d-flex flex-column flex-lg-row">
			<div class="d-flex flex-column gap-7 gap-lg-10 w-100 w-lg-300px mb-7 me-lg-10">
				<div class="card card-flush py-4">
					<div class="card-header">
						<div class="card-title">
							<h2>Profile</h2>
						</div>
					</div>
					<div class="card-body text-center pt-0">
						<div class="image-input image-input-empty image-input-outline mb-3" data-kt-image-input="true" style="">
							<div class="image-input-wrapper w-150px h-150px" style="background-image: url(Assets/media/avatars/blank.png)"></div>
						</div>
					</div>
				</div>

				<asp:UpdatePanel ID="upnlStatus" runat="server" UpdateMode="Conditional" class="card card-flush py-4">
					<ContentTemplate>
						<div class="card-header">
							<div class="card-title">
								<h2>Status</h2>
							</div>
							<div class="card-toolbar">
								<div id="div0101Status" class=""></div>
							</div>
						</div>
						<div class="card-body pt-0">
							<input id="tbx0101Status" type="text" class="form-control mb-1 fs-8" readonly/>
							<div class="text-muted fs-7">Account status.</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>

			</div>
			<div class="d-flex flex-column flex-row-fluid gap-7 gap-lg-10">
				<!--begin:::Tabs-->
				<ul class="nav nav-custom nav-tabs nav-line-tabs nav-line-tabs-2x border-0 fs-4 fw-bold mb-n2">
					<!--begin:::Tab item-->
					<li class="nav-item">
						<a class="nav-link text-active-primary pb-4 active" data-bs-toggle="tab" href="#MNU_TabContent01">General</a>
					</li>
					<!--end:::Tab item-->
					<!--begin:::Tab item-->
					<li class="nav-item">
						<a class="nav-link text-active-primary pb-4" data-bs-toggle="tab" href="#MNU_TabContent02">Uploaded Files</a>
					</li>
					<!--end:::Tab item-->
				</ul>
				<!--end:::Tabs-->
				<!--begin::Tab content-->
				<div class="tab-content">
					<!--begin::Tab pane-->
					<div class="tab-pane fade show active" id="MNU_TabContent01" role="tab-panel">
						<div class="d-flex flex-column gap-7 gap-lg-10">
							<div class="card card-flush py-4">
							<div class="d-flex flex-wrap justify-content-end m-5">
								<button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
								<span class="bullet h-30px w-2px bg-secondary mt-2"></span>
								<button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1 d-none" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
								<button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit Record" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
								<span class="bullet h-30px w-2px bg-secondary mt-2"></span>
								<button id="btn0101Status" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Change Status" onclick="fn0101Status();return false;"><i class="las la-flag fs-2"></i></button>
								<button id="btn0101Upload" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Upload File" onclick="fn0101Upload();return false;"><i class="las la-file-import fs-2"></i></button>
							</div>
								<div class="card-header">
									<div class="card-title">
										<h2>General Information</h2>
									</div>
								</div>
                                <div id="div0101Detail">
									<div class="card-body pt-0 pb-0">
										<div class="fv-row">
											<label class="form-label fs-7">Name</label>
											<input id="lbl0101Name" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Email</label>
											<input id="lbl0101Email" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Contact Person</label>
											<input id="lbl0101ContactPerson" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Type</label>
											<input id="lbl0101Type" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Address</label>
											<textarea id="lbl0101Address" class="form-control mb-1 fs-8" rows="4" readonly></textarea>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Tel. No.</label>
											<input id="lbl0101TelNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Mobile No.</label>
											<input id="lbl0101MobileNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Fax No.</label>
											<input id="lbl0101FaxNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Tin No.</label>
											<input id="lbl0101TinNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
									</div>
									<div class="card-header border-0">
										<div class="card-title">
											<h2>Payment Information</h2>
										</div>
									</div>
									<div class="card-body pt-0 pb-0">
										<div class="fv-row">
											<label class="form-label fs-7">VAT</label>
											<input id="lbl0101VAT" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">EWT</label>
											<input id="lbl0101EWT" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Credit Terms</label>
											<input id="lbl0101CreditTerms" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
									</div>
									<div class="card-header border-0">
										<div class="card-title">
											<h2>Bank Information</h2>
										</div>
									</div>
									<div class="card-body pt-0">
										<div class="fv-row">
											<label class="form-label fs-7">Payment Type</label>
											<input id="lbl0101PaymentType" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Bank</label>
											<input id="lbl0101Bank" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Acct. No.</label>
											<input id="lbl0101AcctNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Acct. Name</label>
											<input id="lbl0101AcctName" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
									</div>
                                </div>
                                <div id="div0101Update">
									<div class="card-body pt-0 pb-0">
										<div class="fv-row">
											<label class="form-label fs-7">Name</label>
											<input id="tbx0101Name" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Email</label>
											<input id="tbx0101Email" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Contact Person</label>
											<input id="tbx0101ContactPerson" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Type</label>
											<input id="tbx0101Type" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Address</label>
											<textarea id="tbx0101Address" class="form-control mb-1 fs-8" rows="4" readonly></textarea>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Tel. No.</label>
											<input id="tbx0101TelNo" type="text" class="form-control mb-1 fs-8" maxlength="20" />
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Mobile No.</label>
											<input id="tbx0101MobileNo" type="text" class="form-control mb-1 fs-8" maxlength="20" />
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Fax No.</label>
											<input id="tbx0101FaxNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Tin No.</label>
											<input id="tbx0101TinNo" type="text" class="form-control mb-1 fs-8" readonly/>
										</div>
									</div>
									<div class="card-header border-0">
										<div class="card-title">
											<h2>Payment Information</h2>
										</div>
									</div>
									<div class="card-body pt-0 pb-0">
										<div class="fv-row">
											<label class="form-label fs-7">VAT</label>
											<select id="ddl0101VAT" data-kt-repeater="select2" class="form-select form-select-sm border border-danger">
												<option value="">VAT</option>
											</select>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">EWT</label>
											<select id="ddl0101EWT" data-kt-repeater="select2" class="form-select form-select-sm border border-danger">
												<option value="">EWT</option>
											</select>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Credit Terms</label>
											<select id="ddl0101CreditTerms" data-kt-repeater="select2" class="form-select form-select-sm border-danger">
												<option value="">Credit Terms</option>
											</select>
										</div>
									</div>
									<div class="card-header border-0">
										<div class="card-title">
											<h2>Bank Information</h2>
										</div>
									</div>
									<div class="card-body pt-0">
										<div class="fv-row">
											<label class="form-label fs-7">Payment Type</label>
											<select id="ddl0101PaymentType" data-kt-repeater="select2" class="form-select form-select-sm" onchange="ddl0101PaymentType_onchange(this);">
												<option value="">Payment Type</option>
												<option value="For Pick-Up">For Pick-Up</option>
												<option value="Bank Deposit">Bank Deposit</option>
											</select>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Bank</label>
											<input id="tbx0101Bank" type="text" class="form-control mb-1 fs-8 border" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Acct. No.</label>
											<input id="tbx0101AcctNo" type="text" class="form-control mb-1 fs-8 border" readonly/>
										</div>
										<div class="fv-row">
											<label class="form-label fs-7">Acct. Name</label>
											<input id="tbx0101AcctName" type="text" class="form-control mb-1 fs-8 border" readonly/>
										</div>
									</div>
                                </div>
							</div>
						</div>
					</div>
					<!--end::Tab pane-->
					<!--begin::Tab pane-->
					<div class="tab-pane fade" id="MNU_TabContent02" role="tab-panel">
                        <div class="d-flex flex-column gap-7 gap-lg-10">
                            <div class="card card-flush py-4">
								<div class="card-header">
									<div class="card-title">
										<h2>Attachments</h2>
									</div>
								</div>
								<div class="card-body table-loading table-responsive">
									<div id="div0201LoaderAttachment" class="table-loading-message">
										Loading...
									</div>
									<table id="table0201Attachment" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
										<thead>
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-60px mw-60px fw-bold border-end">Type</th>
												<th class="min-w-200px w-100 fw-bold">Name</th>
												<th class="min-w-200px mw-200px fw-bold">Status</th>
												<th class="min-w-200px mw-200px fw-bold">Uploaded Date</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
								</div>
                            </div>
                        </div>
					</div>
					<!--end::Tab pane-->
				</div>
				<!--end::Tab content--> 
			</div>
        </div>

		<!--begin::Modal Dialog Box-->
		<div id="mdl0101Status" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
	        <div class="modal-dialog modal-dialog-centered mw-650px">
	            <div class="modal-content">
					<div class="modal-header">
                        <h5 class="modal-title">Update Account - Status</h5>
                        <div class="d-flex align-items-center">
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
					</div>
					<div class="modal-body">
						<select id="ddl0101Status" data-kt-repeater="select2" class="form-select form-select-sm min-h-38px border border-danger">
							<option value="">Status</option>
							<option value="Approved">Approved</option>
							<option value="Declined">Declined</option>
							<option value="For Resubmission">For Resubmission</option>
						</select>
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-primary fw-bolder min-w-100px" onclick="fn0101Update_Ok(this); return false;">
                             <span class="indicator-label">Save</span>
                             <span class='indicator-progress'>Saving</span>
                         </a>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
                    <!--end::Actions-->
				</div>
			</div>
		</div>
		<!--begin::Modal Dialog Box-->
		
		<!--begin::Modal Upload-->
		<div id="mdl0201Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
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
						<!--begin::Dropzone-->
						<div class="dropzone mb-5" id="DropZone01">
							<!--begin::Message-->
							<div class="dz-message needsclick">
								<!--begin::Icon-->
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<!--end::Icon-->
								<!--begin::Info-->
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
								<!--end::Info-->
							</div>
						</div>
						<!--end::Dropzone-->
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0201Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
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
		<!--begin::Modal Upload-->
	
		<!--begin::Modal Upload-->
		<div id="mdl0202Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
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
						<!--begin::Dropzone-->
						<div class="dropzone mb-5" id="DropZone02">
							<!--begin::Message-->
							<div class="dz-message needsclick">
								<!--begin::Icon-->
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<!--end::Icon-->
								<!--begin::Info-->
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
								<!--end::Info-->
							</div>
						</div>
                        <input id="hf02ID" runat="server" type="hidden" value="" />
                        <input id="hf02SeqNo" runat="server" type="hidden" value="" />
                        <input id="hf02FileName" runat="server" type="hidden" value="" />
						<!--end::Dropzone-->
					</div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                        <button id="btn0202Add_Ok" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
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
		<!--begin::Modal Upload-->
	
		<!--param-->
		<input id="hdnPrevID" runat="server" type="hidden" value="" />
		<input id="hdnID" runat="server" type="hidden" value="" />
		<input id="hdnMode" runat="server" type="hidden" value="" />
		<input id="hdnMention" type="hidden" value="" />
		<!--param-->
	
    </div>
	
    <script type="text/javascript">

		//variable
		var FileCount = 0;
		var myDropzone = null;
		var myDropzone01 = null;
		//variable

		//general
        function fn01Load() {
            fnAccess('SCM020000', 'View', function (response) {
                if (response[0].oReturn == "1") {
					fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    location.replace("MNU000022");
                };
            });
		};
        function fn01DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0101Refresh").classList.remove("btn-view");
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Delete").classList.remove("d-none");
                document.getElementById("btn0101Status").classList.remove("btn-add");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Upload").classList.remove("btn-view");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = pValue;
                }
            } else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Delete").classList.add("d-none");
                document.getElementById("btn0101Status").classList.add("btn-add");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Upload").classList.add("btn-view");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = pValue;
                }
            }
            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Delete").disabled = pValue;
            document.getElementById("btn0101Status").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Upload").disabled = pValue;
		};
        function fn01Toggle(button) {
            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            // Hide all other toggle menus
            document.querySelectorAll('.toggle-menu').forEach(menu => {
                if (menu !== toggleMenu) menu.classList.add('d-none');
            });

            // Toggle current menu
            if (toggleMenu) {
                const isVisible = !toggleMenu.classList.contains('d-none');
                toggleMenu.classList.toggle('d-none');

                // If now visible, add outside click listener
                if (!isVisible) {
                    const outsideClickListener = function (event) {
                        if (!wrapper.contains(event.target)) {
                            toggleMenu.classList.add('d-none');
                            document.removeEventListener('click', outsideClickListener);
                        }
                    };
                    setTimeout(() => {
                        // Allow this click to finish before listening
                        document.addEventListener('click', outsideClickListener);
                    }, 0);
                }
            }
        };
		function fn01Status(pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM020100',
                    'Type': 'Contracts Account - Get Info : Status',
                    'pID': pID
                },
				success: function (response) {
                    document.getElementById("tbx0101Status").value = response[0].AcctStatus;
					if (response[0].AcctStatus == "For Approval" || response[0].AcctStatus == "For Verification") {
						document.getElementById("div0101Status").setAttribute("class", "rounded-circle bg-info w-15px h-15px");
					} else if (response[0].AcctStatus == "For Resubmission") {
						document.getElementById("div0101Status").setAttribute("class", "rounded-circle bg-warning w-15px h-15px");
						//redirect
                        window.location.replace("SCM020200-DTL-" + pID);
					} else if (response[0].AcctStatus == "Approved") {
						document.getElementById("div0101Status").setAttribute("class", "rounded-circle bg-success w-15px h-15px");
						//redirect
						window.location.replace("SCM020300-DTL-" + pID);
					} else if (response[0].AcctStatus == "Declined") {
                        document.getElementById("div0101Status").setAttribute("class", "rounded-circle bg-danger w-15px h-15px");
                        //redirect
                        window.location.replace("SCM020400-DTL-" + pID);
					};
                },
            });
		};
		//general

        //overview
		function fn0101LoadOverview(pMode, pID) {
			if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020100',
                        'Type': 'Contracts Account - Get Info : DTL',
                        'pID': pID
                    },
					success: function (response) {

                        //toolbar
                        document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.remove("la-save");
                        fn01Status(document.getElementById("ContentPlaceHolder1_hdnID").value);
                        fn01DisableButtons(false);
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "";
						document.getElementById("div0101Update").style.display = "none";
						document.getElementById("lbl0101Name").value = response[0].Name;
						document.getElementById("lbl0101Email").value = response[0].Email;
						document.getElementById("lbl0101ContactPerson").value = response[0].Contact
						document.getElementById("lbl0101Type").value = response[0].Type;
						document.getElementById("lbl0101Address").value = response[0].Address;
						document.getElementById("lbl0101TelNo").value = response[0].TelNo;
						document.getElementById("lbl0101MobileNo").value = response[0].MobileNo;
						document.getElementById("lbl0101FaxNo").value = response[0].FaxNo;
						document.getElementById("lbl0101TinNo").value = response[0].TinNo;
						document.getElementById("lbl0101VAT").value = response[0].VAT;
						document.getElementById("lbl0101EWT").value = response[0].EWT;
						document.getElementById("lbl0101CreditTerms").value = response[0].CreditTerms;
						document.getElementById("lbl0101PaymentType").value = response[0].PaymentType;
						document.getElementById("lbl0101Bank").value = response[0].Bank;
						document.getElementById("lbl0101AcctNo").value = response[0].AcctNo;
						document.getElementById("lbl0101AcctName").value = response[0].AcctName;
                        //content

                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020100',
                        'Type': 'Contracts Account - Get Info : DTL',
                        'pID': pID
                    },
					success: function (response) {

                        //toolbar
						fn01DisableButtons(true);
                        fn01Status(document.getElementById("ContentPlaceHolder1_hdnID").value);
                        document.getElementById("btn0101Delete").classList.add("btn-delete");
                        document.getElementById("btn0101Delete").disabled = false;
                        document.getElementById("btn0101Edit").classList.add("btn-edit");
                        document.getElementById("btn0101Edit").disabled = false;
                        document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.add("la-save");
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "none";
						document.getElementById("div0101Update").style.display = "";
						document.getElementById("tbx0101Name").value = response[0].Name;
						document.getElementById("tbx0101Email").value = response[0].Email;
						document.getElementById("tbx0101ContactPerson").value = response[0].Contact;
						document.getElementById("tbx0101Type").value = response[0].Type;
						document.getElementById("tbx0101Address").value = response[0].Address;
						document.getElementById("tbx0101TelNo").value = response[0].TelNo;
						document.getElementById("tbx0101MobileNo").value = response[0].MobileNo;
						document.getElementById("tbx0101FaxNo").value = response[0].FaxNo;
						document.getElementById("tbx0101TinNo").value = response[0].TinNo;
						ddl0101VAT(response[0].VATCode);
						ddl0101EWT(response[0].EWTCode);
						ddl0101CreditTerms(response[0].CTCode);
                        $('#ddl0101PaymentType').val(response[0].PaymentType).trigger('change');
						//content

                    }
                });
            }
            function ddl0101VAT(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_VAT',
                        'pPlaceHolder': 'VAT',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101VAT").html(s);
                        $('#ddl0101VAT').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101EWT(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_EWT',
                        'pPlaceHolder': 'EWT',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101EWT").html(s);
                        $('#ddl0101EWT').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101CreditTerms(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM070100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_CreditTerms',
                        'pPlaceHolder': 'Terms',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101CreditTerms").html(s);
                        $('#ddl0101CreditTerms').val(ID).trigger('change');
                    },
                });
            };
		};
		function ddl0101PaymentType_onchange(ddl0101PaymentType) {
            document.getElementById("tbx0101Bank").readOnly = true;
            document.getElementById("tbx0101AcctNo").readOnly = true;
            document.getElementById("tbx0101AcctName").readOnly = true;
            document.getElementById("tbx0101Bank").classList.remove("border-danger");
            document.getElementById("tbx0101AcctNo").classList.remove("border-danger");
            document.getElementById("tbx0101AcctName").classList.remove("border-danger");
			document.getElementById("tbx0101Bank").value = "";
			document.getElementById("tbx0101AcctNo").value = "";
			document.getElementById("tbx0101AcctName").value = "";
			if (ddl0101PaymentType.options[ddl0101PaymentType.selectedIndex].value == "Bank Deposit") {
				document.getElementById("tbx0101Bank").readOnly = false;
				document.getElementById("tbx0101AcctNo").readOnly = false;
                document.getElementById("tbx0101AcctName").readOnly = false;

                document.getElementById("tbx0101Bank").classList.add("border-danger");
                document.getElementById("tbx0101AcctNo").classList.add("border-danger");
                document.getElementById("tbx0101AcctName").classList.add("border-danger");
			};
		};
        function fn0101Refresh() {
            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
		};
		function fn0101Delete() {
			if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "UPD") {
                Cancel_Upd_Question(document.getElementById('ContentPlaceHolder1_hdnID').value);
			};
            function Cancel_Upd_Question(ID) {
                Swal.fire({
                    text: 'Cancel changes?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    showCancelButton: true,
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    }
                });
            };
		};
		function fn0101Edit() {
			// validate
			if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exists
                fnIfExist('SCM_Contractor', 'contractor_id', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                // access
                function Access() {
                    // access
                    fnAccess('SCM020000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Edit_Dtl_Ok_Await(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exists
                fnIfExist('SCM_Contractor', 'contractor_id', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM020000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            ValidateFields(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
            }
            //validate fields
            function ValidateFields(ID) {
                if (document.getElementById("ddl0101VAT").options[document.getElementById("ddl0101VAT").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101EWT").options[document.getElementById("ddl0101EWT").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101CreditTerms").options[document.getElementById("ddl0101CreditTerms").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101PaymentType").options[document.getElementById("ddl0101PaymentType").selectedIndex].value == "Bank Deposit" && document.getElementById("tbx0101Bank").value == "" && document.getElementById("tbx0101AcctNo").value == "" && document.getElementById("tbx0101AcctName").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    Edit_Question(ID);
                }
            }
            //question
            function Edit_Question(ID) {
                Swal.fire({
                    text: 'Save record?',
                    icon: 'question',
                    iconColor: '#0095e8',
                    buttonsStyling: false,
                    showCancelButton: true,
                    confirmButtonText: "Yes",
                    cancelButtonText: 'Cancel',
                    customClass: {
                        confirmButton: 'btn btn-sm btn-info min-w-100px',
                        cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                            Edit_Dtl_Ok_Await();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                            //if exisit
                            fnIfExist('SCM_Contractor', 'contractor_id', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                                if (response[0].oReturn == "1") {
                                    Edit_Upd_Ok_Await(ID);
                                } else {
                                    window.location.replace("MNU040100");
                                };
                            });
                        }
                    }
                });
            };
            //do edit
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD";
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                // Do Update
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020100',
                        'Type': 'Contracts Account - Update Info : DTL',
                        'pID': ID,
                        'pVAT': document.getElementById("ddl0101VAT").options[document.getElementById("ddl0101VAT").selectedIndex].value,
                        'pEWT': document.getElementById("ddl0101EWT").options[document.getElementById("ddl0101EWT").selectedIndex].value,
                        'pCreditTerms': document.getElementById("ddl0101CreditTerms").options[document.getElementById("ddl0101CreditTerms").selectedIndex].value,
                        'pPmtType': document.getElementById("ddl0101PaymentType").options[document.getElementById("ddl0101PaymentType").selectedIndex].value,
                        'pBank': document.getElementById("tbx0101Bank").value,
                        'pAcctNo': document.getElementById("tbx0101AcctNo").value,
                        'pAcctName': document.getElementById("tbx0101AcctName").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
		};
		function fn0101Status() {
			if (document.getElementById("lbl0101VAT").value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
			} else if (document.getElementById("lbl0101EWT").value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
			} else if (document.getElementById("lbl0101CreditTerms").value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else if (document.getElementById("lbl0101PaymentType").value == "Bank Deposit" && document.getElementById("lbl0101Bank").value == "" && document.getElementById("lbl0101AcctNo").value == "" && document.getElementById("lbl0101AcctName").value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
			} else {
				//clear
				$('#ddl0101Status').val("").trigger('change');

				//modal
				$("#mdl0101Status").modal("show");
			};
		};
		function fn0101Update_Ok(Btn) {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = true;
            // Show loading indicator
            Btn.setAttribute('data-kt-indicator', 'on');
            //access
            fnAccess('SCM020000', 'Save', function (response) {
                if (response[0].oReturn == "1") {
					Validate();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
			});
			function Validate() {
				if (document.getElementById("ddl0101Status").options[document.getElementById("ddl0101Status").selectedIndex].value == "") {
                    // Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
				} else {
					Upd_Acc_Question(document.getElementById("ContentPlaceHolder1_hdnID").value);
				};
			};
            function Upd_Acc_Question(ID) {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': 'SCM020100',
                        'Type': 'Contracts Account - Update Info : Status',
						'pID': ID,
                        'pStatus': document.getElementById("ddl0101Status").options[document.getElementById("ddl0101Status").selectedIndex].value
                    },
					success: function (response) {
						fnAlertOnly('Account successfully updated.', 'success', 'btn btn-success');
                        //clear
						$('#ddl0101Status').val("").trigger('change');
						//load
                        fn01Status(document.getElementById("ContentPlaceHolder1_hdnID").value);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = true;
                        // Hide loading indication
						Btn.removeAttribute('data-kt-indicator');

                        //modal
                        $("#mdl0101Status").modal("hide");
                    }
                });
            };
		};
        function fn0101Upload() {
			//reset
            myDropzone01.removeAllFiles();
            FileCount = 0;
            $('#mdl0201Upload').modal('show');
		};
		//overview

		//attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM020100',
                    'Type': 'Contracts Account - Upload : Get Record',
                    'pID': pID
                },
				success: function (response) {
                    //display loader
                    document.getElementById("div0201LoaderAttachment").style.display = "";
                    //display loader

                    $('#table0201Attachment').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0201Attachment = $("#table0201Attachment").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Type' },
                            { data: 'Attachment' },
                            { data: 'Status' },
                            { data: 'UploadedDate' }],
                        columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }]
                    });
                    //datatable

                    //hide loader
                    document.getElementById("div0201LoaderAttachment").style.display = "none";
                    //hide loader

                    //action button
                    if (pMode == "ADD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    } else if (pMode == "DTL") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.add("btn-active-light");
                            btn.disabled = false;
                        }
                    } else if (pMode == "UPD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    }
                    //action button

                },
            });
        };
        function fn0201Download(pID, pFileName, pSeqNo) {
            //if exisit
            fnIfExist('SCM_Upl_Attachments', 'ID', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Download();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //download
            function Download() {
                $.ajax({
                    type: "POST",
                    url: "HNDSCM.ashx",
                    data: {
                        'FormCode': "SCM020100",
                        'Type': 'Contracts Account - Upload : Download Record',
                        'pID': pID,
						'pFileName': pFileName
                    },
					success: function (response) {
						if (response[0].View) {
							window.open('MNU020200?View=' + response[0].View);
						} else {
                            fnAlertOnly('Error in viewing file.', 'error', 'btn btn-danger');
						};
                    },
                });
            };
		};
		function fn0201Approved(pID, pFileName, pSeqNo) {
			// Validate
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM020000',
					'Type': 'Contractors - Validate Attachment',
					'pTblName': "Approved",
                    'pID': pID,
                    'pFileName': pFileName,
                    'pSeqNo': pSeqNo
                },
				success: function (response) {
					if (response[0].oReturn == "") {
						Swal.fire({
							text: 'Approve File?',
							icon: 'question',
							iconColor: '#0095e8',
							buttonsStyling: false,
							showCancelButton: true,
							confirmButtonText: "Yes",
							cancelButtonText: 'Cancel',
							customClass: {
								confirmButton: 'btn btn-sm btn-info min-w-100px',
								cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
							}
						}).then((result) => {
							if (result.isConfirmed) {
								if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
									Approved_File_Ok_Await(pID, pFileName, pSeqNo);
								};
							}
						});
						function Approved_File_Ok_Await(pID, pFileName, pSeqNo) {
							$.ajax({
								type: "POST",
								url: "HNDSCM.ashx",
								data: {
									'FormCode': 'SCM020100',
									'Type': 'Contracts Account - Approved Attachment : Status',
									'pID': pID,
									'pFileName': pFileName,
									'pSeqNo': pSeqNo
								},
								success: function (response) {
									fnAlertOnly('File successfully approved.', 'success', 'btn btn-success');
									//load
									fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
								}
							});
						};
					} else {
                        fnAlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
					};
                }
            });
		};
        function fn0201Resubmission(pID, pFileName, pSeqNo) {
            // Validate
            $.ajax({
                type: "POST",
                url: "HNDSCM.ashx",
                data: {
                    'FormCode': 'SCM020000',
                    'Type': 'Contractors - Validate Attachment',
                    'pTblName': "Resubmission",
                    'pID': pID,
                    'pFileName': pFileName,
                    'pSeqNo': pSeqNo
                },
                success: function (response) {
                    if (response[0].oReturn == "") {
                        Swal.fire({
                            text: 'Resubmit File?',
                            icon: 'question',
                            iconColor: '#0095e8',
                            buttonsStyling: false,
                            showCancelButton: true,
                            confirmButtonText: "Yes",
                            cancelButtonText: 'Cancel',
                            customClass: {
                                confirmButton: 'btn btn-sm btn-info min-w-100px',
                                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
                            }
                        }).then((result) => {
                            if (result.isConfirmed) {
                                if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                                    Resubmit_File_Ok_Await(pID, pFileName, pSeqNo);
                                };
                            }
                        });
                        function Resubmit_File_Ok_Await(pID, pFileName, pSeqNo) {
                            $.ajax({
                                type: "POST",
                                url: "HNDSCM.ashx",
                                data: {
                                    'FormCode': 'SCM020100',
                                    'Type': 'Contracts Account - Resubmission Attachment : Status',
                                    'pID': pID,
                                    'pFileName': pFileName,
                                    'pSeqNo': pSeqNo
                                },
                                success: function (response) {
                                    fnAlertOnly('File successfully marked for resubmission.', 'success', 'btn btn-success');
                                    //load
                                    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                                }
                            });
                        };
                    } else {
                        fnAlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                }
            });
		};
        function fn0201Update(pID, pFileName, pSeqNo) {
            //set
            document.getElementById("ContentPlaceHolder1_hf02ID").value = pID;
            document.getElementById("ContentPlaceHolder1_hf02SeqNo").value = pSeqNo;
            document.getElementById("ContentPlaceHolder1_hf02FileName").value = pFileName;

            myDropzone.removeAllFiles();
            FileCount = 0;
            $('#mdl0202Upload').modal('show');
		};
		//attachment

		function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			jQuery(function ($) {
				//dropdown
				$('[data-kt-repeater="select2"]').select2();
				//dropdown

				//load
				fn01Load();
				//load

				//upload - add
                Dropzone.autoDiscover = false;
                myDropzone01 = new Dropzone("#DropZone01", {
                    url: "/placeholder-url",
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".pdf,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0201Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0201Upload').modal('hide');
                        //load attachment
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
				});
                myDropzone01.on("addedfile", function (file) {
                    FileCount = FileCount + 1;
                });
                myDropzone01.on("removedfile", function (file) {
                    FileCount = FileCount - 1;
                });
                $('#btn0201Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('SCM020000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
                    function Validate() {
                        if (FileCount > 0) {
                            btn0201Add_Ok();
                        } else {
                            fnAlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
                        }
                    }
                    //upload
                    async function btn0201Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0201Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0201Add_Ok_Await(Btn);
                    }
                    async function btn0201Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone01.options.url = "HNDSCM.ashx?FormCode=SCM020100&Type=Upload - New&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
                            myDropzone01.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });

				//dropzone - update
                myDropzone = new Dropzone("#DropZone02", {
                    url: "/placeholder-url",
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".pdf,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0202Upload').modal('hide');
                        //load attachment
                        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                myDropzone.on("addedfile", function (file) {
                    FileCount = FileCount + 1;
                });
                myDropzone.on("removedfile", function (file) {
                    FileCount = FileCount - 1;
                });
                $('#btn0202Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('SCM020000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
                    function Validate() {
                        if (FileCount > 0) {
                            btn0202Add_Ok();
                        } else {
                            fnAlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
                        }
                    }
                    //upload
                    async function btn0202Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0202Add_Ok_Await(Btn);
                    }
                    async function btn0202Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone.options.url = "HNDSCM.ashx?FormCode=SCM020100&Type=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hf02ID').value + "&pFileName=" + document.getElementById("ContentPlaceHolder1_hf02FileName").value + "&pSeqNo=" + document.getElementById("ContentPlaceHolder1_hf02SeqNo").value;
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
				//upload
			});
		};
    </script>

</asp:Content>
