<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MNU010100.aspx.vb" Inherits="NET.MNU010100" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
		<title>Sign in</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="shortcut icon" href="assets/media/logos/favicon.ico" />
		<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" />
		<!--begin::css-->
		<link href="Assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
		<link href="Assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
		<!--end::css-->
    </head>
	<body class="bg-body">
		<!--begin::Main-->
		<div class="d-flex flex-column flex-root">
			<div class="d-flex flex-column flex-lg-row flex-column-fluid">
				<!--begin::Aside-->
				<div class="d-flex flex-column flex-lg-row-auto w-xl-600px positon-xl-relative" style="background-color: #279852">
					<div class="d-flex flex-column position-xl-fixed top-0 bottom-0 w-xl-600px">
						<div class="d-flex flex-row-fluid flex-column text-center p-10 pt-lg-20">
							<div class="py-9 mb-5">
								<img alt="Logo" src="Assets/media/logos/ciislogo.png" style="width:273px;height:150px" />
							</div>
							<h6 class="fw-bolder fs-2qx pb-5 pb-md-10" style="color: #ffffff;">
								CALMARLAND<br /><p class="fw-bold fs-2" style="color: #ffffff;">INTEGRATED INFORMATION SYSTEM</p>
							</h6>
						</div>
						<!--begin::Illustration-->
						<div class="d-flex flex-row-auto bgi-no-repeat bgi-position-x-center bgi-size-contain bgi-position-y-bottom min-h-100px min-h-lg-350px" style="background-image: url(assets/media/illustrations/dozzy-1/19.png"></div>
						<!--end::Illustration-->
					</div>
				</div>
				<!--end::Aside-->
				<!--begin::Body-->
				<div class="d-flex flex-column flex-lg-row-fluid py-10">
					<div class="d-flex flex-center flex-column flex-column-fluid">
						<div class="w-lg-500px p-10 p-lg-15 mx-auto">
							<form id="frmSignIn" runat="Server" class="form w-100">
								<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
								<!--begin::Login-->
								<asp:UpdatePanel ID="upSignIn" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<div class="text-center mb-10">
										<h1 class="text-dark mb-3">Welcome to CIIS Web Portal</h1>
										<div class="text-gray-400 fw-bold fs-4">New Here?
										<a href="MNU010200" class="link-primary fw-bolder">Create an Account</a></div>
									</div>
									<div class="fv-row mb-10">
										<asp:TextBox ID="tbxUsername" runat="server" class="form-control form-control-lg form-control-solid" placeholder="Username" autocomplete="off"></asp:TextBox>
									</div>
									<div class="fv-row mb-10">
										<asp:TextBox ID="tbxPassword" runat="server" class="form-control form-control-lg form-control-solid" type="password" placeholder="Password" autocomplete="off"></asp:TextBox>
									</div>
									<div class="fv-row mb-10">
										<div class="d-flex flex-stack mb-2">
											<label class="form-check form-check-custom form-check-solid">
												<input runat="server" id="cbxRemember" class="form-check-input" type="checkbox" value="1" checked="checked"/>
												<span class="form-check-label fs-7 fw-bold text-muted">
													Remember Me
												</span>
											</label>
											<a href="MNU010300" class="link-primary fs-7 fw-bolder">Change Password</a>
											<a href="MNU010400" class="link-primary fs-7 fw-bolder">Reset Password?</a>
										</div>
									</div>
									<!--begin::Actions-->
									<div class="d-flex flex-wrap justify-content-center pb-lg-0">
										<button id="btnSignIn" runat="server" class="btn btn-lg btn-primary w-50">
											<span class="indicator-label">Login</span>
										</button>
									</div>
									<!--end::Actions-->
												</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::Login-->
							</form>
						</div>
					</div>
					<!--begin::Footer-->
					<div class="d-flex flex-center flex-wrap fs-6 p-5 pb-0">
						<div class="d-flex flex-center fw-bold fs-6">
							<span class="text-muted fw-bold me-1">2025©</span><img src="Assets/media/logos/cldclogo.png" alt="Smiley face" height="25" width="25"><span class="text-gray-800">   CIIS 2024.01.24</span>
						</div>
					</div>
					<!--end::Footer-->
				</div>
				<!--end::Body-->
			</div>
		</div>
		<!--end::Main-->
		<!--begin::Javascript-->
		<script src="Assets/plugins/global/plugins.bundle.js"></script>
		<script src="Assets/js/scripts.bundle.js"></script>
		<!--end::Javascript-->
	</body>
</html>
