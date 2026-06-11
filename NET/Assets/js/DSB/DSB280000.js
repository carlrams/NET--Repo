
//public variable
let grid01Api;
let grid02Api;
let grid03Api;
let grid04Api;
let grid05Api;
//public variable

//function - General
function fn01Load() {
    fnAccess('DSB280000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            //Header
            fn01Header();

            //Chart 
            fn01Chart();
            fn02Chart();
            fn03Chart();

            //Table
            fn01Table();
            fn02Table();
            fn03Table();
            fn04Table();
            fn05Table();
        } else {
            location.replace("MNU000022");
        };
    });
};
//function - General

//function - Refresh
function fn01Refresh() {
    fn01Load();
};
//function - Refresh

//function - Vue Header
const { createApp, ref, onMounted } = Vue;

createApp({
    setup() {
        const message = ref('')
        // 1️⃣ Define the function
        const fetchData = async () => {
            try {
                const response = await fetch('Assets/Handler/DSB/DSB280000HND.ashx', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    body: new URLSearchParams({
                        'pFormCode': 'DSB280000',
                        'pType': 'Get-PO-Header'
                    })
                });
                
                const data = await response.json();
                const postedVal = Number(data[0].Posted);
                const counter = new countUp.CountUp('spn01Counter', postedVal)
                message.value = counter;
                counter.start();
            } catch (e) {
                console.error('Fetch error:', e);
                message.value = 'Error fetching data';
            }
        };

        // 2️⃣ Call it on mount
        onMounted(() => {
            fetchData();
        });

        // 3️⃣ Return any variables or functions if needed in template
        return { message, fetchData };
    }
}).mount('#div01Parent');

//function - Vue Header

//function - Header
function fn01Header() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': 'DSB280000',
            'pType': 'Get-PO-Header'
        },
        success: function (response) {
            //Count up
            const Posted = new countUp.CountUp(document.getElementById("h01Posted"), response[0].Posted, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const Cost = new countUp.CountUp(document.getElementById("h01TotalValue"), response[0].Cost, {
                decimalPlaces: 2,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '₱',
                suffix: ''
            });
            const InProgress = new countUp.CountUp(document.getElementById("h01InProgress"), response[0].InProgress, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const Completed = new countUp.CountUp(document.getElementById("h01Completed"), response[0].Completed, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });

            if (!Posted.error || !Cost.error || !InProgress.error || !Completed.error) {
                Posted.start();
                Cost.start();
                InProgress.start();
                Completed.start();
            };

            //Title
            const monthName = new Date().toLocaleString('en-US', { month: 'long' });

            //span
            document.getElementById("spn01Title").innerHTML = `as of ${monthName}`;
            document.getElementById("spn0102Title").innerHTML = `${response[0].PrevPosted.toLocaleString()} prev. Month`;
            document.getElementById("spn02Title").innerHTML = `as of ${monthName}`;
            document.getElementById("spn0201Title").innerHTML = `₱ ${response[0].PrevCost.toLocaleString()} prev. Month`;
            document.getElementById("spn0301Title").innerHTML = `${response[0].PrevInProgress.toLocaleString()} prev. Month`;
            document.getElementById("spn0401Title").innerHTML = `${response[0].PrevCompleted.toLocaleString()} prev. Month`;


            //div
            document.getElementById("div01Title").innerHTML = `${monthName} Report`;
            document.getElementById("div02Title").innerHTML = `${monthName} Commodity`;
        },
    });
};
//function - Header

