//public variable
let grid01Api;
let grid0101Api;
let grid02Api;
let grid0201Api;
let grid03Api;
let grid0301Api;
let grid0302Api;
let grid04Api;
let grid05Api;
let grid06Api;
let grid07Api;
//public variable

//general
function fn01Load() {
    fnAccess('DSB240000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            //Header
            fn01Header();

            //Chart
            fn01Chart();
            fn02Chart();
            fn03Chart();
            fn04Chart();
            fn05Chart();
            fn06Chart();
            fn07Chart();

            //Table
            fn01Table();
            fn02Table();
            fn03Table();
            fn04Table();
            fn05Table();
            fn06Table();
            fn07Table();
        } else {
            location.replace("MNU000022");
        };
    });
};
//general

//function - Loader
function fn00Loader(id) {
    var element = document.querySelector(id);
    if (!element) return;

    element.innerHTML = `
                <div style="display:flex;align-items:center;justify-content:center;height:100%;">
                    <div class="spinner-border text-primary" role="status"></div>
                </div>
            `;
};
//function - Loader

//function - Refresh
function fn01Refresh() {
    fn01Load();
};
//function - Refresh

//function - Header
function fn01Header() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Issuance-Header'
        },
        success: function (response) {

            document.getElementById("spn01Overall").innerHTML =
                `of ${response[0].Overvall.toLocaleString("en-US", {
                    minimumFractionDigits: 0,
                    maximumFractionDigits: 0
                })} posted record`;

            //Count up
            const options = {
                decimalPlaces: 0,
                duration: 1,
                useGrouping: true,
                separator: ',',
                decimal: '.'
            };

            const counters = [
                new countUp.CountUp("h01Delivered", response[0].Posted, options),
                new countUp.CountUp("h01Pending", response[0].Pending, options),
                new countUp.CountUp("h01LowStock", response[0].LowStock, options),
                new countUp.CountUp("h01TotalStock", response[0].TotalStock, options)
            ];

            counters.forEach(c => {
                if (!c.error) c.start();
            });
        },
    });
};
//function - Header

//function - Chart
function fn01Chart() {
    //loader
    fn00Loader("#kt_volume_graph_001");
    //render
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-Stock-Volume'
        },
        success: function (response) {
            //Variables
            var Total = [];
            var Volume = [];
            var Category = [];
            //Variables

            //push
            response.forEach(function (i) {
                Total.push(i.Total);
                Volume.push(i.VolQty);
                Category.push(i.Month + ". " + i.Yr);
            });
            //push

            var SIChart01 = function () {

                var initSIChart01 = function () {
                    var element = document.getElementById("kt_volume_graph_001");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                    var baseColor = KTUtil.getCssVariableValue('--bs-info');
                    var baseLightColor = KTUtil.getCssVariableValue('--bs-info');
                    var secondaryColor = KTUtil.getCssVariableValue('--bs-success');
                    var secondaryLightColor = KTUtil.getCssVariableValue('--bs-success');

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: 'Total Issuances',
                            data: Total
                        }, {
                            name: 'Volume',
                            data: Volume
                        }],
                        chart: {
                            fontFamily: 'inherit',
                            type: 'line',
                            height: 350,
                            toolbar: {
                                show: false
                            }
                        },
                        plotOptions: {},
                        legend: {
                            show: true
                        },
                        dataLabels: {
                            enabled: false
                        },
                        fill: {
                            type: 'solid',
                            opacity: 1
                        },
                        stroke: {
                            curve: 'smooth'
                        },
                        xaxis: {
                            categories: Category,
                            axisBorder: {
                                show: false,
                            },
                            axisTicks: {
                                show: false
                            },
                            labels: {
                                style: {
                                    colors: labelColor,
                                    fontSize: '12px'
                                }
                            },
                            crosshairs: {
                                position: 'front',
                                stroke: {
                                    color: labelColor,
                                    width: 1,
                                    dashArray: 3
                                }
                            },
                            tooltip: {
                                enabled: true,
                                formatter: undefined,
                                offsetY: 0,
                                style: {
                                    fontSize: '12px'
                                }
                            }
                        },
                        yaxis: {
                            labels: {
                                formatter: val =>
                                    val.toLocaleString('en-US', {
                                        notation: 'compact',
                                        compactDisplay: 'short',
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                    }),
                                style: {
                                    colors: labelColor,
                                    fontSize: '12px'
                                }
                            }
                        },
                        states: {
                            normal: {
                                filter: {
                                    type: 'none',
                                    value: 0
                                }
                            },
                            hover: {
                                filter: {
                                    type: 'none',
                                    value: 0
                                }
                            },
                            active: {
                                allowMultipleDataPointsSelection: false,
                                filter: {
                                    type: 'none',
                                    value: 0
                                }
                            }
                        },
                        tooltip: {
                            style: {
                                fontSize: '12px'
                            },
                            y: {
                                formatter: function (val) {
                                    var n = parseFloat(val).toFixed(2)
                                    return Number(n).toLocaleString('en');
                                }
                            }
                        },
                        colors: [baseColor, secondaryColor],
                        grid: {
                            borderColor: borderColor,
                            strokeDashArray: 4,
                            yaxis: {
                                lines: {
                                    show: true
                                }
                            }
                        },
                        markers: {
                            size: 5,
                            strokeWidth: 3,
                            strokeColors: [baseColor, secondaryColor],
                            fillOpacity: 1,
                            colors: ['#ffffff'],
                            hover: {
                                size: 7
                            }
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                };

                return {
                    init: function () {
                        initSIChart01();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart01;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart01.init();
            });

        }

    });
};
function fn02Chart() {
    //loader
    fn00Loader("#kt_stack_graph_002");
    //render
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-Issuance-Warehouse'
        },
        success: function (response) {

            //Variables
            var Delivered = [];
            var Partial = [];
            var Pending = [];
            var Category = [];
            //Variables

            //push
            response.forEach(function (i) {
                Delivered.push(i.Delivered);
                Partial.push(i.Partial);
                Pending.push(i.Pending);
                Category.push(i.WhseName);
            });
            //push

            var SIChart02 = function () {

                var initSIChart02 = function () {
                    var element = document.getElementById("kt_stack_graph_002");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var height = parseInt(KTUtil.css(element, 'height'));

                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                    var strokeColor = KTUtil.getCssVariableValue('--bs-gray-300');

                    var color1 = KTUtil.getCssVariableValue('--bs-success');
                    var color1Light = KTUtil.getCssVariableValue('--bs-light-success');

                    var color2 = KTUtil.getCssVariableValue('--bs-info');
                    var color2Light = KTUtil.getCssVariableValue('--bs-light-info');

                    var color3 = KTUtil.getCssVariableValue('--bs-warning');
                    var color3Light = KTUtil.getCssVariableValue('--bs-light-warning');

                    if (!element) {
                        return;
                    }
                    var options = {
                        series: [{
                            name: 'Delivered',
                            data: Delivered
                        }, {
                            name: 'Partial',
                            data: Partial
                        }, {
                            name: 'Pending',
                            data: Pending
                        }],
                        chart: {
                            type: 'bar',
                            height: 350,
                            stacked: true,
                            toolbar: {
                                show: true
                            },
                            zoom: {
                                enabled: true
                            }
                        },
                        responsive: [{
                            breakpoint: 480,
                            options: {
                                legend: {
                                    position: 'bottom',
                                    offsetX: -10,
                                    offsetY: 0
                                }
                            }
                        }],
                        plotOptions: {
                            bar: {
                                horizontal: false,
                                borderRadius: 10,
                                borderRadiusApplication: 'end',
                                borderRadiusWhenStacked: 'last',
                                dataLabels: {
                                    total: {
                                        enabled: true,
                                        style: {
                                            fontSize: '13px',
                                            fontWeight: 900
                                        }
                                    }
                                }
                            },
                        },
                        xaxis: {
                            type: 'Warehouse',
                            categories: Category,
                            labels: {
                                formatter: function (val, index) {
                                    // Return a span with title for tooltip
                                    return val;
                                },
                                style: {
                                    fontSize: '10px',
                                    fontFamily: 'Arial, sans-serif'
                                }
                            }
                        },
                        legend: {
                            show: true
                        },
                        colors: [color1, color2, color3],
                        fill: {
                            opacity: 1
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();
                };
                return {
                    init: function () {
                        initSIChart02();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart02;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart02.init();
            });

        }

    });
};
function fn03Chart() {
    //loader
    fn00Loader("#kt_bar_graph_003");
    //render
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-Issued-Item'
        },
        success: function (response) {

            //Variables
            const ItemName = response.map(i => i.ItemName);
            const Qty = response.map(i => i.QtyIssued);
            //Variables

            var SIChart03 = function () {

                var initSIChart03 = function () {

                    var element = document.getElementById("kt_bar_graph_003");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var height = parseInt(KTUtil.css(element, 'height'));
                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                    var baseColor = KTUtil.getCssVariableValue('--bs-success');
                    var baseLightColor = KTUtil.getCssVariableValue('--bs-light-success');
                    var secondaryColor = KTUtil.getCssVariableValue('--bs-warning');
                    var secondaryLightColor = KTUtil.getCssVariableValue('--bs-light-warning');

                    var options = {
                        series: [{
                            name: "Qty. Issued",
                            data: Qty
                        }],
                        chart: {
                            type: 'bar',
                            height: 350
                        },
                        plotOptions: {
                            bar: {
                                borderRadius: 4,
                                borderRadiusApplication: 'end',
                                horizontal: true,
                            }
                        },
                        dataLabels: {
                            enabled: false
                        },
                        xaxis: {
                            categories: ItemName,
                            labels: {
                                formatter: val =>
                                    val.toLocaleString('en-US', {
                                        notation: 'compact',
                                        compactDisplay: 'short',
                                        minimumFractionDigits: 0,
                                        maximumFractionDigits: 2
                                    }),
                                style: {
                                    colors: labelColor,
                                    fontSize: '12px'
                                }
                            }
                        },
                        tooltip: {
                            style: {
                                fontSize: '12px'
                            },
                            y: {
                                formatter: function (val) {
                                    var n = parseFloat(val).toFixed(2)
                                    return Number(n).toLocaleString('en');
                                }
                            }
                        },
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();
                };

                return {
                    init: function () {
                        initSIChart03();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart03;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart03.init();
            });

        }

    });
};
function fn04Chart() {
    //loader
    fn00Loader("#kt_donut_graph_004");
    //ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-PR-Status'
        },
        success: function (response) {
            //variable
            var Status = [response[0].Accepted, response[0].OnGoing, response[0].New, response[0].Cancelled];
            //variable

            // Class definition
            var SIChart04 = function () {
                // Private methods
                var initSIChart04 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);

                    //clear
                    element.innerHTML = "";
                    //clear

                    if (!element) {
                        return;
                    }

                    var baseColor = KTUtil.getCssVariableValue('--bs-success');
                    var infoColor = KTUtil.getCssVariableValue('--bs-info');
                    var darkColor = KTUtil.getCssVariableValue('--bs-dark');
                    var dangerColor = KTUtil.getCssVariableValue('--bs-danger');

                    var height = parseInt(KTUtil.css(element, 'height'));

                    var options = {
                        series: Status,
                        chart: {
                            type: 'donut',
                            height: 420,
                            width: '100%'
                        },
                        labels: ['Approved', 'On-Going', 'New', 'Cancelled'],
                        colors: [baseColor, infoColor, darkColor, dangerColor],
                        responsive: [{
                            breakpoint: 480,
                            options: {
                                chart: {
                                    width: 200
                                },
                                legend: {
                                    position: 'bottom'
                                }
                            }
                        }],
                        legend: {
                            show: true,
                            position: 'bottom',
                            floating: false,
                            labels: {
                                useSeriesColors: true,
                            },
                            markers: {
                                size: 0
                            },
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();
                }

                // Public methods
                return {
                    init: function () {
                        initSIChart04('#kt_donut_graph_004');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart04;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart04.init();
            });

        }

    });
};
function fn05Chart() {
    //loader
    fn00Loader("#kt_bar_graph_005");
    //ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-PR-Stage'
        },
        success: function (response) {
            // Class definition
            var SIChart05 = function () {
                // Private methods
                var initSIChart05 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);

                    //clear
                    element.innerHTML = "";
                    //clear

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Record",
                            data: [{
                                x: 'Purchase Request',
                                y: parseInt(response[0].PR)
                            }, {
                                x: 'Purchase Order',
                                y: parseInt(response[0].PO)
                            }, {
                                x: 'Receiving',
                                y: parseInt(response[0].IR)
                            }, {
                                x: 'Stock Issuance',
                                y: parseInt(response[0].SI)
                            }]
                        }],
                        chart: {
                            type: 'bar',
                            height: 380
                        },
                        xaxis: {
                            type: 'category',
                            labels: {
                                formatter: function (val) {
                                    return val;
                                }
                            }
                        },
                        tooltip: {
                            x: {
                                formatter: function (val) {
                                    return val;
                                }
                            }
                        },
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initSIChart05('#kt_bar_graph_005');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart05;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart05.init();
            });

        }

    });
};
function fn06Chart() {
    //loader
    fn00Loader("#kt_bar_graph_006");
    //ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-Stock-Warehouse'
        },
        success: function (response) {

            //Variables
            var Warehouse = [];
            var Count = [];
            //Variables

            //push
            response.forEach(function (i) {
                Warehouse.push(i.Warehouse);
                Count.push(i.Count);
            });
            //push

            // Class definition
            var SIChart06 = function () {
                // Private methods
                var initSIChart06 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);

                    //clear
                    element.innerHTML = "";
                    //clear

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Materials",
                            data: Count
                        }],
                        chart: {
                            type: 'bar',
                            height: 380
                        },
                        xaxis: {
                            type: 'category',
                            categories: Warehouse,
                        },
                        tooltip: {
                            x: {
                                formatter: function (val) {
                                    return val;
                                }
                            }
                        },
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initSIChart06('#kt_bar_graph_006');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart06;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart06.init();
            });

        }

    });
};
function fn07Chart() {
    //loader
    fn00Loader("#kt_donut_graph_007");
    //ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': "DSB240000",
            'pType': 'Get-Stock-Category'
        },
        success: function (response) {
            //variable
            var Category = [];
            var Count = [];
            //variable

            //push
            response.forEach(function (i) {
                Category.push(i.ClassName);
                Count.push(i.Count);
            });
            //push

            // Class definition
            var SIChart07 = function () {
                // Private methods
                var initSIChart07 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);

                    //clear
                    element.innerHTML = "";
                    //clear

                    if (!element) {
                        return;
                    }

                    var baseColor = KTUtil.getCssVariableValue('--bs-success');
                    var infoColor = KTUtil.getCssVariableValue('--bs-info');
                    var darkColor = KTUtil.getCssVariableValue('--bs-dark');
                    var dangerColor = KTUtil.getCssVariableValue('--bs-danger');

                    var height = parseInt(KTUtil.css(element, 'height'));

                    var dynamicColors = Count.map((_, index) =>
                        `hsl(${Math.round(index * (360 / Count.length))}, 70%, 50%)`
                    );

                    var options = {
                        series: Count,
                        chart: {
                            type: 'donut',
                            height: height,
                            width: '100%'
                        },
                        labels: Category,
                        colors: dynamicColors,
                        responsive: [{
                            breakpoint: 480,
                            options: {
                                chart: {
                                    width: 200
                                },
                                legend: {
                                    position: 'bottom'
                                }
                            }
                        }]
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();
                }

                // Public methods
                return {
                    init: function () {
                        initSIChart07('#kt_donut_graph_007');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = SIChart07;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                SIChart07.init();
            });

        }

    });
};
//function - Chart

