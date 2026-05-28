var FormCode = 'DSB140000'
var DeptCode = [];
let currentMode = 'monthly';
let chart;
//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        fn01Plugins();
        GetDeptCode();
        fn01load();


    });

};
//master

function GetDeptCode() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-DeptCode'
        },
        success: function (response) {
            console.log(response)

                DeptCode = response.map(r => r.DeptCode); 
 
            fn02Load();
        }

    });
};

function fn01load() {
    fnAccess('DSB140000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            fn02Load();
        } else {
            location.replace("MNU000022");
        };
    });
 
};

function fn02Refresh() {
    fn02Load();
};


//page
function fn02Load() {

    Load();
    Load2();
    Load3();
    Load4();

    function Load() {

        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Get-Record-01',
               'pDeptCode': DeptCode.join(',')
            },
            success: function (response) {

                //table
                $('#tbl01Record').DataTable().destroy();
                DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
                DataTable.datetime('MM/DD/YYYY');
                var tbl01Record = $("#tbl01Record").DataTable({
                    processing: true,
                    bFilter: true,
                    bPaginate: true,
                    bInfo: true,
                    paging: true,
                    lengthChange: true,
                    pageLength: 10,
                    select: true,
                    data: response,
                    columns: [
                        { data: 'RefNo' },
                        { data: 'DateReceive' },
                        { data: 'DocumentNo' },
                        { data: 'DocumentTitle' },
                        { data: 'DocumentType' },
                        { data: 'RevisionNo' },
                        { data: 'Dept' },
                        { data: 'DescriptionChange' },
                        { data: 'TargetDate' },
                        { data: 'DateCompletionEnd' },
                        { data: 'Tat' },
                        { data: 'Status' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, className: 'tbody-nowrap-auto' },
                        { targets: 1, className: 'tbody-nowrap-auto' },
                        { targets: 2, className: 'tbody-nowrap-auto' },
                        { targets: 3, className: 'tbody-nowrap-auto' },
                        { targets: 4, className: 'tbody-nowrap-auto' },
                        { targets: 5, className: 'tbody-nowrap-auto' },
                        { targets: 6, className: 'tbody-nowrap-auto' },
                        { targets: 7, className: 'tbody-nowrap-auto' },
                        { targets: 8, className: 'tbody-nowrap-auto' },
                        { targets: 9, className: 'tbody-nowrap-auto' },
                        { targets: 10, className: 'tbody-nowrap-auto' },
                        { targets: 11, className: 'tbody-nowrap-auto' }],
                    order: [[1, 'desc']],

                });
                $('#tbx01Find').on('keyup', function () { tbl01Record.search(this.value).draw(); });
                $('#tbl01Record tbody').on('dblclick', 'tr', function () {

                    var table = $('#tbl01Record').DataTable();
                    var row = table.row(this);

                    // Ensure row is selected
                    if (!row.node()) return;

                    var rowId = row.id(); // gets value from rowId: 'rowId'

                    if (rowId) {
                        var url = 'FRM000044-DTL-' + rowId;
                        window.open(url, '_blank');
                    }
                });
            },
        });
    };

    function Load2() {

        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Get-Record-02',
                'pDeptCode': DeptCode.join(',')
            },
            success: function (response) {
       
                document.querySelector("#PolarAreaCreation").innerHTML = "";
                var totalCreation =
                    Number(response[0].CreationPolicy) +
                    Number(response[0].CreationGuideline) +
                    Number(response[0].CreationProcedure) +
                    Number(response[0].CreationWorkInstruction) +
                    Number(response[0].CreationForm) +
                    Number(response[0].CreationManual);

                document.getElementById("polarTotalCreation").innerText = "TOTAL: " +
                    totalCreation + " / " + Number(response[0].Total);
                var options = {
                    series: [
                        Number(response[0].CreationPolicy),
                        Number(response[0].CreationGuideline),
                        Number(response[0].CreationProcedure),
                        Number(response[0].CreationWorkInstruction),
                        Number(response[0].CreationForm),
                        Number(response[0].CreationManual)
                    ],
                    yaxis: {
                        show: false
                    },
                    stroke: {
                        width: 1,
                        colors: undefined
                    },
                    chart: {
                        type: 'polarArea',
                        height: 220,
                        width: '100%',
                    },
                    labels: [
                        "Policy (" + response[0].CreationPolicy + ")",
                        "Guideline (" + response[0].CreationGuideline + ")",
                        "Procedure (" + response[0].CreationProcedure + ")",
                        "Work Instruction (" + response[0].CreationWorkInstruction + ")",
                        "Form (" + response[0].CreationForm + ")",
                        "Manual (" + response[0].CreationManual + ")"
                    ],
                    fill: {
                        opacity: 0.8
                    },
                    legend: {
                        position: 'right'
                    },
                    theme: {
                        monochrome: {
                            enabled: true,
                            color: '#3B82F6',
                            shadeTo: 'light',
                            shadeIntensity: 0.6
                        }
                    },
                    responsive: [{
                        breakpoint: 480,
                        options: {
                            chart: {
                                height: 250
                            },
                            legend: {
                                position: 'bottom'
                            }
                        }
                    }]
                };

                var chart = new ApexCharts(document.querySelector("#PolarAreaCreation"), options);
                chart.render();

                var totalRevision =
                    Number(response[0].RevisionPolicy) +
                    Number(response[0].RevisionGuideline) +
                    Number(response[0].RevisionProcedure) +
                    Number(response[0].RevisionWorkInstruction) +
                    Number(response[0].RevisionForm) +
                    Number(response[0].RevisionManual);

                document.getElementById("polarTotalRevision").innerText = "TOTAL: " +
                    totalRevision + " / " + Number(response[0].Total);
                document.querySelector("#PolarAreaRevision").innerHTML = "";
                var options = {
                    series: [
                        Number(response[0].RevisionPolicy),
                        Number(response[0].RevisionGuideline),
                        Number(response[0].RevisionProcedure),
                        Number(response[0].RevisionWorkInstruction),
                        Number(response[0].RevisionForm),
                        Number(response[0].RevisionManual)
                    ],
                    yaxis: {
                        show: false
                    },
                    stroke: {
                        width: 1,
                        colors: undefined
                    },
                    chart: {
                        type: 'polarArea',
                        height: 220,
                        width: '100%',
                    },
                    labels: [
                        "Policy (" + response[0].RevisionPolicy + ")",
                        "Guideline (" + response[0].RevisionGuideline + ")",
                        "Procedure (" + response[0].RevisionProcedure + ")",
                        "Work Instruction (" + response[0].RevisionWorkInstruction + ")",
                        "Form (" + response[0].RevisionForm + ")",
                        "Manual (" + response[0].RevisionManual + ")"
                    ],
                    fill: {
                        opacity: 0.8
                    },
                    legend: {
                        position: 'right'
                    },
                    theme: {
                        monochrome: {
                            enabled: true,
                            color: '#3B82F6',
                            shadeTo: 'light',
                            shadeIntensity: 0.6
                        }
                    },
                    responsive: [{
                        breakpoint: 480,
                        options: {
                            chart: {
                                height: 250
                            },
                            legend: {
                                position: 'bottom'
                            }
                        }
                    }]
                };

                var chart = new ApexCharts(document.querySelector("#PolarAreaRevision"), options);
                chart.render();

                document.querySelector("#PolarAreaObsoletion").innerHTML = "";
                var totalObsoletion =
                    Number(response[0].ObsoletionPolicy) +
                    Number(response[0].ObsoletionGuideline) +
                    Number(response[0].ObsoletionProcedure) +
                    Number(response[0].ObsoletionWorkInstruction) +
                    Number(response[0].ObsoletionForm) +
                    Number(response[0].ObsoletionManual);

                document.getElementById("polarTotalObsoletion").innerText = "TOTAL: " +
                    totalObsoletion + " / " + Number(response[0].Total);
                document.querySelector("#PolarAreaObsoletion").innerHTML = "";
                var options = {
                    series: [
                        Number(response[0].ObsoletionPolicy),
                        Number(response[0].ObsoletionGuideline),
                        Number(response[0].ObsoletionProcedure),
                        Number(response[0].ObsoletionWorkInstruction),
                        Number(response[0].ObsoletionForm),
                        Number(response[0].ObsoletionManual)
                    ],
                    yaxis: {
                        show: false
                    },
                    stroke: {
                        width: 1,
                        colors: undefined
                    },
                    chart: {
                        type: 'polarArea',
                        height: 220,
                        width: '100%',
                    },
                    labels: [
                        "Policy (" + response[0].ObsoletionPolicy + ")",
                        "Guideline (" + response[0].ObsoletionGuideline + ")",
                        "Procedure (" + response[0].ObsoletionProcedure + ")",
                        "Work Instruction (" + response[0].ObsoletionWorkInstruction + ")",
                        "Form (" + response[0].ObsoletionForm + ")",
                        "Manual (" + response[0].ObsoletionManual + ")"
                    ],
                    fill: {
                        opacity: 0.8
                    },
                    legend: {
                        position: 'right'
                    },
                    theme: {
                        monochrome: {
                            enabled: true,
                            color: '#3B82F6',
                            shadeTo: 'light',
                            shadeIntensity: 0.6
                        }
                    },
                    responsive: [{
                        breakpoint: 480,
                        options: {
                            chart: {
                                height: 250
                            },
                            legend: {
                                position: 'bottom'
                            }
                        }
                    }]
                };

                var chart = new ApexCharts(document.querySelector("#PolarAreaObsoletion"), options);
                chart.render();

            },
            error: function (err) {
                console.error(err);
            }

        });
    }

    function Load3() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Get-Record-03'
            },
            success: function (response) {

                // Parse JSON from backend
                var dataResult = response;

                // Build arrays for ApexCharts
                var categories = dataResult.map(x => x.description);
                var data = dataResult.map(x => x.TotalCount);

                // Clear previous chart
                document.querySelector("#PieChart").innerHTML = "";

                var options = {
                    series: data,      // 👈 pie chart needs a flat numeric array
                    chart: {
                        width: 380,
                        type: 'pie',
                    },
                    labels: categories,  // 👈 use your dynamic descriptions
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

                var chart = new ApexCharts(document.querySelector("#PieChart"), options);
                chart.render();

            },
            error: function (err) {
                console.error(err);
            }
        });
    }



};

