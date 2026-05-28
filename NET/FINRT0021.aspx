<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FINRT0021.aspx.vb" Inherits="NET.FINRT0021" %>
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
						<li class="breadcrumb-item text-white">GL Detail</li>
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
								<h2 class="mb-1">GL Detail</h2>
							</div>
							<!--end::Title-->
						</div>
					</div>
					<!--end::title-->
					<div class="card-body">
						<div class="row gx-2 gy-2 mb-2">
							<div class="mb-2">
								<div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm" style="padding-left:5px">
									<input id="cbxClear" runat="server" class="form-check-input" type="checkbox" value=""/>
									<label class="form-check-label" for="ContentPlaceHolder1_cbxClear">
										Hide Cleared Items
									</label>
								</div>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:TextBox ID="tbxYearF" runat="server" class="form-control form-control-sm" placeholder="From Year" MaxLength="4"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:TextBox ID="tbxYearT" runat="server" class="form-control form-control-sm" placeholder="To Year" MaxLength="4"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:ListBox ID="ddlYear" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px" SelectionMode="Multiple">
								</asp:ListBox>
							</div>


							<div class="col-sm-12 col-md-4">
								<asp:TextBox ID="tbxPeriodF" runat="server" class="form-control form-control-sm" placeholder="From Period" MaxLength="2"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:TextBox ID="tbxPeriodT" runat="server" class="form-control form-control-sm" placeholder="From Period" MaxLength="2"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:ListBox ID="ddlPeriod" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px" SelectionMode="Multiple">
								</asp:ListBox>
							</div>


							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlGLA" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlGLA2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:ListBox ID="ddlGLA3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px" SelectionMode="Multiple">
								</asp:ListBox>
							</div>


							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlDiv" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlDiv2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:ListBox ID="ddlDiv3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px" SelectionMode="Multiple">
								</asp:ListBox>
							</div>


							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlDept" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlDept2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:ListBox ID="ddlDept3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px" SelectionMode="Multiple">
								</asp:ListBox>
							</div>


							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlJType" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:DropDownList ID="ddlJType2" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px">
								</asp:DropDownList>
							</div>
							<div class="col-sm-12 col-md-4">
								<asp:ListBox ID="ddlJType3" runat="server" data-kt-repeater="select2" class="form-select form-select-sm min-h-35px" SelectionMode="Multiple">
								</asp:ListBox>
							</div>


							<div class="col-sm-12 col-md-6">
								<input id="tbxDateFrom" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Journal Date From" />
							</div>
							<div class="col-sm-12 col-md-6">
								<input id="tbxDateTo" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Journal Date To" />
							</div>


							<div class="col-sm-12 col-md-6">
								<asp:TextBox ID="tbxRef" runat="server" class="form-control form-control-sm" placeholder="From Reference" MaxLength="20"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-6">
								<asp:TextBox ID="tbxRef2" runat="server" class="form-control form-control-sm" placeholder="To Reference" MaxLength="20"></asp:TextBox>
							</div>


							<div class="mb-2">
								<asp:TextBox ID="tbxRemarks" runat="server" class="form-control form-control-sm" placeholder="Remarks" MaxLength="500"></asp:TextBox>
							</div>


							<div class="col-sm-12 col-md-6">
								<asp:TextBox ID="tbxDebit" runat="server" class="form-control form-control-sm" placeholder="From Debit" MaxLength="30"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-6">
								<asp:TextBox ID="tbxDebit2" runat="server" class="form-control form-control-sm" placeholder="To Debit" MaxLength="30"></asp:TextBox>
							</div>


							<div class="col-sm-12 col-md-6">
								<asp:TextBox ID="tbxCredit" runat="server" class="form-control form-control-sm" placeholder="From Credit" MaxLength="30"></asp:TextBox>
							</div>
							<div class="col-sm-12 col-md-6">
								<asp:TextBox ID="tbxCredit2" runat="server" class="form-control form-control-sm" placeholder="To Credit" MaxLength="30"></asp:TextBox>
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
