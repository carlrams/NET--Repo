<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="MNU020100.aspx.vb" Inherits="NET.MNU020100" MaintainScrollPositionOnPostback = "true"%>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Contet1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Notification</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Notifications you received in the last 6 months.</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
            <asp:Button ID="btnRefresh" runat="server" Text="Button" OnClick="btnRefresh_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<div class="card card-flush">
			<!--begin::title-->
			<div class="card-header pt-5 pb-5" style="border-bottom: 1px solid #EFF2F5;">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/MNU020100.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<div class="card-title fs-3 fw-bolder">Notification</div>
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
				</div>
			</div>
			<!--end::Card header-->
			<!--begin::Body-->
			<div class="card-body" >
				<div class="table-responsive" style="max-height:51.41vh;">
					<!--begin::Content-->
					<div ID="divNotificationNew" runat="server" class="card">
						<div class="card-header p-0 border-0">
							<div class="card-title">
								<h3 class='card-title w-100 mb-2 text-warning'><span>New for you</span></h3>
							</div>
							<div class="card-toolbar">
								<a href="#" onclick="MNU020100_MarkAllRead()"><span class="text-dark">Mark all read</span></a>
							</div>
						</div>
					</div>
					<div id="divNotificationListNew" runat="server">

					</div>
					<div ID="divNotificationPrevious" runat="server" class="card">
						<div class="card-header p-0 border-0">
							<div class="card-title">
								<h3 class='card-title w-100 mb-2 text-dark'><span>Previous notifications</span></h3>
							</div>
						</div>
					</div>
					<div id="divNotificationListPrevious" runat="server">

					</div>
				</div>
				
				<!--end::Content-->
			</div>
			<!--end::Body-->
		</div>
        	
	</div>
	<!--end::Post-->

	<!-- scripts related to this page -->
	<script src="Assets/js/custom/custom/MNU020100.js"></script>
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
		//function related to this page only
    </script>
	<!-- scripts related to this page -->

</asp:Content>
