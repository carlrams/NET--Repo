<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AADRT0001.aspx.vb" Inherits="NET.AADRT0001" %>
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
						<li class="breadcrumb-item text-white">Accounts Administration</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Booked Sales</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

        <!--begin::content-->
        <div id="card01Form" class="card">
		    <!--begin::Beader-->
		    <div class="card-header border-0 py-5">
			    <div class="d-flex align-items-center">
				    <!--begin::Icon-->
				    <div class="symbol symbol-35px me-2">
					    <img src="Assets/media/svg/apps/RPT.svg" alt="" />
				    </div>
				    <!--end::Icon-->
				    <!--begin::Title-->
				    <div class="d-flex flex-column">
						<h3 class="card-title align-items-start flex-column">
						    <span class="card-label fw-bolder text-dark">Booked Sales</span>
					    </h3>
				    </div>
				    <!--end::Title-->
			    </div>
			    <div class="card-toolbar">
                    <div class="d-flex flex-stack">
                        <!--begin::Search-->
					    <div class="position-relative me-1">
						    <!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
						    <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
							    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
								    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
							    </svg>
						    </span>
						    <!--end::Svg Icon-->
						    <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
					    </div>
					    <!--end::Search-->
					    <button class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" onclick="fn01Add(this);" title="Add Record">
						    <span class="indicator-label">
							    <i class="las la-plus fs-2"></i>
						    </span>
						    <span class="indicator-progress">
							    <span class="spinner-border spinner-border-sm align-middle"></span>
						    </span>
					    </button>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light align-self-center m-1" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                        <i class="las la-bars fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
						    <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="fn01Search()">Filter</a>
                            </div>
						    <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="excel">Export as Excel</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="csv">Export as CSV</a>
                            </div>
                            <div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" data-kt-export="pdf">Export as PDF</a>
                            </div>
                        </div>
                        <!--begin::Export buttons-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <!--end::Export buttons-->
                        <!--end::Menu-->
                    </div>
			    </div>
		    </div>
		    <!--end::Header-->
		    <!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                <div class="border rounded" style="min-height:62.3vh;">
                    <table id="table01Report" class="table table-row-bordered gy-2 gs-2 w-100">
                        <thead>
                            <tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
								<th class="min-w-50px mw-50px fw-bold border-end fs-8 nowrap-auto pl-3">Action</th>
                                <th class="min-w-30px mw-30px fw-bold border-end fs-8"><i class="las la-lock fs-3"></i></th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto">Code</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto">Date Generated</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto">Type</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto">Territory</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto">Date From</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto">Date To</th>
                                <th class="min-w-150px mw-150px fw-bold fs-8 nowrap-auto">Prepared By</th>
                            </tr>
                            <tr id="tr01Filter" class="fs-7" style="display:none">
                                <td class="min-w-50px mw-50px fw-bold border-end"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-30px mw-30px fw-bold border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find06" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-100px mw-100px fw-bold border-end"><input id="tbx01Find07" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="min-w-150px mw-150px fw-bold border-end"><input id="tbx01Find08" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                            </tr>
                        </thead>
                        <tbody id="tbody01Report" runat="server">
						
                        </tbody>
                    </table>
		        </div>
				<!--end::Files-->
            </div>
		    <!--end::Card body-->
		</div>
		<!--end::content-->

		<!--begin::Modal Add Record-->
		<asp:UpdatePanel ID="mdlAdd" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Add Record</h5>
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
						<div class="mb-2">
							<asp:DropDownList ID="ddlType"  runat="server"  data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlAdd" class="form-select form-select-sm rounded-start-0 min-h-35px required" >
								<asp:ListItem Value="">Select Type</asp:ListItem>
								<asp:ListItem Value="DOE">DOE</asp:ListItem>
								<asp:ListItem Value="SPM">SPM</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddlTerritory"  runat="server"  data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlAdd" class="form-select form-select-sm rounded-start-0 min-h-35px required" >
								<asp:ListItem Value="">Select Territory</asp:ListItem>
								<asp:ListItem Value="All">All</asp:ListItem>
								<asp:ListItem Value="Quezon">Quezon</asp:ListItem>
								<asp:ListItem Value="Laguna">Laguna</asp:ListItem>
								<asp:ListItem Value="Batangas">Batangas</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<input id="tbxDateFrom" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date From *" />
						</div>
						<div class="mb-2">
							<input id="tbxDateTo" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date To *" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="fn02Add(this);">
							Add
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Add Record-->

		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlDelete" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Delete Record</h5>
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
						<p>Are you sure you want to delete this record?</p>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="fn02Delete(this);">
							Delete
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->

		<!--begin::Modal Edit Record-->
		<asp:UpdatePanel ID="mdlEdit" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Edit Record</h5>
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
						<div class="mb-2">
							<asp:DropDownList ID="ddlEditType"  runat="server"  data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlEdit" class="form-select form-select-sm rounded-start-0 min-h-35px required" >
								<asp:ListItem Value="">Select Type</asp:ListItem>
								<asp:ListItem Value="DOE">DOE</asp:ListItem>
								<asp:ListItem Value="SPM">SPM</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<asp:DropDownList ID="ddlEditTerritory"  runat="server"  data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlEdit" class="form-select form-select-sm rounded-start-0 min-h-35px required" >
								<asp:ListItem Value="">Select Territory</asp:ListItem>
								<asp:ListItem Value="All">All</asp:ListItem>
								<asp:ListItem Value="Quezon">Quezon</asp:ListItem>
								<asp:ListItem Value="Laguna">Laguna</asp:ListItem>
								<asp:ListItem Value="Batangas">Batangas</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="mb-2">
							<input id="tbxEditDateFrom" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date From *" />
						</div>
						<div class="mb-2">
							<input id="tbxEditDateTo" runat="server" type="text" data-kt-repeater="datepicker" class="form-control form-control-sm" readonly Placeholder="Date To *" />
						</div>
					</div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="fn02Edit(this);">
							Edit
						</button>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Edit Record-->

		<!--begin::Modal Lock Record-->
		<asp:UpdatePanel ID="mdlLock" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Lock Record</h5>
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
						<div class="mb-2 flex-nowrap">
							<input id="tbxLockPassword" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="fn02Lock(this);">
							Lock
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal Lock Record-->

		<!--begin::Modal Unock Record-->
		<asp:UpdatePanel ID="mdlUnlock" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Unlock Record</h5>
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
							<div class="mb-2 flex-nowrap">
								<input id="tbxUnlockPassword" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
							</div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							<button class="btn btn-primary" onclick="fn02Unlock(this);">
								Unlock
							</button>
						</div>
					</div>
				</div>
			</ContentTemplate>
			</asp:UpdatePanel>
		<!--begin::Modal Unock Record-->


		
		<!--begin::hidden variable-->
		<asp:HiddenField ID="hfRptCode" runat="server" />
		<!--begin::hidden variable-->

	</div>
	<!--end::Post-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">

        //Search
        function fn01Search() {
            var tr01Header = document.getElementById("tr01Header");
            var tr01Filter = document.getElementById("tr01Filter");
            if (window.getComputedStyle(tr01Filter).display === "none") {
                tr01Header.style.display = "none";
                tr01Filter.style.display = "";
            } else {
                tr01Header.style.display = "";
                tr01Filter.style.display = "none";
            }
        }
        //Search

        //Generate Record
        function fn01Generate(formCode, dateFrom, dateTo, rptCode) {
            const url = `AADRTView?FormCode=${formCode}&pDateFrom=${dateFrom}&pDateTo=${dateTo}&pRptcode=${rptCode}`;
            window.open(url);
        }
        //Generate Record

        //Add Record
        function fn01Add(Btn) {
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

            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Access',
                    'Action': 'Add',
                },
                success: function (response) {
                    var trimmedResponse = $.trim(response);

                    if (trimmedResponse == "0") {
                        Swal.fire({
                            text: 'Access denied!',
                            icon: 'error',
                            buttonsStyling: false,
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });
                    } else {
                        $('#ContentPlaceHolder1_mdlAdd').modal('show');
                    }
                }
            });
        };
        function fn02Add(Btn) {
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);

            var ddlType = document.getElementById("ContentPlaceHolder1_ddlType");
            var ddlTerritory = document.getElementById("ContentPlaceHolder1_ddlTerritory");
            var tbxDateFrom = document.getElementById("ContentPlaceHolder1_tbxDateFrom");
            var tbxDateTo = document.getElementById("ContentPlaceHolder1_tbxDateTo");

            if (
                !ddlType || ddlType.selectedIndex === 0 ||
                !ddlTerritory || ddlTerritory.selectedIndex === 0 ||
                !tbxDateFrom || tbxDateFrom.value.trim() === "" ||
                !tbxDateTo || tbxDateTo.value.trim() === ""
            ) {
                Swal.fire({
                    text: 'Some field/s are missing!',
                    icon: 'error',
                    buttonsStyling: false,
                    confirmButtonText: 'Ok, got it!',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                });
                return;
            }

            var dateFrom = new Date(tbxDateFrom.value);
            var dateTo = new Date(tbxDateTo.value);

            if (dateFrom > dateTo) {
                Swal.fire({
                    text: 'Date To must be greater than or equal to Date From!',
                    icon: 'error',
                    buttonsStyling: false,
                    confirmButtonText: 'Ok, got it!',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                });
                return;
            }

            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Add Record',
                    'ddlType': ddlType.options[ddlType.selectedIndex].value,
                    'ddlTerritory': ddlTerritory.options[ddlTerritory.selectedIndex].value,
                    'DateFrom': tbxDateFrom.value,
                    'DateTo': tbxDateTo.value,
                },
                success: function (response) {
                    var table = $('#table01Report').DataTable();
                    var newRow = table.row.add(response[response.length - 1]).draw(false);

                    //blink
                    $('#table01Report tbody tr').removeClass('row-blink');
                    var rowNode = newRow.node();
                    $(rowNode).addClass('row-blink');

                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });

                    $(rowNode).one('animationend', function () {
                        $(this).removeClass('row-blink');
                    });

                    Swal.fire({
                        text: 'Record successfully added.',
                        icon: 'success',
                        buttonsStyling: false,
                        confirmButtonText: 'Ok, got it!',
                        customClass: {
                            confirmButton: 'btn btn-primary'
                        }
                    });

                    $('#ContentPlaceHolder1_mdlAdd').modal('hide');
                    ddlType.selectedIndex = 0;          
                    ddlType.dispatchEvent(new Event("change"));
                    ddlTerritory.selectedIndex = 0;          
                    ddlTerritory.dispatchEvent(new Event("change"));
                    tbxDateFrom.value = "";
                    tbxDateTo.value = "";
                }
            });
        };
        //Add Record

        //Edit Record
        function fn01Edit(rptCode) {
            var hfRptCode = document.getElementById('<%= hfRptCode.ClientID %>');
            hfRptCode.value = rptCode;

            //Access
            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Access',
                    'Action': 'Save',
                },
                success: function (accessResponse) {
                    var trimmedAccess = $.trim(accessResponse);

                    if (trimmedAccess == "0") {
                        Swal.fire({
                            text: 'Access denied!',
                            icon: 'error',
                            buttonsStyling: false,
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });
                    } else {
                        //Validate
                        $.ajax({
                            type: "POST",
                            url: "HNDRPT.ashx",
                            dataType: "text",
                            data: {
                                'FormCode': 'AADRT0001',
                                'Type': 'Validate',
                                'pTblName': 'Rpt_DSRHdr',
                                'pTblCode': rptCode,
                                'pTblVal': '',
                                'pType': 'Save',
                            },
                            success: function (validateResponse) {
                                var trimmedValidate = $.trim(validateResponse);

                                if (trimmedValidate !== "") {
                                    Swal.fire({
                                        text: trimmedValidate,
                                        icon: 'error',
                                        buttonsStyling: false,
                                        confirmButtonText: 'Ok, got it!',
                                        customClass: {
                                            confirmButton: 'btn btn-danger'
                                        }
                                    });
                                } else {
                                    //Both access and validation passed
                                    $.ajax({
                                        type: "POST",
                                        url: "HNDRPT.ashx",
                                        data: {
                                            'FormCode': 'AADRT0001',
                                            'Type': 'Edit Modal',
                                            'Code': rptCode
                                        },
                                        success: function (response) {

                                            var record = response[0];

                                            $("#ContentPlaceHolder1_ddlEditType").val(record.Type).trigger('change');
                                            $("#ContentPlaceHolder1_ddlEditTerritory").val(record.Division).trigger('change');
                                            $("#ContentPlaceHolder1_tbxEditDateFrom").val(record.DateFrom);
                                            $("#ContentPlaceHolder1_tbxEditDateTo").val(record.DateTo);
                                            $('#ContentPlaceHolder1_mdlEdit').modal('show');
                                        },
                                    });
                                }
                            }
                        });
                    }
                }
            });
        }
        function fn02Edit(Btn) {
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);

            var rptCode = document.getElementById('<%= hfRptCode.ClientID %>').value;
            var ddlEditType = document.getElementById("ContentPlaceHolder1_ddlEditType");
            var ddlEditTerritory = document.getElementById("ContentPlaceHolder1_ddlEditTerritory");
            var tbxEditDateFrom = document.getElementById("ContentPlaceHolder1_tbxEditDateFrom");
            var tbxEditDateTo = document.getElementById("ContentPlaceHolder1_tbxEditDateTo");

            if (
                !ddlEditType || ddlEditType.selectedIndex === 0 ||
                !ddlEditTerritory || ddlEditTerritory.selectedIndex === 0 ||
                !tbxEditDateFrom || tbxEditDateFrom.value.trim() === "" ||
                !tbxEditDateTo || tbxEditDateTo.value.trim() === ""
            ) {
                Swal.fire({
                    text: 'Some field/s are missing!',
                    icon: 'error',
                    buttonsStyling: false,
                    confirmButtonText: 'Ok, got it!',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                });
                return;
            }

            var dateFrom = new Date(tbxEditDateFrom.value);
            var dateTo = new Date(tbxEditDateTo.value);

            if (dateFrom > dateTo) {
                Swal.fire({
                    text: 'Date To must be greater than or equal to Date From!',
                    icon: 'error',
                    buttonsStyling: false,
                    confirmButtonText: 'Ok, got it!',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                });
                return;
            }

            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Edit Record',
                    'Code': rptCode,
                    'ddlType': ddlEditType.options[ddlEditType.selectedIndex].value,
                    'ddlTerritory': ddlEditTerritory.options[ddlEditTerritory.selectedIndex].value,
                    'DateFrom': tbxEditDateFrom.value,
                    'DateTo': tbxEditDateTo.value,
                },
                success: function (response) {
                    var table01 = $('#table01Report').DataTable();
                    var newRecord = response[response.length - 1];

                    var rowIndex = table01.row(function (idx, data) {
                        return data.ID.toString() === rptCode.toString();
                    }).index();

                    if (rowIndex !== undefined) {
                        table01.row(rowIndex).data(newRecord).draw(false);

                        //blink
                        $('#table01Report tbody tr').removeClass('row-blink');
                        var rowNode = table01.row(rowIndex).node();
                        $(rowNode).addClass('row-blink');

                        $(rowNode).one('animationend', function () {
                            $(this).removeClass('row-blink');
                        });
                    }


                    Swal.fire({
                        text: 'Record successfully saved.',
                        icon: 'success',
                        buttonsStyling: false,
                        confirmButtonText: 'Ok, got it!',
                        customClass: {
                            confirmButton: 'btn btn-primary'
                        }
                    });

                    $('#ContentPlaceHolder1_mdlEdit').modal('hide');
                }
            });
        }
        //Edit Record

        //Delete Record
        function fn01Delete(rptCode) {
            var hfRptCode = document.getElementById('<%= hfRptCode.ClientID %>');
            hfRptCode.value = rptCode;

            //Access
            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Access',
                    'Action': 'Delete',
                },
                success: function (accessResponse) {
                    var trimmedAccess = $.trim(accessResponse);

                    if (trimmedAccess == "0") {
                        Swal.fire({
                            text: 'Access denied!',
                            icon: 'error',
                            buttonsStyling: false,
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });
                    } else {
                        //Validate
                        $.ajax({
                            type: "POST",
                            url: "HNDRPT.ashx",
                            dataType: "text",
                            data: {
                                'FormCode': 'AADRT0001',
                                'Type': 'Validate',
                                'pTblName': 'Rpt_DSRHdr',
                                'pTblCode': rptCode,
                                'pTblVal': '',
                                'pType': 'Delete',
                            },
                            success: function (validateResponse) {
                                var trimmedValidate = $.trim(validateResponse);

                                if (trimmedValidate !== "") {
                                    Swal.fire({
                                        text: trimmedValidate,
                                        icon: 'error',
                                        buttonsStyling: false,
                                        confirmButtonText: 'Ok, got it!',
                                        customClass: {
                                            confirmButton: 'btn btn-danger'
                                        }
                                    });
                                } else {
                                    //Both access and validation passed
                                    $('#ContentPlaceHolder1_mdlDelete').modal('show');
                                }
                            }
                        });
                    }
                }
            });
        }
        function fn02Delete(Btn) {
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);

            var rptCode = document.getElementById('<%= hfRptCode.ClientID %>').value;
            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Delete Record',
                    'Code': rptCode
                },
                success: function (response) {
                    var table01 = $('#table01Report').DataTable();
                    table01.rows((i, d) => d.ID.toString() === rptCode.toString()).remove().draw(false);

                    Swal.fire({
                        text: 'Record successfully deleted.',
                        icon: 'success',
                        buttonsStyling: false,
                        confirmButtonText: 'Ok, got it!',
                        customClass: {
                            confirmButton: 'btn btn-primary'
                        }
                    });

                    $('#ContentPlaceHolder1_mdlDelete').modal('hide');
                }
            });
        };
        //Delete Record

        //Lock Record
        function fn01Lock(rptCode) {
            var hfRptCode = document.getElementById('<%= hfRptCode.ClientID %>');
            hfRptCode.value = rptCode;

            //Access
            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Access',
                    'Action': 'Lock',
                },
                success: function (accessResponse) {
                    var trimmedAccess = $.trim(accessResponse);

                    if (trimmedAccess == "0") {
                        Swal.fire({
                            text: 'Access denied!',
                            icon: 'error',
                            buttonsStyling: false,
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });
                    } else {
                        //Validate
                        $.ajax({
                            type: "POST",
                            url: "HNDRPT.ashx",
                            dataType: "text",
                            data: {
                                'FormCode': 'AADRT0001',
                                'Type': 'Validate',
                                'pTblName': 'Rpt_DSRHdr',
                                'pTblCode': rptCode,
                                'pTblVal': '',
                                'pType': 'Lock',
                            },
                            success: function (validateResponse) {
                                var trimmedValidate = $.trim(validateResponse);

                                if (trimmedValidate !== "") {
                                    Swal.fire({
                                        text: trimmedValidate,
                                        icon: 'error',
                                        buttonsStyling: false,
                                        confirmButtonText: 'Ok, got it!',
                                        customClass: {
                                            confirmButton: 'btn btn-danger'
                                        }
                                    });
                                } else {
                                    //Both access and validation passed
                                    $('#ContentPlaceHolder1_mdlLock').modal('show');
                                }
                            }
                        });
                    }
                }
            });
        }
        function fn02Lock(Btn) {
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);

            var tbxLockPassword = document.getElementById("ContentPlaceHolder1_tbxLockPassword");
            var rptCode = document.getElementById('<%= hfRptCode.ClientID %>').value;

            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                dataType: "text",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Check Password',
                    'pPassword': tbxLockPassword.value,
                },
                success: function (validationResult) {
                    if (validationResult !== "Invalid password!") {

                        $.ajax({
                            type: "POST",
                            url: "HNDRPT.ashx",
                            data: {
                                'FormCode': 'AADRT0001',
                                'Type': 'Lock Record',
                                'Code': rptCode,
                            },
                            success: function (response) {
                                var table01 = $('#table01Report').DataTable();
                                var newRecord = response[response.length - 1];

                                var rowIndex = table01.row(function (idx, data) {
                                    return data.ID.toString() === rptCode.toString();
                                }).index();

                                if (rowIndex !== undefined) {
                                    table01.row(rowIndex).data(newRecord).draw(false);

                                    //blink
                                    $('#table01Report tbody tr').removeClass('row-blink');
                                    var rowNode = table01.row(rowIndex).node();
                                    $(rowNode).addClass('row-blink');

                                    $(rowNode).one('animationend', function () {
                                        $(this).removeClass('row-blink');
                                    });
                                }

                                Swal.fire({
                                    text: 'Record successfully locked.',
                                    icon: 'success',
                                    buttonsStyling: false,
                                    confirmButtonText: 'Ok, got it!',
                                    customClass: {
                                        confirmButton: 'btn btn-primary'
                                    }
                                });

                                $('#ContentPlaceHolder1_mdlLock').modal('hide');
                                tbxLockPassword.value = "";

                            }
                        });
                    } else {
                        Swal.fire({
                            text: validationResult,
                            icon: 'error',
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });

                        tbxLockPassword.value = "";
                    }
                }
            });
        }
        //Lock Record

        //Unlock Record
        function fn01Unlock(rptCode) {
            var hfRptCode = document.getElementById('<%= hfRptCode.ClientID %>');
            hfRptCode.value = rptCode;

            //Access
            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Access',
                    'Action': 'Unlock',
                },
                success: function (accessResponse) {
                    var trimmedAccess = $.trim(accessResponse);

                    if (trimmedAccess == "0") {
                        Swal.fire({
                            text: 'Access denied!',
                            icon: 'error',
                            buttonsStyling: false,
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });
                    } else {
                        //Validate
                        $.ajax({
                            type: "POST",
                            url: "HNDRPT.ashx",
                            dataType: "text",
                            data: {
                                'FormCode': 'AADRT0001',
                                'Type': 'Validate',
                                'pTblName': 'Rpt_DSRHdr',
                                'pTblCode': rptCode,
                                'pTblVal': '',
                                'pType': 'Unlock',
                            },
                            success: function (validateResponse) {
                                var trimmedValidate = $.trim(validateResponse);

                                if (trimmedValidate !== "") {
                                    Swal.fire({
                                        text: trimmedValidate,
                                        icon: 'error',
                                        buttonsStyling: false,
                                        confirmButtonText: 'Ok, got it!',
                                        customClass: {
                                            confirmButton: 'btn btn-danger'
                                        }
                                    });
                                } else {
                                    //Both access and validation passed
                                    $('#ContentPlaceHolder1_mdlUnlock').modal('show');
                                }
                            }
                        });
                    }
                }
            });
        }
        function fn02Unlock(Btn) {
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);

            var tbxUnlockPassword = document.getElementById("ContentPlaceHolder1_tbxUnlockPassword");
            var rptCode = document.getElementById('<%= hfRptCode.ClientID %>').value;

            $.ajax({
                type: "POST",
                url: "HNDRPT.ashx",
                dataType: "text",
                data: {
                    'FormCode': 'AADRT0001',
                    'Type': 'Check Password',
                    'pPassword': tbxUnlockPassword.value,
                },
                success: function (validationResult) {
                    if (validationResult !== "Invalid password!") {

                        $.ajax({
                            type: "POST",
                            url: "HNDRPT.ashx",
                            data: {
                                'FormCode': 'AADRT0001',
                                'Type': 'Unlock Record',
                                'Code': rptCode,
                            },
                            success: function (response) {
                                var table01 = $('#table01Report').DataTable();
                                var newRecord = response[response.length - 1];

                                var rowIndex = table01.row(function (idx, data) {
                                    return data.ID.toString() === rptCode.toString();
                                }).index();

                                if (rowIndex !== undefined) {
                                    table01.row(rowIndex).data(newRecord).draw(false);

                                    //blink
                                    $('#table01Report tbody tr').removeClass('row-blink');
                                    var rowNode = table01.row(rowIndex).node();
                                    $(rowNode).addClass('row-blink');

                                    $(rowNode).one('animationend', function () {
                                        $(this).removeClass('row-blink');
                                    });
                                }

                                Swal.fire({
                                    text: 'Record successfully unlocked.',
                                    icon: 'success',
                                    buttonsStyling: false,
                                    confirmButtonText: 'Ok, got it!',
                                    customClass: {
                                        confirmButton: 'btn btn-primary'
                                    }
                                });

                                $('#ContentPlaceHolder1_mdlUnlock').modal('hide');
                                tbxUnlockPassword.value = "";
                            }
                        });
                    } else {
                        Swal.fire({
                            text: validationResult,
                            icon: 'error',
                            confirmButtonText: 'Ok, got it!',
                            customClass: {
                                confirmButton: 'btn btn-danger'
                            }
                        });

                        tbxUnlockPassword.value = "";
                    }
                }
            });
        }
        //Unlock Record

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {

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

                //menu
                KTMenu.createInstances();
                //menu

            });
            //general

            //datatable
            jQuery(function ($) {

                if (isPostBack == false) {

                    $.ajax({
                        type: "POST",
                        url: "HNDRPT.ashx",
                        data: {
                            'FormCode': 'AADRT0001',
                            'Type': 'Access',
                            'Action': 'View',
                        },
                        success: function (response) {
                            var trimmedResponse = $.trim(response);

                            if (trimmedResponse !== "1") {
                                //redirect
                                window.location.href = "MNU000022";
                            } else {
                                //initial load
                                $.ajax({
                                    type: "POST",
                                    url: "HNDRPT.ashx",
                                    data: {
                                        'FormCode': 'AADRT0001',
                                        'Type': 'Display'
                                    },
                                    success: function (response) {
                                        $('#table01Report').DataTable().destroy();
                                        Display(response);
                                    },
                                });
                                function Display(response) {
                                    //disable column type detection
                                    DataTable.types().forEach(type => {
                                        DataTable.type(type, 'detect', () => false);
                                    });
                                    //disable column type detection

                                    //sort date by yyyy/mm/dd
                                    $.fn.dataTable.moment('MM/DD/YYYY');
                                    //sort date by yyyy/mm/dd

                                    //datatable
                                    var table01Report = $("#table01Report").DataTable({
                                        bFilter: true,
                                        bPaginate: false,
                                        bInfo: false,
                                        scrollCollapse: true,
                                        scrollResize: true,
                                        scrollX: true,
                                        scrollY: 100,
                                        paging: false,
                                        lengthChange: false,
                                        select: false,
                                        data: response,
                                        columns: [
                                            { data: 'Action' },
                                            { data: 'Lock' },
                                            { data: 'ID' },
                                            { data: 'DateGenerated' },
                                            { data: 'Type' },
                                            { data: 'Division' },
                                            { data: 'DateFrom' },
                                            { data: 'DateTo' },
                                            { data: 'AuditUser' }],
                                        rowId: 'ID',
                                        order: [],
                                        columnDefs: [
                                            {
                                                targets: 0,
                                                orderable: false,
                                                searchable: false,
                                            },
                                            {
                                                targets: 1,
                                                render: function (data, type, row) {
                                                    if (type === 'display') {
                                                        return "<div class='form-check form-check-sm form-check-custom form-check-solid'>" +
                                                            "<input class='form-check-input' type='checkbox' " +
                                                            (data == 1 ? "checked " : "") +
                                                            "onclick='return false;' style='width: 18px; height: 18px;' />" +
                                                            "</div>";
                                                    }
                                                    return data;
                                                }
                                            },
                                            {
                                                targets: 8,
                                                className: 'tbody-nowrap-150px'
                                            }
                                        ],
                                        orderCellsTop: true
                                    });
                                    //datatable

                                    //search
                                    $('#tbx01Find').on('keyup', function () {
                                        table01Report.search(this.value).draw();
                                    });
                                    //search

                                    //filter
                                    $('#tbx01Find01').on('keyup', function () {
                                        table01Report.columns(1).search(this.value).draw();
                                    });
                                    $('#tbx01Find02').on('keyup', function () {
                                        table01Report.columns(2).search(this.value).draw();
                                    });
                                    $('#tbx01Find03').on('keyup', function () {
                                        table01Report.columns(3).search(this.value).draw();
                                    });
                                    $('#tbx01Find04').on('keyup', function () {
                                        table01Report.columns(4).search(this.value).draw();
                                    });
                                    $('#tbx01Find05').on('keyup', function () {
                                        table01Report.columns(5).search(this.value).draw();
                                    });
                                    $('#tbx01Find06').on('keyup', function () {
                                        table01Report.columns(6).search(this.value).draw();
                                    });
                                    $('#tbx01Find07').on('keyup', function () {
                                        table01Report.columns(7).search(this.value).draw();
                                    });
                                    $('#tbx01Find08').on('keyup', function () {
                                        table01Report.columns(8).search(this.value).draw();
                                    });
                                    //filter

                                    //export
                                    const documentTitle = 'Booked Sales';
                                    var buttons = new $.fn.dataTable.Buttons(table01Report, {
                                        buttons: [
                                            {
                                                extend: 'copyHtml5',
                                                title: documentTitle,
                                                exportOptions: {
                                                    columns: [2, 3, 4, 5, 6, 7, 8]
                                                }
                                            },
                                            {
                                                extend: 'excelHtml5',
                                                title: documentTitle,
                                                exportOptions: {
                                                    columns: [2, 3, 4, 5, 6, 7, 8]
                                                }
                                            },
                                            {
                                                extend: 'csvHtml5',
                                                title: documentTitle,
                                                exportOptions: {
                                                    columns: [2, 3, 4, 5, 6, 7, 8]
                                                }
                                            },
                                            {
                                                extend: 'pdfHtml5',
                                                title: documentTitle,
                                                exportOptions: {
                                                    columns: [2, 3, 4, 5, 6, 7, 8]
                                                }
                                            }
                                        ]
                                    }).container().appendTo($('#div01ExportButton'));
                                    // Hook dropdown menu click event to datatable export buttons
                                    const exportButtons = document.querySelectorAll('#div01ExportMenu [data-kt-export]');
                                    exportButtons.forEach(exportButton => {
                                        exportButton.addEventListener('click', e => {
                                            e.preventDefault();

                                            // Get clicked export value
                                            const exportValue = e.target.getAttribute('data-kt-export');
                                            const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                                            // Trigger click event on hidden datatable export buttons
                                            target.click();
                                        });
                                    });
                                    //export

                                }
                                //initial load
                            }
                        }
                    });

                }                //stop loading
                isPostBack = true;
                //stop loading            });
            //datatable

        }
        //load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>