<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="PMD020000.aspx.vb" Inherits="NET.PMD020000" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           
    <!--content-->
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
						<li class="breadcrumb-item text-white">Property Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Electricity Billing and Reading</li>
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
		<asp:Button ID="lbtnFLT" runat="server" Text="Button" OnClick="lbtnFLT_Click" ClientIDMode="Static" Style="display: none;" />
		<!--begin::Card-->
        <div id="card01Form" class="card mb-5">
			<!--begin::Beader-->
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/FRM010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Electricity Billing and Reading</span>
						</h3>
					</div>
					<!--end::Title-->
				</div>
			    <div class="card-toolbar">
                    <div class="d-flex flex-stack">
                        <!--begin::Search-->
					    <div class="position-relative me-2">
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
                        <!--begin::Export buttons-->
                        <div id="div01ExportButton" class="d-none"></div>
                        <!--end::Export buttons-->
                        <!--Filter-->
						 <!--Filter-->
						  <!--begin::Menu-->
						<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2" title="Filter" onclick="lbtnFLTShow(this);">
							<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
						   <i class="las la-filter fs-3"></i>
							<!--end::Svg Icon-->
						</button>
						<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" title="Options">
							<!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
						   <i class="las la-bars fs-3"></i>
							<!--end::Svg Icon-->
						</button>
                        <div id="div01ExportMenu" class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-300px py-4" data-kt-menu="true">
							<div class="menu-item px-3">
                                <a href="#" class="menu-link px-3" onclick="btn01Filter()">Filter</a>
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
                        <!--end::Menu-->
                    </div>
			    </div>
		    </div>
		    <!--end::Header-->
			<!--begin::Card body-->
			<div class="card-body pt-0 mt-0">
				<!--begin::Files-->
                 <div class="border rounded" style="height:62.3vh;">
					
                    <table id="gv01Form" class="table table-row-bordered gy-2 gs-2 w-100">
                        <thead>
							
						  <tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
							  <th id="th01Code" class="min-w-90px fw-bold align-middle border-end" rowspan="2">Code</th>
							  <th class="min-w-20px w-10px fw-bold align-middle border-end " style="width:10px;" rowspan="2"><i class="las la-tag fs-1"></></i></th>
							  <th id="th01Connection" class="min-w-250px fw-bold align-middle border-end" rowspan="2" >Connection</th>
							  <th colspan="2" class="min-w-100px fw-bold text-center border-end">Date</th>
								<th colspan="2" class="min-w-100px fw-bold text-center border-end">Billing Period</th>
						 </tr>
						 <tr id="tr02Header" class="fw-bold fs-7 text-gray-800">
							<th id="th01Issue" class="min-w-50px fw-bold text-center border-end ">Issue</th>
							 <th id="th01Due" class="min-w-50px fw-bold text-center border-end ">Due</th>
							 <th id="th01From" class="min-w-50px fw-bold text-center border-end ">From</th>
							 <th id="th01To" class="min-w-50px fw-bold text-center border-end ">To</th>
							 
						</tr>
						 <tr id="tr01Filter" class="fs-7" style="display:none">
							  <td class="border-end"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							  <td class="border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							  <td class="border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							  <td class="border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							  <td class="border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							  <td class="border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
							  <td class="border-end"><input id="tbx01Find06" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>

							</tr>
                        </thead>

                      <tbody>
						  <%For Each dr As Data.DataRow In Me.FormDataSet.Tables(0).Rows%>
							<tr>
								<%For Each dc As Data.DataColumn In Me.FormDataSet.Tables(0).Columns%>
									<td>
											<%=dr(dc.ColumnName)%>
									</td>
								<% Next%>
							</tr>
						<% Next%>
						  </tbody>
						
                    </table>
				
                </div>
				<!--end::Files-->
            </div>
			<!--end::Card body-->
		</div>
		<!--end::Card-->

        <!--begin::Modal New Form-->
		 <asp:UpdatePanel ID="mdlFLT" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			 <ContentTemplate>
				 <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
					 <div class="modal-content">
						 <div class="modal-header">
							 <h5 class="modal-title">Filter</h5>
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
							 <div class="form-control form-control-sm form-check form-check-custom form-check-solid form-check-sm mb-2" style="padding-left: 5px">
								 <input id="cbxFLT" runat="server" class="form-check-input" type="checkbox" value="0" />
								 <label class="form-check-label" for="ContentPlaceHolder1_cbxFLT">
									 Posted
								 </label>
							 </div>
							 <div class="input-group input-group-sm mb-2 flex-nowrap">
								 <span class="input-group-text min-w-150px required">Connection</span>
								 <asp:DropDownList ID="ddlAdd_Connection" runat="server" data-kt-repeater="select2" data-dropdown-parent="#ContentPlaceHolder1_mdlFLT" class="form-select form-select-transparent form-select-sm min-h-35px">
								 </asp:DropDownList>
							 </div>
						 </div>
						 <!--begin::Actions-->
						 <div class="modal-footer">
							 <button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
							 <button class="btn btn-primary" onclick="lbtnFLTFilter(this);">
								 Filter
							 </button>
						 </div>
						 <!--end::Actions-->
					 </div>
				 </div>
			 </ContentTemplate>
		 </asp:UpdatePanel>
		 <!--End::Modal New Form-->

		 <!--begin::Modal New Form-->
		<div id="mdl02FRM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_GEN()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/GEN.svg" a]lt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">General</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_PDD()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/PDD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Project Development</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_ENG()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/ENG.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Engineering</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_SLS()">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/SLS.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_AAD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/AAD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Accounts Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_FIN()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/FIN.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Finance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_SCM()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/SCM.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Supply Chain Management</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_HRA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/HRA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Human Resources Administration</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_CSD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/CSD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Service</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_BTD()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/BTD.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech.</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a class="text-gray-800 d-flex flex-column pointer" onclick="FRM_ILA()">
											<div class="symbol symbol-50px mb-2">
												<img src="Assets/media/svg/apps/ILA.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Investment and Land Acquisition</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Forms</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form-->

		<!--begin::Modal New Form > GEN-->
		<div id="mdl02FRM_GEN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > General</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000001-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000037-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000001.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Work Order (Contract)</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > GEN-->

		<!--begin::Modal New Form > PDD-->
		<div id="mdl02FRM_PDD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Project Development</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000027-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000027.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">TCT Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > PDD-->
		
		<!--begin::Modal New Form > ENG-->
		<div id="mdl02FRM_ENG" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Engineering</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000019-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000019.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Approval</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000020-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000020.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request For Information</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000021-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000021.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Site Instruction</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000036-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000036.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Survey Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000038-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000038.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Notice of Delay</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000039-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000039.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Non Conformance Report</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000022-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000022.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Construction Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000023-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000023.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Electrical Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000024-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000024.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Request for RFO Keys</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000013-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000013.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Occupancy Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000025-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000025.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Water Service Connection</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > ENG-->
		
		<!--begin::Modal New Form > SLS-->
		<div id="mdl02FRM_SLS" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Sales</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000028-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000028.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Lot Clearance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000029-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000029.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Sales Request Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > SLS-->
		
		<!--begin::Modal New Form > AAD-->
		<div id="mdl02FRM_AAD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Accounts Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000030-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000030.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Account Activity Advice</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000031-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000031.svg" alt="" />
											</div>
											<div class="fs-6 fw-bolder mb-2">Cash Remittance Verification Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000032-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000032.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transfer of Title Routing Slip</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > AAD-->
		
		<!--begin::Modal New Form > FIN-->
		<div id="mdl02FRM_FIN" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Finance</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000018-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000018.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Capital Expenditure Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000015-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000015.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Cash Advance</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000033-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000033.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Billing</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000017-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000017.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Payment Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000016-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000016.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Petty Cash</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > FIN-->
		
		<!--begin::Modal New Form > SCM-->
		<div id="mdl02FRM_SCM" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Supply Chain Management</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000009-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000009.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Contract Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000010-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Purchase Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > SCM-->
		
		<!--begin::Modal New Form > HRA-->
		<div id="mdl02FRM_HRA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Human Resources Administration</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000003-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000003.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Off</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000004-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000004.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Change Shift</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000005-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000005.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Leave of Absence</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000006-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000006.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Out of Office Work</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000007-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000007.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Undertime</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000007-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000008.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Training Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000034-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000034.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Job Order</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000035-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000035.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Conference Room Reservation</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > HRA-->
		
		<!--begin::Modal New Form > CSD-->
		<div id="mdl02FRM_CSD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Customer Service</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000011-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000011.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Customer Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000012-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000012.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Service Request</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
							<div class="col-lg-2 col-md-3 col-sm-6 mr-auto">
								<div class="card h-100">
									<div class="card-body d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000014-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000014.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Transaction Log</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > CSD-->
		
		<!--begin::Modal New Form > BTD-->
		<div id="mdl02FRM_BTD" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Business Tech.</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000002-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000002.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Business Tech. Support</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > BTD-->
		
		<!--begin::Modal New Form > ILA-->
		<div id="mdl02FRM_ILA" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Form > Investment and Land Acquisition</h5>
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
					<div class="modal-body scroll">
						<div class="row">
							<div class="col-lg-2 col-md-3 col-sm-6 ml-auto mr-auto">
								<div class="card h-100">
									<div class="card-FRM000008 d-flex justify-content-center text-center flex-column p-8">
										<a href="FRM000026-ADD-0000000000000" class="text-gray-800 d-flex flex-column">
											<div class="symbol symbol-60px mb-5">
												<img src="Assets/media/svg/apps/FRM000026.svg" alt="" />
											</div>
											<div class="fs-5 fw-bolder mb-2">Rawland Documents Turn-over</div>
										</a>
										<div class="fs-7 fw-bold text-gray-400">Form</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Form > ILA-->
		
		<!--begin::Modal New Assigned-->
		<div id="mdl03New" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Newly Assigned Forms</h5>
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
						<!--begin::Files-->
						<div class="table-responsive border rounded h-100">
							<table id="gv03Form" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
									</tr>
									</thead>
								<tbody>
							
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal New Assigned-->
		
		<!--begin::Modal Subscribed-->
		<div id="mdl04Subscribed" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Subscribed Forms</h5>
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
						<!--begin::Files-->
						<div class="table-responsive border rounded h-100">
							<table id="gv04Form" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
									</tr>
									</thead>
								<tbody>
							
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Subscribed-->
		
		<!--begin::Modal Request-->
		<div id="mdl05Request" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
					<div class="modal-header">
						<h5 class="modal-title">Subscribed Forms</h5>
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
						<!--begin::Files-->
						<div class="table-responsive border rounded h-100">
							<table id="gv05Form" class="table table-row-bordered gy-2 gs-2 w-100">
								<thead>
									<tr class="fw-bold fs-7 text-gray-800">
										<th class="min-w-150px mw-150px fw-bold border-end">ID</th>
										<th class="min-w-200px w-100 fw-bold border-end">Title</th>
										<th class="min-w-150px mw-150px fw-bold border-end">Type</th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Expected Date of Approval">Expected Date of Approval</span></th>
										<th class="min-w-100px mw-100px fw-bold border-end">Status</th>
										<th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Assigned To</th>
									</tr>
									</thead>
								<tbody>
							
								</tbody>
							</table>
						</div>
						<!--end::Files-->
					</div>
				</div>
			</div>
		</div>
		<!--begin::Modal Request-->

    </div>
    <!--content-->

   <script type="text/javascript">
 
       function btn01Filter() {
           var tr01Header = document.getElementById("tr01Header");
           var tr02Header = document.getElementById("tr02Header");
           var tr01Filter = document.getElementById("tr01Filter");
           if (window.getComputedStyle(tr01Filter).display === "none") {
			   tr01Header.style.display = "none";
               tr02Header.style.display = "none";
               tr01Filter.style.display = "";
           } else {
			   tr01Header.style.display = "";
               tr02Header.style.display = "";
               tr01Filter.style.display = "none";
           }
       }
       //filter form

       //load page
       function pageLoad(sender, args) { InitialiseSettings(); }
       function InitialiseSettings() {
           jQuery(function ($) {
               if (isPostBack == false) {
                   //disable column type detection
                   DataTable.types().forEach(type => {
                       DataTable.type(type, 'detect', () => false);
                   });
                   //disable column type detection

                   //sort date by yyyy/mm/dd
                   $.fn.dataTable.moment('MM/DD/YYYY');
                   //sort date by yyyy/mm/dd

                   $('[data-kt-repeater="select2"]').select2();
                   //combobox

                   //date
                   $('[data-kt-repeater="datepicker"]').flatpickr({
                       dateFormat: "m/d/Y"
                   });

                   //datatable
                   var gv01Form = $("#gv01Form").DataTable({
                       bFilter: true,
                       bPaginate: false,
                       bDestroy: true,
                       bInfo: false,
                       scrollCollapse: true,
                       scrollResize: true,
                       scrollX: true,
                       scrollY: "100px",
                       paging: false,
                       lengthChange: false,
                       fixedColumns: { left: 1 },
                       select: false,
                       ordering: true,
                    

                       // ✅ Tell DataTables to use the second row for sorting
                       headerCells: $('#tr02Header th'),

                       // ✅ Explicitly define columns
                       columns: [
                           { data: 'Code' },
                           { data: 'Post' },
                           { data: 'Connection' },
                           { data: 'Issue' },
                           { data: 'Due' },
                           { data: 'From' },
                           { data: 'To' }
                       ]
                   });
          
                   //datatable

                   //search
                   $('#tbx01Find').on('keyup', function () {
                       gv01Form.search(this.value).draw();
                   });
                   //search

                   //filter
                   $('#tbx01Find00').on('keyup', function () { // Code
                       gv01Form.column(0).search(this.value).draw();
                   });
                   $('#tbx01Find01').on('keyup', function () { // Post (Icon)
                       gv01Form.column(1).search(this.value).draw();
                   });
                   $('#tbx01Find02').on('keyup', function () { // Connection
                       gv01Form.column(2).search(this.value).draw();
                   });
                   $('#tbx01Find03').on('keyup', function () { // Issue Date
                       gv01Form.column(3).search(this.value).draw();
                   });
                   $('#tbx01Find04').on('keyup', function () { // Due Date
                       gv01Form.column(4).search(this.value).draw();
                   });
                   $('#tbx01Find05').on('keyup', function () { // Billing From
                       gv01Form.column(5).search(this.value).draw();
                   });
                   $('#tbx01Find06').on('keyup', function () { // Billing To
                       gv01Form.column(6).search(this.value).draw();
                   });
                   //filter

                   //export
                   const documentTitle = 'Assigned Forms';
                   var buttons = new $.fn.dataTable.Buttons(gv01Form, {
                       buttons: [
                           {
                               extend: 'copyHtml5',
                               title: documentTitle
                           },
                           {
                               extend: 'excelHtml5',
                               title: documentTitle
                           },
                           {
                               extend: 'csvHtml5',
                               title: documentTitle
                           },
                           {
                               extend: 'pdfHtml5',
                               title: documentTitle
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
           });
       }
       function lbtnFLTShow(Btn) {
           $('#ContentPlaceHolder1_mdlFLT').modal('show');
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
       function lbtnFLTFilter(Btn) {
           // Perform button
           var clickButton = document.getElementById("<%= lbtnFLT.ClientID %>");
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
   </script>
	<!-- scripts related to this page -->

</asp:Content>
