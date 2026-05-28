<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002001.aspx.vb" Inherits="NET.AAD020100" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<div class="content flex-row-fluid" id="kt_content">

		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Account Inquiry</li>
					</ul>
				</div>
			</div>
		</div>
		
		<div class="card">
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
					<div class="d-flex flex-column">
						<h2 class="mb-1"><span id="spn02Title">-</span></h2>
						<div class="text-muted fw-bolder">
							<span id="spn02Status">-</span>
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
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex">
										<button id="btn02Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn02Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
										<button id="btnTools" class="btn btn-sm btn-icon btn-tools align-self-center m-1" title="Tools" onclick="fn10001Tools();return false;"><i class="las la-cog fs-2"></i></button>
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="row g-2">
									<div class="col-sm-12 col-md-12 col-lg-9">
										<div class="row g-2">
											<div class="col-sm-12 col-md-12 col-lg-5">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Account</span>
													<span id="lbl02AcctNo" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-7">
												<span id="lbl02AcctName" class="form-control form-control-sm">-</span>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-5">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Project</span>
													<span id="lbl02Project" class="form-control text-truncate">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-7">
												<span id="lbl02ModelName" class="form-control form-control-sm">-</span>
											</div>
										</div>
									</div>
									<div class="col-sm-12 col-md-12 col-lg-3">
										<div class="row g-2">
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Status</span>
													<span id="lbl02Status" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Balance</span>
													<span id="lbl02Balance" class="form-control">-</span>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="card-header border-0">
								<div class="d-flex align-items-center">
									<ul class="nav nav-tabs nav-line-tabs nav-line-tabs-2x fs-6 me-2">
										<li class="nav-item">
											<a class="nav-link active w-85px text-center" data-bs-toggle="tab" href="#tab0301">Information</a>
										</li>
										<li class="nav-item">
											<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0302">Summary</a>
										</li>
										<li class="nav-item">
											<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0303">Status</a>
										</li>
										<li class="nav-item">
											<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0304">Documents</a>
										</li>
										<li class="nav-item">
											<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0305">Schedule</a>
										</li>
										<li class="nav-item">
											<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0306">Ledger</a>
										</li>
										<li class="nav-item">
											<a class="nav-link w-85px text-center" data-bs-toggle="tab" href="#tab0307">Others</a>
										</li>
									</ul>
								</div>
							</div>
							<div class="card">
                                <div class="tab-content" >
									<div class="tab-pane fade show active ps-9 pe-9 pt-0 pb-0" id="tab0301">
										<div class="row g-2">
											<div class="card-title fs-5 fw-bolder ms-2">Primary Data</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Account Type</span>
													<span id="lbl02ContractTypeName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Acct. Name</span>
													<span id="lbl02FullName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Last Name</span>
													<span id="lbl02LastName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">First Name</span>
													<span id="lbl02FirstName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Middle Name</span>
													<span id="lbl02MiddleName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Suffix</span>
													<span id="lbl02Suffix" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Birth Date</span>
													<span id="lbl02BirthDate" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Gender</span>
													<span id="lbl02GenderName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Citizenship</span>
													<span id="lbl02CitizenshipName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Civil Status</span>
													<span id="lbl02CivilStatusName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Address</span>
													<span id="lbl02HomeAddress" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Country</span>
													<span id="lbl02HomeCountryName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">City</span>
													<span id="lbl02HomeCityName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Town</span>
													<span id="lbl02HomeTownPlace" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Zip Code</span>
													<span id="lbl02HomeTownCode" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Yrs. of stay</span>
													<span id="lbl02YearsofStay" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Ownership</span>
													<span id="lbl02OwnershipName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Email</span>
													<span id="lbl02Emailaddress" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Mobile No</span>
													<span id="lbl02MobileNo" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">TIN</span>
													<span id="lbl02TIN" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">SSS</span>
													<span id="lbl02SSS" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">UMID</span>
													<span id="lbl02UMID" class="form-control">-</span>
												</div>
											</div>
											<div class="card-title fs-5 fw-bolder ms-2">Employment</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Employer</span>
													<span id="lbl02Employer" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Address</span>
													<span id="lbl02EmployerAddress" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Country</span>
													<span id="lbl02EmpCountryName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">City</span>
													<span id="lbl02EmpCityName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Town</span>
													<span id="lbl02EmpTownPlace" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Zip Code</span>
													<span id="lbl02EmpTownCode" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Yrs. of stay</span>
													<span id="lbl02WorkYears" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Position</span>
													<span id="lbl02Position" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Type</span>
													<span id="lbl02EmploymentTypeName" class="form-control">-</span>
												</div>
											</div>
											<div class="card-title fs-5 fw-bolder ms-2">Mailing Address</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Address</span>
													<span id="lbl02MailingAddress" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Country</span>
													<span id="lbl02MailingCountryCodeName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">City</span>
													<span id="lbl02MailingCityName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Town</span>
													<span id="lbl02MailingTownPlace" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Zip Code</span>
													<span id="lbl02MailingTownCode" class="form-control">-</span>
												</div>
											</div>
										</div>
									</div>
									<div class="tab-pane fade ps-9 pe-9 pt-0 pb-0" id="tab0302">
										<div class="row g-2">
											<div class="card-title fs-5 fw-bolder ms-2">Online Payment</div>
											<div class="col-sm-12 col-md-12 col-lg-12 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Acct. Code</span>
													<span id="lbl02AcctCode" class="form-control">-</span>
												</div>
											</div>
											<div class="card-title fs-5 fw-bolder ms-2">Seller</div>
											<div class="col-sm-12 col-md-12 col-lg-12 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Seller</span>
													<span id="lbl02SellerCodeName" class="form-control">-</span>
												</div>
											</div>
											<div class="card-title fs-5 fw-bolder ms-2">Financing & Terms</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">DOE</span>
													<span id="lbl02RFDate" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Financing</span>
													<span id="lbl02FinancingSchemeName" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Payment Term</span>
													<span id="lbl02PmtTerm" class="form-control">-</span>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="row g-2">
													<div class="card-title fs-5 fw-bolder ms-2">Contract Price</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Selling Price</span>
															<span id="lbl02Sellingprice" class="form-control fw-boldest">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">Less : Disc. (Fixed)</span>
															<span id="lbl02TCPDiscount" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">Less : Disc. (Var.)</span>
															<span id="lbl02VATDiscAmt" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">TCP</span>
															<span id="lbl02TCP" class="form-control fw-boldest">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">Add : VAT (if any)</span>
															<span id="lbl02VATAmount" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">TCP Net</span>
															<span id="lbl02TCPNet" class="form-control fw-boldest">-</span>
														</div>
													</div>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="row g-2">
													<div class="card-title fs-5 fw-bolder ms-2">Downpayment / Equity</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Downpayment</span>
															<span id="lbl02DPAmount" class="form-control fw-boldest">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">Discount</span>
															<span id="lbl02PromoDPDiscount" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">Reservation Fee</span>
															<span id="lbl02RFAmount" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">No. of instll.</span>
															<span id="lbl02DPTerms" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Monthly DP</span>
															<span id="lbl02MoDP" class="form-control fw-boldest">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Payment Start</span>
															<span id="lbl02FirstDPDue" class="form-control fw-boldest">-</span>
														</div>
													</div>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="row g-2">
													<div class="card-title fs-5 fw-bolder ms-2">Amortization / Loan</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Balance</span>
															<span id="lbl02ExternalLoan" class="form-control fw-boldest">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px text-secondary">-</span>
															<span id="lbl02" class="form-control text-white">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">Interest Rate</span>
															<span id="lbl02InterestRate" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px">No. of instll.</span>
															<span id="lbl02MATerms" class="form-control">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Monthly DP</span>
															<span id="lbl02MAAmt" class="form-control fw-boldest">-</span>
														</div>
													</div>
													<div class="col-sm-12 col-md-12 col-lg-12 mb-2">
														<div class="input-group input-group-sm">
															<span class="input-group-text min-w-150px fw-boldest">Payment Start</span>
															<span id="lbl02FirstMADue" class="form-control fw-boldest">-</span>
														</div>
													</div>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="card-title fs-5 fw-bolder ms-2">Remarks</div>
												<div class="input-group input-group-sm">
													<span class="input-group-text input-group-text-top min-w-150px">Remarks</span>
													<span id="lbl02Remarks" class="form-control">-</span>
												</div>
											</div>
										</div>
									</div>
									<div class="tab-pane fade p-0" id="tab0303">
										<div class="card">
											<div class="border-top border-bottom border-gray-200 px-4 py-3">
												<div class="d-flex flex-stack">
													<div class="d-flex">
														<button id="btn0303Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Tag Status" onclick="return false;"><i class="las la-check-square fs-2"></i></button>
													</div>
													<div class="position-relative">
														<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
																<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
															</svg>
														</span>
														<input id="tbx0303Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
													</div>
												</div>
											</div>
											<div class="table-responsive p-9">
												<table id="table0303Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-check-square fs-3'></i></span></th>
															<th class="min-w-150px mw-150px border-end">Group</th>
															<th class="min-w-200px mw-200px">Status</th>
															<th class="min-w-150px mw-150px">Date</th>
															<th class="min-w-200px mw-200px">Remarks</th>
															<th class="min-w-150px mw-150px">By</th>
															<th class="w-100"></th>
														</tr>
													</thead>
													<tbody>

													</tbody>
												</table>
											</div>
										</div>
									</div>
									<div class="tab-pane fade p-0" id="tab0304">
										<div class="card">
											<div class="border-top border-bottom border-gray-200 px-4 py-3">
												<div class="d-flex flex-stack">
													<div class="d-flex">
														<button id="btn0304Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Receive Documents" onclick="return false;"><i class="las la-check-square fs-2"></i></button>
													</div>
													<div class="position-relative">
														<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
																<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
															</svg>
														</span>
														<input id="tbx0304Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
													</div>
												</div>
											</div>
											<div class="table-responsive p-9">
												<table id="table0304Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px fw-bold border-end" style="padding-left:15px"><span title="Lock"><i class='las la-check-square fs-3'></i></span></th>
															<th class="min-w-150px mw-150px border-end">Type</th>
															<th class="min-w-200px mw-200px">Description</th>
															<th class="min-w-100px mw-100px">Doc No</th>
															<th class="min-w-100px mw-100px">Doc Date</th>
															<th class="min-w-100px mw-100px">Exp Date</th>
															<th class="min-w-200px mw-200px">Remarks</th>
															<th class="min-w-150px mw-150px">Received By</th>
															<th class="min-w-150px mw-150px">Received Date</th>
															<th class="w-100"></th>
														</tr>
													</thead>
													<tbody>

													</tbody>
												</table>
											</div>
										</div>
									</div>
									<div class="tab-pane fade p-0" id="tab0305">
										<div class="card">
											<div class="border-top border-bottom border-gray-200 px-4 py-3">
												<div class="d-flex flex-stack">
													<div class="d-flex">
														<button id="btn0305Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Receive Documents" onclick="return false;"><i class="las la-check-square fs-2"></i></button>
													</div>
													<div class="position-relative">
														<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
																<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
															</svg>
														</span>
														<input id="tbx0305Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
													</div>
												</div>
											</div>
											<div class="table-responsive p-9">
												<table id="table0305Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px fw-bold" style="padding-left:15px"><span title="Paid"><i class='las la-check-square fs-3'></i></span></th>
															<th class="min-w-50px mw-50px">No</th>
															<th class="min-w-100px mw-100px text-start">Due Date</th>
															<th class="min-w-150px mw-150px">Description</th>
															<th class="min-w-100px mw-100px text-start">Total</th>
															<th class="min-w-100px mw-100px text-start">Interest</th>
															<th class="min-w-100px mw-100px text-start">Principal</th>
															<th class="min-w-100px mw-100px text-start">Balance</th>
															<th class="min-w-100px mw-100px text-start">Paid Pen.</th>
															<th class="min-w-100px mw-100px text-start">Paid Int.</th>
															<th class="min-w-100px mw-100px text-start">Paid Prin.</th>
															<th class="min-w-100px mw-100px text-start">Balance</th>
															<th class="w-100"></th>
														</tr>
													</thead>
													<tbody>

													</tbody>
												</table>
											</div>
										</div>
									</div>
									<div class="tab-pane fade p-0" id="tab0306">
										<div class="card">
											<div class="border-top border-bottom border-gray-200 px-4 py-3">
												<div class="d-flex flex-stack">
													<div class="d-flex">
														<button id="btn0306Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Receive Documents" onclick="return false;"><i class="las la-check-square fs-2"></i></button>
													</div>
													<div class="position-relative">
														<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
																<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
															</svg>
														</span>
														<input id="tbx0306Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
													</div>
												</div>
											</div>
											<div class="table-responsive p-9">
												<table id="table0306Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
													<thead class="fw-bold">
														<tr class="fw-bold fs-7 text-gray-800">
															<th class="min-w-50px mw-50px">No</th>
															<th class="min-w-100px mw-100px text-center">Doc No</th>
															<th class="min-w-100px mw-100px text-center">Doc Date</th>
															<th class="min-w-150px mw-150px">Doc Desc</th>
															<th class="min-w-100px mw-100px text-start">Total</th>
															<th class="min-w-100px mw-100px text-start">Penalty</th>
															<th class="min-w-100px mw-100px text-start">Interest</th>
															<th class="min-w-100px mw-100px text-start">Principal</th>
															<th class="min-w-100px mw-100px text-start">Balance</th>
															<th class="w-100"></th>
														</tr>
													</thead>
													<tbody>

													</tbody>
												</table>
											</div>
										</div>
										</div>
									<div class="tab-pane fade show active ps-9 pe-9 pt-0 pb-0" id="tab0307">
										<div class="row g-5">
											<div class="col-lg-2 col-md-4 col-sm-6 h-auto">
												<a id="a0307AAD002002" class="btn btn-light h-100 w-100">Non ICR Schedule</a>
											</div>
											<div class="col-lg-2 col-md-4 col-sm-6 h-auto">
												<a class="btn btn-light h-100 w-100">Non ICR Schedule</a>
											</div>
											<div class="col-lg-2 col-md-4 col-sm-6 h-auto">
												<a class="btn btn-light h-100 w-100">Non ICR Schedule</a>
											</div>
											<div class="col-lg-2 col-md-4 col-sm-6 h-auto">
												<a class="btn btn-light h-100 w-100">Non ICR Schedule</a>
											</div>
											<div class="col-lg-2 col-md-4 col-sm-6 h-auto">
												<a class="btn btn-light h-100 w-100">Non ICR Schedule</a>
											</div>
											<div class="col-lg-2 col-md-4 col-sm-6 h-auto">
												<a class="btn btn-light h-100 w-100">Non ICR Schedule</a>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Attachment</div>
							</div>
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex">
										<button id="btn98Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Upload" onclick="return false;"><i class="las la-upload fs-2"></i></button>
									</div>
									<div class="position-relative">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<input id="tbx98Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<table id="table98Record" class="table table-row-bordered border rounded g-2 w-100 align-middle">
										<thead class="fw-bold">
											<tr class="fw-bold fs-7 text-gray-800">
												<th class="min-w-50px mw-50px border-end" style="padding-left:15px"><span title="Action"><i class='las la-bars fs-3'></i></span></th>
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
						<div class="card">
							<div class="card-header">
								<div class="card-title fs-3 fw-bolder">Notes</div>
							</div>
							<div class="border-bottom border-gray-200 px-4 py-3">
								<div class="d-flex flex-stack">
									<div class="d-flex">
										<button id="btn99Add" class="btn btn-sm btn-icon btn-add align-self-center m-1" title="Add" onclick="fn99Add();return false;"><i class="las la-comment fs-2"></i></button>
									</div>
									<div class="position-relative">
										<span class="svg-icon svg-icon-3 svg-icon-gray-500 position-absolute top-50 translate-middle ms-6">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
												<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
											</svg>
										</span>
										<input id="tbx99Find" type="text" data-kt-inbox-listing-filter="search" class="form-control form-control-sm form-control-solid mw-100 min-w-150px min-w-md-200px ps-10" placeholder="Search" />
									</div>
								</div>
							</div>
							<div class="card-body">
								<div class="table-responsive">
									<table id="table99Record" class="table gy-2 gs-2 w-100 align-middle">
										<thead style="display:none">
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
						<div class="dropzone mb-5" id="div98DropZone">
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
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>
	
		<div id="mdl9901Notes" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true" data-bs-focus="false">
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
						<textarea id="tbx9901Note" class="form-control form-control-sm mention h-75px min-h-200px mh-200px" Placeholder="Notes"></textarea>
					</div>
                    <div class="modal-footer">
                        <button class="btn btn-sm btn-primary fw-bolder min-w-100px m-1" onclick="fn9901Add(this);return false;">
                            <span class="indicator-label">
                                Add Note
                            </span>
                            <span class="indicator-progress">
                                Saving
                            </span>
                        </button>
                         <a href="#" class="btn btn-sm btn-light-danger fw-bolder min-w-100px" data-bs-dismiss="modal" aria-label="Close" title="Close">
                             <span class="indicator-label">Cancel</span>
                         </a>
                    </div>
				</div>
			</div>
		</div>

        <div id="mdl10001Tools" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
            <div class="modal-dialog modal-fullscreen">
                <div class="modal-content shadow-none">
                    <div class="modal-header">
                        <h5 class="modal-title">Account Inquiry - Tools</h5>
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
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01Seller();">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_Seller.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Tag Account Status</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-3 col-sm-6 ">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01ContactNo();">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_ContactNo.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Attachment</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-3 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01CoBorrowers()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_CoBorrowers.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Other Charges</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-3 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01Packagelots()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_PackagedLots.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Payment Order</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDC()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_PDC.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Account Diary</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01Document()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_DocumentStatus.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Debit Memo</div>
                                        </a>
                                    </div>
                                </div>
                            </div> 
						</div>
						<div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01AccountDiary()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_AccountDiary.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Credit Memo</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDDPromo()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_Promo.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Commission</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDC()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_PDC.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Account Reactivation</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 ">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01Document()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_DocumentStatus.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Buyers Profile</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01AccountDiary()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_AccountDiary.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Out. Bal. Restructure</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDDPromo()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_Promo.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Account Modification</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDC()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_PDC.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Update Buyers Information</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 ">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01Document()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_DocumentStatus.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Change of Due Date</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01AccountDiary()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_AccountDiary.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Update Selling Price</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDDPromo()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_Promo.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Overriding Comm. (Old)</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDC()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_PDC.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">House Turnover Schedule</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6  mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01Document()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_DocumentStatus.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Transfer of Rights</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
						</div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01AccountDiary()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_AccountDiary.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Notice of Release</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDDPromo()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_Promo.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Notice of Approval</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-12 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDC()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/AAD060100_PDC.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">CTS Financing Ledger</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Payment Schedule</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(ICR)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Payment Schedule</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(Non-ICR)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Buyer's Ledger</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(ICR)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Buyer's Ledger</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(Non-ICR)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Statement of Account</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Statement of Account</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(FI)</div>
                                    </div>
                                </div>
                            </div>
						</div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Contract to Sell</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">CTS Amendment</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Annex E</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(Old)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Annex E</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(New)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Commission Release</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Acct. Summary Update</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Statement of Account</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(LTO)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">EForm</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Status</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">House Turnover</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Notice of Turnover</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">SOA</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(Pre-Approved)</div>
                                    </div>
                                </div>
                            </div>
						</div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2 col-sm-6 ml-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">SOA</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400">(Post-Approved)</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="PSNonICR()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Memorandum of Agreement</div>
                                        </a>
                                        <div class="fs-7 fw-bold text-gray-400"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-12 mr-auto">
                                <div class="card h-100">
                                    <div class="card-body d-flex justify-content-center text-center flex-column p-8">
                                        <a class="text-gray-800 d-flex flex-column pointer" onclick="btn01PDC()">
                                            <div class="symbol symbol-60px mb-5">
                                                <img src="Assets/media/svg/apps/RPT.svg" alt="" />
                                            </div>
                                            <div class="fs-5 fw-bolder mb-2">Authorization To Deduct Bank Charges</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
	</div>

    <input id="hdn02IDPrev" type="hidden" value="" />
	<input id="hdn02ID" type="hidden" value="" />
	<input id="hdn02Mode" type="hidden" value="DTL" />

	<input id="hdn99Mention" type="hidden" value="DTL" />

    <script src="Assets/js/AAD/AAD002001.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
