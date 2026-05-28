//form
var FormCode = 'AAD002000'
//form

//attachment
var FileCount = 0;
//attachment

//@mention
var mentionUser = [];
var initialMention = [];
var jq = jQuery.noConflict();
//@mention

//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        var str = window.location.href;
        var url = new URL(str);
        document.getElementById("hdn02ID").value = url.searchParams.get("pID");
        fn01Plugins();
        fn02Load(document.getElementById("hdn02ID").value);
        fn03Load(document.getElementById("hdn02ID").value);
        fn98Load(document.getElementById("hdn02ID").value);
        fn99Load(document.getElementById("hdn02ID").value);
    });
    jQuery(function ($) {
        Dropzone.autoDiscover = false;
        var myDropzone = new Dropzone("#div98DropZone", {
            url: "Assets/Handler/MNU/MNU001000HND.ashx?pFunction=Add-Record-98&pFormCode=" + FormCode + "&pID=" + document.getElementById('hdn02ID').value,
            autoProcessQueue: false,
            parallelUploads: 5,
            maxFilesize: 10,
            maxFiles: 5,
            acceptedFiles: ".png,.jpg,.jpeg,.jpe,.xlsx,.xls,.docx,.doc,.pdf,.PNG,.JPG,.JPEG,.JPE,.XLSX,.XLS,.DOCX,.DOC,.PDF",
            addRemoveLinks: true,
            success: function (file, response) {
                var imgName = response;
                file.previewElement.classList.add("dz-success");
                var Btn = document.getElementById('btn9801Add');
                Btn.disabled = false;
                Btn.removeAttribute('data-kt-indicator');
                $('#mdl9801Upload').modal('hide');
                fn98Load(document.getElementById('hdn02ID').value);
                fn01AlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
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
        $('#btn98Add').on('click', function (e) {
            fn01Access(FormCode, 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fn01AlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add() {
                myDropzone.removeAllFiles();
                FileCount = 0;
                $('#mdl9801Upload').modal('show');
            };
        });
        $('#btn9801Add').on('click', function (e) {
            fn01Access(FormCode, 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fn01AlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Validate() {
                if (FileCount > 0) {
                    btn9801Add();
                } else {
                    fn01AlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
                }
            }
            async function btn9801Add() {
                var Btn = document.getElementById('btn9801Add');
                Btn.disabled = true;
                Btn.setAttribute('data-kt-indicator', 'on');
                await btn9801Add_Await(Btn);
            }
            async function btn9801Add_Await(Btn) {
                return new Promise(resolve => {
                    myDropzone.options.url = "Assets/Handler/MNU/MNU001000HND.ashx?pFunction=Add-Record-98&pFormCode=" + FormCode + "&pID=" + document.getElementById('hdn02ID').value;
                    myDropzone.processQueue();
                    resolve();
                });
            }
        });
    });
    jQuery(function ($) {
        jq.fn.atwho.debug = true;
        var chatHub = jq.connection.chatHub;
        jq.connection.hub.start().done(function () {
            loadFunction()
        }).fail(function (error) {
            console.error("SignalR connection failed: " + error)
        });
        function loadFunction() {
            chatHub.server.getEmployeeData().then(function (data) {
                initAtWho(data);
            }).catch(function (error) {
                console.error("Error fetching data from SignalR:", error)
            });
            function initAtWho(data) {
                var at_config = {
                    at: "@",
                    data: data,
                    insertTpl: '${fname}',
                    displayTpl: "<li><div class='d-flex align-items-center'><div class='symbol symbol-30px overflow-hidden me-3'><div class='symbol-label'> <img src='Assets/media/avatars/${empPic}' class='w-100' alt='' />  </div></div><div class='d-flex flex-column '><span class='text-weight-500 text-gray-800 '>${name}</span><span class='text-weight-500'>${email}</span></div></div></li>",
                    limit: 200,
                    callbacks: {
                        beforeInsert: function (value, jqli, e) {
                            var selectedUserData = jqli.data('item-data');
                            mentionUser.push({
                                name: selectedUserData.fname,
                                empCode: selectedUserData.empCode
                            })
                            var emp_no = mentionUser.map(function (employee) {
                                return employee.empCode
                            });
                            initialMention = emp_no;
                            $('#hdn99Mention').val(initialMention.join(','));
                            return '@' + value;
                        },
                    }
                }
                $inputor = jq('.mention').atwho(at_config);
                $inputor.caret('pos', 47);
                $inputor.focus().atwho('run');
                $inputor.on('keydown', function (e) {
                    if (e.keyCode === 8) {
                        handleBackspace();
                    }
                })
                function handleBackspace() {
                    var inputValue = $inputor.val();
                    var cursorPosition = $inputor.caret('pos');
                    var mentionStart = inputValue.lastIndexOf('@', cursorPosition - 1);

                    if (mentionStart !== -1) {
                        var mentionText = inputValue.substring(mentionStart, cursorPosition);

                        mentionUser = mentionUser.filter(function (user) {
                            return `@${user.name}` !== mentionText;
                        });

                        var emp_no = mentionUser.map(function (employee) {
                            return employee.empCode
                        });

                        initialMention = emp_no;
                    }
                }
            };
        };
    });
};
//master

//page
function fn02Load(pID) {
    fn01Access('AAD020000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            Load();
        } else {
            location.replace("MNU000022");
        };
    });
    function Load() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Info-02',
                'pID': pID,
            },
            success: function (response) {
                //title
                document.getElementById("spn02Title").innerText = response[0].Title;
                document.getElementById("spn02Status").innerText = response[0].RecordStatus;
                if (document.getElementById("spn02Status").innerText == "Advance") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn02Status").innerText == "Current") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn02Status").innerText == "for LTO") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-locked");
                } else if (document.getElementById("spn02Status").innerText == "Full Paid") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-posted");
                } else if (document.getElementById("spn02Status").innerText == "Past Due") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                } else if (document.getElementById("spn02Status").innerText == "Transferred") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                } else if (document.getElementById("spn02Status").innerText == "Cancelled") {
                    document.getElementById("spn02Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                };
                //title

                //detail
                document.getElementById("lbl02AcctNo").innerText = response[0].AcctNo;
                document.getElementById("lbl02AcctName").innerText = response[0].AcctName;
                document.getElementById("lbl02Project").innerText = response[0].Project;
                document.getElementById("lbl02ModelName").innerText = response[0].ModelName;
                document.getElementById("lbl02Status").innerText = response[0].Status;
                document.getElementById("lbl02Balance").innerText = response[0].Balance;
                //detail
            },
        });
    };
};
function fn02Refresh() {
    fn02Load();
};
//page