function Load4() {

    let year = $("#ddlYear").val();

    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Record-04',
            'pYear': year,
            'pDeptCode': DeptCode.join(',')
        },
        success: function (data) {

            document.querySelector("#LineGraph").innerHTML = "";

            var options = {
                series: [
                    { name: "New", data: data.NewStat },
                    { name: "Pending", data: data.Approved },
                    { name: "Done", data: data.Accepted },
                    { name: "Cancelled", data: data.Cancelled }
                ],
                chart: {
                    type: 'line',
                    height: 350,
                            toolbar: {
                        show: false
                    }
                },
                stroke: {
                    curve: 'smooth'
                },
                xaxis: {
                    categories: data.Months
                }
            };

            var chart = new ApexCharts(document.querySelector("#LineGraph"), options);
            chart.render();
        }
    });
}

function fn03List(pList) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Type-01',
            'pList': pList,
            'pDeptCode': DeptCode.join(',')
        },
        success: function (response) {
            console.log(response)
            //display loader
            document.getElementById("div01Loader").style.display = "";
            document.getElementById("list01Type").innerText = pList;
            //display loader
            $('#table01List').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            DataTable.datetime('MM/DD/YYYY');
            //datatable
            var table01List = $("#table01List").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: true,
                bInfo: true,
                paging: true,
                lengthChange: false,
                pageLength: 50,
                select: true,
                data: response,
                columns: [
                    { data: 'RefNo' },
                    { data: 'DateReceive' },
                    { data: 'DocumentNo' },
                    { data: 'DocumentTitle' },
                    { data: 'DocumentType' },
                    { data: 'RevisionNo' },
                    { data: 'Dept' },
                    { data: 'DescriptionChange' },
                    { data: 'TargetDate' },
                    { data: 'DateCompletionEnd' },
                    { data: 'Tat' },
                    { data: 'Status' }],
                rowId: 'rowId',
                columnDefs: [
                    { targets: 0, orderable: false },
                    { targets: 1, className: 'tbody-nowrap-auto' },
                    { targets: 2, className: 'tbody-nowrap-auto' },
                    { targets: 3, className: 'tbody-nowrap-auto' },
                    { targets: 4, className: 'tbody-nowrap-auto' },
                    { targets: 5, className: 'tbody-nowrap-auto' },
                    { targets: 6, className: 'tbody-nowrap-auto' },
                    { targets: 7, className: 'tbody-nowrap-auto' },
                    { targets: 8, className: 'tbody-nowrap-auto' },
                    { targets: 9, className: 'tbody-nowrap-auto' },
                    { targets: 10, className: 'tbody-nowrap-auto' },
                    { targets: 11, className: 'tbody-nowrap-auto' }],
                order: [[1, 'desc']],

            });
            $('#tbx01Find').on('keyup', function () { tbl01Record.search(this.value).draw(); });
            $('#table01List tbody').on('dblclick', 'tr', function () {

                var table = $('#table01List').DataTable();
                var row = table.row(this);

                // Ensure row is selected
                if (!row.node()) return;

                var rowId = row.id(); // gets value from rowId: 'rowId'

                if (rowId) {
                    var url = 'FRM000044-DTL-' + rowId;
                    window.open(url, '_blank');
                }
            });

            //datatable

            //search
            $('#tbx01ModalFind').on('keyup', function () {
                table01List.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div01Loader").style.display = "none";
            //hide loader
        },
    });
    $('#mdl01List').modal('show');
}

