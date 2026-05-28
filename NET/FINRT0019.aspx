<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FINRT0019.aspx.vb" Inherits="NET.FINRT0019" %>
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
						<li class="breadcrumb-item text-white">SL Detail</li>
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
								<h2 class="mb-1">SL Detail</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
						<div class="card-body">
							<div class="mb-2">
								<div class="col-sm-12 col-md-6 col-lg-3">
									<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
										<input id="cbxclear" runat="server" class="form-check-input" type="checkbox" value=""/>
										<label class="form-check-label" for="ContentPlaceHolder1_cbxNotForSale">
											Hide Cleared Item
										</label>
									</div>
								</div>
							</div>

							<div class="mb-2">
								<asp:DropDownList ID="ddlgl_acct" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;" AutoPostBack="true" >
								</asp:DropDownList>
							</div>

							<div class="mb-2" style="display: flex; gap: 10px; align-items: center; flex-wrap: nowrap;">
								<div style="flex: 1; min-width: 0;">
									<asp:TextBox ID="tbxyear_from" runat="server" class="form-control form-control-sm" placeholder="Year" style="min-height: 35px;" />
								</div>
								<div style="flex: 1; min-width: 0;">
									<asp:TextBox ID="tbxyear_to" runat="server" class="form-control form-control-sm" placeholder="Year" style="min-height: 35px;" />
								</div>
								<div style="flex: 2; min-width: 0;">
									<asp:ListBox ID="lbxyear" runat="server" data-kt-repeater="select2" 
										class="form-select form-select-sm" SelectionMode="Multiple"
										style="width: 100%; min-height: 35px;">
									</asp:ListBox>
								</div>
							</div>

							<div class="mb-2" style="display: flex; gap: 10px; align-items: center; flex-wrap: nowrap;">
								<div style="flex: 1; min-width: 0;">
									<asp:TextBox ID="tbxperiod_from" runat="server" class="form-control form-control-sm" placeholder="Period" style="min-height: 35px;" />
								</div>
								<div style="flex: 1; min-width: 0;">
									<asp:TextBox ID="tbxperiod_to" runat="server" class="form-control form-control-sm" placeholder="Period" style="min-height: 35px;" />
								</div>
								<div style="flex: 2; min-width: 0;">
									<asp:ListBox ID="lbxperiod_srs" runat="server" data-kt-repeater="select2" 
										class="form-select form-select-sm" SelectionMode="Multiple"
										style="width: 100%; min-height: 35px;">
									</asp:ListBox>
								</div>
							</div>


							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<asp:DropDownList ID="ddlsub_from" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:DropDownList>
								<asp:DropDownList ID="ddlsub_to" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:DropDownList>
								<asp:ListBox ID="lbxsub_srs" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" SelectionMode="Multiple"
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:ListBox>
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
							<asp:DropDownList ID="ddldiv_from" runat="server" data-kt-repeater="select2" 
								class="form-select form-select-sm" 
								style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
							</asp:DropDownList>
							<asp:DropDownList ID="ddldiv_to" runat="server" data-kt-repeater="select2" 
								class="form-select form-select-sm" 
								style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
							</asp:DropDownList>
							<asp:ListBox ID="lbxdiv_srs" runat="server" data-kt-repeater="select2" 
								class="form-select form-select-sm" SelectionMode="Multiple"
								style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
							</asp:ListBox>
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<asp:DropDownList ID="ddldept_from" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:DropDownList>
								<asp:DropDownList ID="ddldept_to" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:DropDownList>
								<asp:ListBox ID="lbxdept_srs" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" SelectionMode="Multiple"
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:ListBox>
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<asp:DropDownList ID="ddljtype_from" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:DropDownList>
								<asp:DropDownList ID="ddljtype_to" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" 
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:DropDownList>
								<asp:ListBox ID="lbxjtype_srs" runat="server" data-kt-repeater="select2" 
									class="form-select form-select-sm" SelectionMode="Multiple"
									style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 35px;">
								</asp:ListBox>
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<div class="col-sm-12 col-md-6">
								<input id="tbxjdate_from" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date From" />
								</div>
								<div class="col-sm-12 col-md-6">
								<input id="tbxjdate_to" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date To" />
								</div>
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<div class="col-sm-12 col-md-6">
								<asp:TextBox id="tbxref_from" runat="server" type="text"  class="form-control form-control-sm" Placeholder="Reference" />
								</div>
								<div class="col-sm-12 col-md-6">
								<asp:TextBox id="tbxref_to" runat="server" type="text" class="form-control form-control-sm" Placeholder="Reference" />
								</div>
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<asp:TextBox id="tbxjdesc" runat="server" type="text" class="form-control form-control-sm" Placeholder="Trx. Remarks" />
							</div>

							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<div class="col-sm-12 col-md-6">
								<asp:TextBox id="tbxpdebit_from" runat="server" type="text" class="form-control form-control-sm"  Placeholder="Debit" />
								</div>
								<div class="col-sm-12 col-md-6">
								<asp:TextBox id="tbxpdebit_to" runat="server" type="text"  class="form-control form-control-sm"  Placeholder="Debit" />
								</div>
							</div>


							<div class="mb-2" style="display: flex; gap: 5px; align-items: center; flex-wrap: nowrap;">
								<div class="col-sm-12 col-md-6">
								<asp:TextBox id="tbxpcredit_from" runat="server" type="text"  class="form-control form-control-sm"  Placeholder="Credit" />
								</div>
								<div class="col-sm-12 col-md-6">
								<asp:TextBox id="tbxpcredit_to" runat="server" type="text"  class="form-control form-control-sm"  Placeholder="Credit" />
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
