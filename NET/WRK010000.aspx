<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="WRK010000.aspx.vb" Inherits="NET.WRK010000" MaintainScrollPositionOnPostback = "true" %>
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
						<li class="breadcrumb-item text-white">Work Order</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item">
							<span class="bullet bg-white w-5px h-2px"></span>
						</li>
						<!--end::Item-->
						<!--begin::Item-->
						<li class="breadcrumb-item text-white"><span id="spnTotal" runat="server">You have 253 tasks</span></li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
				<!--begin::Actions-->
				<div class="d-flex align-items-center py-3 py-md-1">
					<!--end::Wrapper-->
					<a class="btn btn-bg-white pointer" href="FRM000001-ADD-0000000000000">Create</a>
					<!--end::Button-->
				</div>
				<!--end::Actions-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--end::breadcrumb bar-->

		<!--begin::Card-->
        <div id="card01Form" class="card mb-5">
			<!--begin::Beader-->
		    <div class="card-header border-0 py-5">
				<div class="d-flex align-items-center">
					<!--begin::Icon-->
					<div class="symbol symbol-35px me-2">
						<img src="Assets/media/svg/apps/WRK010000.svg" alt="" />
					</div>
					<!--end::Icon-->
					<!--begin::Title-->
					<div class="d-flex flex-column">
						 <h3 class="card-title align-items-start flex-column">
							<span class="card-label fw-bolder text-dark">Work Order</span>
							<span id="spn01Total" runat="server" class="text-muted mt-1 fw-bold fs-7">8 assigned work order(s)</span>
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
						<button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2" onclick="btn01Subscribed()" title="Subsription">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-bell fs-3"></i>
	                        <!--end::Svg Icon-->
                        </button>
                        <button type="button" class="btn btn-sm btn-icon btn-light btn-active-light me-2" onclick="btn01Request()" title="My Request">
	                        <!--begin::Svg Icon | path: icons/duotune/general/gen024.svg-->
	                       <i class="las la-archive fs-3"></i>
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
                <div class="border rounded" style="min-height:62.3vh;">
                    <table id="gv01Form" class="table table-row-bordered gy-2 gs-2 w-100">
                        <thead>
                            <tr id="tr01Header" class="fw-bold fs-7 text-gray-800">
                                <th class="min-w-150px mw-150px fw-bold border-end">ID</th>
                                <th class="min-w-200px w-100 fw-bold border-end">Title</th>
                                <th class="min-w-150px mw-150px fw-bold border-end">Type</th>
                                <th class="min-w-100px mw-100px fw-bold border-end fs-8 nowrap-auto"><span title="Date Required">Date Required</span></th>
                                <th class="min-w-100px mw-100px fw-bold border-end">Status</th>
                                <th class="min-w-150px mw-150px fw-bold border-end fs-8 nowrap-auto">Requested By</th>
                            </tr>
                            <tr id="tr01Filter" class="fs-7" style="display:none">
                                <td class="border-end"><input id="tbx01Find00" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find01" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find02" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find03" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find04" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
                                <td class="border-end"><input id="tbx01Find05" type="text" class="border-0 p-0 w-100" style="outline:none" value=""/></td>
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
	<!--end::Post-->
	
	<!-- scripts related to this page -->
    <script type="text/javascript">

        //newly Subscribed
        function btn01Subscribed() {
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDWRK.ashx",
                data: {
                    'FormCode': 'WRK010000',
                    'Type': 'List-Subscribed'
                },
                success: function (response) {
                    Display(response)
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
                var gv04Form = $("#gv04Form").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bDestroy: true,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollX: true,
                    paging: false,
                    lengthChange: false,
                    fixedColumns: { left: 1 },
                    select: false,
                    data: response,
                    columns: [
                        { data: 'ID' },
                        { data: 'Title' },
                        { data: 'Type' },
                        { data: 'DateRequired' },
                        { data: 'Status' },
                        { data: 'RequestedBy' }],
                    columnDefs: [
                        {
                            targets: 1,
                            className: 'tbody-nowrap-auto'
                        },
                        {
                            targets: 2,
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    var label = '';
                                    if (data === 'New') {
                                        label = 'badge-for-new';
                                    } else if (data === 'Assigned') {
                                        label = 'badge-for-endorsement';
                                    } else if (data === 'Accepted') {
                                        label = 'badge-for-approval';
                                    } else if (data === 'Completed') {
                                        label = 'badge-for-implementation';
                                    } else if (data === 'Clarify') {
                                        label = 'badge-for-clarification';
                                    }
                                    return '<span class="badge ' + label + '">' + data + '</span>';
                                }
                                return data;
                            }
                        },
                        {
                            targets: 4,
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    var label = '';
                                    if (data === 'Within') {
                                        label = 'badge-success';
                                    } else if (data === 'Due') {
                                        label = 'badge-warning';
                                    } else if (data === 'Delay') {
                                        label = 'badge-danger';
                                    }
                                    return '<span class="badge ' + label + '">' + data + '</span>';
                                }
                                return data;
                            }
                        },

                        {
                            targets: 5,
                            className: 'tbody-nowrap-150px'
                        }
                    ],
                    orderCellsTop: true
                });
                //datatable

                $('#mdl04Subscribed').modal('show');
            }
            //initial load
        }
        //newly Subscribed

        //newly Request
        function btn01Request() {
            //initial load
            $.ajax({
                type: "POST",
                url: "HNDWRK.ashx",
                data: {
                    'FormCode': 'WRK010000',
                    'Type': 'List-Request'
                },
                success: function (response) {
                    Display(response)
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
                var gv05Form = $("#gv05Form").DataTable({
                    bFilter: true,
                    bPaginate: false,
                    bDestroy: true,
                    bInfo: false,
                    scrollCollapse: true,
                    scrollX: true,
                    paging: false,
                    lengthChange: false,
                    fixedColumns: { left: 1 },
                    select: false,
                    data: response,
                    columns: [
                        { data: 'ID' },
                        { data: 'Title' },
                        { data: 'Type' },
                        { data: 'DateRequired' },
                        { data: 'Status' },
                        { data: 'AssignedTo' }],
                    columnDefs: [
                        {
                            targets: 1,
                            className: 'tbody-nowrap-auto'
                        },
                        {
                            targets: 2,
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    var label = '';
                                    if (data === 'New') {
                                        label = 'badge-for-new';
                                    } else if (data === 'Assigned') {
                                        label = 'badge-for-endorsement';
                                    } else if (data === 'Accepted') {
                                        label = 'badge-for-approval';
                                    } else if (data === 'Completed') {
                                        label = 'badge-for-implementation';
                                    } else if (data === 'Clarify') {
                                        label = 'badge-for-clarification';
                                    }
                                    return '<span class="badge ' + label + '">' + data + '</span>';
                                }
                                return data;
                            }
                        },
                        {
                            targets: 4,
                            render: function (data, type, row, meta) {
                                if (type === 'display') {
                                    var label = '';
                                    if (data === 'Within') {
                                        label = 'badge-success';
                                    } else if (data === 'Due') {
                                        label = 'badge-warning';
                                    } else if (data === 'Delay') {
                                        label = 'badge-danger';
                                    }
                                    return '<span class="badge ' + label + '">' + data + '</span>';
                                }
                                return data;
                            }
                        },

                        {
                            targets: 5,
                            className: 'tbody-nowrap-150px'
                        }
                    ],
                    orderCellsTop: true
                });
                //datatable

                $('#mdl05Request').modal('show');
            }
            //initial load
        }
        //newly Request

        //fixed column header alignment
        $(document).ready(function () {
            $('#mdl03New').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
            $('#mdl04Subscribed').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
            $('#mdl05Request').on('shown.bs.modal', function (e) {
                $($.fn.dataTable.tables(true)).css('width', '100%');
                $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
            });
        });
        //fixed column header alignment

        //filter form
        function btn01Filter() {
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

                    //datatable
                    var gv01Form = $("#gv01Form").DataTable({
                        bFilter: true,
                        bPaginate: false,
                        bDestroy: true,
                        bInfo: false,
                        scrollCollapse: true,
                        scrollResize: true,
                        scrollX: true,
                        scrollY: 100,
                        paging: false,
                        lengthChange: false,
                        fixedColumns: { left: 1 },
                        select: false,
                        columnDefs: [
                            {
                                targets: 1,
                                className: 'tbody-nowrap-auto'
                            },
                            {
                                targets: 2,
                                render: function (data, type, row, meta) {
                                    if (type === 'display') {
                                        var label = '';
                                        if (data === 'New') {
                                            label = 'badge-for-new';
                                        } else if (data === 'Assigned') {
                                            label = 'badge-for-endorsement';
                                        } else if (data === 'Accepted') {
                                            label = 'badge-for-approval';
                                        } else if (data === 'Completed') {
                                            label = 'badge-for-implementation';
                                        } else if (data === 'Clarify') {
                                            label = 'badge-for-clarification';
                                        }
                                        return '<span class="badge ' + label + '">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },
                            {
                                targets: 4,
                                render: function (data, type, row, meta) {
                                    if (type === 'display') {
                                        var label = '';
                                        if (data === 'Within') {
                                            label = 'badge-success';
                                        } else if (data === 'Due') {
                                            label = 'badge-warning';
                                        } else if (data === 'Delay') {
                                            label = 'badge-danger';
                                        }
                                        return '<span class="badge ' + label + '">' + data + '</span>';
                                    }
                                    return data;
                                }
                            },

                            {
                                targets: 5,
                                className: 'tbody-nowrap-150px'
                            }
                        ],
                        orderCellsTop: true,
                        dom: "<'table-responsive'tr>"
                    });
                    //datatable

                    //search
                    $('#tbx01Find').on('keyup', function () {
                        gv01Form.search(this.value).draw();
                    });
                    //search

                    //filter
                    $('#tbx01Find00').on('keyup', function () {
                        gv01Form.columns(0).search(this.value).draw();
                    });
                    $('#tbx01Find01').on('keyup', function () {
                        gv01Form.columns(1).search(this.value).draw();
                    });
                    $('#tbx01Find02').on('keyup', function () {
                        gv01Form.columns(2).search(this.value).draw();
                    });
                    $('#tbx01Find03').on('keyup', function () {
                        gv01Form.columns(3).search(this.value).draw();
                    });
                    $('#tbx01Find04').on('keyup', function () {
                        gv01Form.columns(4).search(this.value).draw();
                    });
                    $('#tbx01Find05').on('keyup', function () {
                        gv01Form.columns(5).search(this.value).draw();
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
		//load page

    </script>
	<!-- scripts related to this page -->

</asp:Content>