function LoadYears() {
    let ddl = document.getElementById("ddlYear");
    let currentYear = new Date().getFullYear();

    for (let y = currentYear; y >= currentYear - 5; y--) {
        let opt = document.createElement("option");
        opt.value = y;
        opt.textContent = y;
        ddl.appendChild(opt);
    }
}
LoadYears();
//page
function fn01DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn01Refresh").classList.remove("btn-view");
        document.getElementById("btn01Add").classList.remove("btn-add");
        document.getElementById("btn01Delete").classList.remove("btn-delete");
        document.getElementById("btn01Edit").classList.remove("btn-edit");
        document.getElementById("btn0201Add").classList.remove("btn-success");
        document.getElementById("btn0202Add").classList.remove("btn-success");
        document.getElementById("btn0203Add").classList.remove("btn-success");
        document.getElementById("btn01Status").classList.remove("btn-secondary");
    } else {
        document.getElementById("btn01Refresh").classList.add("btn-view");
        document.getElementById("btn01Add").classList.add("btn-add");
        document.getElementById("btn01Delete").classList.add("btn-delete");
        document.getElementById("btn01Edit").classList.add("btn-edit");
        document.getElementById("btn0201Add").classList.add("btn-success");
        document.getElementById("btn0202Add").classList.add("btn-success");
        document.getElementById("btn0203Add").classList.add("btn-success");
        document.getElementById("btn01Status").classList.add("btn-secondary");

    }
    document.getElementById("btn01Refresh").disabled = pValue;
    document.getElementById("btn01Add").disabled = pValue;
    document.getElementById("btn01Delete").disabled = pValue;
    document.getElementById("btn01Edit").disabled = pValue;
    document.getElementById("btn0201Add").disabled = pValue;
    document.getElementById("btn0202Add").disabled = pValue;
    document.getElementById("btn0203Add").disabled = pValue;
    document.getElementById("btn01Status").disabled = pValue;
};

function fn0101Add() {
    document.getElementById("hdn01Mode").value = "ADD";
    document.getElementById("hdn01ID").value = '-0-0';
    fn03Load(document.getElementById("hdn01Mode").value, document.getElementById("hdn01ID").value);
    $('#mdl01View').modal('show');
}
function fn01View(pMode, pID) {
    document.getElementById("hdn01Mode").value = pMode;
    document.getElementById("hdn01ID").value = pID;
    fn03Load(document.getElementById("hdn01Mode").value, document.getElementById("hdn01ID").value);


    if (DeptCodeEMP === "2010000004") {
        $('#mdl01View').modal('show');

    } else {

        $('#mdl02View').modal('show');

    }

};

