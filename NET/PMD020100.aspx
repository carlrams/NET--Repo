<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="PMD020100.aspx.vb" Inherits="NET.PMD020100" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
    <style type="text/css">
        /* Input group container: aligns rows and sets spacing */
        .input-group-container {
            width: 100%;
        }

        /* Enforce consistent widths */
        .input-group-text {
            width: 120px; /* Consistent label width */
            text-align: center;
        }

        .form-control {
            flex: 1; /* Fill remaining space */
        }
        .no-space {
            padding: 0 !important;
            margin: 0 !important;
            height: auto;
            min-height: 0;
        }
      

        /*.table-input {
            font-size: inherit;   
            font-weight: inherit;
            color: inherit;     
            padding: 3px 0 0 0;   
            margin: 0;            
            background: transparent; 
            text-align: end;      
            box-sizing: border-box; 
            display: block;      
           line-height: normal;  
             border: 0.5px solid #ddd; 
            width: 100%;         
            height: 100%;
        }*/

        .table-input {
            width: 100%;
            height: 100%;
            border: none;
            border: 0.5px solid #ddd; 
            outline: none;
            text-align: center; /* Adjust as needed */
            font-size: inherit; /* Keep the same font size */
            padding: 0; /* Remove extra spacing */
            box-sizing: border-box; /* Ensures input fits the cell */
        }

        .text-truncate {
            white-space: nowrap;  
            overflow: hidden;     
            text-overflow: ellipsis; 
            max-width: 150px;      
        }
       

        /* Popup styling */
           .swal-popup {
                width: 450px !important;
                height: 250px !important; 

                font-family: Arial, sans-serif;
                padding: 0 !important; /* Remove padding */
 
            }

            .swal-html-container {
                width: 100% !important;
                padding: 0px !important;

            }

            .separator {
                width: 100% !important;
                height: 2px;
                display: block;
                margin: 0;
            }


            /* Header styling */
            .swal-header {
                font-size: 20px;
                font-weight: bold;
                color: #333;
                padding-bottom: 35px;
                text-align: start;
            }

            /* Body styling */
            .swal-body {
                font-size: 14px;
                color: #555;
                text-align: center;
                display: flex;
                align-items: center;
                padding: 25px 0px 35px 0px; 
            }

          
            /* Confirm (Ok) button */
            .swal-confirm-btn {
                background-color: #218838 !important; /* Dark Green */
                color: white !important;
                border-radius: 6px;
                padding: 8px 16px; 
                font-size: 14px;
                border: none;
            }

            /* Cancel button */
            .swal-cancel-btn {
                background-color: #f8f9fa !important; 
                color: #6c757d !important; 
                border-radius: 6px;
                padding: 8px 16px;
                font-size: 14px;
                border: none;
                opacity: 0.7; 
            }

    </style>
