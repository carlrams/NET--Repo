<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FINRT0016.aspx.vb" Inherits="NET.FINRT0016" %>
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
						<li class="breadcrumb-item text-white">Finance</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Report</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">A/P Aging Report</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="btnGenerate" runat="server" Text="Button" OnClick="btnGenerate_Click" ClientIDMode="Static" style="display:none;" />
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<!--begin::Content-->
		<asp:UpdatePanel ID="upnlParameter" runat="server" UpdateMode="Conditional" class="row">
		<ContentTemplate>
			<div class="col-lg-6 col-xl-6 col-xxl-6 ml-auto mr-auto">
				<div class="card">
					<!--begin::title-->
					<div class="card-header pt-5 pb-5">
						<div class="d-flex align-items-center">
							<!--begin::Icon-->
							<div class="symbol me-5">
								<img src="Assets/media/svg/apps/RPT.svg" alt="" />
							</div>
							<!--end::Icon-->
							<!--begin::Title-->
							<div class="d-flex flex-column">
								<h2 class="mb-1">A/P Aging Report</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
						<div class="card-body">
						<div class="mb-2"">
							<asp:DropDownList ID="ddlReport" runat="server" data-kt-repeater="select2" 
								class="form-select form-select-sm min-h-35px" AutoPostBack="True">
								<asp:ListItem Value="">Select Type</asp:ListItem>
								<asp:ListItem Value="Detailed">Detailed</asp:ListItem>
								<asp:ListItem Value="Summary">Summary</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2"">
							<div  class="form-selec min-h-35px">
								<input id="tbxDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" placeholder="Date" />
							</div>
						</div>
						<div class="mb-2"">
							<asp:DropDownList ID="ddlcrdtr_type" runat="server" data-kt-repeater="select2" 
								class="form-select form-select-sm min-h-35px" AutoPostBack="True"
								OnSelectedIndexChanged="ddlcrdtr_type_SelectedIndexChanged">
								<asp:ListItem Value="">Select Type</asp:ListItem>
								<asp:ListItem Value="Agent">Agent</asp:ListItem>
								<asp:ListItem Value="Customer">Customer</asp:ListItem>
								<asp:ListItem Value="Employee">Employee</asp:ListItem>
								<asp:ListItem Value="Vendor">Vendor</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2"">
							<asp:DropDownList ID="ddlcrdtr_code" runat="server" data-kt-repeater="select2" 
								class="form-select form-select-sm min-h-35px" AutoPostBack="True">
							</asp:DropDownList>
						</div>

							
						</div>
					<div class="card-footer d-flex flex-column-fluid  flex-center">
						<button class="btn btn-primary" runat="server" onclick="Generate(this);">Generate Report</button>
					</div>
				</div>
			</div>
		<!--end::Content-->
		</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<!--end::Content-->

	<script type="text/javascript">
        function Generate(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnGenerate.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Show loading indication
            Btn.setAttribute('data-kt-indicator', 'on');
            // Simulate form submission
            setTimeout(function () {
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //combobox
                $('[data-kt-repeater="select2"]').select2();
				//combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

            });
        }
		//load page
    </script>

</asp:Content>
