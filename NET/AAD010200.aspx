<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD010200.aspx.vb" Inherits="NET.DownloadableDocs" MaintainScrollPositionOnPostback = "true" EnableEventValidation="false" %>
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
					<li class="breadcrumb-item text-white opacity-75">Downloadable File</li>
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
	<asp:UpdatePanel ID="upnlDownloadables" runat="server" UpdateMode="Conditional" class="d-flex flex-column-fluid align-items-start container-xxl">
	<ContentTemplate>
	<!--begin::Post-->
	<div class="content flex-row-fluid" id="kt_content2">
		<!--begin::Navbar-->
		<div class="card card-flush pb-0 bgi-position-y-center bgi-no-repeat mb-5" style="background-size: auto calc(100% + 10rem); background-position-x: 100%; background-image: url('../assets/media/custom/upload.png')">
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
									<span class="text-gray-900 fs-2 fw-bolder me-1">Downloadable Templates</span>
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
		<!--begin::Timeline-->
		<div class="card">
			<!--begin::Card head-->
			<div class="card-header card-header-stretch">
				<!--begin::Title-->
				<div class="card-title d-flex align-items-center">
					<h3 class="card-title align-items-start flex-column">
						<span class="card-label fw-bolder text-dark">Downloadable Templates</span>
						<span class="text-gray-400 pt-2 fw-bold fs-6"><asp:Label ID="lbl01Date" runat="server"></asp:Label></span>
					</h3>
				</div>
				<!--end::Title-->
				<!--begin::Action-->
				<asp:LinkButton ID="lbtn01UploadDocuments" runat="server" class="btn btn-sm btn-primary my-6 pointer"><i class="las la-upload fs-6"></i> Upload Downloadables</asp:LinkButton>
				<!--end::Action-->
			</div>
			<!--end::Card head-->
			<!--begin::Card body-->
			<div class="card-body">
				<!--begin::Table Docs-->
				<asp:UpdatePanel ID="upnlDocs" runat="server" UpdateMode="Conditional" class="d-flex flex-column-fluid align-items-start container-xxl">
					<ContentTemplate>
						<div class="content flex-row-fluid">
							<!--begin::details View-->
							<div class="table-responsive" style="max-height:400px; overflow-y:scroll;">
								<asp:GridView ID="gv01Docs" runat="server" class="table table-no-border table-row-bordered table-hover" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<span class="bullet bullet-vertical h-40px bg-secondary"></span>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Action">
											<ItemTemplate>
												<div class="d-flex ">
													<asp:LinkButton ID="lbtn02Delete" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("Name") %>' ToolTip="Remove file" OnClick="DeleteDocs"><i class="las la-trash fs-3"></i></asp:LinkButton>
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
							<!--end::details View-->
						</div>
					</ContentTemplate>
					<Triggers>
						<asp:PostBackTrigger ControlID="gv01Docs" />
					</Triggers>
				</asp:UpdatePanel>
				<!--end::Table Docs-->
			</div>
			<!--end::Tab Content-->
		</div>
		<!--end::Card body-->
	</div>
</ContentTemplate>
</asp:UpdatePanel>
<!--end::Container-->
</div>
							
<!--begin::Modal Downloadables-->
<asp:UpdatePanel ID="mdl01Docs" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" aria-hidden="true">
	<ContentTemplate>
		<div class="modal-dialog modal-lg" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title">Upload Downloadable File</h5>
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
					<!--begin::Attachments-->
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
					<!--end::Attachments-->
				</div>
				<!--begin::Actions-->
				<div class="modal-footer text-center">
					<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
					<asp:LinkButton ID="lbtn01RefreshGVDocs" runat="server" class="btn btn-primary" OnClick="RefreshGVDocs" style="display:none;"></asp:LinkButton>
					<asp:LinkButton ID="lbtn01Upload" runat="server" class="btn btn-primary">Upload</asp:LinkButton>
				</div>
				<!--end::Actions-->
			</div>
		</div>
	</ContentTemplate>
</asp:UpdatePanel>
<!--begin::Modal Downloadables-->

<script type="text/javascript"> 

	function pageLoad(sender, args) {
		InitialiseSettings();
	}

    function InitialiseSettings() {
		jQuery(function ($) {

            //upload
            Dropzone.autoDiscover = false;
            var myDropzone = new Dropzone("#DropZone", {
                url: "HND000005.ashx",
                autoProcessQueue: false, 
                parallelUploads: 4,
                maxFilesize: 4,
                maxFiles: 4,
                maxfilesexceeded: function (file) {
                    this.removeAllFiles();
                    this.addFile(file);
                },
                acceptedFiles: ".pdf,.PDF",
				addRemoveLinks: true,
                params: {
                    'FormCode': 'AAD010200',
                    'Type': 'Downloadables Upload'
                },
                success: function (file, response) {
                    var imgPath = response;
                    file.previewElement.classList.add("dz-success");
                    var tbx01FilePath = $("#ContentPlaceHolder1_tbx01FilePath");
					tbx01FilePath.val(imgPath);

                    Swal.fire({
                        title: 'Success',
                        text: 'File uploaded successfully.',
                        icon: 'success',
                        confirmButtonColor: '#279852'
					});

                    $('#ContentPlaceHolder1_mdl01Docs').modal('hide');

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
                        text: 'Please attach a file before submitting.',
                        icon: 'error',
                        confirmButtonColor: '#279852'
                    });
                }
				else {
					myDropzone.processQueue();
						  
					setTimeout(function () {
                        var lbtn01RefreshGVDocs = document.getElementById('<%= lbtn01RefreshGVDocs.ClientID %>');
                        if (lbtn01RefreshGVDocs) {
							lbtn01RefreshGVDocs.click();
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
