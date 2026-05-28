//public
let grid01Api;
let grid02Api;
//public

//general
function fn01Load() {
    fnAccess('DSB250000', 'View', function (response) {
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
            fn08Chart();
            fn09Chart();
            fn10Chart();

            //Table
            fn01Table();
            fn02Table();

        } else {
            location.replace("MNU000022");
        };
    });
};
//general

//function - Refresh
function fn01Refresh() {
    fn01Load();
};
//function - Refresh

//function - Header
function fn01Header() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': 'DSB250000',
            'pType': 'Get-Construction-Header'
        },
        success: function (response) {

            //Count up
            const Contractor = new countUp.CountUp(document.getElementById("h01Contractor"), response[0].Contractor, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const TotalBatch = new countUp.CountUp(document.getElementById("h01TotalBatch"), response[0].Batch, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const TotalUnit = new countUp.CountUp(document.getElementById("h01TotalUnit"), response[0].Unit, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const OnGoing = new countUp.CountUp(document.getElementById("h01OnGoing"), response[0].OnGoing, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const Completed = new countUp.CountUp(document.getElementById("h01Completed"), response[0].Complete, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const NotStarted = new countUp.CountUp(document.getElementById("h01NotStarted"), response[0].NotStarted, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });

            if (!Contractor.error || !TotalBatch.error || !TotalUnit.error || !OnGoing.error || !Completed.error || !NotStarted.error) {
                Contractor.start();
                TotalBatch.start();
                TotalUnit.start();
                OnGoing.start();
                Completed.start();
                NotStarted.start();
            };
        },
    });

    //bind
    fn01Batch('');
    fn01Project('');
    fn01Contractor('');
    fn01Status('');
    fn02Category('');
    fn02Project('');
    fn02Contractor('');
    //bind

    //Filter - dropdown
    function fn01Batch(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Batch',
                'pPlaceHolder': 'Batch',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl01Batch").html(s);
                $('#ddl01Batch').val(ID).trigger('change');
            },
        });
    };
    function fn01Project(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Project',
                'pPlaceHolder': 'Project',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl01Project").html(s);
                $('#ddl01Project').val(ID).trigger('change');
            },
        });
    };
    function fn01Contractor(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Contractor',
                'pPlaceHolder': 'Contractor',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl01Contractor").html(s);
                $('#ddl01Contractor').val(ID).trigger('change');
            },
        });
    };
    function fn01Status(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Status',
                'pPlaceHolder': 'Status',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl01Status").html(s);
                $('#ddl01Status').val(ID).trigger('change');
            },
        });
    };
    function fn02Category(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Category',
                'pPlaceHolder': 'Category',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl02Category").html(s);
                $('#ddl02Category').val(ID).trigger('change');
            },
        });
    };
    function fn02Project(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Project_COF',
                'pPlaceHolder': 'Project',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl02Project").html(s);
                $('#ddl02Project').val(ID).trigger('change');
            },
        });
    };
    function fn02Contractor(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB250000HND.ashx",
            data: {
                'pFunction': 'Dropdown',
                'pType': 'Get Record',
                'pTblName': 'Get_Contractor',
                'pPlaceHolder': 'Contractor',
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl02Contractor").html(s);
                $('#ddl02Contractor').val(ID).trigger('change');
            },
        });
    };
    //Filter - dropdown
};
//function - Header

