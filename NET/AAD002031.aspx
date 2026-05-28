<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="AAD002031.aspx.vb" Inherits="NET.AAD002031" MaintainScrollPositionOnPostback = "true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="content flex-row-fluid" id="kt_content">

		<div class="toolbar py-5">
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<div class="page-title d-flex flex-column me-3">
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">Apps</h1>
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<li class="breadcrumb-item text-white">Account Inquiry - Tools - Update Buyers Information</li>
					</ul>
				</div>
			</div>
		</div>
		
		<div class="card">
			<div class="card-header pt-5 border-bottom-0">
				<div class="d-flex align-items-center">
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/AAD002000.svg" alt="" />
					</div>
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
									<div class="d-flex ms-3">
										<button id="btn02Refresh" class="btn btn-sm btn-icon btn-view align-self-center m-1" title="Refresh" onclick="fn02Refresh();return false;"><i class="las la-redo-alt fs-2"></i></button>
										<span class="bullet h-25px w-2px bg-secondary mt-2 m-1"></span>
										<button id="btn02Delete" class="btn btn-sm btn-icon btn-delete align-self-center m-1 d-none" title="Remove" onclick="fn02Delete();return false;"><i class="las la-trash fs-2"></i></button>
										<button id="btn02Edit" class="btn btn-sm btn-icon btn-edit align-self-center m-1" title="Edit" onclick="fn02Edit();return false;"><i id="i02Edit" class="las la-pencil-alt fs-2"></i></button>
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
											<div id="div02HeaderDtl" class="col-sm-12 col-md-12 col-lg-7" style="display: none;">
												<span id="lbl02ModelName" class="form-control form-control-sm">-</span>
											</div>
											<div id="div02HeaderUpd" class="col-sm-12 col-md-12 col-lg-4">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">House Model</span>
													<select id="ddl02HouseModel" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">House Model</option>
													</select>
												</div>
											</div>
											<div id="div02HeaderUpdSpec" class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<input id="tbx02HouseSpec" type="text" maxlength="60" class="form-control" Placeholder="House Spec" readonly="readonly" />
												</div>
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
									</ul>
								</div>
							</div>
							<div class="card">
                                <div class="tab-content" >
									<div class="tab-pane fade show active ps-9 pe-9 mb-5" id="tab0301">
										<div id="div02Detail" class="row g-2" style="display: none;">
											<div class="card-title fs-5 fw-bolder ms-2">Primary Data</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Acct. Type</span>
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
										<div id="div02Update" class="row g-2">
											<div class="card-title fs-5 fw-bolder ms-2">Primary Data</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px required">Acct. Type</span>
													<select id="ddl02AcctType" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">Type</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px required">Acct. Name</span>
													<input id="tbx02AcctName" type="text" maxlength="250" class="form-control" Placeholder="Acct. Name" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px required">Last Name</span>
													<input id="tbx02LastName" type="text" maxlength="50" class="form-control" Placeholder="Last Name" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px required">First Name</span>
													<input id="tbx02FirstName" type="text" maxlength="50" class="form-control" Placeholder="First Name" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Middle Name</span>
													<input id="tbx02MiddleName" type="text" maxlength="50" class="form-control" Placeholder="Middle Name" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Suffix</span>
													<input id="tbx02Suffix" type="text" maxlength="5" class="form-control" Placeholder="Suffix" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Birth Date</span>
													<input id="tbx02BirthDate" type="text" class="form-control" data-kt-repeater="datepicker" Placeholder="Date"  readonly="readonly" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Gender</span>
													<select id="ddl02Gender" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">Gender</option>
														<option value="M">Male</option>
														<option value="F">Female</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Citizenship</span>
													<select id="ddl02Citizenship" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">Citizenship</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Civil Status</span>
													<select id="ddl02CivilStatus" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">Status</option>
														<option value="S">Single</option>
														<option value="M">Married</option>
														<option value="W">Widowed</option>
														<option value="L">Legally Separated</option>
														<option value="D">Divorced</option>
														<option value="A">Annulled</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Address</span>
													<input id="tbx02Address" type="text" maxlength="100" class="form-control" Placeholder="Address" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Country</span>
													<select id="ddl02Country" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02Country_onchange(this);">
														<option value="">Country</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">City</span>
													<select id="ddl02City" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02City_onchange(this);">
														<option value="">City</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Town</span>
													<select id="ddl02Town" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02Town_onchange(this);">
														<option value="">Town</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Zip Code</span>
													<input id="tbx02ZipCode" type="text" maxlength="8" class="form-control" Placeholder="Zip Code" readonly="readonly" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Yrs. of stay</span>
													<input id="tbx02YearOfStay" type="text" onkeypress="return fn01EnterKeyNumber(event,this.id);" maxlength="21" class="form-control" Placeholder="Years of Stay" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Ownership</span>
													<select id="ddl02Ownership" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">Ownership</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Email</span>
													<input id="tbx02Email" type="text" maxlength="60" class="form-control" Placeholder="Email" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Mobile No</span>
													<input id="tbx02MobileNo" type="text" maxlength="20" class="form-control" Placeholder="Mobile No." />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">TIN</span>
													<input id="tbx02TIN" type="text" maxlength="20" class="form-control" Placeholder="TIN No." />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">SSS</span>
													<input id="tbx02SSS" type="text" maxlength="20" class="form-control" Placeholder="SSS No." />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-4 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">UMID</span>
													<input id="tbx02UMID" type="text" maxlength="20" class="form-control" Placeholder="UMID No." />
												</div>
											</div>
											<div class="card-title fs-5 fw-bolder ms-2">Employment</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Employer</span>
													<input id="tbx02Employer" type="text" maxlength="180" class="form-control" Placeholder="Employer" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Address</span>
													<input id="tbx02EmpAddress" type="text" maxlength="100" class="form-control" Placeholder="Employer Address" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Country</span>
													<select id="ddl02EmpCountry" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02EmpCountry_onchange(this);">
														<option value="">Country</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">City</span>
													<select id="ddl02EmpCity" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02EmpCity_onchange(this);">
														<option value="">City</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Town</span>
													<select id="ddl02EmpTown" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02EmpTown_onchange(this);">
														<option value="">Town</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Zip Code</span>
													<input id="tbx02EmpZipCode" type="text" maxlength="8" class="form-control" Placeholder="Zip Code" readonly="readonly" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-3">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Yrs. of stay</span>
													<input id="tbx02EmpStay" type="text" maxlength="21" onkeypress="return fn01EnterKeyNumber(event,this.id);" class="form-control" Placeholder="Years of Stay" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Position</span>
													<input id="tbx02EmpPosition" type="text" maxlength="60" class="form-control" Placeholder="Position" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6 mb-2">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Type</span>
													<select id="ddl02EmpType" data-kt-repeater="select2" class="form-select form-select-sm form-select-border ">
														<option value="">Type</option>
													</select>
												</div>
											</div>
											<div class="card-title fs-5 fw-bolder ms-2">Mailing Address</div>
											<div class="col-sm-12 col-md-12 col-lg-12">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Address</span>
													<input id="tbx02MailAddress" type="text" maxlength="100" class="form-control" Placeholder="Address" />
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Country</span>
													<select id="ddl02MailCountry" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02MailCountry_onchange(this);">
														<option value="">Country</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">City</span>
													<select id="ddl02MailCity" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02MailCity_onchange(this);">
														<option value="">City</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Town</span>
													<select id="ddl02MailTown" data-kt-repeater="select2" class="form-select form-select-sm form-select-border " onchange="ddl02MailTown_onchange(this);">
														<option value="">Town</option>
													</select>
												</div>
											</div>
											<div class="col-sm-12 col-md-12 col-lg-6">
												<div class="input-group input-group-sm">
													<span class="input-group-text min-w-150px">Zip Code</span>
													<input id="tbx02MailZipCode" type="text" maxlength="8" class="form-control" Placeholder="Zip Code" readonly="readonly" />
												</div>
											</div>
										</div>
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
	<input id="hdn02Type" type="hidden" value="" />
	<input id="hdn02Phase" type="hidden" value="" />
	<input id="hdn02Block" type="hidden" value="" />
	<input id="hdn02Lot" type="hidden" value="" />

    <script src="Assets/js/AAD/AAD002031.js"></script>
	<script src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
