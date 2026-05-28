<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCMRT0011.aspx.vb" Inherits="NET.SCMRT0011" %>
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
						<li class="breadcrumb-item text-white">Report</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Warehouse Issuance</li>
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
								<h2 class="mb-1">Warehouse Issuance</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<div class="mb-2">
							<asp:DropDownList ID="ddlType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" AutoPostBack ="True">
								<asp:ListItem Value="">Type</asp:ListItem>
								<asp:ListItem Value="Land Development">Land Development</asp:ListItem>
								<asp:ListItem Value="Model House">Model House</asp:ListItem>
								<asp:ListItem Value="Water Connection">Water Connection</asp:ListItem>
								<asp:ListItem Value="Electricity Connection">Electricity Connection</asp:ListItem>
								<asp:ListItem Value="Subdivision Maintenance">Subdivision Maintenance</asp:ListItem>
								<asp:ListItem Value="Office Supplies">Office Supplies</asp:ListItem>
								<asp:ListItem Value="Advances (Employee)">Advances (Employee)</asp:ListItem>
								<asp:ListItem Value="Advances (Contractor)">Advances (Contractor)</asp:ListItem>
								<asp:ListItem Value="Service Vehicle">Service Vehicle</asp:ListItem>
								<asp:ListItem Value="Branch Marketing">Branch Marketing</asp:ListItem>
								<asp:ListItem Value="OSM Project">OSM Project</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddlCharge" runat="server" data-kt-repeater="select2" class="form-select form-select-sm">
								<asp:ListItem Value="">Charge To</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddlWarehouse" runat="server" data-kt-repeater="select2" class="form-select form-select-sm"></asp:DropDownList>
						</div>
						<div class="row gx-2 gy-2 mb-2">
							<div class="col-sm-12 col-md-6">
								<input id="tbxDateFrom" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date From" />
							</div>
							<div class="col-sm-12 col-md-6">
								<input id="tbxDateTo" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date To" />
							</div>
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
