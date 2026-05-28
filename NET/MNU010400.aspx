<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MNU010400.aspx.vb" Inherits="NET.MNU010400" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
		<title>Reset Password</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="shortcut icon" href="assets/media/logos/favicon.ico" />
		<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" />
		<!--begin::css-->
		<link href="Assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
		<link href="Assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
		<!--end::css-->
    </head>
	<body id="kt_body" class="bg-body">
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
				<!--end::Aside-->
				<!--begin::Body-->
				<div class="d-flex flex-column flex-lg-row-fluid py-10">
					<div class="d-flex flex-center flex-column flex-column-fluid">
						<div class="w-lg-500px p-10 p-lg-15 mx-auto">
							<form id="frmReset" runat="Server" class="form w-100">
								<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
								<!--begin::SignUp-->
								<asp:UpdatePanel ID="upReset" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<div class="text-center mb-10">
										<h1 class="text-dark mb-3">Reset Password</h1>
										<div class="text-gray-400 fw-bold fs-4">Already have an account?
										<a href="MNU010100" class="link-primary fw-bolder">Sign in here</a></div>
									</div>
									<!--begin::Alert-->
									<asp:Panel ID="pnlAleart" runat="server" Visible ="false" >
										<!--begin::Icon-->
										<span class="svg-icon svg-icon-2hx svg-icon-light me-4 mb-5 mb-sm-0">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.3" x="2" y="2" width="20" height="20" rx="10" fill="currentColor"/>
												<rect x="11" y="17" width="7" height="2" rx="1" transform="rotate(-90 11 17)" fill="currentColor"/>
												<rect x="11" y="9" width="2" height="2" rx="1" transform="rotate(-90 11 9)" fill="currentColor"/>
											</svg> 
										</span>
										<!--end::Icon-->
										<!--begin::Wrapper-->
										<div class="d-flex flex-column text-light pe-0 pe-sm-10">
											<!--begin::Title-->
											<h4 class="mb-1 text-light">Message</h4>
											<!--end::Title-->
											<!--begin::Content-->
											<asp:Label ID="lblMessage" runat="server">Some fields are missing!</asp:Label>
											<!--end::Content-->
										</div>
										<!--end::Wrapper-->
										<!--begin::Close-->
										<button type="button" class="position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto" data-bs-dismiss="alert">
											<span class="svg-icon svg-icon-2x svg-icon-light">
												<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
													<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
													<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
												</svg>
											</span>
										</button>
										<!--end::Close-->
									</asp:Panel>
									<!--end::Alert-->
									<div class="fv-row mb-10">
										<asp:TextBox ID="tbxEmail" runat="server" class="form-control form-control-lg form-control-solid" placeholder="Corporate Email" autocomplete="off"></asp:TextBox>
									</div>
									<div class="fv-row mb-10">
										<asp:TextBox ID="tbxUsername" runat="server" class="form-control form-control-lg form-control-solid" placeholder="Username" autocomplete="off"></asp:TextBox>
									</div>
									<!--begin::Actions-->
									<div class="d-flex flex-wrap justify-content-center pb-lg-0">
										<asp:LinkButton ID="lbtnSend" runat="server" class="btn btn-lg btn-primary w-25 me-4">
											<span class="indicator-label">Send</span>
										</asp:LinkButton>
										<a href="MNU010100" class="btn btn-lg btn-light-primary fw-bolder w-25">
											<span class="indicator-label">Cancel</span>
										</a>
									</div>
									<!--end::Actions-->
								</ContentTemplate>
								</asp:UpdatePanel>
								<!--end::SignUp-->
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