//detail
function fn03Load(pID) {
    Load01();
    Load02();
    Load03();
    Load04();
    Load05();
    Load06();
    Load07();
    function Load01() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Info-0301',
                'pID': pID,
            },
            success: function (response) {
                //detail
                document.getElementById("lbl02ContractTypeName").innerText = response[0].ContractTypeName;
                document.getElementById("lbl02FullName").innerText = response[0].FullName;
                document.getElementById("lbl02LastName").innerText = response[0].LastName;
                document.getElementById("lbl02FirstName").innerText = response[0].FirstName;
                document.getElementById("lbl02MiddleName").innerText = response[0].MiddleName;
                document.getElementById("lbl02Suffix").innerText = response[0].Suffix;
                document.getElementById("lbl02BirthDate").innerText = response[0].BirthDate;
                document.getElementById("lbl02GenderName").innerText = response[0].GenderName;
                document.getElementById("lbl02CitizenshipName").innerText = response[0].CitizenshipName;
                document.getElementById("lbl02CivilStatusName").innerText = response[0].CivilStatusName;
                document.getElementById("lbl02HomeAddress").innerText = response[0].HomeAddress;
                document.getElementById("lbl02HomeCountryName").innerText = response[0].HomeCountryName;
                document.getElementById("lbl02HomeCityName").innerText = response[0].HomeCityName;
                document.getElementById("lbl02HomeTownPlace").innerText = response[0].HomeTownPlace;
                document.getElementById("lbl02HomeTownCode").innerText = response[0].HomeTownCode;
                document.getElementById("lbl02YearsofStay").innerText = response[0].YearsofStay;
                document.getElementById("lbl02OwnershipName").innerText = response[0].OwnershipName;
                document.getElementById("lbl02Emailaddress").innerText = response[0].Emailaddress;
                document.getElementById("lbl02MobileNo").innerText = response[0].MobileNo;
                document.getElementById("lbl02TIN").innerText = response[0].TIN;
                document.getElementById("lbl02SSS").innerText = response[0].SSS;
                document.getElementById("lbl02UMID").innerText = response[0].UMID;
                document.getElementById("lbl02Employer").innerText = response[0].Employer;
                document.getElementById("lbl02EmployerAddress").innerText = response[0].EmployerAddress;
                document.getElementById("lbl02EmpCountryName").innerText = response[0].EmpCountryName;
                document.getElementById("lbl02EmpCityName").innerText = response[0].EmpCityName;
                document.getElementById("lbl02EmpTownPlace").innerText = response[0].EmpTownPlace;
                document.getElementById("lbl02EmpTownCode").innerText = response[0].EmpTownCode;
                document.getElementById("lbl02WorkYears").innerText = response[0].WorkYears;
                document.getElementById("lbl02Position").innerText = response[0].Position;
                document.getElementById("lbl02EmploymentTypeName").innerText = response[0].EmploymentTypeName;
                document.getElementById("lbl02MailingAddress").innerText = response[0].MailingAddress;
                document.getElementById("lbl02MailingCountryCodeName").innerText = response[0].MailingCountryCodeName;
                document.getElementById("lbl02MailingCityName").innerText = response[0].MailingCityName;
                document.getElementById("lbl02MailingTownPlace").innerText = response[0].MailingTownPlace;
                document.getElementById("lbl02MailingTownCode").innerText = response[0].MailingTownCode;
                //detail
            },
        });
    };
    function Load02() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Info-0302',
                'pID': pID,
            },
            success: function (response) {
                //detail
                document.getElementById("lbl02AcctCode").innerText = response[0].AcctCode;
                document.getElementById("lbl02SellerCodeName").innerText = response[0].SellerCodeName;
                document.getElementById("lbl02RFDate").innerText = response[0].RFDate;
                document.getElementById("lbl02FinancingSchemeName").innerText = response[0].FinancingSchemeName;
                document.getElementById("lbl02PmtTerm").innerText = response[0].PmtTerm;
                document.getElementById("lbl02Sellingprice").innerText = response[0].Sellingprice;
                document.getElementById("lbl02TCPDiscount").innerText = response[0].TCPDiscount;
                document.getElementById("lbl02VATDiscAmt").innerText = response[0].VATDiscAmt;
                document.getElementById("lbl02TCP").innerText = response[0].TCP;
                document.getElementById("lbl02VATAmount").innerText = response[0].VATAmount;
                document.getElementById("lbl02TCPNet").innerText = response[0].TCPNet;
                document.getElementById("lbl02DPAmount").innerText = response[0].DPAmount;
                document.getElementById("lbl02PromoDPDiscount").innerText = response[0].PromoDPDiscount;
                document.getElementById("lbl02RFAmount").innerText = response[0].RFAmount;
                document.getElementById("lbl02DPTerms").innerText = response[0].DPTerms;
                document.getElementById("lbl02MoDP").innerText = response[0].MoDP;
                document.getElementById("lbl02ExternalLoan").innerText = response[0].ExternalLoan;
                document.getElementById("lbl02InterestRate").innerText = response[0].InterestRate;
                document.getElementById("lbl02MATerms").innerText = response[0].MATerms;
                document.getElementById("lbl02MAAmt").innerText = response[0].MAAmt;
                document.getElementById("lbl02FirstMADue").innerText = response[0].FirstMADue;
                document.getElementById("lbl02Remarks").innerText = response[0].Remarks;
                //detail
            },
        });
    };
    function Load03() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Record-0303',
                'pID': pID,
            },
            success: function (response) {
                $('#table0303Record').DataTable().destroy();
                DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
                DataTable.datetime('MM/DD/YYYY');
                var table0303Record = $("#table0303Record").DataTable({
                    processing: true,
                    bFilter: true,
                    bPaginate: true,
                    bInfo: true,
                    paging: true,
                    lengthChange: false,
                    pageLength: 10,
                    select: true,
                    data: response,
                    columns: [
                        { data: 'Check' },
                        { data: 'Group' },
                        { data: 'Status' },
                        { data: 'Date' },
                        { data: 'Remarks' },
                        { data: 'UpdatedByName' },
                        { data: 'Blank' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, className: 'tbody-nowrap-auto' },
                        { targets: 2, className: 'tbody-nowrap-auto' },
                        { targets: 3, className: 'tbody-nowrap-auto' },
                        { targets: 4, className: 'tbody-nowrap-auto' },
                        { targets: 5, className: 'tbody-nowrap-auto' },
                        { targets: 6, orderable: false }],
                    order: [false],

                });
                $('#tbx0303Find').on('keyup', function () { table0303Record.search(this.value).draw(); });
            },
        });
    };
    function Load04() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Record-0304',
                'pID': pID,
            },
            success: function (response) {
                $('#table0304Record').DataTable().destroy();
                DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
                DataTable.datetime('MM/DD/YYYY');
                var table0304Record = $("#table0304Record").DataTable({
                    processing: true,
                    bFilter: true,
                    bPaginate: true,
                    bInfo: true,
                    paging: true,
                    lengthChange: false,
                    pageLength: 10,
                    select: true,
                    data: response,
                    columns: [
                        { data: 'Rcvd' },
                        { data: 'Type' },
                        { data: 'ReqDesc' },
                        { data: 'DocNo' },
                        { data: 'DocDate' },
                        { data: 'ExpDate' },
                        { data: 'Remarks' },
                        { data: 'ReceivedBy' },
                        { data: 'ReceivedDate' },
                        { data: 'Blank' }],
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
                        { targets: 9, orderable: false }],
                    order: [false],

                });
                $('#tbx0304Find').on('keyup', function () { table0304Record.search(this.value).draw(); });
            },
        });
    };
    function Load05() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Record-0305',
                'pID': pID,
            },
            success: function (response) {
                $('#table0305Record').DataTable().destroy();
                DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
                DataTable.datetime('MM/DD/YYYY');
                var table0305Record = $("#table0305Record").DataTable({
                    processing: true,
                    bFilter: true,
                    bPaginate: true,
                    bInfo: true,
                    paging: true,
                    lengthChange: false,
                    pageLength: 10,
                    select: true,
                    data: response,
                    columns: [
                        { data: 'Paid' },
                        { data: 'No' },
                        { data: 'DueDate' },
                        { data: 'Description' },
                        { data: 'Total' },
                        { data: 'Interest' },
                        { data: 'Principal' },
                        { data: 'Balance' },
                        { data: 'AmtPD2Pen' },
                        { data: 'AmtPD2Int' },
                        { data: 'AmtPD2Prin' },
                        { data: 'AmtPD2Bal' },
                        { data: 'Blank' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, className: 'dt-body-center' },
                        { targets: 2, className: 'tbody-nowrap-auto' },
                        { targets: 3, className: 'tbody-nowrap-auto' },
                        { targets: 4, className: 'dt-body-right', type: 'num' },
                        { targets: 5, className: 'dt-body-right', type: 'num' },
                        { targets: 6, className: 'dt-body-right', type: 'num' },
                        { targets: 7, className: 'dt-body-right', type: 'num' },
                        { targets: 8, className: 'dt-body-right', type: 'num' },
                        { targets: 9, className: 'dt-body-right', type: 'num' },
                        { targets: 10, className: 'dt-body-right', type: 'num' },
                        { targets: 11, className: 'dt-body-right', type: 'num' },
                        { targets: 12, orderable: false }],
                    order: [false],

                });
                $('#tbx0305Find').on('keyup', function () { table0305Record.search(this.value).draw(); });
            },
        });
    };
    function Load06() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Record-0306',
                'pID': pID,
            },
            success: function (response) {
                $('#table0306Record').DataTable().destroy();
                DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
                DataTable.datetime('MM/DD/YYYY');
                var table0306Record = $("#table0306Record").DataTable({
                    processing: true,
                    bFilter: true,
                    bPaginate: true,
                    bInfo: true,
                    paging: true,
                    lengthChange: false,
                    pageLength: 10,
                    select: true,
                    data: response,
                    columns: [
                        { data: 'No' },
                        { data: 'DocNo' },
                        { data: 'DocDate' },
                        { data: 'DocDesc' },
                        { data: 'Total' },
                        { data: 'Penalty' },
                        { data: 'Interest' },
                        { data: 'Principal' },
                        { data: 'Balance' },
                        { data: 'Blank' }],
                    rowId: 'rowId',
                    columnDefs: [
                        { targets: 0, orderable: false },
                        { targets: 1, className: 'dt-body-center' },
                        { targets: 2, className: 'dt-body-center' },
                        { targets: 3, className: 'tbody-nowrap-auto' },
                        { targets: 4, className: 'dt-body-right', type: 'num' },
                        { targets: 5, className: 'dt-body-right', type: 'num' },
                        { targets: 6, className: 'dt-body-right', type: 'num' },
                        { targets: 7, className: 'dt-body-right', type: 'num' },
                        { targets: 8, className: 'dt-body-right', type: 'num' },
                        { targets: 9, orderable: false }],
                    order: [false],

                });
                $('#tbx0306Find').on('keyup', function () { table0306Record.search(this.value).draw(); });
            },
        });
    };
    function Load07() {
        document.getElementById("a0307AAD002002").setAttribute("href", "AAD002002?pID=" + document.getElementById("hdn02ID").value);
    };
};
//detail