//function - Chart
function fn01Chart() {

    //loader
    fn00Loader("#kt_bar_graph_01");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': "DSB280000",
            'pType': 'Get-Commodity-Total'
        },
        success: function (response) {

            //variable
            const Commodity = response.map(i => i.Commodity);
            const Total = response.map(i => i.Total);
            //variable

            // Class definition
            var Chart01 = function () {

                // Private methods
                var initChart01 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);
                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                    //clear
                    element.innerHTML = "";
                    //clear

                    const baseColors = [
                        '#6B34EB',
                        '#DE8749',
                        '#9BC255',
                        '#F26D81',
                        '#42428F'
                    ];

                    const randomColors = Commodity.map((_, i) => baseColors[i % baseColors.length]);

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Total Value: ",
                            data: Total
                        }],
                        chart: {
                            type: 'bar',
                            height: 380
                        },
                        dataLabels: {
                            enabled: true,
                            formatter: function (val) {
                                return val.toLocaleString('en-US', {
                                    notation: 'compact',
                                    compactDisplay: 'short',
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                })
                            },
                            offsetY: -20,
                            style: {
                                fontSize: '12px',
                                fontWeight: 'bold',
                                colors: ['#ffffff']
                            },
                        },
                        colors: randomColors,
                        plotOptions: {
                            bar: {
                                distributed: true,
                                borderRadius: 5,
                                horizontal: true,
                                dataLabels: {
                                    position: 'top',
                                },
                            }
                        },
                        legend: {
                            show: false
                        },
                        xaxis: {
                            categories: Commodity,
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
                        tooltip: {
                            x: {
                                formatter: function (val) {
                                    return val;
                                }
                            }
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initChart01('#kt_bar_graph_01');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart01;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart01.init();
            });

        }

    });
};
function fn02Chart() {

    //loader
    fn00Loader("#kt_donut_graph_002");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': "DSB280000",
            'pType': 'Get-Commodity-Item'
        },
        success: function (response) {

            //variable
            const Commodity = response.map(i => i.Commodity);
            const Total = response.map(i => i.Total);
            //variable

            const baseColors = [
                '#6B34EB',
                '#DE8749',
                '#9BC255',
                '#F26D81',
                '#42428F'
            ];

            const randomColors = Commodity.map((_, i) => baseColors[i % baseColors.length]);

            // Class definition
            var Chart02 = function () {

                // Private methods
                var initChart02 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);

                    //clear
                    element.innerHTML = "";
                    //clear

                    if (!element) {
                        return;
                    }

                    var height = parseInt(KTUtil.css(element, 'height'));

                    var options = {
                        series: Total,
                        chart: {
                            type: 'donut',
                            height: 420,
                            width: '100%'
                        },
                        plotOptions: {
                            pie: {
                                donut: {
                                    size: '60%'
                                }
                            }
                        },
                        labels: Commodity,
                        dataLabels: {
                            enabled: true,
                            formatter: function (val, opts) {
                                var num = val.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 2 })
                                return opts.w.config.labels[opts.seriesIndex] + ": " + num + "%";
                            },
                            dropShadow: {
                                enabled: false
                            },
                            style: {
                                fontSize: '14px',
                            },
                            offset: 10,
                            background: {
                                enabled: true,
                                foreColor: '#000',
                                padding: 4,
                                borderRadius: 2,
                                borderWidth: 1,
                                borderColor: '#ccc',
                            },
                            connector: {
                                enabled: true,
                                strokeWidth: 1,
                                strokeColor: '#aaa',
                            }
                        },
                        colors: randomColors,
                        tooltip: {
                            y: {
                                formatter: function (val) {
                                    return Number(val).toLocaleString('en-US', {
                                        minimumFractionDigits: 2,
                                        maximumFractionDigits: 2
                                    });
                                }
                            }
                        },
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
                        initChart02('#kt_donut_graph_002');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart02;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart02.init();
            });

        }

    });
};
function fn03Chart() {

    //loader
    fn00Loader("#kt_bar_graph_03");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': "DSB280000",
            'pType': 'Get-Supplier-Evaluation'
        },
        success: function (response) {

            //variable
            const Supplier = response.map(i => i.Supplier);
            const Total = response.map(i => i.OverallTotal);
            //variable

            // Class definition
            var Chart03 = function () {

                // Private methods
                var initChart03 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);
                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                    //clear
                    element.innerHTML = "";
                    //clear 

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            data: Total
                        }],
                        chart: {
                            type: 'bar',
                            height: 380
                        },
                        plotOptions: {
                            bar: {
                                barHeight: '100%',
                                distributed: true,
                                horizontal: true,
                                dataLabels: {
                                    position: 'bottom'
                                },
                            }
                        },
                        colors: 
                            [
                                '#4E79A7', // muted blue
                                '#59A14F', // soft green
                                '#F28E2B', // warm orange
                                '#E15759', // soft red
                                '#76B7B2', // teal
                                '#EDC948', // muted yellow
                                '#B07AA1', // soft purple
                                '#FF9DA7', // light pink
                                '#9C755F', // brown
                                '#BAB0AC', // gray
                                '#86BCB6', // pastel teal
                                '#D4A6C8', // pastel violet
                                '#A0CBE8', // light blue
                                '#CFCFCF', // light gray
                                '#8CD17D'  // fresh green
                            ],
                        dataLabels: {
                            enabled: true,
                            textAnchor: 'start',
                            style: {
                                colors: ['#fff']
                            },
                            formatter: function (val, opt) {
                                return opt.w.globals.labels[opt.dataPointIndex] + ' : ' + response[opt.dataPointIndex].Rating + ' - ' + val + 'pts';
                            },
                            offsetX: 0,
                            dropShadow: {
                                enabled: true
                            }
                        },
                        stroke: {
                            width: 1,
                            colors: ['#fff']
                        },
                        xaxis: {
                            categories: Supplier
                        },
                        yaxis: {
                            labels: {
                                show: false
                            },
                            max: function (max) {
                                return 100;
                            }
                        },
                        title: {
                            text: 'Top 15 Suppliers',
                            align: 'center',
                            floating: true
                        },
                        tooltip: {
                            theme: 'dark',
                            x: {
                                show: false
                            },
                            y: {
                                title: {
                                    formatter: function (val, opt) {
                                        return response[opt.dataPointIndex].Rating + ':';
                                    }
                                },
                                formatter: function (val) {
                                    return val + ' pts';
                                }
                            }
                        },
                        legend: {
                            show: false
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initChart03('#kt_bar_graph_03');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart03;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart03.init();
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
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': 'DSB280000',
            'pType': 'Get-Purchase-Order'
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
        theme: gridTheme,
        suppressCellFocus: true,
        suppressVerticalScroll: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        columnDefs: [
            {
                headerName: "P.R. Date",
                field: "PRDate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "PRDate"
            },
            {
                headerName: "P.O. Date",
                field: "PODate",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "PODate"
            },
            {
                headerName: "Cycle",
                field: "Cycle",
                filter: 'agTextColumnFilter',
                width: 100,
                tooltipField: "Cycle"
            },
            {
                headerName: "P.R. No.",
                field: "PRNo",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PRNo",
                cellStyle: { fontWeight: 'bold' },
                onCellDoubleClicked: function (params) {
                    //redirect
                    window.open("FRM000010-DTL-" + params.data.PRNo, '_blank').focus();
                }
            },
            {
                headerName: "P.O. No.",
                field: "PONo",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "PONo",
                cellStyle: { fontWeight: 'bold' },
                onCellDoubleClicked: function (params) {
                    //redirect
                    window.open("SCM060100-DTL-" + params.data.POCode, '_blank').focus();
                }
            },
            {
                headerName: "Project",
                field: "Project",
                filter: 'agTextColumnFilter',
                tooltipField: "Project",
                width: 180
            },
            {
                headerName: "Qty",
                field: "Qty",
                tooltipField: "Qty",
                width: 150,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Qty) || 0;
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
                headerName: "Item",
                field: "ItemName",
                filter: 'agTextColumnFilter',
                tooltipField: "ItemName",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Supplier",
                field: "Supplier",
                filter: 'agTextColumnFilter',
                tooltipField: "Supplier",
                width: 250
            },
            {
                headerName: "P.O. Amount",
                field: "Cost",
                tooltipField: "Cost",
                width: 150,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Cost) || 0;
                    }
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2,
                        style: 'currency',
                        currency: 'PHP',
                    });
                },
            },
            {
                headerName: "Strategy",
                field: "Strategy",
                filter: 'agTextColumnFilter',
                tooltipField: "Strategy",
                width: 180,
                cellClass: params => {
                    if (params.value == "CANVASS") {;
                        return 'bg-info text-center text-white fw-bold';
                    } else if (params.value == "OUTRIGHT NEGO") {
                        return 'bg-danger text-center text-white fw-bold';
                    } else if (params.value == "SEALED BID") {
                        return 'bg-warning text-center text-white fw-bold';
                    } else if (params.value == "SUPPLY AGREEMENT") {
                        return 'bg-success text-center text-white fw-bold';
                    }
                }
            },
            {
                headerName: "Procurement Staff",
                field: "Purchaser",
                filter: 'agTextColumnFilter',
                tooltipField: "Purchaser",
                width: 180
            },
            {
                headerName: "Commodity",
                field: "Commodity",
                filter: 'agTextColumnFilter',
                tooltipField: "Commodity",
                width: 200
            }
        ],
        rowData: [],
        pagination: false,
    };
    grid01Api = agGrid.createGrid(gridDiv, gridOptions);

};
function fn02Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': 'DSB280000',
            'pType': 'Get-Purchase-Commodity'
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
        theme: gridTheme,
        suppressCellFocus: true,
        suppressVerticalScroll: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: upd02Footer,
        onFirstDataRendered: upd02Footer,
        columnDefs: [
            {
                headerName: "Commodity",
                field: "Commodity",
                filter: 'agTextColumnFilter',
                tooltipField: "Commodity",
                flex: 1,
                minWidth: 350,
                cellStyle: params => {
                    if (params.node.rowPinned) {
                        return { fontWeight: 'bold', fontStyle: 'italic' };
                    };
                }
            },
            {
                headerName: "Total Purchases (₱)",
                field: "Amount",
                tooltipField: "Amount",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Amount) || 0;
                    };
                    if (params.data?.Commodity === 'Total Item') {
                        return params.value.toLocaleString('en-US');
                    };
                    return '₱ ' + value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Total Item",
                field: "TotalItem",
                tooltipField: "TotalItem",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.TotalItem) || 0;
                    };
                    if (params.data?.Commodity === 'Total Item') {
                        return params.value.toLocaleString('en-US');
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Qty",
                field: "Qty",
                tooltipField: "Qty",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Qty) || 0;
                    };
                    if (params.data?.Commodity === 'Total Item') {
                        return params.value.toLocaleString('en-US');
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "YTD Item",
                field: "YTDItem",
                tooltipField: "YTDItem",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.YTDItem) || 0;
                    };
                    if (params.data?.Commodity === 'Total Item') {
                        return params.value.toLocaleString('en-US');
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "YTD Qty",
                field: "YTDQty",
                tooltipField: "YTDQty",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.YTDQty) || 0;
                    };
                    if (params.data?.Commodity === 'Total Item') {
                        return params.value.toLocaleString('en-US');
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "% of Total Purchases",
                field: "Percentage",
                tooltipField: "Percentage",
                cellClass: "text-end",
                width: 180,
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Percentage) || 0;
                    };
                    if (params.data?.Commodity === 'Total Item') {
                        return '';
                    };
                    return value.toLocaleString("en-US", {
                        style: 'percent',
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            }
        ],
        getRowClass: params => {
            if (params.node.rowPinned === 'bottom') return 'bg-success text-white fw-bold';
        },
        rowData: [],
        pagination: false,
    };
    grid02Api = agGrid.createGrid(gridDiv, gridOptions);
    function upd02Footer() {
        let Total = 0;
        let TotalItem = 0;
        let TotalQty = 0;
        let YTDItem = 0;
        let YTDQty = 0;
        let Percentage = 0;
        let Count = 0;

        grid02Api.forEachNodeAfterFilter(function (node) {
            Total += Number(node.data.Amount) || 0;
            TotalItem += Number(node.data.TotalItem) || 0;
            TotalQty += Number(node.data.Qty) || 0;
            YTDItem += Number(node.data.YTDItem) || 0;
            YTDQty += Number(node.data.YTDQty) || 0;
            Percentage += Number(node.data.Percentage) || 0;
            Count = Number(node.data.CountItem) || 0;
        });

        grid02Api.setGridOption('pinnedBottomRowData', [
            { Commodity: 'Total', Amount: Total, TotalItem: TotalItem, Qty: TotalQty, YTDItem: YTDItem, YTDQty: YTDQty, Percentage: Percentage }
        ]);
    }
};
function fn03Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': 'DSB280000',
            'pType': 'Get-YTD-Purchase'
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
                        { colId: 'Commodity', pinned: 'left' }
                    ]
                });
            }
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressVerticalScroll: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: upd03Footer,
        onFirstDataRendered: upd03Footer,
        columnDefs: [
            {
                headerName: "Commodity",
                field: "Commodity",
                filter: 'agTextColumnFilter',
                tooltipField: "Commodity",
                flex: 1,
                lockPosition: true,
                pinned: "left",
                minWidth: 350,
                cellStyle: params => {
                    if (params.node.rowPinned) {
                        return { fontWeight: 'bold', fontStyle: 'italic' };
                    };
                }
            },
            {
                headerName: "January",
                field: "January",
                tooltipField: "January",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.January) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "February",
                field: "February",
                tooltipField: "February",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.February) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "March",
                field: "March",
                tooltipField: "March",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.March) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "April",
                field: "April",
                tooltipField: "April",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.April) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "May",
                field: "May",
                tooltipField: "May",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.May) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "June",
                field: "June",
                tooltipField: "June",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.June) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "July",
                field: "July",
                tooltipField: "July",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.July) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "August",
                field: "August",
                tooltipField: "August",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.August) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "September",
                field: "September",
                tooltipField: "September",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.September) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "October",
                field: "October",
                tooltipField: "October",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.October) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "November",
                field: "November",
                tooltipField: "November",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.November) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "December",
                field: "December",
                tooltipField: "December",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.December) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Total",
                field: "Total",
                tooltipField: "Total",
                width: 180,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Total) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            }
        ],
        getRowClass: params => {
            if (params.node.rowPinned === 'bottom') return 'bg-success text-white fw-bold';
        },
        rowData: [],
        pagination: false,
    };
    grid03Api = agGrid.createGrid(gridDiv, gridOptions);
    function upd03Footer() {
        let Jan = 0;
        let Feb = 0;
        let Mar = 0;
        let Apr = 0;
        let May = 0;
        let Jun = 0;
        let Jul = 0;
        let Aug = 0;
        let Sept = 0;
        let Oct = 0;
        let Nov = 0;
        let Dec = 0;
        let Total = 0;

        grid03Api.forEachNodeAfterFilter(function (node) {
            Jan += Number(node.data.January) || 0;
            Feb += Number(node.data.February) || 0;
            Mar += Number(node.data.March) || 0;
            Apr += Number(node.data.April) || 0;
            May += Number(node.data.May) || 0;
            Jun += Number(node.data.June) || 0;
            Jul += Number(node.data.July) || 0;
            Aug += Number(node.data.August) || 0;
            Sept += Number(node.data.September) || 0;
            Oct += Number(node.data.October) || 0;
            Nov += Number(node.data.November) || 0;
            Dec += Number(node.data.December) || 0;
            Total += Number(node.data.Total) || 0;
        });

        grid03Api.setGridOption('pinnedBottomRowData', [
            { Commodity: 'Grand Total', January: Jan, February: Feb, March: Mar, April: Apr, May: May, June: Jun, July: Jul, August: Aug, September: Sept, October: Oct, November: Nov, December: Dec, Total: Total }
        ]);
    };
};
function fn04Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': 'DSB280000',
            'pType': 'Get-YTD-Supplier'
        },
        success: function (response) {
            grid04Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid04Api.setGridOption("loading", false);
        }
    });

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
                        { colId: 'Vendor', pinned: 'left' }
                    ]
                });
            }
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressVerticalScroll: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: upd04Footer,
        onFirstDataRendered: upd04Footer,
        columnDefs: [
            {
                headerName: "Vendor",
                field: "Vendor",
                filter: 'agTextColumnFilter',
                tooltipField: "Vendor",
                flex: 1,
                lockPosition: true,
                pinned: "left",
                minWidth: 350,
                cellStyle: params => {
                    if (params.node.rowPinned) {
                        return { fontWeight: 'bold', fontStyle: 'italic' };
                    };
                }
            },
            {
                headerName: "January",
                field: "January",
                tooltipField: "January",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.January) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "February",
                field: "February",
                tooltipField: "February",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.February) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "March",
                field: "March",
                tooltipField: "March",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.March) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "April",
                field: "April",
                tooltipField: "April",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.April) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "May",
                field: "May",
                tooltipField: "May",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.May) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "June",
                field: "June",
                tooltipField: "June",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.June) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "July",
                field: "July",
                tooltipField: "July",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.July) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "August",
                field: "August",
                tooltipField: "August",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.August) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "September",
                field: "September",
                tooltipField: "September",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.September) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "October",
                field: "October",
                tooltipField: "October",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.October) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "November",
                field: "November",
                tooltipField: "November",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.November) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "December",
                field: "December",
                tooltipField: "December",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.December) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Total",
                field: "Total",
                tooltipField: "Total",
                width: 180,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Total) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            }
        ],
        getRowClass: params => {
            if (params.node.rowPinned === 'bottom') return 'bg-success text-white fw-bold';
        },
        rowData: [],
        pagination: false,
    };
    grid04Api = agGrid.createGrid(gridDiv, gridOptions);
    function upd04Footer() {
        let Jan = 0;
        let Feb = 0;
        let Mar = 0;
        let Apr = 0;
        let May = 0;
        let Jun = 0;
        let Jul = 0;
        let Aug = 0;
        let Sept = 0;
        let Oct = 0;
        let Nov = 0;
        let Dec = 0;
        let Total = 0;

        grid04Api.forEachNodeAfterFilter(function (node) {
            Jan += Number(node.data.January) || 0;
            Feb += Number(node.data.February) || 0;
            Mar += Number(node.data.March) || 0;
            Apr += Number(node.data.April) || 0;
            May += Number(node.data.May) || 0;
            Jun += Number(node.data.June) || 0;
            Jul += Number(node.data.July) || 0;
            Aug += Number(node.data.August) || 0;
            Sept += Number(node.data.September) || 0;
            Oct += Number(node.data.October) || 0;
            Nov += Number(node.data.November) || 0;
            Dec += Number(node.data.December) || 0;
            Total += Number(node.data.Total) || 0;
        });

        grid04Api.setGridOption('pinnedBottomRowData', [
            { Vendor: 'Grand Total', January: Jan, February: Feb, March: Mar, April: Apr, May: May, June: Jun, July: Jul, August: Aug, September: Sept, October: Oct, November: Nov, December: Dec, Total: Total }
        ]);
    };
};
function fn05Table() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB280000HND.ashx",
        data: {
            'pFormCode': 'DSB280000',
            'pType': 'Get-YTD-Item'
        },
        success: function (response) {
            grid05Api.setGridOption("rowData", response);
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
        onGridSizeChanged: function (params) {
            const isMobile = params.clientWidth < 768;

            if (isMobile) {
                params.api.applyColumnState({
                    defaultState: { pinned: null }
                });
            } else {
                params.api.applyColumnState({
                    state: [
                        { colId: 'Commodity', pinned: 'left' }
                    ]
                });
            }
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressVerticalScroll: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        loading: true,
        onFilterChanged: upd05Footer,
        onFirstDataRendered: upd05Footer,
        columnDefs: [
            {
                headerName: "Commodity",
                field: "Commodity",
                filter: 'agTextColumnFilter',
                tooltipField: "Commodity",
                flex: 1,
                lockPosition: true,
                pinned: "left",
                minWidth: 350,
                cellStyle: params => {
                    if (params.node.rowPinned) {
                        return { fontWeight: 'bold', fontStyle: 'italic' };
                    };
                }
            },
            {
                headerName: "January",
                field: "January",
                tooltipField: "January",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.January) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "February",
                field: "February",
                tooltipField: "February",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.February) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "March",
                field: "March",
                tooltipField: "March",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.March) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "April",
                field: "April",
                tooltipField: "April",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.April) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "May",
                field: "May",
                tooltipField: "May",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.May) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "June",
                field: "June",
                tooltipField: "June",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.June) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "July",
                field: "July",
                tooltipField: "July",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.July) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "August",
                field: "August",
                tooltipField: "August",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.August) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "September",
                field: "September",
                tooltipField: "September",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.September) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "October",
                field: "October",
                tooltipField: "October",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.October) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "November",
                field: "November",
                tooltipField: "November",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.November) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "December",
                field: "December",
                tooltipField: "December",
                width: 180,
                cellClass: "text-end",
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.December) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Total",
                field: "Total",
                tooltipField: "Total",
                width: 180,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Total) || 0;
                    };
                    return value.toLocaleString("en-PH", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            }
        ],
        getRowClass: params => {
            if (params.node.rowPinned === 'bottom') return 'bg-success text-white fw-bold';
        },
        rowData: [],
        pagination: false,
    };
    grid05Api = agGrid.createGrid(gridDiv, gridOptions);
    function upd05Footer() {
        let Jan = 0;
        let Feb = 0;
        let Mar = 0;
        let Apr = 0;
        let May = 0;
        let Jun = 0;
        let Jul = 0;
        let Aug = 0;
        let Sept = 0;
        let Oct = 0;
        let Nov = 0;
        let Dec = 0;
        let Total = 0;

        grid05Api.forEachNodeAfterFilter(function (node) {
            Jan += Number(node.data.January) || 0;
            Feb += Number(node.data.February) || 0;
            Mar += Number(node.data.March) || 0;
            Apr += Number(node.data.April) || 0;
            May += Number(node.data.May) || 0;
            Jun += Number(node.data.June) || 0;
            Jul += Number(node.data.July) || 0;
            Aug += Number(node.data.August) || 0;
            Sept += Number(node.data.September) || 0;
            Oct += Number(node.data.October) || 0;
            Nov += Number(node.data.November) || 0;
            Dec += Number(node.data.December) || 0;
            Total += Number(node.data.Total) || 0;
        });

        grid05Api.setGridOption('pinnedBottomRowData', [
            { Commodity: 'Grand Total', January: Jan, February: Feb, March: Mar, April: Apr, May: May, June: Jun, July: Jul, August: Aug, September: Sept, October: Oct, November: Nov, December: Dec, Total: Total }
        ]);
    };
};
//function - Table

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

