//form
var FormCodeHdr = 'AAD002000'
var FormCodeDtl = 'AAD002034'
//form

//attachment
var FileCount = 0;
//attachment

//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        var str = window.location.href;
        var url = new URL(str);
        document.getElementById("hdn02ID").value = url.searchParams.get("pID");
        document.getElementById("hdn03Mode").value = "DTL";
        fn02Load(document.getElementById("hdn02ID").value);
        fn01Plugins();
    });
    jQuery(function ($) {
        //date
        $('[data-kt-repeater="timepicker"]').flatpickr({
            enableTime: true,
            noCalendar: true,
            dateFormat: "h:i K"
        });
        $('[data-kt-repeater="datepicker"]').flatpickr({
            dateFormat: "m/d/Y"
        });
        //date
    });
};
//master

//page
function fn02Refresh() {
    fn02Load(document.getElementById("hdn02ID").value);
};
function fn02Load(pID) {
    fn01Access(FormCodeHdr, 'View', function (response) {
        if (response[0].oReturn == "1") {
            LoadHeader(pID);
            LoadBody(pID);
        } else {
            location.replace("MNU000022");
        };
    });
    function LoadHeader(pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002001HND.ashx",
            data: {
                'pFunction': 'Get-Info-02',
                'pID': pID
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
    function LoadBody(pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002034HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID
            },
            success: function (response) {
                if (document.getElementById("hdn03Mode").value == "DTL") {

                    //toolbar
                    fn03DisableButtons(false);
                    document.getElementById("i03Edit").classList.add("la-pencil-alt");
                    document.getElementById("i03Edit").classList.remove("la-save");
                    //toolbar

                    //content
                    document.getElementById("div03Detail").style.display = "";
                    document.getElementById("div03Update").style.display = "none";
                    document.getElementById("lbl03TODate").innerText = response[0].TODate ? response[0].TODate : "-";
                    document.getElementById("tbx03Time").value = "";
                    //content

                } else if (document.getElementById("hdn03Mode").value == "UPD") {

                    //toolbar
                    fn03DisableButtons(true);
                    document.getElementById("btn03Delete").classList.add("btn-delete");
                    document.getElementById("btn03Delete").disabled = false;
                    document.getElementById("btn03Edit").classList.add("btn-edit");
                    document.getElementById("btn03Edit").disabled = false;
                    document.getElementById("i03Edit").classList.remove("la-pencil-alt");
                    document.getElementById("i03Edit").classList.add("la-save");
                    //toolbar

                    //content
                    document.getElementById("div03Detail").style.display = "none";
                    document.getElementById("div03Update").style.display = "";
                    document.getElementById("tbx03TODate").value = response[0].TODate;
                    document.getElementById("tbx03Time").value = "";
                    //content

                };
            }
        });
    };
};
//page

//record
function fn03DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn03Refresh").classList.remove("btn-view");
        document.getElementById("btn03Delete").classList.remove("btn-delete");
        document.getElementById("btn03Delete").classList.remove("d-none");
        document.getElementById("btn03Edit").classList.remove("btn-edit");
        document.getElementById("btn03Send").classList.add("d-none");
    } else {
        document.getElementById("btn03Refresh").classList.add("btn-view");
        document.getElementById("btn03Delete").classList.add("btn-delete");
        document.getElementById("btn03Delete").classList.add("d-none");
        document.getElementById("btn03Edit").classList.add("btn-edit");
        document.getElementById("btn03Send").classList.remove("d-none");
    }
    document.getElementById("btn03Refresh").disabled = pValue;
    document.getElementById("btn03Delete").disabled = pValue;
    document.getElementById("btn03Edit").disabled = pValue;
};
function fn03Refresh() {
    fn02Load(document.getElementById("hdn02ID").value);
};
function fn03Delete() {
    if (document.getElementById("hdn03Mode").value == "UPD") {
        Cancel_Upd_Question(document.getElementById('hdn02ID').value);
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
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn02Load(document.getElementById('hdn03ID').value);
            }
        });
    };
};
function fn03Edit() {
    if (document.getElementById("hdn03Mode").value == "DTL") {
        //access
        fn01Access(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                Edit_Dtl_Ok_Await(document.getElementById('hdn02ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
    } else if (document.getElementById("hdn03Mode").value == "UPD") {
        //access
        fn01Access(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                ValidateFields(document.getElementById('hdn02ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
    };
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx03TODate").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else {
            Edit_Question(ID);
        }
    };
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
                if (document.getElementById('hdn03Mode').value == "DTL") {
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('hdn03Mode').value == "UPD") {
                    Edit_Upd_Ok_Await(ID);
                }
            }
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById("hdn03ID").value = ID;
        document.getElementById('hdn03Mode').value = "UPD"
        fn02Load(document.getElementById('hdn03ID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/handler/AAD/AAD002034HND.ashx",
            data: {
                'pFunction': 'Update-Record-03',
                'pAcctNo': document.getElementById("hdn02ID").value,
                'pTODate': document.getElementById("tbx03TODate").value
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn02Load(document.getElementById('hdn03ID').value);
            },
        });
    };
};
function fn03Send() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002034HND.ashx",
        data: {
            'pFunction': 'Send-Record-03',
            'pAcctNo': document.getElementById("hdn02ID").value,
            'pTODate': document.getElementById("lbl03TODate").innerText,
            'pTime': document.getElementById("tbx03Time").value
        },
        beforeSend: function () {
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });
        },
        success: function (response) {
            Swal.close();
            fn01AlertOnly('Schedule sent!', 'success');
            document.getElementById("tbx03TODate").value = "";
            document.getElementById("tbx03Time").value = "";
        },
        error: function (xhr, status, error) {
            Swal.close();
            fn01AlertOnly(error, 'error');
        }
    });
};
//record