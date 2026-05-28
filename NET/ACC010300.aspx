<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC010300.aspx.vb" Inherits="NET.ACC010300"  MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Notification</li>
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
		<asp:UpdatePanel ID="upnlNotification" runat="server" UpdateMode="Conditional" class="row">
		<ContentTemplate>
			<div class="col-lg-6 col-xl-6 col-xxl-6 ml-auto mr-auto">
				<div class="card">
					<!--begin::title-->
					<div class="card-header pt-5 pb-5">
						<div class="d-flex align-items-center">
							<!--begin::Icon-->
							<div class="symbol me-5">
								<img src="Assets/media/svg/apps/ACC010300.svg" alt="" />
							</div>
							<!--end::Icon-->
							<!--begin::Title-->
							<div class="d-flex flex-column">
								<h2 class="mb-1">Notification</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxChangeStatus" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxChangeStatus">
								Change status
							</label>
						</div>
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxAddRecord" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxAddRecord">
								Add record
							</label>
						</div>
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxDeleteRecord" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxDeleteRecord">
								Delete record
							</label>
						</div>
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxEditRecord" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxEditRecord">
								Edit record
							</label>
						</div>
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxAddFile" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxAddFile">
								Add file
							</label>
						</div>
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxDeleteFile" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxDeleteFile">
								Delete file
							</label>
						</div>
						<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left:5px">
							<input id="cbxAddNote" runat="server" class="form-check-input" type="checkbox" value=""/>
							<label class="form-check-label" for="ContentPlaceHolder1_cbxAddNote">
								Add note
							</label>
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
		function lbtnSave1(Btn) {
            // Disable button to avoid multiple click
			Btn.disabled = true;
			 // Perform button
            var clickButton = document.getElementById("<%= lbtnSave.ClientID %>");
			clickButton.click();
			// Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
			}, 6000);
		};
    </script>

</asp:Content>