//function - Filter
function fn00Month(ID) {
    const months = [
        "January", "February", "March", "April",
        "May", "June", "July", "August",
        "September", "October", "November", "December"
    ];
    const currentMonth = new Date().getMonth();
    var s = '<option value="">Select Month</option>';
    for (var i = 0; i <= currentMonth; i++) {
        s += '<option value="' + (i + 1) + '">' + months[i] + '</option>';
    }
    $("#ddl00Month").html(s);
    $('#ddl00Month').val(ID).trigger('change');
};
function fn00Year(ID) {
    const currentYear = new Date().getFullYear();
    var s = '<option value="">Select Year</option>';
    for (var i = currentYear; i >= currentYear - 10; i--) {
        s += '<option value="' + i + '">' + i + '</option>';
    }
    $("#ddl00Year").html(s);
    $('#ddl00Year').val(ID).trigger('change');
};
function fn00Filter() {
    fn00Month('');
    fn00Year('');
    $("#mdl00Filter").modal("show");
};
function fn00Filter_Ok(Btn) {
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
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    async function Filter_Ok_Await(Btn) {
        // validate
        if (document.getElementById("ddl00Month").options[document.getElementById("ddl00Month").selectedIndex].value == "") {
            // Alert
            fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("ddl00Year").options[document.getElementById("ddl00Year").selectedIndex].value == "") {
            // Alert
            fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            // process
            try {

                //variable
                var pMonth = document.getElementById("ddl00Month").value;
                var pYear = document.getElementById("ddl00Year").options[document.getElementById("ddl00Year").selectedIndex].value;
                //variable

                //filter
                await Promise.all([
                    fn0101Header(pMonth, pYear),
                    fn0101Chart(pMonth, pYear),
                    fn0102Chart(pMonth, pYear),
                    fn0102Table(pMonth, pYear)
                ]);
                //filter

                //alert
                fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

            } catch (error) {
                fnAlertOnly('Error loading record.', 'danger', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            } finally {
                // Always re-enable button
                Btn.disabled = false;
                Btn.removeAttribute('data-kt-indicator');
            };
        };
        //Header
        function fn0101Header(pMonth, pYear) {
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB280000HND.ashx",
                data: {
                    'pFormCode': 'DSB280000',
                    'pType': 'General-Filter-PO-Header',
                    'pMonth': pMonth,
                    'pYear': pYear
                }
            }).done(function (response) {
                //Count up
                const Posted = new countUp.CountUp(document.getElementById("h01Posted"), response[0].Posted, {
                    decimalPlaces: 0,
                    duration: 3,
                    useGrouping: true,
                    separator: ',',
                    decimal: '.',
                    prefix: '',
                    suffix: ''
                });
                const Cost = new countUp.CountUp(document.getElementById("h01TotalValue"), response[0].Cost, {
                    decimalPlaces: 2,
                    duration: 3,
                    useGrouping: true,
                    separator: ',',
                    decimal: '.',
                    prefix: '₱',
                    suffix: ''
                });
                const InProgress = new countUp.CountUp(document.getElementById("h01InProgress"), response[0].InProgress, {
                    decimalPlaces: 0,
                    duration: 3,
                    useGrouping: true,
                    separator: ',',
                    decimal: '.',
                    prefix: '',
                    suffix: ''
                });
                const Completed = new countUp.CountUp(document.getElementById("h01Completed"), response[0].Completed, {
                    decimalPlaces: 0,
                    duration: 3,
                    useGrouping: true,
                    separator: ',',
                    decimal: '.',
                    prefix: '',
                    suffix: ''
                });

                if (!Posted.error || !Cost.error || !InProgress.error || !Completed.error) {
                    Posted.start();
                    Cost.start();
                    InProgress.start();
                    Completed.start();
                };

                //Title
                const months = [
                    "January", "February", "March", "April",
                    "May", "June", "July", "August",
                    "September", "October", "November", "December"
                ];
                const monthName = months[pMonth - 1];

                //span
                document.getElementById("spn01Title").innerHTML = `as of ${monthName}`;
                document.getElementById("spn0102Title").innerHTML = `${response[0].PrevPosted.toLocaleString()} prev. Month`;
                document.getElementById("spn02Title").innerHTML = `as of ${monthName}`;
                document.getElementById("spn0201Title").innerHTML = `₱ ${response[0].PrevCost.toLocaleString()} prev. Month`;
                document.getElementById("spn0301Title").innerHTML = `${response[0].PrevInProgress.toLocaleString()} prev. Month`;
                document.getElementById("spn0401Title").innerHTML = `${response[0].PrevCompleted.toLocaleString()} prev. Month`;

                //div
                document.getElementById("div01Title").innerHTML = `${monthName} Report`;
                document.getElementById("div02Title").innerHTML = `${monthName} Commodity`;
            });
        };
        //Header

        //Chart
        function fn0101Chart(pMonth, pYear) {

            //loader
            fn00Loader("#kt_bar_graph_01");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB280000HND.ashx",
                data: {
                    pFormCode: 'DSB280000',
                    pType: 'General-Filter-Commodity-Total',
                    pMonth: pMonth,
                    pYear: pYear
                }
            }).done(function (response) {

                //variable
                const Commodity = response.map(i => i.Commodity);
                const Total = response.map(i => i.Total);
                //variable

                var element = document.querySelector('#kt_bar_graph_01');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                const baseColors = [
                    '#6B34EB',
                    '#DE8749',
                    '#9BC255',
                    '#F26D81',
                    '#42428F'
                ];

                const randomColors = Commodity.map((_, i) => baseColors[i % baseColors.length]);

                var chart = new ApexCharts(element, {

                    series: [{
                        name: "Total Value: ",
                        data: Total
                    }],
                    chart: {
                        type: 'bar',
                        height: 380
                    },
                    dataLabels: {
                        enabled: true,
                        formatter: function (val) {
                            return val.toLocaleString('en-US', {
                                notation: 'compact',
                                compactDisplay: 'short',
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            })
                        },
                        offsetY: -20,
                        style: {
                            fontSize: '12px',
                            fontWeight: 'bold',
                            colors: ['#ffffff']
                        },
                    },
                    colors: randomColors,
                    plotOptions: {
                        bar: {
                            distributed: true,
                            borderRadius: 5,
                            horizontal: true,
                            dataLabels: {
                                position: 'top',
                            },
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: Commodity,
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
                    tooltip: {
                        x: {
                            formatter: function (val) {
                                return val;
                            }
                        }
                    }
                });

                chart.render();
            });
        };
        function fn0102Chart(pMonth, pYear) {

            //loader
            fn00Loader("#kt_donut_graph_002");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB280000HND.ashx",
                data: {
                    pFormCode: 'DSB280000',
                    pType: 'General-Filter-Commodity-Item',
                    pMonth: pMonth,
                    pYear: pYear
                }
            }).done(function (response) {

                //variable
                const Commodity = response.map(i => i.Commodity);
                const Total = response.map(i => i.Total);
                //variable

                var element = document.querySelector('#kt_donut_graph_002');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                const baseColors = [
                    '#6B34EB',
                    '#DE8749',
                    '#9BC255',
                    '#F26D81',
                    '#42428F'
                ];

                const randomColors = Commodity.map((_, i) => baseColors[i % baseColors.length]);

                var chart = new ApexCharts(element, {

                    series: Total,
                    chart: {
                        type: 'donut',
                        height: 420,
                        width: '100%'
                    },
                    plotOptions: {
                        pie: {
                            donut: {
                                size: '60%'
                            }
                        }
                    },
                    labels: Commodity,
                    dataLabels: {
                        enabled: true,
                        formatter: function (val, opts) {
                            var num = val.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 2 })
                            return opts.w.config.labels[opts.seriesIndex] + ": " + num + "%";
                        },
                        dropShadow: {
                            enabled: false
                        },
                        style: {
                            fontSize: '14px',
                        },
                        offset: 10,
                        background: {
                            enabled: true,
                            foreColor: '#000',
                            padding: 4,
                            borderRadius: 2,
                            borderWidth: 1,
                            borderColor: '#ccc',
                        },
                        connector: {
                            enabled: true,
                            strokeWidth: 1,
                            strokeColor: '#aaa',
                        }
                    },
                    colors: randomColors,
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return Number(val).toLocaleString('en-US', {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                });
                            }
                        }
                    },
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
                });

                chart.render();
            });
        };
        //Chart

        //Table
        function fn0102Table(pMonth, pYear) {
            //Ajax
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB280000HND.ashx",
                data: {
                    pFormCode: 'DSB280000',
                    pType: 'General-Filter-Purchase-Commodity',
                    pMonth: pMonth,
                    pYear: pYear
                },
                success: function (response) {
                    grid02Api.setGridOption('rowData', response);
                    upd02Footer();
                },
                complete: function (response) {
                    grid02Api.setGridOption('loading', false);
                    upd02Footer();
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
                theme: gridTheme,
                suppressCellFocus: true,
                suppressVerticalScroll: true,
                enableCellTextSelection: true,
                rowSelection: 'single',
                loading: true,
                onFilterChanged: upd02Footer,
                onFirstDataRendered: upd02Footer,
                columnDefs: [
                    {
                        headerName: "Commodity",
                        field: "Commodity",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Commodity",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: params => {
                            if (params.node.rowPinned) {
                                return { fontWeight: 'bold', fontStyle: 'italic' };
                            };
                        }
                    },
                    {
                        headerName: "Total Purchases (₱)",
                        field: "Amount",
                        tooltipField: "Amount",
                        width: 180,
                        cellClass: "text-end",
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Amount) || 0;
                            };
                            if (params.data?.Commodity === 'Total Item') {
                                return params.value.toLocaleString('en-US');
                            };
                            return '₱ ' + value.toLocaleString("en-PH", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Total Item",
                        field: "TotalItem",
                        tooltipField: "TotalItem",
                        width: 180,
                        cellClass: "text-end",
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.TotalItem) || 0;
                            };
                            if (params.data?.Commodity === 'Total Item') {
                                return params.value.toLocaleString('en-US');
                            };
                            return value.toLocaleString("en-PH", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty",
                        field: "Qty",
                        tooltipField: "Qty",
                        width: 180,
                        cellClass: "text-end",
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty) || 0;
                            };
                            if (params.data?.Commodity === 'Total Item') {
                                return params.value.toLocaleString('en-US');
                            };
                            return value.toLocaleString("en-PH", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "YTD Item",
                        field: "YTDItem",
                        tooltipField: "YTDItem",
                        width: 180,
                        cellClass: "text-end",
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.YTDItem) || 0;
                            };
                            if (params.data?.Commodity === 'Total Item') {
                                return params.value.toLocaleString('en-US');
                            };
                            return value.toLocaleString("en-PH", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "YTD Qty",
                        field: "YTDQty",
                        tooltipField: "YTDQty",
                        width: 180,
                        cellClass: "text-end",
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.YTDQty) || 0;
                            };
                            if (params.data?.Commodity === 'Total Item') {
                                return params.value.toLocaleString('en-US');
                            };
                            return value.toLocaleString("en-PH", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "% of Total Purchases",
                        field: "Percentage",
                        tooltipField: "Percentage",
                        cellClass: "text-end",
                        width: 180,
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Percentage) || 0;
                            };
                            if (params.data?.Commodity === 'Total Item') {
                                return '';
                            };
                            return value.toLocaleString("en-US", {
                                style: 'percent',
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    }
                ],
                getRowClass: params => {
                    if (params.node.rowPinned === 'bottom') return 'bg-success text-white fw-bold';
                },
                rowData: [],
                pagination: false,
            };
            grid02Api = agGrid.createGrid(gridDiv, gridOptions);
            function upd02Footer() {
                let Total = 0;
                let TotalItem = 0;
                let TotalQty = 0;
                let YTDItem = 0;
                let YTDQty = 0;
                let Percentage = 0;

                grid02Api.forEachNodeAfterFilterAndSort(function (node) {
                    if (!node.rowPinned) {
                        Total += Number(node.data.Amount) || 0;
                        TotalItem += Number(node.data.TotalItem) || 0;
                        TotalQty += Number(node.data.Qty) || 0;
                        YTDItem += Number(node.data.YTDItem) || 0;
                        YTDQty += Number(node.data.YTDQty) || 0;
                        Percentage += Number(node.data.Percentage) || 0;
                        Count = Number(node.data.CountItem) || 0;
                    }
                });

                grid02Api.setGridOption('pinnedBottomRowData', [
                    { Commodity: 'Total', Amount: Total, TotalItem: TotalItem, Qty: TotalQty, YTDItem: YTDItem, YTDQty: YTDQty, Percentage: Percentage }
                ]);
            }
        };
        //Table
    };
};
function fn01Filter() {
    $("#mdl01Filter").modal("show");
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
                    url: "Assets/Handler/DSB/DSB280000HND.ashx",
                    data: {
                        'pFormCode': 'DSB280000',
                        'pType': 'Get-Purchase-Filter',
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
                    theme: gridTheme,
                    suppressCellFocus: true,
                    suppressVerticalScroll: true,
                    enableCellTextSelection: true,
                    rowSelection: 'single',
                    loading: true,
                    columnDefs: [
                        {
                            headerName: "P.R. Date",
                            field: "PRDate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "PRDate"
                        },
                        {
                            headerName: "P.O. Date",
                            field: "PODate",
                            filter: 'agTextColumnFilter',
                            width: 120,
                            tooltipField: "PODate"
                        },
                        {
                            headerName: "Cycle",
                            field: "Cycle",
                            filter: 'agTextColumnFilter',
                            width: 100,
                            tooltipField: "Cycle"
                        },
                        {
                            headerName: "P.R. No.",
                            field: "PRNo",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "PRNo",
                            cellStyle: { fontWeight: 'bold' },
                            onCellDoubleClicked: function (params) {
                                //redirect
                                window.open("FRM000010-DTL-" + params.data.PRNo, '_blank').focus();
                            }
                        },
                        {
                            headerName: "P.O. No.",
                            field: "PONo",
                            filter: 'agTextColumnFilter',
                            width: 150,
                            tooltipField: "PONo",
                            cellStyle: { fontWeight: 'bold' },
                            onCellDoubleClicked: function (params) {
                                //redirect
                                window.open("SCM060100-DTL-" + params.data.POCode, '_blank').focus();
                            }
                        },
                        {
                            headerName: "Project",
                            field: "Project",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Project",
                            width: 180
                        },
                        {
                            headerName: "Qty",
                            field: "Qty",
                            tooltipField: "Qty",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.Qty) || 0;
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
                            headerName: "Item",
                            field: "ItemName",
                            filter: 'agTextColumnFilter',
                            tooltipField: "ItemName",
                            flex: 1,
                            minWidth: 350,
                            cellStyle: { fontWeight: 'bold' }
                        },
                        {
                            headerName: "Supplier",
                            field: "Supplier",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Supplier",
                            width: 250
                        },
                        {
                            headerName: "P.O. Amount",
                            field: "Cost",
                            tooltipField: "Cost",
                            width: 150,
                            cellClass: "text-end",
                            cellStyle: { fontWeight: 'bold' },
                            valueFormatter: params => {
                                let value = parseFloat(params.value);
                                if (isNaN(value)) {
                                    value = parseFloat(params.data.Cost) || 0;
                                }
                                return value.toLocaleString("en-PH", {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2,
                                    style: 'currency',
                                    currency: 'PHP',
                                });
                            },
                        },
                        {
                            headerName: "Strategy",
                            field: "Strategy",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Strategy",
                            width: 150,
                            cellStyle: params => {
                                if (params.value == "CANVASS") {
                                    ;
                                    return { backgroundColor: '#00FFFF', fontStyle: 'italic' };
                                } else if (params.value == "OUTRIGHT NEGO") {
                                    return { backgroundColor: '#FF0000', fontStyle: 'italic' };
                                } else if (params.value == "SEALED BID") {
                                    return { backgroundColor: '#FFFF00', fontStyle: 'italic' };
                                } else if (params.value == "SUPPLY AGREEMENT") {
                                    return { backgroundColor: '#008000', fontStyle: 'italic', color: '#FFFFFF' };
                                }
                            }
                        },
                        {
                            headerName: "Procurement Staff",
                            field: "Purchaser",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Purchaser",
                            width: 180
                        },
                        {
                            headerName: "Commodity",
                            field: "Commodity",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Commodity",
                            width: 200
                        }
                    ],
                    rowData: [],
                    pagination: false,
                };
                grid01Api = agGrid.createGrid(gridDiv, gridOptions);

            });
        };
    };
};
//function - Filter