function fn01Add() {
    //access

    Add();

    function Add() {
        document.getElementById("hdn01Mode").value = "ADD";
        /*document.getElementById("hdn01ID").value = "000000000000";*/
        fn03Load(document.getElementById("hdn01Mode").value, document.getElementById("hdn01ID").value);
    };
};
function fn01Delete(pMode, pID) {
    document.getElementById("hdn01Mode").value = pMode;
    document.getElementById("hdn01ID").value = pID;
    fn02Delete();
};
function fn02Edit() {
    var selected6s = Array.from(
        document.getElementById("ddl016sMeth").selectedOptions
    ).map(option => option.value);

    //validate
    if (document.getElementById('hdn01Mode').value == "ADD") {
        //access

        ValidateFields("");

    } else if (document.getElementById('hdn01Mode').value == "DTL") {
        //access

        Validate(document.getElementById('hdn01ID').value);

        //validate
        function Validate(ID) {
            fn01ValidateRecord('Audit_Report', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    Edit_Dtl_Ok_Await(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    } else if (document.getElementById('hdn01Mode').value == "UPD") {
        //access

        Validate(document.getElementById('hdn01ID').value);

        //validate
        function Validate(ID) {
            fn01ValidateRecord('Audit_Report', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    ValidateFields(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("ddl01Department").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("ddl01Location").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx01Date").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("ddl01Preparedby").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("ddl016sMeth").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx01Description").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("ddl01PIC").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else {
            Edit_Question(ID);
        }
    }
    //question
    function Edit_Question(ID) {
        Swal.fire({
            text: 'Save record?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                if (document.getElementById('hdn01Mode').value == "ADD") {
                    Edit_Add_Ok_Await();
                } else if (document.getElementById('hdn01Mode').value == "DTL") {
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('hdn01Mode').value == "UPD") {
                    Edit_Upd_Ok_Await(ID);
                }
            }
        });
    };
    //do edit
    function Edit_Add_Ok_Await() {

        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Add-Record-01',
                'pDepartment': document.getElementById("ddl01Department").value,
                'pLocation': document.getElementById("ddl01Location").value,
                'pDate': document.getElementById("tbx01Date").value,
                'pPreparedBy': document.getElementById("ddl01Preparedby").value,
                'pMethodology': selected6s.join(","),
                'pDescription': document.getElementById("tbx01Description").value,
                'pRecommendation': document.getElementById("tbx01Recommendation").value,
                'pPersonInCharge': document.getElementById("ddl01PIC").value,
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');


                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/DSB/DSB140000HND.ashx",
                    data: {
                        'pFunction': 'Add-Notification',
                        'pSCode': response[0].oID,
                        'pPreparedBy': document.getElementById("ddl01Preparedby").value,
                        'pDescription': document.getElementById("tbx01Description").value,
                        'pPersonInCharge': document.getElementById("ddl01PIC").value,
                    },
                    success: function (response) {


                    },
                });


                document.getElementById('hdn01Mode').value = "DTL"
                document.getElementById('hdn01ID').value = response[0].oID
                document.getElementById('hdn01IDPrev').value = response[0].oID
                fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
                fn02Load();

            },
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('hdn01Mode').value = "UPD"
        document.getElementById('hdn01ID').value = ID
        document.getElementById('hdn01IDPrev').value = ID
        fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Update-Record-01',
                'pID': ID,
                'pDepartment': document.getElementById("ddl01Department").value,
                'pLocation': document.getElementById("ddl01Location").value,
                'pDate': document.getElementById("tbx01Date").value,
                'pPreparedBy': document.getElementById("ddl01Preparedby").value,
                'pMethodology': selected6s.join(","),
                'pDescription': document.getElementById("tbx01Description").value,
                'pRecommendation': document.getElementById("tbx01Recommendation").value,
                'pPersonInCharge': document.getElementById("ddl01PIC").value,
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                /* fn02Redraw("Edit", ID);*/
                document.getElementById('hdn01Mode').value = "DTL"
                document.getElementById('hdn01ID').value = ID
                document.getElementById('hdn01IDPrev').value = ID
                fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
            },
        });
    };
};
function fn03Edit() {

    if (document.getElementById('hdn01Mode').value == "DTL") {
        Access();
        //access
        function Access() {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB140000HND.ashx",
                data: {
                    'pFunction': 'Access-01'
                },
                success: function (response) {
                    if (response[0].Empno === document.getElementById("lbl02PersonInCharge").textContent) {
                        Validate(document.getElementById('hdn01ID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    }

                },
            });
        }
        //validate
        function Validate(ID) {
            fn01ValidateRecord('Audit_Report', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    Edit_Dtl_Ok_Await(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    } else if (document.getElementById('hdn01Mode').value == "UPD") {
        //access

        Validate(document.getElementById('hdn01ID').value);

        //validate
        function Validate(ID) {
            fn01ValidateRecord('Audit_Report', ID, '', 'Save', function (response) {
                if (response[0].oReturn == "") {
                    ValidateFields(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx02Action").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else {
            Edit_Question(ID);
        }
    }
    //question
    function Edit_Question(ID) {
        Swal.fire({
            text: 'Save record?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                if (document.getElementById('hdn01Mode').value == "DTL") {
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('hdn01Mode').value == "UPD") {
                    Edit_Upd_Ok_Await(ID);
                }
            }
        });
    };
    //do edit

    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('hdn01Mode').value = "UPD"
        document.getElementById('hdn01ID').value = ID
        document.getElementById('hdn01IDPrev').value = ID
        fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Update-Record-02',
                'pID': ID,
                'pAction': document.getElementById("tbx02Action").value
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                /* fn02Redraw("Edit", ID);*/
                document.getElementById('hdn01Mode').value = "DTL"
                document.getElementById('hdn01ID').value = ID
                document.getElementById('hdn01IDPrev').value = ID
                fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
                fn02Load();
            },
        });
    };
};

function fn02Delete() {
    if (document.getElementById('hdn01Mode').value == "ADD") {
        Cancel_Add_Question();
    } else if (document.getElementById('hdn01Mode').value == "DTL") {
        //access  

        Validate(document.getElementById('hdn01ID').value);

        //validate
        function Validate(ID) {
            fn01ValidateRecord('Audit_Report', ID, '', 'Delete', function (response) {
                if (response[0].oReturn == "") {
                    Delete_Dtl_Question(document.getElementById('hdn01ID').value);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning');
                };
            });
        };
    } else if (document.getElementById('hdn01Mode').value == "UPD") {
        Cancel_Upd_Question(document.getElementById('hdn01ID').value);
    }
    function Cancel_Add_Question() {
        Swal.fire({
            text: 'Cancel changes?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                if (document.getElementById('hdn01IDPrev').value == "") {
                    $('#mdl01View').modal('hide');
                } else {
                    document.getElementById('hdn01Mode').value = "DTL"
                    document.getElementById('hdn01ID').value = document.getElementById('hdn01IDPrev').value;
                    document.getElementById('hdn01IDPrev').value = document.getElementById('hdn01IDPrev').value;
                    fn03Load(document.getElementById("hdn01Mode").value, document.getElementById("hdn01ID").value);
                }
            }
        });
    };
    function Delete_Dtl_Question(ID) {
        Swal.fire({
            text: 'Remove record?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                Detele_Ok(ID);
            }
        });
        function Detele_Ok(ID) {
            fn01Delete(FormCode, 'Audit_Report', ID, function (response) {
                if (document.getElementById('hdn01IDPrev').value == "") {
                    $('#mdl01View').modal('hide');
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn02Load();
                } else if (document.getElementById('hdn01IDPrev').value == ID) {
                    $('#mdl01View').modal('hide');
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn02Load();
                } else if (document.getElementById('hdn01IDPrev').value != ID) {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn02Load();
                    document.getElementById('hdn01Mode').value = "DTL"
                    document.getElementById('hdn01ID').value = document.getElementById('hdn01IDPrev').value
                    document.getElementById('hdn01IDPrev').value = document.getElementById('hdn01IDPrev').value
                    fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
                }
            });
        };
    };
    function Cancel_Upd_Question(ID) {
        Swal.fire({
            text: 'Cancel changes?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                document.getElementById('hdn01Mode').value = "DTL"
                document.getElementById('hdn01ID').value = ID
                document.getElementById('hdn01IDPrev').value = ID
                fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
            }
        });
    };
};

