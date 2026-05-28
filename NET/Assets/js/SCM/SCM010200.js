//public variable
let grid01Api;
let grid02Api;
//public variable

//general
function fn01Load() {
    fnAccess('SCM010000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            //Header
            fn01Header();

            //Body
            fn01Body();
            fn02Body();

        } else {
            location.replace("MNU000022");
        };
    });
};
//general

//function - Header
function fn01Header() {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010200',
            'pType': 'Contract Management - Awarded - Header'
        },
        success: function (response) {
            //variable
            const currentDate = new Date();
            let currentYear = currentDate.getFullYear();
            //variable

            //Count up
            const options = {
                decimalPlaces: 0,
                duration: 1,
                useGrouping: true,
                separator: ',',
                decimal: '.'
            };
            //Count up

            const counters = [
                new countUp.CountUp("h01HouseConAward", response[0].HouseConAward, options),
                new countUp.CountUp("h01COFAward", response[0].COFAward, options),
                new countUp.CountUp("h01HouseConAwarded", response[0].HouseConAwarded, options),
                new countUp.CountUp("h01COFAwarded", response[0].COFAwarded, options)
            ];

            counters.forEach(c => {
                if (!c.error) c.start();
            });

            //For Award
            document.getElementById("spn01ForAwardYR").innerHTML = `as of ${currentYear}`;
            //For Award

            //Awarded
            document.getElementById("spn01AwardedYR").innerHTML = `as of ${currentYear}`;
            //Awarded

        }
    });
};
//function - Header

//function - Body
function fn01Body() {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010200',
            'pType': 'Contract Management - Awarded - Repair'
        },
        success: function (response) {
            if (Array.isArray(response) && response.length > 0) {
                const div01RowBody = document.getElementById("div01RowBody");
                div01RowBody.innerHTML = "";

                response.forEach(async (el) => {
                    //Header
                    div01RowBody.innerHTML += `
                        <div class="col-xl-12">
					        <div class="d-flex justify-content-start">
						        <h2 class="text-muted">${el.ProvName}</h2>
					        </div>

                            <div id="div01RowContent${el.ProvName}" class="row g-6 mb-6 g-xl-9 mb-xl-9">

                            </div>
                        </div>
                    `;
                    //Header

                    //Content
                    $.ajax({
                        type: "POST",
                        url: "SCM000011.ashx",
                        data: {
                            'pFormCode': "SCM010200",
                            'pType': 'Contract Management - Awarded - Repair Details',
                            'pDivCode': el.DivCode
                        },
                        success: function (res) {
                            const div01RowContent = document.getElementById("div01RowContent" + el.ProvName);
                            div01RowContent.innerHTML = "";
                            res.forEach((i) => {
                                div01RowContent.innerHTML += `${i.Content}`;
                            });
                        }
                    });
                    //Content
                });
            }
        }
    });
};
function fn02Body() {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010200',
            'pType': 'Contract Management - Awarded - House Construction'
        },
        success: function (response) {
            if (Array.isArray(response) && response.length > 0) {
                const div02RowBody = document.getElementById("div02RowBody");
                div02RowBody.innerHTML = "";

                response.forEach(async (el) => {
                    //Header
                    div02RowBody.innerHTML += `
                        <div class="col-xl-12">
					        <div class="d-flex justify-content-start">
						        <h2 class="text-muted">${el.ProvName}</h2>
					        </div>

                            <div id="div02RowContent${el.ProvName}" class="row g-6 mb-6 g-xl-9 mb-xl-9">

                            </div>
                        </div>
                    `;
                    //Header

                    //Content
                    $.ajax({
                        type: "POST",
                        url: "SCM000011.ashx",
                        data: {
                            'pFormCode': "SCM010200",
                            'pType': 'Contract Management - Awarded - House Construction Details',
                            'pDivCode': el.DivCode
                        },
                        success: function (res) {
                            const div02RowContent = document.getElementById("div02RowContent" + el.ProvName);
                            div02RowContent.innerHTML = "";
                            res.forEach((i) => {
                                div02RowContent.innerHTML += `${i.Content}`;
                            });
                        }
                    });
                    //Content
                });
            }
        }
    });
};
//function - Body

//function - Modal
function fn01Table(pSubdCode) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010200',
            'pType': 'Contract Management - Get Record - Awarded',
            'pSubdCode': pSubdCode
        },
        success: function (response) {
            grid01Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid01Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table01Record');
    let gridOptions;

    // Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'ID', pinned: 'left' },
                        { colId: 'TagColumn', pinned: 'right' }
                    ]
                });
            }
        },
        onRowClicked: params => {
            window.open("SCM000006-" + params.data.ID, '_blank').focus();
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [

            {
                headerName: "ID",
                field: "ID",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "ID",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Title",
                field: "Title",
                filter: 'agTextColumnFilter',
                tooltipField: "Title",
                flex: 1,
                minWidth: 350
            },
            {
                headerName: "Type",
                field: "Type",
                filter: 'agTextColumnFilter',
                width: 180,
                cellRenderer: function (params) {
                    return params.value ? params.value : '';
                }
            },
            {
                headerName: "Date Required",
                field: "DateRequired",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "DateRequired"
            },
            {
                headerName: "Exp. Date of Approval",
                field: "DateExpected",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "DateExpected"
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 100,
                cellRenderer: function (params) {
                    return params.value ? params.value : '';
                }
            },
            {
                headerName: "Requestor By",
                field: "Requestor",
                filter: 'agTextColumnFilter',
                width: 180,
                cellRenderer: function (params) {
                    return params.value ? params.value : '';
                }
            },
            {
                headerName: "Contractor",
                field: "ConName",
                filter: 'agTextColumnFilter',
                width: 220,
                cellRenderer: function (params) {
                    return params.value ? params.value : '';
                }
            }

        ],
        rowData: [],
        pagination: false,
    };
    grid01Api = agGrid.createGrid(gridDiv, gridOptions);

    //modal
    $("#mdl01Record").modal("show");
};
function fn02Table(pSubdCode) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010200',
            'pType': 'Contract Management - Get Record - Awarded - House Construction',
            'pSubdCode': pSubdCode
        },
        success: function (response) {
            grid02Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid02Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table02Record');
    let gridOptions;

    // Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'ID', pinned: 'left' },
                        { colId: 'TagColumn', pinned: 'right' }
                    ]
                });
            }
        },
        onRowClicked: params => {
            window.open("SCM000007-" + params.data.ID, '_blank').focus();
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [

            {
                headerName: "ID",
                field: "ID",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "ID",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Title",
                field: "Title",
                filter: 'agTextColumnFilter',
                tooltipField: "Title",
                flex: 1,
                minWidth: 350
            },
            {
                headerName: "Contractor",
                field: "ConName",
                filter: 'agTextColumnFilter',
                width: 250,
                cellRenderer: function (params) {
                    return params.value ? params.value : '';
                }
            }

        ],
        rowData: [],
        pagination: false,
    };
    grid02Api = agGrid.createGrid(gridDiv, gridOptions);

    //modal
    $("#mdl02Record").modal("show");
};
//function - Modal

//function - Refresh
function fn01Refresh() {
    fn01Load();
};
//function - Refresh

//function - View
function fn01ForAward() {
    window.location.href = "SCM010100";
};
function fn01Awarded() {
    window.location.href = "SCM010200";
};
//function - View

function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {

        //dropdown
        $('[data-kt-repeater="select2"]').select2();
        //dropdown

        //date
        $('[data-kt-repeater="datepicker"]').flatpickr({
            dateFormat: "m/d/Y"
        });
        //date

        fn01Load();
    });
};