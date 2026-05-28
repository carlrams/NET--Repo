<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010100.aspx.vb" Inherits="NET.DocsStorage" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--begin::Post-->
<div class="content flex-row-fluid" id="kt_content1">
	<!--begin::breadcrumb bar-->
	<div class="toolbar py-5">
		<!--begin::Container-->
		<div class="container-xxl d-flex flex-stack flex-wrap p-0">
			<!--begin::Page title-->
			<div class="page-title d-flex flex-column me-3">
				<!--begin::Breadcrumb-->
				<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
					<!--begin::Item-->
					<li class="breadcrumb-item text-white opacity-75">
						<a href="AAD010000" class="text-white text-hover-primary">Dashboard</a>
					</li>
					<!--end::Item-->
					<!--begin::Item-->
					<li class="breadcrumb-item">
						<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
					</li>
					<!--end::Item-->
					<!--begin::Item-->
					<li class="breadcrumb-item text-white opacity-75">Documentary</li>
					<!--end::Item-->
				</ul>
				<!--end::Breadcrumb-->
			</div>
			<!--end::Page title-->
		</div>
		<!--begin::Container-->
	</div>
	<!--begin::breadcrumb bar-->

	<!--begin::Container-->
	<asp:UpdatePanel ID="upnlDocumentary" runat="server" UpdateMode="Conditional" class="d-flex flex-column-fluid align-items-start container-xxl">
		<ContentTemplate>
			<div id="kt_content_container" class="d-flex flex-column-fluid align-items-start container-xxl">
				<!--begin::Post-->
				<div class="content flex-row-fluid" id="kt_content2">
					<!--begin::Navbar-->
					<div class="card card-flush pb-0 bgi-position-y-center bgi-no-repeat mb-5" style="background-size: auto calc(100% + 10rem); background-position-x: 100%; background-image: url('../assets/media/custom/documentary.png')">
						<div class="card-body pt-20 pb-10">
							<!--begin::Details-->
							<div class="d-flex flex-wrap flex-sm-nowrap">
								<!--begin::Info-->
								<div class="flex-grow-1">
									<!--begin::Title-->
									<div class="d-flex justify-content-between align-items-start flex-wrap mb-2">
										<!--begin::User-->
										<div class="d-flex flex-column">
											<!--begin::Name-->
											<div class="d-flex align-items-center mb-2">
												<span class="text-gray-900 fs-2 fw-bolder me-1">Documentary</span>
											</div>
											<!--end::Name-->
										</div>
										<!--end::User-->
									</div>
									<!--end::Title-->
								</div>
								<!--end::Info-->
							</div>
							<!--end::Details-->
						</div>
					</div>
					<!--end::Navbar-->
					<!--begin::Card-->
					<div class="card">
						<!--begin::Card head-->
						<div class="card-header card-header-stretch">
							<!--begin::Title-->
							<div class="card-title d-flex align-items-center">
								<h3 class="card-title align-items-start flex-column">
									<span class="card-label fw-bolder text-dark">Documentary</span>
									<span class="text-gray-400 pt-2 fw-bold fs-6"><asp:Label ID="lblDate" runat="server"></asp:Label></span>
								</h3>
							</div>
							<!--end::Title-->
							<!--begin::Action-->
							<asp:LinkButton ID="lbtnCreateDocumentary" runat="server" class="btn btn-sm btn-primary my-6 pointer"><i class="las la-upload fs-6"></i> Create Documentary</asp:LinkButton>
							<!--end::Action-->
						</div>
						<!--end::Card head-->
						<!--begin::Card body-->
						<div class="card-body">
							<!--begin::Table Documentary-->  
							<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
								<asp:GridView ID="gv01Documentary" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" ShowFooter="true">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
											</ItemTemplate>
											<ItemStyle CssClass=" min-w-20px"/>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Account No.">
											<ItemTemplate>
												<div class="d-flex align-items-center">
													<div class="d-flex flex-column">
														<span class="fw-bold fs-7 text-dark"><%# Eval("AcctNo") %></span>
													</div>
												</div>
											</ItemTemplate>
											<ItemStyle CssClass="min-w-80px"/>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Date Created">
											<ItemTemplate>
												<div class="d-flex align-items-center flex-row-fluid flex-wrap">
													<div class="flex-grow-1 me-2">
														<span class="fw-bold fs-7 text-dark"><%# Eval("DateCreated") %></span>
													</div>
												</div>
											</ItemTemplate>
											<ItemStyle CssClass="pt-10-px pb-10-px min-w-40px" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Actions">
											<ItemTemplate>
												<asp:Linkbutton ID="HyperLink1" runat="server" class="btn btn-sm btn-icon btn-active-success" ToolTip="View Details" CommandArgument='<%# Eval("AcctNo") %>'>
													<span class="svg-icon svg-icon-2">
														<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-upload" viewBox="0 0 16 16">
															<path d="M.5 9.9a.5.5 0 0 1 .5.5v2.5a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1v-2.5a.5.5 0 0 1 1 0v2.5a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2v-2.5a.5.5 0 0 1 .5-.5"/>
															<path d="M7.646 1.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1-.708.708L8.5 2.707V11.5a.5.5 0 0 1-1 0V2.707L5.354 4.854a.5.5 0 1 1-.708-.708z"/>
														</svg>
													</span>
												</asp:Linkbutton>
											</ItemTemplate>
											<ItemStyle CssClass="pt-10-px pb-10-px min-w-50px" />
										</asp:TemplateField>
									</Columns>
									<EmptyDataTemplate>
										<div align="center">No data available.</div>
									</EmptyDataTemplate>
								</asp:GridView>
							</div>
							<!--end::Table Documentary-->  
						</div>
					</div>
					<!--end::Card-->
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<!--end::Container-->
</div>

