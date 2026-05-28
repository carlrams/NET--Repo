<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="DSB140000.aspx.vb" Inherits="NET.DSB140000" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
      .total-creation-chart {
            font-size: 20px !important;
        }
     .polar-wrapper {
        position: relative;
        width: 100%;
    }

    .polar-total {
        position: absolute;
        bottom: 5px;
        right: 65px;
        font-size: 17px;
        font-weight: 600;
        color: #1E88E5;
        pointer-events: none;
    }

    </style>

	<div class="content flex-row-fluid" id="kt_content">
		<!--begin::breadcrumb bar-->
		<div class="toolbar py-1">
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">DCR Dashboard</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white"></li>
					</ul>
				</div>
			</div>
            <div class="d-flex align-items-center py-3 py-md-1 pe-2">
                <!--end::Wrapper-->
                <a id="AFilter" class="btn btn-bg-white pointer" href="#" onclick="fn0101filter();return false;" >Filter</a>
                 
                <!--end::Button-->
            </div>
           
            
		</div>

        <div class="row g-4">
            <div class="col-md-6 col-lg-4 col-xxl-4 mb-5">
                <a class="card card-xxl-stretch pointer" style="height: 300px;" onclick="fn03List('Document Creation')">
                    <div class="d-flex flex-column ps-10">
                        <span id="" class="text-dark fw-bolder fs-1 mb-0 mt-5"></span>
                        <div class="text-muted fw-bold fs-3 pb-5">Document Creation</div>
                    </div>
                   <div>
                        <div id="PolarAreaCreation"></div>
                        <div id="polarTotalCreation" class="polar-total"></div>
                    </div>
                </a>
            </div>
            <div class="col-md-6 col-lg-4 col-xxl-4 mb-5">
              <a class="card card-xxl-stretch pointer" style="height: 300px;" onclick="fn03List('Document Revision')">
                  <div class="d-flex flex-column ps-10">
                      <span id="" class="text-dark fw-bolder fs-1 mb-0 mt-5"></span>
                      <div class="text-muted fw-bold fs-3 pb-5">Document Revision</div>
                  </div>
                      <div>
                         <div id="PolarAreaRevision"></div>
                       <div id="polarTotalRevision" class="polar-total"></div>
                    </div>
              </a>
            </div>
            <div class="col-md-6 col-lg-4 col-xxl-4 mb-5">
                <a class="card card-xxl-stretch pointer" style="height: 300px;" onclick="fn03List('Document Obsoletion')">
                    <div class="d-flex flex-column ps-10">
                        <span id="" class="text-dark fw-bolder fs-1 mb-0 mt-5"></span>
                        <div class="text-muted fw-bold fs-3 pb-5">Document Obsoletion</div>
                    </div>
                    <div>
                        <div id="PolarAreaObsoletion"></div>
                        <div id="polarTotalObsoletion" class="polar-total"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="row g-4">
            <div class="col-md-6 col-xxl-6 mb-5">
                <a class="card card-xxl-stretch pointer" style="height: 400px;">

                    <!-- Make ONE flex container -->
                    <div class="d-flex align-items-center ps-10 pt-4 w-100">

                        <span class="text-muted fw-bold fs-2">Form - Line Graph</span>

                        <!-- Push select to the right -->
                        <div class="ms-auto pe-10">
                            <select id="ddlYear" data-kt-repeater="select2" class="fs-7 form-select form-control form-control-md mw-125px flatpickr-input" onchange="Load4()"></select>
                        </div>

                    </div>

                    <div id="LineGraph"></div>

                </a>
            </div>
          <div class="col-md-6 col-xxl-6 mb-5">
              <a class="card card-xxl-stretch pointer" style="height: 400px;" onclick="">
                  <div class="d-flex flex-column ps-10">
                      <span id="" class="text-dark fw-bolder fs-1 mb-0 mt-5"></span>
                      <div class="text-muted fw-bold fs-2">Originating Department</div>
                  </div>
                 <div id="PieChart" class="pt-5 d-flex justify-content-center">
                </div>

              </a>
            </div>
       </div>
        <div class="row gx-5">
            <div class="col-xxl-12 mb-5">
                <div class="card card-flush">
                    <div class="d-flex flex-stack pt-5">
                        <div class="d-flex ms-10 me-5 pt-4">
                           <div class="text-muted fw-bold fs-3 pb-5">DOCUMENT CREATION/CHANGE REQUEST (DCR) LOG </div>
                        </div>
                        <div class="position-relative me-5">
                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                </svg>
                            </span>
                            <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                        </div>
                    </div>
                    <div class="card-body pt-5">
                        <div class="table-responsive">
                            <table id="tbl01Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                <thead>
                                    <tr>
                                        <th rowspan="2" class="min-w-125px w-125px fw-bold align-middle border-end">DCR No.</th>
                                        <th rowspan="2" class="min-w-100px w-100px text-start align-middle fw-bold border-end">Date<br/>Received</th>
                                        <th rowspan="2" class="min-w-150px w-150px text-start align-middle fw-bold border-end">Document No.</th>
                                        <th colspan="3" class="min-w-350px w-350px text-start align-middle fw-bold border-end">Documented Information</th>
                                        <th rowspan="2" class="min-w-150px w-150px text-center fw-bold align-middle border-end">Requested by<br/>Originating Department</th>
                                        <th rowspan="2" class="min-w-125px w-125px text-center fw-bold align-middle border-end">Action Taken<br/>Changes made</th>
                                        <th rowspan="2" class="min-w-150px w-150px text-center fw-bold align-middle border-end">Target Date of<br/>Implementation</th>
                                        <th rowspan="2" class="min-w-125px w-125px text-center fw-bold align-middle border-end">Actual Date of<br/>Completon</th>
                                        <th rowspan="2" class="min-w-70px w-70px fw-bold align-middle border-end">Aging<br/>(TAT)</th>
                                        <th rowspan="2" class="min-w-100px w-100px align-middle fw-bold border-end">Status</th>
                                    </tr>
                                    <tr>
                                         <th class="min-w-200px fw-bold text-start border-end ">Title</th>
                                         <th class="min-w-100px fw-bold text-start border-end ">Type</th>
                                         <th class="min-w-60px fw-bold text-start border-end ">Rev No.</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
         </div>


        
      
        	
	
	
    
        <div id="mdl0101Filter" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered mw-650px">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Filter record</h5>
						<!--begin::Close-->
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
                        <div class="row g-2 mb-2">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <div class="input-group input-group-sm">
                                    <span class="input-group-text min-w-150px required">Orig. Department</span>
                                    <asp:ListBox ID="ddl03Department" runat="server" 
                                        CssClass="form-select form-select-sm select2 border-0" SelectionMode="Multiple"
                                        style="min-width: 30%; max-width: 30%; flex-grow: 1; min-height: 50px;">
                                    </asp:ListBox>
                                </div>
                            </div>

                        </div>
                    </div>
					<!--begin::Actions-->
					<div class="modal-footer">
						<div class="d-flex flex-center flex-row-fluid">
							<button class="btn btn-sm btn-info fw-bolder min-w-100px m-1" onclick="fn0201Filter_Ok(this);return false;">
								<span class="indicator-label">
									Filter
								</span>
								<span class="indicator-progress">
									Loading
								</span>
							</button>
							<button class="btn btn-sm btn-light-danger min-w-100px" onclick="$('#mdl0101Filter').modal('hide');return false;">
								Cancel
							</button>
						</div>
					</div>
					<!--end::Actions-->
				</div>
			</div>
		</div>

      	<!--begin::Modal List-->
	    <div id="mdl01List" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-fullscreen">
                <div class="modal-content shadow-none">
				    <div class="modal-header">
					    <h5 id="spn01ListTitle" class="modal-title"></h5>
                        <!--begin::Close-->
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-danger" data-bs-dismiss="modal" aria-label="Close" title="Close">
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
                    <!--begin::Card header-->
                    <div class="card-header">
                        <div class="d-flex align-items-center pt-4">
                              <div id="list01Type" class="text-muted fw-bold fs-3 pb-5"></div>
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
                                    <input id="tbx01ModalFind" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                </div>
                                <!--end::Search-->
                            </div>
                        </div>
                    </div>
                    <!--end::Card header-->
				    <div class="modal-body">
                        <!--begin::Files-->
                        <div class="table-loading" style="min-height:62.3vh;">
                            <div id="div01Loader" class="table-loading-message">
                                Loading...
                            </div>
                            <table id="table01List" class="table table-row-bordered border rounded gy-2 gs-2 w-100 align-middle">
                                <thead>
                                    <tr>
                                        <th rowspan="2" class="min-w-100px w-100px fw-bold align-middle border-end">DCR No.</th>
                                        <th rowspan="2" class="min-w-100px w-100px text-start align-middle fw-bold border-end">Date<br />
                                            Received</th>
                                        <th rowspan="2" class="min-w-150px w-150px text-start align-middle fw-bold border-end">Document No.</th>
                                        <th colspan="3" class="min-w-350px w-350px text-start align-middle fw-bold border-end">Documented Information</th>
                                        <th rowspan="2" class="min-w-150px w-150px text-center fw-bold align-middle border-end">Requested by<br />
                                            Originating Department</th>
                                        <th rowspan="2" class="min-w-125px w-125px text-center fw-bold align-middle border-end">Action Taken<br />
                                            Changes made</th>
                                        <th rowspan="2" class="min-w-150px w-150px text-center fw-bold align-middle border-end">Target Date of<br />
                                            Implementation</th>
                                        <th rowspan="2" class="min-w-125px w-125px text-center fw-bold align-middle border-end">Actual Date of<br />
                                            Completon</th>
                                        <th rowspan="2" class="min-w-70px w-70px fw-bold align-middle border-end">Aging<br />
                                            (TAT)</th>
                                        <th rowspan="2" class="min-w-100px w-100px align-middle fw-bold border-end">Status</th>
                                    </tr>
                                    <tr>
                                        <th class="min-w-200px fw-bold text-start border-end ">Title</th>
                                        <th class="min-w-100px fw-bold text-start border-end ">Type</th>
                                        <th class="min-w-60px fw-bold text-start border-end ">Rev No.</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
			                <!--end::Files-->
                        </div>
				    </div>
                    <!--begin::Actions-->
                    <div class="modal-footer">
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Close</span>
                         </a>
                    </div>
                    <!--end::Actions-->
			    </div>
		    </div>
	    </div>
   
	    <!--begin::Modal List-->

    </div>
	<!--param-->
    <input id="hdn01IDPrev" type="hidden" value="" />
    <input id="hdn01ID" type="hidden" value="" />
	<input id="hdn01Mode" type="hidden" value="" />



	<!--param-->
   <script src="https://cdnjs.cloudflare.com/ajax/libs/apexcharts/3.52.0/apexcharts.min.js"></script>

    <script src="Assets/js/DSB/DSB140000.js"></script>
    <script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>