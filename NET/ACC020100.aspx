<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC020100.aspx.vb" Inherits="NET.ACC020100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Daily Time Record</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="btnFilter" runat="server" Text="Button" OnClick="btnFilter_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->
				
		<!--begin::Content-->
		<div class="card card-flush">
			<!--begin::title-->
			<div class="card-header pt-5 pb-5" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/ACC020100.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<div class="card-title fs-3 fw-bolder">Daily Time Record</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<!--begin::Card header-->
			<div class="card-header" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex">
					<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Filter record" onclick="btnFilter01(this);">
						<span class="indicator-label">
							<i class="las la-filter fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
				</div>
			</div>
			<!--end::Card header-->
			<asp:UpdatePanel ID="upnlDTR" runat="server" UpdateMode="Conditional" class="card-body">
			<ContentTemplate>
				<div style="overflow-x:auto; scrollbar-width: thin;">
					<asp:GridView ID="gvDTR" runat="server" class="table table-no-border table-row-bordered table-hover align-middle tscroll tscroll2" AutoGenerateColumns="False" >
					<Columns>
						<asp:TemplateField HeaderText="Date">
							<ItemTemplate>
								<%# Eval("Date") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-100px" />
							<ItemStyle CssClass="min-w-100px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Day">
							<ItemTemplate>
								<%# Eval("Day") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Status">
							<ItemTemplate>
								<%# Eval("Status") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="AM In">
							<ItemTemplate>
								<%# Eval("AMIn") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="AM Out">
							<ItemTemplate>
								<%# Eval("AMOut") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="PM In">
							<ItemTemplate>
								<%# Eval("PMIn") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="PM Out">
							<ItemTemplate>
								<%# Eval("PMOut") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="OT In">
							<ItemTemplate>
								<%# Eval("OTIn") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="OT Out">
							<ItemTemplate>
								<%# Eval("OTOut") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="CS">
							<ItemTemplate>
								<%# Eval("CSTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="CO">
							<ItemTemplate>
								<%# Eval("COTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="LV">
							<ItemTemplate>
								<%# Eval("LVTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="OOW">
							<ItemTemplate>
								<%# Eval("OOWTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="TA">
							<ItemTemplate>
								<%# Eval("TATick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="OB">
							<ItemTemplate>
								<%# Eval("OBTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="OT">
							<ItemTemplate>
								<%# Eval("OTTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="WOP">
							<ItemTemplate>
								<%# Eval("WOPTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="LT/UT">
							<ItemTemplate>
								<%# Eval("LateTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="FTL">
							<ItemTemplate>
								<%# Eval("FTLTick") %>
							</ItemTemplate>
							<HeaderStyle CssClass="min-w-75px" />
							<ItemStyle CssClass="min-w-75px" />
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</div>
				<asp:UpdateProgress ID="uprgDTR" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="upnlDTR">
					<ProgressTemplate>
						<div class="table-loading-message d-flex align-items-center">
							<span class="loader"></span>&nbsp&nbsp<span class="fs-5">Loading...</span>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
			</ContentTemplate>
			</asp:UpdatePanel>
		<!--end::Content-->
		</div>

		<!--begin::Modal Filter-->
		<asp:UpdatePanel ID="mdlFilter" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Filter</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
						<!--end::Close-->
					</div>
					<div class="modal-body">
						<div class="row gx-2 mb-2">
							<div class="col-6"><asp:TextBox ID="tbxDateFrom" runat="server" data-kt-repeater="datepicker" class="form-control form-control-sm" placeholder="Date From" ></asp:TextBox></div>
							<div class="col-6"><asp:TextBox ID="tbxDateTo" runat="server" data-kt-repeater="datepicker" class="form-control form-control-sm" placeholder="Date To" ></asp:TextBox></div>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="btnFilter02(this);">
							Filter
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Filter-->

	</div>
	<!--end::Content-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">
        function btnFilter01(Btn) {
            $('#ContentPlaceHolder1_mdlFilter').modal('show');
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
        function btnFilter02(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnFilter.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 60000);
		};

        //tbody scroll
        var $table = $('table.tscroll'), $bodyCells = $table.find('tbody tr:first').children(), colWidth;
        $(window).resize(function () {
            colWidth = $bodyCells.map(function () {
                return $(this).width();
            }).get();
            $table.find('thead tr').children().each(function (i, v) {
                $(v).width(colWidth[i]);
            });
        });
        //tbody scroll

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
			// general
			jQuery(function ($) {
                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date
			});
			// general
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