<!--begin::Modal Add-->
<asp:UpdatePanel ID="mdl01UploadDocuments" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title"><asp:Label ID="lbl01Title" runat="server"></asp:Label></h5>
					<!--begin::Close-->
					<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
						<span class="svg-icon svg-icon-1">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
								<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
							</svg>
						</span>
					</div>
					<!--end::Close-->
				</div>
				<div class="modal-body">
					<!--begin::Nav group-->
					<div class="card card-flush shadow-sm mb-2">
						<div class="card-body py-2">
							<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder justify-content-end">
								<li class="nav-item" role="presentation">
									<a id="pending_tab_1" class="nav-link text-active-gray-800 me-4 active" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlRequirementsPending">Upload File</a>
								</li>
								<li class="nav-item" role="presentation">
									<a id="approved_tab_2" class="nav-link text-active-gray-800 me-4" data-bs-toggle="tab" role="tab" href="#ContentPlaceHolder1_upnlFiles">Documentary</a>
								</li>
							</ul>
						</div>
					<!--end::Nav group-->
					<div class="card">
						<!--begin::Card body-->
						<div class="card-body">
							<!--begin::Tab Content-->
							<div class="tab-content">
								<!--begin::Tab panel-->
								<asp:UpdatePanel ID="upnlRequirementsPending" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade show active" role="tabpanel">
									<ContentTemplate>
										<!--begin::Account Detail-->
										<div class="card shadow-sm mb-6">
											<div class="card-header">
												<h3 class="card-title">Account Details</h3>
												<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
													<div class="ribbon-icon mt-n5 me-n6">
														<i class="bi bi-card-text fs-3 text-white"></i>
													</div>
												</div>
											</div>
											<div class="card-body">
												<div class="input-group input-group-sm mb-2">
													<span class="input-group-text min-w-150px">Account No.</span>
													<asp:Label ID="lbl01AcctNo" runat="server" class="form-control">-</asp:Label>
												</div>
												<div class="input-group input-group-sm mb-2">
													<span class="input-group-text min-w-150px">Name</span>
													<asp:Label ID="lbl01Name" runat="server" class="form-control">-</asp:Label>
												</div>
												<div class="input-group input-group-sm mb-2">
													<span class="input-group-text min-w-150px">Date Created</span>
													<asp:Label ID="lbl01DateCreated" runat="server" class="form-control">-</asp:Label>
												</div>
											</div>
										</div>
										<!--end::Account Detail-->
										<div class="card shadow-sm">
											<div class="card-header">
												<h3 class="card-title">Attachments</h3>
												<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
													<div class="ribbon-icon mt-n5 me-n6">
														<i class="bi bi-paperclip fs-3 text-white"></i>
													</div>
												</div>
											</div>
											<div class="card-body">
												<!--begin::Dropzone-->
												<div class="dropzone mb-5" id="DropZone">
													<div class="dz-message needsclick">
														<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
														<div class="ms-4">
															<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop your files here or click to upload.</h3>
															<span class="fs-7 fw-bold text-gray-400">Upload files with a maximum 4 and file size of 4 MB below.</span>
														</div>
													</div>
												</div>
												<!--end::Dropzone-->
											</div>
										</div>
									</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Tab panel-->
								<!--begin::Tab panel-->
								<!--begin::Table Documentary-->
								<asp:UpdatePanel ID="upnlFiles" runat="server" UpdateMode="Conditional" class="card-body p-0 tab-pane fade" role="tabpanel">
									<ContentTemplate>
										<div class="card shadow-sm">
											<div class="card-header">
												<h3 class="card-title">Clients Documentary</h3>
												<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
													<div class="ribbon-icon mt-n5 me-n6">
														<i class="bi bi-paperclip fs-3 text-white"></i>
													</div>
												</div>
											</div>
											<div class="card-body">
												<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
													<asp:GridView ID="gv02Files" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False">
														<Columns>
															<asp:TemplateField>
																<ItemTemplate>
																	<span class="bullet bullet-vertical h-40px bg-secondary"></span>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="Action">
																<ItemTemplate>
																	<div class="d-flex ">
																		<asp:LinkButton ID="lbtnDelete" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("Name") %>' ToolTip="Remove file" OnClick="DeleteDocs"><i class="las la-trash fs-3"></i></asp:LinkButton>
																		<asp:LinkButton ID="lbtnDownload" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' ToolTip="Download file" OnClick="DownloadDocs"><i class="las la-download fs-3"></i></asp:LinkButton>
																	</div>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="File">
																<ItemTemplate>
																	<div class="d-flex align-items-center">
																		<div class="symbol symbol-30px overflow-hidden me-3">
																			<asp:Label ID="lblFileIcon" runat="server" CssClass="w-100" Text='<%# Bind("Icon") %>'></asp:Label>
																		</div>
																		<div class="d-flex flex-column">
																			<asp:Label ID="lblFileName" runat="server" CssClass="text-weight-500 text-gray-800" Text='<%# Bind("Name") %>'></asp:Label>
																			<asp:Label ID="lblFileDate" runat="server" Cssclass="text-weight-500 text-gray-600" Text='<%# Bind("CreationTime") %>'></asp:Label>
																		</div>
																	</div>
																</ItemTemplate>
																<ItemStyle Width="100%"/>
															</asp:TemplateField>
														</Columns>
														<EmptyDataTemplate>
															<div align="center">No data available.</div>
														</EmptyDataTemplate>
													</asp:GridView>
												</div>
											</div>
										</div>
									</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Tab panel-->
							</div>
						</div>
						<!--end::Tab panel-->
					</div>
				</div>
			</div>
			<!--begin::Actions-->
			<div class="modal-footer text-center">
				<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
				<asp:LinkButton ID="lbtn01RefreshGVFiles" runat="server" class="btn btn-primary" OnClick="RefreshGVFiles" style="display:none;"></asp:LinkButton>
				<asp:LinkButton ID="lbtn01Upload" runat="server" class="btn btn-primary">Upload</asp:LinkButton>
			</div>
			<!--end::Actions-->
		</div>
	</div>
