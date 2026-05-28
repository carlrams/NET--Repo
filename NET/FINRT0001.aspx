<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FINRT0001.aspx.vb" Inherits="NET.FINRT0001" %>
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
						<li class="breadcrumb-item text-white">Project Development</a></li>
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
						<li class="breadcrumb-item text-white">GL Balance</li>
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
								<h2 class="mb-1">GL Balance</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<div class="mb-2">
							<div class="form-selec min-h-35px">
								<asp:TextBox ID="year" runat="server" class="form-control form-control-sm" placeholder="Year" ></asp:TextBox>
							</div>
						</div>
						<div class="row gx-2 gy-2 mb-2">
							<div class="col-6">
								<asp:DropDownList ID="ddlchart" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" ></asp:DropDownList>
							</div>
							<div class="col-6">
								<asp:DropDownList ID="ddlchart2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" ></asp:DropDownList>
							</div>
						</div>
						<div class="mb-2">
							<asp:ListBox ID="lbxchart3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" SelectionMode="Multiple"></asp:ListBox>
						</div>
						<div class="row row gx-2 gy-2 mb-2">
							<div class="col-6">
								<asp:DropDownList ID="ddldiv" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" ></asp:DropDownList>
							</div>
							<div class="col-6">
								<asp:DropDownList ID="ddldiv2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" ></asp:DropDownList>
							</div>
						</div>
						<div class="mb-2">
							<asp:ListBox ID="lbxdiv3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" SelectionMode="Multiple"></asp:ListBox>
						</div>
						<div class="mb-2">
							<asp:ListBox ID="ListBox1" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" SelectionMode="Multiple"></asp:ListBox>
						</div>
						<div class="row row gx-2 gy-2 mb-2">
							<div class="col-6">
								<asp:DropDownList ID="ddldept" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" ></asp:DropDownList>
							</div>
							<div class="col-6">
								<asp:DropDownList ID="ddldept2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" ></asp:DropDownList>
							</div>
						</div>
						<div class="mb-2">
							<asp:ListBox ID="lbxdept3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm" SelectionMode="Multiple"></asp:ListBox>
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

            });
        }
		//load page
    </script>

</asp:Content>