<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="ENG010701.aspx.vb" Inherits="NET.ENG010701" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Construction</li>
						<li class="breadcrumb-item"><a href="ENG010700" class="text-white opacity-75">Construction</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Other Porject</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtn01Refresh" runat="server" Text="Button" OnClick="lbtn01Refresh_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn01Status" runat="server" Text="Button" OnClick="lbtn01Status_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn01StatusSave" runat="server" Text="Button" OnClick="lbtn01StatusSave_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn06PRGDtlEdit" runat="server" Text="Button" OnClick="lbtn06PRGDtlEdit_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn06PRGDtlSave" runat="server" Text="Button" OnClick="lbtn06PRGDtlSave_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn02Upload" runat="server" Text="Button" OnClick="lbtn02Upload_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn02UploadSave" runat="server" Text="Button" OnClick="lbtn02UploadSave_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn05Add" runat="server" Text="Button" OnClick="lbtn05Add_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="lbtn05NoteAdd" runat="server" Text="Button" OnClick="lbtn05NoteAdd_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::Title-->
		<asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional" class="card card-flush mb-5 ">
		<ContentTemplate>
			<!--begin::title-->
			<div class="card-header pt-10">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/ENG010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<h2 class="mb-1"><asp:Label id="lblTitle" runat="server"></asp:Label></h2>
						<div class="text-muted fw-bolder">
							<asp:Label ID="lblID" runat="server"></asp:Label>
							<span class="mx-3">|</span>
							<asp:Label ID="lblStatus" runat="server"></asp:Label>
						</div>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<!--begin::menu-->
			<div class="card-body pb-0">
				<!--begin::Navs-->
				<div class="d-flex overflow-auto h-55px">
					<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1 active"  title="Overview" data-bs-toggle="tab" href="#Menu01_TabContent"><i class="las la-file-alt fs-3x"></i></a>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1" title="Files" data-bs-toggle="tab" href="#Menu02_TabContent"><i class="las la-paperclip fs-3x"></i></a>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1" title="Notes" data-bs-toggle="tab" href="#Menu05_TabContent"><i class="las la-comment fs-3x"></i></a>
						</li>
						<!--end::Nav item-->
					</ul>
				</div>
				<!--begin::Navs-->
			</div>
			<!--end::menu-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Title-->

		<!--begin::Content-->
		<div class="card card-flush mb-5 no-border"  >
			<!--begin::Content-->
			<div class="tab-content" >
				<div class="tab-pane fade show active" id="Menu01_TabContent">
					<!--begin::Card header-->
					<div class="card-header">
						<!--begin::Card header-->
						<div class="card-title fs-3 fw-bolder">Overview</div>
						<!--end::Card header-->
					</div>
					<!--end::Card header-->
					<!--begin::Card header-->
					<div class="card-header">
						<div class="d-flex">
							<button class="btn btn-sm btn-icon btn-info align-self-center m-1" title="Refresh record" onclick="lbtn01Refresh1(this);">
								<span class="indicator-label">
									<i class="las la-redo-alt fs-2"></i>
								</span>
								<span class="indicator-progress">
									<span class="spinner-border spinner-border-sm align-middle"></span>
								</span>
							</button>
							<button class="btn btn-sm btn-icon btn-secondary align-self-center m-1" title="Change Status" onclick="lbtn01Status1(this);">
								<span class="indicator-label">
									<i class="las la-flag fs-2"></i>
								</span>
								<span class="indicator-progress">
									<span class="spinner-border spinner-border-sm align-middle"></span>
								</span>
							</button>
						</div>
					</div>
					<!--end::Card header-->
					<asp:UpdatePanel ID="upnl01Overview" runat="server" UpdateMode="Conditional" class="card-body">
					<ContentTemplate>
						<!--begin::Dtl-->
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">ID</span>
							<asp:Label ID="lbl01ID" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Project</span>
							<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Contractor</span>
							<asp:Label ID="lbl01ConName" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Assigned To</span>
							<asp:Label ID="lbl01AssignTo" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Status</span>
							<asp:Label ID="lbl01Status" runat="server" class="form-control">-</asp:Label>
						</div>
						<!--end::Dtl-->
					</ContentTemplate>
					</asp:UpdatePanel>
					<!--begin::Card header-->
					<div class="card-header">
						<!--begin::Card header-->
						<div class="card-title fs-3 fw-bolder">Progress</div>
						<!--end::Card header-->
					</div>
					<!--end::Card header-->
					<!--begin::Card header-->
					<div class="card-header">
						<div class="d-flex">
							<button class="btn btn-sm btn-icon btn-warning align-self-center m-1" title="Refresh record" onclick="lbtn06PRGDtlEdit1(this);">
								<span class="indicator-label">
									<i class="las la-pencil-alt fs-2"></i>
								</span>
								<span class="indicator-progress">
									<span class="spinner-border spinner-border-sm align-middle"></span>
								</span>
							</button>
						</div>
					</div>
					<!--end::Card header-->
					<asp:UpdatePanel ID="upnl06PRGDtl" runat="server" UpdateMode="Conditional" class="card-body">
					<ContentTemplate>
						<!--begin::Contract Detail-->
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Rate</span>
							<asp:Label ID="lbl06PRGDtlRate" runat="server" class="form-control">-</asp:Label>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px">Date</span>
							<asp:Label ID="lbl06PRGDtlDate" runat="server" class="form-control">-</asp:Label>
						</div>
						<!--end::Contract Detail-->
					</ContentTemplate>
					</asp:UpdatePanel>
					<!--end::Menu Content-->
				</div>
				<div class="tab-pane fade" id="Menu02_TabContent">
					<!--begin::Menu Content-->
					<div class="card card-xl-stretch">
						<!--begin::Card header-->
						<div class="card-header">
							<!--begin::Card header-->
							<div class="card-title fs-3 fw-bolder">Attachment</div>
							<!--end::Card header-->
						</div>
						<!--end::Card header-->
						<!--begin::Card header-->
						<div class="card-header">
							<div class="d-flex">
								<button class="btn btn-sm btn-icon btn-success align-self-center m-1" title="Refresh record" onclick="lbtn02Upload1(this);">
									<span class="indicator-label">
										<i class="las la-upload fs-2"></i>
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</button>
							</div>
							<div class="d-flex align-items-center position-relative m-1">
								<ul class="nav nav-tabs nav-line-tabs nav-stretch border-0">
									<li class="nav-item ">
										<a class="nav-link active" data-bs-toggle="tab" href="#Menu02_Files" title="Files">
											<i class="las la-list fs-1"></i>
										</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" data-bs-toggle="tab" href="#Menu02_Photos" title="Photos">
											<i class="las la-images fs-1"></i>
										</a>
									</li>
								</ul>
							</div>
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<div class="tab-content" >
								<!--begin::Files-->
								<div class="tab-pane fade show active" id="Menu02_Files">
									<asp:UpdatePanel ID="upnl02Files" runat="server" UpdateMode="Conditional">
									<ContentTemplate>
										<div class="table-responsive">
											<asp:GridView ID="gv02Files" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateField HeaderText="Action">
													<ItemTemplate>
														<div class="d-flex pl-4 ">
															<button class="btn btn-sm btn-icon btn-light mr-5 align-self-center" title="Delete file" onclick="<%# Eval("lbtn02Delete1") %>">
																<span class="indicator-label">
																	<i class="las la-trash fs-2"></i>
																</span>
																<span class="indicator-progress">
																	<span class="spinner-border spinner-border-sm align-middle"></span>
																</span>
															</button>
															<button class="btn btn-sm btn-icon btn-light mr-5 align-self-center" title="Download file" onclick="<%# Eval("lbtn02Download1") %>">
																<span class="indicator-label">
																	<i class="las la-download fs-2"></i>
																</span>
																<span class="indicator-progress">
																	<span class="spinner-border spinner-border-sm align-middle"></span>
																</span>
															</button>
														</div>
													</ItemTemplate>
													<HeaderStyle  />
													<ItemStyle />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="File">
													<ItemTemplate>
														<div class="d-flex align-items-center">
															<!--begin:: Avatar -->
															<div class="symbol symbol-30px overflow-hidden me-3">
																<span class="w-100"><%# Eval("Icon") %></span>
															</div>
															<!--end::Avatar-->
															<!--begin::User details-->
															<div class="d-flex flex-column">
																<span class="fw-bold text-dark"><%# Eval("Name") %></span>
																<span class="text-muted"><%# Eval("CreationTime") %></span>
															</div>
															<!--begin::User details-->
														</div>
													</ItemTemplate>
													<HeaderStyle CssClass="w-100" />
													<ItemStyle CssClass="w-100" />
												</asp:TemplateField>
											</Columns>
											</asp:GridView>
										</div>
									</ContentTemplate>
									</asp:UpdatePanel>
								</div>
								<!--end::Files-->
								<!--begin::Files-->
								<div class="tab-pane fade" id="Menu02_Photos">
									<asp:UpdatePanel ID="upnl02Photos" runat="server" UpdateMode="Conditional">
									<ContentTemplate>
										<div id ="div02Photos" runat="server" class="row g-10 row-cols-2 row-cols-lg-5">
											
										</div>
									</ContentTemplate>
									</asp:UpdatePanel>
								</div>
								<!--end::Files-->
							</div>
						</div>
					</div>
					<!--end::Menu Content-->
					
				</div>
				<div class="tab-pane fade" id="Menu05_TabContent">
					<!--begin::Menu Content-->
					<div class="card card-xl-stretch">
						<!--begin::Card header-->
						<div class="card-header">
							<!--begin::Card header-->
							<div class="card-title fs-3 fw-bolder">Notes</div>
							<!--end::Card header-->
						</div>
						<!--end::Card header-->
						<!--begin::Card header-->
						<div class="card-header">
							<div class="d-flex">
								<button class="btn btn-sm btn-icon btn-success align-self-center m-1" title="Add note" onclick="lbtn05Add1(this);">
									<span class="indicator-label">
										<i class="las la-comment fs-2"></i>
									</span>
									<span class="indicator-progress">
										<span class="spinner-border spinner-border-sm align-middle"></span>
									</span>
								</button>
							</div>
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<asp:UpdatePanel ID="upnl05Notes" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<div class="table-responsive">
									<asp:GridView ID="gv05Notes" runat="server" class="table table-no-border" AutoGenerateColumns="False" ShowHeader="False">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<div class="d-flex align-items-center mb-5">
													<!--begin:: Avatar -->
													<div class="symbol symbol-30px overflow-hidden me-3">
														<div class="symbol-label">
															<img alt="" class="w-100" src="<%# Eval("Icon") %>" />
														</div>
													</div>
													<!--end::Avatar-->
													<!--begin::User details-->
													<div class="d-flex flex-column">
														<span class="fw-bold text-dark"><%# Eval("By") %></span>
														<span class="text-muted"><%# Eval("Date") %></span>
													</div>
													<!--begin::User details-->
												</div>
												<!--begin::Desc-->
												<p class="text-dark"><%# Eval("Notes") %></p>
												<!--end::Desc-->
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
									</asp:GridView>
								</div>
							</ContentTemplate>
							</asp:UpdatePanel>
							<!--end::ID-->
						</div>
					</div>
					<!--end::Menu Content-->
				</div>
			</div>
			<!--end:  Content-->
		</div>
		<!--end::Content-->

		<!--begin::Modal Progress-->
		<asp:UpdatePanel ID="mdl06PRGDtl" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Update Progress</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Rate</span>
							<input id="tbx06PRGDtlRate" runat="server" class='form-control NumVal' onblur="FormatNumeric(this.id);" type="text" value="0.00" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Date</span>
							<input id="tbx06PRGDtlDate" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
							<asp:TextBox ID="tbx06PRGDtlRemarks" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="lbtn06PRGDtlSave1(this);">
							Update
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Progress-->
		
		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdl01DialogBox" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Message</h5>
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
						<p><asp:Label ID="lbl01ConfirmMessageDialogBox" runat="server"></asp:Label></p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<asp:LinkButton ID="lbtn01DeleteOk" runat="server" class="btn btn-primary" Visible="false">Ok</asp:LinkButton>
						<asp:LinkButton ID="lbtn01SaveOk" runat="server" class="btn btn-primary" Visible="false">Ok</asp:LinkButton>
						<asp:LinkButton ID="lbtn02DeleteOk" runat="server" class="btn btn-primary" Visible="false">Ok</asp:LinkButton>
						<asp:HiddenField ID="hfFileName" runat="server" />
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
		
		<!--begin::Modal Status-->
		<asp:UpdatePanel ID="mdl01Status" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Overview - Change Status</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Change status to</span>
							<asp:DropDownList ID="ddl01Status" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select status</asp:ListItem>
								<asp:ListItem Value="Assign">Assign</asp:ListItem>
								<asp:ListItem Value="On-Going">On-Going</asp:ListItem>
								<asp:ListItem Value="On-Hold">On-Hold</asp:ListItem>
								<asp:ListItem Value="Complete">Complete</asp:ListItem>
								<asp:ListItem Value="Clarify">Clarify</asp:ListItem>
								<asp:ListItem Value="Close">Close</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Assign to</span>
							<asp:DropDownList ID="ddl01AssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select user</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
							<asp:TextBox ID="tbx01Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
						
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="lbtn01StatusSave1(this);">Update</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Status-->

		<!--begin::Modal Upload-->
		<asp:UpdatePanel ID="mdl02Upload" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
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
						<!--begin::Dropzone-->
						<div class="dropzone mb-5" id="DropZone">
							<!--begin::Message-->
							<div class="dz-message needsclick">
								<!--begin::Icon-->
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<!--end::Icon-->
								<!--begin::Info-->
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
								<!--end::Info-->
							</div>
						</div>
						<!--end::Dropzone-->
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button id="lbtn02UploadSave1" type="button" class="btn btn-primary">Upload</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Upload-->
		
		<!--begin::Modal Comment-->
		<asp:UpdatePanel ID="mdl05Comment" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Notes - Add Note</h5>
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
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
							<asp:TextBox ID="tbx05Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
							<asp:HiddenField ID="hdnMention" runat="server" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="lbtn05NoteAdd1(this);">Add</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->
		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfFile" runat="server" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Content-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">  
        
		//function related to this page only
        function lbtn01Refresh1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn01Refresh.ClientID %>");
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
        function lbtn01Status1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn01Status.ClientID %>");
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
        function lbtn01StatusSave1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn01StatusSave.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function lbtn06PRGDtlEdit1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn06PRGDtlEdit.ClientID %>");
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
        function lbtn06PRGDtlSave1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn06PRGDtlSave.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function lbtn02Upload1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn02Upload.ClientID %>");
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
        function lbtn05Add1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn05Add.ClientID %>");
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
        function lbtn05NoteAdd1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= lbtn05NoteAdd.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
		//function related to this page only

		//view gallery
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            loadscript();
        });
        $(document).ready(loadscript);
        function loadscript() {
            var script_tag = document.createElement('script');
            script_tag.src = 'assets/plugins/custom/fslightbox/fslightbox.bundle.js';
            document.head.appendChild(script_tag);
        }
		//view gallery

        //numeric formating
        function FormatNumeric(ID) {
            var NumVal = document.getElementById(ID);
            var Val = parseFloat(NumVal.value);
            var NewVal = Val.toFixed(2);
            var Parts = NewVal.toString().split(".");
            var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
            if (Num == "NaN") {
                Num = "0.00";
            }
            NumVal.value = Num;
        }
        //numeric formating

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
		function InitialiseSettings() {
            //form variable
            var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
			var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
			//form variable

			//general
            jQuery(function ($) {

				//combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

				//mention

				//mention

			});
			//general

			//mention
            jQuery(function ($) {
                //metion                jq.fn.atwho.debug = true;
                var chatHub = jq.connection.chatHub;
                jq.connection.hub.start().done(function () {
                    // mention load
                    loadFunction()
                    //// mention save
                    //jq('.lbtn05AddNote').click(function () {
                    //    // Call the Send method on the hub.
                    //    chatHub.server.send(ltrlFormCode, ltrlID, ltrlFormCode, initialMention.join(','), ltrlCreatedBy);
                    //    // clear
                    //    initialMention = [];
                    //    mentionUser = [];
                    //})
                }).fail(function (error) {
                    console.error("SignalR connection failed: " + error)
                });
                function loadFunction() {
                    chatHub.server.getEmployeeData().then(function (data) {
                        initAtWho(data);
                    }).catch(function (error) {
                        console.error("Error fetching data from SignalR:", error)
                    });
                    function initAtWho(data) {
                        var at_config = {
                            at: "@",
                            data: data,
                            insertTpl: '${fname}',
                            displayTpl: "<li><div class='d-flex align-items-center'><div class='symbol symbol-30px overflow-hidden me-3'><div class='symbol-label'> <img src='Assets/media/avatars/${empPic}' class='w-100' alt='' />  </div></div><div class='d-flex flex-column '><span class='text-weight-500 text-gray-800 '>${name}</span><span class='text-weight-500'>${email}</span></div></div></li>",
                            limit: 200,
                            callbacks: {
                                beforeInsert: function (value, jqli, e) {
                                    var selectedUserData = jqli.data('item-data');
                                    mentionUser.push({
                                        name: selectedUserData.fname,
                                        empCode: selectedUserData.empCode
                                    })
                                    var emp_no = mentionUser.map(function (employee) {
                                        return employee.empCode
                                    });
                                    initialMention = emp_no;
                                    $('#<%=hdnMention.ClientID %>').val(initialMention.join(','));
                                    return '@' + value;
                                },
                            }
                        }
                        $inputor = jq('.mention').atwho(at_config);
                        $inputor.caret('pos', 47);
                        $inputor.focus().atwho('run');
                        // for removing mention
                        $inputor.on('keydown', function (e) {
                            if (e.keyCode === 8) {
                                handleBackspace();
                            }
                        })
                        function handleBackspace() {
                            var inputValue = $inputor.val();
                            var cursorPosition = $inputor.caret('pos');
                            var mentionStart = inputValue.lastIndexOf('@', cursorPosition - 1);

                            if (mentionStart !== -1) {
                                // Extract mention text to be removed
                                var mentionText = inputValue.substring(mentionStart, cursorPosition);

                                // Find and remove mention from mentionUser array
                                mentionUser = mentionUser.filter(function (user) {
                                    return `@${user.name}` !== mentionText;
                                });

                                var emp_no = mentionUser.map(function (employee) {
                                    return employee.empCode
                                });

                                initialMention = emp_no;
                            }
                        }
                    };
                };                //metion
            });
			//mention

			//upload
			jQuery(function ($) {
                Dropzone.autoDiscover = false;
                var myDropzone = new Dropzone("#DropZone", {
                    url: "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + ltrlID.replace("#", "No"),
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        var imgName = response;
                        file.previewElement.classList.add("dz-success");
                        console.log("Successfully uploaded :" + imgName);
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                $('#lbtn02UploadSave1').on('click', function (e) {
                    myDropzone.processQueue();
                    // Perform button
                    var Btn = document.getElementById('lbtn02UploadSave1');
                    // Disable button to avoid multiple click
                    Btn.disabled = true;
                    // Show loading indication
                    // Simulate form submission
                    setTimeout(function () {
                        // Perform button
                        var clickButton = document.getElementById("<%= lbtn02UploadSave.ClientID %>");
                        clickButton.click();
						// Enable button
						Btn.disabled = false;
                    }, 3000);
                });
             });
			//upload
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