//function - Table
function fn01Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Moving-PO'
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
                        { colId: 'PRNo', pinned: 'left' },
                        { colId: 'PONo', pinned: 'left' }
                    ]
                });
            }
        },
        onRowClicked: params => {
            fn0102Table(params.data.PRNo);
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [

            {
                headerName: "P.R. No.",
                field: "PRNo",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PRNo",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "P.O. No.",
                field: "PONo",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PONo",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Form Status",
                field: "FormStatus",
                filter: 'agTextColumnFilter',
                tooltipField: "FormStatus",
                width: 180
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Unit",
                field: "Unit",
                filter: 'agTextColumnFilter',
                tooltipField: "Unit",
                width: 100
            },
            {
                headerName: "P.R. Qty",
                field: "PRQty",
                tooltipField: "PRQty",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.PRQty) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "P.O. Qty",
                field: "POQty",
                tooltipField: "POQty",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.IssuedQty) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                field: "Balance",
                tooltipField: "Balance",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Balance) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Status",
                field: "Percentage",
                tooltipField: "Percentage" + "%",
                width: 180,
                cellRenderer: params => {
                    const value = params.value || 0;

                    let colorClass = "bg-danger";
                    if (value.toFixed(2) > 95) {
                        colorClass = "bg-success";
                    } else {
                        colorClass = "bg-warning";
                    }

                    const div = document.createElement("div");
                    div.className = "d-flex flex-column w-100";

                    div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                    // Animate after render
                    setTimeout(() => {
                        const bar = div.querySelector(".progress-bar");
                        bar.style.width = value + "%";
                    }, 50);

                    return div;
                }
            },
            {
                headerName: "Overall Status",
                field: "Overall",
                tooltipField: "Overall" + "%",
                width: 180,
                cellRenderer: params => {
                    const value = params.value || 0;

                    let colorClass = "bg-danger";
                    if (value.toFixed(2) >= 95) {
                        colorClass = "bg-success";
                    } else {
                        colorClass = "bg-warning";
                    }

                    const div = document.createElement("div");
                    div.className = "d-flex flex-column w-100";

                    div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                    // Animate after render
                    setTimeout(() => {
                        const bar = div.querySelector(".progress-bar");
                        bar.style.width = value + "%";
                    }, 50);

                    return div;
                }
            },
            {
                headerName: "Requestor",
                field: "Requestor",
                filter: 'agTextColumnFilter',
                tooltipField: "Requestor",
                width: 150
            },
            {
                headerName: "Purchaser",
                field: "Purchaser",
                filter: 'agTextColumnFilter',
                tooltipField: "Purchaser",
                width: 150
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                width: 200
            },
            {
                headerName: "Category",
                field: "Category",
                filter: 'agTextColumnFilter',
                tooltipField: "Category",
                width: 180
            },
            {
                headerName: "P.R. Remarks",
                field: "PRRemarks",
                filter: 'agTextColumnFilter',
                tooltipField: "PRRemarks",
                width: 250
            },
            {
                headerName: "Created Date",
                field: "PRDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "PRDate"
            },
            {
                headerName: "Date Approval",
                field: "ApprDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "ApprDate"
            },
        ],
        rowData: [],
        pagination: false,
    };
    grid01Api = agGrid.createGrid(gridDiv, gridOptions);

};
function fn0102Table(pID) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-PO-Detail',
            'pPRNo': pID
        },
        success: function (response) {
            if (response && response.length > 0) {
                grid0101Api.setGridOption("rowData", response);
                $("#mdl0102Record").modal("show");
            } else {
                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
            }
        },
        complete: function (response) {
            grid0101Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table0102Record');
    let gridOptions;

    //Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [
            {
                headerName: "PR No.",
                field: "PRNo",
                lockPosition: true,
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PRNo",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    window.open("FRM000010-DTL-" + params.data.PRNo, '_blank').focus();
                }
            },
            {
                headerName: "PO No.",
                field: "PONo",
                lockPosition: true,
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PONo",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    if (params.data.POCode && params.data.POCode.trim() !== "") {
                        window.open("SCM060100-DTL-" + params.data.POCode, '_blank').focus();
                    } else {
                        fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                    }
                }
            },
            {
                headerName: "RR No.",
                field: "IRNo",
                lockPosition: true,
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "IRNo",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    if (params.data.IRCode && params.data.IRcode.tring() !== "") {
                        window.open("SCM070100-DTL-" + params.data.IRCode, '_blank').focus();
                    } else {
                        fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                    }
                }
            },
            {
                headerName: "PO Date",
                field: "PODate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "PODate"
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 180,
                tooltipField: "Status",
                cellRenderer: params => {
                    var span = "";
                    if (params.value != "") {
                        if (params.value == "Processed") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>
                                        <span class='svg-icon svg-icon-info svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M18.1446364,11.84388 L17.4471627,16.0287218 C17.4463569,16.0335568 17.4455155,16.0383857 17.4446387,16.0432083 C17.345843,16.5865846 16.8252597,16.9469884 16.2818833,16.8481927 L4.91303792,14.7811299 C4.53842737,14.7130189 4.23500006,14.4380834 4.13039941,14.0719812 L2.30560137,7.68518803 C2.28007524,7.59584656 2.26712532,7.50338343 2.26712532,7.4104669 C2.26712532,6.85818215 2.71484057,6.4104669 3.26712532,6.4104669 L16.9929851,6.4104669 L17.606173,3.78251876 C17.7307772,3.24850086 18.2068633,2.87071314 18.7552257,2.87071314 L20.8200821,2.87071314 C21.4717328,2.87071314 22,3.39898039 22,4.05063106 C22,4.70228173 21.4717328,5.23054898 20.8200821,5.23054898 L19.6915238,5.23054898 L18.1446364,11.84388 Z' fill='currentColor' opacity='0.3'/>
                                                <path d='M6.5,21 C5.67157288,21 5,20.3284271 5,19.5 C5,18.6715729 5.67157288,18 6.5,18 C7.32842712,18 8,18.6715729 8,19.5 C8,20.3284271 7.32842712,21 6.5,21 Z M15.5,21 C14.6715729,21 14,20.3284271 14,19.5 C14,18.6715729 14.6715729,18 15.5,18 C16.3284271,18 17,18.6715729 17,19.5 C17,20.3284271 16.3284271,21 15.5,21 Z' fill='currentColor'/>
                                            </g>
                                        </svg>
                                        Ordered</span></div>`;
                        } else if (params.value == "Delivered") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-success border border-success fs-base'>
                                        <span class='svg-icon svg-icon-primary svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M20.4061385,6.73606154 C20.7672665,6.89656288 21,7.25468437 21,7.64987309 L21,16.4115967 C21,16.7747638 20.8031081,17.1093844 20.4856429,17.2857539 L12.4856429,21.7301984 C12.1836204,21.8979887 11.8163796,21.8979887 11.5143571,21.7301984 L3.51435707,17.2857539 C3.19689188,17.1093844 3,16.7747638 3,16.4115967 L3,7.64987309 C3,7.25468437 3.23273352,6.89656288 3.59386153,6.73606154 L11.5938615,3.18050598 C11.8524269,3.06558805 12.1475731,3.06558805 12.4061385,3.18050598 L20.4061385,6.73606154 Z' fill='currentColor' opacity='0.3'/>
                                                <polygon fill='currentColor' points='14.9671522 4.22441676 7.5999999 8.31727912 7.5999999 12.9056825 9.5999999 13.9056825 9.5999999 9.49408582 17.25507 5.24126912'/>
                                            </g>
                                        </svg>
                                        Delivered</span></div>`;
                        } else {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info2 border border-info2 fs-base'>
                                        <span class='svg-icon svg-icon-info2 svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M10.9630156,7.5 L11.0475062,7.5 C11.3043819,7.5 11.5194647,7.69464724 11.5450248,7.95024814 L12,12.5 L15.2480695,14.3560397 C15.403857,14.4450611 15.5,14.6107328 15.5,14.7901613 L15.5,15 C15.5,15.2109164 15.3290185,15.3818979 15.1181021,15.3818979 C15.0841582,15.3818979 15.0503659,15.3773725 15.0176181,15.3684413 L10.3986612,14.1087258 C10.1672824,14.0456225 10.0132986,13.8271186 10.0316926,13.5879956 L10.4644883,7.96165175 C10.4845267,7.70115317 10.7017474,7.5 10.9630156,7.5 Z' fill='currentColor'/>
                                                <path d='M7.38979581,2.8349582 C8.65216735,2.29743306 10.0413491,2 11.5,2 C17.2989899,2 22,6.70101013 22,12.5 C22,18.2989899 17.2989899,23 11.5,23 C5.70101013,23 1,18.2989899 1,12.5 C1,11.5151324 1.13559454,10.5619345 1.38913364,9.65805651 L3.31481075,10.1982117 C3.10672013,10.940064 3,11.7119264 3,12.5 C3,17.1944204 6.80557963,21 11.5,21 C16.1944204,21 20,17.1944204 20,12.5 C20,7.80557963 16.1944204,4 11.5,4 C10.54876,4 9.62236069,4.15592757 8.74872191,4.45446326 L9.93948308,5.87355717 C10.0088058,5.95617272 10.0495583,6.05898805 10.05566,6.16666224 C10.0712834,6.4423623 9.86044965,6.67852665 9.5847496,6.69415008 L4.71777931,6.96995273 C4.66931162,6.97269931 4.62070229,6.96837279 4.57348157,6.95710938 C4.30487471,6.89303938 4.13906482,6.62335149 4.20313482,6.35474463 L5.33163823,1.62361064 C5.35654118,1.51920756 5.41437908,1.4255891 5.49660017,1.35659741 C5.7081375,1.17909652 6.0235153,1.2066885 6.2010162,1.41822583 L7.38979581,2.8349582 Z' fill='currentColor' opacity='0.3'/>
                                            </g>
                                        </svg>
                                        ${params.value}</span></div>`;
                        };
                    };
                    return span;
                },
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Qty",
                field: "Qty",
                width: 150,
                tooltipField: "Qty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Unit",
                field: "Unit",
                filter: 'agTextColumnFilter',
                tooltipField: "Unit",
                width: 100
            },
            {
                headerName: "Supplier",
                field: "Supplier",
                filter: 'agTextColumnFilter',
                tooltipField: "Supplier",
                width: 200
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                width: 180
            },
            {
                headerName: "Dlvr. Type",
                field: "DlvrType",
                filter: 'agTextColumnFilter',
                tooltipField: "DlvrType",
                width: 180
            },
            {
                headerName: "Pick-Up Date",
                field: "PickUpDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "PickUpDate"
            }
        ],
        rowData: [],
        pagination: false
    };

    grid0101Api = agGrid.createGrid(gridDiv, gridOptions);

};
function fn02Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Moving-SR'
        },
        success: function (response) {
            grid02Api.setGridOption('rowData', response);
        },
        complete: function (response) {
            grid02Api.setGridOption('loading', false);
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
                        { colId: 'PRNo', pinned: 'left' },
                        { colId: 'SINo', pinned: 'left' }
                    ]
                });
            }
        },
        onRowClicked: params => {
            fn0202Table(params.data.PRNo);
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [

            {
                headerName: "PR. No.",
                field: "PRNo",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PRNo",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "SI. No.",
                field: "SINo",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "SINo",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Form Status",
                field: "FormStatus",
                filter: 'agTextColumnFilter',
                tooltipField: "FormStatus",
                width: 180
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Unit",
                field: "Unit",
                filter: 'agTextColumnFilter',
                tooltipField: "Unit",
                width: 100
            },
            {
                headerName: "P.R. Qty",
                field: "PRQty",
                tooltipField: "PRQty",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.PRQty) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "S.I. Qty",
                field: "SIQty",
                tooltipField: "SIQty",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.IssuedQty) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                field: "Balance",
                tooltipField: "Balance",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Balance) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Status",
                headerClass: "text-center",
                cellClass: "text-end",
                children: [
                    {
                        headerName: "Status",
                        field: "Status",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Status",
                        width: 150,
                        cellRenderer: params => {
                            var span = "";
                            if (params.data.Status == "Delivered") {
                                span = `<span class="d-flex justify-content-center badge badge-success mt-3"><i class="las la-clock fs-7 mr-5 text-white"></i>${params.value}</span>`;
                            } else if (params.data.Status == "On-Going") {
                                span = `<span class="d-flex justify-content-center mt-2 badge badge-for-closed"><i class="las la-bookmark fs-7 mr-5 text-white"></i>${params.value}</span>`;
                            } else if (params.data.Status == "Partial") {
                                span = `<span class="d-flex justify-content-center badge badge-warning mt-3"><i class="las la-exclamation-circle fs-7 mr-5 text-white"></i>Partial</span>`;
                            } else {
                                span = `<span class="d-flex justify-content-center mt-2 badge badge-for-closed"><i class="las la-bookmark fs-7 mr-5 text-white"></i>${params.value}</span>`;
                            };
                            return span;
                        }
                    },
                    {
                        field: "Percentage",
                        tooltipField: "Percentage" + "%",
                        width: 180,
                        cellRenderer: params => {
                            const value = params.value || 0;

                            let colorClass = "bg-danger";
                            if (value.toFixed(2) > 95) {
                                colorClass = "bg-success";
                            } else {
                                colorClass = "bg-warning";
                            }

                            const div = document.createElement("div");
                            div.className = "d-flex flex-column w-100";

                            div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                            // Animate after render
                            setTimeout(() => {
                                const bar = div.querySelector(".progress-bar");
                                bar.style.width = value + "%";
                            }, 50);

                            return div;
                        }
                    },
                ]
            },
            {
                headerName: "Overall Status",
                field: "Overall",
                tooltipField: "Overall" + "%",
                width: 180,
                cellRenderer: params => {
                    const value = params.value || 0;

                    let colorClass = "bg-danger";
                    if (value.toFixed(2) >= 95) {
                        colorClass = "bg-success";
                    } else {
                        colorClass = "bg-warning";
                    }

                    const div = document.createElement("div");
                    div.className = "d-flex flex-column w-100";

                    div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                    // Animate after render
                    setTimeout(() => {
                        const bar = div.querySelector(".progress-bar");
                        bar.style.width = value + "%";
                    }, 50);

                    return div;
                }
            },
            {
                headerName: "Requestor",
                field: "Requestor",
                filter: 'agTextColumnFilter',
                tooltipField: "Requestor",
                width: 150
            },
            {
                headerName: "Issued By",
                field: "IssuedBy",
                filter: 'agTextColumnFilter',
                tooltipField: "IssuedBy",
                width: 150
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                width: 200
            },
            {
                headerName: "Category",
                field: "Category",
                filter: 'agTextColumnFilter',
                tooltipField: "Category",
                width: 180
            },
            {
                headerName: "P.R. Remarks",
                field: "PRRemarks",
                filter: 'agTextColumnFilter',
                tooltipField: "PRRemarks",
                width: 250
            },
            {
                headerName: "Created Date",
                field: "PRDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "PRDate"
            },
            {
                headerName: "Date Approval",
                field: "ApprDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "ApprDate"
            },
        ],
        rowData: [],
        pagination: false,
    };
    grid02Api = agGrid.createGrid(gridDiv, gridOptions);
};
function fn0202Table(pID) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-SR-Detail',
            'pPRNo': pID
        },
        success: function (response) {
            if (response && response.length > 0) {
                grid0201Api.setGridOption("rowData", response);
                $("#mdl0201Record").modal("show");
            } else {
                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
            }
        },
        complete: function (response) {
            grid0201Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table0201Record');
    let gridOptions;

    //Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [
            {
                headerName: "PR No.",
                field: "PRNo",
                lockPosition: true,
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PRNo",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    window.open("FRM000010-DTL-" + params.data.PRNo, '_blank').focus();
                }
            },
            {
                headerName: "S.I. No.",
                field: "SINo",
                lockPosition: true,
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "SINo",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    if (params.data.SICode && params.data.SICode.trim() !== "") {
                        window.open("SCM070100-DTL-" + params.data.SICode, '_blank').focus();
                    } else {
                        fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                    }
                }
            },
            {
                headerName: "G.P No.",
                field: "GPNo",
                lockPosition: true,
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "GPNo",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "S.I. Date",
                field: "SIDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "SIDate"
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 180,
                tooltipField: "Status",
                cellRenderer: params => {
                    var span = "";
                    if (params.value != "") {
                        if (params.value == "Processed") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>
                                        <span class='svg-icon svg-icon-info svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M18.1446364,11.84388 L17.4471627,16.0287218 C17.4463569,16.0335568 17.4455155,16.0383857 17.4446387,16.0432083 C17.345843,16.5865846 16.8252597,16.9469884 16.2818833,16.8481927 L4.91303792,14.7811299 C4.53842737,14.7130189 4.23500006,14.4380834 4.13039941,14.0719812 L2.30560137,7.68518803 C2.28007524,7.59584656 2.26712532,7.50338343 2.26712532,7.4104669 C2.26712532,6.85818215 2.71484057,6.4104669 3.26712532,6.4104669 L16.9929851,6.4104669 L17.606173,3.78251876 C17.7307772,3.24850086 18.2068633,2.87071314 18.7552257,2.87071314 L20.8200821,2.87071314 C21.4717328,2.87071314 22,3.39898039 22,4.05063106 C22,4.70228173 21.4717328,5.23054898 20.8200821,5.23054898 L19.6915238,5.23054898 L18.1446364,11.84388 Z' fill='currentColor' opacity='0.3'/>
                                                <path d='M6.5,21 C5.67157288,21 5,20.3284271 5,19.5 C5,18.6715729 5.67157288,18 6.5,18 C7.32842712,18 8,18.6715729 8,19.5 C8,20.3284271 7.32842712,21 6.5,21 Z M15.5,21 C14.6715729,21 14,20.3284271 14,19.5 C14,18.6715729 14.6715729,18 15.5,18 C16.3284271,18 17,18.6715729 17,19.5 C17,20.3284271 16.3284271,21 15.5,21 Z' fill='currentColor'/>
                                            </g>
                                        </svg>
                                        Ordered</span></div>`;
                        } else if (params.value == "Delivered") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-success border border-success fs-base'>
                                        <span class='svg-icon svg-icon-primary svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M20.4061385,6.73606154 C20.7672665,6.89656288 21,7.25468437 21,7.64987309 L21,16.4115967 C21,16.7747638 20.8031081,17.1093844 20.4856429,17.2857539 L12.4856429,21.7301984 C12.1836204,21.8979887 11.8163796,21.8979887 11.5143571,21.7301984 L3.51435707,17.2857539 C3.19689188,17.1093844 3,16.7747638 3,16.4115967 L3,7.64987309 C3,7.25468437 3.23273352,6.89656288 3.59386153,6.73606154 L11.5938615,3.18050598 C11.8524269,3.06558805 12.1475731,3.06558805 12.4061385,3.18050598 L20.4061385,6.73606154 Z' fill='currentColor' opacity='0.3'/>
                                                <polygon fill='currentColor' points='14.9671522 4.22441676 7.5999999 8.31727912 7.5999999 12.9056825 9.5999999 13.9056825 9.5999999 9.49408582 17.25507 5.24126912'/>
                                            </g>
                                        </svg>
                                        Delivered</span></div>`;
                        } else if (params.value == "Cancelled") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>
                                        <span class='svg-icon svg-icon-primary svg-icon-1x'><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <rect x="0" y="0" width="24" height="24"/>
                                                <circle fill="#000000" opacity="0.3" cx="12" cy="12" r="10"/>
                                                <path d="M12.0355339,10.6213203 L14.863961,7.79289322 C15.2544853,7.40236893 15.8876503,7.40236893 16.2781746,7.79289322 C16.6686989,8.18341751 16.6686989,8.81658249 16.2781746,9.20710678 L13.4497475,12.0355339 L16.2781746,14.863961 C16.6686989,15.2544853 16.6686989,15.8876503 16.2781746,16.2781746 C15.8876503,16.6686989 15.2544853,16.6686989 14.863961,16.2781746 L12.0355339,13.4497475 L9.20710678,16.2781746 C8.81658249,16.6686989 8.18341751,16.6686989 7.79289322,16.2781746 C7.40236893,15.8876503 7.40236893,15.2544853 7.79289322,14.863961 L10.6213203,12.0355339 L7.79289322,9.20710678 C7.40236893,8.81658249 7.40236893,8.18341751 7.79289322,7.79289322 C8.18341751,7.40236893 8.81658249,7.40236893 9.20710678,7.79289322 L12.0355339,10.6213203 Z" fill="currentColor"/>
                                            </g>
                                        </svg>
                                        Cancelled</span></div>`;
                        } else {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info2 border border-info2 fs-base'>
                                        <span class='svg-icon svg-icon-info2 svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M10.9630156,7.5 L11.0475062,7.5 C11.3043819,7.5 11.5194647,7.69464724 11.5450248,7.95024814 L12,12.5 L15.2480695,14.3560397 C15.403857,14.4450611 15.5,14.6107328 15.5,14.7901613 L15.5,15 C15.5,15.2109164 15.3290185,15.3818979 15.1181021,15.3818979 C15.0841582,15.3818979 15.0503659,15.3773725 15.0176181,15.3684413 L10.3986612,14.1087258 C10.1672824,14.0456225 10.0132986,13.8271186 10.0316926,13.5879956 L10.4644883,7.96165175 C10.4845267,7.70115317 10.7017474,7.5 10.9630156,7.5 Z' fill='currentColor'/>
                                                <path d='M7.38979581,2.8349582 C8.65216735,2.29743306 10.0413491,2 11.5,2 C17.2989899,2 22,6.70101013 22,12.5 C22,18.2989899 17.2989899,23 11.5,23 C5.70101013,23 1,18.2989899 1,12.5 C1,11.5151324 1.13559454,10.5619345 1.38913364,9.65805651 L3.31481075,10.1982117 C3.10672013,10.940064 3,11.7119264 3,12.5 C3,17.1944204 6.80557963,21 11.5,21 C16.1944204,21 20,17.1944204 20,12.5 C20,7.80557963 16.1944204,4 11.5,4 C10.54876,4 9.62236069,4.15592757 8.74872191,4.45446326 L9.93948308,5.87355717 C10.0088058,5.95617272 10.0495583,6.05898805 10.05566,6.16666224 C10.0712834,6.4423623 9.86044965,6.67852665 9.5847496,6.69415008 L4.71777931,6.96995273 C4.66931162,6.97269931 4.62070229,6.96837279 4.57348157,6.95710938 C4.30487471,6.89303938 4.13906482,6.62335149 4.20313482,6.35474463 L5.33163823,1.62361064 C5.35654118,1.51920756 5.41437908,1.4255891 5.49660017,1.35659741 C5.7081375,1.17909652 6.0235153,1.2066885 6.2010162,1.41822583 L7.38979581,2.8349582 Z' fill='currentColor' opacity='0.3'/>
                                            </g>
                                        </svg>
                                        ${params.value}</span></div>`;
                        };
                    };
                    return span;
                },
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Qty",
                field: "Qty",
                width: 150,
                tooltipField: "Qty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Unit",
                field: "Unit",
                filter: 'agTextColumnFilter',
                tooltipField: "Unit",
                width: 100
            },
            {
                headerName: "Type",
                field: "Type",
                filter: 'agTextColumnFilter',
                tooltipField: "Type",
                width: 100
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                width: 180
            },
            {
                headerName: "Trxn. Type",
                field: "TrxnType",
                filter: 'agTextColumnFilter',
                tooltipField: "TrxnType",
                width: 180
            },
            {
                headerName: "Created Date",
                field: "SICreatedDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "SICreatedDate"
            }
        ],
        rowData: [],
        pagination: false
    };

    grid0201Api = agGrid.createGrid(gridDiv, gridOptions);

}
function fn03Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Stock-Inventory'
        },
        success: function (response) {
            grid03Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid03Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table03Record');
    let gridOptions;

    //Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: updFooter,
        onFirstDataRendered: updFooter,
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'Warehouse', pinned: 'left' }
                    ]
                });
            }
        },
        //onRowClicked: params => {
        //    fn0301Table(params.data.WhseCode);
        //},
        columnDefs: [
            {
                headerName: "Warehouse",
                field: "Warehouse",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 250,
                tooltipField: "Warehouse",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Classification",
                field: "ClassName",
                filter: 'agTextColumnFilter',
                width: 250,
                tooltipField: "ClassName"
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                flex: 1,
                minWidth: 350,
                tooltipField: "ItemName"
            },
            {
                headerName: "Qty. Stock",
                field: "Qty",
                width: 150,
                tooltipField: "Qty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Unit",
                field: "UMName",
                filter: 'agTextColumnFilter',
                width: 75,
                tooltipField: "UMName"
            },
            {
                headerName: "Cost",
                field: "Cost",
                width: 150,
                tooltipField: "Cost",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Total",
                field: "Total",
                width: 150,
                tooltipField: "Total",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            }
        ],
        rowData: [],
        pagination: false,
        getRowStyle: params => {
            if (params.node.rowPinned) {
                return { fontWeight: 'bold', background: '#f8f9fa' };
            }
        }
    };

    grid03Api = agGrid.createGrid(gridDiv, gridOptions);
    function updFooter() {
        let Qty = 0;
        let Cost = 0;
        let Total = 0;

        grid03Api.forEachNodeAfterFilter(function (node) {
            Total += Number(node.data.Total) || 0;
            Qty += Number(node.data.Qty) || 0;
            Cost += Number(node.data.Cost) || 0;
        });

        grid03Api.setGridOption('pinnedBottomRowData', [
            { Warehouse: 'TOTAL', Qty: Qty, Cost: Cost, Total: Total }
        ]);
    }
};
function fn0301Table(pID) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Stock-Detail',
            'pWarehouse': pID
        },
        success: function (response) {
            if (response && response.length > 0) {
                grid0301Api.setGridOption("rowData", response);
            } else {
                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
            }
        },
        complete: function (response) {
            grid0301Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table0301Record');
    let gridOptions;

    //Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: updFooter,
        onFirstDataRendered: updFooter,
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'Warehouse', pinned: 'left' },
                        { colId: 'Percentage', pinned: 'right' }
                    ]
                });
            }
        },
        columnDefs: [
            {
                headerName: "Warehouse",
                field: "Warehouse",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 200,
                tooltipField: "Warehouse",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Qty",
                field: "Qty",
                width: 150,
                tooltipField: "Qty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Unit",
                field: "Unit",
                filter: 'agTextColumnFilter',
                tooltipField: "Unit",
                width: 100
            },
            {
                headerName: "Item Receiving",
                headerClass: "text-center",
                children: [
                    {
                        headerName: "I.R. No.",
                        field: "IRNo",
                        filter: 'agTextColumnFilter',
                        width: 160,
                        tooltipField: "IRNo",
                        onCellClicked: function (params) {
                            //redirect
                            if (params.data.IRCode && params.data.IRCode.trim() !== "") {
                                window.open("SCM070100-DTL-" + params.data.IRCode, '_blank').focus();
                            } else {
                                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                            }
                        }
                    },
                    {
                        headerName: "I.R. Qty",
                        field: "IRQty",
                        width: 150,
                        tooltipField: "IRQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontStyle: 'italic' }
                    },
                    {
                        headerName: "I.R. Date",
                        field: "IRDate",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "IRDate"
                    },
                ]
            },
            {
                headerName: "Stock Issuance",
                headerClass: "text-center",
                children: [
                    {
                        headerName: "S.I. No.",
                        field: "SINo",
                        filter: 'agTextColumnFilter',
                        width: 160,
                        tooltipField: "SINo",
                        onCellClicked: function (params) {
                            //redirect
                            if (params.data.SICode && params.data.SICode.trim() !== "") {
                                window.open("SCM080100-DTL-" + params.data.SICode, '_blank').focus();
                            } else {
                                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                            }
                        }
                    },
                    {
                        headerName: "S.I. Qty",
                        field: "SIQty",
                        width: 150,
                        tooltipField: "SIQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontStyle: 'italic' }
                    },
                    {
                        headerName: "S.I. Date",
                        field: "SIDate",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "SIDate"
                    },
                ]
            },
            {
                headerName: "Warehouse Transfer",
                headerClass: "text-center",
                children: [
                    {
                        headerName: "W.T. No.",
                        field: "WTNo",
                        filter: 'agTextColumnFilter',
                        width: 160,
                        tooltipField: "WTNo",
                        onCellClicked: function (params) {
                            //redirect
                            if (params.data.WTCode && params.data.WTCode.trim() !== "") {
                                window.open("SCM090100-DTL-" + params.data.WTCode, '_blank').focus();
                            } else {
                                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                            }
                        }
                    },
                    {
                        headerName: "W.T. Qty",
                        field: "WTQty",
                        width: 150,
                        tooltipField: "WTQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontStyle: 'italic' }
                    },
                    {
                        headerName: "W.T. Date",
                        field: "WTDate",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "WTDate"
                    },
                ]
            },
            {
                headerName: "Item Convertion",
                headerClass: "text-center",
                children: [
                    {
                        headerName: "I.C. No.",
                        field: "ICNo",
                        filter: 'agTextColumnFilter',
                        width: 160,
                        tooltipField: "ICNo",
                        onCellClicked: function (params) {
                            //redirect
                            if (params.data.ICCode && params.data.ICCode.trim() !== "") {
                                window.open("SCM100100-DTL-" + params.data.ICCode, '_blank').focus();
                            } else {
                                fnAlertOnly('No records found.', 'error', 'btn btn-danger');
                            }
                        }
                    },
                    {
                        headerName: "I.C. Qty",
                        field: "ICQty",
                        width: 150,
                        tooltipField: "ICQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontStyle: 'italic' }
                    },
                    {
                        headerName: "I.C. Date",
                        field: "ICDate",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "ICDate"
                    },
                ]
            },
            {
                headerName: "Category",
                field: "ClassName",
                filter: 'agTextColumnFilter',
                width: 200,
                tooltipField: "ClassName"
            },
            {
                headerName: "Prev. Average",
                field: "PrevAvg",
                width: 150,
                tooltipField: "PrevAvg",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Stock Level",
                field: "Percentage",
                tooltipField: "Percentage" + "%",
                width: 180,
                pinned: "right",
                cellRenderer: params => {
                    const value = params.value || 0;

                    let colorClass = "bg-danger";
                    if (value.toFixed(2) > 50) {
                        colorClass = "bg-success";
                    } else if (value.toFixed(2) <= 40) {
                        colorClass = "bg-warning";
                    }

                    const div = document.createElement("div");
                    div.className = "d-flex flex-column w-100";

                    div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                    // Animate after render
                    setTimeout(() => {
                        const bar = div.querySelector(".progress-bar");
                        bar.style.width = value + "%";
                    }, 50);

                    return div;
                }
            }
        ],
        rowData: [],
        pagination: false,
        getRowStyle: params => {
            if (params.node.rowPinned) {
                return { fontWeight: 'bold', background: '#f8f9fa' };
            }
        }
    };

    grid0301Api = agGrid.createGrid(gridDiv, gridOptions);

    function updFooter() {
        let totalQty = 0;
        let totalIRQty = 0;
        let totalSIQty = 0;
        let totalWTQty = 0;
        let totalICQty = 0;

        grid0301Api.forEachNodeAfterFilter(function (node) {
            totalQty += Number(node.data.Qty) || 0;
            totalIRQty += Number(node.data.IRQty) || 0;
            totalSIQty += Number(node.data.SIQty) || 0;
            totalWTQty += Number(node.data.WTQty) || 0;
            totalICQty += Number(node.data.ICQty) || 0;
        });

        grid0301Api.setGridOption('pinnedBottomRowData', [
            { Warehouse: 'TOTAL', Qty: totalQty, IRQty: totalIRQty, SIQty: totalSIQty, WTQty: totalWTQty, ICQty: totalICQty }
        ]);
    }

    //modal
    $("#mdl0301Record").modal("show");
};
function fn04Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Actual-Usage'
        },
        success: function (response) {
            grid04Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid04Api.setGridOption("loading", false);
        }
    });

    const AbbrMonths = [];
    for (let i = 0; i < 7; i++) {
        const d = new Date();
        d.setMonth(d.getMonth() - i);
        AbbrMonths.push(d.toLocaleString('default', { month: 'short' }));
    }

    //AG Grid
    let gridDiv = document.querySelector('#table04Record');
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
                        { colId: 'ItemName', pinned: 'left' },
                        { colId: 'CurrentStock', pinned: 'right' },
                        { colId: 'Projection', pinned: 'right' }
                    ]
                });
            }
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: updFooter,
        onFirstDataRendered: updFooter,
        columnDefs: [
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                pinned: 'left',
                flex: 1,
                minWidth: 450,
                getQuickFilterText: params => params.data.SearchText || '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[6],
                field: "Month7",
                tooltipField: "Month7",
                width: 150,
                cellStyle: { fontStyle: 'italic' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month6) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[5],
                field: "Month6",
                tooltipField: "Month6",
                width: 150,
                cellStyle: { fontStyle: 'italic' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month6) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[4],
                field: "Month5",
                tooltipField: "Month5",
                width: 150,
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month5) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[3],
                field: "Month4",
                tooltipField: "Month4",
                width: 150,
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month4) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[2],
                field: "Month3",
                tooltipField: "Month3",
                width: 150,
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month3) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[1],
                field: "Month2",
                tooltipField: "Month2",
                width: 150,
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month2) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: AbbrMonths[0],
                field: "Month1",
                tooltipField: "Month1",
                width: 150,
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month1) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
                cellStyle: params => params.data.No == 1 ? '' : { fontWeight: 'bold', fontStyle: 'italic' }
            },
            {
                headerName: "Avg. per Month",
                field: "AvgMonth",
                tooltipField: "AvgMonth",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.AvgMonth) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
            },
            {
                headerName: "Current Stock",
                colId: "CurrentStock",
                field: "Month1",
                tooltipField: "Month1",
                width: 150,
                pinned: "right",
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Month1) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
            },
            {
                headerName: "Projection",
                field: "Projection",
                tooltipField: "Projection",
                width: 150,
                pinned: "right",
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Projection) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                getQuickFilterText: () => '',
            },
        ],
        rowData: [],
        pagination: false,
        getRowStyle: params => {
            if (params.node.rowPinned) {
                return { fontWeight: 'bold', background: '#f8f9fa' };
            }
        }
    };
    grid04Api = agGrid.createGrid(gridDiv, gridOptions);

    function updFooter() {
        let month6 = 0;
        let month5 = 0;
        let month4 = 0;
        let month3 = 0;
        let month2 = 0;
        let month1 = 0;
        let overall = 0;
        let average = 0;

        grid04Api.forEachNodeAfterFilter(function (node) {
            month6 += Number(node.data.Month6) || 0;
            month5 += Number(node.data.Month5) || 0;
            month4 += Number(node.data.Month4) || 0;
            month3 += Number(node.data.Month3) || 0;
            month2 += Number(node.data.Month2) || 0;
            month1 += Number(node.data.Month1) || 0;
            overall += Number(node.data.Total) || 0;
            average += Number(node.data.AvgMonth) || 0;
        });

        grid04Api.setGridOption('pinnedBottomRowData', [
            { ItemName: 'TOTAL', Month6: month6, Month5: month5, Month4: month4, Month3: month3, Month2: month2, Month1: month1, Total: overall, AvgMonth: average}
        ]);
    }

};
function fn05Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFormCode': 'DSB240000',
            'pType': 'Get-Incoming-Stock'
        },
        success: function (response) {
            grid05Api.setGridOption('rowData', response);
        },
        complete: function (response) {
            grid05Api.setGridOption('loading', false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table05Record');
    let gridOptions;

    // Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        onFilterChanged: updFooter,
        onFirstDataRendered: updFooter,
        loading: true,
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'RefNo', pinned: 'left' },
                        { colId: 'Warehouse', pinned: 'right' },
                        { colId: 'CurrBal', pinned: 'right' },
                        { colId: 'NewBal', pinned: 'right' }
                    ]
                });
            }
        },
        columnDefs: [
            {
                headerName: "PR. No.",
                field: "RefNo",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "RefNo",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    window.open("FRM000010-DTL-" + params.value, '_blank').focus();
                }
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Qty",
                field: "Qty",
                width: 150,
                tooltipField: "Qty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Date",
                field: "Date",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "Date"
            },
            {
                headerName: "Supplier/Vendor",
                field: "Supplier",
                filter: 'agTextColumnFilter',
                tooltipField: "Supplier",
                width: 200,
            },
            {
                headerName: "Purchaser",
                field: "Purchaser",
                filter: 'agTextColumnFilter',
                tooltipField: "Purchaser",
                width: 200,
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 180,
                cellRenderer: params => {
                    var span = "";
                    if (params.value != "") {
                        if (params.value == "Processed") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>
                                        <span class='svg-icon svg-icon-info svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M18.1446364,11.84388 L17.4471627,16.0287218 C17.4463569,16.0335568 17.4455155,16.0383857 17.4446387,16.0432083 C17.345843,16.5865846 16.8252597,16.9469884 16.2818833,16.8481927 L4.91303792,14.7811299 C4.53842737,14.7130189 4.23500006,14.4380834 4.13039941,14.0719812 L2.30560137,7.68518803 C2.28007524,7.59584656 2.26712532,7.50338343 2.26712532,7.4104669 C2.26712532,6.85818215 2.71484057,6.4104669 3.26712532,6.4104669 L16.9929851,6.4104669 L17.606173,3.78251876 C17.7307772,3.24850086 18.2068633,2.87071314 18.7552257,2.87071314 L20.8200821,2.87071314 C21.4717328,2.87071314 22,3.39898039 22,4.05063106 C22,4.70228173 21.4717328,5.23054898 20.8200821,5.23054898 L19.6915238,5.23054898 L18.1446364,11.84388 Z' fill='currentColor' opacity='0.3'/>
                                                <path d='M6.5,21 C5.67157288,21 5,20.3284271 5,19.5 C5,18.6715729 5.67157288,18 6.5,18 C7.32842712,18 8,18.6715729 8,19.5 C8,20.3284271 7.32842712,21 6.5,21 Z M15.5,21 C14.6715729,21 14,20.3284271 14,19.5 C14,18.6715729 14.6715729,18 15.5,18 C16.3284271,18 17,18.6715729 17,19.5 C17,20.3284271 16.3284271,21 15.5,21 Z' fill='currentColor'/>
                                            </g>
                                        </svg>
                                        Ordered</span></div>`;
                        } else if (params.value == "Delivered") {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-success border border-success fs-base'>
                                        <span class='svg-icon svg-icon-primary svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M20.4061385,6.73606154 C20.7672665,6.89656288 21,7.25468437 21,7.64987309 L21,16.4115967 C21,16.7747638 20.8031081,17.1093844 20.4856429,17.2857539 L12.4856429,21.7301984 C12.1836204,21.8979887 11.8163796,21.8979887 11.5143571,21.7301984 L3.51435707,17.2857539 C3.19689188,17.1093844 3,16.7747638 3,16.4115967 L3,7.64987309 C3,7.25468437 3.23273352,6.89656288 3.59386153,6.73606154 L11.5938615,3.18050598 C11.8524269,3.06558805 12.1475731,3.06558805 12.4061385,3.18050598 L20.4061385,6.73606154 Z' fill='currentColor' opacity='0.3'/>
                                                <polygon fill='currentColor' points='14.9671522 4.22441676 7.5999999 8.31727912 7.5999999 12.9056825 9.5999999 13.9056825 9.5999999 9.49408582 17.25507 5.24126912'/>
                                            </g>
                                        </svg>
                                        Delivered</span></div>`;
                        } else {
                            span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info2 border border-info2 fs-base'>
                                        <span class='svg-icon svg-icon-info2 svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M10.9630156,7.5 L11.0475062,7.5 C11.3043819,7.5 11.5194647,7.69464724 11.5450248,7.95024814 L12,12.5 L15.2480695,14.3560397 C15.403857,14.4450611 15.5,14.6107328 15.5,14.7901613 L15.5,15 C15.5,15.2109164 15.3290185,15.3818979 15.1181021,15.3818979 C15.0841582,15.3818979 15.0503659,15.3773725 15.0176181,15.3684413 L10.3986612,14.1087258 C10.1672824,14.0456225 10.0132986,13.8271186 10.0316926,13.5879956 L10.4644883,7.96165175 C10.4845267,7.70115317 10.7017474,7.5 10.9630156,7.5 Z' fill='currentColor'/>
                                                <path d='M7.38979581,2.8349582 C8.65216735,2.29743306 10.0413491,2 11.5,2 C17.2989899,2 22,6.70101013 22,12.5 C22,18.2989899 17.2989899,23 11.5,23 C5.70101013,23 1,18.2989899 1,12.5 C1,11.5151324 1.13559454,10.5619345 1.38913364,9.65805651 L3.31481075,10.1982117 C3.10672013,10.940064 3,11.7119264 3,12.5 C3,17.1944204 6.80557963,21 11.5,21 C16.1944204,21 20,17.1944204 20,12.5 C20,7.80557963 16.1944204,4 11.5,4 C10.54876,4 9.62236069,4.15592757 8.74872191,4.45446326 L9.93948308,5.87355717 C10.0088058,5.95617272 10.0495583,6.05898805 10.05566,6.16666224 C10.0712834,6.4423623 9.86044965,6.67852665 9.5847496,6.69415008 L4.71777931,6.96995273 C4.66931162,6.97269931 4.62070229,6.96837279 4.57348157,6.95710938 C4.30487471,6.89303938 4.13906482,6.62335149 4.20313482,6.35474463 L5.33163823,1.62361064 C5.35654118,1.51920756 5.41437908,1.4255891 5.49660017,1.35659741 C5.7081375,1.17909652 6.0235153,1.2066885 6.2010162,1.41822583 L7.38979581,2.8349582 Z' fill='currentColor' opacity='0.3'/>
                                            </g>
                                        </svg>
                                        ${params.value}</span></div>`;
                        };
                    };

                    if (params.data?.Commodity === 'Total Item') {
                        return params.value.toLocaleString('en-US');
                    };
                    return span;
                },
                valueFormatter: params => {
                    if (params.data?.RefNo === 'Total') {
                        return null;
                    };
                },
                onCellClicked: function (params) {
                    //redirect
                    window.open("SCM060100-DTL-" + params.data.Code, '_blank').focus();
                }
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                pinned: "right",
                width: 200,
            },
            {
                headerName: "Current Balance",
                field: "CurrBal",
                width: 150,
                cellClass: "text-end",
                pinned: "right",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                }
            },
            {
                headerName: "Projected Balance",
                field: "NewBal",
                width: 150,
                cellClass: "text-end",
                pinned: "right",
                cellRenderer: params => {
                    var Qty = "";
                    var val = Number(params.value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    if (params.value == null || params.value === "") return "";
                        Qty = `<span class="text-primary fs-6 fw-bolder">+${val}</span>`;
                    return Qty;
                }
            },
        ],
        rowData: [],
        pagination: false,
    };
    grid05Api = agGrid.createGrid(gridDiv, gridOptions);
    function updFooter() {
        let Total = 0;

        grid05Api.forEachNodeAfterFilter(function (node) {
            Total += Number(node.data.NewBal) || 0;
        });

        grid05Api.setGridOption('pinnedBottomRowData', [
            { RefNo: 'Total', NewBal: Total }
        ]);
    }
};
function fn06Table() {
    //Dropdown
    fn06Warehouse('');
    fn06Category('');
    //Dropdown

    //AG Grid
    let gridDiv = document.querySelector('#table06Record');
    let gridOptions;

    // Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        enableCellTextSelection: true,
        suppressDragLeaveHidesColumns: true,
        rowSelection: 'single',
        loading: false,
        rowBuffer: 5,
        suppressColumnVirtualisation: false,
        debounceVerticalScrollbar: true,
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'Percent', pinned: 'right' },
                        { colId: 'ExpPriority', pinned: 'right' }
                    ]
                });
            }
        },
        columnDefs: [
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Scope of Work",
                field: "Scope",
                filter: 'agTextColumnFilter',
                tooltipField: "Scope",
                width: 200,
            },
            {
                headerName: "Est. Qty",
                field: "EstQty",
                width: 150,
                tooltipField: "EstQty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Bal. Qty",
                field: "BalQty",
                width: 150,
                tooltipField: "BalQty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Remaining",
                field: "Remaining",
                width: 150,
                tooltipField: "Remaining",
                cellClass: "text-end",
                cellRenderer: params => {
                    const value = params.data.Percent || 0;
                    var val = Number(params.value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    var Qty = "";

                    if (params.data.Percent.toFixed(2) > 50) {
                        Qty = `<span class="text-success fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) <= 10) {
                        Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) < 20) {
                        Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) < 40) {
                        Qty = `<span class="text-warning fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) <= 50) {
                        Qty = `<span class="text-info fs-6 fw-bolder">${val}</span>`;
                    }

                    return Qty;
                }
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                width: 250,
            },
            {
                headerName: "Percentage",
                field: "Percent",
                tooltipField: "Percent" + "%",
                width: 180,
                pinned: "right",
                cellRenderer: params => {
                    const value = params.value || 0;

                    if (value.toFixed(2) > 50) {
                        colorClass = "bg-success";
                    } else if (value.toFixed(2) <= 10) {
                        colorClass = "bg-danger";
                    } else if (value.toFixed(2) < 20) {
                        colorClass = "bg-danger";
                    } else if (value.toFixed(2) < 40) {
                        colorClass = "bg-warning";
                    } else if (value.toFixed(2) <= 50) {
                        colorClass = "bg-info";
                    }

                    const div = document.createElement("div");
                    div.className = "d-flex flex-column w-100";

                    div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                    // Animate after render
                    setTimeout(() => {
                        const bar = div.querySelector(".progress-bar");
                        bar.style.width = value + "%";
                    }, 50);

                    return div;
                }
            },
            {
                headerName: "Exp. Priority",
                colId: "ExpPriority",
                width: 180,
                pinned: "right",
                cellRenderer: params => {
                    var span = "";
                    if (params.data.Percent.toFixed(2) > 50) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-secondary border border-secondary text-gray-600 fs-base'>Low</span></div>`;
                    } else if (params.data.Percent.toFixed(2) <= 10) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>Critical</span></div>`;
                    } else if (params.data.Percent.toFixed(2) < 20) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>High</span></div>`;
                    } else if (params.data.Percent.toFixed(2) < 40) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-warning border border-warning fs-base'>Urgent</span></div>`;
                    } else if (params.data.Percent.toFixed(2) <= 50) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>Medium</span></div>`;
                    }
                    return span;
                },
            },
        ],
        rowData: [],
        pagination: false
    };
    grid06Api = agGrid.createGrid(gridDiv, gridOptions);

    function fn06Category(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_BOQCategory',
                'pPlaceHolder': 'Category',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl06Category").html(s);
                $('#ddl06Category').val(ID).trigger('change');
            },
        });
    };
    function fn06Warehouse(ID) {
        $.ajax({
            type: "POST",
            url: "HNDSCM.ashx",
            data: {
                'FormCode': 'SCM070100',
                'Type': 'Get Record',
                'pTblName': 'Mstr_Warehouse',
                'pPlaceHolder': 'Warehouse',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl06Warehouse").html(s);
                $('#ddl06Warehouse').val(ID).trigger('change');
            },
        });
    };
};
function fn07Table() {

    //Dropdown
    fn07Warehouse('');
    fn07Category('');
    //Dropdown

    //AG Grid
    let gridDiv = document.querySelector('#table07Record');
    let gridOptions;

    // Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        theme: gridTheme,
        suppressCellFocus: true,
        enableCellTextSelection: true,
        suppressDragLeaveHidesColumns: true,
        rowSelection: 'single',
        loading: false,
        rowBuffer: 5,
        suppressColumnVirtualisation: false,
        debounceVerticalScrollbar: true,
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'Reference', pinned: 'left' },
                        { colId: 'Percent', pinned: 'right' },
                        { colId: 'ExpPriority', pinned: 'right' }
                    ]
                });
            }
        },
        columnDefs: [
            {
                headerName: "PR. No.",
                field: "Reference",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "Reference",
                cellStyle: { fontWeight: 'bold' },
                onCellClicked: function (params) {
                    //redirect
                    window.open("FRM000010-DTL-" + params.value, '_blank').focus();
                }
            },
            {
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 180,
                pinned: "right",
                cellRenderer: params => {
                    var span = "";
                    if (params.value != "") {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info2 border border-info2 fs-base'>
                                        <span class='svg-icon svg-icon-info2 svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M10.9630156,7.5 L11.0475062,7.5 C11.3043819,7.5 11.5194647,7.69464724 11.5450248,7.95024814 L12,12.5 L15.2480695,14.3560397 C15.403857,14.4450611 15.5,14.6107328 15.5,14.7901613 L15.5,15 C15.5,15.2109164 15.3290185,15.3818979 15.1181021,15.3818979 C15.0841582,15.3818979 15.0503659,15.3773725 15.0176181,15.3684413 L10.3986612,14.1087258 C10.1672824,14.0456225 10.0132986,13.8271186 10.0316926,13.5879956 L10.4644883,7.96165175 C10.4845267,7.70115317 10.7017474,7.5 10.9630156,7.5 Z' fill='currentColor'/>
                                                <path d='M7.38979581,2.8349582 C8.65216735,2.29743306 10.0413491,2 11.5,2 C17.2989899,2 22,6.70101013 22,12.5 C22,18.2989899 17.2989899,23 11.5,23 C5.70101013,23 1,18.2989899 1,12.5 C1,11.5151324 1.13559454,10.5619345 1.38913364,9.65805651 L3.31481075,10.1982117 C3.10672013,10.940064 3,11.7119264 3,12.5 C3,17.1944204 6.80557963,21 11.5,21 C16.1944204,21 20,17.1944204 20,12.5 C20,7.80557963 16.1944204,4 11.5,4 C10.54876,4 9.62236069,4.15592757 8.74872191,4.45446326 L9.93948308,5.87355717 C10.0088058,5.95617272 10.0495583,6.05898805 10.05566,6.16666224 C10.0712834,6.4423623 9.86044965,6.67852665 9.5847496,6.69415008 L4.71777931,6.96995273 C4.66931162,6.97269931 4.62070229,6.96837279 4.57348157,6.95710938 C4.30487471,6.89303938 4.13906482,6.62335149 4.20313482,6.35474463 L5.33163823,1.62361064 C5.35654118,1.51920756 5.41437908,1.4255891 5.49660017,1.35659741 C5.7081375,1.17909652 6.0235153,1.2066885 6.2010162,1.41822583 L7.38979581,2.8349582 Z' fill='currentColor' opacity='0.3'/>
                                            </g>
                                        </svg>
                                        ${params.value}</span></div>`;
                    };
                    return span;
                }
            },
            {
                headerName: "PR. Qty",
                field: "PRQty",
                width: 150,
                tooltipField: "PRQty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Bal. Qty",
                field: "BalQty",
                width: 150,
                tooltipField: "BalQty",
                cellClass: "text-end",
                valueFormatter: params => {
                    if (params.value == null || params.value === "") return "";
                    return Number(params.value).toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Remaining",
                field: "Remaining",
                width: 150,
                tooltipField: "Remaining",
                cellClass: "text-end",
                cellRenderer: params => {
                    const value = params.data.Percent || 0;
                    var val = Number(params.value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    var Qty = "";

                    if (params.data.Percent.toFixed(2) > 50) {
                        Qty = `<span class="text-success fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) <= 10) {
                        Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) < 20) {
                        Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) < 40) {
                        Qty = `<span class="text-warning fs-6 fw-bolder">${val}</span>`;
                    } else if (params.data.Percent.toFixed(2) <= 50) {
                        Qty = `<span class="text-info fs-6 fw-bolder">${val}</span>`;
                    }

                    return Qty;
                }
            },
            {
                headerName: "Warehouse",
                field: "Warehouse",
                filter: 'agTextColumnFilter',
                tooltipField: "Warehouse",
                width: 250,
            },
            {
                headerName: "Percentage",
                field: "Percent",
                tooltipField: "Percent" + "%",
                width: 180,
                cellRenderer: params => {
                    const value = params.value || 0;

                    if (value.toFixed(2) > 50) {
                        colorClass = "bg-success";
                    } else if (value.toFixed(2) <= 10) {
                        colorClass = "bg-danger";
                    } else if (value.toFixed(2) < 20) {
                        colorClass = "bg-danger";
                    } else if (value.toFixed(2) < 40) {
                        colorClass = "bg-warning";
                    } else if (value.toFixed(2) <= 50) {
                        colorClass = "bg-info";
                    }

                    const div = document.createElement("div");
                    div.className = "d-flex flex-column w-100";

                    div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                    // Animate after render
                    setTimeout(() => {
                        const bar = div.querySelector(".progress-bar");
                        bar.style.width = value + "%";
                    }, 50);

                    return div;
                }
            },
            {
                headerName: "Exp. Priority",
                colId: "ExpPriority",
                width: 180,
                pinned: "right",
                cellRenderer: params => {
                    var span = "";
                    if (params.data.Percent.toFixed(2) > 50) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-secondary border border-secondary text-gray-600 fs-base'>Low</span></div>`;
                    } else if (params.data.Percent.toFixed(2) <= 10) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>Critical</span></div>`;
                    } else if (params.data.Percent.toFixed(2) < 20) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>High</span></div>`;
                    } else if (params.data.Percent.toFixed(2) < 40) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-warning border border-warning fs-base'>Urgent</span></div>`;
                    } else if (params.data.Percent.toFixed(2) <= 50) {
                        span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>Medium</span></div>`;
                    }
                    return span;
                },
            },
        ],
        rowData: [],
        pagination: false
    };
    grid07Api = agGrid.createGrid(gridDiv, gridOptions);

    function fn07Category(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_BOQCategory',
                'pPlaceHolder': 'Category',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl07Category").html(s);
                $('#ddl07Category').val(ID).trigger('change');
            },
        });
    };
    function fn07Warehouse(ID) {
        $.ajax({
            type: "POST",
            url: "HNDSCM.ashx",
            data: {
                'FormCode': 'SCM070100',
                'Type': 'Get Record',
                'pTblName': 'Mstr_Warehouse',
                'pPlaceHolder': 'Warehouse',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl07Warehouse").html(s);
                $('#ddl07Warehouse').val(ID).trigger('change');
            },
        });
    };
};
//function - Table

//filter
function fn0001Filter() {
    $('#mdl0001Filter').modal('show');
};
function fn0001Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        const dateFrom = new Date(document.getElementById("tbx0001DateFrom").value);
        const dateTo = new Date(document.getElementById("tbx0001DateTo").value);
        // validate
        if (dateFrom > dateTo) {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx0001DateFrom").value == "" || document.getElementById("tbx0001DateTo").value == "") {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            // process
            return new Promise(resolve => {
                //loader
                fn00Loader("#kt_bar_graph_005");
                //Ajax
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/DSB/DSB240000HND.ashx",
                    data: {
                        'pFormCode': 'DSB240000',
                        'pType': 'Get-Stage-Filter',
                        'pDateFrom': document.getElementById("tbx0001DateFrom").value,
                        'pDateTo': document.getElementById("tbx0001DateTo").value
                    },
                    success: function (response) {

                        // Class definition
                        var SIChart05 = function () {

                            // Private methods
                            var initSIChart05 = function (chartSelector) {
                                var element = document.querySelector(chartSelector);

                                //clear
                                element.innerHTML = "";
                                //clear

                                if (!element) {
                                    return;
                                }

                                var options = {
                                    series: [{
                                        name: "Record",
                                        data: [{
                                            x: 'Purchase Request',
                                            y: parseInt(response[0].PR)
                                        }, {
                                            x: 'Purchase Order',
                                            y: parseInt(response[0].PO)
                                        }, {
                                            x: 'Receiving',
                                            y: parseInt(response[0].IR)
                                        }, {
                                            x: 'Stock Issuance',
                                            y: parseInt(response[0].SI)
                                        }]
                                    }],
                                    chart: {
                                        type: 'bar',
                                        height: 380
                                    },
                                    xaxis: {
                                        type: 'category',
                                        labels: {
                                            formatter: function (val) {
                                                return val;
                                            }
                                        }
                                    },
                                    tooltip: {
                                        x: {
                                            formatter: function (val) {
                                                return val;
                                            }
                                        }
                                    },
                                };

                                var chart = new ApexCharts(element, options);
                                chart.render();

                            }

                            // Public methods
                            return {
                                init: function () {
                                    initSIChart05('#kt_bar_graph_005');
                                }
                            }
                        }();

                        // Webpack support
                        if (typeof module !== 'undefined') {
                            module.exports = SIChart05;
                        }

                        // On document ready
                        KTUtil.onDOMContentLoaded(function () {
                            SIChart05.init();
                        });

                        //alert
                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                        document.getElementById("tbx0001DateFrom").value = "";
                        document.getElementById("tbx0001DateTo").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //resolve
                        resolve();
                    }
                });

            });
        };
    };
};
function fn01Filter() {
    $('#mdl01Filter').modal('show');
};
function fn01Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        const dateFrom = new Date(document.getElementById("tbx01DateFrom").value);
        const dateTo = new Date(document.getElementById("tbx01DateTo").value);
        // validate
        if (dateFrom > dateTo) {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx01DateFrom").value == "" || document.getElementById("tbx01DateTo").value == "") {
            // Alert
            fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            // process
            return new Promise(resolve => {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/DSB/DSB240000HND.ashx",
                    data: {
                        'pFormCode': 'DSB240000',
                        'pType': 'Get-Moving-PO-Filter',
                        'pDateFrom': document.getElementById("tbx01DateFrom").value,
                        'pDateTo': document.getElementById("tbx01DateTo").value
                    },
                    success: function (response) {
                        grid01Api.setGridOption('rowData', response);
                    },
                    complete: function (response) {
                        grid01Api.setGridOption('loading', false);

                        //alert
                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                        document.getElementById("tbx01DateFrom").value = "";
                        document.getElementById("tbx01DateTo").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //resolve
                        resolve();
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
                                    { colId: 'PRNo', pinned: 'left' },
                                    { colId: 'PONo', pinned: 'left' }
                                ]
                            });
                        }
                    },
                    onRowClicked: params => {
                        fn0102Table(params.data.PRNo);
                    },
                    theme: gridTheme,
                    suppressCellFocus: true,
                    suppressDragLeaveHidesColumns: true,
                    enableCellTextSelection: true,
                    rowSelection: 'single',
                    loading: true,
                    columnDefs: [

                        {
                            headerName: "P.R. No.",
                            field: "PRNo",
                            lockPosition: true,
                            pinned: "left",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "PRNo",
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "P.O. No.",
                            field: "PONo",
                            lockPosition: true,
                            pinned: "left",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "PONo",
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "Form Status",
                            field: "FormStatus",
                            filter: 'agTextColumnFilter',
                            tooltipField: "FormStatus",
                            width: 180
                        },
                        {
                            headerName: "Item",
                            field: "ItemName",
                            filter: 'agTextColumnFilter',
                            tooltipField: "ItemName",
                            flex: 1,
                            minWidth: 350,
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "Unit",
                            field: "Unit",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Unit",
                            width: 100
                        },
                        {
                            headerName: "P.R. Qty",
                            field: "PRQty",
                            tooltipField: "PRQty",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.PRQty) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            headerName: "P.O. Qty",
                            field: "POQty",
                            tooltipField: "POQty",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.IssuedQty) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            field: "Balance",
                            tooltipField: "Balance",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.Balance) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            headerName: "Status",
                            field: "Percentage",
                            tooltipField: "Percentage" + "%",
                            width: 180,
                            cellRenderer: params => {
                                const value = params.value || 0;

                                let colorClass = "bg-danger";
                                if (value.toFixed(2) > 95) {
                                    colorClass = "bg-success";
                                } else {
                                    colorClass = "bg-warning";
                                }

                                const div = document.createElement("div");
                                div.className = "d-flex flex-column w-100";

                                div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                                // Animate after render
                                setTimeout(() => {
                                    const bar = div.querySelector(".progress-bar");
                                    bar.style.width = value + "%";
                                }, 50);

                                return div;
                            }
                        },
                        {
                            headerName: "Overall Status",
                            field: "Overall",
                            tooltipField: "Overall" + "%",
                            width: 180,
                            cellRenderer: params => {
                                const value = params.value || 0;

                                let colorClass = "bg-danger";
                                if (value.toFixed(2) >= 95) {
                                    colorClass = "bg-success";
                                } else {
                                    colorClass = "bg-warning";
                                }

                                const div = document.createElement("div");
                                div.className = "d-flex flex-column w-100";

                                div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                                // Animate after render
                                setTimeout(() => {
                                    const bar = div.querySelector(".progress-bar");
                                    bar.style.width = value + "%";
                                }, 50);

                                return div;
                            }
                        },
                        {
                            headerName: "Requestor",
                            field: "Requestor",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Requestor",
                            width: 150
                        },
                        {
                            headerName: "Purchaser",
                            field: "Purchaser",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Purchaser",
                            width: 150
                        },
                        {
                            headerName: "Warehouse",
                            field: "Warehouse",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Warehouse",
                            width: 200
                        },
                        {
                            headerName: "Category",
                            field: "Category",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Category",
                            width: 180
                        },
                        {
                            headerName: "P.R. Remarks",
                            field: "PRRemarks",
                            filter: 'agTextColumnFilter',
                            tooltipField: "PRRemarks",
                            width: 250
                        },
                        {
                            headerName: "Created Date",
                            field: "PRDate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "PRDate"
                        },
                        {
                            headerName: "Date Approval",
                            field: "ApprDate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "ApprDate"
                        },
                    ],
                    rowData: [],
                    pagination: false,
                };
                grid01Api = agGrid.createGrid(gridDiv, gridOptions);

            });
        };
    };
};
function fn02Filter() {
    $('#mdl02Filter').modal('show');
};
function fn02Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        const dateFrom = new Date(document.getElementById("tbx02DateFrom").value);
        const dateTo = new Date(document.getElementById("tbx02DateTo").value);
        // validate
        if (dateFrom > dateTo) {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx02DateFrom").value == "" || document.getElementById("tbx02DateTo").value == "") { 
            // Alert
            fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            // process
            return new Promise(resolve => {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/DSB/DSB240000HND.ashx",
                    data: {
                        'pFormCode': 'DSB240000',
                        'pType': 'Get-Moving-SR-Filter',
                        'pDateFrom': document.getElementById("tbx02DateFrom").value,
                        'pDateTo': document.getElementById("tbx02DateTo").value
                    },
                    success: function (response) {
                        grid02Api.setGridOption('rowData', response);
                    },
                    complete: function (response) {
                        grid02Api.setGridOption('loading', false);

                        //alert
                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                        document.getElementById("tbx02DateFrom").value = "";
                        document.getElementById("tbx02DateTo").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //resolve
                        resolve();
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
                                    { colId: 'PRNo', pinned: 'left' },
                                    { colId: 'SINo', pinned: 'left' }
                                ]
                            });
                        }
                    },
                    onRowClicked: params => {
                        fn0202Table(params.data.PRNo);
                    },
                    theme: gridTheme,
                    suppressCellFocus: true,
                    suppressDragLeaveHidesColumns: true,
                    enableCellTextSelection: true,
                    rowSelection: 'single',
                    loading: true,
                    columnDefs: [

                        {
                            headerName: "PR. No.",
                            field: "PRNo",
                            lockPosition: true,
                            pinned: "left",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "PRNo",
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "SI. No.",
                            field: "SINo",
                            lockPosition: true,
                            pinned: "left",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "SINo",
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "Form Status",
                            field: "FormStatus",
                            filter: 'agTextColumnFilter',
                            tooltipField: "FormStatus",
                            width: 180
                        },
                        {
                            headerName: "Item",
                            field: "ItemName",
                            filter: 'agTextColumnFilter',
                            tooltipField: "ItemName",
                            flex: 1,
                            minWidth: 350,
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "Unit",
                            field: "Unit",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Unit",
                            width: 100
                        },
                        {
                            headerName: "P.R. Qty",
                            field: "PRQty",
                            tooltipField: "PRQty",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.PRQty) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            headerName: "S.I. Qty",
                            field: "SIQty",
                            tooltipField: "SIQty",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.IssuedQty) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            field: "Balance",
                            tooltipField: "Balance",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.Balance) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            headerName: "Status",
                            headerClass: "text-center",
                            cellClass: "text-end",
                            children: [
                                {
                                    headerName: "Status",
                                    field: "Status",
                                    filter: 'agTextColumnFilter',
                                    tooltipField: "Status",
                                    width: 150,
                                    cellRenderer: params => {
                                        var span = "";
                                        if (params.data.Status == "Delivered") {
                                            span = `<span class="d-flex justify-content-center badge badge-success mt-3"><i class="las la-clock fs-7 mr-5 text-white"></i>${params.value}</span>`;
                                        } else if (params.data.Status == "On-Going") {
                                            span = `<span class="d-flex justify-content-center mt-2 badge badge-for-closed"><i class="las la-bookmark fs-7 mr-5 text-white"></i>${params.value}</span>`;
                                        } else if (params.data.Status == "Partial") {
                                            span = `<span class="d-flex justify-content-center badge badge-warning mt-3"><i class="las la-exclamation-circle fs-7 mr-5 text-white"></i>Partial</span>`;
                                        } else {
                                            span = `<span class="d-flex justify-content-center mt-2 badge badge-for-closed"><i class="las la-bookmark fs-7 mr-5 text-white"></i>${params.value}</span>`;
                                        };
                                        return span;
                                    }
                                },
                                {
                                    field: "Percentage",
                                    tooltipField: "Percentage" + "%",
                                    width: 180,
                                    cellRenderer: params => {
                                        const value = params.value || 0;

                                        let colorClass = "bg-danger";
                                        if (value.toFixed(2) > 95) {
                                            colorClass = "bg-success";
                                        } else {
                                            colorClass = "bg-warning";
                                        }

                                        const div = document.createElement("div");
                                        div.className = "d-flex flex-column w-100";

                                        div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                                        // Animate after render
                                        setTimeout(() => {
                                            const bar = div.querySelector(".progress-bar");
                                            bar.style.width = value + "%";
                                        }, 50);

                                        return div;
                                    }
                                },
                            ]
                        },
                        {
                            headerName: "Overall Status",
                            field: "Overall",
                            tooltipField: "Overall" + "%",
                            width: 180,
                            cellRenderer: params => {
                                const value = params.value || 0;

                                let colorClass = "bg-danger";
                                if (value.toFixed(2) >= 95) {
                                    colorClass = "bg-success";
                                } else {
                                    colorClass = "bg-warning";
                                }

                                const div = document.createElement("div");
                                div.className = "d-flex flex-column w-100";

                                div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                                // Animate after render
                                setTimeout(() => {
                                    const bar = div.querySelector(".progress-bar");
                                    bar.style.width = value + "%";
                                }, 50);

                                return div;
                            }
                        },
                        {
                            headerName: "Requestor",
                            field: "Requestor",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Requestor",
                            width: 150
                        },
                        {
                            headerName: "Issued By",
                            field: "IssuedBy",
                            filter: 'agTextColumnFilter',
                            tooltipField: "IssuedBy",
                            width: 150
                        },
                        {
                            headerName: "Warehouse",
                            field: "Warehouse",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Warehouse",
                            width: 200
                        },
                        {
                            headerName: "Category",
                            field: "Category",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Category",
                            width: 180
                        },
                        {
                            headerName: "P.R. Remarks",
                            field: "PRRemarks",
                            filter: 'agTextColumnFilter',
                            tooltipField: "PRRemarks",
                            width: 250
                        },
                        {
                            headerName: "Created Date",
                            field: "PRDate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "PRDate"
                        },
                        {
                            headerName: "Date Approval",
                            field: "ApprDate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "ApprDate"
                        },
                    ],
                    rowData: [],
                    pagination: false,
                };
                grid02Api = agGrid.createGrid(gridDiv, gridOptions);

            });
        };
    };
};
function fn03Filter() {
    $('#mdl03Filter').modal('show');
};
function fn0301Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        const dateFrom = new Date(document.getElementById("tbx03DateFrom").value);
        const dateTo = new Date(document.getElementById("tbx03DateTo").value);
        // validate
        if (dateFrom > dateTo) {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx03DateFrom").value == "" || document.getElementById("tbx03DateTo").value == "") {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            // process
            return new Promise(resolve => {
                //Ajax
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/DSB/DSB240000HND.ashx",
                    data: {
                        'pFormCode': 'DSB240000',
                        'pType': 'Get-Moving-Filter',
                        'pDateFrom': document.getElementById("tbx03DateFrom").value,
                        'pDateTo': document.getElementById("tbx03DateTo").value
                    },
                    success: function (response) {
                        grid03Api.setGridOption("rowData", response);
                        //alert
                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                        document.getElementById("tbx03DateFrom").value = "";
                        document.getElementById("tbx03DateTo").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //resolve
                        resolve();
                    },
                    complete: function (response) {
                        grid03Api.setGridOption("loading", false);
                    }
                });

                //AG Grid
                let gridDiv = document.querySelector('#table03Record');
                let gridOptions;

                //Destroy old grid if exists
                gridDiv.innerHTML = "";

                const gridTheme = agGrid.themeQuartz.withParams({
                    wrapperBorder: true,
                    headerRowBorder: false,
                });

                gridOptions = {
                    onRowClicked: params => {
                        fn0301Table(params.data.Reference);
                    },
                    onGridSizeChanged: function (params) {
                        const isMobile = params.clientWidth < 768;

                        if (isMobile) {
                            params.api.applyColumnState({
                                defaultState: { pinned: null }
                            });
                        } else {
                            params.api.applyColumnState({
                                state: [
                                    { colId: 'Reference', pinned: 'left' },
                                    { colId: 'POPercent', pinned: 'right' }
                                ]
                            });
                        }
                    },
                    theme: gridTheme,
                    suppressCellFocus: true,
                    suppressDragLeaveHidesColumns: true,
                    enableCellTextSelection: true,
                    rowSelection: 'single',
                    loading: true,
                    columnDefs: [
                        {
                            headerName: "PR. No.",
                            field: "Reference",
                            lockPosition: true,
                            pinned: "left",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "Reference",
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "P.R. Status",
                            field: "Status",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "Status"
                        },
                        {
                            headerName: "Item",
                            field: "ItemName",
                            filter: 'agTextColumnFilter',
                            tooltipField: "ItemName",
                            flex: 1,
                            minWidth: 350,
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "For P.O.",
                            field: "ForPO",
                            tooltipField: "ForPO",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.IssuedQty) || 0;
                                }
                                return value.toLocaleString("en-US", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            },
                        },
                        {
                            headerName: "Unit",
                            field: "Unit",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Unit",
                            width: 100
                        },
                        {
                            headerName: "PRDate",
                            field: "PRDate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "PRDate"
                        },
                        {
                            headerName: "Purchase Type",
                            field: "PurchaseType",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "PurchaseType"
                        },
                        {
                            headerName: "Remarks",
                            field: "Remarks",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Remarks",
                            flex: 1,
                            minWidth: 350
                        },
                        {
                            headerName: "Requestor",
                            field: "Requestor",
                            filter: 'agTextColumnFilter',
                            width: 180,
                            tooltipField: "Requestor"
                        },
                        {
                            headerName: "Purchaser",
                            field: "Purchaser",
                            filter: 'agTextColumnFilter',
                            width: 180,
                            tooltipField: "Purchaser"
                        },
                        {
                            headerName: "P.O. Percentage",
                            field: "POPercent",
                            tooltipField: "POPercent" + "%",
                            width: 180,
                            pinned: "right",
                            cellRenderer: params => {
                                const value = params.value || 0;

                                let colorClass = "bg-danger";
                                if (value.toFixed(2) > 50) {
                                    colorClass = "bg-success";
                                } else if (params.data.Status === "Partial") {
                                    colorClass = "bg-warning";
                                }

                                const div = document.createElement("div");
                                div.className = "d-flex flex-column w-100";

                                div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                                // Animate after render
                                setTimeout(() => {
                                    const bar = div.querySelector(".progress-bar");
                                    bar.style.width = value + "%";
                                }, 50);

                                return div;
                            }
                        },
                    ],
                    rowData: [],
                    pagination: false
                };

                grid03Api = agGrid.createGrid(gridDiv, gridOptions);

            });
        };
    };
};
//warehouse dropdown
function ddl0301Warehouse(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB240000HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get Record',
            'pTblName': 'Get_Warehouse',
            'pPlaceHolder': 'Warehouse',
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0301Warehouse").html(s);
            $('#ddl0301Warehouse').val(ID).trigger('change');
        },
    });
};
function fn0301Filter() {
    ddl0301Warehouse('');
    document.getElementById("tbx0301Item").value = "";
    document.getElementById("hf0301ItemCode").value = "";
    document.getElementById("tbx0301Date").value = "";

    //modal
    $("#mdl0301Filter").modal("show");
};
//get item
function fn0301Item() {
    if (document.getElementById("ddl0301Warehouse").options[document.getElementById("ddl0301Warehouse").selectedIndex].value == "") {
        fnAlertOnly('Please select a warehouse!', 'error', 'btn btn-danger');
    } else {
        //item
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFormCode': 'DSB240000',
                'pType': 'Warehouse - Get Record : Item',
                'pWarehouse': document.getElementById("ddl0301Warehouse").options[document.getElementById("ddl0301Warehouse").selectedIndex].value
            },
            success: function (response) {
                grid0302Api.setGridOption("rowData", response);
            },
            complete: function (response) {
                grid0302Api.setGridOption("loading", false);
            }
        });

        //AG Grid
        let gridDiv = document.querySelector('#table0302Record');
        let gridOptions;

        //Destroy old grid if exists
        gridDiv.innerHTML = "";

        const gridTheme = agGrid.themeQuartz.withParams({
            wrapperBorder: true,
            headerRowBorder: false,
        });

        gridOptions = {
            theme: gridTheme,
            suppressCellFocus: true,
            suppressDragLeaveHidesColumns: true,
            enableCellTextSelection: true,
            rowSelection: 'single',
            loading: true,
            columnDefs: [
                {
                    headerName: "Action",
                    field: "Action",
                    sortable: false,
                    resizable: false,
                    lockPosition: true,
                    width: 75,
                    cellRenderer: params => params.value
                },
                {
                    headerName: "Lock",
                    field: "Lock",
                    sortable: false,
                    resizable: false,
                    lockPosition: true,
                    width: 65,
                    cellRenderer: params => params.value
                },
                {
                    headerName: "Item",
                    field: "ItemName",
                    filter: 'agTextColumnFilter',
                    tooltipField: "ItemName",
                    flex: 1,
                    minWidth: 350
                }
            ],
            rowData: [],
            pagination: false
        };

        grid0302Api = agGrid.createGrid(gridDiv, gridOptions);

        $("#mdl0302Item").modal("show");
    };
};
function fn0301GetItem(pItemName, pItemCode, pLock) {
    //validate
    if (pLock == 1) {
        Item(pItemName, pItemCode);
    } else {
        fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
    };
    function Item(pItemName, pItemCode) {
        document.getElementById("tbx0301Item").value = pItemName;
        document.getElementById("hf0301ItemCode").value = pItemCode;
        $("#mdl0302Item").modal("hide");
    };
};
function fn0302Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        // validate
        return new Promise(resolve => {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB240000HND.ashx",
                data: {
                    'pFormCode': 'DSB240000',
                    'pType': 'Warehouse - Get Record : Filter',
                    'pWarehouse': document.getElementById("ddl0301Warehouse").options[document.getElementById("ddl0301Warehouse").selectedIndex].value,
                    'pItemCode': document.getElementById("hf0301ItemCode").value,
                    'pDate': document.getElementById("tbx0301Date").value
                },
                success: function (response) {
                    grid03Api.setGridOption("rowData", response);
                    //alert
                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    ddl0301Warehouse('');
                    document.getElementById("tbx0301Item").value = "";
                    document.getElementById("hf0301ItemCode").value = "";
                    document.getElementById("tbx0301Date").value = "";
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                },
                complete: function (response) {
                    grid03Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table03Record');
            let gridOptions;

            //Destroy old grid if exists
            gridDiv.innerHTML = "";

            const gridTheme = agGrid.themeQuartz.withParams({
                wrapperBorder: true,
                headerRowBorder: false,
            });

            gridOptions = {
                theme: gridTheme,
                suppressCellFocus: true,
                suppressDragLeaveHidesColumns: true,
                enableCellTextSelection: true,
                rowSelection: 'single',
                loading: true,
                onFilterChanged: updFooter,
                onFirstDataRendered: updFooter,
                onGridSizeChanged: function (params) {
                    const isMobile = params.clientWidth < 768;

                    if (isMobile) {
                        params.api.applyColumnState({
                            defaultState: { pinned: null }
                        });
                    } else {
                        params.api.applyColumnState({
                            state: [
                                { colId: 'Warehouse', pinned: 'left' }
                            ]
                        });
                    }
                },
                //onRowClicked: params => {
                //    fn0301Table(params.data.WhseCode);
                //},
                columnDefs: [
                    {
                        headerName: "Warehouse",
                        field: "Warehouse",
                        lockPosition: true,
                        pinned: "left",
                        filter: 'agTextColumnFilter',
                        width: 250,
                        tooltipField: "Warehouse",
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Classification",
                        field: "ClassName",
                        filter: 'agTextColumnFilter',
                        width: 250,
                        tooltipField: "ClassName"
                    },
                    {
                        headerName: "Item",
                        field: "ItemName",
                        filter: 'agTextColumnFilter',
                        flex: 1,
                        minWidth: 350,
                        tooltipField: "ItemName"
                    },
                    {
                        headerName: "Qty. Stock",
                        field: "Qty",
                        width: 150,
                        tooltipField: "Qty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Unit",
                        field: "UMName",
                        filter: 'agTextColumnFilter',
                        width: 75,
                        tooltipField: "UMName"
                    },
                    {
                        headerName: "Cost",
                        field: "Cost",
                        width: 150,
                        tooltipField: "Cost",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Total",
                        field: "Total",
                        width: 150,
                        tooltipField: "Total",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    }
                ],
                rowData: [],
                pagination: false,
                getRowStyle: params => {
                    if (params.node.rowPinned) {
                        return { fontWeight: 'bold', background: '#f8f9fa' };
                    }
                }
            };

            grid03Api = agGrid.createGrid(gridDiv, gridOptions);
            function updFooter() {
                let Qty = 0;
                let Cost = 0;
                let Total = 0;

                grid03Api.forEachNodeAfterFilter(function (node) {
                    Total += Number(node.data.Total) || 0;
                    Qty += Number(node.data.Qty) || 0;
                    Cost += Number(node.data.Cost) || 0;
                });

                grid03Api.setGridOption('pinnedBottomRowData', [
                    { Warehouse: 'TOTAL', Qty: Qty, Cost: Cost, Total: Total }
                ]);
            }
        });
    };
};
//for - 04
function fn05Filter() {
    fn05Warehouse('');
    fn05Vendor('');
    $("#mdl05Filter").modal("show");
};
function fn05Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    Filter_Ok();
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        // process
        return new Promise(resolve => {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB240000HND.ashx",
                data: {
                    'pFormCode': 'DSB240000',
                    'pType': 'Get-Incoming-Filter',
                    'pWarehouse': document.getElementById("ddl05Warehouse").options[document.getElementById("ddl05Warehouse").selectedIndex].value,
                    'pVendor': document.getElementById("ddl05Vendor").options[document.getElementById("ddl05Vendor").selectedIndex].value
                },
                success: function (response) {
                    grid05Api.setGridOption("rowData", response);

                    $('#ddl05Warehouse').val('').trigger('change');
                    $('#ddl05Vendor').val('').trigger('change');
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                },
                complete: function (response) {
                    grid05Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table05Record');
            let gridOptions;

            // Destroy old grid if exists
            gridDiv.innerHTML = "";

            const gridTheme = agGrid.themeQuartz.withParams({
                wrapperBorder: true,
                headerRowBorder: false,
            });

            gridOptions = {
                theme: gridTheme,
                suppressCellFocus: true,
                suppressDragLeaveHidesColumns: true,
                enableCellTextSelection: true,
                rowSelection: 'single',
                loading: true,
                onGridSizeChanged: function (params) {
                    const isMobile = params.clientWidth < 768;

                    if (isMobile) {
                        params.api.applyColumnState({
                            defaultState: { pinned: null }
                        });
                    } else {
                        params.api.applyColumnState({
                            state: [
                                { colId: 'RefNo', pinned: 'left' },
                                { colId: 'Warehouse', pinned: 'right' },
                                { colId: 'CurrBal', pinned: 'right' },
                                { colId: 'NewBal', pinned: 'right' }
                            ]
                        });
                    }
                },
                columnDefs: [
                    {
                        headerName: "PR. No.",
                        field: "RefNo",
                        lockPosition: true,
                        pinned: "left",
                        filter: 'agTextColumnFilter',
                        width: 150,
                        tooltipField: "RefNo",
                        cellStyle: { fontWeight: 'bold' },
                        onCellClicked: function (params) {
                            //redirect
                            window.open("FRM000010-DTL-" + params.value, '_blank').focus();
                        }
                    },
                    {
                        headerName: "Item",
                        field: "ItemName",
                        filter: 'agTextColumnFilter',
                        tooltipField: "ItemName",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Qty",
                        field: "Qty",
                        width: 150,
                        tooltipField: "Qty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Date",
                        field: "Date",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "Date"
                    },
                    {
                        headerName: "Supplier/Vendor",
                        field: "Supplier",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Supplier",
                        width: 200,
                    },
                    {
                        headerName: "Status",
                        field: "Status",
                        filter: 'agTextColumnFilter',
                        width: 180,
                        cellRenderer: params => {
                            var span = "";
                            if (params.value != "") {
                                if (params.value == "Processed") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>
                                        <span class='svg-icon svg-icon-info svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M18.1446364,11.84388 L17.4471627,16.0287218 C17.4463569,16.0335568 17.4455155,16.0383857 17.4446387,16.0432083 C17.345843,16.5865846 16.8252597,16.9469884 16.2818833,16.8481927 L4.91303792,14.7811299 C4.53842737,14.7130189 4.23500006,14.4380834 4.13039941,14.0719812 L2.30560137,7.68518803 C2.28007524,7.59584656 2.26712532,7.50338343 2.26712532,7.4104669 C2.26712532,6.85818215 2.71484057,6.4104669 3.26712532,6.4104669 L16.9929851,6.4104669 L17.606173,3.78251876 C17.7307772,3.24850086 18.2068633,2.87071314 18.7552257,2.87071314 L20.8200821,2.87071314 C21.4717328,2.87071314 22,3.39898039 22,4.05063106 C22,4.70228173 21.4717328,5.23054898 20.8200821,5.23054898 L19.6915238,5.23054898 L18.1446364,11.84388 Z' fill='currentColor' opacity='0.3'/>
                                                <path d='M6.5,21 C5.67157288,21 5,20.3284271 5,19.5 C5,18.6715729 5.67157288,18 6.5,18 C7.32842712,18 8,18.6715729 8,19.5 C8,20.3284271 7.32842712,21 6.5,21 Z M15.5,21 C14.6715729,21 14,20.3284271 14,19.5 C14,18.6715729 14.6715729,18 15.5,18 C16.3284271,18 17,18.6715729 17,19.5 C17,20.3284271 16.3284271,21 15.5,21 Z' fill='currentColor'/>
                                            </g>
                                        </svg>
                                        Ordered</span></div>`;
                                } else if (params.value == "Delivered") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-success border border-success fs-base'>
                                        <span class='svg-icon svg-icon-primary svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M20.4061385,6.73606154 C20.7672665,6.89656288 21,7.25468437 21,7.64987309 L21,16.4115967 C21,16.7747638 20.8031081,17.1093844 20.4856429,17.2857539 L12.4856429,21.7301984 C12.1836204,21.8979887 11.8163796,21.8979887 11.5143571,21.7301984 L3.51435707,17.2857539 C3.19689188,17.1093844 3,16.7747638 3,16.4115967 L3,7.64987309 C3,7.25468437 3.23273352,6.89656288 3.59386153,6.73606154 L11.5938615,3.18050598 C11.8524269,3.06558805 12.1475731,3.06558805 12.4061385,3.18050598 L20.4061385,6.73606154 Z' fill='currentColor' opacity='0.3'/>
                                                <polygon fill='currentColor' points='14.9671522 4.22441676 7.5999999 8.31727912 7.5999999 12.9056825 9.5999999 13.9056825 9.5999999 9.49408582 17.25507 5.24126912'/>
                                            </g>
                                        </svg>
                                        Delivered</span></div>`;
                                } else {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info2 border border-info2 fs-base'>
                                        <span class='svg-icon svg-icon-info2 svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M10.9630156,7.5 L11.0475062,7.5 C11.3043819,7.5 11.5194647,7.69464724 11.5450248,7.95024814 L12,12.5 L15.2480695,14.3560397 C15.403857,14.4450611 15.5,14.6107328 15.5,14.7901613 L15.5,15 C15.5,15.2109164 15.3290185,15.3818979 15.1181021,15.3818979 C15.0841582,15.3818979 15.0503659,15.3773725 15.0176181,15.3684413 L10.3986612,14.1087258 C10.1672824,14.0456225 10.0132986,13.8271186 10.0316926,13.5879956 L10.4644883,7.96165175 C10.4845267,7.70115317 10.7017474,7.5 10.9630156,7.5 Z' fill='currentColor'/>
                                                <path d='M7.38979581,2.8349582 C8.65216735,2.29743306 10.0413491,2 11.5,2 C17.2989899,2 22,6.70101013 22,12.5 C22,18.2989899 17.2989899,23 11.5,23 C5.70101013,23 1,18.2989899 1,12.5 C1,11.5151324 1.13559454,10.5619345 1.38913364,9.65805651 L3.31481075,10.1982117 C3.10672013,10.940064 3,11.7119264 3,12.5 C3,17.1944204 6.80557963,21 11.5,21 C16.1944204,21 20,17.1944204 20,12.5 C20,7.80557963 16.1944204,4 11.5,4 C10.54876,4 9.62236069,4.15592757 8.74872191,4.45446326 L9.93948308,5.87355717 C10.0088058,5.95617272 10.0495583,6.05898805 10.05566,6.16666224 C10.0712834,6.4423623 9.86044965,6.67852665 9.5847496,6.69415008 L4.71777931,6.96995273 C4.66931162,6.97269931 4.62070229,6.96837279 4.57348157,6.95710938 C4.30487471,6.89303938 4.13906482,6.62335149 4.20313482,6.35474463 L5.33163823,1.62361064 C5.35654118,1.51920756 5.41437908,1.4255891 5.49660017,1.35659741 C5.7081375,1.17909652 6.0235153,1.2066885 6.2010162,1.41822583 L7.38979581,2.8349582 Z' fill='currentColor' opacity='0.3'/>
                                            </g>
                                        </svg>
                                        ${params.value}</span></div>`;
                                };
                            };
                            return span;
                        },
                        onCellClicked: function (params) {
                            //redirect
                            window.open("SCM060100-DTL-" + params.data.Code, '_blank').focus();
                        }
                    },
                    {
                        headerName: "Warehouse",
                        field: "Warehouse",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Warehouse",
                        width: 200,
                        pinned: "right",
                    },
                    {
                        headerName: "Current Balance",
                        field: "CurrBal",
                        width: 150,
                        cellClass: "text-end",
                        pinned: "right",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        }
                    },
                    {
                        headerName: "Projected Balance",
                        field: "NewBal",
                        width: 150,
                        cellClass: "text-end",
                        pinned: "right",
                        cellRenderer: params => {
                            var Qty = "";
                            var val = Number(params.value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            if (params.value == null || params.value === "") return "";
                            Qty = `<span class="text-primary fs-6 fw-bolder">+${val}</span>`;
                            return Qty;
                        }
                    },
                ],
                rowData: [],
                pagination: false,
            };
            grid05Api = agGrid.createGrid(gridDiv, gridOptions);

        });
    };
};
function fn05Warehouse(ID) {
    $.ajax({
        type: "POST",
        url: "HNDSCM.ashx",
        data: {
            'FormCode': 'SCM070100',
            'Type': 'Get Record',
            'pTblName': 'Mstr_Warehouse',
            'pPlaceHolder': 'Warehouse',
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl05Warehouse").html(s);
            $('#ddl05Warehouse').val(ID).trigger('change');
        },
    });
}
function fn05Vendor(ID) {
    $.ajax({
        type: "POST",
        url: "HNDSCM.ashx",
        data: {
            'FormCode': 'SCM070100',
            'Type': 'Get Record',
            'pTblName': 'Mstr_Vendor',
            'pPlaceHolder': 'Vendor',
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl05Vendor").html(s);
            $('#ddl05Vendor').val(ID).trigger('change');
        },
    });
};
function ddl06Category_onchange(ddl06Category) {
    document.getElementById("ddl06Estimate").disabled = true;
    document.getElementById("ddl06Project").disabled = true;
    $('#ddl06Project').val('').trigger('change');
    document.getElementById("div06Estimate").classList.remove("border-danger");
    if (ddl06Category.options[ddl06Category.selectedIndex].value != "" && (ddl06Category.options[ddl06Category.selectedIndex].value != "House Construction" && ddl06Category.options[ddl06Category.selectedIndex].value != "House Construction - CCI")) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record (ID)',
                'pTblName': 'Get_Estimate',
                'pTblCode': ddl06Category.options[ddl06Category.selectedIndex].value,
                'pPlaceHolder': 'Estimate'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl06Estimate").html(s);
                $('#ddl06Estimate').val('').trigger('change');

                //disable
                document.getElementById("ddl06Estimate").disabled = false;
                document.getElementById("div06Estimate").classList.add("border-danger");
                document.getElementById("ddl06Project").disabled = true;
            },
        });
    } else if (ddl06Category.options[ddl06Category.selectedIndex].value != "" && (ddl06Category.options[ddl06Category.selectedIndex].value == "House Construction" || ddl06Category.options[ddl06Category.selectedIndex].value == "House Construction - CCI")) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record (ID)',
                'pTblName': 'Get_Batch',
                'pTblCode': ddl06Category.options[ddl06Category.selectedIndex].value,
                'pPlaceHolder': 'Batch'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl06Estimate").html(s);
                $('#ddl06Estimate').val('').trigger('change');

                //disable
                document.getElementById("ddl06Estimate").disabled = false;
                document.getElementById("div06Estimate").classList.add("border-danger");
                document.getElementById("ddl06Project").disabled = false;
            },
        });
    };
};
function ddl06Estimate_onchange(ddl06Estimate) {
    document.getElementById("ddl06Project").disabled = true;
    document.getElementById("div06Project").classList.remove("border-danger");
    if (document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value == "House Construction" || document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value == "House Construction - CCI") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record (ID)',
                'pTblName': 'Get_Project',
                'pTblCode': document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value + ' - ' + ddl06Estimate.options[ddl06Estimate.selectedIndex].value,
                'pPlaceHolder': 'Project'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl06Project").html(s);
                $('#ddl06Project').val('').trigger('change');

                //disable
                document.getElementById("ddl06Project").disabled = false;
                document.getElementById("div06Project").classList.add("border-danger");
            },
        });
    }
};
function fn06Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    if (document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value == "") {
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else if (document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value != "" && document.getElementById("ddl06Estimate").options[document.getElementById("ddl06Estimate").selectedIndex].value == "") {
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else if (document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value.includes("House Construction") && document.getElementById("ddl06Estimate").options[document.getElementById("ddl06Estimate").selectedIndex].value == "" && document.getElementById("ddl06Project").options[document.getElementById("ddl06Project").selectedIndex].value == "") {
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else {
        Filter_Ok();
    };

    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        // process
        return new Promise(resolve => {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB240000HND.ashx",
                data: {
                    'pFormCode': 'DSB240000',
                    'pType': 'Get-Projected-Filter',
                    'pCategory': document.getElementById("ddl06Category").options[document.getElementById("ddl06Category").selectedIndex].value,
                    'pEstimate': document.getElementById("ddl06Estimate").options[document.getElementById("ddl06Estimate").selectedIndex].value,
                    'pProject': document.getElementById("ddl06Project").options[document.getElementById("ddl06Project").selectedIndex].value,
                    'pWarehouse': document.getElementById("ddl06Warehouse").options[document.getElementById("ddl06Warehouse").selectedIndex].value
                },
                success: function (response) {
                    grid06Api.setGridOption("rowData", response);

                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                },
                complete: function (response) {
                    grid06Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table06Record');
            let gridOptions;

            // Destroy old grid if exists
            gridDiv.innerHTML = "";

            const gridTheme = agGrid.themeQuartz.withParams({
                wrapperBorder: true,
                headerRowBorder: false,
            });

            gridOptions = {
                theme: gridTheme,
                suppressCellFocus: true,
                enableCellTextSelection: true,
                suppressDragLeaveHidesColumns: true,
                rowSelection: 'single',
                loading: true,
                rowBuffer: 5,
                suppressColumnVirtualisation: false,
                debounceVerticalScrollbar: true,
                onGridSizeChanged: function (params) {
                    const isMobile = params.clientWidth < 768;

                    if (isMobile) {
                        params.api.applyColumnState({
                            defaultState: { pinned: null }
                        });
                    } else {
                        params.api.applyColumnState({
                            state: [
                                { colId: 'Percent', pinned: 'right' },
                                { colId: 'ExpPriority', pinned: 'right' }
                            ]
                        });
                    }
                },
                columnDefs: [
                    {
                        headerName: "Item",
                        field: "ItemName",
                        filter: 'agTextColumnFilter',
                        tooltipField: "ItemName",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Scope of Work",
                        field: "Scope",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Scope",
                        width: 200,
                    },
                    {
                        headerName: "Est. Qty",
                        field: "EstQty",
                        width: 150,
                        tooltipField: "EstQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Bal. Qty",
                        field: "BalQty",
                        width: 150,
                        tooltipField: "BalQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Remaining",
                        field: "Remaining",
                        width: 150,
                        tooltipField: "Remaining",
                        cellClass: "text-end",
                        cellRenderer: params => {
                            const value = params.data.Percent || 0;
                            var val = Number(params.value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            var Qty = "";

                            if (params.data.Percent.toFixed(2) > 50) {
                                Qty = `<span class="text-success fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) <= 10) {
                                Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) < 20) {
                                Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) < 40) {
                                Qty = `<span class="text-warning fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) <= 50) {
                                Qty = `<span class="text-info fs-6 fw-bolder">${val}</span>`;
                            }

                            return Qty;
                        }
                    },
                    {
                        headerName: "Warehouse",
                        field: "Warehouse",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Warehouse",
                        width: 250,
                    },
                    {
                        headerName: "Percentage",
                        field: "Percent",
                        tooltipField: "Percent" + "%",
                        width: 180,
                        pinned: "right",
                        cellRenderer: params => {
                            const value = params.value || 0;

                            let colorClass = "bg-danger";
                            if (value.toFixed(2) > 50) {
                                colorClass = "bg-success";
                            } else if (value.toFixed(2) <= 20) {
                                colorClass = "bg-danger";
                            } else if (value.toFixed(2) < 40) {
                                colorClass = "bg-warning";
                            } else if (value.toFixed(2) <= 50) {
                                colorClass = "bg-info";
                            }

                            const div = document.createElement("div");
                            div.className = "d-flex flex-column w-100";

                            div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                            // Animate after render
                            setTimeout(() => {
                                const bar = div.querySelector(".progress-bar");
                                bar.style.width = value + "%";
                            }, 50);

                            return div;
                        }
                    },
                    {
                        headerName: "Exp. Priority",
                        colId: "ExpPriority",
                        width: 180,
                        pinned: "right",
                        cellRenderer: params => {
                            var span = "";
                            if (params.data.Percent.toFixed(2) > 50) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-secondary border border-secondary text-gray-600 fs-base'>Low</span></div>`;
                            } else if (params.data.Percent.toFixed(2) <= 10) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>Critical</span></div>`;
                            } else if (params.data.Percent.toFixed(2) < 20) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>High</span></div>`;
                            } else if (params.data.Percent.toFixed(2) < 40) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-warning border border-warning fs-base'>Urgent</span></div>`;
                            } else if (params.data.Percent.toFixed(2) <= 50) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>Medium</span></div>`;
                            }
                            return span;
                        },
                    },
                ],
                rowData: [],
                pagination: false
            };
            grid06Api = agGrid.createGrid(gridDiv, gridOptions);

        });
    };
};
function fn06Clear_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission

    //clear
    $('#ddl06Category').val('').trigger('change');
    $('#ddl06Estimate').val('').trigger('change');
    $('#ddl06Project').val('').trigger('change');
    $('#ddl06Warehouse').val('').trigger('change');
    //clear

    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = false;
    // Hide loading indication
    Btn.removeAttribute('data-kt-indicator');
};
function ddl07Category_onchange(ddl07Category) {
    document.getElementById("ddl07Project").disabled = true;
    $('#ddl07Project').val('').trigger('change');
    $('#ddl07Project').next('.select2-container')
        .find('.select2-selection')
        .removeClass('border border-danger');
    if (ddl07Category.options[ddl07Category.selectedIndex].value != "" && (ddl07Category.options[ddl07Category.selectedIndex].value != "House Construction" && ddl07Category.options[ddl07Category.selectedIndex].value != "House Construction - CCI")) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record (ID)',
                'pTblName': 'Get_Estimate',
                'pTblCode': ddl07Category.options[ddl07Category.selectedIndex].value,
                'pPlaceHolder': 'Estimate'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl07Estimate").html(s);
                $('#ddl07Estimate').val('').trigger('change');

                //disable
                document.getElementById("ddl07Project").disabled = true;
                $('#ddl07Project').next('.select2-container')
                    .find('.select2-selection')
                    .removeClass('border border-danger');
            },
        });
    } else if (ddl07Category.options[ddl07Category.selectedIndex].value != "" && (ddl07Category.options[ddl07Category.selectedIndex].value == "House Construction" || ddl07Category.options[ddl07Category.selectedIndex].value == "House Construction - CCI")) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB240000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record (ID)',
                'pTblName': 'Get_Project',
                'pTblCode': ddl07Category.options[ddl07Category.selectedIndex].value,
                'pPlaceHolder': 'Project'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl07Project").html(s);
                $('#ddl07Project').val('').trigger('change');

                //disable
                document.getElementById("ddl07Project").disabled = false;
                $('#ddl07Project').next('.select2-container')
                    .find('.select2-selection')
                    .addClass('border border-danger');
            },
        });
    };
};
function fn07Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    if (document.getElementById("ddl07Category").options[document.getElementById("ddl07Category").selectedIndex].value == "") {
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else if (document.getElementById("ddl07Category").options[document.getElementById("ddl07Category").selectedIndex].value.includes("House Construction") && document.getElementById("ddl07Project").options[document.getElementById("ddl07Project").selectedIndex].value == "") {
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else {
        Filter_Ok();
    };

    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        // process
        return new Promise(resolve => {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB240000HND.ashx",
                data: {
                    'pFormCode': 'DSB240000',
                    'pType': 'Get-PR-Filter',
                    'pCategory': document.getElementById("ddl07Category").options[document.getElementById("ddl07Category").selectedIndex].value,
                    'pProject': document.getElementById("ddl07Project").options[document.getElementById("ddl07Project").selectedIndex].value,
                    'pWarehouse': document.getElementById("ddl07Warehouse").options[document.getElementById("ddl07Warehouse").selectedIndex].value
                },
                success: function (response) {
                    grid07Api.setGridOption("rowData", response);

                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                    //resolve
                    resolve();
                },
                complete: function (response) {
                    grid07Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table07Record');
            let gridOptions;

            // Destroy old grid if exists
            gridDiv.innerHTML = "";

            const gridTheme = agGrid.themeQuartz.withParams({
                wrapperBorder: true,
                headerRowBorder: false,
            });

            gridOptions = {
                theme: gridTheme,
                suppressCellFocus: true,
                suppressDragLeaveHidesColumns: true,
                enableCellTextSelection: true,
                rowSelection: 'single',
                loading: true,
                rowBuffer: 5,
                suppressColumnVirtualisation: false,
                debounceVerticalScrollbar: true,
                onGridSizeChanged: function (params) {
                    const isMobile = params.clientWidth < 768;

                    if (isMobile) {
                        params.api.applyColumnState({
                            defaultState: { pinned: null }
                        });
                    } else {
                        params.api.applyColumnState({
                            state: [
                                { colId: 'Reference', pinned: 'left' },
                                { colId: 'Percent', pinned: 'right' },
                                { colId: 'ExpPriority', pinned: 'right' }
                            ]
                        });
                    }
                },
                columnDefs: [
                    {
                        headerName: "PR. No.",
                        field: "Reference",
                        lockPosition: true,
                        pinned: "left",
                        filter: 'agTextColumnFilter',
                        width: 150,
                        tooltipField: "Reference",
                        cellStyle: { fontWeight: 'bold' },
                        onCellClicked: function (params) {
                            //redirect
                            window.open("FRM000010-DTL-" + params.value, '_blank').focus();
                        }
                    },
                    {
                        headerName: "Item",
                        field: "ItemName",
                        filter: 'agTextColumnFilter',
                        tooltipField: "ItemName",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Status",
                        field: "Status",
                        filter: 'agTextColumnFilter',
                        width: 180,
                        cellRenderer: params => {
                            var span = "";
                            if (params.value != "") {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info2 border border-info2 fs-base'>
                                        <span class='svg-icon svg-icon-info2 svg-icon-1x'><svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>
                                            <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                                                <rect x='0' y='0' width='24' height='24'/>
                                                <path d='M10.9630156,7.5 L11.0475062,7.5 C11.3043819,7.5 11.5194647,7.69464724 11.5450248,7.95024814 L12,12.5 L15.2480695,14.3560397 C15.403857,14.4450611 15.5,14.6107328 15.5,14.7901613 L15.5,15 C15.5,15.2109164 15.3290185,15.3818979 15.1181021,15.3818979 C15.0841582,15.3818979 15.0503659,15.3773725 15.0176181,15.3684413 L10.3986612,14.1087258 C10.1672824,14.0456225 10.0132986,13.8271186 10.0316926,13.5879956 L10.4644883,7.96165175 C10.4845267,7.70115317 10.7017474,7.5 10.9630156,7.5 Z' fill='currentColor'/>
                                                <path d='M7.38979581,2.8349582 C8.65216735,2.29743306 10.0413491,2 11.5,2 C17.2989899,2 22,6.70101013 22,12.5 C22,18.2989899 17.2989899,23 11.5,23 C5.70101013,23 1,18.2989899 1,12.5 C1,11.5151324 1.13559454,10.5619345 1.38913364,9.65805651 L3.31481075,10.1982117 C3.10672013,10.940064 3,11.7119264 3,12.5 C3,17.1944204 6.80557963,21 11.5,21 C16.1944204,21 20,17.1944204 20,12.5 C20,7.80557963 16.1944204,4 11.5,4 C10.54876,4 9.62236069,4.15592757 8.74872191,4.45446326 L9.93948308,5.87355717 C10.0088058,5.95617272 10.0495583,6.05898805 10.05566,6.16666224 C10.0712834,6.4423623 9.86044965,6.67852665 9.5847496,6.69415008 L4.71777931,6.96995273 C4.66931162,6.97269931 4.62070229,6.96837279 4.57348157,6.95710938 C4.30487471,6.89303938 4.13906482,6.62335149 4.20313482,6.35474463 L5.33163823,1.62361064 C5.35654118,1.51920756 5.41437908,1.4255891 5.49660017,1.35659741 C5.7081375,1.17909652 6.0235153,1.2066885 6.2010162,1.41822583 L7.38979581,2.8349582 Z' fill='currentColor' opacity='0.3'/>
                                            </g>
                                        </svg>
                                        ${params.value}</span></div>`;
                            };
                            return span;
                        }
                    },
                    {
                        headerName: "PR. Qty",
                        field: "PRQty",
                        width: 150,
                        tooltipField: "PRQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Bal. Qty",
                        field: "BalQty",
                        width: 150,
                        tooltipField: "BalQty",
                        cellClass: "text-end",
                        valueFormatter: params => {
                            if (params.value == null || params.value === "") return "";
                            return Number(params.value).toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Remaining",
                        field: "Remaining",
                        width: 150,
                        tooltipField: "Remaining",
                        cellClass: "text-end",
                        cellRenderer: params => {
                            const value = params.data.Percent || 0;
                            var val = Number(params.value).toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                            var Qty = "";

                            if (params.data.Percent.toFixed(2) > 50) {
                                Qty = `<span class="text-success fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) <= 10) {
                                Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) < 20) {
                                Qty = `<span class="text-danger fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) < 40) {
                                Qty = `<span class="text-warning fs-6 fw-bolder">${val}</span>`;
                            } else if (params.data.Percent.toFixed(2) <= 50) {
                                Qty = `<span class="text-info fs-6 fw-bolder">${val}</span>`;
                            }

                            return Qty;
                        }
                    },
                    {
                        headerName: "Warehouse",
                        field: "Warehouse",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Warehouse",
                        width: 250,
                    },
                    {
                        headerName: "Percentage",
                        field: "Percent",
                        tooltipField: "Percent" + "%",
                        width: 180,
                        pinned: "right",
                        cellRenderer: params => {
                            const value = params.value || 0;

                            let colorClass = "bg-danger";
                            if (value.toFixed(2) > 50) {
                                colorClass = "bg-success";
                            } else if (value.toFixed(2) <= 20) {
                                colorClass = "bg-danger";
                            } else if (value.toFixed(2) < 40) {
                                colorClass = "bg-warning";
                            } else if (value.toFixed(2) <= 50) {
                                colorClass = "bg-info";
                            }

                            const div = document.createElement("div");
                            div.className = "d-flex flex-column w-100";

                            div.innerHTML = `
                                    <div class="d-flex align-items-center w-100 mw-125px">
										<div class="progress h-6px w-100 me-2 bg-light-success">
											<div class="progress-bar ${colorClass}" role="progressbar" style="width: 0%" aria-valuenow="${value}" aria-valuemin="0" aria-valuemax="100" title="${value.toFixed(2)}%"></div>
										</div>
										<span class="text-gray-400 fw-bold">${value.toFixed(0)}%</span>
									</div>
                                                `;

                            // Animate after render
                            setTimeout(() => {
                                const bar = div.querySelector(".progress-bar");
                                bar.style.width = value + "%";
                            }, 50);

                            return div;
                        }
                    },
                    {
                        headerName: "Exp. Priority",
                        colId: "ExpPriority",
                        width: 180,
                        pinned: "right",
                        cellRenderer: params => {
                            var span = "";
                            if (params.data.Percent.toFixed(2) > 50) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-secondary border border-secondary text-gray-600 fs-base'>Low</span></div>`;
                            } else if (params.data.Percent.toFixed(2) <= 10) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>Critical</span></div>`;
                            } else if (params.data.Percent.toFixed(2) < 20) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>High</span></div>`;
                            } else if (params.data.Percent.toFixed(2) < 40) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-warning border border-warning fs-base'>Urgent</span></div>`;
                            } else if (params.data.Percent.toFixed(2) <= 50) {
                                span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>Medium</span></div>`;
                            }
                            return span;
                        },
                    },
                ],
                rowData: [],
                pagination: false
            };
            grid07Api = agGrid.createGrid(gridDiv, gridOptions);

        });
    };
};
function fn07Clear_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission

    //clear
    $('#ddl07Category').val('').trigger('change');
    $('#ddl07Project').val('').trigger('change');
    $('#ddl07Warehouse').val('').trigger('change');
    //clear

    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = false;
    // Hide loading indication
    Btn.removeAttribute('data-kt-indicator');
};
//filter

//export
function fn01Export() {
    if (grid01Api) {
        grid01Api.exportDataAsCsv({
            fileName: 'Purchase Request & Status Tracking - For PO.csv',
            columnKeys: ['PRNo', 'PONo', 'FormStatus', 'ItemName', 'Unit', 'PRQty', 'POQty', 'Balance', 'Percentage', 'Overall', 'Requestor', 'Purchaser', 'Warehouse', 'Category', 'PRRemarks', 'PRDate', 'ApprDate']
        });
    }
};
function fn02Export() {
    if (grid02Api) {
        grid02Api.exportDataAsCsv({
            fileName: 'Purchase Request & Status Tracking - For SR.csv',
            columnKeys: ['PRNo', 'SIno', 'FormStatus', 'Status', 'ItemName', 'Unit', 'PRQty', 'SIQty', 'Balance', 'Percentage', 'Overall', 'Requestor', 'IssuedBy', 'Warehouse', 'Category', 'PRRemarks', 'PRDate', 'ApprDate']
        });
    }
}
function fn0201Export() {
    if (grid02Api) {
        grid02Api.exportDataAsCsv({
            fileName: 'Overall progress per Item.csv',
            columnKeys: ['PRNo', 'DateRequested', 'ApprDate', 'ItemName', 'Percentage', 'FormStatus', 'Status']
        });
    }
};
function fn03Export() {
    if (grid03Api) {
        grid03Api.exportDataAsCsv({
            fileName: 'Purchase Request & Status Tracking.csv',
            columnKeys: ['Reference', 'Status', 'ItemName', 'ForPO', 'Unit', 'PRDate', 'PurchaseType', 'Remarks', 'Requestor', 'Purchaser']
        });
    }
};
function fn0301Export() {
    if (grid03Api) {
        grid03Api.exportDataAsCsv({
            fileName: 'Inventory Stock per Warehouse.csv',
            columnKeys: ['Warehouse', 'ClassName', 'ItemName', 'Qty', 'UMName', 'Cost', 'Total']
        });
    }
};
function fn04Export() {
    if (grid04Api) {
        grid04Api.exportDataAsCsv({
            fileName: 'Actual Issuance Usage.csv',
            columnKeys: ['ItemName', 'Month7', 'Month6', 'Month5', 'Month4', 'Month3', 'Month2', 'Month1', 'Total', 'AvgMonth', 'Projection']
        });
    }
};
function fn05Export() {
    if (grid05Api) {
        grid05Api.exportDataAsCsv({
            fileName: 'Upcoming New Balances (Incoming Stock).csv',
            columnKeys: ['RefNo', 'ItemName', 'Qty', 'Date', 'Supplier', 'Purchaser', 'Status', 'Warehouse', 'CurrBal', 'NewBal']
        });
    }
};
function fn06Export() {
    if (grid06Api && grid06Api.getDisplayedRowCount() > 0) {
        grid06Api.exportDataAsCsv({
            fileName: 'Estimate New Balances (BOQ).csv',
            columnKeys: ['ItemName', 'Scope', 'EstQty', 'BalQty', 'Remaining', 'Warehouse', 'Percent']
        });
    } else {
        fnAlertOnly('No data to export.', 'error', 'btn btn-danger');
    };
};
function fn07Export() {
    if (grid07Api && grid07Api.getDisplayedRowCount() > 0) {
        grid07Api.exportDataAsCsv({
            fileName: 'Upcoming New Balances (PR).csv',
            columnKeys: ['Reference', 'ItemName', 'Status', 'PRQty', 'BalQty', 'Remaining', 'Warehouse', 'Percent']
        });
    } else {
        fnAlertOnly('No data to export.', 'error', 'btn btn-danger');
    };
};
//export

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