//attachment
function fn98Load(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Get-Record-98',
            'pFormCode': FormCode,
            'pID': pID,
        },
        success: function (response) {
            $('#table98Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table98Record = $("#table98Record").DataTable({
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
            $('#tbx98Find').on('keyup', function () { table98Record.search(this.value).draw(); });
        },
    });
};
function fn98Download(pFormCode, pID, pFileName) {
    fn01IfExist('calmardblive.dbo.ICR_Buyers', 'AcctNo', document.getElementById('hdn02ID').value, function (response) {
        if (response[0].oReturn == "1") {
            Download(pFormCode, pID, pFileName);
        } else {
            window.location.replace("MNU040100");
        };
    });
    function Download(pFormCode, pID, pFileName) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/MNU/MNU001000HND.ashx",
            data: {
                'pFunction': 'Download-Record-98',
                'pFormCode': pFormCode,
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                window.open('MNU020200?View=' + response[0].View);
            },
        });
    };
};
function fn98Delete(pFormCode, pID, pFileName) {
    //if exisit
    fn01IfExist('calmardblive.dbo.ICR_Buyers', 'AcctNo', document.getElementById('hdn02ID').value, function (response) {
        if (response[0].oReturn == "1") {
            Access(pFormCode, pID, pFileName);
        } else {
            window.location.replace("MNU040100");
        };
    });
    //access
    function Access(pFormCode, pID, pFileName) {
        fn01Access(FormCode, 'Delete', function (response) {
            if (response[0].oReturn == "1") {
                Delete_Question(pFormCode, pID, pFileName);
            } else {
                fn01AlertOnly('Access denied!', 'error', 'btn btn-danger');
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
            url: "Assets/Handler/MNU/MNU001000HND.ashx",
            data: {
                'pFunction': 'Delete-Record-98',
                'pFormCode': pFormCode,
                'pID': pID,
                'pFileName': pFileName,
            },
            success: function (response) {
                fn01AlertOnly('File successfully removed!', 'success', 'btn btn-success');
                fn98Load(pID);
            },
        });
    };
};
//attachment

//notes
function fn99Load(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Get-Record-99',
            'pFormCode': FormCode,
            'pID': pID,
        },
        success: function (response) {
            $('#table99Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table99Record = $("#table99Record").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                data: response,
                columns: [
                    { data: 'Notes' }],
                columnDefs: [{ targets: 0, orderable: false }],
                ordering: false
            });
            $('#tbx99Find').on('keyup', function () { table99Record.search(this.value).draw(); });
        },
    });
};
function fn99Add() {
    fn01IfExist('calmardblive.dbo.ICR_Buyers', 'AcctNo', document.getElementById('hdn02ID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            window.location.replace("MNU040100");
        };
    });
    function Add() {
        document.getElementById("tbx9901Note").value = "";
        document.getElementById("hdn99Mention").value = "";
        $('#mdl9901Notes').modal('show');
    };
};
function fn9901Add(Btn) {
    fn01IfExist('calmardblive.dbo.ICR_Buyers', 'AcctNo', document.getElementById('hdn02ID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add_Ok();
        } else {
            window.location.replace("MNU040100");
        };
    });
    async function Add_Ok() {
        Btn.disabled = true;
        Btn.setAttribute('data-kt-indicator', 'on');
        await fn9901Add_Await(Btn);
    }
};
function fn9901Add_Await(Btn) {
    return new Promise(resolve => {
        if (document.getElementById("tbx9901Note").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else {
            Add_Ok_Await();
        }
        function Add_Ok_Await() {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/MNU/MNU001000HND.ashx",
                data: {
                    'pFunction': 'Add-Record-99',
                    'pFormCode': FormCode,
                    'pID': document.getElementById('hdn02ID').value,
                    'pNotes': document.getElementById("tbx9901Note").value,
                    'pMention': document.getElementById("hdn99Mention").value,
                },
                success: function (response) {
                    fn01AlertOnly('Note successfully added.', 'success');
                    document.getElementById("tbx9901Note").value = "";
                    document.getElementById("hdn99Mention").value = "";
                    fn99Load(document.getElementById('hdn02ID').value);
                },
            });
        };
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        resolve();
    });
};
//notes


//Tools
function fn10001Tools() {
    fn01Access(FormCode, 'View', function (response) {
        if (response[0].oReturn == "1") {
            $('#mdl10001Tools').modal('show');
        } else {
            fn01AlertOnly('Access denied!','error','btn btn-danger')
        };
    });
};
//Tools