</div>
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
						<li class="breadcrumb-item text-white opacity-75">Property Management</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white opacity-75 w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white opacity-75">Electricity Billing and Reading</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtn02UploadSave" runat="server" Text="Button" OnClick="lbtn02UploadSave_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

        <!--begin::Title-->
            <asp:UpdatePanel ID="upnlTitle" runat="server" UpdateMode="Conditional" class="card card-flush mb-5">
            <ContentTemplate>
	            <!--begin::title-->
	            <div class="card-header pt-10">
		            <div class="d-flex align-items-center">
			            <!--begin::Icon-->
			            <div class="symbol me-5">
				            <img src="Assets/media/svg/apps/FRM000010.svg" alt="" />
			            </div>
			            <!--end::Icon-->
			            <!--begin::Title-->
			            <div class="d-flex flex-column">
				            <h2 class="mb-1"><asp:Label id="lblTitle" runat="server">-</asp:Label></h2>
				            <div class="text-muted fw-bolder">
					            <asp:Label ID="lblID" runat="server" ClientIDMode="Static">-</asp:Label>
                                <asp:HiddenField ID="lbl01ID" runat="server"/>
                                <asp:HiddenField ID="Empcode" runat="server" ClientIDMode="Static" />
					            <span class="mx-3"></span>
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
					            <a class="nav-link text-active-primary me-1 active" title="Overview" data-bs-toggle="tab" href="#Menu01_TabContent"><i class="las la-file-alt fs-3x"></i></a>
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
					            <a class="nav-link text-active-primary me-1 position-relative" title="Notes" data-bs-toggle="tab" href="#Menu03_TabContent">
						            <i class="las la-comment fs-3x"></i>
						            <span id="blink01Notes" runat="server" class="bullet bullet-dot bg-warning h-8px w-8px position-absolute translate-middle top-10 start-50 animation-blink" style="display:none"></span>
					            </a>
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
		<div class="card card-flush mb-5" >
			<!--begin::Content-->

			<div class="tab-content" >
                <div class="tab-pane fade show active" id="Menu01_TabContent">
                    <!--begin::Menu Content-->
                    <asp:UpdatePanel ID="upnl01Overview" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
                        <ContentTemplate>
                            <!--begin::Card header-->
                            <div class="card-header">
                                <!--begin::Card header-->
                                <div class="card-title fs-3 fw-bolder">Electricity Billing and Reading</div>
                                <!--end::Card header-->
                            </div>
                            <!--begin::Card header-->
                            <div class="card-header">
                                <div class="d-flex table-responsive">
                                   <%-- <asp:LinkButton ID="lbtn01Find" runat="server" ToolTip="Find record" class="btn btn-sm btn-icon btn-info align-self-center m-1"><i class="las la-search fs-2"></i></asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn01Refresh" runat="server" ToolTip="Refresh record" class="btn btn-sm btn-icon btn-primary align-self-center m-1" OnClientClick=""><i class="las la-redo-alt fs-2"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn01Add" runat="server" ToolTip="Add record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-plus fs-2"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn01Delete" runat="server" ToolTip="Delete record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-trash fs-2"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn01Edit" runat="server" ToolTip="Edit record" class="btn btn-sm btn-icon btn-warning btn align-self-center m-1"><i class="las la-pencil-alt fs-2"></i></asp:LinkButton>
                                    <input id="cbxlock" runat="server" class="form-check-input align-self-center m-1" type="checkbox" value="" onclick="return false;" style="width: 30px; height: 30px; pointer-events: none;" />
                                    <asp:LinkButton ID="lbtn01Lock" runat="server" ToolTip="Lock Record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-lock fs-2"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn01Unlock" runat="server" ToolTip="Unlock Record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-unlock fs-2"></i></asp:LinkButton>
                                    <asp:Button ID="btnLock_Ok" runat="server" Text="Button" OnClick="btnLock_Ok_Click" ClientIDMode="Static" Style="display: none;" />
                                    <asp:Button ID="btnUnlock_Ok" runat="server" Text="Button" OnClick="btnUnlock_Ok_Click" ClientIDMode="Static" Style="display: none;" />
                                     <input id="cbxpost" runat="server" class="form-check-input align-self-center m-1" type="checkbox" value="" onclick="return false;" style="width: 30px; height: 30px; pointer-events: none;"  />
                                    <asp:LinkButton ID="lbtn01Post" runat="server" ToolTip="Post Record" class="btn btn-sm btn-icon btn-success align-self-center m-1"><i class="las la-tag fs-2"></></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn01Unpost" runat="server" ToolTip="Unpost Record" class="btn btn-sm btn-icon btn-danger align-self-center m-1"><i class="las la-tag fs-2"></i></asp:LinkButton>
                                    <asp:Button ID="btnPost_Ok" runat="server" Text="Button" OnClick="btnPost_Ok_Click" ClientIDMode="Static" Style="display: none;" />
                                    <asp:Button ID="btnUnpost_Ok" runat="server" Text="Button" OnClick="btnUnpost_Ok_Click" ClientIDMode="Static" Style="display: none;" />
                                    <asp:LinkButton ID="lbtn01Tools" runat="server" ToolTip="Tools" class="btn btn-sm btn-icon btn-info align-self-center m-1" data-bs-toggle="modal" data-bs-target="#mdl01tools"><i class="lab la-whmcs fs-2"></i> </asp:LinkButton>
                                </div>
                            </div>
                            
                 
                            <!--end::Card header-->
                           <div class="card-body">
                                 <!--begin::Add-->
                                <asp:Panel ID="pnl01Add" runat="server" Visible="false">
                                  <div class="row gx-2 gy-2">
                                     <div class="col-lg-9">
                                          <!-- First Row -->
                                         <div class="row mb-2">
                                           <div class="col-md-12">
                                             <div class="input-group input-group-sm">
                                                 <span class="input-group-text min-w-150px">Connection</span>
                                                 <asp:DropDownList ID="ddlAdd_Connection" runat="server" data-kt-repeater="select2" class="form-select form-select-sm rounded-start-0  min-h-35px">
                                                </asp:DropDownList>
                                             </div>
                                            </div>
                                         </div>
                                          <!-- Second Row -->
                                         <div class="row gx-2 gy-2 mb-2">
                                             <div class="col-md-4">
                                                 <div class="input-group input-group-sm">
                                                     <span class="input-group-text min-w-100px">Issue/Due Date</span>
                                                        <asp:TextBox ID="tbx02IssueDate" runat="server" data-kt-repeater="datepicker" class="form-control"></asp:TextBox>
                                                 </div>
                                             </div>
                                             <div class="col-md-2">
                                                 <div class="input-group input-group-sm">
                                                      <asp:TextBox ID="tbx02DueDate" runat="server" data-kt-repeater="datepicker" class="form-control"></asp:TextBox>
                                                 </div>
                                             </div>
                                           <div class="col-md-3">
                                                 <div class="input-group input-group-sm form-control-sm form-check form-check-custom form-check-solid form-check-sm border rounded d-flex align-items-center justify-content-between p-2">
                                                     <label class="form-check-label" for="cbxCSL" style="min-width: 75px; margin-bottom: 0;">
                                                         Compute System Loss
                                                     </label>
                                                     <div class="form-check m-0">
                                                         <input id="cbx02CLS" runat="server" class="form-check-input" type="checkbox" value="" />
                                                     </div>
                                                 </div>
                                             </div>
                                             <div class="col-md-3">
                                                 <div class="input-group input-group-sm form-control-sm form-check form-check-custom form-check-solid form-check-sm border rounded d-flex align-items-center justify-content-between p-2" >
                                                     <label class="form-check-label" for="ContentPlaceHolder1_cbxWithEWT" style="min-width: 75px; margin-bottom: 0;">
                                                         With EWT
                                                     </label>
                                                     <div class="form-check m-0">
            	                                         <input id="cbx02WithEWT" runat="server"  class="form-check-input" type="checkbox" value="" />
                                                     </div>
                                                       <asp:TextBox ID="tbx02WithEWT" runat="server" class="form-control" Style="height: 20px; width: 5px; text-align: right; margin-left: 10px;" placeholder="0.00"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                          <!-- Third Row -->
                                         <div class="row gx-2 gy-2">
                                             <div class="col-md-4">
                                                 <div class="input-group input-group-sm">
                                                     <span class="input-group-text min-w-100px">Billing Period</span>
                                                     <asp:TextBox ID="tbx02BillingPeriodFrom" runat="server" data-kt-repeater="datepicker" class="form-control" ></asp:TextBox>
                                                 </div>
                                             </div>
                                             <div class="col-md-2">
                                                 <div class="input-group input-group-sm">
                                                      <asp:TextBox ID="tbx02BillingPeriodTo" runat="server" data-kt-repeater="datepicker" class="form-control"></asp:TextBox>
                                                 </div>
                                             </div>
                                             <div class="col-md-6">
                                                 <div class="input-group input-group-sm">
                                                     <span class="input-group-text min-w-100px">Pmt. Posted</span>
                                                     <asp:TextBox ID="tbx02PmtPosted" runat="server" data-kt-repeater="datepicker" class="form-control"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                     </div>
                                     <div class="col-lg-3">
                                          <div class="input-group input-group-sm mb-2">
                                             <span class="input-group-text min-w-60px">Total Bill</span>
                                              <asp:Label ID="lbl02TotalBill" runat="server" placeholder="1.00" class="form-control"></asp:Label>
                                         </div>
                                          <div class="input-group input-group-sm  mb-2">
                                              <span class="input-group-text min-w-60px">Kwh</span>
                                             <asp:Label ID="lbl02Kwh" runat="server" placeholder="1.00" class="form-control"></asp:Label>
                                          </div>
                                          <div class="input-group input-group-sm">
                                              <span class="input-group-text min-w-60px">Factor</span>
                                              <asp:Label ID="lbl02Factor" runat="server" placeholder="1.00" class="form-control"></asp:Label>
                                          </div>
                                     </div>
                                 </div>
                                </asp:Panel>
                                 <!--end::Edit-->
                                <!--begin::Edit-->
                                <asp:Panel ID="pnl01Edit" runat="server" Visible="false">
                                   <div class="row gx-2 gy-2">
                                        <div class="col-lg-9">
                                             <!-- First Row -->
                                            <div class="row mb-2">
                                              <div class="col-md-12">
                                                <div class="input-group input-group-sm">
                                                    <span class="input-group-text min-w-100px">Connection</span>
                                                    <asp:Label ID="lbl03Connection" runat="server" class="form-control">-</asp:Label>
                                                </div>
                                               </div>
                                            </div>
                                             <!-- Second Row -->
                                            <div class="row gx-2 gy-2 mb-2">
                                                <div class="col-md-4">
                                                    <div class="input-group input-group-sm">
                                                        <span class="input-group-text min-w-100px">Issue/Due Date</span>
                                                        <asp:Label ID="lbl03DueDateFrom" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="input-group input-group-sm">
                                                        <asp:Label ID="lbl03DueDateTo" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                     <div class="input-group input-group-sm form-control-sm form-check form-check-custom form-check-solid form-check-sm border rounded d-flex align-items-center justify-content-between p-2">
                                                         <label class="form-check-label" for="cbxCSL" style="min-width: 75px; margin-bottom: 0;">
                                                             Compute System Loss
                                                         </label>
                                                         <div class="form-check m-0">
                                                             <input id="cbx03CSL" runat="server" class="form-check-input" type="checkbox" value="" disabled/>
                                                         </div>
                                                     </div>
                                                 </div>
                                                 <div class="col-md-3">
                                                     <div class="input-group input-group-sm form-control-sm form-check form-check-custom form-check-solid form-check-sm border rounded d-flex align-items-center justify-content-between p-2" >
                                                         <label class="form-check-label" for="ContentPlaceHolder1_cbxWithEWT" style="min-width: 75px; margin-bottom: 0;">
                                                             With EWT
                                                         </label>
                                                         <div class="form-check m-0">
                                                             <input id="cbx03WithEWT" runat="server" class="form-check-input" type="checkbox" value="" disabled/>
                                                         </div>
                                                           <asp:TextBox ID="tbx03EWT" runat="server" ReadOnly="true" class="form-control" Style="height: 20px; width: 5px; text-align: right; margin-left: 10px;" placeholder="0.00"></asp:TextBox>
                                                     </div>
                                                 </div>
                                            </div>
                                             <!-- Third Row -->
                                            <div class="row gx-2 gy-2">
                                                <div class="col-md-4">
                                                    <div class="input-group input-group-sm">
                                                        <span class="input-group-text min-w-100px">Billing Period</span>
                                                        <asp:Label ID="lbl03BillingPeriodFrom" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="input-group input-group-sm">
                                                        <asp:Label ID="lbl03BillingPeriodTo" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="input-group input-group-sm">
                                                        <span class="input-group-text min-w-100px">Pmt. Posted</span>
                                                        <asp:Label ID="lbl03PmtPosted" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                             <div class="input-group input-group-sm mb-2">
                                                <span class="input-group-text min-w-60px">Total Bill</span>
                                                <asp:Label ID="lbl03TotalBill" runat="server" class="form-control">-</asp:Label>
                                            </div>
                                             <div class="input-group input-group-sm  mb-2">
                                                 <span class="input-group-text min-w-60px">Kwh</span>
                                                 <asp:Label ID="Lalbl03Kwh" runat="server" class="form-control">-</asp:Label>
                                             </div>
                                             <div class="input-group input-group-sm">
                                                 <span class="input-group-text min-w-60px">Factor</span>
                                                 <asp:Label ID="lbl03Factor" runat="server" class="form-control">-</asp:Label>
                                             </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <!--end::Edit-->
                                <!--begin::Dtl-->
                                <asp:Panel ID="pnl01Dtl" runat="server" Visible="false">
                                    <div class="row gx-2 gy-2">
                                        <div class="col-lg-9">
                                             <!-- First Row -->
                                            <div class="row mb-2">
                                              <div class="col-md-12">
                                                <div class="input-group input-group-sm">
                                                    <span class="input-group-text min-w-100px">Connection</span>
                                                    <asp:Label ID="lbl01Connection" runat="server" class="form-control">-</asp:Label>
                                                </div>
                                               </div>
                                            </div>
                                             <!-- Second Row -->
                                            <div class="row gx-2 gy-2 mb-2">
                                                <div class="col-md-4">
                                                    <div class="input-group input-group-sm">
                                                        <span class="input-group-text min-w-100px">Issue/Due Date</span>
                                                        <asp:Label ID="lbl01DueDateFrom" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="input-group input-group-sm">
                                                        <asp:Label ID="lbl01DueDateTo" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="input-group input-group-sm form-control-sm form-check form-check-custom form-check-solid form-check-sm border rounded d-flex align-items-center justify-content-between p-2">
                                                        <label class="form-check-label" for="cbxCSL" style="min-width: 75px; margin-bottom: 0;">
                                                            Compute System Loss
                                                        </label>
                                                        <div class="form-check m-0">
                                                            <input id="cbxCSL" runat="server" class="form-check-input" type="checkbox" value="" disabled/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="input-group input-group-sm form-control-sm form-check form-check-custom form-check-solid form-check-sm border rounded d-flex align-items-center justify-content-between p-2" >
                                                        <label class="form-check-label" for="ContentPlaceHolder1_cbxWithEWT" style="min-width: 75px; margin-bottom: 0;">
                                                            With EWT
                                                        </label>
                                                        <div class="form-check m-0">
                                                            <input id="cbxWithEWT" runat="server" class="form-check-input" type="checkbox" value="" disabled/>
                                                        </div>
                                                          <asp:TextBox ID="tbxEWT" runat="server" ReadOnly="true" class="form-control" Style="height: 20px; width: 5px; text-align: right; margin-left: 10px;" placeholder="0.00"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                             <!-- Third Row -->
                                            <div class="row gx-2 gy-2">
                                                <div class="col-md-4">
                                                    <div class="input-group input-group-sm">
                                                        <span class="input-group-text min-w-100px">Billing Period</span>
                                                        <asp:Label ID="lbl01BillingPeriodFrom" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="input-group input-group-sm">
                                                        <asp:Label ID="lbl01BillingPeriodTo" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="input-group input-group-sm">
                                                        <span class="input-group-text min-w-100px">Pmt. Posted</span>
                                                        <asp:Label ID="lbl01PmtPosted" runat="server" class="form-control">-</asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                             <div class="input-group input-group-sm mb-2">
                                                <span class="input-group-text min-w-60px">Total Bill</span>
                                                <asp:Label ID="lbl01TotalBill" runat="server" class="form-control">-</asp:Label>
                                            </div>
                                             <div class="input-group input-group-sm  mb-2">
                                                 <span class="input-group-text min-w-60px">Kwh</span>
                                                 <asp:Label ID="Lalbl01Kwh" runat="server" class="form-control">-</asp:Label>
                                             </div>
                                             <div class="input-group input-group-sm">
                                                 <span class="input-group-text min-w-60px">Factor</span>
                                                 <asp:Label ID="lbl01Factor" runat="server" class="form-control">-</asp:Label>
                                             </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <!--end::Dtl-->
                            </div>
                    <div class="separator border-line-1"></div>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                     <asp:UpdatePanel ID="upnl01table" runat="server" UpdateMode="Conditional" class="card card-xl-stretch">
                         <ContentTemplate>  
                              <div class="card-header">
                                   <div class="d-flex table-responsive">
                                
                                       <asp:LinkButton ID="lbtn02add" runat="server" ToolTip="Add record"
                                            CssClass="btn btn-sm btn-icon btn-success align-self-center m-1" 
                                            OnClientClick="return false;" >
                                            <i class="las la-plus fs-2"></i>
                                        </asp:LinkButton>
                                       
                                     <input type="file" runat="server" id="fileInput" clientidmode="Static" accept=".xls,.xlsx" style="display: none;"/>

                                     <button type="button" runat="server" id="editTableBtn" class="btn btn-sm btn-icon btn-warning align-self-center m-1"
                                        style="width: 35px; height: 35px; display: inline-flex; align-items: center; justify-content: center;"
                                        onclick="makeTableEditable();">
                                        <i class="las la-pencil-alt fs-2"></i>
                                    </button>
                                      <button type="button" runat="server" id="cancelTableBtn" class="btn btn-sm btn-icon btn-danger align-self-center m-1"
                                        style="width: 35px; height: 35px; display: none; align-items: center; justify-content: center;"
                                        onclick="CancelTableChanges();">
                                        <i class="las la-trash fs-2"></i>
                                    </button>
                                    <button type="button" runat="server" id="saveTableBtn" class="btn btn-sm btn-icon btn-warning align-self-center m-1"
                                        style="width: 35px; height: 35px; display: none; align-items: center; justify-content: center;"
                                        onclick="saveTableChanges();">
                                        <i class="las la-save fs-2"></i>
                                    </button>
                                  </div>
                               </div>    
		             <div class="card-body">
                        <div class="border rounded overflow-auto table-responsive" style="height:80.3vh;">
                          <table id="gv01Form" class="table table-row-bordered gy-2 gs-2 w-100">
                                <thead>
                                   <tr class="fw-bold fs-7 text-gray-800 ">
                                        <th colspan="4" class="border-bottom border-end fw-bold">Lot Details</th>
                                        <th colspan="2" class="border-bottom border-end fw-bold">Account</th>
                                        <th colspan="5" class="border-bottom border-end fw-bold">Engineering</th>
                                        <th colspan="4" class="border-bottom border-end fw-bold">Accounting</th>
                                    </tr>
                                    <tr  class="fw-bold fs-7 text-gray-800">
                                        <th class="min-w-50px w-50px text-center align-middle align-middle border-end" >Subd</th>
                                        <th class="min-w-50px w-50px fw-bold text-center align-middle border-end" >Phase</th>
                                        <th class="min-w-50px w-50px fw-bold align-middle align-middle border-end"  >Block</th>
                                        <th class="min-w-50px w-50px fw-bold align-middle align-middle border-end" >Lot</th>
                                        <th class="min-w-150px fw-bold align-middle border-end" >No.</th>
                                        <th class="min-w-250px w-250px fw-bold align-middle border-end" >Name</th> 
                                        <th class="min-w-100px fw-bold align-middle border-end" >Present</th>
                                        <th class="min-w-100px fw-bold align-middle border-end" >Previous</th>
                                        <th class="min-w-100px fw-bold align-middle border-end" >Kwh Used</th>
                                        <th class="min-w-100px fw-bold align-middle border-end" >Factor Rate</th>
                                        <th class="min-w-100px fw-bold align-middle border-end" >Amount</th>
                                          <th class="min-w-100px fw-bold align-middle border-end" >Current Bill</th>
                                          <th class="min-w-100px fw-bold align-middle border-end" >Arrears</th>
                                          <th class="min-w-100px fw-bold align-middle border-end" >Others</th>
                                          <th class="min-w-100px fw-bold text-center align-middle border-end">Total</th>
                                   </tr>
                                   
                                     
                                </thead>
                               <tbody id="gv01FormBody">
                                     <asp:Literal ID="litTableData" runat="server"></asp:Literal>
                                        <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
                                   <% If Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0 Then %>
                                        <% For Each dr As Data.DataRow In Me.FormDataSet.Tables(0).Rows %>
                                            <tr>
                                                <% For Each dc As Data.DataColumn In Me.FormDataSet.Tables(0).Columns %>
                                                    <td>
                                                        <%= dr(dc.ColumnName) %>
                                                    </td>
                                                <% Next %>
                                            </tr>
                                        <% Next %>
                                    <% Else %>
                                        <td colspan="100%" style="text-align: center; font-weight: bold; height: 350px; vertical-align: middle;">
                                            No data available
                                        </td>
                                    <% End If %>             
                               </tbody>
                                        <tfoot>
                                            <tr class="fs-7 text-gray-800">
                                                <th colspan="6" class="border-bottom border-end border-secondary">Total</th>
                                                <th id="footerCurrRead" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumCurrRead"), 0) %>
                                                </th>
                                                <th id="footerPrevRead" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumPrevRead"), 0) %>
                                                </th>
                                                <th id="footerKWHUsed" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumKWHUsed"), 0) %>
                                                </th>
                                                <th id="footerFactorRate" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumFactorRate"), 0) %>
                                                </th>
                                                <th id="footerBillAmt" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumBillAmt"), 0) %>
                                                </th>
                                                <th id="footerTotBill" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumTotBill"), 0) %>
                                                </th>
                                                <th id="footerArrears" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumArrears"), 0) %>
                                                </th>
                                                <th id="footerOthAmt" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumOthAmt"), 0) %>
                                                </th>
                                                <th id="footerNetBill" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumNetBill"), 0) %>
                                                </th>
                                            </tr>
                                            <tr class="fs-7">
                                                <th colspan="11" class="border-bottom border-end border-secondary" >Less : EWT</th>
                                                <th id="footersumEWTBill" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("sumEWTBill"), 0) %>
                                                </th>
                                                <th colspan="3" class="border-bottom border-end border-secondary fw-bold"></th>
                                            </tr>
                                            <tr class="fs-7 text-gray-800">
                                                <th colspan="11" class="border-bottom border-end border-secondary">Net Bill</th>
                                                <th id="footersumTotalnetbill" class="min-w-100px fw-bold align-middle border-bottom border-end border-secondary"">
                                                    <%= If(Me.FormDataSet IsNot Nothing AndAlso Me.FormDataSet.Tables.Count > 0 AndAlso Me.FormDataSet.Tables(0).Rows.Count > 0, ViewState("Totalnetbill"), 0) %>
                                                </th>
                                                <th colspan="3" class="border-bottom border-end border-secondary"></th>
                                            </tr>
                                        </tfoot>
                                 </table>
                             </div>       
			         </div>        
                   <!--end::Menu Content-->
                    </ContentTemplate>
                    </asp:UpdatePanel>
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
		<!--end::Content

		<!--begin::Modal DialogBox-->
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
								<input id="tbxLock_Password" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
							</div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
							<button class="btn btn-primary" onclick="Lock_Ok(this);">
									Yes
							</button>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal DialogBox-->

		<!--begin::Modal DialogBox-->
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
										<input id="tbxUnlock_Password" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
									</div>
								</div>
								<div class="modal-footer">
									<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
									<button class="btn btn-primary" onclick="Unlock_Ok(this);">
										Yes
									</button>
								</div>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->
        
		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlPost" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<ContentTemplate>
				<div class="modal-dialog modal-dialog-centered" role="document">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title">Post Record</h5>
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
								<input id="tbxPost_Password" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
							</div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
							<button class="btn btn-primary" onclick="Post_Ok(this);">
									Yes
							</button>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::Modal DialogBox-->

		<!--begin::Modal DialogBox-->
		<asp:UpdatePanel ID="mdlUnPost" runat="server" UpdateMode="Conditional" class="modal fade z-index-1056" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
				<ContentTemplate>
					<div class="modal-dialog modal-dialog-centered" role="document">
							<div class="modal-content">
								<div class="modal-header">
									<h5 class="modal-title">Unpost Record</h5>
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
										<input id="tbxUnpost_Password" runat="server"  class="form-control form-control-sm" placeholder="Enter password" type="password" />
									</div>
								</div>
								<div class="modal-footer">
									<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">No</button>
									<button class="btn btn-primary" onclick="Unpost_Ok(this);">
										Yes
									</button>
								</div>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
		<!--begin::Modal DialogBox-->


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
							            <span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 4mb per file</span>
						            </div>
						            <!--end::Info-->
					            </div>
				            </div>
				            <!--end::Dropzone-->
			            </div>
			            <!--begin::Actions-->
			            <div class="modal-footer">
				            <asp:LinkButton ID="lbtn02CancelUpload" runat="server" class="btn btn-light me-3">Cancel</asp:LinkButton>
				            <button id="lbtn02SaveUpload" type="button" class="btn btn-primary">Upload</button>
			            </div>
			            <!--end::Actions-->
		            </div>
	            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            <!--begin::Modal Upload-->

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
						        <span class="input-group-text input-group-text-top min-w-150px">Notes</span>
						        <asp:TextBox ID="tbx05Note" runat="server" class="form-control mention h-75px min-h-200px mh-200px" Placeholder="Add note" TextMode="MultiLine" style="height:200px"></asp:TextBox>
						        <asp:HiddenField ID="hdnMention" runat="server" />
					        </div>
				        </div>
				        <!--begin::Actions-->
				        <div class="modal-footer">
					        <button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
					        <asp:LinkButton ID="lbtn05AddNote" runat="server" class="btn btn-primary lbtn05AddNote">Add</asp:LinkButton>
				        </div>
				        <!--end::Actions-->
			        </div>
		        </div>
	        </ContentTemplate>
	        </asp:UpdatePanel>

		<!--begin::Modal to -->
			<div id="mdl01tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
								            <a class="text-gray-800 d-flex flex-column pointer" onclick="Exportexcel()">
                                                <div class="symbol symbol-60px mb-5">
                                                    <img src="Assets/media/svg/apps/GEN.svg" alt="" />
                                                </div>
									            <div class="fs-5 fw-bolder mb-2">Export (excel)</div>
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


        <!--begin::Modal DialogBox-->
        <asp:UpdatePanel ID="mdl02DialogBox" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
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
				        <div class="mb-2 flex-nowrap">
					        <p><asp:Label ID="Label1" runat="server">Do you want to cancel record?</asp:Label></p>
				        </div>
                    </div>
                       <div class="modal-footer">
				            <button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
                           <asp:LinkButton ID="btnOk" runat="server" class="btn btn-primary">Ok</asp:LinkButton>
                                 
                       </div>
		            </div>
	            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!--begin::Modal DialogBox-->
	</div>	

	
	<!--end::Content-->

	<!-- scripts related to this page -->
    
    <script type="text/javascript" >      

        document.addEventListener("DOMContentLoaded", function () {
            function attachEvent() {
                let checkbox = document.getElementById("<%= cbxpost.ClientID %>");
                let fileInput = document.getElementById("fileInput");
                let addButton = document.getElementById("<%= lbtn02add.ClientID %>");
                let editButton = document.getElementById("<%= editTableBtn.ClientID %>");

                if (!checkbox || !fileInput || !editButton || !addButton) return; // Ensure elements exist

        function toggleElements() {
            let isDisabled = checkbox.checked;
            
            if (isDisabled) {
                fileInput.setAttribute("data-disabled", "true"); // Custom attribute
            } else {
                fileInput.removeAttribute("data-disabled");
            }
        }

        checkbox.addEventListener("change", toggleElements);
        toggleElements(); // Run immediately to reflect changes

        // Remove existing event listener to prevent duplication
        editButton.replaceWith(editButton.cloneNode(true));
               editButton = document.getElementById("<%= editTableBtn.ClientID %>"); // Reassign cloned button

               // Prevent function execution when checkbox is checked
               editButton.addEventListener("click", function (event) {
                   if (checkbox.checked) {
                       event.preventDefault();
                       event.stopImmediatePropagation();
                       Alert01("error", "Record is posted!", "");
                       return false;
                   }

                   makeTableEditable();
               });

               // Prevent direct clicks on the hidden file input
               fileInput.addEventListener("click", function (event) {
                   if (checkbox.checked) {
                       event.preventDefault();
                       Alert01("error", "Record is posted!", "");
                   }
               });

               // Handle clicks on the "Add Record" button correctly
               addButton.addEventListener("click", function (event) {
                   if (checkbox.checked) {
                       event.preventDefault();
                       Alert01("error", "Record is posted!", "");
                       return false;
                   }

                   // Manually trigger file input click only ONCE
                   if (!fileInput.hasAttribute("data-clicked")) {
                       fileInput.setAttribute("data-clicked", "true");
                       fileInput.click();

                       // Reset flag after a slight delay to allow file selection
                       setTimeout(() => fileInput.removeAttribute("data-clicked"), 500);
                   }
               });
           }

           // Initial attachment when page loads
           attachEvent();

           // Reattach after UpdatePanel refresh
           Sys.WebForms.PageRequestManager.getInstance().add_endRequest(attachEvent);
       });

        // Function to call SweetAlert
        function Alert01(Alert_01, Message_01, AdditionalScript) {
            let class_01 = Alert_01 === "success" ? "btn btn-primary" : "btn btn-danger";
            Swal.fire({
                text: Message_01,
                icon: Alert_01,
                buttonsStyling: false,
                confirmButtonText: "Ok, got it!",
                customClass: {
                    confirmButton: class_01
                }
            });
        }

        

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
                var ltrlDtlMode = '<asp:Literal ID="ltrlDtlMode" runat="server" />';
                var ltrlSeqNo = '<asp:Literal ID="ltrlSeqNo" runat="server" />';
                //form variable


                //metion                jq.fn.atwho.debug = true;
                var chatHub = jq.connection.chatHub;
                jq.connection.hub.start().done(function () {
                    // mention load
                    loadFunction()
                    //// mention save
                    jq('.lbtn05AddNote').click(function () {
                        // Call the Send method on the hub.
                        chatHub.server.send(ltrlFormCode, ltrlID, ltrlFormCode, initialMention.join(','), ltrlCreatedBy);
                        // clear
                        initialMention = [];
                        mentionUser = [];
                    })
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

                ////upload
                if (!Dropzone.instances.length) {
                    var myDropzone = new Dropzone("#DropZone", {
                        url: "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + ltrlID.replace("#", "No"),
                        autoProcessQueue: false,
                        parallelUploads: 5,
                        maxFilesize: 10,
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
                }
                $('#lbtn02SaveUpload').on('click', function (e) {
                    var lbl01ID = document.getElementById("ContentPlaceHolder1_lbl01ID").value;
                    myDropzone.options.url = "HND000001.ashx?FormCode=" + ltrlFormCode + "&ID=" + lbl01ID;
                    myDropzone.processQueue();
                    // Perform button
                    var Btn = document.getElementById('lbtn02SaveUpload');
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
                //upload 


                //checkbox
                $(document).ready(function () {
                    var checkbox = $("#<%= cbx02WithEWT.ClientID %>");
                     var textbox = $("#<%= tbx02WithEWT.ClientID %>");

                     // Initially disable the textbox
                     textbox.prop("disabled", true);

                     // Toggle textbox enabled/disabled on checkbox change
                     checkbox.change(function () {
                         if ($(this).is(":checked")) {
                             textbox.prop("disabled", false);
                         } else {
                             textbox.prop("disabled", true);
                             textbox.val(""); // Clear value when disabled
                         }
                     });
                 });

                 //combobox
                 $('[data-kt-repeater="select2"]').select2();
                 //combobox


                 //date
                 $(document).ready(function () {
                     // Initialize all Flatpickr elements
                     $('[data-kt-repeater="datepicker"]').each(function () {
                         flatpickr(this, {
                             dateFormat: "m/d/Y"
                         });
                     });

                     var issueDate = document.getElementById("<%= tbx02IssueDate.ClientID %>");
                     var dueDate = document.getElementById("<%= tbx02DueDate.ClientID %>");

                     // Initialize Flatpickr for Issue Date with minDate set to today
                     var issueDatePicker = flatpickr(issueDate, {
                         dateFormat: "m/d/Y",
                         minDate: "today",  // Restrict to today onwards
                         onChange: function (selectedDates, dateStr, instance) {
                             if (selectedDates.length > 0) {
                                 let minDate = selectedDates[0]; // Get selected Issue Date

                                 // Re-initialize Due Date with minDate restriction
                                 flatpickr(dueDate, {
                                     dateFormat: "m/d/Y",
                                     minDate: minDate
                                 });

                                 dueDate.value = ""; // Clear Due Date to prevent invalid selection
                             }
                         }
                     });

                     // Initialize Flatpickr for Due Date separately
                     flatpickr(dueDate, {
                         dateFormat: "m/d/Y"
                     });
                 });
                $(document).ready(function () {
                    // Check if the table has any rows other than the No data available row
                    if ($("#gv01Form tbody tr").length > 0 && $("#gv01Form tbody tr td[colspan]").length === 0) {
                        // If there are rows, initialize the DataTable
                        // ✅ Reinitialize DataTable with the same settings
                        $("#gv01Form").DataTable({
                            bFilter: true,
                            bPaginate: false,
                            bDestroy: true,
                            bInfo: false,
                            scrollCollapse: true,
                            scrollResize: true,
                            scrollX: true,
                            scrollY: '55.4vh',
                            paging: false,
                            lengthChange: false,
                            select: false,
                            ordering: true,
                            rowCallback: function (row, data) {
                                $(row).css("height", "20px"); // Adjust row height
                            },
                            columnDefs: [
                                { targets: 5, className: "text-truncate" }, // Apply nowrap to column index 5
                                {
                                    targets: [6, 7, 8, 9, 10, 11, 12, 13, 14],
                                    className: "text-end",
                                    render: function (data, type, row) {
                                        let value = parseFloat(data); // Convert data to a number
                                        if (isNaN(value)) return `<span style="display: block; padding-top: 3px;">${data}</span>`;

                                        let formattedValue = value.toLocaleString("en-US", {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        });

                                        return `<span style="display: block; padding-top: 3px;">${formattedValue}</span>`;
                                    }
                                },
                                { targets: [1, 2, 3], className: "text-start" } // Text start alignment for certain columns
                            ]
                        });


                    } else {
                        // If no rows are present, destroy DataTable instance if already initialized
                        if ($.fn.dataTable.isDataTable('#gv01Form')) {
                            $('#gv01Form').DataTable().clear().destroy();
                        }
                    }
                });
            });

            jQuery(function ($) {
                var isPostBack = <%= IsPostBack.ToString().ToLower() %>;

                if (!isPostBack) {
                             
                    //export
                    function Exportexcel() {
                        try {
                            // Check if SheetJS is loaded
                            if (typeof XLSX === "undefined") {
                                console.error("SheetJS (xlsx library) is not loaded!");
                                alert("Error: SheetJS library is missing. Please check the script link.");
                                return;
                            }

                            // Get the table element
                            var table = document.getElementById("gv01Form");
                            if (!table) {
                                console.error("Table with ID 'gv01form' not found!");
                                alert("Error: Table not found. Check the table ID.");
                                return;
                            }

                            // Convert table to an Excel file
                            var wb = XLSX.utils.book_new();
                            var ws = XLSX.utils.table_to_sheet(table);
                            XLSX.utils.book_append_sheet(wb, ws, "Sheet1");

                            // Save as Excel
                            XLSX.writeFile(wb, "ExportedData.xlsx");
                            console.log("Export successful!");

                        } catch (error) {
                            console.error("Error during export:", error);
                            alert("An error occurred. Check the console for details.");
                        }
                    }

                    // Make function globally accessible
                    window.Exportexcel = Exportexcel;

                    //Import excel
                    document.getElementById("fileInput").addEventListener("change", function (event) {
                        var file = event.target.files[0];

                        if (!file) {
                            console.log("No file selected.");
                            return;
                        }

                        var billCodeElement = document.getElementById("<%= lblID.ClientID %>");
                        if (!billCodeElement || !billCodeElement.textContent.trim()) {
                            alert("Bill Code is required!");
                            return;
                        }
                        var billCode = billCodeElement.textContent.trim();

                        var auditUserElement = document.getElementById("<%= Empcode.ClientID %>");
                        var AuditUser = auditUserElement ? auditUserElement.value.trim() : "";

                        // 🛑 Show confirmation message before proceeding
                        Swal.fire({
                            html: `
                                <div class="swal-header">Message</div>
                                <div class="separator"></div>
                                <div class="swal-body">Save Record?</div>
                                <div class="separator"></div>
                            `,
                            icon: null,
                            showCancelButton: true,
                            cancelButtonText: "Cancel",
                            confirmButtonText: "Ok",
                            buttonsStyling: false,
                            reverseButtons: true, // Swap the button positions
                            customClass: {
                                popup: "swal-popup",
                                confirmButton: "swal-confirm-btn",
                                cancelButton: "swal-cancel-btn",
                                htmlContainer: "swal-html-content"
                            }

                           }).then((result) => {
                            if (!result.isConfirmed) {
                                console.log("❌ Import cancelled by user.");
                                document.getElementById("fileInput").value = ""; // Reset file input
                                return;
                            }

                               var reader = new FileReader();
                               reader.onload = function (e) {
                                var base64String = e.target.result.split(",")[1];

                                var requestData = {
                                    billCode: billCode,
                                    AuditUser: AuditUser,
                                    fileName: file.name,
                                    fileData: base64String
                                };
                                fetch("PMD020100.aspx/UploadAndReadExcel", {
                                    method: "POST",
                                    headers: { "Content-Type": "application/json" },
                                    body: JSON.stringify(requestData)
                                })
                                    .then(response => response.json())
                                    .then(data => {
                                        if (!data || !data.d || !data.d.success) {
                                            Alert01("error", "Invalid Input Format");
        
                                            return;
                                        }

                                        let result = data.d.data;
                                        if (!Array.isArray(result) || result.length === 0) {
                                            console.warn("⚠️ No data returned from Excel.");
                                            return;
                                        }
                                   
                                        function updateTableData(newData) {
                                            var tableBody = document.getElementById("gv01FormBody");

                                            newData.forEach(row => {
                                                var existingRow = document.querySelector(`tr[data-id='${row.Code}']`);
                                                if (existingRow) {
                                                    existingRow.cells[6].textContent = row.Present;
                                                    existingRow.cells[7].textContent = row.Previous;
                                                    existingRow.cells[9].textContent = row.FactorRate;
                                                    existingRow.cells[10].textContent = row.Amount;
                                                }
                                            });
                                        }
                                    
                                        let filteredData = result.map(row => ({
                                            Code: row.Code,
                                            Present: row.Present,
                                            Previous: row.Previous,
                                            FactorRate: row.FactorRate,
                                            Amount: row.Amount
                                        }));

                                        console.log("🚀 Sending to Server:", JSON.stringify({ billCode, data: result, AuditUser }, null, 2));

                                        fetch("PMD020100.aspx/SaveToDatabase", {
                                            method: "POST",
                                            headers: { "Content-Type": "application/json" },
                                            body: JSON.stringify({ billCode, AuditUser, data: result })
                                        })
                                            .then(response => response.json())
                                            .then(data => {
                                                console.log("📩 Raw Server Response:", data);

                                                try {
                                                    let parsedData = JSON.parse(data.d);
                                                    if (!parsedData.success) {
                                                        console.error("❌ Error Saving to Database:", parsedData.message);
                                                        return;
                                                    }
                                                    console.log("✅ Data successfully saved to database.");

                                                    updateFooterSums();

                                                    Swal.fire({
                                                        text: "Record saved successfully!",
                                                        icon: "success",
                                                        buttonsStyling: false,
                                                        confirmButtonText: "Ok, got it!",
                                                        customClass: { confirmButton: "btn btn-primary" }
                                                    }).then((result) => {
                                                        if (result.isConfirmed) {
                                                            RefreshTable();

                                                        }
                                                    });

                                                } catch (error) {
                                                    console.error("❌ JSON Parse Error:", error, "Server Response:", data);
                                                    Alert02("error", error, "");
                                                }
                                            })
                                            .catch(error => console.error("❌ Fetch Error:", error));
                                    })
                                    .catch(error => console.error("❌ Fetch Error:", error));

                                // Reset file input to allow re-selection
                                document.getElementById("fileInput").value = "";
                            };

                            reader.readAsDataURL(file);

                        });
                    });

                    function RefreshTable() {
                        let billCode = document.getElementById("lblID").textContent.trim();

                        fetch("PMD020100.aspx/GetUpdatedTable", {
                            method: "POST",
                            headers: { "Content-Type": "application/json" },
                            body: JSON.stringify({ BillCode: billCode })
                        })
                            .then(response => response.json())
                            .then(data => {
                                console.log("📩 Updated Table Data:", data);
                                updateFooterSums();
                                if (!data.d.success) {
                                    console.error("❌ Error fetching updated table:", data.d.message);
                                    return;
                                }

                                let table = $('#gv01Form').DataTable(); // Get existing DataTable instance

                                // ✅ Destroy the current DataTable before updating content
                                table.destroy();
                                updateFooterSums();
                                // ✅ Replace tbody content
                                document.getElementById("gv01FormBody").innerHTML = data.d.html;


                                // ✅ Reinitialize DataTable with the same settings
                                $("#gv01Form").DataTable({
                                    bFilter: true,
                                    bPaginate: false,
                                    bDestroy: true,
                                    bInfo: false,
                                    scrollCollapse: true,
                                    scrollResize: true,
                                    scrollX: true,
                                    scrollY: '55.4vh',
                                    paging: false,
                                    lengthChange: false,
                                    select: false,
                                    ordering: true,
                                    columnDefs: [
                                        { targets: 5, className: "text-truncate" }, // Apply nowrap to column index 5
                                        {
                                            targets: [6, 7, 8, 9, 10, 11, 12, 13, 14], // Numeric columns
                                            render: function (data, type, row) {
                                                let value = parseFloat(data); // Convert data to a number
                                                if (isNaN(value)) return data; // Return original value if it's not a number
                                                value = value < 0 ? 0 : value; // Set negative numbers to 0
                                                return type === "display" || type === "filter" ? value.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 }) : value;
                                            }
                                        },
                                        { targets: [1, 2, 3], className: "text-start" } // Text start alignment for certain columns
                                    ]
                                });
                                updateFooterSums();

                            })
                            .catch(error => console.error("❌ Fetch Error:", error));
                    }


                    //numeric formatting
                    function FormatNumeric(ID) {
                        var NumVal = document.getElementById(ID);
                        var RawValue = NumVal.value.replace(/,/g, "");
                        var Val = parseFloat(RawValue);

                        if (isNaN(Val)) {
                            NumVal.value = "0.00";
                            return;
                        }

                        var NewVal = Val.toFixed(2);
                        var Parts = NewVal.toString().split(".");
                        var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");

                        NumVal.value = Num;
                    }
                    //numeric formatting


                   
                }
                IsPostBack = true;
            });
        }

        //load page
        function Unlock_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnUnlock_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        function Lock_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnLock_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        function Unpost_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnUnpost_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        function Post_Ok(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btnPost_Ok.ClientID %>");
            clickButton.click();
            // Disable button to avoid multiple click
            Btn.disabled = true;
            // Simulate form submission
            setTimeout(function () {
                // Enable button
                Btn.disabled = false;
            }, 3000);
        };
        

        //Event
        function ddlBatch_onchange(selectObj) {
            var selectIndex = selectObj.selectedIndex;
            var selectValue = selectObj.options[selectIndex].text;
            bindProject(selectValue)
        }
        $('.toggle-vis').on('change', function () {
            let clmIdx01 = parseInt($(this).val());
            let clmIdx02 = parseInt($(this).val()) + 1;
            let clmIdx03 = parseInt($(this).val()) + 2;
            // Get the column API object
            var column01 = $('#gvProject').DataTable().column(clmIdx01);
            var column02 = $('#gvProject').DataTable().column(clmIdx02);
            var column03 = $('#gvProject').DataTable().column(clmIdx03);
            // Toggle the visibility
            column01.visible(!column01.visible());
            column02.visible(!column02.visible());
            column03.visible(!column03.visible());
        });
        //Event

        //View batch
        function bindInfo(Project, No) {
            document.getElementById("lblInfo_Project").innerHTML = Project;
            document.getElementById("lblInfo_No").innerHTML = No;

            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                     'Type': 'Info',
                    'No': No
                },
                success: function (response) {
                    DisplayInfo(response)
                },
            });
        }
        function DisplayInfo(response) {
            //datatable
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            var gvInfo = $("#gvInfo").DataTable({
                bFilter: true,
                bPaginate: false,
                bSort: false,
                bDestroy: true,
                bInfo: false,
                paging: false,
                lengthChange: false,
                fixedColumns: { left: 1 },
                select: false,
                data: response,
                columns: [
                    { data: 'Task' },
                    { data: 'AssignTo' },
                    { data: 'TargetDate' },
                    { data: 'Status' },
                    { data: 'DateSecured' }]
            });
            //datatable

            // show modal
            $('#mdlInfo').modal('show');
            // show modal
        }
        function bindProject(Batch) {
            $.ajax({
                type: "POST",
                url: "HNDDSB.ashx",
                data: {
                    'FormCode': 'DSB080000',
                    'Type': 'Project',
                    'Batch': Batch
                },
                success: function (response) {
                    DisplayProject(response)
                },
            });
        }
        function DisplayProject(response) {
            //datatable
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });

            var gvProject = $("#gvProject").DataTable({
                bFilter: true,
                bPaginate: false,
                bDestroy: true,
                bInfo: false,
                scrollX: true,
                scrollY: '55.4vh',
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                fixedColumns: { left: 1 },
                select: false,
                data: response,
                columns: [
                    { data: 'No' },
                    { data: 'Batch' },
                    { data: 'Subd' },
                    { data: 'Phase' },
                    { data: 'Block' },
                    { data: 'Lot' },
                    { data: 'House' },
                    { data: 'Target011' },
                    { data: 'Status011' },
                    { data: 'DateSecured011' },
                    { data: 'Target002' },
                    { data: 'Status002' },
                    { data: 'DateSecured002' },
                    { data: 'Target014' },
                    { data: 'Status014' },
                    { data: 'DateSecured014' },
                    { data: 'Target008' },
                    { data: 'Status008' },
                    { data: 'DateSecured008' },
                    { data: 'Target012' },
                    { data: 'Status012' },
                    { data: 'DateSecured012' },
                    { data: 'Target001' },
                    { data: 'Status001' },
                    { data: 'DateSecured001' },
                    { data: 'Target003' },
                    { data: 'Status003' },
                    { data: 'DateSecured003' },
                    { data: 'Target013' },
                    { data: 'Status013' },
                    { data: 'DateSecured013' },
                    { data: 'Target005' },
                    { data: 'Status005' },
                    { data: 'DateSecured005' },
                    { data: 'Target009' },
                    { data: 'Status009' },
                    { data: 'DateSecured009' },
                    { data: 'Target006' },
                    { data: 'Status006' },
                    { data: 'DateSecured006' },
                    { data: 'Target007' },
                    { data: 'Status007' },
                    { data: 'DateSecured007' },
                    { data: 'Target010' },
                    { data: 'Status010' },
                    { data: 'DateSecured010' }]
            });
            //datatable
            //search
            $('#tbxFindProject').on('keyup', function () {
                gvProject.search(this.value).draw();        
            });
            //search
            //export
            const documentTitle = 'House Construction';
            var buttons = new $.fn.dataTable.Buttons(gvProject, {
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
            }).container().appendTo($('#divExportButton'));
            // Hook dropdown menu click event to datatable export buttons
            const exportButtons = document.querySelectorAll('#divExportMenu [data-kt-export]');
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
        $(document).ready(function () {
            var checkbox = $("#<%= cbx02WithEWT.ClientID %>");
            var textbox = $("#<%= tbx02WithEWT.ClientID %>");

            // Initially disable the textbox
            textbox.prop("disabled", true);

            // Toggle textbox enabled/disabled on checkbox change
            checkbox.change(function () {
                if ($(this).is(":checked")) {
                    textbox.prop("disabled", false);
                } else {
                    textbox.prop("disabled", true);
                    textbox.val(""); // Clear value when disabled
                }
            });
        });

       

        function makeTableEditable() {
            let checkbox = document.getElementById("<%= cbxpost.ClientID %>");
            if (checkbox.checked) {
                Alert01("warning", "You cannot edit the table when the checkbox is checked!", "");
                return;
            }

            let table = document.getElementById("gv01Form");
            let rows = table.querySelectorAll("tbody tr");

            rows.forEach(row => {
                let cells = row.querySelectorAll("td");
                cells.forEach((cell, index) => {
                    if ([6, 7, 9, 10].includes(index)) { // Editable columns: 6, 7, 9, 10
                        if (!cell.querySelector("input")) {
                            let text = cell.innerText.trim();
                            let input = document.createElement("input");
                            input.type = "text";
                            input.className = "table-input";
                            input.value = formatToN2(text);
                            input.style.textAlign = "right";
                            // Format and compute when the user leaves the field
                            input.addEventListener("blur", function () {
                                this.value = formatToN2(this.value); // ✅ Now formats with commas
                                computeRowValues(row);
                            });
                            if (index === 10) {
                                input.addEventListener("input", function () {
                                    this.dataset.userEdited = "true"; // Mark that the user has changed the value
                                });
                            }

                            input.addEventListener("input", function () {
                                let cursorPosition = this.selectionStart; // Save cursor position
                                let value = this.value.replace(/,/g, '').replace(/[^0-9.]/g, ''); // Remove commas and non-numeric characters
                                let parts = value.split('.');

                                // Format the integer part with commas
                                parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");

                                // Reconstruct value with decimal part
                                this.value = parts.join('.');   

                                // Restore cursor position
                                this.setSelectionRange(cursorPosition, cursorPosition);
                            });
                            input.dataset.userEdited = "";
                            // ✅ Ensure Column 10 triggers recalculation when changed
                            if (index === 10) {
                                input.addEventListener("change", function () {
                                    computeRowValues(row);
                                });
                            }

                            cell.innerHTML = "";
                            cell.appendChild(input);
                        }
                    }
                });
            });
  
            // Toggle buttons
            document.getElementById("<%= editTableBtn.ClientID %>").style.display = "none";
           document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "inline-flex";
            document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "inline-flex";
            disableLinkButtons();
        }
        // Function to format value as N2 (two decimal places)
        function formatToN2(value) {
            if (!value) return "0.00";

            let num = parseFloat(value.replace(/,/g, '')); // Remove commas before parsing
            if (isNaN(num)) return "0.00";

            return num.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        }

        function computeRowValues(row) {
            let cells = row.querySelectorAll("td");

            function getNumericValue(inputElement) {
                if (!inputElement) return 0;
                let value = inputElement.value.replace(/,/g, '').trim(); // Remove commas
                return parseFloat(value) || 0;
            }

            let present = getNumericValue(cells[6].querySelector("input"));  // Column 6 (Input)
            let previous = getNumericValue(cells[7].querySelector("input")); // Column 7 (Input)
            let kwhUsedCell = cells[8]; // Column 8 (Auto Computed)
            let amountInput = cells[10].querySelector("input");     // Column 10 (Editable)
            let currentCell = cells[11]; // Column 11 (Auto - Copies Column 10)
            let arrearsCell = cells[12]; // Column 12 (Declared)
            let othersCell = cells[13];  // Column 13 (Declared)
            let totalCell = cells[14];   // Column 14 (Auto)

            // 1️⃣ Compute Column 8 (KWH Used) = Column 6 - Column 7
            let kwhUsed = present >= previous ? (present - previous) : 0;
            kwhUsedCell.innerText = kwhUsed.toFixed(2);

            if (amountInput && !amountInput.dataset.userEdited) {
                amountInput.value = kwhUsed.toFixed(2);
            }
            // 3️⃣ Column 11 = Always copy Column 10 dynamically
            if (currentCell && amountInput) {
                currentCell.innerText = amountInput.value;
            }

            // 4️⃣ Compute Column 14 = Column 11 + Column 12 + Column 13
            function getCellValue(cell) {
                return parseFloat(cell.innerText.replace(/,/g, '').trim()) || 0;
            }

            let arrears = getCellValue(arrearsCell);
            let others = getCellValue(othersCell);
            let current = getCellValue(currentCell);
            let total = arrears + others + current;

            if (totalCell) {
                totalCell.innerText = total.toFixed(2);
            }
            updateFooterSums();
       
        }


        function CancelTableChanges() {
            Swal.fire({
                html: `
        <div class="swal-header">Message</div>
        <div class="separator"></div>
        <div class="swal-body">Cancel record?</div>
        <div class="separator"></div>
    `,
                icon: null,
                showCancelButton: true,
                cancelButtonText: "Cancel",
                confirmButtonText: "Ok",
                buttonsStyling: false,
                reverseButtons: true, // Swap the button positions
                customClass: {
                    popup: "swal-popup",
                    confirmButton: "swal-confirm-btn",
                    cancelButton: "swal-cancel-btn",
                    htmlContainer: "swal-html-content"
                }
 


            }).then((result) => {
              
                if (result.isConfirmed) {
                    // ✅ Convert table back to text format (remove inputs)
                    let rows = document.querySelectorAll("#gv01Form tbody tr"); // Change 'yourTableId' to the actual table ID

                    rows.forEach(row => {
                        let formatCell = (cellIndex) => {
                            let cell = row.cells[cellIndex];
                            let input = cell?.querySelector("input");

                            if (input) {
                                let num = parseFloat(input.value.replace(/,/g, '')) || 0;
                                input.remove(); // Remove input field
                                cell.innerText = num.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            }
                        };

                        // Loop through cells to remove inputs
                        for (let i = 0; i < row.cells.length; i++) {
                            formatCell(i);
                        }
                    });
                    // Toggle buttons after successful save
                    document.getElementById("<%= editTableBtn.ClientID %>").style.display = "inline-flex";
                    document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "none";
                    document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "none";
                    enableLinkButtons(); // This runs after the user closes the alert
                }
            });
        }


        function saveTableChanges() {
            let table = document.getElementById("gv01Form");
            let rows = table.querySelectorAll("tbody tr");
            let srsData = [];

            rows.forEach(row => {
                let id = row.getAttribute("data-id") || (row.cells[4] ? row.cells[4].innerText.trim() : "N/A");

                // Function to get input or innerText value safely
                let getValue = (cellIndex) => {
                    let cell = row.cells[cellIndex];
                    let input = cell?.querySelector("input");
                    let rawValue = input ? input.value.trim() : cell.innerText.trim(); // Get input value or innerText
                    console.log(`Raw Value (Column ${cellIndex}):`, rawValue); // Debugging

                    let cleanValue = rawValue.replace(/,/g, ''); // Remove commas before parsing
                    return parseFloat(cleanValue) || 0;
                };

                let present = getValue(6);
                let previous = getValue(7);
                let factorRate = getValue(9);
                let amount = getValue(10);

                // Get computed values directly from table
                let kwhUsed = parseFloat(row.cells[8].innerText.trim().replace(/,/g, '')) || 0;
                let current = parseFloat(row.cells[11].innerText.trim().replace(/,/g, '')) || 0;
                let arrears = parseFloat(row.cells[12].innerText.trim().replace(/,/g, '')) || 0;
                let others = parseFloat(row.cells[13].innerText.trim().replace(/,/g, '')) || 0;
                let total = parseFloat(row.cells[14].innerText.trim().replace(/,/g, '')) || 0;

                // Format row data using '©' as delimiter
                let rowData = `${id}©${present}©${previous}©${kwhUsed}©${factorRate}©${amount}©${current}©${arrears}©${others}©${total}`;
                srsData.push(rowData);
            });

            // ✅ Convert table back to text format (remove inputs)
            rows.forEach(row => {
                let formatCell = (cellIndex) => {
                    let cell = row.cells[cellIndex];
                    let input = cell?.querySelector("input");

                    if (input) {
                        let num = parseFloat(input.value.replace(/,/g, '')) || 0;
                        input.remove(); // Remove input field
                        cell.innerText = num.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    }
                };

                formatCell(6); 
                formatCell(7); 
                formatCell(8);  
                formatCell(9);
                formatCell(10); 
                formatCell(11); 
                formatCell(12); 
                formatCell(13);
                formatCell(14); 
            });

            console.log("Final Data Sent to Server:", srsData);


            // Combine all rows using '®' as delimiter
            let pSRS = srsData.join('®');
            let pBillCode = document.getElementById("<%= lblID.ClientID %>")?.innerText.trim() || "Unknown";
            let pAuditUser = document.getElementById("<%= Empcode.ClientID %>").value;
       
            // Debugging output
            console.log("pSRS:", pSRS);
            console.log("pBillCode:", pBillCode);
            console.log("pAuditUser:", pAuditUser);

            // Call WebMethod to save data
            $.ajax({
                type: "POST",
                url: "PMD020100.aspx/UpdateElectricBill",
                data: JSON.stringify({ pBillCode, pSRS, pAuditUser }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    let data = response.d;

                    Swal.fire({
                        text: "Record saved successfully!",
                        icon: data.status === "success" ? "success" : "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: data.status === "success" ? "btn btn-primary" : "btn btn-danger"
                        }
                    }).then(() => {
                        enableLinkButtons(); // This runs after the user closes the alert
                    });

                   
                    rows.forEach(row => {
                        [6, 7, 9, 10].forEach(index => { // Only columns 6, 7, 9, and 10 are editable
                            let cell = row.cells[index];
                            let input = cell?.querySelector("input");
                            if (input) {
                                let value = parseFloat(input.value.trim());
                                cell.innerHTML = isNaN(value)
                                    ? "0.00"
                                    : value.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            }
                        });
                    });


                    // Toggle buttons after successful save
                    document.getElementById("<%= editTableBtn.ClientID %>").style.display = "inline-flex";
                    document.getElementById("<%= saveTableBtn.ClientID %>").style.display = "none";
                    document.getElementById("<%= cancelTableBtn.ClientID %>").style.display = "none";
                    
                   
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", xhr.responseText);
                    Swal.fire({
                        text: "An error occurred: " + xhr.responseText,
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn btn-danger"
                        }
                    });
                }
            });
        
        }

        function disableLinkButtons() {
            var buttons = [
                "<%= lbtn01Refresh.ClientID %>",
                "<%= lbtn01Add.ClientID %>",
                "<%= lbtn01Delete.ClientID %>",
                "<%= lbtn01Edit.ClientID %>",
                "<%= lbtn01Lock.ClientID %>",
                "<%= lbtn01Unlock.ClientID %>",
                "<%= lbtn01Post.ClientID %>",
                "<%= lbtn01Unpost.ClientID %>",
                "<%= lbtn01Tools.ClientID %>",
                "<%= lbtn02add.ClientID %>"
            ];

            buttons.forEach(function (btnId) {
                var btn = document.getElementById(btnId);
                if (btn) {
                    // Store original class only once
                    if (!btn.dataset.originalClass) {
                        btn.dataset.originalClass = btn.className;
                    }

                    // Remove color classes
                    btn.classList.remove("btn-primary", "btn-success", "btn-danger", "btn-warning", "btn-info");

                    // Disable button
                    btn.classList.add("disabled", "btn-secondary");
                    btn.disabled = true;
                }
            });
        }

        function enableLinkButtons() {
            var buttons = [
                "<%= lbtn01Refresh.ClientID %>",
                "<%= lbtn01Add.ClientID %>",
                "<%= lbtn01Delete.ClientID %>",
                "<%= lbtn01Edit.ClientID %>",
                "<%= lbtn01Lock.ClientID %>",
                "<%= lbtn01Unlock.ClientID %>",
                "<%= lbtn01Post.ClientID %>",
                "<%= lbtn01Unpost.ClientID %>",
                "<%= lbtn01Tools.ClientID %>",
                "<%= lbtn02add.ClientID %>"
            ];

            buttons.forEach(function (btnId) {
                var btn = document.getElementById(btnId);
                if (btn) {
                    // Restore the original class if it was stored
                    if (btn.dataset.originalClass) {
                        btn.className = btn.dataset.originalClass;
                    }

                    // Remove 'disabled' and 'btn-secondary' classes
                    btn.classList.remove("disabled", "btn-secondary");
                    btn.disabled = false;
                }
            });
        }



        function updateFooterSums() {
            let sumCurrRead = 0, sumPrevRead = 0, sumKWHUsed = 0, sumFactorRate = 0;
            let sumBillAmt = 0, sumTotBill = 0, sumArrears = 0, sumOthAmt = 0, sumNetBill = 0;
            let sumEWTBill = 0, totalNetBill = 0;

            const cleanNumber = (value) => {
                if (!value) return 0;  // Prevent undefined errors
                return parseFloat(value.toString().replace(/,/g, '').trim()) || 0;
            };

            document.querySelectorAll("#gv01Form tbody tr").forEach((row, index) => {
                let cells = row.querySelectorAll("td");

                let currRead = cleanNumber(cells[6]?.querySelector("input")?.value || cells[6]?.innerText);
                let prevRead = cleanNumber(cells[7]?.querySelector("input")?.value || cells[7]?.innerText);
                let kwhUsed = cleanNumber(cells[8]?.innerText);
                let factorRate = cleanNumber(cells[9]?.innerText);
                let billAmt = cleanNumber(cells[10]?.querySelector("input")?.value || cells[10]?.innerText);
                let totBill = cleanNumber(cells[11]?.innerText);
                let arrears = cleanNumber(cells[12]?.innerText);
                let othAmt = cleanNumber(cells[13]?.innerText);
                let netBill = cleanNumber(cells[14]?.innerText);
                let ewtBill = cleanNumber(cells[15]?.innerText);

                sumCurrRead += currRead;
                sumPrevRead += prevRead;
                sumKWHUsed += kwhUsed;
                sumFactorRate += factorRate;
                sumBillAmt += billAmt;
                sumTotBill += totBill;
                sumArrears += arrears;
                sumOthAmt += othAmt;
                sumNetBill += netBill;
                sumEWTBill += ewtBill;
            });

            totalNetBill = sumTotBill - sumEWTBill;

            const formatNumber = (num) => num.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 });

            document.querySelector("#footerCurrRead").innerText = formatNumber(sumCurrRead);
            document.querySelector("#footerPrevRead").innerText = formatNumber(sumPrevRead);
            document.querySelector("#footerKWHUsed").innerText = formatNumber(sumKWHUsed);
            document.querySelector("#footerFactorRate").innerText = formatNumber(sumFactorRate);
            document.querySelector("#footerBillAmt").innerText = formatNumber(sumBillAmt);
            document.querySelector("#footerTotBill").innerText = formatNumber(sumTotBill);
            document.querySelector("#footerArrears").innerText = formatNumber(sumArrears);
            document.querySelector("#footerOthAmt").innerText = formatNumber(sumOthAmt);
            document.querySelector("#footerNetBill").innerText = formatNumber(sumNetBill);
            document.querySelector("#footersumEWTBill").innerText = formatNumber(sumEWTBill);
            document.querySelector("#footersumTotalnetbill").innerText = formatNumber(totalNetBill);
        }

    </script>
	<!-- scripts related to this page -->
     
</asp:Content>