//function - Chart
function fn01Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contractor-Amount'
        },
        success: function (response) {

            //variable
            const Contractor = response.map(i => i.Contractor);
            const Amount = response.map(i => i.ContractAmt);
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
                        '#008FFB',
                        '#00E396',
                        '#FEB019',
                        '#FF4560',
                        '#775DD0'
                    ];

                    const randomColors = Contractor.map((_, i) => baseColors[i % baseColors.length]);

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Contractor",
                            data: Amount
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
                                colors: ["#304758"]
                            }
                        },
                        colors: randomColors,
                        plotOptions: {
                            bar: {
                                distributed: true,
                                borderRadius: 5,
                                dataLabels: {
                                    position: 'top', // top, center, bottom
                                },
                            }
                        },
                        legend: {
                            show: false
                        },
                        xaxis: {
                            categories: Contractor,
                            labels: {
                                formatter: function (val) {
                                    return val.length > 12 ? val.substring(0, 12) + "..." : val;
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
                        },
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initChart01('#kt_bar_graph_001');
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
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Project-Status'
        },
        success: function (response) {

            //variable
            const Total = response.map(i => i.Total);
            const Status = response.map(i => i.Status);
            //variable

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
                            height: height,
                            width: '100%'
                        },
                        labels: Status,
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
                        initChart02('#kt_pie_graph_002');
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
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Unit-Batch'
        },
        success: function (response) {

            //variable
            const Unit = response.map(i => i.Unit);
            const BatchNo = response.map(i => i.BatchNo);
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
                            name: "Unit",
                            data: Unit
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
                                    minimumFractionDigits: 0,
                                    maximumFractionDigits: 2
                                })
                            },
                            offsetY: -20,
                            style: {
                                fontSize: '12px',
                                colors: ["#304758"]
                            }
                        },
                        plotOptions: {
                            bar: {
                                borderRadius: 5,
                                dataLabels: {
                                    position: 'top', // top, center, bottom
                                },
                            }
                        },
                        legend: {
                            show: false
                        },
                        xaxis: {
                            categories: BatchNo,
                            labels: {
                                formatter: function (val) {
                                    return val;
                                }
                            }
                        },
                        yaxis: {
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
                        initChart03('#kt_bar_graph_003');
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
function fn04Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contract-Trend'
        },
        success: function (response) {

            //variables
            const Month = response.map(i => i.Date);
            const Amount = response.map(i => i.AwardAmt);
            //variables

            var Chart04 = function () {

                var initChart04 = function () {
                    var element = document.getElementById("kt_line_graph_004");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                    var baseColor = KTUtil.getCssVariableValue('--bs-info');
                    var secondaryColor = KTUtil.getCssVariableValue('--bs-success');

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [ {
                            name: 'Amount',
                            data: Amount
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
                            categories: Month,
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
                                },
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
                            },
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
                        colors: ["#775DD0"],
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
                            strokeWidth: 2,
                            strokeColors: ["#775DD0"],
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
                        initChart04();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart04;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart04.init();
            });

        }

    });
};
function fn05Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contract-Batch'
        },
        success: function (response) {

            //variable
            const OSM = response.map(i => i.OSM);
            const Straight = response.map(i => i.Straight);
            const VariationOrder = response.map(i => i.VariationOrder);
            const Category = response.map(i => i.Date);
            //variable

            var Chart05 = function () {

                var initChart05 = function () {
                    var element = document.getElementById("kt_bar_graph_005");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var warningColor = KTUtil.getCssVariableValue('--bs-warning');
                    var infoColor = KTUtil.getCssVariableValue('--bs-info');
                    var darkColor = KTUtil.getCssVariableValue('--bs-dark');

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: 'OSM',
                            data: OSM
                        }, {
                            name: 'Straight',
                            data: Straight
                        }, {
                            name: 'Variation Order',
                            data: VariationOrder
                        }],
                        chart: {
                            type: 'bar',
                            height: 350
                        },
                        colors: [warningColor, darkColor, infoColor],
                        plotOptions: {
                            bar: {
                                horizontal: false,
                                columnWidth: '55%',
                                borderRadius: 5,
                                borderRadiusApplication: 'end'
                            },
                        },
                        dataLabels: {
                            enabled: false
                        },
                        stroke: {
                            show: true,
                            width: 2,
                            colors: ['transparent']
                        },
                        xaxis: {
                            categories: Category,
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
                        fill: {
                            opacity: 1
                        },
                        tooltip: {
                            y: {
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
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                };

                return {
                    init: function () {
                        initChart05();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart05;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart05.init();
            });

        }

    });
};
function fn06Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contract-Category'
        },
        success: function (response) {

            //variable
            const Category = response.map(i => i.Category);
            const Total = response.map(i => i.Total);
            //variable

            // Class definition
            var Chart06 = function () {

                // Private methods
                var initChart06 = function (chartSelector) {
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
                            height: height,
                            width: '100%'
                        },
                        labels: Category,
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
                        initChart06('#kt_donut_graph_006');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart06;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart06.init();
            });

        }

    });
};
function fn07Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contractor-Amount-COF'
        },
        success: function (response) {

            //variable
            const Contractor = response.map(i => i.Contractor);
            const ConPrice = response.map(i => i.ConPrice);
            //variable

            // Class definition
            var Chart07 = function () {

                // Private methods
                var initChart07 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);
                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                    //clear
                    element.innerHTML = "";
                    //clear

                    const baseColors = [
                        '#008FFB',
                        '#00E396',
                        '#FEB019',
                        '#FF4560',
                        '#775DD0'
                    ];

                    const randomColors = Contractor.map((_, i) => baseColors[i % baseColors.length]);

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Contractor",
                            data: ConPrice
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
                                colors: ["#304758"]
                            }
                        },
                        colors: randomColors,
                        plotOptions: {
                            bar: {
                                distributed: true,
                                borderRadius: 5,
                                dataLabels: {
                                    position: 'top', // top, center, bottom
                                },
                            }
                        },
                        legend: {
                            show: false
                        },
                        xaxis: {
                            categories: Contractor,
                            labels: {
                                formatter: function (val) {
                                    return val.length > 12 ? val.substring(0, 12) + "..." : val;
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
                        },
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initChart07('#kt_bar_graph_007');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart07;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart07.init();
            });

        }

    });
};
function fn08Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contract-Trend-COF'
        },
        success: function (response) {

            //variables
            const Month = response.map(i => i.DateAwarded);
            const Amount = response.map(i => i.AwardAmt);
            //variables

            var Chart04 = function () {

                var initChart04 = function () {
                    var element = document.getElementById("kt_line_graph_008");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');

                    var baseColor = KTUtil.getCssVariableValue('--bs-info');
                    var secondaryColor = KTUtil.getCssVariableValue('--bs-success');

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: 'Amount',
                            data: Amount
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
                            categories: Month,
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
                                },
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
                            },
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
                        colors: ["#775DD0"],
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
                            strokeWidth: 2,
                            strokeColors: ["#775DD0"],
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
                        initChart04();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart04;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart04.init();
            });

        }

    });
};
function fn09Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contract-Status'
        },
        success: function (response) {

            //variable
            const Status = response.map(i => i.Status);
            const Total = response.map(i => i.Total);
            //variable

            // Class definition
            var Chart09 = function () {

                // Private methods
                var initChart09 = function (chartSelector) {
                    var element = document.querySelector(chartSelector);
                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                    //clear
                    element.innerHTML = "";
                    //clear

                    const baseColors = [
                        '#008FFB',
                        '#00E396',
                        '#FEB019',
                        '#FF4560',
                        '#775DD0'
                    ];

                    const randomColors = Status.map((_, i) => baseColors[i % baseColors.length]);

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Contract Order",
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
                                colors: ["#304758"]
                            }
                        },
                        colors: randomColors,
                        plotOptions: {
                            bar: {
                                distributed: true,
                                borderRadius: 5,
                                horizontal: true,
                                dataLabels: {
                                    position: 'top', // top, center, bottom
                                },
                            }
                        },
                        legend: {
                            show: false
                        },
                        xaxis: {
                            categories: Status,
                            labels: {
                                formatter: function (val) {
                                    return val.length > 12 ? val.substring(0, 12) + "..." : val;
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
                        },
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                }

                // Public methods
                return {
                    init: function () {
                        initChart09('#kt_bar_graph_009');
                    }
                }
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart09;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart09.init();
            });

        }

    });
};
function fn10Chart() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': "DSB250000",
            'pType': 'Get-Contract-Batch-COF'
        },
        success: function (response) {

            //variable
            const OSM = response.map(i => i.OSM);
            const Straight = response.map(i => i.Straight);
            const VariationOrder = response.map(i => i.VariationOrder);
            const Category = response.map(i => i.Date);
            //variable

            var Chart05 = function () {

                var initChart05 = function () {
                    var element = document.getElementById("kt_bar_graph_010");

                    //clear
                    element.innerHTML = "";
                    //clear

                    var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                    var warningColor = KTUtil.getCssVariableValue('--bs-warning');
                    var infoColor = KTUtil.getCssVariableValue('--bs-info');
                    var darkColor = KTUtil.getCssVariableValue('--bs-dark');

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: 'OSM',
                            data: OSM
                        }, {
                            name: 'Straight',
                            data: Straight
                        }, {
                            name: 'Variation Order',
                            data: VariationOrder
                        }],
                        chart: {
                            type: 'bar',
                            height: 350
                        },
                        colors: [warningColor, darkColor, infoColor],
                        plotOptions: {
                            bar: {
                                horizontal: false,
                                columnWidth: '55%',
                                borderRadius: 5,
                                borderRadiusApplication: 'end'
                            },
                        },
                        dataLabels: {
                            enabled: false
                        },
                        stroke: {
                            show: true,
                            width: 2,
                            colors: ['transparent']
                        },
                        xaxis: {
                            categories: Category,
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
                        fill: {
                            opacity: 1
                        },
                        tooltip: {
                            y: {
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
                        }
                    };

                    var chart = new ApexCharts(element, options);
                    chart.render();

                };

                return {
                    init: function () {
                        initChart05();
                    }
                };
            }();

            // Webpack support
            if (typeof module !== 'undefined') {
                module.exports = Chart05;
            }

            // On document ready
            KTUtil.onDOMContentLoaded(function () {
                Chart05.init();
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
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': 'DSB250000',
            'pType': 'Get-Construction-Batch'
        },
        success: function (response) {
            grid01Api.setGridOption('rowData', response);
        },
        complete: function (response) {
            grid01Api.setGridOption('loading', false);
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
                        { colId: 'BatchNo', pinned: 'left' },
                        { colId: 'DateStart', pinned: 'right' },
                        { colId: 'DateEnd', pinned: 'right' }
                    ]
                });
            }
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressVerticalScroll: true,
        enableCellTextSelection: true,
        rowSelection: 'single',
        //popupParent: document.body,
        loading: true,
        columnDefs: [
            {
                headerName: "Batch No.",
                field: "BatchNo",
                lockPosition: true,
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "SINo",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Project",
                field: "Project",
                filter: 'agTextColumnFilter',
                width: 200,
                tooltipField: "Project"
            },
            {
                headerName: "Location",
                field: "Location",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "Location"
            },
            {
                headerName: "Contractor",
                field: "Contractor",
                filter: 'agTextColumnFilter',
                tooltipField: "Contractor",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Con. No.",
                field: "ConNo",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "ConNo"
            },
            {
                headerName: "Con. Price",
                field: "ConPrice",
                tooltipField: "ConPrice",
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
                headerName: "TCP Balance",
                field: "TCPBal",
                tooltipField: "TCPBal",
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
                headerName: "VAT",
                field: "VAT",
                tooltipField: "VAT",
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
                headerName: "EWT",
                field: "EWT",
                tooltipField: "EWT",
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
                headerName: "Retention Fee",
                field: "RF",
                tooltipField: "RF",
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
                headerName: "Date Start",
                field: "DateStart",
                filter: 'agTextColumnFilter',
                tooltipField: "DateStart",
                width: 120
            },
            {
                headerName: "Date End",
                field: "DateEnd",
                filter: 'agTextColumnFilter',
                tooltipField: "DateEnd",
                width: 120
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
        url: "Assets/Handler/DSB/DSB250000HND.ashx",
        data: {
            'pFormCode': 'DSB250000',
            'pType': 'Get-Contract-Order'
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
                        { colId: 'FormNo', pinned: 'left' }
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
        columnDefs: [
            {
                headerName: "Form No.",
                field: "FormNo",
                pinned: "left",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "FormNo",
                cellStyle: { fontWeight: 'bold' },
                onCellDoubleClicked: function (params) {
                    window.open("FRM000009-DTL-" + params.data.FormNo, '_blank').focus();
                }
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 180,
                tooltipField: "Status"
            },
            {
                headerName: "Con. No.",
                field: "ConNo",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "ConNo"
            },
            {
                headerName: "Contractor",
                field: "Contractor",
                filter: 'agTextColumnFilter',
                tooltipField: "Contractor",
                flex: 1,
                minWidth: 350,
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Con. Type",
                field: "ConType",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "ConType"
            },
            {
                headerName: "Project",
                field: "Project",
                filter: 'agTextColumnFilter',
                width: 200,
                tooltipField: "Project"
            },
            {
                headerName: "Con. Status",
                field: "ContractStatus",
                filter: 'agTextColumnFilter',
                width: 180,
                tooltipField: "ContractStatus"
            },
            {
                headerName: "Category",
                field: "Category",
                filter: 'agTextColumnFilter',
                tooltipField: "Category",
                width: 180
            },
            {
                headerName: "Con. Price",
                field: "ContractPrice",
                tooltipField: "ContractPrice",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.ContractPrice) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "TCP Balance",
                field: "TCPBal",
                tooltipField: "TCPBal",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.TCPBal) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "VAT",
                field: "VAT",
                tooltipField: "VAT",
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
                headerName: "EWT",
                field: "EWT",
                tooltipField: "EWT",
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
                headerName: "Retention Fee",
                field: "RF",
                tooltipField: "RF",
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
                headerName: "Date Awarded",
                field: "DateAwarded",
                filter: 'agTextColumnFilter',
                tooltipField: "DateAwarded",
                width: 150
            },
            {
                headerName: "Appr. Date",
                field: "ApprDate",
                filter: 'agTextColumnFilter',
                tooltipField: "ApprDate",
                width: 150
            }
        ],
        rowData: [],
        pagination: false,
    };

    grid02Api = agGrid.createGrid(gridDiv, gridOptions);
};
//function - Table

