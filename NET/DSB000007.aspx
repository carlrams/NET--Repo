<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB000007.aspx.vb" Inherits="NET.DSB000007" MaintainScrollPositionOnPostback = "true" %>
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
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Dashboard</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">House Construction</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Overview</li>
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

		<!--begin::Engage widget 6-->
		<div class="card flex-grow-1 bgi-no-repeat bgi-size-contain bgi-position-x-end h-xl-100" style="background-color:#ffffff;background-image:url('assets/media/stock/1600x800/img-5.png')">
			<!--begin::Body-->
			<div class="card-body d-flex justify-content-between flex-column">
				<h3 class="card-title flex-column mb-20 pb-20">
					<!--begin::Labels-->
					<div class="fs-6 d-flex text-gray-400 fs-6 fw-bold pb-20">
						<div class="d-flex align-items-center me-6">
							<a href='DSB000008' class="text-success fw-bold min-w-75px">Overview</a>
						</div>
						<div class="d-flex align-items-center me-6">
							<a href='DSB000009' class=" text-success fw-bold min-w-75px">Territory</a>
						</div>
						<div class="d-flex align-items-center me-6">
							<a href='DSB000010' class="text-success fw-bold min-w-75px">Project</a>
						</div>
						<div class="d-flex align-items-center me-6">
							<a href='DSB000013' class="text-success fw-bold min-w-75px">Batch</a>
						</div>
						<div class="d-flex align-items-center me-6">
							<a href='DSB000008' class="text-success fw-bold min-w-75px">Report</a>
						</div>
					</div>
					<!--end::Labels-->
				</h3>
				<!--end::Card title-->
				<!--begin::Heading-->
				<div class="mb-20 pt-xl-13">
					<!--begin::Title-->
					<h3 class="fw-bolder text-success fs-4x mb-5 ms-n1">Project Management <br> System</h3>
					<!--end::Title-->
					<!--begin::Description-->
					<span class="fw-bolder text-success fs-4 mb-8 d-block lh-0">House Construction Monitoring</span>
					<!--end::Description-->
				</div>
				<!--end::Heading-->
				<!--begin::Action-->
				<div class="mb-xl-10 mb-3"></div>
				<!--begin::Action-->
			</div>
			<!--end::Body-->
		</div>
		<!--end::Engage widget 6-->

	</div>
	<!--end::Post-->

</asp:Content>
