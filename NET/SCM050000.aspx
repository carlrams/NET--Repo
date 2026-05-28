<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM050000.aspx.vb" Inherits="NET.SCM050000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Stock Issuance (For Site Warehouseman)</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
			<asp:Button ID="lbtn01Fill" runat="server" Text="Button" OnClick="lbtn01Fill_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btn01SaveOk" runat="server" Text="Button" OnClick="btn01SaveOk_Click" ClientIDMode="Static" style="display:none;"/>
			<asp:Button ID="btn01Report" runat="server" Text="Button" OnClick="btn01Report_Click" ClientIDMode="Static" style="display:none;"/>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<!--begin::title-->
		<asp:UpdatePanel ID="upnlContent" runat="server" UpdateMode="Conditional" class="card">
		<ContentTemplate>
			<!--begin::title-->
			<div class="card-header pt-5 pb-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol me-5">
						<img src="Assets/media/svg/apps/SCM050000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						<h2 class="mb-1">Stock Issuance (For Site Warehouseman)</h2>
					</div>
					<!--end::Title-->
				</div>
			</div>
			<!--end::title-->
			<div class="card-body">
				<div class="input-group input-group-sm mb-2">
					<span class="input-group-text min-w-150px required">PR No.</span>
					<div class="d-flex align-items-center position-relative w-100" style="margin-left:1px">
						<input id="tbx01PRNo" runat="server" type="text" class="form-control form-control-sm border-0 m-0" placeholder="PR No." />
						<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
						<span class="svg-icon svg-icon-2 position-absolute pointer end-5px" onclick="getPR();">
							<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
								<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
								<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
							</svg>
						</span>
						<!--end::Svg Icon-->
					</div>
				</div>
				<div class="input-group input-group-sm mb-2">
					<span class="input-group-text min-w-150px required">Warehouse</span>
					<asp:DropDownList ID="ddl01Warehouse" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
						<asp:ListItem Value="">Select a warehouse</asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="input-group input-group-sm mb-2">
					<span class="input-group-text min-w-150px required">Charge To</span>
					<asp:DropDownList ID="ddl01ChargeTo" runat="server" data-kt-repeater="select2" class="form-select form-select-sm form-select-border min-h-35px" AutoPostBack="true">
						<asp:ListItem Value="">Select a charge to</asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="input-group input-group-sm">
					<span class="input-group-text min-w-150px required">Project</span>
					<asp:TextBox ID="tbx01Project" runat="server" class="form-control" Placeholder="Add project"></asp:TextBox>
				</div>
			</div>
			<!--begin::Card header-->
			<div class="card-header">
				<!--begin::Card header-->
				<div class="card-title fs-3 fw-bolder">Particular</div>
				<!--end::Card header-->
			</div>
			<!--end::Card header-->
			<div class="card-body">
				<div class="table-responsive">
					<!--begin::Transaction Log Details-->
					<asp:GridView ID="gv01PRDtl" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False">
						<Columns>                                       
							<asp:TemplateField>
								<HeaderTemplate>
									Item
								</HeaderTemplate>
								<ItemTemplate>
									<asp:Label ID="lblPRItem" runat="server" Text='<%# Eval("PRItem") %>'></asp:Label>
									<asp:Label ID="lblPRSeqNo" runat="server" class="hidden" Text='<%# Eval("PRSeqNo") %>' Visible ="false"></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-150px" />
								<ItemStyle CssClass="min-w-1500px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									 Balance
								</HeaderTemplate>
								<ItemTemplate>
									<asp:Label ID="lblPRQty" runat="server" Text='<%# Eval("PRQty") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-75px" />
								<ItemStyle CssClass="min-w-75px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Unit
								</HeaderTemplate>
								<ItemTemplate>
									<asp:Label ID="lblPRUnit" runat="server" Text='<%# Eval("PRUnit") %>'></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-75px" />
								<ItemStyle CssClass="min-w-75px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Item
								</HeaderTemplate>
								<ItemTemplate>
									<asp:DropDownList id="ddl01Item" runat="server" class="form-select form-select-sm border-0 p-0 m-0" data-kt-repeater="select2" AutoPostBack="true" onselectedindexchanged="ddl01Item_SelectedIndexChanged"></asp:DropDownList>                                        
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-150px" />
								<ItemStyle CssClass="min-w-150px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Balance
								</HeaderTemplate>
								<ItemTemplate>
									<asp:Label ID="lblBalance" runat="server" Text="0.00"></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-75px" />
								<ItemStyle CssClass="min-w-75px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Issue
								</HeaderTemplate>
								<ItemTemplate>
									<input id="tbx01QtyIssued" runat="server" type="text" class="border-0 p-0 m-0 w-75px" style="outline:none" onblur="FormatNumeric(this.id);" value="0.00"/>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-75px" />
								<ItemStyle CssClass="min-w-75px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Unit
								</HeaderTemplate>
								<ItemTemplate>
									<asp:Label ID="lblUMName" runat="server"></asp:Label>
									<asp:Label ID="lblUMCode" runat="server" class="d-none"></asp:Label>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-75px" />
								<ItemStyle CssClass="min-w-75px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Contractor
								</HeaderTemplate>
								<ItemTemplate>
									<asp:DropDownList id="ddl01Contractor" runat="server" class="form-select form-select-sm border-0 p-0 m-0" data-kt-repeater="select2"></asp:DropDownList>                                        
								</ItemTemplate>
								 <HeaderStyle CssClass="min-w-150px" />
								<ItemStyle CssClass="min-w-150px" />
							</asp:TemplateField>
							<asp:TemplateField>
								<HeaderTemplate>
									Remarks
								</HeaderTemplate>
								<ItemTemplate>
									<input id="tbx01Remarks" runat="server" type="text" class="border-0 p-0 m-0 w-150px" style="outline:none" value=""/>
								</ItemTemplate>
								<HeaderStyle CssClass="min-w-150px" />
								<ItemStyle CssClass="min-w-150px" />
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
					<!--end::Transaction Log Details-->
				</div>
			</div>
			<!--begin::Card header-->
			<div class="card-footer justify-content-center">
				<div class="d-flex d-block justify-content-center"><asp:LinkButton ID="lbtn01Preview" runat="server" class="btn btn-primary">Review and submit</asp:LinkButton></div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::title-->
		
		<!--begin::Modal Material-->
		<asp:UpdatePanel ID="mdl01Review" runat="server" UpdateMode="Conditional" class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" aria-hidden="true">
		<ContentTemplate>
			<div class="modal-dialog modal-fullscreen">
				<div class="modal-content shadow-none">
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
						<asp:HiddenField ID="hfSINo" runat="server" />
					</div>
					<div class="modal-body">
						<div class="card-body">
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">PR No.</span>
								<asp:Label ID="lbl01PRNo" runat="server" class="form-control">-</asp:Label>
								<asp:HiddenField ID="hf01PRNo" runat="server" />
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Warehouse</span>
								<asp:Label ID="lbl01Warehouse" runat="server" class="form-control">-</asp:Label>
								<asp:HiddenField ID="hf01Warehouse" runat="server" />
							</div>
							<div class="input-group input-group-sm mb-2">
								<span class="input-group-text min-w-150px">Charge To</span>
								<asp:Label ID="lbl01ChargeTo" runat="server" class="form-control">-</asp:Label>
								<asp:HiddenField ID="hf01ChargeTo" runat="server" />
							</div>
						</div>
						<!--begin::Card header-->
						<div class="card-header">
							<!--begin::Card header-->
							<div class="card-title fs-3 fw-bolder">Particular</div>
							<!--end::Card header-->
						</div>
						<!--end::Card header-->
						<div class="modal-body">
						<!--end::Separator-->
							<div class="table-responsive">
								<asp:GridView ID="gv01Review" runat="server" class="table table-no-border table-row-bordered table-hover align-middle" AutoGenerateColumns="False" ShowFooter="true">
									<Columns>
										<asp:TemplateField>
											<HeaderTemplate>
												Item
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblPRItem" runat="server" Text='<%# Eval("PRItem") %>'></asp:Label>
												<asp:Label ID="lblPRSeqNo" runat="server" Text='<%# Eval("PRSeqNo") %>' Visible="false"></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-150px" />
											<ItemStyle CssClass="min-w-1500px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												 Balance
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblPRQty" runat="server" Text='<%# Eval("PRQty") %>'></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-75px" />
											<ItemStyle CssClass="min-w-75px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Unit
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblPRUnit" runat="server" Text='<%# Eval("PRUnit") %>'></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-75px" />
											<ItemStyle CssClass="min-w-75px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Item
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
												<asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' Visible ="false"></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-150px" />
											<ItemStyle CssClass="min-w-150px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Balance
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-75px" />
											<ItemStyle CssClass="min-w-75px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Issue
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-75px" />
											<ItemStyle CssClass="min-w-75px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Unit
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblUMName" runat="server" Text='<%# Eval("UMName") %>'></asp:Label>
												<asp:Label ID="lblUMCode" runat="server" Text='<%# Eval("UMCode") %>' Visible ="false"></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-75px" />
											<ItemStyle CssClass="min-w-75px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Contractor
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblContractorName" runat="server" Text='<%# Eval("ContractorName") %>'></asp:Label>
												<asp:Label ID="lblContractorCode" runat="server" Text='<%# Eval("ContractorCode") %>' Visible ="false"></asp:Label>
											</ItemTemplate>
											 <HeaderStyle CssClass="min-w-150px" />
											<ItemStyle CssClass="min-w-150px" />
										</asp:TemplateField>
										<asp:TemplateField>
											<HeaderTemplate>
												Remarks
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
											</ItemTemplate>
											<HeaderStyle CssClass="min-w-150px" />
											<ItemStyle CssClass="min-w-150px" />
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
						<button class="btn btn-primary" onclick="btn01SaveOk1(this);">
							Submit
							<span class="indicator-progress">
								<span class="spinner-border spinner-border-sm align-middle"></span>
							</span>
						</button>
					</div>
				</div>
			</div>
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::Modal MaterialS-->
	</div>
	<!--end::Content-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">  

		function getPR() {
			var clickButton = document.getElementById("<%= lbtn01Fill.ClientID %>");
			clickButton.click();
        };
        function btn01SaveOk1(Btn) {
            // Perform button
            var clickButton = document.getElementById("<%= btn01SaveOk.ClientID %>");
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
            }, 6000);
        };

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

		//generate report
		function btn01Report1() {
			var clickButton = document.getElementById("<%= btn01Report.ClientID %>");
			clickButton.click();
		};
		//generate report

		//load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
			jQuery(function ($) {

                //combobox
                $('[data-kt-repeater="select2"]').select2({ dropdownAutoWidth: true });
				//combobox

                //date
                $('[data-kt-repeater="datepicker"]').flatpickr({
                    dateFormat: "m/d/Y"
				});
				//date
            });
		}
		//load page
    </script>
	<!-- scripts related to this page -->

</asp:Content>