function fn01ChangeStatus() {
    Swal.fire({
        text: 'Change status?',
        icon: 'question',
        iconColor: '#0095e8',
        buttonsStyling: false,
        showCancelButton: true,
        confirmButtonText: "Yes",
        cancelButtonText: 'Cancel',
        customClass: {
            confirmButton: 'btn btn-sm btn-info min-w-100px',
            cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/DSB/DSB140000HND.ashx",
                data: {
                    'pFunction': 'Change-status',
                    'pID': document.getElementById('hdn01ID').value,

                },
                success: function (response) {
                    fn01AlertOnly('Record successfully changed.', 'success');
                    fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
                    fn02Load()
                },
            });
        }
    });
}

function fn03Delete() {
    if (document.getElementById('hdn01Mode').value == "UPD") {
        Cancel_Upd_Question(document.getElementById('hdn01ID').value);
    }

    function Cancel_Upd_Question(ID) {
        Swal.fire({
            text: 'Cancel changes?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                document.getElementById('hdn01Mode').value = "DTL"
                document.getElementById('hdn01ID').value = ID
                document.getElementById('hdn01IDPrev').value = ID
                fn03Load(document.getElementById('hdn01Mode').value, document.getElementById('hdn01ID').value);
            }
        });
    };
};


function fn03Load(pMode, pID) {

    if (pMode == "ADD") {

        //title
        document.getElementById("spn01Title").innerText = "New Record";
        document.getElementById("spn01Status").innerText = "New";
        if (document.getElementById("spn01Status").innerText == "New") {
            document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-new");
        };
        //title

        //toolbar
        fn01DisableButtons(true);
        document.getElementById("btn01Delete").classList.add("btn-delete");
        document.getElementById("btn01Delete").disabled = false;
        document.getElementById("btn01Edit").classList.add("btn-edit");
        document.getElementById("btn01Edit").disabled = false;
        document.getElementById("i01Edit").classList.remove("la-pencil-alt");
        document.getElementById("i01Edit").classList.add("la-save");

        //toolbar

        //content
        document.getElementById("div01Detail").style.display = "none";
        document.getElementById("div01Update").style.display = "";

        ddl01GetDepartment('');
        $("#ddl01Location").val('').trigger("change");
        document.getElementById("tbx01Date").value = "";
        ddl01GetPreparedBy("")
        $("#ddl016sMeth").val('').trigger("change");
        document.getElementById("tbx01Description").value = "";
        document.getElementById("tbx01Recommendation").value = "";
        $('#ddl01Department').on('change', function () {
            ddl01GetPIC(this.value, '');
        });
        $('#ddl016sMeth').select2({
            width: '100%',
            height: '100%',
            dropdownAutoWidth: true,
            placeholder: "Select Methodology",
            allowClear: true
        });
        //content

        //attachment
        fn0201LoadAttachment(pMode, "");
        fn0201LoadEvidence(pMode, "");
        fn0202LoadEvidence(pMode, "");

        LoadOthers();
        //note

    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Get-Info-01',
                'pID': pID
            },
            success: function (response) {
                //title
                document.getElementById("spn01Title").innerHTML = response[0].Description;
                document.getElementById("spn01Status").innerText = response[0].Status;

                if (document.getElementById("spn01Status").innerText == "New") {
                    document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn01Status").innerText == "Closed") {
                    document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-ClosedAUD");
                } else if (document.getElementById("spn01Status").innerText == "Open") {
                    document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-OpenAUD");
                };
                //title

                //toolbar
                document.getElementById("i01Edit").classList.add("la-pencil-alt");
                document.getElementById("i01Edit").classList.remove("la-save");



                fn01DisableButtons(false);
                //checkbox

                //content
                document.getElementById("div01Detail").style.display = "";
                document.getElementById("div01Update").style.display = "none";


                document.getElementById("lbl01Department").innerText = response[0].dept;
                document.getElementById("lbl01Location").innerText = response[0].Location;
                document.getElementById("lbl01Date").innerText = response[0].Date;
                document.getElementById("lbl01PreparedBy").innerText = response[0].Prepared;
                document.getElementById("lbl016sMeth").innerText = response[0].Methodology;
                document.getElementById("lbl01Desc").innerHTML = response[0].Description;
                document.getElementById("lbl01Recommendation").innerHTML = response[0].Recommendation;
                document.getElementById("lbl01PersonInCharge").innerText = response[0].PIC;

                //for auditee's portal
                document.getElementById("spn02Title").innerHTML = response[0].Description;
                document.getElementById("spn02Status").innerText = response[0].Status;
                if (document.getElementById("spn02Status").innerText == "New") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn02Status").innerText == "Closed") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-ClosedAUD");
                } else if (document.getElementById("spn02Status").innerText == "Open") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-OpenAUD");
                };
                //title
                document.getElementById("div02Detail").style.display = "";
                document.getElementById("div02Update").style.display = "none";
                document.getElementById("i02Edit").classList.add("la-pencil-alt");
                document.getElementById("i02Edit").classList.remove("la-save");
                document.getElementById("btn02Delete").style.display = "none";

                document.getElementById("lbl02Department").innerText = response[0].dept;
                document.getElementById("lbl02Location").innerText = response[0].Location;
                document.getElementById("lbl02Date").innerText = response[0].Date;
                document.getElementById("lbl02PreparedBy").innerText = response[0].Prepared;
                document.getElementById("lbl026sMeth").innerText = response[0].Methodology;
                document.getElementById("lbl02Desc").innerHTML = response[0].Description;
                document.getElementById("lbl02Recommendation").innerHTML = response[0].Recommendation;
                document.getElementById("lbl02PersonInCharge").innerText = response[0].PIC;
                document.getElementById("lbl02Action").innerText = response[0].Action;
                //for auditee's portal
                //content

                //attachment
                fn0201LoadAttachment(pMode, document.getElementById("hdn01ID").value);
                fn0201LoadEvidence(pMode, document.getElementById("hdn01ID").value);
                fn0202LoadEvidence(pMode, document.getElementById("hdn01ID").value);
                //upload
                Dropzone.autoDiscover = false;
                Dropzone.instances
                    .filter(dz => dz.element.id === "DropZoneAttachment")
                    .forEach(dz => dz.destroy());
                var myDropzone = new Dropzone("#DropZoneAttachment", {
                    url: "HNDGEN.ashx?pFormCode=DSB140000&pType=Upload&pID=" + pID,
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        var imgName = response;
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0201Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0202Upload').modal('hide');
                        //load attachment
                        fn0201LoadAttachment('DTL', pID);
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                myDropzone.on("addedfile", function (file) {
                    FileCount = FileCount + 1;
                });
                myDropzone.on("removedfile", function (file) {
                    FileCount = FileCount - 1;
                });
                $('#btn0201Add').on('click', function (e) {
                    //access

                    Add();

                    function Add() {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl0202Upload').modal('show');
                    };
                });

                $('#btn0201Add_Ok').on('click', function (e) {
                    //access

                    Validate();

                    //validate
                    function Validate() {
                        if (FileCount > 0) {
                            btn0201Add_Ok();
                        } else {
                            fnAlertOnly('Please attach at least one file to proceed!', 'error', 'btn btn-danger');
                        }
                    }
                    //upload
                    async function btn0201Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0201Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simu
                        
                        //form submission
                        await btn0201Add_Ok_Await(Btn);
                    }
                    async function btn0201Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=DSB140000&pType=Upload&pID=" + pID
                            myDropzone.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //upload



                //upload Evidence
                Dropzone.autoDiscover = false;
                Dropzone.instances
                    .filter(dz => dz.element.id === "DropZoneEvidence")
                    .forEach(dz => dz.destroy());
                var myDropzoneEvi = new Dropzone("#DropZoneEvidence", {
                    url: "Assets/Handler/DSB/DSB140000HND.ashx?pFormCode=DSB140000Evi&pType=Upload&pID=" + pID,
                    autoProcessQueue: false,
                    //upload more than 2 files by Dropzone.js with button
                    parallelUploads: 5,
                    //File size
                    maxFilesize: 10,
                    //Number of files
                    maxFiles: 5,
                    acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
                    addRemoveLinks: true,
                    success: function (file, response) {
                        var imgName = response;
                        file.previewElement.classList.add("dz-success");
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //hide modal
                        $('#mdl0203Upload').modal('hide');
                        //load attachment
                        fn0201LoadEvidence('DTL', pID);
                        fn0202LoadEvidence('DTL', pID);
                        //message
                        fnAlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
                    },
                    error: function (file, response) {
                        file.previewElement.classList.add("dz-error");
                    }
                });
                myDropzoneEvi.on("addedfile", function (file) {
                    FileCountEvi = FileCountEvi + 1;
                });
                myDropzoneEvi.on("removedfile", function (file) {
                    FileCountEvi = FileCountEvi - 1;
                });
                $('#btn0202Add').on('click', function (e) {
                    //access
                    Add();

                    function Add() {
                        myDropzoneEvi.removeAllFiles();
                        FileCountEvi = 0;
                        $('#mdl0203Upload').modal('show');
                    };
                });
                $('#btn0203Add').on('click', function (e) {
                    //access

                    Access();
                    function Access() {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/DSB/DSB140000HND.ashx",
                            data: {
                                'pFunction': 'Access-01'
                            },
                            success: function (response) {
                                if (response[0].Empno === document.getElementById("lbl02PersonInCharge").textContent) {
                                    Add();
                                } else {
                                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                                }

                            },
                        });
                    }
                    function Add() {
                        myDropzoneEvi.removeAllFiles();
                        FileCountEvi = 0;
                        $('#mdl0203Upload').modal('show');
                    };
                });

                $('#btn0202Add_Ok').on('click', function (e) {
                    //access

                    Validate();

                    //validate
                    function Validate() {
                        if (FileCountEvi > 0) {
                            btn0202Add_Ok();
                        } else {
                            fnAlertOnly('Please attach at least one file to proceed!', 'error', 'btn btn-danger');
                        }
                    }
                    //upload
                    async function btn0202Add_Ok() {
                        // Perform button
                        var Btn = document.getElementById('btn0202Add_Ok');
                        // Disable button to avoid multiple click
                        Btn.disabled = true;
                        // Show loading indicator
                        Btn.setAttribute('data-kt-indicator', 'on');
                        // Simulate form submission
                        await btn0202Add_Ok_Await(Btn);
                    }
                    async function btn0202Add_Ok_Await(Btn) {
                        // process
                        return new Promise(resolve => {
                            myDropzoneEvi.options.url = "Assets/Handler/DSB/DSB140000HND.ashx?pFormCode=DSB140000Evi&pType=Upload&pID=" + pID;
                            myDropzoneEvi.processQueue();
                            //resolve
                            resolve();
                        });
                    }
                });
                //upload





                LoadOthers();
                //note

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFunction': 'Get-Info-01',
                'pID': pID

            },
            success: function (response) {

                $('#table0201Attachment tbody td:first-child').css({
                    'pointer-events': 'none',
                    'opacity': '0.6'
                });

                //title
                document.getElementById("spn01Title").innerHTML = response[0].Description;
                document.getElementById("spn01Status").innerText = response[0].Status;
                if (document.getElementById("spn01Status").innerText == "New") {
                    document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn01Status").innerText == "Closed") {
                    document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-ClosedAUD");
                } else if (document.getElementById("spn01Status").innerText == "Open") {
                    document.getElementById("spn01Status").setAttribute("class", "badge badge-lg badge-record-OpenAUD");
                };
                //title

                //toolbar
                fn01DisableButtons(true);
                document.getElementById("btn01Delete").classList.add("btn-delete");
                document.getElementById("btn01Delete").disabled = false;
                document.getElementById("btn01Edit").classList.add("btn-edit");
                document.getElementById("btn01Edit").disabled = false;
                document.getElementById("i01Edit").classList.remove("la-pencil-alt");
                document.getElementById("i01Edit").classList.add("la-save");
                //toolbar

                //content
                document.getElementById("div01Detail").style.display = "none";
                document.getElementById("div01Update").style.display = "";

                ddl01GetDepartment(response[0].Department);
                $("#ddl01Location").val(response[0].Location).trigger("change");
                document.getElementById("tbx01Date").value = response[0].Date
                ddl01GetPreparedBy(response[0].Preparedby)

                let methods = response[0].Methodology;
                let arr = methods ? methods.split(",") : [];
                $("#ddl016sMeth").val(arr).trigger("change");

                document.getElementById("tbx01Description").value = response[0].DescriptionUpd;
                document.getElementById("tbx01Recommendation").value = response[0].RecommendationUpd;

                $('#ddl01Department').on('change', function () {
                    ddl01GetPIC(this.value, response[0].PersonInCharge);
                });
                $('#ddl016sMeth').select2({
                    width: '100%',
                    dropdownAutoWidth: true,
                    placeholder: "Select Methodology",
                    allowClear: true
                });
                //content



                //for auditee's portal
                $('#table0201Evidence tbody td:first-child').css({
                    'pointer-events': 'none',
                    'opacity': '0.6'
                });
                $('#table0201Evidence2 tbody td:first-child').css({
                    'pointer-events': 'none',
                    'opacity': '0.6'
                });
                document.getElementById("spn02Title").innerHTML = response[0].Description;
                document.getElementById("spn02Status").innerText = response[0].Status;
                if (document.getElementById("spn02Status").innerText == "New") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn02Status").innerText == "Closed") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-ClosedAUD");
                } else if (document.getElementById("spn02Status").innerText == "Open") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-OpenAUD");
                };
                //title
                document.getElementById("div02Detail").style.display = "none";
                document.getElementById("div02Update").style.display = "";
                document.getElementById("i02Edit").classList.remove("la-pencil-alt");
                document.getElementById("i02Edit").classList.add("la-save");
                document.getElementById("btn02Delete").style.display = "";

                document.getElementById("tbx02Action").value = response[0].Action;
                //for auditee's portal



                // remove old temporary options



                //content

                //attachment
                LoadOthers();
                //note
            },
        });
    }
    function LoadOthers() {
        if (pMode == "ADD") { document.getElementById("hdn01IDPrev").value = ""; };
        if (pMode == "DTL") { document.getElementById("hdn01IDPrev").value = pID; };
        if (pMode == "UPD") { document.getElementById("hdn01IDPrev").value = pID; };
    };
}
function ddl01GetDepartment(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Record-01-List',
            'pTblName': 'Department',
            'pPlaceHolder': 'Select Department',
            'pID': pID,
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl01Department").html(s);
            $('#ddl01Department').val(pID).trigger('change');


        },
    });
};
function ddl03GetDepartment(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Record-01-List',
            'pTblName': 'Department01',
            'pPlaceHolder': 'Select All',
            'pID': pID,
        },
        success: function (response) {
            // Build options
            let s = '';
            for (let i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }

            let ddl = $("#ContentPlaceHolder1_ddl03Department");

            // Replace options
            ddl.html(s);

            // Initialize Select2 + select-all logic AFTER loading
            initDeptSelect2();

            // Set initial value if needed
            ddl.val(pID).trigger('change');


        },
    });
};
function ddl01GetPIC(pID, pID2) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Record-01-List',
            'pTblName': 'PIC',
            'pPlaceHolder': 'Select Person in Charge',
            'pID': pID,
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }

            $("#ddl01PIC").html(s);
            if (document.getElementById('hdn01Mode').value === "ADD") {
                $('#ddl01PIC').val('').trigger('change');

            } else {
                $('#ddl01PIC').val(pID2).trigger('change');
            }


        },
    });
};
function ddl01GetPreparedBy(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Record-01-List',
            'pTblName': 'PreparedBy',
            'pPlaceHolder': 'Select Prepared by',
            'pID': pID,
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }

            $("#ddl01Preparedby").html(s);
            $('#ddl01Preparedby').val(pID).trigger('change');
        },
    });
};


