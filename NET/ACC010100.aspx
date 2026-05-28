<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC010100.aspx.vb" Inherits="NET.ACC010100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--begin::Content-->
	<div class="content flex-row-fluid" id="kt_content">

		<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Account</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Personal Settings</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Profile</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtnSave" runat="server" Text="Button" OnClick="lbtnSave_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
				
		<!--begin::Content-->
		<asp:UpdatePanel ID="upnlProfile" runat="server" UpdateMode="Conditional" class="row">
		<ContentTemplate>
			<div class="col-lg-6 col-xl-6 col-xxl-6 ml-auto mr-auto">
				<div class="card">
					<!--begin::title-->
					<div class="card-header pt-5 pb-5">
						<div class="d-flex align-items-center">
							<!--begin::Icon-->
							<div class="symbol me-5">
								<img src="Assets/media/svg/apps/ACC010100.svg" alt="" />
							</div>
							<!--end::Icon-->
							<!--begin::Title-->
							<div class="d-flex flex-column fw-boldest ">
								<h2 class="mb-1">Profile</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<div class="d-flex flex-column-fluid  flex-center">
							<div class="mr-auto ml-auto align-middle mb-5">
								<!--begin::Image input-->
								<div class="image-input image-input-outline mb-5" data-kt-image-input="true" style="background-image: url('assets/media/svg/avatars/blank.svg')">
									<!--begin::Preview existing avatar-->
									<div id="divAvatar" runat="server" class="image-input-wrapper w-125px h-125px"></div>
									<!--end::Preview existing avatar-->
									<!--begin::Label-->
									<label class="btn btn-icon btn-circle btn-active-color-primary w-25px h-25px bg-body shadow" data-kt-image-input-action="change" data-bs-toggle="tooltip" title="Change avatar">
										<i class="bi bi-pencil-fill fs-7"></i>
										<!--begin::Inputs-->
										<asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.PNG" />
										<input type="hidden" name="avatar_remove" />
										<!--end::Inputs-->
									</label>
									<!--end::Label-->
									<!--begin::Cancel-->
									<span class="btn btn-icon btn-circle btn-active-color-primary w-25px h-25px bg-body shadow" data-kt-image-input-action="cancel" data-bs-toggle="tooltip" title="Cancel avatar">
										<i class="bi bi-x fs-2"></i>
									</span>
									<!--end::Cancel-->
									<!--begin::Remove-->
									<span class="btn btn-icon btn-circle btn-active-color-primary w-25px h-25px bg-body shadow" data-kt-image-input-action="remove" data-bs-toggle="tooltip" title="Remove avatar">
										<i class="bi bi-x fs-2"></i>
									</span>
									<!--end::Remove-->
								</div>
								<!--end::Image input-->
								<!--begin::Hint-->
								<div class="form-text">Allowed file types: png</div>
								<!--end::Hint-->
							</div>
						</div>
					</div>
					<div class="card-body">
						<div class="card-title fs-5 fw-bolder">Address</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Address</span>
							<asp:TextBox ID="tbxAddress" runat="server" class="form-control" Placeholder="Add address"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Province</span>
							<asp:DropDownList ID="ddlProvince" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true" data-placeholder="Select province">
								<asp:ListItem Value="">Select a province</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Town</span>
							<asp:DropDownList ID="ddlTown" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px"  data-placeholder="Select town">
								<asp:ListItem Value="">Select a town</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="card-title fs-5 fw-bolder">Contact Numbers</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Email</span>
							<asp:TextBox ID="tbxEmail" runat="server" class="form-control" Placeholder="Add email"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Tel. No.</span>
							<asp:TextBox ID="tbxTelNo" runat="server" class="form-control" Placeholder="Add tel. no."></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Mobile No. 1</span>
							<asp:TextBox ID="tbxMobileNo1" runat="server" class="form-control" Placeholder="Add mobile no. 1"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Mobile No. 2</span>
							<asp:TextBox ID="tbxMobileNo2" runat="server" class="form-control" Placeholder="Add mobile no. 2"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Mobile No. 3</span>
							<asp:TextBox ID="tbxMobileNo3" runat="server" class="form-control" Placeholder="Add mobile no. 3"></asp:TextBox>
						</div>
						<div class="card-title fs-5 fw-bolder">Contact Person</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Name</span>
							<asp:TextBox ID="tbxConName" runat="server" class="form-control" Placeholder="Add name"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Address</span>
							<asp:TextBox ID="tbxConAddress" runat="server" class="form-control" Placeholder="Add address"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Tel. No.</span>
							<asp:TextBox ID="tbxConTelNo" runat="server" class="form-control" Placeholder="Add tel. no."></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Mobile No. </span>
							<asp:TextBox ID="tbxConMobileNo" runat="server" class="form-control" Placeholder="Add mobile no."></asp:TextBox>
						</div>
					</div>
					<div class="card-footer d-flex flex-column-fluid  flex-center">
						<button class="btn btn-primary" runat="server" onclick="lbtnSave1(this);">Save Changes</button>
					</div>
				</div>
			</div>
		<!--end::Content-->
		</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<!--end::Content-->

	<script type="text/javascript">
        var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
        var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';

		function lbtnSave1(Btn) {
            // Disable button to avoid multiple click
            Btn.disabled = true;

            var tbxAddress = document.getElementById("ContentPlaceHolder1_tbxAddress");
            var ddlProvince = document.getElementById("ContentPlaceHolder1_ddlProvince");
            var ddlTown = document.getElementById("ContentPlaceHolder1_ddlTown");

			if (tbxAddress.value == "" || ddlProvince.value == "" || ddlTown.value == "") {
				Swal.fire({ text: 'Some fields are missing!', icon: 'error', buttonsStyling: false, confirmButtonText: 'Ok, got it!', customClass: { confirmButton: 'btn btn-danger' } });
                // Enable button
                Btn.disabled = false;
			} else {
                $.ajax({
                    url: "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + ltrlID.replace("#", "No"),
                    type: 'POST',
                    data: new FormData($('form')[0]),
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function () {
                        // Simulate form submission
						setTimeout(function () {
                            // Perform button
                            var clickButton = document.getElementById("<%= lbtnSave.ClientID %>");
                            clickButton.click();
                            // Enable button
							Btn.disabled = false;
                        }, 3000);
                    }
                });
			}
		};

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox
            });
        }
		//load page

    </script>

</asp:Content>
