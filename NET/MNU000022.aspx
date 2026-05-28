<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MNU000022.aspx.vb" Inherits="NET.MNU000022" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="shortcut icon" href="~/Assets/media/logos/favicon.ico" />
		<!--begin::Fonts-->
		<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" />
		<!--end::Fonts-->
		<!--begin::css-->
		<link href="Assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
		<link href="Assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
		<link href="Assets/plugins/custom/datatables/datatables.bundle.css" rel="stylesheet" type="text/css" />
		<link href="Assets/css/Custom.css" rel="stylesheet" type="text/css" />
		<!--end::css-->
	</head>
	<body id="kt_body" class="auth-bg">
        <form id="form1" runat="server">
            <div class="d-flex flex-column flex-root">
				<!--begin::Authentication - Error 500 -->
				<div class="d-flex flex-column flex-column-fluid">
					<!--begin::Content-->
					<div class="d-flex flex-column flex-column-fluid text-center p-10 py-lg-15">
						<!--begin::Logo-->
						<a href="DSB010000" class="mb-10 pt-lg-10">
							<img alt="Logo" src="Assets/media/logos/ciislogoinverted.png" class=" h-100px" />
						</a>
						<!--end::Logo-->
						<!--begin::Wrapper-->
						<div class="pt-lg-10">
							<!--begin::Logo-->
							<h1 class="fw-bolder fs-2qx text-gray-800 mb-10">System Error</h1>
							<!--end::Logo-->
							<!--begin::Message-->
							<div class="fw-bold fs-3 text-muted mb-15">Access denied!
							<br />Please contact system admin
							<br />for more info.</div>
							<!--end::Message-->
							<!--begin::Action-->
							<div class="text-center">
								<a href="DSB010000" class="btn btn-lg btn-primary fw-bolder">Go to homepage</a>
							</div>
							<!--end::Action-->
						</div>
						<!--end::Wrapper-->
						<!--begin::Illustration-->
						<div class="d-flex flex-row-auto bgi-no-repeat bgi-position-x-center bgi-size-contain bgi-position-y-bottom min-h-100px min-h-lg-350px" style="background-image: url(assets/media/illustrations/sigma-1/17.png"></div>
						<!--end::Illustration-->
					</div>
					<!--end::Content-->
				</div>
				<!--end::Authentication - Error 500-->
			</div>
			<!--end::Root-->
			<!--end::Main-->
			<!--begin::Javascript-->
			<script>var hostUrl = "assets/";</script>
			<!--begin::Global Javascript Bundle(used by all pages)-->
			<script src="Assets/plugins/global/plugins.bundle.js"></script>
			<script src="Assets/js/scripts.bundle.js"></script>
			<!--end::Global Javascript Bundle-->
			<!--end::Javascript-->
        </form>
    </body>
</html>