//filter
function fn0101filter() {
    $('#mdl0101Filter').modal('show');
    ddl03GetDepartment('')
    $('#ContentPlaceHolder1_ddl03Department').select2({
        width: '100%',
        dropdownAutoWidth: true,
        placeholder: "Search Department",
        allowClear: true
    });



};
function initDeptSelect2() {

    let ddl = $('#ContentPlaceHolder1_ddl03Department');

    // Destroy old Select2 if exists (prevents duplicate binding)
    if (ddl.hasClass("select2-hidden-accessible")) {
        ddl.select2('destroy');
    }

    // Initialize Select2
    ddl.select2({
        placeholder: "Search Department",
        allowClear: true,
    });

    // --- SELECT ALL ---
    ddl.off('select2:select').on('select2:select', function (e) {
        let selectedValue = e.params.data.id;

        if (selectedValue === 'ALL') {
            let allValues = ddl.find('option[value!="ALL"]').map(function () {
                return this.value;
            }).get();

            ddl.val(allValues).trigger('change');
        } else {
            ddl.find('option[value="ALL"]').prop('selected', false);
            ddl.trigger('change');
        }
    });

    // --- UNSELECT ALL ---
    ddl.off('select2:unselect').on('select2:unselect', function (e) {
        if (e.params.data.id === 'ALL') {
            ddl.val(null).trigger('change');
        }
    });
}
function fn0201Filter_Ok(Btn) {
    Btn.disabled = true;
    Btn.setAttribute('data-kt-indicator', 'on');

    DeptCode = [...document.getElementById("ContentPlaceHolder1_ddl03Department").selectedOptions]
        .map(o => o.value);
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFunction': 'Get-Record-01',
            'pDeptCode': DeptCode.join(',')
        },
        success: function (response) {
            fn02Load();
            //table
            $('#tbl01Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            DataTable.datetime('MM/DD/YYYY');
            var tbl01Record = $("#tbl01Record").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: true,
                bInfo: true,
                paging: true,
                lengthChange: false,
                pageLength: 50,
                select: true,
                data: response,
                columns: [
                    { data: 'RefNo' },
                    { data: 'DateReceive' },
                    { data: 'DocumentNo' },
                    { data: 'DocumentTitle' },
                    { data: 'DocumentType' },
                    { data: 'RevisionNo' },
                    { data: 'Dept' },
                    { data: 'DescriptionChange' },
                    { data: 'TargetDate' },
                    { data: 'DateCompletionEnd' },
                    { data: 'Tat' },
                    { data: 'Status' }],
                rowId: 'rowId',
                columnDefs: [
                    { targets: 0, orderable: false },
                    { targets: 1, className: 'tbody-nowrap-auto' },
                    { targets: 2, className: 'tbody-nowrap-auto' },
                    { targets: 3, className: 'tbody-nowrap-auto' },
                    { targets: 4, className: 'tbody-nowrap-auto' },
                    { targets: 5, className: 'tbody-nowrap-auto' },
                    { targets: 6, className: 'tbody-nowrap-auto' },
                    { targets: 7, className: 'tbody-nowrap-auto' },
                    { targets: 8, className: 'tbody-nowrap-auto' },
                    { targets: 9, className: 'tbody-nowrap-auto' },
                    { targets: 10, className: 'tbody-nowrap-auto' },
                    { targets: 11, className: 'tbody-nowrap-auto' }],
                order: [[3, 'asc']],

            });
            $('#tbx01Find').on('keyup', function () { tbl01Record.search(this.value).draw(); });
            fn01AlertOnly('Record successfully loaded.', 'success');

            Btn.disabled = false;
            Btn.removeAttribute('data-kt-indicator');
        },
    });
};
//filter




