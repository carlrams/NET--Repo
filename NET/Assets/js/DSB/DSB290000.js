//general
function fn01Load() {
    fnAccess('DSB290000', 'View', function (response) {
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
        url: "Assets/Handler/DSB/DSB290000HND.ashx",
        data: {
            'pFormCode': 'DSB290000',
            'pType': 'Get-Cost-Header'
        },
        success: function (response) {
            const valFormat = new Intl.NumberFormat('en-PH', {
                style: 'currency',
                currency: 'PHP',
                notation: 'compact',
                compactDisplay: 'short',
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            });
            const Project = new countUp.CountUp(document.getElementById("h01Project"), response[0].Project, {
                decimalPlaces: 0,
                duration: 3,
                useGrouping: true,
                separator: ',',
                decimal: '.',
                prefix: '',
                suffix: ''
            });
            const Budget = new countUp.CountUp(
                document.getElementById("h01Budget"),
                response[0].Budget,
                {
                    duration: 3,
                    useGrouping: true,
                    formattingFn: (value) => valFormat.format(value)
                }
            );
            const Cost = new countUp.CountUp(
                document.getElementById("h01Cost"),
                response[0].Cost,
                {
                    duration: 3,
                    useGrouping: true,
                    formattingFn: (value) => valFormat.format(value)
                }
            );
            const CostScope = new countUp.CountUp(
                document.getElementById("h01CostScope"),
                response[0].CostScope,
                {
                    duration: 3,
                    useGrouping: true,
                    formattingFn: (value) => valFormat.format(value)
                }
            );

            if (!Project.error && !Budget.error && !Cost.error && !CostScope.error) {
                Project.start();
                Budget.start();
                Cost.start();
                CostScope.start();
            };
        }
    });
};
//function - Header

