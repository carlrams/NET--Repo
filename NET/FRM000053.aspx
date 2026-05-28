<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="FRM000053.aspx.vb" Inherits="NET.FRM000053" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
        
		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white"><a href="FRM010000" class="text-white">Form</a></li>
						<li class="breadcrumb-item text-white">-</li>
						<li class="breadcrumb-item text-white">Suppliers Performance Evaluation</li>
					</ul>
				</div>
			</div>
		</div>

        <div class="card">
			
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
                    <div class="symbol me-5">
                        <img src="Assets/media/svg/apps/FRM000053.svg" alt="" />
                    </div>
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn0101Title">-</span></h2>
						<div class="text-muted fw-bolder"> 
							<span id="spn0101ID">-</span>
							<span class="mx-3">|</span>
							<span id="spn0101Status">-</span>
						</div>
					</div>
				</div>
			</div>
			
			<div class="card-body pt-3 pb-0">
				<div class="d-flex flex-stack">
					<div class="d-flex overflow-auto">
						<ul class="nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bold flex-nowrap">
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary active" title="Overview" data-bs-toggle="tab" href="#tab020101"><i class="las la-file-alt fs-3x"></i></a>
							</li>
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary" title="Subscribers" data-bs-toggle="tab" href="#tab030101"><i class="las la-user-friends fs-3x"></i></a>
							</li>
							<li class="nav-item m-0">
								<a class="nav-link text-active-primary" title="History" data-bs-toggle="tab" href="#tab040101"><i class="las la-history fs-3x"></i></a>
							</li>
						</ul>
					</div>
				</div>
			</div>

			
			<div class="card" >
				<div class="tab-content" >
                    <div class="tab-pane fade show active" id="tab020101">
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">Overview</div>
                            </div>
							<div class="card-header">
								<div class="d-flex flex-wrap">
									<button id="btn0101Find" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Find" onclick="fn0101Find();return false;"><i class="las la-search fs-2"></i></button>
									<button id="btn0101Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn0101Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
									<button id="btn0101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0101Add();return false;"><i class="las la-plus fs-2"></i></button>
									<button id="btn0101Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1" title="Remove" onclick="fn0101Delete();return false;"><i class="las la-trash fs-2"></i></button>
									<button id="btn0101Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn0101Edit();return false;"><i id="i0101Edit" class="las la-pencil-alt fs-2"></i></button>
									<button id="btn0101ChangeStatus" class="btn btn-sm btn-secondary align-self-center m-1" title="Change Status" onclick="fn0101ChangeStatus();return false;">Change Status</button>
								
								</div>
							</div>
                            <!--begin:: Details -->
                            <div id="div0101Detail" class="card-body">
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">ID</span>
                                    <span id="lbl0101ID" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Type</span>
                                    <span id="lbl0101FormType" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Requested</span>
                                    <span id="lbl0101DateRequested" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Required</span>
                                    <span id="lbl0101DateRequired" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Requested By</span>
                                    <span id="lbl0101RequestedBy" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Assigned To</span>
                                    <span id="lbl0101AssignedTo" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Endorsed To</span>
                                    <span id="lbl0101EndorsedTo" class="form-control"></span>
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Status</span>
                                    <span id="lbl0101Status" class="form-control"></span>
                                </div>
                                <div class="separator separator-dashed my-6"></div>
                                <div class="input-group input-group-sm mb-2">
				                    <span class="input-group-text input-group-text-top min-w-150px">Supplier</span>
				                    <span id="lbl0101Supplier" class="form-control">-</span>
                                </div>
                                <div class="row border border-radius-047rem pt-3 m-05 mb-2">
									<div class="card-body py-3">
										<div class="table-responsive">
											<table class="table table-row-dashed table-row-gray-300 align-middle gs-0 gy-4">
												<thead>
													<tr class="fw-bolder text-muted">
														<th class="min-w-200px">Description</th>
														<th class="min-w-150px text-center">A (10 pts.) 
															<br />
															Above Average
														</th>
														<th class="min-w-150px text-center">B (8 pts.)
															<br />
															Average
														</th>
														<th class="min-w-150px text-center">C (6 pts.)
															<br />
															Below Average
														</th>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">1. Prompt response of inquiry.</span>
																</div>
															</div>
														</td>
														<td>
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" data-points="10" value="" id="cbx0101" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Quick to respond on inquiries.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" data-points="8" value="" id="cbx0102" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Requires average explanation to respond on inquiries.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0103" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Requires more explanations to respond on inquiries.
									                            </label>
								                            </div>
														</td>
													</tr>
                                                    
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">2. Attitude of sales staff.</span>
																</div>
															</div>
														</td>
														<td>
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0201" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Sales Staff are really cooperative on transactions.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0202" onclick="return false;"/>
									                            <label class="form-check-label">
										                            No problem on Sales Staff attitude.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0203" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Seldom cooperative to inquiries or transactions.
									                            </label>
								                            </div>
														</td>
													</tr>
                                                    
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">3. Competitive pricing.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0301" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Costings are always competitively priced and with discounts.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0302" onclick="return false;"/>
									                            <label class="form-check-label">
										                            No problem on costings.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0303" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Costings are always high against competition.
									                            </label>
								                            </div>
														</td>
													</tr>

													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">4. Product / Service availability.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0401" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Products/Services required are always available.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0402" onclick="return false;"/>
									                            <label class="form-check-label">
										                            No problem on Products/ Services availability.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0403" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Needed products/ services are always not-available.
									                            </label>
								                            </div>
														</td>
													</tr>
                                                    
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">5. On time delivery of product / service.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0501" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Products/Services are always delivered on time.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0502" onclick="return false;"/>
									                            <label class="form-check-label">
										                            No problem on Products/ Services delivery time.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0503" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Always late on delivery of products or services.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">6. Product / Service quality consistency.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0601" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Products / Services always conform on requirements.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0602" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Minor quality inconsistency on products / services.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0603" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Almost all products / services rendered are inferior.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">7. After sales service (Supplier initiative efforts).</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0701" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier have the initiative to know performance.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0702" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier just meet job order requirements.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0703" onclick="return false;"/>
									                            <label class="form-check-label">
										                            No after sales-service.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">8. Timeliness of billings.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0801" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier always endorse billings in a timely manner.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0802" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier sometimes late on billing endorsement.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0803" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier are always late on billings endorsement.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">9. Business stability.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx0901" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier been in business for more than 7 years.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx0902" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier been in business for 3 - 6 years.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx0903" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier been in business for 2 years.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr>
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">10. In placed Quality Management System.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="10" id="cbx1001" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier performance on 4,5,6 & 7 is more than average.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="8" id="cbx1002" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier performance on 4,5,6 & 7 is average.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input" type="checkbox" value="" data-points="6" id="cbx1003" onclick="return false;"/>
									                            <label class="form-check-label">
										                            Supplier performance on 4,5,6 & 7 is below average.
									                            </label>
								                            </div>
														</td>
													</tr>

													<tr>
														<td class="w-30 text-end">
															<span class="text-dark fw-bolder text-hover-primary fs-6">Total</span>
														</td>
														<td class="w-25 text-center">
								                            <span class="text-dark fw-bolder text-hover-primary fs-6">(A): <span id="spn0101Total">0</span></span>
														</td>
														<td class="w-25 text-center">
								                            <span class="text-dark fw-bolder text-hover-primary fs-6">(B): <span id="spn0102Total">0</span></span>
														</td>
														<td class="w-25 text-center">
								                            <span class="text-dark fw-bolder text-hover-primary fs-6">(C): <span id="spn0103Total">0</span></span>
														</td>
													</tr>
													
												</tbody>
											</table>
										</div>
										<div class="d-flex justify-content-end">
											<span class="text-dark fw-bolder text-hover-primary fs-6 text-center" id="spn0101Overall">Overall: 0
                                                <br />
												<span class="fst-italic">(Total Points)</span>
											</span>
										</div>
										<span class="text-dark fw-bolder text-hover-primary fs-6 fst-italic">Ratings:</span>
										
										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">A :</span>
											<span class="input-group-text min-w-150px bg-white">90 - 100</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Good</span>
										</div>

										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">B :</span>
											<span class="input-group-text min-w-150px bg-white">80 - 89</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Satisfactory</span>
										</div>
										
										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">C :</span>
											<span class="input-group-text min-w-150px bg-white">70 - 79</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Poor</span>
										</div>
										
										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">D :</span>
											<span class="input-group-text min-w-150px bg-white">69 and below</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Drop from the list</span>
										</div>

									</div>
                                </div>

                                <div class="input-group input-group-sm mt-2">
                                    <span class="input-group-text min-w-150px">Remarks</span>
									<textarea id="lbl0101Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols="" readonly="readonly"></textarea>
                                </div>
                            </div>
                            <!--End:: Details -->

                            <!--begin:: Update/Edit/Add -->
                            <div id="div0101Update" class="card-body" style="display: none;">
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">ID</span>
                                    <input id="tbx0101ID" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Type</span>
                                    <input id="tbx0101FormType" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Date Requested</span>
                                    <input id="tbx0101DateRequested" type="text" class="form-control" readonly="readonly" />

                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px required">Date Required</span>
                                    <input id="tbx0101DateRequired" type="text" data-kt-repeater="datepicker" class="form-control" readonly="readonly" placeholder="Pick a date" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Requested By</span>
                                    <input id="tbx0101RequestedBy" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Assigned To</span>
                                    <input id="tbx0101AssignedTo" type="text" class="form-control" readonly="readonly" />

                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Endorsed To</span>
                                    <input id="tbx0101EndorsedTo" type="text" class="form-control" readonly="readonly" />
                                </div>
                                <div class="input-group input-group-sm mb-2">
                                    <span class="input-group-text min-w-150px">Status</span>
                                    <input id="tbx0101Status" type="text" class="form-control" readonly="readonly" />
                                </div>

                                <div class="separator separator-dashed my-6"></div>
								<div class="input-group input-group-sm mb-2">
									<span class="input-group-text min-w-150px required">Supplier</span>
							        <select id="ddl0101Supplier" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                                        <option value="">Select Supplier</option>
                                    </select>
								</div>
                                <div class="row border border-radius-047rem pt-3 m-05 mb-2">
									<div class="card-body py-3">
										<div class="table-responsive">
											<table class="table table-row-dashed table-row-gray-300 align-middle gs-0 gy-4">
												<thead>
													<tr class="fw-bolder text-muted">
														<th class="min-w-200px">Description</th>
														<th class="min-w-150px text-center">A (10 pts.) 
															<br />
															Above Average
														</th>
														<th class="min-w-150px text-center">B (8 pts.)
															<br />
															Average
														</th>
														<th class="min-w-150px text-center">C (6 pts.)
															<br />
															Below Average
														</th>
													</tr>
												</thead>
												<tbody>
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">1. Prompt response of inquiry.</span>
																</div>
															</div>
														</td>
														<td>
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" data-points="10" value="" id="cbx0101_id"/>
									                            <label class="form-check-label">
										                            Quick to respond on inquiries.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" data-points="8" value="" id="cbx0102_id"/>
									                            <label class="form-check-label">
										                            Requires average explanation to respond on inquiries.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0103_id"/>
									                            <label class="form-check-label">
										                            Requires more explanations to respond on inquiries.
									                            </label>
								                            </div>
														</td>
													</tr>
                                                    
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">2. Attitude of sales staff.</span>
																</div>
															</div>
														</td>
														<td>
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0201_id"/>
									                            <label class="form-check-label">
										                            Sales Staff are really cooperative on transactions.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0202_id"/>
									                            <label class="form-check-label">
										                            No problem on Sales Staff attitude.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0203_id"/>
									                            <label class="form-check-label">
										                            Seldom cooperative to inquiries or transactions.
									                            </label>
								                            </div>
														</td>
													</tr>
                                                    
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">3. Competitive pricing.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0301_id"/>
									                            <label class="form-check-label">
										                            Costings are always competitively priced and with discounts.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0302_id"/>
									                            <label class="form-check-label">
										                            No problem on costings.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0303_id"/>
									                            <label class="form-check-label">
										                            Costings are always high against competition.
									                            </label>
								                            </div>
														</td>
													</tr>

													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">4. Product / Service availability.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0401_id"/>
									                            <label class="form-check-label">
										                            Products/Services required are always available.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0402_id"/>
									                            <label class="form-check-label">
										                            No problem on Products/ Services availability.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0403_id"/>
									                            <label class="form-check-label">
										                            Needed products/ services are always not-available.
									                            </label>
								                            </div>
														</td>
													</tr>
                                                    
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">5. On time delivery of product / service.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0501_id"/>
									                            <label class="form-check-label">
										                            Products/Services are always delivered on time.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0502_id"/>
									                            <label class="form-check-label">
										                            No problem on Products/ Services delivery time.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0503_id"/>
									                            <label class="form-check-label">
										                            Always late on delivery of products or services.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">6. Product / Service quality consistency.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0601_id"/>
									                            <label class="form-check-label">
										                            Products / Services always conform on requirements.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0602_id"/>
									                            <label class="form-check-label">
										                            Minor quality inconsistency on products / services.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0603_id"/>
									                            <label class="form-check-label">
										                            Almost all products / services rendered are inferior.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">7. After sales service (Supplier initiative efforts).</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0701_id"/>
									                            <label class="form-check-label">
										                            Supplier have the initiative to know performance.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0702_id"/>
									                            <label class="form-check-label">
										                            Supplier just meet job order requirements.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0703_id"/>
									                            <label class="form-check-label">
										                            No after sales-service.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">8. Timeliness of billings.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0801_id"/>
									                            <label class="form-check-label">
										                            Supplier always endorse billings in a timely manner.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0802_id"/>
									                            <label class="form-check-label">
										                            Supplier sometimes late on billing endorsement.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0803_id"/>
									                            <label class="form-check-label">
										                            Supplier are always late on billings endorsement.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">9. Business stability.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx0901_id"/>
									                            <label class="form-check-label">
										                            Supplier been in business for more than 7 years.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx0902_id"/>
									                            <label class="form-check-label">
										                            Supplier been in business for 3 - 6 years.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx0903_id"/>
									                            <label class="form-check-label">
										                            Supplier been in business for 2 years.
									                            </label>
								                            </div>
														</td>
													</tr>
													
													<tr class="question-row">
														<td class="w-30">
															<div class="d-flex align-items-center">
																<div class="d-flex justify-content-start flex-column">
																	<span class="text-dark fw-bolder text-hover-primary fs-6">10. In placed Quality Management System.</span>
																</div>
															</div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="10" id="cbx1001_id"/>
									                            <label class="form-check-label">
										                            Supplier performance on 4,5,6 & 7 is more than average.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="8" id="cbx1002_id"/>
									                            <label class="form-check-label">
										                            Supplier performance on 4,5,6 & 7 is average.
									                            </label>
								                            </div>
														</td>
														<td class="w-25">
								                            <div class="form-check form-check-sm form-check-custom form-check-solid">
									                            <input class="form-check-input score" type="checkbox" value="" data-points="6" id="cbx1003_id"/>
									                            <label class="form-check-label">
										                            Supplier performance on 4,5,6 & 7 is below average.
									                            </label>
								                            </div>
														</td>
													</tr>

													<tr>
														<td class="w-30 text-end">
															<span class="text-dark fw-bolder text-hover-primary fs-6">Total</span>
														</td>
														<td class="w-25 text-center">
								                            <span class="text-dark fw-bolder text-hover-primary fs-6">(A): <span id="spn01Total">0</span></span>
														</td>
														<td class="w-25 text-center">
								                            <span class="text-dark fw-bolder text-hover-primary fs-6">(B): <span id="spn02Total">0</span></span>
														</td>
														<td class="w-25 text-center">
								                            <span class="text-dark fw-bolder text-hover-primary fs-6">(C): <span id="spn03Total">0</span></span>
														</td>
													</tr>
													
												</tbody>
											</table>
										</div>
										<div class="d-flex justify-content-end">
											<span class="text-dark fw-bolder text-hover-primary fs-6 text-center" id="spn01Overall">Overall: 0
                                                <br />
												<span class="fst-italic">(Total Points)</span>
											</span>
										</div>
										<span class="text-dark fw-bolder text-hover-primary fs-6 fst-italic">Ratings:</span>
										
										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">A :</span>
											<span class="input-group-text min-w-150px bg-white">90 - 100</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Good</span>
										</div>

										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">B :</span>
											<span class="input-group-text min-w-150px bg-white">80 - 89</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Satisfactory</span>
										</div>
										
										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">C :</span>
											<span class="input-group-text min-w-150px bg-white">70 - 79</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Poor</span>
										</div>
										
										<div class="input-group input-group-sm border-0">
											<span class="input-group-text min-w-150px bg-white fst-italic">D :</span>
											<span class="input-group-text min-w-150px bg-white">69 and below</span>
											<span class="input-group-text min-w-150px bg-white fst-italic">=> Drop from the list</span>
										</div>
										
									</div>
                                </div>
                              
                                <div class="input-group input-group-sm mt-2">
                                    <span class="input-group-text min-w-150px required">Remarks</span>
                                    <textarea id="tbx0101Remarks" class="form-control" placeholder="Add remarks" maxlength="500" rows="3" cols=""></textarea>
                                </div>
                            </div>

                            <!--begin:: Attatchment -->
                            <div class="card">
                                <div class="card-header">
                                    <div class="card-title fs-3 fw-bolder">Attachment</div>
                                </div>
                                <div class="border-bottom border-gray-200 px-4 py-3">
                                    <div class="d-flex flex-stack">
                                        <div class="d-flex ms-5">
                                            <button id="btn98Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="return false;"><i class="las la-upload fs-2"></i></button>
                                        </div>
                                        <div class="position-relative me-5">
                                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                                </svg>
                                            </span>
                                            <input id="tbx0201FindAttachment" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="table-responsive">
										<div id="div0201LoaderAttachment" class="table-loading-message">
											Loading...
										</div>
                                        <table id="table0201Attachment" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                            <thead class="fw-bold">
                                                <tr class="fw-bold fs-7 text-gray-800">
                                                    <th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
                                                    <th class="min-w-50px mw-50px border-end">Type</th>
                                                    <th class="min-w-200px w-100">Name</th>
                                                    <th class="min-w-200px mw-200px">By</th>
                                                    <th class="min-w-200px mw-200px">Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <!--End:: Attatchment -->

                        <!--begin:: Approval Path -->
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Approval Path</div>
							</div>
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex ms-5">
										<button id="btn989Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add Approval Path" onclick="fn0401AddApproval(); return false;"><i class="las la-user-plus fs-2"></i></button>
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<div id="div0401LoaderApprover" class="table-loading-message">
										Loading...
									</div>
									<table id="table0401Approver" class="table  table-row-bordered border table-hover rounded g-2 w-100 align-middle">
										<thead class="fw-bold">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="mw-5px min-w-5px" style="color: transparent; font-size: 0; padding: 0;">Bullet</th>
												<th class="min-w-50px mw-50px border-end" style="padding-left: 15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
												<th class="min-w-150px mw-150px border-end">Type</th>
												<th class="min-w-300px w-100 border-end">User</th>
												<th class="min-w-150px mw-150px border-end">Status</th>
												<th class="min-w-150px mw-150px border-end">Turn Around Time</th>
												<th class="min-w-300px mw-300px">Reason for delay</th>
											</tr>
										</thead>
										<tbody>

										</tbody>
									</table>
								</div>
							</div>
						</div>
                        <!--End:: Approval Path -->

                            <!--begin:: Notes -->
                            <div class="card">
                                <div class="card-header">
                                    <div class="card-title fs-3 fw-bolder">Notes</div>
                                </div>
                                <div class="border-bottom border-gray-200 px-4 py-3">
                                    <div class="d-flex flex-stack">
                                        <div class="d-flex ms-5">
                                            <button id="btn99Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn0301Add();return false;"><i class="las la-comment fs-2"></i></button>
                                        </div>
                                        <div class="position-relative me-5">
                                            <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                    <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                    <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                                </svg>
                                            </span>
                                            <input id="tbx0301FindNotes" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                        </div>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="table-responsive">
										<div id="div0301LoaderNotes" class="table-loading-message">
											Loading...
										</div>
                                        <table id="table0301Notes" class="table gy-2 gs-2 w-100 align-middle">
                                            <thead style="display: none">
                                                <tr class="fw-bold fs-7 text-gray-800">
                                                    <th class="min-w-100px w-100">Notes</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <!--End:: Notes -->
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tab030101">
                        <!--begin:: Subscriber -->
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">Subscribers</div>
                            </div>
                            <div class="border-bottom border-gray-200 px-4 py-3">
                                <div class="d-flex flex-stack">
                                    <div class="d-flex ms-5">
                                        <button id="btn03010101Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add Subscriber" onclick="fn0502AddSubscriber(); return false;"><i class="las la-user-plus fs-2"></i></button>
                                    </div>
                                    <div class="position-relative me-5">
                                        <span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                                <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                                <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                            </svg>
                                        </span>
                                        <input id="tbx03010101Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
									<div id="div0501LoaderSubscriber" class="table-loading-message">
										Loading...
									</div>
                                    <table id="table0501Subscriber" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                        <thead class="fw-bold">
                                            <tr class="fw-bold fs-7 text-gray-800">
												<th class="mw-5px min-w-5px" style="color: transparent; font-size: 0; padding: 0;">Bullet</th>
                                                <th class="min-w-75px mw-75px">Action</th>
                                                <th class="min-w-200px w-100">User</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!--End:: Subscriber -->
                    </div>
                    <div class="tab-pane fade" id="tab040101">
                       <!--begin:: History -->
                        <div class="card">
                            <div class="card-header">
                                <div class="card-title fs-3 fw-bolder">History</div>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table id="table0601History" class="table table-row-bordered border rounded g-2 w-100 align-middle">
                                        <thead class="fw-bold">
                                            <tr class="d-none">
                                                <th class="min-w-200px w-100">Data</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!--End:: History -->
                    </div>
				</div>
			</div>
        </div>
		
		<div id="mdl9801Upload" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Attachment - Upload</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
						<div class="dropzone mb-5" id="divDropzone">
							<div class="dz-message needsclick">
								<i class="bi bi-file-earmark-arrow-up text-primary fs-3x"></i>
								<div class="ms-4">
									<h3 class="fs-5 fw-bolder text-gray-900 mb-1">Drop files here or click to upload.</h3>
									<span class="fs-7 fw-bold text-gray-400">Upload up to 10 files, maximum of 10mb per file</span>
								</div>
							</div>
						</div>
					</div>
                    <div class="modal-footer">
                        <button id="btn9801Add" class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="return false;">
                            <span class="indicator-label">
                                Upload
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

		<div id="mdl0302Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
			<div class="modal-dialog modal-dialog-centered mw-650px" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Notes - Add Note</h5>
						<div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
							<span class="svg-icon svg-icon-1">
								<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
									<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
									<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
								</svg>
							</span>
						</div>
					</div>
					<div class="modal-body">
						<textarea id="tbx0302Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Notes"  rows="3" cols=""></textarea>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0301Add_Ok(this);return false;">
                            <span class="indicator-label">
                                Add Note
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

        <div id="mdl0103Status" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Overview - Change Status</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text min-w-150px required">Change status to</span>
                            <select id="ddl0103ChangeStatus" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0103ChangeStatus_onchange(this);">
                            </select>
                        </div>
                        <div id="pnl01ClarifyTo" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Clarify to</span>
                            <select id="ddl0103Clarifyto" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                        <div class="input-group input-group-sm mb-2">
                            <span id="spn01Note" class="input-group-text input-group-text-top min-w-150px">Notes</span>
                            <textarea id="tbx0103Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" placeholder="Add extra details" rows="3" cols=""></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0101SaveChangeStatus(this); return false;">
                            <span class="indicator-label">Save changes
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl0501AddSubscriber" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Subscribers - Add User</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body">
						<div class="input-group input-group-sm mb-2">
							<span class="input-group-text min-w-150px required">User</span>
							<select id="ddl0501AddUser" data-kt-repeater="select2" data-dropdown-parent="#mdl0501AddSubscriber" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
						</div>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0502AddSubscriber_Ok(this);return false;">
                            <span class="indicator-label">Add User
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl0401Aprroval" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Add User</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text min-w-150px required">Add from</span>
                            <select id="ddl0401AddFrom" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0401AddFrom_onchange(this)">
                                <option value="">Select a type</option>
                                <option value="Manual">Manual</option>
                                <option value="Template">Template</option>
                            </select>
                        </div>
                        <div id="pnl04Type" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Type</span>
                            <select id="ddl0401Type" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px" onchange="ddl0401Type_onchange(this)">
                                <option value="">Select a type</option>
                                <option value="Endorsed By">Endorsed By</option>
                                <option value="Approved By">Approved By</option>
                                <option value="Implementer">Implementer</option>
                            </select>
                        </div>
                        <div id="pnl04AssignTo" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Approver</span>
                            <select id="ddl0401Approver" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                        <div id="pnl04NoDays" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">No. of days</span>
                            <input id="tbx04NoDays" class='form-control' onblur="FormatNumeric(this.id);" onkeypress=" return isNumberKey(event)" type="text" value="0.00" />
                        </div>
                        <div id="pnl04Template" class="input-group input-group-sm mb-2" style="display: none;">
                            <span class="input-group-text min-w-150px required">Type</span>
                            <select id="ddl0401Template" data-kt-repeater="select2" data-dropdown-parent="#mdl0401Aprroval" class="form-select form-select-sm form-select-border min-h-38px">
                            </select>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0401AddApprover_Ok(this);return false;">
                            <span class="indicator-label">Add
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl0402Reason4Delays" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Reason for delay</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text input-group-text-top min-w-150px required">Reason for delay</span>
							<textarea id="tbx0402ReasonForDelay" class="form-control" placeholder="Add remarks" maxlength="1000" rows="3" cols=""></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn0402AddReason_Ok(this);return false;">
                            <span class="indicator-label">Save
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div id="mdl01Find" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-fullscreen" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Find record</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body min-h-80px mh-80px overflow-hidden">
						<div class="d-flex align-items-center">
							<div class="position-relative">
								<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
										<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
									</svg>
								</span>
                                <input id="tbx01Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-12" placeholder="Search" />
							</div>
						</div>
					</div>
                    <div class="modal-body">
                        <div style="overflow-x:auto; scrollbar-width: thin;">
                            <table id="table98Find" class="table table-no-border table-row-bordered table-hover align-middle w-100">
                                <thead>
                                    <tr class="d-none">
                                        <th class="mw-5px min-w-5px">Bullet</th>
                                        <th class="w-100">Data</th>
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

        <div id="mdl01UpdateApprover" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
            <div class="modal-dialog modal-dialog-centered mw-650px" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Approval Path - Update Approver</h5>
                        <div class="btn btn-sm btn-icon btn-bg-white btn-active-white btn-active-color-success" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="svg-icon svg-icon-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                    <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                    <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                                </svg>
                            </span>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="input-group input-group-sm mb-2">
                            <span class="input-group-text input-group-text-top min-w-150px required">Approver</span>
                            <select id="ddl01UpdApprover" data-kt-repeater="select2" class="form-select form-select-transparent form-select-sm h-5px mt-2">
                                <option value="">Select an approver</option>
                            </select>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn989SaveUpdApprover();return false;">
                            <span class="indicator-label">Save
                            </span>
                            <span class="indicator-progress">Saving
                            </span>
                        </button>
                        <a href="#" class="btn btn-sm btn-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                            <span class="indicator-label">Cancel</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>

    </div>
    
	<input id="hdnPrevID" runat="server" type="hidden" value="" />
    <input id="hdnID" runat="server" type="hidden" value="" />
	<input id="hdnMode" runat="server" type="hidden" value="" />
	<input id="hdnMention" type="hidden" value="" />
	<input id="hdnSeqNo" runat="server" type="hidden" value="" />

    <script type="text/javascript" src="Assets/js/FRM/FRM000053.js"></script>
	<script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