//attachment
function fn0201LoadAttachment(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'DSB140000',
            'pType': 'Upload - Get Record',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0201LoaderAttachment").style.display = "";

            //display loader

            $('#table0201Attachment').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0201Attachment = $("#table0201Attachment").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: true,
                data: response,
                columns: [
                    { data: 'Action' },
                    { data: 'Type' },
                    { data: 'Attachment' },
                    { data: 'UploadedBy' },
                    { data: 'UploadedDate' }],
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                order: [[2, 'asc']],
            });
            //datatable




            //hide loader
            document.getElementById("div0201LoaderAttachment").style.display = "none";
            //hide loader
            $('#table0202Attachment').DataTable().destroy();

            //display loader
            document.getElementById("div0202LoaderAttachment").style.display = "";
            //display loader
            //datatable
            var table0202Attachment = $("#table0202Attachment").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: true,
                data: response,
                columns: [
                    { data: 'Action' },
                    { data: 'Type' },
                    { data: 'Attachment' },
                    { data: 'UploadedBy' },
                    { data: 'UploadedDate' }],
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                order: [[2, 'asc']],
            });
            //datatable


            //hide loader
            document.getElementById("div0202LoaderAttachment").style.display = "none";
            //hide loader

            //action button
            if (pMode == "ADD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            } else if (pMode = "DTL") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = false;
                }
            } else if (pMode == "UPD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            }
            //action button

        },
    });
};
function fn0201Download(pFormCode, pID, pFileName) {
    //if exisit

    Download();

    //download
    function Download() {
        $.ajax({
            type: "POST",
            url: "HNDGEN.ashx",
            data: {
                'pFormCode': pFormCode,
                'pType': 'Upload - Download',
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                window.open('MNU020200?View=' + response[0].View);
            },
        });
    };
};
function fn0201Delete(pFormCode, pID, pFileName) {
    Access();
    //if exisit
    function Access() {
        fnAccess('DSB140000', 'Delete', function (response) {
            if (response[0].oReturn == "1") {
                Delete_Question(pFormCode, pID, pFileName);
            } else {
                fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
            };
        });
    };
    //delete question
    function Delete_Question(pFormCode, pID, pFileName) {
        Swal.fire({
            text: 'Remove attachment?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                Delete_Ok(pFormCode, pID, pFileName);
            }
        });
    };
    function Delete_Ok(pFormCode, pID, pFileName) {
        $.ajax({
            type: "POST",
            url: "HNDGEN.ashx",
            data: {
                'pFormCode': pFormCode,
                'pType': 'Upload - Delete',
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                fnAlertOnly('Attachment successfully removed!', 'success', 'btn btn-success');
                fn0201LoadAttachment("DTL", pID);
            },
        });
    };
};
//attachment



