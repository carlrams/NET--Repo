<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="WRK010100.aspx.vb" Inherits="NET.WRK010100" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item"><a href="WRK010000" class="text-white opacity-75">Work Order</a></li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Detail</li>
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

		<!--begin::Title-->
		<asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional" class="card card-flush mb-5 ">
		<ContentTemplate>
			<!--begin::title-->
			<div class="card-header pt-10">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
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
							<a class="nav-link text-active-primary me-1 position-relative" title="Files" data-bs-toggle="tab" href="#Menu02_TabContent">
								<i class="las la-paperclip fs-3x"></i>
								<span id="blink01Attachment" runat="server" class="bullet bullet-dot bg-warning h-8px w-8px position-absolute translate-middle top-10 start-50 animation-blink" style="display:none"></span>
							</a>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1 position-relative" title="Notes" data-bs-toggle="tab" href="#Menu05_TabContent">
								<i class="las la-comment fs-3x"></i>
								<span id="blink01Notes" runat="server" class="bullet bullet-dot bg-warning h-8px w-8px position-absolute translate-middle top-10 start-50 animation-blink" style="display:none"></span>
							</a>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1" title="Approval Path" data-bs-toggle="tab" href="#Menu04_TabContent"><i class="las la-users fs-3x"></i></a>
						</li>
						<!--end::Nav item-->
						<!--begin::Nav item-->
						<li class="nav-item">
							<a class="nav-link text-active-primary me-1" title="Subscribers" data-bs-toggle="tab" href="#Menu03_TabContent"><i class="las la-user-friends fs-3x"></i></a>
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
					<!--begin::Menu Content-->
					<asp:UpdatePanel ID="upnl01Overview" runat="server" UpdateMode="Conditional">
					<ContentTemplate>
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
								<asp:LinkButton ID="lbtn01Find" runat="server" ToolTip="Find record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-search fs-2"></i></asp:LinkButton>
								<asp:LinkButton ID="lbtn01Refresh" runat="server" ToolTip="Refresh record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-redo-alt fs-2"></i></asp:LinkButton>
								<span class="pt-8"><i class="las la-ellipsis-v fs-2"></i></span>
								<asp:LinkButton ID="lbtn01Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-plus fs-2"></i></asp:LinkButton>
								<asp:LinkButton ID="lbtn01Delete" runat="server" ToolTip="Delete record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-trash fs-2"></i></asp:LinkButton>
								<asp:LinkButton ID="lbtn01Edit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
								<span class="pt-8"><i class="las la-ellipsis-v fs-2"></i></span>
								<asp:LinkButton ID="lbtn01Status" runat="server" ToolTip="Change Status" class="btn btn-sm btn-icon btn-secondary align-self-center m-1"><i class="las la-flag fs-2"></i></asp:LinkButton>
								<asp:LinkButton ID="lbtn01Print" runat="server" ToolTip="Print" class="btn btn-sm btn-icon btn-secondary align-self-center m-1"><i class="las la-print fs-2"></i></asp:LinkButton>
							</div>
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<!--begin::Edit-->
							<asp:Panel ID="pnl01Edit" runat="server" Visible="false">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">ID</span>
									<asp:TextBox ID="tbx01ID" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Type</span>
									<asp:TextBox ID="tbx01FormType" runat="server" class="form-control" ReadOnly="true">Business Tech. Support</asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Requested</span>
									<asp:TextBox ID="tbx01DateRequested" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Date Required</span>
									<input id="tbx01DateRequired" runat="server" type="text" data-kt-repeater="datepicker" class="form-control" readonly Placeholder="Pick a date" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Requested By</span>
									<asp:TextBox ID="tbx01RequestedBy" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Assigned To</span>
									<asp:TextBox ID="tbx01AssignedTo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Endorsed To</span>
									<asp:TextBox ID="tbx01EndorsedTo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:TextBox ID="tbx01Status" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
								</div>
								<!--end::separator-->
								<div class="separator separator-dashed my-6"></div>
								<!--begin::separator-->
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Category</span>
									<asp:DropDownList ID="ddl01Category" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddl01Category(this)">
										<asp:ListItem Value="">Select a category</asp:ListItem>
									</asp:DropDownList>
									<asp:HiddenField ID="hf01Category" runat="server" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Project</span>
									<asp:DropDownList ID="ddl01Project" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" onchange="ddl01Project(this)">
										<asp:ListItem Value="">Select a project</asp:ListItem>
									</asp:DropDownList>
									<asp:HiddenField ID="hf01Project" runat="server" />
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Priority</span>
									<asp:DropDownList ID="ddl01Priority" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px">
										<asp:ListItem Value="">Select a priority</asp:ListItem>
										<asp:ListItem>Low</asp:ListItem>
                                        <asp:ListItem>Normal</asp:ListItem>
                                        <asp:ListItem>High</asp:ListItem>
									</asp:DropDownList>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Summary</span>
									<asp:TextBox ID="tbx01Summary" runat="server" class="form-control" Placeholder="Add summary"></asp:TextBox>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text input-group-text-top min-w-150px required">Description</span>
									<asp:TextBox ID="tbx01Description" runat="server" class="form-control min-h-75px" Placeholder="Add remarks" TextMode="MultiLine"></asp:TextBox>
								</div>
							</asp:Panel>
							<!--end::Edit-->
							<!--begin::Dtl-->
							<asp:Panel ID="pnl01Dtl" runat="server" Visible="false">
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">ID</span>
									<asp:Label ID="lbl01ID" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Type</span>
									<asp:Label ID="lbl01FormType" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Requested</span>
									<asp:Label ID="lbl01DateRequested" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Date Required</span>
									<asp:Label ID="lbl01DateRequired" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Requested By</span>
									<asp:Label ID="lbl01RequestedBy" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Assigned To</span>
									<asp:Label ID="lbl01AssignedTo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Endorsed To</span>
									<asp:Label ID="lbl01EndorsedTo" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Status</span>
									<asp:Label ID="lbl01Status" runat="server" class="form-control">-</asp:Label>
								</div>
								<!--begin::Separator-->
								<div class="separator separator-dashed my-6"></div>
								<!--end::Separator-->
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Category</span>
									<asp:Label ID="lbl01Category" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Project</span>
									<asp:Label ID="lbl01Project" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Priority</span>
									<asp:Label ID="lbl01Priority" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px">Summary</span>
									<asp:Label ID="lbl01Summary" runat="server" class="form-control">-</asp:Label>
								</div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text input-group-text-top min-w-150px">Description</span>
									<asp:TextBox ID="lbl01Description" runat="server" class="form-control min-h-75px" Placeholder="Add remarks" TextMode="MultiLine" ReadOnly="true">-</asp:TextBox>
								</div>
							</asp:Panel>
							<!--end::Dtl-->
						</div>
					</ContentTemplate>
					</asp:UpdatePanel>
					<!--end::Menu Content-->
				</div>
				<div class="tab-pane fade" id="Menu02_TabContent">
					<!--begin::Menu Content-->
					<asp:UpdatePanel ID="upnl02Files" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
					<ContentTemplate>
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
								<asp:LinkButton ID="lbtn02Upload" runat="server" ToolTip="Upload file" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-upload fs-2"></i></asp:LinkButton>
							</div>
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<!--begin::Files-->
							<div class="table-responsive">
								<asp:GridView ID="gv02Files" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Action">
										<ItemTemplate>
											<div class="d-flex ">
												<asp:LinkButton ID="lbtn02Delete" runat="server" class="btn btn-sm btn-icon btn-active-success mr-5" CommandArgument='<%# Bind("Name") %>' ToolTip="Remove file" OnClick="lbtn02Delete"><i class="las la-trash fs-3"></i></asp:LinkButton>
												<asp:LinkButton ID="lbtn02Download" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("Name") %>' ToolTip="Download file" OnClick="lbtn02Download"><i class="las la-download fs-3"></i></asp:LinkButton>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark" />
										<ItemStyle CssClass=" align-middle" />
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
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px w-100" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							<!--end::Files-->
						</div>
					</div>
					<!--end::Menu Content-->
					</ContentTemplate>
					</asp:UpdatePanel>
				</div>
				<div class="tab-pane fade" id="Menu03_TabContent">
					<!--begin::Menu Content-->
					<asp:UpdatePanel ID="upnl03Subscribers" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
					<ContentTemplate>
						<!--begin::Card header-->
						<div class="card-header">
							<!--begin::Card header-->
							<div class="card-title fs-3 fw-bolder">Subscribers</div>
							<!--end::Card header-->
						</div>
						<!--end::Card header-->
						<!--begin::Card header-->
						<div class="card-header">
							<div class="d-flex">
								<asp:LinkButton ID="lbtn03Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-user-plus fs-2"></i></asp:LinkButton>
							</div>
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<!--begin::ID-->
							<div class="table-responsive">
								<asp:GridView ID="gv03Subscribers" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class="bullet bullet-margin bullet-vertical h-58px bg-secondary"></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Action">
										<ItemTemplate>
											<div class="d-flex">
												<asp:LinkButton ID="lbtn03Delete" runat="server" class="btn btn-sm btn-icon btn-active-success" CommandArgument='<%# Bind("SeqNo") %>' OnClick="lbtn03Delete"><i class="las la-trash fs-3"></i></asp:LinkButton>
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark" />
										<ItemStyle CssClass=" align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="User">
										<ItemTemplate>
											<div class="d-flex align-items-center">
												<!--begin:: Avatar -->
												<div class="symbol symbol-30px overflow-hidden me-3">
													<div class="symbol-label">
														<img alt="" class="w-100" src="<%# Eval("Icon") %>" />
													</div>
												</div>
												<!--end::Avatar-->
												<!--begin::User details-->
												<div class="d-flex flex-column">
													<span class="fw-bold text-dark"><%# Eval("Approver") %></span>
													<span class="text-muted"><%# Eval("JobDesc") %></span>
												</div>
												<!--begin::User details-->
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px w-100" />
										<ItemStyle CssClass="align-middle" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							<!--end::ID-->
						</div>
					</ContentTemplate>
					</asp:UpdatePanel>
					<!--end::Menu Content-->
				</div>
				<div class="tab-pane fade" id="Menu04_TabContent">
					<!--begin::Menu Content-->
					<asp:UpdatePanel ID="upnl04ApprovalPath" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
					<ContentTemplate>
						<!--begin::Card header-->
						<div class="card-header">
							<!--begin::Card header-->
							<div class="card-title fs-3 fw-bolder">Approval Path</div>
							<!--end::Card header-->
						</div>
						<!--end::Card header-->
						<div class="card-body">
							<!--begin::ID-->
							<div class="table-responsive">
								<asp:GridView ID="gv04ApprovalPath" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<span class='<%# Eval("Bullet") %>'></span>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Type">
										<ItemTemplate>
											<%# Eval("Type") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px" />
										<ItemStyle CssClass=" align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="User">
										<ItemTemplate>
											<div class="d-flex align-items-center">
												<!--begin:: Avatar -->
												<div class="symbol symbol-30px overflow-hidden me-3">
													<div class="symbol-label">
														<img alt="" class="w-100" src="<%# Eval("Icon") %>" />
													</div>
												</div>
												<!--end::Avatar-->
												<!--begin::User details-->
												<div class="d-flex flex-column">
													<span class="fw-bold text-dark"><%# Eval("Approver") %></span>
													<span class="text-muted"><%# Eval("JobDesc") %></span>
												</div>
												<!--begin::User details-->
											</div>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px w-50" />
										<ItemStyle CssClass=" align-middle " />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Status">
										<ItemTemplate>
											<%# Eval("Status") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px" />
										<ItemStyle CssClass=" align-middle" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Reason for delay">
										<ItemTemplate>
											<%# Eval("Reason") %>
										</ItemTemplate>
										<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-300px w-50" />
										<ItemStyle CssClass=" align-middle" />
									</asp:TemplateField>
								</Columns>
								</asp:GridView>
							</div>
							<!--end::ID-->
						</div>
					</ContentTemplate>
					</asp:UpdatePanel>
					<!--end::Menu Content-->
				</div>
				<div class="tab-pane fade" id="Menu05_TabContent">
					<!--begin::Menu Content-->
					<asp:UpdatePanel ID="upnl05Notes" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
					<ContentTemplate>
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
								<asp:LinkButton ID="lbtn05Add" runat="server" ToolTip="Add note" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-comment fs-2"></i></asp:LinkButton>
							</div>
						</div>
						<!--end::Card header-->
						<div class="card-body">
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
							<!--end::ID-->
						</div>
					</ContentTemplate>
					</asp:UpdatePanel>
					<!--end::Menu Content-->
				</div>
			</div>
			<!--end:  Content-->
		</div>
		<!--end::Content-->
		
		<!--begin::Modal Find-->
		<asp:UpdatePanel ID="mdl01Find" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered modal-xl" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Find record</h5>
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
						<!--begin::toolbar-->
						<div class="d-flex flex-stack align-items-center me-5">
							<!--begin::Search-->
							<div class="d-flex align-items-center position-relative my-1">
								<span class="svg-icon svg-icon-2 position-absolute left-20">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor"/>
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor"/>
									</svg>
								</span>
								<input id="tbx01Find" type="text" class="form-control form-control-solid w-250px ps-15" placeholder="Search Record"/>	
							</div>
							<!--end::Search-->
						</div>
						<!--end::toolbar-->
						<!--begin::gridview-->
						<asp:GridView ID="gv01Find" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" >
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<span class="bullet bullet-margin bullet-vertical h-40px bg-secondary"></span>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="ID">
									<ItemTemplate>
										<a href='<%# Eval("Link") %>' class="pointer">
											<%# Eval("ID") %>
										</a>
									</ItemTemplate>
									<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Status">
									<ItemTemplate>
										<%# Eval("Status") %>
									</ItemTemplate>
									<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-100px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Requested By">
									<ItemTemplate>
										<span class="nowrap-150px"><%# Eval("RequestedBy") %></span> 
									</ItemTemplate>
									<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Assigned To">
									<ItemTemplate>
										<span class="nowrap-150px"><%# Eval("AssignedTo") %></span> 
									</ItemTemplate>
									<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-150px" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Description">
									<ItemTemplate>
										<%# Eval("Description") %><
									</ItemTemplate>
									<HeaderStyle CssClass="fw-bold fs-6 text-dark min-w-400px" />
									<ItemStyle CssClass="nowrap-400px" />
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
						<!--end::gridview-->
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Find-->
		
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
								<asp:ListItem Value="">Select a status</asp:ListItem>
								<asp:ListItem Value="Assigned">Assign</asp:ListItem>
                                <asp:ListItem Value="Accepted">Accept</asp:ListItem>
                                <asp:ListItem Value="Clarify">Clarify</asp:ListItem>
                                <asp:ListItem Value="Completed">Complete</asp:ListItem>
                                <asp:ListItem Value="Closed">Close</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Change status to</span>
							<asp:DropDownList ID="ddl01AssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl01Status" class="form-select form-select-sm form-select-border min-h-35px">
								<asp:ListItem Value="">Select a user</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px required">Notes</span>
							<asp:TextBox ID="tbx01Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add extra details" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtn01SaveStatus" runat="server" class="btn btn-primary">Save changes</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
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
						<asp:LinkButton ID="lbtn02CloseUpload" runat="server" Cssclass="btn btn-sm btn-icon btn-sm btn-active-light-primary ms-2">
							<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</asp:LinkButton>
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
						<!--begin::Actions-->
						<div class="modal-footer">
							<asp:LinkButton ID="lbtn02CancelUpload" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
							<button id="lbtn02SaveUpload" type="button" class="btn btn-primary">Upload</button>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Upload-->
		
		<!--begin::Modal Subscribers-->
		<asp:UpdatePanel ID="mdl03User" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Subscribers - Add User</h5>
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
							<span class="input-group-text min-w-150px required">User</span>
							<asp:DropDownList ID="ddl03User" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdl03User" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a user</asp:ListItem>
							</asp:DropDownList>
						</div>
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtn03AddUser" runat="server" class="btn btn-primary">Add</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Subscribers-->
	
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
						<!--begin::Actions-->
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<asp:LinkButton ID="lbtn05AddNote" runat="server" class="btn btn-primary lbtn05AddNote">Add</asp:LinkButton>
						</div>
						<!--end::Actions-->
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Comment-->

	</div>
	<!--end::Content-->

	<!-- scripts related to this page -->
    <script type="text/javascript">  
		//function related to this page only
        function ddl01Category(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].value;

            var hf01Category = document.getElementById("ContentPlaceHolder1_hf01Category");
            hf01Category.value = selectValue;

            $.ajax({
                type: 'GET',
                url: 'HND000003.ashx',
                data: {
                    'FormCode': 'FRM000010',
                    'Type': 'Get Project',
                    'Category': selectValue
                },
                dataType: 'json',
                success: function (response) {
                    var ddl01Project = document.getElementById("ContentPlaceHolder1_ddl01Project");
                    ddl01Project.innerHTML = "";
                    let Option = "";
                    for (var i = 0; i < response.length; i++) {
                        Option += "<option value='" + response[i].Value + "'>" + response[i].Text + "</option>";
                    }
                    ddl01Project.innerHTML = Option;
                }
            });

		}
        function ddl01Project(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].value;

            var hf01Project = document.getElementById("ContentPlaceHolder1_hf01Project");
            hf01Project.value = selectValue;
        }
		//function related to this page only

        //fix for fixed column header
        $(function () {
            $('#ContentPlaceHolder1_mdl01Find').on('shown.bs.modal', function () {
                //datatable
                var gv01Find = $("#ContentPlaceHolder1_gv01Find").DataTable({
                    scrollY: "300px",
                    scrollX: true,
                    scrollCollapse: true,
                    bLengthChange: true,
                    lengthMenu: [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
                    bSort: false,
                    bDestroy: true,
                    fixedColumns: {
                        left: 2
                    },
                    select: true
                });
                //datatable

                //search
                $('#tbx01Find').on('keyup', function () {
                    gv01Find.search(this.value).draw();
                });
                //search
            });
        });
        //fix for fixed column header

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
            jQuery(function ($) {

                //form variable
                var ltrlFormCode = '<asp:Literal ID="ltrlFormCode" runat="server" />';
                var ltrlID = '<asp:Literal ID="ltrlID" runat="server" />';
                var ltrlMode = '<asp:Literal ID="ltrlMode" runat="server" />';
                var ltrlSeqNo = '<asp:Literal ID="ltrlSeqNo" runat="server" />';
                //form variable

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

                //combobox
                $('[data-kt-repeater="select2"]').select2();
                //combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
                });
                //date

                //datatable
                var gv01Find = $("#ContentPlaceHolder1_gv01Find").DataTable({
                    scrollY: "300px",
                    scrollX: true,
                    scrollCollapse: true,
                    bLengthChange: true,
                    lengthMenu: [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
                    bSort: false,
                    bDestroy: true,
                    fixedColumns: {
                        left: 2
                    },
                    select: true
                });
                //datatable

                //search
                $('#tbx01Find').on('keyup', function () {
                    gv01Find.search(this.value).draw();
                });
                //search

                //upload
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
                $('#lbtn02SaveUpload').on('click', function (e) {
                    myDropzone.processQueue();
                });
                //upload
            });
        }
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