</ContentTemplate>
<Triggers>
	<asp:PostBackTrigger ControlID="gv02Files" />
</Triggers>
</asp:UpdatePanel>
<!--begin::Modal Add-->

<!--begin::Modal Create Documentary-->
<asp:UpdatePanel ID="mdl01Documentary" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title">Add Client Documentary</h5>
					<!--begin::Close-->
					<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
						<span class="svg-icon svg-icon-1">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
								<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
							</svg>
						</span>
					</div>
					<!--end::Close-->
				</div>
				<div class="modal-body">
					<!--begin::Notice-->
					<div class="d-flex align-items-center rounded py-5 px-4 bg-success mb-5">  
						<span class="svg-icon svg-icon-2tx svg-icon-primary me-4">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#fff" class="bi bi-check2-circle" viewBox="0 0 16 16">
								<path d="M2.5 8a5.5 5.5 0 0 1 8.25-4.764.5.5 0 0 0 .5-.866A6.5 6.5 0 1 0 14.5 8a.5.5 0 0 0-1 0 5.5 5.5 0 1 1-11 0"/>
								<path d="M15.354 3.354a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0z"/>
							</svg>
						</span> 
						<div class="text-white fw-bold fs-6 lh-lg">
							<h4 class="text-white fw-bolder">Check Your Data.</h4>
							Please make sure to double check your entries before submitting the form.
						</div>  
					</div>
					<!--end::Notice-->
					<div class="card shadow-sm">
						<div class="card-header">
							<h3 class="card-title">Client Details</h3>
							<div class="ribbon ribbon-triangle ribbon-top-end border-primary">
								<div class="ribbon-icon mt-n5 me-n6">
									<i class="bi bi-card-text fs-3 text-white"></i>
								</div>
							</div>
						</div>
						<div class="card-body">
							<div class="input-group select-wrapper input-group-sm mb-2 flex-nowrap">
								<span class="input-group-text min-w-150px required">Client</span>
								<asp:DropDownList ID="ddl01Client" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0 min-h-35px">
									<asp:ListItem Value="">Select a client</asp:ListItem>
								</asp:DropDownList>
							</div>
							<div class="error-message mb-2" style="display:none; color: red;">
								Client is required.
							</div>
						</div>
					</div>
				</div>
				<!--begin::Actions-->
				<div class="modal-footer text-center">
					<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
					<asp:LinkButton ID="lbtn01Create" runat="server" class="btn btn-primary">Create</asp:LinkButton>
				</div>
				<!--end::Actions-->
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
<!--begin::Modal Create Documentary-->

    <script type="text/javascript"> 

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
			jQuery(function ($) {

                //validate inputs
                var dropdownsAdd = ['#ContentPlaceHolder1_ddl01Client',];

                dropdownsAdd.forEach(function (dropdownId) {
                    var dropdown = $(dropdownId);
                    var wrapper = dropdown.closest('.select-wrapper');
					var errorMessage = wrapper.next('.error-message');

                    dropdown.on('change', function () {
                        validateDropdown(dropdown, wrapper, errorMessage);
                    });
                });

                var lbtn01Submit = $("#ContentPlaceHolder1_lbtn01Create");
                $(lbtn01Submit).on('click', function () {
                    var isValid = true;

                    dropdownsAdd.forEach(function (dropdownId) {
                        var dropdown = $(dropdownId);
                        var wrapper = dropdown.closest('.select-wrapper');
						var errorMessage = wrapper.next('.error-message');

                        if (!validateDropdown(dropdown, wrapper, errorMessage)) {
                            isValid = false;
                        }
                    });

                    return isValid;
                });

                function validateDropdown(dropdown, wrapper, errorMessage) {
                    wrapper.css({
                        'border-color': '',
                        'border-width': '',
						'border-style': '',
                        'border-radius': ''
                    });
                    errorMessage.hide();

                    if (dropdown.val() === "" || dropdown.text() === "") {
                        wrapper.css({
                            'border-color': 'red',
                            'border-width': '1px',
                            'border-style': 'solid',
                            'border-radius': '3px'
                        });
                        errorMessage.show();
                        return false;
                    }
                    return true;
                }
                //validate inputs

                //combobox
				$('[data-kt-repeater="select2"]').select2({
                    dropdownParent: $('#ContentPlaceHolder1_mdl01Documentary')
				});
				//combobox

                //upload
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
					url: "HND000005.ashx",
                    autoProcessQueue: false,
                    parallelUploads: 4, 
                    maxFilesize: 4,
                    maxFiles: 4,
                    acceptedFiles: ".pdf,.PDF",
					addRemoveLinks: true,
                    params: {
                        'FormCode': 'AAD010100',
                        'Type': 'Documentary Upload'
                    },
                    init: function () {
                        this.on("sending", function (file, xhr, formData) {
                            var lbl01AcctNo = $('#ContentPlaceHolder1_lbl01AcctNo').text();
                            formData.append("InputValueAcctNo", lbl01AcctNo);
                        });
                    },
                    success: function (file, response) {
                        file.previewElement.classList.add("dz-success");
                        var ddl01Client = $("#ContentPlaceHolder1_ddl01Client");
						ddl01Client.val(response);

                        Swal.fire({
                            title: 'Success',
                            text: 'File uploaded successfully.',
                            icon: 'success',
                            confirmButtonColor: '#279852'
                        });
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });

                var lbtn01Upload = $("#ContentPlaceHolder1_lbtn01Upload");

                $(lbtn01Upload).on('click', function (e) {
					e.preventDefault();
                    if (myDropzone.files.length === 0) {
						Swal.fire({
							title: 'No file attached.',
							text: 'Please attach a file',
							icon: 'error',
							confirmButtonColor: '#279852'
						});
                    } else {
						myDropzone.processQueue();

                        setTimeout(function () {
                            var lbtn01RefreshGVFiles = document.getElementById('<%= lbtn01RefreshGVFiles.ClientID %>');
                            if (lbtn01RefreshGVFiles) {
                                lbtn01RefreshGVFiles.click();
                            }
                        }, 1000);
                    }
                });   
				//upload

            });
        }

    </script>
	<!-- scripts related to this page -->

</asp:Content>
