//form
var FormCode = 'AAD002000'
var FormCodeDtl = 'AAD002031'

let setCity = '';
let setTown = '';
let setEmpCity = '';
let setEmpTown = '';
let setMailCity = '';
let setMailTown = '';
//form

//format
function fn01EnterKeyNumber(event, inputId) {
    const key = event.key;
    // Allow only the following keys: numbers (0-9), decimal point, backspace, delete, arrow keys
    if (
        (key >= '0' && key <= '9') ||    // Allow 0-9
        key === '.' ||                   // Allow decimal point
        key === 'Backspace' ||           // Allow backspace
        key === 'ArrowLeft' ||           // Allow left arrow key
        key === 'ArrowRight' ||          // Allow right arrow key
        key === 'ArrowUp' ||             // Allow up arrow key
        key === 'ArrowDown' ||           // Allow down arrow key
        key === 'Delete'                 // Allow delete key
    ) {
        return true; // Allow the key press
    };
    // Prevent any other keys (including letters and special characters)
    event.preventDefault();
    return false;
};
//format

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
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
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
                ddl02House(response[0].ModelCode, response[0].ProjInit, response[0].Phase, response[0].Block, response[0].Lot);
                document.getElementById("tbx02HouseSpec").value = response[0].HouseSpec;
                document.getElementById("hdn02Type").value = response[0].ProjInit;
                document.getElementById("hdn02Phase").value = response[0].Phase;
                document.getElementById("hdn02Block").value = response[0].Block;
                document.getElementById("hdn02Lot").value = response[0].Lot;
                //detail
            },
        });
        function ddl02House(ID, Type, Phase, Block, Lot) {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/AAD/AAD002031HND.ashx",
                data: {
                    'pFunction': 'Get-Info-0202',
                    'pType': Type,
                    'pPhase': Phase,
                    'pBlock': Block,
                    'pLot': Lot,
                    'pTblName': 'mstr_HouseModels(LotFit)',
                    'pPlaceHolder': 'House Model'
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    };
                    $("#ddl02HouseModel").html(s);
                    $('#ddl02HouseModel').val(ID).trigger('change');
                }
            });
        };
    };
};
function fn02Refresh() {
    fn02Load();
};
//page