//Evidence
function fn0201LoadEvidence(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFormCode': 'DSB140000Evi',
            'pType': 'Upload - Get Record',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0201LoaderEvidence").style.display = "";
            //display loader

            $('#table0201Evidence').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0201Evidence = $("#table0201Evidence").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: true,
                data: response,
                columns: [
                    { data: 'Action' },
                    { data: 'Type' },
                    { data: 'Attachment' },
                    { data: 'UploadedBy' },
                    { data: 'UploadedDate' }],
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                order: [[2, 'asc']],
            });
            //datatable


            //hide loader
            document.getElementById("div0201LoaderEvidence").style.display = "none";
            //hide loader

            //action button
            if (pMode == "ADD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            } else if (pMode = "DTL") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = false;
                }
            } else if (pMode == "UPD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            }
            //action button

        },
    });
};
//Evidence For auditee's
function fn0202LoadEvidence(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/DSB/DSB140000HND.ashx",
        data: {
            'pFormCode': 'DSB140000Evi',
            'pType': 'Upload - Get Record',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0201LoaderEvidence2").style.display = "";
            //display loader

            $('#table0201Evidence2').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0201Evidence2 = $("#table0201Evidence2").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: true,
                data: response,
                columns: [
                    { data: 'Action' },
                    { data: 'Type' },
                    { data: 'Attachment' },
                    { data: 'UploadedBy' },
                    { data: 'UploadedDate' }],
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }, { targets: 4, className: 'tbody-nowrap-auto' }],
                order: [[2, 'asc']],
            });
            //datatable


            //hide loader
            document.getElementById("div0201LoaderEvidence2").style.display = "none";
            //hide loader

            //action button
            if (pMode == "ADD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            } else if (pMode = "DTL") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = false;
                }
            } else if (pMode == "UPD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            }
            //action button

        },
    });
};
function fn0202Download(pFormCode, pID, pFileName) {
    //if exisit

    Download();

    //download
    function Download() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFormCode': pFormCode,
                'pType': 'Upload - Download',
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                window.open('MNU020200?View=' + response[0].View);
            },
        });
    };
};
function fn0202Delete(pFormCode, pID, pFileName) {
    //if exisit

    Delete_Question(pFormCode, pID, pFileName);

    //delete question
    function Delete_Question(pFormCode, pID, pFileName) {
        Swal.fire({
            text: 'Remove attachment?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                Delete_Ok(pFormCode, pID, pFileName);
            }
        });
    };
    function Delete_Ok(pFormCode, pID, pFileName) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/DSB/DSB140000HND.ashx",
            data: {
                'pFormCode': pFormCode,
                'pType': 'Upload - Delete',
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                fnAlertOnly('Attachment successfully removed!', 'success', 'btn btn-success');
                fn0201LoadEvidence("DTL", pID);
                fn0202LoadEvidence("DTL", pID);

            },
        });
    };
};
//Evidence

