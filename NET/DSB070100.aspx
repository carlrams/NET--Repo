<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB070100.aspx.vb" Inherits="NET.DSB070100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
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
						<li class="breadcrumb-item text-white">Business Tech. Support</li>
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
				<!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<!--begin::Button-->
					<!--begin::Wrapper-->
					<div class="me-4">
						<!--begin::Menu-->
						<a class="btn btn-custom btn-active-white btn-flex btn-color-white btn-active-color-primary fw-bolder pointer" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">Report</a>
						<!--begin::Menu 1-->
						<div class="menu menu-sub menu-sub-dropdown w-200px" data-kt-menu="true">
							<!--begin::Header-->
							<div class="px-7 py-5">
								<div class="fs-5 text-dark fw-bolder">Report Options</div>
							</div>
							<!--end::Header-->
							<!--begin::Menu separator-->
							<div class="separator border-gray-200"></div>
							<!--end::Menu separator-->
							<!--begin::Form-->
							<div class="px-7 py-5">
								<a class="btn btn-sm btn-primary w-100 pointer mb-5" data-kt-menu-dismiss="true" onclick="Report_MyRequest()" >My Ticket</a>
								<a class="btn btn-sm btn-primary w-100 pointer" data-kt-menu-dismiss="true" onclick="Report_MyRequest()" >Status</a>
							</div>
							<!--end::Form-->
						</div>
						<!--end::Menu 1-->
						<!--end::Menu-->
					</div>
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" onclick="Add(this)">Create</a>
					<!--end::Button-->
				</div>
				<!--end::Actions-->
			</div>
			<!--begin::Container-->
            <asp:Button ID="btnAdd" runat="server" Text="Button" OnClick="btnAdd_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnAdd_Ok" runat="server" Text="Button" OnClick="btnAdd_Ok_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnList" runat="server" Text="Button" OnClick="btnList_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnList_Close" runat="server" Text="Button" OnClick="btnList_Close_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnDetail" runat="server" Text="Button" OnClick="btnDetail_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnAccept" runat="server" Text="Button" OnClick="btnAccept_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnAccept_Ok" runat="server" Text="Button" OnClick="btnAccept_Ok_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnChangeStatus" runat="server" Text="Button" OnClick="btnChangeStatus_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnChangeStatus_Ok" runat="server" Text="Button" OnClick="btnChangeStatus_Ok_Click" ClientIDMode="Static" style="display:none;" />
			<asp:Button ID="btnReport_MyRequest" runat="server" Text="Button" OnClick="btnReport_MyRequest_Click" ClientIDMode="Static" style="display:none;" />
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<asp:UpdatePanel ID="upnlSummary" runat="server" UpdateMode="Conditional" class="row gx-5">
		<ContentTemplate>
            <div class="col-md-12 col-xxl-4 mb-5">
				<a class="card card-xxl-stretch pointer" onclick="List('New','')">
					<div class="card-body d-flex flex-column justify-content-between">
						<span class="symbol symbol-40px ms-n1 flex-grow-1">
							<img src="Assets/media/svg/apps/DSB070000_New.svg" alt="" />
						</span>
						<div class="d-flex flex-column">
                            <asp:Label ID="lblNew" runat="server" class="text-dark fw-bolder fs-1 mb-0 mt-5" Text="0"></asp:Label>
							<div class="text-muted fw-bold fs-6">New Ticket</div>
						</div>
					</div>
				</a>
			</div>
            <div class="col-md-6 col-xxl-2 mb-5">
				<a class="card card-xxl-stretch pointer" onclick="List('On-Going','')">
					<div class="card-body d-flex flex-column justify-content-between">
						<span class="symbol symbol-40px ms-n1 flex-grow-1">
							<img src="Assets/media/svg/apps/DSB070000_Ongoing.svg" alt="" />
						</span>
						<div class="d-flex flex-column">
                            <asp:Label ID="lblOngoing" runat="server" class="text-dark fw-bolder fs-1 mb-0 mt-5" Text="0"></asp:Label>
							<div class="text-muted fw-bold fs-6">On-Going</div>
						</div>
					</div>
				</a>
			</div>
            <div class="col-md-6 col-xxl-2 mb-5">
				<a class="card card-xxl-stretch pointer" onclick="List('On-Hold','')">
					<div class="card-body d-flex flex-column justify-content-between">
						<span class="symbol symbol-40px ms-n1 flex-grow-1">
							<img src="Assets/media/svg/apps/DSB070000_Onhold.svg" alt="" />
						</span>
						<div class="d-flex flex-column">
							<asp:Label ID="lblOnhold" runat="server" class="text-dark fw-bolder fs-1 mb-0 mt-5" Text="0"></asp:Label>
							<div class="text-muted fw-bold fs-6">On-Hold</div>
						</div>
					</div>
				</a>
			</div>
			<div class="col-md-6 col-xxl-2 mb-5">
				<a class="card card-xxl-stretch pointer" onclick="List('Not Started','')">
					<div class="card-body d-flex flex-column justify-content-between">
						<span class="symbol symbol-40px ms-n1 flex-grow-1">
							<img src="Assets/media/svg/apps/DSB070000_Notstarted.svg" alt="" />
						</span>
						<div class="d-flex flex-column">
                            <asp:Label ID="lblNotstarted" runat="server" class="text-dark fw-bolder fs-1 mb-0 mt-5" Text="0"></asp:Label>
							<div class="text-muted fw-bold fs-6">Not started</div>
						</div>
					</div>
				</a>
			</div>
			<div class="col-md-6 col-xxl-2 mb-5">
				<a class="card card-xxl-stretch pointer" onclick="List('Complete','')">
					<div class="card-body d-flex flex-column justify-content-between">
						<span class="symbol symbol-40px ms-n1 flex-grow-1">
							<img src="Assets/media/svg/apps/DSB070000_Complete.svg" alt="" />
						</span>
						<div class="d-flex flex-column">
							<asp:Label ID="lblComplete" runat="server" class="text-dark fw-bolder fs-1 mb-0 mt-5" Text="0"></asp:Label>
							<div class="text-muted fw-bold fs-6">Complete</div>
						</div>
					</div>
				</a>
			</div>
        </ContentTemplate>
		</asp:UpdatePanel>

        <!--begin::Row-->
		<asp:UpdatePanel ID="upnlEmployee" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div id="divEmployee" runat="server" class="row gx-5 gy-5"></div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Row-->

		<!--begin::Modal Add -->
		<asp:UpdatePanel ID="mdlAdd" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">
							Create Ticket
						</h5>
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
					</div>
					<div class="modal-body">
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Category</span>
							<asp:DropDownList ID="ddlAdd_Category" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlAdd" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a category</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Task</span>
							<asp:DropDownList ID="ddlAdd_Task" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlAdd" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select a task</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Priority</span>
							<asp:TextBox ID="tbxAdd_Priority" runat="server" class="form-control" ReadOnly="true" Placeholder="Add priority"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Summary</span>
							<asp:TextBox ID="tbxAdd_Summary" runat="server" class="form-control" Placeholder="Add summary"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px required">Remarks</span>
							<asp:TextBox ID="tbxAdd_Remarks" runat="server" class="form-control min-h-75px" Placeholder="Add remarks" TextMode="MultiLine"></asp:TextBox>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Requested By</span>
							<asp:DropDownList ID="ddlAdd_CreatedBy" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlAdd" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select requestor</asp:ListItem>
							</asp:DropDownList>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<a class="btn btn-primary" onclick="Add_Ok(this)">
							Add
						</a>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Add -->
		     		
		<!--begin::Modal List -->
		<asp:UpdatePanel ID="mdlList" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title"><asp:Label ID="lblList_Title" runat="server" Text="Label"></asp:Label></h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" onclick="List_Close()">
							<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
							<!--end::Svg Icon-->
						</div>
					</div>
					<div class="modal-body">
						<div id="divList" runat="server" class="row g-5"></div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal List -->
			
		<!--begin::Modal Detail-->
		<asp:UpdatePanel ID="mdlDetail" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Ticket Detail</h5>
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
						<div id="divDetail" runat="server"></div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Detail-->
		   
        <!--begin::Modal Accept-->
		<asp:UpdatePanel ID="mdlAccept" runat="server" UpdateMode="Conditional" class="modal fade z-index-1057" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
						<p>Accept ticket?</p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
						<a class="btn btn-primary pointer" onclick="Accept_Ok(this);">
							Yes
						</a>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Accept-->
		
		<!--begin::Modal New -->
		<asp:UpdatePanel ID="mdlChangeStatus" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">
							Change Status
						</h5>
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
					</div>
					<div class="modal-body">
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Assign To</span>
							<asp:DropDownList ID="ddlChangeStatus_AssignTo" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlChangeStatus" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select user</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Status</span>
							<asp:DropDownList ID="ddlChangeStatus_Status" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlChangeStatus" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select status</asp:ListItem>
								<asp:ListItem Value="Not Started">Not Started</asp:ListItem>
								<asp:ListItem Value="On-Going">On-Going</asp:ListItem>
								<asp:ListItem Value="On-Hold">On-Hold</asp:ListItem>
								<asp:ListItem Value="Complete">Complete</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">Stage</span>
							<asp:DropDownList ID="ddlChangeStatus_Stage" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlChangeStatus" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
								<asp:ListItem Value="">Select stage</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text input-group-text-top min-w-150px">Notes</span>
							<asp:TextBox ID="tbxChangeStatus_Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<a class="btn btn-primary" onclick="ChangeStatus_Ok(this);">
							Change Status
						</a>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal New -->
		   	
		<!--begin::Modal List -->
		<asp:UpdatePanel ID="mdlReport_MyRequest" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">My Ticket</h5>
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
					</div>
					<div class="modal-body">
						<div id="divReport_MyRequest" runat="server" class="row g-5">

						</div>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal List -->
			  
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfView" runat="server" />
		<asp:HiddenField ID="hfEmpCode" runat="server" />
		<asp:HiddenField ID="hfID" runat="server" />
        <asp:HiddenField ID="hfMention" runat="server" />
		<!--begin::hidden variable-->

	</div>
    	
	<!-- scripts related to this page -->
    <script type="text/javascript">

        //function related to this page only
        function Add(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnAdd.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        function Add_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnAdd_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        function List(View, EmpCode) {
            // Save View
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = View;
            // Save View
            var hfEmpCode = document.getElementById("ContentPlaceHolder1_hfEmpCode");
            hfEmpCode.value = EmpCode;
            // Perform button
            var clickButton = document.getElementById("<%= btnList.ClientID %>");
            clickButton.click();
        };
        function Detail(View, ID) {
            // Save View
            var hfView = document.getElementById("ContentPlaceHolder1_hfView");
            hfView.value = View;
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnDetail.ClientID %>");
            clickButton.click();
        };
        function Accept(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnAccept.ClientID %>");
            clickButton.click();
		};
        function Accept_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnAccept_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function List_Close() {
            // Perform button
            var clickButton = document.getElementById("<%= btnList_Close.ClientID %>");
			clickButton.click();
			// close modal
            $('#ContentPlaceHolder1_mdlList').modal('hide');
        };
        function ChangeStatus(ID) {
            // Save ID
            var hfID = document.getElementById("ContentPlaceHolder1_hfID");
            hfID.value = ID;
            // Perform button
            var clickButton = document.getElementById("<%= btnChangeStatus.ClientID %>");
            clickButton.click();
        };
        function ChangeStatus_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnChangeStatus_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
		};
        function Report_MyRequest() {
            // Perform button
            var clickButton = document.getElementById("<%= btnReport_MyRequest.ClientID %>");
            clickButton.click();
        };
		//function related to this page only

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
			jQuery(function ($) {

                //combobox
                $('[data-kt-repeater="select2"]').select2();
				//combobox

                //menu
                KTMenu.createInstances();
                //menu

                //metion
                jq.fn.atwho.debug = true;
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
                                    $('#<%=hfMention.ClientID %>').val(initialMention.join(','));
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
                };
                //metion

            });
        }
        //load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>