//detail
function fn03Load(pID) {
    Load01();
    function Load01() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0301',
                'pID': pID,
            },
            success: function (response) {
                //mode
                if (document.getElementById("hdn02Mode").value == "DTL") {

                    //toolbar
                    fn03DisableButtons(false);
                    document.getElementById("i02Edit").classList.add("la-pencil-alt");
                    document.getElementById("i02Edit").classList.remove("la-save");
                    //toolbar

                    //detail
                    document.getElementById("div02Detail").style.display = "";
                    document.getElementById("div02HeaderDtl").style.display = "";
                    document.getElementById("div02Update").style.display = "none";
                    document.getElementById("div02HeaderUpd").style.display = "none";
                    document.getElementById("div02HeaderUpdSpec").style.display = "none";
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
                    document.getElementById("lbl02HomeTownPlace").innerText = response[0].HomeTownCode ? response[0].HomeTownPlace : "";
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
                    document.getElementById("lbl02EmpTownPlace").innerText = response[0].EmpTownCode ? response[0].EmpTownPlace : "";
                    document.getElementById("lbl02EmpTownCode").innerText = response[0].EmpTownCode;
                    document.getElementById("lbl02WorkYears").innerText = response[0].WorkYears;
                    document.getElementById("lbl02Position").innerText = response[0].Position;
                    document.getElementById("lbl02EmploymentTypeName").innerText = response[0].EmploymentTypeName;
                    document.getElementById("lbl02MailingAddress").innerText = response[0].MailingAddress;
                    document.getElementById("lbl02MailingCountryCodeName").innerText = response[0].MailingCountryCodeName;
                    document.getElementById("lbl02MailingCityName").innerText = response[0].MailingCityName;
                    document.getElementById("lbl02MailingTownPlace").innerText = response[0].MailingTownCode ? response[0].MailingTownPlace : "";
                    document.getElementById("lbl02MailingTownCode").innerText = response[0].MailingTownCode;
                    //detail

                } else if (document.getElementById("hdn02Mode").value == "UPD") {

                    //toolbar
                    fn03DisableButtons(true);
                    document.getElementById("btn02Delete").classList.add("btn-delete");
                    document.getElementById("btn02Delete").disabled = false;
                    document.getElementById("btn02Edit").classList.add("btn-edit");
                    document.getElementById("btn02Edit").disabled = false;
                    document.getElementById("i02Edit").classList.remove("la-pencil-alt");
                    document.getElementById("i02Edit").classList.add("la-save");
                    //toolbar

                    //bind
                    setCity = response[0].HomeCityName ? response[0].HomeCityCode : "";
                    setTown = response[0].HomeTownCode;
                    setEmpCity = response[0].EmpCityName ? response[0].EmpCityCode : "";
                    setEmpTown = response[0].EmpTownCode;
                    setMailCity = response[0].MailingCityName ? response[0].MailingCityCode : "";
                    setMailTown = response[0].MailingTownCode;
                    //bind

                    //detail
                    document.getElementById("div02Detail").style.display = "none";
                    document.getElementById("div02HeaderDtl").style.display = "none";
                    document.getElementById("div02Update").style.display = "";
                    document.getElementById("div02HeaderUpd").style.display = "";
                    document.getElementById("div02HeaderUpdSpec").style.display = "";
                    ddl02AcctType(response[0].ContractType);
                    document.getElementById("tbx02AcctName").value = response[0].FullName;
                    document.getElementById("tbx02LastName").value = response[0].LastName;
                    document.getElementById("tbx02FirstName").value = response[0].FirstName;
                    document.getElementById("tbx02MiddleName").value = response[0].MiddleName;
                    document.getElementById("tbx02Suffix").value = response[0].Suffix;
                    document.getElementById("tbx02BirthDate").value = response[0].BirthDate;
                    response[0].GenderName ? $('#ddl02Gender').val(response[0].Gender).trigger('change') : $('#ddl02Gender').val('').trigger('change');
                    response[0].CivilStatusName ? $('#ddl02CivilStatus').val(response[0].CivilStatus).trigger('change') : $('#ddl02CivilStatus').val('').trigger('change');
                    document.getElementById("tbx02Address").value = response[0].HomeAddress;
                    response[0].HomeCountryName ? ddl02Country(response[0].HomeCountryCode) : ddl02Country('');
                    document.getElementById("tbx02YearOfStay").value = response[0].YearsofStay;
                    response[0].CitizenshipName ? ddl02Citizenship(response[0].CitizenshipCode) : ddl02Citizenship('');
                    response[0].OwnershipName ? ddl02Ownership(response[0].Ownership) : ddl02Ownership('');
                    document.getElementById("tbx02Email").value = response[0].Emailaddress;
                    document.getElementById("tbx02MobileNo").value = response[0].MobileNo;
                    document.getElementById("tbx02TIN").value = response[0].TIN;
                    document.getElementById("tbx02SSS").value = response[0].SSS;
                    document.getElementById("tbx02UMID").value = response[0].UMID
                    document.getElementById("tbx02Employer").value = response[0].Employer;
                    document.getElementById("tbx02EmpAddress").value = response[0].EmployerAddress;
                    response[0].EmpCountryName ? ddl02EmpCountry(response[0].EmpCountryCode) : ddl02EmpCountry('');
                    document.getElementById("tbx02EmpStay").value = response[0].WorkYears;
                    document.getElementById("tbx02EmpPosition").value = response[0].Position;
                    response[0].EmploymentTypeName ? ddl02EmpType(response[0].EmploymentType) : ddl02EmpType('');
                    document.getElementById("tbx02MailAddress").value = response[0].MailingAddress;
                    response[0].MailingCountryCodeName ? ddl02MailCountry(response[0].MailingCountryCode) : ddl02MailCountry('');
                    //detail

                };
            },
        });
    };
    function ddl02AcctType(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0201',
                'pID': '',
                'pType': '',
                'pTblName': "Mstr_ContractTypes",
                'pPlaceHolder': 'Type'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                };
                $("#ddl02AcctType").html(s);
                $('#ddl02AcctType').val(ID).trigger('change');
            }
        });
    };
    function ddl02Citizenship(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0201',
                'pID': '',
                'pType': '',
                'pTblName': "Mstr_Citizenship",
                'pPlaceHolder': 'Citizenship'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                };
                $("#ddl02Citizenship").html(s);
                $('#ddl02Citizenship').val(ID).trigger('change');
            }
        });
    };
    function ddl02Country(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0201',
                'pID': '',
                'pType': '',
                'pTblName': "Mstr_Countries",
                'pPlaceHolder': 'Country'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                };
                $("#ddl02Country").html(s);
                $('#ddl02Country').val(ID).trigger('change');
            }
        });
    };
    function ddl02EmpCountry(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0201',
                'pID': '',
                'pType': '',
                'pTblName': "Mstr_Countries",
                'pPlaceHolder': 'Country'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                };
                $("#ddl02EmpCountry").html(s);
                $('#ddl02EmpCountry').val(ID).trigger('change');
            }
        });
    };
    function ddl02EmpType(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0201',
                'pID': '',
                'pType': '',
                'pTblName': "Mstr_EmploymentType",
                'pPlaceHolder': 'Type'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                };
                $("#ddl02EmpType").html(s);
                $('#ddl02EmpType').val(ID).trigger('change');
            }
        });
    };
    function ddl02MailCountry(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Get-Info-0201',
                'pID': '',
                'pType': '',
                'pTblName': "Mstr_Countries",
                'pPlaceHolder': 'Country'
            },
            success: function (response) {
                var s = '';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                };
                $("#ddl02MailCountry").html(s);
                $('#ddl02MailCountry').val(ID).trigger('change');
            }
        });
    };
};
function ddl02Country_onchange(ddl02Country) {
    document.getElementById("ddl02City").disabled = true;
    $('#ddl02City').val('').trigger('change');
    $('#ddl02Town').val('').trigger('change');
    $("#tbx02ZipCode").val('');
    if (ddl02Country.options[ddl02Country.selectedIndex].value != "") {
        ddl02City(ddl02Country.options[ddl02Country.selectedIndex].value, setCity);
        document.getElementById("ddl02City").disabled = false;
        setCity = '';
    };
};
function ddl02City_onchange(ddl02City) {
    document.getElementById("ddl02Town").disabled = true;
    $('#ddl02Town').val('').trigger('change');
    $("#tbx02ZipCode").val('');
    if (ddl02City.options[ddl02City.selectedIndex].value != "") {
        ddl02Town(ddl02City.options[ddl02City.selectedIndex].value, setTown);
        document.getElementById("ddl02Town").disabled = false;
        setTown = '';
    };
};
function ddl02Town_onchange(ddl02Town) {
    if (ddl02Town.options[ddl02Town.selectedIndex].value != "") {
        document.getElementById("tbx02ZipCode").value = ddl02Town.options[ddl02Town.selectedIndex].value;
    };
};
function ddl02City(pCountry, ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': pCountry,
            'pType': '',
            'pTblName': 'Mstr_Cities',
            'pPlaceHolder': 'City'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02City").html(s);
            $('#ddl02City').val(ID).trigger('change');
        }
    });
};
function ddl02Town(pTown, ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': pTown,
            'pType': document.getElementById("ddl02Country").value,
            'pTblName': 'Mstr_ZipCodes',
            'pPlaceHolder': 'Town'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02Town").html(s);
            $('#ddl02Town').val(ID).trigger('change');
        }
    });
};
function ddl02Ownership(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': '',
            'pType': '',
            'pTblName': "Mstr_HomeOwnership",
            'pPlaceHolder': 'Ownership'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02Ownership").html(s);
            $('#ddl02Ownership').val(ID).trigger('change');
        }
    });
};
function ddl02EmpCountry_onchange(ddl02EmpCountry) {
    document.getElementById("ddl02EmpCity").disabled = true;
    $('#ddl02EmpCity').val('').trigger('change');
    $('#ddl02EmpTown').val('').trigger('change');
    $("#tbx02EmpZipCode").val('');
    if (ddl02EmpCountry.options[ddl02EmpCountry.selectedIndex].value != "") {
        ddl02EmpCity(ddl02EmpCountry.options[ddl02EmpCountry.selectedIndex].value, setEmpCity);
        document.getElementById("ddl02EmpCity").disabled = false;
        setEmpCity = '';
    };
};
function ddl02EmpCity_onchange(ddl02EmpCity) {
    document.getElementById("ddl02EmpTown").disabled = true;
    $('#ddl02EmpTown').val('').trigger('change');
    $("#tbx02EmpZipCode").val('');
    if (ddl02EmpCity.options[ddl02EmpCity.selectedIndex].value != "") {
        ddl02EmpTown(ddl02EmpCity.options[ddl02EmpCity.selectedIndex].value, setEmpTown);
        document.getElementById("ddl02EmpTown").disabled = false;
        setEmpTown = '';
    };
};
function ddl02EmpTown_onchange(ddl02EmpTown) {
    if (ddl02EmpTown.options[ddl02EmpTown.selectedIndex].value != "") {
        document.getElementById("tbx02EmpZipCode").value = ddl02EmpTown.options[ddl02EmpTown.selectedIndex].value;
    };
};
function ddl02EmpCity(pEmpCountry, ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': pEmpCountry,
            'pType': '',
            'pTblName': 'Mstr_Cities',
            'pPlaceHolder': 'City'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02EmpCity").html(s);
            $('#ddl02EmpCity').val(ID).trigger('change');
        }
    });
};
function ddl02EmpTown(pEmpTown, ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': pEmpTown,
            'pType': document.getElementById("ddl02EmpCountry").value,
            'pTblName': 'Mstr_ZipCodes',
            'pPlaceHolder': 'Town'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02EmpTown").html(s);
            $('#ddl02EmpTown').val(ID).trigger('change');
        }
    });
};

