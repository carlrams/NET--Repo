<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ACC030100.aspx.vb" Inherits="NET.ACC030100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
	<!--begin::Post-->
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
						<li class="breadcrumb-item text-white">Monitoring</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Cash Advance (For Liquidation)</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::content-->
		<div class="card card-flush">
			<!--begin::title-->
			<div class="card-header pt-5 pb-5" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/ACC030100.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<div class="card-title fs-3 fw-bolder">Cash Advance (For Liquidation)</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<!--begin::Card header-->
			<div class="card-header" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex">
					<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="btnRefresh1(this);">
						<span class="indicator-label">
							<i class="las la-redo-alt fs-2"></i>
						</span>
						<span class="indicator-progress">
							<span class="spinner-border spinner-border-sm align-middle"></span>
						</span>
					</button>
					<!--begin::Search-->
					<div class="d-flex align-items-center position-relative m-1">
						<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
						<span class="svg-icon svg-icon-2 position-absolute ms-4">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
								<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
							</svg>
						</span>
						<!--end::Svg Icon-->
						<input id="tbxFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search Record" />
					</div>
				</div>
			</div>
			<!--end::Card header-->
			<!--begin::Card body-->
			<asp:UpdatePanel ID="upnlContent" runat="server" UpdateMode="Conditional" class="card-body">
			<ContentTemplate>
				<asp:Button ID="btnRefresh" runat="server" Text="Button" OnClick="lbtnRefresh_Click" ClientIDMode="Static" style="display:none;"/>
				<asp:Button ID="btnRPT_Single" runat="server" Text="Button" OnClick="btnRPT_Single_Click" ClientIDMode="Static" style="display:none;"/>
				<div style="overflow-x:auto; scrollbar-width: thin;">
					<asp:GridView ID="gvTask" runat="server" class="table table-no-border table-row-bordered table-hover align-middle tscroll" AutoGenerateColumns="False" ShowHeader="false" EmptyDataText="No Data" >
					<Columns>
						<asp:TemplateField HeaderText="">
							<ItemTemplate>
								<div class="h-100"><span class='<%# Eval("Bullet") %>'></span></div> 
							</ItemTemplate>
							<HeaderStyle CssClass="mw-5px min-w-5px" />
							<ItemStyle CssClass="mw-5px min-w-5px" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Open Task">
							<ItemTemplate>
								<div class="overlay overflow-hidden">
									<div class="overlay-wrapper">
										<a href='<%# Eval("Link") %>' class="d-flex align-items-center w-100">
											<div class="d-flex flex-column min-w-30px mw-30px me-3"  >
												<div class="symbol symbol-30px overflow-hidden">
													<img alt='' class='w-100' src='<%# Eval("Icon") %>' />
												</div>
											</div>
											<div class="d-flex flex-column min-w-400px w-100">
												<span class="text-dark fw-bolder fs-6 nowrap-auto"> <%# Eval("Title") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7 nowrap-auto"><%# Eval("ID") %> <%# Eval("Name") %> <%# Eval("Date") %></span>
											</div>
												<div class="d-flex flex-column min-w-150px">
												<span class="text-dark fw-bolder fs-6"><%# Eval("Amount") %></span>
												<span class="text-muted fw-bold text-muted d-block fs-7">Amount</span>
											</div>
										</a>
									</div>
									<div class="overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end">
										<div class="d-flex justify-content-end flex-shrink-0">
											<a href="#" class="btn btn-sm btn-icon btn-light btn-active-light-primary me-4" title="Action" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
												<!--begin::Svg Icon | path: icons/duotune/arrows/arr072.svg-->
												<span class="svg-icon svg-icon-1 m-0">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path d="M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z" fill="currentColor"/>
														<path opacity="0.3" d="M21 14H3C2.4 14 2 13.6 2 13V11C2 10.4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z" fill="currentColor"/>
													</svg>
												</span>
												<!--end::Svg Icon-->
											</a>
											<!--begin::Menu-->
											<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-200px py-4" data-kt-menu="true">
												<!--begin::Menu item-->
												<div class="menu-item px-3" <%# Eval("RPT_Display") %>>
													<a class="menu-link px-3" onclick="<%# Eval("RPT_Single") %>">Print Preview</a>
												</div>
												<!--end::Menu item-->
											</div>
											<!--end::Menu-->
										</div>
									</div>
								</div>
								<asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
							</ItemTemplate>
							<HeaderStyle CssClass="w-100" />
							<ItemStyle CssClass="w-100" />
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
				</div>
				<asp:UpdateProgress ID="uprgContent" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="upnlContent">
					<ProgressTemplate>
						<div class="table-loading-message d-flex align-items-center">
							<span class="loader"></span>&nbsp&nbsp<span class="fs-5">Loading...</span>
						</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
			</ContentTemplate>
			</asp:UpdatePanel>
			<!--end::Card body-->
		</div>
		<!--begin::content-->
		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfFormCode" runat="server" />
		<asp:HiddenField ID="hfID" runat="server" />
		<asp:HiddenField ID="hrRPT" runat="server" />
		<asp:HiddenField ID="hfView" runat="server" />
		<asp:HiddenField ID="hfMention" runat="server" />
		<asp:HiddenField ID="hfScrollPosition" runat="server" Value ="0" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Post-->
	
	<!--scripts related to this page -->
    <script type="text/javascript">  

		//function related to this page only
        function btnRefresh1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnRefresh.ClientID %>");
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
        function RPT_Single(FormCode, ID, RPT) {
            var hfFormCode = document.getElementById("ContentPlaceHolder1_hfFormCode");
            hfFormCode.value = FormCode;
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            var hrRPT = document.getElementById("ContentPlaceHolder1_hrRPT");
            hrRPT.value = RPT;
            var clickButton = document.getElementById("<%= btnRPT_Single.ClientID %>");
            clickButton.click();
		}
		//function related to this page only

        //postback
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            //search
            var $rows = $('#ContentPlaceHolder1_gvTask tbody tr');
            $('#tbxFind').keyup(function () {
                var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
                $rows.show().filter(function () {
                    var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
                    return !~text.indexOf(val);
                }).hide();
            });
            //search
        }
        //postback

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

        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {
                //scroll position                document.querySelector('#ContentPlaceHolder1_gvTask > tbody').setAttribute("onscroll", "scrollPos()");                var hfScrollPosition = document.getElementById("ContentPlaceHolder1_hfScrollPosition");                document.querySelector('#ContentPlaceHolder1_gvTask > tbody').scrollTop = hfScrollPosition.value;                //scroll position
                //menu
                KTMenu.createInstances();
                //menu

            });
        }
    </script>
	<!-- scripts related to this page -->

</asp:Content>