//function - Chart
function fn01Chart() {
    //loader
    fn00Loader("#kt_bar_graph_001");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB290000HND.ashx",
        data: {
            'pFormCode': "DSB290000",
            'pType': 'Get-Project-Division'
        },
        success: function (response) {

            //variable
            const Division = response.map(i => i.Division);
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
                        '#008FFB',
                        '#00E396',
                        '#FEB019',
                        '#FF4560',
                        '#775DD0'
                    ];

                    const randomColors = Division.map((_, i) => baseColors[i % baseColors.length]);

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
                                    position: 'top',
                                },
                            }
                        },
                        legend: {
                            show: false
                        },
                        xaxis: {
                            categories: Division,
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
    //loader
    fn00Loader("#kt_pie_graph_002");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB290000HND.ashx",
        data: {
            'pFormCode': "DSB290000",
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
    //loader
    fn00Loader("#kt_line_graph_003");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB290000HND.ashx",
        data: {
            'pFormCode': "DSB290000",
            'pType': 'Get-Monthly-Construction'
        },
        success: function (response) {

            //variable
            const MonthName = response.map(i => i.MonthName);
            const Total = response.map(i => i.Total);
            //variable

            var Chart03 = function () {

                var initChart03 = function () {
                    var element = document.getElementById("kt_line_graph_003");

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
                            name: 'Projects',
                            data: Total
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
                            categories: MonthName,
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
                        initChart03();
                    }
                };
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
    //loader
    fn00Loader("#kt_bar_graph_003");

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB290000HND.ashx",
        data: {
            'pFormCode': "DSB290000",
            'pType': 'Get-Estimate-Category'
        },
        success: function (response) {

            //variable
            const Category = response.map(i => i.Category);
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
                        '#008FFB',
                        '#00E396',
                        '#FEB019',
                        '#FF4560',
                        '#775DD0'
                    ];

                    const randomColors = Category.map((_, i) => baseColors[i % baseColors.length]);

                    if (!element) {
                        return;
                    }

                    var options = {
                        series: [{
                            name: "Category",
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
                            categories: Category,
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
                        initChart01('#kt_bar_graph_003');
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
function fn05Chart() {

    // Class definition
    var Chart05 = function () {

        // Private methods
        var initChart05 = function (chartSelector) {
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
                    name: 'Budget',
                    data: [44, 55, 57, 56]
                }, {
                    name: 'Cost',
                    data: [76, 85, 101, 98]
                }],
                chart: {
                    type: 'bar',
                    height: 350
                },
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
                    categories: ['Infrastructure', 'Residential', 'Commercial', 'Industrial'],
                },
                fill: {
                    opacity: 1
                },
                tooltip: {
                    y: {
                        formatter: function (val) {
                            return val 
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
                initChart05('#kt_bar_graph_005');
            }
        }
    }();

    // Webpack support
    if (typeof module !== 'undefined') {
        module.exports = Chart01;
    }

    // On document ready
    KTUtil.onDOMContentLoaded(function () {
        Chart05.init();
    });

};
function fn06Chart() {

    // Class definition
    var Chart06 = function () {

        // Private methods
        var initChart06 = function (chartSelector) {
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
                    data: [44, 55, 41]
                }, {
                    data: [53, 32, 33]
                }],
                chart: {
                    type: 'bar',
                    height: 430
                },
                plotOptions: {
                    bar: {
                        horizontal: true,
                        dataLabels: {
                            position: 'top',
                        },
                    }
                },
                dataLabels: {
                    enabled: true,
                    offsetX: -6,
                    style: {
                        fontSize: '12px',
                        colors: ['#fff']
                    }
                },
                stroke: {
                    show: true,
                    width: 1,
                    colors: ['#fff']
                },
                tooltip: {
                    shared: true,
                    intersect: false
                },
                xaxis: {
                    categories: ['Quezon', 'Batangas', 'Laguna'],
                },
            };

            var chart = new ApexCharts(element, options);
            chart.render();

        }

        // Public methods
        return {
            init: function () {
                initChart06('#kt_bar_graph_006');
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

};
function fn07Chart() {

    // Class definition
    var Chart07 = function () {

        // Private methods
        var initChart07 = function (chartSelector) {
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
                    name: 'Cost',
                    type: 'column',
                    data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
                }, {
                    name: 'Awarded Projects',
                    type: 'line',
                    data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
                }],
                chart: {
                    height: 350,
                    type: 'line',
                },
                stroke: {
                    width: [0, 4]
                },
                dataLabels: {
                    enabled: true,
                    enabledOnSeries: [1]
                },
                labels: ['01 Jan 2001', '02 Jan 2001', '03 Jan 2001', '04 Jan 2001', '05 Jan 2001', '06 Jan 2001', '07 Jan 2001', '08 Jan 2001', '09 Jan 2001', '10 Jan 2001', '11 Jan 2001', '12 Jan 2001'],
                yaxis: [{
                    title: {
                        text: 'Website Blog',
                    },

                }, {
                    opposite: true,
                    title: {
                        text: 'Social Media'
                    }
                }]
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

};
function fn08Chart() {

    // Class definition
    var Chart08 = function () {

        // Private methods
        var initChart08 = function (chartSelector) {
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
                    name: 'Budget',
                    data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
                }, {
                    name: 'Cost',
                    data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
                }],
                chart: {
                    type: 'bar',
                    height: 350
                },
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
                    categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
                },
                yaxis: {
                    title: {
                        text: '$ (thousands)'
                    }
                },
                fill: {
                    opacity: 1
                },
                tooltip: {
                    y: {
                        formatter: function (val) {
                            return "$ " + val + " thousands"
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
                initChart08('#kt_bar_graph_008');
            }
        }
    }();

    // Webpack support
    if (typeof module !== 'undefined') {
        module.exports = Chart08;
    }

    // On document ready
    KTUtil.onDOMContentLoaded(function () {
        Chart08.init();
    });

};
function fn09Chart() {

    // Class definition
    var Chart09 = function () {

        // Private methods
        var initChart09 = function (chartSelector) {
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
                    name: 'Project',
                    data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
                }],
                chart: {
                    type: 'bar',
                    height: 350
                },
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
                    categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
                },
                fill: {
                    opacity: 1
                },
                tooltip: {
                    y: {
                        formatter: function (val) {
                            return val
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
                initChart09('#kt_bar_graph_009');
            }
        }
    }();

    // Webpack support
    if (typeof module !== 'undefined') {
        module.exports = Chart09;
    };

    // On document ready
    KTUtil.onDOMContentLoaded(function () {
        Chart09.init();
    });

};
//function - Chart

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