function ddl02MailCountry_onchange(ddl02MailCountry) {
    document.getElementById("ddl02MailCity").disabled = true;
    $('#ddl02MailCity').val('').trigger('change');
    $('#ddl02MailTown').val('').trigger('change');
    $("#tbx02MailZipCode").val('');
    if (ddl02MailCountry.options[ddl02MailCountry.selectedIndex].value != "") {
        ddl02MailCity(ddl02MailCountry.options[ddl02MailCountry.selectedIndex].value, setMailCity);
        document.getElementById("ddl02MailCity").disabled = false;
        setMailCity = '';
    };
};
function ddl02MailCity_onchange(ddl02MailCity) {
    document.getElementById("ddl02MailTown").disabled = true;
    $('#ddl02MailTown').val('').trigger('change');
    $("#tbx02MailZipCode").val('');
    if (ddl02MailCity.options[ddl02MailCity.selectedIndex].value != "") {
        ddl02MailTown(ddl02MailCity.options[ddl02MailCity.selectedIndex].value, setMailTown);
        document.getElementById("ddl02MailTown").disabled = false;
        setMailTown = '';
    };
};
function ddl02MailTown_onchange(ddl02MailTown) {
    if (ddl02MailTown.options[ddl02MailTown.selectedIndex].value != "") {
        document.getElementById("tbx02MailZipCode").value = ddl02MailTown.options[ddl02MailTown.selectedIndex].value;
    };
};
function ddl02MailCity(pMailCountry, ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': pMailCountry,
            'pType': '',
            'pTblName': 'Mstr_Cities',
            'pPlaceHolder': 'City'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02MailCity").html(s);
            $('#ddl02MailCity').val(ID).trigger('change');
        }
    });
};
function ddl02MailTown(pMailTown, ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/AAD/AAD002031HND.ashx",
        data: {
            'pFunction': 'Get-Info-0201',
            'pID': pMailTown,
            'pType': document.getElementById("ddl02MailCountry").value,
            'pTblName': 'Mstr_ZipCodes',
            'pPlaceHolder': 'Town'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            };
            $("#ddl02MailTown").html(s);
            $('#ddl02MailTown').val(ID).trigger('change');
        }
    });
};
function fn03DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn02Refresh").classList.remove("btn-view");
        document.getElementById("btn02Delete").classList.remove("btn-delete");
        document.getElementById("btn02Delete").classList.remove("d-none");
        document.getElementById("btn02Edit").classList.remove("btn-edit");
    } else {
        document.getElementById("btn02Refresh").classList.add("btn-view");
        document.getElementById("btn02Delete").classList.add("btn-delete");
        document.getElementById("btn02Delete").classList.add("d-none");
        document.getElementById("btn02Edit").classList.add("btn-edit");
    }
    document.getElementById("btn02Refresh").disabled = pValue;
    document.getElementById("btn02Delete").disabled = pValue;
    document.getElementById("btn02Edit").disabled = pValue;
};
function fn02Edit() {
    if (document.getElementById("hdn02Mode").value == "DTL") {
        //access
        fn01Access(FormCodeDtl, 'Save', function (response) {
            if (response[0].oReturn == "1") {
                Edit_Dtl_Ok_Await(document.getElementById('hdn02ID').value);
            } else {
                fn01AlertOnly('Access denied!', 'error');
            };
        });
    } else if (document.getElementById("hdn02Mode").value = "UPD") {
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
        if (document.getElementById("ddl02AcctType").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx02AcctName").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx02LastName").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error');
        } else if (document.getElementById("tbx02FirstName").value == "") {
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
                if (document.getElementById('hdn02Mode').value == "ADD") {
                    Edit_Add_Ok_Await();
                } else if (document.getElementById('hdn02Mode').value == "DTL") {
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('hdn02Mode').value == "UPD") {
                    Edit_Upd_Ok_Await(ID);
                }
            }
        });
    };
    //do edit
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('hdn02Mode').value = "UPD"
        document.getElementById('hdn02ID').value = ID
        document.getElementById('hdn02IDPrev').value = ID
        fn03Load(document.getElementById('hdn02ID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/handler/AAD/AAD002031HND.ashx",
            data: {
                'pFunction': 'Update-Record-03',
                'pAcctNo': ID,
                'pModelCode': document.getElementById("ddl02HouseModel").value,
                'pHouseSpec': document.getElementById("tbx02HouseSpec").value,
                'pContractType': document.getElementById("ddl02AcctType").value,
                'pAcctName': document.getElementById("tbx02AcctName").value,
                'pFirstName': document.getElementById("tbx02FirstName").value,
                'pLastName': document.getElementById("tbx02LastName").value,
                'pMiddleName': document.getElementById("tbx02MiddleName").value,
                'pSuffix': document.getElementById("tbx02Suffix").value,
                'pHomeAddress': document.getElementById("tbx02Address").value,
                'pHomeCountryCode': document.getElementById("ddl02Country").value,
                'pHomeCityCode': document.getElementById("ddl02City").value,
                'pHomeTownPlace': document.getElementById("ddl02Town").options[document.getElementById("ddl02Town").selectedIndex].text,
                'pHomeTownCode': document.getElementById("ddl02Town").value,
                'pYearsofStay': document.getElementById("tbx02YearOfStay").value,
                'pOwnership': document.getElementById("ddl02Ownership").value,
                'pEmailAddress': document.getElementById("tbx02Email").value,
                'pMobileNo': document.getElementById("tbx02MobileNo").value,
                'pMobileNo': document.getElementById("tbx02MobileNo").value,
                'pBirthDate': document.getElementById("tbx02BirthDate").value,
                'pGender': document.getElementById("ddl02Gender").value,
                'pCitizenship': document.getElementById("ddl02Citizenship").value,
                'pCivilStatus': document.getElementById("ddl02CivilStatus").value,
                'pTIN': document.getElementById("tbx02TIN").value,
                'pSSS': document.getElementById("tbx02SSS").value,
                'pUMID': document.getElementById("tbx02UMID").value,
                'pEmployer': document.getElementById("tbx02Employer").value,
                'pEmployerAddress': document.getElementById("tbx02EmpAddress").value,
                'pEmpCountryCode': document.getElementById("ddl02EmpCountry").value,
                'pEmpCityCode': document.getElementById("ddl02EmpCity").value,
                'pEmpTownPlace': document.getElementById("ddl02EmpTown").options[document.getElementById("ddl02EmpTown").selectedIndex].text,
                'pEmpTownCode': document.getElementById("ddl02EmpTown").value,
                'pWorkYears': document.getElementById("tbx02EmpStay").value,
                'pPosition': document.getElementById("tbx02EmpPosition").value,
                'pEmploymentType': document.getElementById("ddl02EmpType").value,
                'pMailingAddress': document.getElementById("tbx02MailAddress").value,
                'pMailingCountryCode': document.getElementById("ddl02MailCountry").value,
                'pMailingCityCode': document.getElementById("ddl02MailCity").value,
                'pMailingTownPlace': document.getElementById("ddl02MailTown").options[document.getElementById("ddl02MailTown").selectedIndex].text,
                'pMailingTownCode': document.getElementById("ddl02MailTown").value
            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                document.getElementById('hdn02Mode').value = "DTL"
                document.getElementById('hdn02ID').value = ID
                document.getElementById('hdn02IDPrev').value = ID
                fn03Load(document.getElementById('hdn02ID').value);
            },
        });
    };
};
function fn02Delete() {
    if (document.getElementById("hdn02Mode").value == "UPD") {
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
                document.getElementById('hdn02Mode').value = "DTL"
                document.getElementById('hdn02ID').value = ID
                document.getElementById('hdn02IDPrev').value = ID
                fn03Load(document.getElementById('hdn02ID').value);
            }
        });
    };
};
//detail


//Tools
function fn10001Tools() {
    fn01Access(FormCode, 'View', function (response) {
        if (response[0].oReturn == "1") {
            $('#mdl10001Tools').modal('show');
        } else {
            fn01AlertOnly('Access denied!', 'error', 'btn btn-danger')
        };
    });
};
//Tools