//function - Export
function fn01Export() {
    if (grid01Api) {
        grid01Api.exportDataAsCsv({
            fileName: 'Purchase Order.csv',
            columnKeys: ['PRDate', 'PODate', 'Cycle', 'Department', 'PONo', 'PRNo', 'Project', 'Qty', 'Unit', 'ItemName', 'Supplier', 'Cost', 'Strategy', 'Commodity', 'Status', 'Purchaser']
        });
    }
};
function fn02Export() {
    if (grid02Api) {
        grid02Api.exportDataAsCsv({
            fileName: 'Commodity.csv',
            columnKeys: ['Commodity', 'Amount', 'TotalItem', 'Qty', 'YTDItem', 'YTDQty', 'Percentage']
        });
    }
};
function fn03Export() {
    if (grid03Api) {
        grid03Api.exportDataAsCsv({
            fileName: 'Year-to-Date Purchase.csv',
            columnKeys: ['Commodity', 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', 'Total']
        });
    }
};
function fn04Export() {
    if (grid04Api) {
        grid04Api.exportDataAsCsv({
            fileName: 'Year-to-Date Manufacturer & Dealer.csv',
            columnKeys: ['Vendor', 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', 'Total']
        });
    }
};
function fn05Export() {
    if (grid05Api) {
        grid05Api.exportDataAsCsv({
            fileName: 'Year-to-Date Qty.csv',
            columnKeys: ['Commodity', 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', 'Total']
        });
    }
};
//function - Export

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
