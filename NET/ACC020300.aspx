<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC020300.aspx.vb" Inherits="NET.ACC020300" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">HRMS and Payroll</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Payslip</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtnView" runat="server" Text="Button" OnClick="lbtnView_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
				
		<!--begin::Content-->
		<asp:UpdatePanel ID="upnlPayslip" runat="server" UpdateMode="Conditional" class="row">
		<ContentTemplate>
			<div class="col-lg-6 col-xl-6 col-xxl-6 ml-auto mr-auto">
				<div class="card">
					<!--begin::title-->
					<div class="card-header pt-5 pb-5">
						<div class="d-flex align-items-center">
							<!--begin::Icon-->
							<div class="symbol me-5">
								<img src="Assets/media/svg/apps/ACC020300.svg" alt="" />
							</div>
							<!--end::Icon-->
							<!--begin::Title-->
							<div class="d-flex flex-column">
								<h2 class="mb-1">Payslip</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Period / Cut-off</span>
							<asp:DropDownList ID="ddlPeriod" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px"  data-placeholder="Select period">
								<asp:ListItem Value="">Select a period</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Password</span>
							<asp:TextBox ID="tbxPassword" runat="server" class="form-control" type="password" Placeholder="Enter current password"></asp:TextBox>
						</div>
					</div>
					<div class="card-footer d-flex flex-column-fluid flex-center">
						<button class="btn btn-primary" runat="server" onclick="lbtnView1(this);">View</button>
					</div>
				</div>
			</div>
		<!--end::Content-->
		</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<!--end::Content-->

	<script type="text/javascript">
        function lbtnView1(Btn) {
            // Disable button to avoid multiple click
			Btn.disabled = true;
			 // Perform button
            var clickButton = document.getElementById("<%= lbtnView.ClientID %>");
			clickButton.click();
			// Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
			}, 3000);
		};
    </script>

</asp:Content>