//function - Filter
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
    async function Filter_Ok_Await(Btn) {
        // process
        try {

            //variable
            var pBatch = document.getElementById("ddl01Batch").options[document.getElementById("ddl01Batch").selectedIndex].value;
            var pProject = document.getElementById("ddl01Project").options[document.getElementById("ddl01Project").selectedIndex].value;
            var pContractor = document.getElementById("ddl01Contractor").options[document.getElementById("ddl01Contractor").selectedIndex].value;
            var pStatus = document.getElementById("ddl01Status").options[document.getElementById("ddl01Status").selectedIndex].value;
            //variable

            //filter
            await Promise.all([
                fn01Chart(pBatch, pProject, pContractor, pStatus),
                fn02Chart(pBatch, pProject, pContractor, pStatus),
                fn03Chart(pProject),
                fn04Chart(pBatch, pProject, pContractor, pStatus),
                fn05Chart(pBatch, pProject, pContractor, pStatus),
                fn01Table(pBatch, pProject, pContractor, pStatus)
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
        //loader
        function fn00Loader(id) {
            var element = document.querySelector(id);
            if (!element) return;

            element.innerHTML = `
                <div style="display:flex;align-items:center;justify-content:center;height:100%;">
                    <div class="spinner-border text-primary" role="status"></div>
                </div>
            `;
        };
        function fn01Chart(pBatch, pProject, pContractor, pStatus) {
            //loader
            fn00Loader("#kt_bar_graph_001");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contractor-Filter',
                    pBatchNo: pBatch,
                    pProject: pProject,
                    pContractor: pContractor,
                    pStatus: pStatus
                }
            }).done(function (response) {

                const Contractor = response.map(i => i.Contractor);
                const Amount = response.map(i => i.ContractAmt);

                const baseColors = [
                    '#008FFB',
                    '#00E396',
                    '#FEB019',
                    '#FF4560',
                    '#775DD0'
                ];

                const randomColors = Contractor.map((_, i) => baseColors[i % baseColors.length]);
                var element = document.querySelector('#kt_bar_graph_001');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: "Contractor",
                        data: Amount
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
                            colors: ["#304758"]
                        }
                    },
                    colors: randomColors,
                    plotOptions: {
                        bar: {
                            distributed: true,
                            borderRadius: 5,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            },
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: Contractor,
                        labels: {
                            formatter: function (val) {
                                return val.length > 12 ? val.substring(0, 12) + "..." : val;
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
                    },
                });

                chart.render();
            });
        };
        function fn02Chart(pBatch, pProject, pContractor, pStatus) {
            //loader
            fn00Loader("#kt_pie_graph_002")

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Project-Filter',
                    pBatchNo: pBatch,
                    pProject: pProject,
                    pContractor: pContractor,
                    pStatus: pStatus
                }
            }).done(function (response) {

                const Total = response.map(i => i.Total);
                const Status = response.map(i => i.Status);

                var element = document.querySelector('#kt_pie_graph_002');
                element.innerHTML = "";

                var height = parseInt(KTUtil.css(element, 'height'));

                var chart = new ApexCharts(element, {
                    series: Total,
                    chart: {
                        type: 'donut',
                        height: height,
                        width: '100%'
                    },
                    labels: Status,
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
                });

                chart.render();
            });
        };
        function fn03Chart(pProject) {
            //loader
            fn00Loader("#kt_bar_graph_003");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Unit-Filter',
                    pProject: pProject
                }
            }).done(function (response) {

                //variable
                const Unit = response.map(i => i.Unit);
                const BatchNo = response.map(i => i.BatchNo);
                //variable

                var element = document.querySelector('#kt_bar_graph_003');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: "Unit",
                        data: Unit
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
                                minimumFractionDigits: 0,
                                maximumFractionDigits: 2
                            })
                        },
                        offsetY: -20,
                        style: {
                            fontSize: '12px',
                            colors: ["#304758"]
                        }
                    },
                    plotOptions: {
                        bar: {
                            borderRadius: 5,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            },
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: BatchNo,
                        labels: {
                            formatter: function (val) {
                                return val;
                            }
                        }
                    },
                    yaxis: {
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
                        x: {
                            formatter: function (val) {
                                return val;
                            }
                        }
                    },
                });

                chart.render();
            });
        };
        function fn04Chart(pBatch, pProject, pContractor, pStatus) {
            //loader
            fn00Loader("#kt_line_graph_004")

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contract-Filter',
                    pBatchNo: pBatch,
                    pProject: pProject,
                    pContractor: pContractor,
                    pStatus: pStatus
                }
            }).done(function (response) {

                //variables
                const Month = response.map(i => i.Date);
                const Amount = response.map(i => i.AwardAmt);
                //variables

                var element = document.querySelector('#kt_line_graph_004');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-info');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-success');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: 'Amount',
                        data: Amount
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
                        categories: Month,
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
                            },
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
                        },
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
                    colors: ["#775DD0"],
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
                        strokeWidth: 2,
                        strokeColors: ["#775DD0"],
                        fillOpacity: 1,
                        colors: ['#ffffff'],
                        hover: {
                            size: 7
                        }
                    }
                });

                chart.render();
            });
        };
        function fn05Chart(pBatch, pProject, pContractor, pStatus) {
            //loader
            fn00Loader("#kt_bar_graph_005");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Batch-Filter',
                    pBatchNo: pBatch,
                    pProject: pProject,
                    pContractor: pContractor,
                    pStatus: pStatus
                }
            }).done(function (response) {

                //variable
                const OSM = response.map(i => i.OSM);
                const Straight = response.map(i => i.Straight);
                const VariationOrder = response.map(i => i.VariationOrder);
                const Category = response.map(i => i.Date);
                //variable

                var element = document.querySelector('#kt_bar_graph_005');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var warningColor = KTUtil.getCssVariableValue('--bs-warning');
                var infoColor = KTUtil.getCssVariableValue('--bs-info');
                var darkColor = KTUtil.getCssVariableValue('--bs-dark');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: 'OSM',
                        data: OSM
                    }, {
                        name: 'Straight',
                        data: Straight
                    }, {
                        name: 'Variation Order',
                        data: VariationOrder
                    }],
                    chart: {
                        type: 'bar',
                        height: 350
                    },
                    colors: [warningColor, darkColor, infoColor],
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '55%',
                            borderRadius: 5,
                            borderRadiusApplication: 'end'
                        },
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: Category,
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
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
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
                    }
                });

                chart.render();
            });
        };
        function fn01Table(pBatch, pProject, pContractor, pStatus) {
            //Ajax
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Construction-Filter',
                    pBatchNo: pBatch,
                    pProject: pProject,
                    pContractor: pContractor,
                    pStatus: pStatus
                },
                success: function (response) {
                    grid01Api.setGridOption('rowData', response);
                },
                complete: function (response) {
                    grid01Api.setGridOption('loading', false);
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
                                { colId: 'BatchNo', pinned: 'left' },
                                { colId: 'Status', pinned: 'right' }
                            ]
                        });
                    }
                },
                theme: gridTheme,
                suppressCellFocus: true,
                suppressVerticalScroll: true,
                enableCellTextSelection: true,
                rowSelection: 'single',
                //popupParent: document.body,
                loading: true,
                columnDefs: [
                    {
                        headerName: "Batch No.",
                        field: "BatchNo",
                        lockPosition: true,
                        pinned: "left",
                        filter: 'agTextColumnFilter',
                        width: 150,
                        tooltipField: "SINo",
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Project",
                        field: "Project",
                        filter: 'agTextColumnFilter',
                        width: 200,
                        tooltipField: "Project"
                    },
                    {
                        headerName: "Location",
                        field: "Location",
                        filter: 'agTextColumnFilter',
                        width: 150,
                        tooltipField: "Location"
                    },
                    {
                        headerName: "Contractor",
                        field: "Contractor",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Contractor",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Con. No.",
                        field: "ConNo",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "ConNo"
                    },
                    {
                        headerName: "Con. Price",
                        field: "ConPrice",
                        tooltipField: "ConPrice",
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
                        headerName: "VAT",
                        field: "VAT",
                        tooltipField: "VAT",
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
                        headerName: "EWT",
                        field: "EWT",
                        tooltipField: "EWT",
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
                        headerName: "Retention Fee",
                        field: "RF",
                        tooltipField: "RF",
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
                        headerName: "Date Start",
                        field: "DateStart",
                        filter: 'agTextColumnFilter',
                        tooltipField: "DateStart",
                        width: 180
                    },
                    {
                        headerName: "Date End",
                        field: "DateEnd",
                        filter: 'agTextColumnFilter',
                        tooltipField: "DateEnd",
                        width: 180
                    },
                    {
                        headerName: "Status",
                        field: "Status",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Status",
                        width: 150,
                        pinned: "right",
                        cellRenderer: params => {
                            var span = "";
                            if (params.value != "") {
                                if (params.value == "Assign") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>${params.value}</span></div>`;
                                } else if (params.value == "Clarify") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>${params.value}</span></div>`;
                                } else if (params.value == "Close") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-danger border border-danger fs-base'>${params.value}</span></div>`;
                                } else if (params.value == "Complete") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-success border border-success fs-base'>${params.value}</span></div>`;
                                } else if (params.value == "Not Started") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-warning border border-warning fs-base'>${params.value}</span></div>`;
                                } else if (params.value == "On-Going") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-info border border-info fs-base'>${params.value}</span></div>`;
                                } else if (params.value == "On-Hold") {
                                    span = `<div class='d-flex justify-content-center mt-2'><span class='badge badge-light-warning border border-warning fs-base'>${params.value}</span></div>`;
                                };
                            };
                            return span;
                        },
                    }
                ],
                rowData: [],
                pagination: false,
            };
            grid01Api = agGrid.createGrid(gridDiv, gridOptions);
        };
    };
};
function fn01Clear_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission

    //clear
    $('#ddl01Batch').val('').trigger('change');
    $('#ddl01Project').val('').trigger('change');
    $('#ddl01Contractor').val('').trigger('change');
    $('#ddl01Status').val('').trigger('change');
    //clear

    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = false;
    // Hide loading indication
    Btn.removeAttribute('data-kt-indicator');
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
        // process
        try {

            //variable
            var pCategory = document.getElementById("ddl02Category").options[document.getElementById("ddl02Category").selectedIndex].value;
            var pProject = document.getElementById("ddl02Project").options[document.getElementById("ddl02Project").selectedIndex].value;
            var pContractor = document.getElementById("ddl02Contractor").options[document.getElementById("ddl02Contractor").selectedIndex].value;
            //variable

            //filter
            await Promise.all([
                fn06Chart(pCategory, pProject, pContractor),
                fn07Chart(pCategory, pProject, pContractor),
                fn08Chart(pCategory, pProject, pContractor),
                fn09Chart(pCategory, pProject, pContractor),
                fn10Chart(pCategory, pProject, pContractor),
                fn02Table(pCategory, pProject, pContractor)
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
        //loader
        function fn00Loader(id) {
            var element = document.querySelector(id);
            if (!element) return;

            element.innerHTML = `
                <div style="display:flex;align-items:center;justify-content:center;height:100%;">
                    <div class="spinner-border text-primary" role="status"></div>
                </div>
            `;
        };
        function fn06Chart(pCategory, pProject, pContractor) {
            //loader
            fn00Loader("#kt_donut_graph_006");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contract-Category-Filter',
                    pCategory: pCategory,
                    pProject: pProject,
                    pContractor: pContractor
                }
            }).done(function (response) {

                const Total = response.map(i => i.Total);
                const Category = response.map(i => i.Category);

                var element = document.querySelector('#kt_donut_graph_006');
                element.innerHTML = "";

                var height = parseInt(KTUtil.css(element, 'height'));

                var chart = new ApexCharts(element, {
                    series: Total,
                    chart: {
                        type: 'donut',
                        height: height,
                        width: '100%'
                    },
                    labels: Category,
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
                });

                chart.render();
            });
        };
        function fn07Chart(pCategory, pProject, pContractor) {
            //loader
            fn00Loader("#kt_bar_graph_007");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contractor-Amount-COF-Filter',
                    pCategory: pCategory,
                    pProject: pProject,
                    pContractor: pContractor
                }
            }).done(function (response) {

                const Contractor = response.map(i => i.Contractor);
                const Amount = response.map(i => i.ConPrice);

                const baseColors = [
                    '#008FFB',
                    '#00E396',
                    '#FEB019',
                    '#FF4560',
                    '#775DD0'
                ];

                const randomColors = Contractor.map((_, i) => baseColors[i % baseColors.length]);
                var element = document.querySelector('#kt_bar_graph_007');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: "Contractor",
                        data: Amount
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
                            colors: ["#304758"]
                        }
                    },
                    colors: randomColors,
                    plotOptions: {
                        bar: {
                            distributed: true,
                            borderRadius: 5,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            },
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: Contractor,
                        labels: {
                            formatter: function (val) {
                                return val.length > 12 ? val.substring(0, 12) + "..." : val;
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
                    },
                });

                chart.render();
            });
        };
        function fn08Chart(pCategory, pProject, pContractor) {
            //loader
            fn00Loader("#kt_line_graph_008")

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contract-Trend-COF-Filter',
                    pCategory: pCategory,
                    pProject: pProject,
                    pContractor: pContractor
                }
            }).done(function (response) {

                //variables
                const Month = response.map(i => i.DateAwarded);
                const Amount = response.map(i => i.AwardAmt);
                //variables

                var element = document.querySelector('#kt_line_graph_008');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var borderColor = KTUtil.getCssVariableValue('--bs-gray-200');
                var baseColor = KTUtil.getCssVariableValue('--bs-info');
                var secondaryColor = KTUtil.getCssVariableValue('--bs-success');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: 'Amount',
                        data: Amount
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
                        categories: Month,
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
                            },
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
                        },
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
                    colors: ["#775DD0"],
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
                        strokeWidth: 2,
                        strokeColors: ["#775DD0"],
                        fillOpacity: 1,
                        colors: ['#ffffff'],
                        hover: {
                            size: 7
                        }
                    }
                });

                chart.render();
            });
        };
        function fn09Chart(pCategory, pProject, pContractor) {
            //loader
            fn00Loader("#kt_bar_graph_009");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contract-Status-Filter',
                    pCategory: pCategory,
                    pProject: pProject,
                    pContractor: pContractor
                }
            }).done(function (response) {

                //variable
                const Status = response.map(i => i.Status);
                const Total = response.map(i => i.Total);
                //variable

                const baseColors = [
                    '#008FFB',
                    '#00E396',
                    '#FEB019',
                    '#FF4560',
                    '#775DD0'
                ];

                const randomColors = Status.map((_, i) => baseColors[i % baseColors.length]);

                var element = document.querySelector('#kt_bar_graph_009');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: "Contract Order",
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
                            colors: ["#304758"]
                        }
                    },
                    colors: randomColors,
                    plotOptions: {
                        bar: {
                            distributed: true,
                            borderRadius: 5,
                            horizontal: true,
                            dataLabels: {
                                position: 'top', // top, center, bottom
                            },
                        }
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: Status,
                        labels: {
                            formatter: function (val) {
                                return val.length > 12 ? val.substring(0, 12) + "..." : val;
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
                    },
                });

                chart.render();
            });
        };
        function fn10Chart(pCategory, pProject, pContractor) {
            //loader
            fn00Loader("#kt_bar_graph_010");

            //return
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contract-Batch-COF-Filter',
                    pCategory: pCategory,
                    pProject: pProject,
                    pContractor: pContractor
                }
            }).done(function (response) {

                //variable
                const OSM = response.map(i => i.OSM);
                const Straight = response.map(i => i.Straight);
                const VariationOrder = response.map(i => i.VariationOrder);
                const Category = response.map(i => i.Date);
                //variable

                var element = document.querySelector('#kt_bar_graph_010');
                element.innerHTML = "";
                var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
                var warningColor = KTUtil.getCssVariableValue('--bs-warning');
                var infoColor = KTUtil.getCssVariableValue('--bs-info');
                var darkColor = KTUtil.getCssVariableValue('--bs-dark');

                var chart = new ApexCharts(element, {
                    series: [{
                        name: 'OSM',
                        data: OSM
                    }, {
                        name: 'Straight',
                        data: Straight
                    }, {
                        name: 'Variation Order',
                        data: VariationOrder
                    }],
                    chart: {
                        type: 'bar',
                        height: 350
                    },
                    colors: [warningColor, darkColor, infoColor],
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '55%',
                            borderRadius: 5,
                            borderRadiusApplication: 'end'
                        },
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    xaxis: {
                        categories: Category,
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
                    fill: {
                        opacity: 1
                    },
                    tooltip: {
                        y: {
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
                    }
                });

                chart.render();
            });
        };
        function fn02Table(pCategory, pProject, pContractor) {
            //Ajax
            return $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB250000HND.ashx",
                data: {
                    pFormCode: 'DSB250000',
                    pType: 'Get-Contract-Order-Filter',
                    pCategory: pCategory,
                    pProject: pProject,
                    pContractor: pContractor
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
                                { colId: 'FormNo', pinned: 'left' }
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
                columnDefs: [
                    {
                        headerName: "Form No.",
                        field: "FormNo",
                        pinned: "left",
                        filter: 'agTextColumnFilter',
                        width: 150,
                        tooltipField: "FormNo",
                        cellStyle: { fontWeight: 'bold' },
                        onCellDoubleClicked: function (params) {
                            window.open("FRM000009-DTL-" + params.data.FormNo, '_blank').focus();
                        }
                    },
                    {
                        headerName: "Status",
                        field: "Status",
                        filter: 'agTextColumnFilter',
                        width: 180,
                        tooltipField: "Status"
                    },
                    {
                        headerName: "Con. No.",
                        field: "ConNo",
                        filter: 'agTextColumnFilter',
                        width: 150,
                        tooltipField: "ConNo"
                    },
                    {
                        headerName: "Contractor",
                        field: "Contractor",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Contractor",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: { fontWeight: 'bold' }
                    },
                    {
                        headerName: "Con. Type",
                        field: "ConType",
                        filter: 'agTextColumnFilter',
                        width: 120,
                        tooltipField: "ConType"
                    },
                    {
                        headerName: "Project",
                        field: "Project",
                        filter: 'agTextColumnFilter',
                        width: 200,
                        tooltipField: "Project"
                    },
                    {
                        headerName: "Con. Status",
                        field: "ContractStatus",
                        filter: 'agTextColumnFilter',
                        width: 180,
                        tooltipField: "ContractStatus"
                    },
                    {
                        headerName: "Category",
                        field: "Category",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Category",
                        width: 180
                    },
                    {
                        headerName: "Con. Price",
                        field: "ContractPrice",
                        tooltipField: "ContractPrice",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.ContractPrice) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "TCP Balance",
                        field: "TCPBal",
                        tooltipField: "TCPBal",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (isNaN(value)) {
                                value = parseFloat(params.data.TCPBal) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "VAT",
                        field: "VAT",
                        tooltipField: "VAT",
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
                        headerName: "EWT",
                        field: "EWT",
                        tooltipField: "EWT",
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
                        headerName: "Retention Fee",
                        field: "RF",
                        tooltipField: "RF",
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
                        headerName: "Date Awarded",
                        field: "DateAwarded",
                        filter: 'agTextColumnFilter',
                        tooltipField: "DateAwarded",
                        width: 150
                    },
                    {
                        headerName: "Appr. Date",
                        field: "ApprDate",
                        filter: 'agTextColumnFilter',
                        tooltipField: "ApprDate",
                        width: 150
                    }
                ],
                rowData: [],
                pagination: false,
            };

            grid02Api = agGrid.createGrid(gridDiv, gridOptions);
        };
    };
};
//function - Filter

//function - Export
function fn01Export() {
    if (grid01Api) {
        grid01Api.exportDataAsCsv({
            fileName: 'Construction Batches.csv',
            columnKeys: ['BatchNo', 'Project', 'Location', 'Contractor', 'ConNo', 'ConPrice', 'VAT', 'EWT', 'RF', 'DateStart', 'DateEnd', 'Status']
        });
    }
};
function fn02Export() {
    if (grid02Api) {
        grid02Api.exportDataAsCsv({
            fileName: 'Job Order & Construction Repair.csv',
            columnKeys: ['FormNo', 'Status' ,'ConNo', 'Contractor', 'ConType', 'Project', 'ContractStatus', 'Category', 'ContractPrice', 'TCPBal', 'VAT', 'EWT', 'RF', 'DateAwarded', 'ApprDate']
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